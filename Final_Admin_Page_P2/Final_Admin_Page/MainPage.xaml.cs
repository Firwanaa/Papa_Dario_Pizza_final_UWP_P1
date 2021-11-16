/***********************************
 * @Instructor Prof. Dario Guiao   *
 * @Autor: Alqassam Firwana        *
 * @id: 912312312312               *
 * Final Project - Part 2          * 
 * Admin page part                 *
 * Main                            * 
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Final_Admin_Page
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        /***********************************************
        *   Load FrontPage - At start                  *
        ************************************************/
        private void LoadPage(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(viewPage));
        }
        /***********************************************
         *Navigate Pages Function                      *
         ***********************************************/
        private void SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;
            switch (item.Tag.ToString())
            {
                case "viewPage":
                    ContentFrame.Navigate(typeof(viewPage));
                    break;
                case "insertPage":
                    ContentFrame.Navigate(typeof(insertPage));
                    break;

                case "updatePage":
                    ContentFrame.Navigate(typeof(updatePage));
                    break;
                case "deletePage":
                    ContentFrame.Navigate(typeof(deletePage));
                    break;
            }
        }
    }
}
