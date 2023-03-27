//$0976C95F
import { Component, ViewChild, OnInit, OnDestroy, Input, ComponentRef, EventEmitter, AfterViewInit, Output, Renderer2 } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { NursingApplication } from 'NebulaClient/Model/AtlasClientModel';
import { NursingDynamicComponent_SummaryInfo } from '../NursingApplicationMainFormViewModel';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ComposeComponent } from 'Fw/Components/ComposeComponent';
import { DxDataGridComponent } from 'devextreme-angular';


@Component({
    selector: 'NursingDynamicComponentForm',
    templateUrl: './NursingDynamicComponentForm.html',
    providers: [MessageService, SystemApiService]
})
export class NursingDynamicComponentForm extends TTVisual.TTForm implements OnInit, OnDestroy, AfterViewInit {

    private NursingDynamicComponentForm_DocumentUrl: string = '/api/NursingDynamicComponent/NursingDynamicComponentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, public renderer: Renderer2) {
        super('', 'NursingDynamicComponentForm');
        this._DocumentServiceUrl = this.NursingDynamicComponentForm_DocumentUrl;

    }
    public componentInfo: DynamicComponentInfo;

    private _summaryInfoList: Array<NursingDynamicComponent_SummaryInfo>;
    private saveEventSubscription: any;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    @ViewChild('nursingDynamicComponent') nursingDynamicComponent: ComposeComponent;
    @ViewChild(DxDataGridComponent) Grid: DxDataGridComponent;

    @Input() set SummaryInfoList(value: Array<NursingDynamicComponent_SummaryInfo>) {
        this._summaryInfoList = value;

    }
    get SummaryInfoList(): Array<NursingDynamicComponent_SummaryInfo> {
        return this._summaryInfoList;
    }
    private _objectDefName: string;
    @Input() set ObjectDefName(value: string) {
        this._objectDefName = value;
    }
    get ObjectDefName(): string {
        return this._objectDefName;
    }
    private _addButtonHidden: boolean = false;
    @Input() set AddButtonHidden(value: boolean) {
        if (this._isReadOnly != true)
            this._addButtonHidden = value;
        else
            this._addButtonHidden = true; // Eğer IsreadOnly ise her zmana Buton Hide true olur
    }
    get AddButtonHidden(): boolean {
        return this._addButtonHidden;
    }
    @Input() nursingApplication: NursingApplication;
    @Input() title: string;

    private _isReadOnly: boolean = false;
    @Input() set IsReadOnly(value: boolean) {
        this._isReadOnly = value;
        if (value == true) {
            this.AddButtonHidden = true; // Eğer IsreadOnly ise her zmana Buton Hide true olur
        }
    }
    get IsReadOnly(): boolean {
        return this._isReadOnly;
    }

    private _hasShowComponentRole: boolean = true;
    @Input() set HasShowComponentRole(value: boolean) {
        if (value == null)
            this._hasShowComponentRole = true;//null olanlar default gösterilsin
        else
            this._hasShowComponentRole = value; 
    }
    get HasShowComponentRole(): boolean {
        return this._hasShowComponentRole;
    }

    public selectedObjectId: Guid;

    @Output() NursingDynamicComponentSaved: EventEmitter<Guid> = new EventEmitter<Guid>();

    /* Form ismine göre form id veiyoruz ki id ye göre açsın*/
    getFormDefIdByObjectDefName(): Guid {
        switch (this.ObjectDefName) {
            case 'NURSINGAPPLIPROGRESS':
                return new Guid('585d05f0-2320-42f5-b115-5269be2d15ec');
            case 'NURSINGGLASKOWCOMASCALE':
                return new Guid('4c8deecc-3e6f-40aa-95da-23e1a9beb489');
            case 'NURSINGPUPILSYMPTOMS':
                return new Guid('d43612b4-6aad-4d92-9b82-73ca529210cd');
            case 'NURSINGPAINSCALE':
                return new Guid('c7f14c45-b5c9-4f5a-9700-a028709eb494');
            case 'NURSINGSPIRITUALEVALUATION':
                return new Guid('f718ffa4-5736-42be-bc8b-c10e95ff9c8b');
            case 'NURSINGNUTRITIONASSESSMENT':
                return new Guid('fb0838c3-2d88-496b-bb3f-425f760f0a12');
            case 'NURSINGDAILYLIFEACTIVITY':
                return new Guid('101415a0-3599-4b7f-a240-ba7031eeaee2');
            case 'BASENURSINGPATIENTANDFAMILYINSTRUCTION':
                return new Guid('1ccd1eec-e7ec-4d96-8186-f72a553ac306');
            case 'NURSINGCARE':
                return new Guid('4562cfba-d59c-4159-9aae-fe9b62aa71e6');
            case 'BASENURSINGSYSTEMINTERROGATION':
                return new Guid('a3c22a42-52ba-4ca2-85e8-2431fcab9d23');
            case 'BASENURSINGDISCHARGINGINSTRUCTIONPLAN':
                return new Guid('5e99cdf9-e286-49e8-a272-8b4a7eac7da3');
            case 'BASENURSINGFALLINGDOWNRISK':
                return new Guid('aee9e039-6a5c-46ce-a4e3-68901badb042');
            case 'NURSINGWOUNDASSESSMENTSCALE':
                return new Guid('2813724d-e180-4880-b65c-ce911d4bb659');
            case 'NURSINGLEGMEASUREMENT':
                return new Guid('b7f74f05-5fd3-4dba-b550-d801e6120f96');
            case 'NURSINGNUTRITIONALRISKASSESSMENT':
                return new Guid('1ae8e372-5e7c-4293-bd51-e6eb70de46ab');
            case 'NURSINGBODYFLUIDANALYSIS':
                return new Guid('2906ff16-625a-4eab-8728-1a761fc313d8');
            case 'NURSINGPATIENTPREASSESSMENT':
                return new Guid('c5dcb97b-720b-4e2b-8ba6-314178f652d0');
            case 'NURSINGWOUNDEDASSESMENT':
                return new Guid('dc22c2a2-c9a9-442a-b3dc-0f720a418b19');
            default:
                return null;
        }
    }

    public SummaryInfoColumns = [

        {
            caption: i18n("M23763", "Uygulama Tarihi"),
            dataField: "ApplicationDate",
            format: 'dd/MM/yyyy',
            dataType: 'date',
            width: 150,
            allowSorting: true
        },
        {
            "caption": i18n("M23799", "Uygulayan Kişi"),
            dataField: "ApplicationUserName",
            width: 100,
            //cellTemplate: "PriorityCellTemplate",
            allowSorting: true
        },
        {
            'caption': i18n("M16872", "İşlem Özeti"),
            dataField: 'ApplicationSummary',
            width: 'auto',
            allowSorting: true
        }
    ];

    async select(value: any): Promise<void> {
        if (value != null && value.rowType == "data" != null && value.data != null) {
            let _objectID: Guid = value.data.ObjectID;
            if (_objectID != null) {
                this.componentInfo = await this.systemApiService.open(_objectID, this.ObjectDefName, this.getFormDefIdByObjectDefName());
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
        this.componentInfo = await this.systemApiService.new(this.ObjectDefName, null, this.getFormDefIdByObjectDefName());
    }

    onNursingDynamicComponent_SaveClick(savedObjectID: Guid) {

        if (this.nursingDynamicComponent != null) {
            this.nursingDynamicComponent.destroyComponent();
        }

        this.NursingDynamicComponentSaved.emit(savedObjectID);

        this.getSavedObjectSummaryInfoAndAddToList(savedObjectID).then(result => {
            let that = this;
            let nursingDynamicComponent_SummaryInfo: NursingDynamicComponent_SummaryInfo = result as NursingDynamicComponent_SummaryInfo;

            let index = that.SummaryInfoList.findIndex(dr => dr.ObjectID.valueOf() === savedObjectID.valueOf());
            if (index != null && index > -1 && nursingDynamicComponent_SummaryInfo.isDeleted == true) {
                that.SummaryInfoList.splice(index, 1);
            } else if (index != null && index > -1) {
                that.SummaryInfoList[index] = nursingDynamicComponent_SummaryInfo;
            }
            else {
                that.SummaryInfoList.unshift(nursingDynamicComponent_SummaryInfo);
            }

        }).catch(err => {
            console.log(err);
            this.messageService.showError(err);
        });
    }

    protected getSavedObjectSummaryInfoAndAddToList(savedObjectID: Guid): Promise<NursingDynamicComponent_SummaryInfo> {
        let that = this;
        return new Promise<NursingDynamicComponent_SummaryInfo>((resolve, reject) => {
            this.httpService.get<NursingDynamicComponent_SummaryInfo>("/api/NursingApplicationService/GetSummaryInfoByObjectId?ObjectId=" + savedObjectID)
                .then(response => {
                    let ndcSi = response as NursingDynamicComponent_SummaryInfo;
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

    public getNextSummaryInfoSetAndAddToList(): Promise<Array<NursingDynamicComponent_SummaryInfo>> {
        let that = this;
        this.loadNursingAppGrid(true, i18n("M24606", "Yeni veriler yükleniyor, lütfen bekleyiniz."));
        return new Promise<Array<NursingDynamicComponent_SummaryInfo>>((resolve, reject) => {
            this.httpService.get<Array<NursingDynamicComponent_SummaryInfo>>("/api/NursingApplicationService/GetNextSummaryInfoSetAndAddToList?count=" + that.SummaryInfoList.length + "&objectDefName=" + that.ObjectDefName + "&nursingApplicationID=" + that.nursingApplication.ObjectID)
                .then(response => {
                    let ndcSiList: Array<NursingDynamicComponent_SummaryInfo> = response as Array<NursingDynamicComponent_SummaryInfo>;

                    if (ndcSiList.length == 0) {
                        this.messageService.showInfo(i18n("M14933", "Gösterilecek daha fazla veri mevcut değil."));
                        this.loadNursingAppGrid(false, '');
                        return;
                    }

                    ndcSiList.forEach(ndcsi => {
                        that.SummaryInfoList.push(ndcsi);
                    });

                    this.loadNursingAppGrid(false, '');
                    resolve();
                })
                .catch(error => {
                    this.loadNursingAppGrid(false, '');
                    reject(error);
                });
        });
    }

    rowPrepared(event: any) {
        if (event.rowType == "data") {
            let nursingDynamicComponent_SummaryInfo: NursingDynamicComponent_SummaryInfo = event.data as NursingDynamicComponent_SummaryInfo;
            if (nursingDynamicComponent_SummaryInfo.RowColor != "")
                //event.rowElement.firstItem().css('background-color', nursingDynamicComponent_SummaryInfo.RowColor);
                this.renderer.setStyle(event.rowElement.firstItem(), "background-color", nursingDynamicComponent_SummaryInfo.RowColor);

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

    loadNursingAppGrid(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public onComponentCreated(componentRef: ComponentRef<any>): void {
        componentRef.instance['NursingApplication'] = this.nursingApplication;
        componentRef.instance['NursAppReadOnly'] = this.IsReadOnly;

        let eventName = 'saveEventEmitter';

        let funcCheck = <any>componentRef.instance[eventName];
        if (funcCheck != null) {
            if (funcCheck instanceof EventEmitter) {
                let targetEvent = funcCheck as EventEmitter<any>;
                let boundedFunc = this.onNursingDynamicComponent_SaveClick.bind(this);
                this.saveEventSubscription = targetEvent.subscribe(boundedFunc);
            }
        }
    }

    // ***** Method declarations start *****


    // *****Method declarations end *****

    ngAfterViewInit() {
        // console.log(this.nursingDynamicComponent);
    }

    ngOnDestroy() {
        if (this.saveEventSubscription != null) {
            this.saveEventSubscription.unsubscribe();
        }
    }


    async ngOnInit() {
    }



}






