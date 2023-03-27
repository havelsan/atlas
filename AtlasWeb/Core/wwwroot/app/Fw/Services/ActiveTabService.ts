import { Injectable } from '@angular/core';
import { IActiveTabService } from './IActiveTabService';

@Injectable()
export class ActiveTabService implements IActiveTabService {


    public ActiveTabSource: Map<string, string> = new Map<string, string>();

    public ActiveTabID: string;
    public ActiveTabPage: string;

    constructor() {

    }

    public setActiveTab(ActiveTabID: string, ActiveTabPage: string): void {
        this.ActiveTabSource.set(ActiveTabPage, ActiveTabID);
        localStorage.setItem(ActiveTabPage, ActiveTabID);
    }

    public getActiveTab(ActiveTabPage: string): string {
        if (this.ActiveTabSource != undefined || this.ActiveTabSource != null){
            let result = localStorage.getItem(ActiveTabPage);
            if (result)
                return result;
            else
                return  this.ActiveTabSource.get(ActiveTabPage);
        }
    }


}
