using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using UnikomApp.ViewModels;

namespace UnikomApp.Views
{
    public partial class PageJurusan : PhoneApplicationPage
    {
        public static string idfakultas_;


        public PageJurusan()
        {
            InitializeComponent();
            DataContext = new JurusanViewModel();
        }
       


    }
}