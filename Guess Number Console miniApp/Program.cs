
Console.Title = "Guess a number!";

Random rnd = new Random();
int random = rnd.Next(0, 10);

int usersValue;
bool validate;
bool[] numbers = new bool [10];
int counter = 0;

do
{
    do
    {   
        Console.WriteLine("Guess number in rage 0-10 :");
        validate = int.TryParse(Console.ReadLine(), out usersValue);

        if (validate == false)
        {
            PrintMessage("red", "Put a correct NUMBER");

        }
        else if (usersValue < 0 || usersValue > 10)
        {
            PrintMessage("red", "Put a number between 0 and 10");
            validate = false;
        }
        else if (numbers[usersValue-1] == true)
        {
            PrintMessage("darkYellow", "You've already tried this one (we will not take that as a mistake)");
            validate = false;
        }
        else
        {
            numbers[usersValue-1] = true;
        }
    }
    while (validate != true);

    if (usersValue < random)
    {
        PrintMessage("yellow", "Number is larger");

    }
    else if (usersValue > random)
    {
        PrintMessage("yellow", "Number is smaller");

    }
    counter++;
            
}
while (usersValue != random);

PrintMessage("green", "Bravo!", $"You have guessed well in {counter} try");


static void PrintMessage(string color, params string[] content)
{
    switch(color)
    {
        case "darkYellow":
            Console.ForegroundColor = ConsoleColor.DarkYellow; break;
        case "green":
            Console.ForegroundColor = ConsoleColor.Green; break;
        case "red":
            Console.ForegroundColor = ConsoleColor.Red; break;
        case "yellow":
            Console.ForegroundColor = ConsoleColor.Yellow; break;
        default:
            Console.ForegroundColor = ConsoleColor.White; break;
    } 
    foreach (string message in content)
    {
        Console.WriteLine(message);
    }
    Console.ResetColor();
}