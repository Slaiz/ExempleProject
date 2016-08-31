using System;
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
    class MainWindowViewModel:DependencyObject
    {

        public PeopleModel People { get; set; }
        public ICommand ClickCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(MainWindowViewModel), new PropertyMetadata(null));

        public MainWindowViewModel()
        {
            ClickCommand = new Command(arg => ClickMethod());
            AddCommand = new Command(arg => AddMethod());

            Items = CollectionViewSource.GetDefaultView(PeopleModel.GetPeoples());
        }

        private void AddMethod()
        {
            
        }

        private void ClickMethod()
        {
            MessageBox.Show("This is click command.");
        }
    }
}
