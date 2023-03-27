//$0D23E1A1
import { Component, ViewChild, Renderer2 } from '@angular/core';
import { TeletipWorkListViewModel, OrderStatusForAccessionNumber_Output } from './TeletipWorkListViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { DxDataGridComponent, DxAccordionComponent } from "devextreme-angular";
import { IActiveEpisodeActionService } from 'Fw/Services/IActiveEpisodeActionService';

@Component({
    selector: 'teletip-workList-form',
    templateUrl: './TeletipWorkListForm.html',
    providers: [SystemApiService, MessageService]
})
export class TeletipWorkListForm extends BaseComponent<TeletipWorkListViewModel> {

    public teletipWorkListViewModel: TeletipWorkListViewModel = new TeletipWorkListViewModel();
    public selectedRowKeysResultList: Array<OrderStatusForAccessionNumber_Output> = [];
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    public WorkListColumns = [];

    @ViewChild('ortezProtezWorkListGrid') ortezProtezWorkListGrid: DxDataGridComponent;
    @ViewChild('searchAccordion') searchAccordion: DxAccordionComponent;

    btnListele: TTVisual.ITTButton;
    isComponentOpened: boolean = false;



    constructor(protected httpService: NeHttpService, protected messageService: MessageService, container: ServiceContainer, public systemApiService: SystemApiService, private activeEpisodeActionService: IActiveEpisodeActionService, private renderer: Renderer2) {
        super(container);
        this.initFormControls();
        this.generateColumns();
    }

    ngOnDestroy() {
        //this.activeEpisodeActionService.ActiveEpisodeActionID = Guid.Empty;
    }

    getWorkList() {

        let that = this;
        if (this.teletipWorkListViewModel._teletipWorkListSearchCriteria.uniqueRefNo == null && this.teletipWorkListViewModel._teletipWorkListSearchCriteria.accessionno == null
            && this.teletipWorkListViewModel._teletipWorkListSearchCriteria.workListStartDate == null && this.teletipWorkListViewModel._teletipWorkListSearchCriteria.workListEndDate == null) {
            ServiceLocator.MessageService.showError("En az bir tane kriteri doldurmalısınız");
        }
        else if((this.teletipWorkListViewModel._teletipWorkListSearchCriteria.workListStartDate == null && this.teletipWorkListViewModel._teletipWorkListSearchCriteria.workListEndDate != null)
                || (this.teletipWorkListViewModel._teletipWorkListSearchCriteria.workListStartDate != null && this.teletipWorkListViewModel._teletipWorkListSearchCriteria.workListEndDate == null)){
            ServiceLocator.MessageService.showError("Başlangıç ve bitiş tarihini birlikte seçmelisiniz");
        }
        else {
            this.loadPanelOperation(true, 'İşlemler listeleniyor, lütfen bekleyiniz.');
            that.httpService.post<OrderStatusForAccessionNumber_Output[]>("api/TeletipWorkListService/GetTeletipActionWorkList", that.teletipWorkListViewModel._teletipWorkListSearchCriteria)
                .then(response => {
                    that.teletipWorkListViewModel.teletipActionList =  response as OrderStatusForAccessionNumber_Output[];

                    this.systemApiService.componentInfo = null;
                    this.loadPanelOperation(false, '');
                })
                .catch(error => {
                    this.loadPanelOperation(false, '');
                    this.messageService.showError(error);

                });
        }

        // });
    }

    generateColumns()
    {
        let that = this;
        that.WorkListColumns = [
            {
                caption: "Accession No",
                dataField: "AccessionNumber",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },
            {
                caption: "TC Kimlik No",
                dataField: "CitizenId",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },            
            {
                caption: "Hizmet Kodu",
                dataField: "SutCode",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },
            {
                caption: "Teletıp Durumu",
                dataField: "TeletipStatus",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },
            {
                caption: "Medula Durumu",
                dataField: "MedulaStatus",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },
            {
                caption: "Görüntü Durumu",
                dataField: "WadoStatus",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },
            {
                caption: "Rapor Durumu",
                dataField: "ReportStatus",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },
            {
                caption: "Son Medula Gönderim Zamanı",
                dataField: "LastMedulaSendDate",
                dataType: 'date',
                format: "dd/MM/yyyy",
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },
            {
                caption: "Medula Cevabı",
                dataField: "MedulaResponseMessage",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },
            {
                caption: "İstem Gönderim",
                dataField: "ScheduleDate",
                dataType: 'date',
                format: "dd/MM/yyyy",
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },
            {
                caption: "Rapor Zamanı",
                dataField: "PerformedDate",
                dataType: 'date',
                format: "dd/MM/yyyy",
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },
            {
                caption: "Hata Bilgisi",
                dataField: "Error",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },
            {
                caption: "Hasta Geçmiş Durumu",
                dataField: "PatientHistorySearchStatus",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                allowEditing: false
            }
            
            

        ];
    }

    async clientPreScript() {
        // let a = this.getDietList();
    }

    clientPostScript(state: String): void {
        // throw new Error('Method not implemented.');
    }

    async select(value: any): Promise<void> {

    }

    public initFormControls(): void {

        this.btnListele = new TTVisual.TTButton();
        this.btnListele.Text = i18n("M27337", "Listele");
        this.btnListele.Name = "btnListele";
        this.btnListele.TabIndex = 12;
    }

    public btnSearchClicked(): void {

        let a = this.getWorkList();
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public dynamicComponentClosed(e: any) {
        this.isComponentOpened = false;
        let that = this;
        setTimeout(function () {
            if (that.ortezProtezWorkListGrid != null && that.ortezProtezWorkListGrid.instance != null && that.ortezProtezWorkListGrid.instance["_disposed"] == null)
            {
                that.ortezProtezWorkListGrid.instance.repaint();
            }
        }, 30);
        //that.activeEpisodeActionService.ActiveEpisodeActionID = Guid.Empty;
    }

    public componentCreated(e: any) {
        this.isComponentOpened = true;
        this.loadPanelOperation(false, '');
        let that = this;
        setTimeout(function () {
            that.ortezProtezWorkListGrid.instance.repaint();
        }, 300);
    }

    public onRowPrepared(e: any): void {
        //e.rowElement.firstItem().css({ 'line-height': '12px' });
        this.renderer.setStyle(e.rowElement.firstItem(), "line-height", "12px");
    }

    public textBoxKeyPress(e: any) {
        let charArray: Array<string> = new Array<string>();
        let _jQueryEvent: string = e.jQueryEvent.key;

        charArray = ['ç', 'Ç', 'ö', 'Ö', 'ş', 'Ş', 'ü', 'Ü', 'Ğ', 'ğ', 'ı', 'İ', '-'];

        if ((_jQueryEvent < 'A' || _jQueryEvent > 'z') && charArray.findIndex(p => p == _jQueryEvent) < 0)
            e.jQueryEvent.preventDefault();
    }

    keyDownForNumericControl(event: any) {

        if (event != null && event.srcElement != null && event.srcElement.value != null && event.srcElement.value.length < 11 && !(new RegExp('[\.,]', 'g')).test(event.key)) {

        }
        else {
            event.preventDefault();
        }
    }

}



