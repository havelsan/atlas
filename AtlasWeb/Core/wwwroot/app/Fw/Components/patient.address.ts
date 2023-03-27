import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";
import { PatientIdentityAndAddress } from 'NebulaClient/Model/AtlasClientModel';
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";

@Component({
    selector: "hvl-patientaddress-component",
    template: `
<style>
label {
    font-size:11px;
    padding-left: 15px;
}

</style>
<div>
    <div class="row">
        <div class="col-md-4">
            <label>Adres Tipi</label>
            <div class="col-sm-12" style="text-align: center">
                 <hvl-list-box (SelectedObjectChange)="srkAdresObjectChange($event)" [(SelectedObject)]="_patAddress.SKRSAdresTipi"  DefinitionName="SKRSAdresTipiList"  [ReadOnly]="false" [Required]="true" [TabIndex]="17" [Visible]="true"></hvl-list-box>
            </div>
        </div>
        <div class="col-md-4">
            <label>Adres No</label>
            <div class="col-sm-12" style="text-align: center">
                <dx-text-box [(value)]="_patAddress.AddressNo"></dx-text-box>
            </div>
        </div>
        <div class="col-md-4">
            <label>Bina Ada</label>
            <div class="col-sm-12" style="text-align: center">
                <dx-text-box [(value)]="_patAddress.BuildingSquare"></dx-text-box>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <label>Bina Blok Adı</label>
            <div class="col-sm-12" style="text-align: center">
                <dx-text-box [(value)]="_patAddress.BuildingBlockName"></dx-text-box>
            </div>
        </div>
        <div class="col-md-4">
            <label>Bina Kodu</label>
            <div class="col-sm-12" style="text-align: center">
                <dx-text-box [(value)]="_patAddress.BuildingCode"></dx-text-box>
            </div>
        </div>
        <div class="col-md-4">
            <label>Bina No</label>
            <div class="col-sm-12" style="text-align: center">
                <dx-text-box [(value)]="_patAddress.BuildingNo"></dx-text-box>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label>Bina Site Adı</label>
            <div class="col-sm-12" style="text-align: center">
                <dx-text-box [(value)]="_patAddress.SiteName"></dx-text-box>
            </div>
        </div>
        <div class="col-md-4">
            <label>Bina Pafta</label>
            <div class="col-sm-12" style="text-align: center">
                <dx-text-box [(value)]="_patAddress.BuildingSheet"></dx-text-box>
            </div>
        </div>
        <div class="col-md-4">
            <label>Bina Parsel</label>
            <div class="col-sm-12" style="text-align: center">
                <dx-text-box [(value)]="_patAddress.BuildingParcel"></dx-text-box>
            </div>
        </div>

    </div>

    <div class="row">
         <div class="col-md-4">
            <label>Ev Telefonu</label>
            <div class="col-sm-12" style="text-align: center">
                <dx-text-box [(value)]="_patAddress.HomePhone"></dx-text-box>
            </div>
        </div>
        <div class="col-md-4">
            <label>Ev Adresi Posta Kodu</label>
            <div class="col-sm-12" style="text-align: center">
                <dx-text-box [(value)]="_patAddress.HomePostcode"></dx-text-box>
            </div>
        </div>
        <div class="col-md-4">
            <label>Bucak Kodu/Adı</label>
            <div class="col-sm-12" style="text-align: center">
                 <hvl-list-box  (SelectedObjectChange)="srkBucakObjectChange($event)" [(SelectedObject)]="_patAddress.SKRSBucakKodu" DefinitionName="SKRSBucakKodlariList"  [ReadOnly]="false" [Required]="true" [TabIndex]="16" [Visible]="true"></hvl-list-box>
            </div>
        </div>
    </div>


    <div class="row">
        <div class="col-md-4">
            <label>CSBM Kodu/Adı</label>
            <div class="col-sm-12" style="text-align: center">
                 <hvl-list-box  (SelectedObjectChange)="srkCSBMObjectChange($event)" [(SelectedObject)]="_patAddress.SKRSCsbmKodu" DefinitionName="SKRSCSBMTipiList"  [ReadOnly]="false" [Required]="true" [TabIndex]="15" [Visible]="true"></hvl-list-box>

            </div>
        </div>
        <div class="col-md-4">
            <label>Dış Kapı No</label>
            <div class="col-sm-12" style="text-align: center">
                <dx-text-box [(value)]="_patAddress.DisKapi"></dx-text-box>
            </div>
        </div>
        <div class="col-md-4">
            <label>İç Kapı No</label>
            <div class="col-sm-12" style="text-align: center">
                <dx-text-box [(value)]="_patAddress.IcKapi"></dx-text-box>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <label>İl</label>
            <div class="col-sm-12" style="text-align: center">
                 <hvl-list-box  (SelectedObjectChange)="srkILObjectChange($event)" [(SelectedObject)]="_patAddress.SKRSILKodlari"  DefinitionName="SKRSILKodlariList"  [ReadOnly]="false" [Required]="true" [TabIndex]="14" [Visible]="true"></hvl-list-box>

            </div>
        </div>
        <div class="col-md-4">
            <label>İlçe</label>
            <div class="col-sm-12" style="text-align: center">
                 <hvl-list-box  (SelectedObjectChange)="srkIlceObjectChange($event)" [(SelectedObject)]="_patAddress.SKRSIlceKodlari" DefinitionName="SKRSIlceKodlariList" [ReadOnly]="false" [Required]="true" [TabIndex]="13" [Visible]="true"></hvl-list-box>
            </div>
        </div>
        <div class="col-md-4">
            <label>Mahalle</label>
            <div class="col-sm-12" style="text-align: center">
                <hvl-list-box  (SelectedObjectChange)="srkMahalleObjectChange($event)" [(SelectedObject)]="_patAddress.SKRSMahalleKodlari" DefinitionName="SKRSMahalleKodlariList" [ReadOnly]="false" [Required]="true" [TabIndex]="12" [Visible]="true"></hvl-list-box>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
                    <label>Köy</label>
                    <div class="col-sm-12" style="text-align: center">
                            <hvl-list-box  (SelectedObjectChange)="srkKoyObjectChange($event)" [(SelectedObject)]="_patAddress.SKRSKoyKodlari" DefinitionName="SKRSKoyKodlariList" [ReadOnly]="false" [Required]="true" [TabIndex]="1" [Visible]="true"></hvl-list-box>
                    </div>
                </div>
                <div class="col-md-4">
                    <label>İş Adresi Posta Kodu</label>
                    <div class="col-sm-12" style="text-align: center">
                        <dx-text-box [(value)]="_patAddress.BusinessPostcode"></dx-text-box>
                    </div>
                </div>
                <div class="col-md-4">
                    <label>İş Telefon No</label>
                    <div class="col-sm-12" style="text-align: center">
                        <dx-text-box [(value)]="_patAddress.BusinessPhone"></dx-text-box>
                    </div>
                </div>
    </div>
    <div class="row">

        <div class="col-md-4">
            <label>İş adresi</label>
            <div class="col-sm-12" style="text-align: center">
                <dx-text-box [(value)]="_patAddress.BusinessAddress"></dx-text-box>
            </div>
        </div>

        <div class="col-md-4">
            <label>Yabancı Şehir</label>
            <div class="col-sm-12" style="text-align: center">
                <dx-text-box [(value)]="_patAddress.ForeignCity"></dx-text-box>
            </div>
        </div>

    </div>

    <div class="row">
        <div class="col-md-6">
            <label>Yabancı Adres</label>
            <div class="col-sm-12" style="text-align: center">
                <dx-text-box [(value)]="_patAddress.ForeignAddress"></dx-text-box>
            </div>
        </div>
    </div>
<hr>

    <div class="row">
        <div class="col-md-6">
            <div class="col-sm-5" style="float: left">
                <dx-button text="Tamam" (onClick)="okClick()"></dx-button>
            </div>
        </div>

        <div class="col-md-6">
            <div class="col-sm-5" style="float: right">
                <dx-button text="İptal" (onClick)="cancelClick()"></dx-button>
            </div>
        </div>
    </div>

</div>
    `,
})
export class PatientAddressComponent implements IModal {
    public _patAddress: PatientIdentityAndAddress;
    private _modalInfo: ModalInfo;


