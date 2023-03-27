
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
    /// Prosedür
    /// </summary>
    public partial class RadiologyTestProcedureForm : RadiologyTestBaseForm
    {
        override protected void BindControlEvents()
        {
            cmdPrntRequestNo.Click += new TTControlEventDelegate(cmdPrntRequestNo_Click);
            cmdSendPACS.Click += new TTControlEventDelegate(cmdSendPACS_Click);
            buttonOpenTeleTipResults.Click += new TTControlEventDelegate(buttonOpenTeleTipResults_Click);
            ttbuttonToothSchema.Click += new TTControlEventDelegate(ttbuttonToothSchema_Click);
            Materials.CellContentClick += new TTGridCellEventDelegate(Materials_CellContentClick);
            GridEpisodeDiagnosis.CellContentClick += new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            ttPrintRequestBarcode.Click += new TTControlEventDelegate(ttPrintRequestBarcode_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdPrntRequestNo.Click -= new TTControlEventDelegate(cmdPrntRequestNo_Click);
            cmdSendPACS.Click -= new TTControlEventDelegate(cmdSendPACS_Click);
            buttonOpenTeleTipResults.Click -= new TTControlEventDelegate(buttonOpenTeleTipResults_Click);
            ttbuttonToothSchema.Click -= new TTControlEventDelegate(ttbuttonToothSchema_Click);
            Materials.CellContentClick -= new TTGridCellEventDelegate(Materials_CellContentClick);
            GridEpisodeDiagnosis.CellContentClick -= new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            ttPrintRequestBarcode.Click -= new TTControlEventDelegate(ttPrintRequestBarcode_Click);
            base.UnBindControlEvents();
        }

        private void cmdPrntRequestNo_Click()
        {
            /*
#region RadiologyTestProcedureForm_cmdPrntRequestNo_Click
   RadiologyTest.PrintRadiologyRequestBarcode(this._RadiologyTest);
#endregion RadiologyTestProcedureForm_cmdPrntRequestNo_Click */
        }

        private void cmdSendPACS_Click()
        {
            RadiologyTest.SendRadiologyTestToPACS(this._RadiologyTest);
        }

        private void buttonOpenTeleTipResults_Click()
        {
#region RadiologyTestProcedureForm_buttonOpenTeleTipResults_Click
   //Teletip username password ile replace edilecek , commentout lu kisim acilacak
            // Test guid
            System.Diagnostics.Process.Start("http://xxxxxx.com/?GUID=82d1824f-3117-44e2-82f6-004466b148f4");
            
            
            
            
            //            string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
            //            string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
//
            //            string patientidentification =   this._RadiologyTest.Episode.Patient.UniqueRefNo.ToString();
//
            //            if (this._RadiologyTest.Radiology.RequestDoctor != null)
            //            {
            //                string doctoridentification = this._RadiologyTest.Radiology.RequestDoctor.Person.UniqueRefNo.ToString();
            //                string guidLink = TeletipGuidServis.WebMethods.CreateGuidWithTcNoAndAccNoSync(Sites.SiteLocalHost , userName , password ,
            //                                                                                              doctoridentification ,
            //                                                                                              patientidentification ,
            //                                                                                              "","");
            //                System.Diagnostics.Process.Start("http://xxxxxx.com/?GUID="+guidLink);
            //            }
            //            else{
            //                throw new Exception("Doktor bilgisi olmadığından işleme devam edilemiyor");
            //            }
#endregion RadiologyTestProcedureForm_buttonOpenTeleTipResults_Click
        }

        private void ttbuttonToothSchema_Click()
        {
            #region RadiologyTestProcedureForm_ttbuttonToothSchema_Click
            //TODO:ShowEdit!
            //RadiologyTestDentalToothSchema radiologyTestDentalForm = new RadiologyTestDentalToothSchema();
            //         if (radiologyTestDentalForm != null)
            //             radiologyTestDentalForm.ShowReadOnly(this,_RadiologyTest);
            var a = 1;
            #endregion RadiologyTestProcedureForm_ttbuttonToothSchema_Click
        }

        private void Materials_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region RadiologyTestProcedureForm_Materials_CellContentClick
            //TODO:ShowEdit!
            //if (((ITTGridCell)Materials.CurrentCell).OwningColumn.Name == "malzemeCokluOzelDurum")
            //{

            //    RadiologyTestCokluOzelDurum rtcod = new RadiologyTestCokluOzelDurum();
            //    rtcod.ShowEdit(this.FindForm(), this._RadiologyTest);
            //}
            var a = 1;
            #endregion RadiologyTestProcedureForm_Materials_CellContentClick
        }

        private void GridEpisodeDiagnosis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region RadiologyTestProcedureForm_GridEpisodeDiagnosis_CellContentClick
            //TODO:ShowEdit!
            //if (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn.Name == "taniCokluOzelDurum")
            //{

            //    RadiologyTestCokluOzelDurum rtcod = new RadiologyTestCokluOzelDurum();
            //    rtcod.ShowEdit(this.FindForm(), this._RadiologyTest);
            //}
            var a = 1;
            #endregion RadiologyTestProcedureForm_GridEpisodeDiagnosis_CellContentClick
        }

        private void ttPrintRequestBarcode_Click()
        {
#region RadiologyTestProcedureForm_ttPrintRequestBarcode_Click
   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
            cache.Add("VALUE", this._RadiologyTest.ObjectID);
            parameters.Add("TTOBJECTID", cache);
            
         
            if(this.ttBarcodePreviewCheck.Value == true)
            {
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_RadiologyRequestBarcode), true, 1, parameters);
            }
            else
            {
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_RadiologyRequestBarcode), false, 1, parameters);
            }
