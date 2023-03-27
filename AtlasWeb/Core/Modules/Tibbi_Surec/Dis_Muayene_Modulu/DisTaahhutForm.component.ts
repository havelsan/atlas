//$11002322
import { Component, ViewChild } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import {
    OnInitOutputDVO, ActiveMedulaProvision, AddSut, SaveTaahhutInputDVO, SaveTaahhutOutputDVO, ReadTaahhutTCOutputDVO,
    Taahhut, DeleteTaahhutOutputDVO, ReadTaahhutOutputDVO
} from './DisTaahhutFormViewModel';
import { City } from 'NebulaClient/Model/AtlasClientModel';
import { TownDefinitions } from 'NebulaClient/Model/AtlasClientModel';
import DataSource from 'devextreme/data/data_source';
import { DxDataGridComponent, DxSelectBoxComponent } from 'devextreme-angular';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DentalProsthesisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { DisTaahuutInput }  from './DentalExaminationFormViewModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';


@Component({
    selector: 'disTaahhut-form-component',
    template: `
<div class="container-fluid">
    <div class="row">
        <div class="col-sm-3" i18n="@@M30701">
            Hasta Adı
            <dx-text-box [(value)]="patientName" [disabled]="true">
            </dx-text-box>
        </div>
        <div class="col-sm-3" i18n="@@M15303">
            Hasta Soyadı
            <dx-text-box [(value)]="patientSurname" [disabled]="true">
            </dx-text-box>
        </div>
        <div class="col-sm-3" i18n="@@M22941">
            TC Kimlik Numarası
            <dx-text-box [(value)]="patientUniqueNo" [disabled]="true">
            </dx-text-box>
        </div>
        <div class="col-sm-2" i18n="@@M25513">
            Doğum Tarihi
            <dx-text-box [(value)]="patientBirthday" [disabled]="true">
            </dx-text-box>
        </div>
        <div class="col-sm-1"  i18n="@@M27439">
            Cinsiyeti
            <dx-text-box [(value)]="patientSex" [disabled]="true">
            </dx-text-box>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-12"  i18n="@@M16895">
            İşlem Türü
            <dx-radio-group [items]="actionSelectItem" [value]="actionSelectItem[0]" layout="horizontal" (onValueChanged)="onValueChanged($event)">
            </dx-radio-group>
        </div>
    </div>
    <br />
    <div class="row">
        <dx-tab-panel [selectedIndex]="0">
            <dxi-item *ngIf="taahhutKaydetBool" class="tabpanel-item" title="Taahhüt Kaydet">
                <div class="container-fluid">
                    <div class="row" style="height:100px">
                        <div class="col-sm-8">
                            <br />
                            <div class="row">
                                <div class="col-sm-2"  i18n="@@M30515">
                                    İl Plaka
                                    <dx-select-box #il  [items]="cities" displayExpr="Name" [(value)]="city" valueExpr="ObjectID" [searchEnabled]="true" (onValueChanged)="selectCity($event)"></dx-select-box>
                                </div>
                                <div class="col-sm-2"  i18n="@@M30516">
                                    Ilce Adı
                                    <dx-select-box #ilce [items]="towns" displayExpr="Name" [(value)]="town" valueExpr="ObjectID" [searchEnabled]="true"></dx-select-box>
                                </div>
                                <div class="col-sm-2"  i18n="@@M20451">
                                    Posta Kodu
                                    <dx-text-box [(value)]="postKode"> </dx-text-box>
                                </div>
                                <div class="col-sm-4"  i18n="@@M12160">
                                    Cadde Sokak Adı
                                    <dx-text-box [(value)]="streetName"> </dx-text-box>
                                </div>
                                <div class="col-sm-2"  i18n="@@M12746">
                                    Dış Kapı No
                                    <dx-text-box [(value)]="outDoorNo"> </dx-text-box>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-2" i18n="@@M23138">
                                    Telefon Numarası
                                    <dx-text-box [(value)]="mobilePhoneNo"> </dx-text-box>
                                </div>
                                <div class="col-sm-2"  i18n="@@M13804">
                                    E-Posta
                                    <dx-text-box [(value)]="eMailAdress"> </dx-text-box>
                                </div>
                                <div class="col-sm-2"  i18n="@@M22522">
                                    Taahhüt Alanın Adı
                                    <dx-text-box [(value)]="taahhutAlanAdi"> </dx-text-box>
                                </div>
                                <div class="col-sm-4"  i18n="@@M22523">
                                    Taahhüt Alanın Soyadı
                                    <dx-text-box [(value)]="taahhutAlanSoyadi"> </dx-text-box>
                                </div>
                                <div class="col-sm-2"  i18n="@@M16163">
                                    İç Kapı No
                                    <dx-text-box [(value)]="inDoorNo"> </dx-text-box>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <dx-data-grid #provisionGrid [dataSource]="provisions" [hoverStateEnabled]="true" [selectedRowKeys]="[]" style="height:100px ">
                                <dxo-selection mode="single"></dxo-selection>
                                <dxi-column dataField="TakipNo" caption="Takip No" [width]="100" i18n-caption="@@M22659"></dxi-column>
                                <dxi-column dataField="Brans" caption="Branş" [width]="100" i18n-caption="@@M12048"></dxi-column>
                                <dxi-column dataField="ProvisionDate" caption="Provizyon Tarihi" [width]="100" dataType="date" i18n-caption="@@M20586"></dxi-column>
                                <dxi-column dataField="BarsvuruNo" caption="Başvuru Numarası" [width]="100" i18n-caption="@@M30521"></dxi-column>
                                <dxi-column dataField="ProtocolNo" caption="H.Protokol No" [width]="100" i18n-caption="@@M15396"></dxi-column>
                                <dxi-column dataField="OpenDate" caption="Vaka Açılış Tarihi" [width]="100" dataType="date" i18n-caption="@@M27172"></dxi-column>
                                <dxi-column dataField="BransKodu" caption="Branş Kodu" [width]="100" i18n-caption="@@M12052"></dxi-column>
                            </dx-data-grid>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="row">
                                    <div class="col-sm-5">
                                    </div>
                                    <div class="col-sm-2 ">
                                        <hvl-checkbox #ch1 (ValueChange)="optionChanged($event ? '+1' : '-1' );" Title="Tüm Ağız" [(Value)]="checkValues[0]" i18n-Title="@@M23631"></hvl-checkbox>
                                    </div>
                                    <div class="col-sm-5">
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-5">
                                    </div>
                                    <div class="col-sm-2">
                                        <hvl-checkbox #ch2 (ValueChange)="optionChanged($event ? '+2' : '-2' );" Title="Üst Çene" [(Value)]="checkValues[1]" i18n-Title="@@M23981"></hvl-checkbox>
                                    </div>
                                    <div class="col-sm-5">
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-sm-2">
                                    </div>
                                    <div class="col-sm-2 ">
                                        <hvl-checkbox #ch4 (ValueChange)="optionChanged($event ? '+4' : '-4' );" Title="Sağ Üst Çene" [(Value)]="checkValues[2]" i18n-Title="@@M21152"></hvl-checkbox>
                                    </div>
                                    <div class="col-sm-2">
                                    </div>
                                    <div class="col-sm-2">
                                    </div>
                                    <div class="col-sm-2">
                                        <hvl-checkbox #ch5 (ValueChange)="optionChanged($event ? '+5' : '-5' );" Title="Sol Üst Çene" [(Value)]="checkValues[3]" i18n-Title="@@M22021"></hvl-checkbox>
                                    </div>
                                    <div class="col-sm-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="col-sm-2">
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch18 (ValueChange)="optionChanged($event ? '+18' : '-18' );" Title="18" [(Value)]="checkValues[4]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch17 (ValueChange)="optionChanged($event ? '+17' : '-17' );" Title="17" [(Value)]="checkValues[5]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch16 (ValueChange)="optionChanged($event ? '+16' : '-16' );" Title="16" [(Value)]="checkValues[6]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch15 (ValueChange)="optionChanged($event ? '+15' : '-15' );" Title="15" [(Value)]="checkValues[7]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch14 (ValueChange)="optionChanged($event ? '+14' : '-14' );" Title="14" [(Value)]="checkValues[8]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch13 (ValueChange)="optionChanged($event ? '+13' : '-13' );" Title="13" [(Value)]="checkValues[9]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch12 (ValueChange)="optionChanged($event ? '+12' : '-12' );" Title="12" [(Value)]="checkValues[10]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch11 (ValueChange)="optionChanged($event ? '+11' : '-11' );" Title="11" [(Value)]="checkValues[11]"></hvl-checkbox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch21 (ValueChange)="optionChanged($event ? '+21' : '-21' );" Title="21" [(Value)]="checkValues[12]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch22 (ValueChange)="optionChanged($event ? '+22' : '-22' );" Title="22" [(Value)]="checkValues[13]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch23 (ValueChange)="optionChanged($event ? '+23' : '-23' );" Title="23" [(Value)]="checkValues[14]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch24 (ValueChange)="optionChanged($event ? '+24' : '-24' );" Title="24" [(Value)]="checkValues[15]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch25 (ValueChange)="optionChanged($event ? '+25' : '-25' );" Title="25" [(Value)]="checkValues[16]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch26 (ValueChange)="optionChanged($event ? '+26' : '-26' );" Title="26" [(Value)]="checkValues[17]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch27 (ValueChange)="optionChanged($event ? '+27' : '-27' );" Title="27" [(Value)]="checkValues[18]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch28 (ValueChange)="optionChanged($event ? '+28' : '-28' );" Title="28" [(Value)]="checkValues[19]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-2">
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="col-sm-5">
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch55 (ValueChange)="optionChanged($event ? '+55' : '-55' );" Title="55" [(Value)]="checkValues[20]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch54 (ValueChange)="optionChanged($event ? '+54' : '-54' );" Title="54" [(Value)]="checkValues[21]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch53 (ValueChange)="optionChanged($event ? '+53' : '-53' );" Title="53" [(Value)]="checkValues[22]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch52 (ValueChange)="optionChanged($event ? '+52' : '-52' );" Title="52" [(Value)]="checkValues[23]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch51 (ValueChange)="optionChanged($event ? '+51' : '-51' );" Title="51" [(Value)]="checkValues[24]"></hvl-checkbox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch61 (ValueChange)="optionChanged($event ? '+61' : '-61' );" Title="61" [(Value)]="checkValues[25]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch62 (ValueChange)="optionChanged($event ? '+62' : '-62' );" Title="62" [(Value)]="checkValues[26]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch63 (ValueChange)="optionChanged($event ? '+63' : '-63' );" Title="63" [(Value)]="checkValues[27]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch64 (ValueChange)="optionChanged($event ? '+64' : '-64' );" Title="64" [(Value)]="checkValues[28]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch65 (ValueChange)="optionChanged($event ? '+65' : '-65' );" Title="65" [(Value)]="checkValues[29]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-5">
                                        </div>
                                    </div>
                                </div>
                                <hr style="display: flex;
    margin-top: 0.5em;
    margin-bottom: 0.5em;
    margin-left: auto;
    margin-right: auto;
    border-style: inset;
    border-width: 5px;">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="col-sm-5">
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch85 (ValueChange)="optionChanged($event ? '+85' : '-85' );" Title="85" [(Value)]="checkValues[30]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch84 (ValueChange)="optionChanged($event ? '+84' : '-84' );" Title="84" [(Value)]="checkValues[31]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch83 (ValueChange)="optionChanged($event ? '+83' : '-83' );" Title="83" [(Value)]="checkValues[32]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch82 (ValueChange)="optionChanged($event ? '+82' : '-82' );" Title="82" [(Value)]="checkValues[33]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch81 (ValueChange)="optionChanged($event ? '+81' : '-81' );" Title="81" [(Value)]="checkValues[34]"></hvl-checkbox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch71 (ValueChange)="optionChanged($event ? '+71' : '-71' );" Title="71" [(Value)]="checkValues[35]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch72 (ValueChange)="optionChanged($event ? '+72' : '-72' );" Title="72" [(Value)]="checkValues[36]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch73 (ValueChange)="optionChanged($event ? '+73' : '-73' );" Title="73" [(Value)]="checkValues[37]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch74 (ValueChange)="optionChanged($event ? '+74' : '-74' );" Title="74" [(Value)]="checkValues[38]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch75 (ValueChange)="optionChanged($event ? '+75' : '-75' );" Title="75" [(Value)]="checkValues[39]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-5">
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="col-sm-2">
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch48 (ValueChange)="optionChanged($event ? '+48' : '-48' );" Title="48" [(Value)]="checkValues[40]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch47 (ValueChange)="optionChanged($event ? '+47' : '-47' );" Title="47" [(Value)]="checkValues[41]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch46 (ValueChange)="optionChanged($event ? '+46' : '-46' );" Title="46" [(Value)]="checkValues[42]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch45 (ValueChange)="optionChanged($event ? '+45' : '-45' );" Title="45" [(Value)]="checkValues[43]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch44 (ValueChange)="optionChanged($event ? '+44' : '-44' );" Title="44" [(Value)]="checkValues[44]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch43 (ValueChange)="optionChanged($event ? '+43' : '-43' );" Title="43" [(Value)]="checkValues[45]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch42 (ValueChange)="optionChanged($event ? '+42' : '-42' );" Title="42" [(Value)]="checkValues[46]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch41 (ValueChange)="optionChanged($event ? '+41' : '-41' );" Title="41" [(Value)]="checkValues[47]"></hvl-checkbox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch31 (ValueChange)="optionChanged($event ? '+31' : '-31' );" Title="31" [(Value)]="checkValues[48]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch32 (ValueChange)="optionChanged($event ? '+32' : '-32' );" Title="32" [(Value)]="checkValues[49]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch33 (ValueChange)="optionChanged($event ? '+33' : '-33' );" Title="33" [(Value)]="checkValues[50]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch34 (ValueChange)="optionChanged($event ? '+34' : '-34' );" Title="34" [(Value)]="checkValues[51]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch35 (ValueChange)="optionChanged($event ? '+35' : '-35' );" Title="35" [(Value)]="checkValues[52]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch36 (ValueChange)="optionChanged($event ? '+36' : '-36' );" Title="36" [(Value)]="checkValues[53]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch37 (ValueChange)="optionChanged($event ? '+37' : '-37' );" Title="37" [(Value)]="checkValues[54]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-1">
                                            <hvl-checkbox #ch38 (ValueChange)="optionChanged($event ? '+38' : '-38' );" Title="38" [(Value)]="checkValues[55]"></hvl-checkbox>
                                        </div>
                                        <div class="col-sm-2">
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-2">
                                    </div>
                                    <div class="col-sm-2">
                                        <hvl-checkbox #ch6 (ValueChange)="optionChanged($event ? '+6' : '-6' );" Title="Sağ Alt Çene" [(Value)]="checkValues[56]" i18n-Title="@@M21126"></hvl-checkbox>
                                    </div>
                                    <div class="col-sm-2">
                                    </div>
                                    <div class="col-sm-2">
                                    </div>
                                    <div class="col-sm-2">
                                        <hvl-checkbox #ch7 (ValueChange)="optionChanged($event ? '+7' : '-7' );" Title="Sol Alt Çene" [(Value)]="checkValues[57]" i18n-Title="@@M22002"></hvl-checkbox>
                                    </div>
                                    <div class="col-sm-2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-5">
                                    </div>
                                    <div class="col-sm-2">
                                        <hvl-checkbox #ch3 (ValueChange)="optionChanged($event ? '+3' : '-3' );" Title="Alt Çene" [(Value)]="checkValues[58]" i18n-Title="@@M10740"></hvl-checkbox>
                                    </div>
                                    <div class="col-sm-5">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-10">
                            <dx-tag-box [items]="dentalProcedure"
                                        displayExpr="Name"
                                        placeholder="İşlemi Seç"
                                        [showSelectionControls]="false"
                                        [searchEnabled]="true"
                                        [(value)]="selectedDentalProcedure"
                                        applyValueMode="useButtons">
                            </dx-tag-box>
                        </div>
                        <div class="col-sm-2">
                            <dx-button icon="plus" type="success" text="Ekle" (onClick)="add_Click()"></dx-button>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="row">
                                <dx-data-grid [dataSource]="sut" [hoverStateEnabled]="true" style="height:200px ">
                                    <dxi-column dataField="sutKodu" caption="Sut Kodu" [width]="450" i18n-caption="@@M22393"></dxi-column>
                                    <dxi-column dataField="disNo" caption="Diş No" [width]="100" i18n-caption="@@M12915"></dxi-column>
                                </dx-data-grid>
                            </div>
                        </div>
                        <div class="col-sm-6">




                            <div class="row">
                                <div class="col-sm-3">
                                    <dx-button icon="save" type="success" text="Diş Taahhüt Kaydet" (onClick)="buttonDisTaahhutKaydet_Click()" i18n-text="@@M30522">
                                    </dx-button>
                                </div>

<div class="col-sm-3">
                                    <dx-button  type="success" text="Diş Taahhüt Raporu" (onClick)="printDisTaahhutReport()" i18n-text="@@M30523">
                                    </dx-button>
                                </div>


                                <div class="col-sm-6"  i18n="@@M22659">
                                    Takip No
                                    <dx-text-box [(value)]="takipNo" [disabled]="true"></dx-text-box>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4" i18n="@@M22531">
                                    Taahhüt Numarası
                                    <dx-text-box [(value)]="txtAlinanTaahhutNo" [disabled]="true"> </dx-text-box>
                                </div>
                            </div>
                            <br/>
                            <div class="row">
                                <div class="col-sm-4"  i18n="@@M22099">
                                    Sonuç Kodu
                                    <dx-text-box [(value)]="txtSonucKoduTaahhutKaydet" [disabled]="true"> </dx-text-box>
                                </div>
                                <div class="col-sm-8"  i18n="@@M22103">
                                    Sonuç Mesajı
                                    <dx-text-area [height]="90"
                                      [readOnly]="true"
                                      [(value)]="txtSonucMesajiTaahhutKaydet">
                                    </dx-text-area>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </dxi-item>
            <dxi-item *ngIf="taahhutNoSorguBool" class="tabpanel-item" title="Taahhüt Numarası ile Diş Taahhüt Sorgula">
                <div class="row">
                    <div class="col-sm-3"  i18n="@@M22531">
                        Taahhüt Numarası
                        <dx-text-box [(value)]="okunacakTaahhutNumarasi"> </dx-text-box>
                    </div>
                    <div class="col-sm-9">
                        <dx-button icon="find" type="default" text="Taahhut No ile Taahhut Oku" (onClick)="buttonTaahhutNoileTaahhutOku_Click()" i18n-text="@@M30517">
                        </dx-button>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-3"  i18n="@@M22075">
                        Sonuc Kodu
                        <dx-text-box [(value)]="txtSonucKoduTaahhutNoileSorgula" [disabled]="true"> </dx-text-box>
                    </div>
                    <div class="col-sm-9"  i18n="@@M22076">
                        Sonuc Mesajı
                        <dx-text-area [height]="90"
                            [readOnly]="true"
                            [(value)]="txtSonucMesajiTaahhutNoileSorgula">
                        </dx-text-area>
                    </div>
                </div>
                <br />
            </dxi-item>
            <dxi-item *ngIf="taahhutSilBool" class="tabpanel-item" title="Taahhüt Sil" i18n-Title="@@M30518">
                <div class="row">
                    <div class="col-sm-3"  i18n="@@M22531">
                        Taahhüt Numarası
                        <dx-text-box [(value)]="silinecekTaahhutNo"> </dx-text-box>
                    </div>
                    <div class="col-sm-9">
                        <dx-button icon="remove" type="danger" text="Taahhut Sil" (onClick)="buttonTaahhutSil_Click()" i18n-text="@@M30518">
                        </dx-button>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-3"  i18n="@@M22099">
                        Sonuç Kodu
                        <dx-text-box [(value)]="txtSonucKoduTaahhutSil" [disabled]="true"> </dx-text-box>
                    </div>
                    <div class="col-sm-9"  i18n="@@M22103">
                        Sonuç Mesajı
                        <dx-text-area [height]="90"
                            [readOnly]="true"
                            [(value)]="txtSonucMesajiTaahhutSil">
                        </dx-text-area>
                    </div>
                </div>
            </dxi-item>
            <dxi-item *ngIf="taahhutTcNoSorguBool" class="tabpanel-item" title="TC Kimlik No ile Taahhüt Sorgula" i18n-Title="@@M30519">
                <div class="row">
                    <div class="col-sm-5">
                        <dx-button icon="find" type="default" text="Taahhüt Sorgula" (onClick)="buttonTCKimlikNoIleTaahhutSorgula_Click()" i18n-text="@@M30520">
                        </dx-button>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-2" i18n="@@M22075">
                        Sonuç Kodu
                        <dx-text-box [(value)]="txtSonucKoduTCKimlikNoileSorgula" [disabled]="true"> </dx-text-box>
                    </div>
                    <div class="col-sm-4" i18n="@@M22103">
                        Sonuç Mesajı
                        <dx-text-area [height]="90"
                            [readOnly]="true"
                            [(value)]="txtSonucMesajTCKimlikNoileSorgula">
                        </dx-text-area>
                    </div>
                    <br />
                    <div class="col-sm-6">
                        <dx-data-grid [dataSource]="taahhutler"
                                      [hoverStateEnabled]="true"
                                      [selectedRowKeys]="[]">
                            <dxo-selection mode="single"></dxo-selection>
                            <dxi-column dataField="taahhutNo" caption="Taahhut No" [width]="200"></dxi-column>
                        </dx-data-grid>
                    </div>
                </div>
            </dxi-item>
        </dx-tab-panel>
    </div>
</div>
`
})
export class DisTaahhutFormComponent implements IModal {
    public patient: Patient;
    public DentalExaminationID: Guid;
    public patientName: string;
    public patientSurname: string;
    public patientUniqueNo: string;
    public patientBirthday: string;
    public patientSex: string;
    public actionSelectItem: string[];
    public postKode: string;
    public streetName: string;
    public outDoorNo: string;
    public mobilePhoneNo: string;
    public eMailAdress: string;
    public taahhutAlanAdi: string;
    public taahhutAlanSoyadi: string;
    public inDoorNo: string;
    public takipNo: string;
    public okunacakTaahhutNumarasi: string;
    public silinecekTaahhutNo: string;
    public txtAlinanTaahhutNo: string;
    public txtSonucKoduTaahhutKaydet: string;
    public txtSonucMesajiTaahhutKaydet: string;
    public txtSonucKoduTaahhutNoileSorgula: string;
    public txtSonucMesajiTaahhutNoileSorgula: string;
    public txtSonucKoduTaahhutSil: string;
    public txtSonucMesajiTaahhutSil: string;
    public txtSonucKoduTCKimlikNoileSorgula: string;
    public txtSonucMesajTCKimlikNoileSorgula: string;

