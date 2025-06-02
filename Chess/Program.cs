// See https://aka.ms/new-console-template for more information
using System.Text.Json;
string block = 
@"
...
...
";
string blockBlack = 
"""
######
######
A1####
""";
string blockWhite =
"""
******
******
G8****
""";
var result = string.Concat(
    Enumerable.Range(1, 4)  // Ulangi sebanyak 4 kali
        .Select(i =>
            blockBlack.Replace("A1", $"A{i}") +
            "$$$$$$" +
            blockWhite.Replace("G8", $"G{i}")
        )
);
Console.WriteLine(result);
// Console.WriteLine(string.Concat(Enumerable.Repeat(blockBlack + blockWhite, 4)));
// Console.WriteLine((blockBlack + blockWhite).repeat(2));
string[][] boardChess = new string[8][];
for (int i = 0; i < boardChess.Length; i++)
{
    boardChess[i] = new string[8];
    for (int j = 0; j < boardChess[i].Length; j++)
    {
        if ((i + j) % 2 == 0)
        {
            boardChess[i][j] = blockBlack;
        }
        else
        {
            boardChess[i][j] = blockWhite;
        }
    }
}
// Console.Write(block);
Console.Write(blockBlack);
Console.Write(blockWhite);
Console.WriteLine(blockBlack+blockWhite);
// for (int i = 0; i < boardChess.Length; i++)
// {
//     for (int j = 0; j < boardChess[i].Length; j++)
//     {
//         Console.Write(boardChess[i][j] + " ");
//     }
//     Console.WriteLine();
// }
// string[,] boardChess = new string[8, 8];
// Console.WriteLine(board.Length);
// // Console.WriteLine(boardChess.);
// for (int i = 0; i < boardChess.GetLength(0); i++)
// {
//     for (int j = 0; j < boardChess.GetLength(1); j++)
//     {
//         boardChess[i, j] = $"{(char)('A' + j)}{8 - i}";
//     }
// }
// // Console.WriteLine(JsonSerializer.Serialize(boardChess));
// for (int i = 0; i < boardChess.GetLength(0); i++)
// {
//     Console.Write(boardChess[i, 2] + " ");
// }

// Console.WriteLine(blockBlack);
// Console.WriteLine(blockWhite);
string pola = "######[][][][][][]######[][][][][][]######[][][][][][]";
        int barisBoard = 3;

        // Cetak board dan simpan posisi baris terakhir
        for (int i = 0; i < barisBoard; i++)
        {
            Console.WriteLine(pola);
        }

        // Hitung posisi prompt (kanan dari pola baris terakhir)
        int promptX = pola.Length + 2; // +2 untuk spasi antara board dan input
        int promptY = barisBoard - 1; // baris terakhir (0-based)

        // Pindah kursor ke posisi di samping board
        Console.SetCursorPosition(promptX, promptY);
        Console.Write("Your turn: ");

        // Baca input di posisi tersebut
        string input = Console.ReadLine();