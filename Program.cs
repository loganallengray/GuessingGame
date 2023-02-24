using System;

void Main()
{
    Console.WriteLine(@"Guess the number I'm thinking of!");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Choose Difficulty.");
    Console.WriteLine("1) Cheater");
    Console.WriteLine("2) Easy");
    Console.WriteLine("3) Medium");
    Console.WriteLine("4) Hard");

    int secretNumber = randomNumber();
    int difficultyNumber = askDifficulty();

    while (difficultyNumber == 0)
    {
        Console.WriteLine("Please choose a correct option.");
        difficultyNumber = askDifficulty();
    }

    Console.WriteLine("Now choose a number, keep going until you can't!");

    for (int i = 0; i < difficultyNumber; i++)
    {
        string userChoice = Console.ReadLine();
        bool isNum = int.TryParse(userChoice, out int n);
        int userNumber = 0;

        while (!isNum)
        {
            Console.WriteLine("Please choose a number.");
            userChoice = Console.ReadLine();
            isNum = int.TryParse(userChoice, out n);
        }

        userNumber = int.Parse(userChoice);

        if (difficultyNumber == 99)
        {
            i--;
        }

        if (secretNumber == userNumber)
        {
            Console.WriteLine($"Your guess ({userNumber})> You got it!");
            break;
        }
        else
        {
            string compareMessage = "lower";

            if (userNumber > secretNumber)
            {
                compareMessage = "higher";
            }

            Console.WriteLine($"Your guess ({userNumber})> Nope! Nice try, though, your guess was {compareMessage} than mine. You have {Math.Abs(i - difficultyNumber + 1)} guesses left.");
        }
    }
}

int randomNumber()
{
    Random r = new Random();
    int computerChoice = r.Next(1, 100);

    return computerChoice;
}

int askDifficulty()
{
    string difficultyChoice = Console.ReadLine();

    switch (difficultyChoice)
    {
        case "1":
            return 99;
        case "2":
            return 8;
        case "3":
            return 6;
        case "4":
            return 4;
        default:
            return 0;
    }
}

Main();