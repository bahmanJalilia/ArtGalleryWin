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

namespace ArtGalleryWin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public int i = 1;
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            string user = userName.Text;
            string pass = password.Password;
            
            if (user.Trim() == "" || pass.Trim() == "")
            {
                MessageBox.Show("Pleas fill the form.","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                if (i < 3)
                {
                    if (user.Trim() == "CGS" && pass.Trim() == "admin")
                    {
                        CGSArt cgsArt = new CGSArt();
                        cgsArt.Show();
                        cgsArt.Activate();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username and password.\n *Pleas enter the correct one*", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
                        password.Clear();
                        userName.Clear();
                        i++;
                        return;
                    }
                }
                
                this.Close();
            }
        }
    }
}