    constructor(private modalStateService: ModalStateService) {
    }

    public setInputParam(value: PatientIdentityAndAddress) {
        this._patAddress = value;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;

    }

    public srkMahalleObjectChange(value: any): void {
        if (this._patAddress != null && this._patAddress.SKRSMahalleKodlari)
            this._patAddress.SKRSMahalleKodlari.ADI = value;
    }
    public srkKoyObjectChange(value: any): void {
        if (this._patAddress != null && this._patAddress.SKRSKoyKodlari)
            this._patAddress.SKRSKoyKodlari.ADI = value;

    }
    public srkCSBMObjectChange(value: any): void {
        if (this._patAddress != null && this._patAddress.SKRSCsbmKodu)
            this._patAddress.SKRSCsbmKodu.ADI = value;
    }
    public srkBucakObjectChange(value: any): void {
        if (this._patAddress != null && this._patAddress.SKRSBucakKodu)
            this._patAddress.SKRSBucakKodu.ADI = value;
    }
    public srkIlceObjectChange(value: any): void {
        if (this._patAddress != null && this._patAddress.SKRSIlceKodlari)
            this._patAddress.SKRSIlceKodlari.ADI = value;
    }
    public srkILObjectChange(value: any): void {
        if (this._patAddress != null && this._patAddress.SKRSILKodlari)
            this._patAddress.SKRSILKodlari.ADI = value;
    }
    public srkAdresObjectChange(value: any): void {
        if (this._patAddress != null && this._patAddress.SKRSAdresTipi)
            this._patAddress.SKRSAdresTipi.ADI = value;
    }
    public srkUlkeObjectChange(value: any): void {
        if (this._patAddress != null)
            this._patAddress.ForeignCountry = value.Adi;

    }
    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    public okClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._patAddress);
    }

}