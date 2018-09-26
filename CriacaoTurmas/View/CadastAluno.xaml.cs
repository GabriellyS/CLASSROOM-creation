using CriacaoTurmas.DAL;
using CriacaoTurmas.Model;
using System.Windows;

namespace CriacaoTurmas.View
{
    /// <summary>
    /// Interaction logic for CadastAluno.xaml
    /// </summary>
    public partial class CadastAluno : Window
    {
        public CadastAluno()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Aluno aluno = new Aluno { };

            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                aluno.nome = txtNome.Text;
                aluno.telefone = txtFone.Text;
                aluno.email = txtEmail.Text;

                if (AlunoDAO.AdicionarAluno(aluno) == true)
                {
                    MessageBox.Show("Aluno Gravado com Sucesso!");
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