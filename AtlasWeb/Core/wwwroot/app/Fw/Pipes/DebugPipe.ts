import { Pipe } from '@angular/core';

@Pipe({ name: 'Debug' })
export class DebugPipe {
    constructor() { }

    transform(data: any) {
        debugger;
    }
}