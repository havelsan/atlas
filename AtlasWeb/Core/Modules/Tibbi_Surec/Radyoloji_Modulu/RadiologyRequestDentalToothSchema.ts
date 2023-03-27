//$92EA8089
import { Component, OnInit, NgZone } from '@angular/core';
import { RadiologyRequestDentalToothSchemaViewModel } from "./RadiologyRequestDentalToothSchemaViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { ToothNumberEnum } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";




@Component({
    selector: 'RadiologyRequestDentalToothSchema',
    templateUrl: './RadiologyRequestDentalToothSchema.html',
    providers: [MessageService]
})
export class RadiologyRequestDentalToothSchema extends TTVisual.TTForm implements OnInit {
    ch1: TTVisual.ITTCheckBox;
    ch11: TTVisual.ITTCheckBox;
    ch12: TTVisual.ITTCheckBox;
    ch13: TTVisual.ITTCheckBox;
    ch14: TTVisual.ITTCheckBox;
    ch15: TTVisual.ITTCheckBox;
    ch16: TTVisual.ITTCheckBox;
    ch17: TTVisual.ITTCheckBox;
    ch18: TTVisual.ITTCheckBox;
    ch2: TTVisual.ITTCheckBox;
    ch21: TTVisual.ITTCheckBox;
    ch22: TTVisual.ITTCheckBox;
    ch23: TTVisual.ITTCheckBox;
    ch24: TTVisual.ITTCheckBox;
    ch25: TTVisual.ITTCheckBox;
    ch26: TTVisual.ITTCheckBox;
    ch27: TTVisual.ITTCheckBox;
    ch28: TTVisual.ITTCheckBox;
    ch3: TTVisual.ITTCheckBox;
    ch31: TTVisual.ITTCheckBox;
    ch32: TTVisual.ITTCheckBox;
    ch33: TTVisual.ITTCheckBox;
    ch34: TTVisual.ITTCheckBox;
    ch35: TTVisual.ITTCheckBox;
    ch36: TTVisual.ITTCheckBox;
    ch37: TTVisual.ITTCheckBox;
    ch38: TTVisual.ITTCheckBox;
    ch4: TTVisual.ITTCheckBox;
    ch41: TTVisual.ITTCheckBox;
    ch42: TTVisual.ITTCheckBox;
    ch43: TTVisual.ITTCheckBox;
    ch44: TTVisual.ITTCheckBox;
    ch45: TTVisual.ITTCheckBox;
    ch46: TTVisual.ITTCheckBox;
    ch47: TTVisual.ITTCheckBox;
    ch48: TTVisual.ITTCheckBox;
    ch5: TTVisual.ITTCheckBox;
    ch51: TTVisual.ITTCheckBox;
    ch52: TTVisual.ITTCheckBox;
    ch53: TTVisual.ITTCheckBox;
    ch54: TTVisual.ITTCheckBox;
    ch55: TTVisual.ITTCheckBox;
    ch6: TTVisual.ITTCheckBox;
    ch61: TTVisual.ITTCheckBox;
    ch62: TTVisual.ITTCheckBox;
    ch63: TTVisual.ITTCheckBox;
    ch64: TTVisual.ITTCheckBox;
    ch65: TTVisual.ITTCheckBox;
    ch7: TTVisual.ITTCheckBox;
    ch71: TTVisual.ITTCheckBox;
    ch72: TTVisual.ITTCheckBox;
    ch73: TTVisual.ITTCheckBox;
    ch74: TTVisual.ITTCheckBox;
    ch75: TTVisual.ITTCheckBox;
    ch81: TTVisual.ITTCheckBox;
    ch82: TTVisual.ITTCheckBox;
    ch83: TTVisual.ITTCheckBox;
    ch84: TTVisual.ITTCheckBox;
    ch85: TTVisual.ITTCheckBox;
    panelTooth: TTVisual.ITTPanel;
    public ToothNumbersList: Array<ToothNumberEnum> = new Array<ToothNumberEnum>();
    ttbutton1: TTVisual.ITTButton;
    ttbutton2: TTVisual.ITTButton;
    public radiologyRequestDentalToothSchemaViewModel: RadiologyRequestDentalToothSchemaViewModel = new RadiologyRequestDentalToothSchemaViewModel();
    public get _Radiology(): Radiology {
        return this._TTObject as Radiology;
    }
    private RadiologyRequestDentalToothSchema_DocumentUrl: string = '/api/RadiologyService/RadiologyRequestDentalToothSchema';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super("RADIOLOGY", "RadiologyRequestDentalToothSchema");
        this._DocumentServiceUrl = this.RadiologyRequestDentalToothSchema_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    /*
    private async addToothNumberList(controls: Control.ControlCollection): Promise<void> {
        //ToothNumbersList = new List<ToothNumberEnum>();
        for (let currControl of controls) {
            if (currControl.GetType().Equals(typeof TTCheckBox) && currControl.Name.StartsWith("ch") && (<TTCheckBox>currControl).Checked) {
                let currChkbox: TTCheckBox = <TTCheckBox>currControl;
                let enumValueDef: TTDataDictionary.EnumValueDef = (await CommonService.GetEnumValueDefOfEnumValueV2("ToothNumberEnum", number.Parse(currChkbox.Name.substring(2, currChkbox.Name.Length - 2))));
                if (enumValueDef !== null)
                    this.ToothNumbersList.push(<ToothNumberEnum>enumValueDef.EnumValue);
            }
            if (currControl.HasChildren) {
                this.addToothNumberList(currControl.Controls);
            }
        }
    }
    */
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        await super.PostScript(transDef);
        //cancel a basılmış mı kontrolü yapılacak.
       //this.addToothNumberList(this.Controls);
    }
    protected async PreScript() {
        await super.PreScript();
        //this.cmdCancel.Visible = false;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Radiology();
        this.radiologyRequestDentalToothSchemaViewModel = new RadiologyRequestDentalToothSchemaViewModel();
        this._ViewModel = this.radiologyRequestDentalToothSchemaViewModel;
        this.radiologyRequestDentalToothSchemaViewModel._Radiology = this._TTObject as Radiology;
    }

    protected loadViewModel() {
        let that = this;
        that.radiologyRequestDentalToothSchemaViewModel = this._ViewModel as RadiologyRequestDentalToothSchemaViewModel;
        that._TTObject = this.radiologyRequestDentalToothSchemaViewModel._Radiology;
        if (this.radiologyRequestDentalToothSchemaViewModel == null)
            this.radiologyRequestDentalToothSchemaViewModel = new RadiologyRequestDentalToothSchemaViewModel();
        if (this.radiologyRequestDentalToothSchemaViewModel._Radiology == null)
            this.radiologyRequestDentalToothSchemaViewModel._Radiology = new Radiology();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(RadiologyRequestDentalToothSchemaViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.panelTooth = new TTVisual.TTPanel();
        this.panelTooth.AutoSize = true;
        this.panelTooth.Text = "18";
        this.panelTooth.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.panelTooth.Name = "panelTooth";
        this.panelTooth.TabIndex = 4;

        this.ttbutton2 = new TTVisual.TTButton();
        this.ttbutton2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttbutton2.Name = "ttbutton2";
        this.ttbutton2.TabIndex = 19;

        this.ttbutton1 = new TTVisual.TTButton();
        this.ttbutton1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttbutton1.Name = "ttbutton1";
        this.ttbutton1.TabIndex = 18;

        this.ch18 = new TTVisual.TTCheckBox();
        this.ch18.Value = false;
        this.ch18.Text = "18";
        this.ch18.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch18.Name = "ch18";
        this.ch18.TabIndex = 17;

        this.ch17 = new TTVisual.TTCheckBox();
        this.ch17.Value = false;
        this.ch17.Text = "17";
        this.ch17.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch17.Name = "ch17";
        this.ch17.TabIndex = 17;

        this.ch16 = new TTVisual.TTCheckBox();
        this.ch16.Value = false;
        this.ch16.Text = "16";
        this.ch16.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch16.Name = "ch16";
        this.ch16.TabIndex = 17;

        this.ch15 = new TTVisual.TTCheckBox();
        this.ch15.Value = false;
        this.ch15.Text = "15";
        this.ch15.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch15.Name = "ch15";
        this.ch15.TabIndex = 17;

        this.ch14 = new TTVisual.TTCheckBox();
        this.ch14.Value = false;
        this.ch14.Text = "14";
        this.ch14.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch14.Name = "ch14";
        this.ch14.TabIndex = 17;

        this.ch13 = new TTVisual.TTCheckBox();
        this.ch13.Value = false;
        this.ch13.Text = "13";
        this.ch13.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch13.Name = "ch13";
        this.ch13.TabIndex = 17;

        this.ch12 = new TTVisual.TTCheckBox();
        this.ch12.Value = false;
        this.ch12.Text = "12";
        this.ch12.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch12.Name = "ch12";
        this.ch12.TabIndex = 17;

        this.ch31 = new TTVisual.TTCheckBox();
        this.ch31.Value = false;
        this.ch31.Text = "31";
        this.ch31.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch31.Name = "ch31";
        this.ch31.TabIndex = 17;

        this.ch32 = new TTVisual.TTCheckBox();
        this.ch32.Value = false;
        this.ch32.Text = "32";
        this.ch32.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch32.Name = "ch32";
        this.ch32.TabIndex = 17;

        this.ch75 = new TTVisual.TTCheckBox();
        this.ch75.Value = false;
        this.ch75.Text = "75";
        this.ch75.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch75.Name = "ch75";
        this.ch75.TabIndex = 17;

        this.ch33 = new TTVisual.TTCheckBox();
        this.ch33.Value = false;
        this.ch33.Text = "33";
        this.ch33.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch33.Name = "ch33";
        this.ch33.TabIndex = 17;

        this.ch74 = new TTVisual.TTCheckBox();
        this.ch74.Value = false;
        this.ch74.Text = "74";
        this.ch74.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch74.Name = "ch74";
        this.ch74.TabIndex = 17;

        this.ch34 = new TTVisual.TTCheckBox();
        this.ch34.Value = false;
        this.ch34.Text = "34";
        this.ch34.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch34.Name = "ch34";
        this.ch34.TabIndex = 17;

        this.ch81 = new TTVisual.TTCheckBox();
        this.ch81.Value = false;
        this.ch81.Text = "81";
        this.ch81.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch81.Name = "ch81";
        this.ch81.TabIndex = 17;

        this.ch35 = new TTVisual.TTCheckBox();
        this.ch35.Value = false;
        this.ch35.Text = "35";
        this.ch35.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch35.Name = "ch35";
        this.ch35.TabIndex = 17;

        this.ch73 = new TTVisual.TTCheckBox();
        this.ch73.Value = false;
        this.ch73.Text = "73";
        this.ch73.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch73.Name = "ch73";
        this.ch73.TabIndex = 17;

        this.ch36 = new TTVisual.TTCheckBox();
        this.ch36.Value = false;
        this.ch36.Text = "36";
        this.ch36.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch36.Name = "ch36";
        this.ch36.TabIndex = 17;

        this.ch82 = new TTVisual.TTCheckBox();
        this.ch82.Value = false;
        this.ch82.Text = "82";
        this.ch82.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch82.Name = "ch82";
        this.ch82.TabIndex = 17;

        this.ch37 = new TTVisual.TTCheckBox();
        this.ch37.Value = false;
        this.ch37.Text = "37";
        this.ch37.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch37.Name = "ch37";
        this.ch37.TabIndex = 17;

        this.ch72 = new TTVisual.TTCheckBox();
        this.ch72.Value = false;
        this.ch72.Text = "72";
        this.ch72.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch72.Name = "ch72";
        this.ch72.TabIndex = 17;

        this.ch38 = new TTVisual.TTCheckBox();
        this.ch38.Value = false;
        this.ch38.Text = "38";
        this.ch38.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch38.Name = "ch38";
        this.ch38.TabIndex = 17;

        this.ch48 = new TTVisual.TTCheckBox();
        this.ch48.Value = false;
        this.ch48.Text = "48";
        this.ch48.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch48.Name = "ch48";
        this.ch48.TabIndex = 17;

        this.ch71 = new TTVisual.TTCheckBox();
        this.ch71.Value = false;
        this.ch71.Text = "71";
        this.ch71.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch71.Name = "ch71";
        this.ch71.TabIndex = 17;

        this.ch83 = new TTVisual.TTCheckBox();
        this.ch83.Value = false;
        this.ch83.Text = "83";
        this.ch83.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch83.Name = "ch83";
        this.ch83.TabIndex = 17;

        this.ch65 = new TTVisual.TTCheckBox();
        this.ch65.Value = false;
        this.ch65.Text = "65";
        this.ch65.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch65.Name = "ch65";
        this.ch65.TabIndex = 17;

        this.ch84 = new TTVisual.TTCheckBox();
        this.ch84.Value = false;
        this.ch84.Text = "84";
        this.ch84.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch84.Name = "ch84";
        this.ch84.TabIndex = 17;

        this.ch47 = new TTVisual.TTCheckBox();
        this.ch47.Value = false;
        this.ch47.Text = "47";
        this.ch47.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch47.Name = "ch47";
        this.ch47.TabIndex = 17;

        this.ch85 = new TTVisual.TTCheckBox();
        this.ch85.Value = false;
        this.ch85.Text = "85";
        this.ch85.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch85.Name = "ch85";
        this.ch85.TabIndex = 17;

        this.ch64 = new TTVisual.TTCheckBox();
        this.ch64.Value = false;
        this.ch64.Text = "64";
        this.ch64.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch64.Name = "ch64";
        this.ch64.TabIndex = 17;

        this.ch46 = new TTVisual.TTCheckBox();
        this.ch46.Value = false;
        this.ch46.Text = "46";
        this.ch46.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch46.Name = "ch46";
        this.ch46.TabIndex = 17;

        this.ch45 = new TTVisual.TTCheckBox();
        this.ch45.Value = false;
        this.ch45.Text = "45";
        this.ch45.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch45.Name = "ch45";
        this.ch45.TabIndex = 17;

        this.ch63 = new TTVisual.TTCheckBox();
        this.ch63.Value = false;
        this.ch63.Text = "63";
        this.ch63.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch63.Name = "ch63";
        this.ch63.TabIndex = 17;

        this.ch44 = new TTVisual.TTCheckBox();
        this.ch44.Value = false;
        this.ch44.Text = "44";
        this.ch44.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch44.Name = "ch44";
        this.ch44.TabIndex = 17;

        this.ch62 = new TTVisual.TTCheckBox();
        this.ch62.Value = false;
        this.ch62.Text = "62";
        this.ch62.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch62.Name = "ch62";
        this.ch62.TabIndex = 17;

        this.ch43 = new TTVisual.TTCheckBox();
        this.ch43.Value = false;
        this.ch43.Text = "43";
        this.ch43.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch43.Name = "ch43";
        this.ch43.TabIndex = 17;

        this.ch61 = new TTVisual.TTCheckBox();
        this.ch61.Value = false;
        this.ch61.Text = "61";
        this.ch61.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch61.Name = "ch61";
        this.ch61.TabIndex = 17;

        this.ch42 = new TTVisual.TTCheckBox();
        this.ch42.Value = false;
        this.ch42.Text = "42";
        this.ch42.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch42.Name = "ch42";
        this.ch42.TabIndex = 17;

        this.ch51 = new TTVisual.TTCheckBox();
        this.ch51.Value = false;
        this.ch51.Text = "51";
        this.ch51.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch51.Name = "ch51";
        this.ch51.TabIndex = 17;

        this.ch41 = new TTVisual.TTCheckBox();
        this.ch41.Value = false;
        this.ch41.Text = "41";
        this.ch41.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch41.Name = "ch41";
        this.ch41.TabIndex = 17;

        this.ch52 = new TTVisual.TTCheckBox();
        this.ch52.Value = false;
        this.ch52.Text = "52";
        this.ch52.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch52.Name = "ch52";
        this.ch52.TabIndex = 17;

        this.ch53 = new TTVisual.TTCheckBox();
        this.ch53.Value = false;
        this.ch53.Text = "53";
        this.ch53.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch53.Name = "ch53";
        this.ch53.TabIndex = 17;

        this.ch54 = new TTVisual.TTCheckBox();
        this.ch54.Value = false;
        this.ch54.Text = "54";
        this.ch54.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch54.Name = "ch54";
        this.ch54.TabIndex = 17;

        this.ch55 = new TTVisual.TTCheckBox();
        this.ch55.Value = false;
        this.ch55.Text = "55";
        this.ch55.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch55.Name = "ch55";
        this.ch55.TabIndex = 17;

        this.ch28 = new TTVisual.TTCheckBox();
        this.ch28.Value = false;
        this.ch28.Text = "28";
        this.ch28.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch28.Name = "ch28";
        this.ch28.TabIndex = 17;

        this.ch11 = new TTVisual.TTCheckBox();
        this.ch11.Value = false;
        this.ch11.Text = "11";
        this.ch11.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch11.Name = "ch11";
        this.ch11.TabIndex = 17;

        this.ch21 = new TTVisual.TTCheckBox();
        this.ch21.Value = false;
        this.ch21.Text = "21";
        this.ch21.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch21.Name = "ch21";
        this.ch21.TabIndex = 17;

        this.ch27 = new TTVisual.TTCheckBox();
        this.ch27.Value = false;
        this.ch27.Text = "27";
        this.ch27.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch27.Name = "ch27";
        this.ch27.TabIndex = 17;

        this.ch26 = new TTVisual.TTCheckBox();
        this.ch26.Value = false;
        this.ch26.Text = "26";
        this.ch26.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch26.Name = "ch26";
        this.ch26.TabIndex = 17;

        this.ch25 = new TTVisual.TTCheckBox();
        this.ch25.Value = false;
        this.ch25.Text = "25";
        this.ch25.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch25.Name = "ch25";
        this.ch25.TabIndex = 17;

        this.ch24 = new TTVisual.TTCheckBox();
        this.ch24.Value = false;
        this.ch24.Text = "24";
        this.ch24.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch24.Name = "ch24";
        this.ch24.TabIndex = 17;

        this.ch23 = new TTVisual.TTCheckBox();
        this.ch23.Value = false;
        this.ch23.Text = "23";
        this.ch23.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch23.Name = "ch23";
        this.ch23.TabIndex = 17;

        this.ch22 = new TTVisual.TTCheckBox();
        this.ch22.Value = false;
        this.ch22.Text = "22";
        this.ch22.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch22.Name = "ch22";
        this.ch22.TabIndex = 17;

        this.ch3 = new TTVisual.TTCheckBox();
        this.ch3.Value = false;
        this.ch3.Text = i18n("M10740", "Alt Çene");
        this.ch3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch3.Name = "ch3";
        this.ch3.TabIndex = 24;

        this.ch4 = new TTVisual.TTCheckBox();
        this.ch4.Value = false;
        this.ch4.Text = i18n("M21152", "Sağ Üst Çene");
        this.ch4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch4.Name = "ch4";
        this.ch4.TabIndex = 20;

        this.ch6 = new TTVisual.TTCheckBox();
        this.ch6.Value = false;
        this.ch6.Text = i18n("M21126", "Sağ Alt Çene");
        this.ch6.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch6.Name = "ch6";
        this.ch6.TabIndex = 21;

        this.ch5 = new TTVisual.TTCheckBox();
        this.ch5.Value = false;
        this.ch5.Text = i18n("M22021", "Sol Üst Çene");
        this.ch5.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch5.Name = "ch5";
        this.ch5.TabIndex = 22;

        this.ch7 = new TTVisual.TTCheckBox();
        this.ch7.Value = false;
        this.ch7.Text = i18n("M22002", "Sol Alt Çene");
        this.ch7.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch7.Name = "ch7";
        this.ch7.TabIndex = 23;

        this.ch2 = new TTVisual.TTCheckBox();
        this.ch2.Value = false;
        this.ch2.Text = i18n("M23981", "Üst Çene");
        this.ch2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch2.Name = "ch2";
        this.ch2.TabIndex = 25;

        this.ch1 = new TTVisual.TTCheckBox();
        this.ch1.Value = false;
        this.ch1.Text = i18n("M23631", "Tüm Ağız");
        this.ch1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ch1.Name = "ch1";
        this.ch1.TabIndex = 26;

        this.panelTooth.Controls = [this.ttbutton2, this.ttbutton1, this.ch18, this.ch17, this.ch16, this.ch15, this.ch14, this.ch13, this.ch12, this.ch31, this.ch32, this.ch75, this.ch33, this.ch74, this.ch34, this.ch81, this.ch35, this.ch73, this.ch36, this.ch82, this.ch37, this.ch72, this.ch38, this.ch48, this.ch71, this.ch83, this.ch65, this.ch84, this.ch47, this.ch85, this.ch64, this.ch46, this.ch45, this.ch63, this.ch44, this.ch62, this.ch43, this.ch61, this.ch42, this.ch51, this.ch41, this.ch52, this.ch53, this.ch54, this.ch55, this.ch28, this.ch11, this.ch21, this.ch27, this.ch26, this.ch25, this.ch24, this.ch23, this.ch22, this.ch3, this.ch4, this.ch6, this.ch5, this.ch7, this.ch2, this.ch1];
        this.Controls = [this.panelTooth, this.ttbutton2, this.ttbutton1, this.ch18, this.ch17, this.ch16, this.ch15, this.ch14, this.ch13, this.ch12, this.ch31, this.ch32, this.ch75, this.ch33, this.ch74, this.ch34, this.ch81, this.ch35, this.ch73, this.ch36, this.ch82, this.ch37, this.ch72, this.ch38, this.ch48, this.ch71, this.ch83, this.ch65, this.ch84, this.ch47, this.ch85, this.ch64, this.ch46, this.ch45, this.ch63, this.ch44, this.ch62, this.ch43, this.ch61, this.ch42, this.ch51, this.ch41, this.ch52, this.ch53, this.ch54, this.ch55, this.ch28, this.ch11, this.ch21, this.ch27, this.ch26, this.ch25, this.ch24, this.ch23, this.ch22, this.ch3, this.ch4, this.ch6, this.ch5, this.ch7, this.ch2, this.ch1];

    }


}
