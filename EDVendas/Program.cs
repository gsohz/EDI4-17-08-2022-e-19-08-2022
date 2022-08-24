using System;

namespace EDVendas
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = -1;
            
            Vendedores vendedores = new Vendedores();

            do
            {
                Console.WriteLine("\n0. Sair" +
                                  "\n1.Cadastrar vendedor" +
                                  "\n2.Consultar vendedor" +
                                  "\n3.Excluir vendedor" +
                                  "\n4.Registrar venda" +
                                  "\n5.Listar vendedores");
                Console.Write("Opção: ");
                key = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (key) 
                {
                    case 0:
                        Console.WriteLine("Programa encerrado");
                        break;
                    case 1:
                        if (vendedores.Qtde < vendedores.Max)
                        {
                            Vendedor vendedor = new Vendedor();
                            int id;
                            bool podeId;

                            do
                            {
                            Console.Write("Informe o ID do Vendedor: ");
                            id = int.Parse(Console.ReadLine());
                            podeId = vendedores.ChecaId(id);

                                if (!podeId)
                                {
                                    Console.Write("\nId já está registrado. Por favor insira um Id válido: \n");
                                }

                            } while (!podeId);

                            vendedor.Id = id;

                            Console.Write("Informe o nome do Vendedor: ");
                            vendedor.Nome = Console.ReadLine();

                            Console.Write("Informe o percentual de comissão do Vendedor: ");
                            vendedor.PercComissao = double.Parse(Console.ReadLine()) / 100;

                            if (vendedores.AddVendedor(vendedor))
                                Console.Write("\nVendedor cadastrado com o ID " + vendedor.Id + "\n");
                            else
                                Console.Write("Vendedor não cadastrado\n");
                        } else Console.Write("O limite de vendedores cadastros foi atingido: " + vendedores.Qtde + "\n");
                        break;
                    case 2:
                        Vendedor vendedorSearch = new Vendedor();
                        Console.Write("Informe o ID do Vendedor: ");
                        vendedorSearch.Id = int.Parse(Console.ReadLine());

                        vendedorSearch = vendedores.SearchVendedor(vendedorSearch);

                        if (vendedorSearch.Id == -1)
                            Console.WriteLine("Vendedor não encontrado");
                        else
                        {
                            Console.WriteLine("\nID             : " + vendedorSearch.Id +
                                              "\nNome           : " + vendedorSearch.Nome +
                                              "\nVendas         : " + vendedorSearch.ValorVendas().ToString("c") +
                                              "\nComissão       : " + vendedorSearch.ValorComissao().ToString("c") +
                                              "\nMédia de vendas: " + vendedorSearch.ValorVendasMedio().ToString("c"));
                        }
                        break;
                    case 3:
                        Vendedor vendedorDel = new Vendedor();
                        Console.Write("Informe o ID do Vendedor: ");
                        vendedorDel.Id = int.Parse(Console.ReadLine());

                        if (vendedores.DelVendedor(vendedorDel))
                            Console.WriteLine("Vendedor excluído");
                        else
                            Console.WriteLine("Vendedor não encontrado");
                        break;
                    case 4:
                        Venda venda = new Venda();
                        Vendedor vendedorVenda = new Vendedor();

                        Console.Write("Informe o valor da venda: ");
                        venda.Valor = double.Parse(Console.ReadLine());

                        Console.Write("Informe a quantidade da venda: ");
                        venda.Qtde = int.Parse(Console.ReadLine());

                        Console.Write("Informe o ID do Vendedor: ");
                        vendedorVenda.Id = int.Parse(Console.ReadLine());

                        vendedorVenda = vendedores.SearchVendedor(vendedorVenda);

                        if(vendedorVenda.Id == -1) 
                            Console.WriteLine("Vendedor não encontrado");
                        else
                        {
                            vendedorVenda.RegistrarVenda(venda);
                        }
                        break;
                    case 5:
                        double totalVenda = 0, totalComissao = 0;

                        foreach (Vendedor vendedor in vendedores.OsVendedores)
                        {
                            if(vendedor.Id != -1)
                            {

                            Console.WriteLine("ID      : " + vendedor.Id +
                                              "\nNome    : " + vendedor.Nome +
                                              "\nVendas  : " + vendedor.ValorVendas().ToString("c") +
                                              "\nComissão: " + vendedor.ValorComissao().ToString("c"));

                            Console.WriteLine("\n------------------------------------------------------------\n");

                            totalVenda += vendedor.ValorVendas();
                            totalComissao += vendedor.ValorComissao();
                            }
                        }

                        Console.WriteLine("Total de vendas: " + totalVenda.ToString("c"));
                        Console.WriteLine("Total de comissão: " + totalComissao.ToString("c"));
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
                
            } while (key != 0);
        }
    }
}
