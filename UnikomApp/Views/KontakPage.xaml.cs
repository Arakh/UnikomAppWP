using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace UnikomApp.Views
{
    public partial class KontakPage : PhoneApplicationPage
    {
        PhoneCallTask phoneTask = null;
        
        

        // Constructor
        public KontakPage()
        {
            InitializeComponent();
            
            phoneTask = new PhoneCallTask();
        }

        private void btnCall1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            phoneTask.DisplayName = "UNIKOM";
            phoneTask.PhoneNumber = "0222504119";
            phoneTask.Show();           
        }

        

        private void btnCall2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            phoneTask.DisplayName = "UNIKOM";
            phoneTask.PhoneNumber = "0222508412";
            phoneTask.Show();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            phoneTask.DisplayName = "UNIKOM";
            phoneTask.PhoneNumber = "0222508412";
            phoneTask.Show();
        }

        private void btnCall3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            phoneTask.DisplayName = "UNIKOM";
            phoneTask.PhoneNumber = "0222506637";
            phoneTask.Show();
        }

        private void btnCall4_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            phoneTask.DisplayName = "UNIKOM";
            phoneTask.PhoneNumber = "0222506637";
            phoneTask.Show();
        }

        private void btnCall5_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            phoneTask.DisplayName = "UNIKOM";
            phoneTask.PhoneNumber = "0222503054";
            phoneTask.Show();
        }

        private void btnCall6_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            phoneTask.DisplayName = "UNIKOM";
            phoneTask.PhoneNumber = "0222506553";
            phoneTask.Show();
        }

        private void send_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = txtName.Text;
            emailComposeTask.Body = txtBody.Text;
            emailComposeTask.To = "pmb@unikom.ac.id";

            emailComposeTask.Show();

        }

        private void clear_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            txtName.Text = "";
            txtSubject.Text = "";
            txtBody.Text = "";
        }
    }
}