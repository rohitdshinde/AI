//string[] grid = { "1","2","3","4","5","6","7","8","9"};
string[] grid = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
bool player1turn = true;
int numTurn = 0;

while (!checkvictory() && numTurn != 9)
{
    print();
    if (player1turn)
    {
        Console.WriteLine("Player 1 turn");
    }
    else { Console.WriteLine("Player 2 turn"); }

    string choice = Console.ReadLine();
    if (grid.Contains(choice) && choice != "X" && choice != "O")
    {
        int index = int.Parse(choice) - 1;
        if (player1turn) grid[index] = "X";
        else
            (grid)[index] = "O";

        numTurn++;
        Console.WriteLine(numTurn);
    }
    player1turn = !player1turn;
}

print();
if (checkvictory())
    Console.WriteLine("YOU WIN");

else
{
    Console.WriteLine("TIE");
}

void print()
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write(grid[i * 3 + j] + "|");
        }
        Console.WriteLine();
        Console.WriteLine("---------");
    }
}
bool checkvictory()
{
    bool row1 = grid[0] == grid[1] && grid[1] == grid[2];
    bool row2 = grid[3] == grid[4] && grid[4] == grid[5];
    bool row3 = grid[6] == grid[7] && grid[7] == grid[8];
    bool col1 = grid[0] == grid[3] && grid[3] == grid[6];
    bool col2 = grid[1] == grid[4] && grid[4] == grid[7];
    bool col3 = grid[2] == grid[5] && grid[5] == grid[8];
    bool diagDown = grid[0] == grid[4] && grid[4] == grid[8];
    bool diagUP = grid[6] == grid[4] && grid[4] == grid[2];

    return row1 || row2 || row3 || col1 || col2 || col3 || diagDown || diagUP;

}
