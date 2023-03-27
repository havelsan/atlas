//$B031EBC6
import { Component, OnInit } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';

import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { LaundryDefinitionFormViewModel, LinenGroupModel, LinenLocationModel, LinenTypeModel } from './LaundryViewModel'
import { Guid } from '../NebulaClient/Mscorlib/Guid';
@Component({
    selector: "laundry-definition-form",
    templateUrl: './LaundryDefinitionForm.html'
})
export class LaundryDefinitionForm implements OnInit {

    public apiAddress: string = '/api/LaundryApi/';
    public laundryDefinitionFormViewModel: LaundryDefinitionFormViewModel = new LaundryDefinitionFormViewModel();
    public LinenGroupDefinitionColumns = [
        {
            caption: 'Grup Adı',
            dataField: 'Name',
            width: '70%'
        }, {
            caption: 'Entegrasyon Kodu',
            dataField: 'IntegrationCode',
            width: '30%'
        } 
    ];

    public LinenLocationDefinitionColumns = [
        {
            caption: 'Konum Bilgisi',
            dataField: 'Location',
            width: '50%'
        }, {
            caption: 'Mahal Numarası',
            dataField: 'MahalNo',
            width: '30%'
        }, {
            caption: 'Entegrasyon Kodu',
            dataField: 'IntegrationCode',
            width: '20%'
        }
    ];

    public LinenTypeDefinitionColumns;
    GenerateLinenTypeDefinitionColumns() {
        let that = this;
        this.LinenTypeDefinitionColumns = [
            {
                caption: 'Çamaşır Tipi',
                dataField: 'Type',
                width: '50%'
            }, {
                caption: 'Max Yıkama Adedi',
                dataField: 'MaxWashingCount',
                width: '10%'
            }, {
                caption: 'Çamaşır Grubu',
                dataField: 'LinenGroup',
                lookup: { dataSource: that.laundryDefinitionFormViewModel.LinenGroups, valueExpr: 'ObjectID', displayExpr: 'Name' },
                width: '30%'
            }, {
                caption: 'Entegrasyon Kodu',
                dataField: 'IntegrationCode',
                width: '10%'
            }
        ];
    };

    

    constructor(protected http: NeHttpService) {
        this.GenerateLinenTypeDefinitionColumns();
       
    }

    GroupEditingConfig: any = {
        mode: 'form',
        allowUpdating: true,
        allowAdding: true,
        allowDeleting: true,
        texts: {
            deleteRow: 'Sil',
            addRow: 'Yeni grup ekle',
            editRow: 'Güncelle',
            confirmDeleteMessage: 'Çamaşır grubu silinecek. Emin misiniz?'
        }
    };

    LocationEditingConfig: any = {
        mode: 'form',
        allowUpdating: true,
        allowAdding: true,
        allowDeleting: true,
        texts: {
            deleteRow: 'Sil',
            addRow: 'Yeni konum bilgisi ekle',
            editRow: 'Güncelle',
            confirmDeleteMessage: 'Çamaşır konum bilgisi silinecek. Emin misiniz?'
        }
    };

    
    TypeEditingConfig: any = {
        mode: 'form',
        allowUpdating: true,
        allowAdding: true,
        allowDeleting: true,
        texts: {
            deleteRow: 'Sil',
            addRow: 'Yeni çamaşır tipi bilgisi ekle',
            editRow: 'Güncelle',
            confirmDeleteMessage: 'Çamaşır tipi bilgisi silinecek. Emin misiniz?'
        }
    };

    ngOnInit() {
        let that = this;
        this.loadLinenGroupDataSource();
        this.loadLinenLocationDataSource();
        this.loadLinenTypeDataSource();
    }


    onRowInsertingLinenGroup(event: any) {

        let model: LinenGroupModel = new LinenGroupModel();

        model.Name = event.data.Name;
        model.IntegrationCode = event.data.IntegrationCode;

        let apiUrlForTaniKayit: string = this.apiAddress + 'SaveNewLinenGroup';

        this.http.post(apiUrlForTaniKayit, model).then(response => {
            if (response) {
                ServiceLocator.MessageService.showSuccess("Çamaşır grubu başarılı bir şekilde eklendi.");
                this.loadLinenGroupDataSource();
            }
        }).catch(error => {
            //this.errorHandlerForDPTermOperation(error);
            this.loadLinenGroupDataSource();
        });
    }

