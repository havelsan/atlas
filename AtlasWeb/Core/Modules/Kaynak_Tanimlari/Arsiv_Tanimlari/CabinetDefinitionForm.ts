//$857298CA
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { CabinetDefinitionFormViewModel } from './CabinetDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ResCabinet } from 'NebulaClient/Model/AtlasClientModel';
import { ResArchiveRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResShelf } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'CabinetDefinitionForm',
    templateUrl: 'CabinetDefinitionForm.html',
    providers: [MessageService]
})
export class CabinetDefinitionForm extends TTVisual.TTForm implements OnInit {
    FileCapacityResShelf: TTVisual.ITTTextBoxColumn;
    IsActive: TTVisual.ITTCheckBox;
    IsActiveResShelf: TTVisual.ITTCheckBoxColumn;
    labelName: TTVisual.ITTLabel;
    labelResArchiveRoom: TTVisual.ITTLabel;
    Name: TTVisual.ITTTextBox;
    ResArchiveRoom: TTVisual.ITTObjectListBox;
    ResCabinetResShelf: TTVisual.ITTListBoxColumn;
    ResShelves: TTVisual.ITTGrid;
    ShelfNameResShelf: TTVisual.ITTTextBoxColumn;
    public ResShelvesColumns = [];
    public cabinetDefinitionFormViewModel: CabinetDefinitionFormViewModel = new CabinetDefinitionFormViewModel();
    public get _ResCabinet(): ResCabinet {
        return this._TTObject as ResCabinet;
    }
    private CabinetDefinitionForm_DocumentUrl: string = '/api/ResCabinetService/CabinetDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('RESCABINET', 'CabinetDefinitionForm');
        this._DocumentServiceUrl = this.CabinetDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ResCabinet();
        this.cabinetDefinitionFormViewModel = new CabinetDefinitionFormViewModel();
        this._ViewModel = this.cabinetDefinitionFormViewModel;
        this.cabinetDefinitionFormViewModel._ResCabinet = this._TTObject as ResCabinet;
        this.cabinetDefinitionFormViewModel._ResCabinet.ResShelves = new Array<ResShelf>();
        this.cabinetDefinitionFormViewModel._ResCabinet.ResArchiveRoom = new ResArchiveRoom();
    }

    protected loadViewModel() {
        let that = this;
        that.cabinetDefinitionFormViewModel = this._ViewModel as CabinetDefinitionFormViewModel;
        that._TTObject = this.cabinetDefinitionFormViewModel._ResCabinet;
        if (this.cabinetDefinitionFormViewModel == null)
            this.cabinetDefinitionFormViewModel = new CabinetDefinitionFormViewModel();
        if (this.cabinetDefinitionFormViewModel._ResCabinet == null)
            this.cabinetDefinitionFormViewModel._ResCabinet = new ResCabinet();
        that.cabinetDefinitionFormViewModel._ResCabinet.ResShelves = that.cabinetDefinitionFormViewModel.ResShelvesGridList;
        for (let detailItem of that.cabinetDefinitionFormViewModel.ResShelvesGridList) {
            let resCabinetObjectID = detailItem["ResCabinet"];
            if (resCabinetObjectID != null && (typeof resCabinetObjectID === "string")) {
                let resCabinet = that.cabinetDefinitionFormViewModel.ResCabinets.find(o => o.ObjectID.toString() === resCabinetObjectID.toString());
                if (resCabinet) {
                    detailItem.ResCabinet = resCabinet;
                }
            }

        }
    
let resArchiveRoomObjectID = that.cabinetDefinitionFormViewModel._ResCabinet["ResArchiveRoom"];
if (resArchiveRoomObjectID != null && (typeof resArchiveRoomObjectID === "string")) {
    let resArchiveRoom = that.cabinetDefinitionFormViewModel.ResArchiveRooms.find(o => o.ObjectID.toString() === resArchiveRoomObjectID.toString());
    if (resArchiveRoom) {
        that.cabinetDefinitionFormViewModel._ResCabinet.ResArchiveRoom = resArchiveRoom;
    }
}

}

