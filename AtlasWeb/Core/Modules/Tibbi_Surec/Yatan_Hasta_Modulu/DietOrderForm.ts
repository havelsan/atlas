//$33D8C5FC
import { Component, OnInit, NgZone } from '@angular/core';
import { DietOrderFormViewModel } from './DietOrderFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DietOrder } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'DietOrderForm',
    templateUrl: './DietOrderForm.html',
    providers: [MessageService]
})
export class DietOrderForm extends TTVisual.TTForm implements OnInit {
    labelWorkListDate: TTVisual.ITTLabel;
    WorkListDate: TTVisual.ITTDateTimePicker;
    public dietOrderFormViewModel: DietOrderFormViewModel = new DietOrderFormViewModel();
    public get _DietOrder(): DietOrder {
        return this._TTObject as DietOrder;
    }
    private DietOrderForm_DocumentUrl: string = '/api/DietOrderService/DietOrderForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('DIETORDER', 'DietOrderForm');
        this._DocumentServiceUrl = this.DietOrderForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DietOrder();
        this.dietOrderFormViewModel = new DietOrderFormViewModel();
        this._ViewModel = this.dietOrderFormViewModel;
        this.dietOrderFormViewModel._DietOrder = this._TTObject as DietOrder;
    }

    protected loadViewModel() {
        let that = this;

        that.dietOrderFormViewModel = this._ViewModel as DietOrderFormViewModel;
        that._TTObject = this.dietOrderFormViewModel._DietOrder;
        if (this.dietOrderFormViewModel == null)
            this.dietOrderFormViewModel = new DietOrderFormViewModel();
        if (this.dietOrderFormViewModel._DietOrder == null)
            this.dietOrderFormViewModel._DietOrder = new DietOrder();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(DietOrderFormViewModel);
  
    }


    public onWorkListDateChanged(event): void {
        if (event != null) {
            if (this._DietOrder != null && this._DietOrder.WorkListDate != event) {
                this._DietOrder.WorkListDate = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.WorkListDate, "Value", this.__ttObject, "WorkListDate");
    }

    public initFormControls(): void {
        this.labelWorkListDate = new TTVisual.TTLabel();
        this.labelWorkListDate.Text = i18n("M16771", "İş Listesi Tarihi");
        this.labelWorkListDate.Name = "labelWorkListDate";
        this.labelWorkListDate.TabIndex = 1;

        this.WorkListDate = new TTVisual.TTDateTimePicker();
        this.WorkListDate.Format = DateTimePickerFormat.Long;
        this.WorkListDate.Name = "WorkListDate";
        this.WorkListDate.TabIndex = 0;

        this.Controls = [this.labelWorkListDate, this.WorkListDate];

    }


}
