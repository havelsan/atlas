//$56B97B67
import { Component, OnInit } from '@angular/core';
import { DoctorQuotaDefFormViewModel } from './DoctorQuotaDefFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DoctorQuotaDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResPoliclinic } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { DateTimePickerFormat } from 'app/NebulaClient/Utils/Enums/DateTimePickerFormat';

@Component({
    selector: 'DoctorQuotaDefForm',
    templateUrl: './DoctorQuotaDefForm.html',
    providers: [MessageService]
})
export class DoctorQuotaDefForm extends TTVisual.TTForm implements OnInit {
    AutomaticReception: TTVisual.ITTCheckBox;
    Active: TTVisual.ITTCheckBox;
    labelPoliclinic: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelResultEndtTime: TTVisual.ITTLabel;
    labelResultStartTime: TTVisual.ITTLabel;
    labelWorkDate: TTVisual.ITTLabel;
    lblQuota: TTVisual.ITTLabel;
    Policlinic: TTVisual.ITTObjectListBox;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ResultEndtTime: TTVisual.ITTDateTimePicker;
    ResultStartTime: TTVisual.ITTDateTimePicker;
    txtQuota: TTVisual.ITTTextBox;
    txtResultQuota: TTVisual.ITTTextBox;

    GridDataSource: any;

