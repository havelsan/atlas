import { Injectable } from '@angular/core';

@Injectable()
export class SystemMessageService {

    static GetMessage(code: number): string;
    static GetMessage(code: number, sDefaultValue: string): string;
    static GetMessage(code: number, parameters: string[]): string;
    static GetMessage(...prms): string {
        if (arguments.length === 1) {
            return null; //static GetMessage(code: number): string;
        }
        if (arguments.length === 2 && typeof (prms[1]) === 'string') {
            return null; // static GetMessage(code: number, sDefaultValue: string): string;
        }
        if (arguments.length === 2 &&  (prms[1]) instanceof Array) {
            return null; //static GetMessage(code: number, parameters: string[]): string;
        }

    }
}
