//$A7843A60
import { Component, ViewChild, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { InpatientAppInfoFormViewModel } from './InpatientAppInfoFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { InpatientAppointment } from 'NebulaClient/Model/AtlasClientModel';
import { ResBed } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResWard } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'InpatientAppInfoForm',
    templateUrl: './InpatientAppInfoForm.html',
    providers: [MessageService]
})
export class InpatientAppInfoForm extends TTVisual.TTForm implements OnInit {
    AppointmentDate: TTVisual.ITTDateTimePicker;
    Bed: TTVisual.ITTObjectListBox;
    InpatientDay: TTVisual.ITTTextBox;
    IsQueue: TTVisual.ITTCheckBox;
    labelAppointmentDate: TTVisual.ITTLabel;
    labelBed: TTVisual.ITTLabel;
    labelInpatientDay: TTVisual.ITTLabel;
    labelMasterResource: TTVisual.ITTLabel;
    labelPhysicalStateClinic: TTVisual.ITTLabel;
    labelResponsibleDoctor: TTVisual.ITTLabel;
    labelRoom: TTVisual.ITTLabel;
    MasterResource: TTVisual.ITTObjectListBox;
    PhysicalStateClinic: TTVisual.ITTObjectListBox;
    ResponsibleDoctor: TTVisual.ITTObjectListBox;
    Room: TTVisual.ITTObjectListBox;
    InpatientAcceptionType: TTVisual.ITTEnumComboBox;
    public inpatientAppInfoFormViewModel: InpatientAppInfoFormViewModel = new InpatientAppInfoFormViewModel();
    public get _InpatientAppointment(): InpatientAppointment {
        return this._TTObject as InpatientAppointment;
    }
    private InpatientAppInfoForm_DocumentUrl: string = '/api/InpatientAppointmentService/InpatientAppInfoForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('INPATIENTAPPOINTMENT', 'InpatientAppInfoForm');
        this._DocumentServiceUrl = this.InpatientAppInfoForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async PreScript(): Promise<void> {
        super.PreScript();

        if (this.inpatientAppInfoFormViewModel._InpatientAppointment.IsQueue == true) {
            this.AppointmentDate.ReadOnly = true;
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InpatientAppointment();
        this.inpatientAppInfoFormViewModel = new InpatientAppInfoFormViewModel();
        this._ViewModel = this.inpatientAppInfoFormViewModel;
        this.inpatientAppInfoFormViewModel._InpatientAppointment = this._TTObject as InpatientAppointment;
        this.inpatientAppInfoFormViewModel._InpatientAppointment.MasterResource = new ResSection();
        this.inpatientAppInfoFormViewModel._InpatientAppointment.Bed = new ResBed();
        this.inpatientAppInfoFormViewModel._InpatientAppointment.Room = new ResRoom();
        this.inpatientAppInfoFormViewModel._InpatientAppointment.PhysicalStateClinic = new ResWard();
        this.inpatientAppInfoFormViewModel._InpatientAppointment.ResponsibleDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.inpatientAppInfoFormViewModel = this._ViewModel as InpatientAppInfoFormViewModel;
        that._TTObject = this.inpatientAppInfoFormViewModel._InpatientAppointment;
        if (this.inpatientAppInfoFormViewModel == null)
            this.inpatientAppInfoFormViewModel = new InpatientAppInfoFormViewModel();
        if (this.inpatientAppInfoFormViewModel._InpatientAppointment == null)
            this.inpatientAppInfoFormViewModel._InpatientAppointment = new InpatientAppointment();
        let masterResourceObjectID = that.inpatientAppInfoFormViewModel._InpatientAppointment["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === "string")) {
            let masterResource = that.inpatientAppInfoFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.inpatientAppInfoFormViewModel._InpatientAppointment.MasterResource = masterResource;
            }
        }

        let bedObjectID = that.inpatientAppInfoFormViewModel._InpatientAppointment["Bed"];
        if (bedObjectID != null && (typeof bedObjectID === "string")) {
            let bed = that.inpatientAppInfoFormViewModel.ResBeds.find(o => o.ObjectID.toString() === bedObjectID.toString());
            if (bed) {
                that.inpatientAppInfoFormViewModel._InpatientAppointment.Bed = bed;
            }
        }

        let roomObjectID = that.inpatientAppInfoFormViewModel._InpatientAppointment["Room"];
        if (roomObjectID != null && (typeof roomObjectID === "string")) {
            let room = that.inpatientAppInfoFormViewModel.ResRooms.find(o => o.ObjectID.toString() === roomObjectID.toString());
            if (room) {
                that.inpatientAppInfoFormViewModel._InpatientAppointment.Room = room;
            }
        }

        let physicalStateClinicObjectID = that.inpatientAppInfoFormViewModel._InpatientAppointment["PhysicalStateClinic"];
        if (physicalStateClinicObjectID != null && (typeof physicalStateClinicObjectID === "string")) {
            let physicalStateClinic = that.inpatientAppInfoFormViewModel.ResWards.find(o => o.ObjectID.toString() === physicalStateClinicObjectID.toString());
            if (physicalStateClinic) {
                that.inpatientAppInfoFormViewModel._InpatientAppointment.PhysicalStateClinic = physicalStateClinic;
            }
        }

        let responsibleDoctorObjectID = that.inpatientAppInfoFormViewModel._InpatientAppointment["ResponsibleDoctor"];
        if (responsibleDoctorObjectID != null && (typeof responsibleDoctorObjectID === "string")) {
            let responsibleDoctor = that.inpatientAppInfoFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleDoctorObjectID.toString());
            if (responsibleDoctor) {
                that.inpatientAppInfoFormViewModel._InpatientAppointment.ResponsibleDoctor = responsibleDoctor;
            }
        }
    }

    async ngOnInit() {
        await this.load();
    }

    public onAppointmentDateChanged(event): void {
        if (this._InpatientAppointment != null && this._InpatientAppointment.AppointmentDate != event) {
            this._InpatientAppointment.AppointmentDate = event;
        }
    }

    public onBedChanged(event): void {
        if (this._InpatientAppointment != null && this._InpatientAppointment.Bed != event) {
            this._InpatientAppointment.Bed = event;
        }
    }

    public onInpatientDayChanged(event): void {
        if (this._InpatientAppointment != null && this._InpatientAppointment.InpatientDay != event) {
            this._InpatientAppointment.InpatientDay = event;
        }
    }

    public onIsQueueChanged(event): void {
        if (this._InpatientAppointment != null && this._InpatientAppointment.IsQueue != event) {
            this._InpatientAppointment.IsQueue = event;
        }
        if (this._InpatientAppointment.IsQueue == true) {
            this.AppointmentDate.ReadOnly = true;
        } else {
            this.AppointmentDate.ReadOnly = false;
        }
    }

    public onMasterResourceChanged(event): void {
        if (this._InpatientAppointment != null && this._InpatientAppointment.MasterResource != event) {
            this._InpatientAppointment.MasterResource = event;
        }
    }

    public onPhysicalStateClinicChanged(event): void {
        if (this._InpatientAppointment != null && this._InpatientAppointment.PhysicalStateClinic != event) {
            this._InpatientAppointment.PhysicalStateClinic = event;
        }
    }

    public onResponsibleDoctorChanged(event): void {
        if (this._InpatientAppointment != null && this._InpatientAppointment.ResponsibleDoctor != event) {
            this._InpatientAppointment.ResponsibleDoctor = event;
        }
    }

    public onRoomChanged(event): void {
        if (this._InpatientAppointment != null && this._InpatientAppointment.Room != event) {
            this._InpatientAppointment.Room = event;
        }
    }

    public onInpatientAcceptionTypeChanged(event): void {
        if (event != null && this._InpatientAppointment != null && this._InpatientAppointment.InpatientAcceptionType != event) {
            this._InpatientAppointment.InpatientAcceptionType = event;
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.InpatientDay, "Text", this.__ttObject, "InpatientDay");
        redirectProperty(this.IsQueue, "Value", this.__ttObject, "IsQueue");
        redirectProperty(this.AppointmentDate, "Value", this.__ttObject, "AppointmentDate");
        redirectProperty(this.InpatientAcceptionType, "Value", this.__ttObject, "InpatientAcceptionType");
    }

    public initFormControls(): void {
        this.labelMasterResource = new TTVisual.TTLabel();
        this.labelMasterResource.Text = "Klinik";
        this.labelMasterResource.Name = "labelMasterResource";
        this.labelMasterResource.TabIndex = 16;

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ListDefName = "ClinicListDefinition";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 15;

        this.labelBed = new TTVisual.TTLabel();
        this.labelBed.Text = "Yatak";
        this.labelBed.Name = "labelBed";
        this.labelBed.TabIndex = 14;

        this.Bed = new TTVisual.TTObjectListBox();
        this.Bed.ListDefName = "BedListDefinition";
        this.Bed.Name = "Bed";
        this.Bed.TabIndex = 13;

        this.labelRoom = new TTVisual.TTLabel();
        this.labelRoom.Text = "Oda";
        this.labelRoom.Name = "labelRoom";
        this.labelRoom.TabIndex = 12;

        this.Room = new TTVisual.TTObjectListBox();
        this.Room.ListDefName = "RoomListDefinition";
        this.Room.Name = "Room";
        this.Room.TabIndex = 11;

        this.labelPhysicalStateClinic = new TTVisual.TTLabel();
        this.labelPhysicalStateClinic.Text = "Servis";
        this.labelPhysicalStateClinic.Name = "labelPhysicalStateClinic";
        this.labelPhysicalStateClinic.TabIndex = 10;

        this.PhysicalStateClinic = new TTVisual.TTObjectListBox();
        this.PhysicalStateClinic.ListDefName = "WardListDefinition";
        this.PhysicalStateClinic.Name = "PhysicalStateClinic";
        this.PhysicalStateClinic.TabIndex = 9;

        this.labelResponsibleDoctor = new TTVisual.TTLabel();
        this.labelResponsibleDoctor.Text = "Doktor";
        this.labelResponsibleDoctor.Name = "labelResponsibleDoctor";
        this.labelResponsibleDoctor.TabIndex = 6;

        this.ResponsibleDoctor = new TTVisual.TTObjectListBox();
        this.ResponsibleDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ResponsibleDoctor.Name = "ResponsibleDoctor";
        this.ResponsibleDoctor.TabIndex = 5;

        this.IsQueue = new TTVisual.TTCheckBox();
        this.IsQueue.Value = false;
        this.IsQueue.Text = "Hastayı sıraya al";
        this.IsQueue.Title = "Hastayı sıraya al";
        this.IsQueue.Name = "IsQueue";
        this.IsQueue.TabIndex = 4;

        this.labelInpatientDay = new TTVisual.TTLabel();
        this.labelInpatientDay.Text = "Planlanan Yatış Süresi";
        this.labelInpatientDay.Name = "labelInpatientDay";
        this.labelInpatientDay.TabIndex = 3;

        this.InpatientDay = new TTVisual.TTTextBox();
        this.InpatientDay.Name = "InpatientDay";
        this.InpatientDay.TabIndex = 2;

        this.labelAppointmentDate = new TTVisual.TTLabel();
        this.labelAppointmentDate.Text = "Randevu Tarihi";
        this.labelAppointmentDate.Name = "labelAppointmentDate";
        this.labelAppointmentDate.TabIndex = 1;

        this.AppointmentDate = new TTVisual.TTDateTimePicker();
        this.AppointmentDate.Format = DateTimePickerFormat.Long;
        this.AppointmentDate.Name = "AppointmentDate";
        this.AppointmentDate.TabIndex = 0;

        this.InpatientAcceptionType = new TTVisual.TTEnumComboBox();
        this.InpatientAcceptionType.DataTypeName = "InpatientAcceptionTypeEnum";
        this.InpatientAcceptionType.Name = "InpatientAcceptionType";
        this.InpatientAcceptionType.TabIndex = 0;

        this.Controls = [this.labelMasterResource, this.MasterResource, this.labelBed, this.Bed, this.labelRoom, this.Room, this.labelPhysicalStateClinic, this.PhysicalStateClinic, this.labelResponsibleDoctor, this.ResponsibleDoctor, this.IsQueue, this.labelInpatientDay, this.InpatientDay, this.labelAppointmentDate, this.AppointmentDate, this.InpatientAcceptionType];

    }


}
