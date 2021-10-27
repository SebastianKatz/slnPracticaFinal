using LibreriaClub.Admin;
using LibreriaClub.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClub
{
    public partial class WebClub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                mostrarJugadores();
                llenarDropdownList();
            }
        }

        private void mostrarJugadores()
        {
            gridJugador.DataSource = AdminJugador.Listar();
            gridJugador.DataBind();
        }

        private void llenarDropdownList()
        {
            DataTable dt = AdminJugador.ListarPuestos();
            ddlPuesto.DataSource = dt;
            ddlPuesto.DataTextField = dt.Columns["Puesto"].ToString();

            ddlPuesto.DataBind();


            ddlFiltro.DataSource = dt;
            ddlFiltro.DataTextField = dt.Columns["Puesto"].ToString();
            DataRow fila = dt.NewRow();
            fila["Puesto"] = "[Todos]";
            dt.Rows.InsertAt(fila, 0);

            ddlFiltro.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarJugador();
        }

        private void guardarJugador()
        {
            Jugador jugador = new Jugador(txtNombre.Text, txtApellido.Text, DateTime.Parse(txtFechaNacimiento.Text), ddlPuesto.SelectedValue);


            int filasAfectadas = AdminJugador.Insertar(jugador);

            if (filasAfectadas > 0)
            {
                mostrarJugadores();
                EliminarCampos();
            }
        }

        private void EliminarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
        }

        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string puesto = ddlFiltro.SelectedValue;

            if (puesto == "[Todos]")
            {
                mostrarJugadores();
            }
            else
            {
                gridJugador.DataSource = AdminJugador.Listar(puesto);
                gridJugador.DataBind();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {
            int jugadorEliminar = int.Parse(txtId.Text);

            int filasAfectadas = AdminJugador.Eliminar(jugadorEliminar);

            if (filasAfectadas > 0)
            {
                mostrarJugadores();
                EliminarCampos();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Jugador jugador = new Jugador()
            {
                Id = Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                Puesto = ddlPuesto.SelectedValue
            };

            int filasAfectadas = AdminJugador.Modificar(jugador);

            if (filasAfectadas > 0)
            {
                mostrarJugadores();
            }

        }
    }
}