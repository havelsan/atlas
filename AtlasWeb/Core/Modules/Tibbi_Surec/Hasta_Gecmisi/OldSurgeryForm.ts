//$C0DFFB41
import { Component, OnInit, NgZone } from '@angular/core';
import { OldSurgeryFormViewModel } from './OldSurgeryFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Surgery } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'OldSurgeryForm',
    templateUrl: './OldSurgeryForm.html',
    providers: [MessageService]
})
export class OldSurgeryForm extends TTVisual.TTForm implements OnInit {
    public oldSurgeryFormViewModel: OldSurgeryFormViewModel = new OldSurgeryFormViewModel();
    public get _Surgery(): Surgery {
        return this._TTObject as Surgery;
    }
    private OldSurgeryForm_DocumentUrl: string = '/api/SurgeryService/OldSurgeryForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('SURGERY', 'OldSurgeryForm');
        this._DocumentServiceUrl = this.OldSurgeryForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Surgery();
        this.oldSurgeryFormViewModel = new OldSurgeryFormViewModel();
        this._ViewModel = this.oldSurgeryFormViewModel;
        this.oldSurgeryFormViewModel._Surgery = this._TTObject as Surgery;
    }

    protected loadViewModel() {
        let that = this;

        that.oldSurgeryFormViewModel = this._ViewModel as OldSurgeryFormViewModel;
        that._TTObject = this.oldSurgeryFormViewModel._Surgery;
        if (this.oldSurgeryFormViewModel == null)
            this.oldSurgeryFormViewModel = new OldSurgeryFormViewModel();
        if (this.oldSurgeryFormViewModel._Surgery == null)
            this.oldSurgeryFormViewModel._Surgery = new Surgery();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OldSurgeryFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
