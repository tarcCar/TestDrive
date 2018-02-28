using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive
{
    public class LoginService
    {
        public async Task FazerLogin(Login login)
        {
            using (var cliente = new HttpClient())
            {
                var campoFormulario = new FormUrlEncodedContent(new[] {
                        new KeyValuePair<string,string>("email", login.email ),
                        new KeyValuePair<string, string>("senha",login.senha)
                    }
                    );


                cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                HttpResponseMessage resultado = null;
                try
                {
                     resultado = await cliente.PostAsync("/login", campoFormulario);

                }
                catch(Exception e)
                {

                    MessagingCenter.Send<LoginException>(new LoginException("Ocorreu um erro de conexão."), "FalhaLogin");
                    throw e;
                }

                if (resultado.IsSuccessStatusCode)
                {
                    var json = "{'usuario':{'id':1,'nome':'João da Silva','dataNascimento':'30/01/1990','telefone':'1199887788','email':'joao@alura.com.br'}}";//await resultado.Content.ReadAsStringAsync();
                    var resultadoLogin = JsonConvert.DeserializeObject<ResultadoLogin>(json);
                    MessagingCenter.Send<Usuario>(resultadoLogin.usuario, "SucessoLogin");
                }
                else
                {
                    MessagingCenter.Send<LoginException>(new LoginException("Usuario ou senha incorretos!"), "FalhaLogin");
                }
            }
        }
    }
    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {
        }
    }
}
