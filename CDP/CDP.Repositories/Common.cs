using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CDP.Repositories
{
    public static class Common
    {
        public static IQueryable<T> OrderByField<T>(this IQueryable<T> q, string sortColumn, string sortColumnDir)
        {
            var param = Expression.Parameter(typeof(T), "p");

            MemberExpression prop;

            if (sortColumn != "Descripcion")
                prop = Expression.Property(param, sortColumn);
            else
                prop = Expression.Property(param, "Nombre");

            var exp = Expression.Lambda(prop, param);
            string method = sortColumnDir == "asc" ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(mce);
        }
    }

    public class DataMapper
    {
        protected class Mapping
        {
            public Dictionary<int, PropertyInfo> Properties = new Dictionary<int, PropertyInfo>();
        }

        private static readonly Dictionary<string, Mapping> Mappings = new Dictionary<string, Mapping>();

        /// <summary>
        /// Returns a mapping corresponding to a given type.
        /// Internally uses a cache.
        /// </summary>
        /// <param name="scriptName"></param>
        /// <param name="t"></param>
        /// <param name="dataRecord"></param>
        /// <returns></returns>
        protected static Mapping GetMapping(string scriptName, Type t, IDataRecord dataRecord)
        {
            if (!Mappings.ContainsKey(scriptName))
            {
                lock (Mappings)
                {
                    Mappings[scriptName] = LoadMapping(t, dataRecord);
                }
            }
            return Mappings[scriptName];
        }

        /// <summary>
        /// Creates a mapping schema.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="dataRecord"></param>
        /// <returns></returns>
        private static Mapping LoadMapping(Type t, IDataRecord dataRecord)
        {
            Mapping mapping = new Mapping();

            // parse type
            Dictionary<string, PropertyInfo> mappingByName = new Dictionary<string, PropertyInfo>();
            foreach (PropertyInfo propertyInfo in t.GetProperties())
            {
                ColumnAttribute[] columns = (ColumnAttribute[])propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), true);
                if (columns.Length > 0)
                {
                    mappingByName[columns[0].Name.ToLower()] = propertyInfo;
                }
            }

            // read columns
            for (int columnIndex = 0; columnIndex < dataRecord.FieldCount; columnIndex++)
            {
                string propertyName = dataRecord.GetName(columnIndex).ToLower();
                if (mappingByName.ContainsKey(propertyName))
                {
                    mapping.Properties[columnIndex] = mappingByName[propertyName];
                }
            }

            return mapping;
        }

        protected static string GetRecordId(IDataRecord dataRecord)
        {
            StringBuilder id = new StringBuilder(1024);
            for (int index = 0; index < dataRecord.FieldCount; index++)
            {
                id.AppendFormat("{0}///", dataRecord.GetName(index));
            }
            return id.ToString();
        }

        protected static bool HasNoDecimalPart(decimal d)
        {
            return decimal.Truncate(d) == d;
        }

        private static void CheckNoDecimalPart(object rawValue)
        {
            // since Oracle returns decimals, there are very few cases to test
            if (rawValue is decimal && !HasNoDecimalPart((decimal)rawValue))
                throw new ArgumentException(string.Format("Impossible to cast non integer value {0} to long", rawValue));
        }

        protected static object CastToInt(object rawValue)
        {
            CheckNoDecimalPart(rawValue);
            return Convert.ToInt32(rawValue);
        }

        protected static object CastToLong(object rawValue)
        {
            CheckNoDecimalPart(rawValue);
            return Convert.ToInt64(rawValue);
        }

        protected object CastToString(object rawValue)
        {
            return Convert.ToString(rawValue);
        }

        /// <summary>
        /// This method tries to do simple conversions for simple types to class types.
        /// </summary>
        /// <param name="rawValue"></param>
        /// <param name="classType"></param>
        /// <returns></returns>
        protected static object CastToClass(object rawValue, Type classType)
        {
            // 1. we look for a constructor with a single argument
            foreach (var ctor in classType.GetConstructors())
            {
                var parameters = ctor.GetParameters();
                // one parameter...
                if (parameters.Length == 1)
                {
                    // with a value type
                    var parameterType = parameters[0].ParameterType;
                    if (parameterType.IsValueType)
                    {
                        try
                        {
                            object parameterValue = CastValue(rawValue, parameterType);
                            object instance = ctor.Invoke(new[] { parameterValue });
                            return instance;
                        }
                        catch (ArgumentException)
                        {
                        }
                    }
                }
            }
            throw new ArgumentException(string.Format("Don't know how to create {0} with {1}", classType,
                                        rawValue != null ? rawValue.GetType().Name : "(null)"));
        }

        /// <summary>
        /// This method tries to do simple conversions for simple types.
        /// </summary>
        /// <param name="rawValue"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        protected static object CastValue(object rawValue, Type targetType)
        {
            if (rawValue == null)
                return null;
            if (rawValue.GetType() == targetType)
                return rawValue;
            if (targetType == typeof(int))
                return CastToInt(rawValue);
            if (targetType == typeof(long))
                return CastToLong(rawValue);
            if (targetType == typeof(int?))
                return CastToInt(rawValue);
            if (targetType == typeof(long?))
                return CastToLong(rawValue);
            if (targetType == typeof(System.Decimal))
                return Convert.ToDecimal(rawValue);
            if (targetType == typeof(System.Decimal?))
                return Convert.ToDecimal(rawValue);
            if (targetType == typeof(char))
                return Convert.ToChar(rawValue);
            if (targetType == typeof(string))
                return rawValue.ToString();
            if (targetType.IsClass)
                return CastToClass(rawValue, targetType);
            if (targetType == typeof(System.DateTime?))
                return rawValue;
            if (targetType == typeof(bool))
                return (int.Parse(rawValue.ToString()).Equals(0)) ? false : true;
            throw new ArgumentException(string.Format("Don't know how to cast from {0} to {1}", rawValue.GetType(), targetType));
        }

        /// <summary>
        /// Maps an object with a IDataRecord.
        /// </summary>
        /// <param name="contextId"></param>
        /// <param name="dataRecord"></param>
        /// <param name="o"></param>
        public static void Map(string contextId, IDataRecord dataRecord, object o)
        {
            Mapping mapping = GetMapping(contextId, o.GetType(), dataRecord);
            object[] parameters = new object[1];
            for (int columnIndex = 0; columnIndex < dataRecord.FieldCount; columnIndex++)
            {
                PropertyInfo propertyInfo;
                if (mapping.Properties.TryGetValue(columnIndex, out propertyInfo))
                {
                    try
                    {
                        MethodInfo setMethod = propertyInfo.GetSetMethod();
                        object rawValue = null;
                        if (!dataRecord.IsDBNull(columnIndex))
                            rawValue = dataRecord.GetValue(columnIndex);

                        parameters[0] = CastValue(rawValue, propertyInfo.PropertyType);
                        setMethod.Invoke(o, parameters);
                    }
                    catch (ArgumentException argEx)
                    {
                        throw new ArgumentException(string.Format("{0} exception when casting table column: {1} with property: {2} in context {3}",
                            argEx.Message, dataRecord.GetName(columnIndex), propertyInfo.Name, contextId));
                        throw argEx;
                    }
                    catch (Exception argEx)
                    {
                        throw new Exception(string.Format("{0} exception when casting table column: {1} with property: {2} in context {3}",
                            argEx.Message, dataRecord.GetName(columnIndex), propertyInfo.Name, contextId));
                        throw argEx;
                    }
                }
            }
        }

        public static IList<TResult> MapList<TSource, TResult>(IList<TSource> viewList) where TResult : new()
        {

            return viewList.Select(view => Map<TSource, TResult>(view)).ToList();
        }

        public static TResult Map<TSource, TResult>(TSource view) where TResult : new()
        {
            TResult result = new TResult();
            object[] parameters = new object[1];

            if (view != null)
            {
                foreach (PropertyInfo propertyInfo in typeof(TResult).GetProperties())
                {
                    MethodInfo setMethod = propertyInfo.GetSetMethod();
                    if (setMethod != null)
                    {
                        PropertyInfo sourceProperty = typeof(TSource).GetProperty(propertyInfo.Name);
                        if (sourceProperty != null)
                        {
                            MethodInfo getMethod = sourceProperty.GetGetMethod();

                            parameters[0] = CastValue(getMethod.Invoke(view, null), sourceProperty.PropertyType);
                            setMethod.Invoke(result, parameters);
                        }
                    }
                }
            }
            return result;
        }
    }
}