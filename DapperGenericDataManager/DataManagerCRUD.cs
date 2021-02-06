using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static DapperGenericDataManager.DataManagerCRUDEnums;

namespace DapperGenericDataManager
{
    public class DataManagerCRUD<TEntity> : IDataManagerCRUD<TEntity> where TEntity : class
    {
        private DatabaseAdapter _dbAdapter;
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public DataManagerCRUD(DatabaseAdapter adapter, IDbConnectionFactory dbConnectionFactory)
        {
            this._dbAdapter = adapter;
            _dbConnectionFactory = dbConnectionFactory;
            SqlMapperExtensions.GetDatabaseType = conn => adapter.ToString();
        }

        public long Add(TEntity entity)
        {
            long id = 0;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                id = conn.Insert(entity);
                conn.Close();
            }
            return id;
        }


        public long Add<T>(T entity) where T : class
        {
            long id = 0;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                id = conn.Insert(entity);
                conn.Close();
            }
            return id;
        }


        public long AddRange(List<TEntity> entities)
        {
            long id = 0;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                id = conn.Insert(entities);
                conn.Close();
            }
            return id;
        }

        public bool Delete(TEntity entity)
        {
            bool res = false;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                res = conn.Delete(entity);
                conn.Close();
            }
            return res;
        }

        public bool DeleteRange(List<TEntity> entities)
        {
            bool res = false;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                res = conn.Delete(entities);
                conn.Close();
            }
            return res;
        }

        // 
        // Get methods
        //

        public T GetValue<T>(string query)
        {
            T res;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                res = conn.ExecuteScalar<T>(query);
                conn.Close();
            }
            return res;
        }

        public T GetValue<T>(string query, object param)
        {
            T res;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                res = conn.ExecuteScalar<T>(query, param);
                conn.Close();
            }
            return res;
        }

        public TEntity Get(long id)
        {
            TEntity res;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                res = conn.Get<TEntity>(id);
                conn.Close();
            }
            return res;
        }

        public TEntity GetFirstOrDefault(string query, object param, CommandType cmdType = CommandType.Text)
        {
            TEntity result;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                result = conn.QueryFirstOrDefault<TEntity>(query, param, commandType: cmdType);
                conn.Close();
            }
            return result;
        }

        public T GetFirstOrDefault<T>(string query, object param, CommandType cmdType = CommandType.Text) where T : class
        {
            T result;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                result = conn.QueryFirstOrDefault<T>(query, param, commandType: cmdType);
                conn.Close();
            }
            return result;
        }


        public List<TEntity> GetAll()
        {
            List<TEntity> res = new List<TEntity>();
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                res = conn.GetAll<TEntity>().ToList();
                conn.Close();
            }
            return res;
        }


        public List<TEntity> GetAll(string query, CommandType cmdType = CommandType.Text)
        {
            List<TEntity> results = new List<TEntity>();

            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                results = conn.Query<TEntity>(query, commandType: cmdType).ToList();
                conn.Close();
            }

            return results;
        }

        public List<TEntity> GetAll(string query, object p, CommandType cmdType = CommandType.Text)
        {
            List<TEntity> results = new List<TEntity>();

            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                results = conn.Query<TEntity>(query, p, commandType: cmdType).ToList();
                conn.Close();
            }

            return results;
        }


        public async Task<List<TEntity>> GetAllAsync(string query, CommandType cmdType = CommandType.Text)
        {
            List<TEntity> results = new List<TEntity>();

            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                var res = await conn.QueryAsync<TEntity>(query, commandType: cmdType);
                results = res.ToList();
                conn.Close();
            }

            return results;
        }

        public async Task<List<TEntity>> GetAllAsync(string query, object p, CommandType cmdType = CommandType.Text)
        {
            List<TEntity> results = new List<TEntity>();

            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                var res = await conn.QueryAsync<TEntity>(query, p, commandType: cmdType);
                results = res.ToList();
                conn.Close();
            }

            return results;
        }


        public List<T> GetAll<T>() where T : class
        {
            List<T> res = new List<T>();
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                res = conn.GetAll<T>().ToList();
                conn.Close();
            }
            return res;
        }

        public List<T> GetAll<T>(string query, CommandType cmdType = CommandType.Text) where T : class
        {
            List<T> results = new List<T>();

            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                results = conn.Query<T>(query, commandType: cmdType).ToList();
                conn.Close();
            }

            return results;
        }

        public List<T> GetAll<T>(string query, object p, CommandType cmdType = CommandType.Text) where T : class
        {
            List<T> results = new List<T>();

            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                results = conn.Query<T>(query, p, commandType: cmdType).ToList();
                conn.Close();
            }

            return results;
        }

        public async Task<List<T>> GetAllAsync<T>(string query, CommandType cmdType = CommandType.Text) where T : class
        {
            List<T> results = new List<T>();

            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                var res = await conn.QueryAsync<T>(query, commandType: cmdType);
                results = res.ToList();
                conn.Close();
            }

            return results;
        }

        public async Task<List<T>> GetAllAsync<T>(string query, object p, CommandType cmdType = CommandType.Text) where T : class
        {
            List<T> results = new List<T>();

            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                var res = await conn.QueryAsync<T>(query, p, commandType: cmdType);
                results = res.ToList();
                conn.Close();
            }

            return results;
        }




        //
        // UPDATING methods
        //


        public bool Update(TEntity entity)
        {
            bool res;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                res = conn.Update(entity);
                conn.Close();
            }
            return res;
        }


        public bool Update<T>(T entity) where T : class
        {
            bool res;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                res = conn.Update(entity);
                conn.Close();
            }
            return res;
        }

        public bool UpdateRange(List<TEntity> entities)
        {
            bool res;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                res = conn.Update(entities);
                conn.Close();
            }
            return res;
        }


        public long ExecuteStoredProcedure(string storedProcName, object param)
        {
            long result;
            var dynamicParams = new DynamicParameters(param);
            dynamicParams.Add("@returnVal", dbType: DbType.Int64, direction: ParameterDirection.Output);

            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Execute(storedProcName, dynamicParams, commandType: CommandType.StoredProcedure);
                result = dynamicParams.Get<long>("@returnVal");
                conn.Close();
            }
            return result;
        }
    }
}
