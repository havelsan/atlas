import { Component, Output, EventEmitter } from '@angular/core';

@Component({
selector: 'dyn-test-comp',
template: `<h2>Dynamic Test Component</h2>
<button (click)="onClick()">Test Event</button>
`
})
export class DynamicTestComponent {

    @Output() click: EventEmitter<string> = new  EventEmitter<string>();

    public onClick() {
        this.click.emit('OK');
    }
}
