
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
    /// Reçete Dağıtım
    /// </summary>
    public partial class PrescriptionDistributeApprovalForm : TTForm
    {
        override protected void BindControlEvents()
        {
            tttoolstrip21.ItemClicked += new TTToolStripItemClicked(tttoolstrip21_ItemClicked);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            tttoolstrip21.ItemClicked -= new TTToolStripItemClicked(tttoolstrip21_ItemClicked);
            base.UnBindControlEvents();
        }

        private void tttoolstrip21_ItemClicked(ITTToolStripItem item)
        {
#region PrescriptionDistributeApprovalForm_tttoolstrip21_ItemClicked
   Dictionary<Guid, ExternalPharmacy> externalPharmacyies = new Dictionary<Guid, ExternalPharmacy>();
            foreach(DistributeDetail  distributeDetail in _PrescriptionDistribute.DistributeDetails )
            {
                if (externalPharmacyies.ContainsKey(distributeDetail.ExternalPharmacy.ObjectID) == false)
                    externalPharmacyies.Add(distributeDetail.ExternalPharmacy.ObjectID, distributeDetail.ExternalPharmacy);
            }

            foreach (KeyValuePair<Guid, ExternalPharmacy> pharmacy in externalPharmacyies)
            {
                Guid pharmacyID = pharmacy.Key;
                Guid ObjectID = _PrescriptionDistribute.ObjectID;
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                
                switch (item.Name)
                {
                    case "Yazdır":
                        TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
                        pc.Add("VALUE", _PrescriptionDistribute.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                        parameters.Add("OBJECTID", pc);
                       TTReportTool.PropertyCache<object> pc1 = new TTReportTool.PropertyCache<object>();
                        pc1.Add("VALUE", pharmacyID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                        parameters.Add("PHARMACYID", pc1);
                        TTReportTool.TTReport.PrintReport((typeof(TTReportClasses.I_PrescriptionDistributeReportNew)), true, 1, parameters);
                        TTReportTool.TTReport.PrintReport((typeof(TTReportClasses.I_DetailPrescriptionDistributeReport)), true, 1, parameters);
                        break;
                    default:
                        break;
                }

            }
#endregion PrescriptionDistributeApprovalForm_tttoolstrip21_ItemClicked
        }

        protected override void PreScript()
        {
#region PrescriptionDistributeApprovalForm_PreScript
    base.PreScript();
            if(_PrescriptionDistribute.CurrentStateDefID == PrescriptionDistribute.States.Completed)
            {
                this.tttoolstrip21.ReadOnly=false;
            }
#endregion PrescriptionDistributeApprovalForm_PreScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region PrescriptionDistributeApprovalForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if(transDef.ToStateDefID == PrescriptionDistribute.States.Completed)
            {
                Dictionary<Guid, ExternalPharmacy> externalPharmacyies = new Dictionary<Guid, ExternalPharmacy>();
                foreach (DistributeDetail distributeDetail in _PrescriptionDistribute.DistributeDetails)
                {
                    if (externalPharmacyies.ContainsKey(distributeDetail.ExternalPharmacy.ObjectID) == false)
                        externalPharmacyies.Add(distributeDetail.ExternalPharmacy.ObjectID, distributeDetail.ExternalPharmacy);
                }
                
                foreach (KeyValuePair<Guid, ExternalPharmacy> pharmacy in externalPharmacyies)
                {
                    Guid pharmacyID = pharmacy.Key;
                    Guid ObjectID = _PrescriptionDistribute.ObjectID;
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    
                    TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
                    pc.Add("VALUE", _PrescriptionDistribute.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("OBJECTID", pc);
                    TTReportTool.PropertyCache<object> pc1 = new TTReportTool.PropertyCache<object>();
                    pc1.Add("VALUE", pharmacyID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("PHARMACYID", pc1);
                    TTReportTool.TTReport.PrintReport((typeof(TTReportClasses.I_PrescriptionDistributeReportNew)), true, 1, parameters);
                }
            }
#endregion PrescriptionDistributeApprovalForm_ClientSidePostScript

        }
    }
}