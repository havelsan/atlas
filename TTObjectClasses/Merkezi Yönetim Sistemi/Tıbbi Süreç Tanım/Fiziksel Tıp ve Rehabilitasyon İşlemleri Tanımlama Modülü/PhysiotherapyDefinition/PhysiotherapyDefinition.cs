
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
    /// Fiziksel Tıp ve Rehabilitasyon İşlemleri Tanımlama
    /// </summary>
    public partial class PhysiotherapyDefinition : ProcedureDefinition
    {
        public partial class GetPhysiotherapyDefinition_Class : TTReportNqlObject
        {
        }

        #region Methods

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            if (IsActive == null)
            {
                IsActive = false;
            }
            #endregion PreInsert
        }

        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.PhysiotherapyDefinitionInfo;
        }

        public override void SetProcedureType()
        {
            ProcedureType = ProcedureDefGroupEnum.fizikselTipBilgisi;
        }

        #endregion Methods

    }
}