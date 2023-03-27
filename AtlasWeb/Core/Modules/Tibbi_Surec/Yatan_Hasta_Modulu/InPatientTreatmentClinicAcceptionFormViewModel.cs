//$F31D6C6F
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using Infrastructure.Helpers;
using TTUtils;
using System.Collections;
using TTStorageManager.Security;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class InPatientTreatmentClinicApplicationServiceController
    {
        partial void PreScript_InPatientTreatmentClinicAcceptionForm(InPatientTreatmentClinicAcceptionFormViewModel viewModel, InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication, TTObjectContext objectContext)
        {
            viewModel.RecTime = Common.RecTime();
            viewModel.IsPreAcception = false;
            if (inPatientTreatmentClinicApplication.CurrentStateDefID == InPatientTreatmentClinicApplication.States.PreAcception)
            {
                viewModel.IsPreAcception = true;
                BindingList<InpatientAppointment> appId = InpatientAppointment.GetInpatientAppByStarterInpatient(objectContext, inPatientTreatmentClinicApplication.ObjectID);
                if (appId.Count() > 0)
                {
                    viewModel.AppointmentId = appId.FirstOrDefault().ObjectID.ToString();
                }
            }

            if (inPatientTreatmentClinicApplication.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Acception)
                inPatientTreatmentClinicApplication.ClinicInpatientDate = viewModel.RecTime;

            //  inPatientTreatmentClinicApplication.SetProcedureDoctorAsCurrentResource();

            //İlk Klinik Kabul ekranında , Yatış isteği yapan doktor , tedavi gördüğü klinik ile aynı birimde ise  ve  episode acil kabulü ile açılmadı ise , sorumlu doktor alarak set edilir
            if (inPatientTreatmentClinicApplication.ProcedureDoctor == null)
            {
                if (inPatientTreatmentClinicApplication.FromInPatientTrtmentClinicApp == null) // Kurum içi sevklerde sorumlu doktor boş gelir
                {
                    if (inPatientTreatmentClinicApplication.SubEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.Acil)
                    {
                        var requestDoctor = inPatientTreatmentClinicApplication.BaseInpatientAdmission.ProcedureDoctor;
                        if (requestDoctor != null)
                        {
                            var userResource = requestDoctor.UserResources.FirstOrDefault(dr => dr.Resource.ObjectID == inPatientTreatmentClinicApplication.MasterResource.ObjectID);
                            if (userResource != null)// istek yapan doktor hastanın tedavi gördüğü klinşkde yetkili ise
                            {
                                //izinli değil ise
                                if (!Common.PersonelIzinKontrol(inPatientTreatmentClinicApplication.ProcedureDoctor.ObjectID.ToString(), inPatientTreatmentClinicApplication.BaseInpatientAdmission.HospitalInPatientDate.Value, objectContext))
                                    inPatientTreatmentClinicApplication.ProcedureDoctor = requestDoctor;
                            }
                        }
                    }
                }
            }
            else
            {
                DateTime checkdate = DateTime.Now;
                if (inPatientTreatmentClinicApplication.BaseInpatientAdmission.HospitalInPatientDate != null)
                    checkdate = inPatientTreatmentClinicApplication.BaseInpatientAdmission.HospitalInPatientDate.Value;
                else if (inPatientTreatmentClinicApplication.ClinicInpatientDate != null)
                    checkdate = inPatientTreatmentClinicApplication.ClinicInpatientDate.Value;

                //doktor izinli ise
                if (Common.PersonelIzinKontrol(inPatientTreatmentClinicApplication.ProcedureDoctor.ObjectID.ToString(), checkdate, objectContext))
                    inPatientTreatmentClinicApplication.ProcedureDoctor = null;
            }

            viewModel.EpisodeOpeningDate = inPatientTreatmentClinicApplication.Episode.OpeningDate.HasValue ? inPatientTreatmentClinicApplication.Episode.OpeningDate.Value : DateTime.MinValue;

            //
            if (inPatientTreatmentClinicApplication.BaseInpatientAdmission.PhysicalStateClinic == null && inPatientTreatmentClinicApplication.MasterResource != null && inPatientTreatmentClinicApplication.MasterResource is ResWard)
            {
                ResWard treatmentClinic = (ResWard)inPatientTreatmentClinicApplication.MasterResource;
                var treatmentClinicEmptyBedList = ResBed.GetEmptyBedsByClinic(treatmentClinic.ObjectID.ToString()); // boş yatağı varsa Yatacağı klinik de Tedavi kliniği ile aynı set edilir
                if (treatmentClinicEmptyBedList.Count > 0)
                    inPatientTreatmentClinicApplication.BaseInpatientAdmission.PhysicalStateClinic = treatmentClinic;
            }

            viewModel.HasDepositMaterial = inPatientTreatmentClinicApplication.Episode.InpatientAdmissionDepositMaterials.Count > 0 ? true : false;

            //ShowTurnReserveToUsed ve QuarantineProtocolNo
            viewModel.ShowTurnReserveToUsed = false;
            if (inPatientTreatmentClinicApplication.BaseInpatientAdmission != null)
            {
                if (inPatientTreatmentClinicApplication.BaseInpatientAdmission is InpatientAdmission)
                {
                    var inpatientAdd = ((InpatientAdmission)inPatientTreatmentClinicApplication.BaseInpatientAdmission);
                    if (inpatientAdd.QuarantineProtocolNo != null)
                        viewModel.QuarantineProtocolNo = inpatientAdd.QuarantineProtocolNo.ToString();
                }

                IList myResevedToUsedBedList = BaseBedProcedure.GetByBaseInpatientAdmissionAndUseStatus(objectContext, inPatientTreatmentClinicApplication.BaseInpatientAdmission.ObjectID.ToString(), UsedStatusEnum.ReservedToUse);
                if (myResevedToUsedBedList.Count > 0)
                {
                    IList allUsedBedList = BaseBedProcedure.GetByPatientAndUseStatus(objectContext, inPatientTreatmentClinicApplication.Episode.Patient.ObjectID.ToString(), UsedStatusEnum.Used);
                    if (allUsedBedList.Count < 1)
                    {
                        viewModel.ShowTurnReserveToUsed = true;
                    }
                }
            }

            // GivenMsg ve TakenMsg 
            //  Bu alanlar ekrandan kaldırıldı
            //viewModel.GivenMsg = Episode.GivenValuableMaterialsMsg(inPatientTreatmentClinicApplication.Episode);
            //viewModel.TakenMsg = Episode.TakenValuableMaterialsMsg(inPatientTreatmentClinicApplication.Episode);
            //IsPhysicalStateClinicReadOnly
            bool isRoleAssigned = false; // kullanıcıya rol atanmışmı bakıyor.
            foreach (TTUserRole role in TTUser.CurrentUser.Roles)
            {
                if (TTUser.CurrentUser.HasRole(Common.ChangePhysicalStateClinicRoleID) == true)
                {
                    isRoleAssigned = true;
                    break;
                }
            }

            if (inPatientTreatmentClinicApplication.BaseInpatientAdmission.PhysicalStateClinic == null)
            {
                viewModel.IsPhysicalStateClinicReadOnly = false;
            }
            else
            {
                if (Common.CurrentUser.IsSuperUser || isRoleAssigned) // kullanıcıya o rol atanmışsa super user olmasına gerek yok.
                {
                    viewModel.IsPhysicalStateClinicReadOnly = false;
                }
                else
                {
                    viewModel.IsPhysicalStateClinicReadOnly = true;
                }
            }

            if (inPatientTreatmentClinicApplication.Episode.Patient.Sex != null)
                viewModel.PatientSex = inPatientTreatmentClinicApplication.Episode.Patient.Sex.KODU;
            else
                viewModel.PatientSex = null;

            viewModel.HasInpatientAppGiveRole = TTUser.CurrentUser.HasRole(TTRoleNames.Yatan_Hasta_Randevu_Verme) ? true : false;
            viewModel.HasInpatientAppShowRole = TTUser.CurrentUser.HasRole(TTRoleNames.Yatan_Hasta_Randevu_Goruntuleme) ? true : false;
            viewModel.IsClinicAllowAppointment = (inPatientTreatmentClinicApplication.MasterResource as ResClinic).IsAllowAppointment==true ? true : false;

            ContextToViewModel(viewModel, objectContext);

            this.ArrangeButtons(viewModel);
        }

        partial void PostScript_InPatientTreatmentClinicAcceptionForm(InPatientTreatmentClinicAcceptionFormViewModel viewModel, InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //Klinik Kabul Onay aşamasında alanların boş geçilmesine takılmayacak. 
            //Bu kontroller Klinik Kabul aşamasında yapılacak
            bool doNullControl = true;

            if (transDef != null)
            {
                if (transDef.ToStateDefID == InPatientTreatmentClinicApplication.States.Rejected || transDef.FromStateDefID == InPatientTreatmentClinicApplication.States.PreAcception)
                    doNullControl = false;

                if (transDef.FromStateDefID == InPatientTreatmentClinicApplication.States.Acception && transDef.ToStateDefID == InPatientTreatmentClinicApplication.States.Procedure)
                {
                    viewModel.InpatientAcceptionMessage = WaitingClinicAcceptionPatient(inPatientTreatmentClinicApplication);
                }
                if (transDef.FromStateDefID == InPatientTreatmentClinicApplication.States.PreAcception && transDef.ToStateDefID == InPatientTreatmentClinicApplication.States.Acception)
                {
                    if (viewModel._InpatientAppointmentInfo != null)
                    {
                        InpatientAppointment appointment = objectContext.GetObject(viewModel._InpatientAppointmentInfo.ObjectId, viewModel._InpatientAppointmentInfo.ObjectDefName) as InpatientAppointment;
                        appointment.CurrentStateDefID = InpatientAppointment.States.Completed;
                    }
                }
            }
            else
            {
                if (transDef == null || transDef.ToStateDef == null || transDef.ToStateDefID != InPatientTreatmentClinicApplication.States.Rejected)
                    doNullControl = true;
            }

            if (doNullControl)
            {
                if (inPatientTreatmentClinicApplication.MasterResource == null)
                    throw new Exception("'Hastanın Tedavi Gördüğü Klinik' boş geçilemez");
                if (inPatientTreatmentClinicApplication.ProcedureDoctor == null)
                    throw new Exception("'Sorumlu Tabip' boş geçilemez");
                if (inPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed == null)
                    throw new Exception("'Hastanın Yatağı' boş geçilemez");

            }

            if (inPatientTreatmentClinicApplication.IsDailyOperation == true)
            {
                inPatientTreatmentClinicApplication.TurnFromDailyToInpatient();
                if (inPatientTreatmentClinicApplication.InPatientPhysicianApplication.Count > 0)
                    inPatientTreatmentClinicApplication.InPatientPhysicianApplication[0].MasterResource = inPatientTreatmentClinicApplication.MasterResource;
                if (inPatientTreatmentClinicApplication.NursingApplications.Count > 0)
                    inPatientTreatmentClinicApplication.NursingApplications[0].MasterResource = inPatientTreatmentClinicApplication.MasterResource;

                if (inPatientTreatmentClinicApplication.TreatmentDischarge != null && inPatientTreatmentClinicApplication.TreatmentDischarge.CurrentStateDefID != TreatmentDischarge.States.Cancelled)
                    inPatientTreatmentClinicApplication.TreatmentDischarge.CurrentStateDefID = TreatmentDischarge.States.Cancelled;
            }

            var inpatientPhyApp = inPatientTreatmentClinicApplication.SubEpisode.InPatientPhysicianApplications;//yatan hasta kaydedilmişse
            if (inpatientPhyApp.Count() > 0)
            {
                var speciality = inpatientPhyApp.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled).FirstOrDefault().SpecialityBasedObject;//yatan hastanın uzmanlığı varsa
                if (speciality.Count() > 0)
                {
                    IntensiveCareSpecialityObj intensiveCare = speciality.Where(c => c is IntensiveCareSpecialityObj).FirstOrDefault() as IntensiveCareSpecialityObj;//yatan hastanın uzmanlığı yoğun bakım ise
                    var yatakHizmeti = inPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed.BedProcedure.Code;

                    if (intensiveCare != null)
                    {
                        switch (yatakHizmeti)
                        {
                            case "P552001":
                                intensiveCare.IntensiveCareStep = IntensiveCareStepEnum.One;
                                break;
                            case "P552002":
                                intensiveCare.IntensiveCareStep = IntensiveCareStepEnum.Two;
                                break;
                            case "P552003":
                                intensiveCare.IntensiveCareStep = IntensiveCareStepEnum.Three;
                                break;
                        }
                    }
                }
            }
        }


        partial void AfterContextSaveScript_InPatientTreatmentClinicAcceptionForm(InPatientTreatmentClinicAcceptionFormViewModel viewModel, InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //this.ArrangeButtons(viewModel);
            //eğer klinik işlemi üzerinde yoğum bakım varsa ve yatak hizmeti değiştirildiyse -> seçilen yatağın basamağı yoğun bakımdaki basamak bilgisi ile eşleştirilir.

            //IntensiveCareSpecialityObj intensiveCare = inPatientTreatmentClinicApplication.SubEpisode.InPatientPhysicianApplications.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled).FirstOrDefault().SpecialityBasedObject.Where(c => c is IntensiveCareSpecialityObj).FirstOrDefault() as IntensiveCareSpecialityObj;

        }
        public void ArrangeButtons(InPatientTreatmentClinicAcceptionFormViewModel viewModel)
        {

            List<TTObjectStateTransitionDef> removedOutgoingTransitions = new List<TTObjectStateTransitionDef>();
            foreach (var trans in viewModel.OutgoingTransitions)
            {
                if (trans.ToStateDefID == InPatientTreatmentClinicApplication.States.Transferred)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == InPatientTreatmentClinicApplication.States.Discharged)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == InPatientTreatmentClinicApplication.States.Cancelled)
                {
                    if (viewModel._InPatientTreatmentClinicApplication.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Acception)
                        removedOutgoingTransitions.Add(trans);
                }
                /* 
                 else if (trans.ToStateDefID == InPatientTreatmentClinicApplication.States.Approve)
                 {
                     if (TTObjectClasses.SystemParameter.GetParameterValue("APPROVECLINICACCEPTION", "FALSE") == "FALSE")
                         removedOutgoingTransitions.Add(trans);
                 }
                 else if (trans.ToStateDefID == InPatientTreatmentClinicApplication.States.Procedure)
                 {
                     if (viewModel._InPatientTreatmentClinicApplication.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Acception)
                     {
                         if (TTObjectClasses.SystemParameter.GetParameterValue("APPROVECLINICACCEPTION", "FALSE") == "TRUE")
                             removedOutgoingTransitions.Add(trans);
                     }
                 }*/
            }
            foreach (var removedtrans in removedOutgoingTransitions)
            {
                viewModel.OutgoingTransitions.Remove(removedtrans);
            }
        }


        [HttpGet]
        public string GetLastActiveInPatientTreatmentClinicAppObjectId(string EpisodeID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (EpisodeID != null)
                {
                    var GetLastActiveInPatientTreatmentClinicAppList = InPatientTreatmentClinicApplication.GetLastActiveInPatientTreatmentClinicApp(objectContext, new Guid(EpisodeID));
                    foreach (var inPatientTreatmentClinicApp in GetLastActiveInPatientTreatmentClinicAppList)
                    {
                        return inPatientTreatmentClinicApp.ObjectID.ToString();
                    }
                }
            }
            return null;
        }

        [HttpGet]
        public InpatientTreatmentBarcodeInfo GetInpatientTreatmentBarcodeInfoByEpisodeActionId(string EpisodeActionId)
        {
            InpatientTreatmentBarcodeInfo inpatientTreatmentBarcodeInfo = new InpatientTreatmentBarcodeInfo();
            using (var objectContext = new TTObjectContext(true))
            {
                if (!string.IsNullOrEmpty(EpisodeActionId))
                {
                    InPatientTreatmentClinicApplication inpatientTreatmentApp = null;
                    EpisodeAction episodeAction = (EpisodeAction)objectContext.GetObject(new Guid(EpisodeActionId), "EPISODEACTION");
                    if (episodeAction is InPatientTreatmentClinicApplication)
                        inpatientTreatmentApp = (InPatientTreatmentClinicApplication)episodeAction;
                    else if (episodeAction is NursingApplication && ((NursingApplication)episodeAction).InPatientTreatmentClinicApp != null)
                        inpatientTreatmentApp = ((NursingApplication)episodeAction).InPatientTreatmentClinicApp;
                    else if (episodeAction is InPatientPhysicianApplication && ((InPatientPhysicianApplication)episodeAction).InPatientTreatmentClinicApp != null)
                        inpatientTreatmentApp = ((InPatientPhysicianApplication)episodeAction).InPatientTreatmentClinicApp;
                    else
                    {
                        var starterEA = episodeAction.SubEpisode.StarterEpisodeAction;
                        if (starterEA is InPatientTreatmentClinicApplication)
                            inpatientTreatmentApp = (InPatientTreatmentClinicApplication)starterEA;
                    }

                    if (inpatientTreatmentApp != null)
                    {
                        var patient = inpatientTreatmentApp.Episode.Patient;
                        inpatientTreatmentBarcodeInfo.PatientIdentifier = patient.UniqueRefNo != null ? patient.UniqueRefNo.ToString() : (patient.ForeignUniqueRefNo != null ? patient.ForeignUniqueRefNo.ToString() : "");
                        inpatientTreatmentBarcodeInfo.PatientName = (patient.Name != null ? patient.Name : "") + " " + (patient.Surname != null ? patient.Surname : "");
                        inpatientTreatmentBarcodeInfo.MotherName = patient.MotherName != null ? patient.MotherName : "";
                        inpatientTreatmentBarcodeInfo.FatherName = patient.FatherName != null ? patient.FatherName : "";
                        inpatientTreatmentBarcodeInfo.BirthDate = patient.BirthDate != null ? ((DateTime)patient.BirthDate).ToString("dd/MM/yyyy") : "";
                        inpatientTreatmentBarcodeInfo.Clinicname = inpatientTreatmentApp.MasterResource.Name != null ? inpatientTreatmentApp.MasterResource.Name : "";
                        inpatientTreatmentBarcodeInfo.KabulNo = inpatientTreatmentApp.SubEpisode != null ? inpatientTreatmentApp.SubEpisode.ProtocolNo : "";
                        inpatientTreatmentBarcodeInfo.DoctorName = inpatientTreatmentApp.ProcedureDoctor != null ? inpatientTreatmentApp.ProcedureDoctor.Name : "";
                        inpatientTreatmentBarcodeInfo.HospitalName = Convert.ToString(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "TRUE"));
                        inpatientTreatmentBarcodeInfo.InPatientDate = inpatientTreatmentApp.ClinicInpatientDate.HasValue ? inpatientTreatmentApp.ClinicInpatientDate.Value.ToString("dd/MM/yyyy") : "";
                        inpatientTreatmentBarcodeInfo.ArchiveNumber = inpatientTreatmentApp.SubEpisode.Episode.Patient.ID.ToString();
                        inpatientTreatmentBarcodeInfo.RoomNo = (inpatientTreatmentApp.BaseInpatientAdmission != null && inpatientTreatmentApp.BaseInpatientAdmission.Room != null) ? inpatientTreatmentApp.BaseInpatientAdmission.Room.Name : "";
                        inpatientTreatmentBarcodeInfo.TakipNo = (inpatientTreatmentApp.SubEpisode.FirstSubEpisodeProtocol != null && inpatientTreatmentApp.SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo != null) ?
                                                                inpatientTreatmentApp.SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo : "";
                        inpatientTreatmentBarcodeInfo.AcceptionNumber = "";

                        if (inpatientTreatmentApp.Episode != null && inpatientTreatmentApp.Episode.Patient != null && inpatientTreatmentApp.Episode.Patient.Sex != null)
                            inpatientTreatmentBarcodeInfo.Sex = inpatientTreatmentApp.Episode.Patient.Sex.ADI;
                        else
                            inpatientTreatmentBarcodeInfo.Sex = "";

                    }
                    else
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M25211", "Ayaktan Vaka için Yatan Hasta Barkodu basılamaz"));
                    }

                }
            }
            return inpatientTreatmentBarcodeInfo;

        }

        [HttpGet]
        public InpatientWristBarcodeInfo GetInpatientWristBarcodeInfoByEpisodeActionId(string EpisodeActionId)
        {
            InpatientWristBarcodeInfo inpatientTreatmentBarcodeInfo = new InpatientWristBarcodeInfo();
            using (var objectContext = new TTObjectContext(true))
            {
                if (!string.IsNullOrEmpty(EpisodeActionId))
                {
                    InPatientTreatmentClinicApplication inpatientTreatmentApp = null;
                    EpisodeAction episodeAction = (EpisodeAction)objectContext.GetObject(new Guid(EpisodeActionId), "EPISODEACTION");
                    if (episodeAction is InPatientTreatmentClinicApplication)
                        inpatientTreatmentApp = (InPatientTreatmentClinicApplication)episodeAction;
                    else if (episodeAction is NursingApplication && ((NursingApplication)episodeAction).InPatientTreatmentClinicApp != null)
                        inpatientTreatmentApp = ((NursingApplication)episodeAction).InPatientTreatmentClinicApp;
                    else if (episodeAction is InPatientPhysicianApplication && ((InPatientPhysicianApplication)episodeAction).InPatientTreatmentClinicApp != null)
                        inpatientTreatmentApp = ((InPatientPhysicianApplication)episodeAction).InPatientTreatmentClinicApp;
                    else
                    {
                        var starterEA = episodeAction.SubEpisode.StarterEpisodeAction;
                        if (starterEA is InPatientTreatmentClinicApplication)
                            inpatientTreatmentApp = (InPatientTreatmentClinicApplication)starterEA;
                    }

                    if (inpatientTreatmentApp != null)
                    {
                        var patient = inpatientTreatmentApp.Episode.Patient;
                        var protocolNo = inpatientTreatmentApp.SubEpisode.ProtocolNo;
                        var printDate = Common.RecTime();
                        inpatientTreatmentBarcodeInfo.HospitalName = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "GAZİLER FTR EĞİTİM ARŞ.HST");
                        inpatientTreatmentBarcodeInfo.PatientName = (patient.Name != null ? patient.Name : "") + " " + (patient.Surname != null ? patient.Surname : "");
                        inpatientTreatmentBarcodeInfo.BirthDate = patient.BirthDate != null ? ((DateTime)patient.BirthDate).ToString("dd/MM/yyyy") : "";
                        inpatientTreatmentBarcodeInfo.AcceptionNumber = protocolNo;
                        inpatientTreatmentBarcodeInfo.PrintDate = printDate.ToShortDateString();
                        inpatientTreatmentBarcodeInfo.PrintTime = printDate.ToShortTimeString();
                        inpatientTreatmentBarcodeInfo.BarcodeCode = protocolNo;
                        inpatientTreatmentBarcodeInfo.ArchiveNumber = inpatientTreatmentApp.SubEpisode.Episode.ID.ToString();
                        inpatientTreatmentBarcodeInfo.PatientIdentifier = patient.UniqueRefNo != null ? patient.UniqueRefNo.ToString() : (patient.ForeignUniqueRefNo != null ? patient.ForeignUniqueRefNo.ToString() : "");
                        inpatientTreatmentBarcodeInfo.Sex = patient.Sex.ADI;
                        inpatientTreatmentBarcodeInfo.KabulNo = inpatientTreatmentApp.SubEpisode != null ? inpatientTreatmentApp.SubEpisode.ProtocolNo : "";
                        inpatientTreatmentBarcodeInfo.Clinicname = inpatientTreatmentApp.MasterResource.Name != null ? inpatientTreatmentApp.MasterResource.Name : "";
                    }
                    else
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M25211", "Ayaktan Vaka için Yatan Hasta Barkodu basılamaz"));
                    }

                }
            }
            return inpatientTreatmentBarcodeInfo;

        }

        [HttpGet]
        public bool SetTreatmentClinicAcceptionWaiting(Guid ObjectID, Guid ObjectDefID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                InPatientTreatmentClinicApplication _inPatientTreatmentClinicApplication = objectContext.GetObject(ObjectID, ObjectDefID) as InPatientTreatmentClinicApplication;
                if (_inPatientTreatmentClinicApplication.CurrentStateDefID != null && (_inPatientTreatmentClinicApplication.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Acception || _inPatientTreatmentClinicApplication.CurrentStateDefID == InPatientTreatmentClinicApplication.States.PreAcception))//Kliniğe yatırmadan önce yatış isteği yapılan hasta yeni yatış mı?/ transfer mi? bilgileri tutuluyor.
                {
                    if (_inPatientTreatmentClinicApplication.FromInPatientTrtmentClinicApp == null)//bir önceki başlatıldığı yatış yoksa transfer değil yeni yatıştır.
                    {
                        if (_inPatientTreatmentClinicApplication.BaseInpatientAdmission.Emergency == true)
                        {
                            _inPatientTreatmentClinicApplication.InpatientAcceptionType = InpatientAcceptionTypeEnum.EmergencyInpatient;//Acilden yeni yatırılan hasta
                        }
                        else
                        {
                            _inPatientTreatmentClinicApplication.InpatientAcceptionType = InpatientAcceptionTypeEnum.NewInpatient;//Yeni yatırılan hasta
                        }

                    }
                    else
                    {
                        if (((ResClinic)_inPatientTreatmentClinicApplication.FromInPatientTrtmentClinicApp.MasterResource).IsIntensiveCare == true)//tedavi göreceği klinik yoğun bakım ise
                        {
                            _inPatientTreatmentClinicApplication.InpatientAcceptionType = InpatientAcceptionTypeEnum.IntensiveCareTransfer;//Yeni yatırılan hasta
                        }
                        else
                        {
                            _inPatientTreatmentClinicApplication.InpatientAcceptionType = InpatientAcceptionTypeEnum.OtherClinicTransfer;//Yeni yatırılan hasta
                        }
                    }
                }
                else
                {
                    throw new Exception("Klinik Kabul aşamasında olmayan işlemlere 'Yatış Bekliyor' işlemi yapılamaz!");
                }
                _inPatientTreatmentClinicApplication.DescriptionForWorkList += " ";
                objectContext.Save();
                return true;
            }
        }

        [HttpGet]
        public void CancelTreatmentClinicAcceptionWaiting(Guid ObjectID, Guid ObjectDefID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                InPatientTreatmentClinicApplication _inPatientTreatmentClinicApplication = objectContext.GetObject(ObjectID, ObjectDefID) as InPatientTreatmentClinicApplication;
                _inPatientTreatmentClinicApplication.InpatientAcceptionType = null;
                objectContext.Save();
            }
        }

        public string WaitingClinicAcceptionPatient(InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication)
        {
            var waitingClinicAcceptionPatientList = InPatientTreatmentClinicApplication.GetWaitingClinicAcceptionPatient(inPatientTreatmentClinicApplication.MasterResource.ObjectID).Where(x => x.InpatientAcceptionType != inPatientTreatmentClinicApplication.InpatientAcceptionType);
            var message = "";

            if (waitingClinicAcceptionPatientList.Count() > 0)
            {
                if (inPatientTreatmentClinicApplication.InpatientAcceptionType == null)
                {
                    //Yatış Bekliyor olarak işaretlenmemiş hasta yatırılırken eğer yatış bekleyen hasta var ise yatış engellenir.
                    throw new Exception("'Yatış Bekliyor' durumunda hasta bulunmaktadır. Lütfen öncelikli olarak 'Yatış Bekliyor' durumundaki hastayı kliniğe kabul ediniz!");
                }
                else
                {
                    if (inPatientTreatmentClinicApplication.InpatientAcceptionType == InpatientAcceptionTypeEnum.EmergencyInpatient)
                    {
                        //Yatış bekleyen hasta acil hasta ise uyarı vermeden yatış yapılacak!
                    }
                    else if (inPatientTreatmentClinicApplication.InpatientAcceptionType == InpatientAcceptionTypeEnum.IntensiveCareTransfer)
                    {
                        if (waitingClinicAcceptionPatientList.Where(c => c.InpatientAcceptionType == InpatientAcceptionTypeEnum.EmergencyInpatient).Count() > 0)
                        {
                            //Yatış bekleyen hasta yoğun bakımdan transfer hasta ise sadece acil bekleyen varsa uyarı verecek! Değilse uyarı vermeden yatış yapılacak!
                            message = "'Yatış Bekliyor' durumunda hasta bulunmaktadır!";
                        }
                    }
                    else if (inPatientTreatmentClinicApplication.InpatientAcceptionType == InpatientAcceptionTypeEnum.OtherClinicTransfer)
                    {
                        if (waitingClinicAcceptionPatientList.Where(c => c.InpatientAcceptionType == InpatientAcceptionTypeEnum.EmergencyInpatient || c.InpatientAcceptionType == InpatientAcceptionTypeEnum.IntensiveCareTransfer).Count() > 0)
                        {
                            //Yatış bekleyen kurum içi transfer hasta ise acil bekleyen ve yoğun bakım transfer hastalar varsa uyarı verecek! Değilse uyarı vermeden yatış yapılacak!
                            message = "'Yatış Bekliyor' durumunda hastası bulunmaktadır!";
                        }
                    }
                    else if (inPatientTreatmentClinicApplication.InpatientAcceptionType == InpatientAcceptionTypeEnum.NewInpatient)
                    {
                        //Yatış Bekleyen hasta yeni yatış yapılan hasta ise ve kendi InpatientAcceptionType tipinden başka hasta var ise uyarı verecek!
                        message = "'Yatış Bekliyor' durumunda hasta bulunmaktadır!";
                    }
                }
            }
            return message;
        }
    }
}

