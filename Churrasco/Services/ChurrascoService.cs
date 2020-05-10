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
        int db;

        public ChurrascoModel BuscaChurrasco(int id) {
            DataTable dt = DalHelper.BuscaChurrasco(id);
            ChurrascoModel churrascoModel = new ChurrascoModel();

            if (dt.Rows.Count == 0) {
                return null;
            }

            churrascoModel.Id = Convert.ToInt32(dt.Rows[0]["id"]);
            churrascoModel.Descricao = dt.Rows[0]["descricao"].ToString();
            churrascoModel.Data = dt.Rows[0]["data_churrasco"].ToString();
            churrascoModel.NumeroParticipantes = Convert.ToInt32(dt.Rows[0]["numero_participantes"]);
            churrascoModel.ValorTotal = Convert.ToInt32(dt.Rows[0]["valor_total"]);
            int parsedValue = churrascoModel.ValorTotal / churrascoModel.NumeroParticipantes;
            churrascoModel.ValorPessoa = int.TryParse(dt.Rows[0]["valor_pessoa"].ToString(), out db) ? (int?)db : parsedValue;
            return churrascoModel;
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
                churrascoModel.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                churrascoModel.Descricao = dt.Rows[i]["descricao"].ToString();
                churrascoModel.Data = dt.Rows[i]["data_churrasco"].ToString();
                churrascoModel.NumeroParticipantes = Convert.ToInt32(dt.Rows[i]["numero_participantes"]);
                churrascoModel.ValorTotal = Convert.ToInt32(dt.Rows[i]["valor_total"]);
                int parsedValue = churrascoModel.ValorTotal / churrascoModel.NumeroParticipantes;
                churrascoModel.ValorPessoa = int.TryParse(dt.Rows[i]["valor_pessoa"].ToString(), out db) ? (int?)db : parsedValue;
                churrascos.Add(churrascoModel);                
            }
            return churrascos;
        }

        public String InsereChurrasco(ChurrascoModel churrasco) {
            if (BuscaChurrasco(churrasco.Id) == null){
                DalHelper.AdicionaChurrasco(churrasco);
                return "Adicionado com sucesso";
            } else {
                DalHelper.AtualizaChurrasco(churrasco);
                return "Atualizado com sucesso";
            }
        }

        public String DeletaChurrasco(int id) {

            DalHelper.DeletaChurrasco(id);

            return "Excluído com sucesso";
        }

    }
}
