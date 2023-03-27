//$EC67CDCD
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ManipulationFormBaseObject } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'ManipulationFormBaseObjectForm',
    templateUrl: './ManipulationFormBaseObjectForm.html',
    providers: [MessageService]
})
export class ManipulationFormBaseObjectForm extends TTVisual.TTForm implements OnInit {
    public get _ManipulationFormBaseObject(): ManipulationFormBaseObject {
        return this._TTObject as ManipulationFormBaseObject;
    }
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("", "");
    }

    @Output() sendMyViewModel: EventEmitter<any> = new EventEmitter<any>();
    public sendMyViewModelToEpisodeAction() {
        this.sendMyViewModel.emit(this._ViewModel);
    }
    // ***** Method declarations start *****


    // *****Method declarations end *****


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
