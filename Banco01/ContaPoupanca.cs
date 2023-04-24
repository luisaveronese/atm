namespace Banco01
{
    internal class ContaPoupanca : Conta
    {
        public ContaPoupanca(Cliente cliente) : base(cliente)
        {
        }

        public override void Sacar(double valor)
        {
            if (valor <= 1000)
            {
                base.Sacar(valor + 0.1);
            }
            else
            {
                MessageBox.Show("Não foi possível realizar o saque pois o valor é maior que o limite disponível.");
            }
            
        }
    }
}