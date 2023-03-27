//$A0DD7030
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BabyObstetricInformation } from "NebulaClient/Model/AtlasClientModel";
import { Apgar } from "NebulaClient/Model/AtlasClientModel";
import { SKRSCinsiyet } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDogumYontemi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDogumSirasi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDogumunGerceklestigiYer } from "NebulaClient/Model/AtlasClientModel";
import { SKRSBebekOlumNedenleri } from "NebulaClient/Model/AtlasClientModel";
import { RegularObstetric } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class BabyInformationFormViewModel extends BaseViewModel {
    @Type(() => BabyObstetricInformation)
    public _BabyObstetricInformation: BabyObstetricInformation = new BabyObstetricInformation();

    @Type(() => Apgar)
    public Apgars: Array<Apgar> = new Array<Apgar>();

    @Type(() => SKRSCinsiyet)
    public SKRSCinsiyets: Array<SKRSCinsiyet> = new Array<SKRSCinsiyet>();

    @Type(() => SKRSDogumYontemi)
    public SKRSDogumYontemis: Array<SKRSDogumYontemi> = new Array<SKRSDogumYontemi>();

    @Type(() => SKRSDogumSirasi)
    public SKRSDogumSirasis: Array<SKRSDogumSirasi> = new Array<SKRSDogumSirasi>();

    @Type(() => SKRSDogumunGerceklestigiYer)
    public SKRSDogumunGerceklestigiYers: Array<SKRSDogumunGerceklestigiYer> = new Array<SKRSDogumunGerceklestigiYer>();

    @Type(() => SKRSBebekOlumNedenleri)
    public SKRSBebekOlumNedenleris: Array<SKRSBebekOlumNedenleri> = new Array<SKRSBebekOlumNedenleri>();

    @Type(() => RegularObstetric)
    public _RegularObstetric: RegularObstetric ;
    
    public PhotoString: string;
}
