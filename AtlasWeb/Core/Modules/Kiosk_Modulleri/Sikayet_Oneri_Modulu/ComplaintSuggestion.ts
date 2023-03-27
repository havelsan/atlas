import { Component, ViewChild } from '@angular/core';
import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Type } from 'NebulaClient/ClassTransformer';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import { MessageService } from 'app/Fw/Services/MessageService';
import DateTime from 'app/NebulaClient/System/Time/DateTime';
import { ComplationAndSuggestionTypeEnum } from 'app/NebulaClient/Model/AtlasClientModel';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';

@Component({
    selector: "complaintSuggestion-component",
    templateUrl: './ComplaintSuggestion.html',
    providers: [SystemApiService, MessageService]


})
export class ComplaintSuggestion implements IModal {
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "İşleminiz Yapılıyor Lütfen Bekleyiniz..";
    public complaintSuggestionListDTOs: Array<ComplationSuggestionListDTO> = new Array<ComplationSuggestionListDTO>();
    public selectedItem: ComplationSuggestionListDTO;
    public activeComplationAndSuggestionItem: ComplationAndSuggestionOutputItem = new ComplationAndSuggestionOutputItem();
    public selectedItemFromOpen: boolean = false;
    public selectionGridObjectID: any;
    public isRead: boolean;
    ComplationAndSuggestionTypeItems: Array<EnumItem> = ComplationAndSuggestionTypeEnum.Items;
    public ComplationOrSuggestionTypeItem: any;

    constructor(private http: NeHttpService) {
        this.getAllComplaintSuggestionList();
    }

    private collapseAttr = 0;
    public collapseSelectedDivProperties(): string {
        if (this.collapseAttr == 1) {
            return "hidden";
        }
        return "col-md-3";

    }
    public collapseIconProperties(): string {

        if (this.collapseAttr == 1) {
            return "fa fa-2x fa-angle-up";
        }
        return "fa fa-2x fa-angle-left";

    }

    btnCollapse() {
        if (this.collapseAttr == 1) {
            this.collapseAttr = 0;
        } else
            this.collapseAttr = 1;
    }
    public collapseBtnProperties(): string {

        if (this.collapseAttr == 1) {
            return "float-left";
        }
        return "float-right";

    }

    public collapsedPanelProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-11 episodeColMd11 col-sm-12 col-xs-12";
        }
        return "col-md-9";

    }

    public collapseSelectedHiddenDivProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-1 episodeColMd1 col-sm-12 col-xs-12";
        }
        return "hidden";

    }

    public async setInputParam(value: Object) {
    }

    public setModalInfo(value: ModalInfo) {
    }

    public cancelClick(): void {
    }

    public okClick(): void {
    }

    complationOrSuggestionColumn = [
        {
            caption: 'ObjectID',
            dataField: 'ObjectID',
            visible: false,
        },
        {
            caption: "Şikayet/Öneri",
            dataField: 'ComplationOrSuggestionType',
            lookup: { dataSource: this.ComplationAndSuggestionTypeItems, valueExpr: 'code', displayExpr: 'description' }
        },
        {
            caption: 'İçerik',
            dataField: 'Desciption',
            width: 300,
            sortOrder: 'asc',
        },
        {
            caption: "Okundu",
            dataField: 'IsRead',
            dataType: 'boolean',
            width: 'auto',
        }
    ];

    deviceObjectIDList: Array<Guid> = new Array<Guid>();
    async selectGridRow(value: any): Promise<void> {
        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            this.loadingVisible = true;
            this.selectedItemFromOpen = true;
            let input: GetComplationAndSuggestion_Input = new GetComplationAndSuggestion_Input();
            input.ObjectID = value.data.ObjectID;
            let that = this;
            let fullApiUrl: string = 'api/ComplaintSuggestion/getComplationAndSuggestionOutputItem';
            this.http.post<ComplationAndSuggestionOutputItem>(fullApiUrl, input)
                .then((res) => {
                    that.activeComplationAndSuggestionItem = res as ComplationAndSuggestionOutputItem;
                    if (this.activeComplationAndSuggestionItem.ComplationOrSuggestion == 0)
                        this.ComplationOrSuggestionTypeItem = "Şikayet";
                    else
                        this.ComplationOrSuggestionTypeItem = "Öneri";
                    that.isRead = this.activeComplationAndSuggestionItem.IsRead;
                }).catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    that.loadingVisible = false;
                });
            that.loadingVisible = false;
        }
    }





    getAllComplaintSuggestionList() {
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/ComplaintSuggestion/getAllComplaintSuggestionList';
        this.http.post<GetComplationSuggestion>(fullApiUrl, null)
            .then((res) => {
                that.complaintSuggestionListDTOs = res.complaintSuggestionListDTOs as Array<ComplationSuggestionListDTO>;
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });

        console.log(this.ComplationAndSuggestionTypeItems);
    }


    async list() {
        this.getAllComplaintSuggestionList();
    }

    Cancel() {
        this.selectedItemFromOpen = false;
        this.selectedItem = null;
    }

    Save() {
        this.activeComplationAndSuggestionItem.IsRead = this.isRead;
        this.loadingVisible = true;
        let that = this;
        let fullApiUrl: string = 'api/ComplaintSuggestion/saveObjectForAtlas';
        this.http.post(fullApiUrl, that.activeComplationAndSuggestionItem)
            .then((res) => {
                TTVisual.InfoBox.Alert(res.toString());
                this.getAllComplaintSuggestionList();
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }

}


export class ComplationSuggestionListDTO {
    @Type(() => Guid)
    public ObjectID: Guid;
    public ComplationOrSuggestionType: ComplationAndSuggestionTypeEnum;
    public Desciption: string;
    public IsRead: boolean;
}

export class GetComplationSuggestion {
    public complaintSuggestionListDTOs: Array<ComplationSuggestionListDTO>;
}

export class GetComplationAndSuggestion_Input {
    @Type(() => Guid)
    public ObjectID: Guid;
}


export class ComplationAndSuggestionOutputItem {
    public IsRead: boolean;
    public ObjectID: Guid;
    public ComplationOrSuggestion: ComplationAndSuggestionTypeEnum;
    public Surname: string;
    public Name: string;
    public MobilePhone: string;
    public EMail: string;
    public Desciption: string;
}