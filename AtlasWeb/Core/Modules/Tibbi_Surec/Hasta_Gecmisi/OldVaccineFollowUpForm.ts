//$4C210554
import { Component, OnInit, NgZone } from '@angular/core';
import { OldVaccineFollowUpFormViewModel } from './OldVaccineFollowUpFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { VaccineFollowUp } from 'NebulaClient/Model/AtlasClientModel';
import { VaccineDetails } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'OldVaccineFollowUpForm',
    templateUrl: './OldVaccineFollowUpForm.html',
    providers: [MessageService]
})
export class OldVaccineFollowUpForm extends TTVisual.TTForm implements OnInit {
    ApplicationDateVaccineDetails: TTVisual.ITTDateTimePickerColumn;
    AppointmentDateVaccineDetails: TTVisual.ITTDateTimePickerColumn;
    NotesVaccineDetails: TTVisual.ITTTextBoxColumn;
    PeriodNameVaccineDetails: TTVisual.ITTTextBoxColumn;
    PeriodRangeVaccineDetails: TTVisual.ITTTextBoxColumn;
    PeriodUnitVaccineDetails: TTVisual.ITTEnumComboBoxColumn;
    VaccineDetails: TTVisual.ITTGrid;
    VaccineNameVaccineDetails: TTVisual.ITTTextBoxColumn;
    public VaccineDetailsColumns = [];
    public oldVaccineFollowUpFormViewModel: OldVaccineFollowUpFormViewModel = new OldVaccineFollowUpFormViewModel();
    public get _VaccineFollowUp(): VaccineFollowUp {
        return this._TTObject as VaccineFollowUp;
    }
    private OldVaccineFollowUpForm_DocumentUrl: string = '/api/VaccineFollowUpService/OldVaccineFollowUpForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('VACCINEFOLLOWUP', 'OldVaccineFollowUpForm');
        this._DocumentServiceUrl = this.OldVaccineFollowUpForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new VaccineFollowUp();
        this.oldVaccineFollowUpFormViewModel = new OldVaccineFollowUpFormViewModel();
        this._ViewModel = this.oldVaccineFollowUpFormViewModel;
        this.oldVaccineFollowUpFormViewModel._VaccineFollowUp = this._TTObject as VaccineFollowUp;
        this.oldVaccineFollowUpFormViewModel._VaccineFollowUp.VaccineDetails = new Array<VaccineDetails>();
    }

    protected loadViewModel() {
        let that = this;

        that.oldVaccineFollowUpFormViewModel = this._ViewModel as OldVaccineFollowUpFormViewModel;
        that._TTObject = this.oldVaccineFollowUpFormViewModel._VaccineFollowUp;
        if (this.oldVaccineFollowUpFormViewModel == null)
            this.oldVaccineFollowUpFormViewModel = new OldVaccineFollowUpFormViewModel();
        if (this.oldVaccineFollowUpFormViewModel._VaccineFollowUp == null)
            this.oldVaccineFollowUpFormViewModel._VaccineFollowUp = new VaccineFollowUp();
        that.oldVaccineFollowUpFormViewModel._VaccineFollowUp.VaccineDetails = that.oldVaccineFollowUpFormViewModel.VaccineDetailsGridList;
        for (let detailItem of that.oldVaccineFollowUpFormViewModel.VaccineDetailsGridList) {
        }

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OldVaccineFollowUpFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.VaccineDetails = new TTVisual.TTGrid();
        this.VaccineDetails.Name = "VaccineDetails";
        this.VaccineDetails.TabIndex = 0;

        this.VaccineNameVaccineDetails = new TTVisual.TTTextBoxColumn();
        this.VaccineNameVaccineDetails.DataMember = "VaccineName";
        this.VaccineNameVaccineDetails.DisplayIndex = 0;
        this.VaccineNameVaccineDetails.HeaderText = i18n("M11196", "Aşı Adı");
        this.VaccineNameVaccineDetails.Name = "VaccineNameVaccineDetails";
        this.VaccineNameVaccineDetails.ReadOnly = true;
        this.VaccineNameVaccineDetails.Width = 150;

        this.PeriodNameVaccineDetails = new TTVisual.TTTextBoxColumn();
        this.PeriodNameVaccineDetails.DataMember = "PeriodName";
        this.PeriodNameVaccineDetails.DisplayIndex = 1;
        this.PeriodNameVaccineDetails.HeaderText = i18n("M20309", "Periyod Adı");
        this.PeriodNameVaccineDetails.Name = "PeriodNameVaccineDetails";
        this.PeriodNameVaccineDetails.ReadOnly = true;
        this.PeriodNameVaccineDetails.Width = 150;

        this.PeriodRangeVaccineDetails = new TTVisual.TTTextBoxColumn();
        this.PeriodRangeVaccineDetails.DataMember = "PeriodRange";
        this.PeriodRangeVaccineDetails.DisplayIndex = 2;
        this.PeriodRangeVaccineDetails.HeaderText = i18n("M20314", "Periyod Süresi");
        this.PeriodRangeVaccineDetails.Name = "PeriodRangeVaccineDetails";
        this.PeriodRangeVaccineDetails.Width = 80;

        this.PeriodUnitVaccineDetails = new TTVisual.TTEnumComboBoxColumn();
        this.PeriodUnitVaccineDetails.DataTypeName = "PeriodUnitTypeEnum";
        this.PeriodUnitVaccineDetails.DataMember = "PeriodUnit";
        this.PeriodUnitVaccineDetails.DisplayIndex = 3;
        this.PeriodUnitVaccineDetails.HeaderText = "Birim";
        this.PeriodUnitVaccineDetails.Name = "PeriodUnitVaccineDetails";
        this.PeriodUnitVaccineDetails.Width = 80;

        this.AppointmentDateVaccineDetails = new TTVisual.TTDateTimePickerColumn();
        this.AppointmentDateVaccineDetails.DataMember = "AppointmentDate";
        this.AppointmentDateVaccineDetails.DisplayIndex = 4;
        this.AppointmentDateVaccineDetails.HeaderText = i18n("M20740", "Randevu Tarihi");
        this.AppointmentDateVaccineDetails.Name = "AppointmentDateVaccineDetails";
        this.AppointmentDateVaccineDetails.Width = 180;

        this.ApplicationDateVaccineDetails = new TTVisual.TTDateTimePickerColumn();
        this.ApplicationDateVaccineDetails.DataMember = "ApplicationDate";
        this.ApplicationDateVaccineDetails.DisplayIndex = 5;
        this.ApplicationDateVaccineDetails.HeaderText = i18n("M23763", "Uygulama Tarihi");
        this.ApplicationDateVaccineDetails.Name = "ApplicationDateVaccineDetails";
        this.ApplicationDateVaccineDetails.Width = 180;

        this.NotesVaccineDetails = new TTVisual.TTTextBoxColumn();
        this.NotesVaccineDetails.DataMember = "Notes";
        this.NotesVaccineDetails.DisplayIndex = 6;
        this.NotesVaccineDetails.HeaderText = i18n("M19476", "Not");
        this.NotesVaccineDetails.Name = "NotesVaccineDetails";
        this.NotesVaccineDetails.Width = 150;

        this.VaccineDetailsColumns = [this.VaccineNameVaccineDetails, this.PeriodNameVaccineDetails, this.PeriodRangeVaccineDetails, this.PeriodUnitVaccineDetails, this.AppointmentDateVaccineDetails, this.ApplicationDateVaccineDetails, this.NotesVaccineDetails];
        this.Controls = [this.VaccineDetails, this.VaccineNameVaccineDetails, this.PeriodNameVaccineDetails, this.PeriodRangeVaccineDetails, this.PeriodUnitVaccineDetails, this.AppointmentDateVaccineDetails, this.ApplicationDateVaccineDetails, this.NotesVaccineDetails];

    }


}
