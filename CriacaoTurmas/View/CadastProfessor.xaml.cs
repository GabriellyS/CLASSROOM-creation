using CriacaoTurmas.DAL;
using CriacaoTurmas.Model;
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
    /// Interaction logic for CadastProfessor.xaml
    /// </summary>
    public partial class CadastProfessor : Window
    {
        public CadastProfessor()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                Professor professor = new Professor
                {
                    nome = txtNome.Text,

                };
                if (ProfessorDAO.AdicionarProfessor(professor))
                {
                    MessageBox.Show("Professor Gravado com Sucesso!");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar aluno!");
                }
            }
            else
            {
                MessageBox.Show("Favor preencher todos os campos!!");
            }


        }
    }
}
