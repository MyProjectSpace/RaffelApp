// See https://aka.ms/new-console-template for more information
using RaffelApp;
using System.Runtime.CompilerServices;

Raffle raffle = new Raffle();
raffle.DispalyRaffelInstructions(RaffleStatus.NotStarted);
Console.WriteLine("Please enter your preference");
string enteredOptionString = Console.ReadLine();
int enteredOption = 0;
int drawId = 1;
decimal potsize = 100;
do
{
    try
    {
        if (!int.TryParse(enteredOptionString, out enteredOption))
        {
            Console.WriteLine("Enter valid option");
            enteredOptionString = Console.ReadLine();
        }
        else
        {
            switch (enteredOption)
            {
                case 1:
                    raffle.StartDraw(drawId, potsize);
                    Console.ReadLine();
                    raffle.DispalyRaffelInstructions(RaffleStatus.DrawStarted);
                    break;
                case 2:
                    raffle.BuyTickets();
                    raffle.DispalyRaffelInstructions(RaffleStatus.OnGoing);
                    break;
                case 3:
                    raffle.RunRaffle();
                    raffle.DispalyRaffelInstructions(RaffleStatus.RunningRaffle);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    break;

            }
            enteredOptionString = Console.ReadLine();
        }
        
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
} while (enteredOption != -99);



