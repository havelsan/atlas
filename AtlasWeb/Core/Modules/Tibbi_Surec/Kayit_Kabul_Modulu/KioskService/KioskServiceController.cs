using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Security;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using TTInstanceManagement;
using TTObjectClasses;
using static Core.Controllers.PatientAdmissionServiceController;
using static TTObjectClasses.SubEpisodeProtocol;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class KioskServiceController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public PatientAdmissionFormViewModel LoadPatientAdmission(long? kimlikno)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    PatientAdmissionServiceController serviceController = new PatientAdmissionServiceController();
                    PatientAdmissionFormViewModel viewModel = null;
                    Patient p = Patient.GetPatientsByUniqueRefNo(objectContext, kimlikno.Value).FirstOrDefault();
                    if (p == null)
                    {
                        Patient pp = new Patient(objectContext);
                        pp.UniqueRefNo = kimlikno;
                        viewModel = serviceController.PatientAdmissionFormLoadInternal(pp, objectContext);
                    }
                    else
                        viewModel = serviceController.PatientAdmissionFormLoadInternal(p, objectContext);

                    //var aa= SavePatientAdmission(viewModel, objectContext);
                    return viewModel;
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ResultSet SavePatientAdmission(PatientAdmissionSaveDTO saveDTO)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PatientAdmissionServiceController serviceController = new PatientAdmissionServiceController();
                PatientAdmissionFormViewModel viewModel = null;
                bool _isnewPatient = false;

                try
                {
                    Patient p = Patient.GetPatientsByUniqueRefNo(objectContext, saveDTO.UniqueRefNo).FirstOrDefault();
                    if (p == null)
                    {
                        Patient pp = new Patient(objectContext);
                        pp.UniqueRefNo = saveDTO.UniqueRefNo;

                        _isnewPatient = true;
                        viewModel = serviceController.PatientAdmissionFormLoadInternal(pp, objectContext);
                    }
                    else
                        viewModel = serviceController.PatientAdmissionFormLoadInternal(p, objectContext);

                    //viewModel = serviceController.PatientAdmissionFormLoadInternal(viewModel.Patients[0], objectContext);

                    if (string.IsNullOrEmpty(saveDTO.AppointmentID))
                    {
                        #region SET admission Property from client
                        viewModel._PatientAdmission.Department = objectContext.GetObject<ResDepartment>(new Guid(saveDTO.DepartmentID));
                        viewModel._PatientAdmission.Policlinic = objectContext.GetObject<ResPoliclinic>(new Guid(saveDTO.PoliclinicID));
                        viewModel._PatientAdmission.ProcedureDoctor = objectContext.GetObject<ResUser>(new Guid(saveDTO.DoctorID));
                        #endregion
                    }
                    else//randevu bilgileri ile dolacak
                    {
                        viewModel._PatientAdmission = PatientAdmission.LoadAppointmentInfo(viewModel._PatientAdmission, objectContext, new Guid(saveDTO.AppointmentID));
                    }

                    #region default veriler
                    if (viewModel._PatientAdmission.PA_Address != null && _isnewPatient)//yeni kaydedilecek hastanın telefon numarası
                        viewModel._PatientAdmission.PA_Address.MobilePhone = saveDTO.MobilePhone;

                    if (viewModel._PatientAdmission.Payer == null)
                    {
                        string sgkPayerObjectID = TTObjectClasses.SystemParameter.GetParameterValue("SGKPAYERDEFINITION", "ef3e2dc7-2ae8-4603-b199-ec4600267856");
                        PayerDefinition sgkPayer = objectContext.GetObject(new Guid(sgkPayerObjectID), typeof(PayerDefinition)) as PayerDefinition;

                        viewModel._PatientAdmission.Payer = sgkPayer;
                        viewModel.tempPayer = sgkPayer;

                        viewModel._PatientAdmission.MedulaSigortaliTuru = SigortaliTuru.GetSigortaliTuru("1");
                    }
                    #endregion

                    ResultSet result = serviceController.PatientAdmissionFormInternal(viewModel, objectContext);

                    try
                    {                        
                        if (result.MedulaErrorMessage == "ProvisionError")
                        {
                            DeletePA(viewModel._PatientAdmission.ObjectID);
                        }
                    }
                    catch (Exception)
                    {

                    }

                    return result;
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
        }

        public void DeletePA(Guid ObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PatientAdmission pa = objectContext.GetObject<PatientAdmission>(ObjectID, false) as PatientAdmission;
                if (pa != null)
                {
                    PatientAdmission.DeletePatientAdmission(pa);
                    objectContext.Save();
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ResultSet SavePatientAdmission_yedek(PatientAdmissionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PatientAdmissionServiceController serviceController = new PatientAdmissionServiceController();
                PatientAdmissionFormViewModel viewModel1 = null;

                try
                {
                    viewModel1 = serviceController.PatientAdmissionFormLoadInternal(viewModel.Patients[0], objectContext);

                    ResultSet result = serviceController.PatientAdmissionFormInternal(viewModel1, objectContext);
                    return null;
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<PolyclinicDoctorBranchGroupModel> PolyclinicAndBranchByProcedureDoctor(string Doctor)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PatientAdmissionServiceController serviceController = new PatientAdmissionServiceController();

                ResUser user = objectContext.GetObject<ResUser>(new Guid(Doctor));

                return serviceController.PolyclinicAndBranchByProcedureDoctor(user).Where(x => x.PolyclinicObject.ShownInKiosk == true).ToList();

            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public int getWaitingPatienCount(string polID,string docID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<Guid> polList = new List<Guid>();
                polList.Add(new Guid(polID));

                List<ExaminationQueueItem.GetActiveQueueItemByPolID_Class> _queList = ExaminationQueueItem.GetActiveQueueItemByPolID(polList, DateTime.Now.Date, DateTime.Now.AddDays(1).Date).ToList();

                if (_queList != null && _queList.Count > 0)
                {
                    ExaminationQueueItem.GetActiveQueueItemByPolID_Class activeQueueItem = _queList.Where(x => x.Doctor == new Guid(docID)).FirstOrDefault();

                    if (activeQueueItem != null)
                        return Convert.ToInt32(activeQueueItem.Toplam);
                    else
                        return 0;
                }
                else
                    return 0;
            }
            
        }

        #region SONUÇ SIRASI
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<TodayPAListDTO> GetTodayAdmission(long? kimlikno)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<TodayPAListDTO> listDTOs = new List<TodayPAListDTO>();

                  Patient p = Patient.GetPatientsByUniqueRefNo(objectContext, kimlikno.Value).FirstOrDefault();
                if (p == null)
                {
                    throw new Exception("Hasta Bilgilerine Ulaşılamadı.\nLütfen Bankoya Danışınız");
                }
                else
                {
                    List<GetPaBySearchPatient_Class> getPaBySearchPatientList = SubEpisodeProtocol.GetPaBySearchPatient(p.ObjectID).ToList();

                    if (getPaBySearchPatientList == null || getPaBySearchPatientList.Count == 0)
                    {
                        throw new Exception("Sonuç Sırası Alabileceğiniz Bir Kabul Bulunamadı.\nLütfen Bankoya Danışınız");
                    }
                    else
                    {
                        getPaBySearchPatientList = getPaBySearchPatientList.Where(x => x.Openingdate.Value.Date == DateTime.Now.Date && x.Fromse.ToString() == "0").ToList();

                        if (getPaBySearchPatientList == null || getPaBySearchPatientList.Count == 0)
                        {
                            throw new Exception("Sonuç Sırası Alabileceğiniz Bugüne Ait Bir Kabul Bulunamadı.\nLütfen Bankoya Danışınız");
                        }

                        foreach (var item in getPaBySearchPatientList)
                        {
                            TodayPAListDTO dto = new TodayPAListDTO();
                            dto.ObjectID = item.ObjectID.ToString();
                            dto.DocName = item.Doctorname;
                            dto.PolName = item.Policlinicname;
                            dto.ProtocolNo = item.ProtocolNo;

                            PatientAdmission pa = objectContext.GetObject<PatientAdmission>(item.ObjectID.Value);
                            dto.ResultQueueNo = pa.ResultQueueNumber.Value == null ? "0" : pa.ResultQueueNumber.Value.ToString();

                            listDTOs.Add(dto);
                        }

                        return listDTOs;
                    }
                        //return getPaBySearchPatientList.Where(x=> x.Openingdate.Value.Date == DateTime.Now.Date && x.Fromse.ToString() == "0").ToList();
                }
            }

        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Gorme)]
        public string PrintResultBarcode(Guid admissionID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PatientAdmission pa = objectContext.GetObject(admissionID, typeof(PatientAdmission)) as PatientAdmission;
                if (pa != null)
                {
                    ControlQuotaAndWorkingTime(pa, objectContext);

                    if (pa.AdmissionStatus == AdmissionStatusEnum.Acil)
                        throw new TTUtils.TTException("Acil birimine 'Sonuç sıra numarası' alamazsınız.");

                    if (pa.PAStatus == PAStatusEnum.IptalEdildi || pa.PAStatus == PAStatusEnum.KabulSilindi || pa.PAStatus == PAStatusEnum.MuayeneyeGelmedi)
                        throw new TTUtils.TTException(pa.PAStatus + " statüsünde olduğu için 'Sonuç sıra numarası' alamazsınız.");


                    if (pa.Policlinic != null && pa.ResultQueueNumber.Value == null)
                        pa.ResultQueueNumber.GetNextValue(pa.Policlinic.ObjectID.ToString() + DateTime.Today.ToShortDateString());

                    objectContext.Update();

                    foreach (EpisodeAction ea in pa.FiredEpisodeActions)
                    {
                        if (ea is PatientExamination)
                        {
                            ea.WorkListDate = Common.RecTime();

                            ((EpisodeAction)ea).UpdateExaminationQueueItem(pa);
                        }
                    }

                    objectContext.Save();
                }
                return pa.ResultQueueNumber.ToString();
            }
        }

        public void ControlQuotaAndWorkingTime(PatientAdmission pa, TTObjectContext objectContext)
        {
            DoctorQuotaDefinition doctorQuota = DoctorQuotaDefinition.GetDoctorQuotaByPoliclinic(objectContext, pa.Policlinic.ObjectID, pa.ProcedureDoctor.ObjectID).FirstOrDefault();

            if (doctorQuota != null)
            {
                if (doctorQuota.ResultStartTime != null && doctorQuota.ResultEndtTime != null 
                    && (doctorQuota.ResultStartTime.Value.Hour > DateTime.Now.Hour || DateTime.Now.Hour > doctorQuota.ResultEndtTime.Value.Hour))
                {
                    throw new Exception("Bu birim için " + doctorQuota.ResultStartTime.Value.Hour + ":00 ve " + doctorQuota.ResultEndtTime.Value.Hour + ":00 saatleri arasında sonuç sırası alabilirsiniz");
                }
                else if(doctorQuota.ResultQuota != null)
                {
                    PatientAdmission.GetMaxResultQueueByPol_Class maxQueueNum = PatientAdmission.GetMaxResultQueueByPol(pa.Policlinic.ObjectID, pa.ProcedureDoctor.ObjectID, DateTime.Now.Date).FirstOrDefault();
                    if (maxQueueNum != null && maxQueueNum.Maximumqueuenum != null && Convert.ToInt32(maxQueueNum.Maximumqueuenum) == doctorQuota.ResultQuota.Value)
                    {
                        throw new Exception("Bu birim için bugünkü sonuç sırası kotası dolmuştur.\nLütfen detaylı bilgi için Bankoları kullanın");
                    }
                }
            }
        }

        #endregion

    }
}