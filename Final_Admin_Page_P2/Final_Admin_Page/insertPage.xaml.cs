/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: 921341233                  *
 * Final Project - Part 2          * 
 * Admin page part                 *
 * Insert Page                     * 
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

namespace Final_Admin_Page
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class insertPage : Page
    {
        /**************************************************************
          * Connection config                                         *
        ***************************************************************/
        private SqlConnection conn = new SqlConnection();
        //Spring2021Exam
        private string conString = "Server=(local);Database=Spring2021Exam;" +
                   "User=PapaDario;Password=12345";
        private SqlCommand cmd;
        /**************************************************************
          * Start                                                     *
        ***************************************************************/
        public insertPage()
        {
            this.InitializeComponent();
        }
        /**************************************************************
          * Update DB                                                 *
        ***************************************************************/
        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string tempName = tbName.Text;
            string tempEmail = tbEmail.Text;
            string tempNum = tbNumber.Text;
            string tempUser = tbUsername.Text.ToUpper();
            string tempPass = tbPass.Password.ToString();
            string dbtempStr = null;
            bool found = false;
            if (tempName == "" || tempEmail == "" || tempNum == "" || tempUser == "" || tempPass == "")
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
                    // @"select * from  [dbo].[User] where username=" + "'" + @tempUser.username + "'" + " and password=" + "'" + @tempUser.password + "'";
                    string query = @"select * from  [dbo].[User]";
                    string query2 = @"INSERT INTO [dbo].[User]"
                                      + "([username]"
                                      + ",[email]"
                                      + ",[phone]"
                                      + ",[name]"
                                      + ",[password]"
                                      + ",[role])"
                                + "VALUES"
                                       + "("
                                       + "'" + @tempUser + "'"
                                       + ",'" + @tempEmail + "'"
                                       + ",'" + @tempNum + "'"
                                       + ",'" + @tempName + "'"
                                       + ",'" + @tempPass + "'"
                                       + ",'" + 0 + "')";
                    cmd.CommandText = query;

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dbtempStr = reader.GetString(1);
                        if (tempUser == dbtempStr)
                        {
                            found = true;
                            break;
                        }
                    }
                    reader.Close();
                    if (found)
                    {
                        cmd.CommandText = query2;
                        cmd.ExecuteScalar();
                        string message3 = tempUser.ToUpper() + " Already taken !";
                        var dialog = new MessageDialog(message3);
                        //Frame.Navigate(typeof(ordersPage));
                        await dialog.ShowAsync();
                        return;
                    }
                    else
                    {
                        cmd.CommandText = query2;
                        cmd.ExecuteScalar();
                        string message3 = tempUser.ToUpper() + " Inserted !";
                        var dialog = new MessageDialog(message3);
                        //Frame.Navigate(typeof(ordersPage));
                        await dialog.ShowAsync();
                        tbName.Text = "";
                        tbEmail.Text = "";
                        tbNumber.Text = "";
                        tbUsername.Text = "";
                        tbPass.Password = "";
                        return;
                    }

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
