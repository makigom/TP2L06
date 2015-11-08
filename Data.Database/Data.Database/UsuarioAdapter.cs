using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        
        public List<Usuario> GetAll()
        {
            //instanciamos el objeto lista a retornar

            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                this.OpenConnection();

                /*creo el obje sqlcommand que sera la sentencia SQl que vamos a ejecutar
                  contra la BD. (los datos de la bd: usario, contraseña, etc estan en connection
                  string.*/
                
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlConn);

                //instancio un obj datareader que va a ser el que recupere los datos de la BD
                
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                /*read() lee una fila de las devueltas por el comando sql, carga los datos
                  en drUsurios para pdoer accederlos, devuelve verdadero meintras haya podido
                  leer datos y avanza a la fila siguiente para el proximo read.*/
                
                while (drUsuarios.Read())
                {
                    /*creo un obj usuario de la capa de entidades para copiar los datos 
                      de la fila del datareader al objeto de entidades.*/
                   
                    Usuario usr = new Usuario();

                    //copio los datos de la fila al obj
                    
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.CambiaClave = (bool)drUsuarios["cambia_clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];

                    //agrego el objeto con datos a la lista que devuelvo                   
                    usuarios.Add(usr);
                }

                //cerramos el datareader y la conexion a la BD

                drUsuarios.Close();

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }


        public Usuario GetOne(int ID)
        {

            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * from usuarios where id_usuario=@id_usuario", sqlConn);
                cmdUsuarios.Parameters.Add("@id_usuario", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.CambiaClave = (bool)drUsuarios["cambia_clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                }

                drUsuarios.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del usuario", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return usr;
        }


        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                
                SqlCommand cmdDelete = new SqlCommand("DELETE usuarios where id_usuario=@id_usuario", sqlConn);               
                cmdDelete.Parameters.Add("@id_usuario", SqlDbType.Int).Value = ID;               
                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejeada = new Exception("Error al eliminar usuario", Ex);               
                throw ExcepcionManejeada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
        
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave,"
                    + " cambia_clave=@cambia_clave,habilitado=@habilitado, ip_persona=@id_persona WHERE id_usuario=@id_usuario", sqlConn);              
                
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@cambia_clave", SqlDbType.Bit).Value = usuario.CambiaClave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejeada = new Exception("Error al modificar usuario", Ex);              
                throw ExcepcionManejeada;
            }

            finally
            {
                this.CloseConnection();
            }
        }


        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
        
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT into usuarios (nombre_usuario, clave, cambia_clave, habilitado, id_persona)" +
                    "VALUES (@nombre_usuario, @clave,@cambia_clave,@habilitado,@id_persona)" +
                    "SELECT @@identity", sqlConn);

                cmdSave.Parameters.Add("@id_Persona", SqlDbType.Int).Value = usuario.IDPersona;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@cambia_clave", SqlDbType.Bit).Value = usuario.CambiaClave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejeada = new Exception("Error al crear usuario", Ex);              
                throw ExcepcionManejeada;
            }

            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }    
            usuario.State = BusinessEntity.States.Unmodified;
        }
    }
}

