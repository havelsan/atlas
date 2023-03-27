//$50A8498A
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class SurgeryServiceController
    {
        partial void PreScript_SurgeryRequestForm(SurgeryRequestFormViewModel viewModel, Surgery surgery, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionObjectID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                viewModel._Surgery.FromResource = episodeAction.MasterResource;
                viewModel._Surgery.MasterAction = episodeAction;
                viewModel._Surgery.Episode = episodeAction.Episode;
                //viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray(); en altta   ContextToViewModel(viewModel, objectContext); var o yüzden kapatıldı
            }
            Guid? selectedPatientObjectID = viewModel.GetSelectedPatientID();
            if (selectedPatientObjectID.HasValue) //Randevu Action üzerinden açıldığında
            {
                Guid? selectedEpisodeID = viewModel.GetSelectedEpisodeID();
                if (selectedEpisodeID.HasValue)
                {
                    Episode ep = objectContext.GetObject<Episode>((Guid)selectedEpisodeID, false);
                    if (ep == null)
                    {
                        SurgeryAppointment sa = objectContext.GetObject<SurgeryAppointment>((Guid)selectedEpisodeID, false);
                        if (sa != null)
                        {
                            viewModel.LinkedSurgeryAppointment = sa;
                            viewModel.LinkedSurgeryAppointment.Surgery = viewModel._Surgery;
                        }
                    }
                    else
                    {
                        var parameterDate = Common.RecTime().Date.AddMonths(6);
                        var AppointmentList = SurgeryAppointment.GetPatientsApprovedAppointments(objectContext, (Guid)selectedPatientObjectID, parameterDate, Common.RecTime());
                        foreach (var appointment in AppointmentList)
                        {
                            SurgeryAppointmentCarrierClass carrier = new SurgeryAppointmentCarrierClass();
                            carrier.AppointmentObjectID = appointment.ObjectID;
                            carrier.PlannedStartDate = (DateTime)appointment.PlannedSurgeryStartDate;
                            carrier.ProcedureDoctor = appointment.ProcedureDoctor.Name;
                            viewModel.PatientSurgeryAppointments.Add(carrier);
                        }
                    }
                }

            }

            if (viewModel._Surgery.IsNeedAnesthesia == null)
                viewModel._Surgery.IsNeedAnesthesia = true;
            viewModel.HasOtherSurgery = false;
            viewModel.ConsLimitIfHasAnesthesiaConsultation = 0;
            if (surgery.CurrentStateDefID == Surgery.States.SurgeryRequest)
            {
                foreach (Surgery otherSurgery in surgery.Episode.Surgeries)
                {
                    if (!otherSurgery.IsCancelled && otherSurgery.ObjectID != surgery.ObjectID && otherSurgery.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                    {
                        viewModel.HasOtherSurgery = true;
                        break;
                    }
                }

                // Ayaktan hastalarda Kabul Sebebi Günübirlik ve Acil olan hastalar dışında Ameliyat işlemi başlatılamaz!
                if (surgery.SubEpisode != null && surgery.SubEpisode.PatientStatus != null && surgery.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Outpatient)
                {
                    if (surgery.SubEpisode.PatientAdmission != null && surgery.SubEpisode.PatientAdmission.AdmissionType != null)
                    {
                        if (!(surgery.SubEpisode.PatientAdmission.AdmissionStatus.Equals(AdmissionStatusEnum.Gunubirlik)) && !surgery.SubEpisode.PatientStatus.Equals(SubEpisodeStatusEnum.Daily))
                        {
                            throw new Exception("Kabul Sebebi 'Günübirlik' olmayan ayaktan hasta kabullerinde 'Ameliyat İşlemi' başlatılamaz.");
                        }
                    }
                }

                //----------------------
                TTObjectContext context = new TTObjectContext(true);

                // TODO NIDA anestesi konsültasyonu normal konsütasyon uzmanlık dalı anestesi olan olacak
                //int consLimit = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("AnesthesiaConsultationAvailabilityDate", "30"));
                //DateTime limitDate = ((DateTime)Common.RecTime()).AddDays(-1 * consLimit);

                //var anestCons = AnesthesiaConsultation.GetByDateLimitAndPatient(context, limitDate, surgery.Episode.Patient.ObjectID);
                //if (anestCons.Count < 1)
                //{
                //    viewModel.ConsLimitIfHasAnesthesiaConsultation = consLimit; //  Clienta aynı anda hem limit değerini hem de Konsültasyon olup olmadığını yollamak için Int yapıldı
                //}

                //Başlatılacak Anestesi Reanimasyon işleminin Masterresourceunu belirlemek için
                string filter = string.Empty;
                var actionDMRList = EpisodeAction.AcionDefualtMasterResources(context, ActionTypeEnum.AnesthesiaAndReanimation, surgery);
                if (actionDMRList.Count == 1)
                {
                    viewModel.AnesthesiaAndReanimationMasterResource = actionDMRList[0];
                }
                else if (actionDMRList.Count > 0)
                {
                    viewModel.AnesthesiaAndReanimationMasterResource = actionDMRList[0]; // TODO NIDA  burası silinecek clientta field konulup oradan seçilmesi sağlanacak
                    filter = " OBJECTID IN(''";
                    foreach (ResSection resSection in actionDMRList)
                    {
                        filter += ",'" + resSection.ObjectID.ToString() + "'";
                    }

                    filter += ")";
                }

                viewModel.AnesthesiaAndReanimationMasterResourceFilterString = filter;
            }

            //----------------------
            surgery.SetProcedureDoctorAsCurrentResource();
            if (surgery.RequestDate == null)
                surgery.RequestDate = Common.RecTime();

            if (viewModel.LinkedSurgeryAppointment != null)
            {
                viewModel._Surgery.Emergency = viewModel.LinkedSurgeryAppointment.Emergency;
                viewModel._Surgery.IsNeedAnesthesia = viewModel.LinkedSurgeryAppointment.IsNeedAnesthesia;
                viewModel._Surgery.IsComplicationSurgery = viewModel.LinkedSurgeryAppointment.IsComplicationSurgery;
                viewModel._Surgery.ProcedureDoctor = viewModel.LinkedSurgeryAppointment.ProcedureDoctor;
                viewModel._Surgery.MasterResource = viewModel.LinkedSurgeryAppointment.MasterResource;
                viewModel._Surgery.SurgeryRoom = viewModel.LinkedSurgeryAppointment.SurgeryRoom;
                viewModel._Surgery.SurgeryDesk = viewModel.LinkedSurgeryAppointment.SurgeryDesk;
                viewModel._Surgery.PlannedSurgeryDescription = viewModel.LinkedSurgeryAppointment.PlannedSurgeryDescription;
                viewModel._Surgery.ComplicationDescription = viewModel.LinkedSurgeryAppointment.ComplicationDescription;
                viewModel._Surgery.DescriptionToPreOp = viewModel.LinkedSurgeryAppointment.DescriptionToPreOp;
                viewModel._Surgery.NotesToAnesthesia = viewModel.LinkedSurgeryAppointment.NotesToAnesthesia;
                viewModel._Surgery.PlannedSurgeryDate = viewModel.LinkedSurgeryAppointment.PlannedSurgeryStartDate;
                foreach (var procedure in viewModel.LinkedSurgeryAppointment.SurgeryAppointmentProcedures)
                {
                    MainSurgeryProcedure surgeryProcedure = new MainSurgeryProcedure(objectContext);
                    surgeryProcedure.ProcedureObject = procedure.ProcedureDefinition;
                    surgeryProcedure.Surgery = surgery;
                    surgery.MainSurgeryProcedures.Add(surgeryProcedure);
                }

            }
            ContextToViewModel(viewModel, objectContext);
            // TODO Nida ContextToView Bunu neden getirmiyor sor
            List<DiagnosisDefinition> DiagnosisDefinitions = new List<DiagnosisDefinition>();
            foreach (var diagnosisGrid in surgery.Episode.Diagnosis)
            {
                if (!DiagnosisDefinitions.Contains(diagnosisGrid.Diagnose))
                {
                    DiagnosisDefinitions.Add(diagnosisGrid.Diagnose);
                }
            }

            viewModel.DiagnosisDefinitions = DiagnosisDefinitions.ToArray();

            //if (surgery.KvcRiskScores.Count > 0)
            //{
            //    viewModel.KvcScoreId = surgery.KvcRiskScores.FirstOrDefault().ObjectID;
            //}
        }

        partial void PostScript_SurgeryRequestForm(SurgeryRequestFormViewModel viewModel, Surgery surgery, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            bool IsNeedKvcScore = false;
            foreach (var mainSurgeryProcedure in surgery.MainSurgeryProcedures)
            {
                if (surgery.PlannedSurgeryDate != null)
                {
                    if (mainSurgeryProcedure.ActionDate == null)
                        mainSurgeryProcedure.ActionDate = surgery.PlannedSurgeryDate;
                }
                else
                {
                    if (surgery.PlannedSurgeryDate == null)
                        throw new Exception(TTUtils.CultureService.GetText("M26696", "Planlanan ameliyat tarihi boş geçilemez"));
                }

                if (((SurgeryDefinition)mainSurgeryProcedure.ProcedureObject).IsNeedKvcScore == true)
                {
                    IsNeedKvcScore = true;
                }
            }

            if (IsNeedKvcScore==true && viewModel.KvcRiskScore == null)
            {
                throw new Exception("KVC Skorlama boş geçilemez");
            }

            if (viewModel.KvcRiskScore != null)
            {
                var kvc = (KvcRiskScore)objectContext.AddObject(viewModel.KvcRiskScore);
            }


            if (transDef != null)
            {

                if (transDef.ToStateDefID != Surgery.States.Cancelled && transDef.FromStateDefID == Surgery.States.SurgeryRequest)
                {
                    if (surgery.ProcedureDoctor == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26936", "Sorumlu cerrah bilgisini giriniz!"));
                    if (surgery.MasterResource == null)
                        throw new Exception(TTUtils.CultureService.GetText("M25159", "Ameliyathane boş geçilemez"));
                    if (viewModel.AnesthesiaAndReanimationMasterResource == null)
                        throw new Exception("Başlatılacak Anestezi birimi seçilmeden istek yapılamaz ");
                    if (surgery.PlannedSurgeryDescription == null && surgery.MainSurgeryProcedures.Count == 0)
                        throw new Exception("'Planlanan Ameliyat(lar)' ve 'Planlanan Ameliyat Açıklaması' alanlarının ikisi birden boş geçilemez");

                    ChooseMainProcedure(surgery);

                    surgery.AccountingOperation(); // Ameliyat hizmetleri ilk oluşurken kesilerine göre indirimli ücretlensin diye burada çağırıldı

                    if (surgery.IsNeedAnesthesia == true)
                        surgery.FireAnesthesiaAndReanimation(viewModel.AnesthesiaAndReanimationMasterResource);
                    surgery.FireSurgeryExtension();

                    surgery.SafeSurgeryCheckList = new SafeSurgeryCheckList(objectContext);
                    surgery.SafeSurgeryCheckList.CurrentStateDefID = SafeSurgeryCheckList.States.BeforeLeavingClinic;
                }
            }

        }

        partial void AfterContextSaveScript_SurgeryRequestForm(SurgeryRequestFormViewModel viewModel, Surgery surgery, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
        }

        public void ChooseMainProcedure(Surgery surgery)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                double maxSutPoint = surgery.MainSurgeryProcedures.Max(x => x.ProcedureObject.GetSUTPoint());//seçilen işlemler arasında en yüksek sut puanı belirleniyor.

                var selectedMainSurgery = surgery.MainSurgeryProcedures.Where(c => c.ProcedureObject.GetSUTPoint() == maxSutPoint).FirstOrDefault();
                selectedMainSurgery.AyniFarkliKesi = AyniFarkliKesi.GetByAyniFarkliKesiKodu(objectContext, "2").FirstOrDefault();//Sut Puanı en yüksek olan işlem seçilip ana ameliyat olarak belirlenecek.
                selectedMainSurgery.Position = SurgeryLeftRight.AllTheSame;

                foreach (var item in surgery.MainSurgeryProcedures.Where(c => c.ObjectID != selectedMainSurgery.ObjectID))//ana ameliyat olarak seçilen işlem haricindeki işlemler aynı seans aynı kesi olarak belirleniiyor.
                {
                    item.AyniFarkliKesi = AyniFarkliKesi.GetByAyniFarkliKesiKodu(objectContext, "1").FirstOrDefault();
                    item.Position = SurgeryLeftRight.AllTheSame;
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class SurgeryRequestFormViewModel
    {
        //pre
        public Boolean HasOtherSurgery;
        public Int32 ConsLimitIfHasAnesthesiaConsultation;
        public string AnesthesiaAndReanimationMasterResourceFilterString;
        //post
        public ResSection AnesthesiaAndReanimationMasterResource;

        public string KvcScoreId { get; set; }
        public List<SurgeryAppointmentCarrierClass> PatientSurgeryAppointments = new List<SurgeryAppointmentCarrierClass>();
        public SurgeryAppointment LinkedSurgeryAppointment { get; set; }

        public KvcRiskScore KvcRiskScore { get; set; }
        public string KvcTotalRisk { get; set; }
    }

    public class SurgeryAppointmentCarrierClass
    {
        public Guid AppointmentObjectID { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public string ProcedureDoctor { get; set; }
    }
}