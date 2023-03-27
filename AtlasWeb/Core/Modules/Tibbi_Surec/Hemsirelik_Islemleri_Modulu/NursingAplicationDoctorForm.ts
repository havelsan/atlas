//$6715747E
import { Component, OnInit, Input  } from '@angular/core';
import { NursingAplicationDoctorFormViewModel } from './NursingAplicationDoctorFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { NursingApplication} from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'NursingAplicationDoctorForm',
    templateUrl: './NursingAplicationDoctorForm.html',
    providers: [MessageService]
})
export class NursingAplicationDoctorForm extends TTVisual.TTForm implements OnInit {
    labelWorkListDate: TTVisual.ITTLabel;
    WorkListDate: TTVisual.ITTDateTimePicker;
    public nursingAplicationDoctorFormViewModel: NursingAplicationDoctorFormViewModel = new NursingAplicationDoctorFormViewModel();
    public get _NursingApplication(): NursingApplication {
        return this._TTObject as NursingApplication;
    }
    private NursingAplicationDoctorForm_DocumentUrl: string = '/api/NursingApplicationService/NursingAplicationDoctorForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('NURSINGAPPLICATION', 'NursingAplicationDoctorForm');
        this._DocumentServiceUrl = this.NursingAplicationDoctorForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    //private _patient: string;
    @Input() set _nursingApp(value: NursingApplication) {
        //this.nursingAplicationDoctorFormViewModel._NursingApplication = value;
        this.ObjectID = value.ObjectID;
    }
    get _nursingApp(): NursingApplication {
        return this.nursingAplicationDoctorFormViewModel._NursingApplication;
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NursingApplication();
        this.nursingAplicationDoctorFormViewModel = new NursingAplicationDoctorFormViewModel();
        this._ViewModel = this.nursingAplicationDoctorFormViewModel;
        this.nursingAplicationDoctorFormViewModel._NursingApplication = this._TTObject as NursingApplication;
    }

    protected loadViewModel() {
        let that = this;
        that.nursingAplicationDoctorFormViewModel = this._ViewModel as NursingAplicationDoctorFormViewModel;
        that._TTObject = this.nursingAplicationDoctorFormViewModel._NursingApplication;
        if (this.nursingAplicationDoctorFormViewModel == null)
            this.nursingAplicationDoctorFormViewModel = new NursingAplicationDoctorFormViewModel();
        if (this.nursingAplicationDoctorFormViewModel._NursingApplication == null)
            this.nursingAplicationDoctorFormViewModel._NursingApplication = new NursingApplication();

    }

    async ngOnInit() {
        await this.load();
    }

    public onWorkListDateChanged(event): void {
        if (event != null) {
            if (this._NursingApplication != null && this._NursingApplication.WorkListDate != event) {
                this._NursingApplication.WorkListDate = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.WorkListDate, "Value", this.__ttObject, "WorkListDate");
    }

    public initFormControls(): void {
        this.labelWorkListDate = new TTVisual.TTLabel();
        this.labelWorkListDate.Text = i18n("M16771", "İş Listesi Tarihi");
        this.labelWorkListDate.Name = "labelWorkListDate";
        this.labelWorkListDate.TabIndex = 1;

        this.WorkListDate = new TTVisual.TTDateTimePicker();
        this.WorkListDate.Format = DateTimePickerFormat.Long;
        this.WorkListDate.Name = "WorkListDate";
        this.WorkListDate.TabIndex = 0;

        this.Controls = [this.labelWorkListDate, this.WorkListDate];

    }


}
