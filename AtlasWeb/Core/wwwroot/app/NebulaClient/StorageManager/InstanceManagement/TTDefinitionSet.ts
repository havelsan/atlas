import { TTObject } from "../../StorageManager/InstanceManagement/TTObject";

export class TTDefinitionSet extends TTObject {
    constructor() {
        super();
    }
    public get IsActive(): boolean {
        return <boolean>this["IsActive"];
    }
    public set IsActive(value: boolean) {
        this["IsActive"] = value;
    }
    public get LastUpdate(): Date {
        return <Date>this["LastUpdate"];
    }
    public set LastUpdate(value: Date) {
        this["LastUpdate"] = value;
    }
}