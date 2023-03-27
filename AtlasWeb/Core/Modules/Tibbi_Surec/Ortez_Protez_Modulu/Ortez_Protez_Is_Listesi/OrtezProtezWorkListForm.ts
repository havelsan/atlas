//$0D23E1A1
import { Component, ViewChild, Renderer2 } from '@angular/core';
import { OrtezProtezWorkListViewModel, OrtezProtezWorkListItemModel, OrtezProtezWorkListSearchCriteria } from './OrtezProtezWorkListViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionWorkListStateItem, StateOutputDVO, EpisodeActionWorkListItem } from "Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { OrthesisProsthesisRequest } from 'NebulaClient/Model/AtlasClientModel';
import { DxDataGridComponent, DxAccordionComponent } from "devextreme-angular";
import { IActiveEpisodeActionService } from 'Fw/Services/IActiveEpisodeActionService';

@Component({
    selector: 'ortezProtez-workList-form',
    templateUrl: './OrtezProtezWorkListForm.html',
    providers: [SystemApiService, MessageService]
})
export class OrtezProtezWorkListForm extends BaseComponent<OrtezProtezWorkListViewModel> {

    public ortezProtezWorkListViewModel: OrtezProtezWorkListViewModel = new OrtezProtezWorkListViewModel();
    public selectedRowKeysResultList: Array<OrtezProtezWorkListItemModel> = [];
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    public OrtezProtezWorkListStateItems: Array<EpisodeActionWorkListStateItem>;
    public PatientTypeList = [];
    ProcedureDoctor: TTVisual.ITTObjectListBox;

    @ViewChild('ortezProtezWorkListGrid') ortezProtezWorkListGrid: DxDataGridComponent;
    @ViewChild('searchAccordion') searchAccordion: DxAccordionComponent;

    btnListele: TTVisual.ITTButton;
    isComponentOpened: boolean = false;

    public WorkListColumns = [
        {
            caption: i18n("M17021", "Kabul No"),
            dataField: "KabulNo",
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
            caption: i18n("M15133", "Hasta Adı Soyadı"),
            dataField: "PatientNameSurname",
            dataType: 'string',
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
            caption: i18n("M18587", "Malzeme Kodu"),
            dataField: "ProcedureCode",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M18550", "Malzeme Adı"),
            dataField: "ProcedureName",
            width: "300px",
            cssClass: 'WrappedColumnClass',
            allowSorting: true
        },
        {
            caption: i18n("M22824", "Tarafı"),
            dataField: "Side",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M19036", "Miktarı"),
            dataField: "Amount",
            dataType: 'number',
            width: "auto",
            allowSorting: false
        },
        {
            caption: i18n("M27370", "Tekniker Adı"),
            dataField: "Technician",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M17579", "Tarih"),
            dataField: "BranchDate",
            dataType: "date",
            format: "dd/MM/yyyy HH:mm:ss",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M13372", "İşlemin Durumu"),
            dataField: "CurrentState",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M20566", "Prt. Num"),
            dataField: "Protocolno",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M22176", "Sosyal Güvencesi"),
            dataField: "Kurum",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M12323", "Çalışma Durumu"),
            dataField: "SigortaliTuruAdi",
            width: "auto",
            allowSorting: true
        }

    ];

    constructor(protected httpService: NeHttpService, protected messageService: MessageService, container: ServiceContainer, public systemApiService: SystemApiService, private activeEpisodeActionService: IActiveEpisodeActionService, private renderer: Renderer2) {
        super(container);
        this.initFormControls();

        let _episodeActionWorkListItems: Array<EpisodeActionWorkListItem> = new Array<EpisodeActionWorkListItem>();

        let _episodeActionWorkListItem: EpisodeActionWorkListItem = new EpisodeActionWorkListItem();
        _episodeActionWorkListItem.ObjectDefName = "ORTHESISPROSTHESISREQUEST";
        _episodeActionWorkListItem.ObjectDefID = "29f8be50-7930-426f-94f5-83536cc7a4c4";
        _episodeActionWorkListItems.push(_episodeActionWorkListItem);

        this.getStateList(_episodeActionWorkListItems);
        this.getModelInfo();

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
        this.ProcedureDoctor.ListDefName = "DoctorListDefinition";
        this.ProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 154;

    }

