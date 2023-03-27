//$0C2430FE
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using Core.Security;
using Infrastructure.Helpers;
using static TTObjectClasses.SubEpisodeProtocol;

namespace Core.Controllers
{
    public partial class PatientAdmissionServiceController : Controller
    {
        //Kullanýlmýyor
        //[HttpGet]
        //public PatientAdmissionFormViewModel PatientAdmissionForm(Guid? id)
        //{
        //    var formDefID = Guid.Parse("ae86a7f9-497c-4945-8198-108dc56abbb0");
        //    var objectDefID = Guid.Parse("417114a6-5caa-4613-ab25-7ef4b28f5f82");
        //    var viewModel = new PatientAdmissionFormViewModel();
        //    if (id.HasValue && id.Value != Guid.Empty)
        //    {
        //        using (var objectContext = new TTObjectContext(false))
        //        {
        //            viewModel._PatientAdmission = objectContext.GetObject(id.Value, objectDefID) as PatientAdmission;
        //            viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientAdmission, formDefID);
        //            viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientAdmission, formDefID);
        //            objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
        //            ContextToViewModel(viewModel, objectContext);
        //            PreScript_PatientAdmissionForm(viewModel, viewModel._PatientAdmission);
        //            objectContext.FullPartialllyLoadedObjects();
        //        }
        //    }
        //    else
        //    {
        //        using (var objectContext = new TTObjectContext(false))
        //        {
        //            viewModel._PatientAdmission = new PatientAdmission(objectContext);
        //            viewModel.SubEpisodesSubEpisodeGridList = new TTObjectClasses.SubEpisode[] { };
        //            viewModel.ResourcesToBeReferredGridList = new TTObjectClasses.PatientAdmissionResourcesToBeReferred[] { };
        //            viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientAdmission, formDefID);
        //            viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientAdmission, formDefID);
        //            PreScript_PatientAdmissionForm(viewModel, viewModel._PatientAdmission);
        //        }
        //    }
        //    return viewModel;
        //}

        public class ResultSet : BaseViewModel
        {
            public Guid ObjectID
            {
                get;
                set;
            }

            public string Message
            {
                get;
                set;
            }
            public string MedulaErrorMessage
            {
                get;
                set;
            }
            public MedulaTransferredPayerWarningDTO medulaTransferredPayerWarningDTO { get; set; } = new MedulaTransferredPayerWarningDTO();
        }


        internal ResultSet PatientAdmissionFormInternal(PatientAdmissionFormViewModel viewModel, TTObjectContext objectContext)
        {
            ResultSet resultSet = new ResultSet();
            var formDefID = Guid.Parse("ae86a7f9-497c-4945-8198-108dc56abbb0");
            var patientAdmission = (PatientAdmission)objectContext.GetLoadedObject(viewModel._PatientAdmission.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(patientAdmission, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientAdmission, formDefID);
                var episodeImported = patientAdmission.Episode;
                if (episodeImported != null)
                {
                    if (viewModel.SubEpisodesSubEpisodeGridList != null)
                    {
                        foreach (var item in viewModel.SubEpisodesSubEpisodeGridList)
                        {
                            var subEpisodesImported = (SubEpisode)objectContext.GetLoadedObject(item.ObjectID);
                            if (((ITTObject)subEpisodesImported).IsDeleted)
                                continue;
                            subEpisodesImported.Episode = episodeImported;
                        }
                    }
                }

                if (viewModel.ResourcesToBeReferredGridList != null)
                {
                    foreach (var item in viewModel.ResourcesToBeReferredGridList)
                    {
                        var resourcesToBeReferredImported = (PatientAdmissionResourcesToBeReferred)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)resourcesToBeReferredImported).IsDeleted)
                            continue;
                        resourcesToBeReferredImported.PatientAdmission = patientAdmission;
                    }
                }

