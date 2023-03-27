//$E1853F9C
import { Component, OnInit, Input, Output, EventEmitter, NgZone } from '@angular/core';
import { BaseNursingDataEntryFormViewModel } from './BaseNursingDataEntryFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntry } from 'NebulaClient/Model/AtlasClientModel';
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { NursingApplication } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';



@Component({
    selector: 'BaseNursingDataEntryForm',
    templateUrl: './BaseNursingDataEntryForm.html',
    providers: [MessageService]
})
export class BaseNursingDataEntryForm extends TTVisual.TTForm implements OnInit {
    public baseNursingDataEntryFormViewModel: BaseNursingDataEntryFormViewModel = new BaseNursingDataEntryFormViewModel();
    public get _BaseNursingDataEntry(): BaseNursingDataEntry {
        return this._TTObject as BaseNursingDataEntry;
    }
    private BaseNursingDataEntryForm_DocumentUrl: string = '/api/BaseNursingDataEntryService/BaseNursingDataEntryForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('BASENURSINGDATAENTRY', 'BaseNursingDataEntryForm');
        this._DocumentServiceUrl = this.BaseNursingDataEntryForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public _nursingApplication: NursingApplication;
    @Input() set NursingApplication(value: NursingApplication) {
        this._nursingApplication = value;
        this.ActiveIDsModel = new ActiveIDsModel(this.NursingApplication.ObjectID,this.NursingApplication.Episode.ObjectID,null);
    }
    get NursingApplication() {
        return this._nursingApplication;
    }

    // ***** Method declarations start *****


    @Output() saveEventEmitter: EventEmitter<Guid> = new EventEmitter<Guid>();

    protected async save() {
        this._BaseNursingDataEntry["NursingApplication"] = this.NursingApplication;
        try {
            await super.save();
        }
        catch (err)
        {
            console.log(err.message);
            throw new Exception(err.message);
        }

        console.log("");
    }

    protected async setState(transDef: TTObjectStateTransitionDef, saveInfo?: FormSaveInfo) {
        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M24095", "Veri Silme"), i18n("M21538", "Seçilen Veri Kalıcı Olarak Silinecektir.\nDevam Etmek İstiyor Musunuz ? "), 1);
        if (result === "E")
            await super.setState(transDef, saveInfo);
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        this.saveEventEmitter.emit(this._BaseNursingDataEntry.ObjectID);
    }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
    }

    protected async PreScript(): Promise<void> {
        super.PreScript();
        if (this._nursingApplication.CurrentStateDefID == NursingApplication.NursingApplicationStates.Discharged)
            this.DropStateButton(BaseNursingDataEntry.BaseNursingDataEntryStates.Cancelled);
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BaseNursingDataEntry();
        this.baseNursingDataEntryFormViewModel = new BaseNursingDataEntryFormViewModel();
        this._ViewModel = this.baseNursingDataEntryFormViewModel;
        this.baseNursingDataEntryFormViewModel._BaseNursingDataEntry = this._TTObject as BaseNursingDataEntry;
    }

    protected loadViewModel() {
        let that = this;

        that.baseNursingDataEntryFormViewModel = this._ViewModel as BaseNursingDataEntryFormViewModel;
        that._TTObject = this.baseNursingDataEntryFormViewModel._BaseNursingDataEntry;
        if (this.baseNursingDataEntryFormViewModel == null)
            this.baseNursingDataEntryFormViewModel = new BaseNursingDataEntryFormViewModel();
        if (this.baseNursingDataEntryFormViewModel._BaseNursingDataEntry == null)
            this.baseNursingDataEntryFormViewModel._BaseNursingDataEntry = new BaseNursingDataEntry();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(BaseNursingDataEntryFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
