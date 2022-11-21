using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading;

namespace Week10API
{
    public class Services
    {
        List<Error> Errors = new List<Error>();
        private string SQLConnString { get; set; } = string.Empty;
        public void PrepareSQLConnectionString()
        {
            if (SQLConnString == string.Empty)
            {
                SqlConnectionStringBuilder sqlConStringBuilder = new SqlConnectionStringBuilder();
                sqlConStringBuilder["server"] = @"(localdb)\MSSQLLocalDB";
                sqlConStringBuilder["Trusted_Connection"] = true;
                sqlConStringBuilder["Integrated Security"] = "SSPI";
                sqlConStringBuilder["Initial Catalog"] = "PROG260FA22";

                SQLConnString = sqlConStringBuilder.ToString();
            }
        }

        public List<Monster> GetAll()
        {
            List<Monster> monsters = new List<Monster>();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(SQLConnString))
                {
                    conn.Open();

                    string spName = $@"[dbo].[sp_GetAllMonsters]";

                    using (var command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            int fields = reader.FieldCount;
                            List<string> temp = new List<string>();

                            for (int i = 0; i < fields; i++)
                            {
                                temp.Add(reader.GetValue(i)?.ToString() ?? "NULL");
                            }

                            monsters.Add(new Monster(temp));
                        }

                        reader.Close();
                    }

                    conn.Close();
                }

            }
            catch (Exception e)
            {
                Errors.Add(new Error(e.Message, e.Source));
            }

            

            return monsters;
        }

        public Monster GetMonsterByID(int id)
        {
            Monster monster = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SQLConnString))
                {
                    conn.Open();

                    string spName = $@"[dbo].[sp_GetMonsterByID]";

                    using (var command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ID", id);

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            int fields = reader.FieldCount;
                            List<string> temp = new List<string>();

                            for (int i = 0; i < fields; i++)
                            {
                                temp.Add(reader.GetValue(i)?.ToString() ?? "NULL");
                            }

                            monster = new Monster(temp);
                        }

                        reader.Close();
                    }

                    conn.Close();
                }

            }
            catch (Exception e)
            {
                Errors.Add(new Error(e.Message, e.Source));
            }


            return monster;
        }

        public void UpdateMonsterByID(int id, string name, string type, string HP, string MP, string location)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SQLConnString))
                {
                    conn.Open();

                    string spName = $@"[dbo].[sp_UpdateMonsterByID]";

                    using (var command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Type", type);
                        command.Parameters.AddWithValue("@HP", HP);
                        command.Parameters.AddWithValue("@MP", MP);
                        command.Parameters.AddWithValue("@Location", location);

                        command.ExecuteNonQuery();

                    }

                    conn.Close();
                }

            }
            catch (Exception e)
            {
                Errors.Add(new Error(e.Message, e.Source));
            }
        }

        public void DeleteMonsterByID(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SQLConnString))
                {
                    conn.Open();

                    string spName = $@"[dbo].[sp_DeleteMonsterByID]";

                    using (var command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ID", id);

                        command.ExecuteNonQuery();

                    }

                    conn.Close();
                }

            }
            catch (Exception e)
            {
                Errors.Add(new Error(e.Message, e.Source));
            }
        }

        public List<DataModel> GetCountByState()
        {
            List<DataModel> data = new List<DataModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(SQLConnString))
                {
                    conn.Open();

                    string spName = $@"[dbo].[sp_GetMonsterCountByState]";

                    using (var command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            int fields = reader.FieldCount;
                            List<string> temp = new List<string>();

                            for (int i = 0; i < fields; i++)
                            {
                                temp.Add(reader.GetValue(i)?.ToString() ?? "NULL");
                            }

                            data.Add(new DataModel(temp));
                        }

                        reader.Close();
                    }

                    conn.Close();
                }
            }
            catch (Exception e)
            {

                Errors.Add(new Error(e.Message, e.Source));
            }


            return data;
        }

        public List<DataModel> GetCountByHP()
        {
            List<DataModel> data = new List<DataModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(SQLConnString))
                {
                    conn.Open();

                    string spName = $@"[dbo].[sp_GetMonsterCountByHP]";

                    using (var command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            int fields = reader.FieldCount;
                            List<string> temp = new List<string>();

                            for (int i = 0; i < fields; i++)
                            {
                                temp.Add(reader.GetValue(i)?.ToString() ?? "NULL");
                            }

                            data.Add(new DataModel(temp));
                        }

                        reader.Close();
                    }

                    conn.Close();
                }
            }
            catch (Exception e)
            {

                Errors.Add(new Error(e.Message, e.Source));
            }


            return data;
        }

        public List<DataModel> GetTopHPMP()
        {
            List<DataModel> data = new List<DataModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(SQLConnString))
                {
                    conn.Open();

                    string spName = $@"[dbo].[sp_GetTopHPMP]";

                    using (var command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            int fields = reader.FieldCount;
                            List<string> temp = new List<string>();

                            for (int i = 0; i < fields; i++)
                            {
                                temp.Add(reader.GetValue(i)?.ToString() ?? "NULL");
                            }

                            data.Add(new DataModel(temp));
                        }

                        reader.Close();
                    }

                    conn.Close();
                }
            }
            catch (Exception e)
            {

                Errors.Add(new Error(e.Message, e.Source));
            }


            return data;
        }
    }
}
