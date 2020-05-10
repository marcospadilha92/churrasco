using Churrasco.Models;
using Churrasco.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Churrasco.Controllers{

    [Route("churrasco")]
    public class ChurrascoController : Controller
    {
        ChurrascoService churrascoService = new ChurrascoService();

        [HttpPost]
        public String InsereChurrasco([FromBody] ChurrascoModel churrascoModel) {
            return churrascoService.InsereChurrasco(churrascoModel);
        }

        [HttpGet]
        public List<ChurrascoModel> BuscaChurrascos() {
            return churrascoService.BuscaChurrascos();
        }

        [HttpGet("{id}")]
        public ChurrascoModel BuscaChurrasco(int id)
        {
            return churrascoService.BuscaChurrasco(id);
        }

        [HttpDelete("{id}")]
        public String DeletaChurrasco(int id) {
            return churrascoService.DeletaChurrasco(id);
        }

    }
}
