//$51CD9FC5
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MeicalWasteFormViewModel } from './MeicalWasteFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { MedicalWaste, InpatientAdmission, ResBed, UsedStatusEnum, ResWard, MedicalWasteContainerDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalWasteProduceDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalWasteTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from "app/NebulaClient/Mscorlib/GuidParam";
import { DateParam } from "app/NebulaClient/Mscorlib/DateParam";
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { BedSelectionFormViewModel, BedSelectionForm_InputParam, SelectedBedViewModel } from '../Yatan_Hasta_Modulu/BedSelectionFormViewModel';
import { BedProperties, RoomProperties, ArrayClass } from '../Yatan_Hasta_Modulu/BedSelectionForm';
import { ResWardService } from 'app/NebulaClient/Services/ObjectService/ResWardService';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';

@Component({
    selector: 'MeicalWasteForm',
    templateUrl: './MeicalWasteForm.html',
    providers: [MessageService]
})
export class MeicalWasteForm extends TTVisual.TTForm implements OnInit {
    Amount: TTVisual.ITTTextBox;
    labelAmount: TTVisual.ITTLabel;
    labelMedicalWasteProduce: TTVisual.ITTLabel;
    labelMedicalWasteType: TTVisual.ITTLabel;
    labelTransactionDate: TTVisual.ITTLabel;
    MedicalWasteProduce: TTVisual.ITTObjectListBox;
    MedicalWasteType: TTVisual.ITTObjectListBox;
    TransactionDate: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;

    ttobjectlistbox2: TTVisual.ITTObjectListBox;

    ttobjectlistbox3: TTVisual.TTObjectListBox;
    ttvaluelistbox1: TTVisual.ITTValueListBox;
    StartDate: Date;
    EndDate: Date;
    SelectedResource: any;
    SelectedMedicalWasteType: any;
    SelectedResourceID: Guid;
    SelectedMedicalWasteTypeID: Guid;
    Resources: any;
    ContainerForMedicalWaste: any;

