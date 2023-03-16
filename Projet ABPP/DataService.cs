using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Projet_ABBP
{
    public class DataService
    {
        private string connectionString = "Server=nom_du_serveur;Database=ABPP_Csharp;User Id=nom_d'utilisateur;Password=mot_de_passe;";

        public void Connect()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Utilisez la connexion ici

                connection.Close();
            }
        }
    }
}
