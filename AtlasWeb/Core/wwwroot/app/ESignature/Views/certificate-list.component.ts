import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ESignatureService } from '../Services/esignature.service';
import { DxListComponent } from 'devextreme-angular';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';

@Component({
    selector: 'certificate-list-component',
    template: `<div class="list-container">
    <dx-list #list height="100%" [items]="certificates" [selectionMode]="'single'" [showSelectionControls]="false" >
        <div *dxTemplate="let item of 'item'">
            <div>
                <label>Issuer</label><div>{{item.IssuerCommonName}}</div>
                <label>Subject</label><div>{{item.SubjectCommonName}}</div>
                <label>Validity</label><div>{{item.ValidFrom}}</div>
            </div>
        </div>
    </dx-list>
    <dx-button style="margin: 5px 0;" (onClick)="selectCertificate(list)" text="Sertifika Seç"></dx-button>
</div>`,
    providers: [ESignatureService]
})
export class CertificateListComponent implements OnInit, IModal {
    public certificates: any = [];
    private modalInfo: ModalInfo;

    @Output() CertificateSelected: EventEmitter<any> = new EventEmitter<any>();

    constructor(private signService: ESignatureService, private modalStateService: ModalStateService) {
    }

    public setInputParam(value: Object) {
    }

    public setModalInfo(value: ModalInfo) {
        this.modalInfo = value;
    }

    public ngOnInit() {
        let that = this;
        this.signService.getCertificates().then(r => {
            that.certificates = r;
        }).catch(err => {
            console.log(err);
        });
    }

    public selectCertificate(list: DxListComponent) {
        let that = this;
        if (list.selectedItems != null && list.selectedItems.length > 0) {
            let selectedCertificate = list.selectedItems[0];
            this.signService.selectCertificateWithSerialNumber(selectedCertificate.SerialNumber).then(r => {
                that.CertificateSelected.emit(selectedCertificate);
                that.modalStateService.callActionExecuted(DialogResult.OK, this.modalInfo.ContainerItemID, null);
            }).catch(err => {
                console.log(err);
            });
        }
    }

}