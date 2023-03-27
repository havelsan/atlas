//$0D23E1A1
import { Component, ViewChild, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { DrugCorrectionViewModel, PatientInfo, DrugOrderInfo, OutputFor_ApplyTheDrugOrderDetail } from './DrugCorrectionViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { DxDataGridComponent, DxTextBoxComponent } from 'devextreme-angular';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { IModalService } from 'Fw/Services/IModalService';

import { DrugOrderDetailOutputItem } from 'Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/Hemsirelik_Is_Listesi/NursingWorkListViewModel';
import { SimpleTimer } from 'ng2-simple-timer';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
@Component({
    selector: 'drug-correction-form',
    templateUrl: './DrugCorrectionForm.html',
    providers: [SystemApiService, MessageService]
})

export class DrugCorrectionForm extends BaseComponent<DrugCorrectionViewModel> implements AfterViewInit, OnInit, OnDestroy {


    @ViewChild('grid') grid: DxDataGridComponent;
    @ViewChild('gridNursing') gridNursing: DxDataGridComponent;
    @ViewChild('wristBandText') wristBandText: DxTextBoxComponent;
    @ViewChild('drugBagText') drugBagText: DxTextBoxComponent;
    @ViewChild('drugText') drugText: DxTextBoxComponent;
    public verificationColor: string;
    public stockActionIDValue: string;
    public subEpisodeIDValue: string;
    public drugBarcodeValue: string;
    public patientInfoForWristBand: PatientInfo;
    public patientInfoForKschedule: PatientInfo;
    public patientDrugs: DrugOrderInfo[];
    public selectedRowKeys: Array<any>;
    public PatientInfoFromWristbandVisible: boolean;
    public PatientDrugInfoVisible: boolean;
    public DrugBarcodeInfoVisible: boolean;
    public triggeredByRefreshButton: boolean;
    public drugOrderDetails: Array<DrugOrderDetailOutputItem>;
    public olddrugOrderDetails: Array<DrugOrderDetailOutputItem>;
    public run: boolean;


    counter1 = 0;
    timer1Id: string;
    timer1button = 'Subscribe';

    constructor(private st: SimpleTimer, protected messageService: MessageService, container: ServiceContainer, private http: NeHttpService, public systemApiService: SystemApiService,
        protected modalService: IModalService, private objectContextService: ObjectContextService) {
        super(container);
        this.selectedRowKeys = new Array<any>();
        this.triggeredByRefreshButton = false;
    }
    async clientPreScript() {
        this.PatientDrugInfoVisible = false;
        this.DrugBarcodeInfoVisible = false;
        this.PatientInfoFromWristbandVisible = true;
    }
    clientPostScript(state: String): void {
    }

    subscribeTimer1() {
        if (this.timer1Id) {
            // Unsubscribe if timer Id is defined
            this.st.unsubscribe(this.timer1Id);
            this.timer1Id = undefined;
            this.timer1button = 'Subscribe';
        } else {
            // Subscribe if timer Id is undefined
            this.timer1Id = this.st.subscribe('60sec', () => {
                this.timer1callback();
            } );
            this.timer1button = 'Unsubscribe';
        }
    }

    timer1callback() {
        if (this.run) {
            this.sendClick();
        }
        this.run = true;
    }

    ngOnInit() {
        this.PatientInfoFromWristbandVisible = true;
        this.run = true;
        this.drugOrderDetails = new Array<DrugOrderDetailOutputItem>();
        let that = this;
        let fullApiUrl: string = 'api/DrugCorrectionService/GetDrugOrderDetailInformations';
        that.http.get(fullApiUrl).then((response: Array<DrugOrderDetailOutputItem>) => {
            this.olddrugOrderDetails = response;
        });
        this.st.newTimer('60sec', 60);
        this.subscribeTimer1();
    }
    ngOnDestroy() {
        this.st.delTimer('60sec');
    }

    ngAfterViewInit() {
        let that = this;
        setTimeout(() => {
            that.wristBandText.instance.focus();
        }, 500);
    }



    async freshDrugCorrectionProcess(): Promise<void> {
        this.verificationColor = 'White';
        this.PatientInfoFromWristbandVisible = true;
        this.PatientDrugInfoVisible = false;
        this.DrugBarcodeInfoVisible = false;
        this.triggeredByRefreshButton = true;
        this.stockActionIDValue = '';
        this.triggeredByRefreshButton = true;
        this.subEpisodeIDValue = '';
        this.drugBarcodeValue = '';
        this.patientInfoForWristBand = null;
        this.patientInfoForKschedule = null;
        this.patientDrugs = null;
        this.selectedRowKeys = null;

        let that = this;
        setTimeout(() => {
            that.triggeredByRefreshButton = false;
            that.wristBandText.instance.focus();
        }, 500);
    }


    async PatientInfo_FromWristband() {
        try {
            if (this.triggeredByRefreshButton === false) {
                let url: string = '/api/DrugCorrectionService/getPatientInfo_FromWristband';
                let input = { 'subEpisodeID': this.subEpisodeIDValue };
                let httpService: NeHttpService = ServiceLocator.NeHttpService;
                let result = await httpService.post<PatientInfo>(url, input);
                console.log(result);
                this.patientInfoForWristBand = result;
                this.PatientDrugInfoVisible = true;
                this.PatientInfoFromWristbandVisible = false;
                let that = this;
                setTimeout(() => {
                    that.drugBagText.instance.focus();
                }, 500);
            }
            this.triggeredByRefreshButton = false;

        } catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    async getPatientInfo_FromWristbandClick(): Promise<void> {
        let that = this;
        that.PatientInfo_FromWristband();
    }

    async PatientInfo_FromWristband_KeyPress(event: KeyboardEvent) {
        let that = this;
        if (event.charCode === 13) {
            that.PatientInfo_FromWristband();
        }
    }

    public async sendClick() {
        if (this.olddrugOrderDetails !== null && this.olddrugOrderDetails !== undefined) {
            for (let oldItem of this.olddrugOrderDetails) {
                oldItem.BackColorName = 'White';
            }
        }

        this.drugOrderDetails = new Array<DrugOrderDetailOutputItem>();
        let that = this;
        let fullApiUrl: string = 'api/DrugCorrectionService/GetDrugOrderDetailInformations';
        that.http.get(fullApiUrl).then((response: Array<DrugOrderDetailOutputItem>) => {
            this.drugOrderDetails = response;
            let counter: number = 0;
            for (let newitem of this.drugOrderDetails) {
                if (this.olddrugOrderDetails.some(x => x.id === newitem.id) === false) {
                    newitem.BackColorName = 'Orange';
                    counter = counter + 1;
                }
            }
            this.olddrugOrderDetails = this.drugOrderDetails;
            if (counter > 0) {
                this.st.delTimer('60sec');
                TTVisual.InfoBox.CustomShow(i18n("M23735", "Uyarı"), counter.toString() + ' adet yeni işiniz bulunmaktadır.')
                    .then(result => {
                        if (result === 'OK') {
                            this.run = false;
                            this.st.newTimer('60sec', 60);
                            this.timer1Id = this.st.subscribe('60sec', () => {this.timer1callback()});
                        }
                    });
            }
        });
        this.gridNursing.instance.refresh();
    }
    public async sendMessage(counter: number) {
        if (counter > 0) {
            this.messageService.showInfo(counter.toString() + ' adet yeni işiniz bulunmaktadır.');
            let a = await TTVisual.InfoBox.Alert(counter.toString() + ' adet yeni işiniz bulunmaktadır.');
        }
    }

    async PatientInfo() {
        try {
            if (this.triggeredByRefreshButton === false) {
                let url: string = '/api/DrugCorrectionService/getPatientInfo';
                let input = { 'stockActionID': this.stockActionIDValue };
                let httpService: NeHttpService = ServiceLocator.NeHttpService;
                let result = await httpService.post<PatientInfo>(url, input);
                console.log(result);
                this.patientInfoForKschedule = result;
                if (this.patientInfoForWristBand.patientObjectID === this.patientInfoForKschedule.patientObjectID) {
                    this.patientDrugs = result.DrugOrderInfoList;
                    ServiceLocator.MessageService.showInfo(i18n("M15156", "Hasta Bileklik Bilgisi ve İlaç Torba Bilgisi eşleştirme BAŞARILI !"));
                    this.DrugBarcodeInfoVisible = true;
                    this.PatientDrugInfoVisible = false;
                    this.verificationColor = 'LightSeaGreen';
                    let that = this;
                    setTimeout(() => {
                        that.drugText.instance.focus();
                    }, 500);
                } else {
                    this.verificationColor = 'IndianRed';
                    ServiceLocator.MessageService.showError(i18n("M15157", "Hasta Bileklik Bilgisi ve İlaç Torba Bilgisi eşleştirme BAŞARISIZ !"));
                }
            }
            this.triggeredByRefreshButton = false;

        } catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    async getPatientInfoClick(): Promise<void> {
        let that = this;
        that.PatientInfo();
    }

    async PatientInfo_KeyPress(event: KeyboardEvent) {
        let that = this;
        if (event.charCode === 13) {
            that.PatientInfo();
        }
    }

    async readDrugBarcodeVerifyAndApplyIt() {
        console.log(this.drugBarcodeValue);
        const barcodeNumber = this.drugBarcodeValue;
        const scrollToRow = this.patientDrugs.findIndex(i => i.MaterialBarcode === barcodeNumber && i.IsItInTheTimeInterval === true && i.stateDefID !== 'd39a37a6-610e-4143-aca2-691ce5818915');
        const pageSize = this.grid.instance.pageSize();
        const pageIndex = Math.floor(scrollToRow / pageSize) + ((scrollToRow % pageSize) ? 0 : -1);
        this.grid.instance.pageIndex(pageIndex);
        let drugDone: Boolean = false;
        if (scrollToRow !== -1) {
            this.grid.instance.selectRowsByIndexes([scrollToRow]);
            if (this.grid.selectedRowKeys[0].drugType === false) {
                let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'İlaç Bitti',
                    ' Uygulamak üzere olduğunuz ilaç bitti mi ?');
                if (result === 'E') {
                    drugDone = true;
                }
            }
        }
        let that = this;
        setTimeout(() => {
            const dataSource = that.grid.instance.getDataSource();
            const items = dataSource.items();
            const rowIndex = items.findIndex(i => i.MaterialBarcode === barcodeNumber && i.IsItInTheTimeInterval === true && i.stateDefID !== 'd39a37a6-610e-4143-aca2-691ce5818915');
            if (rowIndex !== -1) {
                that.grid.instance.selectRowsByIndexes([rowIndex]);
                //drugOrder'ın uygulama işlemi burada gerçekleştirilecek
                that.grid.selectedRowKeys[0].drugDone = drugDone;
                let url: string = '/api/DrugCorrectionService/ApplyTheDrugOrderDetail';
                let input = { 'drugOrderInfo': that.grid.selectedRowKeys[0] };
                let httpService: NeHttpService = ServiceLocator.NeHttpService;
                httpService.post<OutputFor_ApplyTheDrugOrderDetail>(url, input).then(result => {
                    console.log(result);

                    if (result.processCompleted === true) {
                        if (result.updatedDrugOrder.stateDefID === 'd39a37a6-610e-4143-aca2-691ce5818915') { //uygulama işlemi tamamlanmış ise uyarı versin
                            result.resultMessage += (<DrugOrderInfo>that.grid.selectedRowKeys[0]).MaterialName + i18n("M16580", " isimli ilacı ") +
                                (<DrugOrderInfo>that.grid.selectedRowKeys[0]).DrugUsageType + ' yöntemiyle ' + (<DrugOrderInfo>that.grid.selectedRowKeys[0]).Amount + i18n("M19035", " miktar uygulayınız.");
                        }
                        ServiceLocator.MessageService.showInfo(result.resultMessage);
                    } else
                        ServiceLocator.MessageService.showError(result.resultMessage);

                    (<DrugOrderInfo>that.grid.selectedRowKeys[0]).stateDefID = result.updatedDrugOrder.stateDefID;
                    (<DrugOrderInfo>that.grid.selectedRowKeys[0]).DrugCounter = result.updatedDrugOrder.DrugCounter;
                });
            } else {
                ServiceLocator.MessageService.showError(i18n("M21552", "Seçili ilaç uygulanabilecek ilaçlar listesinde yer almamaktadır!"));
            }

        }, 500);

        this.drugBarcodeValue = '';
        //gridi refresh ettikten sonra görünüm değişecek
        this.grid.instance.refresh();
    }

    async readDrugBarcodeAndVerifyIt(): Promise<void> {
        let that = this;
        that.readDrugBarcodeVerifyAndApplyIt();
    }

    async DrugBarcode_KeyPress(event: KeyboardEvent) {
        let that = this;
        if (event.charCode === 13) {
            that.readDrugBarcodeVerifyAndApplyIt();
        }
    }



    onRowPrepared(e: any): void {
        if (e.rowElement.firstItem() !== undefined && e.rowElement.firstItem().length > 0 && e.rowType !== 'header' && e.rowElement.firstItem().length === 1) {
            if (e.rowType === 'data') {
                if (e.data.stateDefID === 'd39a37a6-610e-4143-aca2-691ce5818915') {
                    e.rowElement.firstItem().css('background-color', 'MediumSeaGreen');
                } else {
                    if (e.data.IsItInTheTimeInterval === true) {
                        e.rowElement.firstItem().css('background-color', 'SandyBrown');
                    }
                }
            }
        }
    }

    onRowPreparedNursing(e: any): void {
        if (e.rowElement.firstItem() !== undefined && e.rowElement.firstItem().length > 0 && e.rowType !== 'header' && e.rowElement.firstItem().length === 1) {
            if (e.rowType === 'data') {
                if (e.data.BackColorName === 'Orange') {
                    e.rowElement.firstItem().css('background-color', 'Orange');
                }
                if (e.data.BackColorName === 'White') {
                    e.rowElement.firstItem().css('background-color', 'White');
                }
            }
        }
    }

}


