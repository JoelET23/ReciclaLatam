using System;
using System.Collections.Generic;
using System.Text;

namespace ReciclaLatam.Models
{
    public class NosotrosModels
    {
        public int tipo_nosotros { get; set; }
        public string descripcion { get; set; }
        public int nostros_id { get; set; }
        public string imagen { get; set; }
        public string titulo { get; set; }
    }

    public class NosotrosLista
    {
        public List<NosotrosModels> Items { get; set; }
        public int Count { get; set; }
        public int ScannedCount { get; set; }
    }
}
