//$A02A6573
import { Component, OnInit, NgZone } from '@angular/core';
import { RadiologyDentalToothSchemaViewModel } from "./RadiologyDentalToothSchemaViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { ToothNumberEnum } from 'NebulaClient/Model/AtlasClientModel';




@Component({
    selector: 'RadiologyDentalToothSchema',
    templateUrl: './RadiologyDentalToothSchema.html',
    providers: [MessageService]
})
export class RadiologyDentalToothSchema extends TTVisual.TTForm implements OnInit {
    Anomali: TTVisual.ITTCheckBox;
    DentalPosition: TTVisual.ITTEnumComboBox;
    labelDentalPosition: TTVisual.ITTLabel;
    labelToothNumber: TTVisual.ITTLabel;
    ToothNumber: TTVisual.ITTEnumComboBox;
    ttbutton1: TTVisual.ITTButton;
    ttbutton11: TTVisual.ITTButton;
    ttbutton12: TTVisual.ITTButton;
    ttbutton13: TTVisual.ITTButton;
    ttbutton14: TTVisual.ITTButton;
    ttbutton15: TTVisual.ITTButton;
    ttbutton16: TTVisual.ITTButton;
    ttbutton17: TTVisual.ITTButton;
    ttbutton18: TTVisual.ITTButton;
    ttbutton19: TTVisual.ITTButton;
    ttbutton2: TTVisual.ITTButton;
    ttbutton21: TTVisual.ITTButton;
    ttbutton22: TTVisual.ITTButton;
    ttbutton23: TTVisual.ITTButton;
    ttbutton24: TTVisual.ITTButton;
    ttbutton25: TTVisual.ITTButton;
    ttbutton26: TTVisual.ITTButton;
    ttbutton27: TTVisual.ITTButton;
    ttbutton28: TTVisual.ITTButton;
    ttbutton3: TTVisual.ITTButton;
    ttbutton31: TTVisual.ITTButton;
    ttbutton32: TTVisual.ITTButton;
    ttbutton33: TTVisual.ITTButton;
    ttbutton34: TTVisual.ITTButton;
    ttbutton35: TTVisual.ITTButton;
    ttbutton36: TTVisual.ITTButton;
    ttbutton37: TTVisual.ITTButton;
    ttbutton38: TTVisual.ITTButton;
    ttbutton4: TTVisual.ITTButton;
    ttbutton41: TTVisual.ITTButton;
    ttbutton42: TTVisual.ITTButton;
    ttbutton43: TTVisual.ITTButton;
    ttbutton44: TTVisual.ITTButton;
    ttbutton45: TTVisual.ITTButton;
    ttbutton46: TTVisual.ITTButton;
    ttbutton47: TTVisual.ITTButton;
    ttbutton48: TTVisual.ITTButton;
    ttbutton5: TTVisual.ITTButton;
    ttbutton51: TTVisual.ITTButton;
    ttbutton52: TTVisual.ITTButton;
    ttbutton53: TTVisual.ITTButton;
    ttbutton54: TTVisual.ITTButton;
    ttbutton55: TTVisual.ITTButton;
    ttbutton6: TTVisual.ITTButton;
    ttbutton61: TTVisual.ITTButton;
    ttbutton62: TTVisual.ITTButton;
    ttbutton63: TTVisual.ITTButton;
    ttbutton64: TTVisual.ITTButton;
    ttbutton65: TTVisual.ITTButton;
    ttbutton71: TTVisual.ITTButton;
    ttbutton72: TTVisual.ITTButton;
    ttbutton73: TTVisual.ITTButton;
    ttbutton74: TTVisual.ITTButton;
    ttbutton75: TTVisual.ITTButton;
    ttbutton81: TTVisual.ITTButton;
    ttbutton82: TTVisual.ITTButton;
    ttbutton83: TTVisual.ITTButton;
    ttbutton84: TTVisual.ITTButton;
    ttbutton85: TTVisual.ITTButton;
    ttbutton91: TTVisual.ITTButton;
    ttbutton92: TTVisual.ITTButton;
    ttbutton93: TTVisual.ITTButton;
    ttbutton94: TTVisual.ITTButton;
    ttbuttonLeft: TTVisual.ITTButton;
    ttbuttonLeftUpperJaw: TTVisual.ITTButton;
    ttbuttonLL1: TTVisual.ITTButton;
    ttbuttonLL2: TTVisual.ITTButton;
    ttbuttonLower: TTVisual.ITTButton;
    ttbuttonLowerJaw: TTVisual.ITTButton;
    ttbuttonLU1: TTVisual.ITTButton;
    ttbuttonLU2: TTVisual.ITTButton;
    ttbuttonRight: TTVisual.ITTButton;
    ttbuttonRightLowerJaw: TTVisual.ITTButton;
    ttbuttonRightUpperJaw: TTVisual.ITTButton;
    ttbuttonRL1: TTVisual.ITTButton;
    ttbuttonRL2: TTVisual.ITTButton;
    ttbuttonRU1: TTVisual.ITTButton;
    ttbuttonRU2: TTVisual.ITTButton;
    ttbuttonUpper: TTVisual.ITTButton;
    ttbuttonUpperJaw: TTVisual.ITTButton;
    ttbuttonWholeJaw: TTVisual.ITTButton;
    ttbuttonWholeJaw2: TTVisual.ITTButton;
    ttgroupboxToothSchema: TTVisual.ITTGroupBox;
    ttlabelAdultTooth: TTVisual.ITTLabel;
    ttlabelAnamoliPositionNum: TTVisual.ITTLabel;
    ttlabelMilkTooth: TTVisual.ITTLabel;
    ttlabelMouthPositionNum: TTVisual.ITTLabel;
    public radiologyDentalToothSchemaViewModel: RadiologyDentalToothSchemaViewModel = new RadiologyDentalToothSchemaViewModel();
    public get _Radiology(): Radiology {
        return this._TTObject as Radiology;
    }
    private RadiologyDentalToothSchema_DocumentUrl: string = '/api/RadiologyService/RadiologyDentalToothSchema';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super("RADIOLOGY", "RadiologyDentalToothSchema");
        this._DocumentServiceUrl = this.RadiologyDentalToothSchema_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async ttbutton11_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth11;
    }
    public async ttbutton12_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth12;
    }
    public async ttbutton13_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth13;
    }
    public async ttbutton14_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth14;
    }
    public async ttbutton15_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth15;
    }
    public async ttbutton16_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth16;
    }
    public async ttbutton17_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth17;
    }
    public async ttbutton18_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth18;
    }
    public async ttbutton19_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.leftLowerJaw7;
    }
    public async ttbutton21_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth21;
    }
    public async ttbutton22_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth22;
    }
    public async ttbutton23_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth23;
    }
    public async ttbutton24_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth24;
    }
    public async ttbutton25_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth25;
    }
    public async ttbutton26_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth26;
    }
    public async ttbutton27_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth27;
    }
    public async ttbutton28_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth28;
    }
    public async ttbutton31_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth31;
    }
    public async ttbutton32_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth32;
    }
    public async ttbutton33_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth33;
    }
    public async ttbutton34_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth34;
    }
    public async ttbutton35_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth35;
    }
    public async ttbutton36_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth36;
    }
    public async ttbutton37_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth37;
    }
    public async ttbutton38_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth38;
    }
    public async ttbutton41_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth41;
    }
    public async ttbutton42_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth42;
    }
    public async ttbutton43_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth43;
    }
    public async ttbutton44_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth44;
    }
    public async ttbutton45_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth45;
    }
    public async ttbutton46_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth46;
    }
    public async ttbutton47_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth47;
    }
    public async ttbutton48_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.adultTooth48;
    }
    public async ttbutton51_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth51;
    }
    public async ttbutton52_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth52;
    }
    public async ttbutton53_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth53;
    }
    public async ttbutton54_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth54;
    }
    public async ttbutton55_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth55;
    }
    public async ttbutton61_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth61;
    }
    public async ttbutton62_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth62;
    }
    public async ttbutton63_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth63;
    }
    public async ttbutton64_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth64;
    }
    public async ttbutton71_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth71;
    }
    public async ttbutton72_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth72;
    }
    public async ttbutton73_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth73;
    }
    public async ttbutton74_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth74;
    }
    public async ttbutton75_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth75;
    }
    public async ttbutton81_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth81;
    }
    public async ttbutton82_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth82;
    }
    public async ttbutton83_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth83;
    }
    public async ttbutton84_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth84;
    }
    public async ttbutton85_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.milkTooth85;
    }
    public async ttbutton91_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.anomalyTooth91;
    }
    public async ttbutton92_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.anomalyTooth92;
    }
    public async ttbutton93_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.anomalyTooth93;
    }
    public async ttbutton94_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.anomalyTooth94;
    }
    public async ttbuttonLeftUpperJaw_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.leftUpperJaw5;
    }
    public async ttbuttonLowerJaw_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.lowerJaw3;
    }
    public async ttbuttonRightLowerJaw_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.rightLowerJaw6;
    }
    public async ttbuttonRightUpperJaw_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.rightUpperJaw4;
    }
    public async ttbuttonUpperJaw_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.upperJaw2;
    }
    public async ttbuttonWholeJaw_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.wholeJaw1;
    }
    public async ttbuttonWholeJaw2_Click(): Promise<void> {
        this._Radiology.ToothNumber = ToothNumberEnum.wholeJaw1;
    }
    protected async PreScript() {
        super.PreScript();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Radiology();
        this.radiologyDentalToothSchemaViewModel = new RadiologyDentalToothSchemaViewModel();
        this._ViewModel = this.radiologyDentalToothSchemaViewModel;
        this.radiologyDentalToothSchemaViewModel._Radiology = this._TTObject as Radiology;
    }

    protected loadViewModel() {
        let that = this;
        that.radiologyDentalToothSchemaViewModel = this._ViewModel as RadiologyDentalToothSchemaViewModel;
        that._TTObject = this.radiologyDentalToothSchemaViewModel._Radiology;
        if (this.radiologyDentalToothSchemaViewModel == null)
            this.radiologyDentalToothSchemaViewModel = new RadiologyDentalToothSchemaViewModel();
        if (this.radiologyDentalToothSchemaViewModel._Radiology == null)
            this.radiologyDentalToothSchemaViewModel._Radiology = new Radiology();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(RadiologyDentalToothSchemaViewModel);
  
    }


    public onAnomaliChanged(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.Anomali != event) {
                this._Radiology.Anomali = event;
            }
        }
    }

    public onDentalPositionChanged(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.DentalPosition != event) {
                this._Radiology.DentalPosition = event;
            }
        }
    }

    public onToothNumberChanged(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.ToothNumber != event) {
                this._Radiology.ToothNumber = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Anomali, "Value", this.__ttObject, "Anomali");
        redirectProperty(this.ToothNumber, "Value", this.__ttObject, "ToothNumber");
        redirectProperty(this.DentalPosition, "Value", this.__ttObject, "DentalPosition");
    }

    public initFormControls(): void {
        this.Anomali = new TTVisual.TTCheckBox();
        this.Anomali.Value = false;
        this.Anomali.Text = "Anomali";
        this.Anomali.Name = "Anomali";
        this.Anomali.TabIndex = 6;

        this.ttgroupboxToothSchema = new TTVisual.TTGroupBox();
        this.ttgroupboxToothSchema.Text = i18n("M12940", "Diş Şeması");
        this.ttgroupboxToothSchema.Name = "ttgroupboxToothSchema";
        this.ttgroupboxToothSchema.TabIndex = 5;

        this.ttlabelAdultTooth = new TTVisual.TTLabel();
        this.ttlabelAdultTooth.Text = i18n("M13834", "Erişkin Dişi Numaraları");
        this.ttlabelAdultTooth.Name = "ttlabelAdultTooth";
        this.ttlabelAdultTooth.TabIndex = 88;

        this.ttlabelMilkTooth = new TTVisual.TTLabel();
        this.ttlabelMilkTooth.Text = i18n("M22429", "Süt Dişleri Numaraları");
        this.ttlabelMilkTooth.Name = "ttlabelMilkTooth";
        this.ttlabelMilkTooth.TabIndex = 87;

        this.ttlabelAnamoliPositionNum = new TTVisual.TTLabel();
        this.ttlabelAnamoliPositionNum.Text = i18n("M10956", "Anamoli Bölge Numaraları");
        this.ttlabelAnamoliPositionNum.Name = "ttlabelAnamoliPositionNum";
        this.ttlabelAnamoliPositionNum.TabIndex = 86;

        this.ttlabelMouthPositionNum = new TTVisual.TTLabel();
        this.ttlabelMouthPositionNum.Text = i18n("M10571", "Ağız Bölge Numaraları");
        this.ttlabelMouthPositionNum.Name = "ttlabelMouthPositionNum";
        this.ttlabelMouthPositionNum.TabIndex = 85;

        this.ttbutton6 = new TTVisual.TTButton();
        this.ttbutton6.BackColor = "#3399FF";
        this.ttbutton6.ForeColor = "#000000";
        this.ttbutton6.Name = "ttbutton6";
        this.ttbutton6.TabIndex = 84;

        this.ttbutton3 = new TTVisual.TTButton();
        this.ttbutton3.BackColor = "#008000";
        this.ttbutton3.ForeColor = "#000000";
        this.ttbutton3.Name = "ttbutton3";
        this.ttbutton3.TabIndex = 83;

        this.ttbutton2 = new TTVisual.TTButton();
        this.ttbutton2.BackColor = "#FF0000";
        this.ttbutton2.ForeColor = "#000000";
        this.ttbutton2.Name = "ttbutton2";
        this.ttbutton2.TabIndex = 82;

        this.ttbutton1 = new TTVisual.TTButton();
        this.ttbutton1.BackColor = "#000000";
        this.ttbutton1.Text = "ttbutton1";
        this.ttbutton1.ForeColor = "#000000";
        this.ttbutton1.Name = "ttbutton1";
        this.ttbutton1.TabIndex = 81;

        this.ttbutton94 = new TTVisual.TTButton();
        this.ttbutton94.Text = "94";
        this.ttbutton94.ForeColor = "#FF0000";
        this.ttbutton94.Name = "ttbutton94";
        this.ttbutton94.TabIndex = 80;

        this.ttbuttonLL1 = new TTVisual.TTButton();
        this.ttbuttonLL1.Name = "ttbuttonLL1";
        this.ttbuttonLL1.TabIndex = 79;

        this.ttbuttonLL2 = new TTVisual.TTButton();
        this.ttbuttonLL2.Name = "ttbuttonLL2";
        this.ttbuttonLL2.TabIndex = 76;

        this.ttbutton75 = new TTVisual.TTButton();
        this.ttbutton75.Text = "75";
        this.ttbutton75.ForeColor = "#008000";
        this.ttbutton75.Name = "ttbutton75";
        this.ttbutton75.TabIndex = 75;

        this.ttbutton74 = new TTVisual.TTButton();
        this.ttbutton74.Text = "74";
        this.ttbutton74.ForeColor = "#008000";
        this.ttbutton74.Name = "ttbutton74";
        this.ttbutton74.TabIndex = 74;

        this.ttbutton73 = new TTVisual.TTButton();
        this.ttbutton73.Text = "73";
        this.ttbutton73.ForeColor = "#008000";
        this.ttbutton73.Name = "ttbutton73";
        this.ttbutton73.TabIndex = 73;

        this.ttbutton72 = new TTVisual.TTButton();
        this.ttbutton72.Text = "72";
        this.ttbutton72.ForeColor = "#008000";
        this.ttbutton72.Name = "ttbutton72";
        this.ttbutton72.TabIndex = 72;

        this.ttbutton71 = new TTVisual.TTButton();
        this.ttbutton71.Text = "71";
        this.ttbutton71.ForeColor = "#008000";
        this.ttbutton71.Name = "ttbutton71";
        this.ttbutton71.TabIndex = 71;

        this.ttbutton37 = new TTVisual.TTButton();
        this.ttbutton37.Text = "37";
        this.ttbutton37.ForeColor = "#3399FF";
        this.ttbutton37.Name = "ttbutton37";
        this.ttbutton37.TabIndex = 70;

        this.ttbutton36 = new TTVisual.TTButton();
        this.ttbutton36.Text = "36";
        this.ttbutton36.ForeColor = "#3399FF";
        this.ttbutton36.Name = "ttbutton36";
        this.ttbutton36.TabIndex = 69;

        this.ttbutton35 = new TTVisual.TTButton();
        this.ttbutton35.Text = "35";
        this.ttbutton35.ForeColor = "#3399FF";
        this.ttbutton35.Name = "ttbutton35";
        this.ttbutton35.TabIndex = 68;

        this.ttbutton38 = new TTVisual.TTButton();
        this.ttbutton38.Text = "38";
        this.ttbutton38.ForeColor = "#3399FF";
        this.ttbutton38.Name = "ttbutton38";
        this.ttbutton38.TabIndex = 67;

        this.ttbutton34 = new TTVisual.TTButton();
        this.ttbutton34.Text = "34";
        this.ttbutton34.ForeColor = "#3399FF";
        this.ttbutton34.Name = "ttbutton34";
        this.ttbutton34.TabIndex = 66;

        this.ttbutton31 = new TTVisual.TTButton();
        this.ttbutton31.Text = "31";
        this.ttbutton31.ForeColor = "#3399FF";
        this.ttbutton31.Name = "ttbutton31";
        this.ttbutton31.TabIndex = 65;

        this.ttbutton32 = new TTVisual.TTButton();
        this.ttbutton32.Text = "32";
        this.ttbutton32.ForeColor = "#3399FF";
        this.ttbutton32.Name = "ttbutton32";
        this.ttbutton32.TabIndex = 64;

        this.ttbutton33 = new TTVisual.TTButton();
        this.ttbutton33.Text = "33";
        this.ttbutton33.ForeColor = "#3399FF";
        this.ttbutton33.Name = "ttbutton33";
        this.ttbutton33.TabIndex = 63;

        this.ttbuttonWholeJaw2 = new TTVisual.TTButton();
        this.ttbuttonWholeJaw2.Text = i18n("M10073", "1- Tüm Ağız");
        this.ttbuttonWholeJaw2.ForeColor = "#000000";
        this.ttbuttonWholeJaw2.Name = "ttbuttonWholeJaw2";
        this.ttbuttonWholeJaw2.TabIndex = 62;

        this.ttbuttonLowerJaw = new TTVisual.TTButton();
        this.ttbuttonLowerJaw.Text = i18n("M10263", "3- Alt Çene");
        this.ttbuttonLowerJaw.ForeColor = "#000000";
        this.ttbuttonLowerJaw.Name = "ttbuttonLowerJaw";
        this.ttbuttonLowerJaw.TabIndex = 61;

        this.ttbutton19 = new TTVisual.TTButton();
        this.ttbutton19.Text = i18n("M10376", "7- Sol Alt Çene");
        this.ttbutton19.ForeColor = "#000000";
        this.ttbutton19.Name = "ttbutton19";
        this.ttbutton19.TabIndex = 60;

        this.ttbuttonRightLowerJaw = new TTVisual.TTButton();
        this.ttbuttonRightLowerJaw.Text = i18n("M10356", "6- Sağ Alt Çene");
        this.ttbuttonRightLowerJaw.ForeColor = "#000000";
        this.ttbuttonRightLowerJaw.Name = "ttbuttonRightLowerJaw";
        this.ttbuttonRightLowerJaw.TabIndex = 59;

        this.ttbuttonLower = new TTVisual.TTButton();
        this.ttbuttonLower.Text = "ALT";
        this.ttbuttonLower.ForeColor = "#000000";
        this.ttbuttonLower.Name = "ttbuttonLower";
        this.ttbuttonLower.TabIndex = 58;

        this.ttbutton93 = new TTVisual.TTButton();
        this.ttbutton93.Text = "93";
        this.ttbutton93.ForeColor = "#FF0000";
        this.ttbutton93.Name = "ttbutton93";
        this.ttbutton93.TabIndex = 57;

        this.ttbuttonRL1 = new TTVisual.TTButton();
        this.ttbuttonRL1.Name = "ttbuttonRL1";
        this.ttbuttonRL1.TabIndex = 56;

        this.ttbutton84 = new TTVisual.TTButton();
        this.ttbutton84.Text = "84";
        this.ttbutton84.ForeColor = "#008000";
        this.ttbutton84.Name = "ttbutton84";
        this.ttbutton84.TabIndex = 55;

        this.ttbutton85 = new TTVisual.TTButton();
        this.ttbutton85.Text = "85";
        this.ttbutton85.ForeColor = "#008000";
        this.ttbutton85.Name = "ttbutton85";
        this.ttbutton85.TabIndex = 54;

        this.ttbuttonRL2 = new TTVisual.TTButton();
        this.ttbuttonRL2.Name = "ttbuttonRL2";
        this.ttbuttonRL2.TabIndex = 53;

        this.ttbutton83 = new TTVisual.TTButton();
        this.ttbutton83.Text = "83";
        this.ttbutton83.ForeColor = "#008000";
        this.ttbutton83.Name = "ttbutton83";
        this.ttbutton83.TabIndex = 52;

        this.ttbutton82 = new TTVisual.TTButton();
        this.ttbutton82.Text = "82";
        this.ttbutton82.ForeColor = "#008000";
        this.ttbutton82.Name = "ttbutton82";
        this.ttbutton82.TabIndex = 51;

        this.ttbutton81 = new TTVisual.TTButton();
        this.ttbutton81.Text = "81";
        this.ttbutton81.ForeColor = "#008000";
        this.ttbutton81.Name = "ttbutton81";
        this.ttbutton81.TabIndex = 50;

        this.ttbutton44 = new TTVisual.TTButton();
        this.ttbutton44.Text = "44";
        this.ttbutton44.ForeColor = "#3399FF";
        this.ttbutton44.Name = "ttbutton44";
        this.ttbutton44.TabIndex = 49;

        this.ttbutton41 = new TTVisual.TTButton();
        this.ttbutton41.Text = "41";
        this.ttbutton41.ForeColor = "#3399FF";
        this.ttbutton41.Name = "ttbutton41";
        this.ttbutton41.TabIndex = 48;

        this.ttbutton42 = new TTVisual.TTButton();
        this.ttbutton42.Text = "42";
        this.ttbutton42.ForeColor = "#3399FF";
        this.ttbutton42.Name = "ttbutton42";
        this.ttbutton42.TabIndex = 47;

        this.ttbutton43 = new TTVisual.TTButton();
        this.ttbutton43.Text = "43";
        this.ttbutton43.ForeColor = "#3399FF";
        this.ttbutton43.Name = "ttbutton43";
        this.ttbutton43.TabIndex = 46;

        this.ttbutton45 = new TTVisual.TTButton();
        this.ttbutton45.Text = "45";
        this.ttbutton45.ForeColor = "#3399FF";
        this.ttbutton45.Name = "ttbutton45";
        this.ttbutton45.TabIndex = 45;

        this.ttbutton46 = new TTVisual.TTButton();
        this.ttbutton46.Text = "46";
        this.ttbutton46.ForeColor = "#3399FF";
        this.ttbutton46.Name = "ttbutton46";
        this.ttbutton46.TabIndex = 44;

        this.ttbutton47 = new TTVisual.TTButton();
        this.ttbutton47.Text = "47";
        this.ttbutton47.ForeColor = "#3399FF";
        this.ttbutton47.Name = "ttbutton47";
        this.ttbutton47.TabIndex = 43;

        this.ttbutton48 = new TTVisual.TTButton();
        this.ttbutton48.Text = "48";
        this.ttbutton48.ForeColor = "#3399FF";
        this.ttbutton48.Name = "ttbutton48";
        this.ttbutton48.TabIndex = 42;

        this.ttbutton28 = new TTVisual.TTButton();
        this.ttbutton28.Text = "28";
        this.ttbutton28.ForeColor = "#3399FF";
        this.ttbutton28.Name = "ttbutton28";
        this.ttbutton28.TabIndex = 41;

        this.ttbutton27 = new TTVisual.TTButton();
        this.ttbutton27.Text = "27";
        this.ttbutton27.ForeColor = "#3399FF";
        this.ttbutton27.Name = "ttbutton27";
        this.ttbutton27.TabIndex = 40;

        this.ttbutton26 = new TTVisual.TTButton();
        this.ttbutton26.Text = "26";
        this.ttbutton26.ForeColor = "#3399FF";
        this.ttbutton26.Name = "ttbutton26";
        this.ttbutton26.TabIndex = 39;

        this.ttbutton25 = new TTVisual.TTButton();
        this.ttbutton25.Text = "25";
        this.ttbutton25.ForeColor = "#3399FF";
        this.ttbutton25.Name = "ttbutton25";
        this.ttbutton25.TabIndex = 38;

        this.ttbutton24 = new TTVisual.TTButton();
        this.ttbutton24.Text = "24";
        this.ttbutton24.ForeColor = "#3399FF";
        this.ttbutton24.Name = "ttbutton24";
        this.ttbutton24.TabIndex = 36;

        this.ttbutton23 = new TTVisual.TTButton();
        this.ttbutton23.Text = "23";
        this.ttbutton23.ForeColor = "#3399FF";
        this.ttbutton23.Name = "ttbutton23";
        this.ttbutton23.TabIndex = 35;

        this.ttbutton22 = new TTVisual.TTButton();
        this.ttbutton22.Text = "22";
        this.ttbutton22.ForeColor = "#3399FF";
        this.ttbutton22.Name = "ttbutton22";
        this.ttbutton22.TabIndex = 34;

        this.ttbutton21 = new TTVisual.TTButton();
        this.ttbutton21.Text = "21";
        this.ttbutton21.ForeColor = "#3399FF";
        this.ttbutton21.Name = "ttbutton21";
        this.ttbutton21.TabIndex = 33;

        this.ttbutton92 = new TTVisual.TTButton();
        this.ttbutton92.Text = "92";
        this.ttbutton92.ForeColor = "#FF0000";
        this.ttbutton92.Name = "ttbutton92";
        this.ttbutton92.TabIndex = 32;

        this.ttbuttonLU2 = new TTVisual.TTButton();
        this.ttbuttonLU2.Name = "ttbuttonLU2";
        this.ttbuttonLU2.TabIndex = 31;

        this.ttbuttonLU1 = new TTVisual.TTButton();
        this.ttbuttonLU1.Name = "ttbuttonLU1";
        this.ttbuttonLU1.TabIndex = 30;

        this.ttbutton65 = new TTVisual.TTButton();
        this.ttbutton65.Text = "65";
        this.ttbutton65.ForeColor = "#008000";
        this.ttbutton65.Name = "ttbutton65";
        this.ttbutton65.TabIndex = 29;

        this.ttbutton64 = new TTVisual.TTButton();
        this.ttbutton64.Text = "64";
        this.ttbutton64.ForeColor = "#008000";
        this.ttbutton64.Name = "ttbutton64";
        this.ttbutton64.TabIndex = 28;

        this.ttbutton63 = new TTVisual.TTButton();
        this.ttbutton63.Text = "63";
        this.ttbutton63.ForeColor = "#008000";
        this.ttbutton63.Name = "ttbutton63";
        this.ttbutton63.TabIndex = 27;

        this.ttbutton62 = new TTVisual.TTButton();
        this.ttbutton62.Text = "62";
        this.ttbutton62.ForeColor = "#008000";
        this.ttbutton62.Name = "ttbutton62";
        this.ttbutton62.TabIndex = 26;

        this.ttbutton61 = new TTVisual.TTButton();
        this.ttbutton61.Text = "61";
        this.ttbutton61.ForeColor = "#008000";
        this.ttbutton61.Name = "ttbutton61";
        this.ttbutton61.TabIndex = 25;

        this.ttbutton11 = new TTVisual.TTButton();
        this.ttbutton11.Text = "11";
        this.ttbutton11.ForeColor = "#3399FF";
        this.ttbutton11.Name = "ttbutton11";
        this.ttbutton11.TabIndex = 24;

        this.ttbutton12 = new TTVisual.TTButton();
        this.ttbutton12.Text = "12";
        this.ttbutton12.ForeColor = "#3399FF";
        this.ttbutton12.Name = "ttbutton12";
        this.ttbutton12.TabIndex = 23;

        this.ttbutton13 = new TTVisual.TTButton();
        this.ttbutton13.Text = "13";
        this.ttbutton13.ForeColor = "#3399FF";
        this.ttbutton13.Name = "ttbutton13";
        this.ttbutton13.TabIndex = 22;

        this.ttbutton14 = new TTVisual.TTButton();
        this.ttbutton14.Text = "14";
        this.ttbutton14.ForeColor = "#3399FF";
        this.ttbutton14.Name = "ttbutton14";
        this.ttbutton14.TabIndex = 21;

        this.ttbutton15 = new TTVisual.TTButton();
        this.ttbutton15.Text = "15";
        this.ttbutton15.ForeColor = "#3399FF";
        this.ttbutton15.Name = "ttbutton15";
        this.ttbutton15.TabIndex = 20;

        this.ttbutton16 = new TTVisual.TTButton();
        this.ttbutton16.Text = "16";
        this.ttbutton16.ForeColor = "#3399FF";
        this.ttbutton16.Name = "ttbutton16";
        this.ttbutton16.TabIndex = 19;

        this.ttbutton17 = new TTVisual.TTButton();
        this.ttbutton17.Text = "17";
        this.ttbutton17.ForeColor = "#3399FF";
        this.ttbutton17.Name = "ttbutton17";
        this.ttbutton17.TabIndex = 18;

        this.ttbutton18 = new TTVisual.TTButton();
        this.ttbutton18.Text = "18";
        this.ttbutton18.ForeColor = "#3399FF";
        this.ttbutton18.Name = "ttbutton18";
        this.ttbutton18.TabIndex = 17;

        this.ttbutton51 = new TTVisual.TTButton();
        this.ttbutton51.Text = "51";
        this.ttbutton51.ForeColor = "#008000";
        this.ttbutton51.Name = "ttbutton51";
        this.ttbutton51.TabIndex = 16;

        this.ttbutton52 = new TTVisual.TTButton();
        this.ttbutton52.Text = "52";
        this.ttbutton52.ForeColor = "#008000";
        this.ttbutton52.Name = "ttbutton52";
        this.ttbutton52.TabIndex = 15;

        this.ttbutton53 = new TTVisual.TTButton();
        this.ttbutton53.Text = "53";
        this.ttbutton53.ForeColor = "#008000";
        this.ttbutton53.Name = "ttbutton53";
        this.ttbutton53.TabIndex = 14;

        this.ttbutton54 = new TTVisual.TTButton();
        this.ttbutton54.Text = "54";
        this.ttbutton54.ForeColor = "#008000";
        this.ttbutton54.Name = "ttbutton54";
        this.ttbutton54.TabIndex = 13;

        this.ttbutton55 = new TTVisual.TTButton();
        this.ttbutton55.Text = "55";
        this.ttbutton55.ForeColor = "#008000";
        this.ttbutton55.Name = "ttbutton55";
        this.ttbutton55.TabIndex = 12;

        this.ttbuttonRU2 = new TTVisual.TTButton();
        this.ttbuttonRU2.Name = "ttbuttonRU2";
        this.ttbuttonRU2.TabIndex = 11;

        this.ttbuttonRU1 = new TTVisual.TTButton();
        this.ttbuttonRU1.Name = "ttbuttonRU1";
        this.ttbuttonRU1.TabIndex = 10;

        this.ttbutton91 = new TTVisual.TTButton();
        this.ttbutton91.Text = "91";
        this.ttbutton91.ForeColor = "#FF0000";
        this.ttbutton91.Name = "ttbutton91";
        this.ttbutton91.TabIndex = 9;

        this.ttbutton5 = new TTVisual.TTButton();
        this.ttbutton5.BackColor = "#000000";
        this.ttbutton5.Text = "ttbutton5";
        this.ttbutton5.Name = "ttbutton5";
        this.ttbutton5.TabIndex = 8;

        this.ttbutton4 = new TTVisual.TTButton();
        this.ttbutton4.BackColor = "#000000";
        this.ttbutton4.Text = "ttbutton4";
        this.ttbutton4.Name = "ttbutton4";
        this.ttbutton4.TabIndex = 7;

        this.ttbuttonRightUpperJaw = new TTVisual.TTButton();
        this.ttbuttonRightUpperJaw.Text = i18n("M10314", "4- Sağ Üst Çene");
        this.ttbuttonRightUpperJaw.ForeColor = "#000000";
        this.ttbuttonRightUpperJaw.Name = "ttbuttonRightUpperJaw";
        this.ttbuttonRightUpperJaw.TabIndex = 6;

        this.ttbuttonLeftUpperJaw = new TTVisual.TTButton();
        this.ttbuttonLeftUpperJaw.Text = i18n("M10344", "5- Sol Üst Çene");
        this.ttbuttonLeftUpperJaw.ForeColor = "#000000";
        this.ttbuttonLeftUpperJaw.Name = "ttbuttonLeftUpperJaw";
        this.ttbuttonLeftUpperJaw.TabIndex = 5;

        this.ttbuttonUpper = new TTVisual.TTButton();
        this.ttbuttonUpper.Text = "ÜST";
        this.ttbuttonUpper.ForeColor = "#000000";
        this.ttbuttonUpper.Name = "ttbuttonUpper";
        this.ttbuttonUpper.TabIndex = 4;

        this.ttbuttonUpperJaw = new TTVisual.TTButton();
        this.ttbuttonUpperJaw.Text = i18n("M10177", "2- Üst Çene");
        this.ttbuttonUpperJaw.ForeColor = "#000000";
        this.ttbuttonUpperJaw.Name = "ttbuttonUpperJaw";
        this.ttbuttonUpperJaw.TabIndex = 3;

        this.ttbuttonWholeJaw = new TTVisual.TTButton();
        this.ttbuttonWholeJaw.Text = i18n("M10073", "1- Tüm Ağız");
        this.ttbuttonWholeJaw.ForeColor = "#000000";
        this.ttbuttonWholeJaw.Name = "ttbuttonWholeJaw";
        this.ttbuttonWholeJaw.TabIndex = 2;

        this.ttbuttonLeft = new TTVisual.TTButton();
        this.ttbuttonLeft.Text = "SOL";
        this.ttbuttonLeft.ForeColor = "#000000";
        this.ttbuttonLeft.Name = "ttbuttonLeft";
        this.ttbuttonLeft.TabIndex = 1;

        this.ttbuttonRight = new TTVisual.TTButton();
        this.ttbuttonRight.Text = "SAĞ";
        this.ttbuttonRight.ForeColor = "#000000";
        this.ttbuttonRight.Name = "ttbuttonRight";
        this.ttbuttonRight.TabIndex = 0;

        this.labelDentalPosition = new TTVisual.TTLabel();
        this.labelDentalPosition.Text = i18n("M20461", "Pozisyon");
        this.labelDentalPosition.Name = "labelDentalPosition";
        this.labelDentalPosition.TabIndex = 4;

        this.DentalPosition = new TTVisual.TTEnumComboBox();
        this.DentalPosition.DataTypeName = "DentalPositionEnum";
        this.DentalPosition.Required = true;
        this.DentalPosition.BackColor = "#F0F0F0";
        this.DentalPosition.Enabled = false;
        this.DentalPosition.Name = "DentalPosition";
        this.DentalPosition.TabIndex = 3;

        this.labelToothNumber = new TTVisual.TTLabel();
        this.labelToothNumber.Text = i18n("M12915", "Diş No");
        this.labelToothNumber.Name = "labelToothNumber";
        this.labelToothNumber.TabIndex = 2;

        this.ToothNumber = new TTVisual.TTEnumComboBox();
        this.ToothNumber.DataTypeName = "ToothNumberEnum";
        this.ToothNumber.Required = true;
        this.ToothNumber.BackColor = "#F0F0F0";
        this.ToothNumber.Enabled = false;
        this.ToothNumber.Name = "ToothNumber";
        this.ToothNumber.TabIndex = 1;

        this.ttgroupboxToothSchema.Controls = [this.ttlabelAdultTooth, this.ttlabelMilkTooth, this.ttlabelAnamoliPositionNum, this.ttlabelMouthPositionNum, this.ttbutton6, this.ttbutton3, this.ttbutton2, this.ttbutton1, this.ttbutton94, this.ttbuttonLL1, this.ttbuttonLL2, this.ttbutton75, this.ttbutton74, this.ttbutton73, this.ttbutton72, this.ttbutton71, this.ttbutton37, this.ttbutton36, this.ttbutton35, this.ttbutton38, this.ttbutton34, this.ttbutton31, this.ttbutton32, this.ttbutton33, this.ttbuttonWholeJaw2, this.ttbuttonLowerJaw, this.ttbutton19, this.ttbuttonRightLowerJaw, this.ttbuttonLower, this.ttbutton93, this.ttbuttonRL1, this.ttbutton84, this.ttbutton85, this.ttbuttonRL2, this.ttbutton83, this.ttbutton82, this.ttbutton81, this.ttbutton44, this.ttbutton41, this.ttbutton42, this.ttbutton43, this.ttbutton45, this.ttbutton46, this.ttbutton47, this.ttbutton48, this.ttbutton28, this.ttbutton27, this.ttbutton26, this.ttbutton25, this.ttbutton24, this.ttbutton23, this.ttbutton22, this.ttbutton21, this.ttbutton92, this.ttbuttonLU2, this.ttbuttonLU1, this.ttbutton65, this.ttbutton64, this.ttbutton63, this.ttbutton62, this.ttbutton61, this.ttbutton11, this.ttbutton12, this.ttbutton13, this.ttbutton14, this.ttbutton15, this.ttbutton16, this.ttbutton17, this.ttbutton18, this.ttbutton51, this.ttbutton52, this.ttbutton53, this.ttbutton54, this.ttbutton55, this.ttbuttonRU2, this.ttbuttonRU1, this.ttbutton91, this.ttbutton5, this.ttbutton4, this.ttbuttonRightUpperJaw, this.ttbuttonLeftUpperJaw, this.ttbuttonUpper, this.ttbuttonUpperJaw, this.ttbuttonWholeJaw, this.ttbuttonLeft, this.ttbuttonRight];
        this.Controls = [this.Anomali, this.ttgroupboxToothSchema, this.ttlabelAdultTooth, this.ttlabelMilkTooth, this.ttlabelAnamoliPositionNum, this.ttlabelMouthPositionNum, this.ttbutton6, this.ttbutton3, this.ttbutton2, this.ttbutton1, this.ttbutton94, this.ttbuttonLL1, this.ttbuttonLL2, this.ttbutton75, this.ttbutton74, this.ttbutton73, this.ttbutton72, this.ttbutton71, this.ttbutton37, this.ttbutton36, this.ttbutton35, this.ttbutton38, this.ttbutton34, this.ttbutton31, this.ttbutton32, this.ttbutton33, this.ttbuttonWholeJaw2, this.ttbuttonLowerJaw, this.ttbutton19, this.ttbuttonRightLowerJaw, this.ttbuttonLower, this.ttbutton93, this.ttbuttonRL1, this.ttbutton84, this.ttbutton85, this.ttbuttonRL2, this.ttbutton83, this.ttbutton82, this.ttbutton81, this.ttbutton44, this.ttbutton41, this.ttbutton42, this.ttbutton43, this.ttbutton45, this.ttbutton46, this.ttbutton47, this.ttbutton48, this.ttbutton28, this.ttbutton27, this.ttbutton26, this.ttbutton25, this.ttbutton24, this.ttbutton23, this.ttbutton22, this.ttbutton21, this.ttbutton92, this.ttbuttonLU2, this.ttbuttonLU1, this.ttbutton65, this.ttbutton64, this.ttbutton63, this.ttbutton62, this.ttbutton61, this.ttbutton11, this.ttbutton12, this.ttbutton13, this.ttbutton14, this.ttbutton15, this.ttbutton16, this.ttbutton17, this.ttbutton18, this.ttbutton51, this.ttbutton52, this.ttbutton53, this.ttbutton54, this.ttbutton55, this.ttbuttonRU2, this.ttbuttonRU1, this.ttbutton91, this.ttbutton5, this.ttbutton4, this.ttbuttonRightUpperJaw, this.ttbuttonLeftUpperJaw, this.ttbuttonUpper, this.ttbuttonUpperJaw, this.ttbuttonWholeJaw, this.ttbuttonLeft, this.ttbuttonRight, this.labelDentalPosition, this.DentalPosition, this.labelToothNumber, this.ToothNumber];

    }


}
