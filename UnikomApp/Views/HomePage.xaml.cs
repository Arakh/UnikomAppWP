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
    public partial class PageHome : PhoneApplicationPage
    {
        bool isOpenNavDraw;
        double marginLeft;
        public PageHome()
        {
            InitializeComponent();
            isOpenNavDraw = false;
            marginLeft = -400;
            Loaded += new RoutedEventHandler(Home_Loaded);
        }

        private void Home_Loaded(object sender, RoutedEventArgs e)
        {
            List<Transaction> transactionList = new List<Transaction>();

            transactionList.Add(new Transaction("Sambutan Rektor", "/Assets/SambutanRektor.png"));
            transactionList.Add(new Transaction("Visi dan Misi", "/Assets/Beasiswa.png"));
            transactionList.Add(new Transaction("Sejarah", "/Assets/Sejarah.png"));
            transactionList.Add(new Transaction("Hymne dan Mars", "/Assets/HymneDanMars.png"));

            TransactionList.ItemsSource = transactionList;
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

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavDrawer.SlideNavBarOpen.Begin();
            marginLeft = 0;
            NavDrawer.Margin = new Thickness(0, 0, 0, 0);
            isOpenNavDraw = true;
        }

        private void GestureListener_DragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            if (isOpenNavDraw)
            {
                NavDrawer.Margin = new Thickness(0, 0, 0, 0);
                isOpenNavDraw = false;
            }

            double temp = marginLeft + e.HorizontalChange;
            if (temp <= 0 && temp >= -400)
            {
                marginLeft += e.HorizontalChange;
                NavDrawer.Margin = new Thickness(marginLeft, 0, 0, 0);
            }
        }

        private void GestureListener_DragCompleted(object sender, DragCompletedGestureEventArgs e)
        {
            if (marginLeft >= -200)
            {
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    while (marginLeft < 0)
                    {
                        marginLeft++;

                        NavDrawer.Margin = new Thickness(marginLeft, 0, 0, 0);
                    }
                });
            }
            else
            {
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    while (marginLeft > -400)
                    {
                        marginLeft--;

                        NavDrawer.Margin = new Thickness(marginLeft, 0, 0, 0);
                    }
                });
            }
        }

        private void stackMenu_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavDrawer.SlideNavBarOpen.Begin();
            marginLeft = 0;
            NavDrawer.Margin = new Thickness(0, 0, 0, 0);
            isOpenNavDraw = true;
        }

    }
}