#endregion RadiologyTestProcedureForm_ttPrintRequestBarcode_Click
        }

        protected override void PreScript()
        {
#region RadiologyTestProcedureForm_PreScript
    base.PreScript();
#endregion RadiologyTestProcedureForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region RadiologyTestProcedureForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["RadiologyMaterial"], (ITTGridColumn)this.Materials.Columns["Material"]);
            this.DropStateButton(RadiologyTest.States.Completed);
            this.DropStateButton(RadiologyTest.States.AdmissionAppointment);
            if (this._RadiologyTest.IsMessageInPACS == false)
                this.cmdSendPACS.Visible = true;

            //foreach(Appointment app in this._RadiologyTest.MyNewAppointments)
            //    this.AppointmentDesc.Text += app.Notes;
            
            
            ITTGridColumn directPurchaseDetailColumn = (ITTGridColumn)this.SurgeryDirectPurchaseGrids.Columns["DPADetailFirmPriceOffer"];
            
            string filterString = "";
            if(this._RadiologyTest.Episode.Patient != null)
                filterString = "DIRECTPURCHASEACTIONDETAIL.DIRECTPURCHASEACTION.PATIENT = '" + this._RadiologyTest.Episode.Patient.ObjectID.ToString() + "'";
            ((ITTListBoxColumn)directPurchaseDetailColumn).ListFilterExpression = filterString;
            
            
            MultiSelectForm msItem = new MultiSelectForm();

            IList<DPADetailFirmPriceOffer> dPADetailFirmPriceOffers = (IList<DPADetailFirmPriceOffer>) TTObjectClasses.DPADetailFirmPriceOffer.GetUnsedAndApproved22FMaterialByPatient(_RadiologyTest.ObjectContext, this._RadiologyTest.Episode.Patient.ObjectID);
            foreach (DPADetailFirmPriceOffer dPADetailFirmPriceOffer in dPADetailFirmPriceOffers)
            {
                if(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTCode != null && string.IsNullOrEmpty(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTCode.SUTCode) == false && string.IsNullOrEmpty(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName) == false)
                    msItem.AddMSItem(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTCode.SUTCode + " " + dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName, dPADetailFirmPriceOffer.ObjectID.ToString());
                else if(string.IsNullOrEmpty(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName) == false)
                    msItem.AddMSItem(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName, dPADetailFirmPriceOffer.ObjectID.ToString());
            }
            
            string key = msItem.GetMSItem(null,"Hastanın 22F Malzemesi Bulunmakta, Kullanmak İstediklerinizi Seçiniz", false, false, true);
            if (!string.IsNullOrEmpty(key))
            {
                foreach (string sp in msItem.MSSelectedItems.Keys)
                {
                    //  createSubProcedure = true;
                    SurgeryDirectPurchaseGrid sdp = new SurgeryDirectPurchaseGrid(_RadiologyTest.ObjectContext);
                    DPADetailFirmPriceOffer dpa = (DPADetailFirmPriceOffer)_RadiologyTest.ObjectContext.GetObject(new Guid(sp),"DPADetailFirmPriceOffer");
                    sdp.DPADetailFirmPriceOffer = dpa;
                    _RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids.Add(sdp);

                }
            }
#endregion RadiologyTestProcedureForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region RadiologyTestProcedureForm_PostScript
    base.PostScript(transDef);

         //Asagıdakı kontrol clıentsıde postscrıpte tasındı.
            /* bool hasMaterial = false;
            if (Materials.Rows.Count > 0)
            {
                foreach (ITTGridRow row in Materials.Rows)
                    if (row.Cells["Amount"].Value != null)
                    hasMaterial = true;
            }
            if (!hasMaterial)
            {
                string result = Show Box.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Malzeme seçmediniz. Devam etmek istediğinize emin misiniz?", 1);
                if (result == "H")
                {
                    String message = SystemMessage.GetMessage(488);
                    throw new TTUtils.TTException(message);

                }
            }
            */
            
             if(_RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids.Count > 0)
            {
                List<DPADetailFirmPriceOffer> materials = new List<DPADetailFirmPriceOffer>();
                foreach(SurgeryDirectPurchaseGrid sdg in _RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids)
                {
                    if(materials.Contains(sdg.DPADetailFirmPriceOffer))
                        throw new TTException("Aynı Malzemeyi Birden Fazla Giremezsiniz ! ");
                    else
                        materials.Add(sdg.DPADetailFirmPriceOffer);
                }
            }
            
            if(transDef != null)
            {
                if(transDef.ToStateDefID == RadiologyTest.States.Completed || transDef.ToStateDefID == RadiologyTest.States.Approve || transDef.ToStateDefID == RadiologyTest.States.ResultEntry)
                {
                    foreach (SurgeryDirectPurchaseGrid sdg in this._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids)
                    {
                        SubActionMatPricingDet titubbPrice = new SubActionMatPricingDet(this._RadiologyTest.ObjectContext);
                        titubbPrice.PatientPrice = 0;
                        titubbPrice.SubActionMaterial = sdg;

                        if (sdg.DPADetailFirmPriceOffer != null && sdg.DPADetailFirmPriceOffer.OfferedSUTCode != null)
                        {
                            titubbPrice.ExternalCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTCode;
                            titubbPrice.Description = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTName;
                            titubbPrice.PayerPrice = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTPrice;
                        }
                        //                else
                        //                {
                        //                    titubbPrice.ExternalCode = "KODSUZ";
                        //                    titubbPrice.Description = productDefinition.Name;
                        //                    titubbPrice.PayerPrice = 0;
                        //                }
                        titubbPrice.ProductDefinition = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product;
                    }
                }
            }
            
            
            Guid malzemeObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("22F_MALZEMEOBJECTID", Guid.Empty.ToString()));
            foreach (SurgeryDirectPurchaseGrid sdg in this._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids)
            {
                sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = true;
                sdg.Material = (Material)this._RadiologyTest.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
                sdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product != null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
                sdg.Amount = sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
                
            }
