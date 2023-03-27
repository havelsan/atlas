//$153F69A1
import { Component, OnInit, NgZone } from '@angular/core';
import { BaseNursingPatientAndFamilyInstructionFormViewModel } from './BaseNursingPatientAndFamilyInstructionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { BaseNursingPatientAndFamilyInstruction } from 'NebulaClient/Model/AtlasClientModel';
import { NursingPatientAndFamilyInstruction } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from "app/NebulaClient/Mscorlib/GuidParam";

@Component({
    selector: 'BaseNursingPatientAndFamilyInstructionForm',
    templateUrl: './BaseNursingPatientAndFamilyInstructionForm.html',
    providers: [MessageService]
})
export class BaseNursingPatientAndFamilyInstructionForm extends BaseNursingDataEntryForm implements OnInit {
    ApplicationDate: TTVisual.ITTDateTimePicker;
    InstructionNote: TTVisual.ITTTextBox;
    CompanionGetInstructionNursingPatientAndFamilyInstruction: TTVisual.ITTCheckBoxColumn;
    CompanionInstruction: TTVisual.ITTCheckBox;
    labelApplicationDate: TTVisual.ITTLabel;
    NursingPatientAndFamilyInstructions: TTVisual.ITTGrid;
    PatientAndFamilyInstructionNursingPatientAndFamilyInstruction: TTVisual.ITTListBoxColumn;
    PatientGetInstructionNursingPatientAndFamilyInstruction: TTVisual.ITTCheckBoxColumn;
    public NursingPatientAndFamilyInstructionsColumns = [];
    public PatientAndFamilyInstructionsListColumns = [];
    public baseNursingPatientAndFamilyInstructionFormViewModel: BaseNursingPatientAndFamilyInstructionFormViewModel = new BaseNursingPatientAndFamilyInstructionFormViewModel();
    public get _BaseNursingPatientAndFamilyInstruction(): BaseNursingPatientAndFamilyInstruction {
        return this._TTObject as BaseNursingPatientAndFamilyInstruction;
    }
    private BaseNursingPatientAndFamilyInstructionForm_DocumentUrl: string = '/api/BaseNursingPatientAndFamilyInstructionService/BaseNursingPatientAndFamilyInstructionForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone,
                protected reportService: AtlasReportService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseNursingPatientAndFamilyInstructionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BaseNursingPatientAndFamilyInstruction();
        this.baseNursingPatientAndFamilyInstructionFormViewModel = new BaseNursingPatientAndFamilyInstructionFormViewModel();
        this._ViewModel = this.baseNursingPatientAndFamilyInstructionFormViewModel;
        this.baseNursingPatientAndFamilyInstructionFormViewModel._BaseNursingPatientAndFamilyInstruction = this._TTObject as BaseNursingPatientAndFamilyInstruction;
        this.baseNursingPatientAndFamilyInstructionFormViewModel._BaseNursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions = new Array<NursingPatientAndFamilyInstruction>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseNursingPatientAndFamilyInstructionFormViewModel = this._ViewModel as BaseNursingPatientAndFamilyInstructionFormViewModel;
        that._TTObject = this.baseNursingPatientAndFamilyInstructionFormViewModel._BaseNursingPatientAndFamilyInstruction;
        if (this.baseNursingPatientAndFamilyInstructionFormViewModel == null)
            this.baseNursingPatientAndFamilyInstructionFormViewModel = new BaseNursingPatientAndFamilyInstructionFormViewModel();
        if (this.baseNursingPatientAndFamilyInstructionFormViewModel._BaseNursingPatientAndFamilyInstruction == null)
            this.baseNursingPatientAndFamilyInstructionFormViewModel._BaseNursingPatientAndFamilyInstruction = new BaseNursingPatientAndFamilyInstruction();
        that.baseNursingPatientAndFamilyInstructionFormViewModel._BaseNursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions = that.baseNursingPatientAndFamilyInstructionFormViewModel.NursingPatientAndFamilyInstructionsGridList;
        for (let detailItem of that.baseNursingPatientAndFamilyInstructionFormViewModel.NursingPatientAndFamilyInstructionsGridList) {
            let patientAndFamilyInstructionObjectID = detailItem["PatientAndFamilyInstruction"];
            if (patientAndFamilyInstructionObjectID != null && (typeof patientAndFamilyInstructionObjectID === 'string')) {
                let patientAndFamilyInstruction = that.baseNursingPatientAndFamilyInstructionFormViewModel.PatientAndFamilyInstructionDefinitions.find(o => o.ObjectID.toString() === patientAndFamilyInstructionObjectID.toString());
                 if (patientAndFamilyInstruction) {
                    detailItem.PatientAndFamilyInstruction = patientAndFamilyInstruction;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(BaseNursingPatientAndFamilyInstructionFormViewModel);
  
    }


    protected async ClientSidePreScript(): Promise<void> {
        //TODO:ismail isteğin detayına göre açılacak
        //this.ReadOnly = true;
        if (this["NursAppReadOnly"] != null)
            this.baseNursingPatientAndFamilyInstructionFormViewModel.ReadOnly = (this.baseNursingPatientAndFamilyInstructionFormViewModel.ReadOnly || this["NursAppReadOnly"]);

        if (this.baseNursingPatientAndFamilyInstructionFormViewModel.ReadOnly)
            this.DropStateButton(BaseNursingPatientAndFamilyInstruction.BaseNursingDataEntryStates.Cancelled);
        super.ClientSidePreScript();
    }

   public printReport() {
        let a: any = this.baseNursingPatientAndFamilyInstructionFormViewModel._BaseNursingPatientAndFamilyInstruction.NursingApplication;
        let obj: any = this.baseNursingPatientAndFamilyInstructionFormViewModel._BaseNursingPatientAndFamilyInstruction.ObjectID;
        if (a.ObjectID != undefined)
            a = a.ObjectID;
        const TTOBJECTID = new GuidParam(a);
        const OBJECTID = new GuidParam(obj);
        let reportParameters: any = { 'TTOBJECTID': TTOBJECTID, 'OBJECTID': OBJECTID};
        this.reportService.showReport('NursingInstructionAndDischargeReport', reportParameters);
    }
    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._BaseNursingPatientAndFamilyInstruction != null && this._BaseNursingPatientAndFamilyInstruction.ApplicationDate != event) {
                this._BaseNursingPatientAndFamilyInstruction.ApplicationDate = event;
            }
        }
    }

    public onCompanionInstructionChanged(event): void {
        if(this._BaseNursingPatientAndFamilyInstruction != null && this._BaseNursingPatientAndFamilyInstruction.CompanionInstruction != event) { 
        this._BaseNursingPatientAndFamilyInstruction.CompanionInstruction = event;
    }
    }

    public onInstructionNoteChanged(event): void {
        if (event != null) {
            if (this._BaseNursingPatientAndFamilyInstruction != null && this._BaseNursingPatientAndFamilyInstruction.InstructionNote !== event) {
                this._BaseNursingPatientAndFamilyInstruction.InstructionNote = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
        redirectProperty(this.CompanionInstruction, "Value", this.__ttObject, "CompanionInstruction");
        redirectProperty(this.InstructionNote, "Text", this.__ttObject, "InstructionNote");
    }

    public initFormControls(): void {

        this.CompanionInstruction = new TTVisual.TTCheckBox();
        this.CompanionInstruction.Value = false;
        this.CompanionInstruction.Title = "Refakatçi Eğitimi Verildi mi?";
        this.CompanionInstruction.Name = "CompanionInstruction";
        this.CompanionInstruction.TabIndex = 5;

        this.NursingPatientAndFamilyInstructions = new TTVisual.TTGrid();
        this.NursingPatientAndFamilyInstructions.Name = "NursingPatientAndFamilyInstructions";
        this.NursingPatientAndFamilyInstructions.TabIndex = 2;

        this.PatientAndFamilyInstructionNursingPatientAndFamilyInstruction = new TTVisual.TTListBoxColumn();
        this.PatientAndFamilyInstructionNursingPatientAndFamilyInstruction.DataMember = "PatientAndFamilyInstruction";
        this.PatientAndFamilyInstructionNursingPatientAndFamilyInstruction.DisplayIndex = 0;
        this.PatientAndFamilyInstructionNursingPatientAndFamilyInstruction.HeaderText = i18n("M15326", "Hasta ve Aile Eğitimi");
        this.PatientAndFamilyInstructionNursingPatientAndFamilyInstruction.Name = "PatientAndFamilyInstructionNursingPatientAndFamilyInstruction";
        this.PatientAndFamilyInstructionNursingPatientAndFamilyInstruction.Width = 300;

        this.CompanionGetInstructionNursingPatientAndFamilyInstruction = new TTVisual.TTCheckBoxColumn();
        this.CompanionGetInstructionNursingPatientAndFamilyInstruction.DataMember = "CompanionGetInstruction";
        this.CompanionGetInstructionNursingPatientAndFamilyInstruction.DisplayIndex = 1;
        this.CompanionGetInstructionNursingPatientAndFamilyInstruction.HeaderText = i18n("M15331", "Hasta Yakını");
        this.CompanionGetInstructionNursingPatientAndFamilyInstruction.Name = "CompanionGetInstructionNursingPatientAndFamilyInstruction";
        this.CompanionGetInstructionNursingPatientAndFamilyInstruction.Width = 80;

        this.PatientGetInstructionNursingPatientAndFamilyInstruction = new TTVisual.TTCheckBoxColumn();
        this.PatientGetInstructionNursingPatientAndFamilyInstruction.DataMember = "PatientGetInstruction";
        this.PatientGetInstructionNursingPatientAndFamilyInstruction.DisplayIndex = 2;
        this.PatientGetInstructionNursingPatientAndFamilyInstruction.HeaderText = i18n("M15125", "Hasta");
        this.PatientGetInstructionNursingPatientAndFamilyInstruction.Name = "PatientGetInstructionNursingPatientAndFamilyInstruction";
        this.PatientGetInstructionNursingPatientAndFamilyInstruction.Width = 80;

        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23772", "Uygulama Zamanı");
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 1;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 0;

        this.InstructionNote = new TTVisual.TTTextBox();
        this.InstructionNote.Multiline = true;
        this.InstructionNote.Height="75px";
        // this.InstructionNote.BackColor = '#FFE3C6';
        this.InstructionNote.Name = 'InstructionNote';
        this.InstructionNote.TabIndex = 0;

        this.NursingPatientAndFamilyInstructionsColumns = [this.PatientAndFamilyInstructionNursingPatientAndFamilyInstruction, this.CompanionGetInstructionNursingPatientAndFamilyInstruction, this.PatientGetInstructionNursingPatientAndFamilyInstruction];

        this.PatientAndFamilyInstructionsListColumns = [
            { caption: i18n("M14447", "Fonksiyon"), dataField: 'PatientAndFamilyInstruction.Name', fixed: true, width: '40%', allowEditing: false },
            { caption: i18n("M15190", "Hasta Eğitimi"), dataField: 'PatientGetInstruction', dataType: 'boolean', fixed: true, width: '80px', allowEditing: true, cellTemplate: "chkTemplate" },
            { caption: i18n("M24246", "Yakını Eğitimi"), dataField: 'CompanionGetInstruction', fixed: true, width: '80px', allowEditing: true, cellTemplate: "chkTemplate" }

        ];
        this.Controls = [this.CompanionInstruction,this.InstructionNote,this.NursingPatientAndFamilyInstructions, this.PatientAndFamilyInstructionNursingPatientAndFamilyInstruction, this.CompanionGetInstructionNursingPatientAndFamilyInstruction, this.PatientGetInstructionNursingPatientAndFamilyInstruction, this.labelApplicationDate, this.ApplicationDate];

    }

    getCellData(cellData: any) {
        return Util.ResolveProperty(cellData.column.dataField, cellData.data);
    }

    setCellData(cellData: any, $event: any) {
        Util.SetPropertyValue(cellData.column.dataField, cellData.data, $event);
    }


}
