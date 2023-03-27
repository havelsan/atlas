//$15FDB559
import { Component, OnInit, NgZone } from '@angular/core';
import { SEPFormViewModel } from "./SEPFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { SubEpisodeProtocol } from 'NebulaClient/Model/AtlasClientModel';



@Component({
    selector: 'SEPForm',
    templateUrl: './SEPForm.html',
    providers: [MessageService]
})
export class SEPForm extends TTVisual.TTForm implements OnInit {
    public sEPFormViewModel: SEPFormViewModel = new SEPFormViewModel();
    public get _SubEpisodeProtocol(): SubEpisodeProtocol {
        return this._TTObject as SubEpisodeProtocol;
    }
    private SEPForm_DocumentUrl: string = '/api/SubEpisodeProtocolService/SEPForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super("SUBEPISODEPROTOCOL", "SEPForm");
        this._DocumentServiceUrl = this.SEPForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SubEpisodeProtocol();
        this.sEPFormViewModel = new SEPFormViewModel();
        this._ViewModel = this.sEPFormViewModel;
        this.sEPFormViewModel._SubEpisodeProtocol = this._TTObject as SubEpisodeProtocol;
    }

    protected loadViewModel() {
        let that = this;
        that.sEPFormViewModel = this._ViewModel as SEPFormViewModel;
        that._TTObject = this.sEPFormViewModel._SubEpisodeProtocol;
        if (this.sEPFormViewModel == null)
            this.sEPFormViewModel = new SEPFormViewModel();
        if (this.sEPFormViewModel._SubEpisodeProtocol == null)
            this.sEPFormViewModel._SubEpisodeProtocol = new SubEpisodeProtocol();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(SEPFormViewModel);
  
    }


    protected redirectProperties(): void {

    }

    public initFormControls(): void {

    }


}
