using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel:BaseViewModel
    {
        public ObservableCollection<Veiculo> Veiculos { get; set; }
        private bool aguarde;

        public bool Aguarde
        {
            get { return aguarde; }
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }

        private const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";
        Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado {
            get
            {
                return veiculoSelecionado;
            }
            set
            {
                veiculoSelecionado = value;
                if (value != null)
                    MessagingCenter.Send<Veiculo>(veiculoSelecionado, "VeiculoSelecionado");
            }
        }
        public ListagemViewModel()
        {
            this.Veiculos = new ObservableCollection<Veiculo>();
        }
        public async Task GetVeiculosAsync()
        {
            Aguarde = true;
            HttpClient cliente = new HttpClient();           
            var resultado = await cliente.GetStringAsync(URL_GET_VEICULOS);
            var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);
            foreach (var item in veiculosJson)
            {
                this.Veiculos.Add(new Veiculo {
                    Nome = item.nome,
                    Preco = item.preco
                });
            }
            Aguarde = false;
        }
    }
    class VeiculoJson
    {
        public string nome { get; set; }
        public int preco { get; set; }
    }

}
