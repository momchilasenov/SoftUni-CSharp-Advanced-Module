using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    public class Shirt
    {
        //3 types of Class Members
        // 1. Fields (for private data)
        private string size;
        private int price;
        private int quantity;

        // 2. Property (for public data)
        public string Size { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        // 3. Method - Behaviour of a class 
        public void Wash()
        {
            Console.WriteLine("Tshirt has been cleaned");
        }
    }


}
