using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public static class DataTableToEntity
    {

        /// <summary>
        /// Fills Entities from Database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <param name="target"></param>
        public static void Fill<T>(DataTable dt, T entity) where T : new()
        {
            if (dt.Rows.Count > 0)
            {
                BuildEntity(entity, dt.Rows[0]);
                //after building the object mark it as OLD                
            }
        }

        /// <summary>
        /// Fills EntityCollection from DataBase
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <param name="target"></param>
        public static void FillList<T>(DataTable dt, object entityCollection) where T : new()
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    object newObject = null;
                    //Creating new instance entity of the respective collection
                    newObject = typeof(T).InvokeMember(null, BindingFlags.CreateInstance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, newObject, new object[] { }, CultureInfo.InvariantCulture);
                    //Fill the entity with datarow
                    BuildEntity(newObject, dr);
                    //Add the entity to its collection
                    entityCollection.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, entityCollection, new object[] { newObject }, CultureInfo.InvariantCulture);
                }
            }
        }

        /// <summary>
        /// Private method, which will be used to build entity from Dataset
        /// </summary>
        /// <param name="target"></param>
        /// <param name="dr"></param>
        private static void BuildEntity(object entity, DataRow dr)
        {
            //Get all the properties of the entity
            System.Reflection.PropertyInfo[] propInfoColl = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

            //Loop through all the properties and assign the values from datatable.
            foreach (System.Reflection.PropertyInfo propInfo in propInfoColl)
            {
                //Get the DataBase Field name of the property
                //string attribute = GetColumnName(propInfo);
                string attribute = propInfo.Name;

                if (dr.Table.Columns.Contains(attribute))
                {
                    //Get the DataBase Field Value
                    //object datatype is required to hold the datarow's column value
                    object value = dr[attribute];

                    if (value != null)
                    {
                        if (value.GetType() != typeof(System.DBNull))
                        {
                            if (propInfo.PropertyType == typeof(DateTime?))
                            {
                                DateTime? dtNull = null;
                                if (value != null)
                                { dtNull = (DateTime?)Convert.ToDateTime(value); }
                                value = dtNull;
                            }
                            else if (propInfo.PropertyType == typeof(TimeSpan?))
                            {
                                TimeSpan? dtNull = null;
                                if (value != null)
                                { dtNull = (TimeSpan?)(value); }
                                value = dtNull;
                            }
                            else if (propInfo.PropertyType == typeof(decimal?))
                            {
                                decimal? dtNull = null;
                                if (value != null)
                                { dtNull = (decimal?)value; }
                                value = dtNull;
                            }
                            else
                            {
                                value = Convert.ChangeType(value, propInfo.PropertyType, CultureInfo.InvariantCulture);
                                //Set DataBase Field value to the entity's respective property
                            }
                            propInfo.SetValue(entity, value, null);
                        }
                    }
                }
            }
        }
    }
}
