using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class ListagemVeiculos
    {
        public ListagemVeiculos()
        {
            this.Veiculos = new List<Veiculo>
            {
                new Veiculo{Nome="Azera",Preco=60000},
                new Veiculo{Nome="Fiesta 2.0",Preco=50000},
                new Veiculo{Nome="HB20 S",Preco=40000}
            };
        }

        public List<Veiculo> Veiculos { get; private set; }
    }
}
