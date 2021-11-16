/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: 000000000                  *
 * Final Project - Part 1          * 
 * My Orders page                  *
 ***********************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Data.SqlClient;
using Windows.UI.Popups;
using System.Diagnostics;
using System.Data;
using System.Collections.ObjectModel;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Final_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class myordersPage : Page
    {
        SqlConnection conn = new SqlConnection();
        //Spring2021Exam
        string conString = "Server=(local);Database=Spring2021Exam;" +
                    "User=PapaDario;Password=12345";
        SqlCommand cmd;
        /***********************************************
        *   Load myorder Page - At start               *
        ************************************************/
        public myordersPage()
        {
            this.InitializeComponent();
            ItemsList.ItemsSource = showDB();
            showDB();
            //tbYourORder.Text = DBTools.orderdetails;
        }
        /***********************************************
        *   Load Orders Table into ListView - By user  *
        ************************************************/
        ObservableCollection<Orders> showDB()
        {
            ObservableCollection<Orders> Ord;
            Ord = new ObservableCollection<Orders>();
            if (DBTools.isLogged == true)
            {
                Debug.WriteLine("Before Connecttion");
                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();

                string tempStr;
                //string tempPass;
                string query = @"select * from  [dbo].[Orders] where [username]=" + "'" + @DBTools.username + "'";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Debug.WriteLine("Try 5");
                while (reader.Read())
                {
                    tempStr = reader.GetString(5);
                    //tempPass = reader.GetString(5);
                    if (tempStr == DBTools.username.ToUpper() && DBTools.username != "")
                    {
                        Ord.Add(new Orders() { username = reader.GetString(5), pizza_size = reader.GetInt32(1), toppingsStr = reader.GetString(2), additionsStr = reader.GetString(3), drinksStr = reader.GetString(4), price = reader.GetDouble(6) });
                    }
                }
                cmd.Dispose();//free up resources in memory
                conn.Close(); //close
            }
            return Ord;
        }
    }
}
