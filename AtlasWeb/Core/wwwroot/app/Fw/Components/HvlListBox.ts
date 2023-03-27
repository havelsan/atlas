import {
    Component, SimpleChanges, OnChanges, Input,
    KeyValueDiffers, ElementRef, Optional, ChangeDetectorRef, AfterViewInit, OnDestroy, EventEmitter
} from '@angular/core';
import { BaseListBox } from './BaseControls/BaseListBox';
import { DataGridMessageService } from '../Services/DataGridMessageService';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ConfigurationCacheService } from 'Fw/Services/ConfigurationCacheService';
import { Subscription } from 'rxjs';

@Component({
    selector: "hvl-list-box",
    inputs: ['DialogTitle', 'DefinitionName', 'Enabled', 'Parameters', 'Required', 'ReadOnly', 'Columns', 'AutoCompleteMode', 'SearchMode'
        , 'Name', 'width', 'Visible', 'TabIndex', 'BackColor', 'ForeColor', 'ListFilterExpression', 'Font', 'AutoCompleteDialogWidth', 'AutoCompleteDialogHeight', 'MinSearchLength', 'SearchTimeout',
        'PopupDialogFieldConfig', 'PopupDialogGridColumns', 'PopupDialogWidth', 'PopupDialogHeight', 'PopupDialogTitle'],
    outputs: ['SelectedObjectChange', 'SelectedItemClear'],
    template: '<table [style.width]="width" style="border:1px solid lightgray;" *ngIf="Visible">\
                    <tr>\
                        <td>\
                             <hvl-autocomplete-grid (BeforeOpen)="beforeOpen($event)" (OnAutoCompleteDataSourceRefresh)="onDataSourceRefresh($event)" RemoveBorder="true" (SelectedObjectChange)="valueChanged($event)" (SelectedItemClear)="valueCleared($event)"\
                             [AutoCompleteDialogHeight]="AutoCompleteDialogHeight" [AutoCompleteDisplayExpression]="listDefSearch?.AutoCompleteDisplayExpression" [SearchTimeout]="SearchTimeout"\
                             [BackColor]="listDefSearch?.BackColor" [EnablePaging]="listDefSearch?.EnablePaging" [Enabled]="Enabled" [Font]="listDefSearch?.Font" [ForeColor]="listDefSearch?.ForeColor"\
                             [GridPageSize]="listDefSearch?.GridPageSize" [ReadOnly]="ReadOnly" [UpdateText]="UpdateText" [IsListBox]="IsListBox" [(IsOnPopUp)]="IsOnPopUp" [(dialogLeft)]="dialogLeft" [(dialogTop)]="dialogTop" [AutoCompleteDialogWidth]="AutoCompleteDialogWidth" [MinSearchLength]="listDefSearch?.MinSearchLength" \
                             [SearchMode]="SearchMode" [SearchTimeout]="listDefSearch?.SearchTimeout" [(SelectedObject)]="SelectedObject" ShowClearButton="true" width="100%" height="100%"\
                             [placeHolder]="placeHolder" (TextChange)="Filter=$event" [AutoCompleteMode]="AutoCompleteMode" [AutoCompleteGridColumns]="Columns" [PopupDialogFieldConfig]="PopupDialogFieldConfig"\
                             [PopupDialogGridColumns]="PopupDialogGridColumns" [PopupDialogWidth]="PopupDialogWidth" [PopupDialogHeight]="PopupDialogHeight" [PopupDialogTitle]="PopupDialogTitle"></hvl-autocomplete-grid>\
                        </td>\
                        <td *ngIf="AutoCompleteMode!=2" width="25px" style="border-left:1px solid lightgray;text-align:center;">\
                            <span style="color: #3073ac;" class="glyphicon glyphicon-triangle-bottom" (click)="Enabled?Toggle():return">\
                            </span>\
                        </td>\
                        <td *ngIf="AutoCompleteMode==2" (click)="Enabled?openPopup():return" width="25px" style="border-left:1px solid lightgray;text-align:center;">\
                            <span style="color: #3073ac;" class="glyphicon glyphicon-option-horizontal">\
                            </span>\
                        </td>\
                    </tr>\
            </table>'
})
export class HvlListBox extends BaseListBox implements OnChanges, AfterViewInit, OnDestroy {
    placeHolder: String = i18n("M26832", "Seçiniz");
    private _value: any;
    @Input() set Value(propVal: any) {
        this._value = propVal;
    }

