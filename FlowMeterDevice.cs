using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySCADA
{
    public class FlowMeterDevice
    {
        public int ID { get; set; }
        public ModbusClient Client { get; set; }

        //Dữ liệu nhận về 
        public float Voltage { get; set; }
        public float Current { get; set; }
        public float Vab { get; set; }
        public float Vbc { get; set; }
        public float Vca { get; set; }
        public float Ia { get; set; }
        public float Ib { get; set; }
        public float Ic { get; set; }
        public float P { get; set; }
        public float Q { get; set; }
        public float PF { get; set; }
        public float E { get; set; }


    public FlowMeterDevice(int id, string ipAddress, int port)
        {
            ID = id;
            Client = new ModbusClient(ipAddress, port);
            Client.ConnectionTimeout = 1000; // Thiết lập thời gian chờ kết nối (ms)
        }

    public void Connect()
        {
            if (!Client.Connected)
            {
                Client.Connect();
            }
        }
        public void Disconnect()
        {
            if (Client.Connected)
            {
                Client.Disconnect();
            }
        }
        public void ReadData()
        {
            try
            {
                Connect();
                int startAddress = 0;
                int numRegisters = 24;
                // Đọc các thanh ghi từ thiết bị
                int[] registers = Client.ReadHoldingRegisters(startAddress, numRegisters);
                // Chuyển đổi dữ liệu từ thanh ghi sang giá trị thực tế
                Voltage = ConvertRegistersToFloat(registers[0], registers[1]);
                Current = ConvertRegistersToFloat(registers[2], registers[3]);
                Vab = ConvertRegistersToFloat(registers[4], registers[5]);
                Vbc = ConvertRegistersToFloat(registers[6], registers[7]);
                Vca = ConvertRegistersToFloat(registers[8], registers[9]);
                Ia = ConvertRegistersToFloat(registers[10], registers[11]);
                Ib = ConvertRegistersToFloat(registers[12], registers[13]);
                Ic = ConvertRegistersToFloat(registers[14], registers[15]);
                P = ConvertRegistersToFloat(registers[16], registers[17]);
                Q = ConvertRegistersToFloat(registers[18], registers[19]);
                PF = ConvertRegistersToFloat(registers[20], registers[21]);
                E = ConvertRegistersToFloat(registers[22], registers[23]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đọc dữ liệu từ FlowMeter ID {ID}: {ex.Message}");
            }
        }
        private float ConvertRegistersToFloat(int highRegister, int lowRegister)
        {
            byte[] bytes = new byte[4];
            bytes[0] = (byte)(lowRegister >> 8);
            bytes[1] = (byte)(lowRegister & 0xFF);
            bytes[2] = (byte)(highRegister >> 8);
            bytes[3] = (byte)(highRegister & 0xFF);
            return BitConverter.ToSingle(bytes, 0);
        }


    }
}
