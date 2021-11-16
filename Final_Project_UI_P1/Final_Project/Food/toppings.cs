/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: 9234we233                  *
 * Final Project - Part 1          * 
 * Toppings Child Class            *
 ***********************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Food
{
    class toppings : foodInterface
    {
        string name { set; get; }
        double price { set; get; }
        public string getfoodName()
        {
            return this.name;
        }

        public double getFoodPrice()
        {
            return this.price;
        }
    }
}
