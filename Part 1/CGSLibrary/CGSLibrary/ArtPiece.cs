using System;
using System.Collections.Generic;
using System.Text;

namespace CGSLibrary
{
    public class ArtPiece
    {
        private string pieceID;
        private string title, year;
        private double price, estimate;
        private string artistID, curatorID;
        private char status; //D: On display , S: Sold , O: Out in storage

        public string PieceID
        {
            get
            {
                return pieceID;
            }

        }

        public string CuratorID
        {
            get
            {
                return curatorID;
            }
        }

        public char Status
        {
            get
            {
                return status;
            }
        }

        public ArtPiece(string pieceID, string title, string year, double estimate, string artist, string curator)
        {
            this.pieceID = pieceID;
            this.title = title;
            this.year = year;
            this.estimate = estimate;
            this.artistID = artist;
            this.curatorID = curator;

            status = 'D';
            price = 0.0;
        }

        public override string ToString()
        {
            string pieceInfo = year + " - " + title + "(" + pieceID + "-" + status + ")";
            string galInfo = "\nArtist: " + artistID + "\nCurator: " + curatorID + "\nEstimated price: " + estimate;
            if (price != 0)
            {
                galInfo += "\nSell Price: " + price;
            }
            return pieceInfo + galInfo;
        }

        public void ChangeStatus (char status)
        {
            this.status = status;
        }

        public void PricePaid(double value)
        {
            this.price = value;
        }

        public double CalculateComm (double value)
        {
            return Math.Abs(estimate - value) * 0.25; ;
        }
    }
}
