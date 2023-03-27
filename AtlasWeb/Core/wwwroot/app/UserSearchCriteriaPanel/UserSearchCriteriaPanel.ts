import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { UserSearchCriteria } from 'NebulaClient/Model/AtlasClientModel';
import { OperationStatus } from "../CashOfficeForms/OperationStatus";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DxAutocompleteComponent } from "devextreme-angular";
import { Guid } from "NebulaClient/Mscorlib/Guid";

@Component({
    selector: "user-search-criteria",
    templateUrl: './UserSearchCriteriaPanel.html',
})
export class UserSearchCriteriaPanel implements OnInit {

    //public Name: string = "";
    public dataSource: Array<UserSearchCriteriaModel> = new Array<UserSearchCriteriaModel>();
    public selectedItem: any;
    public _pageName: any;
    public _searchViewModel;
    public _saveButtonVisible = true;
    public _deleteButtonVisible = true;
    public _defaultButtonVisible = true;
    public isDefault?: boolean = false;
    public _getValuesAfterSave: boolean = true;
    public _clearButtonVisible: boolean = true;
    public _placeHolder = "";
    public _buttonGroupStyle: Object;
    public _buttonGroupClasses: string;
    public _autoCompleteClasses;

    @Output() ViewModelLoaded: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild(DxAutocompleteComponent) autoCompleteInstance: DxAutocompleteComponent;

    constructor(protected http: NeHttpService) {
        this.dataSource = new Array<UserSearchCriteriaModel>();
    }
    ngOnInit(): void {
        this.getUserSearchCriteria();
    }

    @Input() set AutoCompleteClasses(propVal: any) {
        this._autoCompleteClasses = propVal;
    }

    get AutoCompleteClasses(): any {
        return this._autoCompleteClasses;
    }

    @Input() set SearchViewModel(propVal: any) {
        this._searchViewModel = propVal;
    }

    get SearchViewModel(): any {
        return this._searchViewModel;
    }

    @Input() set PageName(propVal: any) {
        this._pageName = propVal;
    }

    get PageName(): any {
        return this._pageName;
    }

    @Input() set SaveButtonVisible(propVal: boolean) {
        this._saveButtonVisible = propVal;
    }

    get SaveButtonVisible(): boolean {
        return this._saveButtonVisible;
    }

    @Input() set DeleteButtonVisible(propVal: boolean) {
        this._deleteButtonVisible = propVal;
    }

    get DeleteButtonVisible(): boolean {
        return this._deleteButtonVisible;
    }

    @Input() set DefaultButtonVisible(propVal: boolean) {
        this._defaultButtonVisible = propVal;
    }

    get DefaultButtonVisible(): boolean {
        return this._defaultButtonVisible;
    }

    @Input() set GetValuesAfterSave(propVal: boolean) {
        this._getValuesAfterSave = propVal;
    }

    get GetValuesAfterSave(): boolean {
        return this._getValuesAfterSave;
    }

    @Input() set ClearButtonVisible(propVal: boolean) {
        this._clearButtonVisible = propVal;
    }

    get ClearButtonVisible(): boolean {
        return this._clearButtonVisible;
    }

    @Input() set PlaceHolder(propVal: string) {
        this._placeHolder = propVal;
    }

    get PlaceHolder(): string {
        return this._placeHolder;
    }

    @Input() set ButtonGroupStyle(propVal: Object) {
        this._buttonGroupStyle = propVal;
    }

    get ButtonGroupStyle(): Object {
        return this._buttonGroupStyle;
    }

    @Input() set ButtonGroupClasses(propVal: string) {
        this._buttonGroupClasses = propVal;
    }

    get ButtonGroupClasses(): string {
        return this._buttonGroupClasses;
    }

    openDataSourceList() {
        this.autoCompleteInstance.instance.open();
    }

    getUserSearchCriteria() {
        let that = this;
        let url = '/api/UserSearchCriteriaService/GetUserSearchCriteria?pageName=' + this._pageName;
        this.http.get<Array<UserSearchCriteria>>(url).then(x => {
            if (x != null) {
                that.dataSource = x;
                //let obj = that.dataSource.find(x => x.IsDefault) != null ? that.dataSource.find(x => x.IsDefault) : x[0];
                // if (obj != null) {
                //     if (obj.IsDefault != null)
                //         that.isDefault = obj.IsDefault;
                //     if (obj.Name != null)
                //         that.selectedItem = obj.Name;
                //     that.ViewModelLoaded.emit(obj);
                // }
            }
        });
    }

    saveUserSearchCriteria() {
        let url = '/api/UserSearchCriteriaService/SaveUserSearchCriteria';
        let userSearchCriteria: UserSearchCriteriaModel = new UserSearchCriteriaModel();

        userSearchCriteria.Name = this.selectedItem;
        userSearchCriteria.PageName = this._pageName;
        userSearchCriteria.Value = JSON.stringify(this._searchViewModel);
        userSearchCriteria.IsDefault = this.isDefault;

        if (this.selectedItem != null && this.dataSource.find(x => x.Name == this.selectedItem) != null)
            userSearchCriteria.ObjectID = this.dataSource.find(x => x.Name == this.selectedItem).ObjectID;

        this.http.post(url, userSearchCriteria).then(x => {
            let result: OperationStatus = <OperationStatus>x;
            if (result.Status) {
                if (!String.isNullOrEmpty(result.CustomMessage))
                    ServiceLocator.MessageService.showSuccess(result.CustomMessage);
                if (this._getValuesAfterSave)
                    this.getUserSearchCriteria();
            }
            else
                ServiceLocator.MessageService.showError(result.ErrorMessage);
        });
    }

    deleteUserSearchCriteria() {
        if (this.selectedItem != null && this.dataSource.find(x => x.Name == this.selectedItem) != null) {
            let url = '/api/UserSearchCriteriaService/DeleteUserSearchCriteria';
            let body = this.dataSource.find(x => x.Name == this.selectedItem);
            this.http.post(url, body).then(x => {
                let result: OperationStatus = <OperationStatus>x;
                if (result.Status) {
                    if (!String.isNullOrEmpty(result.CustomMessage))
                        ServiceLocator.MessageService.showSuccess(result.CustomMessage);
                    if (this._getValuesAfterSave)
                        this.getUserSearchCriteria();
                }
                else
                    ServiceLocator.MessageService.showError(result.ErrorMessage);
            });
        }
    }

    // onValueChanged(data: any) {
    //     if (data != null && data.selectedItem instanceof Object) {
    //         this.selectedItem = data;
    //         this.ViewModelLoaded.emit(data);
    //     }
    // }

    onSelectionChanged(data: any) {
        if (data != null && data.selectedItem instanceof Object) {
            let url = '/api/UserSearchCriteriaService/GetSearchCriteriaValue?objectID=' + data.selectedItem.ObjectID;

            this.http.get<string>(url).then(x => {
                if (!String.isNullOrEmpty(x))
                    this.ViewModelLoaded.emit(x);
            });
        }

        if (data.selectedItem != null && data.selectedItem.IsDefault != null)
            this.isDefault = data.selectedItem.IsDefault;
        //this.ViewModelLoaded.emit(data.selectedItem);
    }
    clearUserSearchCriteria() {
        this.ViewModelLoaded.emit(null);
    }
}

export class UserSearchCriteriaModel {
    public ObjectID: Guid;
    public Name: string;
    public PageName: string;
    public Value: string;
    public IsDefault: boolean;
}