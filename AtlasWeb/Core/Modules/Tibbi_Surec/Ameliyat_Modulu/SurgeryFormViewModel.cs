//$E6338597
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTConnectionManager;
using System.Collections;

using TTUtils;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class SurgeryServiceController
    {
        partial void PreScript_SurgeryForm(SurgeryFormViewModel viewModel, Surgery surgery, TTObjectContext objectContext)
        {
            if (surgery.CurrentStateDefID == Surgery.States.Surgery)
            {
                viewModel.HasUncompleteSubSurgery = surgery.HasUncompletedLinkedAction(surgery);
            }
            else if (surgery.CurrentStateDefID == Surgery.States.WaitingForSubSurgeries) //WaitingForSubsurgeries stepi kullanıcı tarafından  ControlSubSurgeries'e  gönderilmesin diye kaldırıldı
            {
                viewModel.HasUncompleteSubSurgery = true;
                viewModel.ReadOnly = true;
            }


            viewModel.PatientObjectId = surgery.Episode.Patient.ObjectID.ToString();
            // Postta set edilyor
            //if (surgery.SurgeryReportDate == null)
            //{
            //    surgery.SurgeryReportDate = Common.RecTime();
            //}
            viewModel.vitalSingsViewModel = surgery.GetVitalSingsFormViewModel(objectContext);

            viewModel.SurgeryProcedureFormViewModelList = SurgeryProcedureServiceController.GetSurgeryProcedureFormViewModelList(surgery.MainSurgeryProcedures.Where(x => x.CurrentStateDefID != MainSurgeryProcedure.States.Cancelled).ToList<SurgeryProcedure>());

            viewModel.IsRequiredPathology = false;//Ameliyat hizmeti patoloji gerektiriyor ise patoloji istek yapmaya zorlanacak!
            var pathologyOperationNeededProcedure = viewModel.SurgeryProcedureFormViewModelList.Where(c => c.ProcedureDefinitions.FirstOrDefault().PathologyOperationNeeded == true);
            if (pathologyOperationNeededProcedure.Count() > 0 && surgery.SubEpisode != null)
            {
                var pathologyExist = PathologyRequest.GetPathologyRequestBySubEpisode(surgery.SubEpisode.ObjectID.ToString());
                if (pathologyExist.Count() == 0)//patoloji gerektirdiği halde subepisode'da patoloji yok ise uyarı verilecek
                {
                    viewModel.IsRequiredPathology = true;
                }
            }

            // Diğer Branşlara ait ameliyat Özeti
            viewModel.OtherSurgerySummaryFormViewModellList = SurgeryServiceController.GetOtherSurgerySummaryFormViewModellList(surgery, surgery);

            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalışmamalı
            viewModel.GridSurgeryExpendsGridList = viewModel.GridSurgeryExpendsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
            //ContextToViewModel den sonra çağırılmalı //TANI için
            viewModel.GridDiagnosisGridList = surgery.DiagnosisGrid_PreScript();

            // Doktrun Uzmanlığını set etmek için
            var surgeryPersonneSpecilaityList = new List<SurgeryPersonneSpecilaity>();
            foreach (var surgeryPersonnel in surgery.AllSurgeryPersonnels)
            {
                if (surgeryPersonnel.Personnel != null)
                {
                    if (surgeryPersonneSpecilaityList.FirstOrDefault(dr => dr.userObjectId == surgeryPersonnel.Personnel.ObjectID.ToString()) == null)
                    {
                        var surgeryPersonneSpecilaity = new SurgeryPersonneSpecilaity();
                        surgeryPersonneSpecilaity.userObjectId = surgeryPersonnel.Personnel.ObjectID.ToString();
                        surgeryPersonneSpecilaity.specilaityName = surgeryPersonnel.Personnel.GetSpecialityName();
                        surgeryPersonneSpecilaityList.Add(surgeryPersonneSpecilaity);

                    }
                }
            }
            viewModel.SurgeryPersonneSpecilaityList = surgeryPersonneSpecilaityList.ToArray();

            if (surgery.SubEpisode != null && surgery.SubEpisode.StarterEpisodeAction != null)
            {
                var _InPatientTreatmentClinicApplication = surgery.SubEpisode.StarterEpisodeAction as InPatientTreatmentClinicApplication;
                if (_InPatientTreatmentClinicApplication != null)
                {
                    viewModel.InpatientPhyAppObjectId = _InPatientTreatmentClinicApplication.InPatientPhysicianApplication.Count > 0 ? _InPatientTreatmentClinicApplication.InPatientPhysicianApplication.FirstOrDefault().ObjectID : Guid.Empty;
                }
            }

            viewModel.MasterResourceSpecialityID = surgery.ProcedureSpeciality.ObjectID.ToString(); 
        }

        partial void PostScript_SurgeryForm(SurgeryFormViewModel viewModel, Surgery surgery, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (surgery.SurgeryReport != null && !string.IsNullOrEmpty(surgery.SurgeryReport.ToString()) && surgery.SurgeryReportDate == null)
            {
                surgery.SurgeryReportDate = Common.RecTime();
            }

            // Serverdan gelen SurgeryProcedureleri  Contexte add etmeden serverdaki Surgeryprocedure contexte eklenirse (ki bu . mainprocedure Kodu çalıştığında oluyor) clientdakiler tekrar eklenemiyor O yüzden Bu kod en tepeye çekildi
            SurgeryProcedureServiceController.SaveSurgeryProcedureFormViewModelList(objectContext, viewModel.SurgeryProcedureFormViewModelList);

            if (transDef != null)
            {
                if ((transDef.ToStateDefID == Surgery.States.Completed || transDef.ToStateDefID == Surgery.States.WaitingForSubSurgeries) && viewModel.IsRequiredPathology == true)
                {
                    var pathologyExist = PathologyRequest.GetPathologyRequestBySubEpisode(surgery.SubEpisode.ObjectID.ToString());
                    if (pathologyExist.Count() == 0)
                    {
                        throw new Exception("Patoloji işlemi gerektiren bir ameliyat seçildi! Ameliyatın tamamlanması için lütfen ekranı önce 'Patoloji isteği' yapıp daha sonra 'Kaydet/Tamamla' butonuna basınız");
                    }

                }
                // Form açıldığında henüz tamamlanmamış son Linkedaction form kapanmadan önce kapatılırsa beklemede kalmasın diye
                if (transDef.ToStateDefID == Surgery.States.WaitingForSubSurgeries && surgery.HasUncompletedLinkedAction(surgery) == false)
                {
                    surgery.CurrentStateDefID = Surgery.States.Completed;
                    transDef = surgery.TransDef;
                }

                if (transDef.ToStateDefID == Surgery.States.Completed && surgery.HasNewSubSurgeries())
                {
                    throw new Exception(TTUtils.CultureService.GetText("M25360", "Cerrahi Ekip alanından Yeni bir birime ait Doktor seçildi Ek ameliyatın başlatılması için lütfen ekranı önce 'Kaydet' daha sonra 'Kaydet/Tamamla' butonuna basınız"));
                }

                this.CheckSurgeryFormPost(transDef, surgery);

                surgery.CheckCesareanAndFireBirthReport();

                //if (this._Surgery.Episode.PatientStatus == PatientStatusEnum.Outpatient && Episode.IsMedulaEpisode(_Surgery.Episode) == true && this.IsMedulaProvisionNecessaryProcedureExists() == true)
                //{
                //    if (this._Surgery.MedulaProvision == null)
                //    {
                //        MedulaProvision _medulaProvision = new MedulaProvision(this._Surgery.ObjectContext);
                //        this._Surgery.SetMedulaProvisionInitalProperties(_medulaProvision);
                //        this._Surgery.MedulaProvision = _medulaProvision;
                //        this._Surgery.CreateSubEpisode = true;
                //    }
                //    this._Surgery.GetSurgeryMedulaTakip();
                //}

            }

            //TANI için
            surgery.DiagnosisGrid_PostScript(viewModel.GridDiagnosisGridList);
            surgery.SetVitalSingsFormViewModel(viewModel.vitalSingsViewModel);

            // surgery.FireSubSurgeries();

            if (!(surgery.CurrentStateDefID == Surgery.States.Completed && transDef == null)) // Tamamlandı adımında kaydet yapılınca yeniden ücretlendirme yapılmasın
                surgery.AccountingOperation();
        }



        // Sarf için Template
        partial void AfterContextSaveScript_SurgeryForm(SurgeryFormViewModel viewModel, Surgery surgery, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null)
            {
                if (surgery.SurgeryTemplate != null && surgery.SurgeryTemplate == true)
                {
                    if (string.IsNullOrEmpty(viewModel.SurgeryTemplateDescription) == false)
                    {
                        IList userTemplates = Common.CurrentResource.UserTemplates.Select("TAOBJECTDEFID = " + ConnectionManager.GuidToString(surgery.ObjectDef.ID) + " AND DESCRIPTION = '" + viewModel.SurgeryTemplateDescription + "'");
                        if (userTemplates.Count == 0)
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            UserTemplate userTemplate = new UserTemplate(context);
                            userTemplate.ResUser = (ResUser)Common.CurrentResource;
                            userTemplate.Description = viewModel.SurgeryTemplateDescription;
                            userTemplate.TAObjectID = surgery.ObjectID;
                            userTemplate.TAObjectDefID = surgery.ObjectDef.ID;
                            userTemplate.FiliterData = surgery.ObjectDef.Name;
                            context.Save();
                            context.Dispose();
                        }
                        else
                        {
                            TTUtils.InfoMessageService.Instance.ShowMessage(viewModel.SurgeryTemplateDescription + " isimli şablonunuz bulunduğu için şablon kayıt edilemedi");
                        }
                    }
                    else
                        TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M26960", "Şablona isim vermeden kaydedemezsiniz."));
                }

                if ((transDef.FromStateDefID == Surgery.States.Surgery && transDef.ToStateDefID == Surgery.States.Completed) || (transDef.FromStateDefID == Surgery.States.Surgery && transDef.ToStateDefID == Surgery.States.WaitingForSubSurgeries))
                {
                    surgery.NotifyAndSendSMSDoctors();
                }
            }
        }

        public void CheckSurgeryFormPost(TTObjectStateTransitionDef transDef, Surgery surgery)
        {
            if (transDef != null)
            {
                if (transDef.ToStateDefID != Surgery.States.Rejected && transDef.ToStateDefID != Surgery.States.Cancelled && transDef.ToStateDefID != Surgery.States.SurgeryRequest)
                {
                    if (surgery.AnesthesiaAndReanimation != null)
                    {
                        if (surgery.AnesthesiaAndReanimation.CurrentStateDefID == AnesthesiaAndReanimation.States.Cancelled)
                            throw new Exception(TTUtils.CultureService.GetText("M26078", "İlgili Anestezi isteği iptal edilmiştir.Ameliyat İşlemine devam edilemez."));
                    }

                    if (surgery.ProcedureDoctor == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26936", "Sorumlu cerrah bilgisini giriniz!"));
                    if (surgery.SurgeryRoom == null)
                        throw new Exception("'Ameliyat Odası' Alanı boş olamaz");
                    surgery.CheckSurgeryTime();
                    if (surgery.MainSurgeryProcedures.Count < 1)
                    {
                        throw new Exception(SystemMessage.GetMessage(619));
                    }

                    surgery.CheckSurgeryPersonelRoles();
                    //  surgery.CheckMandatoryFiledsForSurgeryProcedures(true);      
                }
            }
            else
            {
                // surgery.CheckMandatoryFiledsForSurgeryProcedures(false); 
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string GetSpecialityOfUser([FromQuery] string UserObjectID) // ReadOnly olarak Açılırsa
        {
            string speciality = string.Empty;
            using (var objectContext = new TTObjectContext(true))
            {

                var userList = ResUser.GetResUserByObjectID(objectContext, UserObjectID);
                if (userList.Count > 0)
                {
                    return userList[0].GetSpecialityName();
                }

            }
            return speciality;
        }


    }
}

namespace Core.Models
{
    public partial class SurgeryFormViewModel
    {
        public string SurgeryTemplateDescription;
        public bool HasUncompleteSubSurgery;
        public TTObjectClasses.EpisodeAction.VitalSingsFormViewModel vitalSingsViewModel;
        public object _selectedSurgeryProcedure
        {
            get;
            set;
        }
        public SurgeryProcedureFormViewModel[] SurgeryProcedureFormViewModelList { get; set; }
        public SurgerySummaryFormViewModel[] OtherSurgerySummaryFormViewModellList { get; set; }

        public SurgeryPersonneSpecilaity[] SurgeryPersonneSpecilaityList { get; set; }

        public Guid InpatientPhyAppObjectId { get; set; }//Yatan Hasta ObjectId
        public Boolean IsRequiredPathology { get; set; }

        public string PatientObjectId { get; set; }
        public string MasterResourceSpecialityID { get; set; }
    }

    public partial class SurgeryPersonneSpecilaity
    {
        public string userObjectId;
        public string specilaityName;

    }
}