import {
    Component, ElementRef, KeyValueDiffers, OnChanges, SimpleChanges, OnDestroy,
    EventEmitter, DoCheck, Optional, AfterViewInit, ViewChild
} from '@angular/core';
import { DataGridMessageService } from '../Services/DataGridMessageService';
import { BaseControl } from './BaseControls/BaseControl';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DxDateBoxComponent } from 'devextreme-angular';
import { Subscription } from 'rxjs';
@Component({
    selector: "hvl-date-picker",
    inputs: ['Value', 'CustomFormat', 'Format', 'Locked', 'ReadOnly', 'Enabled',
        'Required', 'MultiLine', 'CharacterCasing', 'Min', 'Max',
        'InputFormat', 'InputTurkishCharacter', 'TextAlign',
        'Disabled', 'Visible', 'TabIndex', 'BackColor',
        'ForeColor', 'Font', 'Mode', 'ValidationConfiguration', 'Name', 'ShowClearButton'],
    outputs: ['ValueChange'],
    template: `<dx-date-box [(value)]="Value" (keydown)="keydown($event)" [min]="Min" [max]="Max" [visible]="Visible"  [disabled]="!Enabled" [readOnly]="ReadOnly" [(isValid)]="isValid" [validationError]="validationError" [pickerType]="pickerType" [type]="dateType" (onValueChanged)="changed($event)" [showClearButton]="ShowClearButton" [ngStyle]=\"{\'width\':\'100%\'}\" height="height">
    </dx-date-box>`
})
export class HvlDatePicker extends BaseControl implements OnChanges, DoCheck, AfterViewInit, OnDestroy {
    _Min: any;
    _Max: any;
    //@Input()
    get Max(): Date {
        return this._Max;
    }
    //@Input()
    set Max(val: Date) {
        this._Max = val;
    }
    //@Input()
    get Min(): Date {
        return this._Min;
    }
    //@Input()
    set Min(val: Date) {
        this._Min = val;
    }
    Format: DateTimePickerFormat;
    CustomFormat: string = "dd/MM/yyyy";
    dpFormat: string = "dd/MM/yyyy";
    Locked: boolean = false;
    pickerType: string = "calendar";
    dateType: string;
    Value: any;
    ValueChange: EventEmitter<any> = new EventEmitter<any>();
    @ViewChild(DxDateBoxComponent) DateBox;
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
                        this.setAppearence();
                    }
                    else {
                        that[t.messageName] = t.content;
                        if (t.messageName == "Format") {
                            this.changeFormat();
                        }
                        this.setAppearence();
                    }
                }
            });
        }
    }

    Clear() {
        if (this.DateBox) {
            this.DateBox.instance.reset();
        }
    }

    toggleReadOnly(readOnly: Boolean, enable: Boolean) {
        this.DateBox.readOnly = readOnly;
        this.DateBox.disabled = !enable;
    }

    keydown(event: any) {
        if (event.keyCode >= 65 && event.keyCode <= 90) {
            event.preventDefault();
            return false;
        }
    }

    ngDoCheck() {
        super.ngDoCheck();
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['Value'] || changes['Required']) {
            this.Validate(this.Value);
        }
        if (changes['ReadOnly']) {
            this.Locked = this.ReadOnly;
        }
        if (changes['Format']) {
            this.changeFormat();
        }
        //if (changes['CustomFormat']) {
        //    if (this.CustomFormat == undefined || this.CustomFormat != "")
        //        this.CustomFormat = "dd/MM/yyyy";
        //}
        if (changes['showClearButton'] && this.ShowClearButton == undefined) {
            this.ShowClearButton = false;
        }
        super.ngOnChanges(changes);
    }

    ngAfterViewInit() {
        if (this.gridMessageService) {
            this.height = "22px";
        }
        this.element.nativeElement.parentElement.parentElement.style.padding = "0px";
    }

    changeFormat() {
        if (<number>this.Format == DateTimePickerFormat.Long) {
            this.dateType = "datetime";
            this.pickerType = "calendar";
        }
        else if (<number>this.Format == DateTimePickerFormat.Short) {
            this.dateType = "date";
            this.pickerType = "calendar";
        }
        else if (<number>this.Format == DateTimePickerFormat.Time) {
            this.dateType = "time";
            this.pickerType = "calendar";
        }
        else if (<number>this.Format == DateTimePickerFormat.Custom) {
            this.dateType = "date";
            this.pickerType = "calendar";
        }
        else {
            this.dateType = "date";
            this.pickerType = "calendar";
        }
    }

    changed(date: any) {
        this.Validate(date.value);
        this.ValueChange.emit(date.value);
    }

    public SetMinMax(min, max) {
        this.Min = min;
        this.Max = max;
    }

    ngOnDestroy() {
        if (this.gridMessageServiceSubscription != null) {
            this.gridMessageServiceSubscription.unsubscribe();
            this.gridMessageServiceSubscription = null;
        }
    }
}