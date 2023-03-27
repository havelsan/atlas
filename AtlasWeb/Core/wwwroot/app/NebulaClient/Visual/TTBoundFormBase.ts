//$67665D64
import { Output, EventEmitter, ComponentRef, ViewChild, HostListener } from '@angular/core';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { TTFormBase } from './TTFormBase';
import { TTObjectStateTransitionDef } from '../StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { TTObject } from '../StorageManager/InstanceManagement/TTObject';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from '../../Report/Services/AtlasReportService';
import { TTObjectHelper, ObjectIDPropertyName } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectHelper';
import { IHashService } from 'Fw/Services/IHashService';
import { IAuditObjectService, AuditObject } from 'Fw/Services/IAuditObjectService';
import { NeStatePanelComponent } from 'Fw/Components/state-panel.component';
import { FormSaveInfo } from 'NebulaClient/Mscorlib/FormSaveInfo';
import { IHelpService } from 'Fw/Services/IHelpService';
import { helpFormModuleMap } from 'app/help-data';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';

const OriginalValuesPropertyName = 'OriginalValues';
const CurrentStateReportsPropertyName = 'CurrentStateReports';
const OutgoingTransitionsPropertyName = 'OutgoingTransitions';
const UpdatedObjectsPropertyName = 'UpdatedObjects';

export class TTBoundFormBase extends TTFormBase {
    @Output() public ActionExecuted: EventEmitter<any> = new EventEmitter<any>();
    @Output() public ActionFailed: EventEmitter<any> = new EventEmitter<any>();
    @Output() public LoadErrorOccurred: EventEmitter<any> = new EventEmitter<any>();
    @Output() public LoadViewModelCompleted: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild(NeStatePanelComponent) statePanelComponent: NeStatePanelComponent;

    public dynamicComponentRef: ComponentRef<any>;
    public reThrowSetStateException: boolean = false;
    public saveAndCloseCommandVisible: boolean = false;
    public closeWithStateTransition: boolean = false;

    public ActiveIDsModel: ActiveIDsModel;

    public ViewModelHash: string;
    protected __ttObject: TTObject;
    protected get _TTObject(): TTObject {
        return this.__ttObject;
    }

    protected set _TTObject(value: TTObject) {
        this.__ttObject = value;
    }

    private __viewModel: any;
    public get _ViewModel(): any {
        return this.__viewModel;
    }
    public set _ViewModel(value: any) {
        this.__viewModel = value;
    }

    private __documentServiceUrl: string;
    protected get _DocumentServiceUrl(): string {
        return this.__documentServiceUrl;
    }
    protected set _DocumentServiceUrl(value: string) {
        this.__documentServiceUrl = value;
    }

    private calculateHashInternal(object: any): string {
        const hashService = ServiceLocator.Injector.get(IHashService);
        const objectHash = hashService.sha1(object);
        return objectHash;
    }

    protected calculateHash(): string {
        const currentViewModelHash = this.calculateHashInternal(this._ViewModel);
        return currentViewModelHash;
    }

    private getObjectModifiedMemberName(targetObject: any): string {
        if (targetObject['getModifiedMemberName'] instanceof Function) {
            const getModifiedMemberNameFunc = targetObject['getModifiedMemberName'];
            const bindedGetModifiedMemberNameFunc = getModifiedMemberNameFunc.bind(targetObject);
            const modifiedMemberName = bindedGetModifiedMemberNameFunc();
            return modifiedMemberName;
        }
        return null;
    }

