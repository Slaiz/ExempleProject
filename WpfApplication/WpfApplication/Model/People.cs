

namespace WpfApplication.Model
{
    public class People
    {
        private string _firstName;
        private string _lastName;

        public People()
        {
            FirstName = "1";
            LastName = "2";
        }

        public People(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName {
            get { return _firstName;}
            set { _firstName = value; }
        }

        public string LastName {
            get { return _lastName;}
            set { _lastName = value; }
        }

    }
}
