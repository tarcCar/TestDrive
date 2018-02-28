using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class MasterViewModel:BaseViewModel
    {
        

        public string Nome
        {
            get { return usuario.nome; }
            set { usuario.nome = value; }
        }

      
        public string Email
        {
            get { return usuario.email; }
            set { usuario.email = value; }
        }
        private readonly Usuario usuario;
        public string DataNascimento
        {
            get { return this.usuario.dataNascimento; }
            set { this.usuario.dataNascimento = value; }
        }

        public string Telefone
        {
            get { return this.usuario.telefone; }
            set { this.usuario.telefone = value; }
        }
        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            DefinirComandos(usuario);

        }
        private bool editando = false;
        public bool Editando
        {
            get { return editando; }
            private set {
                editando = value;
                OnPropertyChanged();
            }
        }
        private void DefinirComandos(Usuario usuario)
        {
            this.EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(this.usuario, "EditarPerfil");
            });

            this.SalvarCommand = new Command(() =>
            {
                this.Editando = false;
                MessagingCenter.Send<Usuario>(usuario, "SucessoSalvarUsuario");
            });
            this.EditarCommand = new Command(() =>
            {
                this.Editando = true;
            });
        }

        public ICommand EditarPerfilCommand { get; set; }
        public ICommand SalvarCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }

    }
}
