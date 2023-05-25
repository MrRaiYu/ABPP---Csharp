using Projet_ABBP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour Archives.xaml
    /// </summary>
    public partial class Archives : Window
    {
        public Archives()
        {
            InitializeComponent();

            string connectionString = config.VariablesGlobales.connectionString;

            string nomBat = "Archives";

            // Construire la requête SQL pour la description
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

            // Récupérer l'emplacement du batiment
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

            //Récupérer les personnes habilités à ce batiment
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Construire la requête SQL pour les personnes habilités
                string PSemp = "ABPP_ReadHabBatiment";
                SqlCommand command = new SqlCommand(PSemp, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NomBat", nomBat);

                // Ouvrir la connexion et exécuter la requête
                connection.Open();
                string habBat = (string)command.ExecuteScalar();
                connection.Close();

                hab.Text = habBat;
            }
        }

        private void modifier(object sender, RoutedEventArgs e)
        {
            this.Close();
            FormsModifArchives map = new FormsModifArchives();
            map.Show();
        }

        private void Back(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
