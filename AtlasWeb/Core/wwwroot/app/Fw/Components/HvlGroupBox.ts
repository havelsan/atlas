import { Component, KeyValueDiffers, ElementRef } from '@angular/core';
import { BaseControl } from './BaseControls/BaseControl';

@Component({
    selector: "hvl-group-box",
    inputs: ['Text'],
    template: '<div class="panel panel-default">\
    <div class="panel-heading">{{Text}}</div>\
        <div class="panel-body">\
            <ng-content></ng-content>\
        </div>\
    </div>'
})
export class HvlGroupBox extends BaseControl {
    Text: string = "";

    constructor(differs: KeyValueDiffers,
        element: ElementRef) {
        super(differs, element);
    }
}