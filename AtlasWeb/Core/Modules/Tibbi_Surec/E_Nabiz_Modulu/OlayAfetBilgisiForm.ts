//$8583459D
import { Component, OnInit, NgZone } from '@angular/core';
import { OlayAfetBilgisiFormViewModel } from './OlayAfetBilgisiFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { OlayAfetBilgisi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAFETOLAYVATANDASTIPI } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSHayatiTehlikeDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOlayAfetBilgisi } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'OlayAfetBilgisiForm',
    templateUrl: './OlayAfetBilgisiForm.html',
    providers: [MessageService]
})
export class OlayAfetBilgisiForm extends TTVisual.TTForm implements OnInit {
    GlasgowKomaSkalasi: TTVisual.ITTTextBox;
    labelGlasgowKomaSkalasi: TTVisual.ITTLabel;
    labelSKRSAFETOLAYVATANDASTIPI: TTVisual.ITTLabel;
    labelSKRSHayatiTehlikeDurumu: TTVisual.ITTLabel;
    labelSKRSOlayAfetBilgisi: TTVisual.ITTLabel;
    SKRSAFETOLAYVATANDASTIPI: TTVisual.ITTObjectListBox;
    SKRSHayatiTehlikeDurumu: TTVisual.ITTObjectListBox;
    SKRSOlayAfetBilgisi: TTVisual.ITTObjectListBox;
    public statesPanelClass: string = "col-lg-6";
    public olayAfetBilgisiFormViewModel: OlayAfetBilgisiFormViewModel = new OlayAfetBilgisiFormViewModel();
    public get _OlayAfetBilgisi(): OlayAfetBilgisi {
        return this._TTObject as OlayAfetBilgisi;
    }
    private OlayAfetBilgisiForm_DocumentUrl: string = '/api/OlayAfetBilgisiService/OlayAfetBilgisiForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('OLAYAFETBILGISI', 'OlayAfetBilgisiForm');
        this._DocumentServiceUrl = this.OlayAfetBilgisiForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new OlayAfetBilgisi();
        this.olayAfetBilgisiFormViewModel = new OlayAfetBilgisiFormViewModel();
        this._ViewModel = this.olayAfetBilgisiFormViewModel;
        this.olayAfetBilgisiFormViewModel._OlayAfetBilgisi = this._TTObject as OlayAfetBilgisi;
        this.olayAfetBilgisiFormViewModel._OlayAfetBilgisi.SKRSHayatiTehlikeDurumu = new SKRSHayatiTehlikeDurumu();
        this.olayAfetBilgisiFormViewModel._OlayAfetBilgisi.SKRSOlayAfetBilgisi = new SKRSOlayAfetBilgisi();
        this.olayAfetBilgisiFormViewModel._OlayAfetBilgisi.SKRSAFETOLAYVATANDASTIPI = new SKRSAFETOLAYVATANDASTIPI();
    }

    protected loadViewModel() {
        let that = this;

        that.olayAfetBilgisiFormViewModel = this._ViewModel as OlayAfetBilgisiFormViewModel;
        that._TTObject = this.olayAfetBilgisiFormViewModel._OlayAfetBilgisi;
        if (this.olayAfetBilgisiFormViewModel == null)
            this.olayAfetBilgisiFormViewModel = new OlayAfetBilgisiFormViewModel();
        if (this.olayAfetBilgisiFormViewModel._OlayAfetBilgisi == null)
            this.olayAfetBilgisiFormViewModel._OlayAfetBilgisi = new OlayAfetBilgisi();
        let sKRSHayatiTehlikeDurumuObjectID = that.olayAfetBilgisiFormViewModel._OlayAfetBilgisi["SKRSHayatiTehlikeDurumu"];
        if (sKRSHayatiTehlikeDurumuObjectID != null && (typeof sKRSHayatiTehlikeDurumuObjectID === "string")) {
            let sKRSHayatiTehlikeDurumu = that.olayAfetBilgisiFormViewModel.SKRSHayatiTehlikeDurumus.find(o => o.ObjectID.toString() === sKRSHayatiTehlikeDurumuObjectID.toString());
             if (sKRSHayatiTehlikeDurumu) {
                that.olayAfetBilgisiFormViewModel._OlayAfetBilgisi.SKRSHayatiTehlikeDurumu = sKRSHayatiTehlikeDurumu;
            }
        }
        let sKRSOlayAfetBilgisiObjectID = that.olayAfetBilgisiFormViewModel._OlayAfetBilgisi["SKRSOlayAfetBilgisi"];
        if (sKRSOlayAfetBilgisiObjectID != null && (typeof sKRSOlayAfetBilgisiObjectID === "string")) {
            let sKRSOlayAfetBilgisi = that.olayAfetBilgisiFormViewModel.SKRSOlayAfetBilgisis.find(o => o.ObjectID.toString() === sKRSOlayAfetBilgisiObjectID.toString());
             if (sKRSOlayAfetBilgisi) {
                that.olayAfetBilgisiFormViewModel._OlayAfetBilgisi.SKRSOlayAfetBilgisi = sKRSOlayAfetBilgisi;
            }
        }
        let sKRSAFETOLAYVATANDASTIPIObjectID = that.olayAfetBilgisiFormViewModel._OlayAfetBilgisi["SKRSAFETOLAYVATANDASTIPI"];
        if (sKRSAFETOLAYVATANDASTIPIObjectID != null && (typeof sKRSAFETOLAYVATANDASTIPIObjectID === "string")) {
            let sKRSAFETOLAYVATANDASTIPI = that.olayAfetBilgisiFormViewModel.SKRSAFETOLAYVATANDASTIPIs.find(o => o.ObjectID.toString() === sKRSAFETOLAYVATANDASTIPIObjectID.toString());
             if (sKRSAFETOLAYVATANDASTIPI) {
                that.olayAfetBilgisiFormViewModel._OlayAfetBilgisi.SKRSAFETOLAYVATANDASTIPI = sKRSAFETOLAYVATANDASTIPI;
            }
        }

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OlayAfetBilgisiFormViewModel);
  
    }


    public onGlasgowKomaSkalasiChanged(event): void {
        if (event != null) {
            if (this._OlayAfetBilgisi != null && this._OlayAfetBilgisi.GlasgowKomaSkalasi != event) {
                this._OlayAfetBilgisi.GlasgowKomaSkalasi = event;
            }
        }
    }

    public onSKRSAFETOLAYVATANDASTIPIChanged(event): void {
        if (event != null) {
            if (this._OlayAfetBilgisi != null && this._OlayAfetBilgisi.SKRSAFETOLAYVATANDASTIPI != event) {
                this._OlayAfetBilgisi.SKRSAFETOLAYVATANDASTIPI = event;
            }
        }
    }

    public onSKRSHayatiTehlikeDurumuChanged(event): void {
        if (event != null) {
            if (this._OlayAfetBilgisi != null && this._OlayAfetBilgisi.SKRSHayatiTehlikeDurumu != event) {
                this._OlayAfetBilgisi.SKRSHayatiTehlikeDurumu = event;
            }
        }
    }

    public onSKRSOlayAfetBilgisiChanged(event): void {
        if (event != null) {
            if (this._OlayAfetBilgisi != null && this._OlayAfetBilgisi.SKRSOlayAfetBilgisi != event) {
                this._OlayAfetBilgisi.SKRSOlayAfetBilgisi = event;
            }
        }
    }

  

    protected redirectProperties(): void {
        redirectProperty(this.GlasgowKomaSkalasi, "Text", this.__ttObject, "GlasgowKomaSkalasi");
    }

    public initFormControls(): void {
        this.labelSKRSHayatiTehlikeDurumu = new TTVisual.TTLabel();
        this.labelSKRSHayatiTehlikeDurumu.Text = i18n("M15569", "Hayati Tehlike Durumu");
        this.labelSKRSHayatiTehlikeDurumu.Name = "labelSKRSHayatiTehlikeDurumu";
        this.labelSKRSHayatiTehlikeDurumu.TabIndex = 7;

        this.SKRSHayatiTehlikeDurumu = new TTVisual.TTObjectListBox();
        this.SKRSHayatiTehlikeDurumu.ListDefName = "SKRSHayatiTehlikeDurumuList";
        this.SKRSHayatiTehlikeDurumu.Name = "SKRSHayatiTehlikeDurumu";
        this.SKRSHayatiTehlikeDurumu.TabIndex = 6;

        this.labelSKRSOlayAfetBilgisi = new TTVisual.TTLabel();
        this.labelSKRSOlayAfetBilgisi.Text = "Olay/Afet Bilgisi";
        this.labelSKRSOlayAfetBilgisi.Name = "labelSKRSOlayAfetBilgisi";
        this.labelSKRSOlayAfetBilgisi.TabIndex = 5;

        this.SKRSOlayAfetBilgisi = new TTVisual.TTObjectListBox();
        this.SKRSOlayAfetBilgisi.ListDefName = "SKRSOlayAfetBilgisiList";
        this.SKRSOlayAfetBilgisi.Name = "SKRSOlayAfetBilgisi";
        this.SKRSOlayAfetBilgisi.TabIndex = 4;
        this.SKRSOlayAfetBilgisi.AutoCompleteDialogHeight = '50%';

        this.labelSKRSAFETOLAYVATANDASTIPI = new TTVisual.TTLabel();
        this.labelSKRSAFETOLAYVATANDASTIPI.Text = "Afet/Olay Vatandaş Tipi";
        this.labelSKRSAFETOLAYVATANDASTIPI.Name = "labelSKRSAFETOLAYVATANDASTIPI";
        this.labelSKRSAFETOLAYVATANDASTIPI.TabIndex = 3;

        this.SKRSAFETOLAYVATANDASTIPI = new TTVisual.TTObjectListBox();
        this.SKRSAFETOLAYVATANDASTIPI.ListDefName = "SKRSAFETOLAYVATANDASTIPIList";
        this.SKRSAFETOLAYVATANDASTIPI.Name = "SKRSAFETOLAYVATANDASTIPI";
        this.SKRSAFETOLAYVATANDASTIPI.TabIndex = 2;

        this.labelGlasgowKomaSkalasi = new TTVisual.TTLabel();
        this.labelGlasgowKomaSkalasi.Text = i18n("M14823", "Glasgow Koma Skalası");
        this.labelGlasgowKomaSkalasi.Name = "labelGlasgowKomaSkalasi";
        this.labelGlasgowKomaSkalasi.TabIndex = 1;

        this.GlasgowKomaSkalasi = new TTVisual.TTTextBox();
        this.GlasgowKomaSkalasi.Name = "GlasgowKomaSkalasi";
        this.GlasgowKomaSkalasi.TabIndex = 0;

        this.Controls = [this.labelSKRSHayatiTehlikeDurumu, this.SKRSHayatiTehlikeDurumu, this.labelSKRSOlayAfetBilgisi, this.SKRSOlayAfetBilgisi, this.labelSKRSAFETOLAYVATANDASTIPI, this.SKRSAFETOLAYVATANDASTIPI, this.labelGlasgowKomaSkalasi, this.GlasgowKomaSkalasi];

    }


}
