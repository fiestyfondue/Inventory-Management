using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace PracticeW3
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory rice = new Inventory()
            {
                Name = "Basmati",
                weight = 30,
                Price = 20
            }; 
            Inventory pulses = new Inventory()
            {
                Name = "Daal",
                weight = 40,
                Price = 35
            };
            Inventory wheats = new Inventory()
            {
              
                Name = "Wheat",
                weight = 100,
                Price = 25
            };

            List<Inventory> inventories = new List<Inventory>();
            inventories.Add(rice);
            inventories.Add(pulses);
            inventories.Add(wheats);

            //Serialization object from string to json format.//
            string strResult = JsonConvert.SerializeObject(inventories);
            File.WriteAllText(@"Inventort.json", strResult);
            Console.WriteLine("Stored successfully!!");

            //Deserialization object from json file to string format.//
            strResult = File.ReadAllText(@"Inventort.json");
            var list = JsonConvert.DeserializeObject<List<Inventory>>(strResult);
            float totalValue = 0;
            foreach (Inventory inventory in list)
            {
                Console.WriteLine($"Name: {inventory.Name}\n Weight: {inventory.weight}\n Price: {inventory.Price}/Kg\n Total Price: {inventory.weight * inventory.Price}\n");
                totalValue += (inventory.Price * inventory.weight);
            }
            Console.WriteLine($"Total Value of inventory:{totalValue}");

        }

    }    
}
