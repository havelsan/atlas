
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
    /// Diş Protez İşlemleri Tanımlama
    /// </summary>
    public  partial class DentalProsthesisDefinition : ProcedureDefinition
    {
        public partial class GetDentalProsthesisDefinition_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
                        Chargable=true;
#endregion PreInsert
        }

#region Methods
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.DentalProsthesisDefinitionInfo;
        }

        public override void SetProcedureType()
        {
            ProcedureType = ProcedureDefGroupEnum.disProtezBilgileri;
        }

        public override BaseSKRSDefinition GetSKRSDefinition()
        {
            BindingList<SKRSSUT> SKRSSUTList = SKRSSUT.GetByCode(ObjectContext, SUTCode);
            if (SKRSSUTList.Count > 0)
                return SKRSSUTList[0];
            return null;
        }
        #endregion Methods

    }
}