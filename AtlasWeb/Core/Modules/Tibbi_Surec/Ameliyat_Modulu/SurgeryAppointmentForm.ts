//$A2791C3B
import { Component, ViewChild, OnInit, ApplicationRef, Input, Output, EventEmitter } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { SurgeryAppointmentFormViewModel } from './SurgeryAppointmentFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { SurgeryAppointment, Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryDesk } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryAppointmentProc } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { Subscription } from 'rxjs';
import { SurgeryAppointmentSharedService } from './SurgeryAppointmentSharedService';
import { SurgeryAppointmentListItem, SurgeryAppointmentListSearchCriteria } from './SurgeryAppointmentComponentFormViewModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';

@Component({
    selector: 'SurgeryAppointmentForm',
    templateUrl: 'SurgeryAppointmentForm.html',
    providers: [MessageService]
})
export class SurgeryAppointmentForm extends TTVisual.TTForm implements OnInit {
    ComplicationDescription: TTVisual.ITTTextBox;
    DescriptionToPreOp: TTVisual.ITTRichTextBoxControl;
    Emergency: TTVisual.ITTCheckBox;
    IsComplicationSurgery: TTVisual.ITTCheckBox;
    IsNeedAnesthesia: TTVisual.ITTCheckBox;
    labelComplicationDescription: TTVisual.ITTLabel;
    labelDescriptionToPreOp: TTVisual.ITTLabel;
    labelMasterResource: TTVisual.ITTLabel;
    labelNotesToAnesthesia: TTVisual.ITTLabel;
    labelPlannedSurgeryDescription: TTVisual.ITTLabel;
    labelPlannedSurgeryEndDate: TTVisual.ITTLabel;
    labelPlannedSurgeryStartDate: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelSurgeryDesk: TTVisual.ITTLabel;
    labelSurgeryRoom: TTVisual.ITTLabel;
    MasterResource: TTVisual.ITTObjectListBox;
    NotesToAnesthesia: TTVisual.ITTTextBox;
    PlannedSurgeryDescription: TTVisual.ITTTextBox;
    PlannedSurgeryEndDate: TTVisual.ITTDateTimePicker;
    PlannedSurgeryStartDate: TTVisual.ITTDateTimePicker;
    ProcedureDefinitionSurgeryAppointmentProc: TTVisual.ITTListBoxColumn;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    SurgeryAppointmentProcedures: TTVisual.ITTGrid;
    SurgeryDesk: TTVisual.ITTObjectListBox;
    SurgeryRoom: TTVisual.ITTObjectListBox;
    public SurgeryAppointmentProceduresColumns = [];
    public surgeryAppointmentFormViewModel: SurgeryAppointmentFormViewModel = new SurgeryAppointmentFormViewModel();
    public get _SurgeryAppointment(): SurgeryAppointment {
        return this._TTObject as SurgeryAppointment;
    }
    private SurgeryAppointmentForm_DocumentUrl: string = '/api/SurgeryAppointmentService/SurgeryAppointmentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private surgeryAppointmentSharedService: SurgeryAppointmentSharedService) {
        super('SURGERYAPPOINTMENT', 'SurgeryAppointmentForm');
        this._DocumentServiceUrl = this.SurgeryAppointmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    @Input() set FormLoadInput(value: ActiveIDsModel) {
        this.ActiveIDsModel = value;
        if (this.ActiveIDsModel.episodeActionId != null) {
            this.isOpenedFromMenu = false;
        }
        this.load();
    }
    get FormLoadInput(): ActiveIDsModel {
        return this.ActiveIDsModel;
    }

    // ***** Method declarations start *****


    // *****Method declarations end *****

    @Output() IsComponentSaved: EventEmitter<boolean> = new EventEmitter<boolean>();

