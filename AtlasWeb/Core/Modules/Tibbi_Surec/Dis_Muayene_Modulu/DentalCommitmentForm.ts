//$5DE99823
import { Component, ViewChild, OnInit } from '@angular/core';
import { DentalCommitmentFormViewModel, ReadTaahhutOutputDVO, DeleteTaahhutOutputDVO, ReadTaahhutTCOutputDVO, Taahhut } from './DentalCommitmentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DentalCommitment, Service } from 'NebulaClient/Model/AtlasClientModel';
import { City } from 'NebulaClient/Model/AtlasClientModel';
import { DentalCommitmentProsthesis } from 'NebulaClient/Model/AtlasClientModel';
import { DentalProsthesisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TownDefinitions } from 'NebulaClient/Model/AtlasClientModel';

import { AddSut, SaveTaahhutInputDVO, SaveTaahhutOutputDVO } from './DentalCommitmentFormViewModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ModalInfo, ModalStateService } from 'app/Fw/Models/ModalInfo';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DxPopoverComponent, DxDataGridComponent } from 'devextreme-angular';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';

@Component({
    selector: 'DentalCommitmentForm',
    templateUrl: './DentalCommitmentForm.html',
    providers: [MessageService]
})
export class DentalCommitmentForm extends TTVisual.TTForm implements OnInit {
    City: TTVisual.ITTObjectListBox;
    CommitmentNo: TTVisual.ITTTextBox;
    CommitmentProtocolNo: TTVisual.ITTTextBox;
    CommitmentResultCode: TTVisual.ITTTextBox;
    CommitmentResultMessage: TTVisual.ITTTextBox;
    CommitmentTakenByName: TTVisual.ITTTextBox;
    CommitmentTakenBySurname: TTVisual.ITTTextBox;
    DentalCommitmentProstethises: TTVisual.ITTGrid;
    DentalProsthesisDefinitionDentalCommitmentProsthesis: TTVisual.ITTListBoxColumn;
    DentalProsthesisDefinitionName: TTVisual.ITTTextBoxColumn;
    EMail: TTVisual.ITTTextBox;
    InnerDoorNo: TTVisual.ITTTextBox;
    labelCity: TTVisual.ITTLabel;
    labelCommitmentNo: TTVisual.ITTLabel;
    labelCommitmentProtocolNo: TTVisual.ITTLabel;
    labelCommitmentResultCode: TTVisual.ITTLabel;
    labelCommitmentResultMessage: TTVisual.ITTLabel;
    labelCommitmentTakenByName: TTVisual.ITTLabel;
    labelCommitmentTakenBySurname: TTVisual.ITTLabel;
    labelEMail: TTVisual.ITTLabel;
    labelInnerDoorNo: TTVisual.ITTLabel;
    labelOuterDoorNo: TTVisual.ITTLabel;
    labelPhoneNumber: TTVisual.ITTLabel;
    labelPostCode: TTVisual.ITTLabel;
    labelStreetName: TTVisual.ITTLabel;
    labelTown: TTVisual.ITTLabel;
    OuterDoorNo: TTVisual.ITTTextBox;
    PhoneNumber: TTVisual.ITTTextBox;
    PostCode: TTVisual.ITTTextBox;
    StreetName: TTVisual.ITTTextBox;
    ToothNoDentalCommitmentProsthesis: TTVisual.ITTTextBoxColumn;
    Town: TTVisual.ITTObjectListBox;
    @ViewChild(DxPopoverComponent) popOver: DxPopoverComponent;


    /*ESKİ DEĞİŞKENLER */
    private checkList: Array<string> = new Array<string>();
    public actionSelectItem: string[];
    private checkValues: Array<boolean> = new Array<boolean>();
    public selectedDentalProcedure: Array<DentalProsthesisDefinition> = new Array<DentalProsthesisDefinition>();
    public sut: Array<AddSut> = new Array<AddSut>();
    public okunacakTaahhutNumarasi: string;
    public txtSonucKoduTaahhutNoileSorgula: string;
    public txtSonucMesajiTaahhutNoileSorgula: string;
    public silinecekTaahhutNo: string;
    public txtSonucKoduTaahhutSil: string;
    public txtSonucMesajiTaahhutSil: string;
    public txtSonucKoduTCKimlikNoileSorgula: string;
    public txtSonucMesajTCKimlikNoileSorgula: string;
    public taahhutler: Array<Taahhut> = new Array<Taahhut>();

    /*ESKİ DEĞİŞKENLER */

