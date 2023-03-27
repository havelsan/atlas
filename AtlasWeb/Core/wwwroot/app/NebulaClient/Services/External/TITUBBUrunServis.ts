//$609D5130
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace TITUBBUrunServis {
    export class ProductServiceResult {
        public Products: Array<Product>;
    }

    export class Product {
        public ObjectID: Guid;
        public TITUBBProductID: string;
        public ProductNumber: string;
        public Name: string;
        public ProductNumberType: string;
        public Firm: Firm;
        public ProductSUTMatches: Array<ProductSUTMatch>;
        public RegistrationDate: Date;
    }

    export class Firm {
        public ObjectID: Guid;
        public TITUBBFirmID: string;
        public IdentityNumber: number;
        public Name: string;
        public RegistrationDate: Date;
    }

    export class SUTAppendix {
        public ObjectID: Guid;
        public TITUBBSUTAppendixID: string;
        public Name: string;
    }

    export class ProductSUTMatch {
        public ObjectID: Guid;
        public SUTCode: string;
        public SUTName: string;
        public SUTPrice: number;
        public TITUBBProductSUTMatchID: string;
        public ProductID: Guid;
        public SUTAppendixID: Guid;
        public Product: Product;
        public SUTAppendix: SUTAppendix;
    }

    export class WebMethods {
        public static async GetUrunSync(siteID: Guid, userName: string, password: string, barkod: string): Promise<ProductServiceResult> {
            let url: string = "/api/TITUBBUrunServisController/GetUrunSync";
            let inputDto = { "siteID": siteID, "userName": userName, "password": password, "barkod": barkod };
            let result = await ServiceLocator.post(url, inputDto) as ProductServiceResult;
            return result;
        }
    }
}
