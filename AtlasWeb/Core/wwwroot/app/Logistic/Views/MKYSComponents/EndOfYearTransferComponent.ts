import { Component, OnInit } from '@angular/core';
import { BaseComponent } from 'app/Fw/Components/BaseComponent';
import { MkysIntegrationViewModel, DocumentRecordLogGridItem, StockActionMkysCompareItem, ReceivedDataFromMkys, EndOfYearItem, GetYilSonuDevir_Output, StockCensusForAtlas_Input } from 'app/Logistic/Models/MkysIntegrationViewModel';
import { ServiceContainer } from 'app/Fw/Services/ServiceContainer';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { IActiveUserService } from 'app/Fw/Services/IActiveUserService';
import { IModalService } from 'app/Fw/Services/IModalService';
import { MessageService } from 'app/Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';


@Component({
    selector: 'end-of-year-transfer',
    templateUrl: './EndOfYearTransferComponent.html'
})

export class EndOfYearTransferComponent extends BaseComponent<MkysIntegrationViewModel> {
    
    public DocRecordLog = new Array<DocumentRecordLogGridItem>();
    public accountingTermObjId: any;
    public activeAccountingTerm: any;
    public valueForEditableTextArea: string;
    public stockActionID: string;
    public dataSource: any;
    public startDate: Date = new Date();
    public endDate: Date = new Date();
    public dataStockActionSource: Array<StockActionMkysCompareItem> = new Array<StockActionMkysCompareItem>();
    public dataStockActionSourceFaild: Array<StockActionMkysCompareItem> = new Array<StockActionMkysCompareItem>();
    public dataStockActionSourceOld: Array<StockActionMkysCompareItem> = new Array<StockActionMkysCompareItem>();
    public checkBoxValue: boolean = false;
    public stockActionIDdisable: boolean = !this.checkBoxValue;
    public checkBoxValueFailed: boolean = false;
    public sendMKYSButton: boolean = true;
    public CompareWithMkysButton: boolean = false;
    public CreateButtonDisabled: boolean = true;
    public receivedDataSourceFromMkys: Array<ReceivedDataFromMkys> = new Array<ReceivedDataFromMkys>();
    public componentInfo: DynamicComponentInfo;
    public selectedTempItems: Array<ReceivedDataFromMkys>;
    public isWithOutCancelled: boolean = true;

    public hasRoleSendToMkys: boolean;
    public hasRoleCompareToMkys: boolean;
    public hasRoleMkysDocumentsFromInstitutions: boolean;
    public hasRoleMkysEndOfYearCensus: boolean;

    public valueForStore: string;
    public valueForYear: string;

    public MKYSDevirGetirBtn: boolean = false;
    public MKYSDevirGetirYapBtn: boolean = true;

    constructor(container: ServiceContainer, private http: NeHttpService, protected messageService: MessageService, protected activeUserService: IActiveUserService) {
        super(container);
    }
    
    ngOnInit() { }

    clientPreScript(): void { 
        this.valueForStore = this.activeUserService.SelectedUserStore.Name;
    }
    clientPostScript(state: String): void {     }
    loadingVisible = false;
    public dataSoruceEndOfYearGetMkys: Array<GetYilSonuDevir_Output>;

    async btnGetYilSonuDevirClick() {

        if (this.valueForYear != undefined) {
            this.loadingVisible = true;
            let inputDvo = new EndOfYearItem();
            inputDvo.store = this.activeUserService.SelectedUserStore;
            inputDvo.year = this.valueForYear;
            let that = this;
            let fullApiUrl: string = 'api/MkysIntegration/GetYilSonuDevir';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    that.dataSoruceEndOfYearGetMkys = <Array<GetYilSonuDevir_Output>>res;
                    this.MKYSDevirGetirYapBtn = false;
                    this.loadingVisible = false;
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    this.loadingVisible = false;
                });
        }
        else {
            TTVisual.InfoBox.Alert("Yıl Seçimi Yapınız");

        }
    }

    async btnStockCensusForAtlasClick() {
        let control: boolean = true;
        for (let source of this.dataSoruceEndOfYearGetMkys) {
            if (source.hata == "Hatalı Mevcut") {
                ServiceLocator.MessageService.showError("Hatalı Mevcut Var.");
                control = false;
            }
        }
        if (control == true) {
            await this.StockCensusForAtlasClick();
        }
    }

    async StockCensusForAtlasClick() {

        this.loadingVisible = true;
        let inputDvo = new StockCensusForAtlas_Input();
        inputDvo.store = this.activeUserService.SelectedUserStore;
        inputDvo.stokHaraketYilSonuItems = this.dataSoruceEndOfYearGetMkys;
        let fullApiUrl: string = 'api/MkysIntegration/StockCensusForAtlasClick';
        await this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                TTVisual.InfoBox.Alert(res.toString());
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });

    }
}