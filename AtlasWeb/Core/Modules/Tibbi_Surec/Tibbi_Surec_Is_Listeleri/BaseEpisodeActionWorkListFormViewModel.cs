using Microsoft.AspNetCore.Mvc;
using System;
using Infrastructure.Filters;
using System.Collections.Generic;
using TTObjectClasses;
using TTStorageManager.Security;
using TTInstanceManagement;
using Core.Models;
using Core.Security;
using System.ComponentModel;
using TTUtils;
using System.Linq;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class BaseEpisodeActionWorkListServiceController : Controller
    {
        // İş Listesi Liseleme Methodları

        public virtual int WorkListRightDefID(string objectType) // EpisodeActionPermissionDefinition daki Worklist Rolünün  RightDefID'si
        {
            return 1001;
        }

        public bool HasWorkListWorkListRight(TTObjectContext objectContext, TTObject ttobject)
        {
            return TTUser.CurrentUser.HasRight(ttobject.CurrentStateDef.FormDef, ttobject, WorkListRightDefID(ttobject.ObjectDef.Name));
        }

        public bool HasWorkListWorkListRight(TTObjectContext objectContext, Guid objectID,string objectType)
        {
            if (string.IsNullOrEmpty(objectType))
                objectType = "EPISODEACTION";

            TTObject action = (TTObject)objectContext.GetObject(objectID, objectType);
            return HasWorkListWorkListRight(objectContext, action);
        }

        public bool HasWorkListWorkListRight(TTObjectContext objectContext, Guid episodeActionobjectID)
        {
            return HasWorkListWorkListRight(objectContext, episodeActionobjectID, "EPISODEACTION");
        }

        public string GetDateAsString(DateTime? dateTime)
        {
            if (dateTime != null)
                return GetDateAsString(Convert.ToDateTime(dateTime));
            return "";
        }
        public string GetDateAsString(DateTime dateTime)
        {
            return "TODATE('" + Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd HH:mm:ss") + "')";
        }

        public void setWorkListIkonPropertyies(string PriorityStatus,Patient patient, BaseEpisodeActionWorkListItem item)
        {
            //item.isPregnant = false;
            //item.isOld = false;
            //item.isVetera = false;
            //item.isEmergency = false;
            //item.isDisabled = false;
            //item.isYoung = false;
            if (PriorityStatus != null)  //  Queryden this:SubEpisode:PatientAdmission:PriorityStatus:Code as PriorityStatus çeklidi ise  direk verilebilir 
            {
                if (PriorityStatus == "H")//Hamileler
                    item.isPregnant = true;
                if (PriorityStatus == "Y")//65 Yaş Üstü Yaşlılar
                    item.isOld = true;
                if (PriorityStatus == "G")//Harp ve vazife şehitlerinin dul ve yetimleri ile malül ve gaziler
                    item.isVetera = true;
                if (PriorityStatus == "A")//Acil Vakalar
                    item.isEmergency = true;
                if (PriorityStatus == "E")//Engelliler
                    item.isDisabled = true;
                if (PriorityStatus == "C")//7 Yaşından Küçük Çocuklar
                    item.isYoung = true;
            }

            if (patient != null)
            {
                if (patient.ActivePregnancy != null || (patient.MedicalInformation != null && patient.MedicalInformation.Pregnancy.HasValue && patient.MedicalInformation.Pregnancy.Value == true))
                    item.isPregnant = true;
                if (patient.Age.HasValue)
                {
                    if (patient.Age.Value > 65)
                        item.isOld = true;
                    if (patient.Age.Value < 7)
                        item.isYoung = true;
                }
                if (patient.hasMedicalInformation())
                    item.hasMedicalInformation = true;

                if (patient.IsPatientAllergic())
                    item.RowColor = Common.kirmiziRenk;
            }
        }


        //Fonksiyon hastanın önemli tıbbi bilgisi varsa yalnızca ilgili kolonu renklendirebilmek için tekrar oluşturuldu.
        public void editedSetWorkListIkonProperties(string PriorityStatus, Patient patient, BaseEpisodeActionWorkListItem item)
        {
            //item.isPregnant = false;
            //item.isOld = false;
            //item.isVetera = false;
            //item.isEmergency = false;
            //item.isDisabled = false;
            //item.isYoung = false;
            if (PriorityStatus != null)  //  Queryden this:SubEpisode:PatientAdmission:PriorityStatus:Code as PriorityStatus çeklidi ise  direk verilebilir 
            {
                if (PriorityStatus == "H")//Hamileler
                    item.isPregnant = true;
                if (PriorityStatus == "Y")//65 Yaş Üstü Yaşlılar
                    item.isOld = true;
                if (PriorityStatus == "G")//Harp ve vazife şehitlerinin dul ve yetimleri ile malül ve gaziler
                    item.isVetera = true;
                if (PriorityStatus == "A")//Acil Vakalar
                    item.isEmergency = true;
                if (PriorityStatus == "E")//Engelliler
                    item.isDisabled = true;
                if (PriorityStatus == "C")//7 Yaşından Küçük Çocuklar
                    item.isYoung = true;
            }

            if (patient != null)
            {
                if (patient.ActivePregnancy != null || (patient.MedicalInformation != null && patient.MedicalInformation.Pregnancy.HasValue && patient.MedicalInformation.Pregnancy.Value == true))
                    item.isPregnant = true;
                if (patient.Age.HasValue)
                {
                    if (patient.Age.Value > 65)
                        item.isOld = true;
                    if (patient.Age.Value < 7)
                        item.isYoung = true;
                }
                if (patient.hasMedicalInformation())
                    item.hasMedicalInformation = true;

                if (patient.MedicalInformation != null )
                {
                    if (patient.MedicalInformation.MedicalInfoAllergies != null)
                    {
                        if (patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies.Count() > 0)
                        {
                            item.isPatientDrugAllergic = true;
                        }

                        if (patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies.Count() > 0)
                        {
                            item.isPatientFoodAllergic = true;
                        }

                        if (patient.MedicalInformation.HasAllergy == VarYokGarantiEnum.V && item.isPatientDrugAllergic != true && item.isPatientFoodAllergic != true)
                        {
                            item.isPatientOtherAllergic = true;
                        }

                    }

                    if (patient.MedicalInformation.Pandemic == true)
                    {
                        item.Pandemic = true;
                    }

                }
            }
        }



        // Kullanıcı Bazlı Kolon kaydetme 

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void SaveUserBasedGridColumnCustomization(List<GridCustomizationModel> sgcm)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    foreach (var oneGrid in sgcm)
                    {
                        string ColumnList = "1";
                        foreach (var column in oneGrid.ColumnNameList)
                        {
                            ColumnList += "," + column;
                        }

                        ColumnList = ColumnList.Replace("1,", "");
                        UserBasedGridColumnOption ubgco = null;
                        BindingList<UserBasedGridColumnOption> optionList = UserBasedGridColumnOption.GetGridColumnOption(objectContext, Common.CurrentResource.ObjectID, oneGrid.GridName, oneGrid.PageName);
                        if (optionList.Count == 0)
                        {
                            ubgco = new UserBasedGridColumnOption(objectContext);
                            ubgco.ColumnList = ColumnList;
                            ubgco.GridName = oneGrid.GridName;
                            ubgco.PageName = oneGrid.PageName;
                            ubgco.ResUser = Common.CurrentResource;
                        }
                        else if (optionList.Count == 1)
                        {
                            optionList[0].ColumnList = ColumnList;
                        }
                        else
                        {
                            int i = 0;
                            foreach (UserBasedGridColumnOption item in optionList)
                            {
                                if (i == 0)
                                    item.ColumnList = ColumnList;
                                else
                                {
                                    ITTObject tempItem = (ITTObject)item;
                                    tempItem.Delete();
                                }

                                i++;
                            }
                        }
                    }

                    objectContext.Save();
                }
                catch
                {
                    throw new TTException(TTUtils.CultureService.GetText("M26350", "Kullanıcı ayarları kayıt edilirken bir hata oluştu."));
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<string> GetColumnAndOrder([FromQuery] string gridName, [FromQuery] string pageName)
        {
            List<string> result = new List<string>();
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<UserBasedGridColumnOption> optionList = UserBasedGridColumnOption.GetGridColumnOption(objectContext, Common.CurrentResource.ObjectID, gridName, pageName);
                if (optionList.Count > 0)
                {
                    if (optionList[0].ColumnList == null)
                        return result;
                    result = optionList[0].ColumnList.Split(',').ToList();
                }
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<FollowingPatientList> GetTrackingPatientList()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<FollowingPatients> highRiskyDefList = FollowingPatients.GetTrackingPatientsByFilter(objectContext, " WHERE Follower = '" + TTUser.CurrentUser.UserObject.ObjectID + "' AND CURRENTSTATEDEFID='" + FollowingPatients.States.OnTracking + "'").ToList();

                List<FollowingPatientList> followingPatientList = new List<FollowingPatientList>();

                foreach (FollowingPatients item in highRiskyDefList)
                {
                    FollowingPatientList trackingInfo = new FollowingPatientList();

                    SubEpisode.GetSubepisodesForENabiz_Class subepisode = SubEpisode.GetSubepisodesForENabiz(" AND OBJECTID ='" + item.Subepisode+"'").FirstOrDefault();

                    trackingInfo.ObjectID = item.ObjectID;
                    trackingInfo.Name = subepisode.Name + " " + subepisode.Surname;
                    trackingInfo.ProtocolNO = subepisode.ProtocolNo;
                    trackingInfo.UniqueRefNo = subepisode.UniqueRefNo != null ? subepisode.UniqueRefNo.ToString() : "";
                    trackingInfo.StartDate = item.StartDate;
                    trackingInfo.EndDate = item.EndDate;
                    trackingInfo.CurrentState = item.CurrentStateDef.DisplayText;
                    trackingInfo.Type = Common.GetEnumValueDefOfEnumValue(item.FollowingType).DisplayText;
                    trackingInfo.PatientID = item.Paitent.ToString();

                    followingPatientList.Add(trackingInfo);

                }
                return followingPatientList;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool StopTrackingPatient(Guid ObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                FollowingPatients action = (FollowingPatients)objectContext.GetObject(ObjectID, "FOLLOWINGPATIENTS");
                action.CurrentStateDefID = FollowingPatients.States.StopTracking;

                try
                {
                    objectContext.Save();
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
        }
            

    }
}

namespace Core.Models
{
    public class BaseEpisodeActionWorkListFormViewModel
    {
        public int maxWorklistItemCount
        {
            get;
            set;
        }

        public int timerPeriod
        {
            get
            {
               var tp =  TTObjectClasses.SystemParameter.GetParameterValue("EPISODEACTIONWORKLISTTIMERPEROD", "60");
                if (int.TryParse(tp, out int tpInt))
                    return tpInt;
                else
                    return 60;
            }
            set { }
        }

        public bool autoRefreshWorkList
        {
            get
            {
                return TTObjectClasses.SystemParameter.GetParameterValue("EPISODEACTIONWORKLISTAUTOREFRESH", "FALSE") == "TRUE";
            }
        }

        public List<FollowingPatientList> TrackingPatientsList= new List<FollowingPatientList>();
    }       

    [Serializable]
    public class BaseEpisodeActionWorkListSearchCriteria // İŞlistesi Sorgu kriterlerine ait base model
    {
        public DateTime? WorkListStartDate
        {
            get;
            set;
        }

        public DateTime? WorkListEndDate
        {
            get;
            set;
        }

        public string PatientObjectID
        {
            get;
            set;
        }

    }


    public class BaseEpisodeActionWorkListItem // İşListesi Gridinede bulunacak kolonlara ait  base model
    {
        public string ObjectDefName
        {
            get;
            set;
        }

        public string ObjectDefID
        {
            get;
            set;
        }

        public Guid ObjectID
        {
            get;
            set;
        }
        public Object CompComponetOpeningInputParam
        {
            get;
            set;
        }

        public bool isEmergency
        {
            get;
            set;
        }
        public bool isPregnant
        {
            get;
            set;
        }

        public bool isYoung
        {
            get;
            set;
        }

        public bool isOld
        {
            get;
            set;
        }

        public bool isVetera
        {
            get;
            set;
        }

        public bool isDisabled
        {
            get;
            set;
        }

        public bool hasMedicalInformation
        {
            get;
            set;
        }

        public string RowColor
        {
            get;
            set;
        }

        public string MedicalInformation
        {
            get;
            set;
        }

        public bool isPatientDrugAllergic
        {
            get;
            set;
        }

        public bool isPatientFoodAllergic
        {
            get;
            set;
        }

        public bool isPatientOtherAllergic
        {
            get;
            set;
        }

        public string PatientCallStatus { get; set; }
        public string TriageColor { get; set; }

        public bool Pandemic { get; set; }
    }

    public class GridCustomizationModel
    {
        public string PageName
        {
            get;
            set;
        }

        public string GridName
        {
            get;
            set;
        }

        public List<string> ColumnNameList
        {
            get;
            set;
        }

        public GridCustomizationModel()
        {
            this.ColumnNameList = new List<string>();
        }
    }

    public class FollowingPatientList
    {
        public Guid ObjectID { get; set; }
        public string PatientID { get; set; }
        public string Name { get; set; }
        public string ProtocolNO { get; set; }
        public string UniqueRefNo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CurrentState { get; set; }
        public string Type { get; set; }
    }
}