    public taahhutKaydetBool: boolean = true;
    public taahhutSilBool: boolean = false;
    public taahhutNoSorguBool: boolean = false;
    public taahhutTcNoSorguBool: boolean = false;

    private checkList: Array<string> = new Array<string>();
    private checkValues: Array<boolean> = new Array<boolean>();
    public provisions: Array<ActiveMedulaProvision>;
    public dentalProcedure: any;
    public selectedDentalProcedure: Array<DentalProsthesisDefinition> = new Array<DentalProsthesisDefinition>();
    public cities: Array<City> = new Array<City>();
    public selectedCity: City;
    public towns: Array<TownDefinitions> = new Array<TownDefinitions>();
    public sut: Array<AddSut> = new Array<AddSut>();
    public taahhutler: Array<Taahhut> = new Array<Taahhut>();
    public city: any;
    public town: any;
    constructor(private modalStateService: ModalStateService, private http: NeHttpService, private reportService: AtlasReportService) {

        this.actionSelectItem = [
            i18n("M22519", "Taahhut Kaydet"),
            i18n("M22520", "Taahhut No Ile Sorgula"),
            'Taahhut Sil',
            i18n("M22938", "TC Kimlik No Ile Sorgula")
        ];
        this.checkValues = Array.apply(null, Array(58)).map(Boolean.prototype.valueOf, false);
    }
    @ViewChild('provisionGrid') provisionGrid: DxDataGridComponent;
    @ViewChild('il') ilSelectBoxIntance: DxSelectBoxComponent;
    @ViewChild("ilce") ilce: DxSelectBoxComponent;

