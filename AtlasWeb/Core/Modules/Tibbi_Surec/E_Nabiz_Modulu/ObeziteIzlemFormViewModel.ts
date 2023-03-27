//$6C1D9370
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ObeziteIzlemVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { ObeziteEkHastalik } from 'NebulaClient/Model/AtlasClientModel';
import { ObeziteEgzersiz } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSPsikolojikTedavi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSObeziteIlacTedavisi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMorbidObezHastaLenfatikOdemVarligi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDiyetTedavisiTibbiBeslenmeTedavisi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSICD } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSEgzersiz } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class ObeziteIzlemFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.ObeziteIzlemFormViewModel, Core';
     @Type(() => ObeziteIzlemVeriSeti)
    public _ObeziteIzlemVeriSeti: ObeziteIzlemVeriSeti = new ObeziteIzlemVeriSeti();
     @Type(() => ObeziteEkHastalik)
    public ObeziteEkHastalikGridList: Array<ObeziteEkHastalik> = new Array<ObeziteEkHastalik>();
     @Type(() => ObeziteEgzersiz)
    public ObeziteEgzersizGridList: Array<ObeziteEgzersiz> = new Array<ObeziteEgzersiz>();
     @Type(() => SKRSPsikolojikTedavi)
    public SKRSPsikolojikTedavis: Array<SKRSPsikolojikTedavi> = new Array<SKRSPsikolojikTedavi>();
     @Type(() => SKRSObeziteIlacTedavisi)
     public SKRSObeziteIlacTedavisis: Array<SKRSObeziteIlacTedavisi> = new Array<SKRSObeziteIlacTedavisi>();
     @Type(() => SKRSMorbidObezHastaLenfatikOdemVarligi)
     public SKRSMorbidObezHastaLenfatikOdemVarligis: Array<SKRSMorbidObezHastaLenfatikOdemVarligi> = new Array<SKRSMorbidObezHastaLenfatikOdemVarligi>();
     @Type(() => SKRSDiyetTedavisiTibbiBeslenmeTedavisi)
     public SKRSDiyetTedavisiTibbiBeslenmeTedavisis: Array<SKRSDiyetTedavisiTibbiBeslenmeTedavisi> = new Array<SKRSDiyetTedavisiTibbiBeslenmeTedavisi>();
     @Type(() => SKRSICD)
     public SKRSICDs: Array<SKRSICD> = new Array<SKRSICD>();
     @Type(() => SKRSEgzersiz)
    public SKRSEgzersizs: Array<SKRSEgzersiz> = new Array<SKRSEgzersiz>();
}
