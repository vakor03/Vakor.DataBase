using System;
using System.Windows;
using System.Windows.Controls;
using Vakor.DataBase.Lib.DataBases;

namespace Vakor.DataBase.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private IDataBase _dataBase;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            Closed += OnClosed;
        }

        private void OnClosed(object? sender, EventArgs e)
        {
            _dataBase.SaveChanges();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _dataBase = new Lib.DataBases.DataBase(@"C:\Users\Vakor\Pictures\DataBase");
            _dataBase.OpenConnection();
        }

        private void SearchKeyOnTextChanged(object sender, TextChangedEventArgs e)
        {
            string key = (sender as TextBox)?.Text;

            if (!int.TryParse(key, out int intKey) || _dataBase.Search(intKey, out _) is null)
            {
                SearchRecordValue.Content = "Invalid key!";
            }
            else
            {
                SearchRecordValue.Content = _dataBase.Search(intKey, out _).Data;
            }
        }

        private void RemoveButtonOnClick(object sender, RoutedEventArgs e)
        {
            string key = DeleteKey.Text;

            string dialogBoxMessage;
            if (!int.TryParse(key, out int intKey) || _dataBase.Search(intKey, out _) is null)
            {
                dialogBoxMessage = "Invalid key!";
            }
            else
            {
                _dataBase.Remove(intKey);
                _dataBase.SaveChanges();
                dialogBoxMessage = "Removed successfully!";
            }


            MessageBox.Show(dialogBoxMessage);
        }

        private void AddButtonOnClick(object sender, RoutedEventArgs e)
        {
            string value = AddValue.Text;

            _dataBase.Add(value);
            _dataBase.SaveChanges();
            string dialogBoxMessage = "Added successfully!";

            MessageBox.Show(dialogBoxMessage);
        }

        private void EditButtonOnClick(object sender, RoutedEventArgs e)
        {
            string key = EditKey.Text;
            string value = EditValue.Text;

            string dialogBoxMessage;
            if (!int.TryParse(key, out int intKey))
            {
                dialogBoxMessage = "Invalid key!";
            }
            else
            {
                _dataBase.Add(intKey, value);
                dialogBoxMessage = "Edited successfully!";
                _dataBase.SaveChanges();
            }


            MessageBox.Show(dialogBoxMessage);
        }
    }
}