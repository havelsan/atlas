//$DA9FF108
import { Component, ViewChild, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ManagerPrescriptionCountFormViewModel } from './ManagerPrescriptionCountFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ManagerPrescriptionCounts } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { DxDataGridComponent } from 'devextreme-angular';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';

@Component({
    selector: 'ManagerPrescriptionCountForm',
    templateUrl: './ManagerPrescriptionCountForm.html',
    providers: [MessageService]
})
export class ManagerPrescriptionCountForm extends TTVisual.TTForm implements OnInit {
    EndDate: TTVisual.ITTDateTimePicker;
    ePrescriptionCount: TTVisual.ITTTextBox;
    labelEndDate: TTVisual.ITTLabel;
    labelePrescriptionCount: TTVisual.ITTLabel;
    labelEmergencyPrescriptionCount: TTVisual.ITTLabel;
    labelPoliclinicPrescriptionCount: TTVisual.ITTLabel;
    labelPrescriptionCountRate: TTVisual.ITTLabel;
    labelStartDate: TTVisual.ITTLabel;
    labelTotalPrescriptionCounts: TTVisual.ITTLabel;
    EmergencyPrescriptionCount: TTVisual.ITTTextBox;
    PoliclinicPrescriptionCount: TTVisual.ITTTextBox;
    PrescriptionCountRate: TTVisual.ITTTextBox;
    StartDate: TTVisual.ITTDateTimePicker;
    TotalPrescriptionCounts: TTVisual.ITTTextBox;
    ResUser: TTVisual.ITTObjectListBox;

