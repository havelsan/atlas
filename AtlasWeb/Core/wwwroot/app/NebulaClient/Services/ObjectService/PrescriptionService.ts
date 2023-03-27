//$2E429CCD
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Prescription } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { PrescriptionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class PrescriptionService {
    public static async GetEReceteSignedInputRequest(pres: Prescription): Promise<string> {
        let url: string = '/api/PrescriptionService/GetEReceteSignedInputRequest';
        let input = { 'pres': pres };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }

    /*
    public static async GetEReceteDelete(pres: Prescription): Promise<ereceteSilIstekDVO> {
        let url: string = '/api/PrescriptionService/GetEReceteDelete';
        let input = { "pres": pres };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ereceteSilIstekDVO>(url, input);
        return result;
    }
    public static async GetEReceteInputRequest(pres: Prescription): Promise<ereceteGirisIstekDVO> {
        let url: string = "/api/PrescriptionService/GetEReceteInputRequest";
        let input = { "pres": pres };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ereceteGirisIstekDVO>(url, input);
        return result;
    }
    public static async GetEreceteInQuiry(pres: Prescription): Promise<ereceteSorguIstekDVO> {
        let url: string = "/api/PrescriptionService/GetEreceteInQuiry";
        let input = { "pres": pres };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ereceteSorguIstekDVO>(url, input);
        return result;
    }
    public static async GetEreceteListInQuiry(pres: Prescription): Promise<ereceteListeSorguIstekDVO> {
        let url: string = "/api/PrescriptionService/GetEreceteListInQuiry";
        let input = { "pres": pres };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ereceteListeSorguIstekDVO>(url, input);
        return result;
    }
    public static async GetEreceteApprovalRequest(pres: Prescription): Promise<ereceteOnayIstekDVO> {
        let url: string = "/api/PrescriptionService/GetEreceteApprovalRequest";
        let input = { "pres": pres };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ereceteOnayIstekDVO>(url, input);
        return result;
    }
    public static async GetEreceteInpatientApprovalRequest(pres: Prescription): Promise<ereceteYatanHastaOnayiIstekDVO> {
        let url: string = "/api/PrescriptionService/GetEreceteInpatientApprovalRequest";
        let input = { "pres": pres };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ereceteYatanHastaOnayiIstekDVO>(url, input);
        return result;
    }
    public static async GetEreceteApprovalCancelRequest(pres: Prescription): Promise<ereceteOnayIptalIstekDVO> {
        let url: string = "/api/PrescriptionService/GetEreceteApprovalCancelRequest";
        let input = { "pres": pres };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ereceteOnayIptalIstekDVO>(url, input);
        return result;
    }
    public static async GetEreceteEHUApprovalRequest(pres: Prescription, UniqueRefNo: number): Promise<ereceteOnayIstekDVO> {
        let url: string = "/api/PrescriptionService/GetEreceteEHUApprovalRequest";
        let input = { "pres": pres, "UniqueRefNo": UniqueRefNo };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ereceteOnayIstekDVO>(url, input);
        return result;
    }
    public static async GetEreceteEHUCancelRequest(pres: Prescription, UniqueRefNo: number): Promise<ereceteOnayIptalIstekDVO> {
        let url: string = "/api/PrescriptionService/GetEreceteEHUCancelRequest";
        let input = { "pres": pres, "UniqueRefNo": UniqueRefNo };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ereceteOnayIptalIstekDVO>(url, input);
        return result;
    }
    public static async GetEreceteDailyPresApprovalRequest(pres: Prescription, UniqueRefNo: number): Promise<ereceteOnayIstekDVO> {
        let url: string = "/api/PrescriptionService/GetEreceteDailyPresApprovalRequest";
        let input = { "pres": pres, "UniqueRefNo": UniqueRefNo };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ereceteOnayIstekDVO>(url, input);
        return result;
    }
    public static async GetEreceteDailyPresCancelRequest(pres: Prescription, UniqueRefNo: number): Promise<ereceteOnayIptalIstekDVO> {
        let url: string = "/api/PrescriptionService/GetEreceteDailyPresCancelRequest";
        let input = { "pres": pres, "UniqueRefNo": UniqueRefNo };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ereceteOnayIptalIstekDVO>(url, input);
        return result;
    }
    public static async GetDısReceteInfo(pres: Prescription): Promise<ReceteInfo> {
        let url: string = "/api/PrescriptionService/GetDısReceteInfo";
        let input = { "pres": pres };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ReceteInfo>(url, input);
        return result;
    }
    public static async GetReceteInfo(pres: Prescription): Promise<ReceteInfo> {
        let url: string = "/api/PrescriptionService/GetReceteInfo";
        let input = { "pres": pres };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ReceteInfo>(url, input);
        return result;
    }*/
    public static async GetPrescription(STARTDATE: Date, ENDDATE: Date): Promise<Array<Prescription>> {
        let url: string = '/api/PrescriptionService/GetPrescription';
        let input = { 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Prescription>>(url, input);
        return result;
    }
    public static async OLAP_GetPrescription(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<Prescription.OLAP_GetPrescription_Class>> {
        let url: string = '/api/PrescriptionService/OLAP_GetPrescription';
        let input = { 'FIRSTDATE': FIRSTDATE, 'LASTDATE': LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Prescription.OLAP_GetPrescription_Class>>(url, input);
        return result;
    }
    public static async GetFamilyForPrescriptionStatisticReportQuery(MASTERRESOURCEID: string, STARTDATE: Date, ENDDATE: Date,
        PRESCRIPTIONTYPE: PrescriptionTypeEnum): Promise<Array<Prescription.GetFamilyForPrescriptionStatisticReportQuery_Class>> {
        let url: string = '/api/PrescriptionService/GetFamilyForPrescriptionStatisticReportQuery';
        let input = { 'MASTERRESOURCEID': MASTERRESOURCEID, 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'PRESCRIPTIONTYPE': PRESCRIPTIONTYPE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Prescription.GetFamilyForPrescriptionStatisticReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetCivilianForPrescriptionStatisticReportQuery(MASTERRESOURCEID: string, STARTDATE: Date, ENDDATE: Date,
        PRESCRIPTIONTYPE: PrescriptionTypeEnum): Promise<Array<Prescription.GetCivilianForPrescriptionStatisticReportQuery_Class>> {
        let url: string = '/api/PrescriptionService/GetCivilianForPrescriptionStatisticReportQuery';
        let input = { 'MASTERRESOURCEID': MASTERRESOURCEID, 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'PRESCRIPTIONTYPE': PRESCRIPTIONTYPE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Prescription.GetCivilianForPrescriptionStatisticReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetOfficerForPrescriptionStatisticReportQuery(MASTERRESOURCEID: string, STARTDATE: Date, ENDDATE: Date,
        PRESCRIPTIONTYPE: PrescriptionTypeEnum): Promise<Array<Prescription.GetOfficerForPrescriptionStatisticReportQuery_Class>> {
        let url: string = '/api/PrescriptionService/GetOfficerForPrescriptionStatisticReportQuery';
        let input = { 'MASTERRESOURCEID': MASTERRESOURCEID, 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'PRESCRIPTIONTYPE': PRESCRIPTIONTYPE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Prescription.GetOfficerForPrescriptionStatisticReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetPrescriptionSearchWithProtocolNOReportQuery(STARTDATE: Date, ENDDATE: Date, PROTOCOLNO: number):
        Promise<Array<Prescription.GetPrescriptionSearchWithProtocolNOReportQuery_Class>> {
        let url: string = '/api/PrescriptionService/GetPrescriptionSearchWithProtocolNOReportQuery';
        let input = { 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'PROTOCOLNO': PROTOCOLNO };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Prescription.GetPrescriptionSearchWithProtocolNOReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetNCOfficerForPrescriptionStatisticReportQuery(MASTERRESOURCEID: string, STARTDATE: Date, ENDDATE: Date,
        PRESCRIPTIONTYPE: PrescriptionTypeEnum): Promise<Array<Prescription.GetNCOfficerForPrescriptionStatisticReportQuery_Class>> {
        let url: string = '/api/PrescriptionService/GetNCOfficerForPrescriptionStatisticReportQuery';
        let input = { 'MASTERRESOURCEID': MASTERRESOURCEID, 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'PRESCRIPTIONTYPE': PRESCRIPTIONTYPE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Prescription.GetNCOfficerForPrescriptionStatisticReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetPrescriptionStatisticWithGroupReportQuery(STARTDATE: Date, ENDDATE: Date, PRESCRIPTIONTYPEENUM: PrescriptionTypeEnum):
        Promise<Array<Prescription.GetPrescriptionStatisticWithGroupReportQuery_Class>> {
        let url: string = '/api/PrescriptionService/GetPrescriptionStatisticWithGroupReportQuery';
        let input = { 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'PRESCRIPTIONTYPEENUM': PRESCRIPTIONTYPEENUM };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Prescription.GetPrescriptionStatisticWithGroupReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetOfficialForPrescriptionStatisticReportQuery(MASTERRESOURCEID: string, STARTDATE: Date, ENDDATE: Date, PRESCRIPTIONTYPE:
        PrescriptionTypeEnum): Promise<Array<Prescription.GetOfficialForPrescriptionStatisticReportQuery_Class>> {
        let url: string = '/api/PrescriptionService/GetOfficialForPrescriptionStatisticReportQuery';
        let input = { 'MASTERRESOURCEID': MASTERRESOURCEID, 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'PRESCRIPTIONTYPE': PRESCRIPTIONTYPE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Prescription.GetOfficialForPrescriptionStatisticReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetExpertNonComForPrescriptionStatisticReportQuery(MASTERRESOURCEID: string, STARTDATE: Date, ENDDATE: Date, PRESCRIPTIONTYPE:
        PrescriptionTypeEnum): Promise<Array<Prescription.GetExpertNonComForPrescriptionStatisticReportQuery_Class>> {
        let url: string = '/api/PrescriptionService/GetExpertNonComForPrescriptionStatisticReportQuery';
        let input = { 'MASTERRESOURCEID': MASTERRESOURCEID, 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'PRESCRIPTIONTYPE': PRESCRIPTIONTYPE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Prescription.GetExpertNonComForPrescriptionStatisticReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetPrivateForPrescriptionStatisticReportQuery(MASTERRESOURCEID: string, STARTDATE: Date, ENDDATE: Date, PRESCRIPTIONTYPE:
        PrescriptionTypeEnum): Promise<Array<Prescription.GetPrivateForPrescriptionStatisticReportQuery_Class>> {
        let url: string = '/api/PrescriptionService/GetPrivateForPrescriptionStatisticReportQuery';
        let input = { 'MASTERRESOURCEID': MASTERRESOURCEID, 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'PRESCRIPTIONTYPE': PRESCRIPTIONTYPE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Prescription.GetPrivateForPrescriptionStatisticReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetCadetForPrescriptionStatisticReportQuery(MASTERRESOURCEID: string, STARTDATE: Date, ENDDATE: Date, PRESCRIPTIONTYPE:
        PrescriptionTypeEnum): Promise<Array<Prescription.GetCadetForPrescriptionStatisticReportQuery_Class>> {
        let url: string = '/api/PrescriptionService/GetCadetForPrescriptionStatisticReportQuery';
        let input = { 'MASTERRESOURCEID': MASTERRESOURCEID, 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'PRESCRIPTIONTYPE': PRESCRIPTIONTYPE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Prescription.GetCadetForPrescriptionStatisticReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetRetiredForPrescriptionStatisticReportQuery(MASTERRESOURCEID: string, STARTDATE: Date, ENDDATE: Date, PRESCRIPTIONTYPE:
        PrescriptionTypeEnum): Promise<Array<Prescription.GetRetiredForPrescriptionStatisticReportQuery_Class>> {
        let url: string = '/api/PrescriptionService/GetRetiredForPrescriptionStatisticReportQuery';
        let input = { 'MASTERRESOURCEID': MASTERRESOURCEID, 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE, 'PRESCRIPTIONTYPE': PRESCRIPTIONTYPE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Prescription.GetRetiredForPrescriptionStatisticReportQuery_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetCancelledPrescription(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<Prescription.OLAP_GetCancelledPrescription_Class>> {
        let url: string = '/api/PrescriptionService/OLAP_GetCancelledPrescription';
        let input = { 'FIRSTDATE': FIRSTDATE, 'LASTDATE': LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Prescription.OLAP_GetCancelledPrescription_Class>>(url, input);
        return result;
    }
    public static async VEM_RECETE(): Promise<Array<Prescription.VEM_RECETE_Class>> {
        let url: string = '/api/PrescriptionService/VEM_RECETE';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Prescription.VEM_RECETE_Class>>(url, input);
        return result;
    }

    public static async PrepareRepeatApprovalRequest(inpatientPrescription: InpatientPrescription): Promise<string> {
        let url: string = '/api/PrescriptionService/PrepareRepeatApprovalRequest';
        let input = { 'inpatientPrescription': inpatientPrescription };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }

    public static async SendRepeatApprovalRequest(inpatientPrescription: InpatientPrescription, signApprovalContent: string): Promise<boolean> {
        let url: string = '/api/PrescriptionService/SendRepeatApprovalRequest';
        let input = { 'inpatientPrescription': inpatientPrescription, 'signApprovalContent': signApprovalContent };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
}