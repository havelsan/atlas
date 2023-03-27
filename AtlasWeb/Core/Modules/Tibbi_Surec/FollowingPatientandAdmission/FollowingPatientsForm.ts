//$ED817D8E
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { FollowingPatientsFormViewModel } from './FollowingPatientsFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { FollowingPatients } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'FollowingPatientsForm',
    templateUrl: './FollowingPatientsForm.html',
    providers: [MessageService]
})
export class FollowingPatientsForm extends TTVisual.TTForm implements OnInit {
    Follower: TTVisual.ITTTextBox;
    labelFollower: TTVisual.ITTLabel;
    public followingPatientsFormViewModel: FollowingPatientsFormViewModel = new FollowingPatientsFormViewModel();
    public get _FollowingPatients(): FollowingPatients {
        return this._TTObject as FollowingPatients;
    }
    private FollowingPatientsForm_DocumentUrl: string = '/api/FollowingPatientsService/FollowingPatientsForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('FOLLOWINGPATIENTS', 'FollowingPatientsForm');
        this._DocumentServiceUrl = this.FollowingPatientsForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new FollowingPatients();
        this.followingPatientsFormViewModel = new FollowingPatientsFormViewModel();
        this._ViewModel = this.followingPatientsFormViewModel;
        this.followingPatientsFormViewModel._FollowingPatients = this._TTObject as FollowingPatients;
    }

    protected loadViewModel() {
        let that = this;
        that.followingPatientsFormViewModel = this._ViewModel as FollowingPatientsFormViewModel;
        that._TTObject = this.followingPatientsFormViewModel._FollowingPatients;
        if (this.followingPatientsFormViewModel == null)
            this.followingPatientsFormViewModel = new FollowingPatientsFormViewModel();
        if (this.followingPatientsFormViewModel._FollowingPatients == null)
            this.followingPatientsFormViewModel._FollowingPatients = new FollowingPatients();

    }

    async ngOnInit() {
        await this.load();
    }

    public onFollowerChanged(event): void {
        if (this._FollowingPatients != null && this._FollowingPatients.Follower != event) {
            this._FollowingPatients.Follower = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Follower, "Text", this.__ttObject, "Follower");
    }

    public initFormControls(): void {
        this.labelFollower = new TTVisual.TTLabel();
        this.labelFollower.Text = "Takip Eden";
        this.labelFollower.Name = "labelFollower";
        this.labelFollower.TabIndex = 1;

        this.Follower = new TTVisual.TTTextBox();
        this.Follower.Name = "Follower";
        this.Follower.TabIndex = 0;

        this.Controls = [this.labelFollower, this.Follower];

    }


}
