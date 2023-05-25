using System;
using System.Collections.Generic;
using System.Data;
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

namespace Projet_ABPP_bis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();

            string connectionString = config.VariablesGlobales.connectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                using (SqlCommand cmd = new SqlCommand("ABPP_Affichage_Personne", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nomPersonne = reader.GetString(0);
                            string prenomPersonne = reader.GetString(1);

                            ComboBoxItem item = new ComboBoxItem();
                            item.Content = nomPersonne + " " + prenomPersonne;

                            Per.Items.Add(item);
                        }
                    }
                }

                using (SqlCommand cmd = new SqlCommand("ABPP_Affichage_Batiment", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nomBatiment = reader.GetString(0);

                            ComboBoxItem item = new ComboBoxItem();
                            item.Content = nomBatiment;

                            Bat.Items.Add(item);
                        }
                    }
                }

                connection.Close();
            }
        }

        private void Test(object sender, RoutedEventArgs e)
        {

            string connectionString = config.VariablesGlobales.connectionString;

            // Récupérer les informations d'identification entrées par l'utilisateur
            string batiment = Bat.Text;
            string personnel = Per.Text;
            
            // Vérifier si les champs sont vides
            if (string.IsNullOrEmpty(batiment) || string.IsNullOrEmpty(personnel))
            {
                MessageBox.Show("Veuillez Choisir.");
                return;
            }

            string[] words = personnel.Split(' '); //Séparer le nom/prénom d'une saule chaine de caractère
            string nom = words[0];
            string prenom = words[1];

            // Vérifier si les informations d'identification sont valides en interrogeant la base de données
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Construire la requête SQL
                string PS = "ABPP_VerifBadge";
                SqlCommand command = new SqlCommand(PS, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Batiment", batiment);
                command.Parameters.AddWithValue("@Prenom", prenom);
                command.Parameters.AddWithValue("@Nom", nom);

                // Ouvrir la connexion et exécuter la requête
                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                // Vérifier le résultat de la requête
                if (count > 0)
                {
                    // Si les informations d'identification sont valides, naviguer vers la page suivante
                    Result.Foreground = Brushes.Green;
                    Result.Content = "Badge Valide";
                }
                else
                {
                    // Si les informations d'identification sont invalides, afficher un message d'erreur
                    Result.Foreground = Brushes.Red;
                    Result.Content = "Badge Invalide";
                }
            }
        }
    }
}
