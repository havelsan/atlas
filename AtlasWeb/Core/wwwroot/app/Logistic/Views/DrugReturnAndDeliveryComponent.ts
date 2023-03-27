import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import DataSource from 'devextreme/data/data_source';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { GetReturnDetails, GetReturnableDetails_Output, GetDrugReturnAndDeliveryDetails, GetReturnableDrugOrderDetails_Output, DrugReturnActionCreate_Input, DrugReturnActionService, DrugDeliveryActionCreate_Input, GetWaitingPharmacy_Input, GetWaitingPharmacy_Output, GetComplatedPharmacy_Output, HalfDoseDestructionDVO, CreateHalfDoseDestruction_Input, CreateHalfDoseDestruction_Output } from 'app/NebulaClient/Services/ObjectService/DrugReturnActionService';
import { DrugReturnAction } from 'app/NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';

@Component({
    selector: 'drugreturnanddelivery-component',
    template: `

    <div class="row" style="margin-left: 10px;">
    <dx-radio-group [items]="priorities" [value]="priorities[0]" layout="horizontal" (onValueChanged)="onValueChanged($event)">
        <div *dxTemplate="let priority of 'item'">
            <div>{{priority}}</div>
        </div>
    </dx-radio-group>
</div>
<br />

<div *ngIf="ilacIade">
    <div class="row">
        <div class="col-sm-12">
            <dx-data-grid id="grid-container" style="height:340px" [dataSource]="drugReturnActionDataSource" [columns]="DrugReturnActionGridColumns" [showBorders]="true" [(selectedRowKeys)]="selectedReturnActionItems">
                <dxo-selection selectAllMode="allPages" showCheckBoxesMode="onClick" mode="multiple"></dxo-selection>
                <dxo-paging [pageSize]="12"></dxo-paging>
                <dxo-filter-row [visible]="true"></dxo-filter-row>
            </dx-data-grid>
        </div>
    </div>
    <br />
    <div class="row" id="A3477">
        <div class="col-sm-12" id="A3478">
            <label class="control-label" i18n="@@M16069" id="A3479">
                İade Nedeni
            </label>
            <dx-text-area [height]="90" [maxLength]="maxLength" [(value)]="textIadeNedeni"></dx-text-area>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-6">
            <dx-button type="default" text="İlaç İade Et" icon="pulldown" (onClick)="drugReturnActionClick()" id="progress-button" style="min-width:128px;"></dx-button>
        </div>
    </div>
</div>


<div *ngIf="hastayaTeslim">
    <div class="row">
        <div class="col-sm-12">
            <dx-data-grid id="grid-container" style="height:450px" [dataSource]="drugDeliveryActionDataSource" [columns]="DrugDeliveryActionGridColumns" [showBorders]="true" [(selectedRowKeys)]="selectedDeliveryActionItems">
                <dxo-selection mode="multiple"></dxo-selection>
                <dxo-paging [pageSize]="18"></dxo-paging>
                <dxo-filter-row [visible]="true"></dxo-filter-row>
            </dx-data-grid>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-6">
            <dx-button icon="revert" type="danger" text="Hastaya Teslim Et" (onClick)="drugDeliveryActionClick()" id="progress-button" style="min-width:128px;"></dx-button>
        </div>
    </div>
</div>

<div *ngIf="yarimDoseImha">
    <div class="row">
        <div class="col-sm-12">
            <dx-data-grid id="grid-container" style="height:450px" [dataSource]="halfDoseDestructionDataSource" [columns]="HalfDoseGridColumns" [showBorders]="true" [(selectedRowKeys)]="selectedhalfDoseDestructionDVO">
                <dxo-selection mode="multiple"></dxo-selection>
                <dxo-paging [pageSize]="18"></dxo-paging>
                <dxo-filter-row [visible]="true"></dxo-filter-row>
            </dx-data-grid>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-6">
            <dx-button icon="clear" type="danger" text="İmha Onay" (onClick)="CreateHalfDoseDestruction()" id="progress-button" style="min-width:128px;"></dx-button>
        </div>
    </div>
</div>

<div *ngIf="eczaneBekleyen">
    <div class="row" id="pharmacyWaitingGrid">
        <div class="col-sm-12">
            <dx-data-grid style="height:450px" [dataSource]="pharmacyWaitingDataSouce" [masterDetail]="{ enabled: true, template: 'details'  }" [showBorders]="true">
                <dxo-selection mode="single"></dxo-selection>
                <dxo-paging [pageSize]="25"></dxo-paging>
                <dxi-column dataField="ID" caption="İşlem Numarsı" width="auto"></dxi-column>
                <dxi-column dataField="ActionDate" dataType="date" sortOrder="desc" caption="İşlem Tarihi" width="auto"></dxi-column>
                <dxi-column dataField="DrugReturnReason" caption="İade Nedeni" width="auto"></dxi-column>
                <div *dxTemplate="let item of 'details'">
                    <div class="internal-grid-container" id="A32449">
                        <dx-data-grid class="internal-grid" [dataSource]="item.data.details" id="A32450">
                            <dxi-column dataField="MaterialName" caption="İlaç Adı" width="500"></dxi-column>
                            <dxi-column dataField="Amount" caption="Miktarı" width="auto"></dxi-column>
                        </dx-data-grid>
                    </div>
                </div>
            </dx-data-grid>
        </div>
    </div>
</div>

<div *ngIf="eczaneTamamlanan">
    <div class="row" id="pharmacyComplatedGrid">
        <div class="col-sm-12">
            <dx-data-grid style="height:450px" [dataSource]="pharmacyComplatedDataSouce" [masterDetail]="{ enabled: true, template: 'details'  }" [showBorders]="true">
                <dxo-selection mode="single"></dxo-selection>
                <dxo-paging [pageSize]="25"></dxo-paging>
                <dxi-column dataField="ID" caption="İşlem Numarsı" width="auto"></dxi-column>
                <dxi-column dataField="ActionDate" dataType="date" sortOrder="desc" caption="İşlem Tarihi" width="auto"></dxi-column>
                <dxi-column dataField="DrugReturnReason" caption="İade Nedeni" width="auto"></dxi-column>
                <div *dxTemplate="let item of 'details'">
                    <div class="internal-grid-container" id="A32449">
                        <dx-data-grid class="internal-grid" [dataSource]="item.data.details" id="A32450">
                            <dxi-column dataField="MaterialName" caption="İlaç Adı" width="500"></dxi-column>
                            <dxi-column dataField="Amount" caption="Miktarı" width="auto"></dxi-column>
                        </dx-data-grid>
                    </div>
                </div>
            </dx-data-grid>
        </div>
    </div>
</div>

<dx-load-panel #loadPanelPW shadingColor="rgba(0,0,0,0.4)" [position]="{ of: '#pharmacyWaitingGrid' }" [(visible)]="loadingVisibleWDS"
               [showIndicator]="true" [showPane]="true" [shading]="true" [closeOnOutsideClick]="true">
</dx-load-panel>
<dx-load-panel #loadPanelPC shadingColor="rgba(0,0,0,0.4)" [position]="{ of: '#pharmacyComplatedGrid' }" [(visible)]="loadingVisibleCDS"
               [showIndicator]="true" [showPane]="true" [shading]="true" [closeOnOutsideClick]="true">
</dx-load-panel>
    `
})
export class DrugReturnAndDeliveryComponent implements IModal {
    priorities: string[];
    priority: string;
    public ilacIade: boolean = true;
    public hastayaTeslim: boolean = false;
    public eczaneBekleyen: boolean = false;
    public eczaneTamamlanan: boolean = false;
    public yarimDoseImha: boolean = false;
    public componentInfo: DynamicComponentInfo;
    private _modalInfo: ModalInfo;
    
