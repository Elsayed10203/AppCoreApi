using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Helpers
{
    public static class Extensions
    {
        public static async Task<IQueryable<T>> ExecuteStoredByNameAsync<T>(this DbcontextRepo contextOnTrack, string storedName, params object[] parameters) where T : new()
        {
            using (DbcontextRepo context = new DbcontextRepo())
            {
          
                  await context.Database.OpenConnectionAsync();
                DbCommand cmd = context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = storedName;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);
                IQueryable<T> resultlist;
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    resultlist = reader.MapTolistAsyn<T>().AsQueryable();
                }
                return resultlist;
            }
        }
        public static List<T> MapTolistAsyn<T>(this DbDataReader dr) where T : new()
        {
            if (dr != null && dr.HasRows)
            {
                var entity = typeof(T);
                var entities = new List<T>();
                var propDict = new Dictionary<string, PropertyInfo>();
                var props = entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                propDict = props.ToDictionary(p => p.Name.ToUpper(), p => p);
                while (dr.Read())
                {
                    T newObject = new T();
                    for (int index = 0; index < dr.FieldCount; index++)
                    {
                        if (propDict.ContainsKey(dr.GetName(index).ToUpper()))
                        {
                            var info = propDict[dr.GetName(index).ToUpper()];
                            if (info != null && info.CanWrite)
                            {
                                var val = dr.GetValue(index);
                                info.SetValue(newObject, (val == DBNull.Value) ? null : val, null);
                            }
                        }
                    }
                    entities.Add(newObject);
                }
                return entities;
            }
            return new List<T>();
        }
    }
}
