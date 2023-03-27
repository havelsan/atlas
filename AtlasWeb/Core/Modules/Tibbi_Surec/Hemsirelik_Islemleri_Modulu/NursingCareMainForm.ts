//$168B8560
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { NursingCareMainFormViewModel, NursingDefinitionListsByProblemID } from './NursingCareMainFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { HvlMultiSearchPanel } from 'Fw/Components/HvlMultiSearchPanel';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { NursingCare } from 'NebulaClient/Model/AtlasClientModel';
import { NursingProblemDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { NursingCareGrid } from 'NebulaClient/Model/AtlasClientModel';
import { NursingReasonGrid } from 'NebulaClient/Model/AtlasClientModel';
import { NursingTargetGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { TTMultiSearchPanelConfig, MultiSearchPanelSize } from 'NebulaClient/Visual/Controls/TTMultiSearchPanel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Exception } from 'NebulaClient/Mscorlib/Exception';

import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from "app/NebulaClient/Mscorlib/GuidParam";
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';
//declare var jQuery: any;

@Component({
    selector: 'NursingCareMainForm',
    templateUrl: './NursingCareMainForm.html',
    providers: [MessageService]
})
export class NursingCareMainForm extends BaseNursingDataEntryForm implements OnInit {
    @ViewChild('hvlMultiSearchPanel') hvlMultiSearchPanel: HvlMultiSearchPanel;
    //deferred: any;
    ApplicationDate: TTVisual.ITTDateTimePicker;
    labelApplicationDate: TTVisual.ITTLabel;
    labelNote: TTVisual.ITTLabel;
    labelNursingResult: TTVisual.ITTLabel;

    Note: TTVisual.ITTTextBox;
    NursingProblem: TTVisual.ITTObjectListBox;
    NursingResult: TTVisual.ITTEnumComboBox;
    labelNursingProblem: TTVisual.ITTLabel;

    // labelProcedureObject: TTVisual.ITTLabel;

    //labelNursingReason: TTVisual.ITTLabel;
    //labelNursingTarget: TTVisual.ITTLabel;
    //NursingReason: TTVisual.ITTObjectListBox;
    //NursingTarget: TTVisual.ITTObjectListBox;
    // ProcedureObject: TTVisual.ITTObjectListBox;

    // Eklemeye gerek yok çünkü bunlar grid olarak gözükmüyorlar
    //NursingCareGrids: TTVisual.ITTGrid;
    //NursingCareList: TTVisual.ITTListBoxColumn;
    //NursingReasonGrid: TTVisual.ITTListBoxColumn;
    //NursingReasonGrids: TTVisual.ITTGrid;
    //NursingTargetGrid: TTVisual.ITTListBoxColumn;
    //NursingTargetGrids: TTVisual.ITTGrid;
    //public NursingCareGridsColumns = [];
    //public NursingReasonGridsColumns = [];
    //public NursingTargetGridsColumns = [];




    public nursingCareMainFormViewModel: NursingCareMainFormViewModel = new NursingCareMainFormViewModel();
    public get _NursingCare(): NursingCare {
        return this._TTObject as NursingCare;
    }
    private NursingCareMainForm_DocumentUrl: string = '/api/NursingCareService/NursingCareMainForm';
    public SearchPanelDataSources: Array<Array<any>> = new Array<Array<any>>(4);
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone, protected reportService: AtlasReportService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingCareMainForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NursingCare();
        this.nursingCareMainFormViewModel = new NursingCareMainFormViewModel();
        this._ViewModel = this.nursingCareMainFormViewModel;
        this.nursingCareMainFormViewModel._NursingCare = this._TTObject as NursingCare;
        this.nursingCareMainFormViewModel._NursingCare.NursingProblem = new NursingProblemDefinition();
        //this.nursingCareMainFormViewModel._NursingCare.NursingReason = new NursingReasonDefinition();
        //this.nursingCareMainFormViewModel._NursingCare.NursingTarget = new NursingTargetDefinition();
        //this.nursingCareMainFormViewModel._NursingCare.ProcedureObject = new NursingCareDefinition();

        this.nursingCareMainFormViewModel._NursingCare.NursingCareGrids = new Array<NursingCareGrid>();
        this.nursingCareMainFormViewModel._NursingCare.NursingReasonGrids = new Array<NursingReasonGrid>();
        this.nursingCareMainFormViewModel._NursingCare.NursingTargetGrids = new Array<NursingTargetGrid>();
    }

    protected loadViewModel() {
        let that = this;

        that.nursingCareMainFormViewModel = this._ViewModel as NursingCareMainFormViewModel;
        that._TTObject = this.nursingCareMainFormViewModel._NursingCare;
        if (this.nursingCareMainFormViewModel == null)
            this.nursingCareMainFormViewModel = new NursingCareMainFormViewModel();
        if (this.nursingCareMainFormViewModel._NursingCare == null)
            this.nursingCareMainFormViewModel._NursingCare = new NursingCare();

        let nursingProblemObjectID = that.nursingCareMainFormViewModel._NursingCare["NursingProblem"];
        if (nursingProblemObjectID != null && (typeof nursingProblemObjectID === 'string')) {
            let nursingProblem = that.nursingCareMainFormViewModel.NursingProblemDefinitions.find(o => o.ObjectID.toString() === nursingProblemObjectID.toString());
            if (nursingProblem) {
                that.nursingCareMainFormViewModel._NursingCare.NursingProblem = nursingProblem;
            }
        }

        //let nursingReasonObjectID = that.nursingCareMainFormViewModel._NursingCare["NursingReason"];
        //if (nursingReasonObjectID != null && (typeof nursingReasonObjectID === 'string')) {
        //    let nursingReason = that.nursingCareMainFormViewModel.NursingReasonDefinitions.find(o => o.ObjectID.toString() === nursingReasonObjectID.toString());
        //     if (nursingReason) {
        //        that.nursingCareMainFormViewModel._NursingCare.NursingReason = nursingReason;
        //    }
        //}
        //let nursingTargetObjectID = that.nursingCareMainFormViewModel._NursingCare["NursingTarget"];
        //if (nursingTargetObjectID != null && (typeof nursingTargetObjectID === 'string')) {
        //    let nursingTarget = that.nursingCareMainFormViewModel.NursingTargetDefinitions.find(o => o.ObjectID.toString() === nursingTargetObjectID.toString());
        //     if (nursingTarget) {
        //        that.nursingCareMainFormViewModel._NursingCare.NursingTarget = nursingTarget;
        //    }
        //}
        //let procedureObjectObjectID = that.nursingCareMainFormViewModel._NursingCare["ProcedureObject"];
        //if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
        //    let procedureObject = that.nursingCareMainFormViewModel.NursingCareDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
        //     if (procedureObject) {
        //        that.nursingCareMainFormViewModel._NursingCare.ProcedureObject = procedureObject;
        //    }
        //}
        that.nursingCareMainFormViewModel._NursingCare.NursingCareGrids = that.nursingCareMainFormViewModel.NursingCareGridsGridList;
        for (let detailItem of that.nursingCareMainFormViewModel.NursingCareGridsGridList) {
            let nursingCareObjectID = detailItem["NursingCare"];
            if (nursingCareObjectID != null && (typeof nursingCareObjectID === "string")) {
                let nursingCare = that.nursingCareMainFormViewModel.NursingCareDefinitions.find(o => o.ObjectID.toString() === nursingCareObjectID.toString());
                if (nursingCare) {
                    detailItem.NursingCare = nursingCare;
                }
            }

        }
        that.nursingCareMainFormViewModel._NursingCare.NursingReasonGrids = that.nursingCareMainFormViewModel.NursingReasonGridsGridList;
        for (let detailItem of that.nursingCareMainFormViewModel.NursingReasonGridsGridList) {
            let nursingReasonObjectID = detailItem["NursingReason"];
            if (nursingReasonObjectID != null && (typeof nursingReasonObjectID === "string")) {
                let nursingReason = that.nursingCareMainFormViewModel.NursingReasonDefinitions.find(o => o.ObjectID.toString() === nursingReasonObjectID.toString());
                if (nursingReason) {
                    detailItem.NursingReason = nursingReason;
                }
            }
        }
        that.nursingCareMainFormViewModel._NursingCare.NursingTargetGrids = that.nursingCareMainFormViewModel.NursingTargetGridsGridList;
        for (let detailItem of that.nursingCareMainFormViewModel.NursingTargetGridsGridList) {
            let nursingTargetObjectID = detailItem["NursingTarget"];
            if (nursingTargetObjectID != null && (typeof nursingTargetObjectID === "string")) {
                let nursingTarget = that.nursingCareMainFormViewModel.NursingTargetDefinitions.find(o => o.ObjectID.toString() === nursingTargetObjectID.toString());
                if (nursingTarget) {
                    detailItem.NursingTarget = nursingTarget;
                }
            }

        }

        //this.deferred.resolve(that.nursingCareMainFormViewModel.NursingProblemDefinitions);
        /*
        .then(() => {
            that.Panel.Repaint();
        })
        */
        //that.changed(that.nursingCareMainFormViewModel.NursingProblemDefinitions);
    }


    async ngOnInit() {
        let that = this;
        await this.load(NursingCareMainFormViewModel);
  
    }


    protected async ClientSidePreScript(): Promise<void> {

        super.ClientSidePreScript();

        if (this.nursingCareMainFormViewModel.NursingProblemDefinitions != null)
            this.SearchPanelDataSources[0] = this.nursingCareMainFormViewModel.NursingProblemDefinitions;
        if (this.nursingCareMainFormViewModel.NursingReasonDefinitions != null)
            this.SearchPanelDataSources[1] = this.nursingCareMainFormViewModel.NursingReasonDefinitions;
        if (this.nursingCareMainFormViewModel.NursingCareDefinitions != null)
            this.SearchPanelDataSources[2] = this.nursingCareMainFormViewModel.NursingCareDefinitions;
        if (this.nursingCareMainFormViewModel.NursingTargetDefinitions != null)
            this.SearchPanelDataSources[3] = this.nursingCareMainFormViewModel.NursingTargetDefinitions;



     if (this.nursingCareMainFormViewModel._NursingCare.NursingProblem != null)
            this.hvlMultiSearchPanel.setDefaultValues(0, this.nursingCareMainFormViewModel._NursingCare);
        if (this.nursingCareMainFormViewModel._NursingCare.NursingReasonGrids != null)
           this.hvlMultiSearchPanel.setDefaultValues(1, this.nursingCareMainFormViewModel._NursingCare.NursingReasonGrids);
        if (this.nursingCareMainFormViewModel._NursingCare.NursingCareGrids != null)
             this.hvlMultiSearchPanel.setDefaultValues(2, this.nursingCareMainFormViewModel._NursingCare.NursingCareGrids);
        if (this.nursingCareMainFormViewModel._NursingCare.NursingTargetGrids != null)
           this.hvlMultiSearchPanel.setDefaultValues(3, this.nursingCareMainFormViewModel._NursingCare.NursingTargetGrids);


        //if (this.nursingCareMainFormViewModel._NursingCare.NursingProblem != null)
        //    this.PanelConfig[0].LinkedObject = this.nursingCareMainFormViewModel._NursingCare; // this.PanelConfig[0].LinkedObject.concat(this.nursingCareMainFormViewModel._NursingCare);
        //if (this.nursingCareMainFormViewModel._NursingCare.NursingReasonGrids != null)
        //    this.PanelConfig[1].LinkedObject = this.nursingCareMainFormViewModel._NursingCare.NursingReasonGrids//  this.PanelConfig[1].LinkedObject.concat(this.nursingCareMainFormViewModel._NursingCare.NursingReasonGrids);
        //if (this.nursingCareMainFormViewModel._NursingCare.NursingCareGrids != null)
        //    this.PanelConfig[2].LinkedObject = this.nursingCareMainFormViewModel._NursingCare.NursingCareGrids// this.PanelConfig[2].LinkedObject.concat(this.nursingCareMainFormViewModel._NursingCare.NursingCareGrids);
        //if (this.nursingCareMainFormViewModel._NursingCare.NursingTargetGrids != null)
        //    this.PanelConfig[3].LinkedObject = this.nursingCareMainFormViewModel._NursingCare.NursingTargetGrids// this.PanelConfig[3].LinkedObject.concat(this.nursingCareMainFormViewModel._NursingCare.NursingTargetGrids);


        //if (this.nursingCareMainFormViewModel._NursingCare.NursingProblem != null)
        //    this.PanelConfig[0].SelectedObjects.push(this.nursingCareMainFormViewModel._NursingCare.NursingProblem);
        //if (this.nursingCareMainFormViewModel._NursingCare.NursingReasonGrids != null) {
        //    this.nursingCareMainFormViewModel._NursingCare.NursingReasonGrids.forEach(dr => {
        //        this.PanelConfig[1].SelectedObjects.push(dr.NursingReason);
        //    }
        //    );
        //}
        //if (this.nursingCareMainFormViewModel._NursingCare.NursingCareGrids != null) {
        //    this.nursingCareMainFormViewModel._NursingCare.NursingCareGrids.forEach(dr => {
        //        this.PanelConfig[2].SelectedObjects.push(dr.NursingCare);
        //    }
        //    );
        //}
        //if (this.nursingCareMainFormViewModel._NursingCare.NursingTargetGrids != null) {
        //    this.nursingCareMainFormViewModel._NursingCare.NursingTargetGrids.forEach(dr => {
        //        this.PanelConfig[1].SelectedObjects.push(dr.NursingTarget);
        //    }
        //    );
        //}



        if (this["NursAppReadOnly"] != null)
            this.nursingCareMainFormViewModel.ReadOnly = (this.nursingCareMainFormViewModel.ReadOnly || this["NursAppReadOnly"]);

        if (this.nursingCareMainFormViewModel.ReadOnly)
            this.DropStateButton(NursingCare.NursingCareStates.Cancelled);

    }

    printReport() {
        let a: any = this.nursingCareMainFormViewModel._NursingCare.NursingApplication;
        if (a.ObjectID != undefined)
            a = a.ObjectID;
        const TTOBJECTID = new GuidParam(a);
        let reportParameters: any = { 'TTOBJECTID': TTOBJECTID };
        this.reportService.showReport('NursingCareReport', reportParameters);
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);

        if (this._NursingCare.NursingProblem == null)
            throw new Exception(i18n("M15702", "Hemşirelik Tanısını Seçmeden Devam Edemezsiniz."));
        if (this._NursingCare.NursingReasonGrids == null || !this._NursingCare.NursingReasonGrids.Contains(dr => dr.EntityState != EntityStateEnum.Deleted))
            throw new Exception(i18n("M19436", "Neden Seçmeden Devam Edemezsiniz."));
        if (this._NursingCare.NursingCareGrids == null || !this._NursingCare.NursingCareGrids.Contains(dr => dr.EntityState != EntityStateEnum.Deleted))
            throw new Exception(i18n("M15675", "Hemşirelik Girişimi Seçmeden Devam Edemezsiniz."));
        if (this._NursingCare.NursingTargetGrids == null || !this._NursingCare.NursingTargetGrids.Contains(dr => dr.EntityState != EntityStateEnum.Deleted))
            throw new Exception(i18n("M15601", "Hedef Seçmeden Devam Edemezsiniz."));
    }

    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._NursingCare != null && this._NursingCare.ApplicationDate != event) {
                this._NursingCare.ApplicationDate = event;
            }
        }
    }

    public onNoteChanged(event): void {
        if (event != null) {
            if (this._NursingCare != null && this._NursingCare.Note != event) {
                this._NursingCare.Note = event;
            }
        }
    }

    public onNursingProblemChanged(event): void {
        if (event != null) {
            if (this._NursingCare != null && this._NursingCare.NursingProblem != event) {
                this._NursingCare.NursingProblem = event;
            }
        }
    }

    public onNursingResultChanged(event): void {
        if (event != null) {
            if (this._NursingCare != null && this._NursingCare.NursingResult != event) {
                this._NursingCare.NursingResult = event;
            }
        }
    }

    //public onNursingReasonChanged(event): void {
    //    if (event != null) {
    //        if (this._NursingCare != null && this._NursingCare.NursingReason != event) {
    //            this._NursingCare.NursingReason = event;
    //        }
    //    }
    //}

    //public onNursingTargetChanged(event): void {
    //    if (event != null) {
    //        if (this._NursingCare != null && this._NursingCare.NursingTarget != event) {
    //            this._NursingCare.NursingTarget = event;
    //        }
    //    }
    //}

    //public onProcedureObjectChanged(event): void {
    //    if (event != null) {
    //        if (this._NursingCare != null && this._NursingCare.ProcedureObject != event) {
    //            this._NursingCare.ProcedureObject = event;
    //        }
    //    }
    //}



    protected redirectProperties(): void {
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
        redirectProperty(this.NursingResult, "Value", this.__ttObject, "NursingResult");
        redirectProperty(this.Note, "Text", this.__ttObject, "Note");
    }

    public initFormControls(): void {
        this.labelNursingResult = new TTVisual.TTLabel();
        this.labelNursingResult.Text = i18n("M22078", "Sonuç");
        this.labelNursingResult.Name = "labelNursingResult";
        this.labelNursingResult.TabIndex = 19;

        this.NursingResult = new TTVisual.TTEnumComboBox();
        this.NursingResult.DataTypeName = "NursingCareResultEnum";
        this.NursingResult.Name = "NursingResult";
        this.NursingResult.TabIndex = 18;

        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23772", "Uygulama Zamanı");
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 17;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 16;

        //this.labelNursingReason = new TTVisual.TTLabel();
        //this.labelNursingReason.Text = i18n("M15693", "Hemşirelik Neden");
        //this.labelNursingReason.Name = "labelNursingReason";
        //this.labelNursingReason.TabIndex = 13;

        //this.NursingReason = new TTVisual.TTObjectListBox();
        //this.NursingReason.ListDefName = "NursingReasonListDefinition";
        //this.NursingReason.Name = "NursingReason";
        //this.NursingReason.TabIndex = 12;

        //this.labelNursingTarget = new TTVisual.TTLabel();
        //this.labelNursingTarget.Text = i18n("M15683", "Hemşirelik Hedef");
        //this.labelNursingTarget.Name = "labelNursingTarget";
        //this.labelNursingTarget.TabIndex = 11;

        //this.NursingTarget = new TTVisual.TTObjectListBox();
        //this.NursingTarget.ListDefName = "NursingTargetListDefinition";
        //this.NursingTarget.Name = "NursingTarget";
        //this.NursingTarget.TabIndex = 10;

        this.labelNursingProblem = new TTVisual.TTLabel();
        this.labelNursingProblem.Text = i18n("M15699", "Hemşirelik Sorunu");
        this.labelNursingProblem.Name = "labelNursingProblem";
        this.labelNursingProblem.TabIndex = 9;

        this.NursingProblem = new TTVisual.TTObjectListBox();
        this.NursingProblem.ListDefName = "NursingProblemListDefinition";
        this.NursingProblem.Name = "NursingProblem";
        this.NursingProblem.TabIndex = 0;

        //this.labelProcedureObject = new TTVisual.TTLabel();
        //this.labelProcedureObject.Text = i18n("M15674", "Hemşirelik Girişimi");
        //this.labelProcedureObject.Name = "labelProcedureObject";
        //this.labelProcedureObject.TabIndex = 5;

        //this.ProcedureObject = new TTVisual.TTObjectListBox();
        //this.ProcedureObject.ListDefName = "NursingCareListDefinition";
        //this.ProcedureObject.Name = "ProcedureObject";
        //this.ProcedureObject.TabIndex = 1;

        this.labelNote = new TTVisual.TTLabel();
        this.labelNote.Text = i18n("M19476", "Not");
        this.labelNote.Name = "labelNote";
        this.labelNote.TabIndex = 3;

        this.Note = new TTVisual.TTTextBox();
        this.Note.Multiline = true;
        this.Note.Name = "Note";
        this.Note.TabIndex = 3;

        this.Controls = [this.labelNursingResult, this.NursingResult, this.labelApplicationDate, this.ApplicationDate, this.labelNursingProblem, this.NursingProblem, this.labelNote, this.Note]; //this.labelNursingReason, this.NursingReason, this.labelNursingTarget, this.NursingTarget, this.labelProcedureObject, this.ProcedureObject,

    }

    //TestVerisi: Array<any> = [
    //    {
    //        Name: i18n("M10094", "1. Veri"),
    //        Value: '1',
    //        SubItems: [
    //            {
    //                Name: i18n("M10095", "1. Veri 1. Nesne"),
    //                Value: '1_1',
    //                SubItems: [
    //                    {
    //                        Name: i18n("M10096", "1. Veri 1. Nesne 1. Nesne"),
    //                        Value: '1_1_1',
    //                    },
    //                    {
    //                        Name: i18n("M10097", "1. Veri 1. Nesne 2. Nesne"),
    //                        Value: '1_1_2',
    //                    },
    //                    {
    //                        Name: i18n("M10098", "1. Veri 1. Nesne 3. Nesne"),
    //                        Value: '1_1_3',
    //                    }]
    //            },
    //            {
    //                Name: i18n("M10099", "1. Veri 2. Nesne"),
    //                SubItems: [
    //                    {
    //                        Name: i18n("M10100", "1. Veri 2. Nesne 1. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10101", "1. Veri 2. Nesne 2. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10102", "1. Veri 2. Nesne 3. Nesne"),
    //                    }]
    //            },
    //            {
    //                Name: i18n("M10103", "1. Veri 3. Nesne"),
    //                SubItems: [
    //                    {
    //                        Name: i18n("M10104", "1. Veri 3. Nesne 1. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10105", "1. Veri 3. Nesne 2. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10106", "1. Veri 3. Nesne 3. Nesne"),
    //                    }]
    //            }
    //        ]
    //    },
    //    {
    //        Name: i18n("M10205", "2. Veri"),
    //        SubItems: [
    //            {
    //                Name: i18n("M10206", "2. Veri 1. Nesne"),
    //                SubItems: [
    //                    {
    //                        Name: i18n("M10207", "2. Veri 1. Nesne 1. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10208", "2. Veri 1. Nesne 2. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10209", "2. Veri 1. Nesne 3. Nesne"),
    //                    }]
    //            },
    //            {
    //                Name: i18n("M10210", "2. Veri 2. Nesne"),
    //                SubItems: [
    //                    {
    //                        Name: i18n("M10211", "2. Veri 2. Nesne 1. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10212", "2. Veri 2. Nesne 2. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10213", "2. Veri 2. Nesne 3. Nesne"),
    //                    }]
    //            },
    //            {
    //                Name: i18n("M10214", "2. Veri 3. Nesne"),
    //                SubItems: [
    //                    {
    //                        Name: i18n("M10215", "2. Veri 3. Nesne 1. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10216", "2. Veri 3. Nesne 2. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10217", "2. Veri 3. Nesne 3. Nesne"),
    //                    }]
    //            }
    //        ]
    //    },
    //    {
    //        Name: i18n("M10275", "3. Veri"),
    //        SubItems: [
    //            {
    //                Name: i18n("M10276", "3. Veri 1. Nesne"),
    //                SubItems: [
    //                    {
    //                        Name: i18n("M10277", "3. Veri 1. Nesne 1. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10278", "3. Veri 1. Nesne 2. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10279", "3. Veri 1. Nesne 3. Nesne"),
    //                    }]
    //            },
    //            {
    //                Name: i18n("M10280", "3. Veri 2. Nesne"),
    //                SubItems: [
    //                    {
    //                        Name: i18n("M10281", "3. Veri 2. Nesne 1. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10282", "3. Veri 2. Nesne 2. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10283", "3. Veri 2. Nesne 3. Nesne"),
    //                    }]
    //            },
    //            {
    //                Name: i18n("M10284", "3. Veri 3. Nesne"),
    //                SubItems: [
    //                    {
    //                        Name: i18n("M10285", "3. Veri 3. Nesne 1. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10286", "3. Veri 3. Nesne 2. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10287", "3. Veri 3. Nesne 3. Nesne"),
    //                    }]
    //            }
    //        ]
    //    },
    //    {
    //        Name: i18n("M10319", "4. Veri"),
    //        SubItems: [
    //            {
    //                Name: i18n("M10320", "4. Veri 1. Nesne"),
    //                SubItems: [
    //                    {
    //                        Name: i18n("M10321", "4. Veri 1. Nesne 1. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10322", "4. Veri 1. Nesne 2. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10323", "4. Veri 1. Nesne 3. Nesne"),
    //                    }]
    //            },
    //            {
    //                Name: i18n("M10324", "4. Veri 2. Nesne"),
    //                SubItems: [
    //                    {
    //                        Name: i18n("M10325", "4. Veri 2. Nesne 1. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10326", "4. Veri 2. Nesne 2. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10327", "4. Veri 2. Nesne 3. Nesne"),
    //                    }]
    //            },
    //            {
    //                Name: i18n("M10328", "4. Veri 3. Nesne"),
    //                SubItems: [
    //                    {
    //                        Name: i18n("M10285", "3. Veri 3. Nesne 1. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10286", "3. Veri 3. Nesne 2. Nesne"),
    //                    },
    //                    {
    //                        Name: i18n("M10287", "3. Veri 3. Nesne 3. Nesne"),
    //                    }]
    //            }
    //        ]
    //    }];

    PanelConfig: Array<TTMultiSearchPanelConfig> = [
        {
            DisplayMemberPath: 'Name',
            PanelName: 'PanelProblem',
            FilterLabel: i18n("M15701", "Hemşirelik Tanısı"),
            Size: MultiSearchPanelSize.Three,
            SelectedObjects: [],
            selectionMode: "single",
            LinkedObject: this._NursingCare,
            LinkedPropertyName: "NursingProblem",
            RelatedPanelNameToLoad: ""

        },
        {
            DisplayMemberPath: 'Name',
            PanelName: 'PanelReason',
            FilterLabel: i18n("M19430", "Neden"),
            Size: MultiSearchPanelSize.Three,
            SelectedObjects: [],
            selectionMode: "multiple",
            LinkedObject: [],
            LinkedPropertyName: "NursingReason",
            RelatedPanelNameToLoad: "PanelProblem"
        },
        {
            DisplayMemberPath: 'Name',
            PanelName: 'PanelCare',
            FilterLabel: i18n("M15677", "Hemşirelik Girişimleri"),
            Size: MultiSearchPanelSize.Three,
            SelectedObjects: [],
            selectionMode: "multiple",
            LinkedObject: [],
            LinkedPropertyName: "NursingCare",
            RelatedPanelNameToLoad: "PanelProblem"
        }
        ,
        {
            DisplayMemberPath: 'Name',
            PanelName: 'PanelTarget',
            FilterLabel: i18n("M15597", "Hedef"),
            Size: MultiSearchPanelSize.Three,
            SelectedObjects: [],
            selectionMode: "multiple",
            LinkedObject: [],
            LinkedPropertyName: "NursingTarget",
            RelatedPanelNameToLoad: "PanelProblem"
        }
    ];

    changed(data: any) {
        //console.log(data);
        let that = this;

        if (that.nursingCareMainFormViewModel.ReadOnly)//tıklandığı zaman bişey değişmesi
            return false;

        if (data != null) {
            if (data.SelectedObject.length > 0) {
                if (!data.PanelName) {
                    that.SearchPanelDataSources[0] = that.nursingCareMainFormViewModel.NursingProblemDefinitions;
                }
                else if (data.PanelName == 'PanelProblem')// (1. aynı anda 2.,3. ve 4. 'yü tetiklicek)
                {
                    that.httpService.get<any>('/api/NursingCareService/GetNursingDefinitionListsByProblemID?ObjectID=' + data.SelectedObject[0].ObjectID).then(response => {
                        that._NursingCare.NursingProblem = data.SelectedObject[0];
                        let nursingDefListsByProblemID: NursingDefinitionListsByProblemID = response as NursingDefinitionListsByProblemID;

                        that.SearchPanelDataSources[1] = nursingDefListsByProblemID.nursingReasonDefinitionList; //NursingReasonGrids
                        that.SearchPanelDataSources[2] = nursingDefListsByProblemID.nursingCareDefinitionList; //NursingCareGrids
                        that.SearchPanelDataSources[3] = nursingDefListsByProblemID.nursingTargetDefinitionList; //NursingTargetGrids

                    }).catch(error => {
                        this.messageService.showError(error);

                    });
                }

            }

            // Birbirini  tetikleyerek açmak için (1. 2.yi , 2. 3.yü , 3. 4üyü )
            //else if (data.PanelName == 'PanelProblem') {
            //    that.httpService.get<any>('/api/NursingCareService/GetNursingReasonDefinitionByProblemID?ObjectID=' + data.SelectedObject.ObjectID).then(response => {
            //        that.SearchPanelDataSources[1] = response;
            //        that._NursingCare.NursingProblem = data.SelectedObject;

            //        that.SearchPanelDataSources[2] = [];
            //        that.SearchPanelDataSources[3] = [];
            //        that._NursingCare.NursingReason = null;
            //        that._NursingCare.NursingTarget = null;
            //        that._NursingCare.ProcedureObject = null;
            //    }).catch(error => {
            //        this.messageService.showError(error);

            //    });
            //}
            //else if (data.PanelName == 'PanelReason') {
            //    that.httpService.get<any>('/api/NursingCareService/GetNursingCareDefinitionListByProblemID?ObjectID=' + that._NursingCare.NursingProblem.ObjectID).then(response => {
            //        that.SearchPanelDataSources[2] = response;
            //        that._NursingCare.NursingReason = JSON.parse(JSON.stringify(data.SelectedObject));

            //        that.SearchPanelDataSources[3] = [];
            //        that._NursingCare.NursingTarget = null;
            //        that._NursingCare.ProcedureObject = null;
            //    }).catch(error => {
            //        this.messageService.showError(error);

            //    });
            //}
            //else if (data.PanelName == 'PanelProcedure') {
            //    that.httpService.get<any>('/api/NursingCareService/GetNursingTargetDefinitionListByCareID?ObjectID=' + data.SelectedObject.ObjectID).then(response => {
            //        that.SearchPanelDataSources[3] = response;
            //        that._NursingCare.ProcedureObject = data.SelectedObject;

            //        that._NursingCare.NursingTarget = null;
            //    }).catch(error => {
            //        this.messageService.showError(error);
            //    });
            //}
            //else if (data.PanelName == 'PanelTarget') {
            //    //console.log(data.SelectedObject);
            //    that._NursingCare.NursingTarget = data.SelectedObject;
            //}
        }
    }

    //changed(data: any) {
    //    console.log(data);
    //    let that= this;

    //    if (data != null)
    //    {
    //        let asyncLoader: any = {};
    //        if (!data.PanelName) {
    //            //this.deferred = jQuery.Deferred();
    //            asyncLoader.PanelProblem =/* this.deferred.promise();*/Promise.resolve(that.TestVerisi);
    //        }
    //        else if (data.PanelName == 'PanelProblem') {
    //            asyncLoader.PanelReason = Promise.resolve(that.httpService.get('/api/NursingCareService/GetNursingReasonDefinitionByProblemID?ObjectID=' + that._NursingCare.NursingProblem.ObjectID)); //this.getNursingCareDefinitionListByProblemID();//Promise.resolve(data.SelectedObject['SubItems']);
    //            that._NursingCare.NursingProblem = data.SelectedObject;

    //            asyncLoader.PanelProcedure = Promise.resolve([]);
    //            asyncLoader.PanelTarget = Promise.resolve([]);
    //            that._NursingCare.NursingReason = null;
    //            that._NursingCare.NursingTarget = null;
    //            that._NursingCare.ProcedureObject = null;
    //        }
    //        else if (data.PanelName == 'PanelReason') {
    //            asyncLoader.PanelProcedure = Promise.resolve(that.httpService.get('/api/NursingCareService/GetNursingCareDefinitionListByProblemID?ObjectID=' + that._NursingCare.NursingProblem.ObjectID));
    //            that._NursingCare.NursingReason = data.SelectedObject;

    //            asyncLoader.PanelTarget = Promise.resolve([]);
    //            that._NursingCare.NursingTarget = null;
    //            that._NursingCare.ProcedureObject = null;
    //        }
    //        else if (data.PanelName == 'PanelProcedure') {
    //            asyncLoader.PanelTarget = Promise.resolve(that.httpService.get('/api/NursingCareService/GetNursingTargetDefinitionListByCareID?ObjectID=' + data.SelectedObject.ObjectID));
    //            that._NursingCare.ProcedureObject = data.SelectedObject;

    //            that._NursingCare.NursingTarget = null;
    //        }
    //        else if (data.PanelName == 'PanelTarget') {
    //            console.log(data.SelectedObject);
    //            that._NursingCare.NursingTarget = data.SelectedObject;
    //        }
    //        data.DataLoader = asyncLoader;
    //    }
    //}

    public getNursingCareDefinitionListByProblemID() {
        let that = this;

        that.httpService.get<any>("/api/NursingCareService/GetNursingCareDefinitionListByProblemID?ObjectID=" + that._NursingCare.NursingProblem.ObjectID)
            .then(response => {
                that.nursingCareMainFormViewModel.NursingCareDefinitions = response;
                return that.nursingCareMainFormViewModel.NursingCareDefinitions;
            })
            .catch(error => {
                this.messageService.showError(error);

            });
    }
}