    drugReturnActionDataSource: Array<GetReturnableDrugOrderDetails_Output>;
    drugDeliveryActionDataSource: Array<GetReturnableDrugOrderDetails_Output>;
    halfDoseDestructionDataSource: Array<HalfDoseDestructionDVO> = new Array<HalfDoseDestructionDVO>();
    pharmacyWaitingDataSouce:Array<GetWaitingPharmacy_Output>;
    public loadingVisibleWDS: boolean = false;
    pharmacyComplatedDataSouce:Array<GetWaitingPharmacy_Output>;
    public loadingVisibleCDS: boolean = false;
    textIadeNedeni: string ="";
    
    selectedReturnActionItems: Array<GetReturnableDrugOrderDetails_Output>;
    selectedDeliveryActionItems: Array<GetReturnableDrugOrderDetails_Output>;
    selectedhalfDoseDestructionDVO: Array<HalfDoseDestructionDVO>;
    
    MasterResource : Guid;
    SecondaryMasterResource :Guid;
    Episode :Guid;
    SubEpisode :Guid;

    constructor(private modalStateService: ModalStateService, private http: NeHttpService, private reportService: AtlasReportService,) {
        this.priorities = [
            "Eczaneye İlaç İade", 
            "Hastaya Teslim", 
            "Yarım Doz İmha",
            "Eczanede Bekleyen İade İşlemleri",
            "Tamamlanan İade İşlemleri"
        ];
    }