namespace Core.Models
{
    public partial class InPatientTreatmentClinicAcceptionFormViewModel
    {
        public string QuarantineProtocolNo
        {
            get;
            set;
        }

        public bool ShowTurnReserveToUsed
        {
            get;
            set;
        }

        public bool IsPhysicalStateClinicReadOnly
        {
            get;
            set;
        }

        public String PatientSex
        {
            get;
            set;
        }

        public DateTime RecTime
        {
            get;
            set;
        }

        public DateTime EpisodeOpeningDate
        {
            get;
            set;
        }

        public string InpatientAcceptionMessage { get; set; }

        public bool IsPreAcception { get; set; }

        public List<InpatientAdmission> InpatientAdmissionList { get; set; }

        public InpatientAppointmentInfo _InpatientAppointmentInfo { get; set; }

        public string AppointmentId { get; set; }

        public bool HasInpatientAppGiveRole { get; set; }//Yatan hasta randevu verme rolü var mı?
        public bool HasInpatientAppShowRole { get; set; }//Yatan hasta randevu görüntüleme rolü var mı?
        public bool IsClinicAllowAppointment { get; set; }//Klinik tanımından Randevu kullanımı seçildi mi?
        public bool HasDepositMaterial { get; set; } //Hastanın Emanet kaydı var mı?

    }

