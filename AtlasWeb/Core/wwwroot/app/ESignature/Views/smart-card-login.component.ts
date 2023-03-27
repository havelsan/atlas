import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ESignatureService } from '../Services/esignature.service';
import { SmartCardLoginModel } from '../Models/login.model';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DxListComponent } from 'devextreme-angular';

@Component({
    selector: 'smart-card-login-component',
    template: `
<dx-box direction="col" width="100%" height="100%">
    <dxi-item [ratio]="80">
        <dx-box direction="row" width="100%">
            <dxi-item [ratio]="50">
                <dx-form #dxForm [(formData)]="formData" [showColonAfterLabel]="true" [labelLocation]="'top'" [colCount]="1">
                    <dxi-item [label]="{ text: 'Kart Okuyucu' }" dataField="TerminalName" editorType="dxSelectBox" [editorOptions]="{ items: terminalList, value: '' }">
                        <dxi-validation-rule type="required" message="Lütfen kart okuyucu seçiniz"></dxi-validation-rule>
                    </dxi-item>
                    <dxi-item [label]="{ text: 'PIN' }" dataField="PIN" editorType="dxTextBox" [editorOptions]="{ mode: 'password' }">
                        <dxi-validation-rule type="required" message="PIN girişi zorunludur"></dxi-validation-rule>
                    </dxi-item>
                </dx-form>
                <div>
                    <h4>Bilgi</h4>
                    <p>Kart okuyucu seçimi yaptıktan sonra "Giriş" düğmesini kullanarak kart okuyucu girişi yapınız. Başarılı
                        giriş işleminden sonra imza sertifikaları listelenecektir. Listeden elektronik imza için kullanacağınız
                        sertifikanızı seçebilirsiniz.
                    </p>
                </div>
            </dxi-item>
            <dxi-item [ratio]="50">
                <div style="margin-left: 5px">
                    <label>Sertifika Listesi</label>
                    <dx-list #list height="100%" [items]="certificates" [selectionMode]="'single'" [showSelectionControls]="false" noDataText="Lütfen öncelikle giriş yapın">
                        <div *dxTemplate="let item of 'item'">
                            <div>
                                <div><label>Issuer</label><span>{{item.IssuerCommonName}}</span></div>
                                <div><label>Subject</label><span>{{item.SubjectCommonName}}</span></div>
                                <div><label>Validity</label><span>{{item.ValidFrom}}</span></div>
                            </div>
                        </div>
                    </dx-list>
                </div>
            </dxi-item>
        </dx-box>
    </dxi-item>
    <dxi-item [ratio]="10">
        <div>
            <dx-button style="margin: 5px 0;" (onClick)="doLogin()" text="Giriş"></dx-button>
            <dx-button style="margin: 5px 0;" (onClick)="selectCertificate(list)" text="Sertifika Seç"></dx-button>
        </div>
    </dxi-item>
    <dxi-item [ratio]="10">
        <div><span style="color: red">{{errorMessage}}</span></div>
    </dxi-item>
</dx-box>`,
    styles: [`
/deep/ p, div {
    line-height: normal;
}
/deep/ .dx-list {
    line-height: normal;
}
/deep/ .dx-list label {
    margin-bottom: 0px;
}
`],
    providers: [ESignatureService]
})
export class SmartCardLoginComponent implements OnInit, IModal {
    public formData: SmartCardLoginModel;
    public terminalList: Array<string> = new Array<string>();
    private modalInfo: ModalInfo;
    public certificates: any = [];
    public errorMessage: string;

    @Output() LoginCompleted: EventEmitter<SmartCardLoginModel> = new EventEmitter<SmartCardLoginModel>();
    @Output() LoginFailed: EventEmitter<string> = new EventEmitter<string>();
    @Output() CertificateSelected: EventEmitter<any> = new EventEmitter<any>();
    @Output() CertificateSelectFailed: EventEmitter<any> = new EventEmitter<any>();

    constructor(private signService: ESignatureService, private modalStateService: ModalStateService) {
        this.formData = new SmartCardLoginModel();
        this.formData.TerminalName = '';
        this.formData.PIN = '';
    }

    private extractErrorMessage(err: any): string {
        if ((typeof err) === 'string') {
            return err as string;
        }

        if (typeof err.json === 'function') {
            let json = err.json();
            return json.message;
        }

        return err as string;
    }

    public setInputParam(value: Object) {
    }

    public setModalInfo(value: ModalInfo) {
        this.modalInfo = value;
    }

    public ngOnInit(): void {
        let that = this;
        this.signService.getTerminals().then(t => {
            that.terminalList = t;
        }).catch(err => {
            that.errorMessage = err;
        });
    }

    public doLogin(): void {
        let that = this;
        this.signService.login(this.formData.TerminalName, this.formData.PIN).then(loginResult => {
            that.LoginCompleted.emit(this.formData);
            this.signService.getCertificates().then(certResult => {
                that.certificates = certResult;
            }).catch(err => {
                that.errorMessage = that.extractErrorMessage(err);
            });
        }).catch(err => {
            that.LoginFailed.emit(err);
            that.errorMessage = that.extractErrorMessage(err);
        });
    }

    public selectCertificate(list: DxListComponent): void {
        let that = this;
        if (list.selectedItems != null && list.selectedItems.length > 0) {
            let selectedCertificate = list.selectedItems[0];
            this.signService.selectCertificateWithSerialNumber(selectedCertificate.SerialNumber).then(r => {
                that.CertificateSelected.emit(selectedCertificate);
                that.modalStateService.callActionExecuted(DialogResult.OK, this.modalInfo.ContainerItemID, null);
            }).catch(err => {
                that.CertificateSelectFailed.emit(err);
                that.errorMessage = that.extractErrorMessage(err);
            });
        }
    }

}
