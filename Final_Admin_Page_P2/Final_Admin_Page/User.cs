/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: 9812312312                 *
 * Final Project - Part 2          * 
 * Admin page part                 *
 * User Class                      * 
 ***********************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Admin_Page
{
     class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public int role { get; set; }
    }
}