    async ngOnInit() {
        this.patientName = this.patient.Name;
        this.patientSurname = this.patient.Surname;
        this.getForm();


    }

    public setInputParam(value: DisTaahuutInput) {
        this.patient = value.patient;
        this.DentalExaminationID = value.DentalExaminationID;
    }
    public setModalInfo(value: ModalInfo) {
    }

    public cancelClick(): void {
        //this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    public okClick(): void {
        //this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.selectedMaterialList);
    }

    onValueChanged($event) {
        if (i18n("M22519", "Taahhut Kaydet") === $event.value) {
            this.taahhutKaydetBool = true;
            this.taahhutSilBool = false;
            this.taahhutNoSorguBool = false;
            this.taahhutTcNoSorguBool = false;
        } else if (i18n("M22520", "Taahhut No Ile Sorgula") === $event.value) {
            this.taahhutKaydetBool = false;
            this.taahhutSilBool = false;
            this.taahhutNoSorguBool = true;
            this.taahhutTcNoSorguBool = false;
        } else if ('Taahhut Sil' === $event.value) {
            this.taahhutKaydetBool = false;
            this.taahhutSilBool = true;
            this.taahhutNoSorguBool = false;
            this.taahhutTcNoSorguBool = false;
        } else {
            this.taahhutKaydetBool = false;
            this.taahhutSilBool = false;
            this.taahhutNoSorguBool = false;
            this.taahhutTcNoSorguBool = true;
        }
    }

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

