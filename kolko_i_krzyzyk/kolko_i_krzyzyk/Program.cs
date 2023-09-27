using System;

class Program
{
    static void Main(string[] args)
    {
        string[][] br = new string[][]
        {
            new string[] { "", "", "" },
            new string[] { "", "", "" },
            new string[] { "", "", "" }
        };

        void Print_fields(string[][] board, int a, int b, int r = 0)
        {
            for (int i = a; i < b; i++)
            {
                string p = i.ToString();
                if (board[r][i - a] != "")
                {
                    p = board[r][i - a];
                }
                Console.Write($"|   {p}   ");
            }
            Console.WriteLine("|");
        }

        void Display_board(string[][] board)
        {
            Console.WriteLine("+-------+-------+-------+",
                              "|       |       |       |", "\n");
            Print_fields(board, 1, 4, 0);
            Console.WriteLine("|       |       |       |",
                              "+-------+-------+-------+",
                              "|       |       |       |", "\n");
            Print_fields(board, 4, 7, 1);
            Console.WriteLine("|       |       |       |",
                              "+-------+-------+-------+",
                              "|       |       |       |", "\n");
            Print_fields(board, 7, 10, 2);
            Console.WriteLine("|       |       |       |",
                              "+-------+-------+-------+","\n");
        }

        void Enter_move(string[][] board)
        {
            while (true)
            {
                Console.Write("Wykonaj swój ruch: ");
                int r = int.Parse(Console.ReadLine());
                if (board[(r - 1) / 3][r % 3 - 1] == "")
                {
                    board[(r - 1) / 3][r % 3 - 1] = "O";
                    break;
                }
                Console.WriteLine("Podałeś zajęte już pole, spróbuj ponownie");
            }
        }

        List<(int, int)> Make_list_of_free_fields(List<List<string>> board)
        {
            List<(int, int)> f = new List<(int, int)>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i][j] == "")
                    {
                        f.Add((i, j));
                    }
                }
            }
            return f;
        }

        static bool Victory_for(string[][] board, string sign = "X")
        {
            if ((board[0][0] == sign && board[1][1] == sign && board[2][2] == sign) || (board[0][2] == sign && board[1][1] == sign && board[2][0] == sign))
            {
                Console.WriteLine("ZWYCIESTWO " + sign);
                return true;
            }
            for (int i = 0; i < 3; i++)
            {
                var hpass = new List<char>();
                var vpass = new List<char>();
                for (int j = 0; j < 3; j++)
                {
                    if (board[i][j] == sign) hpass.Add(sign);
                    if (board[j][i] == sign) vpass.Add(sign);
                }
                if (hpass.Count == 3 || vpass.Count == 3)
                {
                    Console.WriteLine("ZWYCIESTWO " + sign);
                    return true;
                }
            }
            return false;
        }

        void Draw_move(string[][] board)
        {
            List<Tuple<int, int>> f = Make_list_of_free_fields(board);

            if (f.Contains(new Tuple<int, int>(1, 1)))
            {
                board[1][1] = "X";
            }
            else
            {
                Random random = new Random();
                int p = random.Next(0, f.Count);
                board[f[p].Item1][f[p].Item2] = "X";
            }
        }

        while (true)
        {
            Draw_move(br);
            Display_board(br);
            if (Victory_for(br))
            {
                break;
            }
            Enter_move(br);
            Display_board(br);
            if (Victory_for(br, 'O'))
            {
                break;
            }
        }

    }
}