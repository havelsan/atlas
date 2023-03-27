
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
    /// Paket Hizmet Tanım Ekranı
    /// </summary>
    public  partial class PackageProcedureDefinition : ProcedureDefinition
    {
        public partial class GetPackageProcedureDefinition_Class : TTReportNqlObject 
        {
        }

        public partial class GetDialysisPackageProcedures_Class : TTReportNqlObject 
        {
        }

        public partial class GetESWLPackageProcedures_Class : TTReportNqlObject 
        {
        }

        public partial class GetFTRPackageProcedures_Class : TTReportNqlObject 
        {
        }

#region Methods
        public bool IsPackageMatchingExist()
        {
            if (PackageDefinition.Count > 0)
                return true;
            else
                return false;
        }

        public override void SetProcedureType()
        {
            ProcedureType = ProcedureDefGroupEnum.paketBilgileri;
        }

        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.PackageProcedureDefinitionInfo;
        }
        
#endregion Methods

    }
}