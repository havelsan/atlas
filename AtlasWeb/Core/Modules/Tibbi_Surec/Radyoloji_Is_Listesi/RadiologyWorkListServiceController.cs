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
    public class RadiologyWorkListServiceController : EpisodeActionWorkListServiceController
    {
        protected override WorkListDefinition getWorkListDefinition(string worklistDefID)
        {
            //TODO BB, worklistdef i şimdilik böyle çektim. Değişecek

            //RadiologyworklistDefID gelen parametreyi ezmeli. 
            worklistDefID = "003cc7ea-e6cd-4b4c-9fb6-a645c92443da";

            TTObjectContext objectContext = new TTObjectContext(true);
            WorkListDefinition _workListDefinition = (WorkListDefinition)objectContext.GetObject(new Guid(worklistDefID), "WorkListDefinition");// Radyoloji İş Listesi
            return _workListDefinition;

        }


        [HttpGet]
        public DynamicComponentInfoDVO GetDynamicComponentPatientInfo([FromQuery] string ObjectId)
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                TTObject obj = objectContext.GetObject(new Guid(ObjectId), typeof(RadiologyTest));
                var subFolders = GetParentFolders(obj.ObjectDef.ModuleDef);
                var folderPath = "Tibbi_Surec/Hasta_Demografik_Bilgileri"; //string.Join("/", subFolders.Reverse());
                var moduleName = "PatientDemographicsModule"; //obj.ObjectDef.ModuleDef.Name.GetTsModuleName();
                var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
                dynamicComponentInfo.ComponentName = "PatientDemographicsForm"; // obj.CurrentStateDef.FormDef.CodeName;
                dynamicComponentInfo.ModuleName = moduleName;
                dynamicComponentInfo.ModulePath = modulePath;
                dynamicComponentInfo.objectID = ObjectId;
                objectContext.FullPartialllyLoadedObjects();
                return dynamicComponentInfo;
            }
        }


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public RadiologyEquipmentOutputDVO GetRadiologyEquipment()
        {
            RadiologyEquipmentOutputDVO equipmentOutputDVO = new RadiologyEquipmentOutputDVO();

            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                equipmentOutputDVO.EquipmentItemList = new List<EquipmentItem>();
                foreach (ResRadiologyEquipment.GetRadiologyEquipmentNQL_Class equipment in ResRadiologyEquipment.GetRadiologyEquipmentNQL("WHERE ISACTIVE=1").ToList())
                {
                    EquipmentItem eItem = new EquipmentItem();
                    eItem.EquipmentResourceID = equipment.ObjectID.ToString();
                    eItem.EquipmentName = equipment.Name;
                    equipmentOutputDVO.EquipmentItemList.Add(eItem);
                }
                return equipmentOutputDVO;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public RadiologyWorkListFormViewModel QueryRadiologyWorkList(QueryInputDVO inputdvo)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                RadiologyWorkListFormViewModel model = new RadiologyWorkListFormViewModel();
                if (inputdvo.StartDate.HasValue == false)
                    inputdvo.StartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                if (inputdvo.EndDate.HasValue == false)
                    inputdvo.EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                inputdvo.MinDate = Convert.ToDateTime("01.01.1900 00:00:00");
                WorkListDefinition workListDefinition = getWorkListDefinition("003cc7ea-e6cd-4b4c-9fb6-a645c92443da");
                if (workListDefinition.LastSpecialPanel == null)
                {
                    IList pDefs = SpecialPanelDefinition.GetByUserAndWorkListDef(objectContext, inputdvo.activeResUserObjectID, workListDefinition.ObjectID.ToString()); //inMemory_Context olmalı
                    foreach (SpecialPanelDefinition pDef in pDefs)
                    {
                        if (pDef.Name == "@DEFAULT@")
                        {
                            TTObjectContext objectContextEditable = new TTObjectContext(false);
                            WorkListDefinition workListDefinitionEditable = (WorkListDefinition)objectContextEditable.GetObject(workListDefinition.ObjectID, typeof(WorkListDefinition));
                            workListDefinitionEditable.LastSpecialPanel = pDef;
                            SpecialPanelListItem lastSpecialPanelListItem = createNewSpecialPanelListItem(pDef);
                            model.LastSelectedSpecialPanel = lastSpecialPanelListItem;
                            objectContextEditable.Save();
                            break;
                        }
                    }
                }

                List<RadiologyWorkListItemModel> RadiologyList = new List<RadiologyWorkListItemModel>();
                string filterExpression = string.Empty;
                //if (inputdvo.SelectedStateTypes.Count > 0)
                //{
                //    string stateTypeExp = "AND (CURRENTSTATE IS ";
                //    for (int i = 0; i < inputdvo.SelectedStateTypes.Count; i++)
                //    {
                //        if (i == 0)
                //        {
                //            stateTypeExp += inputdvo.SelectedStateTypes[i].ToString();
                //        }
                //        else
                //        {
                //            stateTypeExp += " OR CURRENTSTATE IS " + inputdvo.SelectedStateTypes[i].ToString();
                //        }
                //    }
                //    stateTypeExp += ")";
                //    if (string.IsNullOrEmpty(inputdvo.StateType) == false)
                //        filterExpression += stateTypeExp;
                //}
                //if (string.IsNullOrEmpty(inputdvo.StateType) == false)
                //    filterExpression += " AND CURRENTSTATE IS " + inputdvo.StateType;
                if (string.IsNullOrEmpty(inputdvo.PatientStatus) == false)
                    filterExpression += " AND THIS:EPISODE:PATIENTSTATUS IN (" + inputdvo.PatientStatus + ")";

           

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
                    List<Guid> resSectionObjectDefIDs = new List<Guid>();
                    List<ResSection> selectedWorkListResources = new List<ResSection>();
                    foreach (UserResourceItem userResourceItem in inputdvo.SelectedUserResourceItems)
                    {
                        ResSection resource = objectContext.GetObject<ResSection>(new Guid(userResourceItem.ResourceID));
                        selectedWorkListResources.Add(resource);
                        resSectionObjectDefIDs.Add(resource.ObjectID);

                    }
                    Common.CurrentResource.SelectedWorkListResources = selectedWorkListResources;

                    filterExpression += Common.CreateFilterExpressionOfGuidList(filterExpression, "MASTERRESOURCE", resSectionObjectDefIDs);
                }
                else
                    Common.CurrentResource.SelectedWorkListResources = new List<ResSection>();

                List<EpisodeActionWorkListStateItem> selectedStateDefs = new List<EpisodeActionWorkListStateItem>();
                filterExpression += GenerateRadiologyWorkListExpression(inputdvo, workListDefinition, out selectedStateDefs);

                if (inputdvo.SelectedWorkListStateItems == null || inputdvo.SelectedWorkListStateItems.Count == 0)
                {
                    inputdvo.WorkListStateItems = selectedStateDefs;
                }
               

                if (inputdvo.SelectedRadiologyEquipmentItems != null && inputdvo.SelectedRadiologyEquipmentItems.Count > 0)
                {
                    List<Guid> objectDefIDs = new List<Guid>();
                    foreach (EquipmentItem equipmentItem in inputdvo.SelectedRadiologyEquipmentItems)
                    {
                        objectDefIDs.Add(new Guid(equipmentItem.EquipmentResourceID));
                    }

                    filterExpression = Common.CreateFilterExpressionOfGuidList(filterExpression, "EQUIPMENT", objectDefIDs);
                }

                
                //Tarihler queryden kaldırıldığı için oluşturulan filterexpressionın sonuna eklendi. (Kabul no ve hasta arama hariç)
                filterExpression += " AND WORKLISTDATE BETWEEN TODATE('" + Convert.ToDateTime(inputdvo.StartDate).ToString("yyyy-MM-dd HH:mm:ss") + "') AND TODATE('" + Convert.ToDateTime(inputdvo.EndDate).ToString("yyyy-MM-dd HH:mm:ss") + "')";

                if (!String.IsNullOrEmpty(inputdvo.txtPatient))
                {
                    //PatientSearch componenti kullanıldığı için değiştirildi.
                    filterExpression = " AND THIS:EPISODE:PATIENT:OBJECTID = '" + inputdvo.txtPatient + "'";
                }

                if (!String.IsNullOrEmpty(inputdvo.SEProtocolNo))
                {
                    filterExpression = " AND THIS:SUBEPISODE:PROTOCOLNO = '" + inputdvo.SEProtocolNo + "'";
                }



                bool isLCDActive = false;
                if (!string.IsNullOrEmpty(inputdvo.SelectedQueueObjectID))
                    isLCDActive = true;

                if (isLCDActive)
                {
                    // Sadece Islemde asaması secıldıgı zaman LCD monıtorundekı hastalar lıstelenecek
                    if (inputdvo.SelectedWorkListStateItems != null && inputdvo.SelectedWorkListStateItems.Count == 1 && inputdvo.SelectedWorkListStateItems[0].StateDefID == RadiologyTest.States.Procedure.ToString())
                    {
                        if (!string.IsNullOrEmpty(inputdvo.SelectedQueueObjectID))
                        {
                            TTObjectClasses.Common.QueueItems ret = new TTObjectClasses.Common.QueueItems();
                            ret = Common.GetSortedQueue(new Guid(inputdvo.SelectedQueueObjectID), false);

                            foreach (Common.QueuePatient patient in ret.patient)
                            {
                                if (patient.SubActionProcedureObjectID != Guid.Empty)
                                {
                                    RadiologyTest radiologyTest = (RadiologyTest)objectContext.GetObject(patient.SubActionProcedureObjectID, "RADIOLOGYTEST");
                                    if (radiologyTest is IWorkListRadiology && TTUser.CurrentUser.HasRight(radiologyTest.CurrentStateDef.FormDef, radiologyTest, workListDefinition.RightDefID.Value))
                                    {
                                        if (radiologyTest.CurrentStateDefID == RadiologyTest.States.Procedure)
                                        {
                                            RadiologyWorkListItemModel radiologyWorkListItemModel = CreateRadiologyWorkListItemModel(radiologyTest);
                                            RadiologyList.Add(radiologyWorkListItemModel);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // Diger statelerde eskiden calistigi gibi listeleme yapilacak.
                        IBindingList radiologyWorkList = RadiologyTest.GetByRadTestWorklistDateReport( filterExpression);
                        foreach (RadiologyTest.GetByRadTestWorklistDateReport_Class rTest in radiologyWorkList)
                        {
                            bool addTestToWorkList = false;
                            RadiologyTest radiologyTest = (RadiologyTest)objectContext.GetObject(rTest.ObjectID.Value, "RADIOLOGYTEST");
                            if (radiologyTest is IWorkListRadiology && TTUser.CurrentUser.HasRight(radiologyTest.CurrentStateDef.FormDef, radiologyTest, workListDefinition.RightDefID.Value))
                            {
                                //DIS labortatuvardan istenen tetkik ise viewmodel e eklenmeyecek. Onlarin is listesinde cikmasi istenmedi : TFS 46793
                                //MEDULA Mevzuat degisikligi sonucu, DIS laboratuvardan istenen MR ve BT tetkiklerin goruntuleri sisteme kaydedilecek ve tetkik Cekim Yapildi asamasina kadar getirilecek 
                                //MR ve BT turundeki tetkikler is listesine eklenecek. TFS:53540

                                if (radiologyTest.MasterResource != null)
                                {
                                    if (((ResObservationUnit)radiologyTest.MasterResource).IsExternalObservationUnit != true)
                                    {
                                        addTestToWorkList = true;
                                    }
                                    else
                                    {
                                        if (radiologyTest.ProcedureObject.IsMR || radiologyTest.ProcedureObject.IsBT)
                                        {
                                            addTestToWorkList = true;
                                        }
                                    }
                                    if (addTestToWorkList)
                                    {
                                        RadiologyWorkListItemModel radiologyWorkListItemModel = CreateRadiologyWorkListItemModel(radiologyTest);
                                        RadiologyList.Add(radiologyWorkListItemModel);
                                    }
                                }
                            }
                        }
                    }
                }

                else
                {
                    // Diger statelerde eskiden calistigi gibi listeleme yapilacak.
                    IBindingList radiologyWorkList = RadiologyTest.GetByRadTestWorklistDateReport(filterExpression);
                    foreach (RadiologyTest.GetByRadTestWorklistDateReport_Class rTest in radiologyWorkList)
                    {
                        bool addTestToWorkList = false;
                        RadiologyTest radiologyTest = (RadiologyTest)objectContext.GetObject(rTest.ObjectID.Value, "RADIOLOGYTEST");
                        if (radiologyTest is IWorkListRadiology && TTUser.CurrentUser.HasRight(radiologyTest.CurrentStateDef.FormDef, radiologyTest, workListDefinition.RightDefID.Value))
                        {
                            //DIS labortatuvardan istenen tetkik ise viewmodel e eklenmeyecek. Onlarin is listesinde cikmasi istenmedi : TFS 46793
                            //MEDULA Mevzuat degisikligi sonucu, DIS laboratuvardan istenen MR ve BT tetkiklerin goruntuleri sisteme kaydedilecek ve tetkik Cekim Yapildi asamasina kadar getirilecek 
                            //MR ve BT turundeki tetkikler is listesine eklenecek. TFS:53540

                            if (radiologyTest.MasterResource != null)
                            {
                                if (((ResObservationUnit)radiologyTest.MasterResource).IsExternalObservationUnit != true)
                                {
                                    addTestToWorkList = true;
                                }
                                else
                                {
                                    if (radiologyTest.ProcedureObject.IsMR || radiologyTest.ProcedureObject.IsBT)
                                    {
                                        addTestToWorkList = true;
                                    }
                                }
                                if (addTestToWorkList)
                                {
                                    RadiologyWorkListItemModel radiologyWorkListItemModel = CreateRadiologyWorkListItemModel(radiologyTest);
                                    RadiologyList.Add(radiologyWorkListItemModel);
                                }
                            }
                        }
                    }
                }
                


                //ESKI KOD
                /*  
                // Sadece Islemde asaması secıldıgı zaman LCD monıtorundekı hastalar lıstelenecek
                if (inputdvo.SelectedWorkListStateItems != null && inputdvo.SelectedWorkListStateItems.Count == 1 && inputdvo.SelectedWorkListStateItems[0].StateDefID == RadiologyTest.States.Procedure.ToString())
                {
                    if (!string.IsNullOrEmpty(inputdvo.SelectedQueueObjectID ))
                    { 
                        TTObjectClasses.Common.QueueItems ret = new TTObjectClasses.Common.QueueItems();
                        ret = Common.GetSortedQueue(new Guid(inputdvo.SelectedQueueObjectID), false);

                        foreach (Common.QueuePatient patient in ret.patient)
                        {
                            if (patient.SubActionProcedureObjectID != Guid.Empty)
                            {
                                RadiologyTest radiologyTest = (RadiologyTest)objectContext.GetObject(patient.SubActionProcedureObjectID, "RADIOLOGYTEST");
                                if (radiologyTest is IWorkListRadiology && TTUser.CurrentUser.HasRight(radiologyTest.CurrentStateDef.FormDef, radiologyTest, workListDefinition.RightDefID.Value))
                                {
                                    if (radiologyTest.CurrentStateDefID == RadiologyTest.States.Procedure)
                                    {
                                        RadiologyWorkListItemModel radiologyWorkListItemModel = CreateRadiologyWorkListItemModel(radiologyTest);
                                        RadiologyList.Add(radiologyWorkListItemModel);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    // Diger statelerde eskiden calistigi gibi listeleme yapilacak.
                    IBindingList radiologyWorkList = RadiologyTest.GetByRadTestWorklistDateReport(inputdvo.StartDate.Value, inputdvo.EndDate.Value, filterExpression);
                    foreach (RadiologyTest.GetByRadTestWorklistDateReport_Class rTest in radiologyWorkList)
                    {
                        bool addTestToWorkList = false;
                        RadiologyTest radiologyTest = (RadiologyTest)objectContext.GetObject(rTest.ObjectID.Value, "RADIOLOGYTEST");
                        if (radiologyTest is IWorkListRadiology && TTUser.CurrentUser.HasRight(radiologyTest.CurrentStateDef.FormDef, radiologyTest, workListDefinition.RightDefID.Value))
                        {
                            //DIS labortatuvardan istenen tetkik ise viewmodel e eklenmeyecek. Onlarin is listesinde cikmasi istenmedi : TFS 46793
                            //MEDULA Mevzuat degisikligi sonucu, DIS laboratuvardan istenen MR ve BT tetkiklerin goruntuleri sisteme kaydedilecek ve tetkik Cekim Yapildi asamasina kadar getirilecek 
                            //MR ve BT turundeki tetkikler is listesine eklenecek. TFS:53540
                            
                            if (radiologyTest.MasterResource != null)
                            {
                                if (((ResObservationUnit)radiologyTest.MasterResource).IsExternalObservationUnit != true)
                                {
                                    addTestToWorkList = true;
                                }
                                else
                                {
                                    if (radiologyTest.ProcedureObject.IsMR || radiologyTest.ProcedureObject.IsBT)
                                    {
                                        addTestToWorkList = true;
                                    }
                                }
                                if (addTestToWorkList)
                                {
                                    RadiologyWorkListItemModel radiologyWorkListItemModel = CreateRadiologyWorkListItemModel(radiologyTest);
                                    RadiologyList.Add(radiologyWorkListItemModel);
                                }
                            }
                        }
                    }
                }
                */

                model.RadiologyList = RadiologyList;
                model.txtPatient = inputdvo.txtPatient;
                model.StartDate = (DateTime)inputdvo.StartDate;
                model.EndDate = (DateTime)inputdvo.EndDate;
                model.ID = inputdvo.ID.ToString();
                if (inputdvo.WorkListCount > 0)
                    model.WorkListCount = (int)inputdvo.WorkListCount;
                //TODO: Kullanıcı özelliklerinden gelmeli.
                model.StateType = inputdvo.StateType;
                //model.SelectedStateTypes = inputdvo.SelectedStateTypes;
                //model.SelectedStateTypesEM = inputdvo.SelectedStateTypesEM;
                if (string.IsNullOrEmpty(inputdvo.PatientStatus) == false)
                    model.PatientStatus = inputdvo.PatientStatus;
                //model.workListItems = FilterStatesWithObjectDef();
                objectContext.FullPartialllyLoadedObjects();
                return model;
            }
        }

        public RadiologyWorkListItemModel CreateRadiologyWorkListItemModel(RadiologyTest radiologyTest)
        {
         
            RadiologyWorkListItemModel radiologyWorkListItemModel = new RadiologyWorkListItemModel();
            radiologyWorkListItemModel.ObjectID = radiologyTest.ObjectID.ToString();
            radiologyWorkListItemModel.ObjectDefName = radiologyTest.ObjectDef.Name;
            radiologyWorkListItemModel.PatientNameSurname = radiologyTest.Episode.Patient.FullName;
            if (radiologyTest.SubEpisode != null && radiologyTest.SubEpisode.PatientAdmission != null)
            {
                if (radiologyTest.SubEpisode.PatientAdmission.FirstSubEpisode != null && radiologyTest.SubEpisode.PatientAdmission.FirstSubEpisode.ProtocolNo != null)
                    radiologyWorkListItemModel.ID = radiologyTest.SubEpisode.PatientAdmission.FirstSubEpisode.ProtocolNo;
                if (radiologyTest.SubEpisode.PatientAdmission.PriorityStatus != null)
                {
                    if (radiologyTest.SubEpisode.PatientAdmission.PriorityStatus.Name == TTUtils.CultureService.GetText("M25767", "Hamileler"))
                        radiologyWorkListItemModel.isPregnant = true;
                    if (radiologyTest.SubEpisode.PatientAdmission.PriorityStatus.Name == TTUtils.CultureService.GetText("M25090", "65 Yaş Üstü Yaşlılar"))
                        radiologyWorkListItemModel.isOld = true;
                    if (radiologyTest.SubEpisode.PatientAdmission.PriorityStatus.Name == "Harp ve vazife şehitlerinin dul ve yetimleri ile malül ve gaziler")
                        radiologyWorkListItemModel.isVetera = true;
                    if (radiologyTest.SubEpisode.PatientAdmission.PriorityStatus.Name == TTUtils.CultureService.GetText("M25097", "Acil Vakalar"))
                        radiologyWorkListItemModel.isEmergency = true;
                    if (radiologyTest.SubEpisode.PatientAdmission.PriorityStatus.Name == TTUtils.CultureService.GetText("M25590", "Engelliler"))
                        radiologyWorkListItemModel.isDisabled = true;
                    if (radiologyTest.SubEpisode.PatientAdmission.PriorityStatus.Name == TTUtils.CultureService.GetText("M25091", "7 Yaşından Küçük Çocuklar"))
                        radiologyWorkListItemModel.isYoung = true;
                }

                if (radiologyTest.Episode.Patient.ActivePregnancy != null || (radiologyTest.Episode.Patient.MedicalInformation != null && radiologyTest.Episode.Patient.MedicalInformation.Pregnancy.HasValue && radiologyTest.Episode.Patient.MedicalInformation.Pregnancy.Value == true))
                    radiologyWorkListItemModel.isPregnant = true;
                if (radiologyTest.Episode.Patient.Age.HasValue && radiologyTest.Episode.Patient.Age.Value > 65)
                    radiologyWorkListItemModel.isOld = true;
                if (radiologyTest.Episode.Patient.Age.HasValue && radiologyTest.Episode.Patient.Age.Value < 7)
                    radiologyWorkListItemModel.isYoung = true;
                if (radiologyTest.Episode.Patient.hasMedicalInformation())
                    radiologyWorkListItemModel.hasMedicalInformation = true;
                if (radiologyWorkListItemModel.hasMedicalInformation)
                    radiologyWorkListItemModel.Pandemic = radiologyTest.Episode.Patient.MedicalInformation.Pandemic.HasValue ? radiologyTest.Episode.Patient.MedicalInformation.Pandemic.Value : false;
            }

            radiologyWorkListItemModel.FromResourceName = radiologyTest.FromResource.Name;
            radiologyWorkListItemModel.EpisodeActionObjectID = radiologyTest.Radiology.ObjectID.ToString();
            radiologyWorkListItemModel.RadiologyTestName = radiologyTest.ProcedureObject.Name.ToString();
            radiologyWorkListItemModel.TransactionDate = (DateTime)radiologyTest.WorkListDate.Value.Date;
            radiologyWorkListItemModel.ActionDate = radiologyTest.ActionDate.Value.ToString("dd.MM.yyyy");
            radiologyWorkListItemModel.StateName = radiologyTest.CurrentStateDef.DisplayText;
            if (radiologyTest.Emergency == true)
                radiologyWorkListItemModel.isRadTestEmergency = true;
            
            if (radiologyTest.Episode.Patient.IsPatientAllergic())
                radiologyWorkListItemModel.RowColor = Common.kirmiziRenk;

            return radiologyWorkListItemModel;
        }

        protected static string GenerateRadiologyWorkListExpression(QueryInputDVO queryInputDVO, WorkListDefinition workListDefinition, out List<EpisodeActionWorkListStateItem> selectedStateDefs)
        {
            selectedStateDefs = new List<EpisodeActionWorkListStateItem>();
            List<EpisodeActionWorkListStateItem> _selectedStateDefs = new List<EpisodeActionWorkListStateItem>();
            if (queryInputDVO.SelectedWorkListStateItems != null && queryInputDVO.SelectedWorkListStateItems.Count > 0)
                _selectedStateDefs = queryInputDVO.SelectedWorkListStateItems;
            else if (queryInputDVO.WorkListStateItems != null && queryInputDVO.WorkListStateItems.Count > 0)
            {
                //if (queryInputDVO.SelectedStateTypesEM.Count > 0)
                //{
                //    foreach (string stateType in queryInputDVO.SelectedStateTypesEM)
                //    {
                //        foreach (EpisodeActionWorkListStateItem stateItem in queryInputDVO.WorkListStateItems)
                //        {
                //            if (stateItem.StateStatus.Equals(stateType))
                //                _selectedStateDefs.Add(stateItem);
                //        }
                //    }

                //}
                //else
                _selectedStateDefs = queryInputDVO.WorkListStateItems;
            }
            else
                return "";

            var expression = new System.Text.StringBuilder(" AND (");

            expression.Append(workListDefinition.GenerateExpression());

            Dictionary<Guid, List<TTObjectStateDef>> states = new Dictionary<Guid, List<TTObjectStateDef>>();
            for (int i = 0; i < _selectedStateDefs.Count; i++)
            {
                TTObjectStateDef stateDef = TTObjectDefManager.Instance.AllTTObjectStateDefs[new Guid(_selectedStateDefs[i].StateDefID)];

                //if (queryInputDVO.SelectedStateTypesEM.Count == 0 || queryInputDVO.SelectedStateTypesEM.Contains<string>(stateDef.Status.ToString().ToUpper()))
                //{
                Guid? permDefID = ((ITTSecurableObject)stateDef.ObjectDef).GetSecurityAuthority().PermissionDefID;
                if (permDefID.HasValue)
                {
                    List<TTObjectStateDef> list;
                    if (states.TryGetValue(permDefID.Value, out list) == false)
                    {
                        list = new List<TTObjectStateDef>();
                        states.Add(permDefID.Value, list);
                    }
                    list.Add(stateDef);
                    EpisodeActionWorkListStateItem stateItem = new EpisodeActionWorkListStateItem();
                    stateItem.StateDefID = stateDef.StateDefID.ToString();
                    stateItem.StateDefName = stateDef.Name;
                    stateItem.StateStatus = stateDef.Status.ToString().ToUpperInvariant();
                    selectedStateDefs.Add(stateItem);
                }
                //}
            }

            if (states.Values.Count == 0)
                return "";

            var sAnd = "";
            foreach (var list in states.Values)
            {
                var autho = ((ITTSecurableObject)list[0].ObjectDef).GetSecurityAuthority();
                expression.Append(sAnd);
                autho.GetWorklistNQLFilter(expression, list);
                sAnd = " OR ";
            }

            expression.Append(")");

            return expression.ToString();
        }

        [HttpGet]
        public RadiologyStatisticReportViewModel LoadRadiologyStatisticReportViewModel()
        {
            RadiologyStatisticReportViewModel model = new RadiologyStatisticReportViewModel();
            using (var objectContext = new TTObjectContext(false))
            {

                model.TestTypeList = new List<RadiologyStatisticBaseObject>();
                model.GenderList = new List<RadiologyStatisticBaseObject>();
                model.PayerList = new List<RadiologyStatisticBaseObject>();
                model.ResourceList = new List<RadiologyStatisticBaseObject>();
                model.EquipmentList = new List<RadiologyStatisticBaseObject>();
                model.ProcedureDoctorList = new List<RadiologyStatisticBaseObject>();

                BindingList<RadiologyTestTypeDefinition.GetRadiologyTestTypeDefinitionNQL_Class> testTypeList = RadiologyTestTypeDefinition.GetRadiologyTestTypeDefinitionNQL("");
                foreach (RadiologyTestTypeDefinition.GetRadiologyTestTypeDefinitionNQL_Class type in testTypeList)
                {
                    RadiologyStatisticBaseObject o = new RadiologyStatisticBaseObject();
                    o.ObjectID = type.ObjectID.ToString();
                    o.Name = type.Name;
                    model.TestTypeList.Add(o);
                }

                BindingList <SKRSCinsiyet.GetSKRSCinsiyet_Class> gList =  SKRSCinsiyet.GetSKRSCinsiyet(" WHERE THIS.AKTIF = 1 ");
                foreach (SKRSCinsiyet.GetSKRSCinsiyet_Class gender in gList)
                {
                    RadiologyStatisticBaseObject o = new RadiologyStatisticBaseObject();
                    o.ObjectID = gender.ObjectID.ToString();
                    o.Name = gender.ADI;
                    model.GenderList.Add(o);
                }

                BindingList<PayerDefinition.GetPayerDefinitions_Class> payerList = PayerDefinition.GetPayerDefinitions(" WHERE THIS.ISACTIVE = 1 ");
                foreach (PayerDefinition.GetPayerDefinitions_Class payer in payerList)
                {
                    RadiologyStatisticBaseObject o = new RadiologyStatisticBaseObject();
                    o.ObjectID = payer.ObjectID.ToString();
                    o.Name = payer.Name;
                    model.PayerList.Add(o);
                }

                
                foreach (UserResource userResource in Common.CurrentResource.UserResources)
                {
                    if (!model.ResourceList.Exists(u => u.ObjectID.Equals(userResource.Resource.ObjectID.ToString())))
                    {
                        
                            foreach (ResourceSpecialityGrid speciality in userResource.Resource.ResourceSpecialities)
                            {
                                if (speciality.Speciality.SKRSKlinik != null && (speciality.Speciality.SKRSKlinik.KODU == "104" || speciality.Speciality.SKRSKlinik.KODU == "130" || speciality.Speciality.SKRSKlinik.KODU == "178"))
                                {
                                    RadiologyStatisticBaseObject userResourceItem = new RadiologyStatisticBaseObject();
                                    userResourceItem.ObjectID = userResource.Resource.ObjectID.ToString();
                                    userResourceItem.Name = userResource.Resource.Name;
                                    model.ResourceList.Add(userResourceItem);
                                }
                            }
                       
                    }
                }

                foreach (ResRadiologyEquipment.GetRadiologyEquipmentNQL_Class equipment in ResRadiologyEquipment.GetRadiologyEquipmentNQL("WHERE ISACTIVE=1").ToList())
                {
                    RadiologyStatisticBaseObject eItem = new RadiologyStatisticBaseObject();
                    eItem.ObjectID = equipment.ObjectID.ToString();
                    eItem.Name = equipment.Name;
                    model.EquipmentList.Add(eItem);
                }

                BindingList<ResUser.SpecialistDoctorListNQL_Class> doctorList =  ResUser.SpecialistDoctorListNQL("");
                foreach(ResUser.SpecialistDoctorListNQL_Class doctor in doctorList)
                {
                    RadiologyStatisticBaseObject item = new RadiologyStatisticBaseObject();
                    item.Name = doctor.Name;
                    item.ObjectID = doctor.ObjectID.ToString();
                    model.ProcedureDoctorList.Add(item);

                }


            }
            return model;
        }

        [HttpGet]
        public List<RadiologyStatisticBaseObject> GetRadiologyTestDefinitionByTestType(string TestTypeObjectID)
        {
            List<RadiologyStatisticBaseObject> list = new List<RadiologyStatisticBaseObject>();
            using (var objectContext = new TTObjectContext(false))
            {

               

                BindingList<RadiologyTestDefinition.GetRadiologyTestDefinitionNQL_Class> testList = RadiologyTestDefinition.GetRadiologyTestDefinitionNQL(" WHERE THIS.ISACTIVE= 1 AND THIS.TestType.OBJECTID = '"+TestTypeObjectID+"'");
                foreach (RadiologyTestDefinition.GetRadiologyTestDefinitionNQL_Class test in testList)
                {
                    RadiologyStatisticBaseObject o = new RadiologyStatisticBaseObject();
                    o.ObjectID = test.ObjectID.ToString();
                    o.Name = test.Code +"-"+test.Name;
                    list.Add(o);
                }


            }
            return list;
        }

        
    }
}