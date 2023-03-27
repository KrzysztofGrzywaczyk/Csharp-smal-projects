
using Duel_Game_Mechanics;
using System.Runtime.CompilerServices;

List<Character> characters = new List<Character>();

characters.Add(new Cowboy("Cowboy", 500, Colors.cyan));
characters.Add(new Farmer("Farmer", 600, Colors.green));
characters.Add(new Goldminer("Miner", 600, Colors.gray));
characters.Add(new Sheriff("Cheriff", 500, Colors.yellow));

Character player1Character;
Character player2Character;

bool isChosen = false;


do
{
    isChosen = choseCharacter(out player1Character,1,characters);
}
while (!isChosen);

do
{
    isChosen = choseCharacter(out player2Character, 2, characters);
}
while (!isChosen);

bool isPlayer1Turn;
Random rnd = new Random();
isPlayer1Turn = (rnd.Next(1, 2) == 1) ? true : false;



do
{
    Console.Clear();
    printCharacter(player1Character, 1);
    printCharacter(player2Character, 2);

    Character currrentPlayer = isPlayer1Turn ? player1Character : player2Character;
    Character otherPlayer = isPlayer1Turn ? player2Character : player1Character;
    Console.WriteLine(" ----------------------------------------------------");
    Console.WriteLine( $"{currrentPlayer.Name}'s move. Choose your action: \n");
    Console.WriteLine("1. Take a shot !!!");
    Console.WriteLine("2. Heal ♥ ");
    if (currrentPlayer is IDynamite && !currrentPlayer.UsedDynamite)
    {
        Console.WriteLine("3. Throw Dynamite !!!");
    }

    ConsoleKey key;
    do
    {
        key = Console.ReadKey().Key;

        switch (key)
        {
            case ConsoleKey.D1:
                currrentPlayer.Attack(otherPlayer);
                break;
            case ConsoleKey.D2:
                currrentPlayer.Heal();
                break;
            case ConsoleKey.D3:
                if (currrentPlayer is IDynamite && !currrentPlayer.UsedDynamite)
                {
                    ((IDynamite)currrentPlayer).Dynamite(otherPlayer);
                }
                else
                {
                    currrentPlayer.Attack(otherPlayer);
                }
                break;
            default:
                printError("This key is no-action, choose again again");
                break;
        }

        Console.WriteLine("Press enter to continue to next Turn");
        Console.ReadKey();

    }
    while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3);

    if (player1Character.CurrentHp == 0 || player2Character.CurrentHp == 0)
    {
        printError("TheEnd");
        printError($"{otherPlayer.Name} is dead :(");
        printError($"Winner is {currrentPlayer}", anyKey: true);

    }
    else
    {
        isPlayer1Turn = !isPlayer1Turn;
    }

}
while (player1Character.CurrentHp > 0 && player2Character.CurrentHp >0);






static void printCharacter(Character player, int oneOrTwo)
{
    switch (player.Color)
    {
        case Colors.gray:
            Console.ForegroundColor = ConsoleColor.DarkGray;
            break;
        case Colors.green:
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            break;
        case Colors.cyan:
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            break;
        case Colors.yellow:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            break;
    }
    if (oneOrTwo == 1)
    {
        Console.WriteLine("Player 1");
    }
    else
    {
        Console.CursorLeft = 25;
        Console.CursorTop = 0;
        Console.WriteLine("Player 2");
        Console.CursorLeft = 25;
        Console.CursorTop = 1;
    }
    Console.WriteLine(player);
    Console.ResetColor();
}


static void printError(string message, bool anyKey = false)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
    if (anyKey == true)
    {
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

}

static bool choseCharacter(out Character character, int player, List<Character> characters)
{
    Console.Clear();
    Console.WriteLine("Gracz {player} - wybierz postać.");

    for (int i = 0; i < characters.Count; i++)
    {
        Console.WriteLine($"{i+1} - {characters[i].Name}");
    }

    int num;
    int.TryParse(Console.ReadLine(), out num);

    if (num >= 0 && num <= characters.Count)
    {
        character = characters[num - 1];
        characters.Remove(character);
        return true;
    }
    else
    {
        printError($"Uncorrect choise, type value 1-{characters.Count}",anyKey : true);
        character = null;
        return false;
    }

}






