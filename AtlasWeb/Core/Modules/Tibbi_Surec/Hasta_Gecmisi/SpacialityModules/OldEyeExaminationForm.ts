//$208382BB
import { Component, OnInit, NgZone } from '@angular/core';
import { OldEyeExaminationFormViewModel } from './OldEyeExaminationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EyeExamination } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'OldEyeExaminationForm',
    templateUrl: './OldEyeExaminationForm.html',
    providers: [MessageService]
})
export class OldEyeExaminationForm extends TTVisual.TTForm implements OnInit {
    public oldEyeExaminationFormViewModel: OldEyeExaminationFormViewModel = new OldEyeExaminationFormViewModel();
    public get _EyeExamination(): EyeExamination {
        return this._TTObject as EyeExamination;
    }
    private OldEyeExaminationForm_DocumentUrl: string = '/api/EyeExaminationService/OldEyeExaminationForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('EYEEXAMINATION', 'OldEyeExaminationForm');
        this._DocumentServiceUrl = this.OldEyeExaminationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new EyeExamination();
        this.oldEyeExaminationFormViewModel = new OldEyeExaminationFormViewModel();
        this._ViewModel = this.oldEyeExaminationFormViewModel;
        this.oldEyeExaminationFormViewModel._EyeExamination = this._TTObject as EyeExamination;
    }

    protected loadViewModel() {
        let that = this;

        that.oldEyeExaminationFormViewModel = this._ViewModel as OldEyeExaminationFormViewModel;
        that._TTObject = this.oldEyeExaminationFormViewModel._EyeExamination;
        if (this.oldEyeExaminationFormViewModel == null)
            this.oldEyeExaminationFormViewModel = new OldEyeExaminationFormViewModel();
        if (this.oldEyeExaminationFormViewModel._EyeExamination == null)
            this.oldEyeExaminationFormViewModel._EyeExamination = new EyeExamination();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OldEyeExaminationFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
