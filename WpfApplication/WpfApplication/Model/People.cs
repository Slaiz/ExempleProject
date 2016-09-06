using System;

namespace WpfApplication.Model
{
    public class People
    {
        private string _firstName;
        private string _lastName;
        private byte[] _image;

        public People()
        {
            FirstName = "1";
            LastName = "2";
        }

        public People(string firstName, string lastName, byte[] image)
        {
            FirstName = firstName;
            LastName = lastName;
            Image = image;
        }

        public string FirstName {
            get { return _firstName;}
            set { _firstName = value; }
        }

        public string LastName {
            get { return _lastName;}
            set { _lastName = value; }
        }

        public byte[] Image
        {
            get
            {
                return _image;
            }
            set { _image = value; }
        }
    }
}
