using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WepAPI.Models;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        //On crée une variable de type IConfiguration
        private readonly IConfiguration _configuration;

        //On ajoute l'injection de dépendance
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            //On crée la requête 
            string query = @"
                select DepartmentId, DepartmentName from dbo.Department";
            
            //Création de la table pour les données
            DataTable table = new DataTable();

            //Création la variable de connection
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

            //Création la variable pour lire les données
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                //Ouverture de la connection
                myCon.Open();

                //Utilisation de SqlCommande avec la requête et la chaine de connection
                using(SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    //Exécuter la commande 'myCommand' et mettre les résulats dans l'objet myReader
                    myReader = myCommand.ExecuteReader();

                    //Mettre les données dans la table
                    table.Load(myReader);

                    //Ferméture l'objet de lecture
                    myReader.Close();

                    //Fermeture la chaine de connection
                    myCon.Close();
                }
            }
            //On retourne la table des données sous format de JSON
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Department dep)
        {
            //On crée la requête 
            string query = @"
                insert into Department values ('"+ dep.DepartmentName +"')";

            //Création de la table pour les données
            DataTable table = new DataTable();

            //Création la variable de connection
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

            //Création la variable pour lire les données
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                //Ouverture de la connection
                myCon.Open();

                //Utilisation de SqlCommande avec la requête et la chaine de connection
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    //Exécuter la commande 'myCommand' et mettre les résulats dans l'objet myReader
                    myReader = myCommand.ExecuteReader();

                    //Mettre les données dans la table
                    table.Load(myReader);

                    //Ferméture l'objet de lecture
                    myReader.Close();

                    //Fermeture la chaine de connection
                    myCon.Close();
                }
            }
            //On retourne la table des données sous format de JSON
            return new JsonResult("Added successfully ");
        }

        [HttpPut]
        public JsonResult Put(Department dep)
        {
            //On crée la requête 
            string query = @"
                update dbo.Department set 
                DepartmentName = '" + dep.DepartmentName + @"'
                where DepartmentId = "+dep.DepartmentId+@"";

            DataTable table = new DataTable();
               
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                //Ouverture de la connection
                myCon.Open();

                //Utilisation de SqlCommande avec la requête et la chaine de connection
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    //Exécuter la commande 'myCommand' et mettre les résulats dans l'objet myReader
                    myReader = myCommand.ExecuteReader();

                    //Mettre les données dans la table
                    table.Load(myReader);

                    //Ferméture l'objet de lecture
                    myReader.Close();

                    //Fermeture la chaine de connection
                    myCon.Close();
                }
            }
            //On retourne la table des données sous format de JSON
            return new JsonResult("Update Successfully !");
        }
        
        [HttpDelete("{id}")]
        public JsonResult Delate(int id) 
        {
            //On crée la requête 
            string query = @"
                delete from dbo.Department             
                where DepartmentId = " + id + "";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                //Ouverture de la connection
                myCon.Open();

                //Utilisation de SqlCommande avec la requête et la chaine de connection
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    //Exécuter la commande 'myCommand' et mettre les résulats dans l'objet myReader
                    myReader = myCommand.ExecuteReader();

                    //Mettre les données dans la table
                    table.Load(myReader);

                    //Ferméture l'objet de lecture
                    myReader.Close();

                    //Fermeture la chaine de connection
                    myCon.Close();
                }
            }
            //On retourne la table des données sous format de JSON
            return new JsonResult("Deleted Successfully !");
        }
    }
}
