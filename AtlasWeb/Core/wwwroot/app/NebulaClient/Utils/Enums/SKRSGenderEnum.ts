import { EnumItem } from "app/NebulaClient/Mscorlib/EnumItem";
import { ClassType } from "app/NebulaClient/ClassTransformer";
import { IEnumList } from "app/NebulaClient/Mscorlib/IEnumList";

//SKRSCinsiyet Tablosunda ki değerlere göre yapıldı.
export enum SKRSGenderEnum {
    Male = 1,
    Female = 2
}

export namespace SKRSGenderEnum {
    export const _Male = new EnumItem(SKRSGenderEnum.Male, 'ERKEK', i18n('M13837', 'Erkek'), 1);
    export const _Female = new EnumItem(SKRSGenderEnum.Female, 'KADIN', i18n('M17061', 'Kadın'), 2);
    export const Items: Array<EnumItem> = [_Male, _Female];

    @ClassType()
    export class GenderEnumList implements IEnumList {
        get Items(): Array<EnumItem> {
            return SKRSGenderEnum.Items;
        }
    }
}