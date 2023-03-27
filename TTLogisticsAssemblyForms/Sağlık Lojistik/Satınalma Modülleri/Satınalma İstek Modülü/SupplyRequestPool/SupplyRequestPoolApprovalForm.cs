
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class SupplyRequestPoolApprovalForm : BaseSupplyRequestPoolForm
    {
        #region SupplyRequestPoolApprovalForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            this._SupplyRequestPool.SendSupplyRequestPoolToXXXXXX(this._SupplyRequestPool);
            base.AfterContextSavedScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID == SupplyRequestPool.States.Approval)
                {
                    foreach (SupplyRequestPoolDetail poolDet in _SupplyRequestPool.SupplyRequestPoolDetails)
                    {
                        foreach (SupplyRequestDetail det in poolDet.SupplyRequestDetails)
                        {
                            det.SupplyRequestStatus = SupplyRequestStatusEnum.AccountingApproval;
                        }
                    }
                }


                if (transDef.ToStateDefID == SupplyRequestPool.States.Completed)
                {
                    foreach (SupplyRequestPoolDetail poolDet in _SupplyRequestPool.SupplyRequestPoolDetails)
                    {
                        if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.ToBeSent)
                            poolDet.SupplyRqstPlDetStatus = SupplyRqstPlDetStatusEnum.Sent;

                        foreach (SupplyRequestDetail det in poolDet.SupplyRequestDetails)
                        {
                            if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.Cancelled)
                                det.SupplyRequestStatus = SupplyRequestStatusEnum.RequestCancelled;

                            if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.SupplyWithExcess)
                                det.SupplyRequestStatus = SupplyRequestStatusEnum.SupplyWithExcess;

                            if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.Sent)
                                det.SupplyRequestStatus = SupplyRequestStatusEnum.RequestCompleted;
                        }
                    }
                }

            }

            _SupplyRequestPool.ObjectContext.Save();
        }



        #endregion SupplyRequestPoolApprovalForm_Methods
    }
}