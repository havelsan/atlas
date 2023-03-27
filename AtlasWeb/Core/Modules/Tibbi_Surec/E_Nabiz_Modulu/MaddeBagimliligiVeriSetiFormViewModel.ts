//$78E5FD61
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { MaddeBagimliligiVeriSeti } from "NebulaClient/Model/AtlasClientModel";
import { MaddeBagimliligiKulMadde } from "NebulaClient/Model/AtlasClientModel";
import { MaddeBagimBulasiciHastalik } from "NebulaClient/Model/AtlasClientModel";
import { SKRSYasamBicimi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSYasadigiBolge } from "NebulaClient/Model/AtlasClientModel";
import { SKRSUygulananTedaviTuruMaddeBagimliligi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSTedaviSonucuMaddeBagimliligi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSTedaviMerkeziTipi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSSigaraKullanimi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSOgrenimDurumu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKullanilanMadde } from "NebulaClient/Model/AtlasClientModel";
import { SKRSIsDurumu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSGonderenBirim } from "NebulaClient/Model/AtlasClientModel";
import { SKRSEnjektorPaylasimDurumu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSAlkolKullanimi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSMaddeKullanimSikligi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSMaddeKullanimYolu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSBulasiciHastalikDurumu } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class MaddeBagimliligiVeriSetiFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.MaddeBagimliligiVeriSetiFormViewModel, Core';
    @Type(() => MaddeBagimliligiVeriSeti)
    public _MaddeBagimliligiVeriSeti: MaddeBagimliligiVeriSeti = new MaddeBagimliligiVeriSeti();
    @Type(() => MaddeBagimliligiKulMadde)
    public MaddeBagimliligiKulMaddeGridList: Array<MaddeBagimliligiKulMadde> = new Array<MaddeBagimliligiKulMadde>();
    @Type(() => MaddeBagimBulasiciHastalik)
    public MaddeBagimBulasiciHastalikGridList: Array<MaddeBagimBulasiciHastalik> = new Array<MaddeBagimBulasiciHastalik>();
    @Type(() => SKRSYasamBicimi)
    public SKRSYasamBicimis: Array<SKRSYasamBicimi> = new Array<SKRSYasamBicimi>();
    @Type(() => SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumu)
    public SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumus: Array<SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumu> = new Array<SKRSYasamindaEnjeksiyonYoluileMaddeKullanimDurumu>();
    @Type(() => SKRSYasadigiBolge)
    public SKRSYasadigiBolges: Array<SKRSYasadigiBolge> = new Array<SKRSYasadigiBolge>();
    @Type(() => SKRSUygulananTedaviTuruMaddeBagimliligi)
    public SKRSUygulananTedaviTuruMaddeBagimliligis: Array<SKRSUygulananTedaviTuruMaddeBagimliligi> = new Array<SKRSUygulananTedaviTuruMaddeBagimliligi>();
    @Type(() => SKRSTedaviSonucuMaddeBagimliligi)
    public SKRSTedaviSonucuMaddeBagimliligis: Array<SKRSTedaviSonucuMaddeBagimliligi> = new Array<SKRSTedaviSonucuMaddeBagimliligi>();
    @Type(() => SKRSTedaviMerkeziTipi)
    public SKRSTedaviMerkeziTipis: Array<SKRSTedaviMerkeziTipi> = new Array<SKRSTedaviMerkeziTipi>();
    @Type(() => SKRSSigaraKullanimi)
    public SKRSSigaraKullanimis: Array<SKRSSigaraKullanimi> = new Array<SKRSSigaraKullanimi>();
    @Type(() => SKRSOgrenimDurumu)
    public SKRSOgrenimDurumus: Array<SKRSOgrenimDurumu> = new Array<SKRSOgrenimDurumu>();
    @Type(() => SKRSKullanilanMadde)
    public SKRSKullanilanMaddes: Array<SKRSKullanilanMadde> = new Array<SKRSKullanilanMadde>();
    @Type(() => SKRSIsDurumu)
    public SKRSIsDurumus: Array<SKRSIsDurumu> = new Array<SKRSIsDurumu>();
    @Type(() => SKRSGonderenBirim)
    public SKRSGonderenBirims: Array<SKRSGonderenBirim> = new Array<SKRSGonderenBirim>();
    @Type(() => SKRSEnjektorPaylasimDurumu)
    public SKRSEnjektorPaylasimDurumus: Array<SKRSEnjektorPaylasimDurumu> = new Array<SKRSEnjektorPaylasimDurumu>();
    @Type(() => SKRSAlkolKullanimi)
    public SKRSAlkolKullanimis: Array<SKRSAlkolKullanimi> = new Array<SKRSAlkolKullanimi>();
    @Type(() => SKRSMaddeKullanimSikligi)
    public SKRSMaddeKullanimSikligis: Array<SKRSMaddeKullanimSikligi> = new Array<SKRSMaddeKullanimSikligi>();
    @Type(() => SKRSMaddeKullanimYolu)
    public SKRSMaddeKullanimYolus: Array<SKRSMaddeKullanimYolu> = new Array<SKRSMaddeKullanimYolu>();
    @Type(() => SKRSBulasiciHastalikDurumu)
    public SKRSBulasiciHastalikDurumus: Array<SKRSBulasiciHastalikDurumu> = new Array<SKRSBulasiciHastalikDurumu>();
}
