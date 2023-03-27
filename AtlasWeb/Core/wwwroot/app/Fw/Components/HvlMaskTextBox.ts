import { Component, ElementRef, KeyValueDiffers, Optional, AfterViewInit, OnChanges, OnDestroy, SimpleChanges } from '@angular/core';
import { DataGridMessageService } from '../Services/DataGridMessageService';
import { BaseInputControl } from './BaseControls/BaseInputControl';
import { Subscription } from 'rxjs';

@Component({
    selector: "hvl-masktext-box",
    inputs: ['Mask', 'Text', 'Name',
        'Required', 'MultiLine', 'ReadOnly',
        'InputFormat', 'InputTurkishCharacter', 'TextAlign', 'Enabled',
        'Disabled', 'Visible', 'TabIndex', 'BackColor',
        'ForeColor', 'Font', 'Mode', 'ValidationConfiguration'],
    outputs: ['TextChange'],
    template: '<dx-text-box [ngClass]="[\'form-control\']" [(value)]="Text" useMaskedValue="true" \
    [mask]="Mask" [visible]="Visible"  [disabled]="!Enabled" [readOnly]="ReadOnly" (onFocusIn)="focus()" \
    (keydown)="onKey($event)" [(isValid)]="isValid" height="height" valueChangeEvent="blur"\
    [validationError]="validationError" (onValueChanged)="valueChanged($event.value)"></dx-text-box>',
})
export class HvlMaskTextBox extends BaseInputControl implements AfterViewInit, OnChanges, OnDestroy {
    inputElement: HTMLInputElement;
    Mask: string;
    private gridMessageServiceSubscription: Subscription;

    constructor(differs: KeyValueDiffers, element: ElementRef,
        @Optional()
        private gridMessageService: DataGridMessageService) {
        super(differs, element);

        if (this.gridMessageService) {
            let that = this;
            this.gridMessageServiceSubscription = this.gridMessageService.OnMessage.subscribe(t => {
                if (t.name == that.Name) {
                    if (t.messageName.startsWith("Font.")) {
                        let fontProperty = t.messageName.substr(t.messageName.indexOf('.') + 1);
                        this.Font[fontProperty] = t.content;
                    }
                    else
                        that[t.messageName] = t.content;
                    this.setAppearence();
                }
            });
        }
    }

    focus() {
        //this.inputElement.selectionStart = 0;
        window.setTimeout(() => {
            if (this.inputElement.setSelectionRange) {
                this.inputElement.setSelectionRange(0, 0);
            }
            this.inputElement.selectionStart = 0;
            this.inputElement.selectionEnd = 0;
        }, 0);
        //else if (this.inputElement.createTextRange) {
        //    var range = this.inputElement.createTextRange();
        //    range.collapse(true);
        //    range.moveEnd('character', 0);
        //    range.moveStart('character', 0);
        //    range.select();
        //}
    }

    valueChanged(data: any) {
        this.TextChange.emit(data);
    }

    ngOnChanges(changes: SimpleChanges) {
        super.ngOnChanges(changes);
    }

    ngAfterViewInit() {
        this.inputElement = this.element.nativeElement.getElementsByClassName('dx-texteditor-input')[0];
        if (this.gridMessageService) {
            this.height = "22px";
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