//$0D942CE7
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PatientInterviewForm } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMedeniHali } from 'NebulaClient/Model/AtlasClientModel';
import { SocServAppliedProcedures } from 'NebulaClient/Model/AtlasClientModel';
import { SocServPatientFamilyInfo } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoom } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PatientIdentityAndAddress } from 'NebulaClient/Model/AtlasClientModel';
import { PayerDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class SocialServicesPatientInterviewFormViewModel extends BaseViewModel {
    @Type(() => PatientInterviewForm)
    public _PatientInterviewForm: PatientInterviewForm = new PatientInterviewForm();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => SKRSMeslekler)
    public SKRSMesleklers: Array<SKRSMeslekler> = new Array<SKRSMeslekler>();
    @Type(() => SKRSOgrenimDurumu)
    public SKRSOgrenimDurumus: Array<SKRSOgrenimDurumu> = new Array<SKRSOgrenimDurumu>();
    @Type(() => SKRSMedeniHali)
    public SKRSMaritalStatuss: Array<SKRSMedeniHali> = new Array<SKRSMedeniHali>();
    @Type(() => SocServAppliedProcedures)
    public SocServAppliedProceduress: Array<SocServAppliedProcedures> = new Array<SocServAppliedProcedures>();
    @Type(() => SocServPatientFamilyInfo)
    public SocServPatientFamilyInfos: Array<SocServPatientFamilyInfo> = new Array<SocServPatientFamilyInfo>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => ResRoom)
    public ResRooms: Array<ResRoom> = new Array<ResRoom>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => PatientIdentityAndAddress)
    public PatientIdentityAndAddresss: Array<PatientIdentityAndAddress> = new Array<PatientIdentityAndAddress>();
    @Type(() => PayerDefinition)
    public PayerDefinitions: Array<PayerDefinition> = new Array<PayerDefinition>();
    @Type(() => ResUser)
    ReportSelectedUser: ResUser = new ResUser();

    public CompanionName: string;
    public CompanionPhoneNumber: string;
    public RoomName: string;
    public PayerName: string;
    public Diagnosis: string;
}
