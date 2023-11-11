using System;
using System.Collections.Generic;
using System.Data;
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
using WpfApp20.cinemakinDataSetTableAdapters;

namespace WpfApp20
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FilmTableAdapter film = new FilmTableAdapter();
        
        public MainWindow()
        {
            InitializeComponent();

            CinemaDataGrid.ItemsSource = film.GetData();
        }

      
        private void pokazhall_Click(object sender, RoutedEventArgs e)
        {
            HallWindow halls = new HallWindow();
            halls.Show();
        }

        private void pokazSessions_Click(object sender, RoutedEventArgs e)
        {
            SesionsWindow session = new SesionsWindow();
            session.Show();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = Vvod.Text;
                string[] b = a.Split(',');
                film.InsertQuery(b[0], (b[1]), (b[2]), Convert.ToInt32(b[3]));
                CinemaDataGrid.ItemsSource = film.GetData();
            }
            catch 
            {
                MessageBox.Show("Неправильный ввод");
            }
        }
        private void del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (CinemaDataGrid.SelectedItem as DataRowView).Row[0];
                film.DeleteQuery(Convert.ToInt32(id));
                CinemaDataGrid.ItemsSource = film.GetData();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
        private void cinemaSelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView id = (CinemaDataGrid.SelectedItem as DataRowView);
                Vvodi.Text = id.Row[1].ToString() + "," + id.Row[2].ToString() + "," + id.Row[3].ToString();
            }
            catch 
            {
                Vvodi.Text = "";
            }
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (CinemaDataGrid.SelectedItem as DataRowView).Row[0];
                string a = Vvodi.Text;
                string[] b = a.Split(',');
                film.UpdateQuery(b[0], Convert.ToInt32(b[1]), Convert.ToInt32(b[2]) ,Convert.ToInt32(id));
                CinemaDataGrid.ItemsSource = film.GetData();

            }
            catch 
            {
                MessageBox.Show("Выберите строку");
            }
        }
    } 

}
