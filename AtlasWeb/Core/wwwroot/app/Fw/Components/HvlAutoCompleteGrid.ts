import { Component, EventEmitter, KeyValueDiffers, Input, ElementRef, OnChanges, SimpleChanges, ViewChild, AfterViewInit, IterableDiffers, ChangeDetectorRef, OnDestroy, HostListener, Renderer2 } from '@angular/core';
import { BaseControl } from './BaseControls/BaseControl';
import { Util } from './Util';
import { DxTextBoxComponent, DxListComponent, DxDataGridComponent } from 'devextreme-angular';
import { HvlDialog } from 'Fw/Components/HvlDialog';
import { SearchMode, AutoCompleteMode, LoadDataSourceEventArgs, PagedResult, ListBoxSearchCriteria } from 'NebulaClient/Visual/Controls/TTAutoCompleteGrid';
import { AsyncSubject } from "rxjs";

declare var jQuery: any;
@Component({
    selector: 'hvl-autocomplete-grid',
    inputs: ['SelectedObject', 'SelectedValue', 'DialogTitle', 'Enabled', 'SearchMode', 'AutoCompleteMode', 'Text', 'AutoCompleteGridColumns', 'SelectSingleResultAutomatically',
        'Required', 'ReadOnly', 'Value', 'Name', 'Font', 'placeHolder', 'Visible', 'TabIndex', 'BackColor', 'ForeColor', 'Font', 'AutoCompleteDialogWidth',
        'MinSearchLength', 'SearchTimeout', 'PageSize', 'StyleExpression', 'height', 'width', 'AutoCompleteDialogHeight', 'RemoveBorder',
        'AutoCompleteDisplayExpression', 'ShowClearButton', 'IdExpression', 'EnablePaging',
        'PopupDialogFieldConfig', 'PopupDialogGridColumns', 'PopupDialogWidth', 'PopupDialogHeight', 'PopupDialogTitle'],
    outputs: ['BeforeOpen', 'SelectedObjectChange', 'OnAutoCompleteDataSourceRefresh', 'OnSearchItemPrepare', 'SelectedValueChange', 'TextChange', 'SelectedItemClear'],
    template: '<dx-text-box (onFocusIn)="FocusIn(Text)" (onFocusOut)="FocusOut($event)" [ngClass]="[\'form-control\',\'disabledTransform\']"  [style.border]="RemoveBorder?\'none\':undefined" [showClearButton]="ShowClearButton"\
    [(value)]="Text" (onValueChanged)="onTextValueChangedByButton($event)" [visible]="Visible" [disabled]="!Enabled" [readOnly]="ReadOnly" [width]="width" (onKeyUp)="keyUp($event)" [placeholder]="placeHolder"\
    [(isValid)]="isValid" [validationError]="validationError" (onValueChanged)="onTxtValueChanged($event)" valueChangeEvent="keyup"></dx-text-box>\
        <hvl-dialog [width]="dialogWidth" [height]="AutoCompleteDialogHeight" [left]="dialogLeft" [top]="dialogTop" [enableAnimation]="enableAnimation" [opened]="autoCompleteDialogOpened" (onExpanded)="expanded()" (onCollapsed)="collapsed()">\
            <div style="width:100%;height:100%;background-color:white;border:1px solid gray">\
                <dx-list *ngIf="autoCompleteDialogOpened && AutoCompleteMode==0" pageLoadMode="scrollBottom" noDataText="Veri Bulunamadı" selectionMode="single" [(selectedItems)]="listSelectedItems"\
                    (onContentReady)="autoCompleteContentReady($event)" (onItemClick)="autoCompleteDialogSelected($event.itemData)" [dataSource]="RemoteDataSource" >\
                    <div *dxTemplate=\'let cellData of "item"\' [ngStyle]="GetTemplateData(StyleExpression,cellData)" style="text-align:left">\
                        <div [innerHtml]="GetTemplateData(AutoCompleteDisplayExpression,cellData)"></div>\
                    </div>\
                </dx-list>\
                <dx-data-grid *ngIf="autoCompleteDialogOpened && AutoCompleteMode==1" loadPanel="{enabled:false}" noDataText="Veri Bulunamadı" [columns]="AutoCompleteGridColumns" [dataSource]="RemoteDataSource" (onContentReady)="autoCompleteContentReady($event)"\
                    width="100%" height="100%" [remoteOperations]="GridRemoteOperations" [selection]="{mode: \'single\',allowSelectAll: false}" [scrolling]="GridScrolling" (onRowPrepared)="gridRowPrepared($event)" [paging]="GridPageConfig"\
                    (onCellClick)="autoCompleteDialogSelected($event.data)" (onSelectionChanged)="gridSelectionChanged($event)">\
                        <div *dxTemplate=\'let cellData of \"gridTemplate\"\' [innerHtml]="GetTemplateData(cellData.column.dataField,cellData.data)"></div>\
                </dx-data-grid>\
            </div>\
        </hvl-dialog>\
        <dx-popup [width]="PopupDialogWidth" [height]="PopupDialogHeight" [title]="PopupDialogTitle" [(visible)]="ShowPopup" (onShown)="dialogShown()">\
            <div *dxTemplate="let t = data of \'content\'" align="center">\
                <table style="width:90%;margin:20px !important">\
                    <tr *ngFor="let config of PopupDialogFieldConfig">\
                        <td width="10%">\
                            {{config.Label}}\
                        </td>\
                        <td  width="90%">\
                            <input style="margin:2px" type="text" class="form-control" [(ngModel)]="config.Value" (keyup.enter)="searchDialog()" />\
                        </td>\
                    </tr>\
                    <tr><td></td><td>\
                            <dx-button type="btn btn-default" style.margin="2px" (onClick)="searchDialog()" text="Ara"></dx-button>\
                    </td></tr>\
                    <tr><td colspan="2">\
                            <dx-data-grid style.margin="2px" #DialogGrid noDataText="Veri Bulunamadı" [columns]="PopupDialogGridColumns" width="100%"  [dataSource]="PopupDialogDataSource" [remoteOperations]="{paging:true}"\
                                 [selection]="{mode: \'single\',allowSelectAll: false}" [pager]="{showInfo: true,visible:true}" (onRowPrepared)="gridRowPrepared($event)" [paging]="{enabled:true, pageSize:10}" (onSelectionChanged)="select($event)">\
                            </dx-data-grid>\
                    </td></tr>\
                </table>\
            </div>\
        </dx-popup>'
})
export class HvlAutoCompleteGrid extends BaseControl implements OnChanges, OnDestroy, AfterViewInit {
    LastKeyPressed: Number;
    @ViewChild(DxTextBoxComponent) TextBoxInstance: DxTextBoxComponent;
    @ViewChild(HvlDialog) DialogInstance: HvlDialog;
    @ViewChild(DxListComponent) ListInstance: DxListComponent;
    @ViewChild(DxDataGridComponent) GridInstance: DxDataGridComponent;
    @ViewChild("DialogGrid") DialogGridInstance: DxDataGridComponent;