    public isOpenedFromMenu: boolean = true;
    public initViewModel(): void {
        this._TTObject = new SurgeryAppointment();
        this.surgeryAppointmentFormViewModel = new SurgeryAppointmentFormViewModel();
        this._ViewModel = this.surgeryAppointmentFormViewModel;
        this.surgeryAppointmentFormViewModel._SurgeryAppointment = this._TTObject as SurgeryAppointment;
        this.surgeryAppointmentFormViewModel._SurgeryAppointment.SurgeryAppointmentProcedures = new Array<SurgeryAppointmentProc>();
        this.surgeryAppointmentFormViewModel._SurgeryAppointment.MasterResource = new ResSection();
        this.surgeryAppointmentFormViewModel._SurgeryAppointment.ProcedureDoctor = new ResUser();
        this.surgeryAppointmentFormViewModel._SurgeryAppointment.SurgeryRoom = new ResSurgeryRoom();
        this.surgeryAppointmentFormViewModel._SurgeryAppointment.SurgeryDesk = new ResSurgeryDesk();
        this.surgeryAppointmentFormViewModel.PatientObject = new Patient();
        this.surgeryAppointmentFormViewModel.PatientObject.BirthDate = new Date();
    }

    protected loadViewModel() {
        let that = this;
        that.surgeryAppointmentFormViewModel = this._ViewModel as SurgeryAppointmentFormViewModel;
        that._TTObject = this.surgeryAppointmentFormViewModel._SurgeryAppointment;
        if (this.surgeryAppointmentFormViewModel == null)
            this.surgeryAppointmentFormViewModel = new SurgeryAppointmentFormViewModel();
        if (this.surgeryAppointmentFormViewModel._SurgeryAppointment == null)
            this.surgeryAppointmentFormViewModel._SurgeryAppointment = new SurgeryAppointment();
        if (this.surgeryAppointmentFormViewModel._SurgeryAppointment.SurgeryAppointmentProcedures == null)
            this.surgeryAppointmentFormViewModel._SurgeryAppointment.SurgeryAppointmentProcedures = new Array<SurgeryAppointmentProc>();
        that.surgeryAppointmentFormViewModel._SurgeryAppointment.SurgeryAppointmentProcedures = that.surgeryAppointmentFormViewModel.SurgeryAppointmentProceduresGridList;
        for (let detailItem of that.surgeryAppointmentFormViewModel.SurgeryAppointmentProceduresGridList) {
            let procedureDefinitionObjectID = detailItem["ProcedureDefinition"];
            if (procedureDefinitionObjectID != null && (typeof procedureDefinitionObjectID === "string")) {
                let procedureDefinition = that.surgeryAppointmentFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureDefinitionObjectID.toString());
                if (procedureDefinition) {
                    detailItem.ProcedureDefinition = procedureDefinition;
                }
            }

        }

