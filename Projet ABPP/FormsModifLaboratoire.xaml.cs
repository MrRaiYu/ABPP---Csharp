using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Projet_ABPP
{
    /// <summary>
    /// Logique d'interaction pour FormsModifLaboratoire.xaml
    /// </summary>
    public partial class FormsModifLaboratoire : Window
    {
        public FormsModifLaboratoire()
        {
            InitializeComponent();
        }

        private string connectionString = config.VariablesGlobales.connectionString;
        private void Send(object sender, MouseButtonEventArgs e)
        {

            string emplacement = Emplacement.Text;
            string description = Description.Text;
            string batiment = "Laboratoire";
            if (string.IsNullOrEmpty(emplacement) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Veuillez remplir les deux champs");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Construire la requête SQL
                string PS = "ABPP_ModifierDesc";
                SqlCommand command = new SqlCommand(PS, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NomBat", batiment);
                command.Parameters.AddWithValue("@DescBat", description);
                command.Parameters.AddWithValue("@EmplacementBat", emplacement);

                connection.Open();
                command.ExecuteScalar();
                connection.Close();
            }
            this.Close();
            Laboratoire map = new Laboratoire();
            map.Show();
        }

        private void Back(object sender, MouseButtonEventArgs e)
        {
            Laboratoire map = new Laboratoire();
            map.Show();
            this.Close();
        }
    }
}
