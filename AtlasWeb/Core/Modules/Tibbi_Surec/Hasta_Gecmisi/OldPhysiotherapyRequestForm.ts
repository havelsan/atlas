//$FB53895B
import { Component, OnInit  } from '@angular/core';
import { OldPhysiotherapyRequestFormViewModel } from './OldPhysiotherapyRequestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PhysiotherapyRequest } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'OldPhysiotherapyRequestForm',
    templateUrl: './OldPhysiotherapyRequestForm.html',
    providers: [MessageService]
})
export class OldPhysiotherapyRequestForm extends TTVisual.TTForm implements OnInit {
    public oldPhysiotherapyRequestFormViewModel: OldPhysiotherapyRequestFormViewModel = new OldPhysiotherapyRequestFormViewModel();
    public get _PhysiotherapyRequest(): PhysiotherapyRequest {
        return this._TTObject as PhysiotherapyRequest;
    }
    private OldPhysiotherapyRequestForm_DocumentUrl: string = '/api/PhysiotherapyRequestService/OldPhysiotherapyRequestForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('PHYSIOTHERAPYREQUEST', 'OldPhysiotherapyRequestForm');
        this._DocumentServiceUrl = this.OldPhysiotherapyRequestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PhysiotherapyRequest();
        this.oldPhysiotherapyRequestFormViewModel = new OldPhysiotherapyRequestFormViewModel();
        this._ViewModel = this.oldPhysiotherapyRequestFormViewModel;
        this.oldPhysiotherapyRequestFormViewModel._PhysiotherapyRequest = this._TTObject as PhysiotherapyRequest;
    }

    protected loadViewModel() {
        let that = this;
        that.oldPhysiotherapyRequestFormViewModel = this._ViewModel as OldPhysiotherapyRequestFormViewModel;
        that._TTObject = this.oldPhysiotherapyRequestFormViewModel._PhysiotherapyRequest;
        if (this.oldPhysiotherapyRequestFormViewModel == null)
            this.oldPhysiotherapyRequestFormViewModel = new OldPhysiotherapyRequestFormViewModel();
        if (this.oldPhysiotherapyRequestFormViewModel._PhysiotherapyRequest == null)
            this.oldPhysiotherapyRequestFormViewModel._PhysiotherapyRequest = new PhysiotherapyRequest();

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
