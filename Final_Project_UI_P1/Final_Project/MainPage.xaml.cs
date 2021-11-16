/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: 000000000                  *
 * Final Project - Part 1          * 
 * Main page                       * 
 * Sources used provided in the PDF* 
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

using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.Toolkit.Uwp.UI.Controls;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Final_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

  
    public sealed partial class MainPage : Page
    {
        /***********************************************
         * Main                                        *
         * *********************************************/
        public MainPage()
        {

            this.InitializeComponent();
        }

        /***********************************************
         *Load FrontPage                               *
         * *********************************************/
        private void LoadPage(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(FrontPage));
        }
        /***********************************************
         *Navigation Function                          *
         * *********************************************/
        private void SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                switch (item.Tag.ToString())
                {

                    case "FrontPage":
                        ContentFrame.Navigate(typeof(FrontPage));
                        break;
                    case "ordersPage":
                        ContentFrame.Navigate(typeof(ordersPage));
                        break;
                    case "registerPage":
                        ContentFrame.Navigate(typeof(registerPage));
                        break;
                    //case "FeedbackPage":
                    //    ContentFrame.Navigate(typeof(FeedbackPage));
                    //    break;
                    case "aboutPage":
                        ContentFrame.Navigate(typeof(aboutPage));
                        break;
                    case "myordersPage":
                        ContentFrame.Navigate(typeof(myordersPage));
                        break;
                    case "loginPage":
                        ContentFrame.Navigate(typeof(loginPage));
                        break;
                }
            }

        }
    }
}