    get Value(): any {
        return this._value;
    }
    @Input() UpdateText: boolean = true;

    @Input() IsListBox: boolean = true;

    public _isOnPopUp: Boolean = false;
    @Input() set IsOnPopUp(value: Boolean) {
        this._isOnPopUp = value;
    }

    get IsOnPopUp(): Boolean {
        return this._isOnPopUp;
    }

    @Input() dialogLeft: any;
    @Input() dialogTop: any;

    private displayExpressionsCache: any;
    @Input() set DisplayExpressionsCache(value: any) {
        this.displayExpressionsCache = value;
    }
    get DisplayExpressionsCache(): any {
        return this.displayExpressionsCache;
    }

    private _selectedObject: any;
    @Input() set SelectedObject(propVal: any) {
        this._selectedObject = propVal;
        // console.log(`${new Date()} - ${propVal}`);
    }

    get SelectedObject(): any {
        return this._selectedObject;
    }
    private gridMessageServiceSubscription: Subscription;

    SelectedItemClear: EventEmitter<any> = new EventEmitter<any>();


    constructor(differs: KeyValueDiffers, element: ElementRef, http: NeHttpService, detector: ChangeDetectorRef,
        @Optional()
        private gridMessageService: DataGridMessageService,
        configService: ConfigurationCacheService) {
        super(differs, element, http, configService);
        this.ReadOnly = true;
        let that = this;
        if (this.gridMessageService) {
            this.gridMessageServiceSubscription = this.gridMessageService.OnMessage.subscribe(t => {
                if (t.name === that.Name) {
                    if (t.messageName.startsWith("Font.")) {
                        let fontProperty = t.messageName.substr(t.messageName.indexOf('.') + 1);
                        that.Font[fontProperty] = t.content;
                        that.setAppearence();
                    }
                    else {
                        that[t.messageName] = t.content;
                        if (t.messageName === "ListDefName") {
                            that.DefinitionName = t.content;
                        }
                        else
                            that.setAppearence();
                    }
                }
            });
        }
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes["SelectedObject"] && (!this.SelectedObject || !this.SelectedObject.ObjectID)) {
            this.SelectedValue = undefined;
        }
        //else if (changes["SelectedObject"] && !this.SelectedValue) {
        //    this.SelectedObject = undefined;
        //}
        if ((changes["SelectedObject"] && this.SelectedObject) ||
            (changes["DefinitionName"] && this.DefinitionName)) {

            if (this.SelectedObject && this.SelectedObject.ObjectID) {
                this.SelectedValue = this.SelectedObject.ObjectID;
                let that = this;
                this.findByValue(this.displayExpressionsCache).then(t => {
                    that._selectedObject = t;
                });
            }
        }
        super.ngOnChanges(changes);
    }

    ngAfterViewInit() {
        if (this.gridMessageService) {
            this.height = "22px !important";
            let table : any = Array.from(this.element.nativeElement.childNodes).find(x=> x.constructor.name == "HTMLTableElement" );
            if(table){
                table.style.height = "22px";
            }
        }
        this.element.nativeElement.parentElement.parentElement.style.padding = "0px";
    }

    ngOnDestroy() {
        if (this.gridMessageServiceSubscription != null) {
            this.gridMessageServiceSubscription.unsubscribe();
            this.gridMessageServiceSubscription = null;
        }
    }

    valueCleared(e) {
        //this.SelectedItemClear.emit(e);
        this.valueChanged(e);
    }
}