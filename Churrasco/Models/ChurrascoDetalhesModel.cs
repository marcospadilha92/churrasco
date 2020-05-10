using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Churrasco.Models
{
    public class ChurrascoDetalhesModel
    {
        public int Id { get; set; }
        public string Participante { get; set; }
        public int Valor { get; set; }
        public bool Bebida { get; set; }
        public bool Pago { get; set; }
        public int Churrasco { get; set; }
    }
}
