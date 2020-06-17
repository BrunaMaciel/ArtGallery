using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace CGSLibrary
{
    public class Gallery
    {
        private List<Artist> artists;
        private List<Curator> curators;
        private List<ArtPiece> pieces;
        

        public Artist AddArtist(string fname, string id)
        {
            Artist a = new Artist(fname, id);
            if (artists == null)
            {
                artists = new List<Artist>();
            }
            artists.Add(a);
            return a;
        }
        public Artist DeletArtist(string id)
        {
            Artist a = SearchArtist(id);

            if (a == null)
                return null;

            artists.Remove(a);
            return a;
        }
        public string ListArtists()
        {
            string artistsList = "";
            if (artists == null)
            {
                return "No artists registered!";
            }
            else if (artists.Count == 0)
            {
                return "No artists registered!";
            }
            else
            {
                foreach (Artist a in artists)
                {
                    artistsList += a.ToString() + "\n";
                }
            }
            return artistsList;
        }
        public Artist SearchArtist(string id)
        {
            if (artists == null)
                return null;
            else
            {
                foreach (Artist a in artists)
                {
                    if (a.ArtistID.Equals(id))
                        return a;
                }
            }
            return null;
        }


        public Curator AddCurator(string fname, string id)
        {
            Curator c = new Curator(fname, id);
            if (curators == null)
            {
                curators = new List<Curator>();
            }
            curators.Add(c);
            return c;
        }
        public Curator DeleteCurator(string id)
        {
            Curator c = SearchCurator(id);
            if (c == null)
                return null;
            curators.Remove(c);
            return c;
        }
        public string ListCurators()
        {
            string curatorslist = "";
            if (curators == null)
            {
                
                return "No curators registered!";
            }
            else if (curators.Count == 0)
            {
                return "No curators registered!";
            }
            else
            {
                foreach (Curator c in curators)
                {
                    curatorslist += c.ToString() + "\n";
                }
            }

            return curatorslist;
        }
        public Curator SearchCurator(string id)
        {
            if (curators == null)
                return null;
            else
            {
                foreach (Curator c in curators)
                {
                    if (c.CuratorID.Equals(id))
                        return c;
                }
            }
            return null;
        }

        public ArtPiece AddArtPiece(string pieceID, string title, string year, double estimate, string artist, string curator)
        {
            ArtPiece p = new ArtPiece(pieceID, title, year, estimate, artist, curator);
            if (pieces == null)
            {
                pieces = new List<ArtPiece>();
            }
            pieces.Add(p);
            return p;
        }
        public ArtPiece DeleteArtPiece(string id)
        {
            ArtPiece p = SearchArtPiece(id);

            if (p == null)
                return null;

            pieces.Remove(p);
            return p;
        }
        public string ListArtPieces()
        {
            string pieceslist = "";
            Console.OpenStandardOutput();
            if (pieces == null)
            {
                return "No pieces registered!";
            }
            else if (pieces.Count == 0)
            {
                return "No pieces registered!";
            }
            else{
                foreach (ArtPiece p in pieces)
                {
                    pieceslist += p.ToString();
                    if (pieces.IndexOf(p) != pieces.Count - 1)
                    {
                        pieceslist += "\n\n";
                    }

                }
            }
            return pieceslist;
            
        }
        public ArtPiece SearchArtPiece(string id)
        {
            if (pieces == null)
                return null;
            else
            {
                foreach (ArtPiece p in pieces)
                {
                    if (p.PieceID.Equals(id))
                        return p;
                }
            }
            return null;
        }
        public int SellPiece(string pieceID, double value)
        {
            ArtPiece p = SearchArtPiece(pieceID);
            if (p == null)
                return 0;
            if (p.Status == 'S')
            {
                //"Art Piece already sold!"
                return 1;
            }
            else if (p.Status == 'O')
            {
                //"Art Piece not avaliable for selling!
                return 2;
            }
            else if (p.Status == 'D')
            {
                p.ChangeStatus('S');
                p.PricePaid(value);

                Curator c = SearchCurator(p.CuratorID);
                c.SetComm(p.CalculateComm(value));
            }
            return 3;
        }
        public bool SetStatus (string pieceID, char status)
        {
            ArtPiece p = SearchArtPiece(pieceID);
            if (p.Status != 'S')
            {
                p.ChangeStatus(status);
                return true;
            }
            return false;
                
        }

    }
}
