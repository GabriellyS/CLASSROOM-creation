using System.Windows;

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
            VerProfessor form = new VerProfessor();
            form.ShowDialog();
        }

        private void MenuItem_Click5(object sender, RoutedEventArgs e)
        {
            ExcluirProfessor form = new ExcluirProfessor();
            form.ShowDialog();
        }
    }
}
