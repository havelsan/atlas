
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ResBed, LCDNotificationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { TTObject } from 'NebulaClient/StorageManager/InstanceManagement/TTObject';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { EnumValueDef } from 'app/NebulaClient/DataDictionary/EnumValueDef';
//import { EnumValueDef } from "../Utils/DefinitionDataInterfaces/ITTEnumValueDef";
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { UserResourceSelectionModel } from 'System/Models/UserResourceSelectionModel';
import { PersonnelTakeOff_Input } from 'Modules/Tibbi_Surec/Kayit_Kabul_Modulu/PatientAdmissionFormViewModel';

export class CommonService {

    public static async RecTime(): Promise<Date> {
        let url: string = '/api/CommonService/RecTime';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        let dateParseResult = DateUtil.parseISOLocal(result);
        return dateParseResult;
    }

    public static async openRaporOnayEkrani(): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'ReportApproveForm';
            componentInfo.ModuleName = 'HastaRaporlariModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/HastaRaporlariModule';

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Rapor Onay Ekranı";
            modalInfo.Width = 1000;
            modalInfo.Height = 600;
            modalInfo.IsShowCloseButton = true;
            modalInfo.fullScreen = true;

            let result = ServiceLocator.ModalService().create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                //that.getQuueuList();
            }).catch(err => {
                reject(err);
            });
        });


    }

    public static async openUserResourceSelectionView(): Promise<ModalActionResult> {
        return new Promise<ModalActionResult>((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'UserResourceSelectionView';
            componentInfo.ModuleName = 'UserResourceSelectionModule';
            componentInfo.ModulePath = '/app/System/UserResourceSelectionModule';

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M17898", "Kullanıcı Birim Değiştirme");
            modalInfo.Width = 400;
            modalInfo.Height = 280;
            modalInfo.IsShowCloseButton = false;
            let result = ServiceLocator.ModalService().create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public static async setIfSingleUserResources(): Promise<boolean> {
        let url: string = '/api/UserResourceSelection/setIfSingleUserResources';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<UserResourceSelectionModel>(url, input);

        try {
            if (result.OutPatientResourceList.length > 1 || result.InPatientResourceList.length > 1)
                return false;
            if (result.OutPatientResourceList.length == 1)
                ServiceLocator.ActiveUserService.SelectedOutPatientResource = result.SelectedOutPatientResource;
            if (result.InPatientResourceList.length == 1)
                ServiceLocator.ActiveUserService.SelectedInPatientResource = result.SelectedInPatientResource;
            if (result.InPatientResourceList.length == 1)
                ServiceLocator.ActiveUserService.SelectedSecMasterResource = result.SelectedSecMasterResource;

            if (ServiceLocator.ActiveUserService.SelectedOutPatientResource || ServiceLocator.ActiveUserService.SelectedInPatientResource) {
                ServiceLocator.ActiveUserService.SelectedQueue = result.SelectedQueue;
                return true;
            }

        } catch (e) {
            ServiceLocator.MessageService.showError("Hata : " + e);
        }
        return false;
    }



    /* public static async CallWebMethod(ns: string, methodName: string, paramters: Object[]): Promise<Object> {
         let url: string = "/api/CommonController/CallWebMethod";
         let input = { "ns": ns, "methodName": methodName, "paramters": paramters };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<Object>;
         return neResult.Result;
     }
     public static async CallWebMethod(ns: string, methodName: string, siteId: string, username: string, password: string, paramters: Object[]): Promise<Object> {
         let url: string = "/api/CommonController/CallWebMethod";
         let input = { "ns": ns, "methodName": methodName, "siteId": siteId, "username": username, "password": password, "paramters": paramters };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<Object>;
         return neResult.Result;
     }
     public static async CallWebMethod(ns: string, methodName: string, siteId: string, credential: IWebMethodCredential, paramters: Object[]): Promise<Object> {
         let url: string = "/api/CommonController/CallWebMethod";
         let input = { "ns": ns, "methodName": methodName, "siteId": siteId, "credential": credential, "paramters": paramters };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<Object>;
         return neResult.Result;
     }
     public static async CallWebMethod(header: IWebMethodCallHeader, credential: IWebMethodCredential, paramters: Object[]): Promise<Object> {
         let url: string = "/api/CommonController/CallWebMethod";
         let input = { "header": header, "credential": credential, "paramters": paramters };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<Object>;
         return neResult.Result;
     }
     public static async SaveDiagnosisInfo(obj: DiagnosisInfo): Promise<void> {
         let url: string = "/api/CommonController/SaveDiagnosisInfo";
         let input = { "obj": obj };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<void>;
         return neResult.Result;
     }
     public static async SaveLabResult(labResult: LabResultInfo): Promise<void> {
         let url: string = "/api/CommonController/SaveLabResult";
         let input = { "labResult": labResult };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<void>;
         return neResult.Result;
     }
     public static async SendPACSPrinterControlMessage(message: string): Promise<void> {
         let url: string = "/api/CommonController/SendPACSPrinterControlMessage";
         let input = { "message": message };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<void>;
         return neResult.Result;
     }
     public static async EliminateIllegalDate(date: Date): Promise<Date> {
         let url: string = "/api/CommonController/EliminateIllegalDate";
         let input = { "date": date };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<Date>;
         return neResult.Result;
     }
     public static async GetPersonelItem(uniqRefNo: number): Promise<PersonelItem> {
         let url: string = "/api/CommonController/GetPersonelItem";
         let input = { "uniqRefNo": uniqRefNo };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<PersonelItem>;
         return neResult.Result;
     }
     public static async SaveResUser(obj: CommonResUser): Promise<void> {
         let url: string = "/api/CommonController/SaveResUser";
         let input = { "obj": obj };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<void>;
         return neResult.Result;
     }
     public static async GetCurrentHospital(objectContext: TTObjectContext): Promise<ResHospital> {
         let url: string = "/api/CommonController/GetCurrentHospital";
         let input = { "objectContext": objectContext };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<ResHospital>;
         return neResult.Result;
     }
     public static async GetCurrentHospitalLogo(objectContext: TTObjectContext): Promise<HospitalEmblemDefinition> {
         let url: string = "/api/CommonController/GetCurrentHospitalLogo";
         let input = { "objectContext": objectContext };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<HospitalEmblemDefinition>;
         return neResult.Result;
     }
     public static async GetCurrentHospitalLogo(): Promise<string> {
         let url: string = "/api/CommonController/GetCurrentHospitalLogo";
         let input = {};
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<string>;
         return neResult.Result;
     }
     public static async GetCurrentMilitaryUnit(objContext: TTObjectContext): Promise<MilitaryUnit> {
         let url: string = "/api/CommonController/GetCurrentMilitaryUnit";
         let input = { "objContext": objContext };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<MilitaryUnit>;
         return neResult.Result;
     }
     public static async MinDateTime(): Promise<Date> {
         let url: string = "/api/CommonController/MinDateTime";
         let input = {};
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<Date>;
         return neResult.Result;
     }
     public static async SaveSystemOption(optionType: UserOptionType, value: string): Promise<void> {
         let url: string = "/api/CommonController/SaveSystemOption";
         let input = { "optionType": optionType, "value": value };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<void>;
         return neResult.Result;
     }
     public static async GetSystemOption(optionType: UserOptionType): Promise<UserOption> {
         let url: string = "/api/CommonController/GetSystemOption";
         let input = { "optionType": optionType };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<UserOption>;
         return neResult.Result;
     }
     public static async GetUserOptionValue(context: TTObjectContext, user: ResUser, optionType: UserOptionType): Promise<string> {
         let url: string = "/api/CommonController/GetUserOptionValue";
         let input = { "context": context, "user": user, "optionType": optionType };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<string>;
         return neResult.Result;
     }
     public static async CurrentResourceSpecialities(): Promise<Array<SpecialityDefinition>> {
         let url: string = "/api/CommonController/CurrentResourceSpecialities";
         let input = {};
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<Array<SpecialityDefinition>>;
         return neResult.Result;
     }
     public static async SortedDoubleItems(unSortedList: Hashtable): Promise<Array<TTDoubleSortableList>> {
         let url: string = "/api/CommonController/SortedDoubleItems";
         let input = { "unSortedList": unSortedList };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<Array<TTDoubleSortableList>>;
         return neResult.Result;
     }
     public static async SortedStringItems(unSortedList: Hashtable): Promise<Array<TTStringSortableList>> {
         let url: string = "/api/CommonController/SortedStringItems";
         let input = { "unSortedList": unSortedList };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<Array<TTStringSortableList>>;
         return neResult.Result;
     }
     public static async SortedDateItems(unSortedList: Hashtable): Promise<Array<TTDateSortableList>> {
         let url: string = "/api/CommonController/SortedDateItems";
         let input = { "unSortedList": unSortedList };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<Array<TTDateSortableList>>;
         return neResult.Result;
     }
     public static async DateDiff(dateIntervalEnum: DateIntervalEnum, Date1: Date, Date2: Date): Promise<number> {
         let url: string = "/api/CommonController/DateDiff";
         let input = { "dateIntervalEnum": dateIntervalEnum, "Date1": Date1, "Date2": Date2 };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<number>;
         return neResult.Result;
     }
     public static async DateDiff(dateIntervalEnum: DateIntervalEnum, Date1: Date, Date2: Date, abs: boolean): Promise<number> {
         let url: string = "/api/CommonController/DateDiff";
         let input = { "dateIntervalEnum": dateIntervalEnum, "Date1": Date1, "Date2": Date2, "abs": abs };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<number>;
         return neResult.Result;
     }
     public static async ArrayListToString(arrayList: Array<any>): Promise<string> {
         let url: string = "/api/CommonController/ArrayListToString";
         let input = { "arrayList": arrayList };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<string>;
         return neResult.Result;
     }
     public static async MainPatientGroupDefinitionByEnum(objectContext: TTObjectContext, mainPatientGroupEnum: MainPatientGroupEnum): Promise<MainPatientGroupDefinition> {
         let url: string = "/api/CommonController/MainPatientGroupDefinitionByEnum";
         let input = { "objectContext": objectContext, "mainPatientGroupEnum": mainPatientGroupEnum };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<MainPatientGroupDefinition>;
         return neResult.Result;
     }
     public static async PatientGroupDefinitionByEnum(objectContext: TTObjectContext, patientGroupEnum: PatientGroupEnum): Promise<PatientGroupDefinition> {
         let url: string = "/api/CommonController/PatientGroupDefinitionByEnum";
         let input = { "objectContext": objectContext, "patientGroupEnum": patientGroupEnum };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<PatientGroupDefinition>;
         return neResult.Result;
     }
     public static async ActiveMainPatientGroupDefinitionByEnum(objectContext: TTObjectContext, mainPatientGroupEnum: MainPatientGroupEnum): Promise<MainPatientGroupDefinition> {
         let url: string = "/api/CommonController/ActiveMainPatientGroupDefinitionByEnum";
         let input = { "objectContext": objectContext, "mainPatientGroupEnum": mainPatientGroupEnum };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<MainPatientGroupDefinition>;
         return neResult.Result;
     }
     public static async ActivePatientGroupDefinitionByEnum(objectContext: TTObjectContext, patientGroupEnum: PatientGroupEnum): Promise<PatientGroupDefinition> {
         let url: string = "/api/CommonController/ActivePatientGroupDefinitionByEnum";
         let input = { "objectContext": objectContext, "patientGroupEnum": patientGroupEnum };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<PatientGroupDefinition>;
         return neResult.Result;
     }
     public static async ReasonForExaminationByType(objectContext: TTObjectContext, reasonForExaminationType: ReasonForExaminationTypeEnum): Promise<ReasonForExaminationDefinition> {
         let url: string = "/api/CommonController/ReasonForExaminationByType";
         let input = { "objectContext": objectContext, "reasonForExaminationType": reasonForExaminationType };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<ReasonForExaminationDefinition>;
         return neResult.Result;
     }
     public static async ReasonForExaminationByCode(objectContext: TTObjectContext, Code: number): Promise<ReasonForExaminationDefinition> {
         let url: string = "/api/CommonController/ReasonForExaminationByCode";
         let input = { "objectContext": objectContext, "Code": Code };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<ReasonForExaminationDefinition>;
         return neResult.Result;
     }
     public static async IsPropertyExist(ttObject: TTObject, propertyName: string): Promise<boolean> {
         let url: string = "/api/CommonController/IsPropertyExist";
         let input = { "ttObject": ttObject, "propertyName": propertyName };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<boolean>;
         return neResult.Result;
     }
     public static async PropertyValue(ttObject: TTObject, propertyName: string): Promise<Object> {
         let url: string = "/api/CommonController/PropertyValue";
         let input = { "ttObject": ttObject, "propertyName": propertyName };
         let httpService: NeHttpService = ServiceLocator.NeHttpService;
         let response = await httpService.post(url, input);
         let neResult = await response.json() as NeResult<Object>;
         return neResult.Result;
     }*/

    public static async IsAttributeExists(atributeName: string, ttobject: TTObject): Promise<boolean> {
        let url: string = '/api/CommonService/IsAttributeExists';
        let input = { 'AttributeName': atributeName, 'ttobject': ttobject };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post<boolean>(url, input);
        return response;
    }

    public static async IsTransitionAttributeExistsByAttName(atributeName: string, transDef: TTObjectStateTransitionDef): Promise<boolean> {
        let url: string = '/api/CommonService/IsTransitionAttributeExistsByAttName';
        let input = { 'AttributeName': atributeName, 'transDef': transDef };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post<boolean>(url, input);
        return response;
    }

    public static async IsAppointmentTransitionAttributeExists(transDefID: Guid, ttobject: TTObject): Promise<boolean> {
        let url: string = '/api/CommonService/IsAppointmentTransitionAttributeExists';
        let input = { 'transDefID': transDefID, 'ttobject': ttobject };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post<boolean>(url, input);
        return response;
    }
    /*
    public static async IsAttributeExists(AttributeType: Type, ttobject: TTObject): Promise<boolean> {
        let url: string = "/api/CommonController/IsAttributeExists";
        let input = { "AttributeType": AttributeType, "ttobject": ttobject };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post<boolean>(url, input);
        return response;
    }
    public static async IsAttributeExists(AttributeType: Type, objectDef: TTObjectDef): Promise<boolean> {
        let url: string = "/api/CommonController/IsAttributeExists";
        let input = { "AttributeType": AttributeType, "objectDef": objectDef };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<boolean>;
        return neResult.Result;
    }
    public static async IsTransitionAttributeExists(AttributeType: Type, transDef: TTObjectStateTransitionDef): Promise<boolean> {
        let url: string = "/api/CommonController/IsTransitionAttributeExists";
        let input = { "AttributeType": AttributeType, "transDef": transDef };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<boolean>;
        return neResult.Result;
    }
    public static async IsStateAttributeExists(AttributeType: Type, stateDef: TTObjectStateDef): Promise<boolean> {
        let url: string = "/api/CommonController/IsStateAttributeExists";
        let input = { "AttributeType": AttributeType, "stateDef": stateDef };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<boolean>;
        return neResult.Result;
    }
    public static async GetUserTitleEnumByValue(value: number): Promise<UserTitleEnum> {
        let url: string = "/api/CommonController/GetUserTitleEnumByValue";
        let input = { "value": value };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<UserTitleEnum>;
        return neResult.Result;
    }
    public static async GetUserTypeEnumByValue(value: number): Promise<UserTypeEnum> {
        let url: string = "/api/CommonController/GetUserTypeEnumByValue";
        let input = { "value": value };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<UserTypeEnum>;
        return neResult.Result;
    }
    public static async GetUserTypeEnumValueDefByValue(value: number): Promise<EnumValueDef> {
        let url: string = "/api/CommonController/GetUserTypeEnumValueDefByValue";
        let input = { "value": value };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<EnumValueDef>;
        return neResult.Result;
    }
    public static async GetNumberOfEmptyBeds(objectContext: TTObjectContext): Promise<number> {
        let url: string = "/api/CommonController/GetNumberOfEmptyBeds";
        let input = { "objectContext": objectContext };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<number>;
        return neResult.Result;
    }
    public static async GetNumberOfEmptyBeds(objectContext: TTObjectContext, withoutIntensiveCareBeds: boolean): Promise<number> {
        let url: string = "/api/CommonController/GetNumberOfEmptyBeds";
        let input = { "objectContext": objectContext, "withoutIntensiveCareBeds": withoutIntensiveCareBeds };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<number>;
        return neResult.Result;
    }*/
    public static async GetNumberOfEmptyBeds(ward: Guid): Promise<number> {
        let url: string = '/api/CommonService/GetNumberOfEmptyBeds';
        let input = { 'ward': ward };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post<number>(url, input);
        return response;
    }
    public static async GetFirstfEmptyBedV2(ward: Guid): Promise<ResBed> {
        let url: string = '/api/CommonService/GetFirstfEmptyBedV2';
        let input = { 'ward': ward };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post<ResBed>(url, input);
        return response;
    }
    public static async GetFirstfEmptyBedV3(ward: Guid, roomGroup: Guid): Promise<ResBed> {
        let url: string = '/api/CommonService/GetFirstfEmptyBedV3';
        let input = { 'ward': ward, 'roomGroup': roomGroup };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post<ResBed>(url, input);
        return response;
    }
    public static async GetFirstfEmptyBedV4(ward: Guid, roomGroup: Guid, room: Guid): Promise<ResBed> {
        let url: string = '/api/CommonService/GetFirstfEmptyBedV4';
        let input = { 'ward': ward, 'roomGroup': roomGroup, 'room': room };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post<ResBed>(url, input);
        return response;
    }

    /*
        public static async GetFirstfEmptyBed(objectContext: TTObjectContext): Promise<ResBed> {
            let url: string = "/api/CommonController/GetFirstfEmptyBed";
            let input = { "objectContext": objectContext };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post(url, input);
            let neResult = await response.json() as NeResult<ResBed>;
            return neResult.Result;
        }
        public static async GetFirstfEmptyBed(objectContext: TTObjectContext, ward: Guid): Promise<ResBed> {
            let url: string = "/api/CommonController/GetFirstfEmptyBed";
            let input = { "objectContext": objectContext, "ward": ward };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post(url, input);
            let neResult = await response.json() as NeResult<ResBed>;
            return neResult.Result;
        }
        public static async GetFirstfEmptyBed(objectContext: TTObjectContext, ward: Guid, roomGroup: Guid): Promise<ResBed> {
            let url: string = "/api/CommonController/GetFirstfEmptyBed";
            let input = { "objectContext": objectContext, "ward": ward, "roomGroup": roomGroup };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post(url, input);
            let neResult = await response.json() as NeResult<ResBed>;
            return neResult.Result;
        }
        public static async GetFirstfEmptyBed(objectContext: TTObjectContext, ward: Guid, roomGroup: Guid, room: Guid): Promise<ResBed> {
            let url: string = "/api/CommonController/GetFirstfEmptyBed";
            let input = { "objectContext": objectContext, "ward": ward, "roomGroup": roomGroup, "room": room };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post(url, input);
            let neResult = await response.json() as NeResult<ResBed>;
            return neResult.Result;
        }
        public static async IsMilitaryPersonnel(objectContext: TTObjectContext, patientGroupEnum: PatientGroupEnum): Promise<boolean> {
            let url: string = "/api/CommonController/IsMilitaryPersonnel";
            let input = { "objectContext": objectContext, "patientGroupEnum": patientGroupEnum };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post(url, input);
            let neResult = await response.json() as NeResult<boolean>;
            return neResult.Result;
        }
        public static async PeriodicCancelUnacceptedInpatientAdmissions(objectContext: TTObjectContext): Promise<void> {
            let url: string = "/api/CommonController/PeriodicCancelUnacceptedInpatientAdmissions";
            let input = { "objectContext": objectContext };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post(url, input);
            let neResult = await response.json() as NeResult<void>;
            return neResult.Result;
        }
        public static async PeriodicCancelOldUnCompletedEAs(objectContext: TTObjectContext): Promise<void> {
            let url: string = "/api/CommonController/PeriodicCancelOldUnCompletedEAs";
            let input = { "objectContext": objectContext };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post(url, input);
            let neResult = await response.json() as NeResult<void>;
            return neResult.Result;
        }
        public static async PeriodicCloseToNewOldEpisodes(objectContext: TTObjectContext): Promise<void> {
            let url: string = "/api/CommonController/PeriodicCloseToNewOldEpisodes";
            let input = { "objectContext": objectContext };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post(url, input);
            let neResult = await response.json() as NeResult<void>;
            return neResult.Result;
        }
        public static async GetCurrentUserComputerName(): Promise<string> {
            let url: string = "/api/CommonController/GetCurrentUserComputerName";
            let input = {};
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post(url, input);
            let neResult = await response.json() as NeResult<string>;
            return neResult.Result;
        }
        public static async GetCurrentWindowsUserName(): Promise<string> {
            let url: string = "/api/CommonController/GetCurrentWindowsUserName";
            let input = {};
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post(url, input);
            let neResult = await response.json() as NeResult<string>;
            return neResult.Result;
        }
        public static async GetObjectDefByPatientGroup(objectContext: TTObjectContext, patientGroupEnum: PatientGroupEnum): Promise<TTObjectDef> {
            let url: string = "/api/CommonController/GetObjectDefByPatientGroup";
            let input = { "objectContext": objectContext, "patientGroupEnum": patientGroupEnum };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post(url, input);
            let neResult = await response.json() as NeResult<TTObjectDef>;
            return neResult.Result;
        }
        public static async GetObjectDefByActionType(actionType: ActionTypeEnum): Promise<TTObjectDef> {
            let url: string = "/api/CommonController/GetObjectDefByActionType";
            let input = { "actionType": actionType };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post(url, input);
            let neResult = await response.json() as NeResult<TTObjectDef>;
            return neResult.Result;
        }
        public static async GetDisplayTextOfDataTypeEnum(enumValue: Enum): Promise<string> {
            let url: string = "/api/CommonController/GetDisplayTextOfDataTypeEnum";
            let input = { "enumValue": enumValue };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post(url, input);
            let neResult = await response.json() as NeResult<string>;
            return neResult.Result;
        }
        public static async GetDisplayTextOfEnumValue(name: string, value: number): Promise<string> {
            let url: string = "/api/CommonController/GetDisplayTextOfEnumValue";
            let input = { "name": name, "value": value };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post(url, input);
            let neResult = await response.json() as NeResult<string>;
            return neResult.Result;
        }
        public static async GetDescriptionOfDataTypeEnum(enumValue: Enum): Promise<string> {
            let url: string = "/api/CommonController/GetDescriptionOfDataTypeEnum";
            let input = { "enumValue": enumValue };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post(url, input);
            let neResult = await response.json() as NeResult<string>;
            return neResult.Result;
        }*/


    public static async GetEnumValueDefOfEnumValue(enumValue: any): Promise<EnumValueDef> {
        let url: string = '/api/CommonService/GetEnumValueDefOfEnumValue';
        let input = { 'enumValue': enumValue };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post<EnumValueDef>(url, input);
        return response;
    }

    public static async GetEnumValueDefOfEnumValueV2(name: any, value: any): Promise<EnumValueDef> {
        let url: string = '/api/CommonService/GetEnumValueDefOfEnumValueV2';
        let input = { 'name': name, 'value': value };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post<EnumValueDef>(url, input);
        return response;
    }

    public static async GetDisplayTextOfEnumValue(name: any, value: any): Promise<string> {
        let url: string = '/api/CommonService/GetDisplayTextOfEnumValue';
        let input = { 'name': name, 'value': value };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post<string>(url, input);
        return response;
    }
    /*
    public static async GetEnumValueDefOfEnumValue(name: string, value: number): Promise<EnumValueDef> {
        let url: string = "/api/CommonController/GetEnumValueDefOfEnumValue";
        let input = { "name": name, "value": value };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<EnumValueDef>;
        return neResult.Result;
    }
    public static async ConvertHourToString(hour: number): Promise<string> {
        let url: string = "/api/CommonController/ConvertHourToString";
        let input = { "hour": hour };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }
    public static async CUCase(s: string, saveTurkish: boolean, alphaOnly: boolean): Promise<string> {
        let url: string = "/api/CommonController/CUCase";
        let input = { "s": s, "saveTurkish": saveTurkish, "alphaOnly": alphaOnly };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }
    public static async Tokenize(s: string, wildCard: boolean): Promise<Array<any>> {
        let url: string = "/api/CommonController/Tokenize";
        let input = { "s": s, "wildCard": wildCard };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<Array<any>>;
        return neResult.Result;
    }
    public static async IsNumeric(s: string): Promise<boolean> {
        let url: string = "/api/CommonController/IsNumeric";
        let input = { "s": s };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<boolean>;
        return neResult.Result;
    }
    public static async TTObjectStatus(ob: TTObject): Promise<string> {
        let url: string = "/api/CommonController/TTObjectStatus";
        let input = { "ob": ob };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    } */
    public static async GetTextOfRTFString(RtfString: string): Promise<string> {
        let url: string = '/api/CommonService/GetTextOfRTFString';
        let input = { 'RtfString': RtfString };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post<string>(url, input);
        return response;
    }
    /*
    public static async GetRTFOfTextString(TextString: string): Promise<string> {
        let url: string = "/api/CommonController/GetRTFOfTextString";
        let input = { "TextString": TextString };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }
    public static async ReturnObjectAsString(obj: Object): Promise<string> {
        let url: string = "/api/CommonController/ReturnObjectAsString";
        let input = { "obj": obj };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }
    public static async OldActionsStyles(): Promise<string> {
        let url: string = "/api/CommonController/OldActionsStyles";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }
    public static async FormatAsOldActionTitle(value: string, tdString: string): Promise<string> {
        let url: string = "/api/CommonController/FormatAsOldActionTitle";
        let input = { "value": value, "tdString": tdString };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }
    public static async FormatAsOldActionTitle(value: string, tdString: string, autoWidth: boolean): Promise<string> {
        let url: string = "/api/CommonController/FormatAsOldActionTitle";
        let input = { "value": value, "tdString": tdString, "autoWidth": autoWidth };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }
    public static async FormatAsOldActionValue(value: string, tdString: string): Promise<string> {
        let url: string = "/api/CommonController/FormatAsOldActionValue";
        let input = { "value": value, "tdString": tdString };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }
    public static async ParseString(parseString: string, item: string): Promise<Array<any>> {
        let url: string = "/api/CommonController/ParseString";
        let input = { "parseString": parseString, "item": item };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<Array<any>>;
        return neResult.Result;
    }
    public static async GetDescriptionOfDataTypeEnum(name: string, value: number): Promise<string> {
        let url: string = "/api/CommonController/GetDescriptionOfDataTypeEnum";
        let input = { "name": name, "value": value };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }
    public static async GetAllSystemOptions(): Promise<Array<UserOption>> {
        let url: string = "/api/CommonController/GetAllSystemOptions";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<Array<UserOption>>;
        return neResult.Result;
    }
    public static async MergeRTFs(RTF1: string, RTF2: string): Promise<string> {
        let url: string = "/api/CommonController/MergeRTFs";
        let input = { "RTF1": RTF1, "RTF2": RTF2 };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }
    public static async RemoveDeadScheduledTaskThreads(): Promise<void> {
        let url: string = "/api/CommonController/RemoveDeadScheduledTaskThreads";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<void>;
        return neResult.Result;
    }
    public static async RunTaskScript(bs: Object): Promise<void> {
        let url: string = "/api/CommonController/RunTaskScript";
        let input = { "bs": bs };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<void>;
        return neResult.Result;
    }
    public static async AutoScript(): Promise<void> {
        let url: string = "/api/CommonController/AutoScript";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<void>;
        return neResult.Result;
    }*/
    public static async CreateFilterExpressionOfGuidList(filterExpression: string, nqlAttribute: string, GuidList: Array<Guid>): Promise<string> {
        let url: string = '/api/CommonController/CreateFilterExpressionOfGuidList';
        let input = { 'filterExpression': filterExpression, 'nqlAttribute': nqlAttribute, 'GuidList': GuidList };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async CheckWorklistDayLimit(dtStart: Date, dtEnd: Date): Promise<void> {
        let url: string = '/api/CommonController/CheckWorklistDayLimit';
        let input = { 'dtStart': dtStart, 'dtEnd': dtEnd };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
/*
    public static async CheckProcedureDefinitionIsActive(procedureDefinition: ProcedureDefinition): Promise<boolean> {
        let url: string = "/api/CommonController/CheckProcedureDefinitionIsActive";
        let input = { "procedureDefinition": procedureDefinition };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<boolean>;
        return neResult.Result;
    }
    public static async IsBaseOfInheritedObject(inheritedObjectDef: TTObjectDef, baseObjectDef: TTObjectDef): Promise<boolean> {
        let url: string = "/api/CommonController/IsBaseOfInheritedObject";
        let input = { "inheritedObjectDef": inheritedObjectDef, "baseObjectDef": baseObjectDef };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<boolean>;
        return neResult.Result;
    }
    public static async GetPatientGroupEnumByValue(value: number): Promise<PatientGroupEnum> {
        let url: string = "/api/CommonController/GetPatientGroupEnumByValue";
        let input = { "value": value };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<PatientGroupEnum>;
        return neResult.Result;
    }
    public static async GetLastDayOfMounth(date: Date): Promise<Date> {
        let url: string = "/api/CommonController/GetLastDayOfMounth";
        let input = { "date": date };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<Date>;
        return neResult.Result;
    }
    public static async PrepareBarcode(barcode: string): Promise<string> {
        let url: string = "/api/CommonController/PrepareBarcode";
        let input = { "barcode": barcode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }
    public static async LatinToRomen(latinSayi: number): Promise<string> {
        let url: string = "/api/CommonController/LatinToRomen";
        let input = { "latinSayi": latinSayi };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }
    public static async CallNextPatient(objectContext: TTObjectContext): Promise<ExaminationQueueItem> {
        let url: string = "/api/CommonController/CallNextPatient";
        let input = { "objectContext": objectContext };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<ExaminationQueueItem>;
        return neResult.Result;
    }
    public static async GetNextItemByQueue(objectContext: TTObjectContext, examinationQueueDef: ExaminationQueueDefinition): Promise<ExaminationQueueItem> {
        let url: string = "/api/CommonController/GetNextItemByQueue";
        let input = { "objectContext": objectContext, "examinationQueueDef": examinationQueueDef };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<ExaminationQueueItem>;
        return neResult.Result;
    }
    public static async GetSortedQueueItems(context: TTObjectContext, queue: ExaminationQueueDefinition): Promise<Dictionary<Guid, SortedExaminationQueueItems>> {
        let url: string = "/api/CommonController/GetSortedQueueItems";
        let input = { "context": context, "queue": queue };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<Dictionary<Guid, SortedExaminationQueueItems>>;
        return neResult.Result;
    }
    public static async GetSortedQueueItemsByQueueID(queueID: Guid, includeCalleds: boolean): Promise<string> {
        let url: string = "/api/CommonController/GetSortedQueueItemsByQueueID";
        let input = { "queueID": queueID, "includeCalleds": includeCalleds };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }
    public static async GetSortedQueueItems(context: TTObjectContext, queue: ExaminationQueueDefinition, includeCalleds: boolean): Promise<Dictionary<Guid, SortedExaminationQueueItems>> {
        let url: string = "/api/CommonController/GetSortedQueueItems";
        let input = { "context": context, "queue": queue, "includeCalleds": includeCalleds };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<Dictionary<Guid, SortedExaminationQueueItems>>;
        return neResult.Result;
    }
    public static async IsCurrentUserReferredToTheResource(resource: Resource): Promise<boolean> {
        let url: string = "/api/CommonController/IsCurrentUserReferredToTheResource";
        let input = { "resource": resource };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<boolean>;
        return neResult.Result;
    }
    public static async SetDentalPosition(toothnumber: number): Promise<DentalPositionEnum> {
        let url: string = "/api/CommonController/SetDentalPosition";
        let input = { "toothnumber": toothnumber };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<DentalPositionEnum>;
        return neResult.Result;
    }
    public static async OverridePrintRoles(ttUser: TTUser): Promise<boolean> {
        let url: string = "/api/CommonController/OverridePrintRoles";
        let input = { "ttUser": ttUser };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<boolean>;
        return neResult.Result;
    }
    public static async FindDueDate(WorkDayCount: number, startDate: Date): Promise<Date> {
        let url: string = "/api/CommonController/FindDueDate";
        let input = { "WorkDayCount": WorkDayCount, "startDate": startDate };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<Date>;
        return neResult.Result;
    }
    public static async CheckMernisNumber(uniqueRefNo: number): Promise<boolean> {
        let url: string = "/api/CommonController/CheckMernisNumber";
        let input = { "uniqueRefNo": uniqueRefNo };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<boolean>;
        return neResult.Result;
    }
    public static async GetDoctorRegisterNoByBranchCode(branchCode: string): Promise<string> {
        let url: string = "/api/CommonController/GetDoctorRegisterNoByBranchCode";
        let input = { "branchCode": branchCode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }*/
    public static async GetSaglikTesisleri(tesisKodu: string): Promise<string> {
        let url: string = '/api/CommonService/GetSaglikTesisleri';
        let input = { 'tesisKodu': tesisKodu };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post<string>(url, input);
        return response;
    }
    public static async DiagnosesForMedula(diagnoseList: Array<string>): Promise<Array<string>> {
        let url: string = '/api/CommonService/DiagnosesForMedula';
        let input = { 'diagnoseList': diagnoseList };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post<Array<string>>(url, input);
        return response;
    }/*
    public static async IsSubEpisodeNeeded(episode: Episode, bransKodlari: string[], tedaviTipi: string, tedaviTuru: string): Promise<boolean> {
        let url: string = "/api/CommonController/IsSubEpisodeNeeded";
        let input = { "episode": episode, "bransKodlari": bransKodlari, "tedaviTipi": tedaviTipi, "tedaviTuru": tedaviTuru };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<boolean>;
        return neResult.Result;
    }
    public static async IsDental(bransKodu: string): Promise<boolean> {
        let url: string = "/api/CommonController/IsDental";
        let input = { "bransKodu": bransKodu };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<boolean>;
        return neResult.Result;
    }
    public static async SaveUserMessageForUndefinedDiagnosis(): Promise<void> {
        let url: string = "/api/CommonController/SaveUserMessageForUndefinedDiagnosis";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<void>;
        return neResult.Result;
    }
    public static async IsLastDayExamination(examinationDate: Date): Promise<boolean> {
        let url: string = "/api/CommonController/IsLastDayExamination";
        let input = { "examinationDate": examinationDate };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<boolean>;
        return neResult.Result;
    }
    public static async CheckWorklistDayLimit(dtStart: Date, dtEnd: Date): Promise<void> {
        let url: string = "/api/CommonController/CheckWorklistDayLimit";
        let input = { "dtStart": dtStart, "dtEnd": dtEnd };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<void>;
        return neResult.Result;
    }
    public static async SerializeObjectToXml(instance: Object): Promise<string> {
        let url: string = "/api/CommonController/SerializeObjectToXml";
        let input = { "instance": instance };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }*/
    public static async PatientSearch(searchString: string): Promise<Array<any>> {
        let url: string = '/api/CommonController/PatientSearch';
        let input = { 'searchString': searchString };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<any>>(url, input);
        return result;
    }

    public static async  PersonelIzinKontrol(resUserID: Guid, ControlDate:Date): Promise<any> {

        let apiUrl: string = '/api/CommonService/PersonelIzinKontrol'; //?resUserID=' + resUserID;    
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let personnelTakeOff_Input :PersonnelTakeOff_Input =new PersonnelTakeOff_Input();

        personnelTakeOff_Input.ControlDate=ControlDate;
        personnelTakeOff_Input.ResuserID=resUserID.toString();

        return new Promise((resolve, reject) => {

            httpService.post<any>(apiUrl, personnelTakeOff_Input).then(
                x => {
                    let a = x;
                    resolve(a);
                }
            ).catch(error => {
                
                reject(false);
            });
        });

    }

    public static async SetLCDNotification(queueID: Guid, lcdNotification : LCDNotificationDefinition): Promise<any> {

        let apiUrl: string = '/api/CommonService/SetLCDNotification'; 
        let input = { 'queueID': queueID, 'lcdNotification': lcdNotification};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(apiUrl, input);
        return result;
    }

    public static async GetLCDNotification(queueID: Guid, drObjectID: Guid): Promise<LCDNotificationDefinition> {

        let apiUrl: string = '/api/CommonService/GetLCDNotification';
        let input = { 'queueID': queueID, 'drObjectID': drObjectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<any>(apiUrl, input);
        return result;
    }

    public static async checkPanicAlert(): Promise<ModalActionResult> {
        

        let that = this;
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'PanicAlertForm';
            componentInfo.ModuleName = 'LaboratuarModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Laboratuar_Modulu/LaboratuarModule';

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Panik Bildirim";
            modalInfo.Width = 1000;
            modalInfo.Height = 800;
            modalInfo.IsShowCloseButton = true;
            modalInfo.fullScreen = false;

            let result = ServiceLocator.ModalService().create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });


       

    }
    
    /*
    public static async GetRhIncompatibility(motherGroup: BloodGroupEnum, fatherGroup: BloodGroupEnum): Promise<VarYokGarantiEnum> {
        let url: string = "/api/CommonController/GetRhIncompatibility";
        let input = { "motherGroup": motherGroup, "fatherGroup": fatherGroup };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<VarYokGarantiEnum>;
        return neResult.Result;
    }
    public static async CalculateAge(birthDate: Date): Promise<Age> {
        let url: string = "/api/CommonController/CalculateAge";
        let input = { "birthDate": birthDate };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<Age>;
        return neResult.Result;
    }
    public static async CalculateBMI(weight: number, height: number): Promise<number> {
        let url: string = "/api/CommonController/CalculateBMI";
        let input = { "weight": weight, "height": height };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<number>;
        return neResult.Result;
    }
    public static async CalculateBodySurfaceArea(weight: number, height: number): Promise<number> {
        let url: string = "/api/CommonController/CalculateBodySurfaceArea";
        let input = { "weight": weight, "height": height };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<number>;
        return neResult.Result;
    }
    public static async PatientAdmissionInfo(patient: Patient, episode: Episode): Promise<string> {
        let url: string = "/api/CommonController/PatientAdmissionInfo";
        let input = { "patient": patient, "episode": episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let response = await httpService.post(url, input);
        let neResult = await response.json() as NeResult<string>;
        return neResult.Result;
    }*/
}