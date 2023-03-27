//$78179EB7
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ArchiveRoomsDefFormViewModel, RoomModel, CabinetShelf } from './ArchiveRoomsDefFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ResArchiveRoom, ResCabinet, ResShelf } from 'NebulaClient/Model/AtlasClientModel';
import { ResBuilding } from 'NebulaClient/Model/AtlasClientModel';
import { ResBuildingWing } from 'NebulaClient/Model/AtlasClientModel';
import { ResFloor } from 'NebulaClient/Model/AtlasClientModel';


import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { List } from 'app/NebulaClient/System/Collections/List';

@Component({
    selector: 'ArchiveRoomsDefForm',
    templateUrl: 'ArchiveRoomsDefForm.html',
    providers: [MessageService]
})
export class ArchiveRoomsDefForm extends TTVisual.TTForm implements OnInit {
    ContactPhone: TTVisual.ITTTextBox;
    IsActive: TTVisual.ITTCheckBox;
    labelContactPhone: TTVisual.ITTLabel;
    labelLocation: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelResBuilding: TTVisual.ITTLabel;
    labelResBuildingWing: TTVisual.ITTLabel;
    labelResFloor: TTVisual.ITTLabel;
    Location: TTVisual.ITTTextBox;
    Name: TTVisual.ITTTextBox;
    ResBuilding: TTVisual.ITTObjectListBox;
    ResBuildingWing: TTVisual.ITTObjectListBox;
    ResFloor: TTVisual.ITTObjectListBox;
    public archiveRoomsDefFormViewModel: ArchiveRoomsDefFormViewModel = new ArchiveRoomsDefFormViewModel();
    public get _ResArchiveRoom(): ResArchiveRoom {
        return this._TTObject as ResArchiveRoom;
    }
    private ArchiveRoomsDefForm_DocumentUrl: string = '/api/ResArchiveRoomService/ArchiveRoomsDefForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super('RESARCHIVEROOM', 'ArchiveRoomsDefForm');
        this._DocumentServiceUrl = this.ArchiveRoomsDefForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public selectedCabinet: ResCabinet;
    public CabinetName: string = "";
    public CabinetActive: boolean = true;

    public ShelfName: string = "";
    public ShelfFileCapacity: number;
    public ShelfActive: boolean = true;

    public RoomGridColumns = [
        {
            caption: i18n("M19030", "Oda"),
            dataField: 'RoomName',
            dataType: 'string',
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: i18n("M19030", "Bina"),
            dataField: 'BuildingName',
            dataType: 'string',
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: i18n("M17464", "Kanat"),
            dataField: 'WingName',
            dataType: 'string',
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: i18n("M17457", "Kat"),
            dataField: 'FloorName',
            dataType: 'string',
            allowEditing: false,
            width: 'auto',

        },
        {
            caption: i18n("M17462", "Aktif"),
            dataField: 'Active',
            dataType: 'boolean',
            allowEditing: false,
            width: 'auto'
        },
    ];

    public CabinetGridColumns = [
        {
            caption: i18n("M19030", "Dolap Adı"),
            dataField: 'Name',
            dataType: 'string',
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: i18n("M17462", "Aktif"),
            dataField: 'IsActive',
            dataType: 'boolean',
            allowEditing: false,
            width: 'auto'
        }
    ];

