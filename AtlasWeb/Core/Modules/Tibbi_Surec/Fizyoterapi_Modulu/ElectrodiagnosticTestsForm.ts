//$7EC77AF7
import { Component, OnInit  } from '@angular/core';
import { ElectrodiagnosticTestsFormViewModel } from './ElectrodiagnosticTestsFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ElectrodiagnosticTests } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'ElectrodiagnosticTestsForm',
    templateUrl: './ElectrodiagnosticTestsForm.html',
    providers: [MessageService]
})
export class ElectrodiagnosticTestsForm extends BaseAdditionalInfoForm implements OnInit {
    Code: TTVisual.ITTTextBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    labelCode: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelRheobaseAndChronaxie: TTVisual.ITTLabel;
    RheobaseAndChronaxie: TTVisual.ITTTextBox;
    public electrodiagnosticTestsFormViewModel: ElectrodiagnosticTestsFormViewModel = new ElectrodiagnosticTestsFormViewModel();
    public get _ElectrodiagnosticTests(): ElectrodiagnosticTests {
        return this._TTObject as ElectrodiagnosticTests;
    }
    private ElectrodiagnosticTestsForm_DocumentUrl: string = '/api/ElectrodiagnosticTestsService/ElectrodiagnosticTestsForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.ElectrodiagnosticTestsForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ElectrodiagnosticTests();
        this.electrodiagnosticTestsFormViewModel = new ElectrodiagnosticTestsFormViewModel();
        this._ViewModel = this.electrodiagnosticTestsFormViewModel;
        this.electrodiagnosticTestsFormViewModel._ElectrodiagnosticTests = this._TTObject as ElectrodiagnosticTests;
    }

    protected loadViewModel() {
        let that = this;
        that.electrodiagnosticTestsFormViewModel = this._ViewModel as ElectrodiagnosticTestsFormViewModel;
        that._TTObject = this.electrodiagnosticTestsFormViewModel._ElectrodiagnosticTests;
        if (this.electrodiagnosticTestsFormViewModel == null)
            this.electrodiagnosticTestsFormViewModel = new ElectrodiagnosticTestsFormViewModel();
        if (this.electrodiagnosticTestsFormViewModel._ElectrodiagnosticTests == null)
            this.electrodiagnosticTestsFormViewModel._ElectrodiagnosticTests = new ElectrodiagnosticTests();

    }

    async ngOnInit() {
        await this.load(ElectrodiagnosticTestsFormViewModel);
    }

    public onCodeChanged(event): void {
        if (event != null) {
            if (this._ElectrodiagnosticTests != null && this._ElectrodiagnosticTests.Code != event) {
                this._ElectrodiagnosticTests.Code = event;
            }
        }
    }

    public onCreationDateChanged(event): void {
        if (event != null) {
            if (this._ElectrodiagnosticTests != null && this._ElectrodiagnosticTests.CreationDate != event) {
                this._ElectrodiagnosticTests.CreationDate = event;
            }
        }
    }

    public onRheobaseAndChronaxieChanged(event): void {
        if (event != null) {
            if (this._ElectrodiagnosticTests != null && this._ElectrodiagnosticTests.RheobaseAndChronaxie != event) {
                this._ElectrodiagnosticTests.RheobaseAndChronaxie = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.RheobaseAndChronaxie, "Text", this.__ttObject, "RheobaseAndChronaxie");
    }

    public initFormControls(): void {
        this.labelCreationDate = new TTVisual.TTLabel();
        this.labelCreationDate.Text = i18n("M13548", "Ekleme Tarihi / Saati");
        this.labelCreationDate.Name = "labelCreationDate";
        this.labelCreationDate.TabIndex = 7;

        this.CreationDate = new TTVisual.TTDateTimePicker();
        this.CreationDate.Format = DateTimePickerFormat.Long;
        this.CreationDate.Name = "CreationDate";
        this.CreationDate.TabIndex = 6;

        this.labelRheobaseAndChronaxie = new TTVisual.TTLabel();
        this.labelRheobaseAndChronaxie.Text = i18n("M21026", "Reobaz ve Kronaksi Ölçümü");
        this.labelRheobaseAndChronaxie.Name = "labelRheobaseAndChronaxie";
        this.labelRheobaseAndChronaxie.TabIndex = 5;

        this.RheobaseAndChronaxie = new TTVisual.TTTextBox();
        this.RheobaseAndChronaxie.Name = "RheobaseAndChronaxie";
        this.RheobaseAndChronaxie.TabIndex = 4;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Name = "Code";
        this.Code.TabIndex = 0;

        this.labelCode = new TTVisual.TTLabel();
        this.labelCode.Text = "Kodu";
        this.labelCode.Name = "labelCode";
        this.labelCode.TabIndex = 1;

        this.Controls = [this.labelCreationDate, this.CreationDate, this.labelRheobaseAndChronaxie, this.RheobaseAndChronaxie, this.Code, this.labelCode];

    }


}
