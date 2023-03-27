import { Component, EventEmitter, KeyValueDiffers, ElementRef, OnChanges, SimpleChanges, ViewChild, ChangeDetectorRef } from '@angular/core';
import { BaseInputControl } from './BaseControls/BaseInputControl';
import { DxTextBoxComponent } from 'devextreme-angular';

@Component({
    selector: 'hvl-button-textbox',
    inputs: ['Enabled', 'Text', 'Required', 'ReadOnly', 'Name', 'Font', 'placeHolder', 'Visible', 'TabIndex', 'Type',
        'BackColor', 'ForeColor', 'ButtonWidth', 'ShowClearButton', 'ButtonOnRight', 'Icon', 'ButtonText', 'ButtonEnabled'],
    outputs: ['TextChange', 'Clicked'],
    template: '<div class="input-group" *ngIf="Visible" style="width:100%">\
        <span class="input-group-btn" *ngIf="!ButtonOnRight">\
            <dx-button type="btn btn-default" [width]="ButtonWidth" [text]="ButtonText"  [disabled]="!ButtonEnabled" [icon]="Icon" (onClick)="Clicked.emit()"></dx-button>\
        </span>\
        <dx-text-box height="20px" [placeholder]="placeHolder" [disabled]="!Enabled" [readOnly]="ReadOnly" [showClearButton]="ShowClearButton" [(value)]="Text" valueChangeEvent="keyup" (onValueChanged)="TextChange.emit($event.value)"></dx-text-box>\
        <span class="input-group-btn" *ngIf="ButtonOnRight">\
            <dx-button type="btn btn-default" [width]="ButtonWidth" [text]="ButtonText" [disabled]="!ButtonEnabled" [icon]="Icon" (onClick)="Clicked.emit()"></dx-button>\
        </span>\
    </div>'
})
export class HvlButtonTextBox extends BaseInputControl implements OnChanges {
    Clicked: EventEmitter<any> = new EventEmitter<any>();
    ButtonWidth: any;
    ButtonText: String;
    Icon: String;
    Type: String;
    ButtonOnRight: Boolean;
    ButtonEnabled: Boolean = true;
    constructor(e: ElementRef, differs: KeyValueDiffers, private detector: ChangeDetectorRef) {
        super(differs, e);
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['ButtonText'] && !this.ButtonText) {
            this.ButtonText = '...';
        }
        if (changes['ButtonEnabled'] && this.ButtonEnabled == false) {
            this.ButtonEnabled = false;
        }
        if (changes['ButtonEnabled'] && this.ButtonEnabled == undefined) {
            this.ButtonEnabled = true;
        }
        if (changes['ButtonOnRight'] && this.ButtonOnRight == undefined) {
            this.ButtonOnRight = true;
        }
        super.ngOnChanges(changes);
    }
}