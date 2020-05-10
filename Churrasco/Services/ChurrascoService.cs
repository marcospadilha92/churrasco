using Churrasco.Dal;
using Churrasco.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Churrasco.Services
{
    public class ChurrascoService
    {
        public DataTable BuscaChurrasco(int id) {
            DataTable dt = DalHelper.BuscaChurrasco(id);

            return dt;
        }

        public List<ChurrascoModel> BuscaChurrascos()
        {
            DataTable dt = DalHelper.BuscaChurrascos();

            if (dt == null) {
                throw new Exception("Não há churrascos");
            }

            List<ChurrascoModel> churrascos = new List<ChurrascoModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChurrascoModel churrascoModel = new ChurrascoModel();
                churrascoModel.id = Convert.ToInt32(dt.Rows[i]["id"]);
                churrascoModel.descricao = dt.Rows[i]["descricao"].ToString();
                churrascoModel.data = Convert.ToDateTime(dt.Rows[i]["data_churrasco"]);
                churrascoModel.numeroParticipantes = Convert.ToInt32(dt.Rows[i]["numero_participantes"]);
                churrascoModel.valor = Convert.ToInt32(dt.Rows[i]["valor"]);
                churrascos.Add(churrascoModel);                
            }
            return churrascos;
        }

        public String InsereChurrasco(ChurrascoModel churrasco) {
            
            DalHelper.AdicionaChurrasco(churrasco);

            return "Adicionado com sucesso";
        }

    }
}
