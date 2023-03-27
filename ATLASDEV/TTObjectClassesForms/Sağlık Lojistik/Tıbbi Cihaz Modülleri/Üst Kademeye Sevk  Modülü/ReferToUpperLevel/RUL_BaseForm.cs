
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
    public partial class RUL_BaseForm : TTForm
    {
        override protected void BindControlEvents()
        {
            tttoolstrip1.ItemClicked += new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            tttoolstrip1.ItemClicked -= new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            base.UnBindControlEvents();
        }

        private void tttoolstrip1_ItemClicked(ITTToolStripItem item)
        {
#region RUL_BaseForm_tttoolstrip1_ItemClicked
   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
            
            switch(item.Name)
            {
                case "ShowRelatedRepair":

                    this.ShowRelatedRepairModule();
                    break;
                    
                case "HasarveDurumTespitRaporu":
                    pc.Add("VALUE", _ReferToUpperLevel.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HasarveDurumTespitRaporu),true,1,parameters);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HasarveDurumTespitRaporu2),true,1,parameters);
                    break;
                    
                case "BakimOnarimMalzemeEtiketi":
                    pc.Add("VALUE", _ReferToUpperLevel.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_BakimOnarimMalzemeEtiketi),true,1,parameters);
                    break;
                    
                case "Tutanak_TeknikMudurlukTeslimi":
                    pc.Add("VALUE", _ReferToUpperLevel.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_Tutanak_TeknikMudurlukTeslimi),true,1,parameters);
                    break;
                    
                case "Tutanak_IkmalMudurlukTeslimi":
                    pc.Add("VALUE", _ReferToUpperLevel.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_Tutanak_IkmalMudurlukTeslimi),true,1,parameters);
                    break;
                case "KayitSilmeyeEsasTeknikRapor":
                    bool yazdir = false;
                    
                    if(_ReferToUpperLevel.RULHekCommisionMembers.Count >0)
                    {
                        if(_ReferToUpperLevel.RULHEKReasons.Count >0)
                        {
                            foreach(RULHEKReason reason in _ReferToUpperLevel.RULHEKReasons)
                            {
                                if((bool)reason.Check)
                                    yazdir = true;
                            }
                        }
                    }
                    if(yazdir)
                    {
                        pc.Add("VALUE", _ReferToUpperLevel.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                        parameters.Add("TTOBJECTID", pc);
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_KayitSilmeyeEsasTeknikRaporRUL),true,1,parameters);
                    }
                    else
                        throw new TTException ("Hek bilgileri doldurulmamıştır.");
                    break;
                default:
                    break;
            }
#endregion RUL_BaseForm_tttoolstrip1_ItemClicked
        }

        protected override void PreScript()
        {
#region RUL_BaseForm_PreScript
    base.PreScript();
            
            if(ReferToUpperLevel.States.FirstExamination != _ReferToUpperLevel.CurrentStateDefID)
            {
                tttoolstrip1.Items["ReportMenu"].Visible = false;
                tttoolstrip1.Items["tttoolstripseparator1"].Visible = false;
            }
#endregion RUL_BaseForm_PreScript

            }
            
#region RUL_BaseForm_ClientSideMethods
        public void ShowRelatedRepairModule()
        {
            //TODO:ShowEdit!
            //ReferToUpperLevel RUL = _ReferToUpperLevel;
            //if (RUL.RepairObjectID != null)
            //{
            //    Guid Repguid = new Guid(RUL.RepairObjectID);
            //    Repair rep = (Repair)RUL.ObjectContext.GetObject(Repguid, "REPAIR");
            //    UpperStageForm upf = new UpperStageForm();
            //    upf.ShowReadOnly(this.FindForm(),rep);
            //}
            //else
            //{
            //    InfoBox.Show("Bu sevke bağlı onarım işlemi bulunmamaktadır", MessageIconEnum.InformationMessage);
            //}
            var a = 1;
        }
        
#endregion RUL_BaseForm_ClientSideMethods
    }
}