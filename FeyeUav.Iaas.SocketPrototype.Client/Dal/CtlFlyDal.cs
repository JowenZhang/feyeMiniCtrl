using DaliyLife.Dal;
using Dapper;
using FeyeUav.Iaas.SocketPrototype.Client.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FeyeUav.Iaas.SocketPrototype.Client.Dal
{
    public class CtlFlyDal
    {
        public int GetCount()
        {
            NpgsqlConnection con = new NpgsqlConnection(CodeDal.ConStr["postgres"]);
            try
            {
                using (con)
                {
                    con.Open();
                    return int.Parse((SqlMapper.ExecuteScalar(con, CodeDal.QueryStr["getCount"]) ?? "0").ToString());
                }
            }
            catch (Exception)
            {
                if (con.State != ConnectionState.Closed)
                {
                    try
                    {
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                throw;
            }
        }

        public ctl_fly GetSingle()
        {
            NpgsqlConnection con = new NpgsqlConnection(CodeDal.ConStr["postgres"]);
            try
            {
                using (con)
                {
                    con.Open();
                    return SqlMapper.QueryFirstOrDefault<ctl_fly>(con, CodeDal.QueryStr["getSingle"]);
                }
            }
            catch (Exception)
            {
                if (con.State != ConnectionState.Closed)
                {
                    try
                    {
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                throw;
            }
        }

        public int Update(ctl_fly model)
        {
            NpgsqlConnection con = new NpgsqlConnection(CodeDal.ConStr["postgres"]);
            try
            {
                using (con)
                {
                    con.Open();
                    return SqlMapper.Execute(con, CodeDal.QueryStr["updateSingle"],model);
                }
            }
            catch (Exception)
            {
                if (con.State != ConnectionState.Closed)
                {
                    try
                    {
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                throw;
            }
        }

        public int Insert(ctl_fly model)
        {
            NpgsqlConnection con = new NpgsqlConnection(CodeDal.ConStr["postgres"]);
            try
            {
                using (con)
                {
                    con.Open();
                    return SqlMapper.Execute(con, CodeDal.QueryStr["insertSingle"], model);
                }
            }
            catch (Exception)
            {
                if (con.State != ConnectionState.Closed)
                {
                    try
                    {
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                throw;
            }
        }
    }
}
