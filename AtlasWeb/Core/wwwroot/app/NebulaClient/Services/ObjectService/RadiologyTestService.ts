//$6E57E5C0
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class RadiologyTestService {
    public static async PrintRadiologyRequestBarcode(radTest: RadiologyTest): Promise<void> {
        let url: string = "/api/RadiologyTestService/PrintRadiologyRequestBarcode";
        let input = { "radTest": radTest };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async SendRadiologyTestToPACS(radTest: RadiologyTest): Promise<void> {
        let url: string = "/api/RadiologyTestService/SendRadiologyTestToPACS";
        let input = { "radTest": radTest };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async WorkListNQL(STARTDATE: Date, ENDDATE: Date, injectionSQL: string): Promise<Array<RadiologyTest>> {
        let url: string = "/api/RadiologyTestService/WorkListNQL";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest>>(url, input);
        return result;
    }
    public static async GetTests(STARTDATE: Date, ENDDATE: Date): Promise<Array<RadiologyTest>> {
        let url: string = "/api/RadiologyTestService/GetTests";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest>>(url, input);
        return result;
    }
    public static async RadiologyTestAppointmentInfoQuery(PARAMOBJID: string): Promise<Array<RadiologyTest.RadiologyTestAppointmentInfoQuery_Class>> {
        let url: string = "/api/RadiologyTestService/RadiologyTestAppointmentInfoQuery";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest.RadiologyTestAppointmentInfoQuery_Class>>(url, input);
        return result;
    }
    public static async GetRadTestByPatientByTestByDate(PATIENTID: string, TESTID: string, STARTDATE: Date, ENDDATE: Date): Promise<Array<RadiologyTest>> {
        let url: string = "/api/RadiologyTestService/GetRadTestByPatientByTestByDate";
        let input = { "PATIENTID": PATIENTID, "TESTID": TESTID, "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest>>(url, input);
        return result;
    }
    public static async RadiologyTestResultReport(PARAMOBJID: string): Promise<Array<RadiologyTest.RadiologyTestResultReport_Class>> {
        let url: string = "/api/RadiologyTestService/RadiologyTestResultReport";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest.RadiologyTestResultReport_Class>>(url, input);
        return result;
    }
    public static async RadiologyTestPatientInfoReportQuery(PARAMOBJID: string): Promise<Array<RadiologyTest.RadiologyTestPatientInfoReportQuery_Class>> {
        let url: string = "/api/RadiologyTestService/RadiologyTestPatientInfoReportQuery";
        let input = { "PARAMOBJID": PARAMOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest.RadiologyTestPatientInfoReportQuery_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetCancelledRadiologyTest(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<RadiologyTest.OLAP_GetCancelledRadiologyTest_Class>> {
        let url: string = "/api/RadiologyTestService/OLAP_GetCancelledRadiologyTest";
        let input = { "FIRSTDATE": FIRSTDATE, "LASTDATE": LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest.OLAP_GetCancelledRadiologyTest_Class>>(url, input);
        return result;
    }
    public static async GetByWLFilterExpression(injectionSQL: string): Promise<Array<RadiologyTest>> {
        let url: string = "/api/RadiologyTestService/GetByWLFilterExpression";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest>>(url, input);
        return result;
    }
    public static async RadiologyTestByObjectIDQuery(PARAMTESTOBJID: string): Promise<Array<RadiologyTest.RadiologyTestByObjectIDQuery_Class>> {
        let url: string = "/api/RadiologyTestService/RadiologyTestByObjectIDQuery";
        let input = { "PARAMTESTOBJID": PARAMTESTOBJID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest.RadiologyTestByObjectIDQuery_Class>>(url, input);
        return result;
    }
    public static async GetRadiologyTestByEpisode(EPISODE: Guid): Promise<Array<RadiologyTest.GetRadiologyTestByEpisode_Class>> {
        let url: string = "/api/RadiologyTestService/GetRadiologyTestByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest.GetRadiologyTestByEpisode_Class>>(url, input);
        return result;
    }
    public static async GetRadTestByEpisode(EPISODE: Guid): Promise<Array<RadiologyTest>> {
        let url: string = "/api/RadiologyTestService/GetRadTestByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest>>(url, input);
        return result;
    }
    public static async GetRadTestBySubEpisode(SUBEPISODE: Guid, EPISODE: string): Promise<Array<RadiologyTest>> {
        let url: string = "/api/RadiologyTestService/GetRadTestBySubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE, "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest>>(url, input);
        return result;
    }
    public static async GetRadiologyTestBySubEpisode(SUBEPISODE: string): Promise<Array<RadiologyTest.GetRadiologyTestBySubEpisode_Class>> {
        let url: string = "/api/RadiologyTestService/GetRadiologyTestBySubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest.GetRadiologyTestBySubEpisode_Class>>(url, input);
        return result;
    }
    public static async GetByRadTestWorklistDateReport(STARTDATE: Date, ENDDATE: Date, injectionSQL: string): Promise<Array<RadiologyTest.GetByRadTestWorklistDateReport_Class>> {
        let url: string = "/api/RadiologyTestService/GetByRadTestWorklistDateReport";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest.GetByRadTestWorklistDateReport_Class>>(url, input);
        return result;
    }
    public static async GetRadiologyTestStatisticsByFilter(injectionSQL: string): Promise<Array<RadiologyTest.GetRadiologyTestStatisticsByFilter_Class>> {
        let url: string = "/api/RadiologyTestService/GetRadiologyTestStatisticsByFilter";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest.GetRadiologyTestStatisticsByFilter_Class>>(url, input);
        return result;
    }
    public static async GetByRadTestFilterExpressionReport(injectionSQL: string): Promise<Array<RadiologyTest.GetByRadTestFilterExpressionReport_Class>> {
        let url: string = "/api/RadiologyTestService/GetByRadTestFilterExpressionReport";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest.GetByRadTestFilterExpressionReport_Class>>(url, input);
        return result;
    }
    public static async GetByFilterExpressionStatistics(injectionSQL: string): Promise<Array<RadiologyTest>> {
        let url: string = "/api/RadiologyTestService/GetByFilterExpressionStatistics";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest>>(url, input);
        return result;
    }
    public static async VEM_RADYOLOJI_SONUC(): Promise<Array<RadiologyTest.VEM_RADYOLOJI_SONUC_Class>> {
        let url: string = "/api/RadiologyTestService/VEM_RADYOLOJI_SONUC";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<RadiologyTest.VEM_RADYOLOJI_SONUC_Class>>(url, input);
        return result;
    }
}