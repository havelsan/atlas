import { Component, OnInit  } from '@angular/core';
import { ZForm2ViewModel } from './ZForm2ViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ZDeneme1 } from 'NebulaClient/Model/AtlasClientModel';
import { City } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKanGrubu } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

@Component({
    selector: 'ZForm2',
    templateUrl: './ZForm2.html',
    providers: [MessageService]
})
export class ZForm2 extends TTVisual.TTForm implements OnInit {
    BirthDate: TTVisual.ITTDateTimePicker;
    BloodType: TTVisual.ITTObjectListBox;
    City: TTVisual.ITTObjectListBox;
    labelBirthDate: TTVisual.ITTLabel;
    labelBloodType: TTVisual.ITTLabel;
    labelCity: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    Name: TTVisual.ITTTextBox;
    public zForm2ViewModel: ZForm2ViewModel = new ZForm2ViewModel();
    public get _ZDeneme1(): ZDeneme1 {
        return this._TTObject as ZDeneme1;
    }
    private ZForm2_DocumentUrl: string = '/api/ZDeneme1Service/ZForm2';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('ZDENEME1', 'ZForm2');
        this._DocumentServiceUrl = this.ZForm2_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ZDeneme1();
        this.zForm2ViewModel = new ZForm2ViewModel();
        this._ViewModel = this.zForm2ViewModel;
        this.zForm2ViewModel._ZDeneme1 = this._TTObject as ZDeneme1;
        this.zForm2ViewModel._ZDeneme1.BloodType = new SKRSKanGrubu();
        this.zForm2ViewModel._ZDeneme1.City = new City();
    }

    protected loadViewModel() {
        let that = this;
        that.zForm2ViewModel = this._ViewModel as ZForm2ViewModel;
        that._TTObject = this.zForm2ViewModel._ZDeneme1;
        if (this.zForm2ViewModel == null)
            this.zForm2ViewModel = new ZForm2ViewModel();
        if (this.zForm2ViewModel._ZDeneme1 == null)
            this.zForm2ViewModel._ZDeneme1 = new ZDeneme1();
        let bloodTypeObjectID = that.zForm2ViewModel._ZDeneme1["BloodType"];
        if (bloodTypeObjectID != null && (typeof bloodTypeObjectID === "string")) {
            let bloodType = that.zForm2ViewModel.SKRSKanGrubus.find(o => o.ObjectID.toString() === bloodTypeObjectID.toString());
            if (bloodType) {
                that.zForm2ViewModel._ZDeneme1.BloodType = bloodType;
            }
        }

        let cityObjectID = that.zForm2ViewModel._ZDeneme1["City"];
        if (cityObjectID != null && (typeof cityObjectID === "string")) {
            let city = that.zForm2ViewModel.Citys.find(o => o.ObjectID.toString() === cityObjectID.toString());
            if (city) {
                that.zForm2ViewModel._ZDeneme1.City = city;
            }
        }

}



async ngOnInit() {
    await this.load();
}

public onBirthDateChanged(event): void {
    if (this._ZDeneme1 != null && this._ZDeneme1.BirthDate != event) {
    this._ZDeneme1.BirthDate = event;
}
}

public onBloodTypeChanged(event): void {
    if (this._ZDeneme1 != null && this._ZDeneme1.BloodType != event) {
    this._ZDeneme1.BloodType = event;
}
}

public onCityChanged(event): void {
    if (this._ZDeneme1 != null && this._ZDeneme1.City != event) {
    this._ZDeneme1.City = event;
}
}

public onNameChanged(event): void {
    if (this._ZDeneme1 != null && this._ZDeneme1.Name != event) {
    this._ZDeneme1.Name = event;
}
}



protected redirectProperties(): void {
    redirectProperty(this.Name, "Text", this.__ttObject, "Name");
    redirectProperty(this.BirthDate, "Value", this.__ttObject, "BirthDate");
}

public initFormControls(): void {
    this.labelBloodType = new TTVisual.TTLabel();
    this.labelBloodType.Text = "Kan Grubu";
    this.labelBloodType.Name = "labelBloodType";
    this.labelBloodType.TabIndex = 7;

    this.BloodType = new TTVisual.TTObjectListBox();
    this.BloodType.ListDefName = "SKRSKanGrubuList";
    this.BloodType.Name = "BloodType";
    this.BloodType.TabIndex = 6;

    this.labelCity = new TTVisual.TTLabel();
    this.labelCity.Text = "Şehir";
    this.labelCity.Name = "labelCity";
    this.labelCity.TabIndex = 5;

    this.City = new TTVisual.TTObjectListBox();
    this.City.ListDefName = "CityListDefinition";
    this.City.Name = "City";
    this.City.TabIndex = 4;

    this.labelBirthDate = new TTVisual.TTLabel();
    this.labelBirthDate.Text = "Doğum Tarihi";
    this.labelBirthDate.Name = "labelBirthDate";
    this.labelBirthDate.TabIndex = 3;

    this.BirthDate = new TTVisual.TTDateTimePicker();
    this.BirthDate.Format = DateTimePickerFormat.Long;
    this.BirthDate.Name = "BirthDate";
    this.BirthDate.TabIndex = 2;

    this.labelName = new TTVisual.TTLabel();
    this.labelName.Text = "Adı";
    this.labelName.Name = "labelName";
    this.labelName.TabIndex = 1;

    this.Name = new TTVisual.TTTextBox();
    this.Name.Name = "Name";
    this.Name.TabIndex = 0;

    this.Controls = [this.labelBloodType, this.BloodType, this.labelCity, this.City, this.labelBirthDate, this.BirthDate, this.labelName, this.Name];

}


}
