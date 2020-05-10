using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Churrasco.Models
{
    public class ChurrascoModel
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string Descricao { get; set; }
        public int NumeroParticipantes { get; set; }
        public int ValorTotal { get; set; }        
        public int? ValorPessoa { get; set; }
    }
}
