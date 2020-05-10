using Churrasco.Models;
using Churrasco.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Churrasco.Controllers
{
    [Route("detalhe")]
    public class ChurrascoDetalhesController : Controller
    {
        ChurrascoDetalhesService churrascoDetalhesService = new ChurrascoDetalhesService();

        [HttpPost]
        public String InsereParticipante([FromBody] ChurrascoDetalhesModel churrascoDetalhesModel)
        {
            return churrascoDetalhesService.InsereParticipante(churrascoDetalhesModel);
        }

        [HttpGet("{id}")]
        public List<ChurrascoDetalhesModel> BuscaParticipantes(int id)
        {
            return churrascoDetalhesService.BuscaParticipantes(id);
        }        

        [HttpDelete("{id}")]
        public String Deleta(int id)
        {
            return churrascoDetalhesService.DeletaParticipante(id);
        }
    }
}
