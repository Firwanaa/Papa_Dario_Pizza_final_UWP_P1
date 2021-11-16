/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: 000000000                  *
 * Final Project - Part 1          * 
 * Register new user page          *
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
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using Windows.UI.Popups;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Final_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class registerPage : Page
    {
        private SqlConnection conn = new SqlConnection();
        //Spring2021Exam
        private string conString = "Server=(local);Database=Spring2021Exam;" +
                   "User=PapaDario;Password=12345";
        //need a command object to excute the query
        private SqlCommand cmd;

        /***********************************************
        *   Load Register Page - At start              *
        ************************************************/
        public registerPage()
        {
            this.InitializeComponent();
            if (DBTools.isLogged) 
            {
                tbEmail.IsEnabled = false;
                tbName.IsEnabled = false;
                tbPassword.IsEnabled = false;
                tbPhone.IsEnabled = false;
                tbUsername.IsEnabled = false;
                btnSubmit.IsEnabled = false;
            }
        }

        /***********************************************
        *   Submit Btn                                 *
        ************************************************/
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            User tempUser = new User();
            tempUser.name = tbName.Text.ToUpper();
            tempUser.email = tbEmail.Text;
            tempUser.phone = tbPhone.Text;
            tempUser.Username = tbUsername.Text;
            tempUser.password = tbPassword.Password.ToString();
            tempUser.role = 0;
            bool checkUsername = DBTools.isValid_user(tempUser.Username); //<-- checks if username taken
            if ((tempUser.password == "") || (tempUser.email == "") || (tempUser.phone == "") || (tempUser.name == ""))
            {
                string message = "No Empty Boxes";
                var dialog = new MessageDialog(message);
                await dialog.ShowAsync();
            }
            else
            {
                Debug.WriteLine("Before Connecttion");
                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();
                try
                {
                    Debug.WriteLine("Try 1");//<-- Debugging connection line by line - Try Block
                    if (checkUsername == false)
                    {
                        string message2 = "Username already taken !";
                        var dialog = new MessageDialog(message2);
                        await dialog.ShowAsync();
                        return;
                    }
                    string query = @"Insert into [dbo].[User] VALUES('"
                                    + @tempUser.Username + "','"
                                    + @tempUser.email + "','"
                                    + @tempUser.phone + "','"
                                    + @tempUser.name + "','"
                                    + @tempUser.password + "','"
                                    + @tempUser.role + "')";

                    Debug.WriteLine("Try 2");
                    cmd.CommandText = query;
                    Debug.WriteLine("Try 3");
                    conn.Open();
                    Debug.WriteLine("Try 4");
                    cmd.ExecuteScalar();
                    Debug.WriteLine("Try 5");
                    if (checkUsername == true)
                    {
                        string message2 = tempUser.Username.ToUpper() +" Successfully Joined Our Club";
                        //string caption = "Error";
                        var dialog = new MessageDialog(message2);

                        await dialog.ShowAsync();
                        return;
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
                    //refreshDate();
                }
            }
        }
        //addnew
        private void Add_new(object sender, EventArgs e)
        {

        }
    }
}