    public DrugReturnActionGridColumns = [
        {
            caption: ' ',
            dataField: 'ObjectID',
            cellTemplate: 'buttonCellTemplate',
            visible: false,
            allowEditing: false,
            width: 50
        },
        {
            caption: i18n("M18550", "İlaç Adı"),
            dataField: 'drugName',
            allowEditing: false,
            width: 300
        },
        {
            caption: 'Miktar',
            dataField: 'amount',
            allowEditing: false,
            width: 120
        },
        {
            caption: 'İade Miktarı',
            dataField: 'returnAmount',
            allowEditing: false,
            visible: false,
            width: 120
        },
        {
            caption: "İlaç Uygulama Tarihi",
            dataField: 'transactionDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: "İlaç Uygulama Saati",
            dataField: 'transactionDate',
            dataType: 'date',
            format: "shortTime",
            allowEditing: false,
            width: 'auto'
        },
        {
            caption:"Durumu",
            dataField: 'status',
            allowEditing: false,
            width: 'auto'
        }
    ];


    public DrugDeliveryActionGridColumns = [
        {
            caption: ' ',
            dataField: 'ObjectID',
            cellTemplate: 'buttonCellTemplate',
            visible: false,
            allowEditing: false,
            width: 50
        },
        {
            caption: i18n("M18550", "İlaç Adı"),
            dataField: 'drugName',
            allowEditing: false,
            width: 300
        },
        {
            caption: 'Miktar',
            dataField: 'amount',
            allowEditing: false,
            width: 120
        },
        {
            caption: 'İade Miktarı',
            dataField: 'returnAmount',
            allowEditing: false,
            visible: false,
            width: 120
        },
        {
            caption: "İlaç Uygulama Tarihi",
            dataField: 'transactionDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: "İlaç Uygulama Saati",
            dataField: 'transactionDate',
            dataType: 'date',
            format: "shortTime",
            allowEditing: false,
            width: 'auto'
        },
        {
            caption:"Durumu",
            dataField: 'status',
            allowEditing: false,
            width: 'auto'
        }
    ];
    public HalfDoseGridColumns = [
        {
            caption: ' ',
            dataField: 'ObjectID',
            cellTemplate: 'buttonCellTemplate',
            visible: false,
            allowEditing: false,
            width: 50
        },
        {
            caption: "İlaç Uygulama Saati",
            dataField: 'drugOrderDetail.OrderPlannedDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: false,
            width: 150
        },
        {
            caption: "İlaç Adı",
            dataField: 'drugName',
            allowEditing: false,
            width: 300
        },
        {
            caption: 'Miktar',
            dataField: 'amount',
            allowEditing: false,
            width: 120
        },
        {
            caption:  "Birim",
            dataField: 'unitName',
            allowEditing: false,
            width: 200
        },

    ];
    
    public async setInputParam(value: Object) {
        let getVal:GetDrugReturnAndDeliveryDetails = <GetDrugReturnAndDeliveryDetails>value;
        this.drugReturnActionDataSource = getVal.getDrugReturnAndDeliveryDetails;
        if(this.drugReturnActionDataSource != null )
            this.drugReturnActionDataSource = this.drugReturnActionDataSource.filter(x=>x.isReturnable == true);
        this.drugDeliveryActionDataSource = getVal.getDrugReturnAndDeliveryDetails;
        this.halfDoseDestructionDataSource = getVal.halfDoseDestructionDVOs;
        this.MasterResource = getVal.MasterResource;
        this.SecondaryMasterResource = getVal.SecondaryMasterResource;
        this.Episode = getVal.Episode;
        this.SubEpisode = getVal.SubEpisode;
    }

