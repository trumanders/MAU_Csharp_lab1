namespace KidsFair
{
    internal class TicketSeller
    {
        private const int ENTRANCE_FEE = 99;
        private String name;
        private int numOfAdults;
        private int numOfChildren;
         
        public void start()
        {
            Console.WriteLine("THE KIDS' FAIR PROGRAM!");
            Console.WriteLine("----------------");
            Console.WriteLine("Children get always a 75% discount!\n");
            ReadAndSaveData();
            DisplayData();
        }

        public void ReadAndSaveData()
        {
            Console.WriteLine("Your name please: ");
            name = Console.ReadLine();
            Console.WriteLine("Number of adults: ");
            numOfAdults = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number of children: ");
            numOfChildren = Convert.ToInt32(Console.ReadLine());
        }

        public void DisplayData()
        {
            decimal totalFee = ((decimal)numOfAdults * ENTRANCE_FEE) + (numOfChildren * ENTRANCE_FEE * 0.25m);
            Console.WriteLine("\n +++ Your receipt +++");
            Console.WriteLine(string.Format(" +++ Amount to pay = {0:0.00}", totalFee));
            Console.WriteLine();
            Console.WriteLine($" +++ Thank you {name} and please come back! +++");
            Console.WriteLine("Press any key to continue to the next program.");
            Console.ReadLine();
        }
    }
}
