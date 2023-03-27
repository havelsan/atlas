
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
    /// Hemşirelik İşlemleri 
    /// </summary>
    public partial class NursingApplicationForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            TabSubaction.SelectedTabChanged += new TTControlEventDelegate(TabSubaction_SelectedTabChanged);
            OrderDetails.CellDoubleClick += new TTGridCellEventDelegate(OrderDetails_CellDoubleClick);
            tttakeintakeoutdate2.ValueChanged += new TTControlEventDelegate(tttakeintakeoutdate2_ValueChanged);
            tttakeintakeoutdate1.ValueChanged += new TTControlEventDelegate(tttakeintakeoutdate1_ValueChanged);
            TakeInTakeOuts.CellValueChanged += new TTGridCellEventDelegate(TakeInTakeOuts_CellValueChanged);
            WaterlowRisks.CellValueChanged += new TTGridCellEventDelegate(WaterlowRisks_CellValueChanged);
            ShowPubilExample.Click += new TTControlEventDelegate(ShowPubilExample_Click);
            GlaskowComaScales.CellValueChanged += new TTGridCellEventDelegate(GlaskowComaScales_CellValueChanged);
            //FallingDownRisks.CellValueChanged += new TTGridCellEventDelegate(FallingDownRisks_CellValueChanged);
            DrugOrderDetails.CellDoubleClick += new TTGridCellEventDelegate(DrugOrderDetails_CellDoubleClick);
            getSurgerySablonButton.Click += new TTControlEventDelegate(getSurgerySablonButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            TabSubaction.SelectedTabChanged -= new TTControlEventDelegate(TabSubaction_SelectedTabChanged);
            OrderDetails.CellDoubleClick -= new TTGridCellEventDelegate(OrderDetails_CellDoubleClick);
            tttakeintakeoutdate2.ValueChanged -= new TTControlEventDelegate(tttakeintakeoutdate2_ValueChanged);
            tttakeintakeoutdate1.ValueChanged -= new TTControlEventDelegate(tttakeintakeoutdate1_ValueChanged);
            TakeInTakeOuts.CellValueChanged -= new TTGridCellEventDelegate(TakeInTakeOuts_CellValueChanged);
            WaterlowRisks.CellValueChanged -= new TTGridCellEventDelegate(WaterlowRisks_CellValueChanged);
            ShowPubilExample.Click -= new TTControlEventDelegate(ShowPubilExample_Click);
            GlaskowComaScales.CellValueChanged -= new TTGridCellEventDelegate(GlaskowComaScales_CellValueChanged);
            //FallingDownRisks.CellValueChanged -= new TTGridCellEventDelegate(FallingDownRisks_CellValueChanged);
            DrugOrderDetails.CellDoubleClick -= new TTGridCellEventDelegate(DrugOrderDetails_CellDoubleClick);
            getSurgerySablonButton.Click -= new TTControlEventDelegate(getSurgerySablonButton_Click);
            base.UnBindControlEvents();
        }

        private void TabSubaction_SelectedTabChanged()
        {
#region NursingApplicationForm_TabSubaction_SelectedTabChanged
   this.GetTakeinTakeOuts();
#endregion NursingApplicationForm_TabSubaction_SelectedTabChanged
        }

        private void OrderDetails_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region NursingApplicationForm_OrderDetails_CellDoubleClick
   //            if (rowIndex < this.OrderDetails.Rows.Count && rowIndex>-1)
