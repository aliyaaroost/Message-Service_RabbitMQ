using System;
class Program
{
	static void Main(String[] args)
	{
		RMQ rmq = new RMQ();
		Console.WriteLine("Tekan tombol apapun untuk inisialisasi RMQ parameters.");
		Console.ReadKey();
		rmq.InitRMQConnection(); // inisialisasi parameter (secara default) untuk koneksi ke server RMQ
		Console.WriteLine("Tekan tombol apapun untuk membuka koneksi ke RMQ."); Console.ReadKey();
		rmq.CreateRMQConnection(); // memulai koneksi dengan RMQ
		Console.Write("Masukkan nama queue channel untuk mengirim pesan melalui RMQ.\n>> ");
		string queue_name = Console.ReadLine();
		rmq.CreateRMQChannel(queue_name);
		Console.Write("Masukkan pesan yang akan dikirim atau 'exit' to close.\n>>");
		Console.Write(">> tujuan: ");
		string tujuan = Console.ReadLine();
		Console.Write(">> pesan: ");
		string inputMsg = Console.ReadLine();
		while (inputMsg != "exit")
		{
			rmq.SendMessage(tujuan, inputMsg);
			Console.Write(">> tujuan: ");
			tujuan = Console.ReadLine();
			Console.Write(">> pesan: ");
			inputMsg = Console.ReadLine();
		}
		rmq.Disconnect();
		// kode program di tulis di sini
		//Console.WriteLine("Hello World!");
	}
}