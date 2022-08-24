using System;
using System.Collections.Generic;
using System.Text;

namespace EDVendas
{
    class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max = 10;
        private int qtde;

        public int Max { get => max; set => max = value; }
        public int Qtde { get => qtde; set => qtde = value; }
        internal Vendedor[] OsVendedores { get => osVendedores; set => osVendedores = value; }

        public Vendedores()
        {
            osVendedores = new Vendedor[max];
            for(int i = 0; i < max; i++)
            {
                OsVendedores[i] = new Vendedor(-1, "...", -1);
            }
            Qtde = 0;
        }

        public bool AddVendedor(Vendedor v)
        {
            bool podeAdd = (Qtde < max);

            if (podeAdd)
            {
                OsVendedores[Qtde] = v;
                Qtde++;
            }

            return podeAdd;
        }


        public Vendedor SearchVendedor(Vendedor v) 
        {
            Vendedor aux = new Vendedor(-1, "...", -1);

            foreach (Vendedor vendedor in OsVendedores)
            {
                if (vendedor.Equals(v))
                {
                    aux = vendedor;
                    break;
                }
            }

            return aux;
        }



        public bool DelVendedor(Vendedor v)
        {
            bool podeDel;
            int i = 0;

            while(i < Max && !OsVendedores[i].Equals(v))
            {
                i++;
            }

            podeDel = (i < Max);
            if (podeDel)
            {
                while(i < Max - 1)
                {
                    OsVendedores[i] = OsVendedores[i + 1];
                    i++;
                }
                OsVendedores[i] = new Vendedor(-1, "...", -1);
                Qtde--;
            }

            return podeDel;
        }

        public bool ChecaId(int id)
        {

            bool podeId;
            int auxId = -1;

            foreach(Vendedor v in OsVendedores)
            {
                if (v.Id.Equals(id))
                {
                    auxId = v.Id;
                    break;
                }
            }

            podeId = !auxId.Equals(id);

            return podeId;
        }
    }
}
