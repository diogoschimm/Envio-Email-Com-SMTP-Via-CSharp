# Envio-Email-Com-SMTP-Via-CSharp

## Provedores

```
  gmail
  Host: smtp.gmail.com
  Port: 587
  SSL: True
  Necessário habilitar Apps menos seguros
  
  hotmail
  Host: smtp.live.com
  Port: 587
  SSL: true
   
  
```

Abaixo o código para enviar e-mail utilizando SMTP Externo

```c#
  using System.Net;
  using System.Net.Mail;


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
```

Tela do sistema

![image](https://user-images.githubusercontent.com/30643035/100935465-82596e00-34c6-11eb-9d09-08e735b9c62a.png)
