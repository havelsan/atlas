import { EnumItem } from './EnumItem';

export abstract class IEnumList {
    abstract get Items(): Array<EnumItem>;
}