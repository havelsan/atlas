//$741875C0
import { Component, OnInit, ComponentRef, Input, Output, EventEmitter } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { QueryParams } from '../../QueryList/Models/QueryParams';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { TTBoundFormBase } from 'NebulaClient/Visual/TTBoundFormBase';
import { TTFormBase } from 'NebulaClient/Visual/TTFormBase';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

@Component({
    selector: 'atlas-form-editor',
    template: `
     <div class="panel panel-info" *ngIf="OpenComponentByAddButton">
    <div class="panel-heading">{{Title}}
    <a *ngIf="!_isComponentOpened && HideAddButton != true" (click)="btnAdd_valueChange()"><i class="glyphicon glyphicon-plus right-float" style="cursor:pointer"></i></a>
    <a *ngIf="_isComponentOpened" (click)="btnRefresh_valueChange()"><i class="fa fa-refresh right-float" style="cursor:pointer"></i></a>
    </div>
    <div class="panel-body">
        <div *ngIf="_isComponentOpened" [style.padding]="editorPadding">
            <comp-compose [Info]="ComponentInfo"
                          [DestroyComponentOnSave]="DestroyComponentOnSave"
                          (ComponentCreated)="editorComponentCreated($event)"
                          (DynamicComponentClosed)="dynamicComponentClosed()"
                          (DynamicComponentActionExecuted)="dynamicComponentActionExecuted($event)"></comp-compose>
        </div>
        <div style="height: 100%" class="atlas-query-list-component">
            <atlas-query-list-component [QueryParameters]="QueryParameters"
                                        (onSelectedItemChanged)="selectionChanged($event)"
                                        (QueryResultLoaded)="queryResultLoaded($event)"
                                        (QueryExecutionCompleted)="queryExecutionCompleted($event)"></atlas-query-list-component>
        </div>
    </div>
</div>
<div *ngIf="!OpenComponentByAddButton">
    <div class="row"><a (click)="btnRefresh_valueChange()"><i class="fa fa-refresh right-float" style="cursor:pointer"></i></a></div>
    <div *ngIf="_isComponentOpened" [style.padding]="editorPadding">
        <comp-compose [Info]="ComponentInfo"
                      [DestroyComponentOnSave]="DestroyComponentOnSave"
                      (ComponentCreated)="editorComponentCreated($event)"
                      (DynamicComponentClosed)="dynamicComponentClosed()"
                      (DynamicComponentActionExecuted)="dynamicComponentActionExecuted($event)"></comp-compose>
    </div>
    <div style="height: 100%" class="atlas-query-list-component">
        <atlas-query-list-component [QueryParameters]="QueryParameters"
                                    (onSelectedItemChanged)="selectionChanged($event)"
                                    (QueryResultLoaded)="queryResultLoaded($event)"
                                    (QueryExecutionCompleted)="queryExecutionCompleted($event)"></atlas-query-list-component>
    </div>
</div>
    `,
})
export class FormEditorComponent implements OnInit {

    private _queryParameters: QueryParams;
    private _selectedItem: any;
    private _componentInfo: DynamicComponentInfo;
    private _formEditorInstance: any;
    private formDataPropertyName = i18n("M14463", "FormData");
    private  _isComponentOpened: boolean = true;
    @Input() editorPadding: string = '10px';
    @Input() DestroyComponentOnSave: boolean = true;
    @Input() OpenComponentByAddButton: boolean = false;
    @Input() HideAddButton: boolean = false;
    @Input() Title: string = '';
    @Output() FormSaved: EventEmitter<TTBoundFormBase> = new EventEmitter<TTBoundFormBase>();

    @Output() ComponentOpenedOrClosed: EventEmitter<Boolean> = new EventEmitter<Boolean>();

    set IsComponentOpened(value: boolean) {
        this._isComponentOpened = value;
        this.ComponentOpenedOrClosed.emit(value);
    }
    get IsComponentOpened(): boolean {
        return this._isComponentOpened;
    }

    private _saveForm: boolean = false;
    @Input() set SaveForm(value: boolean) {
        this._saveForm = value;
        if (value) {
            if (this._formEditorInstance instanceof TTBoundFormBase) {
                let boundForm = this._formEditorInstance as TTBoundFormBase;
                if (boundForm != null) {
                    (<any>boundForm).save();
                    this.FormSaved.emit(boundForm);
                }
            }
        }
    }

    get SaveForm(): boolean {
        return this._saveForm;
    }

    @Input() set QueryParameters(value: QueryParams) {
        this._queryParameters = value;
    }
    get QueryParameters() {
        return this._queryParameters;
    }

    @Input() set ComponentInfo(value: DynamicComponentInfo) {
        this._componentInfo = value;
    }

    get ComponentInfo(): DynamicComponentInfo {
        return this._componentInfo;
    }

    @Output() QueryResultLoaded: EventEmitter<any> = new EventEmitter<any>();
    @Output() QueryExecutionCompleted: EventEmitter<boolean> = new EventEmitter<boolean>();

