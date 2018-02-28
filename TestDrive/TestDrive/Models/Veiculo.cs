﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class Veiculo
    {
        public const int FREIO_ABS = 800;
        public const int AR_CONDICIONADO = 1000;
        public const int MP3_PLAYER = 500;
        public String Nome { get; set; }
        public decimal Preco { get; set; }
        public bool TemFreioAbs { get; set; }
        public bool TemArCondicionado { get; set; }
        public bool TemMP3Player { get; set; }
        public string PrecoFormatado
        {
            get { return string.Format("R$ {0}", Preco); }
        }
        public string PrecoTotalFormatado
        {
            get
            {
                return string.Format("Valor Total: R$ {0}", (
                   Preco
                   + (TemFreioAbs ? FREIO_ABS : 0)
                   + (TemArCondicionado ? AR_CONDICIONADO : 0)
                   + (TemMP3Player ? MP3_PLAYER : 0)
                   ));
            }
        }
    }
}