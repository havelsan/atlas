
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
    /// Diğer XXXXXX
    /// </summary>
    public  partial class ResOtherHospital : ResSection
    {
        public partial class OLAP_ResOtherHospital_Class : TTReportNqlObject 
        {
        }

#region Methods
        //        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        //        {
        //            return SendDataTypesEnum.ResOtherHospital;
        //        }

//        private void CreateOrUpdateBoundReferableHospital()
//        {
//            IList<ReferableHospital> referableHospitalList = ReferableHospital.GetByResOtherHospital(this.ObjectContext,this.ObjectID);
//            ReferableHospital referableHospital = null;
//            if(referableHospitalList.Count <= 0)
//                referableHospital = (ReferableHospital)(this.ObjectContext.CreateObject("ReferableHospital"));
//            else
//                referableHospital = referableHospitalList[0];
//            referableHospital.ResOtherHospital = this;
//            
//        }
        
        public ReferableHospital MyReferableHospital()
        {
            if(ReferableHospital.Count > 0)
                return ReferableHospital[0];
            return null;
        }
        
#endregion Methods

    }
}