    constructor(private http: NeHttpService) {
        this._queryParameters = new QueryParams();
    }

    ngOnInit() {
        if (this.OpenComponentByAddButton) {
            this._isComponentOpened = false;
            this.DestroyComponentOnSave = true; // E�er Butonla ekleniyorsa kaydetde  her zaman Destroy edilmeli
        } else {
            this._isComponentOpened = true;
        }

    }

    selectionChanged(e: any) {
        this._selectedItem = e;
        if (this.OpenComponentByAddButton) {
            this._isComponentOpened = true;
        }
        this.loadSelectedItem();
        //if (this._formEditorInstance != null) {
        //    if (this._formEditorInstance.hasOwnProperty(this.formDataPropertyName)) {
        //        this._formEditorInstance[this.formDataPropertyName] = this._selectedItem;
        //    }
        //}
        //if (this._formEditorInstance instanceof TTFormBase) {
        //    let formBase = this._formEditorInstance as TTFormBase;
        //    if (e.hasOwnProperty('OBJECTID')) {
        //        let objectID = e['OBJECTID'];
        //        let objectIDGuid: Guid;
        //        if (objectID instanceof Guid) {
        //            objectIDGuid = objectID as Guid;
        //        } else if ((typeof objectID) === 'string') {
        //            objectIDGuid = new Guid(objectID as string);
        //        }
        //        if (objectIDGuid != null) {
        //            formBase.ObjectID = objectIDGuid;
        //            if (this._formEditorInstance instanceof TTBoundFormBase) {
        //                let boundFormBase = this._formEditorInstance as TTBoundFormBase;
        //                (<any>boundFormBase).load();
        //            }
        //        }
        //    }
        //}

    }


    loadSelectedItem() {
        if (this._selectedItem != null) {
            if (this._formEditorInstance != null) {
                if (this._formEditorInstance.hasOwnProperty(this.formDataPropertyName)) {
                    this._formEditorInstance[this.formDataPropertyName] = this._selectedItem;
                }
            }
            if (this._formEditorInstance instanceof TTFormBase) {
                let formBase = this._formEditorInstance as TTFormBase;
                if (this._selectedItem.hasOwnProperty('OBJECTID')) {
                    let objectID = this._selectedItem['OBJECTID'];
                    let objectIDGuid: Guid;
                    if (objectID instanceof Guid) {
                        objectIDGuid = objectID as Guid;
                    } else if ((typeof objectID) === 'string') {
                        objectIDGuid = new Guid(objectID as string);
                    }
                    let loadForm = true;
                    if ((objectIDGuid != null && formBase.ObjectID != null) && formBase.ObjectID.valueOf() === objectIDGuid.valueOf()) {
                        loadForm = false;
                    }
                    if (loadForm == true) {
                        formBase.ObjectID = objectIDGuid;
                        if (this._formEditorInstance instanceof TTBoundFormBase) {
                            let boundFormBase = this._formEditorInstance as TTBoundFormBase;
                            (<any>boundFormBase).load();
                        }
                    }
                }
            }
        }
    }


    editorComponentCreated(compRef: ComponentRef<any>) {
        this._formEditorInstance = compRef.instance;
        this.loadSelectedItem();
    }

    queryResultLoaded(e: any) {
        this.QueryResultLoaded.emit(e);
    }

    queryExecutionCompleted(isSuccess: boolean) {
        this.QueryExecutionCompleted.emit(isSuccess);
    }


    dynamicComponentClosed(e: any) {
        /* let dynamicComponentInfo = new DynamicComponentInfo();
         Object.assign(dynamicComponentInfo, this._componentInfo);
         let that = this;
         setTimeout(function () {
             that.ComponentInfo = dynamicComponentInfo;
         }, 1000); */
    }

    dynamicComponentActionExecuted(eventParam: any) {
        if (eventParam.hasOwnProperty('IsSave')) {
            let dynamicComponentSaved = eventParam['IsSave'] as boolean;
            if (dynamicComponentSaved === true) {
                this._selectedItem = null;
                if (this.OpenComponentByAddButton) {
                    this._isComponentOpened = false;
                }
                let componentInfo = new DynamicComponentInfo();
                Object.assign(componentInfo, this._componentInfo);

                let queryParams = new QueryParams();
                Object.assign(queryParams, this._queryParameters);
                let that = this;
                setTimeout(function () {
                    that.QueryParameters = queryParams;
                    that.ComponentInfo = componentInfo;
                }, 1000);
            }
        }
    }

    btnAdd_valueChange() {
        if (this.OpenComponentByAddButton) {
            this._isComponentOpened = true;
        }
        this._selectedItem = null;
    }

    btnRefresh_valueChange() {
        //if (this.OpenComponentByAddButton)
        //    this._isComponentOpened = true;
        this._selectedItem = null;
        let componentInfo = new DynamicComponentInfo();
        Object.assign(componentInfo, this._componentInfo);
        this.ComponentInfo = componentInfo;
    }
}