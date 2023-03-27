//$8278A03D
import { Component, OnInit  } from '@angular/core';
import { BalanceCoordinationTestsFormViewModel } from './BalanceCoordinationTestsFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BalanceCoordinationTestsForm } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { BaseAdditionalInfoForm } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/BaseAdditionalInfoFormForm';
import { ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'BalanceCoordinationTestsForm',
    templateUrl: './BalanceCoordinationTestsFormForm.html',
    providers: [MessageService]
})
export class BalanceCoordinationTestsFormForm extends BaseAdditionalInfoForm implements OnInit {
    BergBalanceTest: TTVisual.ITTTextBox;
    Code: TTVisual.ITTTextBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    FallsEfficacyScale: TTVisual.ITTTextBox;
    FiveTimesSitToStandTest: TTVisual.ITTTextBox;
    FourSquareStepTest: TTVisual.ITTTextBox;
    labelBergBalanceTest: TTVisual.ITTLabel;
    labelCode: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelFallsEfficacyScale: TTVisual.ITTLabel;
    labelFiveTimesSitToStandTest: TTVisual.ITTLabel;
    labelFourSquareStepTest: TTVisual.ITTLabel;
    labelLieDownTest: TTVisual.ITTLabel;
    labelStandingOnOneLeg: TTVisual.ITTLabel;
    labelStandUpWalkTest: TTVisual.ITTLabel;
    LieDownTest: TTVisual.ITTTextBox;
    StandingOnOneLeg: TTVisual.ITTTextBox;
    StandUpWalkTest: TTVisual.ITTTextBox;
    public balanceCoordinationTestsFormViewModel: BalanceCoordinationTestsFormViewModel = new BalanceCoordinationTestsFormViewModel();
    public get _BalanceCoordinationTestsForm(): BalanceCoordinationTestsForm {
        return this._TTObject as BalanceCoordinationTestsForm;
    }
    private BalanceCoordinationTestsForm_DocumentUrl: string = '/api/BalanceCoordinationTestsFormService/BalanceCoordinationTestsForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super(httpService, messageService, modalStateService);
        this._DocumentServiceUrl = this.BalanceCoordinationTestsForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BalanceCoordinationTestsForm();
        this.balanceCoordinationTestsFormViewModel = new BalanceCoordinationTestsFormViewModel();
        this._ViewModel = this.balanceCoordinationTestsFormViewModel;
        this.balanceCoordinationTestsFormViewModel._BalanceCoordinationTestsForm = this._TTObject as BalanceCoordinationTestsForm;
    }

    protected loadViewModel() {
        let that = this;
        that.balanceCoordinationTestsFormViewModel = this._ViewModel as BalanceCoordinationTestsFormViewModel;
        that._TTObject = this.balanceCoordinationTestsFormViewModel._BalanceCoordinationTestsForm;
        if (this.balanceCoordinationTestsFormViewModel == null)
            this.balanceCoordinationTestsFormViewModel = new BalanceCoordinationTestsFormViewModel();
        if (this.balanceCoordinationTestsFormViewModel._BalanceCoordinationTestsForm == null)
            this.balanceCoordinationTestsFormViewModel._BalanceCoordinationTestsForm = new BalanceCoordinationTestsForm();

    }

    async ngOnInit() {
        await this.load(BalanceCoordinationTestsFormViewModel);
    }

    public onBergBalanceTestChanged(event): void {
        if (event != null) {
            if (this._BalanceCoordinationTestsForm != null && this._BalanceCoordinationTestsForm.BergBalanceTest != event) {
                this._BalanceCoordinationTestsForm.BergBalanceTest = event;
            }
        }
    }

    public onCodeChanged(event): void {
        if (event != null) {
            if (this._BalanceCoordinationTestsForm != null && this._BalanceCoordinationTestsForm.Code != event) {
                this._BalanceCoordinationTestsForm.Code = event;
            }
        }
    }

    public onCreationDateChanged(event): void {
        if (event != null) {
            if (this._BalanceCoordinationTestsForm != null && this._BalanceCoordinationTestsForm.CreationDate != event) {
                this._BalanceCoordinationTestsForm.CreationDate = event;
            }
        }
    }

    public onFallsEfficacyScaleChanged(event): void {
        if (event != null) {
            if (this._BalanceCoordinationTestsForm != null && this._BalanceCoordinationTestsForm.FallsEfficacyScale != event) {
                this._BalanceCoordinationTestsForm.FallsEfficacyScale = event;
            }
        }
    }

    public onFiveTimesSitToStandTestChanged(event): void {
        if (event != null) {
            if (this._BalanceCoordinationTestsForm != null && this._BalanceCoordinationTestsForm.FiveTimesSitToStandTest != event) {
                this._BalanceCoordinationTestsForm.FiveTimesSitToStandTest = event;
            }
        }
    }

    public onFourSquareStepTestChanged(event): void {
        if (event != null) {
            if (this._BalanceCoordinationTestsForm != null && this._BalanceCoordinationTestsForm.FourSquareStepTest != event) {
                this._BalanceCoordinationTestsForm.FourSquareStepTest = event;
            }
        }
    }

    public onLieDownTestChanged(event): void {
        if (event != null) {
            if (this._BalanceCoordinationTestsForm != null && this._BalanceCoordinationTestsForm.LieDownTest != event) {
                this._BalanceCoordinationTestsForm.LieDownTest = event;
            }
        }
    }

    public onStandingOnOneLegChanged(event): void {
        if (event != null) {
            if (this._BalanceCoordinationTestsForm != null && this._BalanceCoordinationTestsForm.StandingOnOneLeg != event) {
                this._BalanceCoordinationTestsForm.StandingOnOneLeg = event;
            }
        }
    }

    public onStandUpWalkTestChanged(event): void {
        if (event != null) {
            if (this._BalanceCoordinationTestsForm != null && this._BalanceCoordinationTestsForm.StandUpWalkTest != event) {
                this._BalanceCoordinationTestsForm.StandUpWalkTest = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.StandingOnOneLeg, "Text", this.__ttObject, "StandingOnOneLeg");
        redirectProperty(this.FallsEfficacyScale, "Text", this.__ttObject, "FallsEfficacyScale");
        redirectProperty(this.FourSquareStepTest, "Text", this.__ttObject, "FourSquareStepTest");
        redirectProperty(this.StandUpWalkTest, "Text", this.__ttObject, "StandUpWalkTest");
        redirectProperty(this.LieDownTest, "Text", this.__ttObject, "LieDownTest");
        redirectProperty(this.FiveTimesSitToStandTest, "Text", this.__ttObject, "FiveTimesSitToStandTest");
        redirectProperty(this.BergBalanceTest, "Text", this.__ttObject, "BergBalanceTest");
    }

    public initFormControls(): void {
        this.labelFiveTimesSitToStandTest = new TTVisual.TTLabel();
        this.labelFiveTimesSitToStandTest.Text = i18n("M11769", "Beş Kere Oturup Kalkma Testi");
        this.labelFiveTimesSitToStandTest.Name = "labelFiveTimesSitToStandTest";
        this.labelFiveTimesSitToStandTest.TabIndex = 17;

        this.FiveTimesSitToStandTest = new TTVisual.TTTextBox();
        this.FiveTimesSitToStandTest.Name = "FiveTimesSitToStandTest";
        this.FiveTimesSitToStandTest.TabIndex = 16;

        this.FourSquareStepTest = new TTVisual.TTTextBox();
        this.FourSquareStepTest.Name = "FourSquareStepTest";
        this.FourSquareStepTest.TabIndex = 14;

        this.LieDownTest = new TTVisual.TTTextBox();
        this.LieDownTest.Name = "LieDownTest";
        this.LieDownTest.TabIndex = 12;

        this.FallsEfficacyScale = new TTVisual.TTTextBox();
        this.FallsEfficacyScale.Name = "FallsEfficacyScale";
        this.FallsEfficacyScale.TabIndex = 10;

        this.BergBalanceTest = new TTVisual.TTTextBox();
        this.BergBalanceTest.Name = "BergBalanceTest";
        this.BergBalanceTest.TabIndex = 8;

        this.StandUpWalkTest = new TTVisual.TTTextBox();
        this.StandUpWalkTest.Name = "StandUpWalkTest";
        this.StandUpWalkTest.TabIndex = 6;

        this.StandingOnOneLeg = new TTVisual.TTTextBox();
        this.StandingOnOneLeg.Name = "StandingOnOneLeg";
        this.StandingOnOneLeg.TabIndex = 4;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Name = "Code";
        this.Code.TabIndex = 0;

        this.labelFourSquareStepTest = new TTVisual.TTLabel();
        this.labelFourSquareStepTest.Text = i18n("M13339", "Dört Kare Adım Testi");
        this.labelFourSquareStepTest.Name = "labelFourSquareStepTest";
        this.labelFourSquareStepTest.TabIndex = 15;

        this.labelLieDownTest = new TTVisual.TTLabel();
        this.labelLieDownTest.Text = "Uzanma Testi";
        this.labelLieDownTest.Name = "labelLieDownTest";
        this.labelLieDownTest.TabIndex = 13;

        this.labelFallsEfficacyScale = new TTVisual.TTLabel();
        this.labelFallsEfficacyScale.Text = i18n("M14090", "Falls Efficacy Scale");
        this.labelFallsEfficacyScale.Name = "labelFallsEfficacyScale";
        this.labelFallsEfficacyScale.TabIndex = 11;

        this.labelBergBalanceTest = new TTVisual.TTLabel();
        this.labelBergBalanceTest.Text = i18n("M11762", "Berg Denge Testi");
        this.labelBergBalanceTest.Name = "labelBergBalanceTest";
        this.labelBergBalanceTest.TabIndex = 9;

        this.labelStandUpWalkTest = new TTVisual.TTLabel();
        this.labelStandUpWalkTest.Text = i18n("M17124", "Kalk ve Yürü Testi");
        this.labelStandUpWalkTest.Name = "labelStandUpWalkTest";
        this.labelStandUpWalkTest.TabIndex = 7;

        this.labelStandingOnOneLeg = new TTVisual.TTLabel();
        this.labelStandingOnOneLeg.Text = i18n("M23070", "Tek Bacak Üzerinde Durma");
        this.labelStandingOnOneLeg.Name = "labelStandingOnOneLeg";
        this.labelStandingOnOneLeg.TabIndex = 5;

        this.labelCreationDate = new TTVisual.TTLabel();
        this.labelCreationDate.Text = i18n("M13548", "Ekleme Tarihi / Saati");
        this.labelCreationDate.Name = "labelCreationDate";
        this.labelCreationDate.TabIndex = 3;

        this.CreationDate = new TTVisual.TTDateTimePicker();
        this.CreationDate.Format = DateTimePickerFormat.Long;
        this.CreationDate.Name = "CreationDate";
        this.CreationDate.TabIndex = 2;

        this.labelCode = new TTVisual.TTLabel();
        this.labelCode.Text = "Kodu";
        this.labelCode.Name = "labelCode";
        this.labelCode.TabIndex = 1;

        this.Controls = [this.labelFiveTimesSitToStandTest, this.FiveTimesSitToStandTest, this.FourSquareStepTest, this.LieDownTest, this.FallsEfficacyScale, this.BergBalanceTest, this.StandUpWalkTest, this.StandingOnOneLeg, this.Code, this.labelFourSquareStepTest, this.labelLieDownTest, this.labelFallsEfficacyScale, this.labelBergBalanceTest, this.labelStandUpWalkTest, this.labelStandingOnOneLeg, this.labelCreationDate, this.CreationDate, this.labelCode];

    }


}
