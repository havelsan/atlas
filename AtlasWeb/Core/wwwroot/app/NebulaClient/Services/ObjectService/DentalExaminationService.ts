//$685E0D9A
import { DentalExamination } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DentalProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { DentalProsthesisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { TedaviRaporiIslemKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveMedulaProvision } from 'Modules/Tibbi_Surec/Dis_Muayene_Modulu/OrtodontiFormViewModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class DentalExaminationService {
    public static async GetUnCompletedDentalExams(PATIENT: string): Promise<Array<DentalExamination>> {
        let url: string = '/api/DentalExaminationService/GetUnCompletedDentalExams';
        let input = { 'PATIENT': PATIENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DentalExamination>>(url, input);
        return result;
    }
    public static async OLAP_GetDentalExamination(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<DentalExamination.OLAP_GetDentalExamination_Class>> {
        let url: string = '/api/DentalExaminationService/OLAP_GetDentalExamination';
        let input = { 'FIRSTDATE': FIRSTDATE, 'LASTDATE': LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DentalExamination.OLAP_GetDentalExamination_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetCancelledDentalExamination(FIRSTDATE: Date, LASTDATE: Date): Promise<Array<DentalExamination.OLAP_GetCancelledDentalExamination_Class>> {
        let url: string = '/api/DentalExaminationService/OLAP_GetCancelledDentalExamination';
        let input = { 'FIRSTDATE': FIRSTDATE, 'LASTDATE': LASTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DentalExamination.OLAP_GetCancelledDentalExamination_Class>>(url, input);
        return result;
    }
    public static async GetExcludesDentalProceduresAreCompleted(STATE: Array<Guid>, STARTDATE: Date, ENDDATE: Date): Promise<Array<DentalExamination>> {
        let url: string = '/api/DentalExaminationService/GetExcludesDentalProceduresAreCompleted';
        let input = { 'STATE': STATE, 'STARTDATE': STARTDATE, 'ENDDATE': ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DentalExamination>>(url, input);
        return result;
    }

    public static async GetDentalProcedures(): Promise<Array<ProcedureDefinition>> {
        let url: string = '/api/DentalExaminationService/GetDentalProcedures';
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ProcedureDefinition>>(url, null);
        return result;
    }

    public static async AddDentalProcedures(checkList: Array<string>, procedureList: Array<ProcedureDefinition>, dentalExamination: DentalExamination): Promise<Array<DentalProcedure>> {
        let url: string = '/api/DentalExaminationService/AddDentalProcedures';
        let input = { 'checkList': checkList, 'procedureList': procedureList, 'dentalExamination': dentalExamination };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DentalProcedure>>(url, input);
        return result;
    }

    public static async MustehaklikKontrol(dentalProcedure: DentalProcedure, dentalExamination: DentalExamination, procedureDefinition: ProcedureDefinition): Promise<AddDentalProcedures_Output> {
        let url: string = '/api/DentalExaminationService/MustehaklikKontrol';
        let input = { 'dentalProcedure': dentalProcedure, 'dentalExamination': dentalExamination, 'procedureDefinition': procedureDefinition };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<AddDentalProcedures_Output>(url, input);
        return result;
    }

    public static async GetDepartment(dentalProsthesisDefinition: DentalProsthesisDefinition): Promise<GetDepartment_Output> {
        let url: string = '/api/DentalExaminationService/GetDepartment';
        let input = { 'dentalProsthesisDefinition': dentalProsthesisDefinition };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<GetDepartment_Output>(url, input);
        return result;
    }

    public static async SaveOrtodontiForm(patient: Patient, tedaviRaporiIslemKodlari: TedaviRaporiIslemKodlari, reportTime: Date,
        txtFormNumarasi: string, activeMedulaProvision: ActiveMedulaProvision): Promise<SaveOrtodontiFormOutputDVO> {
        let url: string = '/api/DentalExaminationService/SaveOrtodontiForm';
        let input = {
            'patient': patient, 'tedaviRaporiIslemKodlari': tedaviRaporiIslemKodlari, 'reportTime': reportTime, 'txtFormNumarasi': txtFormNumarasi,
            'activeMedulaProvision': activeMedulaProvision
        };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<SaveOrtodontiFormOutputDVO>(url, input);
        return result;
    }

    public static async ReadOrtodontiForm(patient: Patient, tedaviRaporiIslemKodlari: TedaviRaporiIslemKodlari, txtFormNumarasi: string): Promise<ReadOrtodontiFormOutputDVO> {
        let url: string = '/api/DentalExaminationService/ReadOrtodontiForm';
        let input = { 'patient': patient, 'tedaviRaporiIslemKodlari': tedaviRaporiIslemKodlari, 'txtFormNumarasi': txtFormNumarasi };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ReadOrtodontiFormOutputDVO>(url, input);
        return result;
    }

    public static async DeleteOrtodontiForm(patient: Patient, tedaviRaporiIslemKodlari: TedaviRaporiIslemKodlari, txtFormNumarasi: string): Promise<ReadOrtodontiFormOutputDVO> {
        let url: string = '/api/DentalExaminationService/DeleteOrtodontiForm';
        let input = { 'patient': patient, 'tedaviRaporiIslemKodlari': tedaviRaporiIslemKodlari, 'txtFormNumarasi': txtFormNumarasi };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ReadOrtodontiFormOutputDVO>(url, input);
        return result;
    }

    public static async CalcPatientPrice(dentalProcedure: DentalProcedure, dentalExamination: DentalExamination, procedureDefinition: ProcedureDefinition): Promise<CalcPatientPrice_Output> {
        let url: string = '/api/DentalExaminationService/CalcPatientPrice';
        let input = { 'dentalProcedure': dentalProcedure, 'dentalExamination': dentalExamination, 'procedureDefinition': procedureDefinition };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<CalcPatientPrice_Output>(url, input);
        return result;
    }

    public static async Paid(dentalExaminationId: Guid): Promise<string> {
        let url: string = '/api/DentalExaminationService/Paid';
        let input = { 'dentalExaminationId': dentalExaminationId };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
}
export class AddDentalProcedures_Output {
    succsess: boolean;
    isRecourdable: boolean;
    errorMessage: string;
    resultMessage: string;
}

export class GetDepartment_Output {
    @Type(() => Date)
    actionDate: Date;
    department: ResSection;
}

export class SaveOrtodontiFormOutputDVO {
    public txtFormNumarasi: string;
    public txtSonucMesaji: string;
    public txtSonucKodu: string;
}

export class ReadOrtodontiFormOutputDVO {
    public txtFormNumarasi: string;
    public txtIslemTuru: string;
    public txtSonucKodu: string;
    public txtSonucMesaji: string;
    public txtProvizyonNo1: string;
    @Type(() => Date)
    public IslemTarihi1: Date;
    public txtTesis1: string;
    public txtProvizyonNo2: string;
    @Type(() => Date)
    public IslemTarihi2: Date;
    public txtTesis2: string;
    public txtProvizyonNo3: string;
    @Type(() => Date)
    public IslemTarihi3: Date;
    public txtTesis3: string;
}

export class CalcPatientPrice_Output {
    patientPrice: number;
}