        let masterResourceObjectID = that.surgeryAppointmentFormViewModel._SurgeryAppointment["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === "string")) {
            let masterResource = that.surgeryAppointmentFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.surgeryAppointmentFormViewModel._SurgeryAppointment.MasterResource = masterResource;
            }
        }


        let procedureDoctorObjectID = that.surgeryAppointmentFormViewModel._SurgeryAppointment["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.surgeryAppointmentFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.surgeryAppointmentFormViewModel._SurgeryAppointment.ProcedureDoctor = procedureDoctor;
            }
        }


        let surgeryRoomObjectID = that.surgeryAppointmentFormViewModel._SurgeryAppointment["SurgeryRoom"];
        if (surgeryRoomObjectID != null && (typeof surgeryRoomObjectID === "string")) {
            let surgeryRoom = that.surgeryAppointmentFormViewModel.ResSurgeryRooms.find(o => o.ObjectID.toString() === surgeryRoomObjectID.toString());
            if (surgeryRoom) {
                that.surgeryAppointmentFormViewModel._SurgeryAppointment.SurgeryRoom = surgeryRoom;
            }
        }


        let surgeryDeskObjectID = that.surgeryAppointmentFormViewModel._SurgeryAppointment["SurgeryDesk"];
        if (surgeryDeskObjectID != null && (typeof surgeryDeskObjectID === "string")) {
            let surgeryDesk = that.surgeryAppointmentFormViewModel.ResSurgeryDesks.find(o => o.ObjectID.toString() === surgeryDeskObjectID.toString());
            if (surgeryDesk) {
                that.surgeryAppointmentFormViewModel._SurgeryAppointment.SurgeryDesk = surgeryDesk;
            }
        }

    }

    public filteredAppointmentList: Array<SurgeryAppointmentListItem> = new Array<SurgeryAppointmentListItem>();
    public AppointmentListSubscription: Subscription;
    public initSubscriptions() {
        if (this.AppointmentListSubscription == null) {
            this.AppointmentListSubscription = this.surgeryAppointmentSharedService.SearchedAppointmentsResponse.subscribe(
                responseList => {
                    this.filteredAppointmentList = responseList;
                    if (responseList != null && responseList.length > 0) {
                        ServiceLocator.MessageService.showInfo("Seçilen Tarihte Ameliyat Randevusu Bulunmaktadır. Tarih veya Ameliyathane değiştirerek Randevuyu kaydedebilirsiniz");
                        this.isSaveContinue = false;
                    }else {
                        this.isSaveContinue = true;
                    }
                }
            )
        }
    }

    public destroySubscriptions() {
        if (this.AppointmentListSubscription != null) {
            this.AppointmentListSubscription.unsubscribe();
            this.AppointmentListSubscription = null;
        }
    }

    private getObjectID(ttObject): string {
        if (ttObject == null)
            return null;
        if (typeof ttObject == "string") {
            return ttObject;
        }
        else
            return ttObject.ObjectID.toString();
    }

    private triggerLoadChildComboBoxBySurgeryDepartment(surgeryDepartment): void {

        if (surgeryDepartment != null) {
            this.SurgeryRoom.ListFilterExpression = " THIS.SURGERYDEPARTMENT= '" + surgeryDepartment.ObjectID.toString() + "'";
            if (this._SurgeryAppointment.SurgeryRoom != null && (this._SurgeryAppointment.SurgeryRoom.SurgeryDepartment == null || this.getObjectID(this._SurgeryAppointment.SurgeryRoom.SurgeryDepartment) != surgeryDepartment.ObjectID))
                this._SurgeryAppointment.SurgeryRoom = null;
        }
        else {
            this.SurgeryRoom.ListFilterExpression = " ";
            this._SurgeryAppointment.SurgeryRoom = null;
        }


    }

    private triggerLoadChildComboBoxBySurgeryRoom(surgeryRoom): void {
        if (surgeryRoom != null) {
            this.SurgeryDesk.ListFilterExpression = " THIS.SURGERYROOM= '" + surgeryRoom.ObjectID.toString() + "'";
            if (this._SurgeryAppointment.SurgeryDesk != null && (this._SurgeryAppointment.SurgeryDesk.SurgeryRoom == null || this.getObjectID(this._SurgeryAppointment.SurgeryDesk.SurgeryRoom) != surgeryRoom.ObjectID))
                this._SurgeryAppointment.SurgeryDesk = null;

            if (this._SurgeryAppointment.MasterResource == null || this._SurgeryAppointment.MasterResource.ObjectID != surgeryRoom.SurgeryDepartment)
                this._SurgeryAppointment.MasterResource = surgeryRoom.SurgeryDepartment;
        }
        else {
            this.SurgeryDesk.ListFilterExpression = " ";
            this._SurgeryAppointment.SurgeryDesk = null;
        }
    }

    async ngOnInit() {
        await this.load();
        this.initSubscriptions();
    }

    async ngOnDestroy() {
        this.destroySubscriptions();
    }

    public onComplicationDescriptionChanged(event): void {
        if (this._SurgeryAppointment != null && this._SurgeryAppointment.ComplicationDescription != event) {
            this._SurgeryAppointment.ComplicationDescription = event;
        }
    }

    public onDescriptionToPreOpChanged(event): void {
        if (this._SurgeryAppointment != null && this._SurgeryAppointment.DescriptionToPreOp != event) {
            this._SurgeryAppointment.DescriptionToPreOp = event;
        }
    }

    public onEmergencyChanged(event): void {
        if (this._SurgeryAppointment != null && this._SurgeryAppointment.Emergency != event) {
            this._SurgeryAppointment.Emergency = event;
        }
    }

    public onIsComplicationSurgeryChanged(event): void {
        if (this._SurgeryAppointment != null && this._SurgeryAppointment.IsComplicationSurgery != event) {
            this._SurgeryAppointment.IsComplicationSurgery = event;
        }
    }

    public onIsNeedAnesthesiaChanged(event): void {
        if (this._SurgeryAppointment != null && this._SurgeryAppointment.IsNeedAnesthesia != event) {
            this._SurgeryAppointment.IsNeedAnesthesia = event;
        }
    }

    public onMasterResourceChanged(event): void {
        if (this._SurgeryAppointment != null && this._SurgeryAppointment.MasterResource != event) {
            this._SurgeryAppointment.MasterResource = event;
            this.ListSelectedFiltersAppointments();
        }
        this.triggerLoadChildComboBoxBySurgeryDepartment(event);
    }

    public onNotesToAnesthesiaChanged(event): void {
        if (this._SurgeryAppointment != null && this._SurgeryAppointment.NotesToAnesthesia != event) {
            this._SurgeryAppointment.NotesToAnesthesia = event;
        }
    }

    public onPlannedSurgeryDescriptionChanged(event): void {
        if (this._SurgeryAppointment != null && this._SurgeryAppointment.PlannedSurgeryDescription != event) {
            this._SurgeryAppointment.PlannedSurgeryDescription = event;
        }
    }

    public onPlannedSurgeryEndDateChanged(event): void {
        if (this._SurgeryAppointment != null && this._SurgeryAppointment.PlannedSurgeryEndDate != event) {
            this._SurgeryAppointment.PlannedSurgeryEndDate = event;
            this.ListSelectedFiltersAppointments();
        }
    }

    public onPlannedSurgeryStartDateChanged(event): void {
        if (this._SurgeryAppointment != null && this._SurgeryAppointment.PlannedSurgeryStartDate != event) {
            this._SurgeryAppointment.PlannedSurgeryStartDate = event;
            this.ListSelectedFiltersAppointments();
        }
    }

    public onProcedureDoctorChanged(event): void {
        if (this._SurgeryAppointment != null && this._SurgeryAppointment.ProcedureDoctor != event) {
            this._SurgeryAppointment.ProcedureDoctor = event;
        }
    }

    public onSurgeryDeskChanged(event): void {
        if (this._SurgeryAppointment != null && this._SurgeryAppointment.SurgeryDesk != event) {
            this._SurgeryAppointment.SurgeryDesk = event;
        }
    }

    public onSurgeryRoomChanged(event): void {
        if (this._SurgeryAppointment != null && this._SurgeryAppointment.SurgeryRoom != event) {
            this._SurgeryAppointment.SurgeryRoom = event;
            this.ListSelectedFiltersAppointments();
        }
        this.triggerLoadChildComboBoxBySurgeryRoom(event);
    }

    public ListSelectedFiltersAppointments() {
        let searchCriteria: SurgeryAppointmentListSearchCriteria = new SurgeryAppointmentListSearchCriteria();
        searchCriteria.searchForAppointmentCount = this.isOpenedFromMenu;
        if (this.surgeryAppointmentFormViewModel._SurgeryAppointment.PlannedSurgeryStartDate != null)
            searchCriteria.AppointmentStartDate = this.surgeryAppointmentFormViewModel._SurgeryAppointment.PlannedSurgeryStartDate;

        if (this.surgeryAppointmentFormViewModel._SurgeryAppointment.PlannedSurgeryEndDate != null)
            searchCriteria.AppointmentEndDate = this.surgeryAppointmentFormViewModel._SurgeryAppointment.PlannedSurgeryEndDate;

        if (this.surgeryAppointmentFormViewModel._SurgeryAppointment.MasterResource != null) {
            searchCriteria.SurgeryDepartments = new Array<ResSection>();
            searchCriteria.SurgeryDepartments.push(this.surgeryAppointmentFormViewModel._SurgeryAppointment.MasterResource);
        }
        if (this.surgeryAppointmentFormViewModel._SurgeryAppointment.SurgeryRoom != null)
            searchCriteria.SurgeryRooms = this.surgeryAppointmentFormViewModel._SurgeryAppointment.SurgeryRoom;

        this.surgeryAppointmentSharedService.sendSearchCriteria(searchCriteria);
    }

    public isSaveContinue = false;
    public async saveAppointmentForm(event) {

        if (this.surgeryAppointmentFormViewModel._SurgeryAppointment.ProcedureDoctor == null) {
            ServiceLocator.MessageService.showError("Doktor Seçmeden Devam Edemezsiniz!");
            return;
        }

        if (this.surgeryAppointmentFormViewModel._SurgeryAppointment.PlannedSurgeryStartDate == null || this.surgeryAppointmentFormViewModel._SurgeryAppointment.PlannedSurgeryStartDate < new Date()) {
            ServiceLocator.MessageService.showError("Planlanan Ameliyat Başlangıç Tarihi Boş veya Bugünden Geride Olamaz!");
            return;
        }

        if (this.surgeryAppointmentFormViewModel._SurgeryAppointment.PlannedSurgeryEndDate == null ||
            (this.surgeryAppointmentFormViewModel._SurgeryAppointment.PlannedSurgeryEndDate < this.surgeryAppointmentFormViewModel._SurgeryAppointment.PlannedSurgeryStartDate)) {
            ServiceLocator.MessageService.showError("Planlanan Ameliyat Bitiş Tarihi Boş veya Başlangıç Tarihinden Geride Olamaz!");
            return;
        }

        if (this.surgeryAppointmentFormViewModel._SurgeryAppointment.MasterResource == null) {
            ServiceLocator.MessageService.showError("Ameliyathane Seçmeden Devam Edemezsiniz!");
            return;
        }
        if (this.surgeryAppointmentFormViewModel._SurgeryAppointment.PlannedSurgeryDescription == null && this.surgeryAppointmentFormViewModel._SurgeryAppointment.SurgeryAppointmentProcedures.length == 0) {
            ServiceLocator.MessageService.showError("Planlanan Ameliyat(lar)' ve 'Planlanan Ameliyat Açıklaması' alanlarının ikisi birden boş geçilemez");
            return;
        }

        if (this.filteredAppointmentList != null && this.filteredAppointmentList.length != 0) {
            ServiceLocator.MessageService.showError("Belirtilen Tarihte Seçilen Ameliyathanede ve (varsa) Seçilen Salonda Başka Bir Randevu Bulunmaktadır!");
            return;
        }
        await this.save(event);
        if(this.isOpenedFromMenu == true)
            this.IsComponentSaved.emit(true);
    }

    protected redirectProperties(): void {
        redirectProperty(this.PlannedSurgeryStartDate, "Value", this.__ttObject, "PlannedSurgeryStartDate");
        redirectProperty(this.PlannedSurgeryEndDate, "Value", this.__ttObject, "PlannedSurgeryEndDate");
        redirectProperty(this.IsNeedAnesthesia, "Value", this.__ttObject, "IsNeedAnesthesia");
        redirectProperty(this.Emergency, "Value", this.__ttObject, "Emergency");
        redirectProperty(this.IsComplicationSurgery, "Value", this.__ttObject, "IsComplicationSurgery");
        redirectProperty(this.ComplicationDescription, "Text", this.__ttObject, "ComplicationDescription");
        redirectProperty(this.PlannedSurgeryDescription, "Text", this.__ttObject, "PlannedSurgeryDescription");
        redirectProperty(this.DescriptionToPreOp, "Rtf", this.__ttObject, "DescriptionToPreOp");
        redirectProperty(this.NotesToAnesthesia, "Text", this.__ttObject, "NotesToAnesthesia");
    }

    public initFormControls(): void {
        this.SurgeryAppointmentProcedures = new TTVisual.TTGrid();
        this.SurgeryAppointmentProcedures.Name = "SurgeryAppointmentProcedures";
        this.SurgeryAppointmentProcedures.TabIndex = 25;
        this.SurgeryAppointmentProcedures.ShowFilterCombo = true;
        this.SurgeryAppointmentProcedures.Height = 90;
        this.SurgeryAppointmentProcedures.FilterColumnName = "ProcedureDefinitionSurgeryAppointmentProc";
        this.SurgeryAppointmentProcedures.FilterLabel = i18n("M27385", "Ameliyat");
        this.SurgeryAppointmentProcedures.Filter = { ListDefName: "SurgeryListDefinition" };
        this.SurgeryAppointmentProcedures.IsFilterLabelSingleLine = true;
        this.SurgeryAppointmentProcedures.AllowUserToAddRows = false;

        this.ProcedureDefinitionSurgeryAppointmentProc = new TTVisual.TTListBoxColumn();
        this.ProcedureDefinitionSurgeryAppointmentProc.ListDefName = "SurgeryListDefinition";
        this.ProcedureDefinitionSurgeryAppointmentProc.DataMember = "ProcedureDefinition";
        this.ProcedureDefinitionSurgeryAppointmentProc.DisplayIndex = 0;
        this.ProcedureDefinitionSurgeryAppointmentProc.HeaderText = "Ameliyat";
        this.ProcedureDefinitionSurgeryAppointmentProc.Name = "ProcedureDefinitionSurgeryAppointmentProc";
        this.ProcedureDefinitionSurgeryAppointmentProc.Width = 280;
        this.ProcedureDefinitionSurgeryAppointmentProc.ReadOnly = true;

        this.labelMasterResource = new TTVisual.TTLabel();
        this.labelMasterResource.Text = "Ameliyathane";
        this.labelMasterResource.Name = "labelMasterResource";
        this.labelMasterResource.TabIndex = 24;

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ListDefName = "SurgreyDepartmentListDefinition";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 23;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = "Sorumlu Cerrah";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 22;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 21;

        this.labelSurgeryRoom = new TTVisual.TTLabel();
        this.labelSurgeryRoom.Text = "Ameliyat Salonu";
        this.labelSurgeryRoom.Name = "labelSurgeryRoom";
        this.labelSurgeryRoom.TabIndex = 20;

        this.SurgeryRoom = new TTVisual.TTObjectListBox();
        this.SurgeryRoom.LinkedControlName = "MasterResource";
        this.SurgeryRoom.ListDefName = "SurgeryRoomListDefinition";
        this.SurgeryRoom.Name = "SurgeryRoom";
        this.SurgeryRoom.TabIndex = 19;

        this.labelSurgeryDesk = new TTVisual.TTLabel();
        this.labelSurgeryDesk.Text = "Masa";
        this.labelSurgeryDesk.Name = "labelSurgeryDesk";
        this.labelSurgeryDesk.TabIndex = 18;

        this.SurgeryDesk = new TTVisual.TTObjectListBox();
        this.SurgeryDesk.LinkedControlName = "SurgeryRoom";
        this.SurgeryDesk.ListDefName = "SurgeryDeskListDefinition";
        this.SurgeryDesk.Name = "SurgeryDesk";
        this.SurgeryDesk.TabIndex = 17;

        this.Emergency = new TTVisual.TTCheckBox();
        this.Emergency.Value = false;
        this.Emergency.Text = "Acil";
        this.Emergency.Title = "Acil";
        this.Emergency.Name = "Emergency";
        this.Emergency.TabIndex = 16;

        this.IsNeedAnesthesia = new TTVisual.TTCheckBox();
        this.IsNeedAnesthesia.Value = false;
        this.IsNeedAnesthesia.Text = "Anestezi Gerektirir";
        this.IsNeedAnesthesia.Title = "Anestezi Gerektirir";
        this.IsNeedAnesthesia.Name = "IsNeedAnesthesia";
        this.IsNeedAnesthesia.TabIndex = 13;

        this.IsComplicationSurgery = new TTVisual.TTCheckBox();
        this.IsComplicationSurgery.Value = false;
        this.IsComplicationSurgery.Text = "Komplikasyon Ameliyatı";
        this.IsComplicationSurgery.Title = "Komplikasyon Ameliyatı";
        this.IsComplicationSurgery.Name = "IsComplicationSurgery";
        this.IsComplicationSurgery.TabIndex = 12;

        this.labelComplicationDescription = new TTVisual.TTLabel();
        this.labelComplicationDescription.Text = "Komplikasyon Açıklaması";
        this.labelComplicationDescription.Name = "labelComplicationDescription";
        this.labelComplicationDescription.TabIndex = 11;

        this.ComplicationDescription = new TTVisual.TTTextBox();
        this.ComplicationDescription.Multiline = true;
        this.ComplicationDescription.Name = "ComplicationDescription";
        this.ComplicationDescription.TabIndex = 10;

        this.NotesToAnesthesia = new TTVisual.TTTextBox();
        this.NotesToAnesthesia.Multiline = true;
        this.NotesToAnesthesia.Height = "75px";
        this.NotesToAnesthesia.Name = "NotesToAnesthesia";
        this.NotesToAnesthesia.TabIndex = 4;

        this.PlannedSurgeryDescription = new TTVisual.TTTextBox();
        this.PlannedSurgeryDescription.Multiline = true;
        this.PlannedSurgeryDescription.Height = "75px";
        this.PlannedSurgeryDescription.Name = "PlannedSurgeryDescription";
        this.PlannedSurgeryDescription.TabIndex = 0;

        this.labelPlannedSurgeryEndDate = new TTVisual.TTLabel();
        this.labelPlannedSurgeryEndDate.Text = "Planlanan Ameliyat Bitiş Tarihi";
        this.labelPlannedSurgeryEndDate.Name = "labelPlannedSurgeryEndDate";
        this.labelPlannedSurgeryEndDate.TabIndex = 9;

        this.PlannedSurgeryEndDate = new TTVisual.TTDateTimePicker();
        this.PlannedSurgeryEndDate.Format = DateTimePickerFormat.Long;
        this.PlannedSurgeryEndDate.Name = "PlannedSurgeryEndDate";
        this.PlannedSurgeryEndDate.TabIndex = 8;

        this.labelPlannedSurgeryStartDate = new TTVisual.TTLabel();
        this.labelPlannedSurgeryStartDate.Text = "Planlanan Ameliyat Başlangıç Tarihi";
        this.labelPlannedSurgeryStartDate.Name = "labelPlannedSurgeryStartDate";
        this.labelPlannedSurgeryStartDate.TabIndex = 7;

        this.PlannedSurgeryStartDate = new TTVisual.TTDateTimePicker();
        this.PlannedSurgeryStartDate.Format = DateTimePickerFormat.Long;
        this.PlannedSurgeryStartDate.Name = "PlannedSurgeryStartDate";
        this.PlannedSurgeryStartDate.TabIndex = 6;

        this.labelNotesToAnesthesia = new TTVisual.TTLabel();
        this.labelNotesToAnesthesia.Text = "Anestezi Bölümü İçin Açıklamalar";
        this.labelNotesToAnesthesia.Name = "labelNotesToAnesthesia";
        this.labelNotesToAnesthesia.TabIndex = 5;

        this.labelDescriptionToPreOp = new TTVisual.TTLabel();
        this.labelDescriptionToPreOp.Text = "Ön Hazırlık İçin Direktifler";
        this.labelDescriptionToPreOp.Name = "labelDescriptionToPreOp";
        this.labelDescriptionToPreOp.TabIndex = 3;

        this.DescriptionToPreOp = new TTVisual.TTRichTextBoxControl();
        this.DescriptionToPreOp.Name = "DescriptionToPreOp";
        this.DescriptionToPreOp.TabIndex = 2;

        this.labelPlannedSurgeryDescription = new TTVisual.TTLabel();
        this.labelPlannedSurgeryDescription.Text = "Planlanan Ameliyat Açıklaması";
        this.labelPlannedSurgeryDescription.Name = "labelPlannedSurgeryDescription";
        this.labelPlannedSurgeryDescription.TabIndex = 1;

        this.SurgeryAppointmentProceduresColumns = [this.ProcedureDefinitionSurgeryAppointmentProc];
        this.Controls = [this.SurgeryAppointmentProcedures, this.ProcedureDefinitionSurgeryAppointmentProc, this.labelMasterResource, this.MasterResource, this.labelProcedureDoctor, this.ProcedureDoctor, this.labelSurgeryRoom, this.SurgeryRoom, this.labelSurgeryDesk, this.SurgeryDesk, this.Emergency, this.IsNeedAnesthesia, this.IsComplicationSurgery, this.labelComplicationDescription, this.ComplicationDescription, this.NotesToAnesthesia, this.PlannedSurgeryDescription, this.labelPlannedSurgeryEndDate, this.PlannedSurgeryEndDate, this.labelPlannedSurgeryStartDate, this.PlannedSurgeryStartDate, this.labelNotesToAnesthesia, this.labelDescriptionToPreOp, this.DescriptionToPreOp, this.labelPlannedSurgeryDescription];

    }


}
