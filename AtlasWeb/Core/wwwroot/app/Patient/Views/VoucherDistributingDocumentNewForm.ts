//$C3BF345B
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Component, ViewChild, OnInit } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { DxDataGridComponent } from "devextreme-angular";
import { VoucherDistributingDocumentNewFormViewModel } from "../Models/VoucherDistributingDocumentNewFormViewModel";
import { VoucherDistributingDocument } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { SignUserTypeEnum } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'test-comp',
    template: `<h1>VoucherDistributingDocumentNewForm</h1>`
})
export class VoucherDistributingDocumentNewForm implements OnInit {
    @ViewChild(DxDataGridComponent) dataGridInstance: DxDataGridComponent;

    public ViewModel: VoucherDistributingDocumentNewFormViewModel = new VoucherDistributingDocumentNewFormViewModel();

    public get _VoucherDistributingDocument(): VoucherDistributingDocument {
        return this.ViewModel._VoucherDistributingDocument;
    }

    private documentUrl: string = '/api/VoucherDistributeService/VoucherDistributingDocumentNewForm';

    constructor(private http: Http) {
        //this.ViewModel = new VoucherDistributingDocumentNewFormViewModel();

    }

    ngOnInit(): void {

        let that = this;

        let fullApiUrl: string = this.documentUrl + "/7a035c94-ff37-47cc-872e-fb00983d594e";
        this.http.get(fullApiUrl)
            .toPromise()
            .then(response => {

                that.ViewModel = <VoucherDistributingDocumentNewFormViewModel>response.json();
                let destinationStoreObjectID = that.ViewModel._VoucherDistributingDocument["DestinationStore"];
                if (destinationStoreObjectID !== undefined) {
                    let destinationStore = that.ViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
                    that.ViewModel._VoucherDistributingDocument.DestinationStore = destinationStore;
                    if (destinationStore !== undefined) {
                        let unitStoreGetDataObjectID = destinationStore["UnitStoreGetData"];
                        if (unitStoreGetDataObjectID !== undefined) {
                            let unitStoreGetData = that.ViewModel.UnitStoreGetDatas.find(o => o.ObjectID.toString() === unitStoreGetDataObjectID.toString());
                            destinationStore.UnitStoreGetData = unitStoreGetData;
                        }
                    }
                    if (destinationStore !== undefined) {
                        destinationStore.Stocks = that.ViewModel.StocksStockGridList;
                        for (let detailItem of that.ViewModel.StocksStockGridList) {
                            let storeObjectID = detailItem["Store"];
                            if (storeObjectID !== undefined) {
                                let store = that.ViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
                                detailItem.Store = store;
                            }
                            let materialObjectID = detailItem["Material"];
                            if (materialObjectID !== undefined) {
                                let material = that.ViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                                detailItem.Material = material;
                            }
                        }
                    }
                }
                let storeObjectID = that.ViewModel._VoucherDistributingDocument["Store"];
                if (storeObjectID !== undefined) {
                    let store = that.ViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
                    that.ViewModel._VoucherDistributingDocument.Store = store;
                    if (store !== undefined) {
                        store.Stocks = that.ViewModel.StocksStockGridGridList;
                        for (let detailItem of that.ViewModel.StocksStockGridGridList) {
                            let storeObjectID = detailItem["Store"];
                            if (storeObjectID !== undefined) {
                                let store = that.ViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
                                detailItem.Store = store;
                            }
                            let materialObjectID = detailItem["Material"];
                            if (materialObjectID !== undefined) {
                                let material = that.ViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                                detailItem.Material = material;
                            }
                        }
                    }
                }
                that.ViewModel._VoucherDistributingDocument.VoucherDistributingDocumentMaterials = that.ViewModel.StockActionOutDetailsGridList;
                for (let detailItem of that.ViewModel.StockActionOutDetailsGridList) {
                    let materialObjectID = detailItem["Material"];
                    if (materialObjectID !== undefined) {
                        let material = that.ViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                        detailItem.Material = material;
                        if (material !== undefined) {
                            let stockCardObjectID = material["StockCard"];
                            if (stockCardObjectID !== undefined) {
                                let stockCard = that.ViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                                material.StockCard = stockCard;
                                if (stockCard !== undefined) {
                                    let distributionTypeObjectID = stockCard["DistributionType"];
                                    if (distributionTypeObjectID !== undefined) {
                                        let distributionType = that.ViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                        stockCard.DistributionType = distributionType;
                                    }
                                }
                            }
                        }
                    }
                    let stockLevelTypeObjectID = detailItem["StockLevelType"];
                    if (stockLevelTypeObjectID !== undefined) {
                        let stockLevelType = that.ViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                        detailItem.StockLevelType = stockLevelType;
                    }
                }
                that.ViewModel._VoucherDistributingDocument.StockActionSignDetails = that.ViewModel.StockActionSignDetailsGridList;
                for (let detailItem of that.ViewModel.StockActionSignDetailsGridList) {
                    let signUserObjectID = detailItem["SignUser"];
                    if (signUserObjectID !== undefined) {
                        let signUser = that.ViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                        detailItem.SignUser = signUser;
                    }
                }


                console.log("OK");
            })
            .catch(error => {
                console.log(error);
            });

    }

    public kontrol(): void {
        console.log(this.ViewModel);
        let docMat = this.ViewModel._VoucherDistributingDocument.VoucherDistributingDocumentMaterials[0];
        let material = new Material();
        material.ObjectID = Guid.newGuid();
        material.Name = i18n("M12594", "Deneme Malzeme");
        docMat.Material = material;
        this.dataGridInstance.instance.refresh();

        this.ViewModel._VoucherDistributingDocument.StockActionID = 1234;

    }

    public kaydet(): void {
        let that = this;

        let body = JSON.stringify(this.ViewModel);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        this.http.post(this.documentUrl, body, options)
            .toPromise()
            .then(response => {
                console.log("OK");
            })
            .catch(error => {
                console.log(error);
            });
    }

    public onInitNewRow(o: any) {
        let objectDefID: string = "28fdb576-e0e0-45c3-be11-ec0415062d6b";
        /*
        let obj: o3.TTObjectClasses.StockActionSignDetail = new o3.TTObjectClasses.StockActionSignDetail();
        let g: Guid = new Guid(objectDefID);

        let user: o4.TTObjectClasses.ResUser = new o4.TTObjectClasses.ResUser();
        obj.SignUserType = e1.TTObjectClasses.SignUserTypeEnum.DepoSorumlusu;
        obj.IsDeputy = true;
        obj.SignUser = user;

        obj.ObjectDefID = "28fdb576-e0e0-45c3-be11-ec0415062d6b";

        Object.assign(obj, o.data);
        */
        o.data.ObjectID = Guid.newGuid().toString();
        o.data.ObjectDefID = "28fdb576-e0e0-45c3-be11-ec0415062d6b";
        o.data.IsDeputy = true;
        o.data.SignUserType = SignUserTypeEnum.DepoSorumlusu;
        o.data.SignUser = "abba26fc-afff-481a-be49-0c733b003ec8";
        o.data.NameString = "deneme";
        o.data.StockAction = "7a035c94-ff37-47cc-872e-fb00983d594e";

        // o.data = obj;
        console.log(o);
    }

    public onRowInserting(o: any) {
        console.log(o);
    }

    public onRowInserted(o: any) {
        console.log(o);
    }

}