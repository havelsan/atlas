//$B4381E88
import { Component, OnInit, NgZone } from '@angular/core';
import { InPatientAdmissionClinicProcedureViewModel } from './InPatientAdmissionClinicProcedureViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { InpatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { InPatientAdmissionBaseForm } from "Modules/Tibbi_Surec/Yatan_Hasta_Modulu/InPatientAdmissionBaseForm";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { BaseBedProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { InPatientTreatmentClinicApplication } from 'NebulaClient/Model/AtlasClientModel';
import { ResBed } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoomGroup } from 'NebulaClient/Model/AtlasClientModel';
import { ResWard } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'InPatientAdmissionClinicProcedure',
    templateUrl: './InPatientAdmissionClinicProcedure.html',
    providers: [MessageService]
})
export class InPatientAdmissionClinicProcedure extends InPatientAdmissionBaseForm implements OnInit {
    ActiveBed: TTVisual.ITTObjectListBox;
    ActiveRoom: TTVisual.ITTObjectListBox;
    ActiveRoomGroup: TTVisual.ITTObjectListBox;
    Bed: TTVisual.ITTListBoxColumn;
    BedAmount: TTVisual.ITTTextBoxColumn;
    BedDischargeDate: TTVisual.ITTDateTimePickerColumn;
    BedInPatientDate: TTVisual.ITTDateTimePickerColumn;
    BedsGrid: TTVisual.ITTGrid;
    BedsTab: TTVisual.ITTTabPage;
    ClinicDischargeDate: TTVisual.ITTDateTimePickerColumn;
    ClinicInpatientDate: TTVisual.ITTDateTimePickerColumn;
    HospitalInpatientDate: TTVisual.ITTDateTimePicker;
    InpatientProcedureInfo: TTVisual.ITTTabPage;
    labelBed: TTVisual.ITTLabel;
    labelHospitalInpatientDate: TTVisual.ITTLabel;
    labelNumberOfEmptyBeds: TTVisual.ITTLabel;
    labelQuarantineProtocolNo: TTVisual.ITTLabel;
    labelReasonForInpatientAdmission: TTVisual.ITTLabel;
    labelRoom: TTVisual.ITTLabel;
    labelRoomGroup: TTVisual.ITTLabel;
    MainTab: TTVisual.ITTTabControl;
    PhysicalStateClinic: TTVisual.ITTObjectListBox;
    QuarantineProtocolNo: TTVisual.ITTTextBox;
    ReasonForInpatientAdmission: TTVisual.ITTTextBox;
    ResponsibleDoctor: TTVisual.ITTListBoxColumn;
    Room: TTVisual.ITTListBoxColumn;
    RoomGroup: TTVisual.ITTListBoxColumn;
    TratmentClinicsGrid: TTVisual.ITTGrid;
    TratmentClinicTab: TTVisual.ITTTabPage;
    TreatmentClinic: TTVisual.ITTListBoxColumn;
    ttlabel4: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    UsedStatus: TTVisual.ITTEnumComboBoxColumn;
    public BedsGridColumns = [];
    public TratmentClinicsGridColumns = [];
    public inPatientAdmissionClinicProcedureViewModel: InPatientAdmissionClinicProcedureViewModel = new InPatientAdmissionClinicProcedureViewModel();
    public get _InpatientAdmission(): InpatientAdmission {
        return this._TTObject as InpatientAdmission;
    }
    private InPatientAdmissionClinicProcedure_DocumentUrl: string = '/api/InpatientAdmissionService/InPatientAdmissionClinicProcedure';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.InPatientAdmissionClinicProcedure_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async TratmentClinicsGrid_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {

    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
    }
    protected async PreScript() {
        super.PreScript();
        //servera taşındı
       this.DropStateButton(InpatientAdmission.InpatientAdmissionStates.Discharged);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InpatientAdmission();
        this.inPatientAdmissionClinicProcedureViewModel = new InPatientAdmissionClinicProcedureViewModel();
        this._ViewModel = this.inPatientAdmissionClinicProcedureViewModel;
        this.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission = this._TTObject as InpatientAdmission;
        this.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission.InPatientTreatmentClinicApplications = new Array<InPatientTreatmentClinicApplication>();
        this.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission.Episode = new Episode();
        this.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission.Episode.BaseBedProcedures = new Array<BaseBedProcedure>();
        this.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission.RoomGroup = new ResRoomGroup();
        this.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission.Room = new ResRoom();
        this.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission.Bed = new ResBed();
        this.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission.PhysicalStateClinic = new ResWard();
    }

