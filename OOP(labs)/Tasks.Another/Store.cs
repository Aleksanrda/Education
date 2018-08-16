using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Another
{
    public class Store
    {
        private Article[] arrayOfElements = new Article[]
        {
            new Article
            {
                nameOfProduct = "Milk",
                nameOfShop = "Cow",
                costOfProduct = 20,
                number = 128975
            }
        };

        public int this[int number]
        {
            get
            {
                if (number <= 0)
                {
                    throw new ArgumentException("Number can not be negative");
                }

                for (int i = 0; i < arrayOfElements.Length; i++)
                {
                    if(arrayOfElements[i].number == number)
                    {
                        return i;
                    }
                }
                return -1;
            }
            
        }

        public bool IsSearchInformation(string userInput)
        {
            for(int i = 0; i < arrayOfElements.Length; i++)
            {
                if (userInput == arrayOfElements[i].nameOfProduct)
                {
                    return true;
                }
            }

            return false;
        }

        public string WriteInfo(string userInput)
        {
            string resultOutput = "";

            for (int i = 0; i < arrayOfElements.Length; i++)
            {
                if (userInput == arrayOfElements[i].nameOfProduct)
                {
                   return resultOutput = "Shop: " + arrayOfElements[i].nameOfShop + "Cost: " + arrayOfElements[i].costOfProduct;
                }
            }

            return resultOutput = "Such product dont exist in our shop";
        }
    }
}
