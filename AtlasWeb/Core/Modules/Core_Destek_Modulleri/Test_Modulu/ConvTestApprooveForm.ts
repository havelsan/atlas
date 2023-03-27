//$5B5D037F
import { Component, OnInit, NgZone } from '@angular/core';
import { ConvTestApprooveFormViewModel } from './ConvTestApprooveFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { ConvTest } from 'NebulaClient/Model/AtlasClientModel';
import { ConvTestService } from 'ObjectClassService/ConvTestService';
import { City } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';


@Component({
    selector: 'ConvTestApprooveForm',
    templateUrl: './ConvTestApprooveForm.html',
    providers: [MessageService]
})
export class ConvTestApprooveForm extends TTVisual.TTForm implements OnInit {
    City: TTVisual.ITTObjectListBox;
    Description: TTVisual.ITTTextBox;
    labelCity: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelNo: TTVisual.ITTLabel;
    labelTelephone: TTVisual.ITTLabel;
    No: TTVisual.ITTTextBox;
    Telephone: TTVisual.ITTTextBox;
    ttbutton1: TTVisual.ITTButton;
    public convTestApprooveFormViewModel: ConvTestApprooveFormViewModel = new ConvTestApprooveFormViewModel();
    public get _ConvTest(): ConvTest {
        return this._TTObject as ConvTest;
    }
    private ConvTestApprooveForm_DocumentUrl: string = '/api/ConvTestService/ConvTestApprooveForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('CONVTEST', 'ConvTestApprooveForm');
        this._DocumentServiceUrl = this.ConvTestApprooveForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async ttbutton1_Click(): Promise<void> {
        this.Telephone.Text += '!';
        if (String.isNullOrEmpty(this.No.Text) === false) {
            this.No.Text = (await ConvTestService.NoyuBirArttir(await ConvTestService.NoyuBirArttir(Convert.ToInt32(this.No.Text)))).toString();
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ConvTest();
        this.convTestApprooveFormViewModel = new ConvTestApprooveFormViewModel();
        this._ViewModel = this.convTestApprooveFormViewModel;
        this.convTestApprooveFormViewModel._ConvTest = this._TTObject as ConvTest;
        this.convTestApprooveFormViewModel._ConvTest.City = new City();
    }

    protected loadViewModel() {
        let that = this;
        that.convTestApprooveFormViewModel = this._ViewModel as ConvTestApprooveFormViewModel;
        if (that.convTestApprooveFormViewModel.ReadOnly)
        {
            ServiceLocator.MessageService.showError("Bu form readonly :)");
            return;
        }
        that._TTObject = this.convTestApprooveFormViewModel._ConvTest;
        if (this.convTestApprooveFormViewModel == null) {
            this.convTestApprooveFormViewModel = new ConvTestApprooveFormViewModel();
        }
        if (this.convTestApprooveFormViewModel._ConvTest == null) {
            this.convTestApprooveFormViewModel._ConvTest = new ConvTest();
        }
        let cityObjectID = that.convTestApprooveFormViewModel._ConvTest['City'];
        if (cityObjectID != null && (typeof cityObjectID === 'string')) {
            let city = that.convTestApprooveFormViewModel.Citys.find(o => o.ObjectID.toString() === cityObjectID.toString());
             if (city) {
                that.convTestApprooveFormViewModel._ConvTest.City = city;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(ConvTestApprooveFormViewModel);
        this.redirectProperties();
  
    }


    public onCityChanged(event): void {
        if (event != null) {
            if (this._ConvTest != null && this._ConvTest.City !== event) {
                this._ConvTest.City = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ConvTest != null && this._ConvTest.Description !== event) {
                this._ConvTest.Description = event;
            }
        }
    }

    public onNoChanged(event): void {
        if (event != null) {
            if (this._ConvTest != null && this._ConvTest.No !== event) {
                this._ConvTest.No = event;
            }
        }
    }

    public onTelephoneChanged(event): void {
        if (event != null) {
            if (this._ConvTest != null && this._ConvTest.Telephone !== event) {
                this._ConvTest.Telephone = event;
            }
        }
    }

    public redirectProperties(): void {
        redirectProperty(this.No, 'Text', this.__ttObject, 'No');
        redirectProperty(this.Telephone, 'Text', this.__ttObject, 'Telephone');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
    }

    public initFormControls(): void {
        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.Name = 'labelDescription';
        this.labelDescription.TabIndex = 8;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Name = 'Description';
        this.Description.TabIndex = 7;

        this.Telephone = new TTVisual.TTTextBox();
        this.Telephone.Name = 'Telephone';
        this.Telephone.TabIndex = 2;

        this.No = new TTVisual.TTTextBox();
        this.No.Name = 'No';
        this.No.TabIndex = 0;

        this.ttbutton1 = new TTVisual.TTButton();
        this.ttbutton1.Text = i18n("M12593", "Deneme");
        this.ttbutton1.Name = 'ttbutton1';
        this.ttbutton1.TabIndex = 6;

        this.labelCity = new TTVisual.TTLabel();
        this.labelCity.Text = i18n("M22467", "Şehir");
        this.labelCity.Name = 'labelCity';
        this.labelCity.TabIndex = 5;

        this.City = new TTVisual.TTObjectListBox();
        this.City.ListDefName = 'CityListDefinition';
        this.City.Name = 'City';
        this.City.TabIndex = 4;

        this.labelTelephone = new TTVisual.TTLabel();
        this.labelTelephone.Text = 'Telefon';
        this.labelTelephone.Name = 'labelTelephone';
        this.labelTelephone.TabIndex = 3;

        this.labelNo = new TTVisual.TTLabel();
        this.labelNo.Text = 'No';
        this.labelNo.Name = 'labelNo';
        this.labelNo.TabIndex = 1;


    }


}
