//$0D23E1A1
import { Component, ViewChild, Renderer2 } from '@angular/core';
import { SosyalHizmetlerWorkListFormViewModel, ComboModel, SosyalHizmetlerWorkListFormItemModel, SosyalHizmetlerWorkListFormSearchCriteria } from './SosyalHizmetlerWorkListFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionWorkListStateItem } from "Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { DxDataGridComponent, DxAccordionComponent } from "devextreme-angular";
import { Subscription } from 'rxjs';
import { IActiveEpisodeActionService } from 'Fw/Services/IActiveEpisodeActionService';

@Component({
    selector: 'sosyalHizmetler-WorkList-Form',
    templateUrl: './SosyalHizmetlerWorkListForm.html',
    providers: [SystemApiService, MessageService]
})
export class SosyalHizmetlerWorkListForm {

    public sosyalHizmetlerWorkListFormViewModel: SosyalHizmetlerWorkListFormViewModel = new SosyalHizmetlerWorkListFormViewModel();
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    public SocialServicesStateItems: Array<EpisodeActionWorkListStateItem>;
    public PatientTypeList = [];
    public doctorArray: Array<any> = [];
    public clinicArray: Array<any> = [];
    public PatientInterviewFormStatesList: Array<ComboModel>;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    public lastSelectedObjectid: string;
    public refreshForm: boolean;

    @ViewChild('sosyalHizmetlerWorkListGrid') sosyalHizmetlerWorkListGrid: DxDataGridComponent;
    @ViewChild('searchAccordion') searchAccordion: DxAccordionComponent;

    btnListele: TTVisual.ITTButton;
    isComponentOpened: boolean = false;

    private sosyalHizmetlerWorkListSubscription: Subscription;


    public WorkListColumns = [
        {
            caption: i18n("M27422", "Hasta Tipi"),
            dataField: "PatientType",
            dataType: "string",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M17021", "Kabul No"),
            dataField: "ProtocolNo",
            dataType: "string",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M13372", "İşlemin Durumu"),
            dataField: "State",
            dataType: "string",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M15133", "Hasta Adı Soyadı"),
            dataField: "PatientNameSurname",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M17579", "T.C. Kimlik Numarası"),
            dataField: "UniqueRefno",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M17621", "Klinik / Servis"),
            dataField: "FromResource",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M19602", "Oda"),
            dataField: "RoomNo",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M24353", "Yatak"),
            dataField: "BedNo",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M22183", "Sosyal Hizmet Uzmanı"),
            dataField: "ProcedureByUser",
            dataType: "string",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M16650", "İstek Tarihi"),
            dataField: "RequestDate",
            dataType: "date",
            format: "dd/MM/yyyy",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M16885", "İşlem Tamamlama Tarihi"),
            dataField: "CompleteDate",
            dataType: "date",
            format: "dd/MM/yyyy HH:mm:ss",
            width: "auto",
            allowSorting: true
        },

        {
            caption: i18n("M22176", "Sosyal Güvencesi"),
            dataField: "Payer",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M12323", "Çalışma Durumu"),
            dataField: "WorkStatus",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M27441", "Başvuru Türü"),
            dataField: "AdmissionType",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M15322", "Hasta Türü"),
            dataField: "PatientStatus",
            dataType: "string",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M14664", "Geliş Sebebi"),
            dataField: "ComingReason",
            dataType: "string",
            allowSorting: true
        },
    ];


    onRowPreparedActionList(e: any): void {
        //e.rowElement.firstItem().css({ 'line-height': '12px' });
        this.renderer.setStyle(e.rowElement.firstItem(), 'line-height', '12px');
        /*if (e.rowElement.firstItem() !== undefined && e.rowType !== 'header' && e.rowType !== 'filter' && e.rowElement.firstItem().length === 1) {
            let State = e.data.State;

            if (State === "Tamamlandı") {
                e.rowElement.firstItem().style.backgroundColor = '#b3ffb3';
                //e.rowElement.firstItem().style.color = '#11583D';
            }
            else if (State === "İşlem İptal Edildi") {
                e.rowElement.firstItem().style.backgroundColor = '#ff8080';
                //e.rowElement.firstItem().style.color = '#11583D';
            }

        }*/
    }

