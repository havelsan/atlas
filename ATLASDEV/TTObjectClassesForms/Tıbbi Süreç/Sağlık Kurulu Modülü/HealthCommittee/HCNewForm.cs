
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
    /// Sağlık Kurulu
    /// </summary>
    public partial class HCNewForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            
            //ReasonForExamination.SelectedObjectChanged += new TTControlEventDelegate(ReasonForExamination_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
          
            //ReasonForExamination.SelectedObjectChanged -= new TTControlEventDelegate(ReasonForExamination_SelectedObjectChanged);
            base.UnBindControlEvents();
        }
       

//        private void ReasonForExamination_SelectedObjectChanged()
//        {
//#region HCNewForm_ReasonForExamination_SelectedObjectChanged
//   string sPSKID = TTObjectClasses.SystemParameter.GetParameterValue("PROFESORLERSAGLIKKURULUSEBEBI", "17B8205F-82C2-40BA-A45C-73009F433578");
//            Guid pskID = new Guid(sPSKID);
//            //if (this.ReasonForExamination.SelectedObjectID != null && this.ReasonForExamination.SelectedObjectID.Value.Equals(pskID))
//            //{
//            //    InfoBox.Show("Bu işlem için \"Profesörler Sağlık Kurulu için\" seçeneği seçilmemelidir.");
//            //    this.ReasonForExamination.Text = "";
//            //    this.ReasonForExamination.SelectedObjectID = null;
//            //}
//            //else
//            //    this._HealthCommittee.FillHospitalsUnitsGridByReasonForExamination();

//            Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));

//            if (GridHospitalsUnits.Rows.Count > 0)
//            {
//                foreach (ITTGridRow row in GridHospitalsUnits.Rows)
//                {
//                    if (this._HealthCommittee.HospitalsUnits[row.Index].Hospitals != null)
//                    {
//                        if (this._HealthCommittee.HospitalsUnits[row.Index].Hospitals is ResOtherHospital)
//                        {
//                            if (((ResOtherHospital)this._HealthCommittee.HospitalsUnits[row.Index].Hospitals).Site.ObjectID == siteID)
//                            {
//                                GridHospitalsUnits.Rows[row.Index].Cells[Unit.Name].ReadOnly = false;
//                                GridHospitalsUnits.Rows[row.Index].Cells[ReferableResource.Name].ReadOnly = true;
//                                GridHospitalsUnits.Rows[row.Index].Cells[Speciality.Name].ReadOnly = true;
//                            }
//                            else
//                            {
//                                GridHospitalsUnits.Rows[row.Index].Cells[Unit.Name].ReadOnly = true;
//                                GridHospitalsUnits.Rows[row.Index].Cells[ReferableResource.Name].ReadOnly = false;
//                                GridHospitalsUnits.Rows[row.Index].Cells[Speciality.Name].ReadOnly = true;
//                            }
//                        }
//                        else
//                        {
//                            GridHospitalsUnits.Rows[row.Index].Cells[Unit.Name].ReadOnly = true;
//                            GridHospitalsUnits.Rows[row.Index].Cells[ReferableResource.Name].ReadOnly = true;
//                            GridHospitalsUnits.Rows[row.Index].Cells[Speciality.Name].ReadOnly = false;
//                        }
//                    }
//                }
//            }
//            else
//            {
//                GridHospitalsUnits.Rows.Add();
//                if (TTObjectClasses.SystemParameter.GetSite().ResOtherHospital != null && TTObjectClasses.SystemParameter.GetSite().ResOtherHospital.Count > 0)
//                    GridHospitalsUnits.Rows[0].Cells["Hospital"].Value = TTObjectClasses.SystemParameter.GetSite().ResOtherHospital[0].ObjectID.ToString();

