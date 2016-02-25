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
    public partial class GroupSearchPanel : Page
    {
        private string _where;

        public GroupSearchPanel()
        {
            InitializeComponent();
        }

        public string WhereParams
        {
            get
            {
                _where = "";
                bool flag = false;
                if (ClientMaxTb.Text != String.Empty)
                {
                    _where += " clientmax = " + ClientMaxTb.Text;
                    flag = true;
                }
                if (NotEmptyCb.IsChecked.Value)
                {
                    if (flag)
                        _where += " and clientsnow > 0";
                    else
                    {
                        _where += " clientsnow > 0";
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
    }
}
