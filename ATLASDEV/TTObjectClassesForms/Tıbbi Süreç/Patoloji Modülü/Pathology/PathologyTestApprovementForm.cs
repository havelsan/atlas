
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
    public partial class PathologyTestApprovementForm 
    {
        //TODO ASLI Formlar Revize Edilecek
         protected void BindControlEvents()
        {
            //ttMasterResourceUserCheck.CheckedChanged += new TTControlEventDelegate(ttMasterResourceUserCheck_CheckedChanged);
            //cmdSaveAndPrint.Click += new TTControlEventDelegate(cmdSaveAndPrint_Click);
            //GridPathologyMaterials.CellContentClick += new TTGridCellEventDelegate(GridPathologyMaterials_CellContentClick);
            //GridEpisodeDiagnosis.CellContentClick += new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            //GridConsultantDoctor.UserDeletedRow += new TTGridRowEventDelegate(GridConsultantDoctor_UserDeletedRow);
            base.BindControlEvents();
        }

         protected void UnBindControlEvents()
        {
            //ttMasterResourceUserCheck.CheckedChanged -= new TTControlEventDelegate(ttMasterResourceUserCheck_CheckedChanged);
            //cmdSaveAndPrint.Click -= new TTControlEventDelegate(cmdSaveAndPrint_Click);
            //GridPathologyMaterials.CellContentClick -= new TTGridCellEventDelegate(GridPathologyMaterials_CellContentClick);
            //GridEpisodeDiagnosis.CellContentClick -= new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            //GridConsultantDoctor.UserDeletedRow -= new TTGridRowEventDelegate(GridConsultantDoctor_UserDeletedRow);
            base.UnBindControlEvents();
        }

        private void ttMasterResourceUserCheck_CheckedChanged()
        {
#region PathologyTestApprovementForm_ttMasterResourceUserCheck_CheckedChanged
   //if(this.ttMasterResourceUserCheck.Value == true)
   //         {
   //             ((ITTListBoxColumn)((ITTGridColumn)GridConsultantDoctor.Columns["ConsultantDoctor"])).ListFilterExpression = "USERRESOURCES.RESOURCE = '"+ this._Pathology.MasterResource.ObjectID.ToString()+"'";
   //         }
   //         else
   //         {
   //             ((ITTListBoxColumn)((ITTGridColumn)GridConsultantDoctor.Columns["ConsultantDoctor"])).ListFilterExpression = null;
   //         }
#endregion PathologyTestApprovementForm_ttMasterResourceUserCheck_CheckedChanged
        }

        private void cmdSaveAndPrint_Click()
        {
#region PathologyTestApprovementForm_cmdSaveAndPrint_Click
   //this._Pathology.ObjectContext.Save();
            
   //         Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            
   //         TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
   //         objectID.Add("VALUE", this._Pathology.ObjectID.ToString());
            
   //         parameters.Add("TTOBJECTID",objectID);
                        
   //         TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_PathologyTestResultReport),true,1,parameters);
#endregion PathologyTestApprovementForm_cmdSaveAndPrint_Click
        }

        private void GridPathologyMaterials_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PathologyTestApprovementForm_GridPathologyMaterials_CellContentClick
   //            if (((ITTGridCell)GridPathologyMaterials.CurrentCell).OwningColumn.Name == "malzemeCokluOzelDurum")
//            {
//                
//                PathologyTestCokluOzelDurum ptcod = new PathologyTestCokluOzelDurum();
//                ptcod.ShowEdit(this.FindForm(), this._PathologyTest);
//            }
#endregion PathologyTestApprovementForm_GridPathologyMaterials_CellContentClick
        }

        private void GridEpisodeDiagnosis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PathologyTestApprovementForm_GridEpisodeDiagnosis_CellContentClick
   //            if (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn.Name == "taniCokluOzelDurum")
//            {
//                
//                PathologyTestCokluOzelDurum ptcod = new PathologyTestCokluOzelDurum();
//                ptcod.ShowEdit(this.FindForm(), this._PathologyTest);
//            }
#endregion PathologyTestApprovementForm_GridEpisodeDiagnosis_CellContentClick
        }

        private void GridConsultantDoctor_UserDeletedRow()
        {
#region PathologyTestApprovementForm_GridConsultantDoctor_UserDeletedRow
   if(this.GridConsultantDoctor.Rows.Count < 3)
                this.GridConsultantDoctor.AllowUserToAddRows = true;
#endregion PathologyTestApprovementForm_GridConsultantDoctor_UserDeletedRow
        }

        protected  void PreScript()
        {
#region PathologyTestApprovementForm_PreScript
    //base.PreScript();
            
            
    //        if(this.ttMasterResourceUserCheck.Value != null && this.ttMasterResourceUserCheck.Value == true)
    //        {
    //            ((ITTListBoxColumn)((ITTGridColumn)GridConsultantDoctor.Columns["ConsultantDoctor"])).ListFilterExpression = "USERRESOURCES.RESOURCE = '"+ this._Pathology.MasterResource.ObjectID.ToString()+"'";
    //        }

            
    //        if(!((ITTObject)this._Pathology).IsReadOnly)
    //        {
    //            this._Pathology.SpecialDoctor = Common.CurrentResource;
    //        }
            
    //        //this._PathologyTest.SpecialDoctor = Common.CurrentResource;
            
    //         this.SetProcedureDoctorAsCurrentResource();
            
    //        this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.GridPathologyMaterials.Columns["Material"]);
            
    //        if(this.GridConsultantDoctor.Rows.Count > 2)
    //            this.GridConsultantDoctor.AllowUserToAddRows = false;
            
    //        ((TTGrid)this.GridConsultantDoctor).RowPrePaint += new DataGridViewRowPrePaintEventHandler(dgv_RowPrePaint);
    //        ((TTGrid)this.GridConsultantDoctor).RowsAdded += new DataGridViewRowsAddedEventHandler(dgv_RowAdded);
#endregion PathologyTestApprovementForm_PreScript

            }
            
        protected  void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PathologyTestApprovementForm_PostScript
    base.PostScript(transDef);
