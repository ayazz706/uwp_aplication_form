using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App4
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void paschk(object sender, RoutedEventArgs e)
        {
            pastxt.Text = pasinp.Password;
            pastxt.Visibility = Visibility.Visible;
            pasinp.Visibility = Visibility.Collapsed;
        }

        private void pasunchk(object sender, RoutedEventArgs e)
        {
            pasinp.Password = pastxt.Text;
            pastxt.Visibility = Visibility.Collapsed;
            pasinp.Visibility = Visibility.Visible;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pasinp.Password = string.Empty;
            pastxt.Text = string.Empty;
        }

        private void genderchk(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadioButton = sender as RadioButton;
            if (selectedRadioButton != null)
            {
                string selectedOption = selectedRadioButton.Content.ToString();
                Debug.WriteLine($"Selected: {selectedOption}");
            }
        }
        private void chk2(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadioButton = sender as RadioButton;
            if (selectedRadioButton != null)
            {
                string selectedOption = selectedRadioButton.Content.ToString();
                Debug.WriteLine($"Selected: {selectedOption}");
            }
        }
        private void tocchk(object sender, RoutedEventArgs e)
        {
            submitbutton.IsEnabled = true;
        }

        private void tocunchk(object sender, RoutedEventArgs e)
        {
            submitbutton.IsEnabled = false;
        }
        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string password = pasinp.Visibility == Visibility.Visible ? pasinp.Password : pastxt.Text;

            if (string.IsNullOrWhiteSpace(userinp.Text) ||
                string.IsNullOrWhiteSpace(password) ||
                !(rad1.IsChecked == true || rad2.IsChecked == true) ||
                chk3.IsChecked != true)
            {
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Incomplete Form",
                    Content = "Please fill all the details and accept the terms and conditions.",
                    CloseButtonText = "OK"
                };
                await errorDialog.ShowAsync();
                return;
            }

            ContentDialog successDialog = new ContentDialog
            {
                Title = "Submission Successful",
                Content = "Your form has been submitted successfully.",
                CloseButtonText = "OK"
            };
            await successDialog.ShowAsync();
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit(); 
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            userinp.Text = string.Empty;
            pasinp.Password = string.Empty;
            pastxt.Text = string.Empty;

            pasinp.Visibility = Visibility.Visible;
            pastxt.Visibility = Visibility.Collapsed;

            rad1.IsChecked = false;
            rad2.IsChecked = false;
            chk3.IsChecked = false;
            submitbutton.IsEnabled = false;
        }
    }
}
