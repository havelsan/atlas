
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
    /// Diğer XXXXXXden Tetkik İstek Formu
    /// </summary>
    public partial class InternalProcedureRequestForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cboMasterResource.SelectedIndexChanged += new TTControlEventDelegate(cboMasterResource_SelectedIndexChanged);
            TestMenuDefinition.SelectedObjectChanged += new TTControlEventDelegate(TestMenuDefinition_SelectedObjectChanged);
            OtherHospital.SelectedObjectChanged += new TTControlEventDelegate(OtherHospital_SelectedObjectChanged);
            PreDiagnosis.TextChanged += new TTControlEventDelegate(PreDiagnosis_TextChanged);
            tttextbox2.TextChanged += new TTControlEventDelegate(tttextbox2_TextChanged);
            ProcedureGrid.CellValueChanged += new TTGridCellEventDelegate(ProcedureGrid_CellValueChanged);
            ShowMessageStatus.Click += new TTControlEventDelegate(ShowMessageStatus_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cboMasterResource.SelectedIndexChanged -= new TTControlEventDelegate(cboMasterResource_SelectedIndexChanged);
            TestMenuDefinition.SelectedObjectChanged -= new TTControlEventDelegate(TestMenuDefinition_SelectedObjectChanged);
            OtherHospital.SelectedObjectChanged -= new TTControlEventDelegate(OtherHospital_SelectedObjectChanged);
            PreDiagnosis.TextChanged -= new TTControlEventDelegate(PreDiagnosis_TextChanged);
            tttextbox2.TextChanged -= new TTControlEventDelegate(tttextbox2_TextChanged);
            ProcedureGrid.CellValueChanged -= new TTGridCellEventDelegate(ProcedureGrid_CellValueChanged);
            ShowMessageStatus.Click -= new TTControlEventDelegate(ShowMessageStatus_Click);
            base.UnBindControlEvents();
        }

        private void cboMasterResource_SelectedIndexChanged()
        {
#region InternalProcedureRequestForm_cboMasterResource_SelectedIndexChanged
   this._InternalProcedureRequest.InternalSubActionProcedures.DeleteChildren();
            this._InternalProcedureRequest.DescriptionForWorkList = String.Empty;
            List<InternalSubActionProcedure> delList = new List<InternalSubActionProcedure>();
            foreach (InternalSubActionProcedure procedure in this._InternalProcedureRequest.InternalSubActionProcedures)
            {
                delList.Add(procedure);
            }

            foreach (InternalSubActionProcedure proc in delList)
            {
                ((ITTObject)proc).Delete();
            }
            
            if(cboMasterResource.SelectedItem != null)
            {
                this.ProcedureGrid.ReadOnly = false;
                Sites remoteSite = this._InternalProcedureRequest.OtherHospital.Site;
                Guid masterResourceID = new Guid(cboMasterResource.SelectedItem.Value.ToString());
                List<RemotingInfoClass.LaboratoryListInfo> testList = null;
                //testList = InternalProcedureRequest.RemoteMethods.GetRemoteTestDefinition(remoteSite.ObjectID, masterResourceID, selectedActionType);
                List<Guid> guidList = new List<Guid>();
                foreach(RemotingInfoClass.LaboratoryListInfo info in testList)
                {
                    guidList.Add(info.LabTestDefID);
                }
                SetLaboratoryProcedureDefinitionFilter(guidList);
            }
#endregion InternalProcedureRequestForm_cboMasterResource_SelectedIndexChanged
        }

        private void TestMenuDefinition_SelectedObjectChanged()
        {
#region InternalProcedureRequestForm_TestMenuDefinition_SelectedObjectChanged
   //SetProcedureDefinitionFilter();
           
            
            this._InternalProcedureRequest.InternalSubActionProcedures.DeleteChildren();
            this._InternalProcedureRequest.DescriptionForWorkList = String.Empty;
            List<InternalSubActionProcedure> delList = new List<InternalSubActionProcedure>();
            foreach (InternalSubActionProcedure procedure in this._InternalProcedureRequest.InternalSubActionProcedures)
            {
                delList.Add(procedure);
            }
            foreach (InternalSubActionProcedure proc in delList)
            {
                ((ITTObject)proc).Delete();
            }
            
            if(this._InternalProcedureRequest.OtherHospital != null)
            {
                Sites remoteSite = this._InternalProcedureRequest.OtherHospital.Site;
                TTObjectContext dummyObjectContext = new TTObjectContext(false);
                //TTObject ttObject = null;
                if(this.TestMenuDefinition.SelectedObject != null)
                {
                    //ttObject = (MenuDefinition)this.TestMenuDefinition.SelectedObject;
                    
                    this.ProcedureGrid.ReadOnly = false;
                }
                else
                {
                    this.ProcedureGrid.ReadOnly = true;
                    //Grid'i temizle
                }

                string objectDefName = ((MenuDefinition)this.TestMenuDefinition.SelectedObject).ObjectDefinitionName.ToUpperInvariant();
                
                List<RemotingInfoClass.ResLaboratoryDepartmentInfo> labList = null;
                cboMasterResource.Items.Clear();
                
                if(objectDefName == "LABORATORYREQUEST")
                {
                    lblMasterResource.Visible = true;
                    cboMasterResource.Visible = true;
                    cboMasterResource.Required = true;
                    this.ProcedureGrid.ReadOnly = true;
                    //Grid'i temizle
                    
                    //LaboratoryRequest labRequest= (LaboratoryRequest)dummyObjectContext.CreateObject("LABORATORYREQUEST");
                    selectedActionType = ActionTypeEnum.LaboratoryRequest;
                    //labList = InternalProcedureRequest.RemoteMethods.GetRemoteResourceDefinition(remoteSite.ObjectID, selectedActionType);
                    //foreach(RemotingInfoClass.ResLaboratoryDepartmentInfo info in labList)
                    //{
                    //    TTComboBoxItem item = new TTComboBoxItem(info.LabName, info.LabID);
                    //    cboMasterResource.Items.Add(item);
                    //}
                }
                else if(objectDefName == "RADIOLOGY")
                {
                    lblMasterResource.Visible = true;
                    cboMasterResource.Visible = true;
                    cboMasterResource.Required = true;
                    this.ProcedureGrid.ReadOnly = true;
                    //Grid'i temizle
                    
                    //Radiology radRequest= (Radiology)dummyObjectContext.CreateObject("RADIOLOGY");
                    selectedActionType = ActionTypeEnum.Radiology; ;
                    //labList = InternalProcedureRequest.RemoteMethods.GetRemoteResourceDefinition(remoteSite.ObjectID, selectedActionType);
                    //foreach(RemotingInfoClass.ResLaboratoryDepartmentInfo info in labList)
                    //{
                    //    TTComboBoxItem item = new TTComboBoxItem(info.LabName, info.LabID);
                    //    cboMasterResource.Items.Add(item);
                    //}
                }
                else if(objectDefName == "NUCLEARMEDICINE")
                {
                    lblMasterResource.Visible = true;
                    cboMasterResource.Visible = true;
                    cboMasterResource.Required = true;
                    this.ProcedureGrid.ReadOnly = true;
                    //Grid'i temizle
                    
                    //Radiology radRequest= (Radiology)dummyObjectContext.CreateObject("RADIOLOGY");
                    selectedActionType = ActionTypeEnum.NuclearMedicine;
                    //labList = InternalProcedureRequest.RemoteMethods.GetRemoteResourceDefinition(remoteSite.ObjectID, selectedActionType);
                    //foreach(RemotingInfoClass.ResLaboratoryDepartmentInfo info in labList)
                    //{
                    //    TTComboBoxItem item = new TTComboBoxItem(info.LabName, info.LabID);
                    //    cboMasterResource.Items.Add(item);
                    //}
                }
                else if(objectDefName == "PATHOLOGY")
                {
                    lblMasterResource.Visible = true;
                    cboMasterResource.Visible = true;
                    cboMasterResource.Required = true;
                    this.ProcedureGrid.ReadOnly = true;
                    //Grid'i temizle
                    
                    //Radiology radRequest= (Radiology)dummyObjectContext.CreateObject("RADIOLOGY");
                    selectedActionType = ActionTypeEnum.Pathology; 
                    //labList = InternalProcedureRequest.RemoteMethods.GetRemoteResourceDefinition(remoteSite.ObjectID, selectedActionType);
                    //foreach(RemotingInfoClass.ResLaboratoryDepartmentInfo info in labList)
                    //{
                    //    TTComboBoxItem item = new TTComboBoxItem(info.LabName, info.LabID);
                    //    cboMasterResource.Items.Add(item);
                    //}
                }
                else
                {
                    this.ProcedureGrid.ReadOnly = false;
                    lblMasterResource.Visible = false;
                    cboMasterResource.Visible = false;
                    cboMasterResource.Required = false;
                    SetProcedureDefinitionFilter();
                }

                dummyObjectContext.Dispose();
            }
#endregion InternalProcedureRequestForm_TestMenuDefinition_SelectedObjectChanged
        }

        private void OtherHospital_SelectedObjectChanged()
        {
#region InternalProcedureRequestForm_OtherHospital_SelectedObjectChanged
   if(this.OtherHospital.SelectedObject != null)
            {
                this.TestMenuDefinition.ReadOnly = false;
                //this.TestMenuDefinition.Enabled =true;
                //this.ProcedureGrid.ReadOnly = false;
            }
            else
            {
                this.TestMenuDefinition.ReadOnly = true;
                //this.TestMenuDefinition.Enabled =false;
                this.TestMenuDefinition.SelectedObject = null;
                
            }
#endregion InternalProcedureRequestForm_OtherHospital_SelectedObjectChanged
        }

        private void PreDiagnosis_TextChanged()
        {
#region InternalProcedureRequestForm_PreDiagnosis_TextChanged
   string text = PreDiagnosis.Text;
            ttPreDiagnosisLength.Text = text.Length.ToString()+ " karakter.";
#endregion InternalProcedureRequestForm_PreDiagnosis_TextChanged
        }

        private void tttextbox2_TextChanged()
        {
#region InternalProcedureRequestForm_tttextbox2_TextChanged
   string text = tttextbox2.Text;
            ttNotesLength.Text = text.Length.ToString()+ " karakter.";
#endregion InternalProcedureRequestForm_tttextbox2_TextChanged
        }

        private void ProcedureGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region InternalProcedureRequestForm_ProcedureGrid_CellValueChanged
   if (ProcedureGrid.CurrentCell.OwningColumn.Name == "ProcedureDefinition")
            {
                if(ProcedureGrid.CurrentCell.OwningRow.TTObject == null)
                    return;
                InternalSubActionProcedure procedure = (InternalSubActionProcedure)ProcedureGrid.CurrentCell.OwningRow.TTObject;
                ProcedureDefinition procedureDefinition = procedure.ProcedureObject;
                //ResOtherHospital otherHospital = procedure.OtherHospital;
                
                /*
                bool isProcedureDefinitionActive = (bool)TTMessageFactory.SyncCall(otherHospital.Site.ObjectID,"TTObjectClasses","Common","CheckProcedureDefinitionIsActive",procedureDefinition);
                if(!isProcedureDefinitionActive)
                {
                    ProcedureGrid.CurrentCell.OwningRow.Cells["ProcedureDefinition"].Value = null;
                    TTVisual.InfoBox.Show("Bu test seçtiğiniz XXXXXXde çalışılmamaktadır.");
                }
                */
            }