//            {
//                Guid actionID =(Guid)(((ITTGridRow)this.OrderDetails.Rows[rowIndex]).TTObject).ObjectID;
//                TTObjectContext objectContext = new TTObjectContext(false);
//                
//                try
//                {
//                    NursingOrderDetail  nursingOrderDetail = (NursingOrderDetail)(objectContext.GetObject(actionID, typeof(NursingOrderDetail)));
//                    TTForm frm = TTForm.GetEditForm(nursingOrderDetail);
//                    if (frm == null)
//                    {
//                        MessageBox.Show(nursingOrderDetail.CurrentStateDef.Name + " isimli adım için form tanımı yapılmadığından işlem açılamamaktadır");
//                    }
//                    frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
//                    frm.ShowEdit(this.FindForm(),nursingOrderDetail);
//                }
//                catch (System.Exception ex)
//                {
//                    InfoBox.Show(ex);
//                }
//                finally
//                {
//                    objectContext.Dispose();
//                }
//                
//            }
#endregion NursingApplicationForm_OrderDetails_CellDoubleClick
        }

        private void tttakeintakeoutdate2_ValueChanged()
        {
#region NursingApplicationForm_tttakeintakeoutdate2_ValueChanged
   this.GetTakeinTakeOuts();
#endregion NursingApplicationForm_tttakeintakeoutdate2_ValueChanged
        }

        private void tttakeintakeoutdate1_ValueChanged()
        {
#region NursingApplicationForm_tttakeintakeoutdate1_ValueChanged
   this.GetTakeinTakeOuts();
#endregion NursingApplicationForm_tttakeintakeoutdate1_ValueChanged
        }

        private void TakeInTakeOuts_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region NursingApplicationForm_TakeInTakeOuts_CellValueChanged
   string name=TakeInTakeOuts.CurrentCell.OwningColumn.Name;
            if(name == "HourInterval")
            {
                if (rowIndex < this.TakeInTakeOuts.Rows.Count && rowIndex > -1)
                {
                    ITTGridRow pCurrentRow = this.TakeInTakeOuts.Rows[rowIndex];
                    if((int)pCurrentRow.Cells["HourInterval"].Value>0)
                    {
                        int addHour = (int)pCurrentRow.Cells["HourInterval"].Value;
                        if(addHour== 24)
                            addHour = 0;
                        pCurrentRow.Cells["ttactiondate"].Value =  ((DateTime)pCurrentRow.Cells["ttactiondate"].Value).Date.AddHours(addHour);
                        this.GetTakeinTakeOuts();
                    }
                }
            }
#endregion NursingApplicationForm_TakeInTakeOuts_CellValueChanged
        }

        private void WaterlowRisks_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region NursingApplicationForm_WaterlowRisks_CellValueChanged
   if(WaterlowRisks.CurrentCell.OwningColumn.Name != "RiskScore" && WaterlowRisks.CurrentCell.OwningColumn.Name != "WaterlowActionDate" )
            {
                if (rowIndex < this.WaterlowRisks.Rows.Count && rowIndex > -1)
                {
                    NursingWaterlowRisk nursingWaterlowRisk = (NursingWaterlowRisk)((ITTGridRow)WaterlowRisks.Rows[rowIndex]).TTObject;
                    NursingWaterlowRisk.CalcWaterlowRiskScore(nursingWaterlowRisk);
                }
            }
#endregion NursingApplicationForm_WaterlowRisks_CellValueChanged
        }

        private void ShowPubilExample_Click()
        {
#region NursingApplicationForm_ShowPubilExample_Click
   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.TTReport.PrintReport(this,typeof(TTReportClasses.I_NursingPupilExample), true,0, parameters);
#endregion NursingApplicationForm_ShowPubilExample_Click
        }

        private void GlaskowComaScales_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region NursingApplicationForm_GlaskowComaScales_CellValueChanged
   if(GlaskowComaScales.CurrentCell.OwningColumn.Name == "OralAnswer" || GlaskowComaScales.CurrentCell.OwningColumn.Name == "MotorAnswer" || GlaskowComaScales.CurrentCell.OwningColumn.Name == "Eyes" )
            {
                if (rowIndex < this.GlaskowComaScales.Rows.Count && rowIndex > -1)
                {
                    NursingGlaskowComaScale nursingGlaskowComaScales = (NursingGlaskowComaScale)((ITTGridRow)GlaskowComaScales.Rows[rowIndex]).TTObject;
                    NursingGlaskowComaScale.CalcGlaskowComaScaleTotalScore(nursingGlaskowComaScales);
                }
            }
#endregion NursingApplicationForm_GlaskowComaScales_CellValueChanged
        }

        private void FallingDownRisks_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region NursingApplicationForm_FallingDownRisks_CellValueChanged
   //string name=FallingDownRisks.CurrentCell.OwningColumn.Name;
   //         if(name == "StandUpTest" || name == "RiskFactor" )
   //         {
   //             if (rowIndex < this.FallingDownRisks.Rows.Count && rowIndex > -1)
   //             {
   //                 NursingFallingDownRisk nursingFallingDownRisk = (NursingFallingDownRisk)((ITTGridRow)FallingDownRisks.Rows[rowIndex]).TTObject;
   //                 NursingFallingDownRisk.CalcFallingDownRiskTotalScore(nursingFallingDownRisk);
   //             }
   //         }
