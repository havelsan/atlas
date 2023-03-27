
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
    /// <summary>
    /// Kalibrasyon/Bakım/Onarım İstek Durumu Düzeltme
    /// </summary>
    public partial class CMRActionDataCorrectionForm : BaseDataCorrectionForm
    {
        override protected void BindControlEvents()
        {
            cmdUpdateCMRAction.Click += new TTControlEventDelegate(cmdUpdateCMRAction_Click);
            cmdGetCMRAction.Click += new TTControlEventDelegate(cmdGetCMRAction_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdUpdateCMRAction.Click -= new TTControlEventDelegate(cmdUpdateCMRAction_Click);
            cmdGetCMRAction.Click -= new TTControlEventDelegate(cmdGetCMRAction_Click);
            base.UnBindControlEvents();
        }

        private void cmdUpdateCMRAction_Click()
        {
#region CMRActionDataCorrectionForm_cmdUpdateCMRAction_Click
   bool enable = false ;
            if (_CMRActionDataCorrection.CMRActionRequest.ForkCMRAction != null && _CMRActionDataCorrection.CMRActionRequest.ForkCMRAction.Count > 0)
            {
                CMRAction cmrAction =_CMRActionDataCorrection.CMRActionRequest.ForkCMRAction[0];
                if (cmrAction.CurrentStateDef.BaseStateDefID != CMRAction.States.Completed && cmrAction.CurrentStateDef.BaseStateDefID != CMRAction.States.Cancelled)
                    enable = true;
            }
            if (enable)
            {
                this._CMRActionDataCorrection.CMRActionRequest.CMRActionRequestUpdate = true;
                _CMRActionDataCorrection.CMRActionRequest.CurrentStateDefID = CMRActionRequest.States.Status;
                this.NewCMRActionStatus.Text = this._CMRActionDataCorrection.CMRActionRequest.CurrentStateDef.DisplayText;
            }
#endregion CMRActionDataCorrectionForm_cmdUpdateCMRAction_Click
        }

        private void cmdGetCMRAction_Click()
        {
#region CMRActionDataCorrectionForm_cmdGetCMRAction_Click
   string requestNu = "";
            requestNu = this.RequestNO.Text.ToString();
            if (requestNu == null)
            {
                throw new TTException("İş İstek Numarasını Giriniz.");
            }
            else
            {
            IList cMRActionRequestList = CMRActionRequest.GetCMRActionRequestByRequestNo(this._CMRActionDataCorrection.ObjectContext,requestNu);
            if (cMRActionRequestList.Count == 1)
            {
                _CMRActionDataCorrection.CMRActionRequest = (CMRActionRequest)cMRActionRequestList[0];
                this.OldCMRActionStatus.Text = _CMRActionDataCorrection.CMRActionRequest.CurrentStateDef.DisplayText;
                if (_CMRActionDataCorrection.CMRActionRequest.CurrentStateDefID != CMRActionRequest.States.PreControl)
                {
                    throw new TTException("Bu işlemi önce Ön Kontol adımına getirmeniz gerekmektedir.");
                }
                else
                {
                    this.RequestNO.Enabled = false;
                    this.cmdGetCMRAction.Enabled = false;
                    this.cmdUpdateCMRAction.Enabled =true;
                }
            }
            if (cMRActionRequestList.Count == 0)
                throw new TTException("Bu işlem numaralı Bakım Onarım Kalibrasyon isteği bulunamamıştır");
            if(cMRActionRequestList.Count > 1)
                throw new TTException("Birden fazla işlem bulundu. Bilgi işleme haber verin.");
            }
#endregion CMRActionDataCorrectionForm_cmdGetCMRAction_Click
        }

        protected override void PreScript()
        {
#region CMRActionDataCorrectionForm_PreScript
    base.PreScript();
            this.RequestNO.Text = String.Format("####" + "-" + "####");
            this.cmdUpdateCMRAction.Enabled =false;
#endregion CMRActionDataCorrectionForm_PreScript

            }
                }
}