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
                this.AluInscActual.IDCurso = Convert.ToInt32(this.cbIDCurso.Text);                
                this.AluInscActual.Condicion = this.txtCondicion.Text;                
                this.AluInscActual.Nota = Convert.ToInt32(this.mtbNota.Text);     
                }
            else if (Modo == AplicationForm.ModoForm.Modificacion)
                {
                this.AluInscActual.ID = Convert.ToInt32(this.ID.Text);                
                this.AluInscActual.IDAlumno = Convert.ToInt32(this.mtbIDAlumno.Text);                
                this.AluInscActual.IDCurso = Convert.ToInt32(this.cbIDCurso.Text);                
                this.AluInscActual.Condicion = this.txtCondicion.Text;                
                //mtbNota es de tipo maskedTextBox
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

        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        // Handle the KeyDown event to determine the type of character entered into the control.     
      
       
        private void KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
            //If shift key was pressed, it's not a number.
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }

        }

        // This event occurs after the KeyDown event and can be used to prevent
        // characters from entering the control.
        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }

        }

        private void AlumnoInscripcionesDesktop_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tp2_netDataSet.cursos' Puede moverla o quitarla según sea necesario.
            this.cursosTableAdapter.Fill(this.tp2_netDataSet.cursos);

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
        
        
        
    }
}
 
