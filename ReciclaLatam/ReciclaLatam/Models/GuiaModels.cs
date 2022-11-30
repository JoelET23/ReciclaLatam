using System;
using System.Collections.Generic;
using System.Text;

namespace ReciclaLatam.Models
{
    public class GuiaModels
    {
        public string ruta { get; set; }
        public string descripcion { get; set; }
        public string fecha_pub { get; set; }
        public string imagen { get; set; }
        public string nombre_doc { get; set; }
        public string titulo { get; set; }
        public int guias_id { get; set; }
    }

    public class GuiasLista
    {
        public List<GuiaModels> Items { get; set; }
        public int Count { get; set; }
        public int ScannedCount { get; set; }
    }
}
