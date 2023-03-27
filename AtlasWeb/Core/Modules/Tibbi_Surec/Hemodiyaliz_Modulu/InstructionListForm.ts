//$52DDA664
import { Component, ViewChild, OnInit, ApplicationRef, NgZone, EventEmitter, Output} from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { InstructionListFormViewModel } from './InstructionListFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { HemodialysisInstruction } from 'NebulaClient/Model/AtlasClientModel';

import { Guid } from '../../../wwwroot/app/NebulaClient/Mscorlib/Guid';

@Component({
    selector: 'InstructionListForm',
    templateUrl: './InstructionListForm.html',
    providers: [MessageService]
})
export class InstructionListForm extends TTVisual.TTForm implements OnInit {
    public instructionListFormViewModel: InstructionListFormViewModel = new InstructionListFormViewModel();
    public get _HemodialysisInstruction(): HemodialysisInstruction {
        return this._TTObject as HemodialysisInstruction;
    }
    private InstructionListForm_DocumentUrl: string = '/api/HemodialysisInstructionService/InstructionListForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('HEMODIALYSISINSTRUCTION', 'InstructionListForm');
        this._DocumentServiceUrl = this.InstructionListForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    //
    @Output() multipleDataComponentSavedEventEmitter: EventEmitter<Guid> = new EventEmitter<Guid>();

    public multipleDataComponentSaved(event: any) {
        //this.multipleDataComponentSavedEventEmitter.emit(event); NIDA BAK ?ALI?ACAK MI
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new HemodialysisInstruction();
        this.instructionListFormViewModel = new InstructionListFormViewModel();
        this._ViewModel = this.instructionListFormViewModel;
        this.instructionListFormViewModel._HemodialysisInstruction = this._TTObject as HemodialysisInstruction;
    }

    protected loadViewModel() {
        let that = this;
        that.instructionListFormViewModel = this._ViewModel as InstructionListFormViewModel;
        that._TTObject = this.instructionListFormViewModel._HemodialysisInstruction;
        if (this.instructionListFormViewModel == null)
            this.instructionListFormViewModel = new InstructionListFormViewModel();
        if (this.instructionListFormViewModel._HemodialysisInstruction == null)
            this.instructionListFormViewModel._HemodialysisInstruction = new HemodialysisInstruction();
    }


    async ngOnInit() {
        await this.load();
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
