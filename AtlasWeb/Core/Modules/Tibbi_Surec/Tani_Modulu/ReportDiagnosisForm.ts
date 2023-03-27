//$20ABFE68

import { Component, ApplicationRef, Input, OnChanges, SimpleChanges, EventEmitter, Output } from '@angular/core';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { ReportDiagnosisFormViewModel, ReportDiagnosisGridListViewModel } from './ReportDiagnosisFormViewModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

@Component({
    selector: 'ReportDiagnosisForm',
    templateUrl: './ReportDiagnosisForm.html',
    providers: [MessageService]
})
export class ReportDiagnosisForm extends TTVisual.TTForm implements OnChanges {

    DiagnosisSelection: TTVisual.ITTObjectListBox;
    gridReportDiagnosis: TTVisual.ITTGrid;
    txtDiagnosisName: TTVisual.ITTTextBoxColumn;
    public gridReportDiagnosisColumns = [];

    public reportDiagnosisFormViewModel: ReportDiagnosisFormViewModel = new ReportDiagnosisFormViewModel();

    public showMainDiagnoseDefinitions: boolean = true;
    public enableSelectionOfMainDiagnoses: boolean = false;


    private DiagnosisGridForm_DocumentUrl: string = '/api/ReportDiagnosisService/';

    //constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
    //    super("", "DiagnosisGridForm")
    //    this._DocumentServiceUrl = this.DiagnosisGridForm_DocumentUrl
    //    this.showENabizPopup = false;
    //    this.initViewModel();
    //    this.initFormControls();
    //}
    private HCExaminationComponentForm_DocumentUrl: string = '/api/ReportDiagnosisService/';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private detector: ApplicationRef) {
        super('', 'ReportDiagnosisForm');
        this._DocumentServiceUrl = this.HCExaminationComponentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
    @Output() sendDiagnosisViewModel: EventEmitter<any> = new EventEmitter<any>();

    private _reportViewModels: Array<any> = [];

    //_nabizDataSetList: Array<ENabizDataSets> = [];

    private _episodeAction: Guid;
    @Input() set EpisodeAction(value: Guid) {
        this._episodeAction = value;
        this.reportDiagnosisFormViewModel.reportEpisodeAction = value;

    }
    get EpisodeAction(): Guid {
        return this.reportDiagnosisFormViewModel.reportEpisodeAction;
    }

    @Input() set Episode(value: Guid) {
        this.reportDiagnosisFormViewModel.episode = value;

    }
    get Episode(): Guid {
        return this.reportDiagnosisFormViewModel.episode;
    }
    private _isNew: boolean;
    @Input() set IsNew(value: boolean) {
        this._isNew = value;

    }
    get IsNew(): boolean {
        return this._isNew;
    }
    private _isReadOnly: boolean;
    @Input() set IsReadOnly(value: boolean) {
        this._isReadOnly = value;

    }
    get IsReadOnly(): boolean {
        return this._isReadOnly;
    }

    public _isOnPopUp: Boolean = false;
    @Input() set IsOnPopUp(value: Boolean) {
        this._isOnPopUp = value;
    }

    get IsOnPopUp(): Boolean {
        return this._isOnPopUp;
    }


    public initViewModel(): void {
        //this._TTObject = new HCExaminationComponent();
        this.reportDiagnosisFormViewModel = new ReportDiagnosisFormViewModel();
        this._ViewModel = this.reportDiagnosisFormViewModel;



        //this.hCExaminationComponentFormViewModel._HCExaminationComponent = this._TTObject as HCExaminationComponent;
        //  this.hCExaminationComponentFormViewModel._HCExaminationComponent.ReasonForExamination = new ReasonForExaminationDefinition();

    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['EpisodeAction'] || changes['Episode']) {
            this.getReadOnlyDiagnosis();
        }
        //if (changes['IsReadOnly']) {
        //    //this.getReadOnlyDiagnosis();
        //}
    }
    public async getReadOnlyDiagnosis() {
        let that = this;
        if (that.Episode != null && that.EpisodeAction != null) {
            let episodeAction = that.EpisodeAction;
            let episode = that.Episode;
            this.httpService.get<Array<ReportDiagnosisGridListViewModel>>(this._DocumentServiceUrl + "PreScriptReportDiagnosisForm?reportEpisodeAction=" + episodeAction.toString() + "&episode=" + episode.toString() + "&isNew=" + this._isNew)
                .then(result => {
                    this.reportDiagnosisFormViewModel.ReportDiagnosisGridList = result as Array<ReportDiagnosisGridListViewModel>;
                    this.sendDiagnosisViewModel.emit(this.reportDiagnosisFormViewModel);
                })
                .catch(error => {
                    console.log(error);
                });
        }
    }
    async ngOnInit() {
        //  await this.load();
        //let result = <ReportDiagnosisGridListViewModel[]>await this.httpService.get('/api/ReportDiagnosisService/PreScriptReportDiagnosisForm?reportEpisodeAction=' + this.reportDiagnosisFormViewModel.reportEpisodeAction.ObjectID + "&episode=" + this.reportDiagnosisFormViewModel.reportEpisodeAction.Episode);
        //this.reportDiagnosisFormViewModel.ReportDiagnosisGridList = result;
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
    }

    diagnosisSelection_ValueChanged(data: any) {
        let that = this;
        if (data != null) {
            if (!this._isReadOnly) {
                if (this.enableSelectionOfMainDiagnoses == false && data.IsLeaf == false) {
                    ServiceLocator.MessageService.showInfo("Bu Tanının Alt Kırılımı bulunduğundan bu tanıyı seçemezsiniz.!");
                } else {
                    this.reportDiagnosisFormViewModel._selectedDiagnosis = data;
                    let foundCheck = false;
                    this.reportDiagnosisFormViewModel.ReportDiagnosisGridList.forEach(item => {
                        if (item.DiagnoseCode == data.Code && foundCheck == false) {
                            foundCheck = true;
                        }
                    });
                    if (foundCheck == false) {
                        let diagnosis: ReportDiagnosisGridListViewModel = new ReportDiagnosisGridListViewModel();
                        diagnosis.Diagnosis = this.reportDiagnosisFormViewModel._selectedDiagnosis;
                        diagnosis.DiagnoseName = this.reportDiagnosisFormViewModel._selectedDiagnosis.Code + ' ' + this.reportDiagnosisFormViewModel._selectedDiagnosis.Name;
                        diagnosis.DiagnoseCode = this.reportDiagnosisFormViewModel._selectedDiagnosis.Code;
                        this.reportDiagnosisFormViewModel.ReportDiagnosisGridList.push(diagnosis);
                    }

                    this.sendDiagnosisViewModel.emit(this.reportDiagnosisFormViewModel);
                    this.reportDiagnosisFormViewModel._selectedDiagnosis = null;
                    window.setTimeout(t => {
                        if (this.reportDiagnosisFormViewModel._selectedDiagnosis === null)
                            this.reportDiagnosisFormViewModel._selectedDiagnosis = undefined;
                        else
                            this.reportDiagnosisFormViewModel._selectedDiagnosis = null;
                        that.detector.tick();
                    }, 0);
                }
            }
        }
    }


    onReportClose(fromSave: boolean) {
        let that = this;
        if (fromSave) {//Rapor ektranındaki kaydetten geldiyse
            this.sendDiagnosisViewModel.emit(this._reportViewModels);

            ////Nabız ekranından veri girişi olduysa tanı ekler
            //that.diagnosisGridFormViewModel.DiagnosisDefinitions.push(this.selectedData);
            //this.addNewDiagnosisGrid(this.selectedData.ObjectID, "");

        } else//Cancel ise
        {
            //this.showENabizPopup = false;
        }
    }

    public initFormControls(): void {

        this.DiagnosisSelection = new TTVisual.TTObjectListBox();
        this.DiagnosisSelection.ListDefName = "DiagnosisListDefinition";
        this.DiagnosisSelection.Name = "DiagnosisSelection";
        this.DiagnosisSelection.AutoCompleteDialogWidth = "38%";

        this.gridReportDiagnosis = new TTVisual.TTGrid();
        this.gridReportDiagnosis.Name = "gridReportDiagnosis";
        this.gridReportDiagnosis.TabIndex = 7;
        this.gridReportDiagnosis.AllowUserToAddRows = false;
        this.gridReportDiagnosis.AllowUserToDeleteRows = true;
        this.gridReportDiagnosis.AllowUserToOrderColumns = true;
        this.gridReportDiagnosis.Height = "100";
        this.gridReportDiagnosis.Enabled = this._isReadOnly == true ? false : true;
        this.gridReportDiagnosis.DeleteButtonWidth = "7%";

        this.txtDiagnosisName = new TTVisual.TTTextBoxColumn();
        this.txtDiagnosisName.DataMember = "DiagnoseName";
        this.txtDiagnosisName.DisplayIndex = 0;
        this.txtDiagnosisName.HeaderText = "Tanılar";
        this.txtDiagnosisName.Name = "txtDiagnosisName";
        this.txtDiagnosisName.Width = "93%";
        this.txtDiagnosisName.ReadOnly = true;

        this.gridReportDiagnosisColumns = [this.txtDiagnosisName];
    }
}