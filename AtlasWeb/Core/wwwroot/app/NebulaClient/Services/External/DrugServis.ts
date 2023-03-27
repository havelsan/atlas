//$CC5FFA2B
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace DrugServis {
    export class AuditRow {
        public Id: string;
        public IP: string;
        public MAC: string;
        public ChangeSet: string;
        public Key1: string;
        public Key2: string;
        public Date: Date;
        public IUD: string;
        public ObjectName: string;
    }

    export class WebMethods {
        public static async GetLastAuditsSync(siteID: Guid, userName: string, password: string, LastRowId: string): Promise<AuditRow[]> {
            let url: string = "/api/DrugServisController/GetLastAuditsSync";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "LastRowId": LastRowId };
            let result = await ServiceLocator.post(url, inputDto) as AuditRow[];
            return result;
        }
        public static async GetLastAuditsXXXXXXSync(siteID: Guid, userName: string, password: string, LastRowId: string): Promise<AuditRow[]> {
            let url: string = "/api/DrugServisController/GetLastAuditsXXXXXXSync";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "LastRowId": LastRowId };
            let result = await ServiceLocator.post(url, inputDto) as AuditRow[];
            return result;
        }
    }
}