    SelectedObjectChange: EventEmitter<any> = new EventEmitter<any>();
    SelectedValueChange: EventEmitter<any> = new EventEmitter<any>();
    SelectedItemClear: EventEmitter<any> = new EventEmitter<any>();

    OnAutoCompleteDataSourceRefresh: EventEmitter<LoadDataSourceEventArgs> = new EventEmitter<LoadDataSourceEventArgs>();
    OnSearchItemPrepare: EventEmitter<any> = new EventEmitter<any>();
    BeforeOpen: EventEmitter<any> = new EventEmitter<any>();

    readonly _DefaultMinSearchLength: Number = 0;
    readonly _DefaultSearchTimeout: Number = 200;
    readonly _DefaultPageSize: Number = 30;
    readonly _DefalutEnablePaging: Boolean = false;

    PageSize: Number = this._DefaultPageSize;
    SearchTimeout: Number = this._DefaultSearchTimeout;
    StyleExpression: String;
    SelectedObject: any;
    RemoveBorder: Boolean = false;
    SelectSingleResultAutomatically: Boolean = false;
    SelectedValue: any;
    AutoCompleteDisplayExpression: String;
    AutoCompleteGridColumns: any;
    SearchMode: SearchMode;
    AutoCompleteMode: AutoCompleteMode;
    IdExpression: String;
    EnablePaging: Boolean;
    RemoteDataSource: any = {
        requireTotalCount: false,
        paginate: false
    };
    GridScrolling: any = {
        mode: 'standard'
    };
    @Input() IsListBox: boolean = false;

    private _isOnPopUp: Boolean = false;
    @Input() set IsOnPopUp(value: Boolean) {
        this._isOnPopUp = value;
    }

    get IsOnPopUp(): Boolean {
        return this._isOnPopUp;
    }
    @Input() UpdateText: boolean = true;
    placeHolder: String;
    AutoCompleteDialogWidth: any;
    AutoCompleteDialogHeight: any;
    dialogWidth: any;
    @Input() dialogLeft: any;
    @Input() dialogTop: any;
    enableAnimation: Boolean = true;
    autoCompleteDialogOpened: Boolean = false;
    GridPageConfig: any = { enabled: this._DefalutEnablePaging, pageSize: this._DefaultPageSize };
    GridRemoteOperations: any = { paging: this._DefalutEnablePaging };

