using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections.Generic;
using System.Collections;
using TTStorageManager.Security;
using TTUtils;
using TTDefinitionManagement;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    

    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class NuclearMedicineWorkListServiceController : EpisodeActionWorkListServiceController
    {
        public class NuclearMedicineInputDVO : QueryInputDVO
        {
            public bool OnlyOwnPatient // Yalnız Kendi Hastaları
            {
                get;
                set;
            }

            public string ProtocolNo
            {
                get;set;
            }

        }
        
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Nukleer_Tip_Is_Listesi)]
        public NuclearMedicineWorkListFormViewModel QueryNuclearMedicineWorkList(NuclearMedicineInputDVO inputdvo)
        { 
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                NuclearMedicineWorkListFormViewModel model = new NuclearMedicineWorkListFormViewModel();
                List<NuclearMedicineWorkListItemModel> NuclearMedicineList = new List<NuclearMedicineWorkListItemModel>();
                string filterExpression = string.Empty;

                if (inputdvo.StartDate.HasValue == false)
                    inputdvo.StartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                if (inputdvo.EndDate.HasValue == false)
                    inputdvo.EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                inputdvo.MinDate = Convert.ToDateTime("01.01.1900 00:00:00");
                WorkListDefinition workListDefinition = getWorkListDefinition("84060521-6e7f-42f5-88e5-793cd20eb7f7");
                           
                if (inputdvo.SelectedStateTypes.Count > 0)
                {
                    string stateTypeExp = "AND (CURRENTSTATE IS ";
                    for (int i = 0; i < inputdvo.SelectedStateTypes.Count; i++)
                    {
                        if (i == 0)
                        {
                            stateTypeExp += inputdvo.SelectedStateTypes[i].ToString();
                        }
                        else
                        {
                            stateTypeExp += " OR CURRENTSTATE IS " + inputdvo.SelectedStateTypes[i].ToString();
                        }
                    }
                    stateTypeExp += ")";
                    if (string.IsNullOrEmpty(inputdvo.StateType) == false)
                        filterExpression += stateTypeExp;
                }
                
                if (string.IsNullOrEmpty(inputdvo.PatientStatus) == false)
                    filterExpression += " AND THIS:EPISODE:PATIENTSTATUS IN (" + inputdvo.PatientStatus + ")";
                

                if(inputdvo.OnlyOwnPatient == true)
                {
                    filterExpression += " AND REQUESTDOCTOR.OBJECTID = '" + Common.CurrentDoctor.ObjectID.ToString() + "'";
                }

                if (inputdvo.SelectedWorkListItems != null && inputdvo.SelectedWorkListItems.Count > 0)
                {
                    List<Guid> objectDefIDs = new List<Guid>();
                    foreach (EpisodeActionWorkListItem wli in inputdvo.SelectedWorkListItems)
                    {
                        objectDefIDs.Add(new Guid(wli.ObjectDefID));
                    }

                    filterExpression = Common.CreateFilterExpressionOfGuidList(filterExpression, "OBJECTDEFID", objectDefIDs);
                }
                else if (inputdvo.WorkListItems != null && inputdvo.WorkListItems.Count > 0)
                {
                    List<Guid> objectDefIDs = new List<Guid>();
                    foreach (EpisodeActionWorkListItem wli in inputdvo.WorkListItems)
                    {
                        objectDefIDs.Add(new Guid(wli.ObjectDefID));
                    }

                    filterExpression = Common.CreateFilterExpressionOfGuidList(filterExpression, "OBJECTDEFID", objectDefIDs);
                }

                if (inputdvo.SelectedUserResourceItems != null && inputdvo.SelectedUserResourceItems.Count > 0)
                {
                    List<ResSection> selectedWorkListResources = new List<ResSection>();
                    foreach (UserResourceItem userResourceItem in inputdvo.SelectedUserResourceItems)
                    {
                        ResSection resource = objectContext.GetObject<ResSection>(new Guid(userResourceItem.ResourceID));
                        selectedWorkListResources.Add(resource);
                    }
                    Common.CurrentResource.SelectedWorkListResources = selectedWorkListResources;

                    filterExpression += GenerateResourceFilter(selectedWorkListResources);
                }
                else
                    Common.CurrentResource.SelectedWorkListResources = new List<ResSection>();

                

                List<EpisodeActionWorkListStateItem> selectedStateDefs = new List<EpisodeActionWorkListStateItem>();
                filterExpression += GenerateExpression(inputdvo, workListDefinition, out selectedStateDefs);

                if (!String.IsNullOrEmpty(inputdvo.ProtocolNo))
                {
                    if (inputdvo.ProtocolNo.Contains("-"))
                    {
                        filterExpression = " AND THIS.SUBEPISODE.PROTOCOLNO = '" + inputdvo.ProtocolNo.Trim() + "'";
                    }
                    else
                    {
                        filterExpression = " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + inputdvo.ProtocolNo.Trim() + "%'";
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(inputdvo.txtPatient))
                    {
                        filterExpression = " AND THIS:EPISODE:PATIENT:OBJECTID = '" + inputdvo.txtPatient + "'";
                    }
                }


                    if (inputdvo.SelectedWorkListStateItems == null || inputdvo.SelectedWorkListStateItems.Count == 0)
                {
                    inputdvo.WorkListStateItems = selectedStateDefs;
                }

                IBindingList nuclearMedicineWorkList = NuclearMedicine.GetByNuclearMedicineWorklistDateReport(inputdvo.StartDate.Value, inputdvo.EndDate.Value, filterExpression);
                foreach (NuclearMedicine.GetByNuclearMedicineWorklistDateReport_Class nTest in nuclearMedicineWorkList)
                {
                    NuclearMedicine nuclearMedicine = (NuclearMedicine)objectContext.GetObject(nTest.ObjectID.Value, "NUCLEARMEDICINE");
                    NuclearMedicineWorkListItemModel nuclearMedicineWorkListItemModel = CreateNuclearMedicineWorkListItemModel(nuclearMedicine);
                    NuclearMedicineList.Add(nuclearMedicineWorkListItemModel);

                }

                model.NuclearMedicineList = NuclearMedicineList;
                model.txtPatient = inputdvo.txtPatient;
                model.StartDate = (DateTime)inputdvo.StartDate;
                model.EndDate = (DateTime)inputdvo.EndDate;
                model.ID = inputdvo.ID.ToString();

                if (inputdvo.WorkListCount > 0)
                    model.WorkListCount = (int)inputdvo.WorkListCount;

                model.StateType = inputdvo.StateType;
                model.SelectedStateTypes = inputdvo.SelectedStateTypes;
                model.SelectedStateTypesEM = inputdvo.SelectedStateTypesEM;
                if (string.IsNullOrEmpty(inputdvo.PatientStatus) == false)
                    model.PatientStatus = inputdvo.PatientStatus;
                
                objectContext.FullPartialllyLoadedObjects();
                return model;
            }

        }

        private NuclearMedicineWorkListItemModel CreateNuclearMedicineWorkListItemModel(NuclearMedicine nuclearMedicine)
        {

            NuclearMedicineWorkListItemModel nuclearMedicineWorkListItemModel = new NuclearMedicineWorkListItemModel();
            nuclearMedicineWorkListItemModel.ObjectID = nuclearMedicine.ObjectID.ToString();
            nuclearMedicineWorkListItemModel.ObjectDefName = nuclearMedicine.ObjectDef.Name;
            nuclearMedicineWorkListItemModel.PatientNameSurname = nuclearMedicine.Episode.Patient.FullName;
            if (nuclearMedicine.SubEpisode != null && nuclearMedicine.SubEpisode.PatientAdmission != null)
            {
                if (nuclearMedicine.SubEpisode.PatientAdmission.FirstSubEpisode.ProtocolNo != null)
                    nuclearMedicineWorkListItemModel.ID = nuclearMedicine.SubEpisode.PatientAdmission.FirstSubEpisode.ProtocolNo;
                if (nuclearMedicine.SubEpisode.PatientAdmission.PriorityStatus != null)
                {
                    if (nuclearMedicine.SubEpisode.PatientAdmission.PriorityStatus.Name == TTUtils.CultureService.GetText("M25767", "Hamileler"))
                        nuclearMedicineWorkListItemModel.isPregnant = true;
                    if (nuclearMedicine.SubEpisode.PatientAdmission.PriorityStatus.Name == TTUtils.CultureService.GetText("M25090", "65 Yaş Üstü Yaşlılar"))
                        nuclearMedicineWorkListItemModel.isOld = true;
                    if (nuclearMedicine.SubEpisode.PatientAdmission.PriorityStatus.Name == "Harp ve vazife şehitlerinin dul ve yetimleri ile malül ve gaziler")
                        nuclearMedicineWorkListItemModel.isVetera = true;
                    if (nuclearMedicine.SubEpisode.PatientAdmission.PriorityStatus.Name == TTUtils.CultureService.GetText("M25097", "Acil Vakalar"))
                        nuclearMedicineWorkListItemModel.isEmergency = true;
                    if (nuclearMedicine.SubEpisode.PatientAdmission.PriorityStatus.Name == TTUtils.CultureService.GetText("M25590", "Engelliler"))
                        nuclearMedicineWorkListItemModel.isDisabled = true;
                    if (nuclearMedicine.SubEpisode.PatientAdmission.PriorityStatus.Name == TTUtils.CultureService.GetText("M25091", "7 Yaşından Küçük Çocuklar"))
                        nuclearMedicineWorkListItemModel.isYoung = true;
                }

                if (nuclearMedicine.Episode.Patient.ActivePregnancy != null || (nuclearMedicine.Episode.Patient.MedicalInformation != null && nuclearMedicine.Episode.Patient.MedicalInformation.Pregnancy.HasValue && nuclearMedicine.Episode.Patient.MedicalInformation.Pregnancy.Value == true))
                    nuclearMedicineWorkListItemModel.isPregnant = true;
                if (nuclearMedicine.Episode.Patient.Age.HasValue && nuclearMedicine.Episode.Patient.Age.Value > 65)
                    nuclearMedicineWorkListItemModel.isOld = true;
                if (nuclearMedicine.Episode.Patient.Age.HasValue && nuclearMedicine.Episode.Patient.Age.Value < 7)
                    nuclearMedicineWorkListItemModel.isYoung = true;
                if (nuclearMedicine.Episode.Patient.hasMedicalInformation())
                    nuclearMedicineWorkListItemModel.hasMedicalInformation = true;
            }

            nuclearMedicineWorkListItemModel.FromResourceName = nuclearMedicine.FromResource.Name;
            nuclearMedicineWorkListItemModel.EpisodeActionObjectID = nuclearMedicine.ObjectID.ToString();
            nuclearMedicineWorkListItemModel.NuclearMedicineTestName = nuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name.ToString();
            nuclearMedicineWorkListItemModel.TransactionDate = (DateTime)nuclearMedicine.WorkListDate.Value.Date;
            nuclearMedicineWorkListItemModel.ActionDate = nuclearMedicine.ActionDate.Value.ToString("dd.MM.yyyy");
            nuclearMedicineWorkListItemModel.StateName = nuclearMedicine.CurrentStateDef.DisplayText;
            if (nuclearMedicine.Emergency == true)
                nuclearMedicineWorkListItemModel.isNuclearMedicineTestEmergency = true;
            if (nuclearMedicine.Episode.Patient.IsPatientAllergic())
                nuclearMedicineWorkListItemModel.RowColor = Common.kirmiziRenk;

            return nuclearMedicineWorkListItemModel;
        }

        private string GenerateResourceFilter(List<ResSection> resourceList)
        {
            string filterExpression = string.Empty;

            filterExpression += " AND FROMRESOURCE IN(";

            int count = 0;
            foreach(ResSection section in resourceList)
            {
                count++;
                filterExpression += "'" + section.ObjectID.ToString() + "'";
                if (count != resourceList.Count)
                    filterExpression += ",";
            }

            filterExpression += ")";

            return filterExpression;

        }
    }
}