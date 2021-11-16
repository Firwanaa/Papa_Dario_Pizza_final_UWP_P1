/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: 891231231                  *
 * Final Project - Part 2          * 
 * Admin page part                 *
 * Delete Page                     * 
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
    public sealed partial class deletePage : Page
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
        public deletePage()
        {
            this.InitializeComponent();
        }
        /**************************************************************
          * Find Then Delete From DB                                  *
        ***************************************************************/
        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string tempStr = tbUsername.Text.ToUpper();
            string dbtempStr = null;
            bool found = false;
            if ((tempStr == ""))
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
                    // @"select * from  [dbo].[User] where username=" + "'" + @tempUser.username + "'" + " and password=" + "'" + @tempUser.password + "'";
                    string query = @"select * from  [dbo].[User]";
                    string query2 = @"Delete from [dbo].[User] where username=" + "'" + @tempStr + "'";
                    cmd.CommandText = query;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dbtempStr = reader.GetString(1);
                        int role = reader.GetInt32(6);
                        if (tempStr == dbtempStr)
                        {
                            if (role == 1)
                            {
                                string message3 = " Unauthorized Operation !";
                                var dialog = new MessageDialog(message3);
                                //Frame.Navigate(typeof(ordersPage));
                                await dialog.ShowAsync();
                                return;
                            }else { found = true; break; }                                                     
                        }
                    }
                    reader.Close();
                    if (found)
                    {
                        cmd.CommandText = query2;
                        cmd.ExecuteScalar();
                        string message3 = tempStr.ToUpper() + " Deleted !";
                        var dialog = new MessageDialog(message3);
                        await dialog.ShowAsync();
                        tbUsername.Text = "";
                        return;
                    }
                    else
                    {
                        cmd.CommandText = query2;
                        cmd.ExecuteScalar();
                        string message3 = tempStr.ToUpper() + " Not Found !";
                        var dialog = new MessageDialog(message3);
                        await dialog.ShowAsync();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Catch 1");
                    Debug.WriteLine(ex.ToString());
                    Debug.WriteLine("Catch 2");
                    string message3 = tempStr.ToUpper() + " Not Found !";
                    var dialog = new MessageDialog(message3);
                    await dialog.ShowAsync();
                    return;
                }
                finally
                {
                    Debug.WriteLine("finally 1");
                    cmd.Dispose();//free up resources in memory
                    conn.Close();//close
                }

            }
        }
    }
}
