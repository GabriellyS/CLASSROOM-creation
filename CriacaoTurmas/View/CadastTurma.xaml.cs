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
            bindlist(lbxAlunos);
            bindcombo(cboProfessor);
        }


        private void bindlist(ListBox lbxAlunos)
        {

            List<Aluno> alunos = new List<Aluno>();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CriacaoTurmas.Properties.Settings.Configuração"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from [Aluno]";
            cmd.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Aluno");

            foreach (DataRow rowDT in ds.Tables[0].Rows)
            {
                Aluno a = new Aluno();
                a.nome = rowDT["nome"].ToString();
                a.matricula = int.Parse(rowDT["matricula"].ToString());
                a.telefone = rowDT["telefone"].ToString();
                alunos.Add(a);
            }

            lbxAlunos.ItemsSource = alunos;
        }

        private void bindcombo(ComboBox cboProf)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CriacaoTurmas.Properties.Settings.Configuração"].ConnectionString;
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
            List<Aluno> alunosaqui = new List<Aluno>();
            Turma turma = new Turma();

            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                //para cada aluno selecionado
                foreach (Aluno a in lbxAlunos.SelectedItems)
                {
                    alunosaqui.Add(a);   
                }
                
                turma.Nome_turma = txtNome.Text;
                turma.professor = ProfessorDAO.BuscarProfessorPorMatricula(busca);
                turma.alunos = alunosaqui;

                if (TurmaDAO.AdicionarTurma(turma)==true)
                {
                    MessageBox.Show("Turma Gravada com Sucesso!");
                    this.Close();
                }
                else
                {
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
