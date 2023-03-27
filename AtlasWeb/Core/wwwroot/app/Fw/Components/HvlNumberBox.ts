import {
    SimpleChanges, Component, ElementRef, KeyValueDiffers, OnChanges, OnDestroy,
    DoCheck, EventEmitter, Optional, AfterViewInit
} from '@angular/core';
import { BaseControl } from './BaseControls/BaseControl';
import { DataGridMessageService } from '../Services/DataGridMessageService';
import { Subscription } from 'rxjs';

@Component({
    selector: "hvl-number-box",
    inputs: ['Value', 'Disabled', 'Visible', 'Required', 'ValidationConfiguration', 'BackColor', 'ForeColor', 'ReadOnly', 'TabIndex', 'Font', 'Enabled'],
    template: '<dx-number-box [(value)]="Value" [visible]="Visible" [disabled]="!Enabled" [readOnly]="ReadOnly" valueChangeEvent="keyup" mode="number"\
      [validationError]="validationError" [(isValid)]="isValid" (onValueChanged)="changed($event.value)"></dx-number-box>',
    outputs: ['ValueChange']
})
export class HvlNumberBox extends BaseControl implements AfterViewInit, OnChanges, DoCheck, OnDestroy {

    Value: Number;
    ValueChange: EventEmitter<Number> = new EventEmitter<Number>();
    private gridMessageServiceSubscription: Subscription;

    constructor(differs: KeyValueDiffers, element: ElementRef,
        @Optional() private gridMessageService: DataGridMessageService) {
        super(differs, element);
        if (gridMessageService) {
            let that = this;
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

    changed(val: number) {
        this.Validate(val);
        this.ValueChange.emit(<number>val);
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['Value'] || changes['Required']) {
            this.Validate(this.Value);
        }
        super.ngOnChanges(changes);
    }

    ngDoCheck() {
        super.ngDoCheck();
    }

    ngAfterViewInit() {
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