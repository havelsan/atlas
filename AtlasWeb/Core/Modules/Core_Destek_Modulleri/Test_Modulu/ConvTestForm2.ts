//$B6415077
import { Component, OnInit, NgZone } from '@angular/core';
import { ConvTestForm2ViewModel } from './ConvTestForm2ViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { ConvTest } from 'NebulaClient/Model/AtlasClientModel';
import { ConvTestService } from "ObjectClassService/ConvTestService";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';

import { City } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'ConvTestForm2',
    templateUrl: './ConvTestForm2.html',
    providers: [MessageService]
})
export class ConvTestForm2 extends TTVisual.TTForm implements OnInit {
    cekbaks: TTVisual.ITTCheckBox;
    City: TTVisual.ITTObjectListBox;
    deyt: TTVisual.ITTDateTimePicker;
    labelCity: TTVisual.ITTLabel;
    labelNo: TTVisual.ITTLabel;
    labelTelephone: TTVisual.ITTLabel;
    No: TTVisual.ITTTextBox;
    Telephone: TTVisual.ITTTextBox;
    ttbutton1: TTVisual.ITTButton;
    public convTestForm2ViewModel: ConvTestForm2ViewModel = new ConvTestForm2ViewModel();
    public get _ConvTest(): ConvTest {
        return this._TTObject as ConvTest;
    }
    private ConvTestForm2_DocumentUrl: string = '/api/ConvTestService/ConvTestForm2';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('CONVTEST', 'ConvTestForm2');
        this._DocumentServiceUrl = this.ConvTestForm2_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async No_TextChanged(): Promise<void> {
        this.ttbutton1.Text += ".";
    }
    public async ttbutton1_Click(): Promise<void> {
        this.Telephone.Text += "1";
        if ((this._ConvTest.No !== undefined))
            this.No.Text = (await ConvTestService.NoyuBirArttir(Convert.ToInt32(this.No.Text))).toString();
        this._ConvTest.Telephone += "2";
        if ((this._ConvTest.No !== undefined))
            this._ConvTest.No += (await ConvTestService.NoyuBirArttir(this._ConvTest.No.Value));
        this.cekbaks.Value = true;
        this.deyt.Text = "01.01.2000";
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
        if (transDef != null && transDef.ToStateDefID === ConvTest.ConvTestStates.Approove) {
            this._ConvTest.Description = i18n("M19708", "Onaylar mısınız?");
        }
    }
    protected async PreScript() {
        super.PreScript();
        this._ConvTest.No = 99;
        this.Telephone.Text += "(555)";
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ConvTest();
        this.convTestForm2ViewModel = new ConvTestForm2ViewModel();
        this._ViewModel = this.convTestForm2ViewModel;
        this.convTestForm2ViewModel._ConvTest = this._TTObject as ConvTest;
        this.convTestForm2ViewModel._ConvTest.City = new City();
    }

    protected loadViewModel() {
        let that = this;
        that.convTestForm2ViewModel = this._ViewModel as ConvTestForm2ViewModel;
        if (that.convTestForm2ViewModel.ReadOnly)
        {
            ServiceLocator.MessageService.showError("Bu form readonly :)");
            return;
        }
        that._TTObject = this.convTestForm2ViewModel._ConvTest;
        if (this.convTestForm2ViewModel == null)
            this.convTestForm2ViewModel = new ConvTestForm2ViewModel();
        if (this.convTestForm2ViewModel._ConvTest == null)
            this.convTestForm2ViewModel._ConvTest = new ConvTest();
        let cityObjectID = that.convTestForm2ViewModel._ConvTest["City"];
        if (cityObjectID != null && (typeof cityObjectID === 'string')) {
            let city = that.convTestForm2ViewModel.Citys.find(o => o.ObjectID.toString() === cityObjectID.toString());
             if (city) {
                that.convTestForm2ViewModel._ConvTest.City = city;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(ConvTestForm2ViewModel);
  
    }


    public onCityChanged(event): void {
        if (event != null) {
            if (this._ConvTest != null && this._ConvTest.City != event) {
                this._ConvTest.City = event;
            }
        }
    }

    public onNoChanged(event): void {
        if (event != null) {
            if (this._ConvTest != null && this._ConvTest.No != event) {
                this._ConvTest.No = event;
            }
        }
        this.No_TextChanged();
    }

    public onTelephoneChanged(event): void {
        if (event != null) {
            if (this._ConvTest != null && this._ConvTest.Telephone != event) {
                this._ConvTest.Telephone = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.No, "Text", this.__ttObject, "No");
        redirectProperty(this.Telephone, "Text", this.__ttObject, "Telephone");
    }

    public initFormControls(): void {
        this.Telephone = new TTVisual.TTTextBox();
        this.Telephone.Required = true;
        this.Telephone.BackColor = "#FFE3C6";
        this.Telephone.Name = "Telephone";
        this.Telephone.TabIndex = 2;

        this.No = new TTVisual.TTTextBox();
        this.No.Name = "No";
        this.No.TabIndex = 0;

        this.deyt = new TTVisual.TTDateTimePicker();
        this.deyt.Format = DateTimePickerFormat.Long;
        this.deyt.Name = "deyt";
        this.deyt.TabIndex = 8;

        this.cekbaks = new TTVisual.TTCheckBox();
        this.cekbaks.Value = false;
        this.cekbaks.Text = i18n("M12351", "çekbaks");
        this.cekbaks.Name = "cekbaks";
        this.cekbaks.TabIndex = 7;

        this.ttbutton1 = new TTVisual.TTButton();
        this.ttbutton1.Text = i18n("M12593", "Deneme");
        this.ttbutton1.Name = "ttbutton1";
        this.ttbutton1.TabIndex = 6;

        this.labelCity = new TTVisual.TTLabel();
        this.labelCity.Text = i18n("M22467", "Şehir");
        this.labelCity.Name = "labelCity";
        this.labelCity.TabIndex = 5;

        this.City = new TTVisual.TTObjectListBox();
        this.City.ListDefName = "CityListDefinition";
        this.City.Name = "City";
        this.City.TabIndex = 4;

        this.labelTelephone = new TTVisual.TTLabel();
        this.labelTelephone.Text = "Telefon";
        this.labelTelephone.Name = "labelTelephone";
        this.labelTelephone.TabIndex = 3;

        this.labelNo = new TTVisual.TTLabel();
        this.labelNo.Text = "No";
        this.labelNo.Name = "labelNo";
        this.labelNo.TabIndex = 1;

        this.Controls = [this.Telephone, this.No, this.deyt, this.cekbaks, this.ttbutton1, this.labelCity, this.City, this.labelTelephone, this.labelNo];

    }


}