#endregion InternalProcedureRequestForm_ProcedureGrid_CellValueChanged
        }

        private void ShowMessageStatus_Click()
        {
#region InternalProcedureRequestForm_ShowMessageStatus_Click
   try
            {
                string s = null;
                if (String.IsNullOrEmpty(this._InternalProcedureRequest.MessageID))
                {
                    InfoBox.Show("Mesaj numarası bulunamadı", MessageIconEnum.InformationMessage);
                    return;
                }
                TTMessage message = TTMessageFactory.GetMessage(new Guid(this._InternalProcedureRequest.MessageID));
                if (message == null)
                {
                    InfoBox.Show("İlgili mesaj numarasına ait mesaj bulunamadı.",MessageIconEnum.InformationMessage);
                    return;
                }
                if (message.MessageStatus == TTMessageStatusEnum.Completed)
                {
                    if (message.ReturnValue != null)
                    {
                        Common.RemotingResultClass remotingResultClass = (Common.RemotingResultClass)message.ReturnValue;
                        s = remotingResultClass.resultMessage;
                        if (remotingResultClass.resultCode != "0")
                        {
                            string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Diğer XXXXXX Konsültasyon","Diğer XXXXXXden gelen hata mesajı : \r\n" + s + "\r\n Tekrar gönderim yapılmasını ister misiniz?");
                            if(result == "E")
                            {
                                //this._retrySendingConsultation = true;
                                InfoBox.Show("Mesajın tekrar gönderilebilmesi için Kaydet butonuna basınız.");
                                return;
                            }
                            else
                            {
                                //this._retrySendingConsultation = false;
                                return;
                            }                            
                        }                        
                    }
                    InfoBox.Show("'" + message.MessageID + "' nolu mesaj başarılı olarak gönderildi." + s,MessageIconEnum.InformationMessage);
                }
                else if (message.MessageStatus == TTMessageStatusEnum.MessageNotFound)
                {
                    InfoBox.Show("'" + message.MessageID + "' nolu mesaj bulunamadı.",MessageIconEnum.InformationMessage);
                }
                else if (message.MessageStatus == TTMessageStatusEnum.Waiting)
                {
                    InfoBox.Show("'" + message.MessageID + "' nolu mesaj beklemede.",MessageIconEnum.InformationMessage);
                }
                else
                {
                    //if (message.MessageLog != null)
                    //    s = "Hata Bilgileri : " + message.MessageLog.LogText;
                    InfoBox.Show("Gönderim sırasında '" + message.MessageID + "' nolu mesaj ile ilgili hata alındı.", MessageIconEnum.InformationMessage);
                }
                
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion InternalProcedureRequestForm_ShowMessageStatus_Click
        }

        protected override void PreScript()
        {
#region InternalProcedureRequestForm_PreScript
    base.PreScript();
    if (this._InternalProcedureRequest.CurrentStateDefID == InternalProcedureRequest.States.Procedure && String.IsNullOrEmpty(this._InternalProcedureRequest.MessageID) == true)
    {
        //InfoBox.Alert("İstek sahaya ulaştırılamadığı için işlem bir adım geri alınmıştır.İsteği işlem adımına ilerletmeniz gerekmektedir. " +
        //    "İsteğin sahaya ulaşıp ulaşmadığını kontrol etmek için 'Gönderim Durumunu Sorgula' butonunu kullanabilirsiniz.");
        this.UndoOperation();
        throw new Exception("İstek sahaya ulaştırılamadığı için işlem bir adım geriye alınmıştır.İsteği işlem adımına ilerletmeniz gerekmektedir. " +
            "İsteğin sahaya ulaşıp ulaşmadığını kontrol etmek için 'Gönderim Durumunu Sorgula' butonunu kullanabilirsiniz.");
        
    }
    
    if (this._InternalProcedureRequest.RequestDoctor == null)
    {
        if (Common.CurrentResource.UserType == UserTypeEnum.Doctor)
        {
            this._InternalProcedureRequest.RequestDoctor = Common.CurrentResource;
        }
        else
        {
            this._InternalProcedureRequest.RequestDoctor = null;
        }
    }
    else
    {
        if (this._InternalProcedureRequest.RequestDoctor.UserType != UserTypeEnum.Doctor)
        {
            this._InternalProcedureRequest.RequestDoctor = null;    
        }
    }
#endregion InternalProcedureRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region InternalProcedureRequestForm_PostScript
    base.PostScript(transDef);

            string preDiagnosisText = PreDiagnosis.Text;
            if(preDiagnosisText.Length > 2000)
            {
                throw new Exception("Kısa Anamnez ve Klinik Bulgular alanına en fazla 2000 karakter uzunluğunda metin girilmesine izin verilmektedir!");
            }
            
            
            string notesText = tttextbox2.Text;
            if(notesText.Length > 2000)
            {
                throw new Exception("Açıklamalar alanına en fazla 2000 karakter uzunluğunda metin girilmesine izin verilmektedir!");
            }
#endregion InternalProcedureRequestForm_PostScript

            }
            
#region InternalProcedureRequestForm_Methods
        public ActionTypeEnum selectedActionType;
        
        public void SetProcedureDefinitionFilter()
        {
            string procuderDefNames = this.GetProcedureDefinitionNames();
            string filter = "1=2";
            if (procuderDefNames != "")
                filter = " THIS.OBJECTDEFNAME IN(" + procuderDefNames + ")";
            ((ITTListBox)this.ProcedureDefinition).ListFilterExpression = filter;
        }
        
        public void SetLaboratoryProcedureDefinitionFilter(List<Guid> labTestDefIDs)
        {
            string filter = String.Empty;
            string objectIDs = String.Empty;
            if(labTestDefIDs.Count > 0)
            {
                foreach(Guid id in labTestDefIDs)
                {
                    objectIDs += ConnectionManager.GuidToString(id) + ",";
                }
                if (objectIDs == string.Empty)
                {
                    ((ITTListBox)this.ProcedureDefinition).ListFilterExpression = "";
                }
                else
                {
                    filter = objectIDs.Substring(0, objectIDs.Length - 1);
                    ((ITTListBox)this.ProcedureDefinition).ListFilterExpression = " THIS.OBJECTID IN (" + filter + ")";
                }
            }
        }
        
        public string GetProcedureDefinitionNames()
        {
            string procedureDefNames = "";
            if(this.TestMenuDefinition.SelectedObject == null)
                InfoBox.Alert("Tetkik İşlem Türü boş olamaz.");
            else
            {
                //string objectDefName = ((TestActionTypesEnum)Enum.Parse(typeof(TestActionTypesEnum), this.TestActionType.ControlValue.ToString())).ToString().ToUpperInvariant();
                string objectDefName = ((MenuDefinition)this.TestMenuDefinition.SelectedObject).ObjectDefinitionName.ToUpperInvariant();
                TTObjectDef objDef = null;
                TTObjectDefManager.Instance.ObjectDefs.TryGetValue(objectDefName, out objDef);
                if (objDef != null)
                {
                    if (objDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant()))
                    {
                        foreach (TTObjectRelationSubtypeDef rSubType in objDef.AllChildRelationsSubtypeDefs)
                        {
                            if (rSubType.RelationDef.ParentObjectDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant()) && rSubType.RelationDef.ChildObjectDef.IsOfType(typeof(SubActionProcedure).Name.ToUpperInvariant()))
                            {
                                if (rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.Name.ToUpperInvariant() != "PROCEDUREDEFINITION")
                                {
                                    if (procedureDefNames != "")
                                        procedureDefNames = procedureDefNames + ",";
                                    procedureDefNames = procedureDefNames + "'" + rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.Name.ToUpperInvariant() + "'";
                                }
                                foreach (TTDefinitionManagement.TTObjectRelationSubtypeDef pi in rSubType.ChildObjectDef.AllParentRelationsSubtypeDefs.Values)
                                {
                                    if (Common.IsBaseOfInheritedObject(pi.ParentObjectDef, TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"]))
                                    {
                                        if (procedureDefNames != "")
                                            procedureDefNames = procedureDefNames + ",";
                                        procedureDefNames = procedureDefNames + "'" + pi.ParentObjectDef.Name.ToUpperInvariant() + "'";
                                    }
                                }
                                foreach (TTRelationParentRestrictions rr in rSubType.ChildObjectDef.ParentRelationRestrictions.Values)
                                {
                                    foreach (TTObjectDef od in rr.RestrictedObjectDefs)
                                    {
                                        if (Common.IsBaseOfInheritedObject(od, TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"]))
                                        {
                                            if (procedureDefNames != "")
                                                procedureDefNames = procedureDefNames + ",";
                                            procedureDefNames = procedureDefNames + "'" + od.Name.ToUpperInvariant() + "'";
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
            return procedureDefNames;
        }
        
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if(transDef != null && transDef.ToStateDefID == InternalProcedureRequest.States.Procedure)
            {
                //ResOtherHospital otherHospital = procedure.OtherHospital;
                Sites remoteSite = this._InternalProcedureRequest.OtherHospital.Site;
                Sites requesterSite = TTObjectClasses.SystemParameter.GetSite();
                List<ProcedureDefinition> procDefList = new List<ProcedureDefinition>();
                foreach(ITTGridRow row in ProcedureGrid.Rows)
                {
                    InternalSubActionProcedure procedure = (InternalSubActionProcedure)row.TTObject;
                    ProcedureDefinition procedureDefinition = procedure.ProcedureObject;
                    procDefList.Add(procedureDefinition);
                }
                EpisodeActionWithDiagnosis episodeAction = this._InternalProcedureRequest.CreateRequestOfRelatedProcedureDefinition(procDefList, this._InternalProcedureRequest.OtherHospital);
                
                
                List<SubActionProcedure> subProcList = new List<SubActionProcedure>();
                foreach(SubActionProcedure subProc in episodeAction.SubactionProcedures)
                {
                    subProcList.Add(subProc);
                }
                Guid masterResourceID = new Guid("{00000000-0000-0000-0000-000000000000}");
                if(this.cboMasterResource.SelectedItem != null)
                {
                    masterResourceID = new Guid(cboMasterResource.SelectedItem.Value.ToString());
                }
                this._InternalProcedureRequest.SendInternalProcedureRequest(remoteSite.ObjectID, episodeAction, requesterSite, subProcList,episodeAction.ObjectID, masterResourceID);
                
                this._InternalProcedureRequest.CreatedEpisodeAction = episodeAction;

                //Nesnenin remote mesajının oluşup oluşmadığına dair kontrolü burada yapılır.
                //Eğer mesaj oluşmamış ise işlem bir önceki state'e çekilir.
                /* 
                if (this._InternalProcedureRequest.CurrentStateDefID == InternalProcedureRequest.States.Procedure && String.IsNullOrEmpty(this._InternalProcedureRequest.MessageID) == true)
                {
                    InfoBox.Alert("İstek sahaya ulaştırılamadığı için işlem bir adım geri alınmıştır.İsteği işlem adımına ilerletmeniz gerekmektedir. " +
                        "İsteğin sahaya ulaşıp ulaşmadığını kontrol etmek için 'Gönderim Durumunu Sorgula' butonunu kullanabilirsiniz.");
                    this.UndoOperation();
                }
                */
                
            }
        }
        
        private void UndoOperation()
        {
            try
            {
                string reasonOfStepBack = "Uzak sunucuya gönderilecek mesajın oluşturulamaması nedeniyle işlem geri alınmıştır.";
                EpisodeAction action = (EpisodeAction)this._InternalProcedureRequest.ObjectContext.GetObject(this._InternalProcedureRequest.ObjectID, typeof(EpisodeAction));
                ((ITTObject)action).UndoLastTransition(reasonOfStepBack);
                this._InternalProcedureRequest.ObjectContext.Save();

            }
            catch (Exception ex)
            {
                InfoBox.Alert(ex);
            } 
        }
        
#endregion InternalProcedureRequestForm_Methods
    }
}