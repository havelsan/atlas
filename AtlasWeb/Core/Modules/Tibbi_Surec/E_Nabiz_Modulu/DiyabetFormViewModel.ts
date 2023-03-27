//$2D405E0B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DiyabetVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { DiyabetKompBilgisi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDiyabetEgitimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDiyabetKomplikasyonlari } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class DiyabetFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.DiyabetFormViewModel, Core';
    @Type(() => DiyabetVeriSeti)
    public _DiyabetVeriSeti: DiyabetVeriSeti = new DiyabetVeriSeti();
    @Type(() => DiyabetKompBilgisi)
    public DiyabetKompBilgisiGridList: Array<DiyabetKompBilgisi> = new Array<DiyabetKompBilgisi>();
    @Type(() => SKRSDiyabetEgitimi)
    public SKRSDiyabetEgitimis: Array<SKRSDiyabetEgitimi> = new Array<SKRSDiyabetEgitimi>();
    @Type(() => SKRSDiyabetKomplikasyonlari)
    public SKRSDiyabetKomplikasyonlaris: Array<SKRSDiyabetKomplikasyonlari> = new Array<SKRSDiyabetKomplikasyonlari>();
}
