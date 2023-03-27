import { Component, OnInit  } from '@angular/core';
import { ZForm1ViewModel } from './ZForm1ViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ZDeneme1 } from 'NebulaClient/Model/AtlasClientModel';
import { City } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

@Component({
    selector: 'ZForm1',
    templateUrl: './ZForm1.html',
    providers: [MessageService]
})
export class ZForm1 extends TTVisual.TTForm implements OnInit {
    BirthDate: TTVisual.ITTDateTimePicker;
    City: TTVisual.ITTObjectListBox;
    labelBirthDate: TTVisual.ITTLabel;
    labelCity: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    Name: TTVisual.ITTTextBox;
    public zForm1ViewModel: ZForm1ViewModel = new ZForm1ViewModel();
    public get _ZDeneme1(): ZDeneme1 {
        return this._TTObject as ZDeneme1;
    }
    private ZForm1_DocumentUrl: string = '/api/ZDeneme1Service/ZForm1';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('ZDENEME1', 'ZForm1');
        this._DocumentServiceUrl = this.ZForm1_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ZDeneme1();
        this.zForm1ViewModel = new ZForm1ViewModel();
        this._ViewModel = this.zForm1ViewModel;
        this.zForm1ViewModel._ZDeneme1 = this._TTObject as ZDeneme1;
        this.zForm1ViewModel._ZDeneme1.City = new City();
    }

    protected loadViewModel() {
        let that = this;
        that.zForm1ViewModel = this._ViewModel as ZForm1ViewModel;
        that._TTObject = this.zForm1ViewModel._ZDeneme1;
        if (this.zForm1ViewModel == null)
            this.zForm1ViewModel = new ZForm1ViewModel();
        if (this.zForm1ViewModel._ZDeneme1 == null)
            this.zForm1ViewModel._ZDeneme1 = new ZDeneme1();
        let cityObjectID = that.zForm1ViewModel._ZDeneme1["City"];
        if (cityObjectID != null && (typeof cityObjectID === "string")) {
            let city = that.zForm1ViewModel.Citys.find(o => o.ObjectID.toString() === cityObjectID.toString());
            if (city) {
                that.zForm1ViewModel._ZDeneme1.City = city;
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

    this.Controls = [this.labelCity, this.City, this.labelBirthDate, this.BirthDate, this.labelName, this.Name];

}


}
