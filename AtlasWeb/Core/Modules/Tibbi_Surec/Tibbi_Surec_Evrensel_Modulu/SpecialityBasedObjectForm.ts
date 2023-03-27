//$3E259E08
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { SpecialityBasedObject } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIDsModel } from '../../../wwwroot/app/Fw/Models/ParameterDefinitionModel';

@Component({
    selector: 'SpecialityBasedObjectForm',
    templateUrl: './SpecialityBasedObjectForm.html',
    providers: [MessageService]
})
export class SpecialityBasedObjectForm extends TTVisual.TTForm implements OnInit {
    // public specialityBasedObjectFormViewModel: SpecialityBasedObjectFormViewModel = new SpecialityBasedObjectFormViewModel();
    public get _SpecialityBasedObject(): SpecialityBasedObject {
        return this._TTObject as SpecialityBasedObject;
    }
    // private SpecialityBasedObjectForm_DocumentUrl: string = '/api/SpecialityBasedObjectService/SpecialityBasedObjectForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("", "");
        // this._DocumentServiceUrl = this.SpecialityBasedObjectForm_DocumentUrl
        //this.initViewModel();
        //  this.initFormControls();
    }

    @Output() sendMyViewModel: EventEmitter<any> = new EventEmitter<any>();

    public sendMyViewModelToEpisodeAction() {
        this.sendMyViewModel.emit(this._ViewModel);
    }
    // ***** Method declarations start *****

    public setInputParam(value: ActiveIDsModel) {
        if (value != null) {
            this.ActiveIDsModel = value;
        }
    }

    // *****Method declarations end *****

    //public initViewModel(): void {
    //    this._TTObject = new SpecialityBasedObject();
    //    this.specialityBasedObjectFormViewModel = new SpecialityBasedObjectFormViewModel();
    //    this._ViewModel = this.specialityBasedObjectFormViewModel;
    //    this.specialityBasedObjectFormViewModel._SpecialityBasedObject = this._TTObject as SpecialityBasedObject;
    //}

    //protected loadViewModel() {
    //    let that = this;
    //    that.specialityBasedObjectFormViewModel = this._ViewModel as SpecialityBasedObjectFormViewModel;
    //    that._TTObject = this.specialityBasedObjectFormViewModel._SpecialityBasedObject;
    //    if (this.specialityBasedObjectFormViewModel == null)
    //        this.specialityBasedObjectFormViewModel = new SpecialityBasedObjectFormViewModel();
    //    if (this.specialityBasedObjectFormViewModel._SpecialityBasedObject == null)
    //        this.specialityBasedObjectFormViewModel._SpecialityBasedObject = new SpecialityBasedObject();

    //}

    async ngOnInit() {
        await this.load();
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


    protected async PreScript() {
        this.sendMyViewModelToEpisodeAction();
    }



}
