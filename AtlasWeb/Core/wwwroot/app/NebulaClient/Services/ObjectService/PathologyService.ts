//$C5C757E0
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Pathology } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class PathologyService {
    public static async CheckUncompletedSpecialProcedures(pathology: Pathology): Promise<void> {
        let url: string = "/api/PathologyService/CheckUncompletedSpecialProcedures";
        let input = { "pathology": pathology };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async PathologyTestReqStateInfoNQL(PARAMOBJID: string): Promise<Array<Pathology.PathologyTestReqStateInfoNQL_Class>> {
        let url: string = "/api/PathologyService/PathologyTestReqStateInfoNQL";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.PathologyTestReqStateInfoNQL_Class>>(url, input);
        return result;
    }
    public static async PathologyTestRequestInfoStickerNQL(PARAMOBJID: string): Promise<Array<Pathology.PathologyTestRequestInfoStickerNQL_Class>> {
        let url: string = "/api/PathologyService/PathologyTestRequestInfoStickerNQL";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.PathologyTestRequestInfoStickerNQL_Class>>(url, input);
        return result;
    }
    public static async PathologyTestReportQuery(PARAMPATOBJID: string): Promise<Array<Pathology.PathologyTestReportQuery_Class>> {
        let url: string = "/api/PathologyService/PathologyTestReportQuery";
        let input = { "PARAMPATOBJID": PARAMPATOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.PathologyTestReportQuery_Class>>(url, input);
        return result;
    }
    public static async PathologyTestResultPatientInfoReportQuery(PARAMOBJID: string): Promise<Array<Pathology.PathologyTestResultPatientInfoReportQuery_Class>> {
        let url: string = "/api/PathologyService/PathologyTestResultPatientInfoReportQuery";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.PathologyTestResultPatientInfoReportQuery_Class>>(url, input);
        return result;
    }
    public static async WorkListNQL(STARTDATE: Date, ENDDATE: Date, injectionSQL: string): Promise<Array<Pathology>> {
        let url: string = "/api/PathologyService/WorkListNQL";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology>>(url, input);
        return result;
    }
    public static async PathologyTestResultReportQuery(PARAMOBJID: string): Promise<Array<Pathology.PathologyTestResultReportQuery_Class>> {
        let url: string = "/api/PathologyService/PathologyTestResultReportQuery";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.PathologyTestResultReportQuery_Class>>(url, input);
        return result;
    }
    public static async GetPatTestByEpisode(EPISODE: Guid): Promise<Array<Pathology>> {
        let url: string = "/api/PathologyService/GetPatTestByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology>>(url, input);
        return result;
    }
    public static async GetPathologyStatisticsByInjection(injectionSQL: string): Promise<Array<Pathology.GetPathologyStatisticsByInjection_Class>> {
        let url: string = "/api/PathologyService/GetPathologyStatisticsByInjection";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.GetPathologyStatisticsByInjection_Class>>(url, input);
        return result;
    }
    public static async GetPathologyTestByEpisode(EPISODE: Guid): Promise<Array<Pathology.GetPathologyTestByEpisode_Class>> {
        let url: string = "/api/PathologyService/GetPathologyTestByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.GetPathologyTestByEpisode_Class>>(url, input);
        return result;
    }
    public static async GetByWLFilterExpression(injectionSQL: string): Promise<Array<Pathology>> {
        let url: string = "/api/PathologyService/GetByWLFilterExpression";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology>>(url, input);
        return result;
    }
    public static async GetByPatTestFilterExpressionReport(injectionSQL: string): Promise<Array<Pathology.GetByPatTestFilterExpressionReport_Class>> {
        let url: string = "/api/PathologyService/GetByPatTestFilterExpressionReport";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.GetByPatTestFilterExpressionReport_Class>>(url, input);
        return result;
    }
    public static async GetByPatTestWorklistDateReport(STARTDATE: Date, ENDDATE: Date, injectionSQL: string): Promise<Array<Pathology.GetByPatTestWorklistDateReport_Class>> {
        let url: string = "/api/PathologyService/GetByPatTestWorklistDateReport";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.GetByPatTestWorklistDateReport_Class>>(url, input);
        return result;
    }
    public static async GetPathologyTestBySubEpisode(SUBEPISODE: string): Promise<Array<Pathology.GetPathologyTestBySubEpisode_Class>> {
        let url: string = "/api/PathologyService/GetPathologyTestBySubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.GetPathologyTestBySubEpisode_Class>>(url, input);
        return result;
    }
    public static async GetPatTestBySubEpisode(SUBEPISODE: Guid, EPISODE: string): Promise<Array<Pathology>> {
        let url: string = "/api/PathologyService/GetPatTestBySubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE, "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology>>(url, input);
        return result;
    }
    public static async GetPathologyStatisticsNewNQL(ASSISTANTDOCTOR: string, ASSISTANTDOCTOR_FLG: number, MATPRTNO: string, MATPRTNO_FLG: number, RESPONSIBLEDOCTOR: string, RESPONSIBLEDOCTOR_FLG: number, SPECIALDOCTOR: string, SPECIALDOCTOR_FLG: number, ENDDATE: Date, STARTDATE: Date, TESTCATEGORY_FLG: number, UNIQUEREFNO: string, UNIQUEREFNO_FLG: number, TEST_FLG: number, SNOMEDDIAGNOSIS: string, SNOMEDDIAGNOSIS_FLG: number, DIAGNOSIS: string, DIAGNOSIS_FLG: number): Promise<Array<Pathology.GetPathologyStatisticsNewNQL_Class>> {
        let url: string = "/api/PathologyService/GetPathologyStatisticsNewNQL";
        let input = { "ASSISTANTDOCTOR": ASSISTANTDOCTOR, "ASSISTANTDOCTOR_FLG": ASSISTANTDOCTOR_FLG, "MATPRTNO": MATPRTNO, "MATPRTNO_FLG": MATPRTNO_FLG, "RESPONSIBLEDOCTOR": RESPONSIBLEDOCTOR, "RESPONSIBLEDOCTOR_FLG": RESPONSIBLEDOCTOR_FLG, "SPECIALDOCTOR": SPECIALDOCTOR, "SPECIALDOCTOR_FLG": SPECIALDOCTOR_FLG, "ENDDATE": ENDDATE, "STARTDATE": STARTDATE, "TESTCATEGORY_FLG": TESTCATEGORY_FLG, "UNIQUEREFNO": UNIQUEREFNO, "UNIQUEREFNO_FLG": UNIQUEREFNO_FLG, "TEST_FLG": TEST_FLG, "SNOMEDDIAGNOSIS": SNOMEDDIAGNOSIS, "SNOMEDDIAGNOSIS_FLG": SNOMEDDIAGNOSIS_FLG, "DIAGNOSIS": DIAGNOSIS, "DIAGNOSIS_FLG": DIAGNOSIS_FLG };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.GetPathologyStatisticsNewNQL_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetPathologyTest(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<Pathology.OLAP_GetPathologyTest_Class>> {
        let url: string = "/api/PathologyService/OLAP_GetPathologyTest";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.OLAP_GetPathologyTest_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetCancelledPathologyTest(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<Pathology.OLAP_GetCancelledPathologyTest_Class>> {
        let url: string = "/api/PathologyService/OLAP_GetCancelledPathologyTest";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.OLAP_GetCancelledPathologyTest_Class>>(url, input);
        return result;
    }
    public static async GetByFilterExpression(BIRTHDAYMIN: Date, BIRTHDAYMAX: Date, injectionSQL: string): Promise<Array<Pathology>> {
        let url: string = "/api/PathologyService/GetByFilterExpression";
        let input = { "BIRTHDAYMIN": BIRTHDAYMIN, "BIRTHDAYMAX": BIRTHDAYMAX, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology>>(url, input);
        return result;
    }
    public static async GetPathologyStatisticsNQL(CARDNO: string, MATPRTNO: string, DIAGNOSIS: string, SNOMEDDIAGNOSIS: string, STARTDATE: Date, ENDDATE: Date, RESPONSIBLEDOCTOR: string, SPECIALDOCTOR: string, ASSISTANTDOCTOR: string): Promise<Array<Pathology.GetPathologyStatisticsNQL_Class>> {
        let url: string = "/api/PathologyService/GetPathologyStatisticsNQL";
        let input = { "CARDNO": CARDNO, "MATPRTNO": MATPRTNO, "DIAGNOSIS": DIAGNOSIS, "SNOMEDDIAGNOSIS": SNOMEDDIAGNOSIS, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "RESPONSIBLEDOCTOR": RESPONSIBLEDOCTOR, "SPECIALDOCTOR": SPECIALDOCTOR, "ASSISTANTDOCTOR": ASSISTANTDOCTOR };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.GetPathologyStatisticsNQL_Class>>(url, input);
        return result;
    }
    public static async PathologyTestRequestBarcodeNQL(PARAMOBJID: string): Promise<Array<Pathology.PathologyTestRequestBarcodeNQL_Class>> {
        let url: string = "/api/PathologyService/PathologyTestRequestBarcodeNQL";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.PathologyTestRequestBarcodeNQL_Class>>(url, input);
        return result;
    }
    public static async GetPathologyTestStatisticsByFilter(injectionSQL: string): Promise<Array<Pathology.GetPathologyTestStatisticsByFilter_Class>> {
        let url: string = "/api/PathologyService/GetPathologyTestStatisticsByFilter";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Pathology.GetPathologyTestStatisticsByFilter_Class>>(url, input);
        return result;
    }
}