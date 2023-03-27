//$965DD71B
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { SKRSUlkeKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSILKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { MernisPatientModel } from "./PatientAdmissionFormViewModel";
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { SKRSMedeniHali } from 'NebulaClient/Model/AtlasClientModel';
export class PatientCompareFormViewModel extends BaseViewModel {
    @Type(() => Patient)
    public _Patient: Patient = new Patient();
    @Type('SKRSUlkeKodlari')
    public SKRSUlkeKodlaris: Array<SKRSUlkeKodlari> = new Array<SKRSUlkeKodlari>();
    @Type('SKRSCinsiyet')
    public SKRSCinsiyets: Array<SKRSCinsiyet> = new Array<SKRSCinsiyet>();
    @Type('SKRSILKodlari')
    public SKRSILKodlaris: Array<SKRSILKodlari> = new Array<SKRSILKodlari>();
    public _KPSInfo: MernisPatientModel = new MernisPatientModel();
    @Type(() => SKRSMedeniHali)
    public SKRSMaritalStatuss: Array<SKRSMedeniHali> = new Array<SKRSMedeniHali>();
    @Type(() => Boolean)
    public KimlikBilgileriDuzeltme: boolean = false;

    public HomeAddress: string = "";

}
