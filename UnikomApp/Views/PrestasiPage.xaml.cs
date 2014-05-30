using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace UnikomApp.Views
{
    public partial class PagePrestasi : PhoneApplicationPage
    {
        public PagePrestasi()
        {
            InitializeComponent();
        }

        private void Pivot_Geser(object sender, SelectionChangedEventArgs e)
        {
            PivotItem selectedItem = (PivotItem)e.AddedItems[0];
            String pivotTag = (String)selectedItem.Tag;
            if (pivotTag.Equals("satu"))
            {
                textJudul.Text = "Prestasi & Penghargaan";
                textIsi.Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore";

                elip1.Visibility = Visibility.Visible;
                elip2.Visibility = Visibility.Collapsed;
                elip3.Visibility = Visibility.Collapsed;
                elip4.Visibility = Visibility.Collapsed;
                elip5.Visibility = Visibility.Collapsed;
                elip1_Copy.Visibility = Visibility.Collapsed;
                elip2_Copy.Visibility = Visibility.Visible;
                elip3_Copy.Visibility = Visibility.Visible;
                elip4_Copy.Visibility = Visibility.Visible;
                elip5_Copy.Visibility = Visibility.Visible;
            }
            else if (pivotTag.Equals("dua"))
            {
                textJudul.Text = "Prestasi & Penghargaan";
                textIsi.Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore lalala";


                elip1.Visibility = Visibility.Collapsed;
                elip2.Visibility = Visibility.Visible;
                elip3.Visibility = Visibility.Collapsed;
                elip4.Visibility = Visibility.Collapsed;
                elip5.Visibility = Visibility.Collapsed;
                elip1_Copy.Visibility = Visibility.Visible;
                elip2_Copy.Visibility = Visibility.Collapsed;
                elip3_Copy.Visibility = Visibility.Visible;
                elip4_Copy.Visibility = Visibility.Visible;
                elip5_Copy.Visibility = Visibility.Visible;
            }
            else if (pivotTag.Equals("tiga"))
            {
                textJudul.Text = "Prestasi & Penghargaan";
                textIsi.Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore lilili";


                elip1.Visibility = Visibility.Collapsed;
                elip2.Visibility = Visibility.Collapsed;
                elip3.Visibility = Visibility.Visible;
                elip4.Visibility = Visibility.Collapsed;
                elip5.Visibility = Visibility.Collapsed;
                elip1_Copy.Visibility = Visibility.Visible;
                elip2_Copy.Visibility = Visibility.Visible;
                elip3_Copy.Visibility = Visibility.Collapsed;
                elip4_Copy.Visibility = Visibility.Visible;
                elip5_Copy.Visibility = Visibility.Visible;
            }
            else if (pivotTag.Equals("empat"))
            {
                textJudul.Text = "Prestasi & Penghargaan";
                textIsi.Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore hahaha";

                elip1.Visibility = Visibility.Collapsed;
                elip2.Visibility = Visibility.Collapsed;
                elip3.Visibility = Visibility.Collapsed;
                elip4.Visibility = Visibility.Visible;
                elip5.Visibility = Visibility.Collapsed;
                elip1_Copy.Visibility = Visibility.Visible;
                elip2_Copy.Visibility = Visibility.Visible;
                elip3_Copy.Visibility = Visibility.Visible;
                elip4_Copy.Visibility = Visibility.Collapsed;
                elip5_Copy.Visibility = Visibility.Visible;
            }
            else
            {
                textJudul.Text = "Prestasi & Penghargaan";
                textIsi.Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore hihihi";

                elip1.Visibility = Visibility.Collapsed;
                elip2.Visibility = Visibility.Collapsed;
                elip3.Visibility = Visibility.Collapsed;
                elip4.Visibility = Visibility.Collapsed;
                elip5.Visibility = Visibility.Collapsed;
                elip1_Copy.Visibility = Visibility.Visible;
                elip2_Copy.Visibility = Visibility.Visible;
                elip3_Copy.Visibility = Visibility.Visible;
                elip4_Copy.Visibility = Visibility.Visible;
                elip5_Copy.Visibility = Visibility.Visible;
            }
        }
    }
}