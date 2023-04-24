using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Windows.Forms;

namespace Banco01
{
    public partial class Form1 : Form
    {
        public List<Conta> listContas { get; set; }
        public int IndiceContaEncontrado { get; set; }

        public Conta? ContaAtual1 { get; set; }
        public Conta? ContaAtual2 { get; set; }

        public Form1()
        {
            InitializeComponent();
            listContas = new List<Conta>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = textBox1.Text;

            Conta conta = new Conta(cliente);


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = textBox1.Text;

            Conta conta = new ContaCorrente(cliente);
            conta.Depositar(Convert.ToDouble(textBox2.Text));
            conta.Numero = Convert.ToInt32(textBox5.Text);

            listContas.Add(conta);
            AtualizarComboBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = textBox1.Text;

            Conta conta = new ContaPoupanca(cliente);
            conta.Numero = Convert.ToInt32(textBox5.Text);
            listContas.Add(conta);
            AtualizarComboBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conta? selectedConta = comboBox1.SelectedItem as Conta;
            IndiceContaEncontrado = listContas.FindIndex(x => x.Numero == selectedConta.Numero);
            label4.Text = listContas[IndiceContaEncontrado].getSaldo();
            ContaAtual1 = listContas[IndiceContaEncontrado];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizarComboBox();

        }

        private void AtualizarComboBox()
        {
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = listContas;

            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            //comboBox1.DataSource = listContas;

            comboBox1.DisplayMember = "Numero";
            comboBox1.ValueMember = "Numero";
            comboBox1.DataSource = bindingSource1.DataSource;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox3.Text))
            {
                //sacar
                if (ContaAtual1 is ContaCorrente)
                {
                    ContaAtual1.Sacar(Convert.ToDouble(textBox3.Text));
                }
                else if (ContaAtual1 is ContaPoupanca)
                {
                    ContaAtual1.Sacar(Convert.ToDouble(textBox3.Text));
                }

            }
            else
            {
                MessageBox.Show("valor n�o informado");
            }
            AtualizarComboBox();
        }

        private void button2_Click_1(object sender, EventArgs e) //Deposito
        {
            if (!String.IsNullOrEmpty(textBox3.Text))
            {
                //depositar
                ContaAtual1.Depositar(Convert.ToDouble(textBox3.Text));
                label4.Text = listContas[IndiceContaEncontrado].getSaldo();

            }
            else
            {
                MessageBox.Show("valor n�o informado");
            }



        }
    }
}