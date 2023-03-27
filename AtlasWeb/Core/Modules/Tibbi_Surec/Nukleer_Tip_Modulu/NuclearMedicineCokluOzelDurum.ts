//$BCBE7CBF
import { Component, OnInit, NgZone } from '@angular/core';
import { NuclearMedicineCokluOzelDurumViewModel } from './NuclearMedicineCokluOzelDurumViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { NuclearMedicine } from 'NebulaClient/Model/AtlasClientModel';
import { CokluOzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';


@Component({
    selector: 'NuclearMedicineCokluOzelDurum',
    templateUrl: './NuclearMedicineCokluOzelDurum.html',
    providers: [MessageService]
})
export class NuclearMedicineCokluOzelDurum extends TTVisual.TTForm implements OnInit {
    cokluOzelDurum: TTVisual.ITTListBoxColumn;
    ttgridCokluOzelDurum: TTVisual.ITTGrid;
    public ttgridCokluOzelDurumColumns = [];
    public nuclearMedicineCokluOzelDurumViewModel: NuclearMedicineCokluOzelDurumViewModel = new NuclearMedicineCokluOzelDurumViewModel();
    public get _NuclearMedicine(): NuclearMedicine {
        return this._TTObject as NuclearMedicine;
    }
    private NuclearMedicineCokluOzelDurum_DocumentUrl: string = '/api/NuclearMedicineService/NuclearMedicineCokluOzelDurum';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super('NUCLEARMEDICINE', 'NuclearMedicineCokluOzelDurum');
        this._DocumentServiceUrl = this.NuclearMedicineCokluOzelDurum_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef !== null) {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("NUCLEARMEDICINE", this.nuclearMedicineCokluOzelDurumViewModel._NuclearMedicine.ObjectID, null);

        }
        super.AfterContextSavedScript(transDef);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NuclearMedicine();
        this.nuclearMedicineCokluOzelDurumViewModel = new NuclearMedicineCokluOzelDurumViewModel();
        this._ViewModel = this.nuclearMedicineCokluOzelDurumViewModel;
        this.nuclearMedicineCokluOzelDurumViewModel._NuclearMedicine = this._TTObject as NuclearMedicine;
        this.nuclearMedicineCokluOzelDurumViewModel._NuclearMedicine.CokluOzelDurum = new Array<CokluOzelDurum>();
    }

    protected loadViewModel() {
        let that = this;
        that.nuclearMedicineCokluOzelDurumViewModel = this._ViewModel as NuclearMedicineCokluOzelDurumViewModel;
        that._TTObject = this.nuclearMedicineCokluOzelDurumViewModel._NuclearMedicine;
        if (this.nuclearMedicineCokluOzelDurumViewModel == null)
            this.nuclearMedicineCokluOzelDurumViewModel = new NuclearMedicineCokluOzelDurumViewModel();
        if (this.nuclearMedicineCokluOzelDurumViewModel._NuclearMedicine == null)
            this.nuclearMedicineCokluOzelDurumViewModel._NuclearMedicine = new NuclearMedicine();
        that.nuclearMedicineCokluOzelDurumViewModel._NuclearMedicine.CokluOzelDurum = that.nuclearMedicineCokluOzelDurumViewModel.ttgridCokluOzelDurumGridList;
        for (let detailItem of that.nuclearMedicineCokluOzelDurumViewModel.ttgridCokluOzelDurumGridList) {
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === "string")) {
                let ozelDurum = that.nuclearMedicineCokluOzelDurumViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }

    }

    //async ngOnInit() {
    //    await this.load();
    //}

    async ngOnInit() {
        let that = this;
        await this.load(NuclearMedicineCokluOzelDurumViewModel);
  
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.ttgridCokluOzelDurum = new TTVisual.TTGrid();
        this.ttgridCokluOzelDurum.Name = "ttgridCokluOzelDurum";
        this.ttgridCokluOzelDurum.TabIndex = 0;

        this.cokluOzelDurum = new TTVisual.TTListBoxColumn();
        this.cokluOzelDurum.ListDefName = "OzelDurumListDefinition";
        this.cokluOzelDurum.DataMember = "OzelDurum";
        this.cokluOzelDurum.DisplayIndex = 0;
        this.cokluOzelDurum.HeaderText = "Çoklu Özel Durum";
        this.cokluOzelDurum.Name = "cokluOzelDurum";
        this.cokluOzelDurum.Width = 400;

        this.ttgridCokluOzelDurumColumns = [this.cokluOzelDurum];
        this.Controls = [this.ttgridCokluOzelDurum, this.cokluOzelDurum];

    }


}
