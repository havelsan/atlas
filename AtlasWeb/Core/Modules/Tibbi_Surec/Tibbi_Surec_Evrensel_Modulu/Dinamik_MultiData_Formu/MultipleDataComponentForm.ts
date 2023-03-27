//$0976C95F
import { Component, ViewChild, OnInit, OnDestroy, Input, ComponentRef, EventEmitter, AfterViewInit, Output, Renderer2 } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { MultipleDataComponent_SummaryInfo } from '../BaseMultipleDataEntryFormViewModel';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ComposeComponent } from 'Fw/Components/ComposeComponent';
import { DxDataGridComponent } from 'devextreme-angular';
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import { AsyncSubject } from "rxjs";
import { ShowBoxTypeEnum } from "NebulaClient/Utils/Enums/ShowBoxTypeEnum";



@Component({
    selector: 'MultipleDataComponentForm',
    templateUrl: './MultipleDataComponentForm.html',
    providers: [MessageService, SystemApiService]
})
export class MultipleDataComponentForm extends TTVisual.TTForm implements OnInit, OnDestroy, AfterViewInit {

    private MultipleDataComponentForm_DocumentUrl: string = '/api/MultipleDataComponent/MultipleDataComponentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, public renderer: Renderer2) {
        super('', 'MultipleDataComponentForm');
        this._DocumentServiceUrl = this.MultipleDataComponentForm_DocumentUrl;

    }
    public componentInfo: DynamicComponentInfo;

    private _summaryInfoList: Array<MultipleDataComponent_SummaryInfo>;
    private saveEventSubscription: any;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    @ViewChild('multipleDataComponent') MultipleDataComponent: ComposeComponent;
    @ViewChild(DxDataGridComponent) Grid: DxDataGridComponent;

    @Input() set SummaryInfoList(value: Array<MultipleDataComponent_SummaryInfo>) {
        this._summaryInfoList = value;

    }
    get SummaryInfoList(): Array<MultipleDataComponent_SummaryInfo> {
        return this._summaryInfoList;
    }
    private _objectDefName: string;
    @Input() set ObjectDefName(value: string) {
        this._objectDefName = value;
    }
    get ObjectDefName(): string {
        return this._objectDefName;
    }
    @Input() episodeAction: EpisodeAction;
    @Input() title: string;
    @Input() IsReadOnly: boolean;

    private _isFormOpenPopup: boolean = false;//Formun panel içinde ya da popup üzerinde açılacağı kontrolü (true ise popup false ise panel içinden açılır.)
    @Input() set IsFormOpenPopup(value: boolean) {
        this._isFormOpenPopup = value;
    }
    get IsFormOpenPopup(): boolean {
        return this._isFormOpenPopup;
    }

    private _isTitleRed: boolean = false;//panelin başlığının kırmızı görünüp görünmeyeceğini belirler.
    @Input() set IsTitleRed(value: boolean) {
        this._isTitleRed = value;
    }
    get IsTitleRed(): boolean {
        return this._isTitleRed;
    }

    public selectedObjectId: Guid;

    @Output() MultipleDataComponentSaved: EventEmitter<Guid> = new EventEmitter<Guid>();

    /* Form ismine göre form id veiyoruz ki id ye göre açsın*/ // MultipleDataComponent için
    getFormDefIdByObjectDefName(): Guid {
        switch (this.ObjectDefName) {
            case 'GLASKOWSCORE':
                return new Guid('fd736b74-7edd-440c-8991-801ba662da66');
            case 'APACHESCORE':
                return new Guid('b3c128db-9e82-4496-af79-184b33eaa4b8');
            case 'SAPSSCORE':
                return new Guid('9115e74d-505d-4470-9638-a9d88439692a');
            case 'BABYOBSTETRICINFORMATION':
                return new Guid('4a0db5f5-7f8b-4497-9376-0bd6cf01f0b4');
            case 'APGAR':
                return new Guid('a5b46756-c623-4bdf-805f-38607c08f753');
            case 'BALLARDNEUROMUSCULAR':
                return new Guid('a0a5fd54-01a7-4283-9080-bc2df8adc3ce');
            case 'BALLARDPHYSICAL':
                return new Guid('e034bdb8-353d-4d46-acc7-718ca115d0a0');
            case 'GENERALINFORMATION':
                return new Guid('3c049ba8-6a1d-4d63-9fa7-2d09c7648421');
            case 'PHOTOTHERAPY':
                return new Guid('266d2af0-876f-4a98-a076-51fec38da0c3');
            case 'SNAPPE':
                return new Guid('242eaf4f-6bfd-4503-933f-50f1e937668a');
            case 'WEIGHTCHART':
                return new Guid('863d0d01-310e-4189-b489-b5072fc1423d');
            case 'HEMODIALYSISINSTRUCTION':
                return new Guid('eb90060e-2fd7-410a-b9f9-721ecf448010');
            case 'PRISM':
                return new Guid('0cd5aa2d-ba1e-4e2b-82d6-866b026e03e5');

            default:
                return null;
        }
    }

    public SummaryInfoColumns = [

        {
            caption: i18n("M16886", "İşlem Tarihi"),
            dataField: "EntryDate",
            format: 'dd/MM/yyyy',
            dataType: 'date',
            width: 150,
            allowSorting: true
        },
        {
            "caption": "İşlemi Giren",
            dataField: "EntryUserName",
            width: 100,
            //cellTemplate: "PriorityCellTemplate",
            allowSorting: true
        },
        {
            'caption': i18n("M16872", "İşlem Özeti"),
            dataField: 'Summary',
            width: 'auto',
            allowSorting: true
        }
    ];

    async select(value: any): Promise<void> {
        if (value != null && value.rowType == "data" != null && value.data != null) {
            let _objectID: Guid = value.data.ObjectID;
            if (_objectID != null) {
                this.showForm = true;
                this.componentInfo = await this.systemApiService.open(_objectID, this.ObjectDefName, this.getFormDefIdByObjectDefName());
                if (this.episodeAction != null) {
                    this.componentInfo.InputParam = new DynamicComponentInputParam("", new ActiveIDsModel(this.episodeAction.ObjectID, this.episodeAction.Episode.ObjectID, null));
                }
                this.selectedObjectId = _objectID;
                console.log();
            }
        }

        //onSelectionChanged

        //if (value != null && value.selectedRowsData != null && value.selectedRowsData.length > 0) {
        //    let _objectID: Guid = value.selectedRowsData[0].ObjectID;
        //    if (_objectID != null) {
        //        this.componentInfo = await this.systemApiService.open(_objectID, this.ObjectDefName, this.getFormDefIdByObjectDefName());
        //        this.selectedObjectId = _objectID;
        //        console.log();
        //    }
        //}
    }

    async btnAdd_valueChange(value: any): Promise<void> {
        this.showForm = true;
        this.componentInfo = await this.systemApiService.new(this.ObjectDefName, null, this.getFormDefIdByObjectDefName());
        if (this.episodeAction != null) {
            this.componentInfo.InputParam = new DynamicComponentInputParam("", new ActiveIDsModel(this.episodeAction.ObjectID, this.episodeAction.Episode.ObjectID, null));
        }
    }

    public showForm: boolean = false;
    onMultipleDataComponent_SaveClick(savedObjectID: Guid) {

        if (this.MultipleDataComponent != null) {
            this.MultipleDataComponent.destroyComponent();
        }

        this.MultipleDataComponentSaved.emit(savedObjectID);

        this.getSavedObjectSummaryInfoAndAddToList(savedObjectID).then(result => {
            let that = this;
            let MultipleDataComponent_SummaryInfo: MultipleDataComponent_SummaryInfo = result as MultipleDataComponent_SummaryInfo;

            let index = that.SummaryInfoList.findIndex(dr => dr.ObjectID.valueOf() === savedObjectID.valueOf());
            if (index != null && index > -1) {
                that.SummaryInfoList[index] = MultipleDataComponent_SummaryInfo;
            }
            else {
                that.SummaryInfoList.unshift(MultipleDataComponent_SummaryInfo);
            }

        }).catch(err => {
            console.log(err);
            this.messageService.showError(err);
        });
    }

    protected getSavedObjectSummaryInfoAndAddToList(savedObjectID: Guid): Promise<MultipleDataComponent_SummaryInfo> {
        let that = this;
        return new Promise<MultipleDataComponent_SummaryInfo>((resolve, reject) => {
            this.httpService.get<MultipleDataComponent_SummaryInfo>("/api/BaseMultipleDataEntryService/GetSummaryInfoByObjectId?ObjectId=" + savedObjectID)
                .then(response => {
                    let ndcSi = response as MultipleDataComponent_SummaryInfo;
                    resolve(ndcSi);
                })
                .catch(error => {
                    reject(error);
                });
        });


    }

    //daha fazla göster dediğimiz zaman aşağı otomatik scroll etsin
    contentReady(event: any) {
        let that = this;

        if (that.Grid.instance != null) {
            let scrollable: any = that.Grid.instance.getScrollable();
            if (that.SummaryInfoList != null && that.SummaryInfoList.length > 0) {
                let element = that.Grid.instance.getRowElement(that.SummaryInfoList.length - 1);
                scrollable.scrollToElement(element);
            }
        }
    }

    public getNextSummaryInfoSetAndAddToList(): Promise<Array<MultipleDataComponent_SummaryInfo>> {
        let that = this;
        this.loadMultipleDataGrid(true, i18n("M24606", "Yeni veriler yükleniyor, lütfen bekleyiniz."));
        return new Promise<Array<MultipleDataComponent_SummaryInfo>>((resolve, reject) => {
            this.httpService.get<Array<MultipleDataComponent_SummaryInfo>>("/api/BaseMultipleDataEntryService/GetNextSummaryInfoSetAndAddToList?count=" + that.SummaryInfoList.length + "&objectDefName=" + that.ObjectDefName + "&episodeActionID=" + that.episodeAction.ObjectID)
                .then(response => {
                    let ndcSiList: Array<MultipleDataComponent_SummaryInfo> = response as Array<MultipleDataComponent_SummaryInfo>;

                    if (ndcSiList.length == 0) {
                        this.messageService.showInfo(i18n("M14933", "Gösterilecek daha fazla veri mevcut değil."));
                        this.loadMultipleDataGrid(false, '');
                        return;
                    }

                    ndcSiList.forEach(ndcsi => {
                        that.SummaryInfoList.push(ndcsi);
                    });

                    this.loadMultipleDataGrid(false, '');
                    resolve();
                })
                .catch(error => {
                    this.loadMultipleDataGrid(false, '');
                    reject(error);
                });
        });
    }

    rowPrepared(event: any) {
        if (event.rowType == "data") {
            let MultipleDataComponent_SummaryInfo: MultipleDataComponent_SummaryInfo = event.data as MultipleDataComponent_SummaryInfo;
            if (MultipleDataComponent_SummaryInfo.RowColor != "")
                // event.rowElement.firstItem().css('background-color', MultipleDataComponent_SummaryInfo.RowColor);
                this.renderer.setStyle(event.rowElement.firstItem(), "background-color", MultipleDataComponent_SummaryInfo.RowColor);
        }
    }

    toolbarPreparing(e) {
        e.toolbarOptions.items.unshift({
            location: 'after',
            widget: 'dxButton',
            options: {
                hint: 'Collapse All',
                icon: 'chevrondown',
                onClick: this.getNextSummaryInfoSetAndAddToList.bind(this)
            }
        });
    }

    rowInserted(e) {
        let scrollable = e.component.getView('rowsView')._scrollable;
        let selectedRowElements = e.component.element().find('dx-row dx-data-row dx-column-lines');
        scrollable.scrollToElement(selectedRowElements);
    }

    loadMultipleDataGrid(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public onComponentCreated(componentRef: ComponentRef<any>): void {
        componentRef.instance['EpisodeAction'] = this.episodeAction;
        componentRef.instance['NursAppReadOnly'] = this.IsReadOnly;

        let eventName = 'saveEventEmitter';
        this.showForm = true;

        let funcCheck = <any>componentRef.instance[eventName];
        if (funcCheck != null) {
            if (funcCheck instanceof EventEmitter) {
                let targetEvent = funcCheck as EventEmitter<any>;
                let boundedFunc = this.onMultipleDataComponent_SaveClick.bind(this);
                this.saveEventSubscription = targetEvent.subscribe(boundedFunc);
            }
        }
    }

    public onDynamicComponentClosed(event: any) {
        this.showForm = false;
    }
    // ***** Method declarations start *****


    // *****Method declarations end *****

    ngAfterViewInit() {
        // console.log(this.MultipleDataComponent);
    }

    ngOnDestroy() {
        if (this.saveEventSubscription != null) {
            this.saveEventSubscription.unsubscribe();
        }
    }


    async ngOnInit() {
        //await this.load();

    }

    async  onRowDeleted(data) {



        let jqDeferred = new AsyncSubject<boolean>(); // jQuery.Deferred();
        data.cancel = jqDeferred.toPromise();

        let ttUser = TTUser.CurrentUser;
        let currentUser: ResUser = <ResUser>ttUser.UserObject;


        if (ttUser.IsSuperUser != true && data.data.EntryUserName != undefined && data.data.EntryUserName != null && data.data.EntryUserName.toString() != currentUser.Name.toString()) {
            ServiceLocator.MessageService.showError(i18n("M16917", "İşlemi silme yetkiniz bulunmamaktadır!"));
            jqDeferred.next(true);
            jqDeferred.complete();
        }
        else {
            let closeMultipleDataComponent = false;
            let objectId: string = null;

            if (data.data != null && data != null) {
                if (data.data.ObjectID != null && data.data.ObjectID.id != null) {
                    objectId = data.data.ObjectID.id.toString();
                }
                else {
                    objectId = data.data.ObjectID.toString();
                }
            }
            if (objectId != null) {
                let apiUrl: string = '/api/BaseMultipleDataEntryService/DeleteMultibleDataEntry?objectID=' + objectId;
                if (this.MultipleDataComponent != null && this.MultipleDataComponent.Info != null && this.MultipleDataComponent.Info.objectID != null && this.MultipleDataComponent.Info.objectID.toString() == objectId) {
                    closeMultipleDataComponent = true;
                }

                this.httpService.get<string>(apiUrl)
                    .then(response => {
                        let result: string = response as string;
                        if (result != "") {
                            ServiceLocator.MessageService.showError(result);
                            jqDeferred.next(true);
                            jqDeferred.complete();

                        }
                        else {
                            jqDeferred.next(false);
                            jqDeferred.complete();
                            if (this.MultipleDataComponent != null && closeMultipleDataComponent) {
                                this.MultipleDataComponent.destroyComponent();
                            }
                            ServiceLocator.MessageService.showInfo(i18n("M21530", "Seçilen İşlemler Başarılı Bir Şekilde Silindi"));
                        }
                    })
                    .catch(error => {
                        ServiceLocator.MessageService.showError(error);
                        jqDeferred.next(true);
                        jqDeferred.complete();
                    });
            }
            else {
                ServiceLocator.MessageService.showError("Silinecek satırın ObjectIDsi bulunamaddı");
                jqDeferred.next(true);
                jqDeferred.complete();
            }
        }

    }


}






