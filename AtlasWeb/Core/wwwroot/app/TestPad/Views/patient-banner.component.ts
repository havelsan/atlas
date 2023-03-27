import { Component, Input, OnChanges, SimpleChange, EventEmitter, Output } from '@angular/core';
import { PatientInfoDto } from '../Models/PatientInfoDto';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

const PatientUniqueRefNoName = 'PatientUniqueRefNo';

@Component({
    selector: 'app-patient-banner',
    templateUrl: './patient-banner.component.html',
})
export class PatientBannerComponent implements OnChanges {
    private readonly ActionUrl = 'api/test';

    @Input() PatientUniqueRefNo: number;

    @Output() PatientFound: EventEmitter<PatientInfoDto>  = new EventEmitter<PatientInfoDto>();

    public patientInfo: PatientInfoDto;
    public patientImage: string;
    public gender: string;

    constructor(private httpService: NeHttpService, private messageService: MessageService) {
        this.patientInfo = new PatientInfoDto();
    }

    public setPatientImage(): string {
        if (!this.patientImage) {
            if (this.patientInfo) {
                if (this.patientInfo.Gender === 'ERKEK') {
                    this.patientImage = 'assets/male-patient-avatar-2.png';
                } else if (this.patientInfo.Gender === 'KADIN') {
                    this.patientImage = 'assets/female-patient-avatar-2.png';
                }
            }
        }

        return this.patientImage;
    }

    ngOnChanges(changes: { [propName: string]: SimpleChange }) {
        if (changes.hasOwnProperty(PatientUniqueRefNoName)) {
            const currentValue = changes[PatientUniqueRefNoName].currentValue;
            const previousValue = changes[PatientUniqueRefNoName].previousValue;
            if (currentValue) {
                if (currentValue !== previousValue) {
                    this.loadPatientInfo(currentValue);
                }
            }
        }
    }

    private loadPatientInfo(uniqueRefNo: number): void {
        const apiUrl = `${this.ActionUrl}/getpatientinfo?uniqueRefNo=${uniqueRefNo}`;
        const that = this;
        this.httpService.get<PatientInfoDto>(apiUrl, PatientInfoDto).then(e => {
            that.patientInfo = e;
            that.setPatientImage();
            that.PatientFound.emit(that.patientInfo);
        }).catch(error => {
            that.messageService.showError(error);
        });
    }

    public searchPatient(e: any): void {
        if (e && e.value) {
            const uniqueRefNo = parseInt(e.value);
            this.loadPatientInfo(uniqueRefNo);
        }
    }

}