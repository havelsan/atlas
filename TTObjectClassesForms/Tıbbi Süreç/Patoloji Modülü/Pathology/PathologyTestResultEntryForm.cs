
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
    public partial class PathologyTestResultEntryForm 
    {
        //TODO ASLI Formlar revize edilecek
         protected void BindControlEvents()
        {
            //GridPathologyMaterials.CellContentClick += new TTGridCellEventDelegate(GridPathologyMaterials_CellContentClick);
            //cmdNumberIncrement.Click += new TTControlEventDelegate(cmdNumberIncrement_Click);
            //GridProtocolNumbers.CellContentClick += new TTGridCellEventDelegate(GridProtocolNumbers_CellContentClick);
            //GridProtocolNumbers.CellValueChanged += new TTGridCellEventDelegate(GridProtocolNumbers_CellValueChanged);
            //GridEpisodeDiagnosis.CellContentClick += new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            //GridConsultantDoctor.UserDeletedRow += new TTGridRowEventDelegate(GridConsultantDoctor_UserDeletedRow);
            //ttMasterResourceUserCheck.CheckedChanged += new TTControlEventDelegate(ttMasterResourceUserCheck_CheckedChanged);
            base.BindControlEvents();
        }

         protected void UnBindControlEvents()
        {
            //GridPathologyMaterials.CellContentClick -= new TTGridCellEventDelegate(GridPathologyMaterials_CellContentClick);
            //cmdNumberIncrement.Click -= new TTControlEventDelegate(cmdNumberIncrement_Click);
            //GridProtocolNumbers.CellContentClick -= new TTGridCellEventDelegate(GridProtocolNumbers_CellContentClick);
            //GridProtocolNumbers.CellValueChanged -= new TTGridCellEventDelegate(GridProtocolNumbers_CellValueChanged);
            //GridEpisodeDiagnosis.CellContentClick -= new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            //GridConsultantDoctor.UserDeletedRow -= new TTGridRowEventDelegate(GridConsultantDoctor_UserDeletedRow);
            //ttMasterResourceUserCheck.CheckedChanged -= new TTControlEventDelegate(ttMasterResourceUserCheck_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void GridPathologyMaterials_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PathologyTestResultEntryForm_GridPathologyMaterials_CellContentClick
   //if (((ITTGridCell)GridPathologyMaterials.CurrentCell).OwningColumn.Name == "malzemeCokluOzelDurum")
   //         {
                
   //             PathologyTestCokluOzelDurum ptcod = new PathologyTestCokluOzelDurum();
   //             ptcod.ShowEdit(this.FindForm(), this._Pathology);
   //         }
#endregion PathologyTestResultEntryForm_GridPathologyMaterials_CellContentClick
        }

        private void cmdNumberIncrement_Click()
        {
#region PathologyTestResultEntryForm_cmdNumberIncrement_Click
   //this.RunMatPrtNoIncrement(this._Pathology, GridProtocolNumbers);
#endregion PathologyTestResultEntryForm_cmdNumberIncrement_Click
        }

        private void GridProtocolNumbers_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PathologyTestResultEntryForm_GridProtocolNumbers_CellContentClick
   //this.RunCellContentClick(rowIndex,this._Pathology, GridProtocolNumbers);
#endregion PathologyTestResultEntryForm_GridProtocolNumbers_CellContentClick
        }

        private void GridProtocolNumbers_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PathologyTestResultEntryForm_GridProtocolNumbers_CellValueChanged
   //this.RunGridProtocolNumbersCellValueChanged(rowIndex,this._Pathology,GridProtocolNumbers);
#endregion PathologyTestResultEntryForm_GridProtocolNumbers_CellValueChanged
        }

        private void GridEpisodeDiagnosis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PathologyTestResultEntryForm_GridEpisodeDiagnosis_CellContentClick
   //            if (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn.Name == "cokluOzelDurum")
