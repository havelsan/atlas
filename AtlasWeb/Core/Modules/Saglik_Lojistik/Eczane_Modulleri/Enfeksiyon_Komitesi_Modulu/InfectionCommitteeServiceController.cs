//$FCCB1812
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using static Core.Controllers.DrugOrderIntroductionServiceController;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class InfectionCommitteeServiceController : Controller
    {
        [HttpPost]
        public List<InpatientHasDrugList> GetInpatientHasDrugList(PatientInputDTO input)
        {
            using (var context = new TTObjectContext(false))
            {
                List<InpatientHasDrugList> InpatientHasDrugList = new List<InpatientHasDrugList>();
                string injectionSqlDrugOrder = string.Empty;
                string injectionSqlTreatmentMaterial = string.Empty;
                if (input.all == false)
                {
                    injectionSqlDrugOrder = " WHERE DRUGORDERINTRODUCTION.SUBEPISODE = '" + input.SubepisodeObjectId + "'";
                    injectionSqlTreatmentMaterial = " AND EPISODEACTION.SUBEPISODE= '" + input.SubepisodeObjectId + "'";
                }
                else
                {
                    Episode episode = (Episode)context.GetObject(new Guid(input.EpisodeObjectID), typeof(Episode));
                    injectionSqlDrugOrder = " WHERE DRUGORDERINTRODUCTION.EPISODE.PATIENT = " + TTConnectionManager.ConnectionManager.GuidToString(episode.Patient.ObjectID) + " AND DRUGORDERINTRODUCTION.SUBEPISODE <> '" + input.SubepisodeObjectId + "'";
                    injectionSqlTreatmentMaterial = " AND EPISODEACTION.EPISODE.PATIENT= " + TTConnectionManager.ConnectionManager.GuidToString(episode.Patient.ObjectID) + " AND EPISODEACTION.SUBEPISODE <> '" + input.SubepisodeObjectId + "'";
                }

                BindingList<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class> drugList = DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient(injectionSqlDrugOrder);
                List<InpatientHasDrugList> createGridView = this.CreateDrugOrderIntroductionGridViewModel(drugList, context, input.SubepisodeObjectId);
                BindingList<BaseTreatmentMaterial.GetTreatmentMatByParameter_Class> baseTreatmentList = BaseTreatmentMaterial.GetTreatmentMatByParameter(injectionSqlTreatmentMaterial);
                
                
                foreach (BaseTreatmentMaterial.GetTreatmentMatByParameter_Class item in baseTreatmentList)
                {
                    InpatientHasDrugList baseMat = new InpatientHasDrugList();
                    baseMat.Amount = item.Amount.ToString();
                    baseMat.DoctorName = item.Doctor;
                    baseMat.PlannedEndTime = item.CreationDate.Value;
                    baseMat.PlannedStartTime = item.CreationDate.Value;
                    baseMat.OutStatus = "Cep Depo";
                    baseMat.DrugName = item.Drugname;
                    baseMat.ClinikName = item.Storename;
                    baseMat.EhuStatus = null;
                    baseMat.TreatmentType = null;
                    baseMat.DoseAmount = null;
                    baseMat.Day = 1;
                    if (item.Materialobjectdefid == new Guid("65a2337c-bc3c-4c6b-9575-ad47fa7a9a89"))
                        baseMat.MaterialType = "�la�";
                    else
                        baseMat.MaterialType = "Sarf";

                    createGridView.Add(baseMat);
                }

                return createGridView;
            }
        }


        public List<InpatientHasDrugList> CreateDrugOrderIntroductionGridViewModel(BindingList<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class> details, TTObjectContext objectContext, string SubEpisodeObjectId)
        {
            SubEpisode subEpisode = (SubEpisode)objectContext.GetObject(new Guid(SubEpisodeObjectId), typeof(SubEpisode));

            List<InpatientHasDrugList> output = new List<InpatientHasDrugList>();

            Dictionary<Guid, List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class>> parentDrugOrderDict = new Dictionary<Guid, List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class>>();

            foreach (DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class detail in details)
            {
                if (detail.ParentDrugOrder == null)
                {
                    if (parentDrugOrderDict.ContainsKey(detail.Drugorderid.Value))
                    {
                        parentDrugOrderDict[detail.Drugorderid.Value].Add(detail);
                    }
                    else
                    {
                        List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class> detailList = new List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class>();
                        detailList.Add(detail);
                        parentDrugOrderDict.Add(detail.Drugorderid.Value, detailList);
                    }
                }
                else
                {
                    if (parentDrugOrderDict.ContainsKey(detail.ParentDrugOrder.Value))
                    {
                        parentDrugOrderDict[detail.ParentDrugOrder.Value].Add(detail);
                    }
                    else
                    {
                        List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class> detailList = new List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class>();
                        detailList.Add(detail);
                        parentDrugOrderDict.Add(detail.ParentDrugOrder.Value, detailList);
                    }
                }
            }

            foreach (KeyValuePair<Guid, List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class>> detailDic in parentDrugOrderDict)
            {
                if (detailDic.Value.Count == 1)
                {
                    foreach (var item in detailDic.Value)
                    {
                        InpatientHasDrugList inpatientHasDrug = new InpatientHasDrugList();

                        inpatientHasDrug.DoctorName = item.Doctor;
                        inpatientHasDrug.ClinikName = item.Clinik;
                        inpatientHasDrug.OutStatus = "Eczane";
                        inpatientHasDrug.MaterialType = "�la�";
                        inpatientHasDrug.Dose = item.Hospitaltimeschedulename;

                        if (item.CaseOfNeed.HasValue)
                            inpatientHasDrug.CaseOfNeed = item.CaseOfNeed.Value;
                        else
                            inpatientHasDrug.CaseOfNeed = false;

                        inpatientHasDrug.Day = item.Drugorderday.Value;
                        inpatientHasDrug.DoseAmount = item.DoseAmount.Value;
                        if (item.DrugUsageType != null)
                            inpatientHasDrug.TreatmentType = item.DrugUsageType.Value;

                        if (item.IsImmediate.HasValue)
                            inpatientHasDrug.IsImmediately = item.IsImmediate.Value;
                        else
                            inpatientHasDrug.IsImmediately = false;

                        Material material = (Material)objectContext.GetObject(item.Material.Value, typeof(Material));
                        if (material is DrugDefinition)
                        {
                            if (((DrugDefinition)material).AntibioticType != null)
                                inpatientHasDrug.EhuStatus = ((DrugDefinition)material).AntibioticType.Value;
                        }
                        inpatientHasDrug.DrugName = material.Name;

                        if (item.PatientOwnDrug.Value)
                            inpatientHasDrug.PatientOwnDrug = item.PatientOwnDrug.Value;
                        else
                            inpatientHasDrug.PatientOwnDrug = false;

                        if (inpatientHasDrug.PatientOwnDrug)
                        {
                            BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> ownDrugRestDose = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(subEpisode.Episode.ObjectID, new Guid(material.ObjectID.ToString()));
                            int restamount = 0;
                            foreach (PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class rest in ownDrugRestDose)
                            {
                                restamount = restamount + Convert.ToInt16(rest.Restamount);
                            }
                        }

                        inpatientHasDrug.PlannedStartTime = item.Orderdate.Value;
                        inpatientHasDrug.Desciption = item.UsageNote;

                        List<DrugOrderDetail> drugOrderDetails = objectContext.QueryObjects<DrugOrderDetail>("DRUGORDER = " + TTConnectionManager.ConnectionManager.GuidToString(item.Drugorderid.Value)).ToList();

                        inpatientHasDrug.Amount = (drugOrderDetails.Count * item.DoseAmount * item.Drugorderday).ToString();
                        if (drugOrderDetails.Count > 0)
                        {

                            drugOrderDetails = drugOrderDetails.OrderBy(x => x.OrderPlannedDate).ToList();
                            inpatientHasDrug.PlannedEndTime = drugOrderDetails[drugOrderDetails.Count - 1].OrderPlannedDate.Value;
                            inpatientHasDrug.PlannedStartTime = drugOrderDetails[drugOrderDetails.Count - 1].DrugOrder.CreationDate.Value;
                            inpatientHasDrug.DoctorName = drugOrderDetails[0].DrugOrder.RequestedByUser.Name;
                        }
                        output.Add(inpatientHasDrug);
                    }
                }
                else
                {
                    InpatientHasDrugList inpatientHasDrug = new InpatientHasDrugList();
                    List<DrugOrderIntroductionDet.GetDrugOrderGridViewModelByPatient_Class> sortedList = detailDic.Value.OrderBy(x => x.Orderdate).ThenBy(x => x.CreationDate).ToList();
                    DrugOrder parentDrugOrder = (DrugOrder)objectContext.GetObject(detailDic.Key, typeof(DrugOrder));

                    inpatientHasDrug.DoctorName = parentDrugOrder.RequestedByUser.Name;
                    inpatientHasDrug.ClinikName = parentDrugOrder.MasterResource.Name;
                    inpatientHasDrug.OutStatus = "Eczane";
                    inpatientHasDrug.Dose = parentDrugOrder.HospitalTimeSchedule.Name;


                    if (parentDrugOrder.CaseOfNeed.HasValue)
                        inpatientHasDrug.CaseOfNeed = parentDrugOrder.CaseOfNeed.Value;
                    else
                        inpatientHasDrug.CaseOfNeed = false;

                    inpatientHasDrug.Day = sortedList[sortedList.Count - 1].Drugorderday.Value;
                    inpatientHasDrug.DoseAmount = parentDrugOrder.DoseAmount.Value;
                    if (parentDrugOrder.DrugUsageType != null)
                        inpatientHasDrug.TreatmentType = parentDrugOrder.DrugUsageType.Value;

                    if (parentDrugOrder.IsImmediate.HasValue)
                        inpatientHasDrug.IsImmediately = parentDrugOrder.IsImmediate.Value;
                    else
                        inpatientHasDrug.IsImmediately = false;

                    Material material = (Material)objectContext.GetObject(parentDrugOrder.Material.ObjectID, typeof(Material));
                    if (material is DrugDefinition)
                    {
                        if (((DrugDefinition)material).AntibioticType != null)
                            inpatientHasDrug.EhuStatus = ((DrugDefinition)material).AntibioticType.Value;
                    }
                    inpatientHasDrug.DrugName = material.Name;
                    inpatientHasDrug.PatientOwnDrug = sortedList[sortedList.Count - 1].PatientOwnDrug.Value;
                    inpatientHasDrug.PlannedStartTime = parentDrugOrder.PlannedStartTime.Value;
                    inpatientHasDrug.Desciption = sortedList[sortedList.Count - 1].UsageNote;

                    if (inpatientHasDrug.PatientOwnDrug)
                    {
                        BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> ownDrugRestDose = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(subEpisode.Episode.ObjectID, new Guid(material.ObjectID.ToString()));
                        int restamount = 0;
                        foreach (PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class rest in ownDrugRestDose)
                        {
                            restamount = restamount + Convert.ToInt16(rest.Restamount);
                        }
                    }

                    List<DrugOrderDetail> drugOrderDetails = objectContext.QueryObjects<DrugOrderDetail>("DRUGORDER = " + TTConnectionManager.ConnectionManager.GuidToString(sortedList[sortedList.Count - 1].Drugorderid.Value)).ToList();
                    inpatientHasDrug.Amount = (drugOrderDetails.Count * parentDrugOrder.DoseAmount * inpatientHasDrug.Day).ToString();
                    if (drugOrderDetails.Count > 0)
                    {
                        drugOrderDetails = drugOrderDetails.OrderBy(x => x.OrderPlannedDate).ToList();
                        inpatientHasDrug.PlannedEndTime = drugOrderDetails[drugOrderDetails.Count - 1].OrderPlannedDate.Value;
                        inpatientHasDrug.PlannedStartTime = drugOrderDetails[drugOrderDetails.Count - 1].DrugOrder.CreationDate.Value;
                    }
                    output.Add(inpatientHasDrug);
                }
            }
            return output;
        }
    }

    public class PatientInputDTO
    {
        public string SubepisodeObjectId { get; set; }
        public string EpisodeObjectID { get; set; }
        public bool all { get; set; }
    }

    public class InpatientHasDrugList
    {
        public string OutStatus { get; set; }
        public DateTime? PlannedStartTime { get; set; }
        public DateTime? PlannedEndTime { get; set; }
        public string DrugName { get; set; }
        public AntibioticTypeEnum? EhuStatus { get; set; }
        public string Dose { get; set; }
        public double? DoseAmount { get; set; }
        public int? Day { get; set; }
        public string Amount { get; set; }
        public string Desciption { get; set; }
        public Boolean IsImmediately { get; set; }
        public Boolean PatientOwnDrug { get; set; }
        public Boolean CaseOfNeed { get; set; }
        public DrugUsageTypeEnum? TreatmentType { get; set; }
        public string DoctorName { get; set; }
        public string ClinikName { get; set; }
        public string MaterialType { get; set; }
    }
}