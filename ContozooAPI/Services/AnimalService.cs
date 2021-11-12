using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContozooAPI.Models;

namespace ContozooAPI.Services
{
    public class AnimalService
    {
        static List<Animals> Animals { get; }
        static int nextId = 3;
        static AnimalService()
        {
            Animals = new List<Animals>
        {
            new Animals { AnimalId = 1, Name = "Monkeys", Number = "12", Location = "Safari Zone" , ActiveHours = "9am-11am" , Notes = "They like bananas." },
            new Animals { AnimalId = 2, Name = "Lions", Number = "4", Location = "Safari Zone", ActiveHours = "9am-11am, 6pm-8pm" , Notes = "They male lion is named Simba. The females are named Nala, Rasa, and Tara."},
            new Animals { AnimalId = 3, Name = "Goats", Number = "14", Location = "Petting Zoo" , ActiveHours = "10am-5pm" , Notes = "You can feed the goats and pet them!" }
        };
        }

        public static List<Animals> GetAll() => Animals;

        public static Animals? Get(int id) => Animals.FirstOrDefault(p => p.AnimalId == id);

        public static void Add(Animals animal)
        {
            animal.AnimalId = nextId++;
            Animals.Add(animal);
        }

        public static void Delete(int id)
        {
            var animal = Get(id);
            if (animal is null)
                return;

            Animals.Remove(animal);
        }

        public static void Update(Animals animal)
        {
            var index = Animals.FindIndex(a => a.AnimalId == animal.AnimalId);
            if (index == -1)
                return;

            Animals[index] = animal;
        }
    }
}
