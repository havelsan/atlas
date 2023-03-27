//$2EA0CEC1
import { Component, OnInit, NgZone } from '@angular/core';
import { KronikHastaliklarFormViewModel } from './KronikHastaliklarFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { KronikHastaliklarVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSpirometri } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: 'KronikHastaliklarForm',
    templateUrl: './KronikHastaliklarForm.html',
    providers: [MessageService]
})
export class KronikHastaliklarForm extends TTVisual.TTForm implements OnInit {
    IlkTaniTarihi: TTVisual.ITTDateTimePicker;
    labelIlkTaniTarihi: TTVisual.ITTLabel;
    labelSKRSSpirometri: TTVisual.ITTLabel;
    SKRSSpirometri: TTVisual.ITTObjectListBox;
    RouteData: any;
    RouteData2: any;
    public kronikHastaliklarFormViewModel: KronikHastaliklarFormViewModel = new KronikHastaliklarFormViewModel();
    public get _KronikHastaliklarVeriSeti(): KronikHastaliklarVeriSeti {
        return this._TTObject as KronikHastaliklarVeriSeti;
    }
    private KronikHastaliklarForm_DocumentUrl: string = '/api/KronikHastaliklarVeriSetiService/KronikHastaliklarForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('KRONIKHASTALIKLARVERISETI', 'KronikHastaliklarForm');
        this._DocumentServiceUrl = this.KronikHastaliklarForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new KronikHastaliklarVeriSeti();
        this.kronikHastaliklarFormViewModel = new KronikHastaliklarFormViewModel();
        this._ViewModel = this.kronikHastaliklarFormViewModel;
        this.kronikHastaliklarFormViewModel._KronikHastaliklarVeriSeti = this._TTObject as KronikHastaliklarVeriSeti;
        this.kronikHastaliklarFormViewModel._KronikHastaliklarVeriSeti.SKRSSpirometri = new SKRSSpirometri();
    }

    protected loadViewModel() {
        let that = this;

        that.kronikHastaliklarFormViewModel = this._ViewModel as KronikHastaliklarFormViewModel;
        that._TTObject = this.kronikHastaliklarFormViewModel._KronikHastaliklarVeriSeti;
        if (this.kronikHastaliklarFormViewModel == null)
            this.kronikHastaliklarFormViewModel = new KronikHastaliklarFormViewModel();
        if (this.kronikHastaliklarFormViewModel._KronikHastaliklarVeriSeti == null)
            this.kronikHastaliklarFormViewModel._KronikHastaliklarVeriSeti = new KronikHastaliklarVeriSeti();
        let sKRSSpirometriObjectID = that.kronikHastaliklarFormViewModel._KronikHastaliklarVeriSeti["SKRSSpirometri"];
        if (sKRSSpirometriObjectID != null && (typeof sKRSSpirometriObjectID === "string")) {
            let sKRSSpirometri = that.kronikHastaliklarFormViewModel.SKRSSpirometris.find(o => o.ObjectID.toString() === sKRSSpirometriObjectID.toString());
             if (sKRSSpirometri) {
                that.kronikHastaliklarFormViewModel._KronikHastaliklarVeriSeti.SKRSSpirometri = sKRSSpirometri;
            }
        }

    }

    async ngOnInit()  {
        let that = this;
        if (this.RouteData2 != null){
            this.ObjectID = this.RouteData2.ObjectID;
            this.ActiveIDsModel = new ActiveIDsModel(this.RouteData2.EpisodeActionID, null, null);
       
        }
        await this.load(KronikHastaliklarFormViewModel);
  
    }


    public onIlkTaniTarihiChanged(event): void {
        if (event != null) {
            if (this._KronikHastaliklarVeriSeti != null && this._KronikHastaliklarVeriSeti.IlkTaniTarihi != event) {
                this._KronikHastaliklarVeriSeti.IlkTaniTarihi = event;
            }
        }
    }

    public onSKRSSpirometriChanged(event): void {
        if (event != null) {
            if (this._KronikHastaliklarVeriSeti != null && this._KronikHastaliklarVeriSeti.SKRSSpirometri != event) {
                this._KronikHastaliklarVeriSeti.SKRSSpirometri = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.IlkTaniTarihi, "Value", this.__ttObject, "IlkTaniTarihi");
    }

    public initFormControls(): void {
        this.labelSKRSSpirometri = new TTVisual.TTLabel();
        this.labelSKRSSpirometri.Text = i18n("M22258", "Spirometri");
        this.labelSKRSSpirometri.Name = "labelSKRSSpirometri";
        this.labelSKRSSpirometri.TabIndex = 3;

        this.SKRSSpirometri = new TTVisual.TTObjectListBox();
        this.SKRSSpirometri.Required = true;
        this.SKRSSpirometri.ListDefName = "SKRSSpirometriList";
        this.SKRSSpirometri.Name = "SKRSSpirometri";
        this.SKRSSpirometri.TabIndex = 2;

        this.labelIlkTaniTarihi = new TTVisual.TTLabel();
        this.labelIlkTaniTarihi.Text = i18n("M16453", "İlk Tanı Tarih");
        this.labelIlkTaniTarihi.Name = "labelIlkTaniTarihi";
        this.labelIlkTaniTarihi.TabIndex = 1;

        this.IlkTaniTarihi = new TTVisual.TTDateTimePicker();
        this.IlkTaniTarihi.Required = true;
        this.IlkTaniTarihi.BackColor = "#FFE3C6";
        this.IlkTaniTarihi.Format = DateTimePickerFormat.Long;
        this.IlkTaniTarihi.Name = "IlkTaniTarihi";
        this.IlkTaniTarihi.TabIndex = 0;

        this.Controls = [this.labelSKRSSpirometri, this.SKRSSpirometri, this.labelIlkTaniTarihi, this.IlkTaniTarihi];

    }

    protected async PreScript() {
         <Array<any>>this.RouteData.push(this.kronikHastaliklarFormViewModel);
    }
}