#endregion RadiologyTestProcedureForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region RadiologyTestProcedureForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            bool hasMaterial = false;
            if (Materials.Rows.Count > 0)
            {
                foreach (ITTGridRow row in Materials.Rows)
                    if (row.Cells["Amount"].Value != null)
                    hasMaterial = true;
            }
            if (!hasMaterial)
            {
                string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Malzeme seçmediniz. Devam etmek istediğinize emin misiniz?", 1);
                if (result == "H")
                {
                    String message = SystemMessage.GetMessage(488);
                    throw new TTUtils.TTException(message);

                }
            }
            
            
            if (transDef != null)
            {
                if (transDef.FromStateDefID == RadiologyTest.States.Procedure  &&  transDef.ToStateDefID  == RadiologyTest.States.Reject)
                    DisplayRadiologyRejectReason();
            }
#endregion RadiologyTestProcedureForm_ClientSidePostScript

        }

#region RadiologyTestProcedureForm_Methods
        /*
        bool dontCloseForm = false;
        
        protected override void OnObjectUpdated(TTObject ttObject)
        {
            if(dontCloseForm)
            {
                ITTObject obj = (ITTObject)ttObject;
                ttObject.ObjectContext.Update();
                obj.UndoLastTransition();
                return;
            }
            base.OnObjectUpdated(ttObject);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = dontCloseForm;
            dontCloseForm = false;
            base.OnFormClosing(e);
        }

        protected override void OnOkClick(TTObjectStateTransitionDef transDef)
        {
            dontCloseForm = false;
            bool hasMaterial = false;
            if(transDef != null && transDef.ToStateDefID != RadiologyTest.States.Reject)
            {
                if(Materials.Rows.Count > 0)
                {
                    foreach(ITTGridRow row in Materials.Rows)
                        if(row.Cells["Amount"].Value != null)
                        hasMaterial = true;
                }
                if(!hasMaterial)
                {
                    string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Uyarı","Malzeme seçmediniz. Devam etmek istediğinize emin misiniz?",1);
                    if (result == "H")
                    {
                        dontCloseForm = true;
                        return;
                    }
                }
            }
            base.OnOkClick(transDef);
            
        }
        */
        
#endregion RadiologyTestProcedureForm_Methods
    }
}