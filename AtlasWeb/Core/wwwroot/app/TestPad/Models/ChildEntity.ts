import { Injectable } from '@angular/core';
import { ParentEntity } from './ParentEntity';
import { ClassType, Type } from 'NebulaClient/ClassTransformer';

@Injectable()
@ClassType()
export class ChildEntity {

    @Type(() => Number)
    public ID: number;

    public Name: string;

    @Type('ParentEntity')
    public ExtraParent: ParentEntity;
}

