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
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using CGSLibrary;

namespace ArtGallery
{
    /// <summary>
    /// Interaction logic for CGSArt.xaml
    /// </summary>
    public partial class CGSArt : Window
    {
        Gallery gal;
        Regex ryear = new Regex(@"^[0-9]{4}$");
        Regex rvalue = new Regex(@"^[0-9]+$");

        public CGSArt()
        {
            InitializeComponent();
            gal = new Gallery();
        }

        private bool fieldsValidation (string fieldType, TextBox field)
        {
            
            switch (fieldType)
            {
                case "id":
                    if (field.Text.Length != 5)
                    {
                        return false;
                    }
                    break;
                case "curatorName":
                    if (field.Text.Length > 30)
                    {
                        return false;
                    }
                    break;
                case "artistName":
                case "pieceTitle":
                    if (field.Text.Length > 40)
                    {
                        return false;
                    }
                    break;
                case "pieceYear":
                    if (!ryear.IsMatch(field.Text))
                        return false;
                    break;
                case "pieceEstimate":
                    if (!rvalue.IsMatch(field.Text))
                        return false;
                    break;
            }
            
            return true;
        }
        private void addCurator_Click(object sender, RoutedEventArgs e)
        {
            if (curatorID.Text == "" || curatorName.Text == "")
            {
                MessageBox.Show("ID and Name are required!");
                return;
            }
                
            if (!fieldsValidation("id", curatorID))
            {
                MessageBox.Show("Invalid ID!\nID should have 5 characteres.");
                return;
            }
            if (!fieldsValidation("curatorName", curatorName))
            {
                int size = curatorName.Text.Length;
                MessageBox.Show("Invalid Name!\nName must have maximum 30 characteres.");
                return;
            }


            Curator c = gal.SearchCurator(curatorID.Text);
            if (c != null)
                curatorsText.Text = "Curator ID already exists!";
            else
            {
                c = gal.AddCurator(curatorName.Text, curatorID.Text);
                curatorsText.Text = "Curator added!\n";
                curatorsText.Text += c.ToString();

                //Clear information
                curatorID.Text = "";
                curatorName.Text = "";
            }

        }

        private void addArtist_Click(object sender, RoutedEventArgs e)
        {
            if (artistID.Text == "" || artistName.Text == "")
            {
                MessageBox.Show("ID and Name are required!");
                return;
            }

            if (!fieldsValidation("id", artistID))
            {
                MessageBox.Show("Invalid ID!\nID should have 5 characteres.");
                return;
            }
            if (!fieldsValidation("artistName", artistName))
            {
                MessageBox.Show("Invalid Name!\nName must have maximum 40 characteres.");
                return;
            }

            Artist a = gal.SearchArtist(artistID.Text);
            if (a != null)
                artistsText.Text = "Artist ID already exists!";
            else
            {
                a = gal.AddArtist(artistName.Text, artistID.Text);
                artistsText.Text = "Artist added!\n";
                artistsText.Text += a.ToString();

                //Clear fields
                artistID.Text = "";
                artistName.Text = "";
            }
        }

        private void addArtPiece_Click(object sender, RoutedEventArgs e)
        {
            if (pieceID.Text == "" || pieceTitle.Text == "" || pieceYear.Text == "" || pieceEstimate.Text == "" || pieceArtistID.Text == "" || pieceCuratorID.Text == "")
            {
                MessageBox.Show("All fields are required!");
                return;
            }

            if (!fieldsValidation("id", pieceID))
            {
                MessageBox.Show("Invalid ID!\nID should have 5 characteres.");
                return;
            }
            if (!fieldsValidation("pieceTitle", pieceTitle))
            {
                MessageBox.Show("Invalid Name!\nName must have maximum 40 characteres.");
                return;
            }
            if (!fieldsValidation("pieceYear", pieceYear))
            {
                MessageBox.Show("Invalid Year!\nYear must have 4 digits.");
                return;
            }
            if (!fieldsValidation("pieceEstimate", pieceEstimate))
            {
                MessageBox.Show("Invalid Estimate Value!\nValue must be a number.");
                return;
            }

            piecesText.Text = "";
            ArtPiece p = gal.SearchArtPiece(pieceID.Text);
            if (p != null)
            {
                MessageBox.Show("Piece ID already exists!");
                return;
            }

            Artist a = gal.SearchArtist(pieceArtistID.Text);
            if (a == null)
            {
                MessageBox.Show("Artist ID doesn`t exists!");
                return;
            }
            Curator c = gal.SearchCurator(pieceCuratorID.Text);
           
            if (c == null)
            {
                MessageBox.Show("Curator ID doesn`t exists!");
                return;
            }

             p = gal.AddArtPiece(pieceID.Text, pieceTitle.Text, pieceYear.Text, double.Parse(pieceEstimate.Text), pieceArtistID.Text, pieceCuratorID.Text);
            if (pieceInStorage.IsChecked == true)
                gal.SetStatus(pieceID.Text, 'O');
            if (pieceOnDisplay.IsChecked == true)
                gal.SetStatus(pieceID.Text, 'D');

            piecesText.Text = "Art Piece added!\n";
            piecesText.Text += p.ToString();

            //Clear fields
            pieceID.Text = "";
            pieceTitle.Text = "";
            pieceYear.Text = "";
            pieceEstimate.Text = "";
            pieceArtistID.Text = "";
            pieceCuratorID.Text = "";
        }
    
