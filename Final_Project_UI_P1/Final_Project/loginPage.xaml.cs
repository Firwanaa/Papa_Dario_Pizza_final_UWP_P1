/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: 000000000                  *
 * Final Project - Part 1          * 
 * Login page                      *
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Final_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class loginPage : Page
    {
        private SqlConnection conn = new SqlConnection();
        //Connectionstring ->  contains the information needed to connect to 
        //Spring2021Exam
        private string conString = "Server=(local);Database=Spring2021Exam;" +
                   "User=PapaDario;Password=12345";
        //need a commandobjectt o excute the query
        private SqlCommand cmd;
        /***********************************************
        *   Load Login Page - At start                 *
        ************************************************/
        public loginPage()
        {
            this.InitializeComponent();
            if (DBTools.isLogged == true)
            {
                tbLogPassword.IsEnabled = false;
                tbLogPassword.Password = "";
                tbLogUsername.IsEnabled = false;

                if (DBTools.isLogged == true) { btnEdit.IsEnabled = true; btnSubmit.IsEnabled = false; }
            }
        }
        /***********************************************
        *   Login                                      *
        ************************************************/
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            User tempUser = new User();
            string tempStr = "";
            string tempPass = "";
            DBTools.isLogged = false;
            tempUser.Username = tbLogUsername.Text.ToUpper();
            tempUser.password = tbLogPassword.Password.ToString();

            if ((tempUser.password == "") || (tempUser.Username == ""))
            {
                string message = "No Empty Boxes";
                //string caption = "Error";
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
                    Debug.WriteLine("Try 1");
                    // @"select * from  [dbo].[User] where username=" + "'" + @tempUser.username + "'" + " and password=" + "'" + @tempUser.password + "'";
                    string query = @"select * from  [dbo].[User]";
                    Debug.WriteLine("Try 2");
                    cmd.CommandText = query;
                    Debug.WriteLine("Try 3");

                    conn.Open();
                    Debug.WriteLine("Try 4");
                    //SqlDataReader reader =  cmd.ExecuteReader();
                    //Debug.WriteLine("Try 5");
                    SqlDataReader reader = cmd.ExecuteReader();
                    Debug.WriteLine("Try 5");
                    while (reader.Read())
                    {
                        tempStr = reader.GetString(1);
                        tempPass = reader.GetString(5);
                        if (tempStr.ToUpper() == tempUser.Username.ToUpper() && tempPass == tempUser.password)
                        {

                            string message2 = tempUser.Username.ToUpper()+" Successfully logged In !";
                            Debug.WriteLine("Try 7");
                            //string caption = "Error";
                            var dialog = new MessageDialog(message2);
                            DBTools.isLogged = true;
                            DBTools.username = tempUser.Username;
                            //Frame.Navigate(typeof(ordersPage));
                            await dialog.ShowAsync();
                            tbLogPassword.IsEnabled = false;
                            tbLogUsername.IsEnabled = false;
                            btnSubmit.IsEnabled = false;
                            btnEdit.Visibility = Visibility.Visible;
                            btnEdit.IsEnabled = true;
                            return;
                        }
                    }
                    Debug.WriteLine("Try 6");
                    if (DBTools.isLogged == false)
                    {
                        string message3 = "Invalid Username or Password !";
                        Debug.WriteLine("Try 7");
                        //string caption = "Error";
                        var dialog2 = new MessageDialog(message3);
                        DBTools.isLogged = false;
                        await dialog2.ShowAsync();
                        return;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Catch 1");
                    Debug.WriteLine(ex.ToString());
                    Debug.WriteLine("Catch 2");
                }
                finally
                {
                    Debug.WriteLine("finally 1");
                    cmd.Dispose();//free up resources in memory
                    conn.Close();
                    //refreshDate();

                }
            }
        }
        /***********************************************
        *   Logout                                     *
        ************************************************/
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            loggedOut();

        }
        void loggedOut()
        {
            tbLogPassword.IsEnabled = true;
            tbLogPassword.Password = "";
            tbLogUsername.IsEnabled = true;
            btnSubmit.IsEnabled = true;
            DBTools.username = "";
            DBTools.isLogged = false;
            DBTools.isCombo = false;
            btnEdit.Visibility = Visibility.Collapsed;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //Hide Log_in Form
            tbLogUsername.Visibility = Visibility.Collapsed;
            lbluser.Visibility = Visibility.Collapsed;
            tbLogPassword.Visibility = Visibility.Collapsed;
            lblpass.Visibility = Visibility.Collapsed;

            //Show Edit from
            lblHeader.Text = "Update Info";
            tbEditName.Visibility = Visibility.Visible;
            lblEditName.Visibility = Visibility.Visible;
            tbEditEmail.Visibility = Visibility.Visible;
            lblEditEmail.Visibility = Visibility.Visible;
            tbEditNumber.Visibility = Visibility.Visible;
            lblEditNumber.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Collapsed;
            btnLogout.Visibility = Visibility.Collapsed;
            btnSubmit.Visibility = Visibility.Collapsed;
            btnOK.Visibility = Visibility.Visible;
            Find_User(DBTools.username);

        }

        /***********************************************
        *   Find User and Populate TB                  *
        ************************************************/
        private void Find_User(String user)
        {
            string dbtempStr = "";

            Debug.WriteLine("Before Connecttion");
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = @"select * from  [dbo].[User] where username=" + "'" + @user + "'";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dbtempStr = reader.GetString(1);
                    if (user.ToUpper() == dbtempStr.ToUpper())
                    {
                        tbEditName.Text = reader.GetString(4);
                        tbEditNumber.Text = reader.GetString(3);
                        tbEditEmail.Text = reader.GetString(2);
                        return;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Catch 1");
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("Catch 2");
            }
            finally
            {
                Debug.WriteLine("finally 1");
                cmd.Dispose();//free up resources in memory
                conn.Close();
                //refreshDate();
            }
        }
        /***********************************************
        *  Update DB                                   *
        ************************************************/
        private async void btnOK_Click(object sender, RoutedEventArgs e)
        {
            //values from textboxes
            string tempName = tbEditName.Text;
            string tempEmail = tbEditEmail.Text;
            string tempNumber = tbEditNumber.Text;
            string tempUser = DBTools.username.ToUpper();
            if ((tempName == "" || tempEmail == "" || tempNumber == ""))
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
                    Debug.WriteLine("Try 1");
                    string query = @"UPDATE [dbo].[User] set [name]=" + "'" + @tempName + "'"
                                    + ", [email]=" + "'" + @tempEmail + "'"
                                    + ",[phone]=" + "'" + @tempNumber + "' " + "where " + "[username]=" + "'" + @tempUser + "'"
                                    ;
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                    string message3 = tempUser.ToUpper() + " Updated Successfully !";
                    var dialog2 = new MessageDialog(message3);
                    await dialog2.ShowAsync();

                    //Show Log_in Form
                    lblHeader.Text = "Log In";
                    tbLogUsername.Visibility = Visibility.Visible;
                    lbluser.Visibility = Visibility.Visible;
                    tbLogPassword.Visibility = Visibility.Visible;
                    lblpass.Visibility = Visibility.Visible;
                    btnSubmit.Visibility = Visibility.Visible;
                    btnLogout.Visibility = Visibility.Visible;
                    //Hid Edit From
                    tbEditName.Visibility = Visibility.Collapsed;
                    lblEditName.Visibility = Visibility.Collapsed;
                    tbEditEmail.Visibility = Visibility.Collapsed;
                    lblEditEmail.Visibility = Visibility.Collapsed;
                    tbEditNumber.Visibility = Visibility.Collapsed;
                    lblEditNumber.Visibility = Visibility.Collapsed;
                    btnOK.Visibility = Visibility.Collapsed;
                    btnEdit.Visibility = Visibility.Visible;

                    return;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Catch 1");
                    Debug.WriteLine(ex.ToString());
                    Debug.WriteLine("Catch 2");
                }
                finally
                {
                    Debug.WriteLine("finally 1");
                    cmd.Dispose();//free up resources in memory
                    conn.Close();
                }
            }
        }
    }
}
