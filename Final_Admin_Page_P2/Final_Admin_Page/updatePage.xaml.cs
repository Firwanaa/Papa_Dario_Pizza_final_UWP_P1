/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: 898891239                  *
 * Final Project - Part 2          * 
 * Admin page part                 *
 * Update Page                     * 
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
    public sealed partial class updatePage : Page
    {
        /**************************************************************
          * Connection config                                         *
        ***************************************************************/
        private SqlConnection conn = new SqlConnection();
        //Spring2021Exam
        private string conString = "Server=(local);Database=Spring2021Exam;" +
                   "User=PapaDario;Password=12345";
        //need a commandobjectt o excute the query
        private SqlCommand cmd;
        /**************************************************************
          * Start                                                     *
        ***************************************************************/
        public updatePage()
        {
            this.InitializeComponent();
            btnUpdate.IsEnabled = false;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        /***********************************************
         * Find user function                          *
         **********************************************/
        private async void btnFind_Click(object sender, RoutedEventArgs e)
        {
            string tempStr = tbUsername.Text.ToUpper();
            string dbtempStr = "";
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
                    Debug.WriteLine("Try 1");
                    string query = @"select * from  [dbo].[User] where username=" + "'" + @tempStr + "'";
                    Debug.WriteLine("Try 2");
                    cmd.CommandText = query;
                    Debug.WriteLine("Try 3");
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Debug.WriteLine("Try 5");
                    while (reader.Read())
                    {
                        dbtempStr = reader.GetString(1).ToUpper();
                        if (tempStr == dbtempStr)
                        {
                            string message2 = tempStr.ToUpper()+" Record Found !";
                            var dialog = new MessageDialog(message2);
                            await dialog.ShowAsync();
                            tbUsername.IsEnabled = false;
                            tbName.Text = reader.GetString(4);
                            tbNumber.Text = reader.GetString(3);
                            tbEmail.Text = reader.GetString(2);
                            tbUsername.IsEnabled = false;
                            tbEmail.IsEnabled = true;
                            tbName.IsEnabled = true;
                            tbNumber.IsEnabled = true;
                            btnUpdate.IsEnabled = true;
                            return;
                        }
                    }
                    Debug.WriteLine("Try 6");
                    if (tempStr != dbtempStr)
                    {
                        string message3 = tempStr.ToUpper()+" Username Not Found !";
                        var dialog2 = new MessageDialog(message3);
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
         * Update user function                        *
         * *********************************************/
        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //values from textboxes
            string tempU = tbUsername.Text.ToUpper();
            string tempN = tbName.Text;
            string tempE = tbEmail.Text;
            string tempNum = tbNumber.Text;
            if ((tempN == "" || tempE == "" || tempNum == ""))
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

                    string query = @"UPDATE [dbo].[User] set [name]=" + "'" + @tempN + "'"
                                    + ", [email]=" + "'" + @tempE + "'"
                                    + ",[phone]=" + "'" + @tempNum + "' " + "where " + "[username]=" + "'" + @tempU + "'"
                                    ;
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                    string message3 = tempU.ToUpper() + " Updated Successfully !";
                    var dialog2 = new MessageDialog(message3);
                    await dialog2.ShowAsync();
                    tbUsername.IsEnabled = true;
                    tbUsername.Text = "";
                    tbName.IsEnabled = false;
                    tbName.Text = "";
                    tbEmail.IsEnabled = false;
                    tbEmail.Text = "";
                    tbNumber.IsEnabled = false;
                    tbNumber.Text = "";
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