#endregion NursingApplicationForm_FallingDownRisks_CellValueChanged
        }

        private void DrugOrderDetails_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region NursingApplicationForm_DrugOrderDetails_CellDoubleClick
   //            if (this.DrugOrderDetails.Rows.Count>0)
//            {
//                for ( int i=0;i<this.DrugOrderDetails.Rows.Count;i++)
//                {
//                    DrugOrderDetail drugOrderDetail = (DrugOrderDetail)((ITTGridRow)this.DrugOrderDetails.Rows[i]).TTObject;
//                    foreach (ITTGridCell currentCell in this.DrugOrderDetails.Rows[i].Cells)
//                    {
//                        currentCell.ReadOnly = true;
//                        
//                        if (currentCell.OwningColumn.Name == "Material")
//                        {
//                            DrugDefinition drugDefinition = ((DrugDefinition)drugOrderDetail.Material);
//                            bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
//                            double restDose = DrugOrderTransaction.GetRestDose(drugOrderDetail.DrugOrder);
//                            double dose = 0;
//
//                            if (restDose > 0)
//                            {
//                                dose = restDose;
//                            }
//                            else
//                            {
//                                Dictionary<object, double> patientRestDictionary = DrugOrderTransaction.GetPatientRestDose(drugOrderDetail.Material, drugOrderDetail.Episode);
//                                foreach (KeyValuePair<object, double> restDic in patientRestDictionary)
//                                {
//                                    dose += (double)restDic.Value;
//                                }
//                            }
//                            this.DrugOrderDetails.Rows[i].Cells["RestDose"].Value = dose.ToString();
//                            switch (drugOrderDetail.CurrentStateDefID.Value.ToString())
//                            {
//                                case "d39a37a6-610e-4143-aca2-691ce5818915":
//                                    // drugOrderDetail.Stage = "Uygulandı";
//                                    this.DrugOrderDetails.Rows[i].Cells["Stage"].Value =  "Uygulandı";
//                                    break;
//                                case "add6e452-c007-4849-b477-17d30400abe8":
//                                    drugOrderDetail.Stage = "Uygulama İptal Edildi!";
//                                    break;
//                                default:
//                                    throw new TTException(" Lütfen sistem yöneticisine başvurun!!");
//                            }
//                        }
//                    }
//                }
//            }
            
            
            
            
            
            
            
            
            
            //            if (rowIndex < this.DrugOrderDetails.Rows.Count && rowIndex>-1)
            //            {
            //                Guid actionID =(Guid)(((ITTGridRow)this.DrugOrderDetails.Rows[rowIndex]).TTObject).ObjectID;
            //                TTObjectContext objectContext = new TTObjectContext(false);//bu silinecek
            //                try
            //                {
            //                    DrugOrderDetail  drugOrderDetail = (DrugOrderDetail)(this._NursingApplication.ObjectContext.GetObject(actionID, typeof(DrugOrderDetail)));
            //                    TTForm frm = TTForm.GetEditForm(drugOrderDetail);
            //                    if (frm == null)
            //                    {
            //                        MessageBox.Show(drugOrderDetail.CurrentStateDef.Name + " isimli adım için form tanımı yapılmadığından işlem açılamamaktadır");
            //                    }
            //                   //frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
//
//
            //                    switch (drugOrderDetail.CurrentStateDefID.Value.ToString())
            //                    {
            //                        case "cb22e74b-a2be-456f-8680-660d0b21dc24":
            //                            drugOrderDetail.Stage = "Eczaneden İstenmedi!";
            ////                            frm.DropStateButton(DrugOrderDetail.States.Request);
            ////                            frm.DropStateButton(DrugOrderDetail.States.UseRestDose);
            ////                            frm.DropStateButton(DrugOrderDetail.States.Apply);
            //                            break;
            //                        case "da01e671-efb9-4d84-8122-4bae07e08c20":
            //                            drugOrderDetail.Stage = "Eczaneden İstendi Henüz Karşılanmadı!";
            ////                            frm.DropStateButton(DrugOrderDetail.States.Supply);
            //                            break;
            //                        case "94c4b7eb-b764-4ca5-add6-76e2217f7dd4":
            //                            drugOrderDetail.Stage = "Daha Önce Karşılanan Doz Kullanılacaktır !!!";
            ////                            frm.DropStateButton(DrugOrderDetail.States.Planned);
            //                                                        break;
            //                        case "d4f85132-8d05-4dc7-b9b2-fc04bae622b0":
            //                            drugOrderDetail.Stage = "Eczaneden İstendi Eczane Tarafından Karşılandı!";
            ////                            frm.DropStateButton(DrugOrderDetail.States.Planned);