    protected loadViewModel() {
        let that = this;

        that.inPatientAdmissionClinicProcedureViewModel = this._ViewModel as InPatientAdmissionClinicProcedureViewModel;
        that._TTObject = this.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission;
        if (this.inPatientAdmissionClinicProcedureViewModel == null)
            this.inPatientAdmissionClinicProcedureViewModel = new InPatientAdmissionClinicProcedureViewModel();
        if (this.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission == null)
            this.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission = new InpatientAdmission();
        that.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission.InPatientTreatmentClinicApplications = that.inPatientAdmissionClinicProcedureViewModel.TratmentClinicsGridGridList;
        for (let detailItem of that.inPatientAdmissionClinicProcedureViewModel.TratmentClinicsGridGridList) {
            let masterResourceObjectID = detailItem["MasterResource"];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.inPatientAdmissionClinicProcedureViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                 if (masterResource) {
                    detailItem.MasterResource = masterResource;
                }
            }
            let procedureDoctorObjectID = detailItem["ProcedureDoctor"];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.inPatientAdmissionClinicProcedureViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                 if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
        }
        let episodeObjectID = that.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.inPatientAdmissionClinicProcedureViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission.Episode = episode;
            }
            if (episode != null) {
                episode.BaseBedProcedures = that.inPatientAdmissionClinicProcedureViewModel.BedsGridGridList;
                for (let detailItem of that.inPatientAdmissionClinicProcedureViewModel.BedsGridGridList) {
                    let roomGroupObjectID = detailItem["RoomGroup"];
                    if (roomGroupObjectID != null && (typeof roomGroupObjectID === 'string')) {
                        let roomGroup = that.inPatientAdmissionClinicProcedureViewModel.ResRoomGroups.find(o => o.ObjectID.toString() === roomGroupObjectID.toString());
                         if (roomGroup) {
                            detailItem.RoomGroup = roomGroup;
                        }
                    }
                    let roomObjectID = detailItem["Room"];
                    if (roomObjectID != null && (typeof roomObjectID === 'string')) {
                        let room = that.inPatientAdmissionClinicProcedureViewModel.ResRooms.find(o => o.ObjectID.toString() === roomObjectID.toString());
                         if (room) {
                            detailItem.Room = room;
                        }
                    }
                    let bedObjectID = detailItem["Bed"];
                    if (bedObjectID != null && (typeof bedObjectID === 'string')) {
                        let bed = that.inPatientAdmissionClinicProcedureViewModel.ResBeds.find(o => o.ObjectID.toString() === bedObjectID.toString());
                         if (bed) {
                            detailItem.Bed = bed;
                        }
                    }
                }
            }
        }
        let roomGroupObjectID = that.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission["RoomGroup"];
        if (roomGroupObjectID != null && (typeof roomGroupObjectID === 'string')) {
            let roomGroup = that.inPatientAdmissionClinicProcedureViewModel.ResRoomGroups.find(o => o.ObjectID.toString() === roomGroupObjectID.toString());
             if (roomGroup) {
                that.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission.RoomGroup = roomGroup;
            }
        }
        let roomObjectID = that.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission["Room"];
        if (roomObjectID != null && (typeof roomObjectID === 'string')) {
            let room = that.inPatientAdmissionClinicProcedureViewModel.ResRooms.find(o => o.ObjectID.toString() === roomObjectID.toString());
             if (room) {
                that.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission.Room = room;
            }
        }
        let bedObjectID = that.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission["Bed"];
        if (bedObjectID != null && (typeof bedObjectID === 'string')) {
            let bed = that.inPatientAdmissionClinicProcedureViewModel.ResBeds.find(o => o.ObjectID.toString() === bedObjectID.toString());
             if (bed) {
                that.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission.Bed = bed;
            }
        }
        let physicalStateClinicObjectID = that.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission["PhysicalStateClinic"];
        if (physicalStateClinicObjectID != null && (typeof physicalStateClinicObjectID === 'string')) {
            let physicalStateClinic = that.inPatientAdmissionClinicProcedureViewModel.ResWards.find(o => o.ObjectID.toString() === physicalStateClinicObjectID.toString());
             if (physicalStateClinic) {
                that.inPatientAdmissionClinicProcedureViewModel._InpatientAdmission.PhysicalStateClinic = physicalStateClinic;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(InPatientAdmissionClinicProcedureViewModel);
  
    }


    public onActiveBedChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.Bed != event) {
                this._InpatientAdmission.Bed = event;
            }
        }
    }

    public onActiveRoomChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.Room != event) {
                this._InpatientAdmission.Room = event;
            }
        }
    }

    public onActiveRoomGroupChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.RoomGroup != event) {
                this._InpatientAdmission.RoomGroup = event;
            }
        }
    }

    public onHospitalInpatientDateChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.HospitalInPatientDate != event) {
                this._InpatientAdmission.HospitalInPatientDate = event;
            }
        }
    }

    public onPhysicalStateClinicChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.PhysicalStateClinic != event) {
                this._InpatientAdmission.PhysicalStateClinic = event;
            }
        }
    }

    public onQuarantineProtocolNoChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.QuarantineProtocolNo != event) {
                this._InpatientAdmission.QuarantineProtocolNo = event;
            }
        }
    }

    public onReasonForInpatientAdmissionChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.ReasonForInpatientAdmission != event) {
                this._InpatientAdmission.ReasonForInpatientAdmission = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ReasonForInpatientAdmission, "Text", this.__ttObject, "ReasonForInpatientAdmission");
        redirectProperty(this.HospitalInpatientDate, "Value", this.__ttObject, "HospitalInPatientDate");
        redirectProperty(this.QuarantineProtocolNo, "Text", this.__ttObject, "QuarantineProtocolNo");
    }

    public initFormControls(): void {
        this.MainTab = new TTVisual.TTTabControl();
        this.MainTab.Name = "MainTab";
        this.MainTab.TabIndex = 10;

        this.BaseNumberOfEmptyBeds = new TTVisual.TTTextBox();
        this.BaseNumberOfEmptyBeds.BackColor = "#F0F0F0";
        this.BaseNumberOfEmptyBeds.ReadOnly = true;
        this.BaseNumberOfEmptyBeds.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BaseNumberOfEmptyBeds.Name = "BaseNumberOfEmptyBeds";
        this.BaseNumberOfEmptyBeds.TabIndex = 2;

        this.InpatientProcedureInfo = new TTVisual.TTTabPage();
        this.InpatientProcedureInfo.DisplayIndex = 0;
        this.InpatientProcedureInfo.TabIndex = 0;
        this.InpatientProcedureInfo.Text = "Hasta Yatış Bilgileri";
        this.InpatientProcedureInfo.Name = "InpatientProcedureInfo";

        this.labelReasonForInpatientAdmission = new TTVisual.TTLabel();
        this.labelReasonForInpatientAdmission.Text = i18n("M24439", "Yatış Sebebi");
        this.labelReasonForInpatientAdmission.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelReasonForInpatientAdmission.ForeColor = "#000000";
        this.labelReasonForInpatientAdmission.Name = "labelReasonForInpatientAdmission";
        this.labelReasonForInpatientAdmission.TabIndex = 0;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 2;

        this.TratmentClinicTab = new TTVisual.TTTabPage();
        this.TratmentClinicTab.DisplayIndex = 0;
        this.TratmentClinicTab.TabIndex = 2;
        this.TratmentClinicTab.Text = i18n("M22988", "Tedavi Gördüğü Klinikler/ Servisler");
        this.TratmentClinicTab.Name = "TratmentClinicTab";
        this.TratmentClinicTab.Enabled = false;

        this.TratmentClinicsGrid = new TTVisual.TTGrid();
        this.TratmentClinicsGrid.ReadOnly = true;
        this.TratmentClinicsGrid.Name = "TratmentClinicsGrid";
        this.TratmentClinicsGrid.TabIndex = 0;
        this.TratmentClinicsGrid.AllowUserToAddRows = false;
        this.TratmentClinicsGrid.AllowUserToDeleteRows = false;
        this.TratmentClinicsGrid.Enabled = false;

        this.TreatmentClinic = new TTVisual.TTListBoxColumn();
        this.TreatmentClinic.ListDefName = "ClinicListDefinition";
        this.TreatmentClinic.DataMember = "MasterResource";
        this.TreatmentClinic.DisplayIndex = 0;
        this.TreatmentClinic.HeaderText = i18n("M22987", "Tedavi Gördüğü Klinik/ Servis");
        this.TreatmentClinic.Name = "TreatmentClinic";
        this.TreatmentClinic.Width = 250;
        this.TreatmentClinic.Enabled = false;

        this.ClinicInpatientDate = new TTVisual.TTDateTimePickerColumn();
        this.ClinicInpatientDate.Format = DateTimePickerFormat.Long;
        this.ClinicInpatientDate.DataMember = "ClinicInpatientDate";
        this.ClinicInpatientDate.DisplayIndex = 1;
        this.ClinicInpatientDate.HeaderText = "Klinik/ Servis Yatış Tarihi";
        this.ClinicInpatientDate.Name = "ClinicInpatientDate";
        this.ClinicInpatientDate.Width = 180;
        this.ClinicInpatientDate.ReadOnly = true;

        this.ClinicDischargeDate = new TTVisual.TTDateTimePickerColumn();
        this.ClinicDischargeDate.Format = DateTimePickerFormat.Long;
        this.ClinicDischargeDate.DataMember = "ClinicDischargeDate";
        this.ClinicDischargeDate.DisplayIndex = 2;
        this.ClinicDischargeDate.HeaderText = i18n("M17662", "Klinik/ Servis Taburcu Tarihi");
        this.ClinicDischargeDate.Name = "ClinicDischargeDate";
        this.ClinicDischargeDate.Width = 180;
        this.ClinicDischargeDate.ReadOnly = true;

        this.ResponsibleDoctor = new TTVisual.TTListBoxColumn();
        this.ResponsibleDoctor.ListDefName = "DoctorListDefinition";
        this.ResponsibleDoctor.DataMember = "ProcedureDoctor";
        this.ResponsibleDoctor.DisplayIndex = 3;
        this.ResponsibleDoctor.HeaderText = i18n("M22158", "Sorumlu Tabip");
        this.ResponsibleDoctor.Name = "ResponsibleDoctor";
        this.ResponsibleDoctor.Width = 200;
        this.ResponsibleDoctor.Enabled = false;



        this.BedsTab = new TTVisual.TTTabPage();
        this.BedsTab.DisplayIndex = 1;
        this.BedsTab.TabIndex = 1;
        this.BedsTab.Text = i18n("M24035", "Vakada Hastanın Yattığı Yataklar");
        this.BedsTab.Name = "BedsTab";

        this.BedsGrid = new TTVisual.TTGrid();
        this.BedsGrid.Enabled = false;
        this.BedsGrid.Name = "BedsGrid";
        this.BedsGrid.TabIndex = 17501;
        this.BedsGrid.AllowUserToAddRows = false;
        this.BedsGrid.AllowUserToDeleteRows = false;

        this.BedInPatientDate = new TTVisual.TTDateTimePickerColumn();
        this.BedInPatientDate.Format = DateTimePickerFormat.Long;
        this.BedInPatientDate.DataMember = "BedInPatientDate";
        this.BedInPatientDate.DisplayIndex = 0;
        this.BedInPatientDate.HeaderText = i18n("M24374", "Yatak Yatış Tarihi");
        this.BedInPatientDate.Name = "BedInPatientDate";
        this.BedInPatientDate.Width = 150;
        this.BedInPatientDate.ReadOnly = true;

        this.BedDischargeDate = new TTVisual.TTDateTimePickerColumn();
        this.BedDischargeDate.Format = DateTimePickerFormat.Long;
        this.BedDischargeDate.DataMember = "BedDischargeDate";
        this.BedDischargeDate.DisplayIndex = 1;
        this.BedDischargeDate.HeaderText = i18n("M24355", "Yatak Çıkış Tarihi");
        this.BedDischargeDate.Name = "BedDischargeDate";
        this.BedDischargeDate.Width = 150;
        this.BedDischargeDate.ReadOnly = true;

        this.RoomGroup = new TTVisual.TTListBoxColumn();
        this.RoomGroup.ListDefName = "RoomGroupListDefinition";
        this.RoomGroup.DataMember = "RoomGroup";
        this.RoomGroup.DisplayIndex = 2;
        this.RoomGroup.HeaderText = i18n("M19609", "Oda Grup");
        this.RoomGroup.Name = "RoomGroup";
        this.RoomGroup.Width = 200;
        this.RoomGroup.Enabled = false;


        this.Room = new TTVisual.TTListBoxColumn();
        this.Room.ListDefName = "RoomListDefinition";
        this.Room.DataMember = "Room";
        this.Room.DisplayIndex = 3;
        this.Room.HeaderText = i18n("M19602", "Oda");
        this.Room.Name = "Room";
        this.Room.Width = 150;
        this.Room.Enabled = false;


        this.Bed = new TTVisual.TTListBoxColumn();
        this.Bed.ListDefName = "BedListDefinition";
        this.Bed.DataMember = "Bed";
        this.Bed.DisplayIndex = 4;
        this.Bed.HeaderText = i18n("M24353", "Yatak");
        this.Bed.Name = "Bed";
        this.Bed.Width = 150;
        this.Bed.Enabled = false;

        this.BedAmount = new TTVisual.TTTextBoxColumn();
        this.BedAmount.DataMember = "Amount";
        this.BedAmount.DisplayIndex = 5;
        this.BedAmount.HeaderText = i18n("M17089", "Kaldığı Gün");
        this.BedAmount.Name = "BedAmount";
        this.BedAmount.Width = 70;
        this.BedAmount.ReadOnly = true;

        this.UsedStatus = new TTVisual.TTEnumComboBoxColumn();
        this.UsedStatus.DataTypeName = "UsedStatusEnum";
        this.UsedStatus.DataMember = "UsedStatus";
        this.UsedStatus.DisplayIndex = 6;
        this.UsedStatus.HeaderText = i18n("M24356", "Yatak Durumu");
        this.UsedStatus.Name = "UsedStatus";
        this.UsedStatus.Width = 100;
        this.UsedStatus.ReadOnly = true;

        this.ReasonForInpatientAdmission = new TTVisual.TTTextBox();
        this.ReasonForInpatientAdmission.Multiline = true;
        this.ReasonForInpatientAdmission.BackColor = "#F0F0F0";
        this.ReasonForInpatientAdmission.ReadOnly = true;
        this.ReasonForInpatientAdmission.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ReasonForInpatientAdmission.Name = "ReasonForInpatientAdmission";
        this.ReasonForInpatientAdmission.TabIndex = 1;
        this.ReasonForInpatientAdmission.Enabled = false;

        this.QuarantineProtocolNo = new TTVisual.TTTextBox();
        this.QuarantineProtocolNo.BackColor = "#F0F0F0";
        this.QuarantineProtocolNo.ReadOnly = true;
        this.QuarantineProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.QuarantineProtocolNo.Name = "QuarantineProtocolNo";
        this.QuarantineProtocolNo.TabIndex = 1;
        this.QuarantineProtocolNo.Enabled = false;

        this.labelRoomGroup = new TTVisual.TTLabel();
        this.labelRoomGroup.Text = i18n("M19605", "Oda Grubu");
        this.labelRoomGroup.BackColor = "#DCDCDC";
        this.labelRoomGroup.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRoomGroup.ForeColor = "#000000";
        this.labelRoomGroup.Name = "labelRoomGroup";
        this.labelRoomGroup.TabIndex = 17511;

        this.ActiveRoomGroup = new TTVisual.TTObjectListBox();
        this.ActiveRoomGroup.ReadOnly = true;
        this.ActiveRoomGroup.ListDefName = "RoomGroupListDefinition";
        this.ActiveRoomGroup.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ActiveRoomGroup.Name = "ActiveRoomGroup";
        this.ActiveRoomGroup.TabIndex = 6;
        this.ActiveRoomGroup.Enabled = false;

        this.labelNumberOfEmptyBeds = new TTVisual.TTLabel();
        this.labelNumberOfEmptyBeds.Text = i18n("M11983", "Boş Yatak Sayısı");
        this.labelNumberOfEmptyBeds.BackColor = "#DCDCDC";
        this.labelNumberOfEmptyBeds.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelNumberOfEmptyBeds.ForeColor = "#000000";
        this.labelNumberOfEmptyBeds.Name = "labelNumberOfEmptyBeds";
        this.labelNumberOfEmptyBeds.TabIndex = 17506;

        this.ActiveRoom = new TTVisual.TTObjectListBox();
        this.ActiveRoom.ReadOnly = true;
        this.ActiveRoom.ListDefName = "RoomListDefinition";
        this.ActiveRoom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ActiveRoom.Name = "ActiveRoom";
        this.ActiveRoom.TabIndex = 8;
        this.ActiveRoom.Enabled = false;

        this.ActiveBed = new TTVisual.TTObjectListBox();
        this.ActiveBed.ReadOnly = true;
        this.ActiveBed.ListDefName = "BedListDefinition";
        this.ActiveBed.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ActiveBed.Name = "ActiveBed";
        this.ActiveBed.TabIndex = 9;
        this.ActiveBed.Enabled = false;

        this.labelQuarantineProtocolNo = new TTVisual.TTLabel();
        this.labelQuarantineProtocolNo.Text = i18n("M23395", "Tıbbi Kayıt Protokol No");
        this.labelQuarantineProtocolNo.BackColor = "#DCDCDC";
        this.labelQuarantineProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelQuarantineProtocolNo.ForeColor = "#000000";
        this.labelQuarantineProtocolNo.Name = "labelQuarantineProtocolNo";
        this.labelQuarantineProtocolNo.TabIndex = 17504;

        this.labelRoom = new TTVisual.TTLabel();
        this.labelRoom.Text = i18n("M19602", "Oda");
        this.labelRoom.BackColor = "#DCDCDC";
        this.labelRoom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRoom.ForeColor = "#000000";
        this.labelRoom.Name = "labelRoom";
        this.labelRoom.TabIndex = 17510;

        this.labelBed = new TTVisual.TTLabel();
        this.labelBed.Text = i18n("M24353", "Yatak");
        this.labelBed.BackColor = "#DCDCDC";
        this.labelBed.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelBed.ForeColor = "#000000";
        this.labelBed.Name = "labelBed";
        this.labelBed.TabIndex = 17509;

        this.HospitalInpatientDate = new TTVisual.TTDateTimePicker();
        this.HospitalInpatientDate.BackColor = "#F0F0F0";
        this.HospitalInpatientDate.CustomFormat = "";
        this.HospitalInpatientDate.Format = DateTimePickerFormat.Long;
        this.HospitalInpatientDate.Enabled = false;
        this.HospitalInpatientDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.HospitalInpatientDate.Name = "HospitalInpatientDate";
        this.HospitalInpatientDate.TabIndex = 0;
        this.HospitalInpatientDate.ReadOnly = true;

        this.labelHospitalInpatientDate = new TTVisual.TTLabel();
        this.labelHospitalInpatientDate.Text = i18n("M15402", "XXXXXX Yatış Tarihi");
        this.labelHospitalInpatientDate.BackColor = "#DCDCDC";
        this.labelHospitalInpatientDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelHospitalInpatientDate.ForeColor = "#000000";
        this.labelHospitalInpatientDate.Name = "labelHospitalInpatientDate";
        this.labelHospitalInpatientDate.TabIndex = 17500;

        this.PhysicalStateClinic = new TTVisual.TTObjectListBox();
        this.PhysicalStateClinic.ReadOnly = true;
        this.PhysicalStateClinic.Enabled = false;
        this.PhysicalStateClinic.ListDefName = "WardListDefinition";
        this.PhysicalStateClinic.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PhysicalStateClinic.Name = "PhysicalStateClinic";
        this.PhysicalStateClinic.TabIndex = 5;
        this.PhysicalStateClinic.Enabled = false;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M24455", "Yattığı  Klinik");
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 25;

        this.TratmentClinicsGridColumns = [this.TreatmentClinic, this.ClinicInpatientDate, this.ClinicDischargeDate, this.ResponsibleDoctor];
        this.BedsGridColumns = [this.BedInPatientDate, this.BedDischargeDate, this.RoomGroup, this.Room, this.Bed, this.BedAmount, this.UsedStatus];
        this.MainTab.Controls = [this.InpatientProcedureInfo];
        this.InpatientProcedureInfo.Controls = [this.labelReasonForInpatientAdmission, this.tttabcontrol1, this.ReasonForInpatientAdmission];
        this.tttabcontrol1.Controls = [this.TratmentClinicTab, this.BedsTab];
        this.TratmentClinicTab.Controls = [this.TratmentClinicsGrid];
        this.BedsTab.Controls = [this.BedsGrid];
        this.Controls = [this.MainTab, this.BaseNumberOfEmptyBeds, this.InpatientProcedureInfo, this.labelReasonForInpatientAdmission, this.tttabcontrol1, this.TratmentClinicTab, this.TratmentClinicsGrid, this.TreatmentClinic, this.ClinicInpatientDate, this.ClinicDischargeDate, this.ResponsibleDoctor, this.BedsTab, this.BedsGrid, this.BedInPatientDate, this.BedDischargeDate, this.RoomGroup, this.Room, this.Bed, this.BedAmount, this.UsedStatus, this.ReasonForInpatientAdmission, this.QuarantineProtocolNo, this.labelRoomGroup, this.ActiveRoomGroup, this.labelNumberOfEmptyBeds, this.ActiveRoom, this.ActiveBed, this.labelQuarantineProtocolNo, this.labelRoom, this.labelBed, this.HospitalInpatientDate, this.labelHospitalInpatientDate, this.PhysicalStateClinic, this.ttlabel4];

    }


}
