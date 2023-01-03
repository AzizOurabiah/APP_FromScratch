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
    public class EmployeeController : Controller
    {
        //On crée une variable de type IConfiguration
        private readonly IConfiguration _configuration;

        //On ajoute l'injection de dépendance
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            //On crée la requête 
            string query = @"
                select EmployeeId, EmployeeName, Department, convert(varchar(10), DateOfJoining,120) as DateOfJoining, PhotoFileName from dbo.Employee";

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
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Employee emp)
        {
            //On crée la requête 
            string query = @"
                insert into Employee values ('" + emp.EmployeeName + "','"+emp.Department+ "','" +emp.DateOfJoining + "','"+emp.PhotoFileName+ "')";

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
        public JsonResult Put(Employee emp)
        {
            //On crée la requête 
            string query = @"
                update dbo.Employee set 
                EmployeeName = '"+ emp.EmployeeName + 
                "', Department = '"+ emp.Department + 
                "', DateOfJoining = '" + emp.DateOfJoining + 
                "', PhotoFileName =  '" + emp.PhotoFileName +
                "' where EmployeeId = " + emp.EmployeeId;  

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
                delete from dbo.Employee             
                where EmployeeId = " + id + "";

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
