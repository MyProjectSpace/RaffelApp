// See https://aka.ms/new-console-template for more information
using RaffelApp;
using System.Runtime.CompilerServices;

Raffle raffle = new Raffle();
raffle.DispalyRaffelInstructions();
Console.WriteLine("Please enter your preference");
string enteredOptionString = Console.ReadLine();
int enteredOption = 0;
int drawId = 1;
decimal potsize = 100;
do
{

    if (!int.TryParse(enteredOptionString, out enteredOption))
    {
        Console.WriteLine("Enter valid option");
    }
    else
    {
        switch (enteredOption)
        { 
            case 1:
                raffle.StartDraw(drawId, potsize);
                Console.ReadLine();
                break;

        }
    }
} while (enteredOption != -99);



