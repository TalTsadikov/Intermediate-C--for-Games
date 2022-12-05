using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    class CombatSystem
    {
        public void Combat(List<Unit> army1, List<Unit> army2)
        {
            bool myTurn = true;

            int army1Resources = Random.Shared.Next(100, 250);
            int army2Resources = Random.Shared.Next(100, 250);
            int army1LootedResources = 0;
            int army2LootedResources = 0;

            Console.WriteLine($"Player 1 started with " + army1Resources + " resources");
            Console.WriteLine($"While player 2 started with " + army2Resources + " resources \n");

            while (army1.Count > 0 && army2.Count > 0)
            {
                var unit1 = army1[Random.Shared.Next(0, army1.Count)];
                var unit2 = army2[Random.Shared.Next(0, army2.Count)];

                if (myTurn)
                {
                    unit1.Attack(unit2);
                    if (unit2.IsDead)
                    {
                        army1LootedResources += Loot(unit1, army2Resources);
                        army2.Remove(unit2);
                    }
                }
                else
                {
                    unit2.Attack(unit1);
                    if (unit1.IsDead)
                    {
                        army2LootedResources += Loot(unit2, army1Resources);
                        army1.Remove(unit1);
                    }
                }

                myTurn = !myTurn;
            }

            Console.WriteLine($"Player {(army1.Count == 0 ? 2 : 1)} won");
            Console.WriteLine($"And Looted {(army1.Count == 0 ? army2LootedResources : army1LootedResources)} resources from the enemy");
        }

        public int Loot(Unit looter, int resources)
        {
            int overallResources = resources;
            overallResources -= looter.Capacity;
            resources -= overallResources;
            return resources;
        }

        public List<Unit> GeneratePlayerArmy()
        {
            Console.WriteLine("Hello dear player please choose which army race would you like to play as");
            Console.WriteLine("1. Human");
            Console.WriteLine("2. Cyborg");
            Console.WriteLine("3. Elf");
            int input = int.Parse(Console.ReadLine());
            List<Unit> army = new();

            switch (input)
            {
                case 1:
                    army =  GenerateHumanArmy();
                    break;
                case 2:
                    army = GenerateCyborgArmy();
                    break;
                case 3:
                    army = GenerateElfArmy();
                    break;
            }

            Console.WriteLine("Your army has:");

            foreach (var item in army)
            {
                Console.WriteLine("Unit: " + item.Type);
            }

            return army;
        }

        public List<Unit> GenerateEnemyArmy()
        {
            List<Unit> army = new();

            var num = Random.Shared.Next(0, 3);

            switch (num)
            {
                case 0:
                    army = GenerateHumanArmy();
                    break;
                case 1:
                    army = GenerateCyborgArmy();
                    break;
                case 2:
                    army = GenerateElfArmy();
                    break;
            }

            Console.WriteLine("And your Enemy has: ");

            foreach (var item in army)
            {
                Console.WriteLine("Unit: " + item.Type);
            }

            return army;
        }

        public List<Unit> GenerateHumanArmy()
        {
            List<Unit> army = new();

            for (int i = 0; i < 5; i++)
            {
                var unit = Random.Shared.Next(0, 3);

                switch (unit)
                {
                    case 0:
                        army.Add(new FireBreather());
                        break;
                    case 1:
                        army.Add(new Knight());
                        break;
                    case 2:
                        army.Add(new Assassin());
                        break;
                }
            }

            return army;
        }

        public List<Unit> GenerateCyborgArmy()
        {
            List<Unit> army = new();

            for (int i = 0; i < 5; i++)
            {
                var unit = Random.Shared.Next(0, 3);

                switch (unit)
                {
                    case 0:
                        army.Add(new Samurai());
                        break;
                    case 1:
                        army.Add(new Monk());
                        break;
                    case 2:
                        army.Add(new Engineer());
                        break;
                }
            }

            return army;
        }

        public List<Unit> GenerateElfArmy()
        {
            List<Unit> army = new();

            for (int i = 0; i < 5; i++)
            {
                var unit = Random.Shared.Next(0, 3);

                switch (unit)
                {
                    case 0:
                        army.Add(new Witch());
                        break;
                    case 1:
                        army.Add(new Thief());
                        break;
                    case 2:
                        army.Add(new Archer());
                        break;
                }
            }

            return army;
        }
    }
}
