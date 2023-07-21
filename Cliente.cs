using System;
using System.Collections.Generic;
using System.Text;

namespace Prestiti
{
    class Cliente
    {
        public string _nome, _cognome, _codFisc;
        public float _stipendio;

        public Cliente(string nome, string cognome, string codFisc, float stipendio)
        {
            _nome = nome;
            _cognome = cognome;
            _codFisc = codFisc;
            _stipendio = stipendio;
        }
    }
}
