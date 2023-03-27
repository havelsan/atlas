import { Component } from '@angular/core';
import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import { MessageService } from 'app/Fw/Services/MessageService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';

@Component({
    selector: "routeofadmindefinition-component",
    templateUrl: './RouteOfAdminDefComponent.html',
    providers: [SystemApiService, MessageService]
})
export class RouteOfAdminDefComponent implements IModal {
    loadingVisible: boolean = false;
    LoadPanelMessage: string = "İşleminiz yapılıyor Lütfen Bekleyiniz..";
    rodDefinitionSource: Array<RoutOfAdminList> = new Array<RoutOfAdminList>();
    skrsUpdateList: Array<UpdateRoAListOfSKRS> = new Array<UpdateRoAListOfSKRS>();
    skrsUpdatePopupVisible: boolean = false;
    constructor(private http: NeHttpService) {

    }

    public async setInputParam(value: Object) {
    }

    public setModalInfo(value: ModalInfo) {
    }

    public cancelClick(): void {
    }

    public okClick(): void {
    }

    roaDefinitionDataColumn = [
        {
            caption: 'ObjectID',
            dataField: 'ObjectID',
            visible: false,
            width: 'auto'
        },
        {
            caption: 'Kodu',
            dataField: 'Code',
            sortOrder: 'asc',
            width: 150,
        },
        {
            caption: 'Adı',
            dataField: 'Name',
        },
        {
            caption: "Aktif",
            dataField: 'IsActive',
            dataType: 'boolean',
            width: 'auto',
        }
    ];

    skrsUpdateListDataColumn = [
        {
            caption: 'ObjectID',
            dataField: 'ObjectID',
            visible: false,
            width: 'auto'
        },
        {
            caption: 'Kodu',
            dataField: 'Code',
            width: 150,
        },
        {
            caption: 'Adı',
            dataField: 'Name',
        },
        {
            caption: "Aktif",
            dataField: 'IsActive',
            dataType: 'boolean',
            width: 'auto',
        }
    ];

    listRouteOfAdmin() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/RouteOfAdminDefinitionService/listRouteOfAdmin';
         this.http.post<Array<RoutOfAdminList>>(fullApiUrl, null)
            .then((res) => {
                that.rodDefinitionSource = res;
                that.loadingVisible = false;

            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                that.loadingVisible = false;
            });
    }

     updateSKRS() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/RouteOfAdminDefinitionService/getUpdateSKRSList';
         this.http.post<Array<UpdateRoAListOfSKRS>>(fullApiUrl, null)
            .then((res) => {
                that.skrsUpdateList = res as Array<UpdateRoAListOfSKRS>;
                that.loadingVisible = false;
                that.skrsUpdatePopupVisible = true;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                that.loadingVisible = false;
            });
    }


     closePopupOK() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/RouteOfAdminDefinitionService/UpdateSKRSList';
        let input: UpdateROAInputDTO = new UpdateROAInputDTO();
        input.updateListOfSKRS = this.skrsUpdateList;
         this.http.post<string>(fullApiUrl, input)
            .then((res) => {
                TTVisual.InfoBox.Alert(res);
                that.loadingVisible = false;
                that.skrsUpdatePopupVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                that.loadingVisible = false;
                this.skrsUpdatePopupVisible = false;
            });
    }
    closePopupCancel() {
        this.skrsUpdatePopupVisible = false;
    }

}

export class UpdateROAInputDTO {
    public updateListOfSKRS: Array<UpdateRoAListOfSKRS> = new Array<UpdateRoAListOfSKRS>();
}

export class RoutOfAdminList {
    public ObjectID: Guid;
    public Name: string;
    public Code: number;
    public IsActive: boolean;
}

export class UpdateRoAListOfSKRS {
    public SKRSObjectID: Guid;
    public Name: string;
    public Code: number;
    public IsActive: boolean;
}