import { Pipe, PipeTransform } from '@angular/core';
import { Util } from '../Components/Util';

@Pipe({ name: 'ArrayFilterPipe' })
export class ArrayFilterPipe implements PipeTransform {
    transform(value: Array<any>, ...args: any[]): any {
        //let mode: SearchMode;
        let searchExpression: String;
        let searchStr: string;
        //if (args.length >= 1 && args[0])
        //mode = <SearchMode>args[0];
        if (args.length >= 1 && args[0])
            searchExpression = args[0].toString();
        if (args.length >= 2 && args[1])
            searchStr = args[1].toString();
        if (!searchStr || searchStr == '') {
            return value;
        }
        searchStr = Util.turkishToLower(searchStr);
        return value.filter(val => {
            let resolved: String = Util.ResolveProperty(searchExpression, val);
            if (resolved) {
                resolved = Util.turkishToLower(resolved);
                if (resolved.startsWith(searchStr)) {
                    return value;
                }
            }
        });
    }
}