using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;

namespace CriacaoTurmas.View
{
    /// <summary>
    /// Interaction logic for Ver.xaml
    /// </summary>
    public partial class Ver : Window
    {
        public Ver()
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
            cmd.CommandText = "select * from [Aluno]";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Aluno");
            da.Fill(dt);
            ga.ItemsSource = dt.DefaultView;
        }
    }
}
