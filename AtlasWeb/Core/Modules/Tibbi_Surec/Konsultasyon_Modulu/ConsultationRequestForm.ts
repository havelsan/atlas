//$D6991E73
import { Component, OnInit, NgZone  } from '@angular/core';
import { ConsultationRequestFormViewModel } from './ConsultationRequestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Consultation } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { PatientStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ConsultationRequestParametersModel } from 'app/Fw/Models/ParameterDefinitionModel';

@Component({
    selector: 'ConsultationRequestForm',
    templateUrl: './ConsultationRequestForm.html',
    providers: [MessageService]
})
export class ConsultationRequestForm extends EpisodeActionForm implements OnInit {
    Emergency: TTVisual.ITTCheckBox;
    EPISODEID: TTVisual.ITTTextBox;
    InPatientBed: TTVisual.ITTCheckBox;
    labelActionDate: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labelRequesterDepatment: TTVisual.ITTLabel;
    lblProcedureDoctor: TTVisual.ITTLabel;
    MasterResource: TTVisual.ITTObjectListBox;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ProtocolNo: TTVisual.ITTTextBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    RequestedDoctor: TTVisual.ITTObjectListBox;
    RequesterDepatment: TTVisual.ITTObjectListBox;
    rtfRequestDescription: TTVisual.ITTRichTextBoxControl;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;