        private void listArtPieces_Click(object sender, RoutedEventArgs e)
        {
            piecesText.Text = "Art Pieces List:\n";
            piecesText.Text += gal.ListArtPieces();
        }

        private void listArtists_Click(object sender, RoutedEventArgs e)
        {
            artistsText.Text = "Artists List:\n";
            artistsText.Text += gal.ListArtists();
        }

        private void listCurators_Click(object sender, RoutedEventArgs e)
        {
            curatorsText.Text = "Curators List:\n";
            curatorsText.Text += gal.ListCurators();
        }

        private void SellArtPiece_Click(object sender, RoutedEventArgs e)
        {
            piecesText.Text = "";
            SellPiece sell = new SellPiece();

            sell.Gal = gal; 
            sell.ShowDialog();
            
        }

        private void ReadMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (gal.ReadCurators())
                MessageBox.Show("Curators list updated!");
            else
                MessageBox.Show("Curators list can`t be updated!");
        }

        private void SaveMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (gal.WriteCurators())
                MessageBox.Show("Curators saved in file!");
            else
                MessageBox.Show("Curators can`t be saved in file!");
        }

        private void SearchCurators_Click(object sender, RoutedEventArgs e)
        {
            curatorsText.Text = "";

            if (curatorID.Text == "")
            {
                MessageBox.Show("Curator ID is required!");
                return;
            }
            Curator c = gal.SearchCurator(curatorID.Text);

            if (c != null)
            {
                curatorsText.Text = "Curator found!\n";
                curatorsText.Text += c.ToString();
            }
            else
            {
                MessageBox.Show("Curator ID not registred!");
                return;
            }
                
        }

        private void DeleteCurators_Click(object sender, RoutedEventArgs e)
        {
            curatorsText.Text = "";

            if (curatorID.Text == "")
            {
                MessageBox.Show("Curator ID is required!");
                return;
            }

            Curator c = gal.DeleteCurator(curatorID.Text);

            if (c != null)
            {
                curatorsText.Text = "Curator deleted!\n";
                curatorsText.Text += c.ToString();
            }
            else
            {
                MessageBox.Show("Curator ID not registred!");
                return;
            }
        }

        private void SearchArtists_Click(object sender, RoutedEventArgs e)
        {
            artistsText.Text = "";

            if (artistID.Text == "")
            {
                MessageBox.Show("Artist ID is required!");
                return;
            }
            Artist a = gal.SearchArtist(artistID.Text);

            if (a != null)
            {
                artistsText.Text = "Artist found!\n";
                artistsText.Text += a.ToString();
            }
            else
            {
                MessageBox.Show("Artist ID not registred!");
                return;
            }
        }

        private void DeleteArtists_Click(object sender, RoutedEventArgs e)
        {
            artistsText.Text = "";

            if (artistID.Text == "")
            {
                MessageBox.Show("Artist ID is required!");
                return;
            }
            Artist a = gal.DeletArtist(artistID.Text);

            if (a != null)
            {
                artistsText.Text = "Artist deleted!\n";
                artistsText.Text += a.ToString();
            }
            else
            {
                MessageBox.Show("Artist ID not registred!");
                return;
            }
        }

        private void SearchPiece_Click(object sender, RoutedEventArgs e)
        {
            piecesText.Text = "";

            if (pieceID.Text == "")
            {
                MessageBox.Show("Art Piece ID is required!");
                return;
            }
            ArtPiece p = gal.SearchArtPiece(pieceID.Text);

            if (p != null)
            {
                piecesText.Text = "Art Piece found!\n";
                piecesText.Text += p.ToString();
            }
            else
            {
                MessageBox.Show("Art Piece ID not registred!");
                return;
            }
        }

        private void DeletePiece_Click(object sender, RoutedEventArgs e)
        {
            piecesText.Text = "";

            if (pieceID.Text == "")
            {
                MessageBox.Show("Art Piece ID is required!");
                return;
            }
            ArtPiece p = gal.DeleteArtPiece(pieceID.Text);

            if (p != null)
            {
                piecesText.Text = "Art Piece deleted!\n";
                piecesText.Text += p.ToString();
            }
            else
            {
                MessageBox.Show("Art Piece ID not registred!");
                return;
            }
        }
    }
}
