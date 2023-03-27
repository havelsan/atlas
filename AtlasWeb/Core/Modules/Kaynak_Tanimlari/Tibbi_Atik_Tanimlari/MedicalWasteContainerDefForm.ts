import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { MedicalWasteContainerDefinition } from 'NebulaClient/Model/AtlasClientModel';


import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { MedicalWasteContainerDefFormViewModel, MedicalWasteContainer, MedicalWasteType, MedicalWasteProduct } from './MedicalWasteContainerDefFormViewModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
@Component({
    selector: 'MedicalWasteContainerDefForm',
    templateUrl: './MedicalWasteContainerDefForm.html',
    providers: [MessageService]
})
export class MedicalWasteContainerDefForm extends TTVisual.TTForm implements OnInit {
    medicalWasteDefFormViewModel: MedicalWasteContainerDefFormViewModel = new MedicalWasteContainerDefFormViewModel();

    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super();
        this.initViewModel();
    }
    /*Container Definition*/
    public ContainerName: string = "";
    public ContainerCapacity: number;
    public ContainerActive: boolean = true;

    /*Waste Type Definition*/
    public WasteTypeName: string = "";
    public WasteTypeCode: string = "";
    public WasteTypeActive: boolean = true;

    /*Waste Type Definition*/
    public ProductName: string = "";
    public ProductCode: string = "";
    public ProductActive: boolean = true;
    public ProductTypeID: Guid;
    public ProductTypeName: string = "";


    public ContainerGridColumns = [
        {
            caption: i18n("M19030", "Depo Adı"),
            dataField: 'Name',
            dataType: 'string',
            allowEditing: false,
            width: 250
        },
        {
            caption: i18n("M19030", "Depo Kapasitesi"),
            dataField: 'Capacity',
            dataType: 'number',
            allowEditing: false,
            width: 250
        },
        {
            caption: i18n("M17462", "Aktif"),
            dataField: 'Active',
            dataType: 'boolean',
            allowEditing: false,
            width: 250
        }
    ];

    public WasteGridColumns = [
        {
            caption: i18n("M19030", "İşlem Türü Adı"),
            dataField: 'Name',
            dataType: 'string',
            allowEditing: false,
            width: 250
        },
        {
            caption: i18n("M19030", "İşlem Türü Kodu"),
            dataField: 'Code',
            dataType: 'string',
            allowEditing: false,
            width: 250
        },
        {
            caption: i18n("M17462", "Aktif"),
            dataField: 'Active',
            dataType: 'boolean',
            allowEditing: false,
            width: 250
        }
    ];
    public ProductGridColumns = [
        {
            caption: i18n("M19030", "Ürün Adı"),
            dataField: 'Name',
            dataType: 'string',
            allowEditing: false,
            width: 250
        },
        {
            caption: i18n("M19030", "Ürün Kodu"),
            dataField: 'Code',
            dataType: 'string',
            allowEditing: false,
            width: 250
        },
        {
            caption: i18n("M19030", "Atık Türü"),
            dataField: 'WasteTypeName',
            dataType: 'string',
            allowEditing: false,
            width: 250
        },
        {
            caption: i18n("M17462", "Aktif"),
            dataField: 'Active',
            dataType: 'boolean',
            allowEditing: false,
            width: 250
        }
    ];



    public initViewModel(): void {
    }

    protected loadViewModel() {
    }

    async ngOnInit() {
        await this.LoadMedicalWasteDefForm();
    }

    containerDataSource: Array<MedicalWasteContainer> = new Array<MedicalWasteContainer>();
    typeDataSource: Array<MedicalWasteType> = new Array<MedicalWasteType>();
    productDataSource: Array<MedicalWasteProduct> = new Array<MedicalWasteProduct>();
    activeTypeDataSource: Array<MedicalWasteType> = new Array<MedicalWasteType>();

    public async LoadMedicalWasteDefForm() {
        let that = this;
        let fullApiUrl: string = "/api/MedicalWasteDefService/LoadMedicalWasteDefFormViewModel";
        this.httpService.get<MedicalWasteContainerDefFormViewModel>(fullApiUrl)
            .then(response => {
                that.medicalWasteDefFormViewModel = response as MedicalWasteContainerDefFormViewModel;
                that.containerDataSource = that.medicalWasteDefFormViewModel.ContainerList;
                that.typeDataSource = that.medicalWasteDefFormViewModel.WasteTypeList;
                that.productDataSource = that.medicalWasteDefFormViewModel.ProductList;
                that.activeTypeDataSource = that.medicalWasteDefFormViewModel.ActiveWasteTypeList;
            })
            .catch(error => {
                console.log(error);
            });
    }

    public selectedContainer: MedicalWasteContainer;
    public async onContainerGridRowClick(event) {
        this.selectedContainer = event.data;
        this.ContainerName = event.data.Name;
        this.ContainerCapacity = event.data.Capacity;
        this.ContainerActive = event.data.Active;
    }

    public selectedWasteType: MedicalWasteType;
    public async onTypeGridRowClick(event) {
        this.selectedWasteType = event.data;
        this.WasteTypeName = event.data.Name;
        this.WasteTypeCode = event.data.Code;
        this.WasteTypeActive = event.data.Active;
    }

    public selectedProduct: MedicalWasteProduct;
    public async onProductGridRowClick(event) {
        this.selectedProduct = event.data;
        this.ProductName = event.data.Name;
        this.ProductCode = event.data.Code;
        this.ProductActive = event.data.Active;
        this.ProductTypeName = event.data.WasteTypeName;
        this.ProductTypeID = event.data.WasteTypeID;
    }

    public createNewContainerRecord() {
        this.selectedContainer = null;
        this.ContainerName = "";
        this.ContainerCapacity = null;
        this.ContainerActive = true;
    }

    public createNewTypeRecord() {
        this.selectedWasteType = null;
        this.WasteTypeName = "";
        this.WasteTypeCode = "";
        this.WasteTypeActive = true;
    }

    public createNewProductRecord() {
        this.selectedProduct = null;
        this.ProductName = "";
        this.ProductTypeID = null;
        this.ProductCode = "";
        this.ProductActive = true;
        this.ProductTypeName = "";
    }

    public AddOrUpdateContainer() {

        if (this.ContainerName == null) {
            ServiceLocator.MessageService.showError("Depo adı boş bırakılamaz");
            return;
        }
        let that = this;
        let requestString: string = "";
        if (this.selectedContainer == null)
            requestString = "api/MedicalWasteDefService/SaveOrUpdateContainer?name=" + this.ContainerName + "&capacity=" + this.ContainerCapacity + "&active=" + this.ContainerActive;
        else {
            requestString = "api/MedicalWasteDefService/SaveOrUpdateContainer?name=" + this.ContainerName + "&capacity=" + this.ContainerCapacity + "&active=" + this.ContainerActive + "&ContainerObjectID=" + this.selectedContainer.ObjectID;
        }
        that.httpService.get<Array<MedicalWasteContainer>>(requestString)
            .then(response => {
                that.containerDataSource = response;
                ServiceLocator.MessageService.showSuccess("İşlem başarılı bir şekilde kaydedildi");
                this.createNewContainerRecord();
            })
            .catch(error => {
                that.messageService.showError(error);

            });
    }

    public AddOrUpdateWasteType() {

        if (this.WasteTypeName == null) {
            ServiceLocator.MessageService.showError("İşlem Türü adı boş bırakılamaz");
            return;
        }
        let that = this;
        let requestString: string = "";
        if (this.selectedWasteType == null)
            requestString = "api/MedicalWasteDefService/SaveOrUpdateWasteType?name=" + this.WasteTypeName + "&code=" + this.WasteTypeCode + "&active=" + this.WasteTypeActive;
        else {
            requestString = "api/MedicalWasteDefService/SaveOrUpdateWasteType?name=" + this.WasteTypeName + "&code=" + this.WasteTypeCode + "&active=" + this.WasteTypeActive + "&WasteTypeObjectID=" + this.selectedWasteType.ObjectID;
        }
        that.httpService.get<Array<MedicalWasteType>>(requestString)
            .then(response => {
                that.typeDataSource = response;
                that.activeTypeDataSource = that.typeDataSource.filter(x => x.Active == true);
                ServiceLocator.MessageService.showSuccess("İşlem başarılı bir şekilde kaydedildi");
                this.createNewTypeRecord();
            })
            .catch(error => {
                that.messageService.showError(error);

            });
    }

    public AddOrUpdateProduct() {

        if (this.ProductName == null) {
            ServiceLocator.MessageService.showError("Ürün adı boş bırakılamaz");
            return;
        }
        if(this.ProductTypeID== null){
            ServiceLocator.MessageService.showError("Atık Türü boş bırakılamaz");
            return;
        }
        let that = this;
        let requestString: string = "";
        if (this.selectedProduct == null)
            requestString = "api/MedicalWasteDefService/SaveOrUpdateProduct?name=" + this.ProductName + "&code=" + this.ProductCode + "&TypeObjectID=" + this.ProductTypeID +"&active=" + this.ProductActive;
        else {
            requestString = "api/MedicalWasteDefService/SaveOrUpdateProduct?name=" + this.ProductName + "&code=" + this.ProductCode + "&TypeObjectID=" + this.ProductTypeID +"&active=" + this.ProductActive + "&ProductObjectID=" + this.selectedProduct.ObjectID;
        }
        that.httpService.get<Array<MedicalWasteProduct>>(requestString)
            .then(response => {
                that.productDataSource = response;
                ServiceLocator.MessageService.showSuccess("İşlem başarılı bir şekilde kaydedildi");
                this.createNewProductRecord();
            })
            .catch(error => {
                that.messageService.showError(error);

            });
    }

    public deleteContainerRecord(){
        if (this.selectedContainer == null) {
            this.messageService.showInfo('Lütfen silinecek kaydı seçiniz');
            return;
        }

        const confirmResult = confirm('Seçilen kayıt silinecek. Devam etmek istiyor musunuz?');
        if (confirmResult === false) {
            return;
        }

        let requestString = "api/MedicalWasteDefService/DeleteContainerDefinitionObject?ObjectID=" + this.selectedContainer.ObjectID;
        let that = this;
        that.httpService.get<Array<MedicalWasteContainer>>(requestString)
        .then(response => {
            that.containerDataSource = response;
            ServiceLocator.MessageService.showSuccess("Kayıt başarı ile silindi")
            this.createNewContainerRecord();
        })
        .catch(error => {
            that.messageService.showError(error);

        });

    }

    public deleteTypeRecord(){
        if (this.selectedWasteType == null) {
            this.messageService.showInfo('Lütfen silinecek kaydı seçiniz');
            return;
        }

        const confirmResult = confirm('Seçilen kayıt silinecek. Devam etmek istiyor musunuz?');
        if (confirmResult === false) {
            return;
        }

        let requestString = "api/MedicalWasteDefService/DeleteWasteTypeDefinitionObject?ObjectID=" + this.selectedWasteType.ObjectID;
        let that = this;
        that.httpService.get<Array<MedicalWasteType>>(requestString)
        .then(response => {
            that.typeDataSource = response;
            ServiceLocator.MessageService.showSuccess("Kayıt başarı ile silindi")
            this.createNewTypeRecord();
        })
        .catch(error => {
            that.messageService.showError(error);

        });

    }

    public deleteProductRecord(){
        if (this.selectedProduct == null) {
            this.messageService.showInfo('Lütfen silinecek kaydı seçiniz');
            return;
        }

        const confirmResult = confirm('Seçilen kayıt silinecek. Devam etmek istiyor musunuz?');
        if (confirmResult === false) {
            return;
        }

        let requestString = "api/MedicalWasteDefService/DeleteWasteProductDefinitionObject?ObjectID=" + this.selectedProduct.ObjectID;
        let that = this;
        that.httpService.get<Array<MedicalWasteProduct>>(requestString)
        .then(response => {
            that.productDataSource = response;
            ServiceLocator.MessageService.showSuccess("Kayıt başarı ile silindi")
            this.createNewProductRecord();
        })
        .catch(error => {
            that.messageService.showError(error);

        });

    }




}