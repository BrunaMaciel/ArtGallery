using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using CGSLibrary;

namespace ArtGallery
{
    class Program
    {
        static Gallery gal;
        static Regex ryear = new Regex(@"^[0-9]{4}$");
        static void Main(string[] args)
        {
            gal = new Gallery();
            MainMenu();
        }

        static private void ArtistMenu()
        {
            Console.Clear();
            Console.WriteLine("------ Artist Menu ------ \n");
            Console.WriteLine("1 - Add Artist");
            Console.WriteLine("2 - List Artists");
            Console.WriteLine("3 - Search Artist");
            Console.WriteLine("4 - Delete Artist");
            Console.WriteLine("5 - Return");
            Console.Write("Option:");
            int opt = int.Parse(Console.ReadLine());

            switch (opt)
            {
                case 1:
                    NewArtist();
                    ArtistMenu();
                    break;
                case 2:
                    List('A');
                    ArtistMenu();
                    break;
                case 3:
                    NewSearch('A');
                    ArtistMenu();
                    break;
                case 4:
                    DeleteArtist();
                    ArtistMenu();
                    break;
                case 5:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option! Please choose a valid option.");
                    break;

            }
        }

        static private void CuratorMenu()
        {
            Console.Clear();
            Console.WriteLine("------ Curator Menu ------ \n");
            Console.WriteLine("1 - Add Curator");
            Console.WriteLine("2 - List Curatos");
            Console.WriteLine("3 - Search Curator");
            Console.WriteLine("4 - Delete Curator");
            Console.WriteLine("5 - Return");
            Console.Write("Option:");
            int opt = int.Parse(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        NewCurator();
                        CuratorMenu();
                        break;
                    case 2:
                        List('C');
                        CuratorMenu();
                        break;
                    case 3:
                        NewSearch('C');
                        CuratorMenu();
                        break;
                    case 4:
                        DeleteCurator();
                        CuratorMenu();
                        break;
                    case 5:
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid option! Please choose a valid option.");
                        break;
            }
        }

        static private void ArtPieceMenu()
        {
            Console.Clear();
            Console.WriteLine("------ Art Piece Menu ------ \n");
            Console.WriteLine("1 - Add Art Piece");
            Console.WriteLine("2 - List Art Pieces");
            Console.WriteLine("3 - Search Art Piece");
            Console.WriteLine("4 - Sell Art Piece");
            Console.WriteLine("5 - Delete Art Piece");
            Console.WriteLine("6 - Return");
            Console.Write("Option:");
            int opt = int.Parse(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        NewArtPiece();
                        ArtPieceMenu();
                        break;
                    case 2:
                        List('P');
                        ArtPieceMenu();
                        break;
                    case 3:
                        NewSearch('P');
                        ArtPieceMenu();
                        break;
                    case 4:
                        SellArtPieces();
                        ArtPieceMenu();
                        break;
                    case 5:
                        DeleteArtPiece();
                        ArtPieceMenu();
                        break;
                    case 6:
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid option! Please choose a valid option.");
                        break;
            }
        }

        static private void MainMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("------ Main Menu ------ \n");
                Console.WriteLine("Select the option to enter de submenu.\n");
                Console.WriteLine("1 - Curator");
                Console.WriteLine("2 - Artist");
                Console.WriteLine("3 - Art Piece");
                Console.WriteLine("4 - Return");
                Console.Write("Option:");
                int opt = int.Parse(Console.ReadLine());

