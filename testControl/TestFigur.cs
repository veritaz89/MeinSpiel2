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
    class TestFigur 
    {
        private Ellipse test = new Ellipse();
        private string spielername;
        public TestFigur(string farbe,bool oben, bool unten,string spielername)
        {
            this.test.Width = 20;
            this.test.Height = 20;
            switch (farbe)
            {
                case "rot":
                    this.test.Fill = Brushes.Red;
                    break;
                case "blau":
                    this.test.Fill = Brushes.Blue;
                    break;
                default:
                    break;
            }
            if (oben)
            {
                this.test.VerticalAlignment = VerticalAlignment.Top;
                this.test.Margin = new Thickness(5, 5, 0, 0);
            }
            if (unten)
            {
                this.test.VerticalAlignment = VerticalAlignment.Bottom;
                this.test.Margin = new Thickness(5, 0, 0, 20);
            }
            this.test.HorizontalAlignment = HorizontalAlignment.Left;
            this.spielername = spielername;
        }
        public string GetSpielername()
        {
            return this.spielername;
        }
        public Ellipse GetFigure()
        {
            return this.test;
        }
    }
}
