/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: 990003030                  *
 * Final Project - Part 1          * 
 * Pizza     Child Class           *
 ***********************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Food
{
    class Pizza : foodInterface
    {

        string name { set; get; }
        string psize { set; get; }
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