    private isViewModelModified(): boolean {
        const viewModel = this.__viewModel;
        if (viewModel != null) {
            const keys = Object.keys(viewModel);
            for (const key of keys) {
                const targetObject = viewModel[key];
                if (targetObject && this.getObjectModifiedMemberName(targetObject) != null) {
                    return true;
                }
                if (targetObject instanceof Array) {
                    const targetArray = targetObject as Array<any>;
                    for (const item of targetArray) {
                        if (item && this.getObjectModifiedMemberName(item) != null) {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    protected isFormModified(): boolean {
        return this.isViewModelModified();
    }

    public isModified(): boolean {
        return this.isFormModified();
    }

    public updateModifiedState(): void {
        this.ViewModelHash = this.calculateHashInternal(this._ViewModel);
    }

    public getFormName(): string {

        if (this.__documentServiceUrl) {
            const serviceUrlParts = this._DocumentServiceUrl.split('/');
            if (serviceUrlParts && serviceUrlParts instanceof Array) {
                const lastPart = serviceUrlParts[serviceUrlParts.length - 1];
                return lastPart;
            }
        }

        if (this._formDefName) {
            return this._formDefName;
        }

        return null;
    }

    @HostListener('window:keydown.f1', ['$event'])
    onKeyDown(event: KeyboardEvent) {
        const formName = this.constructor.name;
        if (formName && helpFormModuleMap.has(formName) === true) {
            const helpFileName = helpFormModuleMap.get(formName);
            const helpService: IHelpService = ServiceLocator.Injector.get(IHelpService);
            helpService.showHelp(helpFileName);
            return false;
        }
    }

    protected AfterContextSavedScript(transDef: TTObjectStateTransitionDef) {
    }

    protected async PreScript() {

    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {

    }
    protected async ClientSidePreScript() {

    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {

    }

    private async _internalSaveForm(transDef: TTObjectStateTransitionDef, saveInfo?: FormSaveInfo) {

        await this.ClientSidePostScript(transDef);
        await this.PostScript(transDef);
        let injector = ServiceLocator.Injector;
        let messageService: MessageService = injector.get(MessageService);
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let neResult = await httpService.postForNeResult(this._DocumentServiceUrl, this._ViewModel);
        if (neResult && neResult.Result) {
            if (neResult.Result.hasOwnProperty(OutgoingTransitionsPropertyName)) {
                this._ViewModel[OutgoingTransitionsPropertyName] = neResult.Result[OutgoingTransitionsPropertyName];
            }
            if (neResult.Result.hasOwnProperty(CurrentStateReportsPropertyName)) {
                this._ViewModel[CurrentStateReportsPropertyName] = neResult.Result[CurrentStateReportsPropertyName];
            }
            if (neResult.Result.hasOwnProperty(UpdatedObjectsPropertyName)) {
                this.updateOriginalValues(this._ViewModel, neResult.Result[UpdatedObjectsPropertyName]);
            }
        }
        if (saveInfo) {
            if(transDef == null){
                transDef =  new TTObjectStateTransitionDef();
            }
            transDef.SaveAndClose = saveInfo.saveAndClose;
        }
        await this.AfterContextSavedScript(transDef);
        if (neResult.IsSuccess === true) {
            this.ViewModelHash = this.calculateHash();
            this.showSaveSuccessMessage();
        }
        if (neResult != null) {
            if (neResult.InfoMessage != null) {
                messageService.showInfo(neResult.InfoMessage);
            }
        }
    }

    protected printStateReports(transDef: TTObjectStateTransitionDef) {

        if (transDef.ReportDefs && transDef.ReportDefs.length > 0) {
            let injector = ServiceLocator.Injector;
            let reportService: AtlasReportService = injector.get(AtlasReportService);

            const objectIdParam = new GuidParam(this.__ttObject['ObjectID']);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };

            for (let reportDef of transDef.ReportDefs) {
                reportService.showReport(reportDef['Name'], reportParameters);
            }
        }
    }

    public async setStateToTransition(saveInfo: FormSaveInfo) {
        await this.setState(saveInfo.transDef, saveInfo);
    }


    protected async setState(transDef: TTObjectStateTransitionDef, saveInfo?: FormSaveInfo) {
        try {
            this._TTObject.CurrentStateDefID = transDef.ToStateDefID;
            await this._internalSaveForm(transDef, saveInfo);
            transDef.IsSave = true;
            transDef.SaveAndClose = true;
            this.ActionExecuted.emit(transDef);
            this.triggerSaveCompleted(saveInfo);
            this.printStateReports(transDef);
        } catch (err) {
            this.triggerSaveCompleted(saveInfo);
            this._TTObject.CurrentStateDefID = this._TTObject.PreviousStateDefID;
            ServiceLocator.MessageService.showError(err);
            this.ActionFailed.emit(err);
            if (this.reThrowSetStateException) {
                throw err;
            }
        }
    }

    protected showSaveSuccessMessage(): void {
        ServiceLocator.MessageService.showInfo(i18n('M16829', 'İşlem başarılı olarak kaydedildi.'));
    }

    public async saveForm(saveInfo: FormSaveInfo) {
        await this.save(saveInfo);
    }

    private triggerSaveCompleted(saveInfo?: FormSaveInfo): void {
        if (this.statePanelComponent) {
            this.statePanelComponent.loadingVisible = false;
        }
        if (saveInfo && saveInfo.saveCompleted) {
            saveInfo.saveCompleted.next({});
            saveInfo.saveCompleted.complete();
        }
    }

    protected async save(saveInfo?: FormSaveInfo) {
        try {

            await this._internalSaveForm(null, saveInfo);
            const actionExecutedEventParam = { IsSave: true, SaveAndClose: saveInfo ? saveInfo.saveAndClose : false };
            this.ActionExecuted.emit(actionExecutedEventParam);
            this.triggerSaveCompleted(saveInfo);
        } catch (err) {
            this.triggerSaveCompleted(saveInfo);
            ServiceLocator.MessageService.showError(err);
            this.ActionFailed.emit(err);
            throw err;
        }
    }

    public cancel() {
        this.ActionExecuted.emit({ Cancelled: true });
    }

    protected loadViewModel() {

    }

    protected redirectProperties() {

    }

    protected getParentObjectID(): Guid {
        return null;
    }

    protected loadErrorOccurred(err: any) {

    }

    protected isLoadViewModel(): boolean {
        return true;
    }

    public makeStatePanelReadOnly(): void {
        if (this.statePanelComponent) {
            this.statePanelComponent.StateCommandsVisible = false;
            this.statePanelComponent.SaveCommandVisible = false;
            this.statePanelComponent.PrintCommandVisible = true;
            this.statePanelComponent.CancelCommandVisible = true;
        }
    }

    protected processReadOnly(): void {
        let baseViewModel = this._ViewModel as BaseViewModel;
        if (this._ViewModel.hasOwnProperty('ReadOnly')) {
            if (baseViewModel.ReadOnly === true) {
                this.ReadOnly = baseViewModel.ReadOnly;
            }
        }
        if (this._ViewModel.hasOwnProperty('ReadOnlyFields')) {
            if (baseViewModel.ReadOnlyFields != null) {
                for (let readOnlyField of baseViewModel.ReadOnlyFields) {
                    let control = this.Controls.find(c => c.Name === readOnlyField);
                    if (control != null) {
                        control.ReadOnly = true;
                    }
                }
            }
        }
    }

    protected async _loadInternal<T>(targetType?: { new(): T }, alternateURL?: string) {
        let url = this._DocumentServiceUrl;
        if (alternateURL) {
            url = alternateURL;
        }

        if (this.isLoadViewModel()) {
            if (this.ActiveIDsModel != null) {

                const fullApiUrl = `${url}Load`;
                const httpService: NeHttpService = ServiceLocator.NeHttpService;
                const input = { Id: this.ObjectID === null ? Guid.Empty : this.ObjectID, Model: this.ActiveIDsModel };
                const response = await httpService.post<T>(fullApiUrl, input, targetType);
                this._ViewModel = response;

            } else {

                let fullApiUrl = '';
                if (this.ObjectID != null) {
                    fullApiUrl = url + '/' + this.ObjectID;
                } else {
                    fullApiUrl = `${url}/${Guid.Empty}`;
                }

                let httpService: NeHttpService = ServiceLocator.NeHttpService;
                let response = await httpService.get<T>(fullApiUrl, targetType);
                this._ViewModel = response;

            }


            this.loadViewModel();
            this.processReadOnly();
            this.redirectProperties();
        }

        await this.ClientSidePreScript();
        await this.PreScript();

        this.AddAuditObjectID();

        this.ViewModelHash = this.calculateHash();
    }


    protected AddAuditObjectID(clearAll: boolean = true) {
        if (this.ObjectID !== undefined) {
            const auditService: IAuditObjectService = ServiceLocator.Injector.get(IAuditObjectService);
            if (clearAll === true) {
                auditService.ObjectIDList.Clear();
            }
            let auditObject: AuditObject = new AuditObject;
            auditObject.AuditObjectID = this.ObjectID;
            auditObject.AuditObjectDefID = this._TTObject.ObjectDefID;
            auditService.ObjectIDList.push(auditObject);
        }
    }


    protected async load<T>(targetType?: { new(): T }, alternateURL?: string) {
        try {
            await this._loadInternal(targetType, alternateURL);
            this.signalLoadCompleted();
            this.LoadViewModelCompleted.emit(this._ViewModel);
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
            this.loadErrorOccurred(err);
            this.LoadErrorOccurred.emit(err);
            throw err;
        }
    }

    protected async unload() {
        const auditService = ServiceLocator.Injector.get(IAuditObjectService);
        let auditObject: AuditObject = auditService.ObjectIDList.find(o => o.AuditObjectID.toString() === this.ObjectID.toString());
        let itemIndex = auditService.ObjectIDList.indexOf(auditObject);
        if (itemIndex > -1) {
            auditService.ObjectIDList.splice(itemIndex, 1);
        }
    }

    private getKeys(object: Object): string[] {
        let keys: any[] = [];
        if (object instanceof Map) {
            keys = Array.from(object.keys());
        } else {
            keys = Object.keys(object);
        }
        return keys;
    }

    private findTTObjects(source: any, objectCache: Map<string, any>): void {

        if (TTObjectHelper.isTTObjectFromProperty(source)) {
            const destTTObject = source;
            const objectID = destTTObject[ObjectIDPropertyName];
            const sourceTTObject = objectCache.get(objectID);
            if (sourceTTObject) {
                const newOriginalValues: any = Object.create(Object.prototype);
                Object.assign(newOriginalValues, sourceTTObject, sourceTTObject.OriginalValues);
                delete newOriginalValues.OriginalValues;
                destTTObject.OriginalValues = newOriginalValues;
            }
        } else {
            const isArray = (Object.prototype.toString.call(source) === '[object Array]');
            if (isArray) {
                const array = source as Array<any>;
                for (let item of array) {
                    this.findTTObjects(item, objectCache);
                }
            } else if (source instanceof Object) {
                const keys = this.getKeys(source);
                for (let key of keys) {
                    if (key === OriginalValuesPropertyName) {
                        continue;
                    }
                    const propertyValue = source[key];
                    if (propertyValue instanceof Object) {
                        this.findTTObjects(propertyValue, objectCache);
                    }
                }
            }
        }
    }

    private updateOriginalValues(viewModel: any, sourceTTObjects: Array<any>) {
        if (sourceTTObjects && sourceTTObjects.length === 0) {
            return;
        }

        const objectCache: Map<string, any> = new Map<string, any>();
        for (const ttobject of sourceTTObjects) {
            const objectID = ttobject[ObjectIDPropertyName];
            if (objectID) {
                objectCache.set(objectID, ttobject);
            }
        }

        this.findTTObjects(viewModel, objectCache);
    }

}
