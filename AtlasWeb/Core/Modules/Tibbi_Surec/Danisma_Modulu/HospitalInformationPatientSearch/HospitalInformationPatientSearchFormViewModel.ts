
import { SKRSCinsiyet, ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Type } from 'app/NebulaClient/ClassTransformer';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
export class HospitalInformationPatientSearchFormViewModel extends  BaseViewModel  {

    public ObjectID: string;
    public ObjectDefID: string;
    public ID: number;
    public UnicRefNo: string;
    public PassportNo: string;
    public Surname: string;
    public Name: string;
    public AdmissionNumber: string;
    public MotherName: string;
    public FatherName: string;
    public BirthCity: string;
    public Sex: SKRSCinsiyet;

    public BirthDate: Date;
    public AdmissionDateFirst: Date;
    public AdmissionDateSecond: Date;
    public isOutPatient: Boolean = false;
    @Type(() => ResourceModel)
    public InpatientResources: Array<ResourceModel>;
    @Type(() => ResourceModel)
    ResourceListOutPatient: Array<ResourceModel> = new Array<ResourceModel>();
    @Type(() => ResourceModel)
    ResourceListInPatient: Array<ResourceModel> = new Array<ResourceModel>();
    @Type(() => ResourceModel)
    public OutpatientResources: Array<ResourceModel>;
}
export class ResourceModel{
    public Name: string;
    public ID: Guid;
}