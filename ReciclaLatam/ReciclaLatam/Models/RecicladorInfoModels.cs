using System;
using System.Collections.Generic;
using System.Text;

namespace ReciclaLatam.Models
{
    public class RecicladorInfoModels
    {
        public int recicladorinfo_id { get; set; }
        public string descripcion { get; set; }
        public string titulo { get; set; }
    }

    public class RecicladorInfoLista
    {
        public List<RecicladorInfoModels> Items { get; set; }
        public int Count { get; set; }
        public int ScannedCount { get; set; }
    }
}
