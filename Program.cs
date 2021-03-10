using System;
using System.Collections.Generic;
namespace Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcao();

            while(opcaoUsuario != "7"){
                switch(opcaoUsuario){
                    case "1":
                        listarContas();
                        break;
                    case "2":
                        inserirConta();
                        break;
                    case "3":
                        Trasnferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                    throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = obterOpcao();

            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
            
        }

        private static void Trasnferir()
        {
            Console.WriteLine("Digite o numero da conta de origem: "); 
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de Destino: "); 
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
            
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta: "); 
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser Depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
           Console.WriteLine("Digite o numero da conta: "); 
           int indiceConta = int.Parse(Console.ReadLine());

           Console.WriteLine("Digite o valor a ser sacado: ");
           double valorSaque = double.Parse(Console.ReadLine());

           listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void listarContas()
        {
           Console.WriteLine("Listar Contas");
           if(listaContas.Count == 0) {
               Console.WriteLine("Nenhuma conta cadastrada");
               return;
           }

           for (int i = 0; i < listaContas.Count; i++)
           {
               Conta c = listaContas[i];
               Console.Write("#{0} - ", i);
               Console.WriteLine(c);
           }
        }

        private static void inserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para conta fisica ou 2 para juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial do cliente: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta c = new Conta(tipoConta: (TipoConta)entradaTipoConta, nome: entradaNome, saldo: entradaSaldo,
                                                                                    credito: entradaCredito);

            listaContas.Add(c);
        }

        private static string obterOpcao(){
            Console.WriteLine("");
            Console.WriteLine("University.Bank ao seu dispor!!");
            Console.WriteLine("Informe qual opção desejada");
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("6- Limpar Tela");
            Console.WriteLine("7- Sair");
            Console.WriteLine("");

            string opcao = Console.ReadLine();
            Console.WriteLine();
            return opcao;
        }
    }
}
