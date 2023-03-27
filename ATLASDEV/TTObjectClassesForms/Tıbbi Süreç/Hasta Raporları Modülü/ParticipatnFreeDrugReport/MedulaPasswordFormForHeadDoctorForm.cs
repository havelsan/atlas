
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
    public partial class MedulaPasswordFormForHeadDoctor : TTForm
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
#region MedulaPasswordFormForHeadDoctor_cmdPassOK_Click
   TTObjectContext context = _ParticipatnFreeDrugReport.ObjectContext;
            Guid basHekimObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR_OBJECTID", "XXXXXX").ToString());
            // string basHekimObjectID = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR_OBJECTID", "XXXXXX");
            ResUser user = (ResUser)this._ParticipatnFreeDrugReport.ObjectContext.GetObject(basHekimObjectID, typeof(ResUser));
            try
            {
                if (this._ParticipatnFreeDrugReport.IsRepeated.HasValue)
                {
                    if ((bool)this._ParticipatnFreeDrugReport.IsRepeated)
                    {
                        //                        string basHekimObjectID = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR_OBJECTID", "XXXXXX");
                        //                        BindingList<ResUser.GetUserByID_Class> basTabipList = ResUser.GetUserByID(basHekimObjectID);
                        user.ErecetePassword = this.MedulaUserPassword.Text;
                        //  this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword = this.MedulaUserPassword.Text;
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
#endregion MedulaPasswordFormForHeadDoctor_cmdPassOK_Click
        }

        protected override void PreScript()
        {
#region MedulaPasswordFormForHeadDoctor_PreScript
    base.PreScript();
            this.IsRepeated.Value = false;
            this.cmdCancel.Visible = false;
            this.cmdOK.Visible = false;
#endregion MedulaPasswordFormForHeadDoctor_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MedulaPasswordFormForHeadDoctor_PostScript
    base.PostScript(transDef);
#endregion MedulaPasswordFormForHeadDoctor_PostScript

            }
                }
}