    public consultationRequestFormViewModel: ConsultationRequestFormViewModel = new ConsultationRequestFormViewModel();
    public get _Consultation(): Consultation {
        return this._TTObject as Consultation;
    }
    private ConsultationRequestForm_DocumentUrl: string = '/api/ConsultationService/ConsultationRequestForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone, 
        protected activeUserService: IActiveUserService,
        protected objectContextService: ObjectContextService) {

        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ConsultationRequestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    consultationRequestParametersModel: ConsultationRequestParametersModel; 

    // ***** Method declarations start *****
    public setInputParam(value: ConsultationRequestParametersModel) {
        if (value != null) {
            this.consultationRequestParametersModel = new ConsultationRequestParametersModel(value.episodeId,value.resource,value.resourceList,value.consultation,value.masterAction);
            this.consultationRequestFormViewModel._Consultation = value.consultation;
        }
    }

    protected async PreScript(): Promise<void> {
        let Doctor: Guid = new Guid('9431A69C-1A2A-4DCF-B1D3-6B1368318F89');
        let Dietician: Guid = new Guid('0a5a3824-d3fa-4400-a3c1-c2a8906726a5');
        let Psychologist: Guid = new Guid('fa55ee1d-3048-453d-b46d-64ea35953e50');
        super.PreScript();
        if (this.consultationRequestParametersModel != null) {
            let found: Boolean = false;
            if(this.consultationRequestParametersModel.resource){
                this._Consultation.MasterResource = this.consultationRequestParametersModel.resource;
                found = true;
            }
            if (this.consultationRequestParametersModel.resourceList) {
                let masterResourceListFilter: string = "";
                for (let item of this.consultationRequestParametersModel.resourceList) {
                    masterResourceListFilter = masterResourceListFilter + "'" + item.toString() + "',";
                }
                if (masterResourceListFilter != "") {
                    this.MasterResource.ListFilterExpression = "OBJECTID IN (" + masterResourceListFilter.substring(0, masterResourceListFilter.length - 1) + ")";
                }
                found = true;
            }
            if (found == true)
            {
            }
        }


        if (this.RequestedDoctor.SelectedObject !== null)
            this.RequestedDoctor.ReadOnly = true;
        else this.RequestedDoctor.ReadOnly = false;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Consultation();
        this.consultationRequestFormViewModel = new ConsultationRequestFormViewModel();
        this._ViewModel = this.consultationRequestFormViewModel;
        this.consultationRequestFormViewModel._Consultation = this._TTObject as Consultation;
        this.consultationRequestFormViewModel._Consultation.RequesterDoctor = new ResUser();
        this.consultationRequestFormViewModel._Consultation.ProcedureDoctor = new ResUser();
        this.consultationRequestFormViewModel._Consultation.MasterResource = new ResSection();
        this.consultationRequestFormViewModel._Consultation.RequesterResource = new ResSection();
        this.consultationRequestFormViewModel._Consultation.Episode = new Episode();
    }

    protected async loadViewModel() {
        let that = this;
        that.consultationRequestFormViewModel = this._ViewModel as ConsultationRequestFormViewModel;
        that._TTObject = this.consultationRequestFormViewModel._Consultation;
        if (this.consultationRequestFormViewModel == null)
            this.consultationRequestFormViewModel = new ConsultationRequestFormViewModel();
        if (this.consultationRequestFormViewModel._Consultation == null)
            this.consultationRequestFormViewModel._Consultation = new Consultation();


        let episodeObjectID = that.consultationRequestParametersModel.episodeId;
        //let episodeObjectID = that.consultationRequestFormViewModel._Consultation["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.consultationRequestFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.consultationRequestFormViewModel._Consultation.Episode = episode;
            }
        }

        //let requesterDoctorObjectID = that.consultationRequestFormViewModel._Consultation["RequesterDoctor"];
        //if (requesterDoctorObjectID != null && (typeof requesterDoctorObjectID === "string")) {
        //    let requesterDoctor = that.consultationRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requesterDoctorObjectID.toString());
        //    that.consultationRequestFormViewModel._Consultation.RequesterDoctor = requesterDoctor;
        //}
        let currentUserObjectID = that.activeUserService.ActiveUser.UserObject.ObjectID;
        if (currentUserObjectID != null) {
            let currentUser: ResUser = await this.objectContextService.getObject<ResUser>(currentUserObjectID, ResUser.ObjectDefID);
            that.consultationRequestFormViewModel._Consultation.RequesterDoctor = currentUser;
        }

        //let requesterResourceObjectID = that.consultationRequestFormViewModel._Consultation["RequesterResource"];
        //if (requesterResourceObjectID != null && (typeof requesterResourceObjectID === "string")) {
        //    let requesterResource = that.consultationRequestFormViewModel.ResSections.find(o => o.ObjectID.toString() === requesterResourceObjectID.toString());
        //    that.consultationRequestFormViewModel._Consultation.RequesterResource = requesterResource;
        //}

        let requesterResourceObjectID: Guid;
        if (that.consultationRequestFormViewModel._Consultation.Episode.PatientStatus == PatientStatusEnum.Outpatient)
           requesterResourceObjectID = that.activeUserService.SelectedOutPatientResource.ObjectID;
        else
           requesterResourceObjectID = that.activeUserService.SelectedInPatientResource.ObjectID;

        if (requesterResourceObjectID != null) {
            let requesterResource: ResSection = await this.objectContextService.getObject<ResSection>(requesterResourceObjectID, ResSection.ObjectDefID);
            that.consultationRequestFormViewModel._Consultation.RequesterResource = requesterResource;
        }

        let procedureDoctorObjectID = that.consultationRequestFormViewModel._Consultation["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.consultationRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.consultationRequestFormViewModel._Consultation.ProcedureDoctor = procedureDoctor;
            }
        }

    }

    async ngOnInit() {
        await this.load();
    }

    public onEmergencyChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.Emergency != event) {
                this._Consultation.Emergency = event;
            }
        }
    }

    public onEPISODEIDChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null && this._Consultation.Episode.ID != event) {
                this._Consultation.Episode.ID = event;
            }
        }
    }

    public onInPatientBedChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.InPatientBed != event) {
                this._Consultation.InPatientBed = event;
            }
        }
    }

    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.MasterResource != event) {
                this._Consultation.MasterResource = event;
            }
        }
    }

    public onProcedureDoctorChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.ProcedureDoctor != event) {
                this._Consultation.ProcedureDoctor = event;
            }
        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.ProtocolNo != event) {
                this._Consultation.ProtocolNo = event;
            }
        }
    }

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.RequestDate != event) {
                this._Consultation.RequestDate = event;
            }
        }
    }

    public onRequestedDoctorChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.RequesterDoctor != event) {
                this._Consultation.RequesterDoctor = event;
            }
        }
    }

    public onRequesterDepatmentChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.RequesterResource != event) {
                this._Consultation.RequesterResource = event;
            }
        }
    }

    public onrtfRequestDescriptionChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.RequestDescription != event) {
                this._Consultation.RequestDescription = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.rtfRequestDescription, "Rtf", this.__ttObject, "RequestDescription");
        redirectProperty(this.EPISODEID, "Text", this.__ttObject, "Episode.ID");
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.Emergency, "Value", this.__ttObject, "Emergency");
        redirectProperty(this.InPatientBed, "Value", this.__ttObject, "InPatientBed");
    }

    public initFormControls(): void {
        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M16656", "İstek Yapan");
        this.ttlabel8.BackColor = "#DCDCDC";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 49;

        this.RequestedDoctor = new TTVisual.TTObjectListBox();
        this.RequestedDoctor.ListDefName = "ConsultationRequesterUserList";
        this.RequestedDoctor.Name = "RequestedDoctor";
        this.RequestedDoctor.TabIndex = 5;

        this.rtfRequestDescription = new TTVisual.TTRichTextBoxControl();
        this.rtfRequestDescription.DisplayText = i18n("M16609", "İstek Açıklaması");
        this.rtfRequestDescription.TemplateGroupName = i18n("M17755", "Konsültasyon İstek Açıklaması");
        this.rtfRequestDescription.BackColor = "#DCDCDC";
        this.rtfRequestDescription.Name = "rtfRequestDescription";
        this.rtfRequestDescription.TabIndex = 6;

        this.Emergency = new TTVisual.TTCheckBox();
        this.Emergency.Value = false;
        this.Emergency.Title = "Acil";
        this.Emergency.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Emergency.Name = "Emergency";
        this.Emergency.TabIndex = 1;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16650", "İstek Tarihi");
        this.labelActionDate.BackColor = "#DCDCDC";
        this.labelActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelActionDate.ForeColor = "#000000";
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 35;

        this.InPatientBed = new TTVisual.TTCheckBox();
        this.InPatientBed.Value = false;
        this.InPatientBed.Title = "Yatağında";
        this.InPatientBed.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.InPatientBed.Name = "InPatientBed";
        this.InPatientBed.TabIndex = 2;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.BackColor = "#F0F0F0";
        this.RequestDate.CustomFormat = "dd.MM.yyyy HH:mm";
        this.RequestDate.Format = DateTimePickerFormat.Custom;
        this.RequestDate.Enabled = false;
        this.RequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 0;

        this.lblProcedureDoctor = new TTVisual.TTLabel();
        this.lblProcedureDoctor.Text = i18n("M17795", "Konsültasyonu Yapan");
        this.lblProcedureDoctor.BackColor = "#DCDCDC";
        this.lblProcedureDoctor.ForeColor = "#000000";
        this.lblProcedureDoctor.Name = "lblProcedureDoctor";
        this.lblProcedureDoctor.TabIndex = 49;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.LinkedControlName = "MasterResource";
        this.ProcedureDoctor.LinkedRelationPath = "USERRESOURCES.RESOURCE";
        this.ProcedureDoctor.ListDefName = "ConsultationRequesterUserList";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 5;

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ListDefName = "ConsultationRequestResourceList";
        this.MasterResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 4;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M16678", "İstek Yapılan Birim");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 39;

        this.RequesterDepatment = new TTVisual.TTObjectListBox();
        this.RequesterDepatment.ListDefName = "ResourceListDefinition";
        this.RequesterDepatment.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequesterDepatment.Name = "RequesterDepatment";
        this.RequesterDepatment.TabIndex = 4;

        this.labelRequesterDepatment = new TTVisual.TTLabel();
        this.labelRequesterDepatment.Text = i18n("M16657", "İstek Yapan Birim");
        this.labelRequesterDepatment.BackColor = "#DCDCDC";
        this.labelRequesterDepatment.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRequesterDepatment.ForeColor = "#000000";
        this.labelRequesterDepatment.Name = "labelRequesterDepatment";
        this.labelRequesterDepatment.TabIndex = 39;

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 3;
        this.ProtocolNo.Visible = false;

        this.EPISODEID = new TTVisual.TTTextBox();
        this.EPISODEID.BackColor = "#F0F0F0";
        this.EPISODEID.ReadOnly = true;
        this.EPISODEID.Name = "EPISODEID";
        this.EPISODEID.TabIndex = 3;
        this.EPISODEID.Visible = false;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.BackColor = "#DCDCDC";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 10;
        this.labelProtocolNo.Visible = false;

        this.Controls = [this.ttlabel8, this.RequestedDoctor, this.rtfRequestDescription, this.Emergency, this.labelActionDate, this.InPatientBed, this.RequestDate, this.lblProcedureDoctor, this.ProcedureDoctor, this.MasterResource, this.ttlabel2, this.RequesterDepatment, this.labelRequesterDepatment, this.ProtocolNo, this.EPISODEID, this.labelProtocolNo];

    }


}