    protected _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public DentalCommitmentProstethisesColumns = [];
    public dentalCommitmentFormViewModel: DentalCommitmentFormViewModel = new DentalCommitmentFormViewModel();
    public get _DentalCommitment(): DentalCommitment {
        return this._TTObject as DentalCommitment;
    }
    private DentalCommitmentForm_DocumentUrl: string = '/api/DentalCommitmentService/DentalCommitmentForm';
    constructor(protected httpService: NeHttpService, private http: NeHttpService, protected messageService: MessageService, private reportService: AtlasReportService,
        protected modalStateService: ModalStateService) {
        super('DENTALCOMMITMENT', 'DentalCommitmentForm');
        this._DocumentServiceUrl = this.DentalCommitmentForm_DocumentUrl;

        this.initViewModel();
        this.initFormControls();
        /*ESKİ KODLAR */
        this.checkValues = Array.apply(null, Array(58)).map(Boolean.prototype.valueOf, false);
        this.actionSelectItem = [
            i18n("M22519", "Taahhut Kaydet"),
            i18n("M22520", "Taahhut No Ile Sorgula"),
            'Taahhut Sil',
            i18n("M22938", "TC Kimlik No Ile Sorgula")
        ];
        /*ESKİ KODLAR */
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DentalCommitment();
        this.dentalCommitmentFormViewModel = new DentalCommitmentFormViewModel();
        this._ViewModel = this.dentalCommitmentFormViewModel;
        this.dentalCommitmentFormViewModel._DentalCommitment = this._TTObject as DentalCommitment;
        this.dentalCommitmentFormViewModel._DentalCommitment.DentalCommitmentProstethises = new Array<DentalCommitmentProsthesis>();
        this.dentalCommitmentFormViewModel._DentalCommitment.Town = new TownDefinitions();
        this.dentalCommitmentFormViewModel._DentalCommitment.City = new City();
        this.selectedDentalProcedure = new Array<DentalProsthesisDefinition>();

    }

    async cancel() {
        super.cancel();
        //this.modalStateService.callActionExecuted(DialogResult.Abort, null, this.dentalCommitmentFormViewModel._DentalCommitment);

    }
    protected async save() {
        this.httpService.dentalCommitmentFormSharedService.sendDentalCommitmentObject(this.dentalCommitmentFormViewModel._DentalCommitment);

        super.save();

    }

    async setTownFilter(data: any) {
        if (!data)
            this.Town.ListFilterExpression = "1=1";
        else {
            this.Town.ListFilterExpression = "CITY.OBJECTID ='" + data.ObjectID.toString() + "'";
        }
    }