    onRowRemovingLinenGroup(event: any) {
        console.log("onRowRemovingLinenGroup");
        console.log(event);
        this.removeDefinitionItem(event.key.ObjectID, 1);

    }

    public removeDefinitionItem(objectid: Guid, type: number): void {
        let model: any = {};
        model.ObjectID = objectid;
        model.Type = type;

        let apiUrlForTaniKayit: string = this.apiAddress + 'DeleteLinenDefinition';

        this.http.post(apiUrlForTaniKayit, model).then(response => {
            if (response) {
                if (type == 1)//Group
                    this.loadLinenGroupDataSource();
                else if (type == 2)//Location
                    this.loadLinenLocationDataSource();
                else if (type == 3)//Type
                    this.loadLinenTypeDataSource();
            }
        }).catch(error => {
            
        });
    }
    onRowUpdatingLinenGroup(event: any) {
        console.log("onRowUpdatingLinenGroup");
        console.log(event);

        let model: LinenGroupModel = new LinenGroupModel();

        model.ObjectID = event.key.ObjectID;

        if (event.newData.Name != null && event.newData.Name !== undefined)
            model.Name = event.newData.Name;
        if (event.newData.IntegrationCode != null && event.newData.IntegrationCode !== undefined)
            model.IntegrationCode = event.newData.IntegrationCode;
          
        

        let apiUrlForTaniKayit: string = this.apiAddress + 'UpdateLinenGroup';

        this.http.post(apiUrlForTaniKayit, model).then(response => {
            if (response) {
                ServiceLocator.MessageService.showSuccess("Çamaşır grubu başarılı bir şekilde güncellendi.");
                this.loadLinenGroupDataSource();
            }
        }).catch(error => {
            //this.errorHandlerForDPTermOperation(error);
            this.loadLinenGroupDataSource();
            event.cancel = true;
            ServiceLocator.MessageService.showError("Çamaşır grubu güncellenmesi sırasında hata oluştu.");
        });
    }

    onRowInsertingLinenLocation(event: any) {
        let model: LinenLocationModel = new LinenLocationModel();

        model.Location = event.data.Location;
        model.MahalNo = event.data.MahalNo;
        model.IntegrationCode = event.data.IntegrationCode;

        let apiUrlForTaniKayit: string = this.apiAddress + 'SaveNewLinenLocation';

        this.http.post(apiUrlForTaniKayit, model).then(response => {
            if (response) {
                ServiceLocator.MessageService.showSuccess("Konum bilgisi başarılı bir şekilde eklendi.");
                this.loadLinenLocationDataSource();
            }
        }).catch(error => {
            //this.errorHandlerForDPTermOperation(error);
            this.loadLinenLocationDataSource();
        });
    }

    onRowRemovingLinenLocation(event: any) {
        console.log("onRowRemovingLinenLocation");
        console.log(event);

        this.removeDefinitionItem(event.key.ObjectID, 2);
    }

    onRowUpdatingLinenLocation(event: any) {
        console.log("onRowUpdatingLinenLocation");
        console.log(event);

        let model: LinenLocationModel = new LinenLocationModel();

        model.ObjectID = event.key.ObjectID;

        if (event.newData.Location != null && event.newData.Location !== undefined)
            model.Location = event.newData.Location;
        if (event.newData.IntegrationCode != null && event.newData.IntegrationCode !== undefined)
            model.IntegrationCode = event.newData.IntegrationCode;
        if (event.newData.MahalNo != null && event.newData.MahalNo !== undefined)
            model.MahalNo = event.newData.MahalNo;


        let apiUrlForTaniKayit: string = this.apiAddress + 'UpdateLinenLocation';

        this.http.post(apiUrlForTaniKayit, model).then(response => {
            if (response) {
                ServiceLocator.MessageService.showSuccess("Konum bilgisi başarılı bir şekilde güncellendi.");
                this.loadLinenGroupDataSource();
            }
        }).catch(error => {
            //this.errorHandlerForDPTermOperation(error);
            this.loadLinenGroupDataSource();
            event.cancel = true;
            ServiceLocator.MessageService.showError("Konum bilgisi güncellenmesi sırasında hata oluştu.");
        });
    }

