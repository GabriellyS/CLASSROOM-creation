using CriacaoTurmas.DAL;
using CriacaoTurmas.Model;
using System;
using System.Windows;

namespace CriacaoTurmas.View
{
    /// <summary>
    /// Interaction logic for ExcluirProfessor.xaml
    /// </summary>
    public partial class ExcluirProfessor : Window
    {
        public ExcluirProfessor()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Professor professor = new Professor();

            professor.matricula = Convert.ToInt32(txtPesquisar.Text);

            var professorE = ProfessorDAO.BuscarProfessorPorMatricula(professor);

            if (professorE != null)
            {

                txtDisci.Text = professorE.disciplina;
                txtNome.Text = professorE.nome;
            }
            else
            {
                MessageBox.Show("Professor não encontrado!!");
            }

        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

            Professor professor = new Professor();

            professor.nome = txtNome.Text;
            professor.disciplina = txtDisci.Text;

            if (ProfessorDAO.AlterarProfessor(professor))
            {
                MessageBox.Show("Professor alterado com sucesso!!");
            }
            else
            {
                MessageBox.Show("Erro ao alterar Professor!!");
            }



        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {

            Professor professore = new Professor();

            professore.matricula = Convert.ToInt32(txtPesquisar.Text);
            var professor = ProfessorDAO.BuscarProfessorPorMatricula(professore);

            if (ProfessorDAO.DeletarProfessor(professor))
            {
                MessageBox.Show("Professor deletado com sucesso!!");
            }
            else
            {
                MessageBox.Show("Erro ao deletar professor!!");
            }
        }
    }
}
