namespace KidsFair
{
    class Pet
    {
        private String name;
        private int age;
        private bool isFemale;

        public void start()
        {
            Console.WriteLine("THE PET PROGRAM!");
            Console.WriteLine("----------------\n");
            ReadAndSavePetData();
            DisplayPetData();
        }
        private void ReadAndSavePetData()
        {
            Console.Write("What is the name of your pet? ");
            name = Console.ReadLine();
            Console.Write($"What is {name}'s age? ");
            age = Convert.ToInt32(Console.ReadLine());
            String answer;
            do
            {
                Console.Write($"Is {name} a female? (y/n)");
                answer = Console.ReadLine();
                if (answer == "y") isFemale = true;
                else if (answer == "n") isFemale = false;
            } while (answer != "y" && answer != "n" && answer != "Y" && answer != "Y");
        }

        private void DisplayPetData()
        {
            String gender;
            if (isFemale) gender = "girl";
            else gender = "boy";
            Console.WriteLine("\n+++++++++++++++++++++++++++++++");
            Console.WriteLine($"Name: {name} - Age: {age}");
            Console.WriteLine($"{name} is a good {gender}!");
            Console.WriteLine("+++++++++++++++++++++++++++++++\n");

            Console.WriteLine("Press any key to continue to the next program.");
            Console.ReadLine();
        }
    }

    
}
