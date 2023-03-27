//$96044500
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NuclearMedicine } from "NebulaClient/Model/AtlasClientModel";
import { CokluOzelDurum } from "NebulaClient/Model/AtlasClientModel";
import { OzelDurum } from "NebulaClient/Model/AtlasClientModel";

export class NuclearMedicineCokluOzelDurumViewModel extends BaseViewModel {
    public _NuclearMedicine: NuclearMedicine = new NuclearMedicine();
    public ttgridCokluOzelDurumGridList: Array<CokluOzelDurum> = new Array<CokluOzelDurum>();
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
}
