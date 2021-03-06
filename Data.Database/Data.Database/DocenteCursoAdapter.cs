﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
   public class DocenteCursoAdapter : Adapter
    {

        public List<DocenteCurso> GetAll()
        {
            //instanciamos el objeto lista a retornar

            List<DocenteCurso> docentecurso = new List<DocenteCurso>();

            try
            {
                this.OpenConnection();

                /*creo el obje sqlcommand que sera la sentencia SQl que vamos a ejecutar
                  contra la BD. (los datos de la bd: usario, contraseña, etc estan en connection
                  string.*/

                SqlCommand cmdDocenteCurso = new SqlCommand("select * from docentes_cursos", sqlConn);

                //instancio un obj datareader que va a ser el que recupere los datos de la BD

                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();

                /*read() lee una fila de las devueltas por el comando sql, carga los datos
                  en drUsurios para pdoer accederlos, devuelve erdadero meintras haya podido
                  leer datos y avanza a la fila siguiente para el proximo read.*/

                while (drDocenteCurso.Read())
                {
                    /*creo un obj usuario de la capa de entidades para copiar los datos 
                      de la fila del datareader al objeto de entidades.*/

                    DocenteCurso dc = new DocenteCurso();

                    //copio los datos de la fila al obj

                    dc.IDCurso = (int)drDocenteCurso["id_curso"];
                    dc.IDDocente = (int)drDocenteCurso["id_docente"];
                    dc.TipoCargo = (int)drDocenteCurso["cargo"];
                    dc.ID = (int)drDocenteCurso["id_dictado"];

                    //agrego el objeto con datos a la lista que devuelvo

                    docentecurso.Add(dc);
                }

                //cerramos el datareader y la conexion a la BD

                drDocenteCurso.Close();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos y docentes", Ex);

                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return docentecurso;

        }


        public DocenteCurso GetOne(int ID)
        {

            DocenteCurso dc = new DocenteCurso();

            try
            {
                this.OpenConnection();

                SqlCommand cmdDocenteCurso = new SqlCommand("SELECT * from docentes_cursos where id_dictado=@id", sqlConn);

                cmdDocenteCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();

                if (drDocenteCurso.Read())
                {
                    dc.IDCurso = (int)drDocenteCurso["id_curso"];
                    dc.IDDocente = (int)drDocenteCurso["id_docente"];
                    dc.TipoCargo = (int)drDocenteCurso["cargo"];
                    dc.ID = (int)drDocenteCurso["id_dictado"];
                }

                drDocenteCurso.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de los cursos y docentes", Ex);

                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return dc;
        }


        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete docentes_cursos where id_dictado=@id", sqlConn);

                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejeada = new Exception("Error al eliminar curso y docente", Ex);

                throw ExcepcionManejeada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Update(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE docentes_cursos SET id_docente=@id_docente, id_curso=@id_curso, cargo=@cargo" +
                    "WHERE id_dictado=@id", sqlConn);

                cmdSave.Parameters.Add("@id_dictado", SqlDbType.Int).Value = docenteCurso.ID;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCurso.IDDocente;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCurso.IDCurso;
                cmdSave.Parameters.Add("@cargo", SqlDbType.VarChar, 50).Value = docenteCurso.TipoCargo;
                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejeada = new Exception("Error al modificar docentes y cursos", Ex);

                throw ExcepcionManejeada;
            }

            finally
            {
                this.CloseConnection();
            }
        }


        protected void Insert(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "insert into docentes_cursos (id_docente, id_curso, cargo)" +
                    "values (@id_docente,@id_curso,@cargo)" +
                    "select @@identity", sqlConn);

                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCurso.IDDocente;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCurso.IDCurso;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docenteCurso.TipoCargo;
                docenteCurso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejeada = new Exception("Error al crear curso y docente", Ex);

                throw ExcepcionManejeada;
            }

            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(DocenteCurso docenteCurso)
        {
            if (docenteCurso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(docenteCurso.ID);
            }
            else if (docenteCurso.State == BusinessEntity.States.New)
            {
                this.Insert(docenteCurso);
            }
            else if (docenteCurso.State == BusinessEntity.States.Modified)
            {
                this.Update(docenteCurso);
            }
            docenteCurso.State = BusinessEntity.States.Unmodified;
        }
    }
}