    public setModalInfo(value: ModalInfo) {
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    public okClick(): void {
    }

  

    public returnValueOf : GetDrugReturnAndDeliveryDetails =  new GetDrugReturnAndDeliveryDetails();
    public drugReturnActionClick(){

        if(this.textIadeNedeni == ""){
            ServiceLocator.MessageService.showError("İade nedeni boş geçilemez.");
        }

        if (this.selectedReturnActionItems != null) {
            if(this.selectedReturnActionItems.length > 0 && String.isNullOrEmpty(this.textIadeNedeni) == false){
                let that = this;
                let inputDvo = new DrugReturnActionCreate_Input();
                inputDvo.getDrugReturnAndDeliveryDetail = new GetDrugReturnAndDeliveryDetails();
                inputDvo.getDrugReturnAndDeliveryDetail.SelectedDrugReturnAndDeliveryDetails = this.selectedReturnActionItems;
                inputDvo.getDrugReturnAndDeliveryDetail.Episode = this.Episode;
                inputDvo.getDrugReturnAndDeliveryDetail.MasterResource = this.MasterResource;
                inputDvo.getDrugReturnAndDeliveryDetail.SecondaryMasterResource = this.SecondaryMasterResource;
                inputDvo.getDrugReturnAndDeliveryDetail.SubEpisode = this.SubEpisode;
                inputDvo.getDrugReturnAndDeliveryDetail.getDrugReturnAndDeliveryDetails = this.drugReturnActionDataSource;
                inputDvo.txtIadeNedeni = this.textIadeNedeni;
                try {
                    let fullApiUrl: string = '/api/DrugReturnActionService/CreateDrugReturnAction';
                    this.http.post(fullApiUrl, inputDvo)
                        .then((result) => {
                            ServiceLocator.MessageService.showSuccess("İade işlemi başlatıldı.");
                            this.returnValueOf = result as GetDrugReturnAndDeliveryDetails;
                            this.drugReturnActionDataSource = this.returnValueOf.getDrugReturnAndDeliveryDetails;
                            this.selectedReturnActionItems = new Array<GetReturnableDrugOrderDetails_Output>();
                            this.drugDeliveryActionDataSource = this.returnValueOf.getDrugReturnAndDeliveryDetails;
                            this.textIadeNedeni ="";
                        })
                        .catch(error => {
                        });
                }
                catch (ex) {
                }
            }
        }
    }
    
    public drugDeliveryActionClick(){
        if (this.selectedDeliveryActionItems != null) {
            if(this.selectedDeliveryActionItems.length > 0 ){
                let that = this;
                let inputDvo = new DrugReturnActionCreate_Input();
                inputDvo.getDrugReturnAndDeliveryDetail = new GetDrugReturnAndDeliveryDetails();
                inputDvo.getDrugReturnAndDeliveryDetail.SelectedDrugReturnAndDeliveryDetails = this.selectedDeliveryActionItems;
                inputDvo.getDrugReturnAndDeliveryDetail.Episode = this.Episode;
                inputDvo.getDrugReturnAndDeliveryDetail.MasterResource = this.MasterResource;
                inputDvo.getDrugReturnAndDeliveryDetail.SecondaryMasterResource = this.SecondaryMasterResource;
                inputDvo.getDrugReturnAndDeliveryDetail.SubEpisode = this.SubEpisode;
                inputDvo.getDrugReturnAndDeliveryDetail.getDrugReturnAndDeliveryDetails = this.drugReturnActionDataSource;
                try {
                    let fullApiUrl: string = '/api/DrugReturnActionService/CreateDrugDeliveryAction';
                    this.http.post(fullApiUrl, inputDvo)
                        .then((result) => {
                            ServiceLocator.MessageService.showSuccess("Hastaya / Hasta Yakınına teslim edildi.");
                            this.returnValueOf = result as GetDrugReturnAndDeliveryDetails;
                            this.drugDeliveryActionDataSource = this.returnValueOf.getDrugReturnAndDeliveryDetails;
                            this.selectedDeliveryActionItems = new Array<GetReturnableDrugOrderDetails_Output>();
                        })
                        .catch(error => {
                        });
                }
                catch (ex) {
                }
            }
        }
    }

    public CreateHalfDoseDestruction(){



        if (this.selectedhalfDoseDestructionDVO != null) {
            if(this.selectedhalfDoseDestructionDVO.length > 0 ){
                let that = this;
                let inputDvo = new CreateHalfDoseDestruction_Input();
                inputDvo.episodeID = this.Episode;
                inputDvo.subEpisodeID = this.SubEpisode;
                inputDvo.masterResourceID = this.MasterResource;
                inputDvo.secondaryMasterResourceID = this.SecondaryMasterResource;
                inputDvo.halfDoseDestructionDetails = new Array<HalfDoseDestructionDVO>();
                inputDvo.halfDoseDestructionDetails = this.selectedhalfDoseDestructionDVO;
                try {
                    let fullApiUrl: string = '/api/DrugReturnActionService/CreateHalfDoseDestruction';
                    this.http.post(fullApiUrl, inputDvo)
                        .then((result) => {
                            ServiceLocator.MessageService.showSuccess("İmha işlemi Eczaneye gönderildi.");
                            let output  = result as CreateHalfDoseDestruction_Output;
                            this.halfDoseDestructionDataSource = output.halfDoseDestructionDVOs;
                            const objectIdParam = new GuidParam(output.objectID);
                            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                            this.reportService.showReport('HalfDoseReport', reportParameters);
                            this.selectedhalfDoseDestructionDVO = new Array<HalfDoseDestructionDVO>();
                        })
                        .catch(error => {
                        });
                }
                catch (ex) {
                }
            }
        }
    }

    public getWaitingPharmacy(){
        this.loadingVisibleWDS = true;
        try {
            let that = this;
            let inputDvo = new GetWaitingPharmacy_Input();
            inputDvo.episode = this.Episode;
            inputDvo.subepisode = this.SubEpisode;
            let fullApiUrl: string = '/api/DrugReturnActionService/GetWaitingPharmacy';
            this.http.post(fullApiUrl, inputDvo)
                .then((result) => {
                    this.pharmacyWaitingDataSouce = result as Array<GetWaitingPharmacy_Output>;
                    this.loadingVisibleWDS = false;
                })
                .catch(error => {
                    this.loadingVisibleWDS = false;
                });
        }
        catch (ex) {
            this.loadingVisibleWDS = false;
        }
    }

    public getComplatedPharmacy(){
        this.loadingVisibleCDS = true;
        try {
            let that = this;
            let inputDvo = new GetWaitingPharmacy_Input();
            inputDvo.episode = this.Episode;
            inputDvo.subepisode = this.SubEpisode;
            let fullApiUrl: string = '/api/DrugReturnActionService/GetComplatedPharmacy';
            this.http.post(fullApiUrl, inputDvo)
                .then((result) => {
                    this.pharmacyComplatedDataSouce = result as Array<GetComplatedPharmacy_Output>;
                    this.loadingVisibleCDS = false;
                })
                .catch(error => {
                    this.loadingVisibleCDS = false;
                });
        }
        catch (ex) {
            this.loadingVisibleCDS = false;
        }
    }

    async onValueChanged($event) {
        if ('Eczaneye İlaç İade' === $event.value) {
            this.ilacIade = true;
            this.hastayaTeslim = false;
            this.yarimDoseImha = false;
            this.eczaneBekleyen = false;
            this.eczaneTamamlanan = false;
            this.selectedDeliveryActionItems = new Array<GetReturnableDrugOrderDetails_Output>();
        }
        else if ('Hastaya Teslim' === $event.value) {
            this.ilacIade = false;
            this.hastayaTeslim = true;
            this.yarimDoseImha = false;
            this.eczaneBekleyen = false;
            this.eczaneTamamlanan = false;
            this.selectedReturnActionItems = new Array<GetReturnableDrugOrderDetails_Output>();
        }
        else if ('Yarım Doz İmha' === $event.value) {
            this.ilacIade = false;
            this.hastayaTeslim = false;
            this.yarimDoseImha = true;
            this.eczaneBekleyen = false;
            this.eczaneTamamlanan = false;
            this.selectedReturnActionItems = new Array<GetReturnableDrugOrderDetails_Output>();
        }
        else if ('Eczanede Bekleyen İade İşlemleri' === $event.value) {
            this.ilacIade = false;
            this.hastayaTeslim = false;
            this.yarimDoseImha = false;
            this.eczaneBekleyen = true;
            this.eczaneTamamlanan = false;
            this.selectedReturnActionItems = new Array<GetReturnableDrugOrderDetails_Output>();
            this.selectedDeliveryActionItems = new Array<GetReturnableDrugOrderDetails_Output>();
            this.getWaitingPharmacy();
        }
        else if ('Tamamlanan İade İşlemleri' === $event.value) {
            this.ilacIade = false;
            this.hastayaTeslim = false;
            this.yarimDoseImha = false;
            this.eczaneBekleyen = false;
            this.eczaneTamamlanan = true;
            this.selectedReturnActionItems = new Array<GetReturnableDrugOrderDetails_Output>();
            this.selectedDeliveryActionItems = new Array<GetReturnableDrugOrderDetails_Output>();
            this.getComplatedPharmacy();
        }
        
    }

}