    public meicalWasteFormViewModel: MeicalWasteFormViewModel = new MeicalWasteFormViewModel();
    public get _MedicalWaste(): MedicalWaste {
        return this._TTObject as MedicalWaste;
    }
    private MeicalWasteForm_DocumentUrl: string = '/api/MedicalWasteService/MeicalWasteForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected reportService: AtlasReportService, ) {
        super('MEDICALWASTE', 'MeicalWasteForm');
        this._DocumentServiceUrl = this.MeicalWasteForm_DocumentUrl;
        this.EndDate = new Date();
        this.EndDate.setHours(23, 59, 59, 0);
        this.StartDate = new Date();
        this.StartDate.setHours(0, 0, 0, 0);
        this.Resources = new Array<any>();
        this.initViewModel();
        this.initFormControls();
        this.getPhysicalStateClinicList();
    }


    GetResources() {
        let apiUrl: string = '/api/MedicalWasteService/GetResSections';
        this.httpService.post<any>(apiUrl, null).then(
            x => {
                this.Resources = x;
            });
        }

    public onttvaluelistbox1Changed(event): void {
        if (event != null) {
            if (this._MedicalWaste != null) {
                this.meicalWasteFormViewModel.Container = event;
            }
        }
        else
            this.meicalWasteFormViewModel.Container = null;
    }
    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MedicalWaste();
        this.meicalWasteFormViewModel = new MeicalWasteFormViewModel();
        this._ViewModel = this.meicalWasteFormViewModel;
        this.meicalWasteFormViewModel._MedicalWaste = this._TTObject as MedicalWaste;
        this.meicalWasteFormViewModel._MedicalWaste.MedicalWasteProduce = new MedicalWasteProduceDefinition();
        this.meicalWasteFormViewModel._MedicalWaste.MedicalWasteType = new MedicalWasteTypeDefinition();
        this.meicalWasteFormViewModel._MedicalWaste.ResSection = new ResSection();
        this.SelectedResource = new ResSection();
        this.SelectedMedicalWasteType = new MedicalWasteTypeDefinition();
        this.getDefaultContainer();
    }

    protected loadViewModel() {
        let that = this;
        that.meicalWasteFormViewModel = this._ViewModel as MeicalWasteFormViewModel;
        that._TTObject = this.meicalWasteFormViewModel._MedicalWaste;
        if (this.meicalWasteFormViewModel == null)
            this.meicalWasteFormViewModel = new MeicalWasteFormViewModel();
        if (this.meicalWasteFormViewModel._MedicalWaste == null)
            this.meicalWasteFormViewModel._MedicalWaste = new MedicalWaste();
        let medicalWasteProduceObjectID = that.meicalWasteFormViewModel._MedicalWaste["MedicalWasteProduce"];
        if (medicalWasteProduceObjectID != null && (typeof medicalWasteProduceObjectID === "string")) {
            let medicalWasteProduce = that.meicalWasteFormViewModel.MedicalWasteProduceDefinitions.find(o => o.ObjectID.toString() === medicalWasteProduceObjectID.toString());
            if (medicalWasteProduce) {
                that.meicalWasteFormViewModel._MedicalWaste.MedicalWasteProduce = medicalWasteProduce;
            }
        }
        let medicalWasteTypeObjectID = that.meicalWasteFormViewModel._MedicalWaste["MedicalWasteType"];
        if (medicalWasteTypeObjectID != null && (typeof medicalWasteTypeObjectID === "string")) {
            let medicalWasteType = that.meicalWasteFormViewModel.MedicalWasteTypeDefinitions.find(o => o.ObjectID.toString() === medicalWasteTypeObjectID.toString());
            if (medicalWasteType) {
                that.meicalWasteFormViewModel._MedicalWaste.MedicalWasteType = medicalWasteType;
            }
        }
        let resSectionObjectID = that.meicalWasteFormViewModel._MedicalWaste["ResSection"];
        if (resSectionObjectID != null && (typeof resSectionObjectID === "string")) {
            let resSection = that.meicalWasteFormViewModel.ResSections.find(o => o.ObjectID.toString() === resSectionObjectID.toString());
            if (resSection) {
                that.meicalWasteFormViewModel._MedicalWaste.ResSection = resSection;
            }
        }
        
         this._MedicalWaste.TransactionDate = new Date();

    }

    RowRemoving(data) {
        if (data.key.DeliveryDate == null) {
            let that = this;
            let apiUrl: string = '/api/MedicalWasteService/DeleteSelectedMedicalWaste?id=' + data.key.ObjectID.toString();
            this.httpService.get<any>(apiUrl).then(
                x => {
                    that.GetGridDataSource();
                });
        }
        else {
            this.messageService.showError("Atık firmaya teslim edilmiştir. Silemezsiniz!");
            this.GetGridDataSource();
        }
    }
    public async save() {
        
        if (this.meicalWasteFormViewModel._MedicalWaste.Amount != null && this.meicalWasteFormViewModel._MedicalWaste.Amount > 0 && this.meicalWasteFormViewModel.Container!=null) {
            let res = await this.httpService.post<boolean>('/api/MedicalWasteService/CheckContainerCapacity', { ContainerID: this.meicalWasteFormViewModel.Container.ObjectID, Amount: this.meicalWasteFormViewModel._MedicalWaste.Amount });
            if (res) {
                await super.save();
                this.GetGridDataSource();
            }
            else {
                let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("", "Kapasite aşımı"), i18n("", "Kayıt yapmakta olduğunuz konteynerin yeterli kapasitesi bulunmamaktadır!\r\n\r\n Yine de devam etmek istiyor musunuz?"));
                if (messageResult === "E") {
                    await super.save();
                    this.GetGridDataSource();
                } 
            }
        }
        else
        this.messageService.showError("İşleme devam edebilmek için Tehlikeli atık deposu seçmelisiniz ve miktar girmelisiniz!");
    }

    select(data) {
        let that = this;
        if (data.selectedRowKeys.length > 0) {
            let apiUrl: string = '/api/MedicalWasteService/MeicalWasteForm?id=' + data.selectedRowKeys[data.selectedRowKeys.length - 1].ObjectID.toString();
            this.httpService.get<any>(apiUrl).then(
                x => {
                    this._ViewModel = x;
                    that.loadViewModel();
                });
            this.selectedItems = new Array<Guid>();
            for (let item of data.selectedRowKeys) {
                this.selectedItems.push(item.ObjectID);
            }
        }
    }
    selectedItems: Array<Guid> = new Array<Guid>();
    public medicalWasteDeliveryDate: Date = new Date();
    SetDeliveryDate() {
        let that = this;
        let apiUrl: string = '/api/MedicalWasteService/SetDeliveryDate';
        let params: SetDeliveryDateInput = new SetDeliveryDateInput();
        params.selectedMedicalWasteList = this.selectedItems;
        params.deliveryDate = this.medicalWasteDeliveryDate;
        this.httpService.post<void>(apiUrl, params).then(
            x => {
                that.GetGridDataSource();
            });
    }
    public MedicalWasteColumns = [
        {
            'caption': i18n("M10051", 'Tarih'),
            dataField: 'TransactionDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
        },
        {
            caption: i18n("M11073", 'Ürün'),
            dataField: 'Medicalwasteproduce',
        },
        {
            'caption': i18n("M23460", "Tip"),
            dataField: 'Medicalwastetype',
        },
        {
            'caption': i18n("M11851", 'Birim'),
            dataField: 'Ressection',
            width: 300

        }
        ,
        {
            'caption': i18n("M19030", "Miktar"),
            dataField: 'Amount',
        }
        ,
        {
            'caption': "Firmaya Teslim Tarihi",
            dataField: 'DeliveryDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: 150
        },
        {
            'caption': "Atık Deposu",
            dataField: 'Containername',
        }
    ];

    public SelectedMedicalWasteColumns = [
        {
            'caption': i18n("M10051", 'Tarih'),
            dataField: 'TransactionDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
        },
        {
            caption: i18n("M11073", 'Ürün'),
            dataField: 'Medicalwasteproduce',
        },
        {
            'caption': i18n("M23460", "Tip"),
            dataField: 'Medicalwastetype',
        },
        {
            'caption': i18n("M11851", 'Birim'),
            dataField: 'Ressection',
            width: 300
        }
        ,
        {
            'caption': i18n("M19030", "Miktar"),
            dataField: 'Amount',
        }
        ,
        {
            'caption': "Atık Deposu",
            dataField: 'Containername',
        }
    ];
    GridDataSource: any;
    SelectedMedicalWasteDataSource: any;
    async ngOnInit() {
        await this.load();
        this.GetGridDataSource();
        // this.GetResources();
      
    }

     
    getDefaultContainer() {
        let apiUrl: string = '/api/MedicalWasteService/GetContainers';
        this.httpService.post<any>(apiUrl, null).then(
            x => {
                this.meicalWasteFormViewModel.Container = x;
            });
    }

    CreateReport() {
        const ResourceId = new GuidParam(this.SelectedResourceID);
        const MedicalWasteTypeID = new GuidParam(this.SelectedMedicalWasteTypeID);
        const StartDate = new DateParam(this.StartDate);
        const EndDate = new DateParam(this.EndDate);
        let reportParameters: any = { 'RESOURCEID': ResourceId, 'STARTDATE': StartDate, 'ENDDATE': EndDate, 'MEDICALWASTETYPEID': MedicalWasteTypeID };
        this.reportService.showReport('MedicalWasteListReport', reportParameters);

    }

    GetGridDataSource() {
        let apiUrl: string = '/api/MedicalWasteService/GetAllMedicalWaste';
        this.httpService.post<any>(apiUrl, null).then(
            x => {
                this.GridDataSource = x;
            });
    }

    ListSelectedMedicalWate() {
        let param: InputParam = new InputParam();
        param.ResourceId = this.SelectedResourceID;
        param.MedicalWasteTypeID = this.SelectedMedicalWasteTypeID;
        param.StartDate = this.StartDate;
        param.EndDate = this.EndDate;
        let apiUrl: string = '/api/MedicalWasteService/GetSelectedMedicalWaste';
        this.httpService.post<any>(apiUrl, param).then(
            x => {
                this.SelectedMedicalWasteDataSource = x;
            });
    }

    public onAmountChanged(event): void {
        if (event != null) {
            if (this._MedicalWaste != null && this._MedicalWaste.Amount != event) {
                this._MedicalWaste.Amount = event;
            }
        }
    }

    public onMedicalWasteProduceChanged(event): void {
        if (event != null) {
            if (this._MedicalWaste != null && this._MedicalWaste.MedicalWasteProduce != event) {
                this._MedicalWaste.MedicalWasteProduce = event;
            }
        }
    }

    public onMedicalWasteTypeChanged(event): void {
        if (event != null) {
            if (this._MedicalWaste != null && this._MedicalWaste.MedicalWasteType != event) {
                this._MedicalWaste.MedicalWasteType = event;
                this.MedicalWasteProduce.ListFilterExpression = "MEDICALWASTETYPE = '" + event.ObjectID + "'";
            } else
                this.MedicalWasteProduce.ListFilterExpression = "";
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._MedicalWaste != null && this._MedicalWaste.TransactionDate != event) {
                this._MedicalWaste.TransactionDate = event;
            }
        }
    }

    public onttobjectlistbox1Changed(event): void {
        if (event != null) {
            if (this._MedicalWaste != null && this._MedicalWaste.ResSection != event) {
                this._MedicalWaste.ResSection = event;
            }
        }
    }

    public onttobjectlistbox2Changed(event): void {
        if (event != null) {
            this.SelectedResourceID = event.ObjectID;
        }
        else
            this.SelectedResourceID = Guid.Empty;
    }

    public onttobjectlistbox3Changed(event): void {
        if (event != null) {
            this.SelectedMedicalWasteTypeID = event.ObjectID;
        }
        else
            this.SelectedMedicalWasteTypeID = Guid.Empty;
    }

    public showPopupForBedSelection: boolean = false;
    public btnOpenBedSelectionPopupInfo_Click() {
        this.showPopupForBedSelection = true;
    }
    public showBedSelectionPopup: boolean = false;
    btnOpenBedSelectionPopup_Click() {
        this.showBedSelectionPopup = true;
        this.getBedSelectionFormViewModel();
    }


    public pieDataSource: any;
    public isCleaningModuleActive: boolean;
    public bedSelectionFormViewModel: BedSelectionFormViewModel = new BedSelectionFormViewModel();
    private BedSelectionForm_DocumentUrl: string = '/api/BedSelectionFormService/';
    public getBedSelectionFormViewModel() {
        let that = this;
        let inputparam: BedSelectionForm_InputParam = new BedSelectionForm_InputParam();
        inputparam.selectedPhysicalStateClinic = this.bedSelectionFormViewModel.selectedPhysicalStateClinic;
        inputparam.isOnlyEmptyBeds = this.bedSelectionFormViewModel.isOnlyEmptyBeds == null ? false : this.bedSelectionFormViewModel.isOnlyEmptyBeds;
        this.httpService.post<BedSelectionFormViewModel>(this.BedSelectionForm_DocumentUrl + "BedSelectionForm", inputparam)
            .then(response => {
                let result: any = response;
                this.bedSelectionFormViewModel.BedsPropertysByResWardList = result.BedsPropertysByResWardList;
                this.bedSelectionFormViewModel.emptyBeds = result.emptyBeds;
                this.bedSelectionFormViewModel.usedBedsMan = result.usedBedsMan;
                this.bedSelectionFormViewModel.usedBedsWoman = result.usedBedsWoman;
                this.bedSelectionFormViewModel.cleaningStatusBeds = result.cleaningStatusBeds;
                this.bedSelectionFormViewModel.reservedToUseMan = result.reservedToUseMan;
                this.bedSelectionFormViewModel.reservedToUseWoman = result.reservedToUseWoman;
                that.arrangeRoomPropertiesList(this.bedSelectionFormViewModel.BedsPropertysByResWardList);

                if (this.isCleaningModuleActive == false) {
                    this.bedSelectionFormViewModel.emptyBeds = this.bedSelectionFormViewModel.emptyBeds + this.bedSelectionFormViewModel.cleaningStatusBeds;
                }
                this.pieDataSource =
                    [
                        {
                            "id": 1,
                            "arg": "Yatışa Uygun",
                            "val": this.bedSelectionFormViewModel.emptyBeds

                        },
                        {
                            "id": 2,
                            "arg": "Dolu Yatak (Kadın)",
                            "val": this.bedSelectionFormViewModel.usedBedsWoman
                        },
                        {
                            "id": 3,
                            "arg": "Dolu Yatak (Erkek)",
                            "val": this.bedSelectionFormViewModel.usedBedsMan
                        },
                        {
                            "id": 4,
                            "arg": "İzole Yatak",
                            "val": this.bedSelectionFormViewModel.isolatedBed
                        },
                        {
                            "id": 5,
                            "arg": "Temizlenecek + Temizleniyor",
                            "val": this.bedSelectionFormViewModel.cleaningStatusBeds
                        },
                        {
                            "id": 6,
                            "arg": "Rezerve Yatak (Kadın)",
                            "val": this.bedSelectionFormViewModel.reservedToUseWoman
                        },
                        {
                            "id": 7,
                            "arg": "Rezerve Yatak (Erkek)",
                            "val": this.bedSelectionFormViewModel.reservedToUseMan
                        }
                    ]
            })
            .catch(error => {
                console.log(error);
            });
    }
    public firstChoice: Guid;
    public roomPropertiesList: Array<RoomProperties> = new Array<RoomProperties>();
    public tempRoomPropertiesList: ArrayClass = new ArrayClass();
    public rowList: Array<ArrayClass> = new Array<ArrayClass>();
    public arrangeRoomPropertiesList(BedsPropertysByResWardList: Array<ResBed.GetBedsPropertysByResWard_Class>) {
        this.roomPropertiesList = new Array<RoomProperties>();
        let selected: boolean = false;
        let lastRoom: RoomProperties = null;
        for (let BedsPropertys of BedsPropertysByResWardList) {
            if (lastRoom == null || lastRoom.RoomObjectId != BedsPropertys.Roomobjectid) {
                let roomProperties: RoomProperties = new RoomProperties();
                roomProperties.RoomObjectId = BedsPropertys.Roomobjectid;
                roomProperties.RoomName = BedsPropertys.Roomname;
                roomProperties.BedPropertiesList = new Array<BedProperties>();
                this.roomPropertiesList.push(roomProperties);
                let fullBedOfRoom = BedsPropertysByResWardList.find(dr => dr.Roomobjectid == roomProperties.RoomObjectId && dr.Sex != null);
                if (fullBedOfRoom == null)
                    roomProperties.Sex = null;
                else
                    roomProperties.Sex = fullBedOfRoom.Sex;

                let isolatedRoom = BedsPropertysByResWardList.find(bed => bed.Roomobjectid == roomProperties.RoomObjectId && (bed.HasAirborneContactIsolation == true || bed.HasContactIsolation == true || bed.HasDropletIsolation == true || bed.HasTightContactIsolation == true))
                if (isolatedRoom == null) {
                    roomProperties.IsIsolated = false;
                }
                else {
                    roomProperties.IsIsolated = true;
                    this.bedSelectionFormViewModel.isolatedRoom += 1;
                }

                lastRoom = roomProperties;

            }
            let bedProperties: BedProperties = new BedProperties();
            bedProperties.BedName = BedsPropertys.Bedname;
            bedProperties.BedObjectId = BedsPropertys.Bedobjectid;
            bedProperties.HasFallingRisk = BedsPropertys.HasFallingRisk;
            bedProperties.HasAirborneContactIsolation = BedsPropertys.HasAirborneContactIsolation;
            bedProperties.HasDropletIsolation = BedsPropertys.HasDropletIsolation;
            bedProperties.HasContactIsolation = BedsPropertys.HasContactIsolation;
            bedProperties.HasTightContactIsolation = BedsPropertys.HasTightContactIsolation;
            bedProperties.Sex = BedsPropertys.Sex;
            bedProperties.UsedSatus = BedsPropertys.Usedstatus;
            bedProperties.PatientName = BedsPropertys.Patientname;
            bedProperties.PatientSurname = BedsPropertys.Patientsurname;
            bedProperties.isClean = BedsPropertys.IsClean;


            lastRoom.BedPropertiesList.push(bedProperties);

        }
        this.bedSelectionFormViewModel.isolatedBed = 0;
        this.roomPropertiesList.forEach(room => {
            if (room.IsIsolated == true) {

                room.BedPropertiesList.forEach(bed => {
                    this.bedSelectionFormViewModel.isolatedBed += 1;
                })
            }
        });

        this.tempRoomPropertiesList = new ArrayClass();
        this.rowList = new Array<ArrayClass>();
        let i = 0;
        this.roomPropertiesList.forEach(room => {
            if (i != 12) {
                this.tempRoomPropertiesList.tempArray.push(room);
                i++;
            }
            else {
                this.rowList.push(this.tempRoomPropertiesList);
                this.tempRoomPropertiesList = new ArrayClass();
                i = 0;
            }
        });

        if (this.tempRoomPropertiesList.tempArray.length > 0) {
            this.rowList.push(this.tempRoomPropertiesList);
        }

    }
    public physicalStateClinicList: any;
    public selectedPhysicalClinicObjectId: string;
    private async getPhysicalStateClinicList() {

        let that = this;
        this.httpService.get<ResSection.GetAllResWardListWithEmtyBedCount_Class>(this.BedSelectionForm_DocumentUrl + "GetAllResWardListWithEmtyBedCount")
            .then(response => {
                this.physicalStateClinicList = response;
            })
            .catch(error => {
                console.log(error);
            });
    }
    @Input() set selectedPhysicalStateClinic(value: ResWard) {

        this.bedSelectionFormViewModel.selectedPhysicalStateClinic = value;

        if (value != null && value.ObjectID != null) {
            this.selectedPhysicalClinicObjectId = value.ObjectID.toString();

        }
        else {
            this.selectedPhysicalClinicObjectId = null;
        }
    }
    @Output() sendSelectedPhysicalStateClinic: EventEmitter<ResWard> = new EventEmitter<ResWard>();
    async PhysicalStateChanged(val: any) {
        if (val != null && val.value != null) {
            // this.physicalStateClinicHasEmptyBed = val.
            let arr = await ResWardService.GetByID(val.value);
            if (arr.length > 0) {
                this.bedSelectionFormViewModel.selectedPhysicalStateClinic = arr[0];
                this.selectedPhysicalStateClinic = arr[0];
                this.sendSelectedPhysicalStateClinic.emit(this.selectedPhysicalStateClinic);
            }
        }
        else {
            this.sendSelectedPhysicalStateClinic.emit(null);
        }

    }
    GetRoomStyle(roomProperties: RoomProperties, bedProperties: BedProperties) {
        let textAlign: any = 'center';

        if (bedProperties.HasAirborneContactIsolation || bedProperties.HasContactIsolation || bedProperties.HasDropletIsolation || bedProperties.HasFallingRisk || bedProperties.HasTightContactIsolation) {
            textAlign = 'right';
        }

        if (roomProperties.IsIsolated == true) {
            return {
                'background-color': '#f7d06a',
                'border-bottom': 'black',
                'border-bottom-style': 'groove',
                'border-bottom-width': '1px',
                'text-align': textAlign,
            };

        }

        else {

            return {
                'border-bottom': 'black',
                'border-bottom-style': 'groove',
                'border-bottom-width': '1px',
                'text-align': textAlign
            };
        }

    }

    GetStyleForBackground(bedProperties: BedProperties) {
        if (bedProperties.isClean == false && bedProperties.UsedSatus.toString() == UsedStatusEnum.NotUsed.toString()) {
            return {
                'background-color': '#808080',
                'margin-bottom': '0'
            };
        }

        else {
            return {
                'margin-bottom': '0'
            };
        }
    }
    GetHint(bedProperties: BedProperties) {
        if (bedProperties != null && bedProperties.PatientName != null && bedProperties.PatientSurname != null)
            return bedProperties.BedName + " - " + bedProperties.PatientName + " " + bedProperties.PatientSurname;
        else
            return bedProperties.BedName;

    }
    GetBedStyle(bedProperties: BedProperties) {
        let color: any = 'black'; //koyu gri
        let marginleft: any = '23px';
        let backgroundColor: any = 'white';
        if (bedProperties.UsedSatus.toString() == UsedStatusEnum.Used.toString()) {
            if (bedProperties.Sex == '1') {
                color = '#2da0e6';
            }
            else if (bedProperties.Sex == '2') {
                color = '#fd6b85';
            }
            /*    else if (bedProperties.Sex == null) {
                    color = 'black';
                }*/
        }
        else if (bedProperties.UsedSatus.toString() == UsedStatusEnum.ReservedToUse.toString()) {
            if (bedProperties.Sex == '1') {
                color = '#84bacc';
            }
            else if (bedProperties.Sex == '2') {
                color = '#daa6ad';
            }
            /*   else if (bedProperties.Sex == null) {
                   color = 'black';
               } */
        }
        if (bedProperties.HasAirborneContactIsolation || bedProperties.HasContactIsolation || bedProperties.HasDropletIsolation || bedProperties.HasFallingRisk || bedProperties.HasTightContactIsolation) {
            marginleft = '0px';
        }

        return {
            'color': color
            /*            'padding-right': '20px',
                        'margin-left': marginleft*/
        };

    }
    protected redirectProperties(): void {
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.Amount, "Text", this.__ttObject, "Amount");
    }

    public initFormControls(): void {
        this.labelMedicalWasteProduce = new TTVisual.TTLabel();
        this.labelMedicalWasteProduce.Text = i18n("M23970", "Ürün Adı");
        this.labelMedicalWasteProduce.Name = "labelMedicalWasteProduce";
        this.labelMedicalWasteProduce.TabIndex = 11;

        this.MedicalWasteProduce = new TTVisual.TTObjectListBox();
        this.MedicalWasteProduce.LinkedControlName = "MedicalWasteType";
        this.MedicalWasteProduce.ListDefName = "MedicalWasteProduceListDefinition";
        this.MedicalWasteProduce.Name = "MedicalWasteProduce";
        this.MedicalWasteProduce.TabIndex = 10;

        this.labelMedicalWasteType = new TTVisual.TTLabel();
        this.labelMedicalWasteType.Text = i18n("M16895", "İşlem Türü");
        this.labelMedicalWasteType.Name = "labelMedicalWasteType";
        this.labelMedicalWasteType.TabIndex = 5;

        this.MedicalWasteType = new TTVisual.TTObjectListBox();
        this.MedicalWasteType.ListDefName = "MedicalWasteTypeListDefinition";
        this.MedicalWasteType.Name = "MedicalWasteType";
        this.MedicalWasteType.TabIndex = 4;

        this.labelAmount = new TTVisual.TTLabel();
        this.labelAmount.Text = i18n("M19030", "Miktar");
        this.labelAmount.Name = "labelAmount";
        this.labelAmount.TabIndex = 3;

        this.Amount = new TTVisual.TTTextBox();
        this.Amount.Name = "Amount";
        this.Amount.TabIndex = 2;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 1;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 0;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ListFilterExpression = "ISMEDICALWASTE = 1";
        this.ttobjectlistbox1.ListDefName = "EnableResSectionListDefinition";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 4;

        this.ttobjectlistbox2 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox2.ListDefName = "EnableResSectionListDefinition";
        this.ttobjectlistbox2.Name = "ttobjectlistbox2";
        this.ttobjectlistbox2.TabIndex = 5;

        this.ttobjectlistbox3 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox3.ListDefName = "MedicalWasteTypeListDefinition";
        this.ttobjectlistbox3.Name = "ttobjectlistbox3";
        this.ttobjectlistbox3.TabIndex = 6;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Birim";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 5;

        this.ttvaluelistbox1 = new TTVisual.TTValueListBox();
        this.ttvaluelistbox1.ListDefName = "MedicalWasteContainerListDefinition";
        this.ttvaluelistbox1.Name = "ttvaluelistbox1";
        this.ttvaluelistbox1.TabIndex = 4;
        this.ttvaluelistbox1.ListFilterExpression="ISACTIVE = 1"
        this.ttvaluelistbox1.AutoCompleteDialogWidth = '300';

        this.Controls = [this.labelMedicalWasteProduce, this.MedicalWasteProduce, this.labelMedicalWasteType, this.MedicalWasteType, this.labelAmount, this.Amount, this.labelTransactionDate, this.TransactionDate, this.ttobjectlistbox1, this.ttobjectlistbox2, this.ttobjectlistbox3, this.ttlabel1, this.ttvaluelistbox1];

    }


}

export class SetDeliveryDateInput {
    selectedMedicalWasteList: Array<Guid> = new Array<Guid>();
    deliveryDate: Date = new Date();
}

export class InputParam {
    ResourceId: Guid;
    MedicalWasteTypeID: Guid;
    StartDate: Date = new Date();
    EndDate: Date = new Date();
}
