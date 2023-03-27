import { Component, SimpleChanges, OnChanges, KeyValueDiffers, ElementRef, Input} from '@angular/core';
import { HvlEnumComboBox } from './HvlEnumComboBox';
import { ConfigurationCacheService } from 'Fw/Services/ConfigurationCacheService';
import { NeHttpService } from 'Fw/Services/NeHttpService';

@Component({
    selector: 'hvl-enum-radio-button-group',
    inputs: ['Required', 'ReadOnly', 'Value', 'Name', 'Enabled', 'Visible', 'TabIndex', 'BackColor', 'ForeColor', 'Font', 'DataTypeName', 'ShowClearButton', 'VisibleFirstSpan', 'VisibleLastSpan', 'LastSpanCount', 'FirstSpanCount', 'IsHorizontal'],
    outputs: ['ValueChange'],
    template: '<hvl-radio-button-group [IsHorizontal]="IsHorizontal" [Enabled]="Enabled" [disabled]="!Enabled" [ReadOnly]="ReadOnly" [Visible]="Visible" [Items]="Items" [(Value)]="Value" (ValueChange)="valueChanged($event)" \
                DisplayPath="Name" SelectedValuePath="Value"></hvl-radio-button-group>'
})
export class HvlEnumRadio extends HvlEnumComboBox implements OnChanges {
    IsHorizontal: Boolean;
    constructor(differs: KeyValueDiffers, element: ElementRef, http: NeHttpService, configCache: ConfigurationCacheService) {
        super(differs, element, http, null, configCache);
    }

    ngOnChanges(changes: SimpleChanges) {
        if (this.IsHorizontal == undefined) {
            this.IsHorizontal = true;
        }
        super.ngOnChanges(changes);
    }
}

@Component({
    selector: 'hvl-enum-button-radio-group',
    inputs: ['Required', 'ReadOnly', 'Value', 'Name', 'Enabled', 'Visible', 'TabIndex', 'BackColor', 'ForeColor', 'Font', 'DataTypeName', 'ShowClearButton', 'LastSpanCount', 'FirstSpanCount', 'IsHorizontal'],
    outputs: ['ValueChange'],
    template: '<hvl-button-radio-group *ngIf="IsHorizontal" [Enabled]="Enabled" [Visible]="Visible" [Items]="Items" [(Value)]="Value" (ValueChange)="valueChanged($event)" \
                DisplayPath="Name" SelectedValuePath="Value" [VisibleFirstSpan]="VisibleFirstSpan" [VisibleLastSpan]="VisibleLastSpan" [LastSpanCount]="LastSpanCount" [FirstSpanCount]="FirstSpanCount" ></hvl-button-radio-group>\
                <hvl-vertical-radio-group *ngIf="!IsHorizontal" [ShowValues]="ShowValues" [Enabled]="Enabled" [Visible]="Visible" [Items]="Items" [(Value)]="Value" (ValueChange)="valueChanged($event)" \
                DisplayPath="Name" SelectedValuePath="Value" [VisibleFirstSpan]="VisibleFirstSpan" [VisibleLastSpan]="VisibleLastSpan" ></hvl-vertical-radio-group>'
})
export class HvlEnumRadioButton extends HvlEnumComboBox implements OnChanges {
    IsHorizontal: Boolean;
    ShowValues: Boolean = false;
    constructor(differs: KeyValueDiffers, element: ElementRef, http: NeHttpService, configCache: ConfigurationCacheService) {
        super(differs, element, http, null, configCache);
    }
    @Input() VisibleLastSpan: boolean;
    @Input() VisibleFirstSpan: boolean;
    ngOnChanges(changes: SimpleChanges) {
        if (this.IsHorizontal == undefined) {
            this.IsHorizontal = true;
        }
        super.ngOnChanges(changes);
    }
}

@Component({
    selector: 'hvl-enum-image-radio-group',
    inputs: ['Required', 'ReadOnly', 'Value', 'Name', 'Enabled', 'Visible', 'TabIndex', 'BackColor', 'ForeColor', 'Font', 'DataTypeName', 'ShowClearButton'],
    outputs: ['ValueChange'],
    template: '<hvl-image-radio-group [Enabled]="Enabled" [Visible]="Visible" [Items]="Items" [(Value)]="Value" (ValueChange)="valueChanged($event)" \
                DisplayPath="Name" SelectedValuePath="Value" [VisibleFirstSpan]="VisibleFirstSpan" [VisibleLastSpan]="VisibleLastSpan" ></hvl-image-radio-group>'
})
export class HvlEnumImageRadioButton extends HvlEnumComboBox implements OnChanges {
    constructor(differs: KeyValueDiffers, element: ElementRef, http: NeHttpService, configCache: ConfigurationCacheService) {
        super(differs, element, http, null, configCache);
    }
    @Input() VisibleLastSpan: boolean;
    @Input() VisibleFirstSpan: boolean;
    ngOnChanges(changes: SimpleChanges) {
        super.ngOnChanges(changes);
    }
}


@Component({
    selector: 'hvl-enum-vertical-radio-group',
    inputs: ['Required', 'ReadOnly', 'Value', 'Name', 'Enabled', 'Visible', 'TabIndex', 'BackColor', 'ForeColor', 'Font', 'DataTypeName', 'ShowClearButton'],
    outputs: ['ValueChange'],
    template: '<hvl-vertical-radio-group [Enabled]="Enabled" [Visible]="Visible" [Items]="Items" [(Value)]="Value" (ValueChange)="valueChanged($event)" \
                DisplayPath="Name" SelectedValuePath="Value" [VisibleFirstSpan]="VisibleFirstSpan" [VisibleLastSpan]="VisibleLastSpan" ></hvl-vertical-radio-group>'
})
export class HvlEnumVerticalRadioButton extends HvlEnumComboBox implements OnChanges {
    constructor(differs: KeyValueDiffers, element: ElementRef, http: NeHttpService, configCache: ConfigurationCacheService) {
        super(differs, element, http, null, configCache);
    }
    @Input() VisibleLastSpan: boolean;
    @Input() VisibleFirstSpan: boolean;
    ngOnChanges(changes: SimpleChanges) {
        super.ngOnChanges(changes);
    }
}