    defaultDialogHeight: String = "30%";
    autoCompleteDialogGotFocus: Boolean = false;
    MinSearchLength: Number = this._DefaultMinSearchLength;
    listSelectedItems: Array<any> = new Array<any>();

    LatestTimeoutRef: Number;

    PopupDialogFieldConfig: Array<ListBoxSearchCriteria>;
    PopupDialogGridColumns: Array<any>;
    PopupDialogWidth: any;
    PopupDialogHeight: any;
    PopupDialogTitle: String;
    ShowPopup: Boolean;
    PopupDialogDataSource: any = { requireTotalCount: true };

    constructor(differs: KeyValueDiffers, element: ElementRef, private iterableDiffers: IterableDiffers, private detector: ChangeDetectorRef, public renderer: Renderer2) {
        super(differs, element);
        this.RemoteDataSource.load = (loadOptions: any) => {
            let that = this;
            let jqDeferred = new AsyncSubject();
            let text = that.Text || '';
            if (this.SelectedObject && that.SearchMode == SearchMode.OnKeyPressed) {
                let selectedText: String = Util.ResolveProperty(that.AutoCompleteDisplayExpression, that.SelectedObject);
                if (selectedText == text) {
                    text = '';
                }
            }
            let loaderOptions: LoadDataSourceEventArgs = new LoadDataSourceEventArgs();
            loaderOptions.Filter = text;
            if (that.EnablePaging) {
                loaderOptions.Take = Number(loadOptions.take);
                loaderOptions.Skip = loadOptions.skip;
                loaderOptions.RequireCount = loadOptions.requireTotalCount;
                if (loaderOptions.Take == 0 || isNaN(loaderOptions.Take)) {
                    jqDeferred.next({ data: [], totalCount: 0 });
                    jqDeferred.complete();
                }
            }
            Object.defineProperty(loaderOptions, "AsyncLoader", {
                set: (deferred: Promise<PagedResult>) => {
                    deferred.then(t => {
                        let data: Array<any> = t.Data;
                        /*if (that.SearchMode == SearchMode.OnEnterPressed && (!data || data.length == 0)) {
                            that.closeDialog();
                        }*/
                        that.prepareItems(data);
                        if (that.EnablePaging) {
                            if (!data && !t.RecordCount) {
                                jqDeferred.next({ data: [], totalCount: 0 });
                                jqDeferred.complete();
                            }
                            else {
                                jqDeferred.next({ data: data, totalCount: t.RecordCount });
                                jqDeferred.complete();
                            }
                        }
                        else {
                            jqDeferred.next(data);
                            jqDeferred.complete();
                        }
                    });
                }
            });
            this.OnAutoCompleteDataSourceRefresh.emit(loaderOptions);
            return jqDeferred.toPromise();
        };
        this.PopupDialogDataSource.load = (loadOptions: any) => {
            let that = this;
            let jqDeferred = new AsyncSubject();
            let loaderOptions: LoadDataSourceEventArgs = new LoadDataSourceEventArgs();
            loaderOptions.RequireCount = loadOptions.requireTotalCount;
            loaderOptions.Take = loadOptions.take;
            loaderOptions.Skip = loadOptions.skip;
            loaderOptions.IsPopupDataSource = true;
            Object.defineProperty(loaderOptions, "PopupAsyncLoader", {
                set: (deferred: Promise<PagedResult>) => {
                    deferred.then(t => {
                        let data: Array<any> = t.Data;
                        that.prepareItems(data);
                        jqDeferred.next({ data: data, totalCount: t.RecordCount });
                        jqDeferred.complete();
                    });
                }
            });
            this.OnAutoCompleteDataSourceRefresh.emit(loaderOptions);
            return jqDeferred.toPromise();
        };
    }

    public Focus() {
        this.TextBoxInstance.instance.focus();
    }

    public Blur() {
        this.TextBoxInstance.instance.blur();
    }
    isPatientSearch: boolean = false;
    IsSelectedObjectEmty: boolean = true;
    public FocusIn(e) {
        if (this.IsListBox == true) {
            if (e != "")
                this.IsSelectedObjectEmty = false;
            this.toggleDialog();
        }

    }

    FocusOut(e: MouseEvent) {
        setTimeout(() => {
            if ((this.Text == "" || this.IsSelectedObjectEmty == false) && (this.isItemSelected == false && this.autoCompleteDialogOpened == true)) {
                if (this.IsListBox == true) {
                    this.toggleDialog();
                    this.isItemSelected = false;
                }
            }
            if (this.isPatientSearch == true && this.autoCompleteDialogOpened == true)
                this.toggleDialog();
        }, 200);
        if (this.isItemSelected == true)
            this.isItemSelected = false;

    }

