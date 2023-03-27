
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
    /// İBF İstek Modülü ana sınıfıdır
    /// </summary>
    public  partial class IBFDemand : BasePurchaseAction, IIBFDemandWorkList
    {
#region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
                RequestNo.GetNextValue();
        }
        
        public bool HaveDetails()
        {
            bool haveDetail = false;
            foreach(IBFBaseDemandDetail id in IBFBaseDemandDetails)
            {
                if(id.CurrentStateDefID == IBFBaseDemandDetail.States.New)
                {
                    haveDetail = true;
                    break;
                }
            }
            
            return haveDetail;
        }
        
        public string NullAmounts()
        {
            if(OriginalStateDef == null)
                return null;
            
            string errMsg = null;
            foreach(IBFBaseDemandDetail ibfd in IBFBaseDemandDetails)
            {
                if(ibfd.CurrentStateDefID != IBFBaseDemandDetail.States.Cancelled)
                {
                    if(OriginalStateDef.StateDefID == IBFDemand.States.AccountancyApproval)
                    {
                        if(CurrentStateDefID == IBFDemand.States.RequisiteEvaluationCommision)
                        {
                            if(ibfd.Amount == null)
                                errMsg += "\n" + ibfd.PurchaseItemDef.ItemName;
                        }
                    }
                    else if(OriginalStateDef.StateDefID == IBFDemand.States.ClinicApproval)
                    {
                        if(CurrentStateDefID == IBFDemand.States.AccountancyApproval)
                        {
                            if(ibfd.ClinicApprovedAmount == null)
                                errMsg += "\n" + ibfd.PurchaseItemDef.ItemName;
                        }
                    }
                }
            }
            return errMsg;
        }
        
#endregion Methods

    }
}