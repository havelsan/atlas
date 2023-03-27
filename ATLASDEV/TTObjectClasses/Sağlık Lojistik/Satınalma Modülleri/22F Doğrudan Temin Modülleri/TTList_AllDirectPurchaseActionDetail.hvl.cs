
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
    public partial class TTList_AllDirectPurchaseActionDetail : TTList
    {
        public TTList_AllDirectPurchaseActionDetail(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_AllDirectPurchaseActionDetail(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        override public string GetDisplayText(TTObject ttObj)
        {
            DirectPurchaseActionDetail o = ttObj as DirectPurchaseActionDetail;
            if (o == null)
                throw new TTException("Invalid object type.");
            return (o.SUTCode != null ? (o.SUTCode.SUTCode +" : " + o.SUTName ): (o.ProcedureSUTCode != null ? (o.ProcedureSUTCode.Code  +" : " + o.RadioPharmaceuticalMaterial.Name) : (o.DPA22FCodelessMaterial != null ? o.DPA22FCodelessMaterial.MaterialName : null)) );
        }
    }
}