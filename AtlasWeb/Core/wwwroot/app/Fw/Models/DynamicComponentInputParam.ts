import { ActiveIDsModel } from 'Fw/Models/ParameterDefinitionModel';

export class DynamicComponentInputParam {
    constructor(public data?: any, public activeIDsModel?: ActiveIDsModel) {
        this.data = data;
        this.activeIDsModel = activeIDsModel;
    }
}
