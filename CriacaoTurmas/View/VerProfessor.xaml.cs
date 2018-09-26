using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;

namespace CriacaoTurmas.View
{
    /// <summary>
    /// Interaction logic for VerProfessor.xaml
    /// </summary>
    public partial class VerProfessor : Window
    {
        public VerProfessor()
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
            cmd.CommandText = "select * from [Professor]";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Professor");
            da.Fill(dt);
            professor.ItemsSource = dt.DefaultView;
        }
    }
}
