//$D77B7EF8
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ParticipatnFreeDrugReport } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export class ParticipatnFreeDrugReportService {
    //public static async eraporGiris(pfr: ParticipatnFreeDrugReport): Promise<IlacRaporuServis.eraporGirisIstekDVO> {
    //    let url: string = '/api/ParticipatnFreeDrugReportService/eraporGiris';
    //    let input = { "pfr": pfr };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<eraporGirisIstekDVO>(url, input);
    //    return result;
    //}
    //public static async eraporSil(pfr: ParticipatnFreeDrugReport): Promise<eraporSilIstekDVO> {
    //    let url: string = '/api/ParticipatnFreeDrugReportService/eraporSil';
    //    let input = { "pfr": pfr };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<eraporSilIstekDVO>(url, input);
    //    return result;
    //}
    //public static async eraporSorgula(pfr: ParticipatnFreeDrugReport): Promise<eraporSorguIstekDVO> {
    //    let url: string = '/api/ParticipatnFreeDrugReportService/eraporSorgula';
    //    let input = { "pfr": pfr };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<eraporSorguIstekDVO>(url, input);
    //    return rebsult;
    //}
    //public static async eraporListeSorgula(pfr: ParticipatnFreeDrugReport): Promise<eraporListeSorguIstekDVO> {
    //    let url: string = '/api/ParticipatnFreeDrugReportService/eraporListeSorgula';
    //    let input = { "pfr": pfr };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<eraporListeSorguIstekDVO>(url, input);
    //    return result;
    //}
    //public static async eraporOnay(pfr: ParticipatnFreeDrugReport): Promise<eraporOnayIstekDVO> {
    //    let url: string = '/api/ParticipatnFreeDrugReportService/eraporOnay';
    //    let input = { "pfr": pfr };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<eraporOnayIstekDVO>(url, input);
    //    return result;
    //}
    //public static async eraporOnayRed(pfr: ParticipatnFreeDrugReport): Promise<eraporOnayRedIstekDVO> {
    //    let url: string = '/api/ParticipatnFreeDrugReportService/eraporOnayRed';
    //    let input = { "pfr": pfr };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<eraporOnayRedIstekDVO>(url, input);
    //    return result;
    //}
    //public static async eraporOnayBekleyenListeSorgu(pfr: ParticipatnFreeDrugReport): Promise<eraporOnayBekleyenListeSorguIstekDVO> {
    //    let url: string = '/api/ParticipatnFreeDrugReportService/eraporOnayBekleyenListeSorgu';
    //    let input = { "pfr": pfr };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<eraporOnayBekleyenListeSorguIstekDVO>(url, input);
    //    return result;
    //}
    //public static async eraporBashekimOnay(pfr: ParticipatnFreeDrugReport): Promise<eraporBashekimOnayIstekDVO> {
    //    let url: string = '/api/ParticipatnFreeDrugReportService/eraporBashekimOnay';
    //    let input = { "pfr": pfr };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<eraporBashekimOnayIstekDVO>(url, input);
    //    return result;
    //}
    //public static async eraporBashekimOnayRed(pfr: ParticipatnFreeDrugReport): Promise<eraporBashekimOnayRedIstekDVO> {
    //    let url: string = '/api/ParticipatnFreeDrugReportService/eraporBashekimOnayRed';
    //    let input = { "pfr": pfr };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<eraporBashekimOnayRedIstekDVO>(url, input);
    //    return result;
    //}
    //public static async eraporBashekimOnayBekleyenListeSorgu(pfr: ParticipatnFreeDrugReport): Promise<eraporBashekimOnayBekleyenListeSorguIstekDVO> {
    //    let url: string = '/api/ParticipatnFreeDrugReportService/eraporBashekimOnayBekleyenListeSorgu';
    //    let input = { "pfr": pfr };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<eraporBashekimOnayBekleyenListeSorguIstekDVO>(url, input);
    //    return result;
    //}
    //public static async eraporAciklamaEkle(pfr: ParticipatnFreeDrugReport): Promise<eraporAciklamaEkleIstekDVO> {
    //    let url: string = '/api/ParticipatnFreeDrugReportService/eraporAciklamaEkle';
    //    let input = { "pfr": pfr };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<eraporAciklamaEkleIstekDVO>(url, input);
    //    return result;
    //}
    //public static async eraporEtkinMaddeEkle(pfr: ParticipatnFreeDrugReport): Promise<eraporEtkinMaddeEkleIstekDVO> {
    //    let url: string = '/api/ParticipatnFreeDrugReportService/eraporEtkinMaddeEkle';
    //    let input = { "pfr": pfr };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<eraporEtkinMaddeEkleIstekDVO>(url, input);
    //    return result;
    //}
    //public static async eraporTaniEkle(pfr: ParticipatnFreeDrugReport): Promise<eraporTaniEkleIstekDVO> {
    //    let url: string = '/api/ParticipatnFreeDrugReportService/eraporTaniEkle';
    //    let input = { "pfr": pfr };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<eraporTaniEkleIstekDVO>(url, input);
    //    return result;
    //}
    //public static async eraporTeshisEkle(pfr: ParticipatnFreeDrugReport): Promise<eraporTeshisEkleIstekDVO> {
    //    let url: string = '/api/ParticipatnFreeDrugReportService/eraporTeshisEkle';
    //    let input = { "pfr": pfr };
    //    let httpService: NeHttpService = ServiceLocator.NeHttpService;
    //    let result = await httpService.post<eraporTeshisEkleIstekDVO>(url, input);
    //    return result;
    //}
    public static async GetParticipatnFreeDrugReportRNQL(TTOBJECTID: Guid): Promise<Array<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL_Class>> {
        let url: string = '/api/ParticipatnFreeDrugReportService/GetParticipatnFreeDrugReportRNQL';
        let input = { "TTOBJECTID": TTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL_Class>>(url, input);
        return result;
    }
    public static async GetCompletedBySubEpisode(SUBEPISODE: Guid): Promise<Array<ParticipatnFreeDrugReport>> {
        let url: string = '/api/ParticipatnFreeDrugReportService/GetCompletedBySubEpisode';
        let input = { "SUBEPISODE": SUBEPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ParticipatnFreeDrugReport>>(url, input);
        return result;
    }
}