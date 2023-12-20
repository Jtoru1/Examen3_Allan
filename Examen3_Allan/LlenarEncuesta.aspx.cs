using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen3_Allan
{
    public partial class LlenarEncuesta : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPartidosPoliticosDesdeBD();
            }
        }
        protected void Mostrar_Encuesta_Click(object sender, EventArgs e)
        {
            pnlEncuesta.Visible = true;
        }
        private void CargarPartidosPoliticosDesdeBD()
        {
            string s = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(s))
            {
                string query = "SELECT NombrePartido FROM PartidosPoliticos";
                SqlCommand command = new SqlCommand(query, conexion);

                try
                {
                    conexion.Open();

                   
                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                     
                        ddlPartidosPoliticos.DataSource = reader;
                        ddlPartidosPoliticos.DataTextField = "NombrePartido";
                        ddlPartidosPoliticos.DataBind();
                    }

            
                    ddlPartidosPoliticos.Items.Insert(0, new ListItem("-- Seleccionar Partido --", ""));
                }
                catch (Exception ex)
                {
                  
                    Response.Write("Error al cargar partidos políticos: " + ex.Message);
                }
            }
        }

        protected void btnValidarFecha_Click(object sender, EventArgs e)
        {
            DateTime fechaNacimiento = calFechaNacimiento.SelectedDate;

            if (fechaNacimiento != DateTime.MinValue)
            {
                int edad = CalcularEdad(fechaNacimiento);

                if (edad >= 18 && edad <= 50)
                {
              
                    Response.Write("Fecha válida. Edad: " + edad + " años.");
                }
                else
                {
                
                    Response.Write("La fecha seleccionada no cumple con los requisitos de edad.");
                }
            }
            else
            {
                
                Response.Write("Por favor, seleccione una fecha válida.");
            }
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - fechaNacimiento.Year;

            if (today.Month < fechaNacimiento.Month || (today.Month == fechaNacimiento.Month && today.Day < fechaNacimiento.Day))
            {
                age--;
            }

            return age;
        }

        private void CargarPartidosPoliticos()
        {
          
            ddlPartidosPoliticos.Items.Add(new ListItem("PLN", "1"));
            ddlPartidosPoliticos.Items.Add(new ListItem("PUSC", "2"));
            ddlPartidosPoliticos.Items.Add(new ListItem("PAC", "3"));
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            pnlEncuesta.Visible = !pnlEncuesta.Visible;
            lblMensaje.Text = "Datos guardados correctamente";

        }
    }
}