    public doctorQuotaDefFormViewModel: DoctorQuotaDefFormViewModel = new DoctorQuotaDefFormViewModel();
    public get _DoctorQuotaDefinition(): DoctorQuotaDefinition {
        return this._TTObject as DoctorQuotaDefinition;
    }
    private DoctorQuotaDefForm_DocumentUrl: string = '/api/DoctorQuotaDefinitionService/DoctorQuotaDefForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('DOCTORQUOTADEFINITION', 'DoctorQuotaDefForm');
        this._DocumentServiceUrl = this.DoctorQuotaDefForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DoctorQuotaDefinition();
        this.doctorQuotaDefFormViewModel = new DoctorQuotaDefFormViewModel();
        this._ViewModel = this.doctorQuotaDefFormViewModel;
        this.doctorQuotaDefFormViewModel._DoctorQuotaDefinition = this._TTObject as DoctorQuotaDefinition;
        this.doctorQuotaDefFormViewModel._DoctorQuotaDefinition.Policlinic = new ResPoliclinic();
        this.doctorQuotaDefFormViewModel._DoctorQuotaDefinition.ProcedureDoctor = new ResUser();

    }

    protected loadViewModel() {
        let that = this;
        that.doctorQuotaDefFormViewModel = this._ViewModel as DoctorQuotaDefFormViewModel;
        that._TTObject = this.doctorQuotaDefFormViewModel._DoctorQuotaDefinition;
        if (this.doctorQuotaDefFormViewModel == null)
            this.doctorQuotaDefFormViewModel = new DoctorQuotaDefFormViewModel();
        if (this.doctorQuotaDefFormViewModel._DoctorQuotaDefinition == null)
            this.doctorQuotaDefFormViewModel._DoctorQuotaDefinition = new DoctorQuotaDefinition();
        let policlinicObjectID = that.doctorQuotaDefFormViewModel._DoctorQuotaDefinition["Policlinic"];
        if (policlinicObjectID != null && (typeof policlinicObjectID === "string")) {
            let policlinic = that.doctorQuotaDefFormViewModel.ResPoliclinics.find(o => o.ObjectID.toString() === policlinicObjectID.toString());
            if (policlinic) {
                that.doctorQuotaDefFormViewModel._DoctorQuotaDefinition.Policlinic = policlinic;
            }
        }
        let procedureDoctorObjectID = that.doctorQuotaDefFormViewModel._DoctorQuotaDefinition["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.doctorQuotaDefFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.doctorQuotaDefFormViewModel._DoctorQuotaDefinition.ProcedureDoctor = procedureDoctor;
            }
        }

    }


    RowRemoving(data) {
        let that = this;
        let apiUrl: string = '/api/DoctorQuotaDefinitionService/DeleteSelectedDoctorQuota?id=' + data.key.ObjectID.toString();
        this.httpService.get<any>(apiUrl).then(
            x => {
                that.GetGridDataSource();

                this.load();
                this.PreScript();
            });
    }
    public async save() {
        await super.save();
        this.GetGridDataSource();

        await this.load();
        await this.PreScript();
    }

    select(data) {
        let that = this;
        let apiUrl: string = '/api/DoctorQuotaDefinitionService/DoctorQuotaDefForm?id=' + data.selectedRowKeys[0].ObjectID.toString();
        this.httpService.get<any>(apiUrl).then(
            x => {
                this._ViewModel = x;
                that.loadViewModel();
            });
    }

    public DoctorQuotaColumns = [
        {
            'caption': 'Birim',
            dataField: 'Policlinic',
            allowEditing: false
        },
        {
            'caption': 'Doktor',
            dataField: 'Proceduredoctor',
            allowEditing: false
        },
        {
            'caption': 'Kota',
            dataField: 'Quota',
            allowEditing: true
        },    
        {
            'caption': 'Sonuç Kota',
            dataField: 'ResultQuota',
            allowEditing: true
        },
        {
            'caption': 'Sonuç Başlama',
            dataField: 'ResultStartTime',
            dataType: 'date',
            format: 'HH:mm',
            allowEditing: true
        },
        {
            'caption': 'Sonuç Bitiş',
            dataField: 'ResultEndtTime',
            dataType: 'date',
            format: 'HH:mm',
            allowEditing: true
        },
        {
            'caption': 'Aktif',
            dataField: 'Active',
            allowEditing: true
        },
        {
            'caption': 'Otomatik Kabul',
            dataField: 'AutomaticReception',
            allowEditing: true
        }
    ];

    async ngOnInit() {
        await this.load();
        await this.PreScript();
        await this.GetGridDataSource();
    }

    protected async PreScript() {
        super.PreScript();

        if (this.doctorQuotaDefFormViewModel.isPersonnelDoctor === true)//Giri� yapan kullan�c� doktor ise komboda kendi se�ili gelmeli ve m�dahale edememeli
        {
            this.ProcedureDoctor.Enabled = false;

            this.Policlinic.ListFilterExpression = " THIS.OBJECTID IN ('" + this.doctorQuotaDefFormViewModel.PoliclinicObjectIDs + "')";
        }
        else
        {
            this.ProcedureDoctor.Enabled = true;
        }
    }

    async GetGridDataSource() {
        let apiUrl: string = '/api/DoctorQuotaDefinitionService/GetGridDataSource';
        this.httpService.post<any>(apiUrl, null).then(
            x => {
                this.GridDataSource = x;
            });
    }

    public onAutomaticReceptionChanged(event): void {
        if(this._DoctorQuotaDefinition != null && this._DoctorQuotaDefinition.AutomaticReception != event) { 
        this._DoctorQuotaDefinition.AutomaticReception = event;
    }
    }

    public onActiveChanged(event): void {
        if (event != null) {
            if (this._DoctorQuotaDefinition != null && this._DoctorQuotaDefinition.Active != event) {
                this._DoctorQuotaDefinition.Active = event;
            }
        }
    }

    public onPoliclinicChanged(event): void {
        if (event != null) {
            if (this._DoctorQuotaDefinition != null && this._DoctorQuotaDefinition.Policlinic != event) {
                this._DoctorQuotaDefinition.Policlinic = event;
            }

            if (this._DoctorQuotaDefinition.ProcedureDoctor == null || this.doctorQuotaDefFormViewModel.isPersonnelDoctor != true)
                this.ProcedureDoctor.ListFilterExpression = " USERRESOURCES.RESOURCE = '" + event.ObjectID.toString() + "'";
        }
    }

    public async onProcedureDoctorChanged(event) {
        if (event != null) {
            if (this._DoctorQuotaDefinition != null && this._DoctorQuotaDefinition.ProcedureDoctor != event) {
                this._DoctorQuotaDefinition.ProcedureDoctor = event;
            }

            try {

                let that = this;
                let body = JSON.stringify(event);
                let apiUrlForPASearchUrl: string = '/api/PatientAdmissionService/PolyclinicAndBranchByProcedureDoctor';
                let httpService: NeHttpService = ServiceLocator.NeHttpService;
                let result = await httpService.post(apiUrlForPASearchUrl, event, ResUser);

                this.loadPoliclinic(result);
            }
            catch (ex) {
                TTVisual.InfoBox.Show(ex);
            }

        }
    }

    public loadPoliclinic(result: any)
    {
        let polyclinicObjectIDs = "";
        for (let PolyclinicDoctorBranchGroupModel of result) {
            let polyclinic = PolyclinicDoctorBranchGroupModel["PolyclinicObject"];
            if (polyclinic == null || polyclinic == undefined) {

            }
            else if (this._DoctorQuotaDefinition.Policlinic == null || this._DoctorQuotaDefinition.Policlinic.ObjectID != polyclinic.ObjectID) {
                if (result.length == 1) {
                    this._DoctorQuotaDefinition.Policlinic = polyclinic;
                }
                if (polyclinicObjectIDs != "")
                    polyclinicObjectIDs += "','";
                polyclinicObjectIDs += polyclinic.ObjectID;

            }

        }
        this.Policlinic.ListFilterExpression = " THIS.OBJECTID IN ('" + polyclinicObjectIDs.toString() + "')";
        // this.ProcedureDoctor.ListFilterExpression = " USERRESOURCES.RESOURCE IN ('" + polyclinicObjectIDs.toString() + "')";
    }

    public onResultEndtTimeChanged(event): void {
        if (this._DoctorQuotaDefinition != null && this._DoctorQuotaDefinition.ResultEndtTime != event) {
            this._DoctorQuotaDefinition.ResultEndtTime = event;
        }
    }

    public onResultStartTimeChanged(event): void {
        if (this._DoctorQuotaDefinition != null && this._DoctorQuotaDefinition.ResultStartTime != event) {
            this._DoctorQuotaDefinition.ResultStartTime = event;
        }
    }

    public ahmet()
    {
        this.doctorQuotaDefFormViewModel = new DoctorQuotaDefFormViewModel();
        this._DoctorQuotaDefinition.ProcedureDoctor = new ResUser();
        this._DoctorQuotaDefinition.Policlinic = new ResPoliclinic();
        this.Policlinic.ListFilterExpression = " ";
        this.ProcedureDoctor.ListFilterExpression = " ";
        // this.PreScript();
        // this.loadPoliclinic();
        // this.initViewModel();
        this.ngOnInit();

    }
    public ontxtQuotaChanged(event): void {
        if (event != null) {
            if (this._DoctorQuotaDefinition != null && this._DoctorQuotaDefinition.Quota != event) {
                this._DoctorQuotaDefinition.Quota = event;
            }
        }
    }

    public ontxtResultQuotaChanged(event): void {
        if (event != null) {
            if (this._DoctorQuotaDefinition != null && this._DoctorQuotaDefinition.ResultQuota != event) {
                this._DoctorQuotaDefinition.ResultQuota = event;
            }
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.txtQuota, "Text", this.__ttObject, "Quota");
        redirectProperty(this.txtResultQuota, "Text", this.__ttObject, "ResultQuota");
        redirectProperty(this.Active, "Value", this.__ttObject, "Active");
        redirectProperty(this.AutomaticReception, "Value", this.__ttObject, "AutomaticReception");
	    redirectProperty(this.ResultStartTime, "Value", this.__ttObject, "ResultStartTime");
	    redirectProperty(this.ResultEndtTime, "Value", this.__ttObject, "ResultEndtTime");
    }

    public initFormControls(): void {
    this.labelResultEndtTime = new TTVisual.TTLabel();
    this.labelResultEndtTime.Text = "Sonuç Sıra Bitiş Saati";
    this.labelResultEndtTime.Name = "labelResultEndtTime";
    this.labelResultEndtTime.TabIndex = 13;

    this.ResultEndtTime = new TTVisual.TTDateTimePicker();
    this.ResultEndtTime.Format = DateTimePickerFormat.Time;
    this.ResultEndtTime.Name = "ResultEndtTime";
    this.ResultEndtTime.TabIndex = 12;

    this.labelResultStartTime = new TTVisual.TTLabel();
    this.labelResultStartTime.Text = "Sonuç Sıra Başlama Saati";
    this.labelResultStartTime.Name = "labelResultStartTime";
    this.labelResultStartTime.TabIndex = 11;

    this.ResultStartTime = new TTVisual.TTDateTimePicker();
    this.ResultStartTime.Format = DateTimePickerFormat.Time;
    this.ResultStartTime.Name = "ResultStartTime";
    this.ResultStartTime.TabIndex = 10;
        
    this.AutomaticReception = new TTVisual.TTCheckBox();
        this.AutomaticReception.Value = false;
        this.AutomaticReception.Text = "Otomatik Kabul Al";
        this.AutomaticReception.Name = "AutomaticReception";
        this.AutomaticReception.TabIndex = 9;

        this.lblQuota = new TTVisual.TTLabel();
        this.lblQuota.Text = "Kota";
        this.lblQuota.Name = "lblQuota";
        this.lblQuota.TabIndex = 8;

        this.txtQuota = new TTVisual.TTTextBox();
        this.txtQuota.Name = "txtQuota";
        this.txtQuota.TabIndex = 7;

        this.txtResultQuota = new TTVisual.TTTextBox();
        this.txtResultQuota.Name = "txtResultQuota";
        this.txtResultQuota.TabIndex = 7;

        this.Active = new TTVisual.TTCheckBox();
        this.Active.Value = true;
        this.Active.Text = "Aktif";
        this.Active.Name = "Active";
        this.Active.TabIndex = 6;

        this.labelPoliclinic = new TTVisual.TTLabel();
        this.labelPoliclinic.Text = "Poliklinik";
        this.labelPoliclinic.Name = "labelPoliclinic";
        this.labelPoliclinic.TabIndex = 5;

        this.Policlinic = new TTVisual.TTObjectListBox();
        this.Policlinic.Required = true;
        this.Policlinic.ListDefName = "PoliclinicsListDefinition";
        this.Policlinic.Name = "Policlinic";
        this.Policlinic.TabIndex = 4;
        this.Policlinic.PopupDialogWidth=200;
        this.Policlinic.AutoCompleteDialogWidth = "400px";

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = "Doktor";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 3;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.Required = true;
        this.ProcedureDoctor.ListDefName = "SpecialistDoctorListDefinitionForPA";
        this.ProcedureDoctor.Name = "Resource";
        this.ProcedureDoctor.TabIndex = 2;
        this.ProcedureDoctor.AutoCompleteDialogWidth = "400px"

        this.Controls = [this.labelResultEndtTime, this.ResultEndtTime, this.labelResultStartTime, this.ResultStartTime,this.AutomaticReception,this.lblQuota, this.txtQuota, this.txtResultQuota,this.Active, this.labelPoliclinic, this.Policlinic, this.labelProcedureDoctor, this.ProcedureDoctor];

    }


}
