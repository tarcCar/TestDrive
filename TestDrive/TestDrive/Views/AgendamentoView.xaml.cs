using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
     
        public AgendamentoViewModel ViewModel { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = ViewModel;
        }

       
        protected  override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", async (msg) =>
            {

               var confirma = await DisplayAlert("Salvar Agendamento", "Deseja realmente agendar?", "Sim", "Não");
                if (confirma)
                {
                    ViewModel.SalvarAgendamento();
                }
              
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento",(msg =>
            {
                DisplayAlert("Agendamento","Agendamento salvo com sucesso!","OK");
            }));
            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento", (msg =>
            {
                DisplayAlert("Agendamento", "Ocorreu um erro ao salvar o agentamento!", "OK");
            }));
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "Agendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }
    }
}