using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Churrasco.Models
{
    public class ChurrascoModel
    {
        public int id { get; set; }
        public DateTime data { get; set; }
        public string descricao { get; set; }
        public int numeroParticipantes { get; set; }
        public int valor { get; set; }
    }
}