    public class InpatientTreatmentBarcodeInfo
    {
        public string PatientIdentifier
        {
            get;
            set;
        }
        public string PatientName
        {
            get;
            set;
        }

        public string MotherName
        {
            get;
            set;
        }

        public string FatherName
        {
            get;
            set;
        }

        public string BirthDate
        {
            get;
            set;
        }

        public string Clinicname
        {
            get;
            set;
        }

        public string RoomNo
        {
            get;
            set;
        }

        public string KabulNo
        {
            get;
            set;
        }
        public string DoctorName
        {
            get;
            set;
        }

        public string HospitalName
        {
            get;
            set;
        }
        public string TakipNo { get; set; }
        public string InPatientDate { get; set; }
        public string ArchiveNumber { get; set; }
        public string AcceptionNumber { get; set; }
        public string Sex { get; set; }

    }

    public class InpatientWristBarcodeInfo
    {
        public string HospitalName
        {
            get;
            set;
        }
        public string PatientName
        {
            get;
            set;
        }

        public string BirthDate
        {
            get;
            set;
        }

        public string AcceptionNumber
        {
            get;
            set;
        }

        public string PrintDate
        {
            get;
            set;
        }

        public string PrintTime
        {
            get;
            set;
        }

        public string BarcodeCode
        {
            get;
            set;
        }
        public string ArchiveNumber
        {
            get;
            set;
        }

        public string PatientIdentifier
        {
            get;
            set;
        }
        public string Sex
        {
            get;
            set;
        }

        public string KabulNo
        {
            get;
            set;
        }

        public string Clinicname
        {
            get;
            set;
        }
    }


}