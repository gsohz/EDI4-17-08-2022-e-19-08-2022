using System;
using System.Collections.Generic;
using System.Text;

namespace EDVendas
{
    class Venda
    {
        private int qtde;
        private double valor;

        public int Qtde { get => qtde; set => qtde = value; }
        public double Valor { get => valor; set => valor = value; }

        public Venda()
        {
            Qtde = 0;
            Valor = 0;
        }

        public Venda(int qtde, double valor)
        {
            Qtde = qtde;
            Valor = valor;
        }

        public double ValorMedio()
        {
            return Valor / Qtde;
        }
    }
}