    public openPopupDialog(clearFilterValues: Boolean = true) {
        if (this.PopupDialogFieldConfig && clearFilterValues) {
            for (let i = 0; i < this.PopupDialogFieldConfig.length; i++) {
                this.PopupDialogFieldConfig[i].Value = "";
            }
        }
        if (this.PopupDialogFieldConfig && this.PopupDialogFieldConfig.length == 1) {
            this.PopupDialogFieldConfig[0].Value = this.Text;
        }
        this.detector.detectChanges();
        this.ShowPopup = true;
    }

    // TODO: yavaşlığa sebep oluyor
    // Alternatif hızlı bir yöntem bulunacak
    // Kapalı kalmalı
    /*
     @HostListener('window:mousedown', ['$event'])
    click(event: MouseEvent) {
        if (!Util.ContainsElement(this.element.nativeElement, event.target)) {
            this.onLostFocus();
        }
    }
    */

    dialogShown() {
        if (this.DialogGridInstance) {
            this.DialogGridInstance.instance.clearSelection();
            this.DialogGridInstance.instance.repaint();
            this.DialogGridInstance.instance.refresh();
        }
    }

    ngAfterViewInit() {
        if (this.TextBoxInstance) {
            //let that = this;
            //let element = document.querySelector(".dx-icon-clear");// this.renderer.selectRootElement('.dx-icon-clear');
            //if (element != null) {
            //    if (element.className == "dx-icon dx-icon-clear") {
            //        this.renderer.listen(element, "click", (event: any) => {
            //            that.Clear();
            //            that.detector.detectChanges();
            //        });
            //    }
            //}
            this.preventArrowKeysBehaviour();

            //this.element.nativeElement.getElementsByTagName('input')[0].onkeydown = this.SelectByKey.bind(this);
        }
    }

    onTxtValueChanged(e) {
        if (e.event == undefined && e.value == "") {
            this.Clear();
            this.detector.detectChanges();
        }
    }
    onTextValueChangedByButton(e) {
        if (e.previousValue != "" && e.value == "") {
            this.SelectedItemClear.emit();
        }
    }

    SelectByKey(event: Event) {
        if (event['keyCode'] == 13 || event['keyCode'] == 9) {
            if (this.ListInstance) {
                if (this.listSelectedItems.length > 0) {
                    this.autoCompleteDialogSelected(this.listSelectedItems[0]);
                    this.closeDialog();
                }
                else
                    this.Refresh();
            }
            else if (this.GridInstance) {
                let data: Array<any> = this.GetGridItems();
                let selectedRows: Array<any> = this.GridInstance.instance.getSelectedRowsData();
                if (selectedRows.length > 0) {
                    let selected: any = selectedRows[0];
                    this.autoCompleteDialogSelected(selected);
                    this.closeDialog();
                }
                else
                    this.Refresh();
            }
            if (event && event['keyCode'] == 9) {
                window.setTimeout((() => {
                    this.closeDialog();
                    this.TextBoxInstance.instance.blur();
                }).bind(this));
                event.preventDefault();
            }
        }
    }

    preventArrowKeysBehaviour() {
        //var query = jQuery(this.element.nativeElement).find('input.dx-texteditor-input,input[type=text]');
        //query.keydown((event) => {
        //    if (event.keyCode == 40 || event.keyCode == 38) {
        //        event.preventDefault();
        //    }
        //});
        if (this.element.nativeElement.className == "input.dx-texteditor-input,input[type=text]") {
            this.renderer.listen(this.element.nativeElement, "keydown", (event: any) => {
                if (event.keyCode == 40 || event.keyCode == 38) {
                    event.preventDefault();
                }
            });
        }

    }

    searchDialog() {
        if (this.PopupDialogFieldConfig) {
            for (let i = 0; i < this.PopupDialogFieldConfig.length; i++) {
                this.PopupDialogFieldConfig[i].Value = Util.turkishToUpper(this.PopupDialogFieldConfig[i].Value);
            }
        }
        this.DialogGridInstance.instance.refresh();
    }

