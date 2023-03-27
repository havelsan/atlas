//$99C3AC39
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Point = System.Drawing.Point;
using Color = System.Drawing.Color;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TTUtils;
using Core.Security;
using TTStorageManager.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class CommonServiceController : Controller
    {
        public class CallWebMethod_Input
        {
            public string ns
            {
                get;
                set;
            }

            public string methodName
            {
                get;
                set;
            }

            public object[] paramters
            {
                get;
                set;
            }
        }

        [HttpPost]
        public object CallWebMethod(CallWebMethod_Input input)
        {
            var ret = Common.CallWebMethod(input.ns, input.methodName, input.paramters);
            return ret;
        }

        public class CallWebMethodV3_Input
        {
            public string ns
            {
                get;
                set;
            }

            public string methodName
            {
                get;
                set;
            }

            public string siteId
            {
                get;
                set;
            }

            public string username
            {
                get;
                set;
            }

            public string password
            {
                get;
                set;
            }

            public object[] paramters
            {
                get;
                set;
            }
        }

        [HttpPost]
        public object CallWebMethodV3(CallWebMethodV3_Input input)
        {
            var ret = Common.CallWebMethodV3(input.ns, input.methodName, input.siteId, input.username, input.password, input.paramters);
            return ret;
        }

        public class CallWebMethodV2_Input
        {
            public string ns
            {
                get;
                set;
            }

            public string methodName
            {
                get;
                set;
            }

            public string siteId
            {
                get;
                set;
            }

            public TTUtils.IWebMethodCredential credential
            {
                get;
                set;
            }

            public object[] paramters
            {
                get;
                set;
            }
        }

        public class CallWebMethodWithHeader_Input
        {
            public TTUtils.IWebMethodCallHeader header
            {
                get;
                set;
            }

            public TTUtils.IWebMethodCredential credential
            {
                get;
                set;
            }

            public object[] paramters
            {
                get;
                set;
            }
        }

        [HttpPost]
        public object CallWebMethodWithHeader(CallWebMethodWithHeader_Input input)
        {
            var ret = Common.CallWebMethodWithHeader(input.header, input.credential, input.paramters);
            return ret;
        }

        public class SaveDiagnosisInfo_Input
        {
            public TTObjectClasses.Common.DiagnosisInfo obj
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SaveDiagnosisInfo(SaveDiagnosisInfo_Input input)
        {
            Common.SaveDiagnosisInfo(input.obj);
        }

        public class SaveLabResult_Input
        {
            public TTObjectClasses.Common.LabResultInfo labResult
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SaveLabResult(SaveLabResult_Input input)
        {
            Common.SaveLabResult(input.labResult);
        }

        public class SendPACSPrinterControlMessage_Input
        {
            public string message
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendPACSPrinterControlMessage(SendPACSPrinterControlMessage_Input input)
        {
            Common.SendPACSPrinterControlMessage(input.message);
        }

        public class EliminateIllegalDate_Input
        {
            public System.DateTime? date
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.DateTime? EliminateIllegalDate(EliminateIllegalDate_Input input)
        {
            var ret = Common.EliminateIllegalDate(input.date);
            return ret;
        }

        public class GetPersonelItem_Input
        {
            public long uniqRefNo
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.Common.PersonelItem GetPersonelItem(GetPersonelItem_Input input)
        {
            var ret = Common.GetPersonelItem(input.uniqRefNo);
            return ret;
        }

        public class SaveResUser_Input
        {
            public TTObjectClasses.Common.CommonResUser obj
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SaveResUser(SaveResUser_Input input)
        {
            Common.SaveResUser(input.obj);
        }

        [HttpPost]
        public TTObjectClasses.ResHospital GetCurrentHospital()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.GetCurrentHospital(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public TTObjectClasses.HospitalEmblemDefinition GetCurrentHospitalLogoV2()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.GetCurrentHospitalLogoV2(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public string GetCurrentHospitalLogo()
        {
            var ret = Common.GetCurrentHospitalLogo();
            return ret;
        }

        [HttpPost]
        public TTObjectClasses.MilitaryUnit GetCurrentMilitaryUnit()
        {
            using (var objContext = new TTObjectContext(false))
            {
                var ret = Common.GetCurrentMilitaryUnit(objContext);
                objContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public System.DateTime MinDateTime()
        {
            var ret = Common.MinDateTime();
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public System.DateTime RecTime()
        {
            var ret = Common.RecTime();
            return ret;
        }

        public class SaveSystemOption_Input
        {
            public TTObjectClasses.UserOptionType optionType
            {
                get;
                set;
            }

            public string value
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SaveSystemOption(SaveSystemOption_Input input)
        {
            Common.SaveSystemOption(input.optionType, input.value);
        }

        public class GetSystemOption_Input
        {
            public TTObjectClasses.UserOptionType optionType
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.UserOption GetSystemOption(GetSystemOption_Input input)
        {
            var ret = Common.GetSystemOption(input.optionType);
            return ret;
        }

        public class GetUserOptionValue_Input
        {
            public TTObjectClasses.ResUser user
            {
                get;
                set;
            }

            public TTObjectClasses.UserOptionType optionType
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetUserOptionValue(GetUserOptionValue_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                context.AddObject(input.user);
                var ret = Common.GetUserOptionValue(context, input.user, input.optionType);
                context.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<TTObjectClasses.SpecialityDefinition> CurrentResourceSpecialities()
        {
            var ret = Common.CurrentResourceSpecialities();
            return ret;
        }

        public class SortedDoubleItems_Input
        {
            public System.Collections.Hashtable unSortedList
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<TTObjectClasses.Common.TTDoubleSortableList> SortedDoubleItems(SortedDoubleItems_Input input)
        {
            var ret = Common.SortedDoubleItems(input.unSortedList);
            return ret;
        }

        public class SortedStringItems_Input
        {
            public System.Collections.Hashtable unSortedList
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<TTObjectClasses.Common.TTStringSortableList> SortedStringItems(SortedStringItems_Input input)
        {
            var ret = Common.SortedStringItems(input.unSortedList);
            return ret;
        }

        public class SortedDateItems_Input
        {
            public System.Collections.Hashtable unSortedList
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<TTObjectClasses.Common.TTDateSortableList> SortedDateItems(SortedDateItems_Input input)
        {
            var ret = Common.SortedDateItems(input.unSortedList);
            return ret;
        }

        public class DateDiff_Input
        {
            public TTObjectClasses.Common.DateIntervalEnum dateIntervalEnum
            {
                get;
                set;
            }

            public System.DateTime Date1
            {
                get;
                set;
            }

            public System.DateTime Date2
            {
                get;
                set;
            }
        }

        [HttpPost]
        public int DateDiff(DateDiff_Input input)
        {
            var ret = Common.DateDiff(input.dateIntervalEnum, input.Date1, input.Date2);
            return ret;
        }

        public class DateDiffV2_Input
        {
            public TTObjectClasses.Common.DateIntervalEnum dateIntervalEnum
            {
                get;
                set;
            }

            public System.DateTime Date1
            {
                get;
                set;
            }

            public System.DateTime Date2
            {
                get;
                set;
            }

            public bool abs
            {
                get;
                set;
            }
        }

        [HttpPost]
        public int DateDiffV2(DateDiffV2_Input input)
        {
            var ret = Common.DateDiffV2(input.dateIntervalEnum, input.Date1, input.Date2, input.abs);
            return ret;
        }

        public class ArrayListToString_Input
        {
            public System.Collections.ArrayList arrayList
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string ArrayListToString(ArrayListToString_Input input)
        {
            var ret = Common.ArrayListToString(input.arrayList);
            return ret;
        }

        public class MainPatientGroupDefinitionByEnum_Input
        {
            public TTObjectClasses.MainPatientGroupEnum mainPatientGroupEnum
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.MainPatientGroupDefinition MainPatientGroupDefinitionByEnum(MainPatientGroupDefinitionByEnum_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.MainPatientGroupDefinitionByEnum(objectContext, input.mainPatientGroupEnum);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class PatientGroupDefinitionByEnum_Input
        {
            public TTObjectClasses.PatientGroupEnum patientGroupEnum
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.PatientGroupDefinition PatientGroupDefinitionByEnum(PatientGroupDefinitionByEnum_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.PatientGroupDefinitionByEnum(objectContext, input.patientGroupEnum);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class ActiveMainPatientGroupDefinitionByEnum_Input
        {
            public TTObjectClasses.MainPatientGroupEnum mainPatientGroupEnum
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.MainPatientGroupDefinition ActiveMainPatientGroupDefinitionByEnum(ActiveMainPatientGroupDefinitionByEnum_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.ActiveMainPatientGroupDefinitionByEnum(objectContext, input.mainPatientGroupEnum);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class ActivePatientGroupDefinitionByEnum_Input
        {
            public TTObjectClasses.PatientGroupEnum patientGroupEnum
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.PatientGroupDefinition ActivePatientGroupDefinitionByEnum(ActivePatientGroupDefinitionByEnum_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.ActivePatientGroupDefinitionByEnum(objectContext, input.patientGroupEnum);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class ReasonForExaminationByType_Input
        {
            public TTObjectClasses.ReasonForExaminationTypeEnum reasonForExaminationType
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.ReasonForExaminationDefinition ReasonForExaminationByType(ReasonForExaminationByType_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.ReasonForExaminationByType(objectContext, input.reasonForExaminationType);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class ReasonForExaminationByCode_Input
        {
            public long Code
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.ReasonForExaminationDefinition ReasonForExaminationByCode(ReasonForExaminationByCode_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.ReasonForExaminationByCode(objectContext, input.Code);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class IsPropertyExist_Input
        {
            public TTInstanceManagement.TTObject ttObject
            {
                get;
                set;
            }

            public string propertyName
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsPropertyExist(IsPropertyExist_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(input.ttObject);
                var ret = Common.IsPropertyExist(input.ttObject, input.propertyName);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class PropertyValue_Input
        {
            public TTInstanceManagement.TTObject ttObject
            {
                get;
                set;
            }

            public string propertyName
            {
                get;
                set;
            }
        }

        [HttpPost]
        public object PropertyValue(PropertyValue_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(input.ttObject);
                var ret = Common.PropertyValue(input.ttObject, input.propertyName);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class IsAttributeExists_Input
        {
            public string AttributeName
            {
                get;
                set;
            }

            public TTInstanceManagement.TTObject ttobject
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsAttributeExists(IsAttributeExists_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(input.ttobject);
                var ret = Common.IsAttributeExists(input.AttributeName.ToString(), input.ttobject);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class IsAttributeExistsV2_Input
        {
            public System.Type AttributeType
            {
                get;
                set;
            }

            public TTDefinitionManagement.TTObjectDef objectDef
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsAttributeExistsV2(IsAttributeExistsV2_Input input)
        {
            var ret = Common.IsAttributeExistsV2(input.AttributeType, input.objectDef);
            return ret;
        }

        public class IsTransitionAttributeExists_Input
        {
            public System.Type AttributeType
            {
                get;
                set;
            }

            public TTDefinitionManagement.TTObjectStateTransitionDef transDef
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsTransitionAttributeExists(IsTransitionAttributeExists_Input input)
        {
            var ret = Common.IsTransitionAttributeExists(input.AttributeType, input.transDef);
            return ret;
        }

        public class IsTransitionAttributeExistsByAttName_Input
        {
            public string AttributeName
            {
                get;
                set;
            }

            public TTDefinitionManagement.TTObjectStateTransitionDef transDef
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsTransitionAttributeExistsByAttName(IsTransitionAttributeExistsByAttName_Input input)
        {
            var ret = Common.IsTransitionAttributeExistsByAttName(input.AttributeName, input.transDef);
            return ret;
        }

        public class IsAppointmentTransitionAttributeExists_Input
        {
            public Guid transDefID
            {
                get;
                set;
            }

            public TTInstanceManagement.TTObject ttObject
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsAppointmentTransitionAttributeExists(IsAppointmentTransitionAttributeExists_Input input)
        {
            TTDefinitionManagement.TTObjectStateTransitionDef transDef = input.ttObject.ObjectDef.AllTransitionDefs.Values.FirstOrDefault(t => t.StateTransitionDefID.ToString() == input.transDefID.ToString());
            if (Common.IsTransitionAttributeExistsByAttName("AppointmentDefinitionAttribute", transDef))
                return true;
            if (Common.IsTransitionAttributeExistsByAttName("PlanPlannedActionAttribute", transDef))
                return true;
            if (Common.IsTransitionAttributeExistsByAttName("SplitBySubActionProcedureAppointmentAttribute", transDef))
                return true;
            return false;
        }

        public class IsStateAttributeExists_Input
        {
            public System.Type AttributeType
            {
                get;
                set;
            }

            public TTDefinitionManagement.TTObjectStateDef stateDef
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsStateAttributeExists(IsStateAttributeExists_Input input)
        {
            var ret = Common.IsStateAttributeExists(input.AttributeType, input.stateDef);
            return ret;
        }

        public class IsStateAttributeExistsByAttName_Input
        {
            public string AttributeName
            {
                get;
                set;
            }

            public TTDefinitionManagement.TTObjectStateDef stateDef
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsStateAttributeExistsByAttName(IsStateAttributeExistsByAttName_Input input)
        {
            var ret = Common.IsStateAttributeExistsByAttName(input.AttributeName, input.stateDef);
            return ret;
        }

        public class GetUserTitleEnumByValue_Input
        {
            public int value
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.UserTitleEnum GetUserTitleEnumByValue(GetUserTitleEnumByValue_Input input)
        {
            var ret = Common.GetUserTitleEnumByValue(input.value);
            return ret;
        }

        public class GetUserTypeEnumByValue_Input
        {
            public int value
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.UserTypeEnum GetUserTypeEnumByValue(GetUserTypeEnumByValue_Input input)
        {
            var ret = Common.GetUserTypeEnumByValue(input.value);
            return ret;
        }

        public class GetUserTypeEnumValueDefByValue_Input
        {
            public int value
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTDataDictionary.EnumValueDef GetUserTypeEnumValueDefByValue(GetUserTypeEnumValueDefByValue_Input input)
        {
            var ret = Common.GetUserTypeEnumValueDefByValue(input.value);
            return ret;
        }

        [HttpPost]
        public int GetNumberOfEmptyBedsV2()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.GetNumberOfEmptyBedsV2(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetNumberOfEmptyBedsV3_Input
        {
            public bool withoutIntensiveCareBeds
            {
                get;
                set;
            }
        }

        [HttpPost]
        public int GetNumberOfEmptyBedsV3(GetNumberOfEmptyBedsV3_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.GetNumberOfEmptyBedsV3(objectContext, input.withoutIntensiveCareBeds);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetNumberOfEmptyBeds_Input
        {
            public System.Guid ward
            {
                get;
                set;
            }
        }

        [HttpPost]
        public int GetNumberOfEmptyBeds(GetNumberOfEmptyBeds_Input input)
        {
            var ret = Common.GetNumberOfEmptyBeds(input.ward);
            return ret;
        }

        [HttpPost]
        public TTObjectClasses.ResBed GetFirstfEmptyBed()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.GetFirstfEmptyBed();
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetFirstfEmptyBedV2_Input
        {
            public System.Guid ward
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.ResBed GetFirstfEmptyBedV2(GetFirstfEmptyBedV2_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.GetFirstfEmptyBedV2(input.ward);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetFirstfEmptyBedV3_Input
        {
            public System.Guid ward
            {
                get;
                set;
            }

            public System.Guid roomGroup
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.ResBed GetFirstfEmptyBedV3(GetFirstfEmptyBedV3_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.GetFirstfEmptyBedV3(input.ward, input.roomGroup);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetFirstfEmptyBedV4_Input
        {
            public System.Guid ward
            {
                get;
                set;
            }

            public System.Guid roomGroup
            {
                get;
                set;
            }

            public System.Guid room
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.ResBed GetFirstfEmptyBedV4(GetFirstfEmptyBedV4_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.GetFirstfEmptyBedV4(input.ward, input.roomGroup, input.room);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class IsMilitaryPersonnel_Input
        {
            public TTObjectClasses.PatientGroupEnum patientGroupEnum
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsMilitaryPersonnel(IsMilitaryPersonnel_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.IsMilitaryPersonnel(objectContext, input.patientGroupEnum);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public void PeriodicCancelUnacceptedInpatientAdmissions()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Common.PeriodicCancelUnacceptedInpatientAdmissions(objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        [HttpPost]
        public void PeriodicCancelOldUnCompletedEAs()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Common.PeriodicCancelOldUnCompletedEAs(objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        [HttpPost]
        public void PeriodicCloseToNewOldEpisodes()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Common.PeriodicCloseToNewOldEpisodes(objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        [HttpPost]
        public string GetCurrentUserComputerName()
        {
            var ret = Common.GetCurrentUserComputerName();
            return ret;
        }

        [HttpPost]
        public string GetCurrentWindowsUserName()
        {
            var ret = Common.GetCurrentWindowsUserName();
            return ret;
        }

        public class GetObjectDefByPatientGroup_Input
        {
            public TTObjectClasses.PatientGroupEnum? patientGroupEnum
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTDefinitionManagement.TTObjectDef GetObjectDefByPatientGroup(GetObjectDefByPatientGroup_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.GetObjectDefByPatientGroup(objectContext, input.patientGroupEnum);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetObjectDefByActionType_Input
        {
            public TTObjectClasses.ActionTypeEnum actionType
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTDefinitionManagement.TTObjectDef GetObjectDefByActionType(GetObjectDefByActionType_Input input)
        {
            var ret = Common.GetObjectDefByActionType(input.actionType);
            return ret;
        }

        public class GetDisplayTextOfDataTypeEnum_Input
        {
            public System.Enum enumValue
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetDisplayTextOfDataTypeEnum(GetDisplayTextOfDataTypeEnum_Input input)
        {
            var ret = Common.GetDisplayTextOfDataTypeEnum(input.enumValue);
            return ret;
        }

        public class GetDisplayTextOfEnumValue_Input
        {
            public string name
            {
                get;
                set;
            }

            public int value
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetDisplayTextOfEnumValue(GetDisplayTextOfEnumValue_Input input)
        {
            var ret = Common.GetDisplayTextOfEnumValue(input.name, input.value);
            return ret;
        }

        public class GetDescriptionOfDataTypeEnum_Input
        {
            public System.Enum enumValue
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetDescriptionOfDataTypeEnum(GetDescriptionOfDataTypeEnum_Input input)
        {
            var ret = Common.GetDescriptionOfDataTypeEnum(input.enumValue);
            return ret;
        }

        public class GetEnumValueDefOfEnumValue_Input
        {
            public System.Enum enumValue
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTDataDictionary.EnumValueDef GetEnumValueDefOfEnumValue(GetEnumValueDefOfEnumValue_Input input)
        {
            var ret = Common.GetEnumValueDefOfEnumValue(input.enumValue);
            return ret;
        }

        public class GetEnumValueDefOfEnumValueV2_Input
        {
            public string name
            {
                get;
                set;
            }

            public int value
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTDataDictionary.EnumValueDef GetEnumValueDefOfEnumValueV2(GetEnumValueDefOfEnumValueV2_Input input)
        {
            var ret = Common.GetEnumValueDefOfEnumValueV2(input.name, input.value);
            return ret;
        }

        public class ConvertHourToString_Input
        {
            public int hour
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string ConvertHourToString(ConvertHourToString_Input input)
        {
            var ret = Common.ConvertHourToString(input.hour);
            return ret;
        }

        public class CUCase_Input
        {
            public string s
            {
                get;
                set;
            }

            public bool saveTurkish
            {
                get;
                set;
            }

            public bool alphaOnly
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string CUCase(CUCase_Input input)
        {
            var ret = Common.CUCase(input.s, input.saveTurkish, input.alphaOnly);
            return ret;
        }

        public class Tokenize_Input
        {
            public string s
            {
                get;
                set;
            }

            public bool wildCard
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.ArrayList Tokenize(Tokenize_Input input)
        {
            var ret = Common.Tokenize(input.s, input.wildCard);
            return ret;
        }

        public class IsNumeric_Input
        {
            public string s
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsNumeric(IsNumeric_Input input)
        {
            var ret = Common.IsNumeric(input.s);
            return ret;
        }

        public class TTObjectStatus_Input
        {
            public TTInstanceManagement.TTObject ob
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string TTObjectStatus(TTObjectStatus_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(input.ob);
                var ret = Common.TTObjectStatus(input.ob);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTextOfRTFString_Input
        {
            public string RtfString
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetTextOfRTFString(GetTextOfRTFString_Input input)
        {
            var ret = Common.GetTextOfRTFString(input.RtfString);
            return ret;
        }

        public class GetRTFOfTextString_Input
        {
            public string TextString
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetRTFOfTextString(GetRTFOfTextString_Input input)
        {
            var ret = Common.GetRTFOfTextString(input.TextString);
            return ret;
        }

        public class ReturnObjectAsString_Input
        {
            public object obj
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string ReturnObjectAsString(ReturnObjectAsString_Input input)
        {
            var ret = Common.ReturnObjectAsString(input.obj);
            return ret;
        }

        [HttpPost]
        public string OldActionsStyles()
        {
            var ret = Common.OldActionsStyles();
            return ret;
        }

        public class FormatAsOldActionTitle_Input
        {
            public string value
            {
                get;
                set;
            }

            public string tdString
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string FormatAsOldActionTitle(FormatAsOldActionTitle_Input input)
        {
            var ret = Common.FormatAsOldActionTitle(input.value, input.tdString);
            return ret;
        }

        public class FormatAsOldActionTitleV2_Input
        {
            public string value
            {
                get;
                set;
            }

            public string tdString
            {
                get;
                set;
            }

            public bool autoWidth
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string FormatAsOldActionTitleV2(FormatAsOldActionTitleV2_Input input)
        {
            var ret = Common.FormatAsOldActionTitleV2(input.value, input.tdString, input.autoWidth);
            return ret;
        }

        public class FormatAsOldActionValue_Input
        {
            public string value
            {
                get;
                set;
            }

            public string tdString
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string FormatAsOldActionValue(FormatAsOldActionValue_Input input)
        {
            var ret = Common.FormatAsOldActionValue(input.value, input.tdString);
            return ret;
        }

        public class ParseString_Input
        {
            public string parseString
            {
                get;
                set;
            }

            public char item
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.ArrayList ParseString(ParseString_Input input)
        {
            var ret = Common.ParseString(input.parseString, input.item);
            return ret;
        }

        public class GetDescriptionOfDataTypeEnumV2_Input
        {
            public string name
            {
                get;
                set;
            }

            public int value
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetDescriptionOfDataTypeEnumV2(GetDescriptionOfDataTypeEnumV2_Input input)
        {
            var ret = Common.GetDescriptionOfDataTypeEnumV2(input.name, input.value);
            return ret;
        }

        [HttpPost]
        public System.ComponentModel.BindingList<TTObjectClasses.UserOption> GetAllSystemOptions()
        {
            var ret = Common.GetAllSystemOptions();
            return ret;
        }

        public class MergeRTFs_Input
        {
            public string RTF1
            {
                get;
                set;
            }

            public string RTF2
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string MergeRTFs(MergeRTFs_Input input)
        {
            var ret = Common.MergeRTFs(input.RTF1, input.RTF2);
            return ret;
        }

        [HttpPost]
        public void RemoveDeadScheduledTaskThreads()
        {
            Common.RemoveDeadScheduledTaskThreads();
        }

        public class RunTaskScript_Input
        {
            public object bs
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void RunTaskScript(RunTaskScript_Input input)
        {
            Common.RunTaskScript(input.bs);
        }

        [HttpPost]
        public void AutoScript()
        {
            Common.AutoScript();
        }

        public class CreateFilterExpressionOfGuidList_Input
        {
            public string filterExpression
            {
                get;
                set;
            }

            public string nqlAttribute
            {
                get;
                set;
            }

            public System.Collections.Generic.List<System.Guid> GuidList
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string CreateFilterExpressionOfGuidList(CreateFilterExpressionOfGuidList_Input input)
        {
            var ret = Common.CreateFilterExpressionOfGuidList(input.filterExpression, input.nqlAttribute, input.GuidList);
            return ret;
        }

        public class CheckProcedureDefinitionIsActive_Input
        {
            public TTObjectClasses.ProcedureDefinition procedureDefinition
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool CheckProcedureDefinitionIsActive(CheckProcedureDefinitionIsActive_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(input.procedureDefinition);
                var ret = Common.CheckProcedureDefinitionIsActive(input.procedureDefinition);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class IsBaseOfInheritedObject_Input
        {
            public TTDefinitionManagement.TTObjectDef inheritedObjectDef
            {
                get;
                set;
            }

            public TTDefinitionManagement.TTObjectDef baseObjectDef
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsBaseOfInheritedObject(IsBaseOfInheritedObject_Input input)
        {
            var ret = Common.IsBaseOfInheritedObject(input.inheritedObjectDef, input.baseObjectDef);
            return ret;
        }

        public class GetPatientGroupEnumByValue_Input
        {
            public int value
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.PatientGroupEnum GetPatientGroupEnumByValue(GetPatientGroupEnumByValue_Input input)
        {
            var ret = Common.GetPatientGroupEnumByValue(input.value);
            return ret;
        }

        public class GetLastDayOfMounth_Input
        {
            public System.DateTime date
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.DateTime GetLastDayOfMounth(GetLastDayOfMounth_Input input)
        {
            var ret = Common.GetLastDayOfMounth(input.date);
            return ret;
        }

        public class PrepareBarcode_Input
        {
            public string barcode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string PrepareBarcode(PrepareBarcode_Input input)
        {
            var ret = Common.PrepareBarcode(input.barcode);
            return ret;
        }

        public class LatinToRomen_Input
        {
            public int latinSayi
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string LatinToRomen(LatinToRomen_Input input)
        {
            var ret = Common.LatinToRomen(input.latinSayi);
            return ret;
        }

        [HttpPost]
        public TTObjectClasses.ExaminationQueueItem CallNextPatient()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ret = Common.CallNextPatient(objectContext, null, new Guid());
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetNextItemByQueue_Input
        {
            public TTObjectClasses.ExaminationQueueDefinition examinationQueueDef
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.ExaminationQueueItem GetNextItemByQueue(GetNextItemByQueue_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(input.examinationQueueDef);
                var ret = Common.GetNextItemByQueue(objectContext, input.examinationQueueDef);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetSortedQueueItems_Input
        {
            public TTObjectClasses.ExaminationQueueDefinition queue
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.Dictionary<System.Guid, TTObjectClasses.Common.SortedExaminationQueueItems> GetSortedQueueItems(GetSortedQueueItems_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                context.AddObject(input.queue);
                var ret = Common.GetSortedQueueItems(context, input.queue);
                context.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetSortedQueueItemsByQueueID_Input
        {
            public System.Guid queueID
            {
                get;
                set;
            }

            public bool includeCalleds
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetSortedQueueItemsByQueueID(GetSortedQueueItemsByQueueID_Input input)
        {
            var ret = Common.GetSortedQueueItemsByQueueID(input.queueID, input.includeCalleds);
            return ret;
        }

        public class GetSortedQueueItemsByArray_Input
        {
            public Guid currentResUserID
            {
                get;
                set;
            }

            public Guid outPatientResID
            {
                get;
                set;
            }

            public bool includeCalleds
            {
                get;
                set;
            }
        }

        public class ChangePasswordParam
        {
            public Guid userId
            {
                get;
                set;
            }

            public string oldPassword
            {
                get;
                set;
            }

            public string newPassword
            {
                get;
                set;
            }
            public string applyNewPassword
            {
                get;
                set;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool ChangePassword(ChangePasswordParam input)
        {
            if (input.newPassword != input.applyNewPassword)
                throw new TTException(TTUtils.CultureService.GetText("M26963", "Şifreler Eşleşmemektedir."));
            return TTUser.ChangeUserPassword(input.userId, input.oldPassword, input.newPassword);
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool ChangeKPSPassword(ChangePasswordParam input)
        {
            return ResUser.ChangeKPSPassword(input.userId, input.oldPassword, input.newPassword);
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public TTObjectClasses.Common.QueueItems GetSortedQueueItemsWithArray(GetSortedQueueItemsByArray_Input input)
        {
            Guid queueID = input.outPatientResID;
            TTObjectClasses.Common.QueueItems ret = new TTObjectClasses.Common.QueueItems();
            ret = Common.GetSortedQueue(queueID, input.includeCalleds);
            return ret;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public BindingList<ExaminationQueueDefinition> GetQueueDefinition(GetSortedQueueItemsByArray_Input input)
        {
            TTObjectContext context = new TTObjectContext(true);
            ResUser currentResUser = context.GetObject<ResUser>(input.currentResUserID);
            Resource outPatientRes = context.GetObject<Resource>(input.outPatientResID);
            BindingList<ExaminationQueueDefinition> queueList = TTObjectClasses.ResUser.MyActiveQueues(outPatientRes);
            return queueList;
        }

        public class ExaminationRetunClass
        {
            public ExaminationQueueItem examinationQueueItem
            {
                get;
                set;
            }

            public string RefNo
            {
                get;
                set;
            }

            public string FullName
            {
                get;
                set;
            }
        }

        public class ExaminationQueueDefinitionParamClass
        {
            public ExaminationQueueDefinition selectedQueue
            {
                get;
                set;
            }

            public Guid outResourceId
            {
                get;
                set;
            }

            public Guid currentResourceId
            {
                get;
                set;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ExaminationRetunClass SetQueue(ExaminationQueueDefinitionParamClass param)
        {
            TTObjectContext callPatientObjectContext = new TTObjectContext(false);
            bool resFound = false;
            Common.CurrentResource.SelectedQueue = param.selectedQueue;
            BindingList<Resource> queueWorkingResources = param.selectedQueue.GetWorkingResources(callPatientObjectContext);
            foreach (Resource workingResource in queueWorkingResources)
            {
                if (workingResource.ObjectID == TTObjectClasses.Common.CurrentResource.ObjectID)
                {
                    resFound = true;
                    break;
                }
            }

            if (!resFound)
            {
                QueueResourceWorkPlanDefinition queueResourceWorkPlanDefinition = (QueueResourceWorkPlanDefinition)callPatientObjectContext.CreateObject(typeof(QueueResourceWorkPlanDefinition).Name);
                queueResourceWorkPlanDefinition.IsActive = true;
                queueResourceWorkPlanDefinition.Queue = param.selectedQueue;
                queueResourceWorkPlanDefinition.Resource = TTObjectClasses.Common.CurrentResource;
                queueResourceWorkPlanDefinition.LastCallTime = TTObjectClasses.Common.RecTime();
                DateTime dateTime = TTObjectClasses.Common.RecTime();
                if (TTObjectClasses.SystemParameter.GetParameterValue("GETWORKINGRESOURCESBYMAXQUEUEDATE", "FALSE") != "FALSE")
                {
                    BindingList<QueueResourceWorkPlanDefinition.GetMaxWorkdateForQueue_Class> maxList = QueueResourceWorkPlanDefinition.GetMaxWorkdateForQueue(param.selectedQueue.ObjectID);
                    if (maxList.Count > 0)
                    {
                        if ((DateTime)maxList[0].Maxworkdate != null)
                            dateTime = (DateTime)maxList[0].Maxworkdate;
                    }
                }

                queueResourceWorkPlanDefinition.WorkDate = dateTime.Date;
                callPatientObjectContext.Save();
            }

            ExaminationQueueItem examinationQueueItem = null;
            ResSection currentResUser = callPatientObjectContext.GetObject<ResSection>(param.outResourceId);
            examinationQueueItem = TTObjectClasses.Common.CallNextPatient(callPatientObjectContext, currentResUser, param.currentResourceId);
            ExaminationRetunClass returnclass = new ExaminationRetunClass();
            returnclass.examinationQueueItem = examinationQueueItem;
            if (examinationQueueItem != null)
            {
                returnclass.FullName = examinationQueueItem.Patient.FullName;
                returnclass.RefNo = examinationQueueItem.Patient.RefNo;
            }

            return returnclass;
        }

        public class SetPatientStatusParam
        {
            public string result
            {
                get;
                set;
            }

            public ExaminationQueueItem examinationQueueItem
            {
                get;
                set;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string GetSystemParameterStatistics()
        {
            string returnValue = TTObjectClasses.SystemParameter.GetParameterValue("STATISTICURL", "http://X.X.X.X");

            return returnValue;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string GetSystemParameterDoctorPerformance()
        {
            string returnValue = TTObjectClasses.SystemParameter.GetParameterValue("DOCTORPERFORMANCEURL", "http://X.X.X.X:83");

            return returnValue;
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void SetPatientStatus(SetPatientStatusParam param)
        {
            TTObjectContext callPatientObjectContext = new TTObjectContext(false);
            ExaminationQueueItem queueItem = callPatientObjectContext.GetObject<ExaminationQueueItem>(param.examinationQueueItem.ObjectID);
            if (param.result == "G")
            {
                queueItem.CurrentStateDefID = ExaminationQueueItem.States.Completed;
                callPatientObjectContext.Save();
                //OpenPatientInfoForm(examinationQueueItem.Patient.ObjectID, examinationQueueItem.EpisodeAction.Episode.ObjectID);
            }
            else if (param.result == "E")
            {
                if (queueItem.CallCount == null)
                    queueItem.CallCount = 1;
                else
                    queueItem.CallCount++;
                if (queueItem.CallCount != null && queueItem.ExaminationQueueDefinition.RecallCount != null && queueItem.CallCount >= queueItem.ExaminationQueueDefinition.RecallCount)
                    queueItem.CurrentStateDefID = ExaminationQueueItem.States.Cancelled;
                else
                    queueItem.CurrentStateDefID = ExaminationQueueItem.States.Diverted;
                callPatientObjectContext.Save();
            }
        }

        public class CallNexttPatientParam
        {
            public Guid ObjectId
            {
                get;
                set;
            }
            public Guid outPatientResID
            {
                get;
                set;
            }
            public int OrderNo
            {
                get;
                set;
            }
            public string PatientCallDesc
            {
                get;
                set;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void CallSelectedPatient(CallNexttPatientParam param)
        {

            TTObjectContext callPatientObjectContext = new TTObjectContext(false);

            ExaminationQueueItem qItem = ExaminationQueueItem.GetByEpisodeAction(callPatientObjectContext, param.ObjectId).FirstOrDefault();

            if (qItem == null)
            {
                throw new Exception("Bu işlem için bir sıra nesnesi oluşturulmamıştır.");
            }
            else
            {
                if(qItem.CurrentStateDefID == ExaminationQueueItem.States.Completed || qItem.CurrentStateDefID == ExaminationQueueItem.States.Cancelled)
                    throw new Exception("Bu işlem için aktif bir sıra nesnesi bulunmamaktadır.");

                if(qItem.EpisodeAction.Episode.PatientStatus == PatientStatusEnum.Inpatient)
                {
                    string errInfo = "";
                    InpatientAdmission inpatientAdmission = qItem.EpisodeAction.Episode.InpatientAdmissions.Where(c => c.CurrentStateDefID == InpatientAdmission.States.ClinicProcedure).FirstOrDefault();
                    if(inpatientAdmission != null)
                    {
                        if (inpatientAdmission.PhysicalStateClinic != null && inpatientAdmission.Room != null && inpatientAdmission.Bed != null)
                            errInfo = "Hastanın Yattığı Servis: " + inpatientAdmission.PhysicalStateClinic.Name + ", Oda : " + inpatientAdmission.Room.Name + ", Yatak : " + inpatientAdmission.Bed.Name;
                    }
                        
                    throw new Exception("Yatan hastayı buradan çağıramazsınız. " + errInfo);
                }
                if (qItem.Priority == -1)
                {
                    if (qItem.CallCount == null)
                        qItem.CallCount = 1;
                    if (Common.RecTime().Subtract(qItem.CallTime.Value).Minutes < Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("ACILDETEKRARSIRAYAALMASURESI", "15")))
                        throw new Exception("Bu hasta zaten çağırılmış. Çağırılma sayısı : " + qItem.CallCount.ToString());
                    else
                    {
                        qItem.Priority = 5000;
                        callPatientObjectContext.Save();
                    }
                }

            }
            var ret = Common.GetSortedQueue(param.outPatientResID, false);
            for (int i = 0; i < ret.patient.Count; i++)
            {
                if (int.Parse(ret.patient[i].Priority) == -1)
                {
                    List<ExaminationQueueItem> firstPatrient = ExaminationQueueItem.GetByEpisodeAction(callPatientObjectContext, ret.patient[i].ObjectID).ToList();
                    if (firstPatrient.Count > 0)
                    {
                        if (firstPatrient[0].CurrentStateDefID != ExaminationQueueItem.States.Completed)
                        {
                            firstPatrient[0].Priority = 5000;
                            callPatientObjectContext.Save();
                        }
                        break;
                    }

                }
            }

            List<ExaminationQueueItem> queueItem = ExaminationQueueItem.GetByEpisodeAction(callPatientObjectContext, param.ObjectId).ToList();
            if (queueItem.Count > 0)
            {
                if (queueItem[0].CurrentStateDefID != ExaminationQueueItem.States.Completed)
                {
                    queueItem[0].Priority = -1;
                    queueItem[0].ExaminationQueueDefinition = Common.CurrentResource.SelectedQueue;
                    queueItem[0].Doctor = Common.CurrentResource;
                    queueItem[0].CallTime = Common.RecTime();
                    if (queueItem[0].CallCount == null)
                        queueItem[0].CallCount = 0;
                    queueItem[0].CallCount = queueItem[0].CallCount + 1;
                    queueItem[0].CurrentStateDefID = ExaminationQueueItem.States.Diverted;
                    if (String.IsNullOrEmpty(param.PatientCallDesc) != true)
                        queueItem[0].PriorityReason = param.PatientCallDesc;
                    else
                    {
                        if(queueItem[0].EpisodeAction != null && queueItem[0].EpisodeAction.SubEpisode != null && queueItem[0].EpisodeAction.SubEpisode.PatientAdmission != null)
                            queueItem[0].PriorityReason = (queueItem[0].EpisodeAction.SubEpisode.PatientAdmission.PriorityStatus == null) ? "" : queueItem[0].EpisodeAction.SubEpisode.PatientAdmission.PriorityStatus.Name;
                    }
                    callPatientObjectContext.Save();
                }
            }

            Common.SetLCDNotification(param.outPatientResID, null);
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void CallNexttPatient(GetSortedQueueItemsByArray_Input queeid)
        {
            TTObjectContext callPatientObjectContext = new TTObjectContext(false);
            Guid savePoint = callPatientObjectContext.BeginSavePoint();
            try
            {
                ExaminationQueueDefinition selectedQueue = null;
                if (TTObjectClasses.Common.CurrentResource.SelectedQueue == null)
                {
                    BindingList<ExaminationQueueDefinition> queueList = TTObjectClasses.Common.CurrentResource.MyActiveQueues();
                    if (queueList.Count == 1)
                        selectedQueue = queueList[0];
                    if (selectedQueue != null)
                    {
                        bool resFound = false;
                        BindingList<Resource> queueWorkingResources = selectedQueue.GetWorkingResources(callPatientObjectContext);
                        foreach (Resource workingResource in queueWorkingResources)
                        {
                            if (workingResource.ObjectID == TTObjectClasses.Common.CurrentResource.ObjectID)
                            {
                                resFound = true;
                                break;
                            }
                        }

                        if (!resFound)
                        {
                            QueueResourceWorkPlanDefinition queueResourceWorkPlanDefinition = (QueueResourceWorkPlanDefinition)callPatientObjectContext.CreateObject(typeof(QueueResourceWorkPlanDefinition).Name);
                            queueResourceWorkPlanDefinition.IsActive = true;
                            queueResourceWorkPlanDefinition.Queue = selectedQueue;
                            queueResourceWorkPlanDefinition.Resource = TTObjectClasses.Common.CurrentResource;
                            queueResourceWorkPlanDefinition.LastCallTime = TTObjectClasses.Common.RecTime();
                            DateTime dateTime = TTObjectClasses.Common.RecTime();
                            if (TTObjectClasses.SystemParameter.GetParameterValue("GETWORKINGRESOURCESBYMAXQUEUEDATE", "FALSE") != "FALSE")
                            {
                                BindingList<QueueResourceWorkPlanDefinition.GetMaxWorkdateForQueue_Class> maxList = QueueResourceWorkPlanDefinition.GetMaxWorkdateForQueue(selectedQueue.ObjectID);
                                if (maxList.Count > 0)
                                {
                                    if ((DateTime)maxList[0].Maxworkdate != null)
                                        dateTime = (DateTime)maxList[0].Maxworkdate;
                                }
                            }

                            queueResourceWorkPlanDefinition.WorkDate = dateTime.Date;
                            callPatientObjectContext.Save();
                        }
                    }
                }

                ExaminationQueueItem examinationQueueItem = null;
                examinationQueueItem = TTObjectClasses.Common.CallNextPatient(callPatientObjectContext, null, new Guid());
                string result = "";
                if (examinationQueueItem != null)
                {
                    foreach (QueueResourceWorkPlanDefinition qr in TTObjectClasses.Common.CurrentResource.SelectedQueue.QueueResourceDef)
                    {
                        if (qr.Resource.ObjectID == TTObjectClasses.Common.CurrentResource.ObjectID && (Convert.ToDateTime(qr.WorkDate.Value)).Date == TTObjectClasses.Common.RecTime().Date)
                        {
                            QueueResourceWorkPlanDefinition uq = (QueueResourceWorkPlanDefinition)callPatientObjectContext.GetObject(qr.ObjectID, qr.ObjectDef, false);
                            if (uq != null)
                                uq.LastCallTime = TTObjectClasses.Common.RecTime();
                        }
                    }

                    callPatientObjectContext.Save();
                    while (result == "")
                    {
                        long nextItemsCount;
                        if (examinationQueueItem.NextItemsCount.HasValue == true)
                        {
                            nextItemsCount = examinationQueueItem.NextItemsCount.Value;
                            //result = ShowBox.Show(ShowBoxTypeEnum.Message, "Hasta Geldi,Ertele", "G,E", "Sıradaki Hasta", "Sıradaki Hasta", examinationQueueItem.Patient.RefNo + " " + examinationQueueItem.Patient.FullName + "\r\n\r\nKalan Hasta Sayısı : " + nextItemsCount.ToString(), 1);
                        }
                        else //result = ShowBox.Show(ShowBoxTypeEnum.Message, "Hasta Geldi,Ertele", "G,E", "Sıradaki Hasta", "Sıradaki Hasta", examinationQueueItem.Patient.RefNo + " " + examinationQueueItem.Patient.FullName, 1);
 if (result == "G")
                        {
                            examinationQueueItem.CurrentStateDefID = ExaminationQueueItem.States.Completed;
                            callPatientObjectContext.Save();
                            //OpenPatientInfoForm(examinationQueueItem.Patient.ObjectID, examinationQueueItem.EpisodeAction.Episode.ObjectID);
                        }
                        else if (result == "E")
                        {
                            if (examinationQueueItem.CallCount == null)
                                examinationQueueItem.CallCount = 1;
                            else
                                examinationQueueItem.CallCount++;
                            if (examinationQueueItem.CallCount != null && examinationQueueItem.ExaminationQueueDefinition.RecallCount != null && examinationQueueItem.CallCount >= examinationQueueItem.ExaminationQueueDefinition.RecallCount)
                                examinationQueueItem.CurrentStateDefID = ExaminationQueueItem.States.Cancelled;
                            else
                                examinationQueueItem.CurrentStateDefID = ExaminationQueueItem.States.Diverted;
                            callPatientObjectContext.Save();
                        }
                    }
                }
                else
                {
                    // result = ShowBox.Show(ShowBoxTypeEnum.Message, "Evet,Hayır", "E,H", "Hasta Çağrı Sistemi", "Hasta Çağrı Sistemi", "Kuyrukta hasta kalmadı. Başka bir kuyruktan hasta seçmek ister misiniz?", 1);
                    if (result == "E")
                    {
                        bool qMSFormHasItems = false;
                        foreach (ExaminationQueueDefinition queue in (TTObjectClasses.Common.CurrentResource.SelectedQueue.ResSection).ExaminationQueueDefinitions)
                        {
                            long? currentItemsCountDocIsNull = 0;
                            currentItemsCountDocIsNull = queue.CurrentItemsCountDocIsNull;
                            if (currentItemsCountDocIsNull > 0)
                            {
                                qMSFormHasItems = true;
                            }
                        }

                        if (qMSFormHasItems == true)
                        {
                            string qKey = "";
                            if (!string.IsNullOrEmpty(qKey))
                            {
                                ExaminationQueueDefinition tempQueue = (TTObjectClasses.Common.CurrentResource.SelectedQueue.ResSection).ExaminationQueueDefinitions[0];
                                ExaminationQueueItem tempQueueItem = null;
                                tempQueueItem = TTObjectClasses.Common.GetNextItemByQueue(callPatientObjectContext, tempQueue);
                                if (tempQueueItem != null)
                                {
                                    callPatientObjectContext.Save();
                                    CallNextPatient();
                                }
                                else
                                    throw new TTException(TTUtils.CultureService.GetText("M26815", "Seçilen kuyrukta çalışan bir kaynak bulunamadı."));
                            }
                            else
                                throw new TTException(TTUtils.CultureService.GetText("M26217", "İşlemden vazgeçildi."));
                        }
                        else
                            throw new TTException(TTUtils.CultureService.GetText("M27140", "Uygun bir kuyruk bulunamadı. Tüm kuyruklar tükenmiş ya da kuyruklardaki hastalar için doktor seçilmiş olabilir."));
                    }
                    //else
                    //    throw new TTException("Sıradaki hasta bulunamadı ya da sıra tükendi.");
                }
            }
            catch (TTStorageManager.TTConcurrencyException)
            {
                CallNexttPatient(queeid);
            }
            catch (TTException ex)
            {
                callPatientObjectContext.RollbackSavePoint(savePoint);
                //InfoBox.Show(ex);
            }
            finally
            {
                callPatientObjectContext.Dispose();
            }
        }

        public class GetSortedQueueItemsV2_Input
        {
            public TTObjectClasses.ExaminationQueueDefinition queue
            {
                get;
                set;
            }

            public bool includeCalleds
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.Dictionary<System.Guid, TTObjectClasses.Common.SortedExaminationQueueItems> GetSortedQueueItemsV2(GetSortedQueueItemsV2_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                context.AddObject(input.queue);
                var ret = Common.GetSortedQueueItemsV2(context, input.queue, input.includeCalleds);
                context.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class IsCurrentUserReferredToTheResource_Input
        {
            public TTObjectClasses.Resource resource
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsCurrentUserReferredToTheResource(IsCurrentUserReferredToTheResource_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(input.resource);
                var ret = Common.IsCurrentUserReferredToTheResource(input.resource);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class SetDentalPosition_Input
        {
            public int toothnumber
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.DentalPositionEnum SetDentalPosition(SetDentalPosition_Input input)
        {
            var ret = Common.SetDentalPosition(input.toothnumber);
            return ret;
        }

        public class OverridePrintRoles_Input
        {
            public TTStorageManager.Security.TTUser ttUser
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool OverridePrintRoles(OverridePrintRoles_Input input)
        {
            var ret = Common.OverridePrintRoles(input.ttUser);
            return ret;
        }

        public class FindDueDate_Input
        {
            public int WorkDayCount
            {
                get;
                set;
            }

            public System.DateTime startDate
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.DateTime FindDueDate(FindDueDate_Input input)
        {
            var ret = Common.FindDueDate(input.WorkDayCount, input.startDate);
            return ret;
        }

        public class CheckMernisNumber_Input
        {
            public long uniqueRefNo
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool CheckMernisNumber(CheckMernisNumber_Input input)
        {
            var ret = Common.CheckMernisNumber(input.uniqueRefNo);
            return ret;
        }

        public class DiagnosesForMedula_Input
        {
            public System.Collections.Generic.List<string> diagnoseList
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<string> DiagnosesForMedula(DiagnosesForMedula_Input input)
        {
            var ret = Common.DiagnosesForMedula(input.diagnoseList);
            return ret;
        }

        public class GetDoctorRegisterNoByBranchCode_Input
        {
            public string branchCode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetDoctorRegisterNoByBranchCode(GetDoctorRegisterNoByBranchCode_Input input)
        {
            var ret = Common.GetDoctorRegisterNoByBranchCode(input.branchCode);
            return ret;
        }

        public class GetSaglikTesisleri_Input
        {
            public string tesisKodu
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetSaglikTesisleri(GetSaglikTesisleri_Input input)
        {
            var ret = Common.GetSaglikTesisleri(input.tesisKodu);
            return ret;
        }

        public class IsSubEpisodeNeeded_Input
        {
            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }

            public string[] bransKodlari
            {
                get;
                set;
            }

            public string tedaviTipi
            {
                get;
                set;
            }

            public string tedaviTuru
            {
                get;
                set;
            }
        }

        public class IsDental_Input
        {
            public string bransKodu
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsDental(IsDental_Input input)
        {
            var ret = Common.IsDental(input.bransKodu);
            return ret;
        }

        [HttpPost]
        public void SaveUserMessageForUndefinedDiagnosis()
        {
            Common.SaveUserMessageForUndefinedDiagnosis();
        }

        public class IsLastDayExamination_Input
        {
            public System.DateTime examinationDate
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsLastDayExamination(IsLastDayExamination_Input input)
        {
            var ret = Common.IsLastDayExamination(input.examinationDate);
            return ret;
        }

        public class CheckWorklistDayLimit_Input
        {
            public System.DateTime dtStart
            {
                get;
                set;
            }

            public System.DateTime dtEnd
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void CheckWorklistDayLimit(CheckWorklistDayLimit_Input input)
        {
            Common.CheckWorklistDayLimit(input.dtStart, input.dtEnd);
        }

        public class SerializeObjectToXml_Input
        {
            public object instance
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string SerializeObjectToXml(SerializeObjectToXml_Input input)
        {
            var ret = Common.SerializeObjectToXml(input.instance);
            return ret;
        }

        public class PatientSearch_Input
        {
            public string searchString
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.IList PatientSearch(PatientSearch_Input input)
        {
            var ret = Patient.Search(input.searchString)?.FoundList;
            return ret;
        }

        public class LCDNotification_Input
        {
            public Guid queueID
            {
                get;
                set;
            }

            public LCDNotificationDefinition lcdNotification
            {
                get;
                set;
            }

            public Guid drObjectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SetLCDNotification(LCDNotification_Input input)
        {
            Common.SetLCDNotification(input.queueID,input.lcdNotification);
        }

        [HttpPost]
        public LCDNotificationDefinition GetLCDNotification(LCDNotification_Input input)
        {
            return Common.GetLCDNotification(input.queueID, input.drObjectID);
        }

        public class CalculateAge_Input
        {
            public System.DateTime birthDate
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.Common.Age CalculateAge(CalculateAge_Input input)
        {
            var ret = Common.CalculateAge(input.birthDate);
            return ret;
        }

        public class CalculateBMI_Input
        {
            public double weight
            {
                get;
                set;
            }

            public double height
            {
                get;
                set;
            }
        }

        [HttpPost]
        public double CalculateBMI(CalculateBMI_Input input)
        {
            var ret = Common.CalculateBMI(input.weight, input.height);
            return ret;
        }

        public class CalculateBodySurfaceArea_Input
        {
            public double weight
            {
                get;
                set;
            }

            public double height
            {
                get;
                set;
            }
        }

        [HttpPost]
        public double CalculateBodySurfaceArea(CalculateBodySurfaceArea_Input input)
        {
            var ret = Common.CalculateBodySurfaceArea(input.weight, input.height);
            return ret;
        }

        public class PatientAdmissionInfo_Input
        {
            public TTObjectClasses.Patient patient
            {
                get;
                set;
            }

            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }
        }

        private static String HexConverter(Color c)
        {
            //return "#" + c.R.ToString("x2") + c.G.ToString("x2") + c.B.ToString("x2");
            return String.Format("#{0:X6}", c.ToArgb() & 0x00FFFFFF);
        }

        private static String RGBConverter(Color c)
        {
            //return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
            return String.Format("RGB({0},{1},{2})", c.R, c.G, c.B);
        }

        public static string GetRandomLightColor()
        {
            Color c = RandomColor.GetColor(ColorScheme.Random, Luminosity.Light);
            string hexCode = HexConverter(c);
            return hexCode;
        }

        public static string[] Colours = new[] { "#DFF3BB", "#FFEFC5", "#E6E6E6", "#FFE6D3", "#D2EDF1", "#F8DFF0", "#EAE2D4", "#F9C2C2", "#DFF3BB", "#FFE6D3", "#E6E6E6", "#FFEFC5", "#D2EDF1" };
        public static string GetRandomSpecificColor()
        {
            string color = "";
            if (Colours.Length > 0)
            {
                color = Colours.RandomElement();
                Colours = Colours.Where(val => val != color).ToArray();
                return color;
            }
            else
            {
                Colours = new[] { "#DFF3BB", "#FFEFC5", "#E6E1E6", "#FFE6D3", "#D2HDF1", "#F8DFF0", "#EAE2D4", "#F9C2C2", "#DFF3CB", "#FFE6D3", "#E6G6E6", "#FFAFC5", "#D2EDF1" };
                color = Colours.RandomElement();
                Colours = Colours.Where(val => val != color).ToArray();
                return color;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public static string GetRandomSpecificColor(int index)
        {
            string color = "";
            color = Colours[index % Colours.Length];
            return color;
        }

        public enum ColorScheme
        {
            /// <summary>
            /// Select randomly from among the other color schemes.
            /// </summary>
            Random,
            /// <summary>
            /// Generates only grayscale colors.
            /// </summary>
            Monochrome,
            /// <summary>
            /// Generates only red colors.
            /// </summary>
            Red,
            /// <summary>
            /// Generates only orange colors.
            /// </summary>
            Orange,
            /// <summary>
            /// Generates only yellow colors.
            /// </summary>
            Yellow,
            /// <summary>
            /// Generates only green colors.
            /// </summary>
            Green,
            /// <summary>
            /// Generates only blue colors.
            /// </summary>
            Blue,
            /// <summary>
            /// Generates only purple colors.
            /// </summary>
            Purple,
            /// <summary>
            /// Generates only pink colors.
            /// </summary>
            Pink
        }

        public enum Luminosity
        {
            /// <summary>
            /// Select randomly from among the other luminosities.
            /// </summary>
            Random,
            /// <summary>
            /// Generate dark colors.
            /// </summary>
            Dark,
            /// <summary>
            /// Generate light, pastel colors.
            /// </summary>
            Light,
            /// <summary>
            /// Generate vibrant colors.
            /// </summary>
            Bright,
        }

        public class Options
        {
            /// <summary>
            /// Gets or sets the color scheme to use when generating the color.
            /// </summary>
            public ColorScheme ColorScheme
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the luminosity range to use when generating the color.
            /// </summary>
            public Luminosity Luminosity
            {
                get;
                set;
            }

            /// <summary>
            /// Creates a new instance using default values.
            /// </summary>
            public Options()
            {
            }

            /// <summary>
            /// Creates a new instance with the given color scheme and luminosity range.
            /// </summary>
            /// <param name = "scheme">The color scheme to use when generating the color.</param>
            /// <param name = "luminosity">The luminosity range to use when generating the color.</param>
            public Options(ColorScheme scheme, Luminosity luminosity)
            {
                ColorScheme = scheme;
                Luminosity = luminosity;
            }
        }

        [DebuggerDisplay(@"\{{Lower},{Upper}\}")]
        internal class Range
        {
            public int Lower
            {
                get;
                set;
            }

            public int Upper
            {
                get;
                set;
            }

            public Range()
            {
            }

            public Range(int lower, int upper)
            {
                Lower = lower;
                Upper = upper;
            }

            /// <summary>
            /// Gets the lower range for an index of 0 and the upper for an index of 1.
            /// </summary>
            public int this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0:
                            return Lower;
                        case 1:
                            return Upper;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                set
                {
                    switch (index)
                    {
                        case 0:
                            Lower = value;
                            break;
                        case 1:
                            Upper = value;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            internal static Range ToRange(int[] range)
            {
                if (range == null)
                    return null;
                Debug.Assert(range.Length == 2);
                return new Range(range[0], range[1]);
            }
        }

        public static class RandomColor
        {
            private class DefinedColor
            {
                public Range HueRange
                {
                    get;
                    set;
                }

                public Point[] LowerBounds
                {
                    get;
                    set;
                }

                public Range SaturationRange
                {
                    get;
                    set;
                }

                public Range BrightnessRange
                {
                    get;
                    set;
                }
            }

            private static readonly Dictionary<ColorScheme, DefinedColor> ColorDictionary = new Dictionary<ColorScheme, DefinedColor>();
            private static readonly object LockObj = new object();
            private static Random _rng = new Random();
            static RandomColor()
            {
                // Populate the color dictionary
                LoadColorBounds();
            }

            /// <summary>
            /// Gets a new random color.
            /// </summary>
            /// <param name = "scheme">Which color schemed to use when generating the color.</param>
            /// <param name = "luminosity">The desired luminosity of the color.</param>
            public static Color GetColor(ColorScheme scheme, Luminosity luminosity)
            {
                int H, S, B;
                // First we pick a hue (H)
                H = PickHue(scheme);
                // Then use H to determine saturation (S)
                S = PickSaturation(H, luminosity, scheme);
                // Then use S and H to determine brightness (B).
                B = PickBrightness(H, S, luminosity);
                // Then we return the HSB color in the desired format
                return HsvToColor(H, S, B);
            }

            /// <summary>
            /// Generates multiple random colors.
            /// </summary>
            /// <param name = "scheme">Which color schemed to use when generating the color.</param>
            /// <param name = "luminosity">The desired luminosity of the color.</param>
            /// <param name = "count">How many colors to generate</param>
            public static Color[] GetColors(ColorScheme scheme, Luminosity luminosity, int count)
            {
                var ret = new Color[count];
                for (var i = 0; i < count; i++)
                {
                    ret[i] = GetColor(scheme, luminosity);
                }

                return ret;
            }

            /// <summary>
            /// Generate one color for each of the provided generator options.
            /// </summary>
            /// <param name = "options">List of options to use when creating colors.</param>
            public static Color[] GetColors(params Options[] options)
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));
                return options.Select(o => GetColor(o.ColorScheme, o.Luminosity)).ToArray();
            }

            /// <summary>
            /// Reseeds the random number generated.
            /// </summary>
            /// <param name = "seed">The number used to reseed the random number generator.</param>
            public static void Seed(int seed)
            {
                lock (LockObj)
                {
                    _rng = new Random(seed);
                }
            }

            /// <summary>
            /// Reseeds the random number generated.
            /// </summary>
            public static void Seed()
            {
                lock (LockObj)
                {
                    _rng = new Random();
                }
            }

            private static int PickHue(ColorScheme scheme)
            {
                var hueRange = GetHueRange(scheme);
                var hue = RandomWithin(hueRange);
                // Instead of storing red as two separate ranges,
                // we group them, using negative numbers
                if (hue < 0)
                    hue = 360 + hue;
                return hue;
            }

            private static int PickSaturation(int hue, Luminosity luminosity, ColorScheme scheme)
            {
                if (luminosity == Luminosity.Random)
                {
                    return RandomWithin(0, 100);
                }

                if (scheme == ColorScheme.Monochrome)
                {
                    return 0;
                }

                var saturationRange = GetColorInfo(hue).SaturationRange;
                var sMin = saturationRange.Lower;
                var sMax = saturationRange.Upper;
                switch (luminosity)
                {
                    case Luminosity.Bright:
                        sMin = 55;
                        break;
                    case Luminosity.Dark:
                        sMin = sMax - 10;
                        break;
                    case Luminosity.Light:
                        sMax = 55;
                        break;
                }

                return RandomWithin(sMin, sMax);
            }

            private static int PickBrightness(int H, int S, Luminosity luminosity)
            {
                var bMin = GetMinimumBrightness(H, S);
                var bMax = 100;
                switch (luminosity)
                {
                    case Luminosity.Dark:
                        bMax = bMin + 20;
                        break;
                    case Luminosity.Light:
                        bMin = (bMax + bMin) / 2;
                        break;
                    case Luminosity.Random:
                        bMin = 0;
                        bMax = 100;
                        break;
                }

                return RandomWithin(bMin, bMax);
            }

            private static int GetMinimumBrightness(int H, int S)
            {
                var lowerBounds = GetColorInfo(H).LowerBounds;
                for (var i = 0; i < lowerBounds.Length - 1; i++)
                {
                    var s1 = lowerBounds[i].X;
                    var v1 = lowerBounds[i].Y;
                    var s2 = lowerBounds[i + 1].X;
                    var v2 = lowerBounds[i + 1].Y;
                    if (S >= s1 && S <= s2)
                    {
                        var m = (v2 - v1) / (s2 - s1);
                        var b = v1 - m * s1;
                        return (int)(m * S + b);
                    }
                }

                return 0;
            }

            private static Range GetHueRange(ColorScheme colorInput)
            {
                DefinedColor color;
                if (ColorDictionary.TryGetValue(colorInput, out color))
                {
                    if (color.HueRange != null)
                    {
                        return color.HueRange;
                    }
                }

                return new Range(0, 360);
            }

            private static DefinedColor GetColorInfo(int hue)
            {
                // Maps red colors to make picking hue easier
                if (hue >= 334 && hue <= 360)
                {
                    hue -= 360;
                }

                var ret = ColorDictionary.FirstOrDefault(c => c.Value.HueRange != null && hue >= c.Value.HueRange[0] && hue <= c.Value.HueRange[1]);
                Debug.Assert(ret.Value != null);
                return ret.Value;
            }

            private static int RandomWithin(Range range)
            {
                return RandomWithin(range.Lower, range.Upper);
            }

            private static int RandomWithin(int lower, int upper)
            {
                lock (LockObj)
                {
                    return _rng.Next(lower, upper + 1);
                }
            }

            private static void DefineColor(ColorScheme scheme, int[] hueRange, int[,] lowerBounds)
            {
                int[][] jagged = new int[lowerBounds.GetLength(0)][];
                for (int i = 0; i < lowerBounds.GetLength(0); i++)
                {
                    jagged[i] = new int[lowerBounds.GetLength(1)];
                    for (int j = 0; j < lowerBounds.GetLength(1); j++)
                    {
                        jagged[i][j] = lowerBounds[i, j];
                    }
                }

                var sMin = jagged[0][0];
                var sMax = jagged[jagged.Length - 1][0];
                var bMin = jagged[jagged.Length - 1][1];
                var bMax = jagged[0][1];
                ColorDictionary[scheme] = new DefinedColor()
                { HueRange = Range.ToRange(hueRange), LowerBounds = jagged.Select(j => new Point(j[0], j[1])).ToArray(), SaturationRange = new Range(sMin, sMax), BrightnessRange = new Range(bMin, bMax) };
            }

            private static void LoadColorBounds()
            {
                DefineColor(ColorScheme.Monochrome, null, new[,] { { 0, 0 }, { 100, 0 } });
                DefineColor(ColorScheme.Red, new[] { -26, 18 }, new[,] { { 20, 100 }, { 30, 92 }, { 40, 89 }, { 50, 85 }, { 60, 78 }, { 70, 70 }, { 80, 60 }, { 90, 55 }, { 100, 50 } });
                DefineColor(ColorScheme.Orange, new[] { 19, 46 }, new[,] { { 20, 100 }, { 30, 93 }, { 40, 88 }, { 50, 86 }, { 60, 85 }, { 70, 70 }, { 100, 70 } });
                DefineColor(ColorScheme.Yellow, new[] { 47, 62 }, new[,] { { 25, 100 }, { 40, 94 }, { 50, 89 }, { 60, 86 }, { 70, 84 }, { 80, 82 }, { 90, 80 }, { 100, 75 } });
                DefineColor(ColorScheme.Green, new[] { 63, 178 }, new[,] { { 30, 100 }, { 40, 90 }, { 50, 85 }, { 60, 81 }, { 70, 74 }, { 80, 64 }, { 90, 50 }, { 100, 40 } });
                DefineColor(ColorScheme.Blue, new[] { 179, 257 }, new[,] { { 20, 100 }, { 30, 86 }, { 40, 80 }, { 50, 74 }, { 60, 60 }, { 70, 52 }, { 80, 44 }, { 90, 39 }, { 100, 35 } });
                DefineColor(ColorScheme.Purple, new[] { 258, 282 }, new[,] { { 20, 100 }, { 30, 87 }, { 40, 79 }, { 50, 70 }, { 60, 65 }, { 70, 59 }, { 80, 52 }, { 90, 45 }, { 100, 42 } });
                DefineColor(ColorScheme.Pink, new[] { 283, 334 }, new[,] { { 20, 100 }, { 30, 90 }, { 40, 86 }, { 60, 84 }, { 80, 80 }, { 90, 75 }, { 100, 73 } });
            }

            /// <summary>
            /// Converts hue, saturation, and lightness to a color.
            /// </summary>
            public static Color HsvToColor(int hue, int saturation, double value)
            {
                // this doesn't work for the values of 0 and 360
                // here's the hacky fix
                var h = Convert.ToDouble(hue);
                if (h == 0)
                {
                    h = 1;
                }

                if (h == 360)
                {
                    h = 359;
                }

                // Rebase the h,s,v values
                h = h / 360.0;
                var s = saturation / 100.0;
                var v = value / 100.0;
                var hInt = (int)Math.Floor(h * 6.0);
                var f = h * 6 - hInt;
                var p = v * (1 - s);
                var q = v * (1 - f * s);
                var t = v * (1 - (1 - f) * s);
                var r = 256.0;
                var g = 256.0;
                var b = 256.0;
                switch (hInt)
                {
                    case 0:
                        r = v;
                        g = t;
                        b = p;
                        break;
                    case 1:
                        r = q;
                        g = v;
                        b = p;
                        break;
                    case 2:
                        r = p;
                        g = v;
                        b = t;
                        break;
                    case 3:
                        r = p;
                        g = q;
                        b = v;
                        break;
                    case 4:
                        r = t;
                        g = p;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = p;
                        b = q;
                        break;
                }

                var c = Color.FromArgb(255, (byte)Math.Floor(r * 255.0), (byte)Math.Floor(g * 255.0), (byte)Math.Floor(b * 255.0));
                return c;
            }
        }

        public class PersonnelTakeOff_Input
        {
            public DateTime ControlDate { get; set; }
            public string ResuserID { get; set; }
        }

        //[HttpPost]
        //[AtlasRequiredRoles(TTRoleNames.Everyone)]
        //public bool PersonelIzinKontrol(string resUserID)
        //{
        //    using (var objectContext = new TTObjectContext(false))
        //    {
        //        return Common.PersonelIzinKontrol(resUserID,DateTime.Now, objectContext);
        //    }
        //}

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool PersonelIzinKontrol(CommonServiceController.PersonnelTakeOff_Input personnelTakeOff_Input)
        {
            //bool ControlPersonelIzin = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("CONTROLPERSONELIZIN", "TRUE"));

            //if (ControlPersonelIzin)
            //{
            using (var objectContext = new TTObjectContext(false))
            {
                return Common.PersonelIzinKontrol(personnelTakeOff_Input.ResuserID, personnelTakeOff_Input.ControlDate, objectContext);
            }
            //}
            //else
            //    return false;//izin kontrolü yapma
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void SaveUserBarcodeSettings(BarcodeSettingsViewModel barcodeModel)
        {
            ResUser myUser = Common.CurrentResource;
            myUser.SaveUserOptionValue(UserOptionType.UserBarcodeSettings, barcodeModel);
        }

        [HttpGet]
        public BarcodeSettingsViewModel GetUserBarcodeSettings()
        {
            BarcodeSettingsViewModel result = new BarcodeSettingsViewModel();
            ResUser myUser = Common.CurrentResource;
            UserOption myUserOption = myUser.GetUserOption(UserOptionType.UserBarcodeSettings);
            if (myUserOption == null || myUserOption.OptionValue == null)
            {
                result._Settings = new List<BarcodeSettings>();
            }
            else
            {
                result = ((BarcodeSettingsViewModel)myUserOption.OptionValue);

            }

            return result;
        }

        [HttpGet]
        public BarcodeSettings GetUserBarcodeSettingsByFunction(string fromFuntion)
        {
            BarcodeSettings result = new BarcodeSettings();
            ResUser myUser = Common.CurrentResource;
            UserOption myUserOption = myUser.GetUserOption(UserOptionType.UserBarcodeSettings);
            if (myUserOption != null && myUserOption.OptionValue != null)
            {
                BarcodeSettingsViewModel m = new BarcodeSettingsViewModel();
                m = ((BarcodeSettingsViewModel)myUserOption.OptionValue);
                if (m._Settings.Count == 0)
                    return null;
                foreach (BarcodeSettings item in m._Settings)
                {
                    if (fromFuntion == "printPatientBarcode" && item.BarcodeType == "Kabul Barkodu")
                    {
                        result = item;
                        break;
                    }
                    else if (fromFuntion == "printPatientBarcode" && item.BarcodeType == "Sonuç Barkodu")
                    {
                        result = item;
                        break;
                    }
                    else if ((fromFuntion == "printLaboratoryBarcode"|| fromFuntion == "printPeeLaboratoryBarcode") && item.BarcodeType == "Laboratuvar Barkodu")
                    {
                        result = item;
                        break;
                    }
                    else if ((fromFuntion == "printInpatientBarcode" || fromFuntion == "printInpatientTreatmentBarcode") && item.BarcodeType == "Yatan Hasta Barkodu")
                    {
                        result = item;
                        break;
                    }
                    else if (fromFuntion == "printInPatientWristBarcode" && item.BarcodeType == "Hasta Bilekliği")
                    {
                        result = item;
                        break;
                    }
                    else if (fromFuntion == "printArchiveBarcode" && item.BarcodeType == "Arşiv Barkodu")
                    {
                        result = item;
                        break;
                    }

                }
            }
            else
            {
                return null;
            }

            return result;
        }



        [Serializable]
        public class BarcodeSettingsViewModel
        {
            public List<BarcodeSettings> _Settings { get; set; }
        }
        [Serializable]
        public class BarcodeSettings
        {
            public string BarcodeType { get; set; }
            public string Printer { get; set; }
            public int BarcodeCount { get; set; }
        }

    }

    public static class ArrayExtensions
    {
        public static T RandomElement<T>(this IEnumerable<T> coll)
        {
            var rnd = new Random();
            return coll.ElementAt(rnd.Next(coll.Count()));
        }
    }
}