//                if (this._HealthCommittee.Episode.PatientStatus.Value == PatientStatusEnum.Outpatient)
//                {
//                    if (Common.CurrentResource.SelectedOutPatientResource != null)
//                        GridHospitalsUnits.Rows[0].Cells["Unit"].Value = Common.CurrentResource.SelectedOutPatientResource.ObjectID;
//                }
//                else
//                {
//                    if (Common.CurrentResource.SelectedInPatientResource != null)
//                        GridHospitalsUnits.Rows[0].Cells["Unit"].Value = Common.CurrentResource.SelectedInPatientResource.ObjectID;
//                }
//            }
            
//            // Kurum Hastası ise Muayene Nedenine göre Ücreti Ödeyecek alanı set edilir
//            this.WhoPays.ReadOnly = true;
//            SubEpisodeProtocol sep = _HealthCommittee.SubEpisode.ActiveSubEpisodeProtocol;
//            if(sep != null && sep.Protocol != null && sep.Protocol.Type != ProtocolTypeEnum.Paid) // Kurum Hastası ise
//            {
//                if(this._HealthCommittee.HCRequestReason.ReasonForExamination == null)
//                    this._HealthCommittee.WhoPays = WhoPaysEnum.PayerPays;
//                else
//                {

//                    //TODO NE:  hasta kabulden alınacak bu veri
//                    //if(this._HealthCommittee.ReasonForExamination.WhoPays == null || this._HealthCommittee.ReasonForExamination.WhoPays == WhoPaysAskUserEnum.PayerPays)
//                    //    this._HealthCommittee.WhoPays = WhoPaysEnum.PayerPays;
//                    //else if (this._HealthCommittee.ReasonForExamination.WhoPays == WhoPaysAskUserEnum.PatientPays)
//                    //    this._HealthCommittee.WhoPays = WhoPaysEnum.PatientPays;
//                    //else
//                    //{
//                        this._HealthCommittee.WhoPays = null;
//                        this.WhoPays.ReadOnly = false;
//                  //  }
//                }
//            }
//#endregion HCNewForm_ReasonForExamination_SelectedObjectChanged
//        }

      
        protected override void PreScript()
        {
#region HCNewForm_PreScript
    base.PreScript();
            this.SetEpisodeRelations();

            if (_HealthCommittee.CurrentStateDefID.Value.Equals(HealthCommittee.States.New))
            {
                // BLOCKHCFROMNEWPROCESS sistem parametresi TRUE ise Ayaktan hastalar için yeni süreçten Sağlık Kurulu işlemi başlatılamaması kontrolü
                if(TTObjectClasses.SystemParameter.GetParameterValue("BLOCKHCFROMNEWPROCESS","FALSE").ToUpper() == "TRUE" && _HealthCommittee.Episode.PatientStatus == PatientStatusEnum.Outpatient)
                {
                    ITTObject iTTobject = (ITTObject)this._HealthCommittee;
                    if (iTTobject.IsNew)
                        throw new Exception("Ayaktan hastalar için Sağlık Kurulu işlemi yeni süreçten başlatılamaz. Sadece kabul sebebi 'Sağlık Kurulu Muayenesi' olan yeni hasta kabul yaparak başlatılabilir.");
                }

                // İşlemi başlatan doktor set edilir
                this.SetProcedureDoctorAsCurrentResource();

                /*
                if(TTObjectClasses.SystemParameter.GetParameterValue("GETCOMPLETEDHCSUMMARIES","FALSE").ToUpper() == "TRUE")
                {
                    // Önceki Sağlık Kurulu İşlemleri getirilir
                    System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(HealthCommittee.RunGetHCSummariesThead));
                    t.Start(this._HealthCommittee);
                }
                */

                // Butonlar drop edilir
                this.Text = "Sağlık Kurulu İstek(" + this._HealthCommittee.CurrentStateDef.DisplayText + ")";              
                this.DropStateButton(HealthCommittee.States.Cancelled);
                //this.cmdOK.Visible = false;               
               
                
                // Kabul türüne göre, Yeni adımında "Periyodik Muayene" veya "Özel Bakım Muayenesi" set edilir
                //todo bg
                /*
                if (this._EpisodeAction.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.PeriodicExamination)
                {
                    ReasonForExaminationDefinition perExamdef = Common.ReasonForExaminationByCode(this._EpisodeAction.ObjectContext, 19);
                    if (perExamdef != null)
                        this._HealthCommittee.HCRequestReason.ReasonForExamination = perExamdef;
                    else
                        InfoBox.Alert(SystemMessage.GetMessage(490));
                }
                else if (this._EpisodeAction.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.SpacialCareExamReport)
                {
                    ReasonForExaminationDefinition speExamdef = Common.ReasonForExaminationByCode(this._EpisodeAction.ObjectContext, 36);
                    if (speExamdef != null)
                        this._HealthCommittee.HCRequestReason.ReasonForExamination = speExamdef;
                    else
                        InfoBox.Alert(SystemMessage.GetMessage(492));
                }*/
                // İlgili klasörde fotoğraf bulunursa eklenir
              

                SubEpisodeProtocol sep = SubEpisode.GetOpenSubEpisodeProtocol(_HealthCommittee.SubEpisode);
                if(sep == null)
                    throw new TTUtils.TTException("Altvakada açık anlaşma bulunamadığı için Ücreti Ödeyecek belirlenemiyor.");
                
                if(sep.Protocol != null && sep.Protocol.Type == ProtocolTypeEnum.Paid) // Ücretli hasta
                    this._HealthCommittee.WhoPays = WhoPaysEnum.PatientPays;
                else // Kurum hastası
                    this._HealthCommittee.WhoPays = WhoPaysEnum.PayerPays;
            }
            else
            {
              //  this.ReasonForExamination.ReadOnly = true; // Ne Maksatla Muayene Edildiği alanı sadece yeni adımında seçilebilir                            
           
            }

            if (this._HealthCommittee.ReturnDescriptions.Count > 0)
            {
                this.ReturnDescriptionGrid.Visible = true;
                this.labelReturnDescription.Visible = true;
                this.ReturnDescriptionGrid.Rows.Clear();

                foreach (HealthCommittee_ReturnDescriptionsGrid pGrid in this._HealthCommittee.ReturnDescriptions)
                {
                    if (pGrid.RelatedStateID != null && pGrid.RelatedStateID == this._HealthCommittee.CurrentStateDefID.Value.ToString())
                    {
                        ITTGridRow newRow = this.ReturnDescriptionGrid.Rows.Add();
                        newRow.Cells["EntryDate"].Value = pGrid.EntryDate.Value.ToString();
                        newRow.Cells["ReturnDescription"].Value = pGrid.Description;
                        newRow.Cells["OwnerUser"].Value = pGrid.UserName;
                    }
                }
            }          

           
#endregion HCNewForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region HCNewForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            if (_HealthCommittee.CurrentStateDefID.Value.Equals(HealthCommittee.States.New))
            {
                foreach (HealthCommittee healthCommittee in this._HealthCommittee.Episode.HealthCommittees)
                {
                    if (!healthCommittee.IsCancelled && healthCommittee.ObjectID != _HealthCommittee.ObjectID)
                    {
                        string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Vakada zaten aktif bir Sağlık Kurulu işlemi mevcuttur. Yeni bir Sağlık Kurulu işlemi başlatmak istediğinize emin misiniz ?", 1);
                        if (result == "H")
                            throw new Exception(SystemMessage.GetMessage(1201));
                        break;
                    }
                }
            }
#endregion HCNewForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region HCNewForm_PostScript
    base.PostScript(transDef);

            this._HealthCommittee.Requester = Common.CurrentResource; // İsteği yapan kullanıcı ataması

            if (transDef != null)
            {
                if(transDef.FromStateDefID.Equals(HealthCommittee.States.New))
                {
                    if (this._HealthCommittee.HCRequestReason.ReasonForExamination == null)
                        throw new TTUtils.TTException(SystemMessage.GetMessage(494));

                    this.ControlUserResourceExistsInGrid();
                }
            }
#endregion HCNewForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region HCNewForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if (transDef != null)
            {
                //if (transDef.ToStateDefID.Equals(HealthCommittee.States.Rejected))
                //{
                //    StringEntryForm pDescForm = new StringEntryForm();
                //    DialogResult res = pDescForm.ShowStringDialog(this, "Red Açıklamasını Giriniz");
                //    if (res == DialogResult.OK)
                //        this._HealthCommittee.ReasonOfReject = pDescForm.StringContent;
                //}

                if (transDef.FromStateDefID.Equals(HealthCommittee.States.CommitteeAcceptance) && transDef.ToStateDefID.Equals(HealthCommittee.States.New))
                {
                    this.ReturnDescriptionInput();
                }
            }
#endregion HCNewForm_ClientSidePostScript

        }

