//$16520530
import { Component, OnInit } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'Fw/Services/MessageService';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { DataSetsFormViewModel } from './DataSetsFormViewModel';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { ENabizDataSets } from "./ENabizViewModel";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
@Component({
    selector: "datasetform",
    templateUrl: './DataSetsForm.html',
    providers: [MessageService]

})
export class DataSetsForm extends BaseComponent<any> implements OnInit, IModal {
    public dataSetsFormViewModel: DataSetsFormViewModel = new DataSetsFormViewModel();
    public _DatasetList = new Array<ENabizDataSets>();
    public selectedDatasets: Array<ENabizDataSets> = [];
    showENabizPopup = false;
    eNabizViewModels: Array<any> = [];
    _EpisodeActionID: Guid;
    public DataSetListColumns = [

        {
            caption: i18n("M24094", "Veri Seti"),
            dataField: "PackageName",
            width: '100%',
            allowSorting: false,
            allowEditing: false
        }

    ];

    clientPostScript(state: String) {

    }

    clientPreScript() {

    }


    constructor(protected httpService: NeHttpService, services: ServiceContainer, protected messageService: MessageService, private modalStateService: ModalStateService) {
        super(services);
        this.initViewModel();
        this.showENabizPopup = false;
    }

    public initViewModel(): void {

        this.dataSetsFormViewModel = new DataSetsFormViewModel();
        this.dataSetsFormViewModel._DatasetList = new Array<ENabizDataSets>();
        this._DatasetList = new Array<ENabizDataSets>();
    }

    async ngOnInit() {
        await this.loadDataSets();
    }


    private loadDataSets(): void {

        let that = this;
        let apiUrl: string = '/api/DataSetsService/GetDataSets';

        that.httpService.get<any>(apiUrl)
            .then(response => {
                let result = response;
                this._DatasetList = result as Array<ENabizDataSets>;

            })
            .catch(error => {
                console.log(error);
            });

    }

    public setInputParam(value: any) {
 
        this._EpisodeActionID = value;

    }
    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    onSelect() {

        this.showENabizPopup = true;
        //this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, null,true);
    }

    onEnabizClose() {

        this.showENabizPopup = false;

    }


}

