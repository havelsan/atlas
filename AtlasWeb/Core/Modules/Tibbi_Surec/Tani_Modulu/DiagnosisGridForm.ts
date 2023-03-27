//$F0B200A1
import { Component, ViewChild, ViewChildren, OnInit, ApplicationRef, Input, OnChanges, SimpleChanges, AfterViewInit, QueryList, OnDestroy, Output, EventEmitter, HostListener } from '@angular/core';
import { DiagnosisGridFormViewModel, vmNewDiagnosisGrid, vmDiagnosisGridFormDefinitionsParameter, DiagnoseObjectSelectionViewModel, DiagnosisActionSuggestionViewModel, PhysicianSuggestionDefViewModel } from "./DiagnosisGridFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { Util } from "Fw/Components/Util";
import { HvlDataGrid } from "Fw/Components/HvlDataGrid";
import { HvlCheckBox } from "Fw/Components/HvlCheckBox";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionWithDiagnosis, SpecialityBasedObjectEnum, DiagnosisDefinition, PatientExamination, WomanSpecialityObject } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisTypeEnum, FTRDiagnosisGroupEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { FavoriteDiagnosis } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DxListComponent, DxDataGridComponent } from "devextreme-angular";
import { TTRadioButtonGroupColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTRadioButtonGroupColumn';
import { TTLabelColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTLabelColumn';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { IModalService } from "Fw/Services/IModalService";
import { ENabizDataSets } from '../E_Nabiz_Modulu/ENabizViewModel';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { CommonService } from "ObjectClassService/CommonService";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { ShowBoxTypeEnum } from "NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import { ProcedureRequestSharedService } from "../Tetkik_Istem_Modulu/ProcedureRequestSharedService";
import { ObjectContextService } from "Fw/Services/ObjectContextService";
import { HvlListBox } from 'Fw/Components/HvlListBox';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import CustomStore from 'devextreme/data/custom_store';
import DataSource from "devextreme/data/data_source";
import { ENabizButtonResponseModel } from 'app/Fw/Components/HvlApp';
import { Sonuc } from '../Poliklinik_Modulu/PatientExaminationDoctorFormNewViewModel';
import { Subscription } from 'rxjs';
import { DiagnosisGridSharedService } from './DiagnosisGridSharedService';

@Component({
    selector: 'DiagnosisGridForm',
    templateUrl: './DiagnosisGridForm.html',
    providers: [MessageService]
})
export class DiagnosisGridForm extends TTVisual.TTForm implements OnInit, OnChanges, AfterViewInit, OnDestroy {
    @ViewChildren(DxListComponent) Lists: QueryList<DxListComponent>;
    @ViewChild('diagnosisGridPanel') diagnosisGridPanelInstance: HTMLElement;
    @ViewChild('dataGrid') datagridInstance: DxDataGridComponent;
    DiagnosisSelection: TTVisual.ITTObjectListBox;
    AddToFavorite: TTVisual.ITTButtonColumn;
    Diagnose: TTLabelColumn;
    StarterAction: TTLabelColumn;
    DiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    FreeDiagnosis: TTVisual.ITTTextBoxColumn;
    GridDiagnosis: TTVisual.ITTGrid;
    IsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    PreSecDiagnosis: TTRadioButtonGroupColumn;
    ResponsibleDoctor: TTLabelColumn;
    public GridDiagnosisColumns = [];

    dialogWidth: string;
    dialogHeight: string;
    dialogLeft: string;
    dialogTop: string;
    dialogOpened: Boolean = false;
    TimeOutHandler: any;
    showENabizPopup = false;
    showHighRiskyPregnancy = false;
    HighRiskDiagnoseSelected = false;

    selectedData: any;
    public E_Nabiz_Title: string = "E-Nabız";
    public hasBulasiciMSVS: boolean = true;

    public GridFavoriteDiagnosisColumns = [];
    public GridLast10DiagnosisOfPatientBySpecialityColumns = [];
    public GridTop10DiagnosisOfUserColumns = [];
    public diagnosisGridFormViewModel: DiagnosisGridFormViewModel = new DiagnosisGridFormViewModel();

    public showMainDiagnoseDefinitions: boolean = true;
    public enableSelectionOfMainDiagnoses: boolean = false;

    public AddDiagnosisFromOutsideSubscription: Subscription;

    public get _EpisodeActionWithDiagnosis(): EpisodeActionWithDiagnosis {
        return this._TTObject as EpisodeActionWithDiagnosis;
    }


    //diagnosisActionSuggestion
    @Output() openIstem: EventEmitter<any> = new EventEmitter<any>();
    @Output() setLastMenstrualPeriod: EventEmitter<any> = new EventEmitter<any>();
    @Input() SuggestProcedureByDiagnosis: Boolean = false;
    showDiagnosisActionSuggestionPopup = false;
    _tempDiagnosisActionSuggestionList: Array<DiagnosisActionSuggestionViewModel> = [];


    public columns = [
        {
            caption: i18n("M22736", "Tanı"),
            name: "Diagnose",
            dataField: "Diagnose.GeneratedDisplayExpression",
            width: "auto",
        },
        {
            caption: i18n("M19992", "Ön|Kesin"),
            name: "PreSecDiagnosis",
            dataField: "DiagnosisType",
            width: 70,
            cellTemplate: "DiagnosisTypeCellTemplate",
        },
        {
            caption: i18n("M10926", "Ana Tanı"),
            name: "IsMainDiagnose",
            dataField: "IsMainDiagnose",
            width: 70,
            cellTemplate: "IsMainDiagnoseCellTemplate",
            allowEditing: false,
        },
        {
            caption: i18n("M27330", "Doktor"),
            name: "ResponsibleDoctor.Name",
            dataField: "ResponsibleDoctor.Name",
            width: "auto",
        },
        //{
        //    caption: i18n("M14275", "Favoriye Ekle"),
        //    name: "AddToFavorite",
        //    width: 50,
        //    cellTemplate: "buttonCellTemplate",
        //},
        {
            caption: i18n("M27286", "Sil"),
            name: "RowDelete",
            width: 35,
            cellTemplate: "deleteCellTemplate",
        },
    ];

    public diagnosisActionSuggestionColumns = [
        {
            caption: i18n("M15818", "Hizmet"),
            name: "DiagnosisActionSuggestionProcedureName",
            dataField: "ProcedureName",
            width: 600,
        },
        {
            caption: i18n("M16698", "İsteme Ekle"),
            name: "CreateProcedure",
            dataField: "CreateProcedure",
            width: 50,
            cellTemplate: "CreateProcedureCellTemplate",
            allowEditing: false,
        },

    ];


    public IsEpisodeBaseDentalEpisodeAction = false;
    preSecDiagnosisRadioItems: Array<any> = [{ Value: 1, Name: '' }, { Value: 2, Name: '' }]; //"DiagnosisTypeEnum";// 1 -> Ön Tanı , 2 -> Kesin Tanı

    private DiagnosisGridForm_DocumentUrl: string = '/api/DiagnosisGridService/';

    constructor(protected httpService: NeHttpService,private diagnosisGridSharedService:DiagnosisGridSharedService, protected messageService: MessageService, private detector: ApplicationRef, protected modalService: IModalService, protected activeUserService: IActiveUserService, private procedureRequestSharedService: ProcedureRequestSharedService, private objectContextService: ObjectContextService) {
        super("", "DiagnosisGridForm");
        this._DocumentServiceUrl = this.DiagnosisGridForm_DocumentUrl;
        this.showENabizPopup = false;
        this.initViewModel();
        this.initFormControls();

        const menuActionFunc = this.RemoveDiagnosisGridToFavorite.bind(this); // This'in Menu İtem içinde kullanılabilmesi için  fonksiyona constracterda this bind edildi
        this.gridFavoriteMenuItems[0].action = menuActionFunc;

    }
    gridFavoriteMenuItems = [{
        text: "Favorilerden Çıkar",
        action: null,
    }];


    // ***** Method declarations start *****

    //@ViewChild('diagnosisQuickSelectionAccordion') diagnosisQuickSelectionAccordion: DxAccordionComponent;
    private _isReadOnlyDiagnosisGridGet: Boolean;
    private _isReadonly: Boolean;
    @Input() set IsReadOnly(value: Boolean) {
        this._isReadonly = value;

    }
    get IsReadOnly(): Boolean {
        return this._isReadonly == true ? true : false;
    }
    public _isOnPopUp: Boolean = false;
    @Input() set IsOnPopUp(value: Boolean) {
        this._isOnPopUp = value;
    }

    get IsOnPopUp(): Boolean {
        return this._isOnPopUp;
    }

    private _ProcedureDoctor: any;
    @Input() set ProcedureDoctor(value) {
        if (value != undefined)
            this._ProcedureDoctor = value;
    }
    get ProcedureDoctor(): any {
        return this._ProcedureDoctor;
    }

    private _removeDeletedRow: Boolean;
    @Input() set RemoveDeletedRow(value: Boolean) {
        this._removeDeletedRow = value;
        if (this._removeDeletedRow == true) {
            let lengthOfdeletedRows = this.GridDiagnosisGridList.filter(dr => dr.RemoveSubEpisodeRelation == true).length;
            let index = this.GridDiagnosisGridList.findIndex(dr => dr.RemoveSubEpisodeRelation == true); //ilk elemanın indeks nosunu döndürür
            while (index > 0) {
                this.GridDiagnosisGridList.splice(index, 1); //ikinci parametre bu indexden itibaren kaç tanesini sileceğini gösteriyor
                index = this.GridDiagnosisGridList.findIndex(dr => dr.RemoveSubEpisodeRelation == true); //ilk elemanın indeks nosunu döndürür
            }
        }

    }
    get RemoveDeletedRow(): Boolean {
        return this._removeDeletedRow == true ? true : false;
    }

    private _episodeAction: EpisodeActionWithDiagnosis;
    @Input() set EpisodeAction(value: EpisodeActionWithDiagnosis) {
        this._episodeAction = value;
        if (value && value.hasOwnProperty('ObjectID')) { // Form  ilk load olduğunda boş geliyor o zaman çalışmasın diye
            if (this._episodeAction != null) {
                if (typeof this._episodeAction != "string") {
                    if (this._episodeAction.ObjectDefID != null && this._episodeAction.ObjectDefID.toString() == '37809a1b-4c90-45b9-b475-ef4c985fb9e3')// diş Muayene
                        this.IsEpisodeBaseDentalEpisodeAction = true;
                }
            }
        }
    }
    get EpisodeAction(): EpisodeActionWithDiagnosis {
        return this._episodeAction;
    }


    private _gridDiagnosisGridList: Array<DiagnosisGrid>;
    @Input() set GridDiagnosisGridList(value: Array<DiagnosisGrid>) {
        this._gridDiagnosisGridList = value;
        if (this._isReadonly != true) {
            if ((this._gridDiagnosisGridList != null && this._gridDiagnosisGridList.length > 0)) {
                this.getDefinitionsViewModel();
                this._isReadOnlyDiagnosisGridGet = true;
            }
        }
    }
    // private CurrentResUser: ResUser;
    get GridDiagnosisGridList(): Array<DiagnosisGrid> {
        return this._gridDiagnosisGridList;
    }

    // Enabız için kullanılıyor
    @Output() sendENabizViewModel: EventEmitter<Array<any>> = new EventEmitter<Array<any>>();

    private _eNabizViewModels: Array<any> = [];

    _nabizDataSetList: Array<ENabizDataSets> = [];

    //Bazı modullerden nabız girişi olmayabilir
    private _checkENabiz: Boolean;
    @Input() set CheckENabiz(value: Boolean) {
        this._checkENabiz = value;

    }
    get CheckENabiz(): Boolean {
        return this._checkENabiz;
    }

    expanded() {
        if (this.Lists) {
            this.Lists.forEach(item => {
                item.instance.repaint();
            });
        }
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['IsReadOnly'] || changes['EpisodeAction']) {
            this.getReadOnlyDiagnosis();
        }

    }
    async ngOnInit() {

        await this.getDiagnosisListFilterExpressionViewModel();
        this.redirectProperties();
        let showMainDiagnose: string = (await SystemParameterService.GetParameterValue('ANATANIGOSTER', 'TRUE'));
        if (showMainDiagnose === 'TRUE') {
            this.showMainDiagnoseDefinitions = true;
        }
        else {
            this.showMainDiagnoseDefinitions = false;
        }

        let enableMainDiagnoseSelection: string = (await SystemParameterService.GetParameterValue('ANATANISECIMI', 'FALSE'));
        if (enableMainDiagnoseSelection === 'TRUE') {
            this.enableSelectionOfMainDiagnoses = true;
        }
        else {
            this.enableSelectionOfMainDiagnoses = false;
        }

        if (this.showMainDiagnoseDefinitions == false) {
            this.DiagnosisSelection.ListFilterExpression = 'ISLEAF = 1';
        }
        this.LoadAllDiagnosisDefinitions();

    }
    initSubscriptions() {
        if (this.AddDiagnosisFromOutsideSubscription == null) {
            this.AddDiagnosisFromOutsideSubscription = this.diagnosisGridSharedService.AddedDiagnosisList.subscribe(
                addedDiagnosisDetails => {
                    for(let diagnose of addedDiagnosisDetails){
                        this.diagnosisSelection_ValueChanged(diagnose);
                    }
                    //this.removeProcedureRequestCheck(deletedRequestFormDetailID);
                }
            );
        }
    }

    ngAfterViewInit() {
        this.initSubscriptions();
    }
    ngOnDestroy() {
        if(this.AddDiagnosisFromOutsideSubscription != null){
            this.AddDiagnosisFromOutsideSubscription.unsubscribe();
            this.AddDiagnosisFromOutsideSubscription = null;
        }
    }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        //   this.CurrentResUser = await UserHelper.CurrentResource;

        //this.SetDiagnosisListFilter();
    }
    public setDiagnosisListFilter() {
        let that = this;
        this.DiagnosisSelection.ListFilterExpression = that._ViewModel.DiagnosisListFilterExpression;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this.diagnosisGridFormViewModel = new DiagnosisGridFormViewModel();
        this._ViewModel = this.diagnosisGridFormViewModel;
    }

    protected getReadOnlyDiagnosis() {
        let that = this;
        if (this._isReadOnlyDiagnosisGridGet != true && this.IsReadOnly != null && this.IsReadOnly == true && this.EpisodeAction != null) {
            let episodeActionOrSubEpisodeObjectID = that.getEpisodeActionOrSubEpisodeObjectID();
            if (episodeActionOrSubEpisodeObjectID != null) {
                this.httpService.get<vmDiagnosisGridFormDefinitionsParameter>(this._DocumentServiceUrl + "GetReadOnlyDiagnosisByEpisodeActionId?episodeActionOrSubEpisodeObjectID=" + episodeActionOrSubEpisodeObjectID, vmDiagnosisGridFormDefinitionsParameter)
                    .then(result => {
                        if (that.diagnosisGridFormViewModel.DiagnosisDefinitions == null)
                            that.diagnosisGridFormViewModel.DiagnosisDefinitions = result.DiagnosisDefinitions;
                        else {
                            let concatedDiagnosisDef = that.diagnosisGridFormViewModel.DiagnosisDefinitions.concat(result.DiagnosisDefinitions);
                            that.diagnosisGridFormViewModel.DiagnosisDefinitions = concatedDiagnosisDef;
                        }
                        this.GridDiagnosisGridList = result.GridDiagnosisGridList;

                        that.loadViewModelDefinitions();
                        that._isReadOnlyDiagnosisGridGet = true;
                    })
                    .catch(error => {
                        console.log(error);
                    });
            }

        }
    }

    public onMainDiagnoseChanged(cellData: any, event) {
        if (event == true) {
            let diagnosisGrid: DiagnosisGrid = cellData.data;

            this.GridDiagnosisGridList.forEach(gridItem => {
                if (diagnosisGrid.ObjectID.toString() != gridItem.ObjectID.toString()) {
                    gridItem.IsMainDiagnose = false;
                }
            });
        }
    }

    protected getDefinitionsViewModel() {
        let that = this;
        let _vmDiagnosisGridFormDefinitionsParameter: vmDiagnosisGridFormDefinitionsParameter = new vmDiagnosisGridFormDefinitionsParameter();
        _vmDiagnosisGridFormDefinitionsParameter.GridDiagnosisGridList = that.GridDiagnosisGridList;


        this.httpService.post<DiagnosisGridFormViewModel>(this._DocumentServiceUrl + "DiagnosisGridFormDefinitions", _vmDiagnosisGridFormDefinitionsParameter, DiagnosisGridFormViewModel)
            .then(result => {

                if (!that.diagnosisGridFormViewModel.ResUsers)
                    that.diagnosisGridFormViewModel.ResUsers = new Array<ResUser>();

                if (that.diagnosisGridFormViewModel.ResUsers.length > 0) {
                    let concatedResUserDefinitions = that.diagnosisGridFormViewModel.ResUsers.concat(result.ResUsers);
                    that.diagnosisGridFormViewModel.ResUsers = concatedResUserDefinitions;
                }
                else
                    that.diagnosisGridFormViewModel.ResUsers = result.ResUsers;

                if (that.diagnosisGridFormViewModel.DiagnosisDefinitions != null) {
                    let concatedDiagnosisDefinitions = that.diagnosisGridFormViewModel.DiagnosisDefinitions.concat(result.DiagnosisDefinitions);
                    that.diagnosisGridFormViewModel.DiagnosisDefinitions = concatedDiagnosisDefinitions;
                }
                else
                    that.diagnosisGridFormViewModel.DiagnosisDefinitions = result.DiagnosisDefinitions;
                that.loadViewModelDefinitions();
            })
            .catch(error => {
                console.log(error);
            });

    }

    protected async getDiagnosisListFilterExpressionViewModel() {
        let that = this;

        this.httpService.get<DiagnosisGridFormViewModel>(this._DocumentServiceUrl + "DiagnosisGridFormFilterExpression", DiagnosisGridFormViewModel)
            .then(result => {
                that.diagnosisGridFormViewModel.DiagnosisListFilterExpression = result.DiagnosisListFilterExpression;
                this.setDiagnosisListFilter();
            })
            .catch(error => {
                console.log(error);
            });
    }

    protected getDiagnosisQuickSelectionDataViewModel() {
        let that = this;
        if (this.diagnosisAccordionLoaded == false) {
            this.httpService.get<DiagnosisGridFormViewModel>(this._DocumentServiceUrl + "DiagnosisQuickSelectionData?episodeObjectId=" + that.getEpisodeObjectId() + "&procedureSpecialityObjectId=" + that.getProcedureSpecialityObjectId(), DiagnosisGridFormViewModel)
                .then(result => {
                    if (that.diagnosisGridFormViewModel.FavoriteDiagnosisList == null)
                        that.diagnosisGridFormViewModel.FavoriteDiagnosisList = result.FavoriteDiagnosisList;
                    else {
                        let concatedFavoriteDiagnosis = that.diagnosisGridFormViewModel.FavoriteDiagnosisList.concat(result.FavoriteDiagnosisList);
                        that.diagnosisGridFormViewModel.FavoriteDiagnosisList = concatedFavoriteDiagnosis;
                    }

                    that.diagnosisGridFormViewModel.Last10DiagnosisOfPatientList = result.Last10DiagnosisOfPatientList;
                    that.diagnosisGridFormViewModel.Top10DiagnosisDefinitionOfUserList = result.Top10DiagnosisDefinitionOfUserList;
                    if (that.diagnosisGridFormViewModel.DiagnosisDefinitions != null) {
                        let concatedDiagnosisDefinitions = that.diagnosisGridFormViewModel.DiagnosisDefinitions.concat(result.DiagnosisDefinitions);
                        that.diagnosisGridFormViewModel.DiagnosisDefinitions = concatedDiagnosisDefinitions;
                    }
                    else
                        that.diagnosisGridFormViewModel.DiagnosisDefinitions = result.DiagnosisDefinitions;

                    for (let detailItem of that.diagnosisGridFormViewModel.FavoriteDiagnosisList) {
                        detailItem.Diagnose = this.getDiagnosisDefinitionItem(detailItem["Diagnose"]);
                    }

                    that.diagnosisGridFormViewModel.EpisodeDiagnosisGridList = result.EpisodeDiagnosisGridList;
                    for (let _vmEpisodeDiagnosisGrid of that.diagnosisGridFormViewModel.EpisodeDiagnosisGridList) {
                        _vmEpisodeDiagnosisGrid.DiagnosisGrid.Diagnose = this.getDiagnosisDefinitionItem(_vmEpisodeDiagnosisGrid.DiagnoseObjectID);
                    }

                    that.diagnosisAccordionLoaded = true;
                })
                .catch(error => {
                    console.log(error);
                });
        }
    }

    chkValueChange(data) {
        this._gridDiagnosisGridList[0].DiagnosisType = data;
        let a;
        a++;
    }


    protected getDiagnosisDefinitionItem(diagnoseObjectID: any) {
        let that = this;
        if (diagnoseObjectID != null) {
            if (typeof diagnoseObjectID === "string") {
                let diagnose = that.diagnosisGridFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                if (diagnose != null) {
                    if (diagnose.FtrDiagnoseGroup != null) {


                        FTRDiagnosisGroupEnum.Items.forEach(element => {
                            if (element.code == diagnose.FtrDiagnoseGroup)
                                diagnose['GeneratedDisplayExpression'] = diagnose.Code + ' ' + diagnose.Name + ' - ' + element.description + ' Grubu';
                        });


                    } else
                        diagnose['GeneratedDisplayExpression'] = diagnose.Code + ' ' + diagnose.Name;
                    return diagnose;
                }
            }
            else
                return diagnoseObjectID;
        }
        return null;
    }


    protected getEpisodeObjectId(): string {

        if (this.EpisodeAction.Episode != null) {
            if (typeof this.EpisodeAction.Episode === "string") {
                return this.EpisodeAction.Episode;
            }
            else {
                return this.EpisodeAction.Episode.ObjectID.toString();
            }
        }
        return null;
    }


    protected getProcedureSpecialityObjectId(): string {

        if (this.EpisodeAction.ProcedureSpeciality != null) {
            if (typeof this.EpisodeAction.ProcedureSpeciality === "string") {
                return this.EpisodeAction.ProcedureSpeciality;
            }
            else {
                return this.EpisodeAction.ProcedureSpeciality.ObjectID.toString();
            }
        }
        return null;
    }

    // diagnosisGridi çağıran yerde EpisodeActionın SubEpisode'u varsa Readonly Gridi , SubEpisodeId kullanılarak doldurulur yoksa EpisodeActionID kullanılır.
    //Ancak yeni başlayan bir işlemde mutlaka SubEpisodeID olmalıdır .Çünkü yeni başlayn işlemin EpisodeActionı veri tabanında olmaz
    protected getEpisodeActionOrSubEpisodeObjectID(): string {

        if (this.EpisodeAction != null) {
            if (typeof this.EpisodeAction === "string") {
                return this.EpisodeAction;
            }
            else {
                if (this.EpisodeAction.SubEpisode != null) {
                    if (typeof this.EpisodeAction.SubEpisode === "string") {
                        return this.EpisodeAction.SubEpisode;
                    }
                    else if (this.EpisodeAction.SubEpisode.ObjectID != null)
                        return this.EpisodeAction.SubEpisode.ObjectID.toString();
                }
                else if (this.EpisodeAction.ObjectID != null)
                    return this.EpisodeAction.ObjectID.toString();
            }
        }
        return null;
    }

    protected getEpisodeActionMasterResourceObjectId(): string {

        if (this.EpisodeAction != null) {
            if (typeof this.EpisodeAction !== "string" && this.EpisodeAction.MasterResource != null) {
                if (typeof this.EpisodeAction.MasterResource == "string")
                    return this.EpisodeAction.MasterResource;
                else
                    return this.EpisodeAction.MasterResource.ObjectID.toString();
            }
        }
        return null;
    }

    protected getEpisodeActionObjectID(): string {

        if (this.EpisodeAction != null) {
            if (typeof this.EpisodeAction === "string")
                return this.EpisodeAction;
            else if (this.EpisodeAction.ObjectID != null)
                return this.EpisodeAction.ObjectID.toString();
        }
        return null;
    }

    protected getUserObjectId(user: any): string {

        if (user) {
            if (typeof user === "string") {
                return user;
            }
            else {
                return user.ObjectID.toString();
            }
        }
        return null;
    }

    protected getResUserItem(resuserObjectID: any) {
        let that = this;
        if (resuserObjectID != null) {
            let resUser = that.diagnosisGridFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resuserObjectID.toString());
            return resUser;
        }
        return null;
    }
    protected async loadViewModelDefinitions() {
        let that = this;

        that.diagnosisGridFormViewModel = this._ViewModel as DiagnosisGridFormViewModel;
        if (this.diagnosisGridFormViewModel == null)
            this.diagnosisGridFormViewModel = new DiagnosisGridFormViewModel();
        if (!that.GridDiagnosisGridList) {
            return;
        }
        for (let detailItem of that.GridDiagnosisGridList) {
            detailItem.Diagnose = this.getDiagnosisDefinitionItem(detailItem["Diagnose"]);

            if (detailItem.Diagnose.FtrDiagnoseGroup != null) {


                FTRDiagnosisGroupEnum.Items.forEach(element => {
                    if (element.code == detailItem.Diagnose.FtrDiagnoseGroup)
                        detailItem.Diagnose['GeneratedDisplayExpression'] = detailItem.Diagnose.Code + ' ' + detailItem.Diagnose.Name + ' - ' + element.description + ' Grubu';
                });


            } else
                detailItem.Diagnose['GeneratedDisplayExpression'] = detailItem.Diagnose.Code + ' ' + detailItem.Diagnose.Name;
            //detailItem.ResponsibleUser = this.getResUserItem(detailItem["ResponsibleUser"]);
            if (detailItem.EntryActionType != undefined && detailItem.EntryActionType != null) {
                let entryActionType: string = await CommonService.GetDisplayTextOfEnumValue('ActionTypeEnum', detailItem.EntryActionType);
                if (entryActionType)
                    detailItem["StarterAction"] = entryActionType;
            }
            //Bir doktorun girdiği tanıyı bir başkası silemez
            detailItem.ResponsibleDoctor = this.getResUserItem(detailItem["ResponsibleDoctor"]);
            detailItem['isEnabled'] = this.authControl(detailItem);
        }
        if (this.datagridInstance != null)
            this.datagridInstance.instance.refresh();

    }


    //Hızlı Tanı seçimi akordion kodlar


    private diagnosisAccordionLoaded: boolean = false;



    private diagnosisQuickSelectionDetailIconClassCollapse = 0;
    public diagnosisQuickSelectionDetailIconClassProperties(): string {
        if (this.diagnosisQuickSelectionDetailIconClassCollapse == 0) {
            this.dialogOpened = false;
            return "fa fa-2x fa-angle-down";
        }
        else {
            this.dialogOpened = true;
            return "fa fa-2x fa-angle-up";
        }
    }

    OpenDialog() {
        let rect: ClientRect = this.diagnosisGridPanelInstance['nativeElement'].getBoundingClientRect();
        this.dialogLeft = rect.left.toString() + "px";
        this.dialogTop = (rect.top + rect.height).toString() + "px";
        this.dialogWidth = rect.width + "px";
        this.dialogHeight = "550px";
        this.dialogOpened = true;
    }

    authControl(detailItem): boolean {

        if (detailItem.IsReportDiagnose)
            return false;
        if (this.IsReadOnly != true) {
            if (this.activeUserService.ActiveUser.IsSuperUser)
                return true;
            else {
                let activeUserObjectID = this.activeUserService.ActiveUser.UserObject.ObjectID;
                if (detailItem.ResponsibleDoctor)
                    return (detailItem.ResponsibleDoctor.ObjectID == activeUserObjectID);
                else {
                    if (detailItem.ResponsibleUser) {
                        let userObjectId: string = this.getUserObjectId(detailItem.ResponsibleUser);
                        if (userObjectId)
                            return (userObjectId == activeUserObjectID.toString());
                    }
                }
            }
        }
        return false;
    }


    @HostListener('window:mousedown', ['$event'])
    mouseDown(event: MouseEvent) {
        if (!Util.ContainsElement(this.diagnosisGridPanelInstance['nativeElement'], event.target) && event.target['name'] != 'hizliTani') {
            this.dialogOpened = false;
            this.diagnosisQuickSelectionDetailIconClassCollapse = 0;
        }
    }
    public quickDiagnosis_onBlur() {
        this.diagnosisQuickSelectionCollapse_Click();
    }
    public diagnosisQuickSelectionCollapse_Click(): void {
        if (!this.dialogOpened) {
            this.OpenDialog();
        }
        else
            this.dialogOpened = false;
        if (this.diagnosisQuickSelectionDetailIconClassCollapse == 0) {
            this.diagnosisQuickSelectionDetailIconClassCollapse = 1;
            this.getDiagnosisQuickSelectionDataViewModel();
        }
        else
            this.diagnosisQuickSelectionDetailIconClassCollapse = 0;
    }


    public redirectProperties(): void {

    }

    private isGridDiagnosisGridListExists(diagnoseObjectid): boolean {
        return !this.GridDiagnosisGridList.every(dr => dr.Diagnose != null && dr.Diagnose.ObjectID.toString() != diagnoseObjectid);
    }

    private checkToAddDiagnosis(diagnoseObjectid: string, freeDiagnosis: string): boolean {
        if (this._episodeAction != null && this._episodeAction["HCExaminationComponent"] != null) {
            if (this.GridDiagnosisGridList.filter(dr => dr.EpisodeAction.toString() == this._episodeAction.ObjectID.toString() && dr.RemoveSubEpisodeRelation != true && dr.Diagnose.ObjectID.toString() == diagnoseObjectid).length > 0) {
                return false;
            }
            return true;
        }
        if (this.GridDiagnosisGridList.every(dr => dr.Diagnose != null && (dr.RemoveSubEpisodeRelation == true || (dr.Diagnose.ObjectID.toString() != diagnoseObjectid) || (dr.Diagnose.ObjectID.toString() == diagnoseObjectid && dr.DiagnosisType != DiagnosisTypeEnum.Seconder)))) {
            if (diagnoseObjectid != null || freeDiagnosis != null) {
                return true;
            }
        }
        return false;

    }

    private async addNewDiagnosisGrid(diagnoseObjectid: string, freeDiagnosis: string) {

        // Tanı default olarak Kesin tanı olarak atılır
        // Atılmak istenen tanı , Tanı Listesinde Ön Tanı olarak varsa tekrar atılabilir(Kesin tanı olarak) ,Listede kesin tanı olarak varsa tekrar atılamaz
        // Listedeki Tüm tanılar eklenen tanıdan farklı ise yada eklenen tanı ile aynı bile olsa  Kesin tanı değil ise
        let that = this;
        let getEpisodeActionObjectID = this.getEpisodeActionObjectID();
        if (this.checkToAddDiagnosis(diagnoseObjectid, freeDiagnosis) == true) {
            this.httpService.get<vmNewDiagnosisGrid>(this._DocumentServiceUrl + "GetNewDiagnosisGrid?isEpisodeBaseDentalEpisodeAction=" + this.IsEpisodeBaseDentalEpisodeAction + "&episodeActionId=" + getEpisodeActionObjectID)
                .then(result => {
                    let _vmNewDiagnosisGrid: vmNewDiagnosisGrid = result;
                    let newDiagnosisGrid: DiagnosisGrid = _vmNewDiagnosisGrid.DiagnosisGrid;
                    if (diagnoseObjectid != null)
                        newDiagnosisGrid.Diagnose = that.getDiagnosisDefinitionItem(diagnoseObjectid);
                    if (freeDiagnosis != null)
                        newDiagnosisGrid.FreeDiagnosis = freeDiagnosis;
                    newDiagnosisGrid.DiagnosisType = DiagnosisTypeEnum.Seconder;
                    newDiagnosisGrid.IsMainDiagnose = false;
                    if (that.EpisodeAction != null) {
                        if (newDiagnosisGrid['EpisodeAction'] == null) {
                            (<any>newDiagnosisGrid)['EpisodeAction'] = that.getEpisodeActionObjectID();
                        }
                        if (that.EpisodeAction.Episode != null) {
                            newDiagnosisGrid.Episode = that.EpisodeAction.Episode;
                        }
                        //if (that.EpisodeAction.ProcedureDoctor != null) {
                        //    newDiagnosisGrid.ResponsibleDoctor = that.EpisodeAction.ProcedureDoctor;
                        //}
                        //let entryActionType: string = await CommonService.GetDisplayTextOfEnumValue('ActionTypeEnum', this.EpisodeAction.ActionType);
                        //if (entryActionType)
                        //    newDiagnosisGrid["StarterAction"] = entryActionType;
                    }
                    // Responsibledoktorı userlar arasına set et
                    if (_vmNewDiagnosisGrid.ResponsibleDoctor != null) {
                        newDiagnosisGrid.ResponsibleDoctor = _vmNewDiagnosisGrid.ResponsibleDoctor;
                        //if (!that.diagnosisGridFormViewModel.ResUsers.Contains(_vmNewDiagnosisGrid.ResponsibleDoctor)) {
                        //    that.diagnosisGridFormViewModel.ResUsers.push(_vmNewDiagnosisGrid.ResponsibleDoctor)
                        //}

                    }
                    if (this.ProcedureDoctor != null) {
                        newDiagnosisGrid.ResponsibleDoctor = this.ProcedureDoctor;
                    }
                    newDiagnosisGrid["StarterAction"] = _vmNewDiagnosisGrid.StarterAction;
                    newDiagnosisGrid["IsNew"] = true;
                    that.GridDiagnosisGridList.unshift(newDiagnosisGrid);
                })
                .catch(error => {
                    ServiceLocator.MessageService.showError(error);
                });
        }

        //let newDiagnosisGrid: DiagnosisGrid = new DiagnosisGrid() ;
        //if (this.IsEpisodeBaseDentalEpisodeAction == true) // dişin tanı gridi farklı
        //    newDiagnosisGrid = new BaseDentalEpisodeActionDiagnosisGrid();
        //if (diagnoseObjectid != null)
        //    newDiagnosisGrid.Diagnose = this.getDiagnosisDefinitionItem(diagnoseObjectid);
        //if (freeDiagnosis != null)
        //    newDiagnosisGrid.FreeDiagnosis = freeDiagnosis;
        //newDiagnosisGrid.DiagnosisType = DiagnosisTypeEnum.Seconder;
        //newDiagnosisGrid.IsMainDiagnose = false;
        //if (this.EpisodeAction != null) {
        //    (<any>newDiagnosisGrid)['EpisodeAction'] = this.getEpisodeActionObjectID();
        //    let entryActionType: string = await CommonService.GetDisplayTextOfEnumValue('ActionTypeEnum', this.EpisodeAction.ActionType);
        //    if (entryActionType)
        //        newDiagnosisGrid["StarterAction"] = entryActionType;
        //    //newDiagnosisGrid.EntryActionType = this.EpisodeAction.ActionType;
        //    if (this.EpisodeAction.ProcedureDoctor != null) {
        //        newDiagnosisGrid.ResponsibleDoctor = this.EpisodeAction.ProcedureDoctor;
        //    }
        //    if (this.EpisodeAction.Episode != null) {
        //        newDiagnosisGrid.Episode = this.EpisodeAction.Episode;
        //    }
        //}
        //newDiagnosisGrid["IsNew"] = true;
        //this.GridDiagnosisGridList.unshift(newDiagnosisGrid);
    }

    gridTop10DiagnosisDefinitionOfUser_CellContentClicked(data: any) {
        this.addNewDiagnosisGrid(data.itemData.Diagnoseobjectid, "");
    }

    gridLast10DiagnosisOfPatientBySpeciality_CellContentClicked(data: any) {
        this.addNewDiagnosisGrid(data.itemData.Diagnoseobjectid, "");

    }

    gridFavoriteDiagnosis_CellContentClicked(data: any) {
        this.addNewDiagnosisGrid(data.itemData.Diagnose.ObjectID, "");
    }

    gridEpisodeDiagnosis_CellContentClicked(data: any) {
        if (this.checkToAddDiagnosis(data.itemData.DiagnoseObjectID, "") == true) {
            this.GridDiagnosisGridList.unshift(data.itemData.DiagnosisGrid);
        }
    }

    async gridDiagnosisGrid_CellContentClicked(data: any) {
        let that = this;
        if (this.IsReadOnly != true) {

            if (data.column.name = "RowDelete") {
                if (data.row != null) {

                    if (data.row.key != null) {
                        if (this.GridDiagnosisGridList.filter(dr => dr.RemoveSubEpisodeRelation != true).length > 0) {
                            if (data.row.key.IsNew) {
                                this.datagridInstance.instance.deleteRow(data.rowIndex);
                            }
                            else {

                                if (this.authControl(data.row.key)) {
                                    // Artık silinen degerin RemoveSubEpisodeRelationu  true set edilmeli sorguda bu değer üzerinden yapılmalı

                                    data.key.RemoveSubEpisodeRelation = true;
                                    this.datagridInstance.instance.filter(['RemoveSubEpisodeRelation', '<>', true]);
                                    this.datagridInstance.instance.refresh();
                                }

                                else {
                                    if (data.row.key.IsReportDiagnose)
                                        TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M12093", "Bu tanının hastanın raporu ile ilişkisi var, silinemez!"), MessageIconEnum.WarningMessage);
                                    else
                                        TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M12083", "Bu işlem için yetkiniz bulunmamaktadır!"), MessageIconEnum.WarningMessage);
                                }

                            }
                        }
                        else {
                            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M00000", "Hastaya girilmiş  tüm tanılar silinemez. En az bir tanı girişi yapılmalı!"), MessageIconEnum.WarningMessage);
                        }
                    }
                }

            }

        }

    }


    protected saveFavoriteDiagnoseDefinition(diagnoseDefinitionObjectId: string) {
        let that = this;
        this.httpService.get(this._DocumentServiceUrl + "SaveFavoriteDiagnose?diagnoseDefinitionObjectId=" + diagnoseDefinitionObjectId)
            .then(result => {
            })
            .catch(error => {
                console.log(error);
            });
    }

    public onFavoriteDiagnosisList_ItemDeleting(data: any) {
        if (data != null && data.itemData != null && data.itemData.Diagnose != null) {
            this.httpService.get(this._DocumentServiceUrl + "RemoveFavoriteDiagnose?diagnoseDefinitionObjectId=" + data.itemData.Diagnose.ObjectID)
                .then(result => {
                })
                .catch(error => {
                    console.log(error);
                });

        }
    }

    private async gridDiagnosisGrid_CellValueChange(data: any): Promise<void> {

        if (data.column.name == "PreSecDiagnosis") {
            if (data.row != null) {
                if (data.row != null) {
                    let diagnosisGrid = data.row;
                    if (diagnosisGrid.DiagnosisType == DiagnosisTypeEnum.Primer) {
                        diagnosisGrid.IsMainDiagnose = false;
                    }
                }
            }
        }
        if (data.column.name == "IsMainDiagnose") {
            if (data.row != null) {
                if (data.row != null) {
                    let diagnosisGrid = data.row;
                    if (diagnosisGrid.IsMainDiagnose == true && diagnosisGrid.DiagnosisType == DiagnosisTypeEnum.Primer) {
                        diagnosisGrid.DiagnosisType = DiagnosisTypeEnum.Seconder;
                    }
                }
            }
        }
    }

    public DiagnosisArray: any;
    public async LoadAllDiagnosisDefinitions() {
        let filterString: string = '';

        if (this.showMainDiagnoseDefinitions == false)
            filterString = 'ISLEAF=1'
        else
            filterString = ''
        this.DiagnosisArray = new DataSource({
            store: new CustomStore({
                key: "Code",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'DiagnosisListDefinition',
                        injectionFilter: filterString
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    if (String.isNullOrEmpty(loadOptions.searchValue)) {
                        return null;
                    } else {
                        return this.httpService.post<any>("/api/DefinitionQuery/DevExtremePagingQueryForDefList", loadOptions);
                    }
                },
                byKey: (key: any) => {
                    let loadOptions: any = new Object();
                    loadOptions.Params = {
                        searchText: key,
                        definitionName: 'DiagnosisListDefinition',
                        injectionFilter: filterString
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    if (String.isNullOrEmpty(loadOptions.searchValue)) {
                        return null;
                    } else {
                        return this.httpService.post<any>("/api/DefinitionQuery/DevExtremePagingQueryForDefList", loadOptions);
                    }
                }
            }),
            paginate: true,
            pageSize: 10
        });
    }


    public async diagnosisSelection_ValueChanged(data: any) {
        let that = this;
        if (data != null) {
            this.selectedData = data;
            if (this.enableSelectionOfMainDiagnoses == false && data.IsLeaf == false) {
                ServiceLocator.MessageService.showInfo("Bu Tanının Alt Kırılımı bulunduğundan bu tanıyı seçemezsiniz.!");
            } else {
                if (this._checkENabiz || this.SuggestProcedureByDiagnosis) {

                    let RequestUnitResourceId = this.getEpisodeActionMasterResourceObjectId();

                    this.httpService.get<any>(this._DocumentServiceUrl + "GetDiagnoseObjectSelectionViewModel?DiagnoseObjectID=" + data.ObjectID + "&CheckENabiz=" + this._checkENabiz + "&SuggestProcedureByDiagnosis=" + this.SuggestProcedureByDiagnosis + "&RequestUnitResourceId=" + RequestUnitResourceId)
                        .then(result => {
                            let diagnoseSelectionVM = result as DiagnoseObjectSelectionViewModel;
                            let addNewDiagnosisGrid: Boolean = true;
                            if (diagnoseSelectionVM != null) {
                                if (diagnoseSelectionVM.ENabizDataSets != null) {
                                    that._nabizDataSetList = diagnoseSelectionVM.ENabizDataSets as Array<ENabizDataSets>;
                                    that._eNabizViewModels = [];
                                    //Ekran aç
                                    if (that._nabizDataSetList.length > 0) {

                                        let _bulasiciVSIndex = that._nabizDataSetList.findIndex(x => x.PackageID == 214); //Bulaşıcı veriseti var mı?

                                        if (_bulasiciVSIndex >= 0) {
                                            this.E_Nabiz_Title = "Girdiğiniz Tanı BZBH kapsamındadır! Devam Etmek İstiyor Musunuz?";
                                            //this.hasBulasiciMSVS = true;
                                        }
                                        else {
                                            this.E_Nabiz_Title = "E-Nabız";
                                            //this.hasBulasiciMSVS = false;
                                        }
                                        //     this.openBZBH().then(result1 => {

                                        //         if (result1 === 'T') {
                                        //             addNewDiagnosisGrid = false; // ENabız formu açıldı ise o form kapandığında tanı eklenir
                                        //             that.showENabizPopup = true;
                                        //         }
                                        //    });
                                        //}
                                        //else {
                                        addNewDiagnosisGrid = false; // ENabız formu açıldı ise o form kapandığında tanı eklenir
                                        that.showENabizPopup = true;
                                        //}
                                    }
                                }

                                if (diagnoseSelectionVM.PhysicianSuggestionDefs != null && diagnoseSelectionVM.PhysicianSuggestionDefs.length > 0) {
                                    that.openIstem.emit(); // bunu çağıran yerde istem panelinin tabına hiç tıklanmadı ise procedureRequestSharedService aktive olmuyordu .Tetkik istem yapılacaksa tıklanmış gibi davranması için yazıldı
                                    let physicianSuggestionDefList = diagnoseSelectionVM.PhysicianSuggestionDefs as Array<PhysicianSuggestionDefViewModel>;
                                    physicianSuggestionDefList.filter(dr => dr.DiagnosisObjectId != null).forEach(physicianSuggestionDefViewModel => {
                                        that.showPhysicianSuggestion(physicianSuggestionDefList, physicianSuggestionDefViewModel);
                                    });
                                }

                                if (diagnoseSelectionVM.DiagnosisActionSuggestions != null && diagnoseSelectionVM.DiagnosisActionSuggestions.length > 0) {
                                    that.openIstem.emit(); // bunu çağıran yerde istem panelinin tabına hiç tıklanmadı ise procedureRequestSharedService aktive olmuyordu .Tetkik istem yapılacaksa tıklanmış gibi davranması için yazıldı
                                    that._tempDiagnosisActionSuggestionList = diagnoseSelectionVM.DiagnosisActionSuggestions as Array<DiagnosisActionSuggestionViewModel>;
                                    if (that._tempDiagnosisActionSuggestionList.length > 0) {
                                        that.showDiagnosisActionSuggestionPopup = true;
                                    }
                                }
                            }

                            if (addNewDiagnosisGrid) //İlişkili veri seti yok ise direk tanıyı ekle
                            {
                                that.AddSelectedDiagnosisToDiagnosisGrid(data);
                            }

                        })
                        .catch(error => {
                            console.log(error);
                        });
                } else {
                    this.AddSelectedDiagnosisToDiagnosisGrid(data);
                }
            }
            //E-Nabız

            //E-Nabız

        }

        window.setTimeout(t => {
            if (this.diagnosisGridFormViewModel._selectedDiagnosis === null)
                this.diagnosisGridFormViewModel._selectedDiagnosis = undefined;
            else
                this.diagnosisGridFormViewModel._selectedDiagnosis = null;
            that.detector.tick();
        }, 500);
    }

    private AddSelectedDiagnosisToDiagnosisGrid(data: any) {
        this.diagnosisGridFormViewModel.DiagnosisDefinitions.push(data);
        this.addNewDiagnosisGrid(data.ObjectID, "");

        if (this._episodeAction != null && typeof this._episodeAction != "string" && this._episodeAction.constructor.name == "PatientExamination"
            && this._episodeAction.ProcedureSpeciality != null && this._episodeAction.ProcedureSpeciality.SpecialityBasedObjectType != null
            && this._episodeAction.ProcedureSpeciality.SpecialityBasedObjectType == SpecialityBasedObjectEnum.WomanSpecialityObject) {

            this.httpService.get<Sonuc>("/api/PatientExaminationService/HasHighRiskPregnancy?IsWomanSpecialityExam=true&UniqueRefNo=" + this.EpisodeAction.Episode.Patient.UniqueRefNo)
                .then(result => {
                    if (result != null) {
                        if (data.Code == "Z32.0" || data.Code == "Z32.1") {//gebelik tanısı
                            if (result.returnMessage != null && result.returnMessage != "")
                                this.highRiskAlgorithm(result.returnMessage);
                            else
                                this.openHighRiskPregnancyDiag();
                        }
                        else if (result.gebelikBildirim != null && result.gebelikBildirim.length > 0 && data.PregnancyDiagnos)// TODO: hamilelik ile değiştirmeyi unutma
                        {
                            this.setLastMenstrualPeriod.emit(result.gebelikBildirim);
                        }
                    }

                })
                .catch(error => {
                    console.log(error);
                });

        }


    }

    async highRiskAlgorithm(message: string) {
        let result: string = await ShowBox.Show(1, '&Evet,&Hayır', 'OK,CANCEL', i18n("M23735", "Uyarı"), "", "Hastada Yüksek Riskli Gebelik bulunmaktadır. Sağlık verilerine ulaşmak ister misiniz?\nDetay:" + message, 1);

        if (result === "OK")
            this.showPatientENabizInfoByParameter(this.EpisodeAction.ObjectID, this.EpisodeAction.Episode.Patient.ObjectID);
        else if (message == "")
            this.messageService.showInfo("Yüksek Riskli Gebeliklerde Hasta Perinatoloğa Yönlendirilmelidir");

    }

    private showPatientENabizInfoByParameter(episodeActionId: Guid, patientId: Guid) {
        let that = this;
        let apiUrl: string = '/api/PatientExaminationService/ShowPatientENabizInfo?episodeActionObjectID=' + episodeActionId + '&patientObjectID=' + patientId;


        that.httpService.get<ENabizButtonResponseModel>(apiUrl)
            .then(response => {
                let result: ENabizButtonResponseModel = response as ENabizButtonResponseModel;
                if (result.isResponseSuccess == true) {
                    let nabizURL = "http://xxxxxx.com/DoktorErisim/home?Token=" + result.responseLink;
                    let win = window.open(nabizURL, '_blank');
                    win.focus();
                } else {
                    TTVisual.InfoBox.Alert(result.responseMessage);
                }
            })
            .catch(error => {
                this.messageService.showError(error);
            });
    }

    async openHighRiskPregnancyDiag() {
        let that = this;
        let result: string = await ShowBox.Show(1, '&Evet,&Hayır', 'OK,CANCEL', i18n("M23735", "Uyarı"), "", "Hastada Yüksek Riskli Gebelik Düşünülüyor mu?", 1);

        if (result === "OK") {
            this.httpService.get<Array<DiagnosisDefinition>>(this._DocumentServiceUrl + "GetHighRiskyPregnantDefiniton")
                .then(result => {
                    if (result != null) {
                        that.diagnosisGridFormViewModel.HighRiskyPregnantDefiniton = result;

                        let concatedDiagnosisDefinitions = that.diagnosisGridFormViewModel.DiagnosisDefinitions.concat(result);
                        that.diagnosisGridFormViewModel.DiagnosisDefinitions = concatedDiagnosisDefinitions;

                        that.showHighRiskyPregnancy = true;
                    }

                })
                .catch(error => {
                    console.log(error);
                });
        }

    }

    public selectHighRiskDiagnose(event) {
        this.addNewDiagnosisGrid(event.data.ObjectID, "");
        this.HighRiskDiagnoseSelected = true;
    }

    public onHighRiskyPregnancyHiding() {
        this.showHighRiskyPregnancy = false;

        if (this.HighRiskDiagnoseSelected)
            this.highRiskAlgorithm("");
    }

    async openBZBH(): Promise<string> {
        let result1: string = await ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", i18n("M23735", "Uyarı"), i18n("0", "Bulaşıcı Hastalık!"), i18n("0", "Girdiğiniz tanı BZBH kapsamındadır.") + "\r\n" + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
        return result1;
    }

    async showPhysicianSuggestion(physicianSuggestionDefList: Array<PhysicianSuggestionDefViewModel>, physicianSuggestionDefViewModel: PhysicianSuggestionDefViewModel) {

        if (physicianSuggestionDefViewModel.diagnosisActionSuggestionViewModel == null) // Soru ya da uyarı ise
        {
            let result: string = await ShowBox.CustomShow(ShowBoxTypeEnum.Message, physicianSuggestionDefViewModel.ButtonCaptions, physicianSuggestionDefViewModel.ReturnValues, "Doktor KKD", "", physicianSuggestionDefViewModel.Message, 1);
            physicianSuggestionDefList.filter(dr => dr.ParentPhysicianSuggestionDefObjectId == physicianSuggestionDefViewModel.PhysicianSuggestionDefObjectId && dr.ReturnValueOfParent == result).forEach(physicianSuggestionDefVM => {
                this.showPhysicianSuggestion(physicianSuggestionDefList, physicianSuggestionDefVM);
            });
        }
        else// hizmet başlatılacak ise
        {
            this.openIstem.emit(); // bunu çağıran yerde istem panelinin tabına hiç tıklanmadı ise procedureRequestSharedService aktive olmuyordu .Tetkik istem yapılacaksa tıklanmış gibi davranması için yazıldı
            let diagnosisActionSuggestions = new Array<DiagnosisActionSuggestionViewModel>();

            //birden fazla tetkik girildi ise aynı anda sorması için  NOT:
            if (physicianSuggestionDefViewModel.DiagnosisObjectId != null) {// Procedure direk tanıyla başlatılan  Procedureler birden fazla olursa ayrı gruplarda oluyorlar ama Foreachle dönerken birbirini eziyorlar o yüzden  burada biri açıldığında diğerleri de forma yükleniyor
                physicianSuggestionDefList.filter(dr => dr.DiagnosisObjectId != null && dr.diagnosisActionSuggestionViewModel != null).forEach(physicianSuggestionDefVMForProcedure => {
                    diagnosisActionSuggestions.push(physicianSuggestionDefVMForProcedure.diagnosisActionSuggestionViewModel);
                });
            }
            else { // Procedure soru sonrası seçilirse Aynı sorunun aynı cevabından sonra gelen Procedureleri ekrana birlikte yükler
                physicianSuggestionDefList.filter(dr => dr.ParentPhysicianSuggestionDefObjectId == physicianSuggestionDefViewModel.ParentPhysicianSuggestionDefObjectId && dr.ReturnValueOfParent == physicianSuggestionDefViewModel.ReturnValueOfParent && dr.diagnosisActionSuggestionViewModel != null).forEach(physicianSuggestionDefVMForProcedure => {
                    diagnosisActionSuggestions.push(physicianSuggestionDefVMForProcedure.diagnosisActionSuggestionViewModel);
                });
            }
            this._tempDiagnosisActionSuggestionList = diagnosisActionSuggestions;
            this.showDiagnosisActionSuggestionPopup = true;
        }
    }


    rowPrepared(row: any) {
        //if (row.rowType == "data") {
        //row.data icinde rowun datasi var
        //row.rowElement.firstItem().removeClass();
        // }
    }

    rowInserting(data: any) {

    }

    rowRemoved(data: any) {
        //data.key.EntityState = EntityStateEnum.Deleted;
        data.key.RemoveSubEpisodeRelation = true;
    }



    onDiognosisGridContextMenuPreparing(e: any): void {
        let that = this;
        if (e.row !== undefined && e.row !== null) {
            if (e.row.rowType === 'data') {
                e.items = [{
                    text: "Favorilere Ekle",
                    disabled: false,
                    onItemClick: function () {
                        that.AddDiagnosisGridToFavorite(e.row.data);
                    }
                }
                ];
            }
        }
    }


    async AddDiagnosisGridToFavorite(data) {
        if (this.IsReadOnly != true) {
            if (data != null) {
                let diagnosisGrid = data;
                let exists: boolean = false;
                for (let i = 0; i < this.diagnosisGridFormViewModel.FavoriteDiagnosisList.length; i++) {
                    if (this.diagnosisGridFormViewModel.FavoriteDiagnosisList[i].Diagnose.ObjectID.toString() == diagnosisGrid.Diagnose.ObjectID.toString()) {
                        exists = true;
                        break;
                    }
                }
                if (!exists) {
                    let newFavoriteDiagnosis: FavoriteDiagnosis = new FavoriteDiagnosis();
                    newFavoriteDiagnosis = diagnosisGrid;
                    this.diagnosisGridFormViewModel.FavoriteDiagnosisList.push(newFavoriteDiagnosis);
                    this.saveFavoriteDiagnoseDefinition(newFavoriteDiagnosis.Diagnose.ObjectID.toString());
                } else {
                    ServiceLocator.MessageService.showInfo("Bu Tanı daha önceden Favori Tanılara Eklenmiştir.!");
                }
            }
        }
    }


    async RemoveDiagnosisGridToFavorite(data) {
        let that = this;
        if (this.IsReadOnly != true) {
            if (data != null && data.itemData != null && data.itemData.Diagnose != null) {
                this.httpService.get(this._DocumentServiceUrl + "RemoveFavoriteDiagnose?diagnoseDefinitionObjectId=" + data.itemData.Diagnose.ObjectID)
                    .then(result => {
                        that.diagnosisGridFormViewModel.FavoriteDiagnosisList.splice(data.itemIndex, 1);
                    })
                    .catch(error => {
                        console.log(error);
                    });

            }
        }
    }




    public initFormControls(): void {

        this.DiagnosisSelection = new TTVisual.TTObjectListBox();
        this.DiagnosisSelection.ListDefName = "DiagnosisListDefinition";
        this.DiagnosisSelection.Name = "DiagnosisSelection";
        this.DiagnosisSelection.AutoCompleteDialogWidth = "40%";

        this.GridDiagnosis = new TTVisual.TTGrid();
        this.GridDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridDiagnosis.Name = "GridDiagnosis";
        this.GridDiagnosis.AllowUserToAddRows = false;
        this.GridDiagnosis.TabIndex = 6;
        this.GridDiagnosis.Height = 116;
        this.GridDiagnosis.DeleteButtonWidth = 20;

        this.StarterAction = new TTLabelColumn();
        this.StarterAction.DataMember = "StarterAction";
        this.StarterAction.Name = "StarterAction";
        this.StarterAction.ToolTipText = "StarterAction";
        this.StarterAction.Width = 45;
        this.StarterAction.DisplayIndex = 6;
        this.StarterAction.HeaderText = i18n("M16818", "İşlem");

        this.Diagnose = new TTLabelColumn();
        this.Diagnose.DataMember = "Diagnose.GeneratedDisplayExpression";
        this.Diagnose.Name = "Diagnose.GeneratedDisplayExpression";
        this.Diagnose.ToolTipText = "Diagnose.GeneratedDisplayExpression";
        this.Diagnose.Width = "70%";
        this.Diagnose.DisplayIndex = 0;
        this.Diagnose.HeaderText = i18n("M22736", "Tanı");

        this.PreSecDiagnosis = new TTRadioButtonGroupColumn();
        this.PreSecDiagnosis.Font = {};
        this.PreSecDiagnosis.Items = this.preSecDiagnosisRadioItems;
        this.PreSecDiagnosis.DisplayExpression = 'Name';
        this.PreSecDiagnosis.ValueExpression = 'Value';
        this.PreSecDiagnosis.DataMember = "DiagnosisType";
        this.PreSecDiagnosis.Required = true;
        this.PreSecDiagnosis.DisplayIndex = 1;
        this.PreSecDiagnosis.HeaderText = i18n("M19963", "Ön  |Kesin"); //"Ön Tanı | Kesin Tanı"
        this.PreSecDiagnosis.Name = "PreSecDiagnosis";
        this.PreSecDiagnosis.ToolTipText = i18n("M19987", "Ön Tanı | Kesin Tanı");
        this.PreSecDiagnosis.Width = 57;
        this.PreSecDiagnosis.Margin = "0px 0px 0px 15px";
        this.PreSecDiagnosis.EnabledBindingPath = "isEnabled";



        this.IsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.IsMainDiagnose.DataMember = "IsMainDiagnose";
        this.IsMainDiagnose.DisplayIndex = 2;
        this.IsMainDiagnose.HeaderText = "Ana";
        this.IsMainDiagnose.ToolTipText = i18n("M10926", "Ana Tanı");
        this.IsMainDiagnose.Name = "IsMainDiagnose";
        this.IsMainDiagnose.Width = 35;
        this.IsMainDiagnose.EnabledBindingPath = "isEnabled";


        this.AddToFavorite = new TTVisual.TTButtonColumn();
        this.AddToFavorite.DisplayIndex = 4;
        this.AddToFavorite.HeaderText = "Favori";
        this.AddToFavorite.Text = i18n("M13543", "Ekle");
        this.AddToFavorite.Name = "AddToFavorite";
        this.AddToFavorite.ToolTipText = i18n("M14275", "Favoriye Ekle");
        this.AddToFavorite.Width = 35;
        //this.AddToFavorite.ButtonWidth = "30px";
        this.AddToFavorite.Height = "18px";
        this.AddToFavorite.EnabledBindingPath = "isEnabled";

        this.ResponsibleDoctor = new TTLabelColumn();
        this.ResponsibleDoctor.DataMember = "ResponsibleDoctor.Name";
        this.ResponsibleDoctor.Name = "ResponsibleDoctor.Name";
        this.ResponsibleDoctor.ToolTipText = "ResponsibleDoctor.Name";
        this.ResponsibleDoctor.Width = 55;
        this.ResponsibleDoctor.DisplayIndex = 5;
        this.ResponsibleDoctor.HeaderText = "Doktor";


        this.GridDiagnosisColumns = [this.Diagnose, this.PreSecDiagnosis, this.IsMainDiagnose, this.ResponsibleDoctor, this.AddToFavorite]; // this.StarterAction, //, this.DiagnoseDate,this.AddToHistory, this.FreeDiagnosis



    }

    onEnabizClose(fromSave: boolean) {
        let that = this;
        if (fromSave) {//Nabız ektranındaki kaydetten geldiyse
            this.showENabizPopup = false;
            this.sendENabizViewModel.emit(this._eNabizViewModels);

            //Nabız ekranından veri girişi olduysa tanı ekler
            that.AddSelectedDiagnosisToDiagnosisGrid(that.selectedData);

        } else//Cancel ise
        {
            this.showENabizPopup = false;
        }


    }

    async onDiagnosisActionSuggestionClose(fromSave: boolean) {
        if (fromSave) {//Nabız ektranındaki kaydetten geldiyse
            this.showDiagnosisActionSuggestionPopup = false;


            if (this._tempDiagnosisActionSuggestionList != null) {
                let procedureFormDetailList: Array<Guid> = new Array<Guid>();
                let procedureList: Array<Guid> = new Array<Guid>();
                let ignoredProcedureNameList: Array<string> = new Array<string>();
                let isChoosed: boolean = false;
                this._tempDiagnosisActionSuggestionList.forEach(dr => {
                    dr.ChoosedByUser = true;
                    if (dr.CreateProcedure == true) {
                        isChoosed = true;
                        //this.DiagnosisActionSuggestionList.push(dr);
                        if (dr.ProcedureRequestFormDetailObjectId != null && dr.ProcedureRequestFormDetailObjectId != new Guid("00000000-0000-0000-0000-000000000000"))
                            procedureFormDetailList.push(dr.ProcedureRequestFormDetailObjectId);
                        else if (dr.IsAdditionalApplication)
                            procedureList.push(dr.ProcedureObjectId);
                        else
                            ignoredProcedureNameList.push(dr.ProcedureName);
                    }
                });
                if (isChoosed) {
                    this.procedureRequestSharedService.onpackageSelected(procedureFormDetailList); // Tetkik istemden panelinden Checklemek için
                    for (let procedureObjectId of procedureList) {
                        this.procedureRequestSharedService.addProcedureToRequestedProcedureGrid(procedureObjectId, this.EpisodeAction.ObjectID); // Hizmet Tetkik istek Gridine atmak için
                    }
                    if (ignoredProcedureNameList.length > 0) {
                        let msg = i18n("M11192", "Aşağıdaki Hizmetler İstem kataloğunda yer almadığı için istem yapılamadı");
                        for (let procedureName of ignoredProcedureNameList) {
                            msg = msg + "<br/>" + procedureName;
                        }
                        TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), msg, MessageIconEnum.WarningMessage, 400);
                    }
                    //for (let formdetailID of packageProcedureFormDetails) {
                    //    this.procedureRequestSharedService.procedureRequestOnChange(formdetailID, this.EpisodeAction.ObjectID, true, false, this.RecTime, false); // Hizmet Tetkik istek Gridine atmak için
                    //}

                }
            }

        } else//Cancel ise
        {
            this.showDiagnosisActionSuggestionPopup = false;
        }

        this._tempDiagnosisActionSuggestionList = [];
    }





}