//
            //                            break;
            //                        case "d39a37a6-610e-4143-aca2-691ce5818915":
            //                            drugOrderDetail.Stage = "Uygulandı";
            //                            break;
            //                        case "add6e452-c007-4849-b477-17d30400abe8":
            //                            drugOrderDetail.Stage = "Uygulama İptal Edildi!";
            //                            break;
            //                        default:
            //                            throw new TTException(" Lütfen sistem yöneticisine başvurun!!");
            //                    }
            //                    frm.ShowEdit(this,drugOrderDetail);
//
            //                    ITTGridRow pCurrentRow = this.DrugOrderDetails.Rows[rowIndex];
            //                    if(drugOrderDetail.CurrentStateDefID.Value.ToString() == "d4f85132-8d05-4dc7-b9b2-fc04bae622b0")
            //                        pCurrentRow.Cells["Stage"].Value = "Uygulandı";
            //                }
            //                catch (System.Exception ex)
            //                {
            //                    InfoBox.Show(ex);
            //                }
            //                finally
            //                {
            //                    objectContext.Dispose();
            //                }
            //            }
#endregion NursingApplicationForm_DrugOrderDetails_CellDoubleClick
        }

        private void getSurgerySablonButton_Click()
        {
#region NursingApplicationForm_getSurgerySablonButton_Click
   IList userTemplates = _NursingApplication.ObjectContext.QueryObjects("USERTEMPLATE", "RESUSER =" + ConnectionManager.GuidToString(Common.CurrentResource.ObjectID)+" AND FILITERDATA ='NURSINGAPPLICATIONTEM'");

            string notInMaterial = ""; 
            if (userTemplates.Count > 0)
            {
                MultiSelectForm pForm = new MultiSelectForm();
                foreach (UserTemplate userTemplate in userTemplates)
                {
                    pForm.AddMSItem(userTemplate.Description, userTemplate.ObjectID.ToString(), userTemplate);

                }
                string sKey = pForm.GetMSItem(this, "Şablon seçiniz.", false, false, false, false, true, false);
                if (!String.IsNullOrEmpty(sKey))
                {
                    UserTemplate selectedTemplate = (UserTemplate)pForm.MSSelectedItemObject;
                    NursingApplicationTemplate nursingApplicationTemplate = (NursingApplicationTemplate)_NursingApplication.ObjectContext.GetObject((Guid)selectedTemplate.TAObjectID, (Guid)selectedTemplate.TAObjectDefID);

                    foreach (NursingAppTemplateDet nursingAppTemplateDet in nursingApplicationTemplate.NursingAppTempDetails)
                    {
                       Store store = this.GetStore((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["NursingApplicationTreatmentMaterial"]);
                       double inheld = nursingAppTemplateDet.Material.StockInheld(store);
                       if (inheld >0 )
                       {
                        NursingApplicationTreatmentMaterial treatmentMaterial = new NursingApplicationTreatmentMaterial(_NursingApplication.ObjectContext);
                        treatmentMaterial.Material = nursingAppTemplateDet.Material;
                        treatmentMaterial.Material.StockCard.DistributionType = nursingAppTemplateDet.Material.StockCard.DistributionType;
                        treatmentMaterial.UBBCode = nursingAppTemplateDet.Material.Barcode;
                        _NursingApplication.NursingApplicationTreatmentMaterials.Add(treatmentMaterial);
                       }
                       else
                       {
                           notInMaterial += nursingAppTemplateDet.Material.ToString()+" Malmenin mevcudu yoktur.\n";
                       }
                    }
                    if(notInMaterial != "")
                       InfoBox.Show(notInMaterial, MessageIconEnum.InformationMessage);
                }
            }
            else
                InfoBox.Show("Herhangibir şablonunuz bulunmamaktadır", MessageIconEnum.InformationMessage);
#endregion NursingApplicationForm_getSurgerySablonButton_Click
        }

        protected override void PreScript()
        {
#region NursingApplicationForm_PreScript
    base.PreScript();

            this.DropStateButton(NursingApplication.States.PreDischarged);// REdyToDischage

                if(this._NursingApplication.InPatientTreatmentClinicApp != null && this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission != null)
                {
                    if(this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission is InpatientAdmission)
                        this.QuarantineProtocolNo.Text = ((InpatientAdmission)this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission).QuarantineProtocolNo.ToString();
                }
            if (this.OrderDetails.Rows.Count>0)
            {
                int count=this.OrderDetails.Rows.Count-1;
                for ( int i=0;i<count;i++)
                {
                    foreach (ITTGridCell cell in this.OrderDetails.Rows[i].Cells)
                    {
                        cell.ReadOnly=true;
                    }
                }
            }
            this.Age.Text = this._NursingApplication.Episode.Patient.Age.ToString();
            //            if(this._NursingApplication.InPatientTreatmentClinicApplication==null)
            //            {
            //                if (this.TabSubaction.TabPages.Contains(this.InPatientInfo))
            //                {
            //                    this.TabSubaction.TabPages.RemoveAt(this.InPatientInfo.DisplayIndex);
            //                }
            //            }
            
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["NursingApplicationTreatmentMaterial"], (ITTGridColumn)this.TreatmentMaterials.Columns["MMaterial"]);
            //this.GetDrugOrderDetails(); tüm ilaçları dönüp dozlarını ve durumlarını dolduryordu çok yavaşlattığı için kapatıldı
            this.CheckLastWaterlowRiskScore();
            this.GetTakeinTakeOuts();
#endregion NursingApplicationForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region NursingApplicationForm_PostScript
    base.PostScript(transDef);
#endregion NursingApplicationForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region NursingApplicationForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
             if(transDef!=null)
            {
                if(transDef.ToStateDef.StateDefID==NursingApplication.States.Discharged)
                {
                    string result="E";
                    bool found=false;
                    foreach (NursingOrderDetail  nursingOrderDetail in this._NursingApplication.NursingApplicationNursingOrderDetails)
                    {
                        if(nursingOrderDetail.CurrentStateDefID == NursingOrderDetail.States.Execution )
                        {
                            if(found==false)
                            {
                                found=true;
                                result=ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır", "E,H", "Uyarı","Uyarı" , "Henüz Uygulanmamış Takip Gözlem işlemleri bulunmaktadır.İptal edip İşleme devam etmek istediğinize emin misiniz?", 1);
                            }
                            
                            if(result=="E")
                            {
                                nursingOrderDetail.CurrentStateDefID=NursingOrderDetail.States.Cancelled;
                            }
                            else
                            {
                                throw new Exception(SystemMessage.GetMessage(1035));
                                
                            }
                        }
                    }
                    
                    if (this._NursingApplication.InPatientTreatmentClinicApp != null && this._NursingApplication.InPatientTreatmentClinicApp.ClinicDischargeDate != null )
                    {
                        result = ShowBox.Show(ShowBoxTypeEnum.Message, "&amp;Evet,&amp;Hayır", "E,H", "Uyarı", "TARİH DEĞİŞİKLİĞİ UYARISI", "Klinik Taburcu Tarihi güncel tarihten farklıdır. Klinik Taburcu Tarihini güncel tarih ile değiştirmek istiyor musunuz?");
                        if (result == "E")
                        {
                            this._NursingApplication.InPatientTreatmentClinicApp.ClinicDischargeDate = Common.RecTime();
                        }
                    }
                }
       
            }
#endregion NursingApplicationForm_ClientSidePostScript

        }