//            {
//                
//                PathologyTestCokluOzelDurum ptcod = new PathologyTestCokluOzelDurum();
//                ptcod.ShowEdit(this.FindForm(), this._PathologyTest);
//            }
#endregion PathologyTestResultEntryForm_GridEpisodeDiagnosis_CellContentClick
        }

        private void GridConsultantDoctor_UserDeletedRow()
        {
#region PathologyTestResultEntryForm_GridConsultantDoctor_UserDeletedRow
   if(this.GridConsultantDoctor.Rows.Count < 3)
                this.GridConsultantDoctor.AllowUserToAddRows = true;
#endregion PathologyTestResultEntryForm_GridConsultantDoctor_UserDeletedRow
        }

        private void ttMasterResourceUserCheck_CheckedChanged()
        {
#region PathologyTestResultEntryForm_ttMasterResourceUserCheck_CheckedChanged
   //if(this.ttMasterResourceUserCheck.Value == true)
   //         {
   //             ((ITTListBoxColumn)((ITTGridColumn)GridConsultantDoctor.Columns["ConsultantDoctor"])).ListFilterExpression = "USERRESOURCES.RESOURCE = '"+ this._Pathology.MasterResource.ObjectID.ToString()+"'";
   //             this.ResposibleDoctor.ListFilterExpression = "USERRESOURCES.RESOURCE = '"+ this._Pathology.MasterResource.ObjectID.ToString()+"'";
   //             this.SpecialDoctor.ListFilterExpression = "USERRESOURCES.RESOURCE = '"+ this._Pathology.MasterResource.ObjectID.ToString()+"'";
   //             this.ttobjectlistbox1.ListFilterExpression = "USERRESOURCES.RESOURCE = '"+ this._Pathology.MasterResource.ObjectID.ToString()+"'";
   //         }
   //         else
   //         {
   //             ((ITTListBoxColumn)((ITTGridColumn)GridConsultantDoctor.Columns["ConsultantDoctor"])).ListFilterExpression = null;
   //             this.ResposibleDoctor.ListFilterExpression = null;
   //             this.SpecialDoctor.ListFilterExpression = null;
   //             this.ttobjectlistbox1.ListFilterExpression = null;
   //         }
#endregion PathologyTestResultEntryForm_ttMasterResourceUserCheck_CheckedChanged
        }

        protected  void PreScript()
        {
#region PathologyTestResultEntryForm_PreScript


            //base.PreScript();
            //this.DropStateButton(Pathology.States.Report);
            
            
            //if(this.ttMasterResourceUserCheck.Value != null && this.ttMasterResourceUserCheck.Value == true)
            //{
            //    ((ITTListBoxColumn)((ITTGridColumn)GridConsultantDoctor.Columns["ConsultantDoctor"])).ListFilterExpression = "USERRESOURCES.RESOURCE = '"+ this._Pathology.MasterResource.ObjectID.ToString()+"'";
            //    this.ResposibleDoctor.ListFilterExpression = "USERRESOURCES.RESOURCE = '"+ this._Pathology.MasterResource.ObjectID.ToString()+"'";
            //    this.SpecialDoctor.ListFilterExpression = "USERRESOURCES.RESOURCE = '"+ this._Pathology.MasterResource.ObjectID.ToString()+"'";
            //    this.ttobjectlistbox1.ListFilterExpression = "USERRESOURCES.RESOURCE = '"+ this._Pathology.MasterResource.ObjectID.ToString()+"'";
            //}

            
            //if(!((ITTObject)this._Pathology.PathologyRequest).IsReadOnly)
            //{
            //    this._Pathology.PathologyRequest.ResultEntryDate = Common.RecTime();
            //    this._Pathology.PathologyRequest.ReportDate = Common.RecTime();
            //}
            
            //this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.GridPathologyMaterials.Columns["Material"]);
            
            //if(this.GridConsultantDoctor.Rows.Count > 2)
            //    this.GridConsultantDoctor.AllowUserToAddRows = false;
            
            //((TTGrid)this.GridConsultantDoctor).RowPrePaint += new DataGridViewRowPrePaintEventHandler(dgv_RowPrePaint);
            //((TTGrid)this.GridConsultantDoctor).RowsAdded += new DataGridViewRowsAddedEventHandler(dgv_RowAdded);
             
            //this.SetProcedureDoctorAsCurrentResource();
#endregion PathologyTestResultEntryForm_PreScript

            }
            
        protected  void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PathologyTestResultEntryForm_PostScript
    base.PostScript(transDef);
            Pathology.CheckUncompletedSpecialProcedures(this._Pathology);
#endregion PathologyTestResultEntryForm_PostScript

            }
            
#region PathologyTestResultEntryForm_Methods
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
            
            //if (transDef != null && transDef.ToStateDefID == Pathology.States.Approvement && this._Pathology.SnomedDiagnosis != null)
            //{
            //    foreach(SnomedDiagnosisGrid snomedItem in this._Pathology.SnomedDiagnosis)
            //    {
            //        if(snomedItem.PanicDiagnosisNotification == true)
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
        
#endregion PathologyTestResultEntryForm_Methods
    }
}