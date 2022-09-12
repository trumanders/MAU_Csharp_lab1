using System;
using System.Collections.Generic;

namespace Part2;


class Program
{
    public static void Main(String[] args)
    {
        List<Aquarium> allAquariums = new List<Aquarium>();
        Menu(allAquariums);
    }

    public static void Menu(List<Aquarium> allAquariums)
    {
        int menuChoise;
        do
        {
            do
            {
                Console.WriteLine("\n\nAQUARIUM AND FISH DATABASE");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"1. Add and edit new aquarium\t{Aquarium.numOfAquariums}");
                Console.WriteLine("2. Show all aquariums");
                Console.WriteLine("3. Edit aquarium");
                Console.WriteLine("4. Show all fish");
                Console.WriteLine("5. Delete aquarium");
                Console.WriteLine("0. Quit");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.Write("\nSelect > ");
            } while (!int.TryParse(Console.ReadLine(), out menuChoise) || menuChoise < 0 || menuChoise > 5); 
                switch (menuChoise)
                {
                    case 1:
                        AddAquarium(allAquariums);
                        break;
                    case 2:
                        ShowAllAquariums(allAquariums);
                        break;
                    case 3:
                        SelectAquariumToEdit(allAquariums);
                        break;
                    case 4:
                        showAllFish(allAquariums);
                        break;
                    case 5:
                        DeleteAquarium(allAquariums);
                        break;
                }
        } while (menuChoise != 0);
        return;
    }



    private static void DeleteAquarium(List<Aquarium> allAquariums)
    {
        int deleteChoise;
        do
        {
            ShowAllAquariums(allAquariums);
            Console.WriteLine("Choose aquarium to delete > ");
        } while (!int.TryParse(Console.ReadLine(), out deleteChoise) || deleteChoise < 0 || deleteChoise > 5);
        allAquariums.RemoveAt(deleteChoise-1);
    }
    private static void showAllFish(List<Aquarium> allAquariums)
    {
        Console.WriteLine("LIST OF ALL FISH");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        foreach (Aquarium aquarium in allAquariums)
        {
            foreach (Fish fish in aquarium.GetFishInAquarium())
            {
                Console.WriteLine(fish.GetLatinName().PadRight(30) + "(" + fish.GetQuantity() + ") in aquarium: " + aquarium.GetName());
            }
        }
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.ReadLine();
    }


    static void AddAquarium(List<Aquarium> allAquariums)
    {
        Console.WriteLine("\nNEW AQUARIUM ADDED - edit info below.");
        
        // Create new instance of Aquarium - constructor calls edit method in Aquarium
        allAquariums.Add(new Aquarium());     
    }


    static void ShowAllAquariums(List<Aquarium> allAquariums)
    {
        Console.WriteLine("\nLIST OF ALL AQUARIUMS");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.Write("#".PadRight(4));
        Console.Write("NAME".PadRight(21));
        Console.Write("LITERS".PadRight(9));
        Console.Write("DIMEMSION".PadRight(14));
        Console.Write("STYLE".PadRight(25));
        Console.Write("LIGHT".PadRight(10));
        Console.Write("FISH".PadRight(6));
        Console.WriteLine("LAST FED");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        int aquariumNumber = 1;
        foreach (Aquarium a in allAquariums)
        {
            Console.WriteLine($"{aquariumNumber}.".PadRight(4) + $"{a.GetName().PadRight(21)}{a.GetSizeInLiters().ToString().PadRight(9)}{a.GetDimensionString().PadRight(14)}{a.GetStyle().PadRight(25)}{a.GetLighting().PadRight(10)}{a.GetNumOfFish().ToString().PadRight(6)}{a.GetLastFed()}");
            aquariumNumber++;
        }
        Console.WriteLine();
    }


    static void SelectAquariumToEdit(List<Aquarium> allAquariums)
    {
        int chosenAquarium;
        if (allAquariums.Count == 0)
        {
            Console.WriteLine("You haven't added any aquariums yet");
            Console.ReadLine();
            return;
        }
        do
        {
            ShowAllAquariums(allAquariums);
            if (allAquariums.Count > 0)
            {
                Console.Write("Select aquarium to edit > ");
            }

            // Don't allow selecting an non-existing aquarium
        } while (!int.TryParse(Console.ReadLine(), out chosenAquarium) || chosenAquarium < 0 || chosenAquarium > allAquariums.Count);

        // Call edit for the selected aquarium
        if (chosenAquarium != 0)
        {
            allAquariums[chosenAquarium - 1].EditAquarium();
        }
    }
}