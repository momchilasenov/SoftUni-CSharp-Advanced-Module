using System;
using System.Linq;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> idList = new List<IIdentifiable>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] data = command.Split();

                if (data.Length == 2)
                {
                    string model = data[0];
                    string id = data[1];

                    idList.Add(new Robot(model, id));
                }
                else if (data.Length == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = (data[2]);

                    idList.Add(new Citizen(name, age, id));
                }
                                

            }

            string idEnding = Console.ReadLine();

            var detainedIds = idList
                .Where(i => i.Id.EndsWith(idEnding));

           foreach(var id in detainedIds)
            {
                Console.WriteLine(id.Id);
            }
        }
    }
}
