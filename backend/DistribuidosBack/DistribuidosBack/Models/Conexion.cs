using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistribuidosBack.Models
{
    public class Conexion
    {


        NpgsqlConnection cone;


        public Conexion()
        {
            conectar();
        }

        public NpgsqlConnection getCone()
        {
            return cone;
        }

        public void conectar()
        {
            this.cone = new NpgsqlConnection("Server= 127.0.0.1;User Id=distribuidos;Password=12345678;Database=distribuidos2_web ");
            this.cone.Open();
        }
    }
}
