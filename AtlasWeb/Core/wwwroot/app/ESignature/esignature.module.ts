import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { DevExtremeModule } from 'devextreme-angular';
import { SmartCardLoginComponent } from './Views/smart-card-login.component';
import { CertificateListComponent } from './Views/certificate-list.component';
import { IESignatureService } from './Services/IESignatureService';
import { ESignatureService } from './Services/esignature.service';

@NgModule({
    imports: [CommonModule, HttpModule, FormsModule, DevExtremeModule],
    declarations: [SmartCardLoginComponent, CertificateListComponent],
    exports: [SmartCardLoginComponent, CertificateListComponent],
    entryComponents: [SmartCardLoginComponent, CertificateListComponent],
    providers: [{ provide: IESignatureService, useClass: ESignatureService }]
})
export class ESignatureModule {
	static dynamicComponentsMap = {
		SmartCardLoginComponent, 
		CertificateListComponent
	};

}