    getForm() {
        if (this.patient !== null) {
            let that = this;
            this.http.get<OnInitOutputDVO>('api/DisTaahhutForm/GetForm?PatientObjectId=' + this.patient.ObjectID.toString()).then((output: OnInitOutputDVO) => {
                that.provisions = output.provisions;
                that.patientUniqueNo = output.txtTCKNo;
                that.patientBirthday = output.txtBirthDate;
                that.patientSex = output.txtSex;
                this.dentalProcedure = new DataSource({
                    store: output.procedures,
                    searchOperation: 'contains',
                    searchExpr: 'Name'
                });
                this.dentalProcedure = output.procedures;
                this.selectedDentalProcedure = new Array<DentalProsthesisDefinition>();
                this.cities = output.cities;

                this.streetName = output.addressInfo.adressCaddeSokak;
                this.outDoorNo = output.addressInfo.adressDisKapiNo;
                this.eMailAdress = output.addressInfo.adressEposta;
                this.inDoorNo = output.addressInfo.adressIcKapiNo;
                this.postKode = output.addressInfo.adressPostaKodu;
                this.mobilePhoneNo = output.addressInfo.adressTelefon;
                this.city = output.addressInfo.adressIl.ObjectID;
                this.town = output.addressInfo.adressIlce.ObjectID;

            });
        }
    }

