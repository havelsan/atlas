//$42D96741
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { EkokardiografiFormObject } from "NebulaClient/Model/AtlasClientModel";
import { EkokardiografiBulgu } from "NebulaClient/Model/AtlasClientModel";
import { PulmonerKapakBulgu } from "NebulaClient/Model/AtlasClientModel";
import { TrikuspitKapakBulgu } from "NebulaClient/Model/AtlasClientModel";
import { AortKapakBulgu } from "NebulaClient/Model/AtlasClientModel";
import { MitralKapakBulgu } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class EkokardiografiFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.EkokardiografiFormViewModel, Core';
    @Type(() => EkokardiografiFormObject)
    public _EkokardiografiFormObject: EkokardiografiFormObject = new EkokardiografiFormObject();
    @Type(() => EkokardiografiBulgu)
    public EkokardiografiBulgularGridList: Array<EkokardiografiBulgu> = new Array<EkokardiografiBulgu>();
    @Type(() => PulmonerKapakBulgu)
    public PulmonerKapakBulgularGridList: Array<PulmonerKapakBulgu> = new Array<PulmonerKapakBulgu>();
    @Type(() => TrikuspitKapakBulgu)
    public TrikuspitKapakBulgularGridList: Array<TrikuspitKapakBulgu> = new Array<TrikuspitKapakBulgu>();
    @Type(() => AortKapakBulgu)
    public AortKapakBulgularGridList: Array<AortKapakBulgu> = new Array<AortKapakBulgu>();
    @Type(() => MitralKapakBulgu)
    public MitralKapakBulgularGridList: Array<MitralKapakBulgu> = new Array<MitralKapakBulgu>();
}
