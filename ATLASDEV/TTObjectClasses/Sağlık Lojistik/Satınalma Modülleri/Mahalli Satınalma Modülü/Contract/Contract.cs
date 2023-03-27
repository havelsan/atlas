
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
    /// İhalede Sözleşme Yapılan Her Firma İçin Sözleşme Bilgilerinin Tutulduğu Sınıftır.
    /// </summary>
    public  partial class Contract : TTObject
    {
        public partial class KararBelgesiNQL_Class : TTReportNqlObject 
        {
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();
            
            ContractBondAmount = Convert.ToDouble(SystemParameter.GetParameterValue("PPKatiTeminatOrani", null));
            DecisionStampAmount = Convert.ToDouble(SystemParameter.GetParameterValue("PPKararPuluOrani", null));
            ContractStampAmount = Convert.ToDouble(SystemParameter.GetParameterValue("PPSozlesmePuluOrani", null));

#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            
            if(TransDef.ToStateDefID == Contract.States.Cancelled || TransDef.ToStateDefID == Contract.States.Closed)
            {
                foreach (ContractDetail cd in ContractDetails)
                {
                    if (cd.IncludedToContract == false)
                    {
                        ((ITTObject)cd).Delete();
                    }
                }
            }

#endregion PostUpdate
        }

    }
}