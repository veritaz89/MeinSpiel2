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

namespace testControl
{
    /// <summary>
    /// Interaktionslogik für Brett.xaml
    /// </summary>
    public partial class Brett : Page
    {
        private Ellipse figure1 = new Ellipse();
        private Ellipse figure2 = new Ellipse();
        testControl.Spieler spieler1 = new testControl.Spieler();
        testControl.Spieler spieler2 = new testControl.Spieler();
        private int counter = 0;

        public Brett()
        {
            InitializeComponent();            
            TestFigur test1 = new TestFigur("rot",true,false,"Alex");
            TestFigur test2 = new TestFigur("blau",false,true,"Tim");
            figure1 = test1.GetFigure();            
            Field.Children.Add(figure1);
            Grid.SetRow(figure1, 9);
            Grid.SetColumn(figure1, 0);
            figure2 = test2.GetFigure();
            Field.Children.Add(figure2);
            Grid.SetRow(figure2, 9);
            Grid.SetColumn(figure2, 0);
            spieler1.Name = test1.GetSpielername();
            name1.Content = spieler1.Name + " ist rot";
            spieler2.Name = test2.GetSpielername();
            name2.Content = spieler2.Name + " ist blau";
        }

       
        private void move(int anzahl, Ellipse figur,string spielername)
        {
            int column, row, counter = 0;
            int startwert = Grid.GetColumn(figur);
            while (anzahl != counter)
            {
                column = Grid.GetColumn(figur);
                row = Grid.GetRow(figur);
                if (EinsHoch(column, row) && row > 0)
                {
                    switch (row % 2)
                    {
                        case 0:
                            Grid.SetColumn(figur, 0);
                            Grid.SetRow(figur, row - 1);
                            break;
                        default:
                            Grid.SetColumn(figur, 9);
                            Grid.SetRow(figur, row - 1);
                            break;
                    }
                }
                else
                {
                    if ((row % 2 == 0))
                    {
                        Grid.SetColumn(figur, column - 1);
                    }
                    else
                    {
                        Grid.SetColumn(figur, column + 1);
                    }

                }
                counter++;
                if (Grid.GetColumn(figur) == 0 && Grid.GetRow(figur) == 0)
                {
                    MessageBox.Show("Glückwunsch! "+spielername+" hat das Spiel gewonnen");
                    counter = anzahl;
                    wuerfeln.IsEnabled = false;
                }
            }
        }
        private void hochOderRunterRutschen(Ellipse figure,string spielername)
        {
            int spalte = Grid.GetColumn(figure);
            int reihe = Grid.GetRow(figure);
            if (spalte == 2 && reihe == 9)
            {
                hochRutschen(0, 4, figure,spielername);
            }
            if (spalte == 5 && reihe == 9)
            {
                hochRutschen(6, 5, figure, spielername);
            }
            if (spalte == 8 && reihe == 6)
            {
                hochRutschen(7, 4, figure, spielername);
            }
            if (spalte == 4 && reihe == 5)
            {
                hochRutschen(5, 1, figure, spielername);
            }
            if (spalte == 9 && reihe == 4)
            {
                hochRutschen(6, 0, figure, spielername);
            }
            if (spalte == 0 && reihe == 3)
            {
                hochRutschen(2, 1, figure, spielername);
            }
            if (spalte == 9 && reihe == 5)
            {
                runterRutschen(7, 8, figure, spielername);
            }
            if (spalte == 7 && reihe == 3)
            {
                runterRutschen(5, 4, figure, spielername);
            }
            if (spalte == 0 && reihe == 1)
            {
                runterRutschen(4, 8, figure, spielername);
            }
            if (spalte == 7 && reihe == 0)
            {
                runterRutschen(2, 5, figure, spielername);
            }
            if (spalte == 2 && reihe == 0)
            {
                runterRutschen(4, 6, figure, spielername);
            }

        }
        private void hochRutschen(int spalte, int reihe, Ellipse figure,string spielnername)
        {
            MessageBox.Show(spielnername+"! Du kletterst hoch!");
            Grid.SetColumn(figure, spalte);
            Grid.SetRow(figure, reihe);
        }
        private void runterRutschen(int spalte, int reihe, Ellipse figure, string spielnername)
        {
            MessageBox.Show(spielnername+"! Du rutscht runter!");
            Grid.SetColumn(figure, spalte);
            Grid.SetRow(figure, reihe);
        }
        private bool EinsHoch(int c, int r)
        {
            bool musshoch = false;
            if ((c == 9 && r == 9))
            {
                musshoch = true;
            }

            if ((c == 0 && r == 8))
            {
                musshoch = true;
            }
            if ((c == 9 && r == 7))
            {
                musshoch = true;
            }
            if ((c == 0 && r == 6))
            {
                musshoch = true;
            }
            if ((c == 9 && r == 5))
            {
                musshoch = true;
            }
            if ((c == 0 && r == 4))
            {
                musshoch = true;
            }
            if ((c == 9 && r == 3))
            {
                musshoch = true;
            }
            if ((c == 0 && r == 2))
            {
                musshoch = true;
            } if ((c == 9 && r == 1))
            {
                musshoch = true;
            }
            if ((c == 0 && r == 0))
            {
                musshoch = true;
            }
            return musshoch;
        }
        private bool Gehtderzug(Ellipse figure, int nummer)
        {
            int spalte = Grid.GetColumn(figure);
            int reihe = Grid.GetRow(figure);
            if (reihe != 0)
            {
                return true;
            }
            if (spalte < 6 && nummer == 6)
            {
                return false;
            }
            if (spalte < 5 && nummer == 5)
            {
                return false;
            }
            if (spalte < 4 && nummer == 4)
            {
                return false;
            }
            if (spalte < 3 && nummer == 3)
            {
                return false;
            }
            if (spalte < 2 && nummer == 2)
            {
                return false;
            }
            return true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random num = new Random();
            int nummer = num.Next(1, 7);
            label1.Content = nummer + " Nummer";
            counter++;            
            switch (counter % 2)
            {
                case 0:
                    if (Gehtderzug(figure2, nummer))
                    {
                        move(nummer, figure2,spieler2.Name);
                        hochOderRunterRutschen(figure2,spieler2.Name);
                    }
                    break;
                default:
                    if (Gehtderzug(figure1, nummer))
                    {
                        move(nummer, figure1,spieler1.Name);
                        hochOderRunterRutschen(figure1,spieler1.Name);
                    }
                    break;
            }                    
        }
    }
    
}
