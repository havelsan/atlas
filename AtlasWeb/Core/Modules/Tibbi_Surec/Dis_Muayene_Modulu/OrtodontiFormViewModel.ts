import { BaseModel } from 'Fw/Models/BaseModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { TedaviRaporiIslemKodlari } from 'NebulaClient/Model/AtlasClientModel';

export class OrtodontiFormViewModel extends BaseModel {


}

export class OnInitOutputDVO {
    public suts: Array<TedaviRaporiIslemKodlari>;
    public provisions: Array<ActiveMedulaProvision>;
    public txtTCKNo: string;
    public txtBirthDate: string;
    public txtSex: string;
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
