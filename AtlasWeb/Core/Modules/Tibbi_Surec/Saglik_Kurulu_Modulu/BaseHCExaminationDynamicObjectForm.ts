//$482C2DE1
import { Component, OnInit, Output, EventEmitter  } from '@angular/core';
import { BaseHCExaminationDynamicObjectFormViewModel } from './BaseHCExaminationDynamicObjectFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseHCExaminationDynamicObject } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'BaseHCExaminationDynamicObjectForm',
    templateUrl: './BaseHCExaminationDynamicObjectForm.html',
    providers: [MessageService]
})
export class BaseHCExaminationDynamicObjectForm extends TTVisual.TTForm implements OnInit {
    public baseHCExaminationDynamicObjectFormViewModel: BaseHCExaminationDynamicObjectFormViewModel = new BaseHCExaminationDynamicObjectFormViewModel();
    public get _BaseHCExaminationDynamicObject(): BaseHCExaminationDynamicObject {
        return this._TTObject as BaseHCExaminationDynamicObject;
    }
    private BaseHCExaminationDynamicObjectForm_DocumentUrl: string = '/api/BaseHCExaminationDynamicObjectService/BaseHCExaminationDynamicObjectForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('BASEHCEXAMINATIONDYNAMICOBJECT', 'BaseHCExaminationDynamicObjectForm');
        this._DocumentServiceUrl = this.BaseHCExaminationDynamicObjectForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    @Output() sendMyViewModel: EventEmitter<any> = new EventEmitter<any>();

    public sendMyViewModelToEpisodeAction() {
        this.sendMyViewModel.emit(this._ViewModel);
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BaseHCExaminationDynamicObject();
        this.baseHCExaminationDynamicObjectFormViewModel = new BaseHCExaminationDynamicObjectFormViewModel();
        this._ViewModel = this.baseHCExaminationDynamicObjectFormViewModel;
        this.baseHCExaminationDynamicObjectFormViewModel._BaseHCExaminationDynamicObject = this._TTObject as BaseHCExaminationDynamicObject;
    }

    protected loadViewModel() {
        let that = this;
        that.baseHCExaminationDynamicObjectFormViewModel = this._ViewModel as BaseHCExaminationDynamicObjectFormViewModel;
        that._TTObject = this.baseHCExaminationDynamicObjectFormViewModel._BaseHCExaminationDynamicObject;
        if (this.baseHCExaminationDynamicObjectFormViewModel == null)
            this.baseHCExaminationDynamicObjectFormViewModel = new BaseHCExaminationDynamicObjectFormViewModel();
        if (this.baseHCExaminationDynamicObjectFormViewModel._BaseHCExaminationDynamicObject == null)
            this.baseHCExaminationDynamicObjectFormViewModel._BaseHCExaminationDynamicObject = new BaseHCExaminationDynamicObject();

    }

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