    userSearchModelLoaded(value) {
        if (value != null)
            this.sosyalHizmetlerWorkListFormViewModel._sosyalHizmetlerWorkListFormSearchCriteria = JSON.parse(value);
        else
            this.sosyalHizmetlerWorkListFormViewModel._sosyalHizmetlerWorkListFormSearchCriteria = new SosyalHizmetlerWorkListFormSearchCriteria();
    }

    constructor(protected httpService: NeHttpService, protected messageService: MessageService, container: ServiceContainer,
         private activeEpisodeActionService: IActiveEpisodeActionService, public systemApiService: SystemApiService,
         private renderer: Renderer2) {
        // super(container);
        this.initFormControls();


        this.PatientTypeList = [
            {
                TypeName: 'Tümü',
                TypeID: -1
            }, {
                TypeName: 'Ayaktan',
                TypeID: 0
            }, {
                TypeName: 'Yatan',
                TypeID: 1
            }];

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "ConsultationRequesterUserList";
        this.ProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 154;
        this.ProcedureDoctor.ListFilterExpression = "USERRESOURCES.RESOURCE ='0826bcf2-5837-4f4f-ab87-e684a597f7e5'";


        let that = this;
        this.sosyalHizmetlerWorkListSubscription = this.httpService.episodeActionWorkListSharedService.RefreshEpisodeActionWorkList.subscribe(
            RefreshEpisodeActionWorkList => {
                if (RefreshEpisodeActionWorkList) {
                    this.refreshForm = true;
                   this.callGetActionList();
                   this.accordionIndexChange(false);
                    setTimeout(function () {
                        that.loadPanelOperation(true, 'Form hazırlanıyor, lütfen bekleyiniz.');
                        //that.activeEpisodeActionService.ActiveEpisodeActionID = new Guid(that.lastSelectedObjectid);
                        that.openDynamicComponent("PATIENTINTERVIEWFORM", that.lastSelectedObjectid);
                    }, 300);
                }
            });
        this.sosyalHizmetlerWorkListFormViewModel._sosyalHizmetlerWorkListFormSearchCriteria = new SosyalHizmetlerWorkListFormSearchCriteria();
        this.sosyalHizmetlerWorkListFormViewModel._sosyalHizmetlerWorkListFormSearchCriteria.workListStartDate = new Date();
        this.sosyalHizmetlerWorkListFormViewModel._sosyalHizmetlerWorkListFormSearchCriteria.workListEndDate = new Date();
    }

    async callGetActionList(){
        await this.getActionList();
    }

    createStates() {
        this.PatientInterviewFormStatesList = new Array<ComboModel>();
        let cmbModel = new ComboModel();
        cmbModel.Text = 'Tamamlanmayanlar';
        cmbModel.value = new Guid('cf1c45ad-8a29-4137-8f88-35433be4d7eb');
        this.PatientInterviewFormStatesList.push(cmbModel);
        let cmbModel2 = new ComboModel();
        cmbModel2.Text = 'Tamamlananlar';
        cmbModel2.value = new Guid('1feb0ae5-1530-44a4-9b85-b3009488c04a');
        this.PatientInterviewFormStatesList.push(cmbModel2);
        let cmbModel3 = new ComboModel();
        cmbModel3.Text = 'İptal Edilenler';
        cmbModel3.value = new Guid('082b2115-464a-4a49-b144-a9c22c8368c2');
        this.PatientInterviewFormStatesList.push(cmbModel3);
    }

    onPatientTypeChanged(e: any): void {
        this.sosyalHizmetlerWorkListFormViewModel._sosyalHizmetlerWorkListFormSearchCriteria.patienttype = e.value;
    }

    patientChanged(patient: any) {
        if (patient)
            this.sosyalHizmetlerWorkListFormViewModel._sosyalHizmetlerWorkListFormSearchCriteria.patientObjectID = patient.ObjectID;
        else
            this.sosyalHizmetlerWorkListFormViewModel._sosyalHizmetlerWorkListFormSearchCriteria.patientObjectID = "";
    }

    accordionIndexChange(willOpen: boolean){
        if (willOpen){
            this.searchAccordion.selectedIndex = 0;
        }else{
            this.searchAccordion.selectedIndex = -1;
        }
    }