    ngOnDestroy() {
    }

    getDietList() {

        let that = this;
        let _SearchCriteria: OrtezProtezWorkListSearchCriteria = new OrtezProtezWorkListSearchCriteria();
        this.loadPanelOperation(true, 'İşlemler listeleniyor, lütfen bekleyiniz.');
        that.httpService.post<OrtezProtezWorkListItemModel[]>("api/OrtezProtezWorkListService/GetOrtezProtezActionWorkList", that.ortezProtezWorkListViewModel._ortezProtezWorkListSearchCriteria)
            .then(response => {
                that.ortezProtezWorkListViewModel.OrtezProtezActionList =  response as OrtezProtezWorkListItemModel[];
                this.searchAccordion.selectedIndex = -1;
                this.saveOrtezWorklistFilterUserOption();
                this.systemApiService.componentInfo = null;
                this.loadPanelOperation(false, '');
            })
            .catch(error => {
                this.loadPanelOperation(false, '');
                this.messageService.showError(error);

            });

        // });
    }

    getModelInfo() {
        let that = this;

        that.httpService.get<OrtezProtezWorkListSearchCriteria>("api/OrtezProtezWorkListService/GetModelInfo")
            .then(response => {
                that.ortezProtezWorkListViewModel._ortezProtezWorkListSearchCriteria = response as OrtezProtezWorkListSearchCriteria;
            })
            .catch(error => {
                this.messageService.showError(error);

            });
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
            this.loadPanelOperation(true, 'Form hazırlanıyor, lütfen bekleyiniz.');
            let _data: OrtezProtezWorkListItemModel = value.data as OrtezProtezWorkListItemModel;
            //this.activeEpisodeActionService.ActiveEpisodeActionID = new Guid(_data.ObjectID);
            this.openDynamicComponent("ORTHESISPROSTHESISREQUEST", _data.ObjectID);
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
    }

