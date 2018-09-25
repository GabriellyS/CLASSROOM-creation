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

namespace CriacaoTurmas.View
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CadastAluno form = new CadastAluno();
            form.ShowDialog();
        }

        private void MenuItem_Click1(object sender, RoutedEventArgs e)
        {
            CadastProfessor form = new CadastProfessor();
            form.ShowDialog();
        }

        private void MenuItem_Click2(object sender, RoutedEventArgs e)
        {
            CadastTurma form = new CadastTurma();
            form.ShowDialog();
        }
        
        private void MenuItem_Click3(object sender, RoutedEventArgs e)
        {
            Ver form = new Ver();
            form.ShowDialog();
        }
        private void MenuItem_Click4(object sender, RoutedEventArgs e)
        {
            VerTurmas form = new VerTurmas();
            form.ShowDialog();
        }

        private void MenuItem_Click5(object sender, RoutedEventArgs e)
        {
            VerProfessor form = new VerProfessor();
            form.ShowDialog();
        }
    }
}
