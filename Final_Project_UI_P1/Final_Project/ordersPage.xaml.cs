/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: 000000000                  *
 * Final Project - Part 1          * 
 * Orders page                     *
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
using System.Diagnostics;
using System.Collections;
using Windows.UI.Popups;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Final_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ordersPage : Page
    {
        Orders or = new Orders();
        public static double total = 0;
        CheckBox[] TcbArr = new CheckBox[3];
        CheckBox[] AcbArr = new CheckBox[4];
        CheckBox[] DcbArr = new CheckBox[2];

        /***********************************************
        *   Load Register Page - At start              *
        ************************************************/
        public ordersPage()
        {
            this.InitializeComponent();
            tbGlobalUserName.Text = DBTools.username.ToUpper();
            if (DBTools.isCombo == true)
            {
                combPizzaSize.SelectedIndex = 2;
                combKind.SelectedIndex = 2;
                TcbBroc.IsChecked = true;
                TcbOli.IsChecked = true;
                TcbPot.IsChecked = true;
                AcbSand.IsChecked = true;
                DcbSoda.IsChecked = true;
            }
        }
        /***********************************************
        *   Load Register Page - At start              *
        ************************************************/
        private async void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            //or.Date = today;
            total = 0;
            Debug.WriteLine("Orderdetails strart 0" + DBTools.orderdetails);
            DBTools.isCombo = false;
            or.toppings = new ArrayList();
            or.additions = new ArrayList();
            or.drinks = new ArrayList();
            //TcbArr = { TcbBroc, TcbPot, TcbOli };
            //Array.Clear(TcbArr, 0, TcbArr.Length);
            //Array.Clear(AcbArr, 0, AcbArr.Length);
            //Array.Clear(DcbArr, 0, DcbArr.Length);

            //comboAirplaneType.SelectedItem.ToString();
            string t = "Selected " + combPizzaSize;
            Debug.WriteLine(t);
            Debug.WriteLine("Selected2 " + combKind.SelectedItem);
            if (combPizzaSize.SelectedIndex == 0) { total += 6.99; or.pizza_size = 6; }
            if (combPizzaSize.SelectedIndex == 1) { total += 9.99; or.pizza_size = 12; }
            if (combPizzaSize.SelectedIndex == 2) { total += 14.99; or.pizza_size = 24; }
            Debug.WriteLine("Selected2 " + combKind.SelectedIndex);
            Debug.WriteLine("total " + total);
            TcbArr[0] = TcbBroc; TcbArr[1] = TcbPot; TcbArr[2] = TcbOli;
            AcbArr[0] = AcbWings; AcbArr[1] = AcbSand; AcbArr[2] = AcbPout; AcbArr[3] = AcbGu;
            DcbArr[0] = DcbSoda; DcbArr[1] = DcbWater;
            Debug.WriteLine("One " + TcbArr[1].Content);
            Debug.WriteLine("Two  " + TcbArr[2].Content.ToString());
            for (int i = 0; i < TcbArr.Length; i++) { if (TcbArr[i].IsChecked == true) { total += 3; or.toppings.Add(TcbArr[i].Content); } }
            for (int i = 0; i < AcbArr.Length; i++) { if (AcbArr[i].IsChecked == true) { total += 3; or.additions.Add(AcbArr[i].Content); } }
            for (int i = 0; i < DcbArr.Length; i++) { if (DcbArr[i].IsChecked == true) { total += 3; or.drinks.Add(DcbArr[i].Content); } }
            if (combPizzaSize.SelectedIndex == -1 || combKind.SelectedIndex == -1)
            {
                string message2 = "Please select Pizza size and kind first !";
                //string caption = "Error";
                var dialog = new MessageDialog(message2);
                await dialog.ShowAsync();
                return;
            }
            or.username = DBTools.username;
            if (DBTools.isLogged) { total = total - (total * 0.10); }; //<-- Discount for Club members 
            or.price = total;
            DBTools.orderdetails = Orders.save_recipt2(or);
            //string newStr = Orders.save_recipt2(or);
            //Orders.save_recipt(or);

            //Orders.save_recipt3(or);
            Debug.WriteLine("Object Total " + or.price);
            Debug.WriteLine("Loca; Total " + or.price);
            Debug.WriteLine(or.username);
            Debug.WriteLine(or.toppings.ToString());
            Debug.WriteLine(or.toppings.ToString());
            Orders.inset_order(or);
            Debug.WriteLine("Orderdetails 1\n" + DBTools.orderdetails);
            btnSave.IsEnabled = true;
            if (DBTools.isLogged == true)
            {
                ContentDialog receiptDialog = new ContentDialog
                {
                    Title = "Order Receipt",
                    Content = DBTools.orderdetails,
                    CloseButtonText = "Ok"
                };
                ContentDialogResult result = await receiptDialog.ShowAsync();
                //Frame.Navigate(typeof(myordersPage)); 
            }
            else
            {

                ContentDialog receiptDialog = new ContentDialog
                {
                    Title = "Order Receipt",
                    Content = DBTools.orderdetails,
                    CloseButtonText = "Ok"
                };
                ContentDialogResult result = await receiptDialog.ShowAsync();
                return;
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbGlobalUserName_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        /***********************************************
        *  Save Btn -   Call Save Function             *
        ************************************************/
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Orders.save_recipt_FilePicker(or);
            btnSave.IsEnabled = false;
        }
    }
}
