namespace MontyHallProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Run the simulation 1,000,000 times
            int wins = 0;
            int losses = 0;
            for (int i = 1; i <= 1000000; i++)
            {
                bool success = MontyHall();
                if (success)
                {
                    wins++;
                }
                else
                {
                    losses++;
                }
            // if the simluation has been run 10^N times, output the results
            // it has to be dynamic to any number
            if (Math.Log10(i) % 1 == 0)
                {
                Console.WriteLine("Wins: " + wins);
                Console.WriteLine("Losses: " + losses);
                double winPercentage = (double)wins / (double)(wins + losses) * 100;
                Console.WriteLine("Win Percentage: " + winPercentage + "%");
                }

            }
        }
        public static bool MontyHall()
        {
            // Initialize the doors and fills them with goats (false)
            bool[] doors = new bool[3];
            doors[0] = false;
            doors[1] = false;
            doors[2] = false;
            Random random = new Random();
            // Place the car behind one of the doors (true)
            int car = random.Next(0, 3);
            doors[car] = true;
            // The player selects a door
            int choice = random.Next(0, 3);

            // Monty opens a door that has not been selected and does not have the car
            int montyOpen = random.Next(0, 3);
            while (montyOpen == choice || doors[montyOpen] == true)
            {
                montyOpen = random.Next(0, 3);
            }
            // player switches doors
            if (choice == 0 && montyOpen == 1)
            {
                choice = 2;
            }
            else if (choice == 0 && montyOpen == 2)
            {
                choice = 1;
            }
            else if (choice == 1 && montyOpen == 0)
            {
                choice = 2;
            }
            else if (choice == 1 && montyOpen == 2)
            {
                choice = 0;
            }
            else if (choice == 2 && montyOpen == 0)
            {
                choice = 1;
            }
            else if (choice == 2 && montyOpen == 1)
            {
                choice = 0;
            }
            // Check if the player won
            if (doors[choice] == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}