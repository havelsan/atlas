//$EF323170
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PatientIdentityAndAddress } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSILKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSUlkeKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKanGrubu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSYabanciHastaTuru } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMedeniHali } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOzurlulukDurumu } from 'NebulaClient/Model/AtlasClientModel';
export class NewPatientFormViewModel extends BaseViewModel {
    @Type(() => Patient)
    public _Patient: Patient = new Patient();
    @Type('PatientIdentityAndAddress')
    public PatientIdentityAndAddresss: Array<PatientIdentityAndAddress> = new Array<PatientIdentityAndAddress>();
    @Type('SKRSCinsiyet')
    public SKRSCinsiyets: Array<SKRSCinsiyet> = new Array<SKRSCinsiyet>();
    @Type('SKRSILKodlari')
    public SKRSILKodlaris: Array<SKRSILKodlari> = new Array<SKRSILKodlari>();
    @Type('SKRSUlkeKodlari')
    public SKRSUlkeKodlaris: Array<SKRSUlkeKodlari> = new Array<SKRSUlkeKodlari>();
    @Type('SKRSMeslekler')
    public SKRSMesleklers: Array<SKRSMeslekler> = new Array<SKRSMeslekler>();
    @Type('SKRSOgrenimDurumu')
    public SKRSOgrenimDurumus: Array<SKRSOgrenimDurumu> = new Array<SKRSOgrenimDurumu>();
    @Type('SKRSKanGrubu')
    public SKRSKanGrubus: Array<SKRSKanGrubu> = new Array<SKRSKanGrubu>();
    @Type(() => SKRSYabanciHastaTuru)
    public SKRSYabanciHastaTurus: Array<SKRSYabanciHastaTuru> = new Array<SKRSYabanciHastaTuru>();
    @Type(() => SKRSOzurlulukDurumu)
    public SKRSOzurlulukDurumus: Array<SKRSOzurlulukDurumu> = new Array<SKRSOzurlulukDurumu>();
    @Type(() => SKRSMedeniHali)
    public SKRSMaritalStatuss: Array<SKRSMedeniHali> = new Array<SKRSMedeniHali>();
    @Type(() => Boolean)
    public GizliHastaKabulRole: boolean;
    @Type(() => Boolean)
    public ModifyPatientInfoRole: boolean = false;
    public tempName: string = "";
    public tempSurname: string = "";
    public tempPrivacyName: string = "";
    public tempPrivacySurname: string = "";
    public tempHomeAddress: string = "";
    public tempMobilePhone: string = "";
    //@Type(() => Number)
    public tempUniqueRefNo: number;
    public PhotoString: string;
}