    @ViewChild('prosthesisGrid') prosthesisGrid: DxDataGridComponent;
    prosthesisGrid_CellContentClicked(data: any) {
        if (data.column.name == "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    if (data.row.key.IsNew) {
                        this.prosthesisGrid.instance.deleteRow(data.rowIndex);
                    }
                    else {
                        data.key.EntityState = EntityStateEnum.Deleted;
                        this.prosthesisGrid.instance.filter(['EntityState', '<>', 1]);
                        this.prosthesisGrid.instance.refresh();
                    }
                }
            }
        }
    }

    public DentalCommitmentProsthesisColumns =
        [
            {
                caption: 'Sut Kodu',
                dataField: 'DentalProsthesisDefinition.Name',
                width: "auto",
                allowEditing: false

            },
            {
                caption: 'Diş No',
                dataField: 'ToothNo',
                width: "auto",
                allowEditing: false
            },{
                caption: i18n("M27286", "Sil"),
                name: 'RowDelete',
                width: '50',
                cellTemplate: 'deleteCellTemplate'
            }
        ];

    public oldDentalCommitmentsColumns =
        [
            {
                caption: 'Taahhüt Tarihi',
                dataField: 'commitmentDate',
                dataType: 'datetime',
                format: 'dd.MM.yyyy HH:mm:ss',
                width: '10%',
                allowEditing: false

            },
            {
                caption: 'Taahhüt No',
                dataField: 'commitmentNo',
                width: '15%',
                allowEditing: false
            },
            {
                caption: 'Taahhüt İşlemleri',
                dataField: 'oldCommitments',
                width: '75%',
                allowEditing: false
            }
        ];
    protected loadViewModel() {
        let that = this;
        that.dentalCommitmentFormViewModel = this._ViewModel as DentalCommitmentFormViewModel;
        that._TTObject = this.dentalCommitmentFormViewModel._DentalCommitment;
        if (this.dentalCommitmentFormViewModel == null)
            this.dentalCommitmentFormViewModel = new DentalCommitmentFormViewModel();
        if (this.dentalCommitmentFormViewModel._DentalCommitment == null)
            this.dentalCommitmentFormViewModel._DentalCommitment = new DentalCommitment();
        that.dentalCommitmentFormViewModel._DentalCommitment.DentalCommitmentProstethises = that.dentalCommitmentFormViewModel.DentalCommitmentProstethisesGridList;
        for (let detailItem of that.dentalCommitmentFormViewModel.DentalCommitmentProstethisesGridList) {
            let dentalProsthesisDefinitionObjectID = detailItem["DentalProsthesisDefinition"];
            if (dentalProsthesisDefinitionObjectID != null && (typeof dentalProsthesisDefinitionObjectID === "string")) {
                let dentalProsthesisDefinition = that.dentalCommitmentFormViewModel.DentalProsthesisDefinitions.find(o => o.ObjectID.toString() === dentalProsthesisDefinitionObjectID.toString());
                if (dentalProsthesisDefinition) {
                    detailItem.DentalProsthesisDefinition = dentalProsthesisDefinition;
                }
            }

        }

        let townObjectID = that.dentalCommitmentFormViewModel._DentalCommitment["Town"];
        if (townObjectID != null && (typeof townObjectID === "string")) {
            let town = that.dentalCommitmentFormViewModel.TownDefinitionss.find(o => o.ObjectID.toString() === townObjectID.toString());
            if (town) {
                that.dentalCommitmentFormViewModel._DentalCommitment.Town = town;
            }
        }


        let cityObjectID = that.dentalCommitmentFormViewModel._DentalCommitment["City"];
        if (cityObjectID != null && (typeof cityObjectID === "string")) {
            let city = that.dentalCommitmentFormViewModel.Citys.find(o => o.ObjectID.toString() === cityObjectID.toString());
            if (city) {
                that.dentalCommitmentFormViewModel._DentalCommitment.City = city;
            }
        }

    }


    async ngOnInit() {
        await this.load();
    }

    public onCityChanged(event): void {
        if (this._DentalCommitment != null && this._DentalCommitment.City != event) {
            this._DentalCommitment.City = event;
            this.setTownFilter(event);
        }
    }

    public onCommitmentNoChanged(event): void {
        if (this._DentalCommitment != null && this._DentalCommitment.CommitmentNo != event) {
            this._DentalCommitment.CommitmentNo = event;
        }
    }

    public onCommitmentProtocolNoChanged(event): void {
        if (this._DentalCommitment != null && this._DentalCommitment.CommitmentProtocolNo != event) {
            this._DentalCommitment.CommitmentProtocolNo = event;
        }
    }

    public onCommitmentResultCodeChanged(event): void {
        if (this._DentalCommitment != null && this._DentalCommitment.CommitmentResultCode != event) {
            this._DentalCommitment.CommitmentResultCode = event;
        }
    }

    public onCommitmentResultMessageChanged(event): void {
        if (this._DentalCommitment != null && this._DentalCommitment.CommitmentResultMessage != event) {
            this._DentalCommitment.CommitmentResultMessage = event;
        }
    }

    public onCommitmentTakenByNameChanged(event): void {
        if (this._DentalCommitment != null && this._DentalCommitment.CommitmentTakenByName != event) {
            this._DentalCommitment.CommitmentTakenByName = event;
        }
    }

    public onCommitmentTakenBySurnameChanged(event): void {
        if (this._DentalCommitment != null && this._DentalCommitment.CommitmentTakenBySurname != event) {
            this._DentalCommitment.CommitmentTakenBySurname = event;
        }
    }

    public onEMailChanged(event): void {
        if (this._DentalCommitment != null && this._DentalCommitment.EMail != event) {
            this._DentalCommitment.EMail = event;
        }
    }

    public onInnerDoorNoChanged(event): void {
        if (this._DentalCommitment != null && this._DentalCommitment.InnerDoorNo != event) {
            this._DentalCommitment.InnerDoorNo = event;
        }
    }

    public onOuterDoorNoChanged(event): void {
        if (this._DentalCommitment != null && this._DentalCommitment.OuterDoorNo != event) {
            this._DentalCommitment.OuterDoorNo = event;
        }
    }

    public onPhoneNumberChanged(event): void {
        if (this._DentalCommitment != null && this._DentalCommitment.PhoneNumber != event) {
            this._DentalCommitment.PhoneNumber = event;
        }
    }

    public onPostCodeChanged(event): void {
        if (this._DentalCommitment != null && this._DentalCommitment.PostCode != event) {
            this._DentalCommitment.PostCode = event;
        }
    }

    public onStreetNameChanged(event): void {
        if (this._DentalCommitment != null && this._DentalCommitment.StreetName != event) {
            this._DentalCommitment.StreetName = event;
        }
    }

    public onTownChanged(event): void {
        if (this._DentalCommitment != null && this._DentalCommitment.Town != event) {
            this._DentalCommitment.Town = event;
        }
    }

    /*ESKİ METODLAR*/
    optionChanged(e: string) {
        if (e.substr(0, 1) === '+') {
            let item = e.substr(1, e.length - 1);
            let foundItem = this.checkList.find(x => x === item);
            if (!foundItem) {
                this.checkList.push(item);
            }
        } else if (e.substr(0, 1) === '-') {
            let item = e.substr(1, e.length - 1);
            let foundItem = this.checkList.find(x => x === item);
            if (foundItem) {
                let index = this.checkList.indexOf(item);
                this.checkList.splice(index, 1);
            }
        }
    }

    add_Click() {
        for (let dis of this.checkList) {
            for (let s of this.selectedDentalProcedure) {
                let newProsthesis: DentalCommitmentProsthesis = new DentalCommitmentProsthesis();
                newProsthesis.ToothNo = dis;
                newProsthesis.DentalProsthesisDefinition = s;
                this.dentalCommitmentFormViewModel._DentalCommitment.DentalCommitmentProstethises.push(newProsthesis);
            }
        }
        this.checkValues = Array.apply(null, Array(58)).map(Boolean.prototype.valueOf, false);
        this.selectedDentalProcedure = new Array<DentalProsthesisDefinition>();
        this.checkList = new Array<string>();
    }

    async buttonDisTaahhutKaydet_Click() {
        let inputdvo: SaveTaahhutInputDVO = new SaveTaahhutInputDVO();
        inputdvo.activeMedulaProvision = this.dentalCommitmentFormViewModel.provisionNo;
        this.sut = new Array<AddSut>();
        this.dentalCommitmentFormViewModel._DentalCommitment.DentalCommitmentProstethises.forEach(commitmentProsthesis => {
            let newSut: AddSut = new AddSut();
            newSut.disNo = commitmentProsthesis.ToothNo;
            newSut.sutDef = commitmentProsthesis.DentalProsthesisDefinition;
            this.sut.push(newSut);
        });
        inputdvo.suts = this.sut;
        if(inputdvo.suts.length < 1){
            ServiceLocator.MessageService.showError("İşlem eklemeden taahhütü medulaya gönderemezsiniz.!");
        }else if (this.dentalCommitmentFormViewModel._DentalCommitment.City == null){
            ServiceLocator.MessageService.showError("Şehir seçmeden taahhütü medulaya gönderemezsiniz.!");
        }else if (this.dentalCommitmentFormViewModel._DentalCommitment.Town == null){
            ServiceLocator.MessageService.showError("İlçe seçmeden taahhütü medulaya gönderemezsiniz.!");
        }else if (this.dentalCommitmentFormViewModel._DentalCommitment.StreetName == null || this.dentalCommitmentFormViewModel._DentalCommitment.StreetName == ''){
            ServiceLocator.MessageService.showError("Cadde-Sokak Adı girmeden taahhütü medulaya gönderemezsiniz.!");
        }else if (this.dentalCommitmentFormViewModel._DentalCommitment.OuterDoorNo == null || this.dentalCommitmentFormViewModel._DentalCommitment.OuterDoorNo == ''){
            ServiceLocator.MessageService.showError("Dış Kapı No girmeden taahhütü medulaya gönderemezsiniz.!");
        }else if (this.dentalCommitmentFormViewModel._DentalCommitment.InnerDoorNo == null || this.dentalCommitmentFormViewModel._DentalCommitment.InnerDoorNo == ''){
            ServiceLocator.MessageService.showError("İç Kapı No girmeden taahhütü medulaya gönderemezsiniz.!");
        }else if (this.dentalCommitmentFormViewModel._DentalCommitment.PostCode == null || this.dentalCommitmentFormViewModel._DentalCommitment.PostCode == ''){
            ServiceLocator.MessageService.showError("Posta Kodu girmeden taahhütü medulaya gönderemezsiniz.!");
        }else if (this.dentalCommitmentFormViewModel._DentalCommitment.PhoneNumber == null || this.dentalCommitmentFormViewModel._DentalCommitment.PhoneNumber == ''){
            ServiceLocator.MessageService.showError("Telefon No girmeden taahhütü medulaya gönderemezsiniz.!");
        }else if (this.dentalCommitmentFormViewModel._DentalCommitment.CommitmentTakenByName == null || this.dentalCommitmentFormViewModel._DentalCommitment.CommitmentTakenByName == ''){
            ServiceLocator.MessageService.showError("Taahhüt Alanın Adı girmeden taahhütü medulaya gönderemezsiniz.!");
        }else if (this.dentalCommitmentFormViewModel._DentalCommitment.CommitmentTakenBySurname == null || this.dentalCommitmentFormViewModel._DentalCommitment.CommitmentTakenBySurname == ''){
            ServiceLocator.MessageService.showError("Taahhüt Alanın Soyadı girmeden taahhütü medulaya gönderemezsiniz.!");
        }else{
            inputdvo.adressIlPlaka = (<City>this.dentalCommitmentFormViewModel._DentalCommitment.City).Code;
            inputdvo.adressIlce = (<TownDefinitions>this.dentalCommitmentFormViewModel._DentalCommitment.Town).Name;
            inputdvo.adressCaddeSokak = this.dentalCommitmentFormViewModel._DentalCommitment.StreetName;
            inputdvo.adressDisKapiNo = this.dentalCommitmentFormViewModel._DentalCommitment.OuterDoorNo;
            inputdvo.adressEposta = this.dentalCommitmentFormViewModel._DentalCommitment.EMail;
            inputdvo.adressIcKapiNo = this.dentalCommitmentFormViewModel._DentalCommitment.InnerDoorNo;
            inputdvo.adressPostaKodu = this.dentalCommitmentFormViewModel._DentalCommitment.PostCode;
            inputdvo.adressTelefon = this.dentalCommitmentFormViewModel._DentalCommitment.PhoneNumber;
            inputdvo.hastaTCKimlikNo = this.dentalCommitmentFormViewModel.patientUniqueRefNo;
            inputdvo.taahhutAlanAd = this.dentalCommitmentFormViewModel._DentalCommitment.CommitmentTakenByName;
            inputdvo.taahhutAlanSoyad = this.dentalCommitmentFormViewModel._DentalCommitment.CommitmentTakenBySurname;
    
            let fullApiUrl = 'api/DisTaahhutForm/SaveTaahhut';
            this.http.post(fullApiUrl, inputdvo)
                .then((res: SaveTaahhutOutputDVO) => {
                    let result = <SaveTaahhutOutputDVO>res;
                    if (result.işlemSonuc === true) {
                        this.dentalCommitmentFormViewModel._DentalCommitment.CommitmentNo = result.txtAlınanTaahhutNo;
                        this.dentalCommitmentFormViewModel._DentalCommitment.CommitmentResultCode = result.txtSonucKoduTaahhutKaydet;
                        this.dentalCommitmentFormViewModel._DentalCommitment.CommitmentResultMessage = result.txtSonucMesajiTaahhutKaydet;
                        this.dentalCommitmentFormViewModel._DentalCommitment.SendDate = result.taahhutGonderimTarihi;
                        ServiceLocator.MessageService.showInfo(result.işlemSonucMesajı);
    
                        this.printDisTaahhutReport();
    
    
                    } else {
                        this.dentalCommitmentFormViewModel._DentalCommitment.CommitmentResultCode = result.txtSonucKoduTaahhutKaydet;
                        this.dentalCommitmentFormViewModel._DentalCommitment.CommitmentResultMessage = result.txtSonucMesajiTaahhutKaydet;
                        ServiceLocator.MessageService.showError(result.işlemSonucMesajı);
                    }
                    this.save();
    
                })
                .catch(error => {
                    console.log(error);
                    ServiceLocator.MessageService.showError(error);
                });
    
        }
        
    }

    buttonTaahhutNoileTaahhutOku_Click() {
        let that = this;
        this.http.get<ReadTaahhutOutputDVO>('api/DisTaahhutForm/ReadTaahhut?TaahhutNo=' + this.okunacakTaahhutNumarasi.toString()).then((output: ReadTaahhutOutputDVO) => {
            if (output.işlemSonuc === true) {
                that.txtSonucKoduTaahhutNoileSorgula = output.txtSonucKoduTaahhutNoileSorgula;
                that.txtSonucMesajiTaahhutNoileSorgula = output.txtSonucMesajiTaahhutNoileSorgula;
                ServiceLocator.MessageService.showInfo(output.işlemSonucMesajı);
            } else {
                that.txtSonucKoduTaahhutNoileSorgula = output.txtSonucKoduTaahhutNoileSorgula;
                that.txtSonucMesajiTaahhutNoileSorgula = output.txtSonucMesajiTaahhutNoileSorgula;
                ServiceLocator.MessageService.showInfo(output.işlemSonucMesajı);
            }
        });
    }

    buttonTaahhutSil_Click() {
        let that = this;
        this.http.get<DeleteTaahhutOutputDVO>('api/DisTaahhutForm/DeleteTaahhut?TaahhutNo=' + this.silinecekTaahhutNo.toString()).then((output: DeleteTaahhutOutputDVO) => {
            if (output.işlemSonuc === true) {
                that.txtSonucKoduTaahhutSil = output.txtSonucKoduTaahhutSil;
                that.txtSonucMesajiTaahhutSil = output.txtSonucMesajiTaahhutSil;
                ServiceLocator.MessageService.showInfo(output.işlemSonucMesajı);
            } else {
                that.txtSonucKoduTaahhutSil = output.txtSonucKoduTaahhutSil;
                that.txtSonucMesajiTaahhutSil = output.txtSonucMesajiTaahhutSil;
                ServiceLocator.MessageService.showInfo(output.işlemSonucMesajı);
            }
        });
    }

    buttonTCKimlikNoIleTaahhutSorgula_Click() {
        let that = this;
        this.http.get<ReadTaahhutTCOutputDVO>('api/DisTaahhutForm/ReadTaahhutTC?TcNo=' + this.dentalCommitmentFormViewModel.patientUniqueRefNo.toString()).then((output: ReadTaahhutTCOutputDVO) => {
            if (output.işlemSonuc === true) {
                that.txtSonucKoduTCKimlikNoileSorgula = output.txtSonucKoduTCKimlikNoileSorgula;
                that.txtSonucMesajTCKimlikNoileSorgula = output.txtSonucMesajTCKimlikNoileSorgula;
                that.taahhutler = output.taahhutler;
                ServiceLocator.MessageService.showInfo(output.işlemSonucMesajı);
            } else {
                that.txtSonucKoduTCKimlikNoileSorgula = output.txtSonucKoduTCKimlikNoileSorgula;
                that.txtSonucMesajTCKimlikNoileSorgula = output.txtSonucMesajTCKimlikNoileSorgula;
                ServiceLocator.MessageService.showInfo(output.işlemSonucMesajı);
            }
        });
    }

    printDisTaahhutReport() {
        try {
            const objectIdParam = new GuidParam(this.dentalCommitmentFormViewModel.DentalExaminationID);
            let reportParameters: any = { 'DentalExamination': objectIdParam };
            this.reportService.showReport('DISTAAHHUTREPORT', reportParameters);
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }
    /*ESKİ METODLAR SON */

    protected redirectProperties(): void {
        redirectProperty(this.PostCode, "Text", this.__ttObject, "PostCode");
        redirectProperty(this.StreetName, "Text", this.__ttObject, "StreetName");
        redirectProperty(this.OuterDoorNo, "Text", this.__ttObject, "OuterDoorNo");
        redirectProperty(this.PhoneNumber, "Text", this.__ttObject, "PhoneNumber");
        redirectProperty(this.EMail, "Text", this.__ttObject, "EMail");
        redirectProperty(this.CommitmentTakenByName, "Text", this.__ttObject, "CommitmentTakenByName");
        redirectProperty(this.CommitmentTakenBySurname, "Text", this.__ttObject, "CommitmentTakenBySurname");
        redirectProperty(this.InnerDoorNo, "Text", this.__ttObject, "InnerDoorNo");
        redirectProperty(this.CommitmentNo, "Text", this.__ttObject, "CommitmentNo");
        redirectProperty(this.CommitmentResultCode, "Text", this.__ttObject, "CommitmentResultCode");
        redirectProperty(this.CommitmentProtocolNo, "Text", this.__ttObject, "CommitmentProtocolNo");
        redirectProperty(this.CommitmentResultMessage, "Text", this.__ttObject, "CommitmentResultMessage");
    }

    public initFormControls(): void {
        this.labelCommitmentResultMessage = new TTVisual.TTLabel();
        this.labelCommitmentResultMessage.Text = "Sonuç Mesajı";
        this.labelCommitmentResultMessage.Name = "labelCommitmentResultMessage";
        this.labelCommitmentResultMessage.TabIndex = 29;

        this.CommitmentResultMessage = new TTVisual.TTTextBox();
        this.CommitmentResultMessage.Multiline = true;
        this.CommitmentResultMessage.Name = "CommitmentResultMessage";
        this.CommitmentResultMessage.TabIndex = 28;

        this.CommitmentResultCode = new TTVisual.TTTextBox();
        this.CommitmentResultCode.Name = "CommitmentResultCode";
        this.CommitmentResultCode.TabIndex = 26;

        this.CommitmentProtocolNo = new TTVisual.TTTextBox();
        this.CommitmentProtocolNo.Name = "CommitmentProtocolNo";
        this.CommitmentProtocolNo.TabIndex = 24;

        this.CommitmentNo = new TTVisual.TTTextBox();
        this.CommitmentNo.Name = "CommitmentNo";
        this.CommitmentNo.TabIndex = 22;

        this.InnerDoorNo = new TTVisual.TTTextBox();
        this.InnerDoorNo.Name = "InnerDoorNo";
        this.InnerDoorNo.TabIndex = 14;

        this.CommitmentTakenBySurname = new TTVisual.TTTextBox();
        this.CommitmentTakenBySurname.Name = "CommitmentTakenBySurname";
        this.CommitmentTakenBySurname.TabIndex = 12;

        this.CommitmentTakenByName = new TTVisual.TTTextBox();
        this.CommitmentTakenByName.Name = "CommitmentTakenByName";
        this.CommitmentTakenByName.TabIndex = 10;

        this.EMail = new TTVisual.TTTextBox();
        this.EMail.Name = "EMail";
        this.EMail.TabIndex = 8;

        this.PhoneNumber = new TTVisual.TTTextBox();
        this.PhoneNumber.Name = "PhoneNumber";
        this.PhoneNumber.TabIndex = 6;

        this.OuterDoorNo = new TTVisual.TTTextBox();
        this.OuterDoorNo.Name = "OuterDoorNo";
        this.OuterDoorNo.TabIndex = 4;

        this.StreetName = new TTVisual.TTTextBox();
        this.StreetName.Name = "StreetName";
        this.StreetName.TabIndex = 2;

        this.PostCode = new TTVisual.TTTextBox();
        this.PostCode.Name = "PostCode";
        this.PostCode.TabIndex = 0;

        this.labelCommitmentResultCode = new TTVisual.TTLabel();
        this.labelCommitmentResultCode.Text = "Sonuç Kodu";
        this.labelCommitmentResultCode.Name = "labelCommitmentResultCode";
        this.labelCommitmentResultCode.TabIndex = 27;

        this.labelCommitmentProtocolNo = new TTVisual.TTLabel();
        this.labelCommitmentProtocolNo.Text = "Takip No";
        this.labelCommitmentProtocolNo.Name = "labelCommitmentProtocolNo";
        this.labelCommitmentProtocolNo.TabIndex = 25;

        this.labelCommitmentNo = new TTVisual.TTLabel();
        this.labelCommitmentNo.Text = "Taahhüt Numarası";
        this.labelCommitmentNo.Name = "labelCommitmentNo";
        this.labelCommitmentNo.TabIndex = 23;

        this.DentalCommitmentProstethises = new TTVisual.TTGrid();
        this.DentalCommitmentProstethises.Name = "DentalCommitmentProstethises";
        this.DentalCommitmentProstethises.TabIndex = 21;
        this.DentalCommitmentProstethises.AllowUserToAddRows = false;

        this.DentalProsthesisDefinitionName = new TTVisual.TTTextBoxColumn();
        this.DentalProsthesisDefinitionName.DataMember = "DentalProsthesisDefinition.Name";
        this.DentalProsthesisDefinitionName.DisplayIndex = 0;
        this.DentalProsthesisDefinitionName.HeaderText = "Sut Kodu";
        this.DentalProsthesisDefinitionName.Name = "DentalProsthesisDefinitionName";
        this.DentalProsthesisDefinitionName.Width = 250;

        this.ToothNoDentalCommitmentProsthesis = new TTVisual.TTTextBoxColumn();
        this.ToothNoDentalCommitmentProsthesis.DataMember = "ToothNo";
        this.ToothNoDentalCommitmentProsthesis.DisplayIndex = 1;
        this.ToothNoDentalCommitmentProsthesis.HeaderText = "Diş No";
        this.ToothNoDentalCommitmentProsthesis.Name = "ToothNoDentalCommitmentProsthesis";
        this.ToothNoDentalCommitmentProsthesis.Width = 80;

        this.DentalProsthesisDefinitionDentalCommitmentProsthesis = new TTVisual.TTListBoxColumn();
        this.DentalProsthesisDefinitionDentalCommitmentProsthesis.ListDefName = "DentalProsthesisListDefinition";
        this.DentalProsthesisDefinitionDentalCommitmentProsthesis.DataMember = "DentalProsthesisDefinition";
        this.DentalProsthesisDefinitionDentalCommitmentProsthesis.DisplayIndex = 2;
        this.DentalProsthesisDefinitionDentalCommitmentProsthesis.HeaderText = "";
        this.DentalProsthesisDefinitionDentalCommitmentProsthesis.Name = "DentalProsthesisDefinitionDentalCommitmentProsthesis";
        this.DentalProsthesisDefinitionDentalCommitmentProsthesis.Visible = false;
        this.DentalProsthesisDefinitionDentalCommitmentProsthesis.Width = 100;

        this.labelTown = new TTVisual.TTLabel();
        this.labelTown.Text = "İlçe Adı";
        this.labelTown.Name = "labelTown";
        this.labelTown.TabIndex = 20;

        this.Town = new TTVisual.TTObjectListBox();
        this.Town.ListDefName = "TownListDefinition";
        this.Town.Name = "Town";
        this.Town.TabIndex = 19;

        this.labelCity = new TTVisual.TTLabel();
        this.labelCity.Text = "İl Plaka";
        this.labelCity.Name = "labelCity";
        this.labelCity.TabIndex = 18;

        this.City = new TTVisual.TTObjectListBox();
        this.City.ListDefName = "CityListDefinition";
        this.City.Name = "City";
        this.City.TabIndex = 17;

        this.labelInnerDoorNo = new TTVisual.TTLabel();
        this.labelInnerDoorNo.Text = "İç Kapı No";
        this.labelInnerDoorNo.Name = "labelInnerDoorNo";
        this.labelInnerDoorNo.TabIndex = 15;

        this.labelCommitmentTakenBySurname = new TTVisual.TTLabel();
        this.labelCommitmentTakenBySurname.Text = "Taahhüt Alanın Soyadı";
        this.labelCommitmentTakenBySurname.Name = "labelCommitmentTakenBySurname";
        this.labelCommitmentTakenBySurname.TabIndex = 13;

        this.labelCommitmentTakenByName = new TTVisual.TTLabel();
        this.labelCommitmentTakenByName.Text = "Taahhüt Alanın Adı";
        this.labelCommitmentTakenByName.Name = "labelCommitmentTakenByName";
        this.labelCommitmentTakenByName.TabIndex = 11;

        this.labelEMail = new TTVisual.TTLabel();
        this.labelEMail.Text = "E-Posta";
        this.labelEMail.Name = "labelEMail";
        this.labelEMail.TabIndex = 9;

        this.labelPhoneNumber = new TTVisual.TTLabel();
        this.labelPhoneNumber.Text = "Telefon No";
        this.labelPhoneNumber.Name = "labelPhoneNumber";
        this.labelPhoneNumber.TabIndex = 7;

        this.labelOuterDoorNo = new TTVisual.TTLabel();
        this.labelOuterDoorNo.Text = "Dış Kapı No";
        this.labelOuterDoorNo.Name = "labelOuterDoorNo";
        this.labelOuterDoorNo.TabIndex = 5;

        this.labelStreetName = new TTVisual.TTLabel();
        this.labelStreetName.Text = "Cadde-Sokak Adı";
        this.labelStreetName.Name = "labelStreetName";
        this.labelStreetName.TabIndex = 3;

        this.labelPostCode = new TTVisual.TTLabel();
        this.labelPostCode.Text = "Posta Kodu";
        this.labelPostCode.Name = "labelPostCode";
        this.labelPostCode.TabIndex = 1;

        this.DentalCommitmentProstethisesColumns = [this.DentalProsthesisDefinitionName, this.ToothNoDentalCommitmentProsthesis, this.DentalProsthesisDefinitionDentalCommitmentProsthesis];
        this.Controls = [this.labelCommitmentResultMessage, this.CommitmentResultMessage, this.CommitmentResultCode, this.CommitmentProtocolNo, this.CommitmentNo, this.InnerDoorNo, this.CommitmentTakenBySurname, this.CommitmentTakenByName, this.EMail, this.PhoneNumber, this.OuterDoorNo, this.StreetName, this.PostCode, this.labelCommitmentResultCode, this.labelCommitmentProtocolNo, this.labelCommitmentNo, this.DentalCommitmentProstethises, this.DentalProsthesisDefinitionName, this.ToothNoDentalCommitmentProsthesis, this.DentalProsthesisDefinitionDentalCommitmentProsthesis, this.labelTown, this.Town, this.labelCity, this.City, this.labelInnerDoorNo, this.labelCommitmentTakenBySurname, this.labelCommitmentTakenByName, this.labelEMail, this.labelPhoneNumber, this.labelOuterDoorNo, this.labelStreetName, this.labelPostCode];

    }


}
