//$E61F518C
import { Component, OnInit, NgZone } from '@angular/core';
import { OldEmergencyFormViewModel } from './OldEmergencyFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EmergencySpecialityObject } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'OldEmergencyForm',
    templateUrl: './OldEmergencyForm.html',
    providers: [MessageService]
})
export class OldEmergencyForm extends TTVisual.TTForm implements OnInit {
    public oldEmergencyFormViewModel: OldEmergencyFormViewModel = new OldEmergencyFormViewModel();
    public get _EmergencySpecialityObject(): EmergencySpecialityObject {
        return this._TTObject as EmergencySpecialityObject;
    }
    private OldEmergencyForm_DocumentUrl: string = '/api/EmergencySpecialityObjectService/OldEmergencyForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('EMERGENCYSPECIALITYOBJECT', 'OldEmergencyForm');
        this._DocumentServiceUrl = this.OldEmergencyForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new EmergencySpecialityObject();
        this.oldEmergencyFormViewModel = new OldEmergencyFormViewModel();
        this._ViewModel = this.oldEmergencyFormViewModel;
        this.oldEmergencyFormViewModel._EmergencySpecialityObject = this._TTObject as EmergencySpecialityObject;
    }

    protected loadViewModel() {
        let that = this;

        that.oldEmergencyFormViewModel = this._ViewModel as OldEmergencyFormViewModel;
        that._TTObject = this.oldEmergencyFormViewModel._EmergencySpecialityObject;
        if (this.oldEmergencyFormViewModel == null)
            this.oldEmergencyFormViewModel = new OldEmergencyFormViewModel();
        if (this.oldEmergencyFormViewModel._EmergencySpecialityObject == null)
            this.oldEmergencyFormViewModel._EmergencySpecialityObject = new EmergencySpecialityObject();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OldEmergencyFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
