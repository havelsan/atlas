//$F0B200A1
import { Component, ViewChild, ViewChildren, OnInit, ApplicationRef, Input, OnChanges, SimpleChanges, AfterViewInit, QueryList, OnDestroy } from '@angular/core';
import { DiagnosisGridFormViewModel, vmDiagnosisGridReadOnly } from "./DiagnosisGridFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { HvlDataGrid } from "Fw/Components/HvlDataGrid";
import { HvlCheckBox } from "Fw/Components/HvlCheckBox";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionWithDiagnosis } from 'NebulaClient/Model/AtlasClientModel';
import { DxListComponent, DxDataGridComponent } from "devextreme-angular";
import { TTRadioButtonGroupColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTRadioButtonGroupColumn';
import { TTLabelColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTLabelColumn';
import { IModalService } from "Fw/Services/IModalService";
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { ProcedureRequestSharedService } from "../Tetkik_Istem_Modulu/ProcedureRequestSharedService";

@Component({
    selector: 'DiagnosisGridReadOnlyForm',
    templateUrl: './DiagnosisGridReadOnlyForm.html',
    providers: [MessageService]
})
export class DiagnosisGridReadOnlyForm extends TTVisual.TTForm implements OnInit, OnChanges, AfterViewInit, OnDestroy {
    @ViewChildren(DxListComponent) ListsInstance: QueryList<DxListComponent>;

    Diagnose: TTLabelColumn;
    StarterAction: TTLabelColumn;
    DiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    FreeDiagnosis: TTVisual.ITTTextBoxColumn;
    GridDiagnosis: TTVisual.ITTGrid;
    IsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    // PreSecDiagnosis: TTVisual.ITTEnumComboBoxColumn;
    PreSecDiagnosis: TTRadioButtonGroupColumn;
    ResponsibleDoctor: TTLabelColumn;
    // ResponsibleUser: TTVisual.ITTListBoxColumn;
    public GridDiagnosisColumns = [];
    dialogWidth: string;
    dialogHeight: string;
    dialogLeft: string;
    dialogTop: string;
    dialogOpened: Boolean = false;
    TimeOutHandler: any;

    selectedData: any;

    public diagnosisGridFormViewModel: DiagnosisGridFormViewModel = new DiagnosisGridFormViewModel();
    public get _EpisodeActionWithDiagnosis(): EpisodeActionWithDiagnosis {
        return this._TTObject as EpisodeActionWithDiagnosis;
    }


    public columns = [
        {
            caption: i18n("M22736", "Tanı"),
            name: "Diagnose",
            dataField: "Diagnosis",
            width: 300,
        },
        {
            caption: i18n("M19992", "Ön|Kesin"),
            name: "PreSecDiagnosis",
            dataField: "DiagnosisType",
            width: 70,
            cellTemplate: "DiagnosisTypeCellTemplate",
            allowEditing: false,
        },
        {
            caption: i18n("M10926", "Ana Tanı"),
            name: "IsMainDiagnose",
            dataField: "IsMainDiagnose",
            width: 50,
            cellTemplate: "IsMainDiagnoseCellTemplate",
            allowEditing: false,
        },
        {
            caption: "Doktor",
            name: "ResponsibleDoctor",
            dataField: "ResponsibleDoctor",
            width: 100,
        },
        {
            caption: "Giriş İşlemi",
            name: "EntryActionType",
            dataField: "EntryActionType",
            width: 100,
        },
    ];

    preSecDiagnosisRadioItems: Array<any> = [{ Value: 1, Name: '' }, { Value: 2, Name: '' }]; //"DiagnosisTypeEnum";// 1 -> Ön Tanı , 2 -> Kesin Tanı

    private DiagnosisGridForm_DocumentUrl: string = '/api/DiagnosisGridService/';

    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private detector: ApplicationRef, protected modalService: IModalService, protected activeUserService: IActiveUserService, private procedureRequestSharedService: ProcedureRequestSharedService) {
        super("", "DiagnosisGridForm");
        this._DocumentServiceUrl = this.DiagnosisGridForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();

    }

    // ***** Method declarations start *****

    private _episodeAction: EpisodeActionWithDiagnosis;
    @Input() set EpisodeAction(value: EpisodeActionWithDiagnosis) {
        this._episodeAction = value;
    }
    get EpisodeAction(): EpisodeActionWithDiagnosis {
        return this._episodeAction;
    }

    private _height: 130;
    @Input() set Height(value: any) {
        this._height = value;
    }
    get Height(): any {
        return this._height;
    }



    expanded() {
        if (this.ListsInstance) {
            this.ListsInstance.forEach(item => {
                item.instance.repaint();
            });
        }
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['EpisodeAction']) {
             this.getReadOnlyDiagnosis();
        }
    }
    async ngOnInit() {
        this.getReadOnlyDiagnosis();
        this.redirectProperties();
    }

    ngAfterViewInit() {
    }
    ngOnDestroy() {
    }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this.diagnosisGridFormViewModel = new DiagnosisGridFormViewModel();
        this._ViewModel = this.diagnosisGridFormViewModel;
    }
    public GridDiagnosisGridList: Array<vmDiagnosisGridReadOnly>;

    protected getReadOnlyDiagnosis() {
        let that = this;
        if (this.EpisodeAction != null) {
            let episodeActionOrSubEpisodeObjectID = that.getEpisodeActionOrSubEpisodeObjectID();
            if (episodeActionOrSubEpisodeObjectID != null) {
                this.httpService.get<Array<vmDiagnosisGridReadOnly>>(this._DocumentServiceUrl + "GetDiagnosisGridReadOnlyForm?episodeActionOrSubEpisodeObjectID=" + episodeActionOrSubEpisodeObjectID)
                    .then(result => {

                        that.GridDiagnosisGridList = result as Array<vmDiagnosisGridReadOnly>;
                        //that.loadViewModelDefinitions();
                    })
                    .catch(error => {
                        console.log(error);
                    });
            }

        }
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


    //protected async loadViewModelDefinitions() {
    //    let that = this;

    //    that.diagnosisGridFormViewModel = this._ViewModel as DiagnosisGridFormViewModel;
    //    //if (this.diagnosisGridFormViewModel == null)
    //    //    this.diagnosisGridFormViewModel = new DiagnosisGridFormViewModel();
    //    //if (!that.GridDiagnosisGridList) {
    //    //    return;
    //    //}
    //    //for (let detailItem of that.GridDiagnosisGridList) {
    //    //    detailItem.Diagnose = this.getDiagnosisDefinitionItem(detailItem["Diagnose"]);
    //    //    detailItem.Diagnose['GeneratedDisplayExpression'] = detailItem.Diagnose.Code + ' ' + detailItem.Diagnose.Name;
    //    //    //detailItem.ResponsibleUser = this.getResUserItem(detailItem["ResponsibleUser"]);
    //    //    if (detailItem.EntryActionType != undefined && detailItem.EntryActionType != null) {
    //    //        let entryActionType: string = await CommonService.GetDisplayTextOfEnumValue('ActionTypeEnum', detailItem.EntryActionType);
    //    //        if (entryActionType)
    //    //            detailItem["StarterAction"] = entryActionType;
    //    //    }
    //    //    //Bir doktorun girdiği tanıyı bir başkası silemez
    //    //    detailItem.ResponsibleDoctor = this.getResUserItem(detailItem["ResponsibleDoctor"]);
    //    //    detailItem['isEnabled'] = false;
    //    //}
    //    this.datagrid.instance.refresh();
    //    //this.datagrid.instance.repaint();

    //}


    public redirectProperties(): void {

    }




    public initFormControls(): void {

        this.GridDiagnosis = new TTVisual.TTGrid();
        this.GridDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridDiagnosis.Name = "GridDiagnosis";
        this.GridDiagnosis.AllowUserToAddRows = false;
        this.GridDiagnosis.AllowUserToDeleteRows = false;
        this.GridDiagnosis.TabIndex = 6;
        this.GridDiagnosis.Height = 130;

        //this.StarterAction = new TTLabelColumn();
        //this.StarterAction.DataMember = "StarterAction";
        //this.StarterAction.Name = "StarterAction";
        //this.StarterAction.ToolTipText = "StarterAction";
        //this.StarterAction.Width = 45;
        //this.StarterAction.DisplayIndex = 6;
        //this.StarterAction.HeaderText = "İşlem";

        //this.Diagnose = new TTLabelColumn();
        //this.Diagnose.DataMember = "Diagnose.GeneratedDisplayExpression";
        //this.Diagnose.Name = "Diagnose.GeneratedDisplayExpression";
        //this.Diagnose.ToolTipText = "Diagnose.GeneratedDisplayExpression";
        //this.Diagnose.Width = "70%";
        //this.Diagnose.DisplayIndex = 0;
        //this.Diagnose.HeaderText = "Tanı";



        //this.PreSecDiagnosis = new TTRadioButtonGroupColumn();
        //this.PreSecDiagnosis.Font = {};
        //this.PreSecDiagnosis.Items = this.preSecDiagnosisRadioItems;
        //this.PreSecDiagnosis.DisplayExpression = 'Name';
        //this.PreSecDiagnosis.ValueExpression = 'Value';
        //this.PreSecDiagnosis.DataMember = "DiagnosisType";
        //this.PreSecDiagnosis.Required = true;
        //this.PreSecDiagnosis.DisplayIndex = 1;
        //this.PreSecDiagnosis.HeaderText = "Ön  |Kesin";//"Ön Tanı | Kesin Tanı"
        //this.PreSecDiagnosis.Name = "PreSecDiagnosis";
        //this.PreSecDiagnosis.ToolTipText = "'Ön Tanı | Kesin Tanı'"
        //this.PreSecDiagnosis.Width = 57;
        //this.PreSecDiagnosis.Margin = "0px 0px 0px 15px";
        //this.PreSecDiagnosis.EnabledBindingPath = "isEnabled";



        //this.IsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        //this.IsMainDiagnose.DataMember = "IsMainDiagnose";
        //this.IsMainDiagnose.DisplayIndex = 2;
        //this.IsMainDiagnose.HeaderText = "Ana";
        //this.IsMainDiagnose.ToolTipText = "'Ana Tanı'";
        //this.IsMainDiagnose.Name = "IsMainDiagnose";
        //this.IsMainDiagnose.Width = 35;
        //this.IsMainDiagnose.EnabledBindingPath = "isEnabled";



        //this.ResponsibleDoctor = new TTLabelColumn();
        //this.ResponsibleDoctor.DataMember = "ResponsibleDoctor.Name";
        //this.ResponsibleDoctor.Name = "ResponsibleDoctor.Name";
        //this.ResponsibleDoctor.ToolTipText = "ResponsibleDoctor.Name";
        //this.ResponsibleDoctor.Width = 55;
        //this.ResponsibleDoctor.DisplayIndex = 5;
        //this.ResponsibleDoctor.HeaderText = "Doktor";

        //this.GridDiagnosisColumns = [this.Diagnose, this.PreSecDiagnosis, this.IsMainDiagnose, this.ResponsibleDoctor];// this.StarterAction, //, this.DiagnoseDate,this.AddToHistory, this.FreeDiagnosis




    }






}
