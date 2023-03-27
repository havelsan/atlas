
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
    /// Medula Şifre Giriş
    /// </summary>
    public partial class MedulaPasswordForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdPassOK.Click += new TTControlEventDelegate(cmdPassOK_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdPassOK.Click -= new TTControlEventDelegate(cmdPassOK_Click);
            base.UnBindControlEvents();
        }

        private void cmdPassOK_Click()
        {
#region MedulaPasswordForm_cmdPassOK_Click
   TTObjectContext context = _ParticipatnFreeDrugReport.ObjectContext;
            //   ResUser user = (ResUser)this._ParticipatnFreeDrugReport.ObjectContext.GetObject(Common.CurrentResource.ObjectID, typeof(ResUser));
            try
            {
                if (this._ParticipatnFreeDrugReport.IsRepeated.HasValue)
                {
                    if ((bool)this._ParticipatnFreeDrugReport.IsRepeated)
                    {
                        if (_ParticipatnFreeDrugReport.ReportApprovalType == ReportApproveTypeEnum.ProcedureDoktorApprove)
                            this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword = this.MedulaUserPassword.Text;
                        if (_ParticipatnFreeDrugReport.ReportApprovalType == ReportApproveTypeEnum.SecondDoktorApprove)
                            this._ParticipatnFreeDrugReport.SecondDoctor.ErecetePassword = this.MedulaUserPassword.Text;
                        if (_ParticipatnFreeDrugReport.ReportApprovalType == ReportApproveTypeEnum.ThirdDoktorApprove)
                            this._ParticipatnFreeDrugReport.ThirdDoctor.ErecetePassword = this.MedulaUserPassword.Text;
                    }
                    else
                    {
                        this._ParticipatnFreeDrugReport.MedulaPassword = this.MedulaUserPassword.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex.ToString(), MessageIconEnum.ErrorMessage);
            }

            _ParticipatnFreeDrugReport.IsRepeated = (bool)this.IsRepeated.Value;
            this.DialogResult = DialogResult.OK;
            context.Save();
            // ((ITTObject)user).Refresh();
            this.Close();
#endregion MedulaPasswordForm_cmdPassOK_Click
        }

        protected override void PreScript()
        {
#region MedulaPasswordForm_PreScript
    base.PreScript();
            this.IsRepeated.Value = false;
            this.cmdCancel.Visible = false;
            this.cmdOK.Visible = false;
#endregion MedulaPasswordForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MedulaPasswordForm_PostScript
    base.PostScript(transDef);
#endregion MedulaPasswordForm_PostScript

            }
                }
}