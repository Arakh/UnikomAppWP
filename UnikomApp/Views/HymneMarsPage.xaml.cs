using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using UnikomApps;

namespace UnikomApps
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Load data for the ViewModel Items
        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PivotItem selectedItem = (PivotItem)e.AddedItems[0];
            String pivotTag = (String)selectedItem.Tag;

            if (pivotTag.Equals("Hymne"))
            {
                borderHymne.Visibility = Visibility.Visible;
                borderMars.Visibility = Visibility.Collapsed;
            }
            else
            {
                borderHymne.Visibility = Visibility.Collapsed;
                borderMars.Visibility = Visibility.Visible;
            }
        }

        private void Tap_selectionChangedPivot(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid grid = (Grid)sender;

            if (grid.Name.Equals("tapHymne"))
            {
                pivotControl.SelectedIndex = 0;
            }
            else
            {
                pivotControl.SelectedIndex = 1;
            }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}