using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class CursoDesktop : AplicationForm
    {
        
        public CursoDesktop()
            {
            InitializeComponent();
            }

        private Business.Entities.Curso _CursoActual;

        public Business.Entities.Curso CursoActual
        
            {
            get { return _CursoActual; }

            set { _CursoActual = value; }
            }

        public override void MapearDeDatos()
            {
            this.txtID.Text = this.CursoActual.ID.ToString();     
            this.cbComision.Text = this.CursoActual.IDComision.ToString();           
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();    
            this.cbIDMateria.Text = this.CursoActual.IDMateria.ToString();           
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();

            switch (Modo)
                {

                case ModoForm.Alta:
                        {
                        this.btnAceptar.Text = "Guardar";

                        this.CursoActual.State = BusinessEntity.States.New;
                        }
                    break;
                case ModoForm.Modificacion:
                        {
                        this.btnAceptar.Text = "Guardar";

                        this.CursoActual.State = BusinessEntity.States.Modified;                        
                        }
                    break;
                case ModoForm.Baja:
                        {
                        this.btnAceptar.Text = "Eliminar";

                        this.CursoActual.State = BusinessEntity.States.Deleted;
                        } 
                    break;
                case ModoForm.Consulta:
                        {
                        this.btnAceptar.Text = "Aceptar";

                        this.CursoActual.State = BusinessEntity.States.Unmodified;
                        }
                    break;
                default:
                    break;
                }
            }

        public override void MapearADatos()
            {
            
            if (Modo == AplicationForm.ModoForm.Alta)
                {
                Business.Entities.Curso cur = new Business.Entities.Curso();             
                CursoActual = cur;
                 
                this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);              
                this.CursoActual.AnioCalendario=int.Parse(txtAnioCalendario.Text);
                this.CursoActual.IDComision=int.Parse(cbComision.Text);                     
                this.CursoActual.IDMateria=int.Parse(cbIDMateria.Text);

                }
            else if (Modo == AplicationForm.ModoForm.Modificacion)
                {
                this.CursoActual.ID = Convert.ToInt32(this.txtID.Text);             
                this.CursoActual.AnioCalendario=Convert.ToInt32(this.txtAnioCalendario);                
                this.CursoActual.Cupo=Convert.ToInt32(this.txtCupo);
                this.CursoActual.IDComision = Convert.ToInt32(this.cbComision);
                this.CursoActual.IDMateria = Convert.ToInt32(this.cbIDMateria);
                
                }
            }

        public override void GuardarCambios() 
            {

            MapearADatos();

            CursoLogic CL = new CursoLogic();

            CL.Save(CursoActual);

            }

      public override bool Validar()
            {
                string mensaje = "";
                bool ok = true;

                foreach (Control c in this.Controls)
                {
                    if ((c is TextBox) && (c.Tag.ToString() != "ID") && (!Util.Util.IsComplete(c.Text))) mensaje += " - " + c.Tag.ToString() + "\n";
                }

                if (!string.IsNullOrEmpty(mensaje))
                {
                    mensaje = "Por favor complete los siguientes campos:\n" + mensaje;
                    ok = false;
                }

                if (!string.IsNullOrEmpty(mensaje)) Notificar(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ok;
      }
        
        public new  void Notificar(string titulo,string mensaje,MessageBoxButtons botones,MessageBoxIcon icono)
            {
            MessageBox.Show(titulo,mensaje, botones, icono);
            }

        public new void Notificar( string mensaje, MessageBoxButtons botones, MessageBoxIcon icono )
            {
            this.Notificar(this.Text, mensaje, botones, icono);
            }


        public CursoDesktop(ModoForm modo):this()
            {
            this.Modo = modo;   
            }

        public CursoDesktop(int ID, ModoForm modo):this()
            {
            this.Modo = modo;

            CursoLogic CL = new CursoLogic();

            CursoActual = CL.GetOne(ID);

            MapearDeDatos();
            }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {
                GuardarCambios();

                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult DR = (MessageBox.Show("Seguro que desea cancelar el proceso?", "Cancelar", MessageBoxButtons.YesNo));

            if (DR == DialogResult.Yes) this.Close();
        }

        private void CursoDesktop_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tp2_netDataSet.materias' Puede moverla o quitarla según sea necesario.
            this.materiasTableAdapter.Fill(this.tp2_netDataSet.materias);
            // TODO: esta línea de código carga datos en la tabla 'tp2_netDataSet.comisiones' Puede moverla o quitarla según sea necesario.
            this.comisionesTableAdapter.Fill(this.tp2_netDataSet.comisiones);

        }
    }
}