                if (viewModel.EDisabledReports != null)
                {
                    foreach (var item in viewModel.EDisabledReports)
                    {
                        var eDisabledReport = (EDisabledReport)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)eDisabledReport).IsDeleted)
                            continue;
                        if (eDisabledReport.PatientAdmission.Count == 0)
                            eDisabledReport.PatientAdmission.Add(patientAdmission);
                    }
                }

                if (viewModel.EStatusNotRepCommitteeObjs != null)
                {
                    foreach (var item in viewModel.EStatusNotRepCommitteeObjs)
                    {
                        var eStatusNotReportComObj = (EStatusNotRepCommitteeObj)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)eStatusNotReportComObj).IsDeleted)
                            continue;
                        if (eStatusNotReportComObj.PatientAdmission.Count == 0)
                            eStatusNotReportComObj.PatientAdmission.Add(patientAdmission);
                    }
                }

                var transDef = patientAdmission.TransDef;
                PostScript_PatientAdmissionForm(viewModel, patientAdmission, transDef, objectContext);
                resultSet.UpdatedObjects = objectContext.GetDirtyObjects();
                objectContext.Save();
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(patientAdmission);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(patientAdmission);
                AfterContextSaveScript_PatientAdmissionForm(viewModel, viewModel._PatientAdmission, transDef, objectContext);
                resultSet.OutgoingTransitions = viewModel.OutgoingTransitions;
                resultSet.CurrentStateReports = viewModel.CurrentStateReports;
                resultSet.ObjectID = viewModel._PatientAdmission.ObjectID;
                resultSet.Message = viewModel.returnMessage;
                resultSet.MedulaErrorMessage = viewModel.returnMedulaErrorMessage;
                resultSet.medulaTransferredPayerWarningDTO = viewModel.medulaTransferredPayerWarningDTO;
                objectContext.FullPartialllyLoadedObjects();
            
            return resultSet;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public ResultSet PatientAdmissionForm(PatientAdmissionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                
                objectContext.AddToRawObjectList(viewModel.Patients);
                objectContext.AddToRawObjectList(viewModel.SKRSUlkeKodlaris);
                objectContext.AddToRawObjectList(viewModel.SKRSOgrenimDurumus);
                objectContext.AddToRawObjectList(viewModel.SKRSKanGrubus);
                objectContext.AddToRawObjectList(viewModel.SKRSMesleklers);
                objectContext.AddToRawObjectList(viewModel.SKRSCinsiyets);
                objectContext.AddToRawObjectList(viewModel.SKRSILKodlaris);
                objectContext.AddToRawObjectList(viewModel.SKRSOzurlulukDurumus);
                objectContext.AddToRawObjectList(viewModel.TownDefinitionss);
                objectContext.AddToRawObjectList(viewModel.MedulaProvisions);
                objectContext.AddToRawObjectList(viewModel.PatientIdentityAndAddresss);
                objectContext.AddToRawObjectList(viewModel.SKRSMahalleKodlaris);
                objectContext.AddToRawObjectList(viewModel.SKRSKoyKodlaris);
                objectContext.AddToRawObjectList(viewModel.SKRSCSBMTipis);
                objectContext.AddToRawObjectList(viewModel.SKRSBucakKodlaris);
                objectContext.AddToRawObjectList(viewModel.SKRSIlceKodlaris);
                objectContext.AddToRawObjectList(viewModel.SKRSAdresTipis);
                objectContext.AddToRawObjectList(viewModel.SKRSTRIAJKODUs);
                objectContext.AddToRawObjectList(viewModel.SKRSAdliVakaGelisSeklis);
                objectContext.AddToRawObjectList(viewModel.SKRSYabanciHastaTurus);
                objectContext.AddToRawObjectList(viewModel.SKRSMaritalStatuss);
                objectContext.AddToRawObjectList(viewModel.SKRSDogumSirasis);
                objectContext.AddToRawObjectList(viewModel.ProtocolDefinitions);
                objectContext.AddToRawObjectList(viewModel.PayerDefinitions);
                objectContext.AddToRawObjectList(viewModel.Episodes);
                objectContext.AddToRawObjectList(viewModel.ProvizyonTipis);
                objectContext.AddToRawObjectList(viewModel.ExternalHospitalDefinitions);
                objectContext.AddToRawObjectList(viewModel.EmergencyInterventions);
                objectContext.AddToRawObjectList(viewModel.ResPoliclinics);
                objectContext.AddToRawObjectList(viewModel.PriorityStatusDefinitions);
                objectContext.AddToRawObjectList(viewModel.EDisabledReports);
                objectContext.AddToRawObjectList(viewModel.EStatusNotRepCommitteeObjs);
                objectContext.AddToRawObjectList(viewModel.ResDepartments);
                objectContext.AddToRawObjectList(viewModel.ResBuildings);
                objectContext.AddToRawObjectList(viewModel.ResUsers);
                objectContext.AddToRawObjectList(viewModel.ResSections);
                objectContext.AddToRawObjectList(viewModel.HCRequestReasons);
                objectContext.AddToRawObjectList(viewModel.ReasonForExaminationDefinitions);
                objectContext.AddToRawObjectList(viewModel.SubEpisodesSubEpisodeGridList);
                objectContext.AddToRawObjectList(viewModel.ResourcesToBeReferredGridList);

                objectContext.AddToRawObjectList(viewModel.SEPMasters);
                objectContext.AddToRawObjectList(viewModel.SubEpisode);
                objectContext.AddToRawObjectList(viewModel.SubEpisodeProtocol);

                objectContext.AddToRawObjectList(viewModel._PatientAdmission);



                objectContext.ProcessRawObjects();
                return PatientAdmissionFormInternal(viewModel, objectContext);
            }
        }

        partial void PostScript_PatientAdmissionForm(PatientAdmissionFormViewModel viewModel, PatientAdmission patientAdmission, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_PatientAdmissionForm(PatientAdmissionFormViewModel viewModel, PatientAdmission patientAdmission, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_PatientAdmissionForm(PatientAdmissionFormViewModel viewModel, PatientAdmission patientAdmission);
        void ContextToViewModel(PatientAdmissionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var episode = viewModel._PatientAdmission.Episode;
            if (episode != null)
            {
                viewModel.SubEpisodesSubEpisodeGridList = episode.SubEpisodes.OfType<SubEpisode>().ToArray();
            }

            viewModel.ResourcesToBeReferredGridList = viewModel._PatientAdmission.ResourcesToBeReferred.OfType<PatientAdmissionResourcesToBeReferred>().ToArray();
            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
            viewModel.SKRSUlkeKodlaris = objectContext.LocalQuery<SKRSUlkeKodlari>().ToArray();
            viewModel.SKRSOgrenimDurumus = objectContext.LocalQuery<SKRSOgrenimDurumu>().ToArray();
            viewModel.SKRSKanGrubus = objectContext.LocalQuery<SKRSKanGrubu>().ToArray();
            viewModel.SKRSMesleklers = objectContext.LocalQuery<SKRSMeslekler>().ToArray();
            viewModel.SKRSCinsiyets = objectContext.LocalQuery<SKRSCinsiyet>().ToArray();
            viewModel.SKRSILKodlaris = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
            viewModel.SKRSOzurlulukDurumus = objectContext.LocalQuery<SKRSOzurlulukDurumu>().ToArray();
            viewModel.TownDefinitionss = objectContext.LocalQuery<TownDefinitions>().ToArray();
            viewModel.MedulaProvisions = objectContext.LocalQuery<MedulaProvision>().ToArray();
            viewModel.PatientIdentityAndAddresss = objectContext.LocalQuery<PatientIdentityAndAddress>().ToArray();
            viewModel.SKRSMahalleKodlaris = objectContext.LocalQuery<SKRSMahalleKodlari>().ToArray();
            viewModel.SKRSKoyKodlaris = objectContext.LocalQuery<SKRSKoyKodlari>().ToArray();
            viewModel.SKRSCSBMTipis = objectContext.LocalQuery<SKRSCSBMTipi>().ToArray();
            viewModel.SKRSBucakKodlaris = objectContext.LocalQuery<SKRSBucakKodlari>().ToArray();
            viewModel.SKRSIlceKodlaris = objectContext.LocalQuery<SKRSIlceKodlari>().ToArray();
            viewModel.SKRSAdresTipis = objectContext.LocalQuery<SKRSAdresTipi>().ToArray();
            viewModel.SKRSTRIAJKODUs = objectContext.LocalQuery<SKRSTRIAJKODU>().ToArray();
            viewModel.SKRSAdliVakaGelisSeklis = objectContext.LocalQuery<SKRSAdliVakaGelisSekli>().ToArray();
            viewModel.SKRSYabanciHastaTurus = objectContext.LocalQuery<SKRSYabanciHastaTuru>().ToArray();
            viewModel.SKRSMaritalStatuss = objectContext.LocalQuery<SKRSMedeniHali>().ToArray();
            viewModel.SKRSDogumSirasis = objectContext.LocalQuery<SKRSDogumSirasi>().ToArray();
            viewModel.SigortaliTurus = objectContext.LocalQuery<SigortaliTuru>().ToArray();
            viewModel.ProtocolDefinitions = objectContext.LocalQuery<ProtocolDefinition>().ToArray();
            viewModel.PayerDefinitions = objectContext.LocalQuery<PayerDefinition>().ToArray();
            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
            viewModel.ProvizyonTipis = objectContext.LocalQuery<ProvizyonTipi>().ToArray();
            viewModel.EmergencyInterventions = objectContext.LocalQuery<EmergencyIntervention>().ToArray();
            viewModel.ResPoliclinics = objectContext.LocalQuery<ResPoliclinic>().ToArray();
            viewModel.PriorityStatusDefinitions = objectContext.LocalQuery<PriorityStatusDefinition>().ToArray();
            viewModel.ResDepartments = objectContext.LocalQuery<ResDepartment>().ToArray();
            viewModel.ResBuildings = objectContext.LocalQuery<ResBuilding>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            viewModel.HCRequestReasons = objectContext.LocalQuery<HCRequestReason>().ToArray();
            viewModel.ReasonForExaminationDefinitions = objectContext.LocalQuery<ReasonForExaminationDefinition>().ToArray();
            viewModel.EDisabledReports = objectContext.LocalQuery<EDisabledReport>().ToArray();
            viewModel.EStatusNotRepCommitteeObjs = objectContext.LocalQuery<EStatusNotRepCommitteeObj>().ToArray();
            viewModel.ExternalHospitalDefinitions = objectContext.LocalQuery<ExternalHospitalDefinition>().ToArray();

            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKanGrubuList", viewModel.SKRSKanGrubus);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSUlkeKodlariList", viewModel.SKRSUlkeKodlaris);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOgrenimDurumuList", viewModel.SKRSOgrenimDurumus);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMesleklerList", viewModel.SKRSMesleklers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSCinsiyetList", viewModel.SKRSCinsiyets);
            //            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TownListDefinition", viewModel.TownDefinitionss);
            //            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "CityListDefinition", viewModel.SKRSILKodlaris);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDogumSirasiList", viewModel.SKRSDogumSirasis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMahalleKodlariList", viewModel.SKRSMahalleKodlaris);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKoyKodlariList", viewModel.SKRSKoyKodlaris);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSCSBMTipiList", viewModel.SKRSCSBMTipis);
            //ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBucakKodlariList", viewModel.SKRSBucakKodlaris);
            //            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSIlceKodlari", viewModel.SKRSIlceKodlaris);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SigortaliTuruListDefinition", viewModel.SigortaliTurus);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProtocolListDefinition", viewModel.ProtocolDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PayerListDefinition", viewModel.PayerDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSTRIAJKODUList", viewModel.SKRSTRIAJKODUs);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAdliVakaGelisSekliList", viewModel.SKRSAdliVakaGelisSeklis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSYabanciHastaTuruList", viewModel.SKRSYabanciHastaTurus);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProvizyonTipiListDefinition", viewModel.ProvizyonTipis);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PoliclinicsListDefinition", viewModel.ResPoliclinics);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PriorityStatusListDef", viewModel.PriorityStatusDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DepartmentListDefinition", viewModel.ResDepartments);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BuildinglistDefinition", viewModel.ResBuildings);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinitionForPA", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PoliclinicAndEmergencyListDefinition", viewModel.ResSections);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "HealthCommitteeExaminationReasonListDefinition", viewModel.ReasonForExaminationDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMedeniHaliList", viewModel.SKRSMaritalStatuss);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOzurlulukDurumuList", viewModel.SKRSOzurlulukDurumus);

        }
    }
}

