import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { BaseModel } from 'Fw/Models/BaseModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class PatientDemographicsViewModel extends BaseModel {
    public IsPrivacyPatient: boolean;

    @Type(() => Number)
    public ShowType: number;

    public name: string;
    public surname: string;
    public fatherName: string;
    public age: string;
    public BirthDate: string;
    public importantPatientInfo: string;
    public refNo: string;
    public payerName: string;
    public policlinicName: string;
    public admissionDate: string;
    public formattedRequestDate: string;
    public admissionType: string;
    public provisionNo: string;
    public archiveNo: string;
    public hospitalProtocolNo: string;
    public profilPhotoPath: string;
    public gender: string;
    public admissionDoctor: string;
    public patientGuidID: string;
    public medicalInformationGuidID: string;
    @Type(() => Boolean)
    public hasMedicalInformation: boolean;
    @Type(() => Boolean)
    public isPregnant: boolean;
    public pregnancyWeekInfo: string;
    @Type(() => Boolean)
    public isHighRiskPregnant: boolean;
    @Type(() => Boolean)
    public Pandemic: boolean;

    public inpatientClinicDate: string;
    public responsibleNurse: string;
    public InpatientClinicDischargeDate: string;
    public InpatientDay: string;
    public InpatientType: string;
    public IsInpatientTypeDischarge: boolean;
    public ClinicProtocolNo: string;
    public RoomGroup: string;
    public Room: string;
    public Bed: string;
    public SubEpisodeProtocolNo: string;
    public PoliclinicProtocolNo: string;
    public ExaminationProcessAndEndDate: string;

    public PatientClassGroup: string;
    public ApplicationReason: string;
    public MedulaSigortaTuru: string;
    public PatientType: string;
    public bloodGroup: string;
    @Type(() => Boolean)
    public IsPatientAllergic: boolean;
    @Type(() => Boolean)
    public HasAirborneContactIsolation: boolean;
    @Type(() => Boolean)
    public HasContactIsolation: boolean;
    @Type(() => Boolean)
    public HasDropletIsolation: boolean;
    @Type(() => Boolean)
    public HasTightContactIsolation: boolean;
    @Type(() => Boolean)
    public HasFallingRisk: boolean;

    public allergyDetail: AllergyTypesDetails;

    public ArchiveNo: string;
}

export class PatientDetailsViewModel {
    public IsPrivacyPatient: boolean;
    public PatientIdentifier: string;
    public PatientName: string;
    public PatientSurname: string;
    public MotherName: string;
    public FatherName: string;
    public RelativeFullName: string;
    public RelativeMobilePhone: string;
    public BirthPlace: string;
    public BirthDate: string;
    public Sex: string;
    public Nationality: string;
    public MobilePhone: string;
    public Address: string;
}

export class DynamicComponentInfoDVO {
    public ComponentName: string;
    public ModuleName: string;
    public ModulePath: string;
    public objectID: string;
    @Type(() => Guid)
    public episodeObjectID: Guid;
    @Type(() => Guid)
    public patientObjectID: Guid;

}

export class AllergyTypesDetails {
    public foodAllergies: string;
    public drugAllergies: string;
}