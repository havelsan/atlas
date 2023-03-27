//$775E8D07
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { InPatientTreatmentClinicApplication } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class InPatientTreatmentClinicApplicationService {
    public static async GetActiveByPhysicalStateClinic(PHYSICALSTATECLINIC: Guid): Promise<Array<InPatientTreatmentClinicApplication>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetActiveByPhysicalStateClinic";
        let input = { "PHYSICALSTATECLINIC": PHYSICALSTATECLINIC };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication>>(url, input);
        return result;
    }
    public static async GetInpatientListReportNQL(PHYSICALSTATECLINIC: Guid): Promise<Array<InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetInpatientListReportNQL";
        let input = { "PHYSICALSTATECLINIC": PHYSICALSTATECLINIC };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class>>(url, input);
        return result;
    }
    public static async GetInpatientStatistics(): Promise<Array<InPatientTreatmentClinicApplication.GetInpatientStatistics_Class>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetInpatientStatistics";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication.GetInpatientStatistics_Class>>(url, input);
        return result;
    }
    public static async GetInpatientStatisticsByDate(STARTDATE: Date, ENDDATE: Date, MASTERRESOURCE: Guid): Promise<Array<InPatientTreatmentClinicApplication.GetInpatientStatisticsByDate_Class>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetInpatientStatisticsByDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "MASTERRESOURCE": MASTERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication.GetInpatientStatisticsByDate_Class>>(url, input);
        return result;
    }
    public static async GetAllActiveInPatientTreatmentClinicApp(): Promise<Array<InPatientTreatmentClinicApplication>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetAllActiveInPatientTreatmentClinicApp";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication>>(url, input);
        return result;
    }
    public static async GetByEpisodeAndProcedureSpeciality(EPISODE: Guid, PROCEDURESPECIALITY: Guid): Promise<Array<InPatientTreatmentClinicApplication>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetByEpisodeAndProcedureSpeciality";
        let input = { "EPISODE": EPISODE, "PROCEDURESPECIALITY": PROCEDURESPECIALITY };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication>>(url, input);
        return result;
    }
    public static async GetByEpisodeAndMasterResourceReport(EPISODE: Guid, MASTERRESOURCE: Guid): Promise<Array<InPatientTreatmentClinicApplication.GetByEpisodeAndMasterResourceReport_Class>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetByEpisodeAndMasterResourceReport";
        let input = { "EPISODE": EPISODE, "MASTERRESOURCE": MASTERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication.GetByEpisodeAndMasterResourceReport_Class>>(url, input);
        return result;
    }
    public static async GetByEpisodeAndProcedureSpecialityASC(PROCEDURESPECIALITY: Guid, EPISODE: Guid): Promise<Array<InPatientTreatmentClinicApplication>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetByEpisodeAndProcedureSpecialityASC";
        let input = { "PROCEDURESPECIALITY": PROCEDURESPECIALITY, "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication>>(url, input);
        return result;
    }
    public static async GetAllClinicDischargeDatesByEpisode(EPISODE: string): Promise<Array<InPatientTreatmentClinicApplication>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetAllClinicDischargeDatesByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication>>(url, input);
        return result;
    }
    public static async GetpatientListReportByDaysNQL(INPATIENTDAYS: number, PHYSICALSTATECLINIC: Guid): Promise<Array<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetpatientListReportByDaysNQL";
        let input = { "INPATIENTDAYS": INPATIENTDAYS, "PHYSICALSTATECLINIC": PHYSICALSTATECLINIC };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class>>(url, input);
        return result;
    }
    public static async GetpatientListReportByInpatientDayNQL(PHYSICALSTATECLINIC: Guid, STARTDATE: Date, INPATIENTDAYS: number): Promise<Array<InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetpatientListReportByInpatientDayNQL";
        let input = { "PHYSICALSTATECLINIC": PHYSICALSTATECLINIC, "STARTDATE": STARTDATE, "INPATIENTDAYS": INPATIENTDAYS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class>>(url, input);
        return result;
    }
    public static async GetInpatientByPatientGroup(): Promise<Array<InPatientTreatmentClinicApplication.GetInpatientByPatientGroup_Class>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetInpatientByPatientGroup";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication.GetInpatientByPatientGroup_Class>>(url, input);
        return result;
    }
    public static async OLAP_YatanHasta(): Promise<Array<InPatientTreatmentClinicApplication.OLAP_YatanHasta_Class>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/OLAP_YatanHasta";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication.OLAP_YatanHasta_Class>>(url, input);
        return result;
    }
    public static async GetInPatientBeds(): Promise<Array<InPatientTreatmentClinicApplication.GetInPatientBeds_Class>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetInPatientBeds";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication.GetInPatientBeds_Class>>(url, input);
        return result;
    }
    public static async GetpatientListReportByDateNQL(PHYSICALSTATECLINIC: Guid, STARTDATE: Date, ENDDATE: Date): Promise<Array<InPatientTreatmentClinicApplication.GetpatientListReportByDateNQL_Class>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetpatientListReportByDateNQL";
        let input = { "PHYSICALSTATECLINIC": PHYSICALSTATECLINIC, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication.GetpatientListReportByDateNQL_Class>>(url, input);
        return result;
    }
    public static async GetInpatientBedsByResWard(SELECTEDWARD: Guid): Promise<Array<InPatientTreatmentClinicApplication.GetInpatientBedsByResWard_Class>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetInpatientBedsByResWard";
        let input = { "SELECTEDWARD": SELECTEDWARD };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication.GetInpatientBedsByResWard_Class>>(url, input);
        return result;
    }
    public static async GetInpatientInformation_RQ(injectionSQL: string): Promise<Array<InPatientTreatmentClinicApplication.GetInpatientInformation_RQ_Class>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetInpatientInformation_RQ";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication.GetInpatientInformation_RQ_Class>>(url, input);
        return result;
    }
    public static async GetJustInpatientStatistic(): Promise<Array<InPatientTreatmentClinicApplication.GetJustInpatientStatistic_Class>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetJustInpatientStatistic";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication.GetJustInpatientStatistic_Class>>(url, input);
        return result;
    }
    public static async GetByEpisodeAndMasterResource(EPISODE: Guid, MASTERRESOURCE: Guid): Promise<Array<InPatientTreatmentClinicApplication>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetByEpisodeAndMasterResource";
        let input = { "EPISODE": EPISODE, "MASTERRESOURCE": MASTERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication>>(url, input);
        return result;
    }
    public static async GetActiveInpatientTrtClinicAppByMasterResource(MASTERRESOURCE: Guid): Promise<Array<InPatientTreatmentClinicApplication.GetActiveInpatientTrtClinicAppByMasterResource_Class>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetActiveInpatientTrtClinicAppByMasterResource";
        let input = { "MASTERRESOURCE": MASTERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication.GetActiveInpatientTrtClinicAppByMasterResource_Class>>(url, input);
        return result;
    }
    public static async GetBySubEpisodeAndProcedureSpeciality(EPISODE: Guid, SUBEPISODE: Guid, PROCEDURESPECIALITY: Guid): Promise<Array<InPatientTreatmentClinicApplication>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetBySubEpisodeAndProcedureSpeciality";
        let input = { "EPISODE": EPISODE, "SUBEPISODE": SUBEPISODE, "PROCEDURESPECIALITY": PROCEDURESPECIALITY };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication>>(url, input);
        return result;
    }
    public static async GetInPatientInfoByPatients(PATIENTS: Array<Guid>): Promise<Array<InPatientTreatmentClinicApplication.GetInPatientInfoByPatients_Class>> {
        let url: string = "/api/InPatientTreatmentClinicApplicationService/GetInPatientInfoByPatients";
        let input = { "PATIENTS": PATIENTS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<InPatientTreatmentClinicApplication.GetInPatientInfoByPatients_Class>>(url, input);
        return result;
    }
}