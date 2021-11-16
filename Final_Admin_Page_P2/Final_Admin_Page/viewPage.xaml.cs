/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: 932443234                  *
 * Final Project - Part 2          * 
 * Admin page part                 *
 * View Page                       * 
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

namespace Final_Admin_Page
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class viewPage : Page
    {
        /**************************************************************
          * Connection config                                         *
        ***************************************************************/
        SqlConnection conn = new SqlConnection();
        //Connectionstring ->  contains the information needed to connect to 
        //Spring2021Exam
        string conString = "Server=(local);Database=Spring2021Exam;" +
                    "User=PapaDario;Password=12345";
        SqlCommand cmd;
        /**************************************************************
          * Start                                                     *
        ***************************************************************/
        public viewPage()
        {
            this.InitializeComponent();
            ItemsList.ItemsSource = showDB();
        }
        /**************************************************************
          * Function to Load database to Observable obj               *
        ***************************************************************/
        ObservableCollection<User> showDB()
        {
            ObservableCollection<User> userslist;
            userslist = new ObservableCollection<User>();
            try
            {
                Debug.WriteLine("Before Connecttion");
                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();
                string query = @"select * from  [dbo].[User]";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Debug.WriteLine("Try 5");
                while (reader.Read())
                {
                    userslist.Add(new User()
                    {
                        id = reader.GetInt32(0),
                        username = reader.GetString(1),
                        email = reader.GetString(2),
                        phone = reader.GetString(3),
                        name = reader.GetString(4),
                        role = reader.GetInt32(6)
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                cmd.Dispose();//free up resources in memory
                conn.Close();
            }
            return userslist;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
