using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WpfApplication.Model;

namespace WpfApplication.ViewModel
{
    class MainViewModel: BaseViewModel
    {
        public ICommand ClickCommand { get; set; }
        public ICommand AddCommand { get; set; }

        private List<People> itemsList = new List<People>();

        public List<People> ItemsList
        {
            get { return itemsList; }
        }

        string _textProperty1;

        string _textProperty2;

        public string TextProperty1
        {
            get
            {
                return _textProperty1;
            }
            set
            {
                if (_textProperty1 != value)
                {
                    _textProperty1 = value;
                    OnPropertyChanged("TextProperty1");
                }
            }
        }

        public string TextProperty2
        {
            get
            {
                return _textProperty2;
            }
            set
            {
                if (_textProperty2 != value)
                {
                    _textProperty2 = value;
                    OnPropertyChanged("TextProperty2");
                }
            }
        }

        public MainViewModel()
        {
            ClickCommand = new Command(arg => ClickMethod());
            AddCommand = new Command(arg => AddMethod());
        }

        private void AddMethod()
        {
            if (TextProperty1 == "" || TextProperty2 == "")
                {MessageBox.Show("Please write all fields"); return;}

            itemsList.Add(new People(TextProperty1, TextProperty2));
            OnPropertyChanged(nameof(ItemsList));

            //TextProperty1 = "";
            //TextProperty2 = "";
        }

        private void ClickMethod()
        {
            MessageBox.Show("This is click command.");
        }
    }
}
