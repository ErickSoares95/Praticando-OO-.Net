using System;

namespace Bank
{
    public class Conta
    {

        private TipoConta tipoConta {get; set; }

        private string nome { get; set; }

        private double saldo { get; set; }

        private double credito { get; set; }

        public Conta ( TipoConta tipoConta, string nome,  double saldo, double credito)
        {
            this.tipoConta = tipoConta;
            this.nome = nome;
            this.saldo = saldo;
            this.credito = credito;
        }
        public bool Sacar(double ValorSaque)
        {
            if(this.saldo - ValorSaque < (this.credito*-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.saldo-= ValorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.nome, this.saldo);

            return true;
        }

        public void Depositar(double valorDeposito){
            this.saldo += valorDeposito;

            Console.WriteLine($"Saldo atual da conta de {this.nome} é {this.saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino){
            if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno="";
            retorno += "TipoConta " + this.tipoConta + " | ";
            retorno += "Nome " + this.tipoConta + " | ";
            retorno += "Saldo " + this.tipoConta + " | ";
            retorno += "Credito " + this.tipoConta + " | ";
            return retorno;
        }

    }
}