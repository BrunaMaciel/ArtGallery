using System;
using System.Collections.Generic;
using System.Text;

namespace CGSLibrary
{
    public class Artist : Person
    {
        private string artistID;

        public Artist (string fname, string artistID):base(fname)
        {
            this.artistID = artistID;
        }

        public string ArtistID
        {
            get
            {
                return artistID;
            }
        }

        public override string ToString()
        {
            return base.ToString()+" (ID: "+artistID+")";
        }
    }
}
