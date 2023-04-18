using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task1SQL.Model;
using Task1SQL.View;

namespace Task1SQL
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SASEntities _db = new SASEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(TbLogin.Text) ||
                    string.IsNullOrEmpty(PbPassword.Password) ||
                    string.IsNullOrEmpty(TbPhone.Text) ||
                    string.IsNullOrEmpty(TbEmail.Text))


                {
                    MessageBox.Show($"Не все строки заполнены!");
                }
                else
                {
                    _db.Users.Add(new User()
                    {
                        Login = TbLogin.Text,
                        Password = PbPassword.Password,
                        Phone = TbPhone.Text,
                        Email = TbEmail.Text
                    });
                    _db.SaveChanges();
                    MessageBox.Show($"New User Created! Well done!");
                    TbLogin.Text = string.Empty;
                    PbPassword.Password = string.Empty;
                    TbPhone.Text = string.Empty;
                    TbEmail.Text = string.Empty;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Error 3");
            }
        }

        private void Run_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new InfoWindow().Show();
            Close();
        }
    }
}