    getActionList() {

        let that = this;
        this.loadPanelOperation(true, 'İşlemler listeleniyor, lütfen bekleyiniz.');
        that.httpService.post<SosyalHizmetlerWorkListFormItemModel[]>("api/SosyalHizmetlerWorkListService/GetSocialServicesActionsWorkList", that.sosyalHizmetlerWorkListFormViewModel._sosyalHizmetlerWorkListFormSearchCriteria)
            .then(response => {
                that.sosyalHizmetlerWorkListFormViewModel.SosyalHizmetlerActionList =response as SosyalHizmetlerWorkListFormItemModel[];
                this.systemApiService.componentInfo = null;
                this.loadPanelOperation(false, '');

            })
            .catch(error => {
                this.loadPanelOperation(false, '');
                this.messageService.showError(error);

            });
        this.accordionIndexChange(true);
        // });
    }

    ngOnDestroy() {
        if (this.sosyalHizmetlerWorkListSubscription != null) {
            this.sosyalHizmetlerWorkListSubscription.unsubscribe();
            this.sosyalHizmetlerWorkListSubscription = null;
        }
        if (this.systemApiService.componentInfo)
            this.closeDynamicComponent();
    }


    closeDynamicComponent() {
        this.systemApiService.componentInfo = null;
        this.lastSelectedObjectid = null;
        //this.activeEpisodeActionService.ActiveEpisodeActionID = Guid.Empty;
    }

    async clientPreScript() {
        // let a = this.getDietList();
    }

    clientPostScript(state: String): void {
        // throw new Error('Method not implemented.');
    }

    async select(value: any): Promise<void> {

        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            this.accordionIndexChange(false);
            this.loadPanelOperation(true, 'Form hazırlanıyor, lütfen bekleyiniz.');
            let _data: SosyalHizmetlerWorkListFormItemModel = value.data as SosyalHizmetlerWorkListFormItemModel;
            this.lastSelectedObjectid = _data.ObjectID;
            //this.activeEpisodeActionService.ActiveEpisodeActionID = new Guid(_data.ObjectID);
            this.openDynamicComponent("PATIENTINTERVIEWFORM", _data.ObjectID);
        }

    }

    openDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        if (objectID != null) {
            this.systemApiService.open(objectID, objectDefName, formDefId, inputparam).then(x => {
                //this.isComponentOpened = true;
                //let that = this;
                //setTimeout(function () {
                //    that.ortezProtezWorkListGrid.instance.repaint();
                //}, 300);
            });
        }
        else {
            this.systemApiService.new(objectDefName, null, formDefId, inputparam).then(c => {
                //this.selectedEpisodeActionId = c.ParentObjectID.toString();
            });
        }
        //    this.setComponentPatientInfo();

    }

    public initFormControls(): void {


        this.btnListele = new TTVisual.TTButton();
        this.btnListele.Text = i18n("M27337", "Listele");
        this.btnListele.Name = "btnListele";
        this.btnListele.TabIndex = 12;

        this.httpService.get<Array<any>>("api/SosyalHizmetlerWorkListService/GetDoctor").then(result => {
            this.doctorArray = result;
        });
        this.httpService.get<Array<any>>("api/SosyalHizmetlerWorkListService/GetClinics").then(result => {
            this.clinicArray = result;
        });
        this.createStates();


    }

    public btnSearchClicked(): void {

        let a = this.getActionList();
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }







    public onProcedureByUserChanged(event): void {

        this.sosyalHizmetlerWorkListFormViewModel._sosyalHizmetlerWorkListFormSearchCriteria.ProcedureByUser = event;
    }

    btnPrintRationReportClicked() {

    }

    public dynamicComponentClosed(e: any) {
        this.isComponentOpened = false;
        let that = this;
        this.accordionIndexChange(true);
        //this.activeEpisodeActionService.ActiveEpisodeActionID = Guid.Empty;
    }

    public componentCreated(e: any) {
        this.isComponentOpened = true;
        this.loadPanelOperation(false, '');
        let that = this;
        setTimeout(function () {
            //that.sosyalHizmetlerWorkListGrid.instance.repaint();
        }, 300);
    }

    //Hizmet/tetkik filtrelemesini user option olarak saklamak icin


    public onRowPrepared(e: any): void {

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