#region NursingApplicationForm_Methods
        protected override void ShowAction_ObjectUpdated(TTObject ttObject,ref bool contextSaved )
        {
            
            ttObject.ObjectContext.Save();
            
            TTObjectContext context = _NursingApplication.ObjectContext;
            Guid objectID = ttObject.ObjectID;
            if (context.ContainsObject(objectID))
            {
                ITTObject obj = context.GetLoadedObject(objectID);
                obj.Refresh();
            }
        }
        public void GetTakeinTakeOuts()
        {
            
            int count= this._NursingApplication.TakeInTakeOuts.Count;
            if(count>0){
                int IVInf = 0;
                int Oral=0;
                int Idrar=0;
                int gaita=0;
                int dren=0;
                int kusma = 0;
                int kanama=0;
                bool devam= false;
                for ( int i=0;i<this._NursingApplication.TakeInTakeOuts.Count;i++)
                {
                    NursingTakeInTakeOut  takeintakeout= (NursingTakeInTakeOut)this._NursingApplication.TakeInTakeOuts[i];
                    devam = false;
                    if (this.tttakeintakeoutdate1.Text.ToString()=="" && this.tttakeintakeoutdate2.Text.ToString()=="" )
                        devam = true;
                    else
                    {
                        DateTime startdate =  (Convert.ToDateTime(this.tttakeintakeoutdate1.Text)).Date.AddHours(Convert.ToDateTime(this.tttakeintakeoutdate1.Text.ToString()).Hour);
                        DateTime enddate;
                        if (Convert.ToDateTime(this.tttakeintakeoutdate2.Text).Minute > 0)
                            enddate =  (Convert.ToDateTime(this.tttakeintakeoutdate2.Text)).Date.AddHours(Convert.ToDateTime(this.tttakeintakeoutdate2.Text.ToString()).Hour+1);
                        else
                            enddate =  (Convert.ToDateTime(this.tttakeintakeoutdate2.Text)).Date.AddHours(Convert.ToDateTime(this.tttakeintakeoutdate2.Text.ToString()).Hour);
                        if (takeintakeout.ActionDate >=  Convert.ToDateTime(startdate)  && takeintakeout.ActionDate <  Convert.ToDateTime(enddate))
                        {
                            devam = true;
                        }
                    }
                    if (devam){
                        if (takeintakeout.IVInf!=null)
                            IVInf = IVInf + takeintakeout.IVInf.Value;
                        if (takeintakeout.Oral!=null)
                            Oral = Oral + takeintakeout.Oral.Value;
                        if (takeintakeout.Uretic!=null)
                            Idrar = Idrar + takeintakeout.Uretic.Value;
                        if (takeintakeout.Gaita!=null)
                            gaita = gaita + takeintakeout.Gaita.Value;
                        if (takeintakeout.Dren!=null)
                            dren = dren + takeintakeout.Dren.Value;
                        if (takeintakeout.Vomiting!=null)
                            kusma = kusma + takeintakeout.Vomiting.Value;
                        if (takeintakeout.Bleeding!=null)
                            kanama = kanama + takeintakeout.Bleeding.Value;
                    }
                }
                this.ttIVInf.Text  = IVInf.ToString();
                this.ttOral.Text = Oral.ToString();
                this.ttIdrar.Text = Idrar.ToString();
                this.ttGaita.Text = gaita.ToString();
                this.ttDren.Text = dren.ToString();
                this.ttKusma.Text = kusma.ToString();
                this.ttKanama.Text = kanama.ToString();
                this.ttdenge.Text = ((IVInf + Oral) - (Idrar + gaita + dren + kusma + kanama)).ToString();
            }
        }
        public void GetDrugOrderDetails()
        {
            if (this.DrugOrderDetails.Rows.Count>0)
            {
                for ( int i=0;i<this.DrugOrderDetails.Rows.Count;i++)
                {
                    DrugOrderDetail drugOrderDetail = (DrugOrderDetail)((ITTGridRow)this.DrugOrderDetails.Rows[i]).TTObject;
                    foreach (ITTGridCell currentCell in this.DrugOrderDetails.Rows[i].Cells)
                    {
                        currentCell.ReadOnly = true;
                        if (currentCell.OwningColumn.Name == "ActionDate")
                        {
                            drugOrderDetail.ActionDate = Common.RecTime().Date;
                        }

                        if (currentCell.OwningColumn.Name == "Material")
                        {
                            DrugDefinition drugDefinition = ((DrugDefinition)drugOrderDetail.Material);
                            bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                            double restDose = 0;
                            if(drugOrderDetail.DrugOrder != null)
                            {
                                restDose = DrugOrderTransaction.GetRestDose(drugOrderDetail.DrugOrder);
                            }
                            double dose = 0;

                            if (restDose > 0)
                            {
                                dose = restDose;
                            }
                            else
                            {
                                Dictionary<object, double> patientRestDictionary = DrugOrderTransaction.GetPatientRestDose(drugOrderDetail.Material, drugOrderDetail.Episode);
                                foreach (KeyValuePair<object, double> restDic in patientRestDictionary)
                                {
                                    dose += (double)restDic.Value;
                                }
                            }
                            this.DrugOrderDetails.Rows[i].Cells["RestDose"].Value = dose.ToString();
                            switch (drugOrderDetail.CurrentStateDefID.Value.ToString())
                            {
                                case "cb22e74b-a2be-456f-8680-660d0b21dc24":
                                    drugOrderDetail.Stage = "Eczaneden İstenmedi!";
                                    //this.DropStateButton(DrugOrderDetail.States.Request);
                                    //this.DropStateButton(DrugOrderDetail.States.UseRestDose);
                                    //this.DropStateButton(DrugOrderDetail.States.Apply);
                                    break;
                                case "da01e671-efb9-4d84-8122-4bae07e08c20":
                                    drugOrderDetail.Stage = "Eczaneden İstendi Henüz Karşılanmadı!";
                                    //this.DropStateButton(DrugOrderDetail.States.Supply);
                                    break;
                                case "94c4b7eb-b764-4ca5-add6-76e2217f7dd4":
                                    drugOrderDetail.Stage = "Daha Önce Karşılanan Doz Kullanılacaktır !!!";
                                    //this.DropStateButton(DrugOrderDetail.States.Planned);
                                    if (!drugType)
                                    {
                                        //drugOrderDetail.DrugDone.Visible = true;
                                    }
                                    break;
                                case "d4f85132-8d05-4dc7-b9b2-fc04bae622b0":
                                    drugOrderDetail.Stage = "Eczaneden İstendi Eczane Tarafından Karşılandı!";
                                    //this.DropStateButton(DrugOrderDetail.States.Planned);
                                    if (!drugType)
                                    {
                                        //drugOrderDetail.DrugDone.Visible = true;
                                    }
                                    break;
                                case "d39a37a6-610e-4143-aca2-691ce5818915":
                                    drugOrderDetail.Stage = "Uygulandı";
                                    break;
                                case "add6e452-c007-4849-b477-17d30400abe8":
                                    drugOrderDetail.Stage = "Uygulama İptal Edildi!";
                                    break;
                                case "1d516c6e-4b74-46b6-b0f0-89e3402a3819":
                                    drugOrderDetail.Stage = "Dış Eczaneden Temin Edildi.";
                                    break;
                                case "6613a06d-4359-46a2-9547-1413e80592a1":
                                    drugOrderDetail.Stage = "Uygulandı";
                                    break;
                                case "f1b24e44-ecb3-4b44-9b23-1d77e9901721":
                                    drugOrderDetail.Stage = "Durduruldu";
                                    break;
                                case "14ea4626-5b27-4663-82f9-64968cb4eb63":
                                    drugOrderDetail.Stage = "Hasta / Hasta Yakınına Teslim Edildi.";
                                    break;
                                case "0586979d-523c-4800-995c-750ac3984606"://Dış Eczane Tarafından Karşılandı
                                    drugOrderDetail.Stage = "Dış Eczane Tarafından Karşılandı";
                                    break;
                                case "ad54f2c0-8ebe-4fbb-a57a-b7c870fd1fb3": // Eczacılık Bilimlerinden İstendi
                                    drugOrderDetail.Stage = "Eczacılık Bilimlerinden İstendi";
                                    break;
                                default:
                                    throw new TTException(SystemMessage.GetMessage(987));
                            }
                        }
                    }
                }
            }
        }
        
        void CheckLastWaterlowRiskScore(){
            if(this._NursingApplication.CurrentStateDef.Status == StateStatusEnum.Uncompleted){
                int count= this._NursingApplication.WaterlowRisks.Count;
                if(count>0){
                    NursingWaterlowRisk waterlowRisk= this._NursingApplication.WaterlowRisks[count-1];
                    if(waterlowRisk.RiskScore!=WaterlowScoreEnum.LowThenTen){
                        int uyarıSuresi=3000;//gün
                        switch(waterlowRisk.RiskScore){
                            case WaterlowScoreEnum.TenPlusRisk:
                                uyarıSuresi=21;
                                break;
                            case WaterlowScoreEnum.FifteenPlusRisk:
                                uyarıSuresi=14;
                                break;
                            case WaterlowScoreEnum.TwentyPlusRisk:
                                uyarıSuresi=7;
                                break;
                        }
                        if(Common.DateDiffV2(0,Common.RecTime(),Convert.ToDateTime(waterlowRisk.ActionDate),false)> uyarıSuresi)
                            InfoBox.Show("Hastaya Waterlow Bası Risk Değerlendirmesi Yapılmalıdır.");
                    }
                }
            }
        }
        
        void CheckLastFallingDownRisk(){
            if(this._NursingApplication.CurrentStateDef.Status == StateStatusEnum.Uncompleted){
                //int count= this._NursingApplication.FallingDownRisks.Count;
                //if(count>0){
                //    NursingFallingDownRisk fallingDownRisk= this._NursingApplication.FallingDownRisks[count-1];
                //    int uyarıSuresi=0;//gün
                //    if(fallingDownRisk.TotalScore<5){
                //        uyarıSuresi=7;
                //    }
                //    else{
                //        uyarıSuresi=2;
                //    }
                //    if(Common.DateDiffV2(0,Common.RecTime(),Convert.ToDateTime(fallingDownRisk.ActionDate),false)> uyarıSuresi)
                //        InfoBox.Show("Hastaya Düşme Riski Değerlendirmesi Yapılmalıdır.");
                    
                //}
            }
        }
        
        
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if(transDef != null && transDef.ToStateDefID == NursingApplication.States.Discharged)
            {
                if(this._NursingApplication.InPatientTreatmentClinicApp !=null)
                {
                    if(this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission is InpatientAdmission)
                    {
                        Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                        TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                        objectID.Add("VALUE", this._NursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.ObjectID.ToString());
                        parameter.Add("TTOBJECTID", objectID);
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_InpatientFolderReport), true, 1, parameter);
                    }
                }
            }

            
            
        }
        
    
        
