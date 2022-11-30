using System;
using System.Collections.Generic;
using System.Text;

namespace ReciclaLatam.Models
{

    public class NoticiasModels
    {
        public string descripcion { get; set; }
        public string fecha_pub { get; set; }
        public string imagen { get; set; }
        public int noticias_id { get; set; }
        public string titulo { get; set; }
        public string categoria { get; set; }
        public string contenido_noticia { get; set; }

    }

    public class NoticiasLista
    {
        public List<NoticiasModels> Items { get; set; }
        public int Count { get; set; }
        public int ScannedCount { get; set; }
    }
}
