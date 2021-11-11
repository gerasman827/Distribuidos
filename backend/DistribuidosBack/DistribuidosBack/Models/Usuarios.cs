using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Dynamic;

using System.Linq;
using System.Threading.Tasks;

namespace DistribuidosBack.Models
{
    public class Usuarios
    {

        NpgsqlCommand cmd;

        String cedula { set; get; }
        String nombre { set; get; }
        int edad { set; get; }
        public object JsonConvert { get; private set; }

        public Usuarios(String cedula, String nombre, int edad)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.edad = edad;
        }

        public string ingresarU(Conexion cone)
        {
            try
            {

                String sql = "INSERT  INTO usuarios VALUES('" + this.cedula + "','" + this.nombre + "'," + this.edad + ")";
                new NpgsqlCommand(sql, cone.getCone()).ExecuteNonQuery();
                return "datos guardados";
            }
            catch
            {
                return "error";
            }
        }


        public String listar(Conexion cone)
        {

            String Mensaje = "";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();

                String sql = "select * from usuarios ";
                if(this.cedula!= "")
                {
                    sql = "select * from usuarios where cedula ='" + this.cedula+"'";
                }
                var reader = new NpgsqlCommand(sql, cone.getCone()).ExecuteReader();
                var todoslosusers = new List<dynamic>();

                while (reader.Read())
                {
                    dynamic usuarios = new ExpandoObject();

                    usuarios.cedula = reader.GetString(0);
                    usuarios.nombre = reader.GetString(1);
                    usuarios.edad = reader.GetString(2);

                    todoslosusers.Add(usuarios);

                }
                string Json = Newtonsoft.Json.JsonConvert.SerializeObject(todoslosusers); ; 
                
                
                reader.Close();
               return Json;
               

            }
            catch (Exception E)
            {
                Mensaje = "Error" + E;
            }
            return Mensaje;

        }


        public String modificar(Conexion cone)
        {
            try
            {

                //String sql = "UPDATE usuarios SET cedua = '"this.cedula"', nombre='"this.nombre"', edad='"this.edad"' WEHRE cedula ='"cedulaAntigua"'";
                String sql = "UPDATE usuarios SET nombre='"+this.nombre+"', edad='"+this.edad+"' WHERE cedula='"+this.cedula+"';";
                new NpgsqlCommand(sql, cone.getCone()).ExecuteNonQuery();
                return "datos actualizados";
            }
            catch
            {
                return "error";
            }
        }




        public String  eliminar(Conexion cone)
        {
            try
            {

                String sql = "DELETE FROM usuarios WHERE cedula = '"+this.cedula+"';";
                new NpgsqlCommand(sql, cone.getCone()).ExecuteNonQuery();
                return "datos eliminados";
            }
            catch
            {
                return "error, verificar si existe el usuarios";
            }
        }

    }
}
