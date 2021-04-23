using System;
using System.Collections.Generic;
using System.Text;

namespace Static_Class
{
    public class Mathematics
    {
        public int PI { get; set; }

        //public Mathematics math = new Mathematics(); //this causes a stack overflow

        public static int Something { get; set; }

        public static int Add (int a, int b) //this method is static -> it's attached directly to the class
        {
            return a + b + Something; //не можеш да използваш PI. Add не е вързан към конкретен обект, той е вързан за класа. PI не съществува в контекста на глобалния клас а съществува само в контекста на отделна инстанция която се създава. Можеш да извикаш само статични пропъртита и методи.
        }

        public int Multiply (int a, int b)
        {
            return a * b 
                + this.PI //PI работи тук защото и Multiply и PI се намират на конкретния обект
                + Mathematics.Something; //Something също работи, защото се вижда от всичко в класа
        }
    }
}
