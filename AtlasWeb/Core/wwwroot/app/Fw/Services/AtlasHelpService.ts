import { Injectable } from '@angular/core';
import { IHelpService } from 'Fw/Services/IHelpService';
import { WindowRef } from 'NebulaClient/Mscorlib/WindowRef';

@Injectable()
export class AtlasHelpService implements IHelpService {

    constructor(private winRef: WindowRef) {

    }

    public showHelp(helpFileName: string) {
        const nativeWindow = this.winRef.getNativeWindow();
        nativeWindow.open(`/Help/${helpFileName}`);
    }

}