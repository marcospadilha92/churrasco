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

        public static void CriarTabelaSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Churrasco(id int, data_churrasco Date(50), descricao VarChar(50)," +
                        "numero_participantes int, valor int)";
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
                        "numero_participantes, valor) values (@id, @data_churrasco, @descricao, @numero_participantes, @valor)";
                    cmd.Parameters.AddWithValue("@id", churrascoModel.id);
                    cmd.Parameters.AddWithValue("@data_churrasco", churrascoModel.data);
                    cmd.Parameters.AddWithValue("@descricao", churrascoModel.descricao);
                    cmd.Parameters.AddWithValue("@numero_participantes", churrascoModel.numeroParticipantes);
                    cmd.Parameters.AddWithValue("@valor", churrascoModel.valor);
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
                    if (churrascoModel.id != null)
                    {
                        cmd.CommandText = "UPDATE Clientes SET data_churrasco = @data_churrasco, descricao = @descricao," +
                            "numero_participantes = @numero_participantes, valor = @valor";
                        cmd.Parameters.AddWithValue("@id", churrascoModel.id);
                        cmd.Parameters.AddWithValue("@data_churrasco", churrascoModel.data);
                        cmd.Parameters.AddWithValue("@descricao", churrascoModel.descricao);
                        cmd.Parameters.AddWithValue("@numero_participantes", churrascoModel.numeroParticipantes);
                        cmd.Parameters.AddWithValue("@valor", churrascoModel.valor);
                        cmd.ExecuteNonQuery();
                    }
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
    }

}

