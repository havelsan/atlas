
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
    /// İptal Edilen İhale Bilgileri
    /// </summary>
    public partial class CancelDescriptionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region CancelDescriptionForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(_PurchaseProject.ObjectID, typeof(PurchaseProject));
            if (TTObjectClasses.Common.GetEnumValueDefOfEnumValue(pp.PurchaseMainType).DisplayText.ToString() == "İhale")
            {
                if (transDef != null && transDef.ToStateDefID == PurchaseProject.States.Canceled)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                    objectID.Add("VALUE", _PurchaseProject.ObjectID.ToString());
                    parameters.Add("TTOBJECTID", objectID);

                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_IptalEdilenIhaleKarari), true, 1, parameters);

                    IList proposalList = Proposal.GetProposalledFirms(_PurchaseProject.ObjectID.ToString());
                    IList denyList = PurchaseProjectProposalFirm.GetUnEligibleProposalFirms(_PurchaseProject.ObjectID.ToString());
                    if (proposalList.Count == denyList.Count)
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_IptalEdilenIhaleKarari_TekliflerRed), true, 1, parameters);
                }
            }
        }
        
#endregion CancelDescriptionForm_Methods
    }
}