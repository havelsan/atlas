//$19F8320B
import { Component, OnInit, NgZone } from '@angular/core';
import { OldManipulationFormViewModel } from './OldManipulationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Manipulation } from 'NebulaClient/Model/AtlasClientModel';

import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
@Component({
    selector: 'OldManipulationForm',
    templateUrl: './OldManipulationForm.html',
    providers: [MessageService]
})
export class OldManipulationForm extends TTVisual.TTForm implements OnInit, IModal {
    public oldManipulationFormViewModel: OldManipulationFormViewModel = new OldManipulationFormViewModel();
    public get _Manipulation(): Manipulation {
        return this._TTObject as Manipulation;
    }
    private OldManipulationForm_DocumentUrl: string = '/api/ManipulationService/OldManipulationForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('MANIPULATION', 'OldManipulationForm');
        this._DocumentServiceUrl = this.OldManipulationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Manipulation();
        this.oldManipulationFormViewModel = new OldManipulationFormViewModel();
        this._ViewModel = this.oldManipulationFormViewModel;
        this.oldManipulationFormViewModel._Manipulation = this._TTObject as Manipulation;
    }

    protected loadViewModel() {
        let that = this;

        that.oldManipulationFormViewModel = this._ViewModel as OldManipulationFormViewModel;
        that._TTObject = this.oldManipulationFormViewModel._Manipulation;
        if (this.oldManipulationFormViewModel == null)
            this.oldManipulationFormViewModel = new OldManipulationFormViewModel();
        if (this.oldManipulationFormViewModel._Manipulation == null)
            this.oldManipulationFormViewModel._Manipulation = new Manipulation();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OldManipulationFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }

 async setInputParam(value: string) {

        if (value != null && value != undefined) {
            this.ObjectID = new Guid(value);
            this.ReadOnly = true;

        }

    }
     private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }
}
