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
    public class NuclearServiceController : EpisodeActionWorkListServiceController
    {
        //protected override WorkListDefinition getWorkListDefinition()
        //{
        //    //TODO BB, worklistdef i şimdilik böyle çektim. Değişecek

        //    TTObjectContext objectContext = new TTObjectContext(true);
        //    WorkListDefinition _workListDefinition = (WorkListDefinition)objectContext.GetObject(new Guid("003cc7ea-e6cd-4b4c-9fb6-a645c92443da"), "WorkListDefinition");// Radyoloji İş Listesi
        //    return _workListDefinition;

        //}


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
                foreach (ResRadiologyEquipment.GetRadiologyEquipmentNQL_Class equipment in ResRadiologyEquipment.GetRadiologyEquipmentNQL("WHERE ISACTIVE = 1").ToList())
                {
                    EquipmentItem eItem = new EquipmentItem();
                    eItem.EquipmentResourceID = equipment.ObjectID.ToString();
                    eItem.EquipmentName = equipment.Name;
                    equipmentOutputDVO.EquipmentItemList.Add(eItem);
                }
                return equipmentOutputDVO;
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
                if (radiologyTest.SubEpisode.PatientAdmission.FirstSubEpisode.ProtocolNo != null)
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
    }
}