
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
    /// Onarım Sarf Giriş İptal 
    /// </summary>
    public partial class CMRActionConsCancelNewForm : ActionForm
    {
        override protected void BindControlEvents()
        {
            cmdConsDetail.Click += new TTControlEventDelegate(cmdConsDetail_Click);
            cmdFindCMRAction.Click += new TTControlEventDelegate(cmdFindCMRAction_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdConsDetail.Click -= new TTControlEventDelegate(cmdConsDetail_Click);
            cmdFindCMRAction.Click -= new TTControlEventDelegate(cmdFindCMRAction_Click);
            base.UnBindControlEvents();
        }

        private void cmdConsDetail_Click()
        {
#region CMRActionConsCancelNewForm_cmdConsDetail_Click
   if (_CMRActionConsCancel.CMRAction is Repair)
            {
                foreach (UsedConsumedMaterail usedConsumedMaterail in ((Repair)_CMRActionConsCancel.CMRAction).UsedConsumedMaterails)
                {
                    if(usedConsumedMaterail.CurrentStateDefID == UsedConsumedMaterail.States.Completed)
                    {
                        CMRActionConsCancelDetail cmrActionConsCancelDetail = new CMRActionConsCancelDetail(_CMRActionConsCancel.ObjectContext);
                        cmrActionConsCancelDetail.DetailCancel = false;
                        cmrActionConsCancelDetail.UsedConsumedMaterail = usedConsumedMaterail;
                        cmrActionConsCancelDetail.CMRActionConsCancel = _CMRActionConsCancel;
                    }
                }
            }
            else if (_CMRActionConsCancel.CMRAction is MaterialRepair)
            {
                foreach (UsedConsumedMaterail usedConsumedMaterail in ((MaterialRepair)_CMRActionConsCancel.CMRAction).UsedConsumedMaterails)
                {
                    if(usedConsumedMaterail.CurrentStateDefID == UsedConsumedMaterail.States.Completed)
                    {

                        CMRActionConsCancelDetail cmrActionConsCancelDetail = new CMRActionConsCancelDetail(_CMRActionConsCancel.ObjectContext);
                        cmrActionConsCancelDetail.DetailCancel = false;
                        cmrActionConsCancelDetail.UsedConsumedMaterail = usedConsumedMaterail;
                        cmrActionConsCancelDetail.CMRActionConsCancel = _CMRActionConsCancel;
                    }
                }
            }
            else if (_CMRActionConsCancel.CMRAction is MaintenanceOrder)
            {
                foreach (UsedConsumedMaterail usedConsumedMaterail in ((MaintenanceOrder)_CMRActionConsCancel.CMRAction).UsedConsumedMaterails)
                {
                    if(usedConsumedMaterail.CurrentStateDefID == UsedConsumedMaterail.States.Completed)
                    {

                        CMRActionConsCancelDetail cmrActionConsCancelDetail = new CMRActionConsCancelDetail(_CMRActionConsCancel.ObjectContext);
                        cmrActionConsCancelDetail.DetailCancel = false;
                        cmrActionConsCancelDetail.UsedConsumedMaterail = usedConsumedMaterail;
                        cmrActionConsCancelDetail.CMRActionConsCancel = _CMRActionConsCancel;
                    }
                }
            }
            else if (_CMRActionConsCancel.CMRAction is WorkStep)
            {
                foreach (UsedConsumedMaterail usedConsumedMaterail in ((WorkStep)_CMRActionConsCancel.CMRAction).UsedConsumedMaterails)
                {
                    if(usedConsumedMaterail.CurrentStateDefID == UsedConsumedMaterail.States.Completed)
                    {

                        CMRActionConsCancelDetail cmrActionConsCancelDetail = new CMRActionConsCancelDetail(_CMRActionConsCancel.ObjectContext);
                        cmrActionConsCancelDetail.DetailCancel = false;
                        cmrActionConsCancelDetail.UsedConsumedMaterail = usedConsumedMaterail;
                        cmrActionConsCancelDetail.CMRActionConsCancel = _CMRActionConsCancel;
                    }
                }
            }
            else if (_CMRActionConsCancel.CMRAction is PackagingDepartmentAction)
            {
                foreach (UsedConsumedMaterail usedConsumedMaterail in ((PackagingDepartmentAction)_CMRActionConsCancel.CMRAction).UsedConsumedMaterails)
                {
                    if(usedConsumedMaterail.CurrentStateDefID == UsedConsumedMaterail.States.Completed)
                    {

                        CMRActionConsCancelDetail cmrActionConsCancelDetail = new CMRActionConsCancelDetail(_CMRActionConsCancel.ObjectContext);
                        cmrActionConsCancelDetail.DetailCancel = false;
                        cmrActionConsCancelDetail.UsedConsumedMaterail = usedConsumedMaterail;
                        cmrActionConsCancelDetail.CMRActionConsCancel = _CMRActionConsCancel;
                    }
                }
            }
            else
            {
                InfoBox.Show("Bu işlemde malzeme girilemez");
                this.CMRActionRequestNo.ReadOnly = false;
                this.cmdFindCMRAction.ReadOnly = false;
            }
            this.cmdConsDetail.ReadOnly = true;
#endregion CMRActionConsCancelNewForm_cmdConsDetail_Click
        }

        private void cmdFindCMRAction_Click()
        {
#region CMRActionConsCancelNewForm_cmdFindCMRAction_Click
   IList cmrActions = CMRAction.GetCMRActionByRequestNo(_CMRActionConsCancel.ObjectContext, _CMRActionConsCancel.CMRActionRequestNo);
            MultiSelectForm multiSelectForm = new MultiSelectForm();
            foreach (CMRAction cmr in cmrActions)
            {
                string descriptionText = cmr.ObjectDef.DisplayText + " - " + cmr.CurrentStateDef.DisplayText ;
                multiSelectForm.AddMSItem(descriptionText , descriptionText , cmr);
            }
            
            string key = multiSelectForm.GetMSItem(ParentForm, "İşlem yapacağınız işlemi seçin");

            if (string.IsNullOrEmpty(key))
                throw new Exception("İşlem seçilmedi.");

            _CMRActionConsCancel.CMRAction = multiSelectForm.MSSelectedItemObject as CMRAction;
            _CMRActionConsCancel.Description = key ;
            this.CMRActionRequestNo.ReadOnly = true;
            this.cmdFindCMRAction.ReadOnly = true;
            this.cmdConsDetail.ReadOnly = false;
#endregion CMRActionConsCancelNewForm_cmdFindCMRAction_Click
        }
    }
}