#region HCNewForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                // "Yeni" veya "Tamamlanmamış SK Onay" adımlarından "SKM Fişi İstek" adımına geçerken HCUncompleted merkezde oluşturulur
                //if((transDef.FromStateDefID == HealthCommittee.States.New || transDef.FromStateDefID == HealthCommittee.States.ApproveOfHCUncompleted) &&
                //   transDef.ToStateDefID == HealthCommittee.States.HCESlipRequest)
                //    this._HealthCommittee.RunCreateHCUncompleted(HCUncompleted.States.Uncompleted);
                
                if(transDef.FromStateDefID == HealthCommittee.States.New)
                {
                    // Laboratuvar isteklerinin LabAsistan'a düşmesi için eklendi
                    if (transDef.ToStateDefID == HealthCommittee.States.CommitteeAcceptance)
                        HealthCommittee.SendToLab(this._HealthCommittee);

                    if ( transDef.ToStateDefID == HealthCommittee.States.CommitteeAcceptance)
                    {
                        Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                        TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                        cache.Add("VALUE", this._HealthCommittee.ObjectID.ToString());
                        parameters.Add("TTOBJECTID", cache);


                        if (this._HealthCommittee.HCRequestReason.ReasonForExamination.Code == 36)
                            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SpecialCareExaminationReport), true, 1, parameters);
                        else
                        {
                            if (this._HealthCommittee.HCRequestReason.ReasonForExamination.HealthCommitteeType == HealthCommitteeTypeEnum.FlierCommittee)
                            {
                                if (this._HealthCommittee.HCRequestReason.ReasonForExamination.ExaminationType == ExaminationTypeEnum.FlierExaminationForFiveYear)
                                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HCEFlierSlipReportForFiveYears), true, 1, parameters);
                                else
                                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HealthCommitteeExaminationFlierSlipReport), true, 1, parameters);
                            }
                            else
                                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HealthCommitteeExaminationSlipReport), true, 1, parameters);
                        }
                    }
                }
            }
        }

        private void SetEpisodeRelations()
        {
            //            MilitaryClassDefinitions militaryClass= this._HealthCommittee.Episode.MyMilitaryClass();
            //            if (militaryClass!=null)
            //            {
            //                this.MilitaryClass.SelectedObjectID=militaryClass.ObjectID;
            //            }

            //            RankDefinitions rank= this._HealthCommittee.Episode.MyRank();
            //            if (rank!=null)
            //            {
            //                this.Rank.SelectedObjectID=rank.ObjectID;
            //            }

            //            MilitaryOffice militaryOffice = this._HealthCommittee.Episode.MyMilitaryOffice();
            //            if (militaryOffice!=null)
            //            {
            //                this._HealthCommittee.LocalBranch = militaryOffice;
            //                this.MilitaryOffice.SelectedObjectID=militaryOffice.ObjectID;
            //            }

            //if (this._HealthCommittee.CurrentStateDefID == HealthCommittee.States.New)
            //    this._HealthCommittee.LocalBranch = this._HealthCommittee.Episode.MilitaryOffice;

            //RelationshipDefinition relationship = this._HealthCommittee.Episode.MyRelationship();
            //if (relationship != null)
            //{
            //    this.Relationship.SelectedObjectID = relationship.ObjectID;
            //}

            //string headOfFamilyName = this._HealthCommittee.Episode.MyHeadOfFamilyName();
            //if (headOfFamilyName != null)
            //{
            //    this.HeadOfFamilyName.Text = headOfFamilyName;
            //}

           

            //this.EmploymentRecordID.Text = this._HealthCommittee.Episode.MyEmploymentRecordID();

            //            MilitaryUnit pMUnit = this._HealthCommittee.Episode.MyMilitaryUnit();
            //            if(pMUnit != null)
            //            {
            //                this.MilitaryUnit.SelectedObjectID = pMUnit.ObjectID;
            //            }

            //this.Adres.Text = this._HealthCommittee.Episode.MyAddress();

           // this.DocumentNumber.Text = SubEpisode.MyDocumentNumber(this._HealthCommittee.SubEpisode);

            DateTime? pDocDate = SubEpisode.MyDocumentDate(this._HealthCommittee.SubEpisode);
            if (pDocDate != null)
                this.DocumentDate.ControlValue = pDocDate.Value;
        }
        

        // Doktor olan kullanıcılar için, muayene nedeni tanım ekranındaki Muayene Edecek Birimler/XXXXXXler gridi boş ise,
        // Havale Edilen Birimler XXXXXXler gridinde doktorun bağlı olduğu birimlerden en az birinin olduğunu kontrol eder
        private void ControlUserResourceExistsInGrid()
        {
            if (!Common.CurrentUser.IsPowerUser && !Common.CurrentUser.IsSuperUser)
            {
                if (Common.CurrentDoctor != null && this._HealthCommittee.HCRequestReason.ReasonForExamination != null)
                {
                    if (this._HealthCommittee.HCRequestReason.ReasonForExamination.HospitalsUnits != null && this._HealthCommittee.HCRequestReason.ReasonForExamination.HospitalsUnits.Count == 0)
                    {
                        bool resourceExists = false;
                        foreach (BaseHealthCommittee_HospitalsUnitsGrid unitsGrid in this._HealthCommittee.HospitalsUnits)
                        {
                            if (unitsGrid.Unit != null)
                            {
                                foreach (UserResource userResource in Common.CurrentResource.UserResources)
                                {
                                    if (userResource.Resource != null && unitsGrid.Unit.ObjectID == userResource.Resource.ObjectID)
                                    {
                                        resourceExists = true;
                                        break;
                                    }
                                }
                                if (resourceExists)
                                    break;
                            }
                        }

                        if (!resourceExists)
                            throw new TTUtils.TTException("Sağlık Kurulu işlemi başlatabilmek için bağlı olduğunuz birimlerden en az biri seçili olmalıdır.");
                    }
                }
            }
        }
        
#endregion HCNewForm_Methods

#region HCNewForm_ClientSideMethods
        private void ReturnDescriptionInput()
        {
            //TODO:ShowEdit!
            //StringEntryForm pReturnForm = new StringEntryForm();
            //DialogResult res = pReturnForm.ShowStringDialog(this, "İade Açıklamasını Giriniz");
            //if (res == DialogResult.OK)
            //{
            //    HealthCommittee_ReturnDescriptionsGrid theGrid = null;
            //    theGrid = new HealthCommittee_ReturnDescriptionsGrid(this._HealthCommittee.ObjectContext);
            //    theGrid.Description = pReturnForm.StringContent;
            //    theGrid.EntryDate = DateTime.Now;
            //    theGrid.UserName = Common.CurrentResource == null ? "" : Common.CurrentResource.Name;

            //    this._HealthCommittee.ReturnDescriptions.Add(theGrid);
            //}
            var a = 1;
        }
        
       
        
#endregion HCNewForm_ClientSideMethods
    }
}