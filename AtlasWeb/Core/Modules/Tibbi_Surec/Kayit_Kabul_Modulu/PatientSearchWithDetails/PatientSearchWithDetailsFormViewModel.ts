
import { BaseModel } from 'Fw/Models/BaseModel';
import { SKRSILKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class PatientSearchWithDetailsFormViewModel extends BaseModel {

    public Name: string;
    public Surname: string;
    public MotherName: string;
    public FatherName: string;
    @Type('SKRSILKodlari')
    public CityOfBirth: SKRSILKodlari;
    public DoctorName: string;
    public policlinicName: string;
    public UniqueRefNo: string;
    public Age: string; s;
    public AdmissionPoliclinic: string;
    public Payer: string;
    public AdmissionType: string;
    @Type(() => Date)
    public BirthDate: Date;
    public BirthPlace: string;
    @Type(() => Date)
    public AdmissionDateFirst: Date;
    @Type(() => Date)
    public AdmissionDateSecond: Date;
    @Type(() => Date)
    public AdmissionTimeFirst: Date;
    @Type(() => Date)
    public AdmissionTimeSecond: Date;

    public DispatchNumber: string;
    public DistrictPoliclinicName: string;
    public PatientInServiceName: string;
    public PasaportNo: string;

}
