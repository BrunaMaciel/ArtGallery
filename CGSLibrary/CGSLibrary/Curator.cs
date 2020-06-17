using System;
using System.Collections.Generic;
using System.Text;

namespace CGSLibrary
{
    public class Curator: Person
    {
        private string curatorID;
        private double commission;
        private const double commRate = 0.1;

        public string CuratorID
        {
            get
            {
                return curatorID;
            }

        }

        public double Commission
        {
            get
            {
                return commission;
            }

        }

        public static double CommRate
        {
            get
            {
                return commRate;
            }
        }

        public Curator(string fname, string curatorID) : base(fname)
        {
            this.curatorID = curatorID;
            commission = 0;
        }
        public Curator(string fname, string curatorID, double commission) : base(fname)
        {
            this.curatorID = curatorID;
            this.commission = commission;
        }

        public override string ToString()
        {
            return base.ToString()+" (ID: "+ CuratorID+")" + " Commission: " + commission;
        }

        public void SetComm(double value)
        {
            // not clear in the assignement if the commission should be added to the existing amount or overriden
            commission = value * commRate;
        }

        private void OnChangeCcommission (EventArgs e)
        {
            //method avaliable in the class diagram, but  there is no use for it
        }

        private void ClearComm()
        {
            //method avaliable in the class diagram, but  there is no use for it
        }



    }
}
