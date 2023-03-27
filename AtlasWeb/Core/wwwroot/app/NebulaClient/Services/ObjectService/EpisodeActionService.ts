//$BBAA70D4
import { ActionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Appointment } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Resource } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { TTObjectContext } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectContext';

export class EpisodeActionService {
    public static async GetMyNewAppointments(objectID: Guid): Promise<Array<Appointment>> {
        let url: string = "/api/EpisodeActionService/GetMyNewAppointments";
        let input = { "objectID": objectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async MyCompletedAppointments(objectID: Guid): Promise<Array<Appointment>> {
        let url: string = "/api/EpisodeActionService/MyCompletedAppointments";
        let input = { "objectID": objectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Appointment>>(url, input);
        return result;
    }
    public static async DiagnosisIsRequired(episodeAction: EpisodeAction): Promise<void> {
        let url: string = "/api/EpisodeActionService/DiagnosisIsRequired";
        let input = { "episodeAction": episodeAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async GetProcedureDefinitionNames(objectDefName: string): Promise<string> {
        let url: string = "/api/EpisodeActionService/GetProcedureDefinitionNames";
        let input = { "objectDefName": objectDefName };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetAvailableUserResourcesByAllocation(episode: Episode, episodeAction: EpisodeAction): Promise<Array<Resource>> {
        let url: string = "/api/EpisodeActionService/GetAvailableUserResourcesByAllocation";
        let input = { "episode": episode, "episodeAction": episodeAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Resource>>(url, input);
        return result;
    }
    public static async AcionDefualtMasterResources(context: TTObjectContext, actionType: ActionTypeEnum, episodeAction: EpisodeAction): Promise<Array<ResSection>> {
        let url: string = "/api/EpisodeActionService/AcionDefualtMasterResources";
        let input = { "context": context, "actionType": actionType, "episodeAction": episodeAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResSection>>(url, input);
        return result;
    }
    public static async LimitedMasterResourceTypes(episodeAction: EpisodeAction): Promise<Array<any>> {
        let url: string = "/api/EpisodeActionService/LimitedMasterResourceTypes";
        let input = { "episodeAction": episodeAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<any>>(url, input);
        return result;
    }
    public static async SetProcedureSpecialtyBy(objectDefID: Guid): Promise<string> {
        let url: string = "/api/EpisodeActionService/SetProcedureSpecialtyBy";
        let input = { "objectDefID": objectDefID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetLinkedEpisodeActions(episodeActionParam: EpisodeAction): Promise<Array<any>> {
        let url: string = "/api/EpisodeActionService/GetLinkedEpisodeActions";
        let input = { "episodeActionParam": episodeActionParam };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<any>>(url, input);
        return result;
    }
    public static async CheckPaid(episodeActionObjectID: Guid): Promise<void> {
        let url: string = "/api/EpisodeActionService/CheckPaid";
        let input = { "episodeActionObjectID": episodeActionObjectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
        return result;
    }
    public static async CheckProvision(episodeActionObjectID: Guid): Promise<boolean> {
        let url: string = "/api/EpisodeActionService/CheckProvision";        
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let input = { "episodeActionObjectID": episodeActionObjectID };
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async CheckInvoicedCompletely(episodeActionObjectID: Guid): Promise<boolean> {
        let url: string = "/api/EpisodeActionService/CheckInvoicedCompletely";        
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let input = { "episodeActionObjectID": episodeActionObjectID };
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async IsFiredByPatientAdmission(episodeAction: EpisodeAction): Promise<boolean> {
        let url: string = "/api/EpisodeActionService/IsFiredByPatientAdmission";
        let input = { "episodeAction": episodeAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async CheckAndCloseEpisode(episodeActionObjectID: Guid): Promise<void> {
        let url: string = "/api/EpisodeActionService/CheckAndCloseEpisode";
        let input = { "episodeActionObjectID": episodeActionObjectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
    }
    public static async GetSpecialResourceForStore(episodeAction: EpisodeAction): Promise<Resource> {
        let url: string = "/api/EpisodeActionService/GetSpecialResourceForStore";
        let input = { "episodeAction": episodeAction };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Resource>(url, input);
        return result;
    }
    public static async GetAllExaminationsOfPatient(PATIENTOBJECTID: string): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetAllExaminationsOfPatient";
        let input = { "PATIENTOBJECTID": PATIENTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetBirthEpisodeAction(injectionSQL: string): Promise<Array<EpisodeAction.GetBirthEpisodeAction_Class>> {
        let url: string = "/api/EpisodeActionService/GetBirthEpisodeAction";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetBirthEpisodeAction_Class>>(url, input);
        return result;
    }
    public static async GetPatientInfoByEpisodeAction(EPISODEACTION: string): Promise<Array<EpisodeAction.GetPatientInfoByEpisodeAction_Class>> {
        let url: string = "/api/EpisodeActionService/GetPatientInfoByEpisodeAction";
        let input = { "EPISODEACTION": EPISODEACTION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetPatientInfoByEpisodeAction_Class>>(url, input);
        return result;
    }
    public static async GetEpisodeActionsByEpisode(EPISODE: string): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetEpisodeActionsByEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetAllConsFromOtherHospOfPatient(PATIENTOBJECTID: string): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetAllConsFromOtherHospOfPatient";
        let input = { "PATIENTOBJECTID": PATIENTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetUnCompletedEAByActiondate(ACTIONDATE: Date, MASTERRESOURCE: string): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetUnCompletedEAByActiondate";
        let input = { "ACTIONDATE": ACTIONDATE, "MASTERRESOURCE": MASTERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetEpisodesNotExistsMTS(STARTDATE: Date, ENDDATE: Date): Promise<Array<EpisodeAction.GetEpisodesNotExistsMTS_Class>> {
        let url: string = "/api/EpisodeActionService/GetEpisodesNotExistsMTS";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetEpisodesNotExistsMTS_Class>>(url, input);
        return result;
    }
    public static async GetConsFromOtherHospOfSubEpisode(SUBEPISODE: Guid, EPISODE: string): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetConsFromOtherHospOfSubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE, "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetPoliclinicExaminationDetail(STARTDATE: Date, ENDDATE: Date, MASTERRESOURCE: Guid): Promise<Array<EpisodeAction.GetPoliclinicExaminationDetail_Class>> {
        let url: string = "/api/EpisodeActionService/GetPoliclinicExaminationDetail";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "MASTERRESOURCE": MASTERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetPoliclinicExaminationDetail_Class>>(url, input);
        return result;
    }
    public static async GetEmergencyAdmissionCount(STARTDATE: Date, ENDDATE: Date): Promise<Array<EpisodeAction.GetEmergencyAdmissionCount_Class>> {
        let url: string = "/api/EpisodeActionService/GetEmergencyAdmissionCount";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetEmergencyAdmissionCount_Class>>(url, input);
        return result;
    }
    public static async GetByEpisodeOrderByRequestDate(EPISODE: Guid): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetByEpisodeOrderByRequestDate";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetEpisodeActionsByRequestDate(STARTDATE: Date, ENDDATE: Date, MASTERRESOURCE: Guid): Promise<Array<EpisodeAction.GetEpisodeActionsByRequestDate_Class>> {
        let url: string = "/api/EpisodeActionService/GetEpisodeActionsByRequestDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "MASTERRESOURCE": MASTERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetEpisodeActionsByRequestDate_Class>>(url, input);
        return result;
    }
    public static async GetByWorklistDate(STARTDATE: Date, ENDDATE: Date, MINDATE: Date, injectionSQL: string): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetByWorklistDate";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "MINDATE": MINDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetInpatientFolderInfoForIAandNA(EPISODEACTION: Guid): Promise<Array<EpisodeAction.GetInpatientFolderInfoForIAandNA_Class>> {
        let url: string = "/api/EpisodeActionService/GetInpatientFolderInfoForIAandNA";
        let input = { "EPISODEACTION": EPISODEACTION };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetInpatientFolderInfoForIAandNA_Class>>(url, input);
        return result;
    }
    public static async GetAllPatientExaminationsOfPatient(PATIENT: Guid): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetAllPatientExaminationsOfPatient";
        let input = { "PATIENT": PATIENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetEHREpisodeActionSubactProcFlowablesTotalAmount(PROCEDUREID: Guid, EPISODEACTIONID: Guid): Promise<Array<EpisodeAction.GetEHREpisodeActionSubactProcFlowablesTotalAmount_Class>> {
        let url: string = "/api/EpisodeActionService/GetEHREpisodeActionSubactProcFlowablesTotalAmount";
        let input = { "PROCEDUREID": PROCEDUREID, "EPISODEACTIONID": EPISODEACTIONID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetEHREpisodeActionSubactProcFlowablesTotalAmount_Class>>(url, input);
        return result;
    }
    public static async GetUnCompletedEpisodeActionsByEpisode(EPISODE: Guid, EAOBJECTID: Guid): Promise<Array<EpisodeAction.GetUnCompletedEpisodeActionsByEpisode_Class>> {
        let url: string = "/api/EpisodeActionService/GetUnCompletedEpisodeActionsByEpisode";
        let input = { "EPISODE": EPISODE, "EAOBJECTID": EAOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetUnCompletedEpisodeActionsByEpisode_Class>>(url, input);
        return result;
    }
    public static async GetByEpisodeActionFilterExpressionReport(injectionSQL: string): Promise<Array<EpisodeAction.GetByEpisodeActionFilterExpressionReport_Class>> {
        let url: string = "/api/EpisodeActionService/GetByEpisodeActionFilterExpressionReport";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetByEpisodeActionFilterExpressionReport_Class>>(url, input);
        return result;
    }
    public static async GetByFilterExpression(injectionSQL: string): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetByFilterExpression";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetEndOfDayPoliclinicReport(ENDDATE: Date, STARTDATE: Date, MASTERRESOURCE: Guid): Promise<Array<EpisodeAction.GetEndOfDayPoliclinicReport_Class>> {
        let url: string = "/api/EpisodeActionService/GetEndOfDayPoliclinicReport";
        let input = { "ENDDATE": ENDDATE, "STARTDATE": STARTDATE, "MASTERRESOURCE": MASTERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetEndOfDayPoliclinicReport_Class>>(url, input);
        return result;
    }
    public static async GetByEpisodeAndId(EPISODE: string, ID: Array<string>): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetByEpisodeAndId";
        let input = { "EPISODE": EPISODE, "ID": ID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetByEpisodeActionWorklistDateReport(STARTDATE: Date, ENDDATE: Date, MINDATE: Date, injectionSQL: string): Promise<Array<EpisodeAction.GetByEpisodeActionWorklistDateReport_Class>> {
        let url: string = "/api/EpisodeActionService/GetByEpisodeActionWorklistDateReport";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "MINDATE": MINDATE, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetByEpisodeActionWorklistDateReport_Class>>(url, input);
        return result;
    }
    public static async GetEpisodeActionsCount(STARTDATE: Date, ENDDATE: Date): Promise<Array<EpisodeAction.GetEpisodeActionsCount_Class>> {
        let url: string = "/api/EpisodeActionService/GetEpisodeActionsCount";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetEpisodeActionsCount_Class>>(url, input);
        return result;
    }
    public static async GetByMasterAction(MASTERACTIONOBJECTID: string): Promise<Array<EpisodeAction.GetByMasterAction_Class>> {
        let url: string = "/api/EpisodeActionService/GetByMasterAction";
        let input = { "MASTERACTIONOBJECTID": MASTERACTIONOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetByMasterAction_Class>>(url, input);
        return result;
    }
    public static async GetEpisodeActionByID(ID: string): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetEpisodeActionByID";
        let input = { "ID": ID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetLaboratoryRequestActionOfEpisode(EPISODE: string): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetLaboratoryRequestActionOfEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetEHREpisodeActionSubactionProcedures(PROCEDUREID: Guid, EPISODEACTIONID: Guid, injectionSQL: string): Promise<Array<EpisodeAction.GetEHREpisodeActionSubactionProcedures_Class>> {
        let url: string = "/api/EpisodeActionService/GetEHREpisodeActionSubactionProcedures";
        let input = { "PROCEDUREID": PROCEDUREID, "EPISODEACTIONID": EPISODEACTIONID, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetEHREpisodeActionSubactionProcedures_Class>>(url, input);
        return result;
    }
    public static async GetAllAnesthesiaConsultationOfEpisode(EPISODEOBJECTID: string): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetAllAnesthesiaConsultationOfEpisode";
        let input = { "EPISODEOBJECTID": EPISODEOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetPoliclinicAdmissionCount(STARTDATE: Date, ENDDATE: Date): Promise<Array<EpisodeAction.GetPoliclinicAdmissionCount_Class>> {
        let url: string = "/api/EpisodeActionService/GetPoliclinicAdmissionCount";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetPoliclinicAdmissionCount_Class>>(url, input);
        return result;
    }
    public static async GetEpisodeActionsByObjectIDs(OBJECTIDS: Array<string>): Promise<Array<EpisodeAction.GetEpisodeActionsByObjectIDs_Class>> {
        let url: string = "/api/EpisodeActionService/GetEpisodeActionsByObjectIDs";
        let input = { "OBJECTIDS": OBJECTIDS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetEpisodeActionsByObjectIDs_Class>>(url, input);
        return result;
    }
    public static async GetEHREpisodeActionDiagnosis(EPISODEACTIONID: Guid, injectionSQL: string): Promise<Array<EpisodeAction.GetEHREpisodeActionDiagnosis_Class>> {
        let url: string = "/api/EpisodeActionService/GetEHREpisodeActionDiagnosis";
        let input = { "EPISODEACTIONID": EPISODEACTIONID, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetEHREpisodeActionDiagnosis_Class>>(url, input);
        return result;
    }
    public static async GetExaminationsOfEpisode(EPISODE: string): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetExaminationsOfEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetConsFromOtherHospOfEpisode(EPISODE: string): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetConsFromOtherHospOfEpisode";
        let input = { "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetAllAnesthesiaConsultationOfPatient(PATIENTOBJECTID: string): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetAllAnesthesiaConsultationOfPatient";
        let input = { "PATIENTOBJECTID": PATIENTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetEpisodeActionsOfPatientToInsertIntoQueue(PATIENT: Guid): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetEpisodeActionsOfPatientToInsertIntoQueue";
        let input = { "PATIENT": PATIENT };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetEHREpisodeActionSubactionMaterialsTotalAmount(EPISODEACTIONID: Guid, MATERIALID: Guid): Promise<Array<EpisodeAction.GetEHREpisodeActionSubactionMaterialsTotalAmount_Class>> {
        let url: string = "/api/EpisodeActionService/GetEHREpisodeActionSubactionMaterialsTotalAmount";
        let input = { "EPISODEACTIONID": EPISODEACTIONID, "MATERIALID": MATERIALID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetEHREpisodeActionSubactionMaterialsTotalAmount_Class>>(url, input);
        return result;
    }
    public static async GetEHREpisodeActionSubactionProceduresTotalAmount(EPISODEACTIONID: Guid, PROCEDUREID: Guid): Promise<Array<EpisodeAction.GetEHREpisodeActionSubactionProceduresTotalAmount_Class>> {
        let url: string = "/api/EpisodeActionService/GetEHREpisodeActionSubactionProceduresTotalAmount";
        let input = { "EPISODEACTIONID": EPISODEACTIONID, "PROCEDUREID": PROCEDUREID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetEHREpisodeActionSubactionProceduresTotalAmount_Class>>(url, input);
        return result;
    }
    public static async GetClinicStatisticsByDateDiagnosisAndPoliclinics(STARTDATE: Date, ENDDATE: Date, MASTERRESOURCE: Guid, DIAGNOSIS: Array<string>): Promise<Array<EpisodeAction.GetClinicStatisticsByDateDiagnosisAndPoliclinics_Class>> {
        let url: string = "/api/EpisodeActionService/GetClinicStatisticsByDateDiagnosisAndPoliclinics";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "MASTERRESOURCE": MASTERRESOURCE, "DIAGNOSIS": DIAGNOSIS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetClinicStatisticsByDateDiagnosisAndPoliclinics_Class>>(url, input);
        return result;
    }
    public static async GetEpisodeActionByObjectID(OBJECTID: Guid): Promise<Array<EpisodeAction.GetEpisodeActionByObjectID_Class>> {
        let url: string = "/api/EpisodeActionService/GetEpisodeActionByObjectID";
        let input = { "OBJECTID": OBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetEpisodeActionByObjectID_Class>>(url, input);
        return result;
    }
    public static async GetAllExaminationsExceptCurrentExamination(MASTERRESOURCE: Guid, PATIENT: string, OBJECTID: Guid, REQUESTDATE: Date): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetAllExaminationsExceptCurrentExamination";
        let input = { "MASTERRESOURCE": MASTERRESOURCE, "PATIENT": PATIENT, "OBJECTID": OBJECTID, "REQUESTDATE": REQUESTDATE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetAllDentalExaminationsOfPatient(PATIENTOBJECTID: string): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetAllDentalExaminationsOfPatient";
        let input = { "PATIENTOBJECTID": PATIENTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetPatientFolderEpisodeActions(EPISODEID: Guid): Promise<Array<EpisodeAction.GetPatientFolderEpisodeActions_Class>> {
        let url: string = "/api/EpisodeActionService/GetPatientFolderEpisodeActions";
        let input = { "EPISODEID": EPISODEID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetPatientFolderEpisodeActions_Class>>(url, input);
        return result;
    }
    public static async GetOutPatientsByPatientObjectIDs(STARTDATE: Date, ENDDATE: Date, PATIENTOBJECTIDS: Array<Guid>): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetOutPatientsByPatientObjectIDs";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "PATIENTOBJECTIDS": PATIENTOBJECTIDS };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetAllAnesthesiaConsultationOfSubEpisode(SUBEPISODE: string, EPISODE: string): Promise<Array<EpisodeAction>> {
        let url: string = "/api/EpisodeActionService/GetAllAnesthesiaConsultationOfSubEpisode";
        let input = { "SUBEPISODE": SUBEPISODE, "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction>>(url, input);
        return result;
    }
    public static async GetActionDetailNQLByEpisode(RESOURCE: Guid, EPISODE: string): Promise<Array<EpisodeAction.GetActionDetailNQLByEpisode_Class>> {
        let url: string = "/api/EpisodeActionService/GetActionDetailNQLByEpisode";
        let input = { "RESOURCE": RESOURCE, "EPISODE": EPISODE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetActionDetailNQLByEpisode_Class>>(url, input);
        return result;
    }
    public static async GetEpisodeActionsGroupByHasApp(STARTDATE: Date, ENDDATE: Date, MASTERRESOURCE: Guid): Promise<Array<EpisodeAction.GetEpisodeActionsGroupByHasApp_Class>> {
        let url: string = "/api/EpisodeActionService/GetEpisodeActionsGroupByHasApp";
        let input = { "STARTDATE": STARTDATE, "ENDDATE": ENDDATE, "MASTERRESOURCE": MASTERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<EpisodeAction.GetEpisodeActionsGroupByHasApp_Class>>(url, input);
        return result;
    }
}