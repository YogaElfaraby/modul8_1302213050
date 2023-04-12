using modul8_1302213050;

internal class Program
{
    private static void Main(string[] args)
    {
        BankTransferConfig bankTransferYoga = new BankTransferConfig();
        string language = bankTransferYoga.Config.lang;

        if (language == "id" || language == "en")
        {
            if (language == "en")
            {
                Console.Write("Please insert the amount of money to transfer: ");
            }
            else if (language == "id")
            {
                Console.Write("Masukkan jumlah uang yang akan di-transfer: ");
            }

            int jumlah = Convert.ToInt32(Console.ReadLine());
            int biaya;  
            if (jumlah <= bankTransferYoga.Config.transfer.threshold)
            {
                biaya = bankTransferYoga.Config.transfer.low_fee;
            }
            else
            {
                biaya = bankTransferYoga.Config.transfer.high_fee;
            }

            int total = jumlah + biaya;

            if (language == "en")
            {
                Console.WriteLine("Transfer fee = " + biaya);
                Console.WriteLine("Total amount = " + total);
            }
            else if (language == "id")
            {
                Console.WriteLine("Biaya transfer = " + biaya);
                Console.WriteLine("Total biaya = " + total);
            }

            if (language == "en")
            {
                Console.WriteLine("Select tranfer method:");
            }
            else if (language == "id")
            {
                Console.WriteLine("Pilih metode transfer:");
            }

            for (int i = 0; i < bankTransferYoga.Config.methods.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + bankTransferYoga.Config.methods[i]);
            }
            Console.WriteLine("Ketik: ");
            string metode = Console.ReadLine();

            if (language == "en")
            {
                Console.WriteLine("Please type " + bankTransferYoga.Config.confirmation.en +
                    " to confirm the transaction: ");
            }
            else if (language == "id")
            {
                Console.WriteLine("Ketik " + bankTransferYoga.Config.confirmation.id +
                    " untuk mengkonfirmasi transaksi: ");
            }
            string konfirmasi = Console.ReadLine();

            if (language == "en")
            {
                if (konfirmasi == bankTransferYoga.Config.confirmation.en)
                {
                    Console.WriteLine("The transfer is completed");
                }
                else
                {
                    Console.WriteLine("Transfer is cancelled");
                }
            }
            else if (language == "id")
            {
                if (konfirmasi == bankTransferYoga.Config.confirmation.id)
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }
        }
        else
        {
            Console.WriteLine("Unknown language");
        }
    }
}