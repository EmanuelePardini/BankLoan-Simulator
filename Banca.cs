using System;
using System.Collections.Generic;
using System.Text;

namespace Prestiti
{
    class Banca
    {
        public Cliente[] _clienti;
        public string _nomeBanca;
        public Banca(Cliente[] clienti, string nomeBanca)
        {
            _nomeBanca = nomeBanca;
            _clienti = clienti;
        }

            }
    }

