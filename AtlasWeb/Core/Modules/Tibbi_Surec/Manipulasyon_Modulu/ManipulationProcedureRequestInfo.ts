//$177203AC
import { Component,  Input, EventEmitter } from '@angular/core';

import { ManipulationProcedureRequestInfoViewModel } from './ManipulationProcedureRequestInfoViewModel';

import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ManipulationProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';



@Component({
    selector: 'ManipulationProcedureRequestInfo',
    templateUrl: './ManipulationProcedureRequestInfo.html',
    providers: [MessageService]
})
export class ManipulationProcedureRequestInfo extends TTVisual.TTForm  {
    Description: TTVisual.ITTTextBox;
    labelDescription: TTVisual.ITTLabel;
    textDescriptionChange: EventEmitter<string> = new EventEmitter<string>();
    public manipulationProcedureRequestInfoViewModel: ManipulationProcedureRequestInfoViewModel = new ManipulationProcedureRequestInfoViewModel();
    public get _ManipulationProcedure(): ManipulationProcedure {
        return this._TTObject as ManipulationProcedure;
    }
    private ManipulationProcedureRequestInfo_DocumentUrl: string = '/api/ManipulationProcedureService/ManipulationProcedureRequestInfo';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('MANIPULATIONPROCEDURE', 'ManipulationProcedureRequestInfo');
        this._DocumentServiceUrl = this.ManipulationProcedureRequestInfo_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    @Input() procedureObjectList: Array<ProcedureDefinition>;


    private _manipulationProcedure: ManipulationProcedure;
    @Input() set manipulationProcedure(value: ManipulationProcedure) {
        this._manipulationProcedure = value;
        if (this.manipulationProcedure != null) {

            this.manipulationProcedureRequestInfoViewModel._ManipulationProcedure = this.manipulationProcedure;

            let procedure = this.procedureObjectList.find(o => o.ObjectID.toString() === this.manipulationProcedure.ProcedureObject.toString());
            if (procedure != null) {
                this.manipulationProcedureRequestInfoViewModel.ProcedureName = procedure.Name;
            }
        }

    }
    get manipulationProcedure(): ManipulationProcedure {
        return this._manipulationProcedure;
    }

    public get textDescription(): string {
        return this.manipulationProcedureRequestInfoViewModel.Description;
    }
    public set textDescription(s: string) {
        this.manipulationProcedureRequestInfoViewModel.Description = s;
        this.textDescriptionChange.emit(s);

    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ManipulationProcedure();
        this.manipulationProcedureRequestInfoViewModel = new ManipulationProcedureRequestInfoViewModel();
        this._ViewModel = this.manipulationProcedureRequestInfoViewModel;
        this.manipulationProcedureRequestInfoViewModel._ManipulationProcedure = this._TTObject as ManipulationProcedure;
    }

    //protected loadViewModel() {
    //    let that = this;
    //    that.manipulationProcedureRequestInfoViewModel = this._ViewModel as ManipulationProcedureRequestInfoViewModel;
    //    that._TTObject = this.manipulationProcedureRequestInfoViewModel._ManipulationProcedure;
    //    if (this.manipulationProcedureRequestInfoViewModel == null)
    //        this.manipulationProcedureRequestInfoViewModel = new ManipulationProcedureRequestInfoViewModel();
    //    if (this.manipulationProcedureRequestInfoViewModel._ManipulationProcedure == null)
    //        this.manipulationProcedureRequestInfoViewModel._ManipulationProcedure = new ManipulationProcedure();

    //}

    //async ngOnInit() {
    //    await this.load();
    //}

    public onDescriptionChanged(event): void {
        if (this._ManipulationProcedure != null && this._ManipulationProcedure.Description != event) {
            this._ManipulationProcedure.Description = event;
            this.manipulationProcedureRequestInfoViewModel._ManipulationProcedure.Description = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = "Ön Bilgi";
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 1;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.Controls = [this.labelDescription, this.Description];

    }

    public async save() {
        try {


            let injector = ServiceLocator.Injector;
            let messageService: MessageService = injector.get(MessageService);
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let neResult = await httpService.postForNeResult(this._DocumentServiceUrl, this._ViewModel);
            //this.showSaveSuccessMessage();
            if (neResult != null) {
                if (neResult.InfoMessage != null) {
                    messageService.showInfo(neResult.InfoMessage);
                }
            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }


    }
}
