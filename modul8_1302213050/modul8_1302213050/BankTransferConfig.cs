using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_1302213050
{
    public class BankTransferConfig
    {
        public BankTranfer Config;

        private const string filePath = "C:\\Users\\Yoga Elfaraby\\Documents\\GitHub\\modul8_1302213050\\";
        private const string fileLocation = filePath + "bank_transfer_config.json";

        public BankTransferConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
        private BankTranfer ReadConfigFile()
        {
            string hasilBaca = File.ReadAllText(fileLocation);
            Config = JsonSerializer.Deserialize<BankTranfer>(hasilBaca);
            return Config;
        }
        private void SetDefault()
        {
            string lang = "en";
            Transfer transfer = new Transfer(1000000, 6500, 19500);
            List<string> methods = new List<string>();
            methods.Add("RTO (real-time)");
            methods.Add("SKN");
            methods.Add("RTGS");
            methods.Add("BI FAST");
            Confirmation confirmation = new Confirmation("yes", "ya");
            Config = new BankTranfer(lang, transfer, methods, confirmation);
        }
        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            string textTulis = JsonSerializer.Serialize(Config, options);
            File.WriteAllText(fileLocation, textTulis);

        }
        
    }
}
