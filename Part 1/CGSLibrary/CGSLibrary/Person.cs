using System;

namespace CGSLibrary
{
    public abstract class Person
    {
        private string fullName;

        public Person (string fname)
        {
            this.fullName = fname;
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
        }

        public override string ToString()
        {
            return fullName;
        }
    }
}