async ngOnInit() {
    await this.load();
}

public onIsActiveChanged(event): void {
    if(this._ResCabinet != null && this._ResCabinet.IsActive != event) { 
    this._ResCabinet.IsActive = event;
}
}

public onNameChanged(event): void {
    if(this._ResCabinet != null && this._ResCabinet.Name != event) { 
    this._ResCabinet.Name = event;
}
}

public onResArchiveRoomChanged(event): void {
    if(this._ResCabinet != null && this._ResCabinet.ResArchiveRoom != event) { 
    this._ResCabinet.ResArchiveRoom = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.Name, "Text", this.__ttObject, "Name");
    redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
}

public initFormControls() : void {
    this.ResShelves = new TTVisual.TTGrid();
    this.ResShelves.Name = "ResShelves";
    this.ResShelves.TabIndex = 4;

    this.ResCabinetResShelf = new TTVisual.TTListBoxColumn();
    this.ResCabinetResShelf.DataMember = "ResCabinet";
    this.ResCabinetResShelf.DisplayIndex = 0;
    this.ResCabinetResShelf.HeaderText = "";
    this.ResCabinetResShelf.Name = "ResCabinetResShelf";
    this.ResCabinetResShelf.Width = 300;

    this.FileCapacityResShelf = new TTVisual.TTTextBoxColumn();
    this.FileCapacityResShelf.DataMember = "FileCapacity";
    this.FileCapacityResShelf.DisplayIndex = 1;
    this.FileCapacityResShelf.HeaderText = "Dosya Kapasitesi";
    this.FileCapacityResShelf.Name = "FileCapacityResShelf";
    this.FileCapacityResShelf.Width = 80;

    this.ShelfNameResShelf = new TTVisual.TTTextBoxColumn();
    this.ShelfNameResShelf.DataMember = "ShelfName";
    this.ShelfNameResShelf.DisplayIndex = 2;
    this.ShelfNameResShelf.HeaderText = "Adı";
    this.ShelfNameResShelf.Name = "ShelfNameResShelf";
    this.ShelfNameResShelf.Width = 80;

    this.IsActiveResShelf = new TTVisual.TTCheckBoxColumn();
    this.IsActiveResShelf.DataMember = "ISACTIVE";
    this.IsActiveResShelf.DisplayIndex = 3;
    this.IsActiveResShelf.HeaderText = "Aktif";
    this.IsActiveResShelf.Name = "IsActiveResShelf";
    this.IsActiveResShelf.Width = 80;

    this.labelResArchiveRoom = new TTVisual.TTLabel();
    this.labelResArchiveRoom.Text = "Bulunduğu Oda";
    this.labelResArchiveRoom.Name = "labelResArchiveRoom";
    this.labelResArchiveRoom.TabIndex = 3;

    this.ResArchiveRoom = new TTVisual.TTObjectListBox();
    this.ResArchiveRoom.ListDefName = "ArchiveRoomListDef";
    this.ResArchiveRoom.Name = "ResArchiveRoom";
    this.ResArchiveRoom.TabIndex = 2;

    this.labelName = new TTVisual.TTLabel();
    this.labelName.Text = "Kaynak adı";
    this.labelName.Name = "labelName";
    this.labelName.TabIndex = 1;

    this.Name = new TTVisual.TTTextBox();
    this.Name.Name = "Name";
    this.Name.TabIndex = 0;

    this.IsActive = new TTVisual.TTCheckBox();
    this.IsActive.Value = true;
    this.IsActive.Text = "Aktif";
    this.IsActive.Name = "IsActive";
    this.IsActive.TabIndex = 3;

    this.ResShelvesColumns = [this.ResCabinetResShelf, this.FileCapacityResShelf, this.ShelfNameResShelf, this.IsActiveResShelf];
    this.Controls = [this.ResShelves, this.ResCabinetResShelf, this.FileCapacityResShelf, this.ShelfNameResShelf, this.IsActiveResShelf, this.labelResArchiveRoom, this.ResArchiveRoom, this.labelName, this.Name, this.IsActive];

}


}
