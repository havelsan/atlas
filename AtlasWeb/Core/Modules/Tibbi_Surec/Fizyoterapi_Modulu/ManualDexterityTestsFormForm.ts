//$2FD8CDAE
import { Component, OnInit  } from '@angular/core';
import { ManualDexterityTestsFormViewModel } from './ManualDexterityTestsFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ManualDexterityTestsForm } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'ManualDexterityTestsForm',
    templateUrl: './ManualDexterityTestsFormForm.html',
    providers: [MessageService]
})
export class ManualDexterityTestsFormForm extends BaseAdditionalInfoForm implements OnInit {
    BimanuelFineMotorTest: TTVisual.ITTTextBox;
    Code: TTVisual.ITTTextBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    DellonTest: TTVisual.ITTTextBox;
    labelBimanuelFineMotorTest: TTVisual.ITTLabel;
    labelCode: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelDellonTest: TTVisual.ITTLabel;
    labelMobergTest: TTVisual.ITTLabel;
    labelNineHolePegTest: TTVisual.ITTLabel;
    labelOConnorTest: TTVisual.ITTLabel;
    labelPurduePegboardTest: TTVisual.ITTLabel;
    MobergTest: TTVisual.ITTTextBox;
    NineHolePegTest: TTVisual.ITTTextBox;
    OConnorTest: TTVisual.ITTTextBox;
    PurduePegboardTest: TTVisual.ITTTextBox;
    public manualDexterityTestsFormViewModel: ManualDexterityTestsFormViewModel = new ManualDexterityTestsFormViewModel();
    public get _ManualDexterityTestsForm(): ManualDexterityTestsForm {
        return this._TTObject as ManualDexterityTestsForm;
    }
    private ManualDexterityTestsForm_DocumentUrl: string = '/api/ManualDexterityTestsFormService/ManualDexterityTestsForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.ManualDexterityTestsForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ManualDexterityTestsForm();
        this.manualDexterityTestsFormViewModel = new ManualDexterityTestsFormViewModel();
        this._ViewModel = this.manualDexterityTestsFormViewModel;
        this.manualDexterityTestsFormViewModel._ManualDexterityTestsForm = this._TTObject as ManualDexterityTestsForm;
    }

    protected loadViewModel() {
        let that = this;
        that.manualDexterityTestsFormViewModel = this._ViewModel as ManualDexterityTestsFormViewModel;
        that._TTObject = this.manualDexterityTestsFormViewModel._ManualDexterityTestsForm;
        if (this.manualDexterityTestsFormViewModel == null)
            this.manualDexterityTestsFormViewModel = new ManualDexterityTestsFormViewModel();
        if (this.manualDexterityTestsFormViewModel._ManualDexterityTestsForm == null)
            this.manualDexterityTestsFormViewModel._ManualDexterityTestsForm = new ManualDexterityTestsForm();

    }

    async ngOnInit() {
        await this.load(ManualDexterityTestsFormViewModel);
    }

    public onBimanuelFineMotorTestChanged(event): void {
        if (event != null) {
            if (this._ManualDexterityTestsForm != null && this._ManualDexterityTestsForm.BimanuelFineMotorTest != event) {
                this._ManualDexterityTestsForm.BimanuelFineMotorTest = event;
            }
        }
    }

    public onCodeChanged(event): void {
        if (event != null) {
            if (this._ManualDexterityTestsForm != null && this._ManualDexterityTestsForm.Code != event) {
                this._ManualDexterityTestsForm.Code = event;
            }
        }
    }

    public onCreationDateChanged(event): void {
        if (event != null) {
            if (this._ManualDexterityTestsForm != null && this._ManualDexterityTestsForm.CreationDate != event) {
                this._ManualDexterityTestsForm.CreationDate = event;
            }
        }
    }

    public onDellonTestChanged(event): void {
        if (event != null) {
            if (this._ManualDexterityTestsForm != null && this._ManualDexterityTestsForm.DellonTest != event) {
                this._ManualDexterityTestsForm.DellonTest = event;
            }
        }
    }

    public onMobergTestChanged(event): void {
        if (event != null) {
            if (this._ManualDexterityTestsForm != null && this._ManualDexterityTestsForm.MobergTest != event) {
                this._ManualDexterityTestsForm.MobergTest = event;
            }
        }
    }

    public onNineHolePegTestChanged(event): void {
        if (event != null) {
            if (this._ManualDexterityTestsForm != null && this._ManualDexterityTestsForm.NineHolePegTest != event) {
                this._ManualDexterityTestsForm.NineHolePegTest = event;
            }
        }
    }

    public onOConnorTestChanged(event): void {
        if (event != null) {
            if (this._ManualDexterityTestsForm != null && this._ManualDexterityTestsForm.OConnorFingerDexterityTest != event) {
                this._ManualDexterityTestsForm.OConnorFingerDexterityTest = event;
            }
        }
    }

    public onPurduePegboardTestChanged(event): void {
        if (event != null) {
            if (this._ManualDexterityTestsForm != null && this._ManualDexterityTestsForm.PurduePegboardTest != event) {
                this._ManualDexterityTestsForm.PurduePegboardTest = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.PurduePegboardTest, "Text", this.__ttObject, "PurduePegboardTest");
        redirectProperty(this.MobergTest, "Text", this.__ttObject, "MobergTest");
        redirectProperty(this.OConnorTest, "Text", this.__ttObject, "OConnorFingerDexterityTest");
        redirectProperty(this.BimanuelFineMotorTest, "Text", this.__ttObject, "BimanuelFineMotorTest");
        redirectProperty(this.NineHolePegTest, "Text", this.__ttObject, "NineHolePegTest");
        redirectProperty(this.DellonTest, "Text", this.__ttObject, "DellonTest");
    }

    public initFormControls(): void {
        this.labelCreationDate = new TTVisual.TTLabel();
        this.labelCreationDate.Text = i18n("M13548", "Ekleme Tarihi / Saati");
        this.labelCreationDate.Name = "labelCreationDate";
        this.labelCreationDate.TabIndex = 19;

        this.CreationDate = new TTVisual.TTDateTimePicker();
        this.CreationDate.Format = DateTimePickerFormat.Long;
        this.CreationDate.Name = "CreationDate";
        this.CreationDate.TabIndex = 18;

        this.labelCode = new TTVisual.TTLabel();
        this.labelCode.Text = "Kodu";
        this.labelCode.Name = "labelCode";
        this.labelCode.TabIndex = 17;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Name = "Code";
        this.Code.TabIndex = 16;

        this.DellonTest = new TTVisual.TTTextBox();
        this.DellonTest.Name = "DellonTest";
        this.DellonTest.TabIndex = 14;

        this.BimanuelFineMotorTest = new TTVisual.TTTextBox();
        this.BimanuelFineMotorTest.Name = "BimanuelFineMotorTest";
        this.BimanuelFineMotorTest.TabIndex = 12;

        this.MobergTest = new TTVisual.TTTextBox();
        this.MobergTest.Name = "MobergTest";
        this.MobergTest.TabIndex = 10;

        this.NineHolePegTest = new TTVisual.TTTextBox();
        this.NineHolePegTest.Name = "NineHolePegTest";
        this.NineHolePegTest.TabIndex = 8;

        this.OConnorTest = new TTVisual.TTTextBox();
        this.OConnorTest.Name = "OConnorTest";
        this.OConnorTest.TabIndex = 6;

        this.PurduePegboardTest = new TTVisual.TTTextBox();
        this.PurduePegboardTest.Name = "PurduePegboardTest";
        this.PurduePegboardTest.TabIndex = 4;

        this.labelDellonTest = new TTVisual.TTLabel();
        this.labelDellonTest.Text = "Dellon Modifiye Toplama Test";
        this.labelDellonTest.Name = "labelDellonTest";
        this.labelDellonTest.TabIndex = 15;

        this.labelBimanuelFineMotorTest = new TTVisual.TTLabel();
        this.labelBimanuelFineMotorTest.Text = i18n("M11810", "Bimanuel Fine Motor Test");
        this.labelBimanuelFineMotorTest.Name = "labelBimanuelFineMotorTest";
        this.labelBimanuelFineMotorTest.TabIndex = 13;

        this.labelMobergTest = new TTVisual.TTLabel();
        this.labelMobergTest.Text = i18n("M19111", "Moberg Toplama Testi");
        this.labelMobergTest.Name = "labelMobergTest";
        this.labelMobergTest.TabIndex = 11;

        this.labelNineHolePegTest = new TTVisual.TTLabel();
        this.labelNineHolePegTest.Text = i18n("M19454", "Nine Hole Peg Test");
        this.labelNineHolePegTest.Name = "labelNineHolePegTest";
        this.labelNineHolePegTest.TabIndex = 9;

        this.labelOConnorTest = new TTVisual.TTLabel();
        this.labelOConnorTest.Text = i18n("M19601", "O'Connor Parmak Beceri Testi");
        this.labelOConnorTest.Name = "labelOConnorTest";
        this.labelOConnorTest.TabIndex = 7;

        this.labelPurduePegboardTest = new TTVisual.TTLabel();
        this.labelPurduePegboardTest.Text = i18n("M20635", "Purdue Pegboard Testi");
        this.labelPurduePegboardTest.Name = "labelPurduePegboardTest";
        this.labelPurduePegboardTest.TabIndex = 5;

        this.Controls = [this.labelCreationDate, this.CreationDate, this.labelCode, this.Code, this.DellonTest, this.BimanuelFineMotorTest, this.MobergTest, this.NineHolePegTest, this.OConnorTest, this.PurduePegboardTest, this.labelDellonTest, this.labelBimanuelFineMotorTest, this.labelMobergTest, this.labelNineHolePegTest, this.labelOConnorTest, this.labelPurduePegboardTest];

    }


}
