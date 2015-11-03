using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Personas : AplicationForm
    {
        public Personas()
        {
            InitializeComponent();
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            PersonasLogic PL = new PersonasLogic();
            this.dgvPersona.AutoGenerateColumns = true;
            List<Persona> l = PL.GetAll();
            this.dgvPersona.DataSource = l;
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop PD = new PersonaDesktop(AplicationForm.ModoForm.Alta);
            PD.Text = "Alta persona";
            PD.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersona.SelectedRows.Count != 0)
            {

                int ID = ((Persona)this.dgvPersona.SelectedRows[0].DataBoundItem).ID;
                PersonaDesktop PD = new PersonaDesktop(ID, AplicationForm.ModoForm.Modificacion);
                PD.Text = "Editar persona";
                PD.ShowDialog();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersona.SelectedRows.Count != 0)
            {
                int ID = ((Persona)this.dgvPersona.SelectedRows[0].DataBoundItem).ID;
                PersonaDesktop PD = new PersonaDesktop(ID, AplicationForm.ModoForm.Baja);
                PD.Text = "Eliminar persona";
                PD.ShowDialog();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            DialogResult DR = (MessageBox.Show("Seguro que dese salir?", "Salir", MessageBoxButtons.YesNo));

            if (DR == DialogResult.Yes) this.Close();
        }
    }
}
   