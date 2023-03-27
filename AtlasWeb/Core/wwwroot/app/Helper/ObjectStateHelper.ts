import { Injectable } from '@angular/core';
import { TTObjectStateDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateDef';
import { DefinitionService } from 'Fw/Services/DefinitionService';
import { MessageService } from 'Fw/Services/MessageService';


@Injectable()
// @Component({
//        providers: [MessageService, DefinitionService]
// })
export class ObjectStateHelper {

    private objectStates: Array<TTObjectStateDef>;

    public async getStateDefinitions(objectDefID: string): Promise<Array<TTObjectStateDef>> {
        this.objectStates = await this.definitionService.getObjectStateDefList(objectDefID);
        return this.objectStates;
    }

    constructor(private definitionService: DefinitionService, private messageService: MessageService) {
        this.objectStates = new Array<TTObjectStateDef>();
    }

}