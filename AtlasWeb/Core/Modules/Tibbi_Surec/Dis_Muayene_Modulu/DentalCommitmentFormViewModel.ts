//$62346ED4
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DentalCommitment } from "NebulaClient/Model/AtlasClientModel";
import { DentalCommitmentProsthesis } from "NebulaClient/Model/AtlasClientModel";
import { DentalProsthesisDefinition } from "NebulaClient/Model/AtlasClientModel";
import { TownDefinitions } from "NebulaClient/Model/AtlasClientModel";
import { City } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "NebulaClient/ClassTransformer";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";

export class DentalCommitmentFormViewModel extends BaseViewModel {
    @Type(() => DentalCommitment)
    public _DentalCommitment: DentalCommitment = new DentalCommitment();
    @Type(() => DentalCommitmentProsthesis)
    public DentalCommitmentProstethisesGridList: Array<DentalCommitmentProsthesis> = new Array<DentalCommitmentProsthesis>();
    @Type(() => DentalProsthesisDefinition)
    public DentalProsthesisDefinitions: Array<DentalProsthesisDefinition> = new Array<DentalProsthesisDefinition>();
    @Type(() => TownDefinitions)
    public TownDefinitionss: Array<TownDefinitions> = new Array<TownDefinitions>();
    @Type(() => DentalProsthesisDefinition)
    public dentalProcedures: Array<DentalProsthesisDefinition> = new Array<DentalProsthesisDefinition>();
    @Type(() => City)
    public Citys: Array<City> = new Array<City>();
    public provisionNo: string;
    public patientName: string;
    public patientSurname: string;
    public patientUniqueRefNo: string;
    public patientSex: string;
    @Type(() => Date)
    public patientBirthDate: Date;
    @Type(() => Guid)
    public DentalExaminationID: Guid;
    @Type(() => OldDentalCommitment)
    public oldDentalCommitments: Array<OldDentalCommitment> = new Array<OldDentalCommitment>();
}

export class OldDentalCommitment{
    @Type(() => Guid)
    public ObjectId: Guid;
    public commitmentNo: string;
    @Type(() => DentalCommitmentProsthesis)
    public dentalCommitmentProstheses: Array<DentalCommitmentProsthesis> = new Array<DentalCommitmentProsthesis>();
    public oldCommitments: string;
    @Type(() => Date)
    public commitmentDate: Date;
}



export class AddSut {
    public sutKodu: string;
    public disNo: string;
    public sutDef: DentalProsthesisDefinition;
}

export class ActiveMedulaProvision {
    public TakipNo: string;
    public Brans: string;
    @Type(() => Date)
    public ProvisionDate: Date;
    public BarsvuruNo: string;
    public ProtocolNo: string;
    @Type(() => Date)
    public OpenDate: Date;
    public BransKodu: string;
}

export class SaveTaahhutInputDVO {
    public adressIlPlaka: number;
    public adressIlce: string;
    public adressPostaKodu: string;
    public adressCaddeSokak: string;
    public adressDisKapiNo: string;
    public adressIcKapiNo: string;
    public adressTelefon: string;
    public adressEposta: string;
    public taahhutAlanAd: string;
    public taahhutAlanSoyad: string;
    public hastaTCKimlikNo: string;
    public suts: Array<AddSut>;
    public activeMedulaProvision: string;
}

export class SaveTaahhutOutputDVO {
    public işlemSonuc: boolean;
    public işlemSonucMesajı: string;
    public txtSonucKoduTaahhutKaydet: string;
    public txtSonucMesajiTaahhutKaydet: string;
    public txtAlınanTaahhutNo: string;
    @Type(() => Date)
    public taahhutGonderimTarihi: Date;
}

export class ReadTaahhutTCOutputDVO {
    public işlemSonuc: boolean;
    public işlemSonucMesajı: string;
    public txtSonucKoduTCKimlikNoileSorgula: string;
    public txtSonucMesajTCKimlikNoileSorgula: string;
    public taahhutler: Array<Taahhut>;
}

export class Taahhut {
    public taahhutNo: string;
}

export class DeleteTaahhutOutputDVO {
    public işlemSonuc: boolean;
    public işlemSonucMesajı: string;
    public txtSonucKoduTaahhutSil: string;
    public txtSonucMesajiTaahhutSil: string;
}

export class ReadTaahhutOutputDVO {
    public işlemSonuc: boolean;
    public işlemSonucMesajı: string;
    public txtSonucKoduTaahhutNoileSorgula: string;
    public txtSonucMesajiTaahhutNoileSorgula: string;
}


 export class AdressInfo{
     public adressIl: City;
     public adressIlce: TownDefinitions;
     public adressPostaKodu: string;
     public adressCaddeSokak: string;
     public adressDisKapiNo: string;
     public adressIcKapiNo: string;
     public adressTelefon: string;
     public adressEposta: string;
}