    public btnSearchClicked(): void {

        let a = this.getDietList();
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    async getStateList(value: any) {
        let that = this;

        let res = await this.httpService.post("api/EpisodeActionWorkListService/GetEpisodeActionStateDefinition", value);
        let output = <StateOutputDVO>res;

        let _number = 0;
        _number = this.getStateIndex(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Appointment.id, output);

        if (_number >= 0)
            output.WorkListSearchStateItem = this.removeState(_number, output);

        _number = this.getStateIndex(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.FinancialDepartmentControl.id, output);

        if (_number >= 0)
            output.WorkListSearchStateItem = this.removeState(_number, output);

        _number = this.getStateIndex(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.FinancialDepartmentRejected.id, output);

        if (_number >= 0)
            output.WorkListSearchStateItem = this.removeState(_number, output);

        _number = this.getStateIndex(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommittee.id, output);

        if (_number >= 0)
            output.WorkListSearchStateItem = this.removeState(_number, output);

        _number = this.getStateIndex(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommitteeApproval.id, output);

        if (_number >= 0)
            output.WorkListSearchStateItem = this.removeState(_number, output);

        _number = this.getStateIndex(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommitteeWithThreeSpecialist.id, output);

        if (_number >= 0)
            output.WorkListSearchStateItem = this.removeState(_number, output);

        _number = this.getStateIndex(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommitteeWithThreeSpecialistApproval.id, output);

        if (_number >= 0)
            output.WorkListSearchStateItem = this.removeState(_number, output);

        _number = this.getStateIndex(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.RequestAcception.id, output);

        if (_number >= 0)
            output.WorkListSearchStateItem = this.removeState(_number, output);

        //output.WorkListSearchStateItem.splice(output.WorkListSearchStateItem.findIndex(o => o.StateDefID === OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Appointment.id),1);
        //output.WorkListSearchStateItem.splice(output.WorkListSearchStateItem.findIndex(o => o.StateDefID === OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.FinancialDepartmentControl.id), 1);
        //output.WorkListSearchStateItem.splice(output.WorkListSearchStateItem.findIndex(o => o.StateDefID === OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.FinancialDepartmentRejected.id), 1);
        //output.WorkListSearchStateItem.splice(output.WorkListSearchStateItem.findIndex(o => o.StateDefID === OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommittee.id), 1);
        //output.WorkListSearchStateItem.splice(output.WorkListSearchStateItem.findIndex(o => o.StateDefID === OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommitteeApproval.id), 1);
        //output.WorkListSearchStateItem.splice(output.WorkListSearchStateItem.findIndex(o => o.StateDefID === OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommitteeWithThreeSpecialist.id), 1);
        //output.WorkListSearchStateItem.splice(output.WorkListSearchStateItem.findIndex(o => o.StateDefID === OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommitteeWithThreeSpecialistApproval.id), 1);
        //output.WorkListSearchStateItem.splice(output.WorkListSearchStateItem.findIndex(o => o.StateDefID === OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.RequestAcception.id), 1);

        this.OrtezProtezWorkListStateItems = output.WorkListSearchStateItem;

    }

    getStateIndex(id: string, outputList: StateOutputDVO): number {
        return outputList.WorkListSearchStateItem.findIndex(o => o.StateDefID === id);
    }

    removeState(_index: number, outputList: StateOutputDVO): EpisodeActionWorkListStateItem[] {
        outputList.WorkListSearchStateItem.splice(_index, 1);

        return outputList.WorkListSearchStateItem;
    }

    onOrtezProtezWorkListStateItems(e: any): void {
        this.ortezProtezWorkListViewModel._ortezProtezWorkListSearchCriteria.ortezProtezWorkListStateItem = e.value;
    }

    onPatientTypeChanged(e: any): void {
        this.ortezProtezWorkListViewModel._ortezProtezWorkListSearchCriteria.patienttype = e.value;
    }

    public onRequesterDoctorChanged(event): void {

        this.ortezProtezWorkListViewModel._ortezProtezWorkListSearchCriteria.requesterDoctor = event;
    }

    btnPrintRationReportClicked() {

 
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

    //Hizmet/tetkik filtrelemesini user option olarak saklamak icin
    async saveOrtezWorklistFilterUserOption(): Promise<void> {
        try {
            //let inputDVO = new UserOptionInputDVO();
            //inputDVO.UserOptionType = UserOptionType.FilterProcedureAndTests;

            //let optionValue = "";
            //if (this.ortezProtezWorkListViewModel._ortezProtezWorkListSearchCriteria.ortezProtezWorkListStateItem != null)
            //    for (var i = 0; i < this.ortezProtezWorkListViewModel._ortezProtezWorkListSearchCriteria.ortezProtezWorkListStateItem.length; i++) {

            //    }

            //inputDVO.OptionValue = optionValue;

            let apiUrl: string = 'api/OrtezProtezWorkListService/SaveUserOption';
            let result = await this.httpService.post(apiUrl, this.ortezProtezWorkListViewModel._ortezProtezWorkListSearchCriteria);

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }

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

    patientChanged(patient: any) {
        if (patient)
            this.ortezProtezWorkListViewModel._ortezProtezWorkListSearchCriteria.patientObjectID = patient.ObjectID;
        else
            this.ortezProtezWorkListViewModel._ortezProtezWorkListSearchCriteria.patientObjectID = "";
    }

    keyDownForNumericControl(event: any) {

        if (event != null && event.srcElement != null && event.srcElement.value != null && event.srcElement.value.length < 11 && !(new RegExp('[\.,]', 'g')).test(event.key)) {

        }
        else {
            event.preventDefault();
        }
    }
}



