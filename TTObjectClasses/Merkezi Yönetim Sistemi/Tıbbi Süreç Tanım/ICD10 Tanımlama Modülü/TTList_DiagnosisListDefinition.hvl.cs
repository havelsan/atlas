
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
        public TTList_DiagnosisListDefinition(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_DiagnosisListDefinition(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        override public string GetDisplayText(TTObject ttObj)
        {
            DiagnosisDefinition o = ttObj as DiagnosisDefinition;
            if (o == null)
                throw new TTException("Invalid object type.");
            return o.Code + '-' + o.Name;
        }
    }
}