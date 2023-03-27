//$3D0FEB35
import { Component, OnInit, Input  } from '@angular/core';
import { SurgerySummaryFormViewModel } from './SurgerySummaryFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";




@Component({
    selector: 'SurgerySummaryForm',
    templateUrl: './SurgerySummaryForm.html',    providers: [MessageService]
})
export class SurgerySummaryForm extends TTVisual.TTForm implements OnInit {

    DepartmentName: TTVisual.ITTTextBox;
    ResponsibleDoctorName: TTVisual.ITTTextBox;
    SurgeryReport: TTVisual.ITTRichTextBoxControl;


    private SurgerySummaryForm_DocumentUrl: string = '/api/SurgeryService/SurgerySummaryForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("", "SurgerySummaryForm");
        this._DocumentServiceUrl = this.SurgerySummaryForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    private _surgerySummaryFormViewModel: SurgerySummaryFormViewModel;
    @Input() set surgerySummaryFormViewModel(value: SurgerySummaryFormViewModel) {
        this._surgerySummaryFormViewModel = value;
        this._ViewModel = this.surgerySummaryFormViewModel;
        this.loadViewModel();
        this.PreScript();
    }
    get surgerySummaryFormViewModel(): SurgerySummaryFormViewModel {
        return this._surgerySummaryFormViewModel;
    }

    // ***** Method declarations start *****






    // *****Method declarations end *****



    public initViewModel(): void {
        this.surgerySummaryFormViewModel = new SurgerySummaryFormViewModel();
        this._ViewModel = this.surgerySummaryFormViewModel;

    }



    async ngOnInit() {
        await this.load();
    }



    public onSurgeryReportChanged(event): void {
        if (event != null) {
            if (this.surgerySummaryFormViewModel.SurgeryReport != event) {
                this.surgerySummaryFormViewModel.SurgeryReport = event;
            }
        }
    }

    public onDepartmentNameChanged(event): void {
        if (event != null) {
            if (this.DepartmentName != event) {
                this.DepartmentName = event;
            }
        }
    }
    public onResponsibleDoctorNameChanged(event): void {
        if (event != null) {
            if (this.ResponsibleDoctorName != event) {
                this.ResponsibleDoctorName = event;
            }
        }
    }



    protected redirectProperties(): void {

        redirectProperty(this.SurgeryReport, "Rtf", this.__ttObject, "SurgeryReport");
        redirectProperty(this.DepartmentName, "Text", this.__ttObject, "DepartmentName");
        redirectProperty(this.ResponsibleDoctorName, "Text", this.__ttObject, "ResponsibleDoctorName");

    }

    public initFormControls(): void {


        this.DepartmentName = new TTVisual.TTTextBox();
        this.DepartmentName.BackColor = "#F0F0F0";
        this.DepartmentName.ReadOnly = true;
        this.DepartmentName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DepartmentName.Name = "DepartmentName";
        this.DepartmentName.TabIndex = 88;


        this.ResponsibleDoctorName = new TTVisual.TTTextBox();
        this.ResponsibleDoctorName.BackColor = "#F0F0F0";
        this.ResponsibleDoctorName.ReadOnly = true;
        this.ResponsibleDoctorName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ResponsibleDoctorName.Name = "ProtocolNo";
        this.ResponsibleDoctorName.TabIndex = 88;


        this.SurgeryReport = new TTVisual.TTRichTextBoxControl();
        this.SurgeryReport.DisplayText = i18n("M10837", "Ameliyat Raporu");
        this.SurgeryReport.TemplateGroupName = "SURGERYREPORT";
        this.SurgeryReport.BackColor = "#FFFFFF";
        this.SurgeryReport.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryReport.Name = "TabSubaction";
        this.SurgeryReport.TabIndex = 94;
        this.SurgeryReport.ReadOnly = true;


        this.Controls = [this.SurgeryReport, this.ResponsibleDoctorName, this.DepartmentName];

    }


}
