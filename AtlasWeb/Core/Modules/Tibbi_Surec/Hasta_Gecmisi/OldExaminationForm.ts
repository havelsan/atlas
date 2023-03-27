//$156EB7DE
import { Component, OnInit, NgZone } from '@angular/core';
import { OldExaminationFormViewModel } from './OldExaminationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PatientExamination } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'OldExaminationForm',
    templateUrl: './OldExaminationForm.html',
    providers: [MessageService]
})
export class OldExaminationForm extends TTVisual.TTForm implements OnInit {
    public oldExaminationFormViewModel: OldExaminationFormViewModel = new OldExaminationFormViewModel();
    public get _PatientExamination(): PatientExamination {
        return this._TTObject as PatientExamination;
    }
    private OldExaminationForm_DocumentUrl: string = '/api/PatientExaminationService/OldExaminationForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('PATIENTEXAMINATION', 'OldExaminationForm');
        this._DocumentServiceUrl = this.OldExaminationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PatientExamination();
        this.oldExaminationFormViewModel = new OldExaminationFormViewModel();
        this._ViewModel = this.oldExaminationFormViewModel;
        this.oldExaminationFormViewModel._PatientExamination = this._TTObject as PatientExamination;
    }

    protected loadViewModel() {
        let that = this;

        that.oldExaminationFormViewModel = this._ViewModel as OldExaminationFormViewModel;
        that._TTObject = this.oldExaminationFormViewModel._PatientExamination;
        if (this.oldExaminationFormViewModel == null)
            this.oldExaminationFormViewModel = new OldExaminationFormViewModel();
        if (this.oldExaminationFormViewModel._PatientExamination == null)
            this.oldExaminationFormViewModel._PatientExamination = new PatientExamination();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OldExaminationFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
