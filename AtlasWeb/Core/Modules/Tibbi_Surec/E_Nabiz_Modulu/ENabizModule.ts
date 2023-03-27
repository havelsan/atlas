//$2AE89E62
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { EvdeSaglikIzlemForm } from './EvdeSaglikIzlemForm';
import { EvdeSaglikIlkIzlemForm } from './EvdeSaglikIlkIzlemForm';
import { ENabizMainForm } from './ENabizMainForm';
import { KronikHastaliklarForm } from './KronikHastaliklarForm';
import { BulasiciHastaliklarNewForm } from './BulasiciHastaliklarNewForm';
import { BulasiciHastaliklarForm } from './BulasiciHastaliklarForm';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { SendToENabizTestForm } from './SendToENabizTestForm';
import { DiyabetForm } from './DiyabetForm';
import { ObeziteIzlemForm } from './ObeziteIzlemForm';
import { OlayAfetBilgisiForm } from './OlayAfetBilgisiForm';
import { DataSetsForm } from './DataSetsForm';
import { VeremVeriSetiForm } from './VeremVeriSetiForm';
import { KuduzProfilaksiIzlemForm } from './KuduzProfilaksiIzlemForm';
import { TutunKullanimiVeriSetiForm } from './TutunKullanimiVeriSetiForm';
import { KuduzRiskliTemasVeriSetiForm } from './KuduzRiskliTemasVeriSetiForm';
import { MaddeBagimliligiVeriSetiForm } from './MaddeBagimliligiVeriSetiForm';
import { IntiharIzlemForm } from './IntiharIzlemForm';
import { IntiharGirisimiKrizTespitVeriSetiForm } from './IntiharGirisimiKrizTespitVeriSetiForm';
import { KadinaYonelikSiddetVeriSetiForm } from './KadinaYonelikSiddetVeriSetiForm';
import { InfluenzaResultForm } from './InfluenzaResultForm';

const enabizRoutes: Routes = [
    {
        path: 'test',
        component: SendToENabizTestForm,
    },

];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule,
        RouterModule.forChild(enabizRoutes)],
    declarations: [
        EvdeSaglikIzlemForm, EvdeSaglikIlkIzlemForm, ENabizMainForm, KronikHastaliklarForm, BulasiciHastaliklarNewForm, BulasiciHastaliklarForm,
		SendToENabizTestForm, DiyabetForm, ObeziteIzlemForm, OlayAfetBilgisiForm, DataSetsForm, VeremVeriSetiForm, KuduzProfilaksiIzlemForm, 
		TutunKullanimiVeriSetiForm, KuduzRiskliTemasVeriSetiForm,
        MaddeBagimliligiVeriSetiForm, IntiharIzlemForm, IntiharGirisimiKrizTespitVeriSetiForm, KadinaYonelikSiddetVeriSetiForm, InfluenzaResultForm
    ],
    exports: [
        EvdeSaglikIzlemForm, EvdeSaglikIlkIzlemForm, ENabizMainForm, KronikHastaliklarForm, BulasiciHastaliklarNewForm, BulasiciHastaliklarForm,
		SendToENabizTestForm, DiyabetForm, ObeziteIzlemForm, OlayAfetBilgisiForm, DataSetsForm, VeremVeriSetiForm, KuduzProfilaksiIzlemForm,
		 TutunKullanimiVeriSetiForm, KuduzRiskliTemasVeriSetiForm,
        MaddeBagimliligiVeriSetiForm, IntiharIzlemForm, IntiharGirisimiKrizTespitVeriSetiForm, KadinaYonelikSiddetVeriSetiForm, InfluenzaResultForm
    ],
    entryComponents: [
        EvdeSaglikIzlemForm, EvdeSaglikIlkIzlemForm, ENabizMainForm, KronikHastaliklarForm, BulasiciHastaliklarNewForm, BulasiciHastaliklarForm,
		SendToENabizTestForm, DiyabetForm, ObeziteIzlemForm, OlayAfetBilgisiForm, DataSetsForm, VeremVeriSetiForm, KuduzProfilaksiIzlemForm, 
		TutunKullanimiVeriSetiForm, KuduzRiskliTemasVeriSetiForm,
        MaddeBagimliligiVeriSetiForm, IntiharIzlemForm, IntiharGirisimiKrizTespitVeriSetiForm, KadinaYonelikSiddetVeriSetiForm, InfluenzaResultForm
    ]
})
export class ENabizModule {
	static dynamicComponentsMap = {
		EvdeSaglikIzlemForm, 
		EvdeSaglikIlkIzlemForm, 
		ENabizMainForm, 
		KronikHastaliklarForm, 
		BulasiciHastaliklarNewForm, 
		BulasiciHastaliklarForm, 
		SendToENabizTestForm, 
		DiyabetForm, 
		ObeziteIzlemForm, 
		OlayAfetBilgisiForm, 
		DataSetsForm, 
		VeremVeriSetiForm, 
		KuduzProfilaksiIzlemForm, 
		TutunKullanimiVeriSetiForm, 
		KuduzRiskliTemasVeriSetiForm, 
		MaddeBagimliligiVeriSetiForm, 
		IntiharIzlemForm, 
		IntiharGirisimiKrizTespitVeriSetiForm, 
		KadinaYonelikSiddetVeriSetiForm, 
		InfluenzaResultForm
	};
 }

