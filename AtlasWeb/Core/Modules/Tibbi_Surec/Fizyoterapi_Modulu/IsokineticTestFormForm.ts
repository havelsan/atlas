//$DCAC2281
import { Component, OnInit  } from '@angular/core';
import { IsokineticTestFormViewModel } from './IsokineticTestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { IsokineticTestForm } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'IsokineticTestForm',
    templateUrl: './IsokineticTestFormForm.html',
    providers: [MessageService]
})
export class IsokineticTestFormForm extends BaseAdditionalInfoForm implements OnInit {
    Code: TTVisual.ITTTextBox;
    ComputerBasedIsokineticTest: TTVisual.ITTTextBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    labelCode: TTVisual.ITTLabel;
    labelComputerBasedIsokineticTest: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    public isokineticTestFormViewModel: IsokineticTestFormViewModel = new IsokineticTestFormViewModel();
    public get _IsokineticTestForm(): IsokineticTestForm {
        return this._TTObject as IsokineticTestForm;
    }
    private IsokineticTestForm_DocumentUrl: string = '/api/IsokineticTestFormService/IsokineticTestForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.IsokineticTestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new IsokineticTestForm();
        this.isokineticTestFormViewModel = new IsokineticTestFormViewModel();
        this._ViewModel = this.isokineticTestFormViewModel;
        this.isokineticTestFormViewModel._IsokineticTestForm = this._TTObject as IsokineticTestForm;
    }

    protected loadViewModel() {
        let that = this;
        that.isokineticTestFormViewModel = this._ViewModel as IsokineticTestFormViewModel;
        that._TTObject = this.isokineticTestFormViewModel._IsokineticTestForm;
        if (this.isokineticTestFormViewModel == null)
            this.isokineticTestFormViewModel = new IsokineticTestFormViewModel();
        if (this.isokineticTestFormViewModel._IsokineticTestForm == null)
            this.isokineticTestFormViewModel._IsokineticTestForm = new IsokineticTestForm();

    }

    async ngOnInit() {
        await this.load(IsokineticTestFormViewModel);
    }

    public onCodeChanged(event): void {
        if (event != null) {
            if (this._IsokineticTestForm != null && this._IsokineticTestForm.Code != event) {
                this._IsokineticTestForm.Code = event;
            }
        }
    }

    public onComputerBasedIsokineticTestChanged(event): void {
        if (event != null) {
            if (this._IsokineticTestForm != null && this._IsokineticTestForm.ComputerBasedIsokineticTest != event) {
                this._IsokineticTestForm.ComputerBasedIsokineticTest = event;
            }
        }
    }

    public onCreationDateChanged(event): void {
        if (event != null) {
            if (this._IsokineticTestForm != null && this._IsokineticTestForm.CreationDate != event) {
                this._IsokineticTestForm.CreationDate = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.ComputerBasedIsokineticTest, "Text", this.__ttObject, "ComputerBasedIsokineticTest");
    }

    public initFormControls(): void {
        this.labelCreationDate = new TTVisual.TTLabel();
        this.labelCreationDate.Text = i18n("M13548", "Ekleme Tarihi / Saati");
        this.labelCreationDate.Name = "labelCreationDate";
        this.labelCreationDate.TabIndex = 5;

        this.CreationDate = new TTVisual.TTDateTimePicker();
        this.CreationDate.Format = DateTimePickerFormat.Long;
        this.CreationDate.Name = "CreationDate";
        this.CreationDate.TabIndex = 4;

        this.labelComputerBasedIsokineticTest = new TTVisual.TTLabel();
        this.labelComputerBasedIsokineticTest.Text = i18n("M11799", "Bilgisayarlı İzokinetik Test");
        this.labelComputerBasedIsokineticTest.Name = "labelComputerBasedIsokineticTest";
        this.labelComputerBasedIsokineticTest.TabIndex = 3;

        this.ComputerBasedIsokineticTest = new TTVisual.TTTextBox();
        this.ComputerBasedIsokineticTest.Name = "ComputerBasedIsokineticTest";
        this.ComputerBasedIsokineticTest.TabIndex = 2;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Name = "Code";
        this.Code.TabIndex = 0;

        this.labelCode = new TTVisual.TTLabel();
        this.labelCode.Text = "Kodu";
        this.labelCode.Name = "labelCode";
        this.labelCode.TabIndex = 1;

        this.Controls = [this.labelCreationDate, this.CreationDate, this.labelComputerBasedIsokineticTest, this.ComputerBasedIsokineticTest, this.Code, this.labelCode];

    }


}