namespace Core.Models
{
    public partial class PatientAdmissionFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PatientAdmission _PatientAdmission
        {
            get;
            set;
        }

        public TTObjectClasses.SubEpisode[] SubEpisodesSubEpisodeGridList
        {
            get;
            set;
        }

        public TTObjectClasses.PatientAdmissionResourcesToBeReferred[] ResourcesToBeReferredGridList
        {
            get;
            set;
        }

        public TTObjectClasses.EDisabledReport[] EDisabledReports
        {
            get;
            set;
        }

        public TTObjectClasses.EStatusNotRepCommitteeObj[] EStatusNotRepCommitteeObjs
        {
            get;
            set;
        }

        public TTObjectClasses.Patient[] Patients
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSUlkeKodlari[] SKRSUlkeKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSOgrenimDurumu[] SKRSOgrenimDurumus
        {
            get;
            set;
        }
        public TTObjectClasses.SKRSKanGrubu[] SKRSKanGrubus
        {
            get;
            set;
        }
        public TTObjectClasses.SKRSMeslekler[] SKRSMesleklers
        {
            get;
            set;
        }
        public TTObjectClasses.SKRSOzurlulukDurumu[] SKRSOzurlulukDurumus
        {
            get;
            set;
        }
        public TTObjectClasses.SKRSCinsiyet[] SKRSCinsiyets
        {
            get;
            set;
        }

