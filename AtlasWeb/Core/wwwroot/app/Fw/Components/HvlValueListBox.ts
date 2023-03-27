import { Component, SimpleChanges, OnChanges, OnDestroy, Input, KeyValueDiffers, ElementRef, Optional, AfterViewInit } from '@angular/core';
import { DataGridMessageService } from '../Services/DataGridMessageService';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { BaseListBox } from './BaseControls/BaseListBox';
import { ConfigurationCacheService } from 'Fw/Services/ConfigurationCacheService';
import { Subscription } from 'rxjs';

@Component({
    selector: "hvl-valuelist-box",
    inputs: ['SelectedValue', 'DefinitionName', 'Enabled', 'width', 'AutoCompleteDialogWidth', 'MinSearchLength', 'SearchTimeout',
        'Parameters', 'Required', 'ReadOnly', 'Value', 'Name', 'Columns', 'AutoCompleteMode', 'SearchMode', 'AutoCompleteDialogHeight',
        'Visible', 'TabIndex', 'BackColor', 'ForeColor', 'ListFilterExpression', 'Font', 'PopupDialogFieldConfig', 'PopupDialogGridColumns', 'PopupDialogWidth', 'PopupDialogHeight', 'PopupDialogTitle'],
    outputs: ['SelectedValueChange'],
    template: '<table [style.width]="width" style="border:1px solid lightgray;" *ngIf="Visible">\
                    <tr>\
                        <td>\
                             <hvl-autocomplete-grid (BeforeOpen)="beforeOpen($event)" (OnAutoCompleteDataSourceRefresh)="onDataSourceRefresh($event)" RemoveBorder="true" (SelectedObjectChange)="valueChanged($event)"\
                             [AutoCompleteDialogHeight]="listDefSearch?.AutoCompleteDialogHeight" [AutoCompleteDisplayExpression]="listDefSearch?.AutoCompleteDisplayExpression" [SearchTimeout]="SearchTimeout"\
                             [BackColor]="listDefSearch?.BackColor" [EnablePaging]="listDefSearch?.EnablePaging" [Enabled]="Enabled" [Font]="listDefSearch?.Font" [ForeColor]="listDefSearch?.ForeColor"\
                             [GridPageSize]="listDefSearch?.GridPageSize" [ReadOnly]="ReadOnly" [AutoCompleteDialogWidth]="AutoCompleteDialogWidth" [MinSearchLength]="listDefSearch?.MinSearchLength" \
                             [SearchMode]="SearchMode" [SearchTimeout]="listDefSearch?.SearchTimeout" [(SelectedObject)]="SelectedObject" ShowClearButton="true" width="100%" height="100%"\
                             placeHolder="Seçiniz" i18n-placeholder="@@M26832" (TextChange)="Filter=$event" [AutoCompleteMode]="AutoCompleteMode" [AutoCompleteGridColumns]="Columns" [PopupDialogFieldConfig]="PopupDialogFieldConfig"\
                             [PopupDialogGridColumns]="PopupDialogGridColumns" [PopupDialogWidth]="PopupDialogWidth" [PopupDialogHeight]="PopupDialogHeight" [PopupDialogTitle]="PopupDialogTitle"></hvl-autocomplete-grid>\
                        </td>\
                        <td *ngIf="AutoCompleteMode!=2" width="25px" style="border-left:1px solid lightgray;text-align:center;">\
                            <span class="glyphicon glyphicon-triangle-bottom" (click)="Enabled?Toggle():return">\
                            </span>\
                        </td>\
                        <td *ngIf="AutoCompleteMode==2" (click)="Enabled?openPopup():return" width="25px" style="border-left:1px solid lightgray;text-align:center;">\
                            <span class="glyphicon glyphicon-option-horizontal">\
                            </span>\
                        </td>\
                    </tr>\
            </table>',
})
export class HvlValueListBox extends BaseListBox implements OnChanges, AfterViewInit, OnDestroy {
    private gridMessageServiceSubscription: Subscription;

    private displayExpressionsCache: Map<string, any>;
    @Input() set DisplayExpressionsCache(value: Map<string, any>) {
        this.displayExpressionsCache = value;
    }
    get DisplayExpressionsCache(): Map<string, any> {
        return this.displayExpressionsCache;
    }

    constructor(differs: KeyValueDiffers,
        element: ElementRef,
        http: NeHttpService,
        @Optional()
        private gridMessageService: DataGridMessageService,
        configService: ConfigurationCacheService) {
        super(differs, element, http, configService);
        let that = this;
        if (this.gridMessageService) {
            let that = this;
            this.gridMessageServiceSubscription = this.gridMessageService.OnMessage.subscribe(t => {
                if (t.name == that.Name) {
                    if (t.messageName.startsWith("Font.")) {
                        let fontProperty = t.messageName.substr(t.messageName.indexOf('.') + 1);
                        that.Font[fontProperty] = t.content;
                        that.setAppearence();
                    }
                    else {
                        that[t.messageName] = t.content;
                        if (t.messageName == "ListDefName") {
                            that.DefinitionName = t.content;
                        }
                        else
                            that.setAppearence();
                    }
                }
            });
        }
    }

    ngOnChanges(changeRecord: SimpleChanges) {
        if (changeRecord["SelectedValue"] || changeRecord["DefinitionName"]) {
            if (this.SelectedValue) {
                this.findByValue(this.displayExpressionsCache).then(t => {
                    this.SelectedObject = t;
                });
            }
            else {
                this.valueChanged(null);
            }
        }
        super.ngOnChanges(changeRecord);
    }

    ngAfterViewInit() {
        if (this.gridMessageService) {
            this.height = "22px !important";
            this.element.nativeElement.childNodes[1].style.height = "22px";
        }
        this.element.nativeElement.parentElement.parentElement.style.padding = "0px";
    }

    ngOnDestroy() {
        if (this.gridMessageServiceSubscription != null) {
            this.gridMessageServiceSubscription.unsubscribe();
            this.gridMessageServiceSubscription = null;
        }
    }
}