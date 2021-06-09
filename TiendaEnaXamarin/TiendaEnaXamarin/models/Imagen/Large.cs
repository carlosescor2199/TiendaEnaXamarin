using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEnaXamarin.models.Imagen
{
    public class Large
    {
        public string name;
        public string hash;
        public string ext;
        public string mime;
        public int width;
        public int height;
        public float size;
        public string path;
        public string url;

        public Large()
        {
        }

        public Large(string name, string hash, string ext, string mime, int width, int height, float size, string path, string url)
        {
            this.name = name;
            this.hash = hash;
            this.ext = ext;
            this.mime = mime;
            this.width = width;
            this.height = height;
            this.size = size;
            this.path = path;
            this.url = url;
        }
    }
}