    Refresh() {
        if (this.ListInstance) {
            this.ListInstance.instance.reload();
        }
        else if (this.GridInstance) {
            this.GridInstance.instance.refresh();
        }
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['SelectSingleResultAutomatically'] && this.SelectSingleResultAutomatically == undefined) {
            this.SelectSingleResultAutomatically = false;
        }
        if (changes['MinSearchLength'] && !this.MinSearchLength) {
            this.MinSearchLength = this._DefaultMinSearchLength;
        }
        if (changes['SearchTimeout'] && !this.SearchTimeout) {
            this.SearchTimeout = this._DefaultSearchTimeout;
        }
        if (changes['PageSize']) {
            if (this.PageSize == undefined)
                this.PageSize = this._DefaultPageSize;
            this.GridPageConfig = { enabled: true, pageSize: this.PageSize };
            this.RemoteDataSource.pageSize = this.PageSize;
        }
        if (changes['StyleExpression'] && this.StyleExpression) {
            this.Refresh();
        }
        if (changes['RemoveBorder'] && this.RemoveBorder == undefined) {
            this.RemoveBorder = false;
        }
        if (changes['SearchMode']) {
            if (this.SearchMode == undefined) {
                this.SearchMode = SearchMode.OnEnterPressed;
            }
        }
        if (changes['SelectedObject']) {
            if (!this.SelectedObject) {
                this.Text = '';
            }
            else {
                if (this.UpdateText)
                    this.Text = Util.ResolveProperty(this.AutoCompleteDisplayExpression, this.SelectedObject);
            }

        }
        if (changes['AutoCompleteMode']) {
            if (this.AutoCompleteMode == undefined)
                this.AutoCompleteMode = AutoCompleteMode.List;
        }
        if (changes['AutoCompleteGridColumns'] && this.AutoCompleteGridColumns) {
            for (let i = 0; i < this.AutoCompleteGridColumns.length; i++) {
                this.AutoCompleteGridColumns[i].cellTemplate = 'gridTemplate';
            }
        }
        if (changes['ShowClearButton']) {
            if (typeof this.ShowClearButton == "string") {
                this.ShowClearButton = this.ShowClearButton == "true" ? true : false;
            }
            if (this.TextBoxInstance != null)
                this.TextBoxInstance.showClearButton = this.ShowClearButton;
        }
        if (changes['EnablePaging']) {
            if (this.EnablePaging == undefined) {
                this.EnablePaging = false;
            }
            if (this.EnablePaging == true) {
                this.GridPageConfig = { enabled: true, pageSize: this.PageSize };
                this.GridRemoteOperations = { paging: true };
                this.GridScrolling = {
                    mode: 'virtual'
                };
            }
            else {
                this.GridPageConfig = { enabled: false, pageSize: this.PageSize };
                this.GridRemoteOperations = { paging: false };
                this.GridScrolling = {
                    mode: 'standard'
                };
            }
            if (this.AutoCompleteMode == AutoCompleteMode.Grid) {
                this.RemoteDataSource.requireTotalCount = this.EnablePaging;
            }
            this.RemoteDataSource.paginate = this.EnablePaging;
        }
        if (changes['AutoCompleteDialogHeight'] && this.AutoCompleteDialogHeight == undefined) {
            this.AutoCompleteDialogHeight = this.defaultDialogHeight;
        }
        super.ngOnChanges(changes);
    }

    /* @HostListener('window:focus', ['$event'])
     focused(event: FocusEvent) {
         if (!Util.ContainsElement(this.element.nativeElement, event.target)) {
             this.onLostFocus();
         }
     } */

    @HostListener('window:resize', ['$event'])
    resize(event: Event) {
        this.setDialogVars();
    }

    ngOnDestroy() {
    }

    setDialogVars() {
        if (this.dialogLeft == null && this.dialogTop == null) {
            let element: any = this.TextBoxInstance.instance.element();
            let bbox: ClientRect = element.getBoundingClientRect();
            if (Util.IsBrowserChrome()) {
                let transformedElements: Array<any> = [];
                this.getTransformedParent(element, transformedElements);
                let combinedTranslate: any = { x: 0, y: 0 };
                for (let i = 0; i < transformedElements.length; i++) {
                    combinedTranslate.x += this.getTransform(transformedElements[i]).translate.x;
                    combinedTranslate.y += this.getTransform(transformedElements[i]).translate.y;
                }
                bbox = <any>{ top: bbox.top, bottom: bbox.bottom, width: bbox.width, height: bbox.height, left: bbox.left };
                bbox.top -= combinedTranslate.y;
                bbox.left -= combinedTranslate.x;

                let outerTab: HTMLElement = this.getParentTab(element);
                if (outerTab) {
                    bbox.top -= outerTab.getBoundingClientRect().top;
                    bbox.left -= outerTab.getBoundingClientRect().left;
                }
            }
            let viewPortHeight: number = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);
            let viewPortWidth: number = Math.max(document.documentElement.clientWidth, window.innerWidth || 0);
            if (!this.AutoCompleteDialogWidth) {
                this.dialogWidth = (bbox.width).toString() + "px";
                this.dialogLeft = bbox.left.toString() + "px";
            }
            else {
                this.dialogWidth = this.AutoCompleteDialogWidth;
                if (!isNaN(Number(this.AutoCompleteDialogWidth))) {
                    if (bbox.left + Number(this.AutoCompleteDialogWidth) > viewPortWidth) {
                        this.dialogLeft = (bbox.left - (this.AutoCompleteDialogWidth - bbox.width)).toString() + "px";
                    }
                    else
                        this.dialogLeft = bbox.left.toString() + "px";
                }
                else if (this.AutoCompleteDialogWidth.toString().endsWith('px')) {
                    let width: number = Number(this.AutoCompleteDialogWidth.toString().substr(0, this.AutoCompleteDialogWidth.toString().indexOf('px')));
                    if (bbox.left + width > viewPortWidth) {
                        this.dialogLeft = (bbox.left - (width - bbox.width)).toString() + "px";
                    }
                    else
                        this.dialogLeft = bbox.left.toString() + "px";
                }
                else if (this.AutoCompleteDialogWidth.toString().endsWith('%')) {
                    let width: number = (viewPortWidth * Number(this.AutoCompleteDialogWidth.toString().substr(0, this.AutoCompleteDialogWidth.toString().indexOf('%')))) / 100;
                    if (bbox.left + width > viewPortWidth) {
                        this.dialogLeft = (bbox.left - (width - bbox.width)).toString() + "px";
                    }
                    else
                        this.dialogLeft = bbox.left.toString() + "px";
                }
                else {
                    this.dialogLeft = bbox.left.toString() + "px";
                }
            }
            let height = bbox.height;
            let dialogHeight: number = this.DialogInstance.element.nativeElement.firstChild.clientHeight;
            if (bbox.top + dialogHeight > viewPortHeight) {
                this.dialogTop = (bbox.top - dialogHeight).toString() + "px";
            }
            else {
                this.dialogTop = (bbox.top + height).toString() + "px";
            }

            if (this.IsOnPopUp) {
                this.dialogLeft = "10%";
                this.dialogTop = "16%";
            }
        }
    }

    prepareItems(data: Array<any>) {
        if (data && data.length > 0) {
            for (let i = 0; i < data.length; i++) {
                this.OnSearchItemPrepare.emit({ Item: data[i], Index: i });
            }
        }
    }

    collapsed() {
        if (this.AutoCompleteMode == AutoCompleteMode.List) {
            this.listSelectedItems.Clear();
        }
    }

    expanded() {
        let that = this;
        if (this.GridInstance) {
            that.GridInstance.instance.repaint();
        }
        else if (this.ListInstance) {
            that.ListInstance.instance.repaint();
        }
    }

    select(data: any) {
        if (data == null)
            return;
        if (data.selectedRowKeys[0] == null)
            return;
        let selected = data.selectedRowKeys[0];
        this.setSelectedObject(selected);
        if (selected) {
            this.Text = this.GetTemplateData(this.AutoCompleteDisplayExpression, selected);
        }
        if (this.DialogGridInstance)
            this.DialogGridInstance.instance.deselectAll();
        this.ShowPopup = false;
    }

    gridSelectionChanged(options: any) {
        let scrollable = options.component.getView('rowsView')._scrollable;
        if (scrollable) {
            let selectedRowElements = document.querySelector('tr.dx-selection'); // this.renderer.selectRootElement('tr.dx-selection');// options.component.element().find('tr.dx-selection');
            scrollable.scrollToElement(selectedRowElements);
        }
    }
    isItemSelected: boolean = false;
    autoCompleteDialogSelected(itemData: any) {
        if (itemData) {
            if (this.UpdateText)
                this.Text = Util.ResolveProperty(this.AutoCompleteDisplayExpression, itemData);
            this.setSelectedObject(itemData);
            this.isItemSelected = true;
            this.onLostFocus();
        }
    }

    GetTemplateData(path: String, data: any) {
        if (path) {
            let result: String = Util.ResolvePropertyCaseInsensitive(path, data);
            if (!this.Text || this.Text == '') {
                if (result != null)
                    return result;
                else
                    return data.GeneratedDisplayExpression;
            }
            if (result) {
                let lowerResult: String = Util.turkishToLower(result);
                let lowerText: string = Util.turkishToLower(this.Text);
                if (lowerResult.startsWith(lowerText)) {
                    let index: number = this.Text.length;
                    return result.toString().substr(0, index) + result.toString().substr(index);
                }
                return result;
            }
            if (result != null)
                return result;
            else
                return data.GeneratedDisplayExpression;
        }
    }

    keyDown(event: any) {
        if (event.keyCode == 40 || event.keyCode == 38) {
            event.preventDefault();
        }
    }

    keyUp(data: any) {
        let that = this;
        let event: any = data.event;
        this.TextChange.emit(this.Text);
        let text: String = this.Text || '';
        if (text.length == 0 && (event.keyCode == 8 || event.keyCode == 46)) {
            this.Clear();
        }
        if (event.keyCode == 27) {
            this.onLostFocus();
        }
        else if (event.keyCode == 40) {
            if (this.autoCompleteDialogOpened) {
                this.selectItemByKeyboard(false);
            }
            else {
                this.openDialog();
            }
            event.preventDefault();
        }
        else if (event.keyCode == 38) {
            this.selectItemByKeyboard(true);
            event.preventDefault();
        }
        else if (event.keyCode == 13) {
            if (!this.autoCompleteDialogOpened && this.SearchMode == SearchMode.OnEnterPressed) {
                if (text.length >= this.MinSearchLength) {
                    this.openDialog();
                }
            }
            else {
                this.SelectByKey(event.originalEvent);
            }
        }
        else {
            if (this.SearchMode == SearchMode.OnKeyPressed) {
                let that = this;
                let text = that.Text || '';
                if (text.length >= this.MinSearchLength) {
                    this.LatestTimeoutRef ? window.clearTimeout(this.LatestTimeoutRef.Value) : 0;
                    this.LatestTimeoutRef = (<any>window.setTimeout(() => {
                        if (!that.autoCompleteDialogOpened)
                            that.openDialog();
                        else
                            that.Refresh();
                    }, this.SearchTimeout.Value)); //.data.handleId;
                }
            }
            else {
                if (this.ListInstance) {
                    this.listSelectedItems.Clear();
                }
                else if (this.GridInstance) {
                    this.GridInstance.instance.clearSelection();
                }
            }
        }
    }

    GetGridItems(): Array<any> {
        return (<any>this.GridInstance.instance)._controllers.data._dataSource._items;
    }

    selectItemByKeyboard(selectPrevious: Boolean) {
        let index: number;
        let data: Array<any>;
        this.detector.detectChanges();
        if (this.ListInstance) {
            data = this.ListInstance.items;
        }
        else if (this.GridInstance) {
            data = this.GetGridItems();
        }
        if (this.ListInstance) {
            if (data && data.length > 0) {
                index = data.indexOf(this.listSelectedItems[0]);
                if (selectPrevious && index == 0) {
                    return;
                }
                else if (!selectPrevious && index == data.length - 1) {
                    return;
                }
                if (selectPrevious) {
                    index--;
                }
                else {
                    index++;
                }
                this.listSelectedItems.Clear();
                this.listSelectedItems.push(data[index]);
                this.ListInstance.instance.scrollToItem(index);
            }
        }
        else if (this.GridInstance) {
            if (data && data.length > 0) {
                let selectedRows: Array<any> = this.GridInstance.instance.getSelectedRowsData();
                if (selectedRows.length > 0) {
                    let selected: any = selectedRows[0];
                    index = data.indexOf(selected);
                    if (selectPrevious && index == 0) {
                        return;
                    }
                    else if (!selectPrevious && index == data.length - 1) {
                        return;
                    }
                    if (selectPrevious) {
                        index--;
                    }
                    else {
                        index++;
                    }
                    this.GridInstance.instance.clearSelection();
                    this.GridInstance.instance.selectRowsByIndexes([index]);
                }
                else {
                    if (selectPrevious) {
                        index = data.length - 1;
                    }
                    else {
                        index = 0;
                    }
                    this.GridInstance.instance.selectRowsByIndexes([index]);
                }
            }
        }
    }

    onLostFocus() {
        let that = this;
        if (this.SelectedObject && this.autoCompleteDialogOpened) {
            if (this.UpdateText)
                that.Text = Util.ResolveProperty(that.AutoCompleteDisplayExpression, this.SelectedObject);
        }
        if (this.autoCompleteDialogOpened) {
            window.setTimeout(() => {
                that.closeDialog();
            }, 50);
        }
    }

    getTransform(elem) {
        let computedStyle: any = getComputedStyle(elem, null),
            val = computedStyle.transform ||
                computedStyle.webkitTransform ||
                computedStyle.MozTransform ||
                computedStyle.msTransform,
            matrix = this.parseMatrix(val),
            rotateY = Math.asin(-matrix.m13),
            rotateX,
            rotateZ;

        rotateX = Math.atan2(matrix.m23, matrix.m33);
        rotateZ = Math.atan2(matrix.m12, matrix.m11);

        return {
            transformStyle: val,
            matrix: matrix,
            rotate: {
                x: rotateX,
                y: rotateY,
                z: rotateZ
            },
            translate: {
                x: matrix.m41,
                y: matrix.m42,
                z: matrix.m43
            }
        };
    }

    parseMatrix(matrixString: string) {
        let c = matrixString.split(/\s*[(),]\s*/).slice(1, -1),
            matrix;

        if (c.length === 6) {
            matrix = {
                m11: +c[0], m21: +c[2], m31: 0, m41: +c[4],
                m12: +c[1], m22: +c[3], m32: 0, m42: +c[5],
                m13: 0, m23: 0, m33: 1, m43: 0,
                m14: 0, m24: 0, m34: 0, m44: 1
            };
        } else if (c.length === 16) {
            matrix = {
                m11: +c[0], m21: +c[4], m31: +c[8], m41: +c[12],
                m12: +c[1], m22: +c[5], m32: +c[9], m42: +c[13],
                m13: +c[2], m23: +c[6], m33: +c[10], m43: +c[14],
                m14: +c[3], m24: +c[7], m34: +c[11], m44: +c[15]
            };

        } else {
            matrix = {
                m11: 1, m21: 0, m31: 0, m41: 0,
                m12: 0, m22: 1, m32: 0, m42: 0,
                m13: 0, m23: 0, m33: 1, m43: 0,
                m14: 0, m24: 0, m34: 0, m44: 1
            };
        }
        return matrix;
    }

    getTransformedParent(e: HTMLElement, transformList: Array<any>) {
        if (e.style.transform != '') {
            transformList.push(e);
        }
        if (e.parentElement) {
            this.getTransformedParent(e.parentElement, transformList);
        }
    }

    getParentTab(e: HTMLElement): HTMLElement {
        if (e.classList.contains('dx-multiview-wrapper')) {
            return e;
        }
        if (e.parentElement) {
            return this.getParentTab(e.parentElement);
        }
        else {
            return null;
        }
    }

    openDialog() {
        if (!this.ReadOnly) {
            if (this.BeforeOpen.observers.length > 0) {
                const that = this;
                let jqDeferred = new AsyncSubject();
                jqDeferred.subscribe(x => {
                    that.setDialogVars();
                    that.autoCompleteDialogOpened = true;
                });
                this.BeforeOpen.emit(jqDeferred);
            }
            else {
                this.setDialogVars();
                this.autoCompleteDialogOpened = true;
            }
        }
    }

    closeDialog() {
        this.autoCompleteDialogOpened = false;
    }

    toggleDialog() {
        if (!this.autoCompleteDialogOpened) {
            this.openDialog();
        }
        else {
            this.autoCompleteDialogOpened = false;
        }
    }

    Clear() {
        this.setSelectedObject(null);
        this.Text = '';
    }

    openDropDown() {
        this.openDialog();
    }

    setSelectedObject(obj: any) {
        if (this.SelectedObject && obj && this.SelectedObject == obj) {
            return;
        }
        this.SelectedObject = obj;
        this.SelectedObjectChange.emit(this.SelectedObject);
        if (this.IdExpression) {
            this.SelectedValue = obj ? Util.ResolveProperty(this.IdExpression, obj) : null;
            this.SelectedValueChange.emit(this.SelectedValue);
        }
        if (!this.UpdateText)
            this.Text = "";
    }

    gridRowPrepared($event) {
        if ($event.rowType == "data" && this.StyleExpression) {
            let style: any = Util.ResolveProperty(this.StyleExpression, $event.data);
            for (let property in style) {
                if (style.hasOwnProperty(property)) {
                    $event.rowElement.firstItem().css(property, style[property]);
                }
            }
        }
    }

    autoCompleteContentReady(event: any) {
        let data: Array<any>;
        if (this.AutoCompleteMode == AutoCompleteMode.List && this.ListInstance) {
            data = this.ListInstance.items;
        }
        else if (this.AutoCompleteMode == AutoCompleteMode.Grid && this.GridInstance) {
            data = this.GetGridItems();
        }
        if (data && data.length > 0) {
            if (this.SelectSingleResultAutomatically && data && data.length == 1) {
                this.setSelectedObject(data[0]);
                this.Text = Util.ResolveProperty(this.AutoCompleteDisplayExpression, this.SelectedObject);
                this.closeDialog();
            }
            else {
                if (this.GridInstance) {
                    this.GridInstance.instance.selectRowsByIndexes([0]);
                }
                else if (this.ListInstance) {
                    this.listSelectedItems.Clear();
                    this.listSelectedItems.push(data[0]);
                }
            }
        }
    }
}