//$4A0EEF5F
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SubEpisodeStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { TedaviTuru } from 'NebulaClient/Model/AtlasClientModel';
import { AccountTransaction } from 'NebulaClient/Model/AtlasClientModel';

export class EpisodeService {
    public static async CalculatePatientDebt(episode: Episode, serviceTotal: Object, advanceTotal: Object): Promise<PatientEpisodePaymentDetail> {
        let url: string = "/api/EpisodeService/CalculatePatientDebt";
        let input = { "episode": episode, "serviceTotal": serviceTotal, "advanceTotal": advanceTotal };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<PatientEpisodePaymentDetail>(url, input);
        return result;
    }
    public static async GetTransactionsForReceipt(episode: Episode): Promise<Array<AccountTransaction>> {
        let url: string = "/api/EpisodeService/GetTransactionsForReceipt";
        let input = { "episode": episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<AccountTransaction>>(url, input);
        return result;
    }
    public static async MyAddress(episode: Episode): Promise<string> {
        let url: string = "/api/EpisodeService/MyAddress";
        let input = { "episode": episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async MyDocumentNumber(episode: Episode): Promise<string> {
        let url: string = "/api/EpisodeService/MyDocumentNumber";
        let input = { "episode": episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async MyDocumentDate(episode: Episode): Promise<Date> {
        let url: string = "/api/EpisodeService/MyDocumentDate";
        let input = { "episode": episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Date>(url, input);
        return result;
    }
    public static async GivenValuableMaterialsMsg(episode: Episode): Promise<string> {
        let url: string = "/api/EpisodeService/GivenValuableMaterialsMsg";
        let input = { "episode": episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async TakenValuableMaterialsMsg(episode: Episode): Promise<string> {
        let url: string = "/api/EpisodeService/TakenValuableMaterialsMsg";
        let input = { "episode": episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async HasMainDiagnose(episode: Episode): Promise<boolean> {
        let url: string = "/api/EpisodeService/HasMainDiagnose";
        let input = { "episode": episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async IsMedulaEpisode(episode: Episode): Promise<boolean> {
        let url: string = "/api/EpisodeService/IsMedulaEpisode";
        let input = { "episode": episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async GetMedulaTedaviTuruByPatientStatus(patientStatus: SubEpisodeStatusEnum): Promise<TedaviTuru> {
        let url: string = "/api/EpisodeService/GetMedulaTedaviTuruByPatientStatus";
        let input = { "patientStatus": patientStatus };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<TedaviTuru>(url, input);
        return result;
    }
    public static async GetMyMedulaDiagnosisDefinitionICDCodes(episode: Episode): Promise<Array<string>> {
        let url: string = "/api/EpisodeService/GetMyMedulaDiagnosisDefinitionICDCodes";
        let input = { "episode": episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<string>>(url, input);
        return result;
    }
    public static async HasAnyEpisodePhysiotherapyOrderWithoutRobotikRehabilitasyon(episode: Episode): Promise<boolean> {
        let url: string = "/api/EpisodeService/HasAnyEpisodePhysiotherapyOrderWithoutRobotikRehabilitasyon";
        let input = { "episode": episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async HasAnyEpisodeRobotikRehabilitasyon(episode: Episode): Promise<boolean> {
        let url: string = "/api/EpisodeService/HasAnyEpisodeRobotikRehabilitasyon";
        let input = { "episode": episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async GetByLastUpdateDate(DATE: Date): Promise<Array<Episode>> {
        let url: string = "/api/EpisodeService/GetByLastUpdateDate";
        let input = { "DATE": DATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode>>(url, input);
        return result;
    }

    public static async OLAP_GetEpisodeInformation(EID: string): Promise<Array<Episode.OLAP_GetEpisodeInformation_Class>> {
        let url: string = "/api/EpisodeService/OLAP_GetEpisodeInformation";
        let input = { "EID": EID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post(url, input);
        return result as Array<Episode.OLAP_GetEpisodeInformation_Class>;
    }
    public static async OLAP_GetEpisodeDiagnosis(EID: string): Promise<Array<Episode.OLAP_GetEpisodeDiagnosis_Class>> {
        let url: string = "/api/EpisodeService/OLAP_GetEpisodeDiagnosis";
        let input = { "EID": EID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode.OLAP_GetEpisodeDiagnosis_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetLastDiagnosis(EID: string): Promise<Array<Episode.OLAP_GetLastDiagnosis_Class>> {
        let url: string = "/api/EpisodeService/OLAP_GetLastDiagnosis";
        let input = { "EID": EID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode.OLAP_GetLastDiagnosis_Class>>(url, input);
        return result;
    }

    public static async GetEpisodesByPatient(PATIENT: string): Promise<Array<Episode>> {
        let url: string = "/api/EpisodeService/GetEpisodesByPatient";
        let input = { "PATIENT": PATIENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode>>(url, input);
        return result;
    }
    public static async OLAP_GetEmergencyAdmission(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<Episode.OLAP_GetEmergencyAdmission_Class>> {
        let url: string = "/api/EpisodeService/OLAP_GetEmergencyAdmission";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode.OLAP_GetEmergencyAdmission_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetEpisodeResourceByStatus(EPISODEID: string): Promise<Array<Episode.OLAP_GetEpisodeResourceByStatus_Class>> {
        let url: string = "/api/EpisodeService/OLAP_GetEpisodeResourceByStatus";
        let input = { "EPISODEID": EPISODEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode.OLAP_GetEpisodeResourceByStatus_Class>>(url, input);
        return result;
    }
    public static async GetDischargedPatientCount(STARTDATE: Date, ENDDATE: Date): Promise<Array<Episode.GetDischargedPatientCount_Class>> {
        let url: string = "/api/EpisodeService/GetDischargedPatientCount";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode.GetDischargedPatientCount_Class>>(url, input);
        return result;
    }

    public static async GetByPatientAndDayLimitNQL(DAYLIMIT: Date, PATIENT: Guid): Promise<Array<Episode.GetByPatientAndDayLimitNQL_Class>> {
        let url: string = "/api/EpisodeService/GetByPatientAndDayLimitNQL";
        let input = { "DAYLIMIT": DAYLIMIT, "PATIENT": PATIENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode.GetByPatientAndDayLimitNQL_Class>>(url, input);
        return result;
    }
    public static async GetByDayLimitAndMainSpeciality(DAYLIMIT: Date, SPECIALITIES: Array<Guid>, PATIENT: string): Promise<Array<Episode>> {
        let url: string = "/api/EpisodeService/GetByDayLimitAndMainSpeciality";
        let input = { "DAYLIMIT": DAYLIMIT, "SPECIALITIES": SPECIALITIES, "PATIENT": PATIENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode>>(url, input);
        return result;
    }

    public static async GetNotDiagnosisExistsByDateInterval(STARTDATE: Date, ENDDATE: Date): Promise<Array<Episode.GetNotDiagnosisExistsByDateInterval_Class>> {
        let url: string = "/api/EpisodeService/GetNotDiagnosisExistsByDateInterval";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post(url, input);
        return result as Array<Episode.GetNotDiagnosisExistsByDateInterval_Class>;
    }
    public static async OLAP_GetCancelledEmergencyAdmission(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<Episode.OLAP_GetCancelledEmergencyAdmission_Class>> {
        let url: string = "/api/EpisodeService/OLAP_GetCancelledEmergencyAdmission";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode.OLAP_GetCancelledEmergencyAdmission_Class>>(url, input);
        return result;
    }
    public static async GetByHospitalProtocolNo(HPROTOCOLNO: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<Episode>> {
        let url: string = "/api/EpisodeService/GetByHospitalProtocolNo";
        let input = { "HPROTOCOLNO": HPROTOCOLNO, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode>>(url, input);
        return result;
    }
    public static async GetEpisodeInformation_RQ(STARTDATE: Date, ENDDATE: Date): Promise<Array<Episode.GetEpisodeInformation_RQ_Class>> {
        let url: string = "/api/EpisodeService/GetEpisodeInformation_RQ";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode.GetEpisodeInformation_RQ_Class>>(url, input);
        return result;
    }
    public static async GetEpisodesToSendEHRs(STARTDATE: Date, ENDDATE: Date): Promise<Array<Episode.GetEpisodesToSendEHRs_Class>> {
        let url: string = "/api/EpisodeService/GetEpisodesToSendEHRs";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode.GetEpisodesToSendEHRs_Class>>(url, input);
        return result;
    }
    public static async GetDiagnosisByPatientExamination(PATIENTEXAMINATION: Guid): Promise<Array<Episode.GetDiagnosisByPatientExamination_Class>> {
        let url: string = "/api/EpisodeService/GetDiagnosisByPatientExamination";
        let input = { "PATIENTEXAMINATION": PATIENTEXAMINATION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post(url, input);
        return result as Array<Episode.GetDiagnosisByPatientExamination_Class>;
    }
    public static async GetByOpeningDate(STARTDATE: Date, ENDDATE: Date): Promise<Array<Episode>> {
        let url: string = "/api/EpisodeService/GetByOpeningDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode>>(url, input);
        return result;
    }
    public static async GetOpenedOutPatientByDate(DATE: Date): Promise<Array<Episode>> {
        let url: string = "/api/EpisodeService/GetOpenedOutPatientByDate";
        let input = { "DATE": DATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode>>(url, input);
        return result;
    }
    public static async GetEpisodes(OBJECTIDS: Array<Guid>): Promise<Array<Episode>> {
        let url: string = "/api/EpisodeService/GetEpisodes";
        let input = { "OBJECTIDS": OBJECTIDS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode>>(url, input);
        return result;
    }
    public static async GetVeteransOfEpisodesByDate(OPENINGDATE: Date, ENDOPENINGDATE: Date): Promise<Array<Episode.GetVeteransOfEpisodesByDate_Class>> {
        let url: string = "/api/EpisodeService/GetVeteransOfEpisodesByDate";
        let input = { "OPENINGDATE": OPENINGDATE, "ENDOPENINGDATE": ENDOPENINGDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Episode.GetVeteransOfEpisodesByDate_Class>>(url, input);
        return result;
    }
}

export class PatientEpisodePaymentDetail {
    public ServiceTotal: number;
    public ReceiptTotal: number;
    public AdvanceBackTotal: number;
    public ReceiptBackTotal: number;
    public AdvanceTotal: number;
    public TotalDebt: number;
    public RemainingDebt: number;
}