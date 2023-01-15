using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_Board_Test
{
    interface I_Items
    {
        void Craft();
    }

    public class Items : I_Items
    {

        private String _name = "Item";
        public String interact_text = "You....";
        public String Name { get => _name; set { _name = value; } }

        public void Craft()
        {
            Console.Write($"Crafting {this._name}");
        }

        public override string ToString()
        {
            return this._name.ToString();
        }
    }

    public class Iron_Ore : Items
    {
        private String _name = "Iron";
        public String interact_text;
        public Iron_Ore() { Name = _name; interact_text = "You mine Iron"; }
    }

    public class Item_Stick : Items
    {
        private String _name = "Stick";
        public String interact_text;

        public Item_Stick() { Name = _name; interact_text = "You pickup a stick";  }
    }

    public class Crafted_Item : Items
    {
        public String Requirement { get; set; }
        public int Amount { get; set; }


        public Crafted_Item(String name)
        {
            Name = name;
        }
        public Crafted_Item(String name, String required, int amount) 
        { 
            Name = name;
            Requirement = required;
            Amount = amount;
        }


    }
}
