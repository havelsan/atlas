//$87150347
import { Component, OnInit, NgZone } from '@angular/core';
import { BaseNursingDischargingInstructionPlanFormViewModel } from './BaseNursingDischargingInstructionPlanFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { BaseNursingDischargingInstructionPlan } from 'NebulaClient/Model/AtlasClientModel';
import { NursingDischargingInstructionPlan } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from "app/NebulaClient/Mscorlib/GuidParam";
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';

@Component({
    selector: 'BaseNursingDischargingInstructionPlanForm',
    templateUrl: './BaseNursingDischargingInstructionPlanForm.html',
    providers: [MessageService]
})
export class BaseNursingDischargingInstructionPlanForm extends BaseNursingDataEntryForm implements OnInit {
    ApplicationDate: TTVisual.ITTDateTimePicker;
    DischargingInstructionPlanNursingDischargingInstructionPlan: TTVisual.ITTListBoxColumn;
    labelApplicationDate: TTVisual.ITTLabel;
    NursingDischargingInstructionPlans: TTVisual.ITTGrid;
    PatientGetInstructionNursingDischargingInstructionPlan: TTVisual.ITTCheckBoxColumn;
    public NursingDischargingInstructionPlansColumns = [];
    public baseNursingDischargingInstructionPlanFormViewModel: BaseNursingDischargingInstructionPlanFormViewModel = new BaseNursingDischargingInstructionPlanFormViewModel();
    public get _BaseNursingDischargingInstructionPlan(): BaseNursingDischargingInstructionPlan {
        return this._TTObject as BaseNursingDischargingInstructionPlan;
    }
    private BaseNursingDischargingInstructionPlanForm_DocumentUrl: string = '/api/BaseNursingDischargingInstructionPlanService/BaseNursingDischargingInstructionPlanForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone,
                protected reportService: AtlasReportService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseNursingDischargingInstructionPlanForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BaseNursingDischargingInstructionPlan();
        this.baseNursingDischargingInstructionPlanFormViewModel = new BaseNursingDischargingInstructionPlanFormViewModel();
        this._ViewModel = this.baseNursingDischargingInstructionPlanFormViewModel;
        this.baseNursingDischargingInstructionPlanFormViewModel._BaseNursingDischargingInstructionPlan = this._TTObject as BaseNursingDischargingInstructionPlan;
        this.baseNursingDischargingInstructionPlanFormViewModel._BaseNursingDischargingInstructionPlan.NursingDischargingInstructionPlans = new Array<NursingDischargingInstructionPlan>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseNursingDischargingInstructionPlanFormViewModel = this._ViewModel as BaseNursingDischargingInstructionPlanFormViewModel;
        that._TTObject = this.baseNursingDischargingInstructionPlanFormViewModel._BaseNursingDischargingInstructionPlan;
        if (this.baseNursingDischargingInstructionPlanFormViewModel == null)
            this.baseNursingDischargingInstructionPlanFormViewModel = new BaseNursingDischargingInstructionPlanFormViewModel();
        if (this.baseNursingDischargingInstructionPlanFormViewModel._BaseNursingDischargingInstructionPlan == null)
            this.baseNursingDischargingInstructionPlanFormViewModel._BaseNursingDischargingInstructionPlan = new BaseNursingDischargingInstructionPlan();
        that.baseNursingDischargingInstructionPlanFormViewModel._BaseNursingDischargingInstructionPlan.NursingDischargingInstructionPlans = that.baseNursingDischargingInstructionPlanFormViewModel.NursingDischargingInstructionPlansGridList;
        for (let detailItem of that.baseNursingDischargingInstructionPlanFormViewModel.NursingDischargingInstructionPlansGridList) {
            let dischargingInstructionPlanObjectID = detailItem["DischargingInstructionPlan"];
            if (dischargingInstructionPlanObjectID != null && (typeof dischargingInstructionPlanObjectID === 'string')) {
                let dischargingInstructionPlan = that.baseNursingDischargingInstructionPlanFormViewModel.DischargingInstructionPlanDefinitions.find(o => o.ObjectID.toString() === dischargingInstructionPlanObjectID.toString());
                 if (dischargingInstructionPlan) {
                    detailItem.DischargingInstructionPlan = dischargingInstructionPlan;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(BaseNursingDischargingInstructionPlanFormViewModel);
  
    }


    protected async ClientSidePreScript(): Promise<void> {
        //TODO:ismail isteğin detayına göre açılacak
        //this.ReadOnly = true;
        if (this["NursAppReadOnly"] != null)
            this.baseNursingDischargingInstructionPlanFormViewModel.ReadOnly = (this.baseNursingDischargingInstructionPlanFormViewModel.ReadOnly || this["NursAppReadOnly"]);

        if (this.baseNursingDischargingInstructionPlanFormViewModel.ReadOnly || this._BaseNursingDischargingInstructionPlan.IsNew)
            this.DropStateButton(BaseNursingDischargingInstructionPlan.BaseNursingDataEntryStates.Cancelled);
        super.ClientSidePreScript();
    }

    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._BaseNursingDischargingInstructionPlan != null && this._BaseNursingDischargingInstructionPlan.ApplicationDate != event) {
                this._BaseNursingDischargingInstructionPlan.ApplicationDate = event;
            }
        }
    }

    public printReport() {
        let a: any = this.baseNursingDischargingInstructionPlanFormViewModel._BaseNursingDischargingInstructionPlan.NursingApplication;
        if(a != null ){
            if (a.ObjectID != undefined)
            a = a.ObjectID;
        const TTOBJECTID = new GuidParam(a);
        let reportParameters: any = { 'TTOBJECTID': TTOBJECTID, 'OBJECTID': new GuidParam(Guid.Empty) };
        this.reportService.showReport('NursingInstructionAndDischargeReport', reportParameters);
        }       
    }

    
    public async saveForm(saveInfo: FormSaveInfo) {
        if(this.baseNursingDischargingInstructionPlanFormViewModel.ReportCountControl == true){
            ServiceLocator.MessageService.showError("Hasta üzerinde kayıtlı bir Taburculuk Planlama bulunmaktadır.");
            return;
        }
        await super.saveForm(saveInfo);
    }

    protected redirectProperties(): void {
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
    }

    public initFormControls(): void {
        this.NursingDischargingInstructionPlans = new TTVisual.TTGrid();
        this.NursingDischargingInstructionPlans.Name = "NursingDischargingInstructionPlans";
        this.NursingDischargingInstructionPlans.TabIndex = 2;

        this.DischargingInstructionPlanNursingDischargingInstructionPlan = new TTVisual.TTListBoxColumn();
        this.DischargingInstructionPlanNursingDischargingInstructionPlan.ListDefName = "DischargingInstructionPlanListDefinition";
        this.DischargingInstructionPlanNursingDischargingInstructionPlan.DataMember = "DischargingInstructionPlan";
        this.DischargingInstructionPlanNursingDischargingInstructionPlan.DisplayIndex = 0;
        this.DischargingInstructionPlanNursingDischargingInstructionPlan.HeaderText = i18n("M22575", "Taburculuk Eğitim Planı");
        this.DischargingInstructionPlanNursingDischargingInstructionPlan.Name = "DischargingInstructionPlanNursingDischargingInstructionPlan";
        this.DischargingInstructionPlanNursingDischargingInstructionPlan.Width = 300;

        this.PatientGetInstructionNursingDischargingInstructionPlan = new TTVisual.TTCheckBoxColumn();
        this.PatientGetInstructionNursingDischargingInstructionPlan.DataMember = "PatientGetInstruction";
        this.PatientGetInstructionNursingDischargingInstructionPlan.DisplayIndex = 1;
        this.PatientGetInstructionNursingDischargingInstructionPlan.HeaderText = "";
        this.PatientGetInstructionNursingDischargingInstructionPlan.Name = "PatientGetInstructionNursingDischargingInstructionPlan";
        this.PatientGetInstructionNursingDischargingInstructionPlan.Width = 80;

        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23772", "Uygulama Zamanı");
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 1;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 0;

        this.NursingDischargingInstructionPlansColumns = [this.DischargingInstructionPlanNursingDischargingInstructionPlan, this.PatientGetInstructionNursingDischargingInstructionPlan];
        this.Controls = [this.NursingDischargingInstructionPlans, this.DischargingInstructionPlanNursingDischargingInstructionPlan, this.PatientGetInstructionNursingDischargingInstructionPlan, this.labelApplicationDate, this.ApplicationDate];

    }


}
