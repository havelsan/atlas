//$AE2FB9C5
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { HCExaminationComponent, CozgerSpecReqArea, CozgerSpecReqLevel, HCExaminationDisabledRatio } from 'NebulaClient/Model/AtlasClientModel';
import { ReasonForExaminationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class HCExaminationComponentFormViewModel extends BaseViewModel {
    @Type(() => HCExaminationComponent)
    public _HCExaminationComponent: HCExaminationComponent = new HCExaminationComponent();
    @Type(() => ReasonForExaminationDefinition)
    public ReasonForExaminationDefinitions: Array<ReasonForExaminationDefinition> = new Array<ReasonForExaminationDefinition>();
    @Type(() => CozgerSpecReqArea)
    public CozgerSpecReqAreas: Array<CozgerSpecReqArea> = new Array<CozgerSpecReqArea>();
    @Type(() => CozgerSpecReqLevel)
    public CozgerSpecReqLevels: Array<CozgerSpecReqLevel> = new Array<CozgerSpecReqLevel>();
    @Type(() => HCExaminationDisabledRatio)
    public HCExaminationDisabledRatios: Array<HCExaminationDisabledRatio> = new Array<HCExaminationDisabledRatio>();
    @Type(() => Boolean)
    public IsDisabled: Boolean;
    @Type(() => Boolean)
    public IsCozger: Boolean = false;
    @Type(() => Number)
    public Height: number;
    @Type(() => Number)
    public Weight: number;
    public CozgerListFilterExpression: string;
}