    selectCity(data) {
        if (data !== null) {
            let that = this;
            that.towns = new Array<TownDefinitions>();
            this.http.get<Array<TownDefinitions>>('api/DisTaahhutForm/GetTowns?CityObjectId=' + data.value.toString()).then((output: Array<TownDefinitions>) => {
                that.towns = output;
            });
        }
    }

    add_Click() {
        for (let dis of this.checkList) {
            for (let s of this.selectedDentalProcedure) {
                let newSut: AddSut = new AddSut();
                newSut.disNo = dis;
                newSut.sutKodu = s.Code + ' ' + s.Name;
                newSut.sutDef = s;
                this.sut.push(newSut);
            }
        }
        this.checkValues = Array.apply(null, Array(58)).map(Boolean.prototype.valueOf, false);
        this.selectedDentalProcedure = new Array<DentalProsthesisDefinition>();
        this.checkList = new Array<string>();
    }

    buttonDisTaahhutKaydet_Click() {
        let inputdvo: SaveTaahhutInputDVO = new SaveTaahhutInputDVO();
        inputdvo.activeMedulaProvision = this.provisionGrid.selectedRowKeys[0];
        inputdvo.suts = this.sut;
        inputdvo.adressIlPlaka = (<City>this.ilSelectBoxIntance.selectedItem).Code;
        inputdvo.adressIlce = (<TownDefinitions>this.ilce.selectedItem).Name;
        inputdvo.adressCaddeSokak = this.streetName;
        inputdvo.adressDisKapiNo = this.outDoorNo;
        inputdvo.adressEposta = this.eMailAdress;
        inputdvo.adressIcKapiNo = this.inDoorNo;
        inputdvo.adressPostaKodu = this.postKode;
        inputdvo.adressTelefon = this.mobilePhoneNo;
        inputdvo.hastaTCKimlikNo = this.patientUniqueNo;
        inputdvo.taahhutAlanAd = this.taahhutAlanAdi;
        inputdvo.taahhutAlanSoyad = this.taahhutAlanSoyadi;

        let fullApiUrl = 'api/DisTaahhutForm/SaveTaahhut';
        this.http.post(fullApiUrl, inputdvo)
            .then((res: SaveTaahhutOutputDVO) => {
                let result = <SaveTaahhutOutputDVO>res;
                if (result.işlemSonuc === true) {
                    this.txtAlinanTaahhutNo = result.txtAlınanTaahhutNo;
                    this.txtSonucKoduTaahhutKaydet = result.txtSonucKoduTaahhutKaydet;
                    this.txtSonucMesajiTaahhutKaydet = result.txtSonucMesajiTaahhutKaydet;
                    ServiceLocator.MessageService.showInfo(result.işlemSonucMesajı);

                    this.printDisTaahhutReport();


                } else {
                    this.txtSonucKoduTaahhutKaydet = result.txtSonucKoduTaahhutKaydet;
                    this.txtSonucMesajiTaahhutKaydet = result.txtSonucMesajiTaahhutKaydet;
                    ServiceLocator.MessageService.showError(result.işlemSonucMesajı);
                }
            })
            .catch(error => {
                console.log(error);
            });
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
        this.http.get<ReadTaahhutTCOutputDVO>('api/DisTaahhutForm/ReadTaahhutTC?TcNo=' + this.patientUniqueNo.toString()).then((output: ReadTaahhutTCOutputDVO) => {
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
    printDisTaahhutReport()
    {
        try {
            const objectIdParam = new GuidParam(this.DentalExaminationID);
            let reportParameters: any = { 'DentalExamination': objectIdParam };
            this.reportService.showReport('DISTAAHHUTREPORT', reportParameters);
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }
}