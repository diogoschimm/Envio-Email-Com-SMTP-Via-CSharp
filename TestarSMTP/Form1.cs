using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestarSMTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                var email = new MailMessage();
                email.From = new MailAddress( txtLogin.Text, "Teste de Sistema");
                email.To.Add(txtPara.Text);

                email.IsBodyHtml = true;
                email.Subject = "Teste de SMTP";
                email.Body = "<p>Enviado com sucesso</p>";

                var smtp = new SmtpClient(txtHost.Text, int.Parse( txtPorta.Text));
                smtp.Credentials = new NetworkCredential(txtLogin.Text, txtSenha.Text);
                smtp.EnableSsl = chkBoxSSL.Checked;

                smtp.Send(email);

                txtLog.Text = "E-mail enviado com sucesso!!!!";

                MessageBox.Show("E-mail enviado com sucesso!!!");
            }
            catch (Exception ex)
            {
                txtLog.Text = ex.Message;
            }
        } 

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtLogin.Focus();
        }
    }
}
