using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArtGallery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int loginTries = 3;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "" || password.Password == "")
            {
                MessageBox.Show("Username and password are required!");
            }
            else
            {
                if (username.Text.Equals("CGS") || password.Password.Equals("admin"))
                {
                    loginTries = 3;


                    CGSArt cgsArt = new CGSArt();
                    this.Close();
                    cgsArt.ShowDialog();



                }
                else
                {
                    loginTries--;
                    if (loginTries == 0)
                    {
                        string message = "Invalid username or password! Exiting application!";
                        MessageBox.Show(message);
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        string message = "Invalid username or password! You can try " + loginTries.ToString() + " more times.";
                        MessageBox.Show(message);
                    }



                }
            }

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
