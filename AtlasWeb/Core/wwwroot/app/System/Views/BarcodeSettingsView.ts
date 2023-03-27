//$8F2DAF9F

import { Component, OnInit, Input, EventEmitter, OnDestroy } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'app/Fw/Services/MessageService';
import { AtlasHttpService } from 'app/Fw/Services/AtlasHttpService';
import { BarcodeSettings, BarcodeSettingsViewModel } from '../Models/BarcodeSettingsModel';


@Component({
    selector: "barcodesettingsform",
    templateUrl: './BarcodeSettingsView.html',
    providers: [MessageService]

})
export class BarcodeSettingsView extends BaseComponent<any> implements OnInit, OnDestroy {

    _AtlasClientInfo: string = "";
    _printerDataSource : Array<any> = [];
    _barcodeType:Array<string> = ["Kabul Barkodu","Sonuç Barkodu","Laboratuvar Barkodu","Yatan Hasta Barkodu","Hasta Bilekliği","Arşiv Barkodu"];
    _barcodeCount:number = 1;
    _barcodeSettingsArray:Array<BarcodeSettings> = [];
    _selectedPrinter :string;
    _selectedBarcodeType:string;
    _barcodeSettingColumns =[
        { caption: 'Barkod Tipi',fixed: true, dataField: 'BarcodeType', width: '110' },
        { caption: 'Barkod Sayısı', fixed: true,dataField: 'BarcodeCount', width: '90' },
        { caption: 'Barkod Cihazı', dataField: 'Printer', width: 'auto' }
       
    ];
    _disabled:boolean = false;
    barcodeModel :BarcodeSettingsViewModel = new BarcodeSettingsViewModel();


    clientPostScript(state: String) {

    }

    clientPreScript() {

    }
    public ngOnDestroy(): void {
    }

   
    
    constructor(protected httpService: NeHttpService,private http: AtlasHttpService, services: ServiceContainer, protected messageService: MessageService) {
        super(services);
    }

    async ngOnInit() {
        await this.loadBarcodeSettings();
        await this.getBarcodeSettings();
    }


    private async loadBarcodeSettings():Promise<any> {
        let response = await this.getPrinterList();

        if (response == undefined) {
            this._AtlasClientInfo = "Atlas Client Servis Kurunuz.";
            this._disabled = true;
            return;
        }
        if (response.json().Result instanceof Array) {
            const printers = response.json().Result as Array<any>;
            for (let item of printers) {
                 //Printer combosu dolduruluyor
                this._printerDataSource.push(item);
            }
          
         
        }
        else {
            this._AtlasClientInfo = "Atlas Client Servis Kurunuz.";
            this._disabled = true;
        }
    }

    public async getPrinterList(): Promise<any> {

      
        try {
            let printers = await this.http.get('http://localhost:5000/api/AtlasPrint/PrinterList').toPromise();
            return printers;
        } catch (e) {
            this._AtlasClientInfo = "Atlas Client Servis Kurunuz.";
            this._disabled = true;
        }

    }

    addBarcodeSettings()
    {
        let that=this;

        //aynı cihaza aynı tip için birden fazla ekleme yapılmaması kontrol edilmeli.
        for(let item of that._barcodeSettingsArray)
        {
            if(that._selectedBarcodeType == item.BarcodeType && that._selectedPrinter == item.Printer){
                this.messageService.showError("Aynı barkod yazıcısına aynı tür barkod ekleyemezsiniz.")
                return;
            }
        }
        let s :BarcodeSettings = new BarcodeSettings();
        s.BarcodeCount = that._barcodeCount;
        s.BarcodeType = that._selectedBarcodeType;
        s.Printer = that._selectedPrinter;
        that._barcodeSettingsArray.push(s);
  
    }

    printerChanged(data)
    {
        let that=this;
        that._selectedPrinter = data.value;
    }

    barcodeTypeChanged(data)
    {
        let that=this;
        that._selectedBarcodeType = data.value;
    }
    
    saveBarcodeSettings()
    {
        let that = this;
        this.barcodeModel = new BarcodeSettingsViewModel();
        this.barcodeModel._Settings = new Array<BarcodeSettings>();
        this.barcodeModel._Settings = that._barcodeSettingsArray;

        let apiUrl: string = '/api/CommonService/SaveUserBarcodeSettings';

        this.httpService.post(apiUrl, this.barcodeModel).then(result => {
          this.messageService.showInfo("İşlem başarıyla kaydedildi.");
           
        })
            .catch(error => {
                this.messageService.showError(error);
            });
    }

    async getBarcodeSettings()
    {
        let apiUrl: string = '/api/CommonService/GetUserBarcodeSettings';

        this.httpService.get<BarcodeSettingsViewModel>(apiUrl).then(result => {
     
         this._barcodeSettingsArray = result._Settings;
           
        })
            .catch(error => {
                this.messageService.showError(error);
            });
    }
}

