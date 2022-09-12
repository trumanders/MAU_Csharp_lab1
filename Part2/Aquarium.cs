using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class Aquarium
    {
        public static int numOfAquariums;       
        private String name;
        private int sizeInLiters;
        private int lengthInDecimeters;
        private int widthInDecimeters;
        private int heightInDecimeters;
        private String style;
        private String lighting;
        private int numberOfFish;                       // Number of fish in current aquarium
        private List<Fish> fishInAquarium;              // Holds all Fish-objects for the aquarium
        private String lastFed;

        // Constructor runs when adding aquarium (new object)
        public Aquarium()
        {
            // Set default values for aquarium
            this.name = "NEW AQUARIUM";
            this.sizeInLiters = 0;
            this.style = "-";
            this.lighting = "-";
            this.numberOfFish = 0;
            numOfAquariums++;
            this.fishInAquarium = new List<Fish>();      // Creates a list to hold fish objects for the aquarium
            this.lastFed = "never";
            ResetDimensions();          
            EditAquarium();                         // Called upon instantiation and when selecting edit from menu
            
        }



        // Counts the fish objects for the aquarim
        private int CountFishInAquarium()
        {
            int fishCount = 0;
            for (int i = 0; i < fishInAquarium.Count; i++)
            {
                fishCount += fishInAquarium[i].GetQuantity();
                if (fishInAquarium[i].GetQuantity() == 0)
                {
                    fishInAquarium.RemoveAt(i);
                }
            }
            return fishCount;
        }


        // Removes a fish from fish list if quantity is zero
        private void RemoveZeroFish()
        {
            for (int i = 0; i < fishInAquarium.Count; i++)
            {
                if (fishInAquarium[i].GetQuantity() == 0)
                {
                    fishInAquarium.RemoveAt(i);
                }
            }
        }


        // Called upon instatiantion of Aquarium and when selecting edit from menu
        public void EditAquarium()
        {     
            // Loop util exiting menu
            int editChoise;
            do
            {
                // Update number of fish for current aquarium
                this.numberOfFish = CountFishInAquarium();

                // Remove any fish that has quantity 0
                // So, when deleting all individuals of a particular fish, the fish disappears from the fish list
                RemoveZeroFish();

                // Loop menu until valid choise is entered
                do
                {
                    Console.WriteLine($"\nEDIT AQUARIUM: \"{name}\"");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine($"1. Name\t\t\t{name}");
                    Console.WriteLine($"2. Liters\t\t{sizeInLiters}");
                    Console.WriteLine($"3. Dimensions\t\t{lengthInDecimeters * 10} x {widthInDecimeters * 10} x {heightInDecimeters * 10}");
                    Console.WriteLine($"4. Style\t\t{style}");
                    Console.WriteLine($"5. Lighting\t\t{lighting}");
                    Console.WriteLine($"6. Add fish\t\t{numberOfFish}");
                    Console.WriteLine("7. Delete fish");
                    Console.WriteLine("8. Show fish");
                    Console.WriteLine("9. Edit fish");
                    Console.WriteLine($"10. Feed aquarium\tLast fed: {lastFed}");
                    Console.WriteLine("0. DONE - GO TO PREVIUOS MENU");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.Write("\nSelect > ");
                } while (!int.TryParse(Console.ReadLine(), out editChoise) || editChoise < 0 || editChoise > 10);

                switch (editChoise)
                {
                    case 1:
                        SetName();
                        break;
                    case 2:
                        SetLiters();
                        break;
                    case 3:
                        SetDimensions();
                        break;
                    case 4:
                        SetStyle();
                        break;
                    case 5:
                        SetLighting();
                        break;
                    case 6:
                        AddFish(fishInAquarium);
                        break;
                    case 7:
                        DeleteFish(fishInAquarium);
                        break;
                    case 8:
                        ShowFish(fishInAquarium);
                        break;
                    case 9:

                        // Passing true to activate editing of existing fish
                        EditFish(fishInAquarium, true);
                        break;
                    case 10:
                        FeedAquarium();
                        break;
                }
            } while (editChoise != 0);
        }


        private void FeedAquarium()
        {
            lastFed = DateTime.Now.ToString("H:mm - dd MMMM yyyy");
        }

        private void SetName()
        {
            do
            {
                Console.Write("Enter aquarium name (max 20 characters) > ");
                this.name = Console.ReadLine();
            } while (this.name.Length > 20);
        }



        private void SetLiters()
        {
            this.sizeInLiters = 0;
            int liters;
            do
            {
                Console.Write("\nSize in liters > ");
                if (int.TryParse(Console.ReadLine(), out liters))
                {
                    this.sizeInLiters = liters;
                }
                else
                {
                    Console.WriteLine("Please enter a number.");
                }
            } while (this.sizeInLiters == 0);

            // Setting size in liters override the already set dimensions, if not corresponding
            if (CalcSizeInLiters() != this.sizeInLiters)
            {
                ResetDimensions();
            }
        }


        private void SetDimensions()
        {
            Console.Write("Enter LENGTH in centimeters > ");
            this.lengthInDecimeters = Convert.ToInt32(Console.ReadLine()) / 10;
            Console.Write("Enter WIDTH in centimeters > ");
            this.widthInDecimeters = Convert.ToInt32(Console.ReadLine()) / 10;
            Console.Write("Enter HEIGHT in centimeters > ");
            this.heightInDecimeters = Convert.ToInt32(Console.ReadLine()) / 10;

            // Setting the dimensions override the already set liters.
            this.sizeInLiters = lengthInDecimeters * widthInDecimeters * heightInDecimeters;
        }

        
        // Calculates the size in liters, based on the chosen dimensions
        private int CalcSizeInLiters()
        {
            return lengthInDecimeters * widthInDecimeters * heightInDecimeters;
        }


        private void SetStyle()
        {
            int styleChoise;
            do
            {
                Console.WriteLine("\nSELECT THE STYLE OF THE AQUARIUM");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("1. Lake Tanganyika");
                Console.WriteLine("2. Lake Malawi");
                Console.WriteLine("3. Mixed african cichlids");
                Console.WriteLine("4. South America");
                Console.WriteLine("5. Central America");
                Console.WriteLine("6. North America");
                Console.WriteLine("7. Mixed american cichlids");
                Console.WriteLine("8. Lake Victoria");
                Console.WriteLine("9. Community / mixed");
                Console.WriteLine("10. Enter custom type");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.Write("\nSelect style > ");
            } while (!int.TryParse(Console.ReadLine(), out styleChoise) || styleChoise < 1 || styleChoise > 10);

            switch (styleChoise)
            {
                case 1:
                    style = "Tanganyika";
                    break;
                case 2:
                    style = "Malawi";
                    break;
                case 3:
                    style = "Mixed african cichlids";
                    break;
                case 4:
                    style = "South America"; 
                    break;
                case 5:
                    style = "Central America";
                    break;
                case 6:
                    style = "North America";
                    break;
                case 7:
                    style = "Mixed american cichlids";
                    break;
                case 8:
                    style = "Lake Victoria";
                    break;
                case 9:
                    style = "Community fish / mixed";
                    break;
                case 10:
                    Console.Write("Enter type > ");
                    style = Console.ReadLine();
                    break;

            }
        }


        private void SetLighting()
        {
            int lightingChoise;
            do
            {
                Console.WriteLine("1. LED");
                Console.WriteLine("2. Tungsten");
                Console.WriteLine("3. Lysrör");
                Console.WriteLine("4. Hallogen");
                Console.Write("\nSelect > ");
            } while (!int.TryParse(Console.ReadLine(), out lightingChoise) || lightingChoise < 1 || lightingChoise > 4);

            switch (lightingChoise)
            {
                case 1:
                    this.lighting = "LED";
                    break;
                case 2:
                    this.lighting = "Tungsten";
                    break;
                case 3:
                    this.lighting = "Lysrör";
                    break;
                case 4:
                    this.lighting = "Hallogen";
                    break;
            }
        }


        private void AddFish(List<Fish> fishInAquarium)
        {
            Console.WriteLine($"\nADD NEW FISH TO AQUARIUM \"{name}\"");

            // Create new instance of Fish - constructor calls edit method in Fish class
            fishInAquarium.Add(new Fish());

            // Passing false, since we're not editing existing fish, just adding a new.
            EditFish(fishInAquarium, false);
        }



        public void SetNumberOfFish(int numOfFish)
        {
            if (numOfFish > 0)
            {
                this.numberOfFish = numOfFish;
            }
        }


        // Change quantity of a specific fish
        private void DeleteFish(List<Fish> fishInAquarium)
        {
            int deleteFishChoise;
            do
            {
                Console.WriteLine($"\nDELETE FISH FROM: {name}.");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                ShowFish(fishInAquarium);
                Console.Write("\nSelect fish to delete > ");
                deleteFishChoise = Convert.ToInt32(Console.ReadLine());
            } while (deleteFishChoise < 0 || deleteFishChoise > fishInAquarium.Count);
            int numberOfFishToDelete;

            // Enter number of {fish} to delete (0 - {quatity})
            Console.Write($"Enter number of {fishInAquarium[deleteFishChoise - 1].GetLatinName()} to delete (0 - {fishInAquarium[deleteFishChoise - 1].GetQuantity()}) > ");
            numberOfFishToDelete = Convert.ToInt32(Console.ReadLine());
            fishInAquarium[deleteFishChoise-1].SetQuantity(fishInAquarium[deleteFishChoise-1].GetQuantity() - numberOfFishToDelete);
        }



        public void ShowFish(List<Fish> fishInAquarium)
        {
            Console.WriteLine($"\nFISH IN AQUARIUM: \"{name}\"");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
            int fishNumber = 1;
            foreach (Fish fish in fishInAquarium)
            {
                Console.WriteLine($"{fishNumber}. {fish.GetLatinName()} ({fish.GetQuantity()})");
                fishNumber++;
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
        }
 


        public void EditFish(List<Fish> fishInAquarium, bool isEditFish)
        {
            if (fishInAquarium.Count == 0)
            {
                Console.WriteLine("You don't have any fish added to this aquarium");
                return;
            }
            int chosenFish = fishInAquarium.Count;        // If adding new fish, the last added will be edited
            if (isEditFish)
            {
                do
                {
                    ShowFish(fishInAquarium);
                    Console.Write("\nChose fish to edit > ");
                } while (!int.TryParse(Console.ReadLine(), out chosenFish) || chosenFish < 0 || chosenFish > fishInAquarium.Count);              
            }

            int editFishChoise;
            do
            {
                do
                {
                    Console.WriteLine($"\nEDIT FISH: {fishInAquarium[chosenFish-1].GetLatinName()} in aquarium {name}");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine($"1. Latin name\t-\t{fishInAquarium[chosenFish-1].GetLatinName()}");
                    Console.WriteLine($"2. Common name\t-\t{fishInAquarium[chosenFish-1].GetCommonName()}");
                    Console.WriteLine($"3. Quantity\t-\t{fishInAquarium[chosenFish-1].GetQuantity()}");
                    Console.WriteLine($"4. Geography\t-\t{fishInAquarium[chosenFish-1].GetGeography()}");
                    Console.WriteLine("0. DONE - GO TO PREVIOUS MENU");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.Write("\nSelect > ");
                } while (!int.TryParse(Convert.ToString(Console.ReadLine()), out editFishChoise) || editFishChoise < 0 || editFishChoise > 4);

                switch (editFishChoise)
                {
                    case 1:
                        fishInAquarium[chosenFish-1].SetLatinName();
                        break;
                    case 2:
                        fishInAquarium[chosenFish - 1].SetCommonName();
                        break;
                    case 3:
                        fishInAquarium[chosenFish - 1].SetQuantity();
                        break;
                    case 4:
                        fishInAquarium[chosenFish - 1].SetGeography();
                        break;
                    case 0:
                        return;
                }
            } while (editFishChoise != 0);
        }


        public int GetSizeInLiters()
        {
            return sizeInLiters;
        }

        public String GetName()
        {
            return name;
        }

        public String GetStyle()
        {
            return style;   
        }

        public String GetLighting()
        {
            return lighting;
        }

        public int GetNumOfFish()
        {
            return numberOfFish;
        }

        public String GetDimensionString()
        {
            return $"{lengthInDecimeters * 10}x{widthInDecimeters * 10}x{heightInDecimeters * 10}";
        }

        private void ResetDimensions()
        {
            this.lengthInDecimeters = 0;
            this.widthInDecimeters = 0;
            this.heightInDecimeters = 0;
        }

        public List<Fish> GetFishInAquarium()
        {
            return fishInAquarium;
        }

        public String GetLastFed()
        {
            return lastFed;
        }
    }
}
