import { Component, KeyValueDiffers, ElementRef, Optional
    , OnChanges, OnDestroy, SimpleChanges, AfterViewInit } from '@angular/core';
import { BaseInputControl } from './BaseControls/BaseInputControl';
import { DataGridMessageService } from '../Services/DataGridMessageService';
import { Subscription } from 'rxjs';
import { CharacterCasing } from 'NebulaClient/Utils/Enums/CharacterCasing';

@Component({
    selector: "hvl-text-box",
    inputs: ['IsNonNumeric',
        'Required', 'MultiLine', 'CharacterCasing', 'ReadOnly',
        'InputFormat', 'InputTurkishCharacter', 'TextAlign', 'changeEvent',
        'Disabled', 'Visible', 'TabIndex', 'BackColor', 'height',
        'ForeColor', 'Font', 'Mode', 'ValidationConfiguration', 'Name', 'Enabled', 'ngClass', 'autoResizeEnabled', 'PlaceHolder'],
    outputs: ['TextChange'],
    template: `<dx-text-box [(value)]="Text" [height]="height" width="100%" [ngClass]="ngClass"
    [mode]="Mode" *ngIf="!MultiLine"
    [visible]="Visible" [disabled]="!Enabled" [readOnly]="ReadOnly"
    (keydown)="onKey($event)" [(isValid)]="isValid" [validationError]="validationError" (onValueChanged)="changed(Text)" [valueChangeEvent]="changeEvent" [placeholder]="PlaceHolder">
    </dx-text-box>
    <dx-text-area *ngIf="MultiLine" [(isValid)]="isValid" [validationError]="validationError" [(value)]="Text" [height]="height" [valueChangeEvent]="changeEvent"[visible]="Visible" [disabled]="!Enabled" [readOnly]="ReadOnly" (onFocusOut)="changed(Text)" [autoResizeEnabled]="autoResizeEnabled" [placeholder]="PlaceHolder">
    </dx-text-area>`,
})
export class HvlTextBox extends BaseInputControl implements OnChanges, AfterViewInit, OnDestroy {
    changeEvent: String = "keyup";
    private gridMessageServiceSubscription: Subscription;
    CharacterCasing: CharacterCasing;
    ngClass = [];
    
    constructor(differs: KeyValueDiffers, element: ElementRef,
        @Optional() private gridMessageService: DataGridMessageService) {
        super(differs, element);

        if (gridMessageService) {
            let that = this;
            //that.changeEvent = "blur";
            this.gridMessageServiceSubscription = this.gridMessageService.OnMessage.subscribe(t => {
                if (t.name == that.Name) {
                    if (t.messageName.startsWith("Font.")) {
                        let fontProperty = t.messageName.substr(t.messageName.indexOf('.') + 1);
                        that.Font[fontProperty] = t.content;
                    }
                    else {
                        that[t.messageName] = t.content;
                    }
                    that.setAppearence();
                }
            });
        }
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['Value'] || changes['Required']) {
            this.Validate(this.Text);
        }
        if (changes['changeEvent'] && !this.changeEvent) {
            this.changeEvent = 'keyup';
        }
        let casing: CharacterCasing = <number>this.CharacterCasing || CharacterCasing.Normal;
        if (casing == CharacterCasing.Upper) {
            this.changeEvent = 'change';
        }
        super.ngOnChanges(changes);
    }

    ngDoCheck() {
        super.ngDoCheck();
    }

    ngAfterViewInit() {
        if (this.gridMessageService) {
            this.height = "22px";
            this.element.nativeElement.parentElement.parentElement.style.padding = "0px";
        }
    }

    ngOnDestroy() {
        if (this.gridMessageServiceSubscription != null) {
            this.gridMessageServiceSubscription.unsubscribe();
            this.gridMessageServiceSubscription = null;
        }
    }
}