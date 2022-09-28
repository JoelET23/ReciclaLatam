using ReciclaLatam.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ReciclaLatam.ViewsModels
{
    public class ManualVM
    {
        public ObservableCollection<ManualModels> Manual { get; set; }

        public ManualVM()
        {
            Manual = new ObservableCollection<ManualModels>
            {
                new ManualModels
                {
                    Id = 1,
                    Titulo = "Manual para la correcta disposicíón",
                    Descripcion = "Todo lo que necesitas saber para la correcta segregación de manterial reciclable.",
                    Link = "#",
                    Imagen = "Manual1.png"
                },
                new ManualModels
                {
                    Id = 2,
                    Titulo = "Guía de residuos reaprovechables",
                    Descripcion = "Lista detallada de los productos que son y no son reciclables.",
                    Link = "#",
                    Imagen = "Manual2.png"
                }
                
            };
        }
    }
}
