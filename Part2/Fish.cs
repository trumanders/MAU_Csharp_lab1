using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class Fish
    {
        private int quantity;
        private String latinName;
        private String commonName;
        private String geography;

        public Fish()
        { 
            quantity = 0;
            latinName = "name not entered";
            commonName = "name not entered";
            geography = "not entered";
        }


        public void SetLatinName()
        {
            Console.Write("Enter latin name > ");
            latinName = Console.ReadLine();
        }


        public void SetCommonName()
        {
            Console.Write("Enter common name > ");
            commonName = Console.ReadLine();
        }


        // Set quantity directly (for deleting fish)
        public void SetQuantity(int quantity)
        {
            this.quantity = quantity;
        }


        public void SetQuantity()
        {
            do
            {
                Console.Write("Enter quantity of this fish > ");
            } while (!int.TryParse(Convert.ToString(Console.ReadLine()), out quantity) || quantity < 0);
        }


        public void SetGeography()
        {
            Console.Write("Enter geographic origin of fish > ");
            geography = Console.ReadLine();
        }


        public String GetLatinName()
        {
            return this.latinName;
        }

        public String GetCommonName()
        {
            return this.commonName;
        }

        public String GetGeography()
        {
            return this.geography;
        }


        public int GetQuantity()
        {
            return this.quantity;
        }
    }
}
