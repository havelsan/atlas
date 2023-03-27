
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
    /// <summary>
    /// ICD10 Tanı Listesi
    /// </summary>
    public partial class TTList_DiagnosisListDefinition : TTList
    {
#region Methods
        override public string GetFilterExpressionForFillChildNodes(TTObject parentNodeObject, TTObjectRelationDef relDef)
        {
            string filterExpression = "";
            bool listDefHasExpression = false;
            filterExpression = GetListExpression(null);
            if(String.IsNullOrEmpty(ListDef.FilterExpression) == false)
                if("(" + ListDef.FilterExpression.Trim() + ")" == filterExpression)
                listDefHasExpression = true;
            if (parentNodeObject != null || String.IsNullOrEmpty(filterExpression) || listDefHasExpression)
                return base.GetFilterExpressionForFillChildNodes(parentNodeObject, relDef);
            
            return GetListExpression(null);
        }

        public override bool IsObjectSelectable(object obj)
        {
            return true;
        }

        #endregion Methods
    }
}