#endregion NursingApplicationForm_Methods

#region NursingApplicationForm_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            string barcode = Common.PrepareBarcode(value);
            Material material = null;
            IList materials = _NursingApplication.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + barcode + "'");
            List<Material> findMaterials = new List<Material>();
            if (materials.Count == 0)
            {
                IList productDefinitions = _NursingApplication.ObjectContext.QueryObjects("PRODUCTDEFINITION", "PRODUCTNUMBER ='" + barcode + "'");
                if (productDefinitions.Count > 0)
                {
                    foreach (ProductDefinition product in productDefinitions)
                    {
                        IList mpl = _NursingApplication.ObjectContext.QueryObjects("MATERIALPRODUCTLEVEL", "PRODUCT=" + ConnectionManager.GuidToString(product.ObjectID));
                        foreach (MaterialProductLevel level in mpl)
                        {
                            Store store = this.GetStore(this.ObjectDef);
                            double inheld = level.Material.StockInheld(store);
                            if (inheld > 0)
                                findMaterials.Add(level.Material);
                        }
                    }
                    if (findMaterials.Count == 1)
                        material = findMaterials[0];
                    else if (findMaterials.Count > 1)
                    {
                        MultiSelectForm multiSelectForm = new MultiSelectForm();
                        foreach (Material m in findMaterials)
                        {
                            multiSelectForm.AddMSItem(m.Name, m.Name, m);
                        }
                        string key = multiSelectForm.GetMSItem(ParentForm, "Malzeme seçin");

                        if (string.IsNullOrEmpty(key))
                            InfoBox.Show("Herhangibir malzeme seçilmedi.", MessageIconEnum.ErrorMessage);
                        else
                            material = multiSelectForm.MSSelectedItemObject as Material;
                    }
                    else
                        InfoBox.Show(barcode + " UBB/Barkodlu malzeme bulunamadı.", MessageIconEnum.ErrorMessage);
                }
                else
                {
                    InfoBox.Show(barcode + " UBB/Barkodlu malzeme bulunamadı.", MessageIconEnum.ErrorMessage);
                }
            }
            else if (materials.Count == 1)
                material = (Material)materials[0];
            else
            {
                MultiSelectForm multiSelectForm = new MultiSelectForm();
                foreach (Material m in materials)
                {
                    multiSelectForm.AddMSItem(m.Name, m.Name, m);
                }
                string key = multiSelectForm.GetMSItem(ParentForm, "Malzeme seçin");

                if (string.IsNullOrEmpty(key))
                    InfoBox.Show("Herhangibir malzeme seçilmedi.", MessageIconEnum.ErrorMessage);
                else
                    material = multiSelectForm.MSSelectedItemObject as Material;
            }

            if (material != null)
            {
                //Sarf edilecek miktar girişi
                string retAmount = InputForm.GetText("Sarf Edilecek Miktarı Giriniz.");
                Currency? amount = 0;
                if (string.IsNullOrEmpty(retAmount) == false)
                {
                    if (CurrencyType.TryConvertFrom(retAmount, false, out amount) == false)
                        throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retAmount.ToString() }));
                }
                
                BaseTreatmentMaterial returningDocument = _NursingApplication.TreatmentMaterials.AddNew();
                
                returningDocument.Material = material;
                returningDocument.Amount = amount;
            }
        }
        
#endregion NursingApplicationForm_ClientSideMethods
    }
}