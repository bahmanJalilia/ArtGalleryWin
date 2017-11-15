using System;
using CGS;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Threading;

namespace ArtGalleryWin
{
    /// <summary>
    /// Interaction logic for CGSArt.xaml
    /// </summary>
    public partial class CGSArt : Window
    {
        
        Gallery gal = new Gallery();
        public CGSArt()
        {
            InitializeComponent();
            this.Reset();
        }
        
        public void Reset()
        {
            
            curatorFN.Text = String.Empty;
            curatorLN.Text = String.Empty;
            curatorID.Text = String.Empty;
            artistFN.Text = String.Empty;
            artistLN.Text = String.Empty;
            artistID.Text = String.Empty;
            pieceID.Text = String.Empty;
            pieceTitle.Text = String.Empty;
            pieceYear.Text = String.Empty;
            pieceValue.Text = String.Empty;
            pieceArtistID.Text = String.Empty;
            pieceCuratorID.Text = String.Empty;
            onDisplay.IsChecked = true;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult key = MessageBox.Show("Are you sure you want to quit", "Confirm",
           MessageBoxButton.YesNo,
           MessageBoxImage.Question,
           MessageBoxResult.No);
           e.Cancel = (key == MessageBoxResult.No);
        }
        private void addCurator_Click(object sender, RoutedEventArgs e)
        {
            if (gal.addCurator(curatorFN.Text, curatorLN.Text, curatorID.Text) == 2)
            {
                Thread.Sleep(1000);
                Action act = new Action(() =>
                {
                    status.Items.Clear();
                    status.Items.Add("Curator Informations Add");
                });
                this.Dispatcher.Invoke(act, DispatcherPriority.ApplicationIdle);
                this.Reset();
            }
            else
            {
                textView.Text = "You have to fill the form correctly.";
            }
        }

        private void viewCurator_Click(object sender, RoutedEventArgs e)
        {
            if (gal.listCurators() == "")
            {
                textView.Text = "There is no Curator in list!";
            }
            else
            {
                textView.Text = gal.listCurators();
            }
            //MessageBox.Show(gal.listCurators(), "Curators Informathion",
            //    MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void addArtist_Click(object sender, RoutedEventArgs e)
        {
            if (gal.addArtist(artistFN.Text, artistLN.Text, artistID.Text) == 2)
            {
                Thread.Sleep(1000);
                Action act = new Action(() =>
                {
                    status.Items.Clear();
                    status.Items.Add("Artist Informations Add");
                });
                this.Dispatcher.Invoke(act, DispatcherPriority.ApplicationIdle);
                this.Reset();
            }
            else
            {
                textView.Text = "You have to fill the form correctly.";
            }
        }

        private void viewArtist_Click(object sender, RoutedEventArgs e)
        {
            if (gal.listArtists() == "")
            {
                textView.Text = "There is no Artist in list!";
            }
            else
            {
                textView.Text = gal.listArtists();
            }

            //MessageBox.Show(gal.listArtists(),"Artists Informathion",
            //    MessageBoxButton.OK,MessageBoxImage.Information);
        }
        
        private void addArtPiece_Click(object sender, RoutedEventArgs e)
        {
             char stat = 'O';
            if (onDisplay.IsChecked == true)
            {
                stat = 'D';
            }
            if (pieceValue.Text == ""|pieceTitle.Text==""|pieceID.Text==""|pieceYear.Text==""
                |pieceArtistID.Text==""|pieceCuratorID.Text=="")
            {
                textView.Text = "You have to fill the form correctly.";
                //Action acte = new Action(() =>
                //{
                //    status.Items.Clear();
                //    textView.Text = "";
                //    status.Items.Add("Error");

                //});
                //this.Dispatcher.Invoke(acte, DispatcherPriority.ApplicationIdle);
            }
            else
            {
                switch (gal.addArtPiece(pieceID.Text, pieceTitle.Text, pieceYear.Text,
                    Convert.ToDouble(pieceValue.Text), pieceArtistID.Text, pieceCuratorID.Text, stat))
                {
                    case 1:
                        MessageBox.Show("The Artists list is empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case 2:
                        Thread.Sleep(1000);
                        Action act = new Action(() =>
                        {
                            status.Items.Clear();
                            status.Items.Add("Art Piece Informations Add");

                        });
                        this.Dispatcher.Invoke(act, DispatcherPriority.ApplicationIdle);
                        break;
                    case 3:
                        MessageBox.Show("The Curator ID is Incorrect.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case 4:
                        MessageBox.Show("The Artist ID is Incorrect.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
            this.Reset();
        }

        private void listPiece_Click(object sender, RoutedEventArgs e)
        {
            if (gal.listArtPiece() == "")
            {
                textView.Text = "There is no Art Piece in list!";
            }
            else
            {
                textView.Text = gal.listArtPiece();
            }
            //MessageBox.Show(gal.listArtPiece(), "Art Pieces Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void sellArtPiece_Click(object sender, RoutedEventArgs e)
        {

            SellPiece piece = new SellPiece(gal);
            piece.Show();
            piece.Activate();
        }

        private void MenuItem_exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_open(object sender, RoutedEventArgs e)
        {
            if (gal.GetCurators() == false)
            {
                textView.Text = "error";
            }
            else
            {
                textView.Text = "The curators open";
            }
        }

        private void MenuItem_Save(object sender, RoutedEventArgs e)
        {
            gal.WriteCurators();
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            Action act = new Action(() =>
            {
                status.Items.Clear();
                textView.Text = "";
                status.Items.Add("ART PIECE");

            });
            this.Dispatcher.Invoke(act, DispatcherPriority.ApplicationIdle);
        }

        private void TabItem_GotFocus_1(object sender, RoutedEventArgs e)
        {
            Action act = new Action(() =>
            {
                status.Items.Clear();
                textView.Text = "";
                status.Items.Add("ARTISTS");

            });
            this.Dispatcher.Invoke(act, DispatcherPriority.ApplicationIdle);
        }

        private void TabItem_GotFocus_2(object sender, RoutedEventArgs e)
        {
            Action act = new Action(() =>
            {
                status.Items.Clear();
                textView.Text = "";
                status.Items.Add("CURATORS");

            });
            this.Dispatcher.Invoke(act, DispatcherPriority.ApplicationIdle);
        }

        private void saveCurator_Click(object sender, RoutedEventArgs e)
        {
            gal.WriteCurators();
            Thread.Sleep(1000);
            Action act = new Action(() =>
            {
                status.Items.Clear();
                //textView.Text = "";
                status.Items.Add("CURATORS SAVED TO THE FILE");

            });
            this.Dispatcher.Invoke(act, DispatcherPriority.ApplicationIdle);
        }
    }
}
