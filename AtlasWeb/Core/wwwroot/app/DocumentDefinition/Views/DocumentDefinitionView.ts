import { Component } from '@angular/core';
import { Headers, RequestOptions, ResponseContentType } from '@angular/http';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { DocumentDefinitionViewModel, DocumentDefinitionItem, Tab } from '../Models/DocumentDefinitionViewModel';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { AtlasHttpService } from 'Fw/Services/AtlasHttpService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { CommonHelper } from 'app/Helper/CommonHelper';

@Component({
    selector: 'hvl-documentdefinition-view',
    inputs: ['Model'],
    templateUrl: './DocumentDefinitionView.html'
})

export class DocumentDefinitionView extends BaseComponent<DocumentDefinitionViewModel> {
    dataSource: string[];
    constructor(container: ServiceContainer, private http: NeHttpService, private http2: AtlasHttpService) {
        super(container);
    }

    public tabs: Array<Tab>;
    public documentDefinitions: Array<DocumentDefinitionItem>;
    public tabID: Guid;
    public currentItem: DocumentDefinitionItem;

    clientPreScript() {
        this.getFirstOpen();

    }

    clientPostScript(state: String) {

    }

    async getFirstOpen() {
        let input: any;
        let that = this;
        let fullApiUrl: string = 'api/DocumentDefinitionView/GetFirstOpen';
        this.http.post(fullApiUrl, input)
            .then((res) => {
                let result = <DocumentDefinitionViewModel>res;
                that.Model = result;
                if (that.Model) {
                    that.tabs = that.Model.tabs;
                    that.documentDefinitions = that.Model.documentDefinitions;
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    selectTab(e) {
        this.tabID = this.tabs[e.itemIndex].id;
        let that = this;
        this.http.get<Array<DocumentDefinitionItem>>('api/DocumentDefinitionView/GetDocuments?tabID=' + this.tabID.toString()).then((res: Array<DocumentDefinitionItem>) => {
            let output = res;
            that.documentDefinitions = res;
        });
    }

    selectItem(e) {
        //this.tabContent = this.tabs[e.itemIndex].content;
        this.currentItem = e.itemData;
    }

    saveFile() {
        let apiUrl: string = '/api/DocumentDefinitionDownload/DownloadFile';
        let input = { id: this.currentItem.id };
        let headers = new Headers();
        headers.set('Content-Type', 'application/json');
        let options = new RequestOptions();
        options.headers = headers;
        options.responseType = ResponseContentType.Blob;

        this.http2.post(apiUrl, JSON.stringify(input), options).toPromise().then(
            (res) => {
                CommonHelper.saveFile(res.blob(), this.currentItem.name);
            });

    }

}