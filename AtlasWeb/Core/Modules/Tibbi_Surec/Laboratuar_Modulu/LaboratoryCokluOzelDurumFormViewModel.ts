//$393F6E6B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { CokluOzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';

export class LaboratoryCokluOzelDurumFormViewModel extends BaseViewModel {
    public _LaboratoryProcedure: LaboratoryProcedure = new LaboratoryProcedure();
    public ttgridOzelDurumGridList: Array<CokluOzelDurum> = new Array<CokluOzelDurum>();
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
}
