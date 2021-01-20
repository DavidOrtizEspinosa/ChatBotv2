using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    

    class Mensaje
    {

        private String texto;

        public String Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        public enum TipoEmisor 
        {
            Bot, Hombre, Mujer
        }

        public TipoEmisor emisor;


        public TipoEmisor Emisor
        {
            get { return emisor; }
            set { emisor = value; }
        }

        public Mensaje(String texto, TipoEmisor emisor)
        {
            this.Texto = texto;
            this.Emisor = emisor;

        }

        

    }
}
