import { Injectable } from '@angular/core';
import { ChildEntity } from './ChildEntity';
import { ClassType, Type } from 'NebulaClient/ClassTransformer';

@Injectable()
@ClassType()
export class ParentEntity {

    @Type(() => Number)
    public ID: number;

    public Name: string;

    @Type('ChildEntity')
    public Children: Array<ChildEntity>;

}
