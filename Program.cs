using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TextAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Body parts of the player
            string head = " O\n";
            string arms = "-+-\n";
            string body = " |\n";
            string leftLegs = "/";
            string rightLeg = "|\n";
            string legs = leftLegs + rightLeg;

            //Movement:
            //step      =   step for each body part of the player
            //latestPos  =   latest known position of the player (sum of all the steps done)
            string step;
            string latestPos = "";

            //All the body parts of the player combined
            List<String> player = new List<string>();
            player.Add(head);
            player.Add(arms);
            player.Add(body);
            player.Add(legs);

            //Running the animation 5 times
            for (int turn = 0; turn < 5; turn++)
            {
                //Initialize step & console & text color
                step = " ";
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;

                //Moving 5 steps forward the player
                for (int i = 0; i < 5; i++)
                {
                    foreach (string bodyPart in player)
                    {
                        Console.Write(step + bodyPart);
                    }
                    //add a delay of 300ms to the printing process so every loop is visible in the console
                    Thread.Sleep(300);
                    //Clear the console in order to erase the previous printings (previous steps of the player)
                    Console.Clear();
                    //add a step to the player for each loop
                    step += step;
                    //the sum of all the steps done, is the latest known position of the player
                    latestPos = step;
                }

                //Print a message to warn that enemies are coming
                Console.Write(latestPos + "     WARNING !!! \n" + latestPos + "ENEMIES ARE COMING !!!");
                //Add a delay to give the user the time to read the waring message
                Thread.Sleep(1500);
                Console.Clear();

                //Print the player and the enemy at the latest known position
                foreach (string bodyPart in player)
                {
                    //player is diplayed in white
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(latestPos + bodyPart);

                    //emeny is diplayed in red
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(latestPos + step + bodyPart);
                }
                Thread.Sleep(2000);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n" + latestPos + "THE END!");

                Thread.Sleep(1000);
            }
            Console.ReadLine();
        }
    }
}