        public TTObjectClasses.TownDefinitions[] TownDefinitionss
        {
            get;
            set;
        }
        public TTObjectClasses.ExternalHospitalDefinition[] ExternalHospitalDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSILKodlari[] SKRSILKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSDogumSirasi[] SKRSDogumSirasis
        {
            get;
            set;
        }

        public TTObjectClasses.MedulaProvision[] MedulaProvisions
        {
            get;
            set;
        }

        public TTObjectClasses.PatientIdentityAndAddress[] PatientIdentityAndAddresss
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSMahalleKodlari[] SKRSMahalleKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSKoyKodlari[] SKRSKoyKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSCSBMTipi[] SKRSCSBMTipis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSBucakKodlari[] SKRSBucakKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSIlceKodlari[] SKRSIlceKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSAdresTipi[] SKRSAdresTipis
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSTRIAJKODU[] SKRSTRIAJKODUs
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSAdliVakaGelisSekli[] SKRSAdliVakaGelisSeklis
        {
            get;
            set;
        }
        public TTObjectClasses.SKRSYabanciHastaTuru[] SKRSYabanciHastaTurus
        {
            get;
            set;
        }
        public TTObjectClasses.SKRSMedeniHali[] SKRSMaritalStatuss { get; set; }
        public TTObjectClasses.ProtocolDefinition[] ProtocolDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.PayerDefinition[] PayerDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }

        public TTObjectClasses.ProvizyonTipi[] ProvizyonTipis
        {
            get;
            set;
        }

        public TTObjectClasses.EmergencyIntervention[] EmergencyInterventions
        {
            get;
            set;
        }

        public TTObjectClasses.ResPoliclinic[] ResPoliclinics
        {
            get;
            set;
        }

        public TTObjectClasses.PriorityStatusDefinition[] PriorityStatusDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResDepartment[] ResDepartments
        {
            get;
            set;
        }

        public TTObjectClasses.ResBuilding[] ResBuildings
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.ResSection[] ResSections
        {
            get;
            set;
        }

        public TTObjectClasses.HCRequestReason[] HCRequestReasons
        {
            get;
            set;
        }

        public TTObjectClasses.ReasonForExaminationDefinition[] ReasonForExaminationDefinitions
        {
            get;
            set;
        }

        public bool fromVerifiedKPSBtn = false;

    }
}