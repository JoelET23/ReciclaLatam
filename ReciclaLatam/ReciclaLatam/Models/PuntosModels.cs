using System;
using System.Collections.Generic;
using System.Text;

namespace ReciclaLatam.Models
{
    public class PuntosModels
    {
        public int puntos_recojo_id { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string CampoT { get; set; }
        public string Descripcion { get; set; }
        public string CampoO { get; set; }
        public string Leyenda { get; set; }
        public string CampoTh { get; set; }
        public string Icono { get; set; }
    }

    public class PuntosLista
    {
        public List<PuntosModels> Items { get; set; }
        public int Count { get; set; }
        public int ScannedCount { get; set; }
    }
}
