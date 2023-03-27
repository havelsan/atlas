import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Size } from '../Models/DockPanel/Layout/Size';

@Injectable()
export class DockPanelService {
    public SizeChanged: Subject<Size>;

    constructor() {
        this.SizeChanged = new Subject<Size>();
    }

    Resize(width: number, height: number) {
        this.SizeChanged.next(new Size(width, height));
    }
}