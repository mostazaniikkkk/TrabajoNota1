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
using System.Windows.Shapes;

namespace Nota2
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            win1 = this;
        }

        internal static Window1 win1;
        internal string Status
        {
            get { return lblUser.Content.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { lblUser.Content = value; })); }
        }
        internal string Status1
        {
            get { return lblRut.Content.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { lblRut.Content = value; })); }
        }
    }
}