    onRowInsertingLinenType(event: any) {

        let model: LinenTypeModel = new LinenTypeModel();

        model.MaxWashingCount = event.data.MaxWashingCount;
        model.Type = event.data.Type;
        model.IntegrationCode = event.data.IntegrationCode;
        model.LinenGroup = event.data.LinenGroup;
        
        let apiUrlForTaniKayit: string = this.apiAddress + 'SaveNewLinenType';

        this.http.post(apiUrlForTaniKayit, model).then(response => {
            if (response) {
                ServiceLocator.MessageService.showSuccess("Konum bilgisi başarılı bir şekilde eklendi.");
                this.loadLinenTypeDataSource();
            }
        }).catch(error => {
            //this.errorHandlerForDPTermOperation(error);
            this.loadLinenTypeDataSource();
        });
    }
    onRowRemovingLinenType(event: any) {
        console.log("onRowRemovingLinenType");
        console.log(event);

        this.removeDefinitionItem(event.key.ObjectID, 3);
    }
    onRowUpdatingLinenType(event: any) {
        console.log("onRowUpdatingLinenType");
        console.log(event);

        let model: LinenTypeModel = new LinenTypeModel();

        model.ObjectID = event.key.ObjectID;

        if (event.newData.Type != null && event.newData.Type !== undefined)
            model.Type = event.newData.Type;
        if (event.newData.IntegrationCode != null && event.newData.IntegrationCode !== undefined)
            model.IntegrationCode = event.newData.IntegrationCode;
        if (event.newData.MaxWashingCount != null && event.newData.MaxWashingCount!== undefined)
            model.MaxWashingCount = event.newData.MaxWashingCount;
        if (event.newData.LinenGroup != null && event.newData.LinenGroup!== undefined)
            model.LinenGroup = event.newData.LinenGroup;

        let apiUrlForTaniKayit: string = this.apiAddress + 'UpdateLinenType';

        this.http.post(apiUrlForTaniKayit, model).then(response => {
            if (response) {
                ServiceLocator.MessageService.showSuccess("Çamaşır tipi bilgisi başarılı bir şekilde güncellendi.");
                this.loadLinenGroupDataSource();
            }
        }).catch(error => {
            //this.errorHandlerForDPTermOperation(error);
            this.loadLinenGroupDataSource();
            event.cancel = true;
            ServiceLocator.MessageService.showError("Çamaşır tipi bilgisi güncellenmesi sırasında hata oluştu.");
        });
    }

    async loadLinenGroupDataSource(): Promise<void> {
        this.http.get<Array<LinenGroupModel>>(this.apiAddress + "GetAllLinenGroups").then(result => {
            this.laundryDefinitionFormViewModel.LinenGroups = result;
            this.GenerateLinenTypeDefinitionColumns();
            return;
        }).catch(error => {
            //this.errorHandlerForDPTermOperation(error);
        });
    }
    async loadLinenLocationDataSource(): Promise<void> {
        this.http.get<Array<LinenLocationModel>>(this.apiAddress + "GetAllLinenLocations").then(result => {
            this.laundryDefinitionFormViewModel.LinenLocations = result;
        }).catch(error => {
            //this.errorHandlerForDPTermOperation(error);
        });
    }
    async loadLinenTypeDataSource(): Promise<void> {
        this.http.get<Array<LinenTypeModel>>(this.apiAddress + "GetAllLinenTypes").then(result => {
            this.laundryDefinitionFormViewModel.LinenTypes = result;
        }).catch(error => {
            //this.errorHandlerForDPTermOperation(error);
        });
    }
}