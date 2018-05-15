using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    class Tarificador
    {
        public Cliente Cliente { get; set; }

        public Tarificador()
        {
            Init();
        }

        private void Init()
        {
            Cliente = new Cliente();
        }

        public void CalcularPrima()
        {

        }
    }
}