#endregion PathologyTestApprovementForm_PostScript

            }
            
#region PathologyTestApprovementForm_Methods
        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //ITTGrid grd = sender as ITTGrid;
            //if(grd.Rows.Count > 2)
            //    grd.AllowUserToAddRows = false;
            //else if(grd.Rows.Count < 3)
            //    grd.AllowUserToAddRows = true;
        }

        private void dgv_RowAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //ITTGrid grd = sender as ITTGrid;
            //if(grd.Rows.Count > 3)
            //    grd.AllowUserToAddRows = false;
            //else if(grd.Rows.Count < 3)
            //    grd.AllowUserToAddRows = true;
        }
        
        protected  void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            
            //if (transDef != null && transDef.ToStateDefID == Pathology.States.Report && this._Pathology.SnomedDiagnosis != null)
            //{
            //    foreach(SnomedDiagnosisGrid snomedItem in this._Pathology.SnomedDiagnosis)
            //    {
            //        if(snomedItem.PanicDiagnosisNotification == true && snomedItem.UserMessage == null) //Sonuç girişte oluşturulmuş mesajların tekrarlanmasını engellemek için
            //        {
            //            TTObjectContext newContext = new TTObjectContext(false);
            //            UserMessage message = new UserMessage(newContext);
            //            message.BaseAction = (BaseAction)this._Pathology.PathologyRequest;
            //            message.SubAction = (SubActionProcedure)this._Pathology;
            //            message.Patient = this._Pathology.Episode.Patient;
            //            message.IsPanicMessage = true;
            //            message.IsSystemMessage = false;
            //            message.Sender = Common.CurrentResource;
            //            message.ToUser = this._Pathology.PathologyRequest.RequestDoctor;
            //            message.Status = MessageStatusEnum.Sent;
            //            message.MessageDate = TTObjectDefManager.ServerTime;
            //            message.MessageFeedback = true;
            //            message.Subject = "PATOLOJİ_PANİK_TANI_BİLDİRİMİ";
                        
            //            string messageText = "" ;
            //            messageText += "Sayın " +this._Pathology.PathologyRequest.RequestDoctor.Name + ", ";
                        
            //            if(this._Pathology.Episode.Patient.UniqueRefNo != null)
            //                messageText += "( " + this._Pathology.Episode.Patient.UniqueRefNo+ " ) ";
                        
            //            messageText += this._Pathology.Episode.Patient.Name.Trim() + " " +this._Pathology.Episode.Patient.Surname.Trim();
                        
            //            messageText += " isimli hasta için istemiş olduğunuz Patoloji İstek İşlemi sonucunda Snomed Tanı olarak; ";
                        
            //            messageText += "'"+snomedItem.SnomedDiagnose.Code.ToString() + "'  '" + snomedItem.SnomedDiagnose.Name.ToString()+ "' belirlenmiştir.";
                        
            //            if(this._Pathology.Episode.Patient.UniqueRefNo != null)
            //                messageText += "| | HASTA TCKİMLİKNU : " + this._Pathology.Episode.Patient.UniqueRefNo;
                        
            //            messageText += " | HASTA ADI SOYADI : " + this._Pathology.Episode.Patient.Name.Trim() + " " +this._Pathology.Episode.Patient.Surname.Trim();
                        
            //            messageText += " | VAKA AÇILIŞ TARİHİ : " +this._Pathology.Episode.OpeningDate.ToString();
                        
            //            messageText +=" | İŞLEM NUMARASI : " +this._Pathology.ID.Value.ToString();
                        
            //            messageText +=" | SNOMED TANI : '" + snomedItem.SnomedDiagnose.Code.ToString() + "'  '" + snomedItem.SnomedDiagnose.Name.ToString()+ "'";
                        
            //            messageText += "| | Dikkat: Bu mesaj patoloji tetkik işlemi sonucunda belirlenen Snomed Tanının Panik Bildirim olarak seçilmesi sonucunda sistem tarafından otomatik olarak oluşturulmuştur."
            //                +"Mesajın okunduğu bilgisi snomed tanı girişini gerçekleştiren kullanıcı ile paylaşılacaktır." ;
                        
            //            message.SetRTFBody(messageText.Trim());
                        
            //            ////
            //            SnomedDiagnosisGrid snomedDiagnosisItem = (SnomedDiagnosisGrid)newContext.GetObject(snomedItem.ObjectID,typeof(SnomedDiagnosisGrid));
            //            snomedDiagnosisItem.UserMessage = message;
            //            ////
            //            newContext.Save();
            //        }
            //    }
            //}
        }
        
#endregion PathologyTestApprovementForm_Methods
    }
}