import { Component, SimpleChanges, OnChanges, OnDestroy, KeyValueDiffers, ElementRef, Optional, AfterViewInit } from '@angular/core';
import { BaseSelectBox } from './BaseControls/BaseSelectBox';
import { DataGridMessageService, Messages } from '../Services/DataGridMessageService';
import { Subscription } from 'rxjs';

@Component({
    selector: 'hvl-combobox',
    inputs: ['Required', 'ReadOnly', 'Value',
        'Visible', 'TabIndex', 'Enabled',
        'BackColor', 'ForeColor',
        'Font', 'DisplayPath', 'SelectedValuePath',
        'Items', 'SelectedIndex', 'Name'],
    outputs: ['ValueChange'],
    template: '<dx-select-box [visible]="Visible" [disabled]="!Enabled" [readOnly]="ReadOnly" [(value)]="Value" \
    [displayExpr]="DisplayPath" [valueExpr]="SelectedValuePath" placeholder="Seçiniz" i18n-placeholder="@@M26832"\
    [dataSource]="Items" (onValueChanged)="changed($event)" ></dx-select-box>',
})
export class HvlComboBox extends BaseSelectBox implements OnChanges, AfterViewInit, OnDestroy {

    SelectedIndex: number;
    private gridMessageServiceSubscription: Subscription;

    constructor(
        differs: KeyValueDiffers,
        element: ElementRef, @Optional() private gridMessageService: DataGridMessageService) {
        super(differs, element);
        this.DisplayPath = "Text";
        this.SelectedValuePath = "Value";

        if (gridMessageService) {
            let that = this;
            this.gridMessageServiceSubscription = this.gridMessageService.OnMessage.subscribe(t => {
                if (t.name == that.Name) {
                    if (t.messageName == Messages.ItemsChangeMessage) {
                        that.Items = [];
                        window.setTimeout(() => {
                            that.Items = t.content;
                        }, 0);
                    } else if (t.messageName.startsWith("Font.")) {
                        let fontProperty = t.messageName.substr(t.messageName.indexOf('.') + 1);
                        this.Font[fontProperty] = t.content;
                        this.setAppearence();
                    }
                    else {
                        that[t.messageName] = t.content;
                        this.setAppearence();
                    }
                }
            });
        }
    }

    changed(val: any) {
        this.ValueChange.emit(val.value);
    }

    ngAfterViewInit() {
        if (this.gridMessageService) {
        }
        this.element.nativeElement.parentElement.parentElement.style.padding = "0px";
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['SelectedIndex']) {
            if (this.SelectedIndex && this.Items.length > this.SelectedIndex) {
                let value = this.Items[this.SelectedIndex][this.SelectedValuePath];
                this.Value = value;
                this.ValueChange.emit(this.Value);
            }
        }
        super.ngOnChanges(changes);
    }

  ngOnDestroy() {
        if (this.gridMessageServiceSubscription != null) {
            this.gridMessageServiceSubscription.unsubscribe();
            this.gridMessageServiceSubscription = null;
        }
    }
}