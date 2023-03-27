
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


using System.Data.Common;

namespace TTObjectClasses
{
    /// <summary>
    /// Hasta isimlerini içerir
    /// </summary>
    public  partial class PatientToken : TTObject
    {

        public static BindingList<PatientToken.GetByInjectionInternal_Class> GetSpecial(int tokenCount , string injectionSQL, PaginationInfo pi = null)
        {
            DataTable resultSet = null;

            using (DbConnection cn = ConnectionManager.CreateConnection())
            {
                cn.Open();
                char pc = ConnectionManager.ParameterChar;
                int take = pi.Skip + pi.PageSize;

                string innerSql = @"SELECT PATIENT FROM ( " + injectionSQL + " ) GROUP BY PATIENT HAVING Count(*) = " + tokenCount;
                string sql;
                if (pi != null)
                {
                    switch (ConnectionManager.ProviderType)
                    {
                        case DBProviderTypeEnum.MSSqlServer:
                            sql = "SELECT TOP " + pc + "MAXROWS" + " * FROM (" + innerSql + " ) A";
                            break;
                        case DBProviderTypeEnum.Oracle:
                            sql = "SELECT * FROM (" + innerSql + " ) where ROWNUM<" + pc + "MAXROWS";
                            break;
                        case DBProviderTypeEnum.DB2:
                            sql = "SELECT * FROM (" + innerSql + " ) fetch first " + pc + "MAXROWS" + " rows only";
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
                else
                    sql = innerSql;

                DbCommand cmd = ConnectionManager.CreateCommand(sql, cn);
                cmd.Parameters.Add(ConnectionManager.CreateParameter(pc + "MAXROWS", take));

                DbDataAdapter adap = ConnectionManager.CreateDataAdapter(cmd);
                resultSet = new DataTable();
                try
                {
                    adap.Fill(resultSet);

                }
                catch (Exception ex)
                {
                    var a = ex.ToString();
                    throw;
                }
                cn.Close();
            }

            BindingList<PatientToken.GetByInjectionInternal_Class> retList = null;
            if (resultSet != null)
            {
                TTObjectContext objectContext = new TTObjectContext(true);

                retList = new BindingList<PatientToken.GetByInjectionInternal_Class>();
                foreach (DataRow dataRow in resultSet.Rows)
                {
                    PatientToken.GetByInjectionInternal_Class newObj = new PatientToken.GetByInjectionInternal_Class(objectContext, typeof(PatientToken).Name, dataRow);
                    retList.Add(newObj);
                }
            }
            return retList;
        }

        public partial class GetByInjection_Class : TTReportNqlObject 
        {
        }

        public partial class GetPatientByInjection_Class : TTReportNqlObject 
        {
        }

    }
}