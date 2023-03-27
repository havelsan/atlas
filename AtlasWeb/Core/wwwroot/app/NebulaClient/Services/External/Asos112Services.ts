//$58DBE58A
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { TTObjectContext } from "NebulaClient/StorageManager/InstanceManagement/TTObjectContext";
import { Exception } from "NebulaClient/Mscorlib/Exception";
import { IWebMethodCallback } from "NebulaClient/Utils/IWebMethodCallback";

export namespace XXXXXX112Services {
    export class AsyncBase {
        constructor() {
            this.MessageObjectID = Guid.newGuid().toString();
        }

        public MessageObjectID: string;
        public MedulaProvisionObjectID: string;
    }


    export class EUYSTaniGonderParam extends AsyncBase implements IWebMethodCallback {
        constructor() {
            super();
        }

        public ObjectContext: TTObjectContext;
        public WebMethodCallback(returnValue: any, calledParameters: any[], messageException: Exception): boolean {
            if (returnValue !== null) {
                let result: number = <number>returnValue;
                if (result !== 1) {
                    //string medulaProvisionObjectID = MedulaProvisionObjectID;
                    this.HastaKabulCompletedInternal(result, this.ObjectContext);
                    //MedulaHelper.SaveAndDisposeContext(ObjectContext);
                    return false;
                }
                else return true;
            }
            else return true;
        }
        public HastaKabulCompletedInternal(result: number, _context: TTObjectContext): void {

        }
    }


    export class VakaSonlandirParam extends AsyncBase implements IWebMethodCallback {
        constructor() {
            super();
        }

        public ObjectContext: TTObjectContext;
        public WebMethodCallback(returnValue: any, calledParameters: any[], messageException: Exception): boolean {
            //                if (returnValue != null)
            //                {
            //                   int? result = (int?)returnValue;
            //                    if (result != 1)
            //                    {
            //                        //string medulaProvisionObjectID = MedulaProvisionObjectID;
            //                        HastaKabulCompletedInternal(result, ObjectContext);
            //                        //MedulaHelper.SaveAndDisposeContext(ObjectContext);
            //                        return false;
            //                    }
            //                    else
            return true;
        }
    }


    export class WebMethods {

    }
}
