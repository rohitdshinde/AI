//using System;

//class TicTacToe
//{
//    private char[,] board;
//    private char currentPlayer;

//    public TicTacToe()
//    {
//        board = new char[3, 3];
//        currentPlayer = 'X';
//        InitializeBoard();
//    }

//    private void InitializeBoard()
//    {
//        for (int row = 0; row < 3; row++)
//        {
//            for (int col = 0; col < 3; col++)
//            {
//                board[row, col] = ' ';
//            }
//        }
//    }

//    public void PrintBoard()
//    {
//        Console.WriteLine("Current Board:");
//        for (int row = 0; row < 3; row++)
//        {
//            for (int col = 0; col < 3; col++)
//            {
//                Console.Write(board[row, col]);
//                if (col < 2)
//                {
//                    Console.Write(" | ");
//                }
//            }
//            Console.WriteLine();
//            if (row < 2)
//            {
//                Console.WriteLine("---------");
//            }
//        }
//        Console.WriteLine();
//    }

//    public void Play()
//    {
//        Console.WriteLine("Welcome to Tic Tac Toe!\n");
//        PrintBoard();

//        while (!IsGameOver())
//        {
//            if (currentPlayer == 'X')
//            {
//                PlayerMove();
//            }
//            else
//            {
//                ComputerMove();
//            }
//            TogglePlayer();
//            PrintBoard();
//        }

//        if (IsWinner('X'))
//        {
//            Console.WriteLine("Congratulations! Player X wins!");
//        }
//        else if (IsWinner('O'))
//        {
//            Console.WriteLine("Congratulations! Player O wins!");
//        }
//        else
//        {
//            Console.WriteLine("It's a draw!");
//        }
//    }

//    private void PlayerMove()
//    {
//        int row, col;
//        bool validMove = false;

//        do
//        {
//            Console.WriteLine($"Player {currentPlayer}'s turn");
//            Console.Write("Enter row and column numbers: ");
//            string[] input = Console.ReadLine().Split();
//            row = int.Parse(input[0]);
//            col = int.Parse(input[1]);

//            if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ')
//            {
//                validMove = true;
//                board[row, col] = currentPlayer;
//            }
//            else
//            {
//                Console.WriteLine("Invalid move! Try again.");
//            }

//        } while (!validMove);
//    }

//    private void ComputerMove()
//    {
//        Random rand = new Random();
//        int row, col;

//        do
//        {
//            row = rand.Next(0, 3);
//            col = rand.Next(0, 3);
//        } while (board[row, col] != ' ');

//        board[row, col] = currentPlayer;
//        Console.WriteLine($"Computer chooses row {row} and column {col}");
//    }

//    private bool IsGameOver()
//    {
//        return IsBoardFull() || IsWinner('X') || IsWinner('O');
//    }

//    private bool IsBoardFull()
//    {
//        for (int row = 0; row < 3; row++)
//        {
//            for (int col = 0; col < 3; col++)
//            {
//                if (board[row, col] == ' ')
//                {
//                    return false;
//                }
//            }
//        }
//        return true;
//    }

//    private bool IsWinner(char player)
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
//            {
//                return true;
//            }
//            if (board[0, i] == player && board[1, i] == player && board[2, i] == player)
//            {
//                return true;
//            }
//        }
//        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
//        {
//            return true;
//        }
//        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
//        {
//            return true;
//        }
//        return false;
//    }

//    private void TogglePlayer()
//    {
//        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        TicTacToe game = new TicTacToe();
//        game.Play();
//    }
//}
