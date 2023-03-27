//$C9AEFAD1
import { Component, OnInit, Input, Output, EventEmitter, NgZone } from '@angular/core';
import { BaseMultipleDataEntryFormViewModel } from './BaseMultipleDataEntryFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseMultipleDataEntry } from 'NebulaClient/Model/AtlasClientModel';

import { Exception } from 'NebulaClient/Mscorlib/Exception';

import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { FormSaveInfo } from 'NebulaClient/Mscorlib/FormSaveInfo';


@Component({
    selector: 'BaseMultipleDataEntryForm',
    templateUrl: './BaseMultipleDataEntryForm.html',
    providers: [MessageService]
})
export class BaseMultipleDataEntryForm extends TTVisual.TTForm implements OnInit {
    public baseMultipleDataEntryFormViewModel: BaseMultipleDataEntryFormViewModel = new BaseMultipleDataEntryFormViewModel();
    public get _BaseMultipleDataEntry(): BaseMultipleDataEntry {
        return this._TTObject as BaseMultipleDataEntry;
    }
    private BaseMultipleDataEntryForm_DocumentUrl: string = '/api/BaseMultipleDataEntryService/BaseMultipleDataEntryForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super('BASEMULTIPLEDATAENTRY', 'BaseMultipleDataEntryForm');
        this._DocumentServiceUrl = this.BaseMultipleDataEntryForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private _episodeAction: EpisodeAction;
    @Input() set EpisodeAction(value: EpisodeAction) {
        this._episodeAction = value;
    }
    get EpisodeAction() {
        return this._episodeAction;
    }

    @Output() saveEventEmitter: EventEmitter<Guid> = new EventEmitter<Guid>();

    protected async save() {
        this._BaseMultipleDataEntry["EpisodeAction"] = this.EpisodeAction;
        try {
            await super.save();
        }
        catch (err) {
            console.log(err.message);
            throw new Exception(err.message);
        }

        console.log("");
    }

    protected async setState(transDef: TTObjectStateTransitionDef, saveInfo?: FormSaveInfo) {
        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hay?r", "E,H", "Uyar?", i18n("M24095", "Veri Silme"), "Se?ilen Veri Kal?c? Olarak Silinecektir.\nDevam Etmek ?stiyor Musunuz ? ", 1);
        if (result === "E")
            await super.setState(transDef, saveInfo);
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        this.saveEventEmitter.emit(this._BaseMultipleDataEntry.ObjectID);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BaseMultipleDataEntry();
        this.baseMultipleDataEntryFormViewModel = new BaseMultipleDataEntryFormViewModel();
        this._ViewModel = this.baseMultipleDataEntryFormViewModel;
        this.baseMultipleDataEntryFormViewModel._BaseMultipleDataEntry = this._TTObject as BaseMultipleDataEntry;
    }

    protected loadViewModel() {
        let that = this;
        that.baseMultipleDataEntryFormViewModel = this._ViewModel as BaseMultipleDataEntryFormViewModel;
        that._TTObject = this.baseMultipleDataEntryFormViewModel._BaseMultipleDataEntry;
        if (this.baseMultipleDataEntryFormViewModel == null)
            this.baseMultipleDataEntryFormViewModel = new BaseMultipleDataEntryFormViewModel();
        if (this.baseMultipleDataEntryFormViewModel._BaseMultipleDataEntry == null)
            this.baseMultipleDataEntryFormViewModel._BaseMultipleDataEntry = new BaseMultipleDataEntry();

    }

    async ngOnInit() {
        let that = this;
        await this.load(BaseMultipleDataEntryFormViewModel);
  
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
