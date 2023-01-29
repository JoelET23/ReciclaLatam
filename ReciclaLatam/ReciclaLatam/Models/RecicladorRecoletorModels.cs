using System;
using System.Collections.Generic;
using System.Text;

namespace ReciclaLatam.Models
{
    public class RecicladorRecoletorModels
    {
        public string id { get; set; }
        public int id_reciclador { get; set; }
        public int id_recoleccion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
    }

    public class RecicladorRecoletorLista
    {
        public List<RecicladorRecoletorModels> Items { get; set; }
        public int Count { get; set; }
        public int ScannedCount { get; set; }
    }
}
