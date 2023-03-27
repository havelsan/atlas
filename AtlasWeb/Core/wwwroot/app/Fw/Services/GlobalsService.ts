import {Injectable} from '@angular/core';
import {Subject} from 'rxjs';

@Injectable()
export class GlobalsService {
    public UserName: String;
    public IsLoggedIn: Boolean;
    public Busy: Subject<Boolean>;

    constructor() {
        this.Busy = new Subject<Boolean>();
    }
}