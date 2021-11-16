/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: 992323232                  *
 * Final Project - Part 1          * 
 * User Class Inherits DBTool      *
 ***********************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace Final_Project
{
    class User : DBTools
    {
        public string Username { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public int role { get; set; }
    }
}
