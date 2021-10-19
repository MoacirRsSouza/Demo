using System;

namespace Demo.Prova.Core.Entities
{
    public class Moedas : BaseEntity
    {
        public string Moeda { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime Data_Fim { get; set; }
    }
}
