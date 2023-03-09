using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void bt_oblicz_Click(object sender, RoutedEventArgs e)
        {
            double r, h, v;

            try
            {
                r = Convert.ToDouble(txtpromien.Text);
                h = Convert.ToDouble(txtwysokosc.Text);
                if (r <= 0 || h <= 0)
                {
                    MessageBox.Show("Nieprawidłowe dane!");
                }
                else
                {
                    switch (cmbRodzajbryly.SelectedIndex)
                    {
                        default: throw new NotImplementedException();
                        case 0: v = Math.PI * Math.Pow(r, 2) * h; break;
                        case 1: v = 1D / 3D * Math.PI * Math.Pow(r, 2) * h; break;
                        case 2: v = 4.0 / 3.0 * Math.PI * Math.Pow(r, 3) * h; break;
                    }

                    lbl_objetosc.Content = "Objętość wynosi: " + v.ToString("F2") + "m^3";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Nieprawidłowe dane!");
            }

            }

        private void cmbRodzajbryly_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbRodzajbryly.SelectedIndex == 2)
            {
                txtwysokosc.Visibility = Visibility.Hidden;
                label_info2.Visibility = Visibility.Hidden;
            }
            else
            {
                txtwysokosc.Visibility = Visibility.Visible;
                label_info2.Visibility = Visibility.Visible;
            }
        }

        void RysujLinie(Brush pedzel, double xstart, double xend, double ystart, double yend, double Thick)
        {
            var myLine = new Line();
            myLine.Stroke = pedzel;
            myLine.X1 = xstart;
            myLine.X2 = xend;
            myLine.Y1 = ystart;
            myLine.Y2 = yend;
            myLine.StrokeThickness = Thick;
            cv_rysunek.Children.Add(myLine);
        }
        void czyscPlotno()
        {
            cv_rysunek.Children.Clear();
        }

        void rysujWypelnionaElipse(double wid, double hei, Brush kolor, double x = 50, double y = 50)
        {
            Ellipse elips = new Ellipse();
            elips.Stroke = kolor;
            elips.Width = wid;
            elips.Height = hei;
            elips.Fill = kolor;
            cv_rysunek.Children.Add(elips);
            Canvas.SetLeft(elips, x);
            Canvas.SetTop(elips, y);
/*
            for (int i = 0; i < 72; i++)
            {

                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = 150;
                line.Y1 = 150;
                line.X2 = 250;
                line.Y2 = 150;
                line.RenderTransform = new RotateTransform(5 * i, 150, 150);
                cv_rysunek.Children.Add(line);
            }*/
        }

        void rysujWypelnioneKolo(double x = 100, double y = 100, double r = 50)
        {
            Brush col = Brushes.Green;
            rysujWypelnionaElipse(r,r, col, x, y);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RysujLinie(Brushes.Black, xstart: 0, xend: 299, ystart: 150, yend: 150, Thick:1);
            RysujLinie(Brushes.Black, xstart: 0, xend: 299, ystart: 150, yend: 150, Thick: 1);
        }

        private void bt_clear_Click(object sender, RoutedEventArgs e)
        {
            czyscPlotno();
        }

        private void bt_elipsa_Click(object sender, RoutedEventArgs e)
        {
            rysujWypelnionaElipse(200,200,Brushes.Red);
        }

        private void bt_kolo_Click(object sender, RoutedEventArgs e)
        {
            rysujWypelnioneKolo();
        }

        void RysujDrzewo()
        {
            var pien = new Line();
            var korona = new Ellipse();

            pien.Stroke = Brushes.Brown;
            pien.X1 = 140;
            pien.Y1 = 150;
            pien.X2 = 140;
            pien.Y2 = 300;
            pien.StrokeThickness = 10;
            cv_rysunek.Children.Add(pien);
            rysujWypelnioneKolo(pien.X2,pien.Y2,100);

        }

        private void bt_tree_Click(object sender, RoutedEventArgs e)
        {
            RysujDrzewo();

        }
    }
}
