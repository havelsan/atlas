
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
    public partial class RadiologyTestBaseForm : SubactionProcedureFlowableForm
    {
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region RadiologyTestBaseForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
#endregion RadiologyTestBaseForm_ClientSidePostScript

        }

#region RadiologyTestBaseForm_ClientSideMethods
        public void DisplayRadiologyRejectReason()
        {
            IList rejectionList = RadiologyRejectReasonDefinition.GetAll(this._RadiologyTest.ObjectContext);
            MultiSelectForm rejectionFrm = new MultiSelectForm();
            int i = 1;
            foreach (RadiologyRejectReasonDefinition reason in rejectionList)
            {
                rejectionFrm.AddMSItem(reason.Name.ToString(), "K-" + i.ToString(), reason);
                i = i + 1;
            }

            string key = rejectionFrm.GetMSItem(null, "Red Nedeni Seçiniz", false, false, false, false, false, true);

            this._RadiologyTest.RejectReason = (RadiologyRejectReasonDefinition)rejectionFrm.MSSelectedItemObject;
        }

        public void DisplayRadiologyRepeatReason()
        {
            IList repeatList = RadiologyRepeatReasonDefinition.GetAll(this._RadiologyTest.ObjectContext);
            MultiSelectForm repeatFrm = new MultiSelectForm();
            int i = 1;
            foreach (RadiologyRepeatReasonDefinition reason in repeatList)
            {
                repeatFrm.AddMSItem(reason.Name.ToString(), "K-" + i.ToString(), reason);
                i = i + 1;
            }
            string key = repeatFrm.GetMSItem(null, "Tekrar Nedeni Seçiniz", false, false, false, false, false, true);
            this._RadiologyTest.RepeatReason = (RadiologyRepeatReasonDefinition)repeatFrm.MSSelectedItemObject;
        }
        
        
        public void LinkRadiologyTestToCopyReportInfo(TTObjectStateTransitionDef transDef)
        {
            
            
            if (!string.IsNullOrEmpty(this._RadiologyTest.ReportTxt))
            {
                MultiSelectForm testFrm = new MultiSelectForm();
                
                if (transDef.FromStateDefID == RadiologyTest.States.ResultEntry || transDef.FromStateDefID == RadiologyTest.States.Approve)
                {
                    
                    foreach (RadiologyTest tetkik in this._RadiologyTest.Radiology.RadiologyTests)
                    {
                        if (this._RadiologyTest != tetkik && tetkik.CurrentStateDefID == transDef.FromStateDefID)
                        {
                            testFrm.AddMSItem(tetkik.ProcedureObject.Code.ToString() + "-" + tetkik.ProcedureObject.Name.ToString(), tetkik.ObjectID.ToString(), (object)tetkik);
                        }
                    }
                }
                
                string key = testFrm.GetMSItem(null, "Sonuç Raporunu kopyalamak istediğiniz tetkikleri seçiniz.", false, false, true, false, false, false);
                if (!string.IsNullOrEmpty(key))
                {
                    //coklu secım yapilabiliyor
                    
                    foreach (RadiologyTest rt in this._RadiologyTest.Radiology.RadiologyTests)
                    {
                        if (testFrm.MSSelectedItems.ContainsKey(rt.ObjectID.ToString()))
                        {
                            //RadiologyTest rt = (RadiologyTest)this._RadiologyTest.ObjectContext.GetObject(new Guid(selectedItem.Key), "RadiologyTest");
                            if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", rt.ID + " no'lu işlem için de aynı rapor kopyalanacak ve bu işlem de Tamam aşamasına alınacaktır.\nDevam etmek istediğinize emin misiniz?") == "E")
                            {
                                rt.Report = this._RadiologyTest.Report;
                                rt.ReportDate = this._RadiologyTest.ReportDate;
                                rt.ReportedBy = this._RadiologyTest.ReportedBy;
                                rt.ReportTxt = this._RadiologyTest.ReportTxt;
                                rt.CurrentStateDefID = RadiologyTest.States.Completed;
                                
                            }
                            else
                                InfoBox.Alert("Sonuç raporu kopyalama işleminden vazgeçildi. Sadece bu tetkik için süreç tamamlanacaktır.", MessageIconEnum.InformationMessage);
                        }
                    }
                }
                else
                    InfoBox.Alert("Sonuç raporu kopyalanacak tetkik seçilmedi. Sadece bu tetkik için süreç tamamlanacaktır.", MessageIconEnum.InformationMessage);
            }
        }
        
#endregion RadiologyTestBaseForm_ClientSideMethods
    }
}