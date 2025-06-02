// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Create a new thread that will run the WriteY method
// Thread t = new Thread(WriteY);
// t.Start();  // Starts the thread execution
// for (int i = 0; i < 1000; i++) Console.Write($"x{i}\t");
// Thread newT = new Thread(WriteYe) { Name = "Thread Y" };
// newT.Name = "Thread Ye"; // Set the name of the thread
// newT.Start();
// Console.WriteLine("Nama thread utama: " + Thread.CurrentThread.Name);

// // Wait for the thread to finish before continuing in the main thread
// Thread t = new Thread(Go);
// t.Start();
// t.Join();  // Waits for thread t to finish
// newT.Join(); // Waits for newT to finish
// // thread newT tidak menunggu thread t, kedua thread berjalan bersamaan. Namun untuk melanjutkan eksekusi di thread utama, kita harus menunggu kedua thread selesai dengan Join().
// Console.WriteLine("Thread t has ended!");


Console.WriteLine("Program starting");
Thread t1 = new Thread(Print);
Thread t2 = new Thread(Fax);
Thread t3 = new Thread(Scan);

t1.IsBackground = true;
t2.IsBackground = true;
t3.IsBackground = true;
// Thread utama tidak menunggu background thread jika sudah selesai mengeksekusi semua script.

t1.Start();
t2.Start();
t3.Start();

t1.Join();
t2.Join();
t3.Join();

Console.WriteLine("Program finished");


// // PRIORITY THREADS EXAMPLE
// Thread priorT1 = new Thread(() => PrintMessage()) { Priority = ThreadPriority.Normal };
// priorT1.Start();

// // Create a new thread with High priority
// Thread priorT2 = new Thread(() => PrintMessage("MEDIC")) { Priority = ThreadPriority.Highest };
// priorT2.Start();

// // The main thread's priority is Normal by default
// for (int i = 0; i < 100; i++) Console.Write("Main thread running...");
// // END PRIORITY THREADS EXAMPLE



// EXCEPTION HANDLING IN THREADS EXAMPLE
Console.WriteLine("Program starting");
Thread exceptionT1 = new Thread(Execution);
// Thread exceptionT1 = new Thread(() =>
// {
//     try
//     {
//         Execution();
//         // MethodA();
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine("Exception caught in thread: " + ex.Message);
//     }
// });
exceptionT1.Start();
exceptionT1.Join();
Console.WriteLine("Program finished");
// END EXCEPTION HANDLING IN THREADS EXAMPLE

// THREAD POOL EXAMPLE
ThreadPool.QueueUserWorkItem(DoWork, "Pekerjaan di Thread Pool");
// Menunggu agar program tidak langsung berakhir
Console.WriteLine("Tunggu sebentar, pekerjaan sedang dijalankan...");
Console.ReadLine();
// END THREAD POOL EXAMPLE

void DoWork(object state)
{
    // Logika yang akan dijalankan oleh thread pool
    string message = (string)state;
    Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}, Pesan: {message}");
    Thread.Sleep(2000);  // Simulasi pekerjaan berat
    Console.WriteLine("Pekerjaan selesai!");
}
static void MethodA()
{
    throw new Exception();
}
static void Execution()
{
    try
    {
        MethodA();
    }
    catch (Exception e)
    {
        Console.WriteLine("Masuk ke catch block");
        Console.WriteLine(e.Message);
    }
}
void PrintMessage(string msg = "Worker")
{
    for (int i = 0; i < 100; i++)
        Console.WriteLine($"{msg} thread running... {i}");
}
void Go()
{
    for (int i = 0; i < 1000; i++)
        Console.Write("y");
}
void WriteY()
{
    for (int i = 0; i < 1000; i++)
        Console.Write($"y{i}\t");
}
void WriteYe()
{
    for (int i = 0; i < 150; i++)
        Console.Write($"${i} ");
}
static void Print()
{
    Console.WriteLine("Print start");
    Thread.Sleep(10000);
    Console.WriteLine("Print finished");
}
static void Fax()
{
    Console.WriteLine("Fax start");
    Thread.Sleep(5000);
    Console.WriteLine("Fax finished");
}
static void Scan()
{
    Console.WriteLine("Scan start");
    Thread.Sleep(11000);
    Console.WriteLine("Scan finished");
}
class ThreadTest
{
    static bool _done;    // Shared state
    static void Main()
    {
        new Thread(Go).Start();
        Go();
    }

    static void Go()
    {
        if (!_done) { _done = true; Console.WriteLine("Done"); }
    }
}
class ThreadSafe
{
    static bool _done;
    static readonly object _locker = new object();

    static void Main()
    {
        new Thread(Go).Start();
        Go();
    }

    static void Go()
    {
        lock (_locker)
        {
            if (!_done) { Console.WriteLine("Done"); _done = true; }
        }
    }
}




// using TicTacToeLib;
// class Program
// {
// 	static void Main(string[] args)
// 	{
// 		TicTacToeController game = new TicTacToeController();

// 		while (game.CheckWinner() == ' ')
// 		{
// 			Console.WriteLine("\nCurrent board:");
// 			for (int i = 0; i < 9; i++)
// 			{
// 				Console.Write(game.GetBoardPosition(i)); 
// 				if ((i + 1) % 3 == 0) Console.WriteLine();
// 			}

// 			Console.Write($"Player {game.GetCurrentPlayer()}, enter position (0-8): ");
// 			int position;
// 			while (!int.TryParse(Console.ReadLine(), out position) || !game.MakeMove(position))
// 			{
// 				Console.WriteLine("Invalid input. Try again.");
// 			}
// 		}

// 		char winner = game.CheckWinner();
// 		if (winner == 'T')
// 			Console.WriteLine("It's a tie!");
// 		else
// 			Console.WriteLine($"Player {winner} wins!");
// 	}
// }