                while (opt != 4)
                {
                    switch (opt)
                    {
                        case 1:
                            CuratorMenu();
                            break;
                        case 2:
                            ArtistMenu();
                            break;
                        case 3:
                            ArtPieceMenu();
                            break;
                        case 4:
                            return;
                            break;
                        default:
                            Console.WriteLine("Invalid option! Please choose a valid option.");
                            break;

                    }
                }
            }
            catch (FormatException fex)
            {
                Console.WriteLine("\nWrong format input!");
            }
        }

        static private void List(char type)
        {
            Console.Clear();

            switch (type)
            {
                case 'A':
                    Console.WriteLine("------ Artists List ------ \n");
                    Console.WriteLine();
                    Console.WriteLine(gal.ListArtists());
                    break;
                case 'C':
                    Console.WriteLine("------ Curators List ------ \n");
                    Console.WriteLine();
                    Console.WriteLine(gal.ListCurators());
                    break;
                case 'P':
                    Console.WriteLine("------ Art Pieces List ------ \n");
                    Console.WriteLine();
                    Console.WriteLine(gal.ListArtPieces());
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
        static private void NewSearch(char type)
        {
            string id;
            Console.Clear();
            Console.WriteLine("------ New Search ------ \n");
            switch (type)
            {
                case 'A':
                    Console.Write("Type the artistID you want to search:");
                    id = Console.ReadLine();
                    Console.WriteLine();
                    Artist a = gal.SearchArtist(id);
                    if (a != null)
                        Console.WriteLine(a.ToString());
                    else
                        Console.WriteLine("ID not found!");
                    break;
                case 'C':
                    Console.Write("Type the curatorID you want to search:");
                    id = Console.ReadLine();
                    Console.WriteLine();
                    Curator c = gal.SearchCurator(id);
                    if (c != null)
                        Console.WriteLine(c.ToString());
                    else
                        Console.WriteLine("ID not found!");
                    break;
                case 'P':
                    Console.Write("Type the pieceID you want to search:");
                    id = Console.ReadLine();
                    Console.WriteLine();
                    ArtPiece p = gal.SearchArtPiece(id);
                    if (p != null)
                        Console.WriteLine(p.ToString());
                    else
                        Console.WriteLine("ID not found!");
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
        static private void NewArtist()
        {
            Console.Clear();
            Console.WriteLine("------ Add new artist ------ \n");

            Console.Write("Type the artist name: ");
            string fName = Console.ReadLine();

            Console.Write("Type the artist ID: ");
            string artistID = Console.ReadLine();
            while (artistID.Length != 5 || gal.SearchArtist(artistID) != null)
            {
                Console.WriteLine("Invalid ID!Please try again.");
                artistID = Console.ReadLine();
            }

            gal.AddArtist(fName, artistID);
            Console.WriteLine();
            Console.WriteLine("Artist added!Press any key to continue.");
            Console.ReadLine();

        }
        static private void DeleteArtist()
        {
            Console.Clear();
            Console.WriteLine("------ Delete artist ------ \n");

            Console.Write("Type the artist ID: ");
            string artistID = Console.ReadLine();
            while (artistID.Length != 5 || gal.SearchArtist(artistID) == null)
            {
                Console.WriteLine("Invalid ID!Please try again.");
                artistID = Console.ReadLine();
            }

            gal.DeletArtist(artistID);
            Console.WriteLine();
            Console.WriteLine("Artist deleted!Press any key to continue.");
            Console.ReadLine();

        }
        static private void NewCurator()
        {
            Console.Clear();
            Console.WriteLine("------ Add new curator ------ \n");

            Console.Write("Type the curator name: ");
            string fName = Console.ReadLine();

            Console.Write("Type the curator ID: ");
            string curatorID = Console.ReadLine();
            while (curatorID.Length != 5 || gal.SearchCurator(curatorID) != null)
            {
                Console.WriteLine("Invalid ID!Please try again.");
                curatorID = Console.ReadLine();
            }
            gal.AddCurator(fName, curatorID);

            Console.WriteLine("Curator added!Press any key to continue.");
            Console.ReadLine();
        }

        static private void DeleteCurator()
        {
            Console.Clear();
            Console.WriteLine("------ Delete curator ------ \n");

            Console.Write("Type the curator ID: ");
            string curatorID = Console.ReadLine();
            while (curatorID.Length != 5 || gal.SearchCurator(curatorID) == null)
            {
                Console.WriteLine("Invalid ID!Please try again.");
                curatorID = Console.ReadLine();
            }

            gal.DeleteCurator(curatorID);
            Console.WriteLine();
            Console.WriteLine("Curator deleted!Press any key to continue.");
            Console.ReadLine();

        }
        static private void NewArtPiece()
        {
            Console.Clear();
            Console.WriteLine("------ Add new art piece ------ \n");

            Console.Write("Type the piece ID: ");
            string artPieceID = Console.ReadLine();
            while (artPieceID.Length != 5 || gal.SearchArtPiece(artPieceID) != null)
            {
                Console.WriteLine("Invalid ID!Please try again.");
                artPieceID = Console.ReadLine();
            }

            Console.Write("Type the piece title: ");
            string pieceTitle = Console.ReadLine();
            while (pieceTitle.Length > 40)
            {
                Console.WriteLine("Title must have a maximum of 40 caracters!Please try again.");
                pieceTitle = Console.ReadLine();
            }

            Console.Write("Type the piece year: ");
            string pieceYear = Console.ReadLine();
            while (!ryear.IsMatch(pieceYear))
            {
                Console.WriteLine("Year must be exactly 4 numbers!Please try again.");
                pieceYear = Console.ReadLine();

            }

            Console.Write("Type the piece estimated price: ");
            double pieceValue = double.Parse(Console.ReadLine());

            Console.Write("Type the artist ID: ");
            string artistID = Console.ReadLine();
            while (artistID.Length != 5 || gal.SearchArtist(artistID) == null)
            {
                Console.WriteLine("Invalid ID!Please try again.");
                artistID = Console.ReadLine();
            }

            Console.Write("Type the curator ID: ");
            string curatorID = Console.ReadLine();
            while (curatorID.Length != 5 || gal.SearchCurator(curatorID) == null)
            {
                Console.WriteLine("Invalid ID!Please try again.");
                curatorID = Console.ReadLine();
            }

            gal.AddArtPiece(artPieceID, pieceTitle, pieceYear, pieceValue, artistID, curatorID);

            Console.WriteLine();
            Console.WriteLine("Art Piece added!Press any key to continue.");
            Console.ReadLine();
        }

        static private void DeleteArtPiece()
        {
            Console.Clear();
            Console.WriteLine("------ Delete Art Piece ------ \n");

            Console.Write("Type the art piece ID: ");
            string pieceID = Console.ReadLine();
            while (pieceID.Length != 5 || gal.SearchArtPiece(pieceID) == null)
            {
                Console.WriteLine("Invalid ID!Please try again.");
                pieceID = Console.ReadLine();
            }

            gal.DeleteArtPiece(pieceID);

            Console.WriteLine();
            Console.WriteLine("Art piece deleted!Press any key to continue.");
            Console.ReadLine();

        }
        static private void SellArtPieces()
        {
            Console.Clear();
            Console.WriteLine("------ Sell art piece ------ \n");

            Console.Write("Type the piece ID: ");
            string artPieceID = Console.ReadLine();
            while (artPieceID.Length != 5 || gal.SearchArtPiece(artPieceID) == null)
            {
                Console.WriteLine("Invalid ID!Please try again.");
                artPieceID = Console.ReadLine();
            }

            Console.Write("Type the piece sell price: ");
            double piecePrice = double.Parse(Console.ReadLine());

            gal.SellPiece(artPieceID, piecePrice);

            Console.WriteLine();
            Console.WriteLine("Art Piece sold!Press any key to continue.");
            Console.ReadLine();

        }
    }
}
