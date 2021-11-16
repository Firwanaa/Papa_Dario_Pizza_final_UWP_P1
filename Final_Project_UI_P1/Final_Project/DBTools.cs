/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: 000000000                  *
 * Final Project - Part 1          * 
 * DBTools - Handy Tools           *
 ***********************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Windows.UI.Popups;
using System.Diagnostics;
using System.Data;
using Windows.UI.Xaml;

namespace Final_Project
{
    public abstract class DBTools
    {
        //User loggedUser = new User();
        //Global boolean
        public static bool isLogged;
        //Global Username
        public static string username = "";
        //Global order
        public static String orderdetails = string.Empty;
        //Global Combo
        public static bool isCombo = false;
        //Connection Configuration
        public static SqlConnection conn = new SqlConnection();
        public static string conString = "Server=(local);Database=Spring2021Exam;" +
                   "User=PapaDario;Password=12345";
        public static SqlCommand cmd;

        /***********************************************
        *   Checks if username Taken                   *
        ************************************************/
        public static bool isValid_user(string username)
        {
            //User tempUser = new User();
            bool isExist = false;
            {
                try
                {
                    Debug.WriteLine("Before Connecttion");
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();

                    string tempStr;
                    //string tempPass;
                    string query = @"select * from  [dbo].[User]";
                    cmd.CommandText = query;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Debug.WriteLine("Try 5");
                    while (reader.Read())
                    {
                        tempStr = reader.GetString(1);
                        //tempPass = reader.GetString(5);
                        if (tempStr.ToUpper() == username.ToUpper())
                        {
                            isExist = false;
                            break;
                        }
                        else { isExist = true; };
                    }
                    cmd.Dispose();//free up resources in memory
                    conn.Close();
                    return isExist;
                }
                catch (Exception e) { Debug.WriteLine(e.Message); return isExist; }
            }
        }

        /***********************************************
        *   Returns UserID                             *
        ************************************************/
        public static int usere_id(string username)
        {
            //User tempUser = new User();
            int userid = 0;
            {
                Debug.WriteLine("Before Connecttion");
                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();
                string tempStr;
                //string tempPass;
                string query = @"select * from  [dbo].[User]";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Debug.WriteLine("Try 5");
                while (reader.Read())
                {
                    tempStr = reader.GetString(1);
                    userid = reader.GetInt32(0);
                    //tempPass = reader.GetString(5);
                    if (tempStr.ToUpper() == username.ToUpper())
                    {
                        userid = reader.GetInt32(0);
                        break;
                    }
                    else { userid = 0; };
                }
                cmd.Dispose();//free up resources in memory
                conn.Close(); //close
                return userid;
            }
        }
    }
}
