//$410AE97B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { SkinPrickTestResult } from "NebulaClient/Model/AtlasClientModel";
import { SkinPrickTestDetail } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class SkinPrickTestResultFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.SkinPrickTestResultFormViewModel, Core';
    @Type(() => SkinPrickTestResult)
    public _SkinPrickTestResult: SkinPrickTestResult = new SkinPrickTestResult();
    @Type(() => SkinPrickTestDetail)
    public SkinPrickTestDetailGridList: Array<SkinPrickTestDetail> = new Array<SkinPrickTestDetail>();
    @Type(() => SkinPrickTest)
    public _SkinPrickList: Array<SkinPrickTest> = new Array<SkinPrickTest>();
}

export class SkinPrickTest {
    @Type(() => Guid)
    public ObjectID: Guid;
    public ProcedureCode: string;
    public ProcedureName: string;
    @Type(() => Boolean)
    public Negative: boolean;
    @Type(() => Boolean)
    public Positive: boolean;
    public Description: string;

}