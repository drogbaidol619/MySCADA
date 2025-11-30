using EasyModbus;
using System;
using System.Collections.Generic;
using System.Timers;

namespace MySCADA
{
    public class FlowMeterSystem
    {
        private ModbusClient modbusClient;
        private Timer updateTimer;
        public List<FlowMeter> Meters = new List<FlowMeter>();

        // "Ổ khóa" để đồng bộ luồng
        public object Semaphore = new object();

        public FlowMeterSystem(string ip, int port = 502)
        {
            for (int i = 1; i <= 10; i++)
            {
                Meters.Add(new FlowMeter($"Meter_{i}", i));
            }

            // 2. Cấu hình EasyModbus
            modbusClient = new ModbusClient(ip, port);
            modbusClient.ConnectionTimeout = 1000;

            Connect();

            // 3. Khởi tạo Timer đọc (1 giây/lần)
            updateTimer = new Timer(1000);
            updateTimer.Elapsed += UpdateTimer_Elapsed;
            updateTimer.Start();
        }

        private void Connect()
        {
            try
            {
                if (!modbusClient.Connected)
                {
                    modbusClient.Connect();
                    Console.WriteLine("Đã kết nối Modbus Gateway.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối Modbus: {ex.Message}");
            }
        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (Semaphore)
            {
                try
                {
                    if (!modbusClient.Connected)
                    {
                        modbusClient.Connect();
                        return;
                    }

                    // --- VÒNG LẶP QUÉT TỪNG THIẾT BỊ ---
                    foreach (var meter in Meters)
                    {
                        modbusClient.UnitIdentifier = (byte)meter.UnitId;

                        // Đọc 24 thanh ghi
                        int[] registers = modbusClient.ReadInputRegisters(0, 24);

                        meter.Voltage = ConvertToFloat(registers[0], registers[1]);
                        meter.Vab = ConvertToFloat(registers[2], registers[3]);
                        meter.Vbc = ConvertToFloat(registers[4], registers[5]);
                        meter.Vca = ConvertToFloat(registers[6], registers[7]);
                        meter.Current = ConvertToFloat(registers[8], registers[9]);
                        meter.Ia = ConvertToFloat(registers[10], registers[11]);
                        meter.Ib = ConvertToFloat(registers[12], registers[13]);
                        meter.Ic = ConvertToFloat(registers[14], registers[15]);
                        meter.P = ConvertToFloat(registers[16], registers[17]);
                        meter.Q = ConvertToFloat(registers[18], registers[19]);
                        meter.PF = ConvertToFloat(registers[20], registers[21]);
                        meter.E = ConvertToFloat(registers[22], registers[23]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc Modbus: {ex.Message}");
                    if (modbusClient.Connected) modbusClient.Disconnect();
                }
            }
        }

        // Hàm này ghép 2 thanh ghi 16-bit (int) thành 1 số thực (float)
        private float ConvertToFloat(int reg1, int reg2)
        {
            // 1. Lấy byte từ thanh ghi 1
            byte[] bytes1 = BitConverter.GetBytes((short)reg1);
            // 2. Lấy byte từ thanh ghi 2
            byte[] bytes2 = BitConverter.GetBytes((short)reg2);

            // 3. Tạo mảng 4 byte cho số Float
            byte[] floatBytes = new byte[4];

            // Cách ghép mới: Đưa reg2 lên đầu
            floatBytes[0] = bytes2[0]; // Byte thấp của Reg 2
            floatBytes[1] = bytes2[1]; // Byte cao của Reg 2
            floatBytes[2] = bytes1[0]; // Byte thấp của Reg 1
            floatBytes[3] = bytes1[1]; // Byte cao của Reg 1

            return BitConverter.ToSingle(floatBytes, 0);
        }
    }
}