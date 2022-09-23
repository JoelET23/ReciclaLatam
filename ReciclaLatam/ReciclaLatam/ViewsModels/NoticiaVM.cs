using ReciclaLatam.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ReciclaLatam.ViewsModels
{
    public class NoticiaVM
    {
        public ObservableCollection<NoticiasModels> NoticiasCol { get; set; }

        public NoticiaVM()
        {
            NoticiasCol = new ObservableCollection<NoticiasModels>
            {
                new NoticiasModels
                {
                    Id = 1,
                    Titulo = "Consequat sagittis sapien blandit velit egestas.",
                    Descripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Rhoncus nunc nunc vel viverra.",
                    Fecha = "16 Ago",
                    Imagen = "Noticia1.png"
                },
                new NoticiasModels
                {
                    Id = 2,
                    Titulo = "Consequat sagittis sapien blandit velit egestas.",
                    Descripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Rhoncus nunc nunc vel viverra.",
                    Fecha = "25 Ago",
                    Imagen = "Noticia2.png"
                }

            };
        }
    }
}
