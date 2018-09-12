using CriacaoTurmas.DAL;
using CriacaoTurmas.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace CriacaoTurmas.View
{
    /// <summary>
    /// Interaction logic for CadastTurma.xaml
    /// </summary>
    public partial class CadastTurma : Window
    {
        public CadastTurma()
        {
            InitializeComponent();

            List<Aluno> alunos = new List<Aluno>();

            // Criando uma lista ficticia para simular dados salvos no banco

            for (int i = 0; i < 3; i++)
            {
                Aluno a = new Aluno();

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CriacaoTurmas.Properties.Settings.Setting"].ConnectionString;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from [Aluno]";
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Aluno");
                da.Fill(dt);
                lbxAlunos.ItemsSource = dt.DefaultView;

                alunos.Add(a);
            }

            lbxAlunos.ItemsSource = alunos;
            bindcombo(cboProfessor);
        }

        private void bindlist()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CriacaoTurmas.Properties.Settings.Setting"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from [Aluno]";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Aluno");
            da.Fill(dt);
        }
        private void bindcombo(ComboBox cboProf)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CriacaoTurmas.Properties.Settings.Setting"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select nome,matricula FROM [Professor]";
            cmd.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Professor");
            cboProf.ItemsSource = ds.Tables[0].DefaultView;
            cboProf.DisplayMemberPath = ds.Tables[0].Columns["nome"].ToString();
            cboProf.SelectedValuePath = ds.Tables[0].Columns["matricula"].ToString();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Professor busca = new Professor();
            busca.matricula = Convert.ToInt32(cboProfessor.SelectedValue);

            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                Turma turma = new Turma();

                turma.Materia = txtNome.Text;
                turma.professor = ProfessorDAO.BuscarProfessorPorMatricula(busca);
                turma.aluno = null;


                if (TurmaDAO.AdicionarTurma(turma))
                {

                    MessageBox.Show("Turma Gravada com Sucesso!");
                    this.Close();

                }
                else
                {
                    MessageBox.Show(Convert.ToString(cboProfessor.SelectedValue));
                    MessageBox.Show("Erro ao cadastrar turma!");
                }
            }
            else
            {
                MessageBox.Show("Favor preencher todos os campos!!");
            }
        }
    }
}
