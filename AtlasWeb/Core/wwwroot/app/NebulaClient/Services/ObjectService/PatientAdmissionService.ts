import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { PatientMedulaHastaKabul } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { TTObjectContext } from "NebulaClient/StorageManager/InstanceManagement/TTObjectContext";

export class PatientAdmissionService {
    public static async CreateEpisode(patientAdmission: PatientAdmission): Promise<void> {
        let url: string = "/api/PatientAdmissionService/CreateEpisode";
        let input = { "patientAdmission": patientAdmission };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async ControlAndCreateEpisodeProtocol(resList: Array<ResSection>, patientAdmission: PatientAdmission): Promise<void> {
        let url: string = "/api/PatientAdmissionService/ControlAndCreateEpisodeProtocol";
        let input = { "resList": resList, "patientAdmission": patientAdmission };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async FillSEPProperties(patientAdmission: PatientAdmission): Promise<void> {
        let url: string = "/api/PatientAdmissionService/FillSEPProperties";
        let input = { "patientAdmission": patientAdmission };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async GetPatientBySearch(searchString: string): Promise<Patient> {
        let url: string = "/api/PatientAdmissionService/GetPatientBySearch";
        let input = { "searchString": searchString };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Patient>(url, input);
        return result;
    }
    public static async SetAdmissionResource(patientAdmission: PatientAdmission): Promise<void> {
        let url: string = "/api/PatientAdmissionService/SetAdmissionResource";
        let input = { "patientAdmission": patientAdmission };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async ControlBulletinProtocol(patientAdmission: PatientAdmission): Promise<void> {
        let url: string = "/api/PatientAdmissionService/ControlBulletinProtocol";
        let input = { "patientAdmission": patientAdmission };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async ReturnEpisodeWithSameSpecialityInTenDays(patientAdmission: PatientAdmission): Promise<Episode> {
        let url: string = "/api/PatientAdmissionService/ReturnEpisodeWithSameSpecialityInTenDays";
        let input = { "patientAdmission": patientAdmission };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Episode>(url, input);
        return result;
    }
    public static async SavePatientAdmission(pa: PatientAdmission): Promise<PatientAdmission> {
        let url: string = "/api/PatientAdmissionService/SavePatientAdmission";
        let input = { "pa": pa };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<PatientAdmission>(url, input);
        return result;
    }
    public static async FireNewPatientExamination(pa: PatientAdmission): Promise<void> {
        let url: string = "/api/PatientAdmissionService/FireNewPatientExamination";
        let input = { "pa": pa };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async SelectMedulaHastaKabul(pa: PatientAdmission): Promise<PatientMedulaHastaKabul> {
        let url: string = "/api/PatientAdmissionService/SelectMedulaHastaKabul";
        let input = { "pa": pa };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<PatientMedulaHastaKabul>(url, input);
        return result;
    }
    public static async LoadPatientAdmission(TC: string, ctx: TTObjectContext): Promise<PatientAdmission> {
        let url: string = "/api/PatientAdmissionService/LoadPatientAdmission";
        let input = { "TC": TC, "ctx": ctx };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<PatientAdmission>(url, input);
        return result;
    }
    public static async GetAdressInfoNotExists(STARTDATE: Date, ENDDATE: Date, RESOURCE: Array<string>, RESOURCEFLAG: number): Promise<Array<PatientAdmission.GetAdressInfoNotExists_Class>> {
        let url: string = "/api/PatientAdmissionService/GetAdressInfoNotExists";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "RESOURCE": RESOURCE, "RESOURCEFLAG": RESOURCEFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientAdmission.GetAdressInfoNotExists_Class>>(url, input);
        return result;
    }
    public static async GetProvisionNumberNotExists(STARTDATE: Date, ENDDATE: Date, RESOURCE: Array<string>, RESOURCEFLAG: number): Promise<Array<PatientAdmission.GetProvisionNumberNotExists_Class>> {
        let url: string = "/api/PatientAdmissionService/GetProvisionNumberNotExists";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "RESOURCE": RESOURCE, "RESOURCEFLAG": RESOURCEFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientAdmission.GetProvisionNumberNotExists_Class>>(url, input);
        return result;
    }

    public static async GetPatientAdmissionsCount(STARTDATE: Date, ENDDATE: Date): Promise<Array<PatientAdmission.GetPatientAdmissionsCount_Class>> {
        let url: string = "/api/PatientAdmissionService/GetPatientAdmissionsCount";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientAdmission.GetPatientAdmissionsCount_Class>>(url, input);
        return result;
    }
    public static async CloseDailyAdmisnsAfter24(STARTDATE: Date, ENDDATE: Date): Promise<Array<PatientAdmission>> {
        let url: string = "/api/PatientAdmissionService/CloseDailyAdmisnsAfter24";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientAdmission>>(url, input);
        return result;
    }
    public static async OLAP_AdliVaka(DATE: Date): Promise<Array<PatientAdmission.OLAP_AdliVaka_Class>> {
        let url: string = "/api/PatientAdmissionService/OLAP_AdliVaka";
        let input = { "DATE": DATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientAdmission.OLAP_AdliVaka_Class>>(url, input);
        return result;
    }
    public static async GetOutPatientEtiquette(OBJECTID: string): Promise<Array<PatientAdmission.GetOutPatientEtiquette_Class>> {
        let url: string = "/api/PatientAdmissionService/GetOutPatientEtiquette";
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientAdmission.GetOutPatientEtiquette_Class>>(url, input);
        return result;
    }
    public static async GetForeignPatientsNQL(ACTIONSTARTDATE: Date, ACTIONENDDATE: Date): Promise<Array<PatientAdmission.GetForeignPatientsNQL_Class>> {
        let url: string = "/api/PatientAdmissionService/GetForeignPatientsNQL";
        let input = { "ACTIONSTARTDATE": ACTIONSTARTDATE, "ACTIONENDDATE": ACTIONENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientAdmission.GetForeignPatientsNQL_Class>>(url, input);
        return result;
    }
    public static async GetMAPByCountryAndDate(STARTDATE: Date, ENDDATE: Date, COUNTRY: string, COUNTRYFLAG: number, MAINSPECIALITY: string, MAINSPECIALITYFLAG: number, INPATIENTFLAG: number, OUTPATIENTFLAG: number): Promise<Array<PatientAdmission.GetMAPByCountryAndDate_Class>> {
        let url: string = "/api/PatientAdmissionService/GetMAPByCountryAndDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "COUNTRY": COUNTRY, "COUNTRYFLAG": COUNTRYFLAG, "MAINSPECIALITY": MAINSPECIALITY, "MAINSPECIALITYFLAG": MAINSPECIALITYFLAG, "INPATIENTFLAG": INPATIENTFLAG, "OUTPATIENTFLAG": OUTPATIENTFLAG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientAdmission.GetMAPByCountryAndDate_Class>>(url, input);
        return result;
    }
    public static async VEM_HASTA_ILETISIM(): Promise<Array<PatientAdmission.VEM_HASTA_ILETISIM_Class>> {
        let url: string = "/api/PatientAdmissionService/VEM_HASTA_ILETISIM";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientAdmission.VEM_HASTA_ILETISIM_Class>>(url, input);
        return result;
    }
}