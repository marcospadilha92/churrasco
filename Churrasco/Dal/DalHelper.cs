using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using Churrasco.Models;

namespace Churrasco.Dal
{
    public class DalHelper
    {
        private static SQLiteConnection sqliteConnection;        

        public DalHelper(){ }

        private static SQLiteConnection DbConnection()
        {
            string diretorio = Environment.CurrentDirectory;
            sqliteConnection = new SQLiteConnection("Data Source= "+ diretorio + "\\CadastroChurrasco.sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void CriarBancoSQLite()
        {
            try
            {
                string diretorio = Environment.CurrentDirectory;
                SQLiteConnection.CreateFile(diretorio + "\\CadastroChurrasco.sqlite");
            }
            catch
            {
                throw;
            }
        }

        public static void CriarTabelaChurrascoSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Churrasco(id int, data_churrasco VarChar(50), descricao VarChar(50)," +
                        "numero_participantes int, valor_total int, valor_pessoa int)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CriarTabelaChurrascoDetalhesSQlite()
        {
            CriarTabelaChurrascoSQlite();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Churrasco_Detalhes(id int, participante VarChar(50)," +
                        " valor int, bebida BOOLEAN NOT NULL CHECK (bebida IN (0,1)), pago BOOLEAN NOT NULL CHECK (pago IN (0,1)), churrasco int," +
                        " FOREIGN KEY(churrasco) REFERENCES Churrasco(id))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable BuscaChurrascos()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Churrasco";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable BuscaChurrasco(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Churrasco Where Id=" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AdicionaChurrasco(ChurrascoModel churrascoModel)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Churrasco(id, data_churrasco, descricao," +
                        "numero_participantes, valor_total, valor_pessoa) values (@id, @data_churrasco, @descricao, @numero_participantes, @valor_total, @valor_pessoa)";
                    cmd.Parameters.AddWithValue("@id", churrascoModel.Id);
                    cmd.Parameters.AddWithValue("@data_churrasco", churrascoModel.Data);
                    cmd.Parameters.AddWithValue("@descricao", churrascoModel.Descricao);
                    cmd.Parameters.AddWithValue("@numero_participantes", churrascoModel.NumeroParticipantes);
                    cmd.Parameters.AddWithValue("@valor_total", churrascoModel.ValorTotal);
                    cmd.Parameters.AddWithValue("@valor_pessoa", churrascoModel.ValorPessoa);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AtualizaChurrasco(ChurrascoModel churrascoModel)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {                    
                        cmd.CommandText = "UPDATE Churrasco SET data_churrasco = @data_churrasco, descricao = @descricao," +
                            "numero_participantes = @numero_participantes, valor_total = @valor_total, valor_pessoa = @valor_pessoa";
                        cmd.Parameters.AddWithValue("@id", churrascoModel.Id);
                        cmd.Parameters.AddWithValue("@data_churrasco", churrascoModel.Data);
                        cmd.Parameters.AddWithValue("@descricao", churrascoModel.Descricao);
                        cmd.Parameters.AddWithValue("@numero_participantes", churrascoModel.NumeroParticipantes);
                        cmd.Parameters.AddWithValue("@valor_total", churrascoModel.ValorTotal);
                        cmd.Parameters.AddWithValue("@valor_pessoa", churrascoModel.ValorPessoa);
                        cmd.ExecuteNonQuery();
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeletaChurrasco(int id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM Churrasco Where id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable BuscaParticipantes(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Churrasco_Detalhes Where Id=" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AdicionaParticipante(ChurrascoDetalhesModel churrascoDetalhesModel)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Churrasco_Detalhes(id, participante, valor," +
                        "bebida, pago, churrasco) values (@id, @participante, @valor, @bebida, @pago, @churrasco)";
                    cmd.Parameters.AddWithValue("@id", churrascoDetalhesModel.Id);
                    cmd.Parameters.AddWithValue("@participante", churrascoDetalhesModel.Participante);
                    cmd.Parameters.AddWithValue("@valor", churrascoDetalhesModel.Valor);
                    cmd.Parameters.AddWithValue("@bebida", churrascoDetalhesModel.Bebida);
                    cmd.Parameters.AddWithValue("@pago", churrascoDetalhesModel.Pago);
                    cmd.Parameters.AddWithValue("@churrasco", churrascoDetalhesModel.Churrasco);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AtualizaParticipante(ChurrascoDetalhesModel churrascoDetalhesModel) {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "UPDATE Churrasco_Detalhes SET id = @id, participante = @participante," +
                        "valor = @valor, bebida = @bebida, pago = @pago, churrasco = @churrasco";
                    cmd.Parameters.AddWithValue("@id", churrascoDetalhesModel.Id);
                    cmd.Parameters.AddWithValue("@participante", churrascoDetalhesModel.Participante);
                    cmd.Parameters.AddWithValue("@valor", churrascoDetalhesModel.Valor);
                    cmd.Parameters.AddWithValue("@bebida", churrascoDetalhesModel.Bebida);
                    cmd.Parameters.AddWithValue("@pago", churrascoDetalhesModel.Pago);
                    cmd.Parameters.AddWithValue("@churrasco", churrascoDetalhesModel.Churrasco);
                    cmd.ExecuteNonQuery();
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletaParticipante(int id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM Churrasco_Detalhes Where id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

