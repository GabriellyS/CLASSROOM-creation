using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;

namespace CriacaoTurmas.View
{
    /// <summary>
    /// Interaction logic for VerTurmas.xaml
    /// </summary>
    public partial class VerTurmas : Window
    {
        public VerTurmas()
        {
            InitializeComponent();
            binddatagrid();
        }

        private void binddatagrid()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CriacaoTurmas.Properties.Settings.Configuração"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Nome_turma,matriculaProfessor,Aluno_matricula from [Turma],[TurmaAlunoes]";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Turma");
            da.Fill(dt);
            turma.ItemsSource = dt.DefaultView;
        }
    }
}
