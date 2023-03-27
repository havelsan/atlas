import { Component } from '@angular/core';
import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import { MessageService } from 'app/Fw/Services/MessageService';

@Component({
    selector: "distributiondefinition-component",
    templateUrl: './DistributionDefinitionComponent.html',
    providers: [SystemApiService, MessageService]
})
export class DistributionDefinitionComponent implements IModal {

    loadingVisible: boolean = false;
    LoadPanelMessage: string = "İşleminiz yapılıyor Lütfen Bekleyiniz..";
    distDefinitionSource: Array<DistributionDefList> = new Array<DistributionDefList>();
    myksUpdateList: Array<UpdateListOfMKYS> = new Array<UpdateListOfMKYS>();
    mkysUpdatePopupVisible: boolean = false;
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

    distDefinitionDataColumn = [
        {
            caption: 'ObjectID',
            dataField: 'ObjectID',
            visible: false,
            width: 'auto'
        },
        {
            caption: 'Değeri',
            dataField: 'Value',
            width: 150,
        },
        {
            caption: 'Adı',
            dataField: 'Name',
        },
        
        {
            caption: 'Enum No',
            dataField: 'EnumNo',
            sortOrder:'asc',
            width: 150,
        },
        {
            caption: "Aktif",
            dataField: 'IsActive',
            dataType: 'boolean',
            width: 'auto',
        }
    ];

    mkysUpdateListDataColumn = [
        {
            caption: 'ObjectID',
            dataField: 'MKYSObjectID',
            visible: false,
            width: 'auto'
        },
        {
            caption: 'Adı',
            dataField: 'Name',
            width: 150,
        },
        {
            caption: 'Değeri',
            dataField: 'Value',
        },
        {
            caption: 'Enum No',
            dataField: 'EnumNo',
        },
        {
            caption: "Aktif",
            dataField: 'IsActive',
            dataType: 'boolean',
            width: 'auto',
        }
    ];

     listDistributionDefinition() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/DistributionDefinitionService/listDistributionDef';
         this.http.post<Array<DistributionDefList>>(fullApiUrl, null)
            .then((res) => {
                that.distDefinitionSource = res;
                that.loadingVisible = false;

            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                that.loadingVisible = false;
            });
    }

     updateMKYS() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/DistributionDefinitionService/getUpdateMKYSList';
         this.http.post<Array<UpdateListOfMKYS>>(fullApiUrl, null)
            .then((res) => {
                that.myksUpdateList = res as Array<UpdateListOfMKYS>;
                that.loadingVisible = false;
                that.mkysUpdatePopupVisible = true;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                that.loadingVisible = false;
            });
    }


     closePopupOK() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/DistributionDefinitionService/UpdateMKYSList';
        let input: UpdateMKYSInputDTO = new UpdateMKYSInputDTO();
        input.updateListOfMKYS = this.myksUpdateList;
         this.http.post<string>(fullApiUrl, input)
            .then((res) => {
                TTVisual.InfoBox.Alert(res);
                that.loadingVisible = false;
                that.mkysUpdatePopupVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                that.loadingVisible = false;
                this.mkysUpdatePopupVisible = false;
            });
    }
    closePopupCancel() {
        this.mkysUpdatePopupVisible = false;
    }

}

export class UpdateMKYSInputDTO {
    public updateListOfMKYS: Array<UpdateListOfMKYS> = new Array<UpdateListOfMKYS>();
}

export class DistributionDefList {
    public ObjectID: Guid;
    public Name: string;
    public Value: string;
    public EnumNo: number;
    public IsActive: boolean;
}


export class UpdateListOfMKYS {
    public MKYSObjectID: Guid;
    public Name: string;
    public Value: string;
    public EnumNo: number;
    public IsActive: boolean;
}

