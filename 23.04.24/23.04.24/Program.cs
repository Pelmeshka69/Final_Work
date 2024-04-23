using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace _23._04._24
{
    public class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intellect { get; set; }
        public List<Item> Inventory { get; set; }

        public Character()
        {
            Inventory = new List<Item>();
        }

        public override string ToString()
        {
            return $"Name: {Name}, Level: {Level}, Health: {Health}, Strength: {Strength}, Agility: {Agility}, Intellect: {Intellect}, Inventory: {string.Join(", ", Inventory.Select(i => i.Name))}";
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Type: {Type}, Value: {Value}, Weight: {Weight}";
        }
    }

    public class Game
    {
        public List<Character> Characters { get; set; }
        public List<Item> Items { get; set; }

        public Game()
        {
            Characters = new List<Character>();
            Items = new List<Item>();
        }

        public void AddCharacter(Character character)
        {
            Characters.Add(character);
        }

        public void RemoveCharacter(Character character)
        {
            Characters.Remove(character);
        }

        public void AddItemToInventory(Character character, Item item)
        {
            character.Inventory.Add(item);
        }

        public void RemoveItemFromInventory(Character character, Item item)
        {
            character.Inventory.Remove(item);
        }

        public void ChangeCharacterLevel(Character character, int newLevel)
        {
            character.Level = newLevel;
        }

        public Character FindCharacterByName(string name)
        {
            return Characters.FirstOrDefault(p => p.Name == name);
        }

        public void SaveData()
        {
            string json = JsonConvert.SerializeObject(this);
            System.IO.File.WriteAllText(@"C:\temp\gameData.json", json);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            
            Character character = new Character { Name = "Character 1", Level = 1, Health = 100, Strength = 10, Agility = 10, Intellect = 10 };
            game.AddCharacter(character);

            
            Item item = new Item { Name = "Item 1", Type = "Weapon", Value = 100, Weight = 10.0 };
            game.AddItemToInventory(character, item);

            
            Console.WriteLine(character);

           
            game.RemoveItemFromInventory(character, item);

            
            game.RemoveCharacter(character);

            
            game.SaveData();
        }
    }
}
