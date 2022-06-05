using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using BancoDeDados;
using System.Configuration;
using Mensagens;
using GerenciadorProducao;

namespace testeSerial
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int retorno;
        private void Form1_Load(object sender, EventArgs e)
        {


            string[] ports = SerialPort.GetPortNames();
            comboBox1.Sorted = true;
            foreach (var p in ports)
            {
                comboBox1.Items.Add(p);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            string ano = DateTime.Now.Year.ToString();
            lblRodape.Text = "Copyright © " + ano + " | Developed By Flávio Leandro - Lacuca Brinquedos";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                button1.Text = "ABRIR";
                button1.BackColor = Color.Blue;
                serialPort1.Close();
            }
            else
            {
                button1.BackColor = Color.Red;
                button1.Text = "FECHAR";
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
            }
        }
        //public void preencheTextBox()
        //{
        //    int conta = 0;
        //    while (conta++<10)
        //    {
        //        string dado = "*U    0,09" + conta + " kg";
        //        BeginInvoke((MethodInvoker)(() => { textBox1.Text += Environment.NewLine + dado; }));                
        //        string peso = dado.Replace("*U", "").Replace("kg", "").Trim();
        //        try
        //        {
        //            if (!string.IsNullOrEmpty(peso))
        //            {
        //                Db db = new Db();
        //                db.Adicionar(double.Parse(peso));
        //                BeginInvoke((MethodInvoker)(() => { textBox1.Text += " ADICIONADO NO BANCO DE DADOS " + DateTime.Now.ToString(); ; }));
        //                //textBox1.Text =
        //            }
                    
                   
        //        }
        //        catch (Exception e)
        //        {
        //            textBox1.Text =string.Format(" ERRO AO ADICIONAR NO BANCO DE DADOS {0}",e.Message);
        //        }
        //    }
        //}

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            string dados = serialPort1.ReadExisting();
            BeginInvoke((MethodInvoker)(() => { textBox1.Text += Environment.NewLine+dados; }));
            string peso = dados.Replace("*U", "").Replace("kg", "").Trim();

            try
            {
                Db db = new Db();
                db.Adicionar(double.Parse(peso));
                //textBox1.Text = " ADICIONADO NO BANCO DE DADOS " + DateTime.Now.ToString();
                BeginInvoke((MethodInvoker)(() => { textBox1.Text += " ADICIONADO NO BANCO DE DADOS " + DateTime.Now.ToString(); }));
            }
            catch (Exception)
            {
                //textBox1.Text = " ERRO AO ADICIONAR NO BANCO DE DADOS";
                BeginInvoke((MethodInvoker)(() => { textBox1.Text += " ERRO AO ADICIONAR NO BANCO DE DADOS " + DateTime.Now.ToString(); }));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Relógio
            lblRelogio.Text = DateTime.Now.ToLongTimeString();

            //Rodapé
            //string ano = DateTime.Now.Year.ToString();            
            //lblRodape.Text = "Copyright © " + ano + " | Developed By Flávio Leandro - Lacuca Brinquedos";

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formEmail frmEmail = new formEmail();
            frmEmail.ShowDialog();
            
            //EnvioEmail envio = new EnvioEmail();
            //envio.enviar();
        }

        private void btnCor_Click(object sender, EventArgs e)
        {
            EnvioEmail envio = new EnvioEmail();
            envio.enviarMudanca();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Buscar busca = new Buscar();
            retorno = busca.Consulta();
            label2.Text = retorno.ToString();
        }
    }
}
