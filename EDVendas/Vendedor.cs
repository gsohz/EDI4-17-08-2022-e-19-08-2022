using System;
using System.Collections.Generic;
using System.Text;

namespace EDVendas
{
    class Vendedor
    {
        private int id;
        private string nome;
        private double percComissao;
        private Venda[] asVendas;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public double PercComissao { get => percComissao; set => percComissao = value; }
        public Venda[] AsVendas { get => asVendas; set => asVendas = value; }

        public Vendedor()
        {
            AsVendas = new Venda[31];
            for (int i = 0; i < 31; i++)
            {
                AsVendas[i] = new Venda();
            }
        }
        
        public Vendedor(int id, string nome, double percComissao)
        {
            Id = id;
            Nome = nome;
            PercComissao = percComissao;

        }


        public void RegistrarVenda(Venda venda)    
        {
            int aux = 0;
            bool podeAdd;

            while (AsVendas[aux].Qtde != 0 && aux < 31)
            {
                aux++;
            }

            podeAdd = (aux < 31);

            if (podeAdd)
            {
                AsVendas[aux] = new Venda(venda.Qtde, venda.Valor);
                Console.WriteLine("Venda cadastrada");
            } 
            else Console.WriteLine("Todos os dias já foram cadastrados");

        }

        public double ValorVendas()
        {
            double total = 0;

            foreach(Venda venda in AsVendas)
            {
                total += venda.Valor * venda.Qtde;
            }

            return total;
        }

        public double ValorVendasMedio()
        {
            double total = 0;
       

            foreach (Venda venda in AsVendas)
            {
                if (venda.Valor > 0)
                {
                    total += venda.ValorMedio();
                }
            }

            

            return total;
        }


        public double ValorComissao()
        {
            return ValorVendas() * PercComissao;
        }

        public override bool Equals(object obj)
        {
            return Id.Equals(((Vendedor)obj).Id);
        }
    }
}
