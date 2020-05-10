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
        public void InsereChurrasco([FromBody] ChurrascoModel churrascoModel) {
            churrascoService.InsereChurrasco(churrascoModel);
        }

        [HttpGet]
        public List<ChurrascoModel> BuscaChurrascos() {
            return churrascoService.BuscaChurrascos();
        }
    }
}
