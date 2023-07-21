using System;
using System.Collections.Generic;
using System.Text;

namespace Prestiti
{
    class Prestito
    {
        public float _ammontare, _rata;
        public DateTime _DataInizio, _DataFine;
        public Banca _Banca;
        public Cliente _cliente;
        public Prestito(Banca Banca, Cliente cliente, DateTime DataInizio, DateTime DataFine, float Ammontare, float Rata)
        {
            _Banca = Banca;
            _cliente = cliente;
            _DataInizio = DataInizio;
            _DataFine = DataFine;
            _ammontare = Ammontare;
            _rata = Rata;
        }
    }
}
