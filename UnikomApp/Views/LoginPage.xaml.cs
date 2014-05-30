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
    public partial class PageLogin : PhoneApplicationPage
    {
        public PageLogin()
        {
            InitializeComponent();
        }
        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PivotItem selectedItem = (PivotItem)e.AddedItems[0];
            String pivotTag = (String)selectedItem.Tag;
            if (pivotTag.Equals("satu"))
            {
                textJudul.Text = "Fakultas";
                textIsi.Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy";

                elip1.Visibility = Visibility.Visible;
                elip2.Visibility = Visibility.Collapsed;
                elip3.Visibility = Visibility.Collapsed;
                elip4.Visibility = Visibility.Collapsed;
                elip5.Visibility = Visibility.Collapsed;
                elip6.Visibility = Visibility.Collapsed;
                elip1_Copy.Visibility = Visibility.Collapsed;
                elip2_Copy.Visibility = Visibility.Visible;
                elip3_Copy.Visibility = Visibility.Visible;
                elip4_Copy.Visibility = Visibility.Visible;
                elip5_Copy.Visibility = Visibility.Visible;
                elip6_Copy.Visibility = Visibility.Visible;
            }
            else if (pivotTag.Equals("dua"))
            {
                textJudul.Text = "Jurusan";
                textIsi.Text = "When an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five";


                elip1.Visibility = Visibility.Collapsed;
                elip2.Visibility = Visibility.Visible;
                elip3.Visibility = Visibility.Collapsed;
                elip4.Visibility = Visibility.Collapsed;
                elip5.Visibility = Visibility.Collapsed;
                elip6.Visibility = Visibility.Collapsed;
                elip1_Copy.Visibility = Visibility.Visible;
                elip2_Copy.Visibility = Visibility.Collapsed;
                elip3_Copy.Visibility = Visibility.Visible;
                elip4_Copy.Visibility = Visibility.Visible;
                elip5_Copy.Visibility = Visibility.Visible;
                elip6_Copy.Visibility = Visibility.Visible;
            }
            else if (pivotTag.Equals("tiga"))
            {
                textJudul.Text = "Penampakan";
                textIsi.Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy";


                elip1.Visibility = Visibility.Collapsed;
                elip2.Visibility = Visibility.Collapsed;
                elip3.Visibility = Visibility.Visible;
                elip4.Visibility = Visibility.Collapsed;
                elip5.Visibility = Visibility.Collapsed;
                elip6.Visibility = Visibility.Collapsed;
                elip1_Copy.Visibility = Visibility.Visible;
                elip2_Copy.Visibility = Visibility.Visible;
                elip3_Copy.Visibility = Visibility.Collapsed;
                elip4_Copy.Visibility = Visibility.Visible;
                elip5_Copy.Visibility = Visibility.Visible;
                elip6_Copy.Visibility = Visibility.Visible;
            }
            else if (pivotTag.Equals("empat"))
            {
                textJudul.Text = "Universitas";
                textIsi.Text = "When an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five";

                elip1.Visibility = Visibility.Collapsed;
                elip2.Visibility = Visibility.Collapsed;
                elip3.Visibility = Visibility.Collapsed;
                elip4.Visibility = Visibility.Visible;
                elip5.Visibility = Visibility.Collapsed;
                elip6.Visibility = Visibility.Collapsed;
                elip1_Copy.Visibility = Visibility.Visible;
                elip2_Copy.Visibility = Visibility.Visible;
                elip3_Copy.Visibility = Visibility.Visible;
                elip4_Copy.Visibility = Visibility.Collapsed;
                elip5_Copy.Visibility = Visibility.Visible;
                elip6_Copy.Visibility = Visibility.Visible;
            }
            else if (pivotTag.Equals("lima"))
            {
                textJudul.Text = "Entahlah";
                textIsi.Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy";

                elip1.Visibility = Visibility.Collapsed;
                elip2.Visibility = Visibility.Collapsed;
                elip3.Visibility = Visibility.Collapsed;
                elip4.Visibility = Visibility.Collapsed;
                elip5.Visibility = Visibility.Visible;
                elip6.Visibility = Visibility.Collapsed;
                elip1_Copy.Visibility = Visibility.Visible;
                elip2_Copy.Visibility = Visibility.Visible;
                elip3_Copy.Visibility = Visibility.Visible;
                elip4_Copy.Visibility = Visibility.Visible;
                elip5_Copy.Visibility = Visibility.Collapsed;
                elip6_Copy.Visibility = Visibility.Visible;
            }
            else
            {
                textJudul.Text = "Mungkin";
                textIsi.Text = "When an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five";

                elip1.Visibility = Visibility.Collapsed;
                elip2.Visibility = Visibility.Collapsed;
                elip3.Visibility = Visibility.Collapsed;
                elip4.Visibility = Visibility.Collapsed;
                elip5.Visibility = Visibility.Collapsed;
                elip6.Visibility = Visibility.Visible;
                elip1_Copy.Visibility = Visibility.Visible;
                elip2_Copy.Visibility = Visibility.Visible;
                elip3_Copy.Visibility = Visibility.Visible;
                elip4_Copy.Visibility = Visibility.Visible;
                elip5_Copy.Visibility = Visibility.Visible;
                elip6_Copy.Visibility = Visibility.Collapsed;
            }
        }




    }
}