    @ViewChild('dataGrid') oldCountGrid: DxDataGridComponent;
    public gridHeight = "650px";
    public oldPrescriptionsGridColumns = [];
    public managerPrescriptionCountFormViewModel: ManagerPrescriptionCountFormViewModel = new ManagerPrescriptionCountFormViewModel();
    public get _ManagerPrescriptionCounts(): ManagerPrescriptionCounts {
        return this._TTObject as ManagerPrescriptionCounts;
    }
    private ManagerPrescriptionCountForm_DocumentUrl: string = '/api/ManagerPrescriptionCountsService/ManagerPrescriptionCountForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('MANAGERPRESCRIPTIONCOUNTS', 'ManagerPrescriptionCountForm');
        this._DocumentServiceUrl = this.ManagerPrescriptionCountForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
        this.oldPrescriptionsGridColumns = [
            {
                caption: 'Başlangıç Tarihi',
                dataField: 'StartDate',
                dataType: 'date',
                format: 'dd/MM/yyyy',
                allowEditing: false,
                width: 130
            },
            {
                caption: 'Bitiş Tarihi',
                dataField: 'EndDate',
                dataType: 'date',
                format: 'dd/MM/yyyy',
                allowEditing: false,
                width: 100
            },
            {
                caption: 'e-Reçete Sayısı',
                dataField: 'ePrescriptionCount',
                allowEditing: false,
                width: 120
            },
            {
                caption: 'Kağıt Reçete Sayısı (Acil) ',
                dataField: 'EmergencyPrescriptionCount',
                allowEditing: false,
                width: 150
            },
            {
                caption: 'Kağıt Reçete Sayısı (Poliklinik)',
                dataField: 'PoliclinicPrescriptionCount',
                allowEditing: false,
                width: 150
            },
            {
                caption: 'Toplam Reçete Sayısı',
                dataField: 'TotalPrescriptionCounts',
                allowEditing: false,
                width: 150
            },
            {
                caption: 'Reçete Oranı',
                dataField: 'PrescriptionCountRate',
                allowEditing: false,
                width: 100
            },
            {
                caption: 'Doktor',
                dataField: 'doctorName',
                allowEditing: false,
                width: 200
            },
            {
                caption: 'Ekleyen Kullanıcı',
                dataField: 'AddedUser',
                allowEditing: false,
                width: 200
            },
            {
                caption: 'Kaydın Son Güncellenme Tarihi',
                dataField: 'LastUpdate',
                dataType: 'date',
                format: 'dd/MM/yyyy HH:mm:ss',
                allowEditing: false,
                width: 130
            },

        ];
    }

    public async save() {
        if (this.managerPrescriptionCountFormViewModel._ManagerPrescriptionCounts.StartDate == null) {
            ServiceLocator.MessageService.showError("Başlangıç Tarihi Boş Olamaz!");
            return;
        }
        if (this.managerPrescriptionCountFormViewModel._ManagerPrescriptionCounts.EndDate == null) {
            ServiceLocator.MessageService.showError("Bitiş Tarihi Boş Olamaz!");
            return;
        }
        if (this.managerPrescriptionCountFormViewModel._ManagerPrescriptionCounts.ePrescriptionCount == null) {
            ServiceLocator.MessageService.showError("e-Reçete Sayısı Boş Olamaz!");
            return;
        }
        if (this.managerPrescriptionCountFormViewModel._ManagerPrescriptionCounts.EmergencyPrescriptionCount == null) {
            ServiceLocator.MessageService.showError("Kağıt Reçete Sayısı (Acil) Boş Olamaz!");
            return;
        }
        if (this.managerPrescriptionCountFormViewModel._ManagerPrescriptionCounts.PoliclinicPrescriptionCount == null) {
            ServiceLocator.MessageService.showError("Kağıt Reçete Sayısı(Poliklinik) Boş Olamaz!");
            return;
        }
        if (this.managerPrescriptionCountFormViewModel._ManagerPrescriptionCounts.TotalPrescriptionCounts == null) {
            ServiceLocator.MessageService.showError("Toplam Reçete Sayısı Boş Olamaz!");
            return;
        }
        if (this.managerPrescriptionCountFormViewModel._ManagerPrescriptionCounts.ResUser == null) {
            ServiceLocator.MessageService.showError("Doktor Boş Olamaz!");
            return;
        }
        await super.save();

        await this.load();
        await this.PreScript();
    }

    public async cancelForm() {
        this.ActiveIDsModel = null;
        this.ObjectID = null;
        await this.load();
    }
    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ManagerPrescriptionCounts();
        this.managerPrescriptionCountFormViewModel = new ManagerPrescriptionCountFormViewModel();
        this._ViewModel = this.managerPrescriptionCountFormViewModel;
        this.managerPrescriptionCountFormViewModel._ManagerPrescriptionCounts = this._TTObject as ManagerPrescriptionCounts;
    }

    protected loadViewModel() {
        let that = this;
        that.managerPrescriptionCountFormViewModel = this._ViewModel as ManagerPrescriptionCountFormViewModel;
        that._TTObject = this.managerPrescriptionCountFormViewModel._ManagerPrescriptionCounts;
        if (this.managerPrescriptionCountFormViewModel == null)
            this.managerPrescriptionCountFormViewModel = new ManagerPrescriptionCountFormViewModel();
        if (this.managerPrescriptionCountFormViewModel._ManagerPrescriptionCounts == null)
            this.managerPrescriptionCountFormViewModel._ManagerPrescriptionCounts = new ManagerPrescriptionCounts();
        let resUserObjectId = this.managerPrescriptionCountFormViewModel._ManagerPrescriptionCounts["ResUser"];
        if (resUserObjectId != null && (typeof resUserObjectId === 'string')) {
            let resUser = that.managerPrescriptionCountFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectId.toString());
            if (resUser) {
                this.managerPrescriptionCountFormViewModel._ManagerPrescriptionCounts.ResUser = resUser;
            }
        }
        if (this.managerPrescriptionCountFormViewModel.oldCounts.length > 1) {
            // this.gridHeight = (this.managerPrescriptionCountFormViewModel.oldCounts.length * 50).toString() + "px";
            this.oldCountGrid.instance.repaint();
        }
    }

    async  onRowDeleted(event) {
        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", " Daha önceden eklenmiş oran bilgisi silinecektir. Devam edilsin mi?"), 1);
        if (result === "H")
            return;

        let response = await this.httpService.get<boolean>('/api/ManagerPrescriptionCountsService/CancelAddedManagerPrescriptionCount?ObjectId=' + event.data.ObjectId);

        if (response == true) {
            ServiceLocator.MessageService.showSuccess("Oran bilgisi başarıyla silinmiştir.");
            this.ActiveIDsModel = null;
            this.ObjectID = null;
            await this.load()
        }
    }

    async ngOnInit() {
        await this.load();
    }

    public async onGridRowClick(event) {
        this.ActiveIDsModel = new ActiveIDsModel(null, null, null);
        this.ObjectID = event.data.ObjectId;
        await this.load();
        //this.loadProcedure($event.data)
        // this.TTObjectToModel();
    }

    public changeRate() {

        if (this._ManagerPrescriptionCounts.TotalPrescriptionCounts != null && +this._ManagerPrescriptionCounts.TotalPrescriptionCounts > 0
            && this._ManagerPrescriptionCounts.ePrescriptionCount != null && +this._ManagerPrescriptionCounts.ePrescriptionCount >= 0) {
            this._ManagerPrescriptionCounts.PrescriptionCountRate = "%" + Number(((+this._ManagerPrescriptionCounts.ePrescriptionCount / +this._ManagerPrescriptionCounts.TotalPrescriptionCounts) * 100).toFixed(2));
        } else {
            this._ManagerPrescriptionCounts.PrescriptionCountRate = "";
        }
    }

    public onResUserChanged(event): void {
        if (event != null) {
            if (this._ManagerPrescriptionCounts != null && this._ManagerPrescriptionCounts.ResUser != event) {
                this._ManagerPrescriptionCounts.ResUser = event;
            }
        }
    }

    public onEndDateChanged(event): void {
        if (this._ManagerPrescriptionCounts != null && this._ManagerPrescriptionCounts.EndDate != event) {
            this._ManagerPrescriptionCounts.EndDate = event;
        }
    }

    public onePrescriptionCountChanged(event): void {
        if (this._ManagerPrescriptionCounts != null && this._ManagerPrescriptionCounts.ePrescriptionCount != event) {
            this._ManagerPrescriptionCounts.ePrescriptionCount = event;
            this.calculateTotalCount();
            this.changeRate();
        }
    }

    public onEmergencyPrescriptionCountChanged(event): void {
        if (this._ManagerPrescriptionCounts != null && this._ManagerPrescriptionCounts.EmergencyPrescriptionCount != event) {
            this._ManagerPrescriptionCounts.EmergencyPrescriptionCount = event;
            this.calculateTotalCount();
            this.changeRate();
        }
    }

    public onPoliclinicPrescriptionCountChanged(event): void {
        if (this._ManagerPrescriptionCounts != null && this._ManagerPrescriptionCounts.PoliclinicPrescriptionCount != event) {
            this._ManagerPrescriptionCounts.PoliclinicPrescriptionCount = event;
            this.calculateTotalCount();
            this.changeRate();
        }
    }

    public onPrescriptionCountRateChanged(event): void {
        if (this._ManagerPrescriptionCounts != null && this._ManagerPrescriptionCounts.PrescriptionCountRate != event) {
            this._ManagerPrescriptionCounts.PrescriptionCountRate = event;
        }
    }

    public onStartDateChanged(event): void {
        if (this._ManagerPrescriptionCounts != null && this._ManagerPrescriptionCounts.StartDate != event) {
            this._ManagerPrescriptionCounts.StartDate = event;
        }
    }

    public onTotalPrescriptionCountsChanged(event): void {
        if (this._ManagerPrescriptionCounts != null && this._ManagerPrescriptionCounts.TotalPrescriptionCounts != event) {
            this._ManagerPrescriptionCounts.TotalPrescriptionCounts = event;
            this.changeRate();
        }
    }

    public calculateTotalCount() {
        if (this._ManagerPrescriptionCounts.EmergencyPrescriptionCount != null &&
            this._ManagerPrescriptionCounts.PoliclinicPrescriptionCount != null &&
            this._ManagerPrescriptionCounts.ePrescriptionCount != null) {

            let PolPaperCount: number = +this._ManagerPrescriptionCounts.PoliclinicPrescriptionCount;
            let ePresCount: number = +this._ManagerPrescriptionCounts.ePrescriptionCount;
            let EmergencyPaperCount: number = +this._ManagerPrescriptionCounts.EmergencyPrescriptionCount;

            this._ManagerPrescriptionCounts.TotalPrescriptionCounts = (ePresCount + PolPaperCount + EmergencyPaperCount).toString();
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.ePrescriptionCount, "Text", this.__ttObject, "ePrescriptionCount");
        redirectProperty(this.EmergencyPrescriptionCount, "Text", this.__ttObject, "EmergencyPrescriptionCount");
        redirectProperty(this.PoliclinicPrescriptionCount, "Text", this.__ttObject, "PoliclinicPrescriptionCount");
        redirectProperty(this.TotalPrescriptionCounts, "Text", this.__ttObject, "TotalPrescriptionCounts");
        redirectProperty(this.StartDate, "Value", this.__ttObject, "StartDate");
        redirectProperty(this.EndDate, "Value", this.__ttObject, "EndDate");
        redirectProperty(this.PrescriptionCountRate, "Text", this.__ttObject, "PrescriptionCountRate");
    }

    public initFormControls(): void {
        this.labelPrescriptionCountRate = new TTVisual.TTLabel();
        this.labelPrescriptionCountRate.Text = "Toplam Oran";
        this.labelPrescriptionCountRate.Name = "labelPrescriptionCountRate";
        this.labelPrescriptionCountRate.TabIndex = 11;

        this.PrescriptionCountRate = new TTVisual.TTTextBox();
        this.PrescriptionCountRate.Name = "PrescriptionCountRate";
        this.PrescriptionCountRate.TabIndex = 10;
        this.PrescriptionCountRate.ReadOnly = true;

        this.TotalPrescriptionCounts = new TTVisual.TTTextBox();
        this.TotalPrescriptionCounts.Name = "TotalPrescriptionCounts";
        this.TotalPrescriptionCounts.TabIndex = 4;
        this.TotalPrescriptionCounts.ReadOnly = true;

        this.EmergencyPrescriptionCount = new TTVisual.TTTextBox();
        this.EmergencyPrescriptionCount.Name = "EmergencyPrescriptionCount";
        this.EmergencyPrescriptionCount.TabIndex = 2;

        this.PoliclinicPrescriptionCount = new TTVisual.TTTextBox();
        this.PoliclinicPrescriptionCount.Name = "PoliclinicPrescriptionCount";
        this.PoliclinicPrescriptionCount.TabIndex = 2;

        this.ResUser = new TTVisual.TTObjectListBox();
        this.ResUser.ListDefName = "ResUserListDefinition";
        this.ResUser.ListFilterExpression = "USERTYPE IN (0, 2, 17)";
        this.ResUser.Name = "ProcedureByUser";
        this.ResUser.TabIndex = 30;

        this.ePrescriptionCount = new TTVisual.TTTextBox();
        this.ePrescriptionCount.Name = "ePrescriptionCount";
        this.ePrescriptionCount.TabIndex = 0;

        this.labelEndDate = new TTVisual.TTLabel();
        this.labelEndDate.Text = "Bitiş Tarihi";
        this.labelEndDate.Name = "labelEndDate";
        this.labelEndDate.TabIndex = 9;

        this.EndDate = new TTVisual.TTDateTimePicker();
        this.EndDate.Format = DateTimePickerFormat.Short;
        this.EndDate.Name = "EndDate";
        this.EndDate.TabIndex = 8;

        this.labelStartDate = new TTVisual.TTLabel();
        this.labelStartDate.Text = "Başlangıç Tarihi";
        this.labelStartDate.Name = "labelStartDate";
        this.labelStartDate.TabIndex = 7;

        this.StartDate = new TTVisual.TTDateTimePicker();
        this.StartDate.Format = DateTimePickerFormat.Short;
        this.StartDate.Name = "StartDate";
        this.StartDate.TabIndex = 6;

        this.labelTotalPrescriptionCounts = new TTVisual.TTLabel();
        this.labelTotalPrescriptionCounts.Text = "Toplam Reçete Sayısı";
        this.labelTotalPrescriptionCounts.Name = "labelTotalPrescriptionCounts";
        this.labelTotalPrescriptionCounts.TabIndex = 5;

        this.labelEmergencyPrescriptionCount = new TTVisual.TTLabel();
        this.labelEmergencyPrescriptionCount.Text = "Kağıt Reçete Sayısı (Acil)";
        this.labelEmergencyPrescriptionCount.Name = "labelEmergencyPrescriptionCount";
        this.labelEmergencyPrescriptionCount.TabIndex = 3;

        this.labelPoliclinicPrescriptionCount = new TTVisual.TTLabel();
        this.labelPoliclinicPrescriptionCount.Text = "Kağıt Reçete Sayısı (Acil)";
        this.labelPoliclinicPrescriptionCount.Name = "labelPoliclinicPrescriptionCount";
        this.labelPoliclinicPrescriptionCount.TabIndex = 3;

        this.labelePrescriptionCount = new TTVisual.TTLabel();
        this.labelePrescriptionCount.Text = "e-Reçete Sayısı";
        this.labelePrescriptionCount.Name = "labelePrescriptionCount";
        this.labelePrescriptionCount.TabIndex = 1;

        this.Controls = [this.labelPrescriptionCountRate, this.PrescriptionCountRate, this.ResUser, this.TotalPrescriptionCounts, this.EmergencyPrescriptionCount, this.PoliclinicPrescriptionCount, this.ePrescriptionCount, this.labelEndDate, this.EndDate, this.labelStartDate, this.StartDate, this.labelTotalPrescriptionCounts, this.labelEmergencyPrescriptionCount, this.labelPoliclinicPrescriptionCount, this.labelePrescriptionCount];

    }


}
