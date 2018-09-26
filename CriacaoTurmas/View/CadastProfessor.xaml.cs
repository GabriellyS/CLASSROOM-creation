using CriacaoTurmas.DAL;
using CriacaoTurmas.Model;
using System.Windows;

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
            Professor professor = new Professor { };

            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                professor.nome = txtNome.Text;
                professor.disciplina = txtDisciplina.Text;


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
