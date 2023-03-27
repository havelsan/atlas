//$20F102E1
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SexEnum } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisodeProtocol } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectContext } from "NebulaClient/StorageManager/InstanceManagement/TTObjectContext";

export class PatientService {
    public static async IsAdmittingAllPatientGroupFromSiteAllowed(): Promise<boolean> {
        let url: string = "/api/PatientService/IsAdmittingAllPatientGroupFromSiteAllowed";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async Search(searchString: string): Promise<Array<any>> {
        let url: string = "/api/PatientService/Search";
        let input = { "searchString": searchString };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<any>>(url, input);
        return result;
    }
    public static async IsGuid(str: string): Promise<boolean> {
        let url: string = "/api/PatientService/IsGuid";
        let input = { "str": str };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async SendPatientToPACS(patient: Patient): Promise<void> {
        let url: string = "/api/PatientService/SendPatientToPACS";
        let input = { "patient": patient };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    /*public static async GetInpatientList(PhysicalStateClinicGuid: Guid): Promise<Array<InPatientListItem>> {
        let url: string = "/api/PatientService/GetInpatientList";
        let input = { "PhysicalStateClinicGuid": PhysicalStateClinicGuid };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientListItem>>(url, input);
        return result;
    }
    public static async GetPatient(ObjectId: Guid): Promise<InPatientInfo> {
        let url: string = "/api/PatientService/GetPatient";
        let input = { "ObjectId": ObjectId };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<InPatientInfo>(url, input);
        return result;
    }
    public static async GetSrcTableType(srctable: string): Promise<SrcTableType> {
        let url: string = "/api/PatientService/GetSrcTableType";
        let input = { "srctable": srctable };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<SrcTableType>(url, input);
        return result;
    }*/
    public static async AddOrUpdatePatientWithLocalID(objectContext: TTObjectContext, sourcePatient: Patient): Promise<Patient> {
        let url: string = "/api/PatientService/AddOrUpdatePatientWithLocalID";
        let input = { "objectContext": objectContext, "sourcePatient": sourcePatient };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Patient>(url, input);
        return result;
    }
    public static async IsAllRequiredPropertiesExists(throwException: boolean, patient: Patient): Promise<boolean> {
        let url: string = "/api/PatientService/IsAllRequiredPropertiesExists";
        let input = { "throwException": throwException, "patient": patient };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async GetSGKSEPs(patient: Patient, startDate: Date, endDate: Date): Promise<Array<SubEpisodeProtocol>> {
        let url: string = "/api/PatientService/GetSGKSEPs";
        let input = { "patient": patient, "startDate": startDate, "endDate": endDate };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol>>(url, input);
        return result;
    }
    public static async GetActiveSGKSEPs(patient: Patient, startDate: Date, endDate: Date): Promise<Array<SubEpisodeProtocol>> {
        let url: string = "/api/PatientService/GetActiveSGKSEPs";
        let input = { "patient": patient, "startDate": startDate, "endDate": endDate };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<SubEpisodeProtocol>>(url, input);
        return result;
    }
    public static async CoverPatientInformation(isPrivacy: boolean, patient: Patient): Promise<void> {
        let url: string = "/api/PatientService/CoverPatientInformation";
        let input = { "isPrivacy": isPrivacy, "patient": patient };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async GetAllPatients(): Promise<Array<Patient>> {
        let url: string = "/api/PatientService/GetAllPatients";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient>>(url, input);
        return result;
    }
    public static async OLAP_deneme(): Promise<Array<Patient.OLAP_deneme_Class>> {
        let url: string = "/api/PatientService/OLAP_deneme";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient.OLAP_deneme_Class>>(url, input);
        return result;
    }
    public static async GetPatientByInjection(): Promise<Array<Patient.GetPatientByInjection_Class>> {
        let url: string = "/api/PatientService/GetPatientByInjection";
        let input = { "injectionSQL": "" };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient.GetPatientByInjection_Class>>(url, input);
        return result;
    }
    public static async GetPatientsByIdentityInfo(Name: string, FatherName: string, SurName: string, MotherName: string, CityOfBirth: string, TownOfBirth: string, BirthDate: Date, Sex: SexEnum): Promise<Array<Patient>> {
        let url: string = "/api/PatientService/GetPatientsByIdentityInfo";
        let input = { "Name": Name, "FatherName": FatherName, "SurName": SurName, "MotherName": MotherName, "CityOfBirth": CityOfBirth, "TownOfBirth": TownOfBirth, "BirthDate": BirthDate, "Sex": Sex };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient>>(url, input);
        return result;
    }
    public static async GetImportantMedicalInformationByPatient(PATIENT: string): Promise<Array<Patient>> {
        let url: string = "/api/PatientService/GetImportantMedicalInformationByPatient";
        let input = { "PATIENT": PATIENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient>>(url, input);
        return result;
    }
    public static async GetPatientByPID(ID: number): Promise<Array<Patient>> {
        let url: string = "/api/PatientService/GetPatientByPID";
        let input = { "ID": ID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient>>(url, input);
        return result;
    }
    public static async GetPatientsByUniqueRefNo(UNIQUEREFNO: number): Promise<Array<Patient>> {
        let url: string = "/api/PatientService/GetPatientsByUniqueRefNo";
        let input = { "UNIQUEREFNO": UNIQUEREFNO };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient>>(url, input);
        return result;
    }
    public static async GetPatientByID(ID: string): Promise<Array<Patient>> {
        let url: string = "/api/PatientService/GetPatientByID";
        let input = { "ID": ID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient>>(url, input);
        return result;
    }
    public static async GetPatientsBetweenUniqueRefNo(UNIQUEREFNO1: number, UNIQUEREFNO2: number): Promise<Array<Patient>> {
        let url: string = "/api/PatientService/GetPatientsBetweenUniqueRefNo";
        let input = { "UNIQUEREFNO1": UNIQUEREFNO1, "UNIQUEREFNO2": UNIQUEREFNO2 };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient>>(url, input);
        return result;
    }
    public static async GetPatientsBetweenIDExceptFamily(ID1: number, ID2: number, injectionSQL: string): Promise<Array<Patient>> {
        let url: string = "/api/PatientService/GetPatientsBetweenIDExceptFamily";
        let input = { "ID1": ID1, "ID2": ID2, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient>>(url, input);
        return result;
    }
    public static async GetPatientIdentityAddress(): Promise<Array<Patient.GetPatientIdentityAddress_Class>> {
        let url: string = "/api/PatientService/GetPatientIdentityAddress";
        let input = { "injectionSQL": "" };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient.GetPatientIdentityAddress_Class>>(url, input);
        return result;
    }
    public static async GetPatientsBetweenIDOnlyFamily(ID1: number, ID2: number, injectionSQL: string): Promise<Array<Patient>> {
        let url: string = "/api/PatientService/GetPatientsBetweenIDOnlyFamily";
        let input = { "ID1": ID1, "ID2": ID2, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient>>(url, input);
        return result;
    }
    public static async GetInpatientPatientsByPatientGroup(): Promise<Array<Patient>> {
        let url: string = "/api/PatientService/GetInpatientPatientsByPatientGroup";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient>>(url, input);
        return result;
    }
    public static async GetPatientExistsByUniqueRefNO_RQ(RFN: number): Promise<Array<Patient.GetPatientExistsByUniqueRefNO_RQ_Class>> {
        let url: string = "/api/PatientService/GetPatientExistsByUniqueRefNO_RQ";
        let input = { "RFN": RFN };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient.GetPatientExistsByUniqueRefNO_RQ_Class>>(url, input);
        return result;
    }
    public static async GetPatientInformation_RQ(injectionSQL: string): Promise<Array<Patient.GetPatientInformation_RQ_Class>> {
        let url: string = "/api/PatientService/GetPatientInformation_RQ";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient.GetPatientInformation_RQ_Class>>(url, input);
        return result;
    }
    public static async GetPatients(OBJECTIDS: Array<Guid>): Promise<Array<Patient>> {
        let url: string = "/api/PatientService/GetPatients";
        let input = { "OBJECTIDS": OBJECTIDS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient>>(url, input);
        return result;
    }
    public static async VEM_HASTA(): Promise<Array<Patient.VEM_HASTA_Class>> {
        let url: string = "/api/PatientService/VEM_HASTA";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient.VEM_HASTA_Class>>(url, input);
        return result;
    }
    public static async VEM_HASTA_ARSIV(): Promise<Array<Patient.VEM_HASTA_ARSIV_Class>> {
        let url: string = "/api/PatientService/VEM_HASTA_ARSIV";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Patient.VEM_HASTA_ARSIV_Class>>(url, input);
        return result;
    }
}