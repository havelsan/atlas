import { BaseModel } from 'Fw/Models/BaseModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { City } from 'NebulaClient/Model/AtlasClientModel';
import { TownDefinitions } from 'NebulaClient/Model/AtlasClientModel';
import { DentalProsthesisDefinition } from 'NebulaClient/Model/AtlasClientModel';

export class DisTaahhutFormViewModel extends BaseModel {

}
export class OnInitOutputDVO {
    public procedures: Array<DentalProsthesisDefinition>;
    public provisions: Array<ActiveMedulaProvision>;
    public txtTCKNo: string;
    public txtBirthDate: string;
    public txtSex: string;
    public cities: Array<City>;
    public addressInfo: AdressInfo;
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

export class AddSut {
    public sutKodu: string;
    public disNo: string;
    public sutDef: DentalProsthesisDefinition;
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