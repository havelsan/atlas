import { Pipe } from '@angular/core';

@Pipe({ name: 'ListSelection' })
export class ListSelectionPipe {
    constructor() { }

    transform(value: any, ...args: any[]): any {
        debugger;
    }
}