import { Injectable } from '@angular/core';
import { IHashService } from 'Fw/Services/IHashService';
import * as ObjectHash from 'object-hash';

@Injectable()
export class AtlasHashService implements IHashService {

    public sha1(object: any, excludeKeyList?: any): string {
        const options: any = {
            algorithm: 'sha1', excludeKeys: (k) => {
                if (excludeKeyList && excludeKeyList.hasOwnProperty(k) === true) {
                    return false;
                }
                return true;
            }
        };

        if (excludeKeyList) {
            const objectHashWithExcludeKeys = ObjectHash(object, options);
            return objectHashWithExcludeKeys;
        }

        const objectHash = ObjectHash.sha1(object);
        return objectHash;
    }

    public MD5(object: any, excludeKeyList?: any): string {
        const options: any = {
            algorithm: 'md5', excludeKeys: (k) => {
                if (excludeKeyList && excludeKeyList.hasOwnProperty(k) === true) {
                    return false;
                }
                return true;
            }
        };

        if (excludeKeyList) {
            const objectHashWithExcludeKeys = ObjectHash(object, options);
            return objectHashWithExcludeKeys;
        }
        const objectHash = ObjectHash.MD5(object);
        return objectHash;
    }

}


