using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Projet_ABPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string connectionString = "Server=localhost,1434;Database=ABPP_Csharp;User ID=sa; Password=Info76240#";
        private void Send(object sender, RoutedEventArgs e)
        {
            // Récupérer les informations d'identification entrées par l'utilisateur
            string username = Login.Text;
            string password = Motdepasse.Password;


            // Vérifier si les champs d'identification sont vides
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez entrer votre nom d'utilisateur et votre mot de passe.");
                return;
            }

            // Vérifier si les informations d'identification sont valides en interrogeant la base de données
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Construire la requête SQL
                string PS = "ABPP_LoginConnexion";
                SqlCommand command = new SqlCommand(PS, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Identifiant", username);
                command.Parameters.AddWithValue("@Motdepasse", password);

                // Ouvrir la connexion et exécuter la requête
                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                // Vérifier le résultat de la requête
                if (count > 0)
                {
                    // Si les informations d'identification sont valides, naviguer vers la page suivante
                    Carte map = new Carte(username);
                    map.Show();
                    this.Close();
                }
                else
                {
                    // Si les informations d'identification sont invalides, afficher un message d'erreur
                    MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
                }
            }
        }

        private void Motdepasse0_TextChanged(object sender, TextChangedEventArgs e)
        {

        }  
        }
    }
