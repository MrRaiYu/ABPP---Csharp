using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projet_ABPP
{
    /// <summary>
    /// Logique d'interaction pour BatPrincipale.xaml
    /// </summary>
    public partial class BatPrincipale : Window
    {
        public BatPrincipale()
        {
            InitializeComponent();

            string connectionString = config.VariablesGlobales.connectionString;

            // Récupérer du nom du batiment
            string nomBat = "Bâtiment principal";

            // Vérifier si les informations d'identification sont valides en interrogeant la base de données
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Construire la requête SQL pour la description
                string PSdesc = "ABPP_ReadDescBatiment";
                SqlCommand command = new SqlCommand(PSdesc, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NomBat", nomBat);

                // Ouvrir la connexion et exécuter la requête
                connection.Open();
                string descBat = (string)command.ExecuteScalar();
                connection.Close();

                desc.Text = descBat;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Construire la requête SQL pour la description
                string PSemp = "ABPP_ReadEmpBatiment";
                SqlCommand command = new SqlCommand(PSemp, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NomBat", nomBat);

                // Ouvrir la connexion et exécuter la requête
                connection.Open();
                string EmpBat = (string)command.ExecuteScalar();
                connection.Close();

                Emp.Text = EmpBat;
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void modifier(object sender, RoutedEventArgs e)
        {
            this.Close();
            FormsModifBatPrincipale map = new FormsModifBatPrincipale();
            map.Show();
        }

        private void Back(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}