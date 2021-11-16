/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: _________                  *
 * Final Project - Part 1          * 
 * Orders Class                    *
 ***********************************/


using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.SqlClient;
using Windows.UI.Popups;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.Storage.AccessCache;
using System.Runtime.Serialization.Formatters.Binary;

namespace Final_Project
{
    class Orders
    {
        public static SqlConnection conn = new SqlConnection();
        //Spring2021Exam
        public static string conString = "Server=(local);Database=Spring2021Exam;" +
                   "User=PapaDario;Password=12345";
        //need a commandobjectt o excute the query
        public static SqlCommand cmd;
        public int pizza_size { set; get; }
        public static int x = 0;
        public ArrayList toppings { set; get; }
        public ArrayList additions { set; get; }
        public ArrayList drinks { set; get; }
        public string username { set; get; }
        public string toppingsStr { set; get; }
        public string additionsStr { set; get; }
        public string drinksStr { set; get; }
        public int userid { set; get; }
        public double price { set; get; }
        public string Date { set; get; }


        /***********************************************
        *   Writing to C:\ With StreamWriter - Failed  *<-- Failed attempt
        ************************************************/
        public static void save_recipt(Orders or)
        {
            try
            {//saving start_config
                //File.WriteAllText(Filename, Str);
                using (StreamWriter wr = new StreamWriter(@"C:\" + or.username + "_" + or.Date + "_" + x + ".txt"))
                {
                    wr.WriteLine("*******************************************");
                    wr.WriteLine("    Papa Dario's Pizza");
                    wr.WriteLine("      Order Receipt");
                    // wr.WriteLine("Date: "+or.Date);
                    wr.WriteLine("Username: " + or.username);
                    wr.WriteLine("******************************************");
                    wr.WriteLine("Pizza Size  : " + or.pizza_size);
                    wr.WriteLine("Toppings  : " + or.toppings.ToString());
                    Debug.WriteLine(or.toppings.ToString());
                    wr.WriteLine("Additions  : " + or.additions.ToString());
                    wr.WriteLine("Additions  : " + or.additions.ToString());
                    wr.WriteLine("******************************************");
                    wr.WriteLine("Total " + or.price);
                    wr.WriteLine("******************************************");
                    x++;
                    wr.Dispose();
                    wr.Close();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        public static StringBuilder str = new StringBuilder();
        public static string Tstr { set; get; }
        public static string Astr;
        public static string Dstr;
        /**************************************************************
        * Save file  Youname_FinalResults.txt
        ***************************************************************/
        public static string save_recipt2(Orders or)
        {
            str.Clear();
            Tstr = String.Join(",", or.toppings.ToArray());
            Astr = String.Join(",", or.additions.ToArray());
            Dstr = String.Join(",", or.drinks.ToArray());
            try
            {//saving start_config
             //File.WriteAllText(Filename, Str);
             //StreamWriter wr = new StreamWriter(@"C:\" + or.usrename + "_" + or.Date + "_" + x + ".txt")
                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();
                str.Append("************************************************\n");
                str.Append("                    Papa Dario's Pizza\n");
                str.Append("                      Order Receipt\n");
                // wr.WriteLine("Date: "+or.Date);
                str.Append("Username: " + or.username.ToUpper() + "\n");
                str.Append("************************************************\n");
                str.Append("Pizza Size  : " + or.pizza_size + "\n");
                str.Append("Toppings  : " + Tstr + "\n");
                str.Append("Additions  : " + Astr + "\n");
                str.Append("Drink  : " + Dstr + "\n");
                str.Append("************************************************\n");
                str.Append("Total: " + or.price + "\n");
                str.Append("************************************************\n");
                x++;
                return str.ToString();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
        /**************************************************************
        * Save file  Youname_FinalResults.txt
        ***************************************************************/
        public static void inset_order(Orders or)
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                or.userid = DBTools.usere_id(or.username.ToUpper());
                string query = @"Insert into [dbo].[Orders] VALUES('"
                                        + @or.pizza_size + "','"
                                        + @Tstr + "','"
                                        + @Astr + "','"
                                        + @Dstr + "','"
                                        + @or.username + "','"
                                        + @or.price + "')";
                cmd.CommandText = query;
                conn.Open();
                cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                cmd.Dispose();//free up resources in memory
                conn.Close();//close
            }
        }

        /***********************************************
        *   Saving txt to file using FileSavePicker    *
        ************************************************/
        static int fileNum = 0;
        public async static void save_recipt_FilePicker(Orders or)
        {
            string dateAndTime = DateTime.Now.ToString("dd.MM.yyy"); ;
            string fileName = "Order_" + dateAndTime + "_" + fileNum;
            var fileSavePicker = new FileSavePicker();
            fileSavePicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            fileSavePicker.SuggestedFileName = fileName;
            fileSavePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt", ".text" });
            StorageFile saveFile = await fileSavePicker.PickSaveFileAsync();
            if (saveFile != null)
            {
                // Save file was picked, you can now write in it
                await FileIO.WriteTextAsync(saveFile, str.ToString());
            }
            else
            {
                // No file was picked or the dialog was cancelled.
                Debug.WriteLine("Error");
            }
            //fileSavePicker.SuggestedFileName = fileName;
            fileNum++;
        }
    }
}

