import { Component } from '@angular/core';
import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import { MessageService } from 'app/Fw/Services/MessageService';

@Component({
    selector: "atcdefinition-component",
    templateUrl: './ATCDefinitionComponent.html',
    providers: [SystemApiService, MessageService]
})
export class ATCDefinitionComponent implements IModal {

    loadingVisible: boolean = false;
    LoadPanelMessage: string = "İşleminiz yapılıyor Lütfen Bekleyiniz..";
    atcDefinitionSource: Array<ATCList> = new Array<ATCList>();
    skrsUpdateList: Array<UpdateListOfSKRS> = new Array<UpdateListOfSKRS>();
    skrsUpdatePopupVisible: boolean = false;
    constructor(private http: NeHttpService) {
        //this.getAllCommisionDefinition();
    }

    public async setInputParam(value: Object) {
    }

    public setModalInfo(value: ModalInfo) {
    }

    public cancelClick(): void {
    }

    public okClick(): void {
    }

    atcDefinitionDataColumn = [
        {
            caption: 'ObjectID',
            dataField: 'ObjectID',
            visible: false,
            width: 'auto'
        },
        {
            caption: 'Barkodu',
            dataField: 'Barcode',
            width: 150,
        },
        {
            caption: 'İlaç Adı',
            dataField: 'DrugName',
        },
        {
            caption: 'ATC Kodu - Adı',
            dataField: 'AtcCodeAndName',
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
            dataField: 'SKRSIlacObjectID',
            visible: false,
            width: 'auto'
        },
        {
            caption: 'Barkodu',
            dataField: 'Barcode',
            width: 150,
        },
        {
            caption: 'İlaç Adı',
            dataField: 'DrugName',
        },
        {
            caption: 'ATC Kodu',
            dataField: 'AtcCode',
        },
        {
            caption: 'ATC Adı',
            dataField: 'AtcName',
        },
        {
            caption: "Aktif",
            dataField: 'IsActive',
            dataType: 'boolean',
            width: 'auto',
        }
    ];

     listATC() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/ATCDefinitionService/listATC';
         this.http.post<Array<ATCList>>(fullApiUrl, null)
            .then((res) => {
                that.atcDefinitionSource = res;
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
        let fullApiUrl: string = 'api/ATCDefinitionService/getUpdateSKRSList';
         this.http.post<Array<UpdateListOfSKRS>>(fullApiUrl, null)
            .then((res) => {
                that.skrsUpdateList = res as Array<UpdateListOfSKRS>;
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
        let fullApiUrl: string = 'api/ATCDefinitionService/UpdateSKRSList';
        let input: UpdateInputDTO = new UpdateInputDTO();
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

export class UpdateInputDTO {
    public updateListOfSKRS: Array<UpdateListOfSKRS> = new Array<UpdateListOfSKRS>();
}

export class ATCList {
    public ObjectID: Guid;
    public DrugName: string;
    public Barcode: string;
    public AtcCodeAndName: string;
    public IsActive: boolean;
}


export class UpdateListOfSKRS {
    public SKRSIlacObjectID: Guid;
    public DrugName: string;
    public Barcode: string;
    public AtcCode: string;
    public AtcName: string;
    public IsActive: boolean;
}

