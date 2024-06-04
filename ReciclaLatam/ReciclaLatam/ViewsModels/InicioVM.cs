using ReciclaLatam.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ReciclaLatam.ViewsModels
{
    public class InicioVM
    {
        public ObservableCollection<MenuInicioModels> MenuInicio { get; set; }

        public InicioVM()
        {
            MenuInicio = new ObservableCollection<MenuInicioModels>
            {
                new MenuInicioModels
                {
                    Id = 1,
                    Nombre = "Recojo",
                    Imagen = "recojo.png"
                },
                new MenuInicioModels
                {
                    Id = 2,
                    Nombre = "Puntos",
                    Imagen = "puntos.png"
                },
                new MenuInicioModels
                {
                    Id = 3,
                    Nombre = "Manuales",
                    Imagen = "manuales.png"
                },
                /*new MenuInicioModels
                {
                    Id = 4,
                    Nombre = "Noticias",
                    Imagen = "noticias.png"
                },*/
                new MenuInicioModels
                {
                    Id = 5,
                    Nombre = "Mi info",
                    Imagen = "miinfo.png"
                },
                new MenuInicioModels
                {
                    Id = 6,
                    Nombre = "Nosotros",
                    Imagen = "nosotros.png"
                },
                new MenuInicioModels
                {
                    Id = 7,
                    Nombre = "Sugerencias",
                    Imagen = "noticias.png"
                }
            };
        }
    }
}
