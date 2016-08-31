using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApplication.Model;

namespace WpfApplication.ViewModel
{
    class MainWindowViewModel
    {

        public PeopleModel People { get; set; }
        public ICommand ClickCommand { get; set; }

        public MainWindowViewModel()
        {
            ClickCommand = new Command(arg => ClickMethod());

            People = new PeopleModel()
            {
                FirstName = "First name",
                LastName = "Last name"
            };            
        }

        private void ClickMethod()
        {
            MessageBox.Show("This is click command.");
        }
    }
}
