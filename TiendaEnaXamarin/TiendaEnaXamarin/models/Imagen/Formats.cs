using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEnaXamarin.models.Imagen
{
    public class Formats
    {
        public Thumbnail thumbnail;
        public Large large;
        public Medium medium;
        public Small Small;

        public Formats()
        {
        }

        public Formats(Thumbnail thumbnail, Large large, Medium medium, Small small)
        {
            this.thumbnail = thumbnail;
            this.large = large;
            this.medium = medium;
            Small = small;
        }
    }
}
