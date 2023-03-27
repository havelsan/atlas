//$6C071500
import { Component, OnInit, NgZone } from '@angular/core';
import { OldPsychologyObjectFormViewModel } from './OldPsychologyObjectFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PsychologyBasedObject } from 'NebulaClient/Model/AtlasClientModel';

import { InfoBox } from 'NebulaClient/Visual/InfoBox';

@Component({
    selector: 'OldPsychologyObjectForm',
    templateUrl: './OldPsychologyObjectForm.html',
    providers: [MessageService]
})
export class OldPsychologyObjectForm extends TTVisual.TTForm implements OnInit {
    public oldPsychologyObjectFormViewModel: OldPsychologyObjectFormViewModel = new OldPsychologyObjectFormViewModel();
    public get _PsychologyBasedObject(): PsychologyBasedObject {
        return this._TTObject as PsychologyBasedObject;
    }
    private OldPsychologyObjectForm_DocumentUrl: string = '/api/PsychologyBasedObjectService/OldPsychologyObjectForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('PSYCHOLOGYBASEDOBJECT', 'OldPsychologyObjectForm');
        this._DocumentServiceUrl = this.OldPsychologyObjectForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PsychologyBasedObject();
        this.oldPsychologyObjectFormViewModel = new OldPsychologyObjectFormViewModel();
        this._ViewModel = this.oldPsychologyObjectFormViewModel;
        this.oldPsychologyObjectFormViewModel._PsychologyBasedObject = this._TTObject as PsychologyBasedObject;
    }

    protected loadViewModel() {
        let that = this;

        if (this._ViewModel.IsAuthorized == false) {
            InfoBox.Alert(i18n("M12078", "Bu Hastanın Bilgilerini Görmeye Yetkiniz Yoktur"));
            return;
        }
        that.oldPsychologyObjectFormViewModel = this._ViewModel as OldPsychologyObjectFormViewModel;
        that._TTObject = this.oldPsychologyObjectFormViewModel._PsychologyBasedObject;
        if (this.oldPsychologyObjectFormViewModel == null)
            this.oldPsychologyObjectFormViewModel = new OldPsychologyObjectFormViewModel();
        if (this.oldPsychologyObjectFormViewModel._PsychologyBasedObject == null)
            this.oldPsychologyObjectFormViewModel._PsychologyBasedObject = new PsychologyBasedObject();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OldPsychologyObjectFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
