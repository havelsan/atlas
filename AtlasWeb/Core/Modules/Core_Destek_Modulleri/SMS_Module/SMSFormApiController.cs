using AtlasSmsManager;
using Core.Models;
using Core.Services;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TTDataDictionary;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace Core.Modules.Merkezi_Yonetim_Sistemi.Tibbi_Surec_Tanim.Hizmet_Tanimlama_Modulu
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class SMSFormApiController : Controller
    {

        [HttpGet]
        public SMSFormViewModel InitSMSForm()
        {
            SMSFormViewModel viewModel = new SMSFormViewModel();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                viewModel.SKRSIlDataSource = objectContext.QueryObjects<SKRSILKodlari>("").Select(x => new SKRSIlDTO
                {
                    ObjectID = x.ObjectID,
                    ADI = x.ADI,
                    ADI_LowerCase = x.ADI.ToLower(),
                    ADI_UpperCase = x.ADI.ToUpper(),
                    KODU = x.KODU
                }).ToList();
                viewModel.SpecialityDefDataSource = objectContext.QueryObjects<SpecialityDefinition>("").Select(x => new SpecialityDefinitionDTO
                {
                    Code = x.Code,
                    Name = x.Name,
                    Name_LowerCase = x.Name.ToLower(),
                    Name_Shadow = x.Name_Shadow,
                    Name_UpperCase = x.Name.ToUpper(),
                    ObjectID = x.ObjectID
                }).ToList();
                viewModel.ProvizyonTipiDataSource = objectContext.QueryObjects<ProvizyonTipi>("").ToList();
                viewModel.IstisnaiHalDataSource = objectContext.QueryObjects<IstisnaiHal>("").ToList();
                viewModel.TedaviTuruDataSource = objectContext.QueryObjects<TedaviTuru>("").ToList();
            }
            return viewModel;
        }

        [HttpPost]
        public List<SMSPatientGridViewModel> GetPatientList(SMSPatientSearchModel searchModel)
        {
            List<SMSPatientGridViewModel> viewModel = new List<SMSPatientGridViewModel>();

            using (var objectContext = new TTObjectContext(true))
            {
                if (searchModel.AdmissionStartDate.HasValue)
                {
                    string filter = string.Empty;

                    if (!string.IsNullOrWhiteSpace(searchModel.FirstName))
                        filter += " AND THIS:SUBEPISODE:EPISODE:PATIENT.NAME LIKE '%" + searchModel.FirstName.ToUpper() + "%'";

                    if (!string.IsNullOrWhiteSpace(searchModel.SurName))
                        filter += " AND THIS:SUBEPISODE:EPISODE:PATIENT.SURNAME LIKE '%" + searchModel.SurName.ToUpper() + "%'";

                    if (searchModel.Gender != null)
                        filter += " AND THIS:SUBEPISODE:EPISODE:PATIENT.SEX.KODU = '" + searchModel.Gender + "'";

                    if (searchModel.BirthDate.HasValue)
                        filter += " AND THIS:SUBEPISODE:EPISODE:PATIENT.BIRTHDATE = TODATE('" + searchModel.BirthDate.Value.ToString("yyyy-MM-dd") + "')";

                    if (searchModel.HasPhoneNumber.HasValue && searchModel.HasPhoneNumber.Value)
                        filter += " AND THIS:SUBEPISODE:EPISODE:PATIENT.PATIENTADDRESS.MOBILEPHONE IS NOT NULL";

                    if (searchModel.InPatientStartDate.HasValue)
                    {
                        string startDate = Convert.ToDateTime((searchModel.InPatientStartDate.Value.ToShortDateString() + " 00:00:00")).ToString("yyyy-MM-dd HH:mm:ss");

                        string endDate = string.Empty;

                        if (searchModel.InPatientEndDate.HasValue)
                            endDate = Convert.ToDateTime(searchModel.AdmissionEndDate.Value.ToShortDateString() + " 23:59:59").ToString("yyyy-MM-dd HH:mm:ss");
                        else
                            endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 23:59:59").ToString("yyyy-MM-dd HH:mm:ss");

                        filter += " AND THIS:SUBEPISODE.INPATIENTADMISSION.HOSPITALINPATIENTDATE BETWEEN TODATE('" + startDate + "') AND TODATE('" + endDate + "')";
                    }

                    if (searchModel.SelectedCityOfBirthPlace.HasValue && searchModel.SelectedCityOfBirthPlace != Guid.Empty)
                    {
                        if (searchModel.SelectedCountyOfBirthPlace.HasValue && searchModel.SelectedCountyOfBirthPlace != Guid.Empty)
                        {
                            SKRSIlceKodlari city = objectContext.GetObject<SKRSIlceKodlari>(searchModel.SelectedCountyOfBirthPlace.Value);
                            filter += " AND THIS:SUBEPISODE:EPISODE:PATIENT.BIRTHPLACE ='" + city.ADI + "'";
                        }
                        else
                        {
                            SKRSILKodlari city = objectContext.GetObject<SKRSILKodlari>(searchModel.SelectedCityOfBirthPlace.Value);
                            filter += " AND THIS:SUBEPISODE:EPISODE:PATIENT.BIRTHPLACE ='" + city.ADI + "'";
                        }
                    }

                    if (searchModel.SelectedCityOfAddress.HasValue && searchModel.SelectedCityOfAddress != Guid.Empty)
                    {
                        filter += " AND THIS:SUBEPISODE:EPISODE:PATIENT.PATIENTADDRESS.SKRSILKODLARI = '" + searchModel.SelectedCityOfAddress.Value + "'";

                        if (searchModel.SelectedCountyOfAddress.HasValue && searchModel.SelectedCountyOfAddress != Guid.Empty)
                            filter += " AND THIS:SUBEPISODE:EPISODE:PATIENT.PATIENTADDRESS.SKRSILCEKODLARI = '" + searchModel.SelectedCountyOfAddress.Value + "'";
                    }


                    if (searchModel.Nationality.HasValue && searchModel.Nationality != Guid.Empty)
                        filter += " AND THIS:SUBEPISODE:EPISODE:PATIENT.NATIONALITY = '" + searchModel.Nationality.Value + "'";

                    string admissionStartDate = Convert.ToDateTime((searchModel.AdmissionStartDate.Value.ToShortDateString() + " 00:00:00")).ToString("yyyy-MM-dd HH:mm:ss");

                    string admissionEndDate = string.Empty;

                    if (searchModel.AdmissionEndDate.HasValue)
                        admissionEndDate = Convert.ToDateTime(searchModel.AdmissionEndDate.Value.ToShortDateString() + " 23:59:59").ToString("yyyy-MM-dd HH:mm:ss");
                    else
                        admissionEndDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 23:59:59").ToString("yyyy-MM-dd HH:mm:ss");

                    filter += " AND THIS:SUBEPISODE:EPISODE.OPENINGDATE BETWEEN TODATE('" + admissionStartDate + "') AND TODATE('" + admissionEndDate + "')";

                    //Tanı
                    if (searchModel.SelectedDiagnosis != null && searchModel.SelectedDiagnosis.Count > 0)
                        filter += " AND SEPDIAGNOSES(" + Common.CreateFilterExpressionOfGuidList("", "DIAGNOSE", searchModel.SelectedDiagnosis) + ").EXISTS";

                    //Tedavi Türü
                    if (searchModel.SelectedTreatment != null && searchModel.SelectedTreatment != Guid.Empty)
                        filter += " AND MEDULATEDAVITURU = '" + searchModel.SelectedTreatment.Value + "'";

                    //Kurum
                    if (searchModel.SelectedPayers != null && searchModel.SelectedPayers.Count > 0)
                        filter += " AND " + Common.CreateFilterExpressionOfGuidList("", "PAYER", searchModel.SelectedPayers);

                    //Geliş Sebebi
                    if (searchModel.SelectedProvizyonTipi != null && searchModel.SelectedProvizyonTipi.Count > 0)
                        filter += " AND " + Common.CreateFilterExpressionOfGuidList("", "MEDULAPROVIZYONTIPI", searchModel.SelectedProvizyonTipi);

                    //İstisnai Hal
                    if (searchModel.SelectedIstisnaiHal != null && searchModel.SelectedIstisnaiHal.Count > 0)
                        filter += " AND " + Common.CreateFilterExpressionOfGuidList("", "MEDULAISTISNAIHAL", searchModel.SelectedIstisnaiHal);

                    //Kabul Birimi
                    if (searchModel.SelectedPoliclinics != null && searchModel.SelectedPoliclinics.Count > 0)
                        filter += " AND " + Common.CreateFilterExpressionOfGuidList("", "THIS:SUBEPISODE.RESSECTION", searchModel.SelectedPoliclinics);

                    //Kabul Branşı
                    if (searchModel.SelectedSpecialities != null && searchModel.SelectedSpecialities.Count > 0)
                        filter += " AND " + Common.CreateFilterExpressionOfGuidList("", "BRANS", searchModel.SelectedSpecialities);

                    //Kabul Doktoru
                    if (searchModel.SelectedAdmissionDoctor != null && searchModel.SelectedAdmissionDoctor.Count > 0)
                        filter += " AND " + Common.CreateFilterExpressionOfGuidList("", "THIS:SUBEPISODE.PATIENTADMISSION.PROCEDUREDOCTOR", searchModel.SelectedAdmissionDoctor);

                    viewModel = SubEpisodeProtocol.SMSPatientListQuery(objectContext, filter).Select(x => new SMSPatientGridViewModel
                    {
                        ObjectID = x.ObjectID.Value,
                        Name = x.Name,
                        SurName = x.Surname,
                        Phone = !string.IsNullOrEmpty(x.MobilePhone) ? x.MobilePhone.Trim() : "",
                        UniqueRefNo = x.UniqueRefNo.HasValue ? x.UniqueRefNo.Value.ToString() : ""
                    }).ToList();

                    //Eğer telefon numrası olanlar seçildiyse sadece formata uygun telefon numaralarını getir.
                    if (searchModel.HasPhoneNumber.HasValue && searchModel.HasPhoneNumber.Value)
                    {
                        string RegexDesen = @"^(5(\d{9}))$";
                        //Sadece cep telefonu formatına uygun olan kullanıcıları getirir. Format:5aabbbccdd 10 hane olacak şekilde kabul edildi.
                        viewModel = viewModel.Where(x => Regex.Match(x.Phone, RegexDesen, RegexOptions.IgnoreCase).Success).ToList();
                    }

                    return viewModel;
                }
                else
                    throw new TTException("Lütfen Kabul Bş. Tarihi seçiniz.");
            }
        }

        [HttpPost]
        public List<SMSPersonnelGridViewModel> GetPersonnelList(SMSPersonnelSearchModel searchModel)
        {
            List<SMSPersonnelGridViewModel> viewModel = new List<SMSPersonnelGridViewModel>();
            using (var objectContext = new TTObjectContext(true))
            {
                string filter = "WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(searchModel.FirstName))
                    filter += "AND PERSON.NAME LIKE '%" + searchModel.FirstName + "%'";

                if (!string.IsNullOrWhiteSpace(searchModel.SurName))
                    filter += "AND PERSON.SURNAME LIKE '%" + searchModel.SurName + "%'";

                if (searchModel.WorkStatus != null)
                {
                    //Çalışıyor
                    if (searchModel.WorkStatus == 1)
                        filter += " AND DATEOFLEAVE IS NULL";
                    //Çalışmıyor
                    else
                        filter += " AND DATEOFLEAVE IS NOT NULL";
                }

                if (searchModel.Gender != null)
                    filter += " AND PERSON.SEX.KODU = '" + searchModel.Gender + "'";

                if (searchModel.SelectedCitiesObjectIDs != null && searchModel.SelectedCitiesObjectIDs.Count > 0)
                    filter += " AND " + Common.CreateFilterExpressionOfGuidList("", "PERSON.TOWNOFBIRTH.CITY", searchModel.SelectedCitiesObjectIDs);

                if (searchModel.BirthDate.HasValue)
                    filter += " AND PERSON.BIRTHDATE = TODATE('" + searchModel.BirthDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                if (searchModel.SelectedOccupations != null && searchModel.SelectedOccupations.Count > 0)
                    filter += " AND " + Common.CreateFilterExpressionOfStringList("USERTYPE", searchModel.SelectedOccupations.Select(x => x.ToString()).ToList());

                if (searchModel.SelectedResourcesObjectIDs != null && searchModel.SelectedResourcesObjectIDs.Count > 0)
                {
                    filter += " AND USERRESOURCES(";
                    filter += Common.CreateFilterExpressionOfGuidList("", "RESOURCE", searchModel.SelectedResourcesObjectIDs);
                    filter += ").EXISTS";
                }

                if (searchModel.SelectedSpecialityObjectIDs != null && searchModel.SelectedSpecialityObjectIDs.Count > 0)
                {
                    filter += " AND RESOURCESPECIALITIES(";
                    filter += Common.CreateFilterExpressionOfGuidList("", "SPECIALITY", searchModel.SelectedSpecialityObjectIDs);
                    filter += ").EXISTS";
                }

                if (searchModel.Title != null)
                    filter += " AND TITLE =" + searchModel.Title;

                if (searchModel.HasPhoneNumber.HasValue && searchModel.HasPhoneNumber.Value)
                    filter += " AND PHONENUMBER IS NOT NULL";

                var userList = ResUser.GetResUserForSMS(filter);

                //foreach (var item in userList)
                //{
                //    try
                //    {
                //        SMSPersonnelGridViewModel userDTO = new SMSPersonnelGridViewModel();
                //        userDTO.ObjectID = item.ObjectID.Value;
                //        userDTO.Name = item.Name;
                //        userDTO.SurName = item.Person != null ? item.Person.Surname : "";
                //        userDTO.Phone = item.PhoneNumber;
                //        userDTO.Position = item.UserType != null ? Common.GetDisplayTextOfDataTypeEnum(item.UserType.Value) : "";
                //        userDTO.WorkStatus = item.DateOfLeave == null ? "Çalışıyor" : "Çalışmıyor";
                //        viewModel.Add(userDTO);
                //    }
                //    catch
                //    {
                //        continue;
                //    }
                //}

                viewModel = userList.Select(x => new SMSPersonnelGridViewModel
                {
                    ObjectID = x.ObjectID.Value,
                    Name = x.Name,
                    SurName = x.Surname,
                    Phone = !string.IsNullOrEmpty(x.PhoneNumber) ? x.PhoneNumber.Trim() : "",
                    Position = x.UserType != null ? Common.GetDisplayTextOfDataTypeEnum(x.UserType.Value) : "",
                    WorkStatus = x.DateOfLeave == null ? "Çalışıyor" : "Çalışmıyor"
                }).ToList();

                if (searchModel.HasPhoneNumber.HasValue && searchModel.HasPhoneNumber.Value)
                {
                    string RegexDesen = @"^(5(\d{9}))$";
                    //Sadece cep telefonu formatına uygun olan kullanıcıları getirir. Format:5aabbbccdd 10 hane olacak şekilde kabul edildi.
                    viewModel = viewModel.Where(x => Regex.Match(x.Phone, RegexDesen, RegexOptions.IgnoreCase).Success).ToList();
                }

                return viewModel;
            }
        }

        [HttpPost]
        public Guid? SaveSMSToPatient(SendPatientSMSModel model)
        {
            if (model != null && model.SMSModel != null && model.SMSModel.Count > 0)
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    SendSMSMaster smsMaster = CreateSendSMSMaster(objectContext, model.SMSText, true, model.smsType);

                    foreach (SMSPatientGridViewModel smsItem in model.SMSModel)
                    {
                        SendSMSDetail sendSMSDetail = new SendSMSDetail(objectContext);
                        sendSMSDetail.SendSMSMaster = smsMaster;
                        sendSMSDetail.FirstName = smsItem.Name;
                        sendSMSDetail.SurName = smsItem.SurName;
                        sendSMSDetail.PhoneNumber = smsItem.Phone;
                        sendSMSDetail["PATIENT"] = smsItem.ObjectID;
                        sendSMSDetail.CurrentStateDefID = SendSMSDetail.States.New;
                    }

                    objectContext.Save();
                    return smsMaster.ObjectID;
                }
            }
            else
                return null;
        }

        [HttpPost]
        public Guid? SaveSMSToPersonnel(SendPersonnelSMSModel model)
        {
            if (model != null && model.SMSModel != null && model.SMSModel.Count > 0)
            {
                if (string.IsNullOrWhiteSpace(model.SMSText))
                    throw new TTException("Mesaj içeriği boş bırakılamaz.");

                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    SendSMSMaster smsMaster = CreateSendSMSMaster(objectContext, model.SMSText, false, model.SMSType);

                    foreach (SMSPersonnelGridViewModel smsItem in model.SMSModel)
                    {
                        SendSMSDetail sendSMSDetail = new SendSMSDetail(objectContext);
                        sendSMSDetail.SendSMSMaster = smsMaster;
                        sendSMSDetail.FirstName = smsItem.Name;
                        sendSMSDetail.SurName = smsItem.SurName;
                        sendSMSDetail.PhoneNumber = smsItem.Phone;
                        sendSMSDetail["RESUSER"] = smsItem.ObjectID;
                        sendSMSDetail.CurrentStateDefID = SendSMSDetail.States.New;
                    }

                    objectContext.Save();
                    return smsMaster.ObjectID;
                }
            }
            else
                return null;
        }

        [HttpGet]
        public void Exec(Guid masterSmsID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                SendSMSMaster masterSMS = objectContext.GetObject<SendSMSMaster>(masterSmsID);

                if (masterSMS.CurrentStateDefID == SendSMSMaster.States.New)
                {
                    masterSMS.CurrentStateDefID = SendSMSMaster.States.Started;
                    objectContext.Save();

                    foreach (var smsItem in masterSMS.SendSMSDetails.Where(x => x.CurrentStateDefID == SendSMSDetail.States.New || x.CurrentStateDefID == SendSMSDetail.States.NotSent))
                    {
                        masterSMS = objectContext.GetObject<SendSMSMaster>(masterSmsID);

                        if (masterSMS.CurrentStateDefID != SendSMSMaster.States.Cancelled)
                        {
                            var smsInstance = SmsManager.Instance;
                            if (smsInstance == null)
                                throw new TTException("SMS için gerekli sistem parametreleri eksik. Lütfen sistem yöneticisine bildiriniz.");
                            AtlasSMS sms = new AtlasSMS();
                            sms.Number = smsItem.PhoneNumber;
                            sms.Text = masterSMS.MessageText;
                            if (smsInstance.SendSms(sms))
                                smsItem.CurrentStateDefID = SendSMSDetail.States.Sent;
                            else
                                smsItem.CurrentStateDefID = SendSMSDetail.States.NotSent;
                        }
                        else
                            masterSMS.Cancelled = true;

                        objectContext.Save();
                    }

                    masterSMS = objectContext.GetObject<SendSMSMaster>(masterSmsID);

                    masterSMS.CurrentStateDefID = SendSMSMaster.States.Sent;
                    objectContext.Save();
                }
            }
        }

        [HttpGet]
        public bool CheckSMSMaster(Guid masterSmsID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                SendSMSMaster masterSMS = objectContext.GetObject<SendSMSMaster>(masterSmsID);
                if (masterSMS.CurrentStateDefID == SendSMSMaster.States.New || masterSMS.CurrentStateDefID == SendSMSMaster.States.Started)
                    return true;
                else
                    return false;
            }
        }

        [HttpGet]
        public void CancelSMS(Guid masterSmsID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                SendSMSMaster masterSMS = objectContext.GetObject<SendSMSMaster>(masterSmsID);
                masterSMS.CurrentStateDefID = SendSMSMaster.States.Cancelled;
                objectContext.Save();
            }
        }

        [HttpPost]
        public LoadResult GetSMSLog(DataSourceLoadOptions loadOptions)
        {
            SMSLogSearchModel searchModel = JsonConvert.DeserializeObject<SMSLogSearchModel>(loadOptions.Params.SMSLogSearchModel.ToString());

            LoadResult result = null;
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SendSMSDetail"].QueryDefs["GetSMSLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            string filter = " 1 = 1";
            string startDate = string.Empty;
            string endDate = string.Empty;

            if (searchModel.Status.HasValue)
            {
                if (searchModel.Status.Value)
                    filter += " AND CURRENTSTATEDEFID = '" + SendSMSDetail.States.Sent + "'";
                else
                    filter += " AND CURRENTSTATEDEFID IN ('" + SendSMSDetail.States.NotSent + "', '" + SendSMSDetail.States.HasNoPhonenumber + "', '" + SendSMSDetail.States.IncorrectPhoneNumber + "')";
            }

            if (searchModel.StartDate.HasValue)
                startDate = Convert.ToDateTime(searchModel.StartDate.Value.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
            else
                startDate = Convert.ToDateTime(DateTime.MinValue.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");

            if (searchModel.EndDate.HasValue)
                endDate = Convert.ToDateTime(searchModel.StartDate.Value.ToShortDateString() + " 23:59:59").ToString("yyyy-MM-dd HH:mm:ss");
            else
                endDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59:59").ToString("yyyy-MM-dd HH:mm:ss");

            filter += " AND LASTUPDATE BETWEEN TODATE('" + startDate + "') AND TODATE('" + endDate + "')";

            if (!string.IsNullOrEmpty(searchModel.PhoneNumber))
                filter += " AND PHONENUMBER = '" + searchModel.PhoneNumber + "'";

            if (!string.IsNullOrEmpty(searchModel.MessageText))
                filter += " AND LOWER(SENDSMSMASTER.MESSAGETEXT) LIKE '%" + searchModel.MessageText.ToLower(System.Globalization.CultureInfo.CurrentCulture) + "%'";

            if (searchModel.SMSType.HasValue)
                filter += " AND SendSMSMaster.SMSType =" + (int)searchModel.SMSType.Value;

            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, filter);
            }
            return result;
        }

        [HttpPost]
        public object GetListDefinition([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;

            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;
            string injectionFilter = loadOptions.Params.injectionFilter;
            using (var objectContext = new TTObjectContext(true))
            {
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs[definitionName.Trim()];
                TTList resultList = TTList.NewList(objectContext, listDef, string.Empty);


                result = DevexpressLoader.Load(objectContext, resultList, loadOptions, new Dictionary<string, object>(), searchText, injectionFilter, String.Empty);
            }
            return result.data;
        }

        [HttpPost]
        public object GetDiagnosisListDefinition([FromBody] DataSourceLoadOptions loadOptions, [FromQuery] string key)
        {
            LoadResult result = null;

            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;
            string injectionFilter = loadOptions.Params.injectionFilter;
            using (var objectContext = new TTObjectContext(true))
            {
                if (!string.IsNullOrEmpty(searchText))
                {
                    string _searchText = Common.GenerateSearchTextForShadowProperty(searchText);
                    searchText = "(NAME_SHADOW LIKE '%" + _searchText + "%')";
                    injectionFilter += " AND " + searchText;
                }

                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DiagnosisDefinition"].QueryDefs["GetDiagnosisDefinitions"];
                Dictionary<string, object> paramList = new Dictionary<string, object>();
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injectionFilter);
            }
            return result.data;
        }

        [HttpPost]
        public object GetCountyListDefinition([FromBody] DataSourceLoadOptions loadOptions, [FromQuery] string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var result = objectContext.QueryObjects<SKRSIlceKodlari>("ObjectID = '" + key + "'").ToList().Select(x => new SKRSIlceDTO { ObjectID = x.ObjectID, ADI = x.ADI, KODU = x.KODU, ILKODU = x.ILKODU }).FirstOrDefault();
                    return result;
                }
            }
            else
            {
                LoadResult result = null;

                string definitionName = loadOptions.Params.definitionName;
                string searchText = loadOptions.Params.searchText;
                string injectionFilter = loadOptions.Params.injectionFilter;
                using (var objectContext = new TTObjectContext(true))
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        searchText = "ADI like '%" + searchText.ToUpper() + "%'";
                        injectionFilter += " AND " + searchText;
                    }

                    TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSIlceKodlari"].QueryDefs["GetSKRSIlceKodlari"];
                    Dictionary<string, object> paramList = new Dictionary<string, object>();
                    result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injectionFilter);
                }
                return result.GetData<SKRSIlceKodlari.GetSKRSIlceKodlari_Class>().Select(x => new SKRSIlceDTO { ObjectID = x.ObjectID, ADI = x.ADI, KODU = x.KODU, ILKODU = x.ILKODU });
            }
        }

        [HttpPost]
        public object GetResources([FromBody] DataSourceLoadOptions loadOptions)
        {
            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;
            string injectionFilter = loadOptions.Params.injectionFilter;
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                var resPoliclinicList = from item in context.ResPoliclinic
                                        select new ResourceDTO
                                        {
                                            ObjectId = item.ResSection.Resource.ObjectId,
                                            Name = item.ResSection.Resource.Name,
                                            Name_Shadow = item.ResSection.Resource.Name_Shadow
                                        };

                var resClinicList = from item in context.ResClinic
                                    select new ResourceDTO
                                    {
                                        ObjectId = item.ResWard.ResSection.Resource.ObjectId,
                                        Name = item.ResWard.ResSection.Resource.Name,
                                        Name_Shadow = item.ResWard.ResSection.Resource.Name_Shadow
                                    };

                var resDepartmentList = from item in context.ResDepartment
                                        select new ResourceDTO
                                        {
                                            ObjectId = item.ResSection.Resource.ObjectId,
                                            Name = item.ResSection.Resource.Name,
                                            Name_Shadow = item.ResSection.Resource.Name_Shadow
                                        };

                var res = resDepartmentList.Union(resClinicList).Union(resPoliclinicList);

                if (loadOptions.Filter != null && loadOptions.Filter.Count > 0)
                {
                    var jarray = new JArray(loadOptions.Filter);

                    List<Guid> whereClauseList = new List<Guid>();
                    foreach (var item in jarray.Children<JArray>())
                    {
                        if (item[2] != null && item.GetType() == typeof(JArray))
                            whereClauseList.Add(new Guid(item[2].ToString()));
                    }

                    var query2 = from item in res
                                 where whereClauseList.Contains(item.ObjectId)
                                 select new { item.ObjectId, item.Name, item.Name_Shadow };

                    return query2.ToList();

                }
                else
                {
                    if (!string.IsNullOrEmpty(searchText))
                        res = res.Where(x => x.Name_Shadow.Contains(searchText.ToUpperInvariant()) || x.Name.Contains(searchText.ToLowerInvariant()) || x.Name.Contains(searchText.ToUpperInvariant()) || x.Name.Contains(searchText)).Skip(loadOptions.Skip).Take(loadOptions.Take);
                    else
                        res = res.Skip(loadOptions.Skip).Take(loadOptions.Take);
                }
                return res.ToList();
            }
        }

        public SendSMSMaster CreateSendSMSMaster(TTObjectContext objectContext, string SMSText, bool IsPatientSMS, SMSTypeEnum? smsType)
        {
            if (smsType.HasValue == false)
                throw new TTException("SMS Türü boş bırakılamaz.");

            SendSMSMaster smsMaster = new SendSMSMaster(objectContext);
            smsMaster.MessageText = SMSText;
            smsMaster.IsPatientSMS = true;
            smsMaster.SMSType = smsType;
            smsMaster.CurrentStateDefID = SendSMSMaster.States.New;
            smsMaster["RESUSER"] = Common.CurrentResource.ObjectID;
            return smsMaster;
        }
    }

    public class SMSLogSearchModel
    {
        public DateTime? StartDate;
        public DateTime? EndDate;
        public string PhoneNumber;
        public bool? Status;
        public string MessageText;
        public SMSTypeEnum? SMSType { get; set; }
    }
}
