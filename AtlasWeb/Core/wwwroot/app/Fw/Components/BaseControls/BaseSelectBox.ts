import { EventEmitter, KeyValueDiffers, ElementRef } from '@angular/core';
import { BaseControl } from './BaseControl';

export class BaseSelectBox extends BaseControl {
    SelectedValuePath: string;
    DisplayPath: string;
    Items: Array<any> = [];
    Value: any;
    ValueChange: EventEmitter<any> = new EventEmitter<any>();
    ShowClearButton: boolean;

    constructor(differs: KeyValueDiffers,
        element: ElementRef) {
        super(differs, element);
    }

}