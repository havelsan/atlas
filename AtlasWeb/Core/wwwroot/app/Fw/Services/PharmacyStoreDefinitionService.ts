import { Guid } from "NebulaClient/Mscorlib/Guid";
import { TTObjectContext } from "NebulaClient/StorageManager/InstanceManagement/TTObjectContext";
import { PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';

export class PharmacyStoreDefinitionService {
    public static GetInpatientPharmacyStore(objectContext: TTObjectContext): Array<PharmacyStoreDefinition> {
        return null;
    }
    public static GetPharmacyByUnitStore(objectContext: TTObjectContext, UNITSTORE: Guid): Array<PharmacyStoreDefinition> {
        return null;
    }
}