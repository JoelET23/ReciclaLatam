using System;
using System.Collections.Generic;
using System.Text;

namespace ReciclaLatam.Models 
{
    public class RecojosModels
    {
        public int id_municipalidad { get; set; }
        public int recoleccion_id { get; set; }
        public int id_reciclador { get; set; }
        public string hora_inicio { get; set; }
        public string hora_fin { get; set; }
        public string fecha { get; set; }
        public int id_usuario { get; set; }
    }

    public class RecojosLista
    {
        public List<RecojosModels> Items { get; set; }
        public int Count { get; set; }
        public int ScannedCount { get; set; }
    }
}