    public ShelfGridColumns = [
        {
            caption: i18n("M19030", "Raf Adı"),
            dataField: 'ShelfName',
            dataType: 'string',
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: i18n("M19030", "Dosya Kapasitesi"),
            dataField: 'FileCapacity',
            dataType: 'number',
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: i18n("M17462", "Aktif"),
            dataField: 'Active',
            dataType: 'boolean',
            allowEditing: false,
            width: 'auto'
        }
    ];



    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ResArchiveRoom();
        this.archiveRoomsDefFormViewModel = new ArchiveRoomsDefFormViewModel();
        this._ViewModel = this.archiveRoomsDefFormViewModel;
        this.archiveRoomsDefFormViewModel._ResArchiveRoom = this._TTObject as ResArchiveRoom;
        this.archiveRoomsDefFormViewModel._ResArchiveRoom.ResFloor = new ResFloor();
        this.archiveRoomsDefFormViewModel._ResArchiveRoom.ResBuildingWing = new ResBuildingWing();
        this.archiveRoomsDefFormViewModel._ResArchiveRoom.ResBuilding = new ResBuilding();
    }

    protected loadViewModel() {
        let that = this;
        that.archiveRoomsDefFormViewModel = this._ViewModel as ArchiveRoomsDefFormViewModel;
        that._TTObject = this.archiveRoomsDefFormViewModel._ResArchiveRoom;
        if (this.archiveRoomsDefFormViewModel == null)
            this.archiveRoomsDefFormViewModel = new ArchiveRoomsDefFormViewModel();
        if (this.archiveRoomsDefFormViewModel._ResArchiveRoom == null)
            this.archiveRoomsDefFormViewModel._ResArchiveRoom = new ResArchiveRoom();
        let resFloorObjectID = that.archiveRoomsDefFormViewModel._ResArchiveRoom["ResFloor"];
        if (resFloorObjectID != null && (typeof resFloorObjectID === "string")) {
            let resFloor = that.archiveRoomsDefFormViewModel.ResFloors.find(o => o.ObjectID.toString() === resFloorObjectID.toString());
            if (resFloor) {
                that.archiveRoomsDefFormViewModel._ResArchiveRoom.ResFloor = resFloor;
            }
        }


        let resBuildingWingObjectID = that.archiveRoomsDefFormViewModel._ResArchiveRoom["ResBuildingWing"];
        if (resBuildingWingObjectID != null && (typeof resBuildingWingObjectID === "string")) {
            let resBuildingWing = that.archiveRoomsDefFormViewModel.ResBuildingWings.find(o => o.ObjectID.toString() === resBuildingWingObjectID.toString());
            if (resBuildingWing) {
                that.archiveRoomsDefFormViewModel._ResArchiveRoom.ResBuildingWing = resBuildingWing;
            }
        }


        let resBuildingObjectID = that.archiveRoomsDefFormViewModel._ResArchiveRoom["ResBuilding"];
        if (resBuildingObjectID != null && (typeof resBuildingObjectID === "string")) {
            let resBuilding = that.archiveRoomsDefFormViewModel.ResBuildings.find(o => o.ObjectID.toString() === resBuildingObjectID.toString());
            if (resBuilding) {
                that.archiveRoomsDefFormViewModel._ResArchiveRoom.ResBuilding = resBuilding;
            }
        }

        this.archiveRoomsDefFormViewModel.ShelfList.forEach(shelf => {
            this.archiveRoomsDefFormViewModel.CabinetList.forEach(cabinet => {
                if (shelf.ResCabinet.toString() == cabinet.ObjectID.toString()) {
                    if (cabinet.ResShelves == null) {
                        cabinet.ResShelves = new Array<ResShelf>();
                    }
                    cabinet.ResShelves.unshift(shelf);
                }
            })
        });
        this.archiveRoomsDefFormViewModel.CabinetShelf = new Array<CabinetShelf>();

    }

    async ngOnInit() {
        await this.load();
    }

    public onContactPhoneChanged(event): void {
        if (this._ResArchiveRoom != null && this._ResArchiveRoom.ContactPhone != event) {
            this._ResArchiveRoom.ContactPhone = event;
        }
    }

    public onIsActiveChanged(event): void {
        if (this._ResArchiveRoom != null && this._ResArchiveRoom.IsActive != event) {
            this._ResArchiveRoom.IsActive = event;
        }
    }

    public onLocationChanged(event): void {
        if (this._ResArchiveRoom != null && this._ResArchiveRoom.Location != event) {
            this._ResArchiveRoom.Location = event;
        }
    }

    public onNameChanged(event): void {
        if (this._ResArchiveRoom != null && this._ResArchiveRoom.Name != event) {
            this._ResArchiveRoom.Name = event;
        }
    }

    public onResBuildingChanged(event): void {
        if (this._ResArchiveRoom != null && this._ResArchiveRoom.ResBuilding != event) {
            this._ResArchiveRoom.ResBuilding = event;
        }
        if (this._ResArchiveRoom.ResBuilding != null)
            this.ResBuildingWing.ListFilterExpression = " THIS.RESBUILDING.OBJECTID = '" + this._ResArchiveRoom.ResBuilding.ObjectID.toString() + "'";

    }

    public onResBuildingWingChanged(event): void {
        if (this._ResArchiveRoom != null && this._ResArchiveRoom.ResBuildingWing != event) {
            this._ResArchiveRoom.ResBuildingWing = event;
        }
        if (this._ResArchiveRoom.ResBuilding != null)
            this.ResFloor.ListFilterExpression = " THIS.RESBUILDING.OBJECTID = '" + this._ResArchiveRoom.ResBuilding.ObjectID.toString() + "'";
        if (this._ResArchiveRoom.ResBuildingWing != null)
            this.ResFloor.ListFilterExpression = " THIS.RESBUILDINGWING.OBJECTID = '" + this._ResArchiveRoom.ResBuildingWing.ObjectID.toString() + "'";
    }

    public onResFloorChanged(event): void {
        if (this._ResArchiveRoom != null && this._ResArchiveRoom.ResFloor != event) {
            this._ResArchiveRoom.ResFloor = event;
        }
    }

    public async onGridRowClick(event) {
        this.ActiveIDsModel = new ActiveIDsModel(null, null, null);
        this.ObjectID = event.data.ObjectID;
        this.archiveRoomsDefFormViewModel.CabinetList = new Array<ResCabinet>();
        if (this.selectedCabinet != null)
            this.selectedCabinet.ResShelves = new Array<ResShelf>();
        await this.load();
        this.CabinetName = "";
        this.CabinetActive = true;
        this.ShelfName = "";
        this.ShelfActive = true;
        this.ShelfFileCapacity = null;
        //this.loadProcedure($event.data)
        // this.TTObjectToModel();
    }

    public async onCabinetGridRowClick(event) {
        this.selectedCabinet = event.data;
        this.CabinetName = event.data.Name;
        this.CabinetActive = event.data.IsActive;
    }

    public selectedShelf: ResShelf;
    public async onShelfGridRowClick(event) {
        this.selectedShelf = event.data;
        this.ShelfName = event.data.ShelfName;
        this.ShelfFileCapacity = event.data.FileCapacity;
        this.ShelfActive = event.data.Active;
    }

    public async AddOrUpdateCabinet() {
        if (this.CabinetName == "" || this.CabinetName == null) {
            ServiceLocator.MessageService.showError("Dolap adı boş bırakılamaz");
            return;
        }
        if (this.selectedCabinet == null) {
            let cabinet: ResCabinet = new ResCabinet();
            cabinet.ResShelves = new Array<ResShelf>();
            cabinet.Name = this.CabinetName;
            cabinet.IsActive = this.CabinetActive;
            cabinet.ResArchiveRoom = this.archiveRoomsDefFormViewModel._ResArchiveRoom;
            this.archiveRoomsDefFormViewModel.CabinetList.unshift(cabinet);
            let saveInfo: FormSaveInfo = new FormSaveInfo(this._ResArchiveRoom.ObjectDefID.toString(), false);
            await this.saveForm(saveInfo);

        }
        else {
            this.selectedCabinet.Name = this.CabinetName;
            this.selectedCabinet.IsActive = this.CabinetActive;
        }

        this.CabinetName = "";
        this.selectedCabinet= null;
        this.selectedShelf = null;
    }

    public AddOrUpdateShelf() {


        if (this.selectedShelf == null) {

            if (this.ShelfName == null) {
                ServiceLocator.MessageService.showError("Raf adı boş bırakılamaz");
                return;
            }
            let shelf: ResShelf = new ResShelf();
            shelf.ShelfName = this.ShelfName;
            shelf.FileCapacity = this.ShelfFileCapacity;
            shelf.Active = this.ShelfActive;
            shelf.ResCabinet = this.selectedCabinet;
            this.archiveRoomsDefFormViewModel.ShelfList.unshift(shelf);
            if (this.selectedCabinet.ResShelves == null) {
                this.selectedCabinet.ResShelves = new Array<ResShelf>();
            }
            this.selectedCabinet.ResShelves.unshift(shelf);
       
        }

        else {
            if (this.selectedShelf.ShelfName == "") {
                ServiceLocator.MessageService.showError("Raf adı boş bırakılamaz");
                return;
            }
            this.selectedShelf.ShelfName = this.ShelfName;
            this.selectedShelf.FileCapacity = this.ShelfFileCapacity;
            this.selectedShelf.Active = this.ShelfActive;
        }

        this.ShelfFileCapacity = null;
        this.ShelfName = "";
        this.selectedShelf = null;
    }

    public roomList: List<RoomModel> = new List<RoomModel>();
    public async FillRoomList() {
        try {
            let that = this;
            let body = "";
            let apiUrlForPASearchUrl: string;
            let headers = new Headers({ 'Content-Type': 'application/json' });
            apiUrlForPASearchUrl = '/api/ResArchiveRoomService/FillRoomList';
            let index;

            await this.httpService.post<any>(apiUrlForPASearchUrl, null).then(response => {
                let result = response as List<RoomModel>;
                if (result) {

                    this.roomList = response;
                }

            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public LoadEmptyForm() {
        this.archiveRoomsDefFormViewModel.CabinetList = new Array<ResCabinet>();
        if (this.selectedCabinet != null)
            this.selectedCabinet.ResShelves = new Array<ResShelf>();
        this.CabinetName = "";
        this.CabinetActive = true;
        this.ShelfName = "";
        this.ShelfActive = true;
        this.ShelfFileCapacity = null;
        this.archiveRoomsDefFormViewModel._ResArchiveRoom.ResBuilding = null;
        this.archiveRoomsDefFormViewModel._ResArchiveRoom.ResBuildingWing = null;
        this.archiveRoomsDefFormViewModel._ResArchiveRoom.ResFloor = null;
        this.archiveRoomsDefFormViewModel._ResArchiveRoom.Name = "";
        this.archiveRoomsDefFormViewModel._ResArchiveRoom.Location = "";
        this.archiveRoomsDefFormViewModel._ResArchiveRoom.DeskPhoneNumber = "";
    }

    public async clearForm() {
        await this.initViewModel();
        await this.LoadEmptyForm();
        await this.load();
    }

    public async saveForm(saveInfo: FormSaveInfo) {
        if (this.archiveRoomsDefFormViewModel._ResArchiveRoom.ResBuilding == null) {
            ServiceLocator.MessageService.showError("Bina alanı boş bırakılamaz");
            return;
        }
        if (this.archiveRoomsDefFormViewModel._ResArchiveRoom.Name == null || this.archiveRoomsDefFormViewModel._ResArchiveRoom.Name == "") {
            ServiceLocator.MessageService.showError("Oda adı boş bırakılamaz");
            return;
        }
        
        this.CabinetName = "";
        this.ShelfName = "";
        this.ShelfFileCapacity = null;
        await super.saveForm(saveInfo);
        await this.load();
    }

    protected redirectProperties(): void {
        redirectProperty(this.Name, "Text", this.__ttObject, "Name");
        redirectProperty(this.ContactPhone, "Text", this.__ttObject, "ContactPhone");
        redirectProperty(this.Location, "Text", this.__ttObject, "Location");
        redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
    }

    public initFormControls(): void {
        this.labelLocation = new TTVisual.TTLabel();
        this.labelLocation.Text = "Adres";
        this.labelLocation.Name = "labelLocation";
        this.labelLocation.TabIndex = 11;

        this.Location = new TTVisual.TTTextBox();
        this.Location.Name = "Location";
        this.Location.TabIndex = 10;

        this.ContactPhone = new TTVisual.TTTextBox();
        this.ContactPhone.Name = "ContactPhone";
        this.ContactPhone.TabIndex = 8;

        this.Name = new TTVisual.TTTextBox();
        this.Name.Name = "Name";
        this.Name.TabIndex = 6;

        this.labelContactPhone = new TTVisual.TTLabel();
        this.labelContactPhone.Text = "İrtibat Telefonu";
        this.labelContactPhone.Name = "labelContactPhone";
        this.labelContactPhone.TabIndex = 9;

        this.labelName = new TTVisual.TTLabel();
        this.labelName.Text = "Kaynak adı";
        this.labelName.Name = "labelName";
        this.labelName.TabIndex = 7;

        this.labelResFloor = new TTVisual.TTLabel();
        this.labelResFloor.Text = "Kat";
        this.labelResFloor.Name = "labelResFloor";
        this.labelResFloor.TabIndex = 5;

        this.ResFloor = new TTVisual.TTObjectListBox();
        this.ResFloor.ListDefName = "FloorListDefinition";
        this.ResFloor.Name = "ResFloor";
        this.ResFloor.TabIndex = 4;

        this.labelResBuildingWing = new TTVisual.TTLabel();
        this.labelResBuildingWing.Text = "Kanat";
        this.labelResBuildingWing.Name = "labelResBuildingWing";
        this.labelResBuildingWing.TabIndex = 3;

        this.ResBuildingWing = new TTVisual.TTObjectListBox();
        this.ResBuildingWing.ListDefName = "WingListDefinition";
        this.ResBuildingWing.Name = "ResBuildingWing";
        this.ResBuildingWing.TabIndex = 2;

        this.labelResBuilding = new TTVisual.TTLabel();
        this.labelResBuilding.Text = "Bina";
        this.labelResBuilding.Name = "labelResBuilding";
        this.labelResBuilding.TabIndex = 1;
        this.labelResBuilding.Visible = false;

        this.ResBuilding = new TTVisual.TTObjectListBox();
        this.ResBuilding.Required = true;
        this.ResBuilding.ListDefName = "BuildinglistDefinition";
        this.ResBuilding.Name = "ResBuilding";
        this.ResBuilding.TabIndex = 0;

        this.IsActive = new TTVisual.TTCheckBox();
        this.IsActive.Value = true;
        this.IsActive.Text = "Aktif";
        this.IsActive.Name = "IsActive";
        this.IsActive.TabIndex = 3;

        this.Controls = [this.labelLocation, this.Location, this.ContactPhone, this.Name, this.labelContactPhone, this.labelName, this.labelResFloor, this.ResFloor, this.labelResBuildingWing, this.ResBuildingWing, this.labelResBuilding, this.ResBuilding, this.IsActive];

    }


}
