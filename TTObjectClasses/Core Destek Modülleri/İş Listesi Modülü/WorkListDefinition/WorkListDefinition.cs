
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


namespace TTObjectClasses
{
    public  partial class WorkListDefinition : TerminologyManagerDef
    {
        public partial class GetWorkListDefinitionQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        public string GenerateExpression()
        {
            string expression = "";
            foreach(CriteriaDefinition cr in Criterion)
            {
                CriteriaValue crVal = GetUserCriteriaValue(cr.CriteriaValues);
                if(crVal != null && !string.IsNullOrEmpty(crVal.Value))
                {
                    if(crVal.Value.IndexOf(',') < 0)
                    {
                        if(crVal.Value.Trim() == "IS NULL" || crVal.Value.Trim() == "IS NOT NULL")
                        {
                            expression += " " + cr.Name.ToUpperInvariant() + " " + crVal.Value.Trim() + " AND ";
                        }
                        else
                        {
                            if(cr.CriteriaType == "System.String")
                                expression += " " + cr.Name.ToUpperInvariant() + " = '" + crVal.Value + "' AND ";
                            else if(cr.CriteriaType == "System.Int32" || cr.CriteriaType == "System.Int64")
                                expression += " " + cr.Name.ToUpperInvariant() + " = " + crVal.Value + " AND ";
                            else if(cr.CriteriaType == "System.Boolean")
                                expression += " " + cr.Name.ToUpperInvariant() + " = " +  Convert.ToInt32(Convert.ToBoolean(crVal.Value)).ToString() + " AND ";
                            else if(cr.CriteriaType == "STATE")
                                expression += " " + cr.Name.ToUpperInvariant() + " IS " + crVal.Value + " AND ";
                        }
                    }
                    else
                    {
                        string[] sDatas = crVal.Value.Split(',');
                        if(cr.CriteriaType == "System.String")
                        {
                            expression += " " + cr.Name.ToUpperInvariant() + " IN(";
                            for (int i = 0; i < sDatas.Length; i++)
                            {
                                expression += "'" + sDatas[i] + "'";
                                if ((i + 1) < sDatas.Length)
                                    expression += ",";
                            }
                            expression += ") AND ";
                        }
                        else if(cr.CriteriaType == "System.Int32" || cr.CriteriaType == "System.Int64")
                        {
                            expression += " " + cr.Name.ToUpperInvariant() + " IN(";
                            for (int i = 0; i < sDatas.Length; i++)
                            {
                                expression += "" + sDatas[i] + "";
                                if ((i + 1) < sDatas.Length)
                                    expression += ",";
                            }
                            expression += ") AND ";
                        }
                        else if(cr.CriteriaType == "System.Boolean")
                        {
                            expression += " " + cr.Name.ToUpperInvariant() + " IN(";
                            for (int i = 0; i < sDatas.Length; i++)
                            {
                                expression += "" +  Convert.ToInt32(Convert.ToBoolean(sDatas[i])).ToString() + "";
                                if ((i + 1) < sDatas.Length)
                                    expression += ",";
                            }
                            expression += ") AND ";
                        }
                        else if(cr.CriteriaType == "STATE")
                        {
                            expression += " " + cr.Name.ToUpperInvariant() + " IN(";
                            for (int i = 0; i < sDatas.Length; i++)
                            {
                                expression += "" + sDatas[i] + "";
                                if ((i + 1) < sDatas.Length)
                                    expression += ",";
                            }
                            expression += ") AND ";
                        }
                    }
                }
            }
            
            return expression;
        }

        
        private CriteriaValue GetUserCriteriaValue(CriteriaValue.ChildCriteriaValueCollection col)
        {
            CriteriaValue retVal = null;
            foreach(CriteriaValue val in col)
            {
                if(val.SpecialPanel != null)
                {
                    if(val.User.ObjectID.Equals(Common.CurrentResource.ObjectID) && val.SpecialPanel.ObjectID.Equals(LastSpecialPanel.ObjectID))
                    {
                        retVal = val;
                        break;
                    }
                }
            }
            
            return retVal;
        }
        
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.WorkListDefinitionInfo;
        }

        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = base. GetMyLocalPropertyNamesList();
            if(localPropertyNamesList==null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("LastSpecialPanel");                      
            return localPropertyNamesList;
        }
        
#endregion Methods

    }
}