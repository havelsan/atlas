//$BBE92CE2
import { Component, OnInit, NgZone } from '@angular/core';
import { LaboratoryCokluOzelDurumFormViewModel } from './LaboratoryCokluOzelDurumFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { CokluOzelDurum } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'LaboratoryCokluOzelDurumForm',
    templateUrl: './LaboratoryCokluOzelDurumForm.html',
    providers: [MessageService]
})
export class LaboratoryCokluOzelDurumForm extends TTVisual.TTForm implements OnInit {
    cokluOzelDurum: TTVisual.ITTListDefComboBoxColumn;
    ttgridOzelDurum: TTVisual.ITTGrid;
    public ttgridOzelDurumColumns = [];
    public laboratoryCokluOzelDurumFormViewModel: LaboratoryCokluOzelDurumFormViewModel = new LaboratoryCokluOzelDurumFormViewModel();
    public get _LaboratoryProcedure(): LaboratoryProcedure {
        return this._TTObject as LaboratoryProcedure;
    }
    private LaboratoryCokluOzelDurumForm_DocumentUrl: string = '/api/LaboratoryProcedureService/LaboratoryCokluOzelDurumForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('LABORATORYPROCEDURE', 'LaboratoryCokluOzelDurumForm');
        this._DocumentServiceUrl = this.LaboratoryCokluOzelDurumForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new LaboratoryProcedure();
        this.laboratoryCokluOzelDurumFormViewModel = new LaboratoryCokluOzelDurumFormViewModel();
        this._ViewModel = this.laboratoryCokluOzelDurumFormViewModel;
        this.laboratoryCokluOzelDurumFormViewModel._LaboratoryProcedure = this._TTObject as LaboratoryProcedure;
        this.laboratoryCokluOzelDurumFormViewModel._LaboratoryProcedure.CokluOzelDurum = new Array<CokluOzelDurum>();
    }

    protected loadViewModel() {
        let that = this;

        that.laboratoryCokluOzelDurumFormViewModel = this._ViewModel as LaboratoryCokluOzelDurumFormViewModel;
        that._TTObject = this.laboratoryCokluOzelDurumFormViewModel._LaboratoryProcedure;
        if (this.laboratoryCokluOzelDurumFormViewModel == null)
            this.laboratoryCokluOzelDurumFormViewModel = new LaboratoryCokluOzelDurumFormViewModel();
        if (this.laboratoryCokluOzelDurumFormViewModel._LaboratoryProcedure == null)
            this.laboratoryCokluOzelDurumFormViewModel._LaboratoryProcedure = new LaboratoryProcedure();
        that.laboratoryCokluOzelDurumFormViewModel._LaboratoryProcedure.CokluOzelDurum = that.laboratoryCokluOzelDurumFormViewModel.ttgridOzelDurumGridList;
        for (let detailItem of that.laboratoryCokluOzelDurumFormViewModel.ttgridOzelDurumGridList) {
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                let ozelDurum = that.laboratoryCokluOzelDurumFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                 if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(LaboratoryCokluOzelDurumFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.ttgridOzelDurum = new TTVisual.TTGrid();
        this.ttgridOzelDurum.Name = "ttgridOzelDurum";
        this.ttgridOzelDurum.TabIndex = 0;

        this.cokluOzelDurum = new TTVisual.TTListDefComboBoxColumn();
        this.cokluOzelDurum.ListDefName = "OzelDurumListDefinition";
        this.cokluOzelDurum.DataMember = "OzelDurum";
        this.cokluOzelDurum.DisplayIndex = 0;
        this.cokluOzelDurum.HeaderText = i18n("M12418", "Çoklu Özel Durum");
        this.cokluOzelDurum.Name = "cokluOzelDurum";
        this.cokluOzelDurum.Width = 400;

        this.ttgridOzelDurumColumns = [this.cokluOzelDurum];
        this.Controls = [this.ttgridOzelDurum, this.cokluOzelDurum];

    }


}
