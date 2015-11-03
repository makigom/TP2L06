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
    public partial class Cursos : Form
    {
       public Cursos()
            {
            InitializeComponent();
            }

        public void Listar()
            {

            CursoLogic CL = new CursoLogic();
            
            this.dgvCurso.DataSource = CL.GetAll();
            }


        private void Curso_Load(object sender, EventArgs e)
        {
            Listar();
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop CD = new CursoDesktop(AplicationForm.ModoForm.Alta);

            CD.ShowDialog();

            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCurso.SelectedRows.Count != 0)
            {

                int ID = ((Business.Entities.Curso)this.dgvCurso.SelectedRows[0].DataBoundItem).ID;

                CursoDesktop UD = new CursoDesktop(ID, AplicationForm.ModoForm.Modificacion);

                UD.ShowDialog();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvCurso.SelectedRows.Count != 0)
            {

                int ID = ((Business.Entities.Curso)this.dgvCurso.SelectedRows[0].DataBoundItem).ID;

                CursoDesktop CD = new CursoDesktop(ID, AplicationForm.ModoForm.Baja);

                CD.ShowDialog();
            }
        }

    }
}
