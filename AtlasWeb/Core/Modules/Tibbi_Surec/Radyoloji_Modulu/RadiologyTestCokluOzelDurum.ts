//$95CFE55F
import { Component, OnInit, NgZone } from '@angular/core';
import { RadiologyTestCokluOzelDurumViewModel } from "./RadiologyTestCokluOzelDurumViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';

import { CokluOzelDurum } from 'NebulaClient/Model/AtlasClientModel';



@Component({
    selector: 'RadiologyTestCokluOzelDurum',
    templateUrl: './RadiologyTestCokluOzelDurum.html',
    providers: [MessageService]
})
export class RadiologyTestCokluOzelDurum extends TTVisual.TTForm implements OnInit {
    cokluOzelDurum: TTVisual.ITTListDefComboBoxColumn;
    ttgridCokluOzelDurum: TTVisual.ITTGrid;
    public ttgridCokluOzelDurumColumns = [];
    public radiologyTestCokluOzelDurumViewModel: RadiologyTestCokluOzelDurumViewModel = new RadiologyTestCokluOzelDurumViewModel();
    public get _RadiologyTest(): RadiologyTest {
        return this._TTObject as RadiologyTest;
    }
    private RadiologyTestCokluOzelDurum_DocumentUrl: string = '/api/RadiologyTestService/RadiologyTestCokluOzelDurum';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super("RADIOLOGYTEST", "RadiologyTestCokluOzelDurum");
        this._DocumentServiceUrl = this.RadiologyTestCokluOzelDurum_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new RadiologyTest();
        this.radiologyTestCokluOzelDurumViewModel = new RadiologyTestCokluOzelDurumViewModel();
        this._ViewModel = this.radiologyTestCokluOzelDurumViewModel;
        this.radiologyTestCokluOzelDurumViewModel._RadiologyTest = this._TTObject as RadiologyTest;
        this.radiologyTestCokluOzelDurumViewModel._RadiologyTest.CokluOzelDurum = new Array<CokluOzelDurum>();
    }

    protected loadViewModel() {
        let that = this;
        that.radiologyTestCokluOzelDurumViewModel = this._ViewModel as RadiologyTestCokluOzelDurumViewModel;
        that._TTObject = this.radiologyTestCokluOzelDurumViewModel._RadiologyTest;
        if (this.radiologyTestCokluOzelDurumViewModel == null)
            this.radiologyTestCokluOzelDurumViewModel = new RadiologyTestCokluOzelDurumViewModel();
        if (this.radiologyTestCokluOzelDurumViewModel._RadiologyTest == null)
            this.radiologyTestCokluOzelDurumViewModel._RadiologyTest = new RadiologyTest();
        that.radiologyTestCokluOzelDurumViewModel._RadiologyTest.CokluOzelDurum = that.radiologyTestCokluOzelDurumViewModel.ttgridCokluOzelDurumGridList;
        for (let detailItem of that.radiologyTestCokluOzelDurumViewModel.ttgridCokluOzelDurumGridList) {
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                let ozelDurum = that.radiologyTestCokluOzelDurumViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                 if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(RadiologyTestCokluOzelDurumViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.ttgridCokluOzelDurum = new TTVisual.TTGrid();
        this.ttgridCokluOzelDurum.Name = "ttgridCokluOzelDurum";
        this.ttgridCokluOzelDurum.TabIndex = 0;

        this.cokluOzelDurum = new TTVisual.TTListDefComboBoxColumn();
        this.cokluOzelDurum.ListDefName = "OzelDurumListDefinition";
        this.cokluOzelDurum.DataMember = "OzelDurum";
        this.cokluOzelDurum.DisplayIndex = 0;
        this.cokluOzelDurum.HeaderText = i18n("M12418", "Çoklu Özel Durum");
        this.cokluOzelDurum.Name = "cokluOzelDurum";
        this.cokluOzelDurum.Width = 400;

        this.ttgridCokluOzelDurumColumns = [this.cokluOzelDurum];
        this.Controls = [this.ttgridCokluOzelDurum, this.cokluOzelDurum];

    }


}
