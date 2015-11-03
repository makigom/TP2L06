using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        public List<Especialidad> GetAll()
        {

            List<Especialidad> especialidades = new List<Especialidad>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades", sqlConn);


                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                while (drEspecialidades.Read())
                {

                    Especialidad e = new Especialidad();

               
                    e.ID = (int)drEspecialidades["id_especialidad"];
                    e.Descripcion = (string)drEspecialidades["descripcion"];


                    especialidades.Add(e);
                }

                drEspecialidades.Close();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades", Ex);

                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return especialidades;

        }


        public Especialidad GetOne(int ID)
        {

            Especialidad e = new Especialidad();

            try
            {
                this.OpenConnection();

                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * from especialidades where id_especialidad=@id", sqlConn);

                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                if (drEspecialidades.Read())
                {
                    e.ID = (int)drEspecialidades["id_especialidades"];
                    e.Descripcion=(string)drEspecialidades["descripcion"];
                }

                drEspecialidades.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de especialidades", Ex);

                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return e;
        }


        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete especialidades where id_especialidad=@id", sqlConn);

                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejeada = new Exception("Error al eliminar la especialidad", Ex);

                throw ExcepcionManejeada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE especialidades SET id_especialidad=@id_especialidad, descripcion=@descripcion" +
                    "WHERE id_especialidad=@id", sqlConn);

                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = especialidad.ID;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.VarChar,50).Value = especialidad.Descripcion;

                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejeada = new Exception("Error al modificar especialidad", Ex);

                throw ExcepcionManejeada;
            }

            finally
            {
                this.CloseConnection();
            }
        }


        protected void Insert(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "insert into especialidad (id_especialidad, descripcion)" +
                    "values (@id_especialidad, @descripcion)" +
                    "select @@identity", sqlConn);

                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar,50).Value = especialidad.Descripcion;
                especialidad.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejeada = new Exception("Error al crear especialidad", Ex);

                throw ExcepcionManejeada;
            }

            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == BusinessEntity.States.New)
            {
                this.Insert(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                this.Update(especialidad);
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }
    }
}
