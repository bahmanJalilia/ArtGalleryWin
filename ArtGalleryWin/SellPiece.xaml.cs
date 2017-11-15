using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGS;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ArtGalleryWin
{
    /// <summary>
    /// Interaction logic for SellPiece.xaml
    /// </summary>
    public partial class SellPiece : Window
    {
        Gallery gal = new Gallery();
        public SellPiece(Gallery Gal)
        {
            InitializeComponent();
            gal = Gal;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        { 
            if (gal.sellPiece(PieceSellID.Text, Convert.ToDouble(PieceSellPrice.Text)) == true)
            {
                MessageBox.Show("The Art Piece was sold.", "accepted", MessageBoxButton.OK,MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter the correct Piece ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
