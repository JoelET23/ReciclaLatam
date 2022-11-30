using System;
using System.Collections.Generic;
using System.Text;

namespace ReciclaLatam.Models
{
    public class UsuarioModels
    {
        public string latitud { get; set; }
        public string geolocalizacion { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string termycond { get; set; }
        public string nombres { get; set; }
        public string correo { get; set; }
        public int usuario_id { get; set; }
        public string password { get; set; }
        public string id_municipalidad { get; set; }
        public string telefono { get; set; }
        public string foto { get; set; }
        public string longitud { get; set; }
    }

    public class UsuarioLista
    {
        public List<UsuarioModels> Items { get; set; }
        public int Count { get; set; }
        public int ScannedCount { get; set; }
    }

    public class UsuarioUpdate
    {
        public string latitud { get; set; }
        public string geolocalizacion { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string termycond { get; set; }
        public string nombres { get; set; }
        public string correo { get; set; }
        public int id { get; set; }
        public string password { get; set; }
        public string id_municipalidad { get; set; }
        public string telefono { get; set; }
        public string foto { get; set; }
        public string longitud { get; set; }
    }
}
