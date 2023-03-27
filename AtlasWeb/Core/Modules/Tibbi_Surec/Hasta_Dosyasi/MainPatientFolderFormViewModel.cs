using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using System.ComponentModel;
using TTObjectClasses;
using Infrastructure.Filters;
using Core.Security;
using TTInstanceManagement;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class MainPatientFolderServiceController : Controller
    {
        [HttpGet]
        public SubEpisodeData[] GetSubEpisodes(Guid PatientID)
        {

            BindingList<SubEpisode.GetSubEpisodesForPatientFolder_Class> subepisodeList = SubEpisode.GetSubEpisodesForPatientFolder(PatientID);

            List<SubEpisodeData> resultList = new List<SubEpisodeData>();

            foreach (var item in subepisodeList)
            {
                SubEpisodeData subepisode = new SubEpisodeData();

                subepisode.ObjectID = (Guid)item.ObjectID;
                subepisode.OpeningDate = Convert.ToDateTime(((DateTime)item.OpeningDate).ToString("dd.MM.yyyy HH:mm")); ;
                if (item.ProtocolNo == null)
                    subepisode.ProtocolNo = "";
                else
                    subepisode.ProtocolNo = item.ProtocolNo.ToString();
                subepisode.SpecialityName = item.Specialityname;
                subepisode.DoctorName = item.Doctorname;
                subepisode.PatientStatus = Common.GetDisplayTextOfEnumValue("SubEpisodeStatusEnum", Convert.ToInt32(item.PatientStatus.Value));
                if (item.InpatientStatus != null)
                    subepisode.PatientStatus = subepisode.PatientStatus + "-" + Common.GetDisplayTextOfEnumValue("InpatientStatusEnum", Convert.ToInt32(item.InpatientStatus.Value));
                subepisode.AdmissionType = item.Admissiontype.ToString();
                if (item.ClosingDate == null)
                    subepisode.ClosingDate = null;
                else
                    subepisode.ClosingDate = Convert.ToDateTime(((DateTime)item.ClosingDate).ToString("dd.MM.yyyy HH:mm"));


                resultList.Add(subepisode);
            }

            return resultList.ToArray();
        }

        [HttpGet]
        public EpisodeActionData[] GetEpisodeActionsandSubActionFlowables(Guid SubEpisodeID)
        {
            List<EpisodeActionData> resultList = new List<EpisodeActionData>();

            TTObjectContext objectContext = new TTObjectContext(true);

            var episodeActionList = EpisodeAction.GetBySubEpisode(objectContext, SubEpisodeID, "And OBJECTDEFNAME<>'PHYSIOTHERAPYORDER'");
            foreach (var episodeAction in episodeActionList)
            {
                if (episodeAction.IsAttributeExists(typeof(NotShownOnPatientFolderAttribute)) != true)
                {
                    EpisodeActionData episodeActionData = new EpisodeActionData();
                    episodeActionData.ObjectID = (Guid)episodeAction.ObjectID;
                    episodeActionData.ObjectDefName = episodeAction.ObjectDef.Name;
                    episodeActionData.FromResourceName = episodeAction.FromResource.Name;
                    episodeActionData.MasterResourceName = episodeAction.MasterResource.Name;
                    if (episodeAction.RequestDate != null)
                        episodeActionData.ActionDate = Convert.ToDateTime(episodeAction.RequestDate);
                    else if (episodeAction.ActionDate != null)
                        episodeActionData.ActionDate = Convert.ToDateTime(episodeAction.ActionDate);
                    else
                        episodeActionData.ActionDate = null;
                    episodeActionData.ObjectName = episodeAction.ObjectDef.ApplicationName;
                    episodeActionData.State = episodeAction.CurrentStateDef.DisplayText;
                    if (episodeAction.ProcedureDoctor == null)
                        episodeActionData.DoctorName = "";
                    else
                        episodeActionData.DoctorName = episodeAction.ProcedureDoctor.Name;
                    if (episodeAction.DescriptionForWorkList == null)
                        episodeActionData.Description = "";
                    else
                        episodeActionData.Description = episodeAction.DescriptionForWorkList;

                    episodeActionData.IsOldAction = (episodeAction.IsOldAction != null && episodeAction.IsOldAction == true) ? true : false;

                    resultList.Add(episodeActionData);
                }

            }
            //SubactionProcedureFlowables
            var subactionList = SubactionProcedureFlowable.GetBySubEpisode(objectContext, SubEpisodeID, "AND OBJECTDEFNAME <> 'PHYSIOTHERAPYORDERDETAIL'");
            foreach (var subactionProcedureFlowable in subactionList)
            {
                if (subactionProcedureFlowable.IsAttributeExists(typeof(NotShownOnPatientFolderAttribute)) != true)
                {
                    EpisodeActionData episodeActionData = new EpisodeActionData();
                    episodeActionData.ObjectID = (Guid)subactionProcedureFlowable.ObjectID;
                    episodeActionData.ObjectDefName = subactionProcedureFlowable.ObjectDef.Name;
                    if (subactionProcedureFlowable.FromResource != null)
                        episodeActionData.FromResourceName = subactionProcedureFlowable.FromResource.Name;
                    else
                        episodeActionData.FromResourceName = "";
                    if (subactionProcedureFlowable.MasterResource != null)
                        episodeActionData.MasterResourceName = subactionProcedureFlowable.MasterResource.Name;
                    else
                        episodeActionData.MasterResourceName = "";

                    if (subactionProcedureFlowable.CreationDate != null)
                        episodeActionData.ActionDate = Convert.ToDateTime(subactionProcedureFlowable.CreationDate);
                    else if (subactionProcedureFlowable.ActionDate != null)
                        episodeActionData.ActionDate = Convert.ToDateTime(subactionProcedureFlowable.ActionDate);
                    else
                        episodeActionData.ActionDate = null;
                    episodeActionData.ObjectName = subactionProcedureFlowable.ObjectDef.ApplicationName;
                    episodeActionData.State = subactionProcedureFlowable.CurrentStateDef.DisplayText;
                    if (subactionProcedureFlowable.ProcedureDoctor != null)
                        episodeActionData.DoctorName = subactionProcedureFlowable.ProcedureDoctor.Name;
                    if (subactionProcedureFlowable.EpisodeAction != null && subactionProcedureFlowable.EpisodeAction.ProcedureDoctor != null)
                        episodeActionData.DoctorName = subactionProcedureFlowable.EpisodeAction.ProcedureDoctor.Name;
                    else
                        episodeActionData.DoctorName = "";

                    if (subactionProcedureFlowable.DescriptionForWorkList == null)
                        episodeActionData.Description = "";
                    else
                        episodeActionData.Description = subactionProcedureFlowable.DescriptionForWorkList;

                    episodeActionData.IsOldAction = (subactionProcedureFlowable.IsOldAction != null && subactionProcedureFlowable.IsOldAction == true) ? true : false;

                    resultList.Add(episodeActionData);
                }

            }

            return resultList.OrderByDescending(dr => dr.ActionDate).ToArray();

        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public EpisodeActionData[] CancelEpisodeActionOrSPFlowableByObjectId(string ObjectId)
        {
            Guid subEpisodeId;
            TTObjectContext objectContext = new TTObjectContext(false);
            var episodeActionList = EpisodeAction.GetEpisodeActionByID(objectContext, ObjectId);

            if (episodeActionList.Count > 0)
            {
                var episodeAction = episodeActionList[0];
                subEpisodeId = episodeAction.SubEpisode.ObjectID;
                ((ITTObject)episodeAction).Cancel();
                objectContext.Save();

            }
            else
            {
                var subactionProcedureFlowable = objectContext.GetObject(new Guid(ObjectId), typeof(SubactionProcedureFlowable)) as SubactionProcedureFlowable;
                subEpisodeId = subactionProcedureFlowable.EpisodeAction.SubEpisode.ObjectID;
                ((ITTObject)subactionProcedureFlowable).Cancel();
                objectContext.Save();
            }
            if (subEpisodeId != null)
                return this.GetEpisodeActionsandSubActionFlowables(subEpisodeId);
            else
                return null;

        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public EpisodeActionData[] UndoLastTransitionEAorSPFlowableByObjectId(string ObjectId)
        {
            Guid subEpisodeId;
            TTObjectContext objectContext = new TTObjectContext(false);
            var episodeActionList = EpisodeAction.GetEpisodeActionByID(objectContext, ObjectId);
            if (episodeActionList.Count > 0)
            {
                var episodeAction = episodeActionList[0];
                subEpisodeId = episodeAction.SubEpisode.ObjectID;
                ((ITTObject)episodeAction).UndoLastTransition();
                objectContext.Save();
            }
            else
            {
                var subactionProcedureFlowable = objectContext.GetObject(new Guid(ObjectId), typeof(SubactionProcedureFlowable)) as SubactionProcedureFlowable;
                subEpisodeId = subactionProcedureFlowable.EpisodeAction.SubEpisode.ObjectID;
                ((ITTObject)subactionProcedureFlowable).UndoLastTransition();
                objectContext.Save();
            }
            if (subEpisodeId != null)
                return this.GetEpisodeActionsandSubActionFlowables(subEpisodeId);
            else
                return null;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void UndoLastTransitionDruOrderDetailByObjectId(string ObjectId)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            DrugOrderDetail drugOrderDetail = objectContext.GetObject<DrugOrderDetail>(new Guid(ObjectId));
            if (drugOrderDetail != null)
            {
                if (drugOrderDetail.PrevState.StateDefID != DrugOrderDetail.States.Apply)
                {
                    /*
                    if (DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material) == false && drugOrderDetail.Eligible == true)
                    {
                        List<DrugOrderDetail> anotherDrugOrderDetail = drugOrderDetail.DrugOrder.DrugOrderDetails.Where(x => x.ObjectID != drugOrderDetail.ObjectID).ToList();
                        if(anotherDrugOrderDetail.Count > 0)
                        {
                            if (anotherDrugOrderDetail.Select(x => x.CurrentStateDef.Status != TTDefinitionManagement.StateStatusEnum.Uncompleted).Count() == 0)
                                throw new Exception("Bu uygulama fatura ya yansıdığı için geri alınamaz");
                        }
                        else
                            throw new Exception("Bu uygulama fatura ya yansıdığı için geri alınamaz");

                    }*/
                    drugOrderDetail.CancelMyAccountTransactions();

                    ((ITTObject)drugOrderDetail).UndoLastTransition();
                    var drugOrderTrx = objectContext.QueryObjects("DRUGORDERTRANSACTIONDETAIL", " DRUGORDERDETAIL = " + TTConnectionManager.ConnectionManager.GuidToString(drugOrderDetail.ObjectID));
                    foreach (DrugOrderTransactionDetail dx in drugOrderTrx)
                    {
                        if (dx.CurrentStateDefID != DrugOrderTransactionDetail.States.Cancel)
                            dx.CurrentStateDefID = DrugOrderTransactionDetail.States.Cancel;
                    }



                    objectContext.Save();

                }
                else
                    throw new Exception("Uygulanmış işlemin iptale geçişi yoktur.");
                objectContext.Dispose();
            }
        }

        private string getResourceName(Resource resource)
        {
            if (resource.Qref != null)
                return resource.Qref.ToString();
            return resource.Name.ToString();
        }

        [HttpGet]
        public SubEpisodeData[] GetSubEpisodeByProtocolNo(string ProtocolNo)
        {

            BindingList<SubEpisode.GetSubepisodeByProtocolNoForPatientFolder_Class> subepisodeList = SubEpisode.GetSubepisodeByProtocolNoForPatientFolder(ProtocolNo);

            List<SubEpisodeData> resultList = new List<SubEpisodeData>();

            foreach (var item in subepisodeList)
            {
                SubEpisodeData subepisode = new SubEpisodeData();

                subepisode.ObjectID = (Guid)item.ObjectID;
                subepisode.OpeningDate = Convert.ToDateTime(((DateTime)item.OpeningDate).ToString("dd.MM.yyyy HH:mm")); ;
                if (item.ProtocolNo == null)
                    subepisode.ProtocolNo = "";
                else
                    subepisode.ProtocolNo = item.ProtocolNo.ToString();
                subepisode.SpecialityName = item.Specialityname;
                subepisode.DoctorName = item.Doctorname;
                subepisode.PatientStatus = Common.GetDisplayTextOfEnumValue("SubEpisodeStatusEnum", Convert.ToInt32(item.PatientStatus.Value));
                if (item.InpatientStatus != null)
                    subepisode.PatientStatus = subepisode.PatientStatus + "-" + Common.GetDisplayTextOfEnumValue("InpatientStatusEnum", Convert.ToInt32(item.InpatientStatus.Value));
                subepisode.AdmissionType = item.Admissiontype.ToString();
                if (item.ClosingDate == null)
                    subepisode.ClosingDate = null;
                else
                    subepisode.ClosingDate = Convert.ToDateTime(((DateTime)item.ClosingDate).ToString("dd.MM.yyyy HH:mm"));


                resultList.Add(subepisode);
            }

            return resultList.ToArray();
        }
    }
}

namespace Core.Models
{
    public class MainPatientFolderFormViewModel
    {
        public SubEpisodeData[] SubEpisodeList
        {
            get;
            set;
        }
        public EpisodeActionData[] EpisodeActionList
        {
            get;
            set;
        }
    }

    public class SubEpisodeData
    {
        public Guid ObjectID
        {
            get;
            set;
        }
        public DateTime? OpeningDate
        {
            get;
            set;
        }
        public string ProtocolNo
        {
            get;
            set;
        }
        public string SpecialityName
        {
            get;
            set;
        }
        public string DoctorName
        {
            get;
            set;
        }
        public string PatientStatus
        {
            get;
            set;
        }
        public string AdmissionType
        {
            get;
            set;
        }
        public DateTime? ClosingDate
        {
            get;
            set;
        }
    }

    public class EpisodeActionData
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string ObjectDefName
        {
            get;
            set;
        }

        public string FromResourceName
        {
            get;
            set;
        }
        public string MasterResourceName
        {
            get;
            set;
        }
        public DateTime? ActionDate
        {
            get;
            set;
        }
        public string ObjectName
        {
            get;
            set;
        }
        public string State
        {
            get;
            set;
        }
        public string DoctorName
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public bool IsOldAction { get; set; }
    }
}
