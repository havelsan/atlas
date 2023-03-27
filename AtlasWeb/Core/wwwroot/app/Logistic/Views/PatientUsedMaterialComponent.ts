import { Component, ViewChild } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DxDataGridComponent } from 'devextreme-angular';
import { DrugOrderInfo_Output } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderGridComponentViewModel';
import { DrugOrderTypeEnum, AntibioticTypeEnum, DrugUsageTypeEnum } from 'app/NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'patientusedmaterial-component',
    template: ` 
    <div class="row" style="padding-left: 1%;">
    <dx-tab-panel [selectedIndex]="0"  (onSelectionChanged)="tabSelectionPatient($event)">
        <dxi-item class="tabpanel-item" title="Bu Gelişe Ait İlaç / Malzemeler" style="height: 100%;">
            <br/>
            <dx-data-grid [columns]="inpatientHasDrugListColumn" [dataSource]="InpatientHasDrugList"
                [groupPanel]="{visible: true}" [filterRow]="{visible: true}"
                width="100%" height="560px"  showRowLines="true"
                [editing]="{mode: 'form' ,allowUpdating:false , allowAdding:false, allowDeleting:false}">
                <dxo-paging [pageSize]="20"></dxo-paging>
            </dx-data-grid>
        </dxi-item>
       
        <dxi-item class="tabpanel-item" title="Daha Önceki Yatışlara Ait İlaçlar / Malzemeler" style="height: 100%;">
            <br/>
            <dx-data-grid [columns]="inpatientHasDrugListColumn" [dataSource]="AllInpatientHasDrugList"
                [groupPanel]="{visible: true}" [filterRow]="{visible: true}"
                width="100%" height="560px"  showRowLines="true"
                [editing]="{mode: 'form' ,allowUpdating:false , allowAdding:false, allowDeleting:false}">
                <dxo-paging [pageSize]="20"></dxo-paging>
            </dx-data-grid>
        </dxi-item>
    </dx-tab-panel>
</div>

<dx-load-panel shadingColor="rgba(0,0,0,0.4)" [(visible)]="loadingVisible" [showIndicator]="true" [showPane]="true"
    [shading]="true" [closeOnOutsideClick]="false" [(message)]="LoadPanelMessage">
</dx-load-panel>

 `
})
export class PatientUsedMaterialComponent implements IModal {

    public componentInfo: DynamicComponentInfo;
    private _modalInfo: ModalInfo;
    patientInfo:PatientInputDTO;
    public InpatientHasDrugList: Array<InpatientHasDrugListDTO> = new Array<InpatientHasDrugListDTO>();
    public AllInpatientHasDrugList: Array<InpatientHasDrugListDTO> = new Array<InpatientHasDrugListDTO>();

    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
     
    }

    public async setInputParam(value: PatientInputDTO) {
        this.patientInfo = value as PatientInputDTO;
        this.InpatientHasFirst();
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public okClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, null);
    }

    public inpatientHasDrugListColumn = [
        {
            caption: 'Çıkış Şekli',
            dataField: 'OutStatus',
            allowEditing: false,
            width: 90,
        },
        {
            caption: "Başlangıç Tarihi",
            dataField: 'PlannedStartTime',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: false,
            sortOrder: 'asc',
            width: 110,
        },
        {
            caption: 'İlaç/Malzeme Adı',
            dataField: 'DrugName',
            allowEditing: false,
            width: 350,
        },
        {
            caption: 'Miktar',
            dataField: 'Amount',
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Doktor',
            dataField: 'DoctorName',
            allowEditing: false,
            width: 180,
        },
        {
            caption: 'Klinik',
            dataField: 'ClinikName',
            allowEditing: false,
            width: 200,
        },
        {
            caption : 'Malzeme Türü',
            dataField:'MaterialType',
            allowEditing:false,
            width:150,
        }
    ];

    InpatientHasFirst(){
        this.loadingVisible = true;
        this.LoadPanelMessage = " Hastaya Ait İlaç / Sarf Malzemeler Listeleniyor..";
        if (this.InpatientHasDrugList.length == 0) {
            let that = this;
            let inputDVO = new PatientInputDTO();
            inputDVO.SubepisodeObjectId = this.patientInfo.SubepisodeObjectId;
            inputDVO.all = false;
            let apiUrl: string = 'api/InfectionCommitteeService/GetInpatientHasDrugList';
            this.http.post<Array<InpatientHasDrugListDTO>>(apiUrl, inputDVO).then(
                result => {
                    this.InpatientHasDrugList = result;
                    this.loadingVisible = false;
                },
            ).catch(ex => {
                this.loadingVisible = false;
            });
        }
    }

    loadingVisible: boolean = false;
    LoadPanelMessage: string = "";
    tabSelectionPatient(event) {
        if (event.addedItems[0].title === "Daha Önceki Yatışlara Ait İlaçlar / Malzemeler") {
            this.loadingVisible = true;
            this.LoadPanelMessage = "Daha Önceki Yatışlara Ait İlaçlar / Sarf Malzemeler Listeleniyor..";
            if (this.AllInpatientHasDrugList.length == 0) {
                let that = this;
                let inputDVO = new PatientInputDTO();
                inputDVO.EpisodeObjectID = this.patientInfo.EpisodeObjectID;
                inputDVO.SubepisodeObjectId = this.patientInfo.SubepisodeObjectId;
                inputDVO.all = true;
                let apiUrl: string = 'api/InfectionCommitteeService/GetInpatientHasDrugList';
                this.http.post<Array<InpatientHasDrugListDTO>>(apiUrl, inputDVO).then(
                    result => {
                        this.AllInpatientHasDrugList = result;
                        this.loadingVisible = false;
                    },
                ).catch(ex => {
                    this.loadingVisible = false;
                });
            }
        }
        this.loadingVisible = false;
    }
}


export class PatientInputDTO{
    public SubepisodeObjectId:string;
    public EpisodeObjectID: string;
    public all: boolean;
    }

export class InpatientHasDrugListDTO {
    public OutStatus: string;
    public PlannedStartTime: Date;
    public PlannedEndTime: Date;
    public DrugName: string;
    public EhuStatus: string;
    public Dose: string;
    public DoseAmount: string;
    public Day: string;
    public Amount: string;
    public Desciption: string;
    public IsImmediately: boolean;
    public PatientOwnDrug: boolean;
    public CaseOfNeed: boolean;
    public TreatmentType: DrugUsageTypeEnum;
    public DoctorName: string;
    public ClinikName: string;
    public MaterialType:string;

}