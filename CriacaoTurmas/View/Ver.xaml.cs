using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
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
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CriacaoTurmas.Properties.Settings.Setting"].ConnectionString;
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
