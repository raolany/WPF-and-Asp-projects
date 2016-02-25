using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using MainWpfApplication.Model;

namespace MainWpfApplication.View.SearchPanels
{
    public partial class TrainerSearchPnl : Page
    {
        private string _where;

        public TrainerSearchPnl()
        {
            InitializeComponent();
        }

        public string WhereParams
        {
            get
            {
                _where = "";
                bool flag = false;
                if (Age != String.Empty)
                {
                    _where += " age = " + Age;
                    flag = true;
                }
                if (City != String.Empty)
                {
                    if (flag)
                        _where += " and city = '" + City+"'";
                    else
                    {
                        _where += " city = '" + City+"'";
                        flag = true;
                    }
                }
                if (Male.IsChecked.Value)
                {
                    if (flag)
                        _where += " and gender = 'Male'";
                    else
                    {
                        _where += " gender = 'Male'";
                        flag = true;
                    }
                }
                if (Female.IsChecked.Value)
                {
                    if (flag)
                        _where += " and gender = 'Female'";
                    else
                    {
                        _where += " gender = 'Female'";
                        flag = true;
                    }
                }
                return _where;
            }
        } 

        private string Age => AgeTb.Text;
        private string City => CityTb.Text;

        private void DigitPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
            {
                try
                {
                    if (((TextBox) sender).Text == "0") ((TextBox) sender).Text = "";
                    if (!(Int32.Parse(((TextBox) sender).Text) > 0 && Int32.Parse(((TextBox) sender).Text) <= 9))
                        e.Handled = true;
                }
                catch
                {
                    
                }
            }
            else e.Handled = true;
        }

        private void TextOnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //if (!Regex.IsMatch(((TextBox) sender).Text+e.Text, RegexMask.CityMask))
            //    e.Handled = true;
        }
    }
}
