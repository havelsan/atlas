//$1BF0ABF8
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { CokluOzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";

export class RadiologyTestCokluOzelDurumViewModel extends BaseViewModel {
    @Type(() => RadiologyTest)
    public _RadiologyTest: RadiologyTest = new RadiologyTest();
    @Type(() => CokluOzelDurum)
    public ttgridCokluOzelDurumGridList: Array<CokluOzelDurum> = new Array<CokluOzelDurum>();
    @Type(() => OzelDurum)
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
}
