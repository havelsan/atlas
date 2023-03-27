//$BE298A5D
import { Component, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { TedaviRaporiIslemKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { OnInitOutputDVO, ActiveMedulaProvision } from './OrtodontiFormViewModel';
import { DentalExaminationService, SaveOrtodontiFormOutputDVO, ReadOrtodontiFormOutputDVO } from 'ObjectClassService/DentalExaminationService';

@Component({
    selector: 'ortodonti-form-component',
    template: `
<div class="container-fluid">
    <div class="row">
        <div class="col-sm-3">
            Hasta Adı
            <dx-text-box [readOnly]="true"
                         [hoverStateEnabled]="false"
                         [(value)]="txtName"></dx-text-box>
        </div>
        <div class="col-sm-3">
            Hasta Soyadı
            <dx-text-box [readOnly]="true"
                         [hoverStateEnabled]="false"
                         [(value)]="txtSurname"></dx-text-box>
        </div>
        <div class="col-sm-3">
            TC Kimlik Numarası
            <dx-text-box [readOnly]="true"
                         [hoverStateEnabled]="false"
                         [(value)]="txtTCKNo"></dx-text-box>
        </div>
        <div class="col-sm-2">
            Doğum Tarihi
            <dx-text-box [readOnly]="true"
                         [hoverStateEnabled]="false"
                         [(value)]="txtBirthDate"></dx-text-box>
        </div>
        <div class="col-sm-1">
            Cinsiyeti
            <dx-text-box [readOnly]="true"
                         [hoverStateEnabled]="false"
                         [(value)]="txtSex"></dx-text-box>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-12">
            <dx-radio-group [items]="priorities"
                            [value]="priorities[0]"
                            layout="horizontal"
                            (onValueChanged)="onValueChangedType($event)">
            </dx-radio-group>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-6">
            SUT Kodu
            <dx-select-box [items]="suts"
                           [(selectedItem)]="selectedSutItem"
                           displayExpr="TedaviRaporuIslemi"
                           valueExpr="TedaviRaporuIslemKodu"
                           [searchEnabled]="true"></dx-select-box>
        </div>
        <div class="col-sm-2">
            Form No
            <dx-text-box [(value)]="txtFormNumarasi"></dx-text-box>
        </div>
    </div>
    <br />
    <div class="row">
        <dx-tab-panel [selectedIndex]="0">
            <dxi-item *ngIf="isSave" class="tabpanel-item" title="Ortodonti Formu Kaydet">
                <div class="row">
                    <div class="col-sm-12">
                        <dx-data-grid #provisionGrid
                                      [dataSource]="provisions"
                                      [hoverStateEnabled]="true"
                                      [selectedRowKeys]="selectedProvision">
                            <dxo-selection mode="single"></dxo-selection>
                            <dxi-column dataField="TakipNo" caption="Takip No" [width]="100"></dxi-column>
                            <dxi-column dataField="Brans" caption="Branş" [width]="200"></dxi-column>
                            <dxi-column dataField="ProvisionDate" caption="Provizyon Tarihi" [width]="100" dataType="date"></dxi-column>
                            <dxi-column dataField="BarsvuruNo" caption="Başvuru Numarası" [width]="150"></dxi-column>
                            <dxi-column dataField="ProtocolNo" caption="H.Protokol No" [width]="100"></dxi-column>
                            <dxi-column dataField="OpenDate" caption="Vaka Açılış Tarihi" [width]="100" dataType="date"></dxi-column>
                            <dxi-column dataField="BransKodu" caption="Branş Kodu" [width]="100"></dxi-column>
                        </dx-data-grid>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-2">
                        İşlem Tarihi
                        <dx-date-box [(value)]="ReportTime"
                                     type="date">
                        </dx-date-box>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-4">
                        <dx-button icon="check"
                                   type="success"
                                   text="Ortodonti Formu Kaydet"
                                   (onClick)="buttonOrtodontiKaydet_Click()">
                        </dx-button>
                    </div>
                    <div class="col-sm-2">
                        Sonuç Kodu
                        <dx-text-box [readOnly]="true"
                                     [hoverStateEnabled]="false"
                                     [(value)]="txtSonucKodu1"></dx-text-box>
                    </div>
                    <div class="col-sm-6">
                        Sonuç Mesajı
                        <dx-text-area [height]="90"
                                      [readOnly]="true"
                                      [(value)]="txtSonucMesaji">
                        </dx-text-area>
                    </div>
                </div>
            </dxi-item>
            <dxi-item *ngIf="isRead" class="tabpanel-item" title="Ortodonti Formu Oku / İptal">
                <br />
                <div class="row">
                    <div class="col-sm-4">
                        <dx-button icon="find"
                                   type="default"
                                   text="Ortodonti Formu Oku"
                                   (onClick)="butttonOrtodontiFormuOku_Click()">
                        </dx-button>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-2">
                        İşlem Türü
                        <dx-text-box [readOnly]="true"
                                     [hoverStateEnabled]="false"
                                     [(value)]="txtIslemTuru"></dx-text-box>
                    </div>
                    <div class="col-sm-2">
                        Sonuç Kodu
                        <dx-text-box [readOnly]="true"
                                     [hoverStateEnabled]="false"
                                     [(value)]="txtSonucKodu2"></dx-text-box>
                    </div>
                    <div class="col-sm-7">
                        Sonuç Mesajı
                        <dx-text-box [readOnly]="true"
                                     [hoverStateEnabled]="false"
                                     [(value)]="txtSonucMesaji2"></dx-text-box>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-2">
                        Provizyon No 1
                        <dx-text-box [readOnly]="true"
                                     [hoverStateEnabled]="false"
                                     [(value)]="txtProvizyonNo1"></dx-text-box>
                    </div>
                    <div class="col-sm-2">
                        İşlem Tarihi 1
                        <dx-date-box [(value)]="IslemTarihi1"
                                     [disabled]="true"
                                     type="date">
                        </dx-date-box>
                    </div>
                    <div class="col-sm-7">
                        Tesis 1
                        <dx-text-box [readOnly]="true"
                                     [hoverStateEnabled]="false"
                                     [(value)]="txtTesis1"></dx-text-box>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-2">
                        Provizyon No 2
                        <dx-text-box [readOnly]="true"
                                     [hoverStateEnabled]="false"
                                     [(value)]="txtProvizyonNo2"></dx-text-box>
                    </div>
                    <div class="col-sm-2">
                        İşlem Tarihi 2
                        <dx-date-box [(value)]="IslemTarihi2"
                                     [disabled]="true"
                                     type="date">
                        </dx-date-box>
                    </div>
                    <div class="col-sm-7">
                        Tesis 2
                        <dx-text-box [readOnly]="true"
                                     [hoverStateEnabled]="false"
                                     [(value)]="txtTesis2"></dx-text-box>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-2">
                        Provizyon No 3
                        <dx-text-box [readOnly]="true"
                                     [hoverStateEnabled]="false"
                                     [(value)]="txtProvizyonNo3"></dx-text-box>
                    </div>
                    <div class="col-sm-2">
                        İşlem Tarihi 3
                        <dx-date-box [(value)]="IslemTarihi3"
                                     [disabled]="true"
                                     type="date">
                        </dx-date-box>
                    </div>
                    <div class="col-sm-7">
                        Tesis 3
                        <dx-text-box [readOnly]="true"
                                     [hoverStateEnabled]="false"
                                     [(value)]="txtTesis3"></dx-text-box>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-4">
                        <dx-button icon="remove"
                                   type="danger"
                                   text="Ortodonti Formu Sil"
                                   (onClick)="butttonOrtodontiFormuSil_Click()">
                        </dx-button>
                    </div>
                </div>
            </dxi-item>
        </dx-tab-panel>
    </div>
</div>
`
})
export class OrtodontiFormComponent implements IModal {
    public patient: Patient;
    public txtName: string;
    public txtSurname: string;
    public txtTCKNo: string;
    public txtBirthDate: string;
    public txtSex: string;
    public priorities: string[];
    public suts: Array<TedaviRaporiIslemKodlari>;
    public selectedSutItem: TedaviRaporiIslemKodlari;
    public provisions: Array<ActiveMedulaProvision>;
    public selectedProvision: Array<ActiveMedulaProvision> = new Array<ActiveMedulaProvision>();
    public ReportTime: Date = new Date();
    public txtFormNumarasi: string;
    public txtSonucKodu1: string;
    public txtSonucMesaji: string;
    public txtIslemTuru: string;
    public txtSonucKodu2: string;
    public txtSonucMesaji2: string;
    public txtProvizyonNo1: string;
    public IslemTarihi1: Date;
    public txtTesis1: string;
    public txtProvizyonNo2: string;
    public IslemTarihi2: Date;
    public txtTesis2: string;
    public txtProvizyonNo3: string;
    public IslemTarihi3: Date;
    public txtTesis3: string;
    public isSave: boolean = true;
    public isRead: boolean = false;

    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
        this.priorities = [
            i18n("M19802", "Ortodonti Kaydet"),
            i18n("M22943", "TC Kimlik Numarası ile Ortodonti Sorgula"),
        ];
    }

    @ViewChild('provisionGrid') provisionGrid: DxDataGridComponent;
    ngOnInit() {
        this.getForm();
    }
    public setInputParam(value: Patient) {
        this.patient = value;
        this.txtName = this.patient.Name;
        this.txtSurname = this.patient.Surname;
        //this.txtTCKNo = this.patient.UniqueRefNo.toString();
        //this.txtSex = this.patient.Sex.ADI;

    }
    public setModalInfo(value: ModalInfo) {
    }

    public cancelClick(): void {
        //this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    public okClick(): void {
        //this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.selectedMaterialList);
    }

    onValueChangedType(e) {
        if (e.value === i18n("M19802", "Ortodonti Kaydet")) {
            this.isSave = true;
            this.isRead = false;
        }
        if (e.value === i18n("M22943", "TC Kimlik Numarası ile Ortodonti Sorgula")) {
            this.isSave = false;
            this.isRead = true;
        }
    }

    getForm() {
        if (this.patient !== null) {
            let that = this;
            this.http.get<OnInitOutputDVO>('api/OrtodontiForm/GetForm?PatientObjectId=' + this.patient.ObjectID.toString()).then((output: OnInitOutputDVO) => {
                that.suts = output.suts;
                that.provisions = output.provisions;
                that.txtTCKNo = output.txtTCKNo;
                that.txtBirthDate = output.txtBirthDate;
                that.txtSex = output.txtSex;
            });
        }
    }

    async buttonOrtodontiKaydet_Click() {
        let prov: ActiveMedulaProvision = this.provisionGrid.selectedRowKeys[0];
        let output: SaveOrtodontiFormOutputDVO = await DentalExaminationService.SaveOrtodontiForm(this.patient, this.selectedSutItem, this.ReportTime,
            this.txtFormNumarasi, prov);
        this.txtFormNumarasi = output.txtFormNumarasi;
        this.txtSonucMesaji = output.txtSonucMesaji;
        this.txtSonucKodu1 = output.txtSonucKodu;
    }

    async butttonOrtodontiFormuOku_Click() {
        let output: ReadOrtodontiFormOutputDVO = await DentalExaminationService.ReadOrtodontiForm(this.patient, this.selectedSutItem, this.txtFormNumarasi);
        this.txtIslemTuru = output.txtIslemTuru;
        this.txtFormNumarasi = output.txtFormNumarasi;
        this.txtSonucMesaji2 = output.txtSonucMesaji;
        this.txtSonucKodu2 = output.txtSonucKodu;
        this.txtProvizyonNo1 = output.txtProvizyonNo1;
        this.IslemTarihi1 = output.IslemTarihi1;
        this.txtTesis1 = output.txtTesis1;
        this.txtProvizyonNo2 = output.txtProvizyonNo2;
        this.IslemTarihi2 = output.IslemTarihi2;
        this.txtTesis2 = output.txtTesis2;
        this.txtProvizyonNo3 = output.txtProvizyonNo3;
        this.IslemTarihi3 = output.IslemTarihi3;
        this.txtTesis3 = output.txtTesis3;

    }

    async butttonOrtodontiFormuSil_Click() {
        let output: ReadOrtodontiFormOutputDVO = await DentalExaminationService.DeleteOrtodontiForm(this.patient, this.selectedSutItem, this.txtFormNumarasi);
        this.txtIslemTuru = output.txtIslemTuru;
        this.txtFormNumarasi = output.txtFormNumarasi;
        this.txtSonucMesaji2 = output.txtSonucMesaji;
        this.txtSonucKodu2 = output.txtSonucKodu;
        this.txtProvizyonNo1 = output.txtProvizyonNo1;
        this.IslemTarihi1 = output.IslemTarihi1;
        this.txtTesis1 = output.txtTesis1;
        this.txtProvizyonNo2 = output.txtProvizyonNo2;
        this.IslemTarihi2 = output.IslemTarihi2;
        this.txtTesis2 = output.txtTesis2;
        this.txtProvizyonNo3 = output.txtProvizyonNo3;
        this.IslemTarihi3 = output.IslemTarihi3;
        this.txtTesis3 = output.txtTesis3;

    }
}