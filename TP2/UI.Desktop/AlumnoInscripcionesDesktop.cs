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
    public partial class AlumnoInscripcionesDesktop : AplicationForm
    {
        public AlumnoInscripcionesDesktop()
        {
            InitializeComponent();

            CursoLogic cl = new CursoLogic();
            this.cbIDCurso.DataSource = cl.GetAll();
            this.cbIDCurso.DisplayMember = "id_materia";
            this.cbIDCurso.ValueMember = "id_curso";
        }

        private AlumnoInscripciones _AluInscActual;

        public AlumnoInscripciones AluInscActual
            {
            get { return _AluInscActual; }

            set { _AluInscActual = value; }
            }

        public override void MapearDeDatos()
            {
            this.ID.Text = this.AluInscActual.ID.ToString();          
            this.mtbIDAlumno.Text = this.AluInscActual.IDAlumno.ToString();            
            this.cbIDCurso.Text = this.AluInscActual.IDCurso.ToString();            
            this.txtCondicion.Text = this.AluInscActual.Condicion;            
            this.mtbNota.Text = this.AluInscActual.Nota.ToString();      

            switch (Modo)
                {

                case ModoForm.Alta:
                        {
                        this.btnAceptar.Text = "Guardar";

                        this.AluInscActual.State = BusinessEntity.States.New;
                        }
                    break;
                case ModoForm.Modificacion:
                        {
                        this.btnAceptar.Text = "Guardar";

                        this.AluInscActual.State = BusinessEntity.States.Modified;                        
                        }
                    break;
                case ModoForm.Baja:
                        {
                        this.btnAceptar.Text = "Eliminar";

                        this.AluInscActual.State = BusinessEntity.States.Deleted;
                        } 
                    break;
                case ModoForm.Consulta:
                        {
                        this.btnAceptar.Text = "Aceptar";

                        this.AluInscActual.State = BusinessEntity.States.Unmodified;
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
                AlumnoInscripciones aluInsc = new AlumnoInscripciones();
                
                AluInscActual = aluInsc;
                                
                this.AluInscActual.IDAlumno = Convert.ToInt32(this.mtbIDAlumno.Text);                
                this.AluInscActual.IDCurso = Convert.ToInt32(this.cbIDCurso.SelectedValue);                
                this.AluInscActual.Condicion = this.txtCondicion.Text;                
                this.AluInscActual.Nota = Convert.ToInt32(this.mtbNota.Text);     
                }
            else if (Modo == AplicationForm.ModoForm.Modificacion)
                {
                this.AluInscActual.ID = Convert.ToInt32(this.ID.Text);                
                this.AluInscActual.IDAlumno = Convert.ToInt32(this.mtbIDAlumno.Text);                
                this.AluInscActual.IDCurso = Convert.ToInt32(this.cbIDCurso.SelectedValue);                
                this.AluInscActual.Condicion = this.txtCondicion.Text;                
                this.AluInscActual.Nota = Convert.ToInt32(this.mtbNota.Text);
                }
            }

        public override void GuardarCambios() 
            {
            MapearADatos();
            AlumnoInscripcionLogic AIL = new AlumnoInscripcionLogic();
            AIL.Save(AluInscActual);
            }

        public override bool Validar()
        {
            string mensaje = "";
            bool ok = true;

            foreach (Control c in this.Controls)
            {
                if ((c is TextBox || c is ComboBox) && (c.Tag.ToString() != "ID") && (!Util.Util.IsComplete(c.Text))) mensaje += " - " + c.Tag.ToString() + "\n";
            }

            if (!(mtbIDAlumno.MaskFull || mtbNota.MaskFull))
            {
                mensaje = "IDAlumno y/o Nota estan vacios.\n" + mensaje;
                ok = false;
            }

            if (!string.IsNullOrEmpty(mensaje))
            {
                mensaje = "Por favor complete los siguientes campos:\n" + mensaje;
                ok = false;
            }       

            if (!string.IsNullOrEmpty(mensaje)) Notificar(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return ok;
        }             

        public new void Notificar(string titulo,string mensaje,MessageBoxButtons botones,MessageBoxIcon icono)
            {
                MessageBox.Show(titulo, mensaje, botones, icono);
            }

        public new void Notificar( string mensaje, MessageBoxButtons botones, MessageBoxIcon icono )
            {
            this.Notificar(this.Text, mensaje, botones, icono);
            }


        public AlumnoInscripcionesDesktop(ModoForm modo):this()
            {
            this.Modo = modo;   
            }

        public AlumnoInscripcionesDesktop(int ID, ModoForm modo): this()
            {
            this.Modo = modo;
            AlumnoInscripcionLogic AIL = new AlumnoInscripcionLogic();
            AluInscActual = AIL.GetOne(ID);
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

        //Metodo que se utiliza en conjunto con la mascara mbNota para validar que el tipo de dato que se ingrese sea entero

        private void mtbNota_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            ttNota.ToolTipTitle = "Tipo de dato no valido";
            ttNota.Show("El campo admite solo digitos(0-10)",mtbNota);
        }

        private void mtbIDAlumno_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            ttIDAlumno.ToolTipTitle = "Tipo de dato invalido";
            ttIDAlumno.Show("El campo admite solo digitos",mtbIDAlumno);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Siempre se deben ingresar 5 numeros, de lo contrario tira error. Buscar como hacer que se complete con ceros
            
            int id = Convert.ToInt32(this.mtbIDAlumno.Text);
            AlumnoInscripcionLogic AIL = new AlumnoInscripcionLogic();
            AluInscActual = AIL.GetOne(id);
            
            if (AluInscActual == null)
            {
                DialogResult DR = (MessageBox.Show("El id no existe", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Error));
            }
            else 
            { 
                txtCondicion.ReadOnly = false; 
                mtbNota.ReadOnly = false; 
            }

        }
    }
}
 
