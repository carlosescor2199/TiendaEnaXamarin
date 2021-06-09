using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEnaXamarin.models.Imagen
{
    public class Imagen
    {
        public int id;
        public string name;
        public string alternativeText;
        public string caption;
        public int width;
        public int height;
        public Formats formats;
        public string hash;
        public string ext;
        public string mime;
        public float size;
        public string url;
        public string previewUrl;
        public string provider;
        public string provider_metadata;
        public string created_at;
        public string updated_at;

        public Imagen()
        {
        }

        public Imagen(int id, string name, string alternativeText, string caption, int width, int height, Formats formats, string hash, string ext, string mime, float size, string url, string previewUrl, string provider, string provider_metadata, string created_at, string updated_at)
        {
            this.id = id;
            this.name = name;
            this.alternativeText = alternativeText;
            this.caption = caption;
            this.width = width;
            this.height = height;
            this.formats = formats;
            this.hash = hash;
            this.ext = ext;
            this.mime = mime;
            this.size = size;
            this.url = url;
            this.previewUrl = previewUrl;
            this.provider = provider;
            this.provider_metadata = provider_metadata;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }
    }
}
