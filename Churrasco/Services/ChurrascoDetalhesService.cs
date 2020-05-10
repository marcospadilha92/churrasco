using Churrasco.Dal;
using Churrasco.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Churrasco.Services
{
    public class ChurrascoDetalhesService
    {
        public List<ChurrascoDetalhesModel> BuscaParticipantes(int churrasco) {
            DataTable dt = DalHelper.BuscaParticipantes(churrasco);

            if (dt == null)
            {
                throw new Exception("Não há participantes");
            }

            List<ChurrascoDetalhesModel> churrascos = new List<ChurrascoDetalhesModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChurrascoDetalhesModel churrascoDetalhesModel = new ChurrascoDetalhesModel();
                churrascoDetalhesModel.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                churrascoDetalhesModel.Participante = dt.Rows[i]["participante"].ToString();
                churrascoDetalhesModel.Valor = Convert.ToInt32(dt.Rows[i]["valor"]);
                churrascoDetalhesModel.Bebida = Convert.ToBoolean(dt.Rows[i]["bebida"]);
                churrascoDetalhesModel.Pago = Convert.ToBoolean(dt.Rows[i]["pago"]);
                churrascoDetalhesModel.Churrasco = Convert.ToInt32(dt.Rows[i]["churrasco"]);
                churrascos.Add(churrascoDetalhesModel);
            }
            return churrascos;
        }

        public String InsereParticipante(ChurrascoDetalhesModel churrascoDetalhesModel)
        {
            if (BuscaParticipantes(churrascoDetalhesModel.Id) == null)
            {
                DalHelper.AdicionaParticipante(churrascoDetalhesModel);
                return "Adicionado com sucesso";
            }
            else {
                DalHelper.AdicionaParticipante(churrascoDetalhesModel);
                return "Atualizado com sucesso";
            }         
        }

        public String DeletaParticipante(int id)
        {

            DalHelper.DeletaParticipante(id);

            return "Excluído com sucesso";
        }
    }
}
