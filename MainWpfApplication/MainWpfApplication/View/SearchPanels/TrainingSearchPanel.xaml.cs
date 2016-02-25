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

namespace MainWpfApplication.View.SearchPanels
{
    public partial class TrainingSearchPanel : Page
    {
        private string _where;

        public TrainingSearchPanel()
        {
            InitializeComponent();
        }

        public string WhereParams
        {
            get
            {
                _where = "";
                bool flag = false;
                if (TimeTb.Text != String.Empty)
                {
                    _where += " hours = " + TimeTb.Text;
                    flag = true;
                }
                if (PriceTb.Text != String.Empty)
                {
                    if (flag)
                        _where += " and price = " + PriceTb.Text;
                    else
                    {
                        _where += " price = " + PriceTb.Text;
                        flag = true;
                    }
                }
                if (MinageTb.Text != String.Empty)
                {
                    if (flag)
                        _where += " and minage = " + MinageTb.Text;
                    else
                    {
                        _where += " minage = " + MinageTb.Text;
                        flag = true;
                    }
                }

                return _where;
            }
        }

        private void DigitPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == " ")
            {
                e.Handled = true;
                return;
            }
            if (Char.IsDigit(e.Text, 0))
            {
                try
                {
                    if (((TextBox)sender).Text == "0") ((TextBox)sender).Text = "";
                    if (!(Int32.Parse(((TextBox)sender).Text) > 0 && Int32.Parse(((TextBox)sender).Text) <= 99))
                        e.Handled = true;
                }
                catch
                {

                }
            }
            else e.Handled = true;
        }

        private void PriceDigitPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
            {
                try
                {
                    if (((TextBox)sender).Text == "0") ((TextBox)sender).Text = "";
                    if (!(Int32.Parse(((TextBox)sender).Text) > 0 && Int32.Parse(((TextBox)sender).Text) <= 99))
                        e.Handled = true;
                }
                catch
                {

                }
            }
            else if (e.Text == ".")
            {
                if (((TextBox)sender).Text.Contains("."))
                    e.Handled = true;
            }
            else e.Handled = true;
        }
    }
}
