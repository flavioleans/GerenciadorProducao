using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mensagens;

namespace GerenciadorProducao
{
    public partial class formEmail : Form
    {
        public formEmail()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string msgMotivo = tbxMotivo.Text.ToString();
            EnvioEmail enviarMsg = new EnvioEmail();
            enviarMsg.enviar(msgMotivo);
            this.Close();
        }
    }
}
