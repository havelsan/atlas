import { Component, OnInit, Input, EventEmitter, OnDestroy } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'app/Fw/Services/MessageService';
import { AtlasHttpService } from 'app/Fw/Services/AtlasHttpService';
import { ArchiveDeliveryFormViewModel } from './ArchiveDeliveryFormViewModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { DynamicReportParameters } from 'Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { IModalService } from 'Fw/Services/IModalService';

@Component({
    selector: "ArchiveDeliveryForm",
    templateUrl: './ArchiveDeliveryForm.html',

    providers: [SystemApiService],

})
export class ArchiveDeliveryForm extends BaseComponent<any> implements OnInit, IModal, OnDestroy {
    archiveDeliveryFormViewModel: ArchiveDeliveryFormViewModel = new ArchiveDeliveryFormViewModel();
    FolderContentColumns = [{
        caption: 'Seç',
        dataField: 'IsSelected',
        dataType: 'boolean',
        fixed: true,
        width: '80px',
        allowEditing: true,
        cellTemplate: "ChkTemplate"
    },
        { caption: 'Evrak Adı', dataField: 'ContentName', fixed: true, width: '500', allowEditing: false },
        { caption: 'Sayfa Sayısı', dataField: 'PageNumber', fixed: true, width: '100', allowEditing: true}

    ]
    _episodeActionID: string = "";

    constructor(protected httpService: NeHttpService, private http: AtlasHttpService, services: ServiceContainer, protected messageService: MessageService, protected modalService: IModalService) {
        super(services);
    }

    async ngOnInit() {
        await this.loadArchiveDeliveryFormViewModel();

    }

  
    public setInputParam(value: any) {

        this._episodeActionID = value.toString();
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    loadArchiveDeliveryFormViewModel() {
        let that = this;
        let fullApiUrl: string = "/api/ArchiveDeliveryService/LoadArchiveDeliveryFormViewModel?EpisodeActionID=" + this._episodeActionID;
        this.httpService.get<ArchiveDeliveryFormViewModel>(fullApiUrl)
            .then(response => {
                that.archiveDeliveryFormViewModel = response as ArchiveDeliveryFormViewModel;
            })
            .catch(error => {
                console.log(error);
            });

    }

    public ngOnDestroy(): void {
    }

    clientPostScript(state: String) {

    }

    clientPreScript() {

    }

    SaveArchieDeliveryForm() {
        let that = this;

        for (let content of this.archiveDeliveryFormViewModel.FolderContentList)
        {
            if (content.IsSelected == true && content.PageNumber =="")
            {
                this.messageService.showError("İşleme Devam Etmek İçin Seçili Evrakların Sayfa Sayılarını Giriniz.");
                return;
            }
        }


        let fullApiUrl: string = "/api/ArchiveDeliveryService/SaveArchiveDeliveryFormViewModel";
        this.httpService.post<any>(fullApiUrl, this.archiveDeliveryFormViewModel)
            .then(response => {
                this.messageService.showSuccess("İşlem Kaydedildi.");
            })
            .catch(error => {
                console.log(error);
            });
    }

    PrintArchieDeliveryForm() {
        let that = this;
        let reportData: DynamicReportParameters = {

            Code: 'ARSIVTESLIMFORMU',
            ReportParams: { SubepisodeID: this.archiveDeliveryFormViewModel.SubepisodeID },
            ViewerMode: true

        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "ARŞİV TESLİM FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    //public Close(): void {
    //    ServiceLocator.ModalStateService().callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
    //}


}
