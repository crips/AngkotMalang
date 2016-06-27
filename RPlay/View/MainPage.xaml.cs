using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace RPlay.View
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BaackRequested;
        }

        private void MainPage_BaackRequested(object sender, BackRequestedEventArgs e)
        {
            if (MainFrame == null)
            {
                return;
            }

            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
                e.Handled = true;
            }
        }

        void BurgerButton()
        {
            if (!MySplitView.IsPaneOpen)
            {
                MySplitView.IsPaneOpen = true;
                SearchIcon.Visibility = Visibility.Collapsed;
                SearchBox.Visibility = Visibility.Visible;
            }
            else
            {
                MySplitView.IsPaneOpen = false;
                SearchIcon.Visibility = Visibility.Visible;
                SearchBox.Visibility = Visibility.Collapsed;
            }
        }



        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            BurgerButton();
        }

        private void SearchIcon_Click(object sender, RoutedEventArgs e)
        {
            BurgerButton();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var x = (e.AddedItems[0] as ListViewItem).Name;

            switch(x)
            {
                case "beranda":
                    Frame.Navigate(typeof(MainPage), null);
                    break;
                case "keretaapi":
                    MainFrame.Navigate(typeof(TrainPage), null);
                    break;
                case "terminal":
                    MainFrame.Navigate(typeof(AngkotPage), null);
                    break;
            }
        }
    }
}