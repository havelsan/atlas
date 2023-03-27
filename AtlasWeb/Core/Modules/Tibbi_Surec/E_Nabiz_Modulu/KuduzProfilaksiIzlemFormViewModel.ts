//$9504D910
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { KuduzProfilaksiVeriSeti } from "NebulaClient/Model/AtlasClientModel";
import { KuduzProfilaksiUygProfilak } from "NebulaClient/Model/AtlasClientModel";
import { SKRSImmunglobulinTuru } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKuduzProfilaksisiTamamlanmaDurumu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSUygulananKuduzProfilaksisi } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class KuduzProfilaksiIzlemFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.KuduzProfilaksiIzlemFormViewModel, Core';

    @Type(() => KuduzProfilaksiVeriSeti)
    public _KuduzProfilaksiVeriSeti: KuduzProfilaksiVeriSeti = new KuduzProfilaksiVeriSeti();
    @Type(() => KuduzProfilaksiUygProfilak)
    public KuduzProfilaksiUygProfilakGridList: Array<KuduzProfilaksiUygProfilak> = new Array<KuduzProfilaksiUygProfilak>();
    @Type(() => SKRSImmunglobulinTuru)
    public SKRSImmunglobulinTurus: Array<SKRSImmunglobulinTuru> = new Array<SKRSImmunglobulinTuru>();
    @Type(() => SKRSKuduzProfilaksisiTamamlanmaDurumu)
    public SKRSKuduzProfilaksisiTamamlanmaDurumus: Array<SKRSKuduzProfilaksisiTamamlanmaDurumu> = new Array<SKRSKuduzProfilaksisiTamamlanmaDurumu>();
    @Type(() => SKRSUygulananKuduzProfilaksisi)
    public SKRSUygulananKuduzProfilaksisis: Array<SKRSUygulananKuduzProfilaksisi> = new Array<SKRSUygulananKuduzProfilaksisi>();

   
}
