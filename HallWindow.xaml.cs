﻿using System;
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
using System.Windows.Shapes;
using WpfApp20.cinemakinDataSetTableAdapters;

namespace WpfApp20
{
    /// <summary>
    /// Логика взаимодействия для HallWindow.xaml
    /// </summary>
    public partial class HallWindow : Window
    {
        HallTableAdapter hall = new HallTableAdapter();
        public HallWindow()
        {
            InitializeComponent();
            CinemaDataGrid.ItemsSource = hall.GetData();

        }

        private void close_click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = Vvod.Text;
                string[] b = a.Split(',');
                hall.InsertQuery(b[0], Convert.ToInt32(b[1]),(b[1]));
                CinemaDataGrid.ItemsSource = hall.GetData();
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
                hall.DeleteQuery(Convert.ToInt32(id));
                CinemaDataGrid.ItemsSource = hall.GetData();
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
                hall.UpdateQuery(b[0], Convert.ToInt32(b[1]), Convert.ToInt32(b[2]), Convert.ToInt32(id));
                CinemaDataGrid.ItemsSource = hall.GetData();

            }
            catch
            {
                MessageBox.Show("Выберите строку");
            }
        }
    }
}
