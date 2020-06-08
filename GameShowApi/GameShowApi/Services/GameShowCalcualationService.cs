using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShowApi.Services
{
    public class GameShowCalcualationService
    {

        private static readonly int Goat = 0;
        private static readonly int Car = 1;
        private static readonly int NumberOfDoors = 3;


        public static int CalculateNumberOfWins(int numberOfTries, bool switchDoor)
        {

            Random randomGenerator = new Random();
            int numberOfWins = 0;

            for (int tries = 0; tries < numberOfTries; tries++)
            {
                int[] doors = { Goat, Goat, Goat };

                int winningDoor = randomGenerator.Next(NumberOfDoors);
                doors[winningDoor] = Car;


                int doorPickedByContestant = randomGenerator.Next(NumberOfDoors);
                int result = doors[doorPickedByContestant];

                if (switchDoor)
                {
                    doors = RemoveDoor(doors, doorPickedByContestant);

                    int indexOfFirstGoat = Array.IndexOf(doors, Goat);
                    doors = RemoveDoor(doors, indexOfFirstGoat);
                    
                    result = doors[0]; // Only remaining door
                }

                numberOfWins += result;
            }

            return numberOfWins;
        }

        private static int[] RemoveDoor(int[] doors, int indexOfDoorToBeRemoved) {
            return doors.Where((door, index) => index != indexOfDoorToBeRemoved).ToArray();
        }

    }
}
