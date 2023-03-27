import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { LogisticWorkList } from './Views/WorkListView';
import { SupplyRequestManagerView } from './Views/SupplyRequestManagerView';
import { LogisticDashboardView } from './Views/LogisticDashboardView';
import { LogisticReportView } from './Views/LogisticReportView';
import { LogisticAddAndUpdateView } from './Views/LogisticAddAndUpdateView';
import { MkysIntegrationView } from './Views/MkysIntegrationView';
import { MainView } from './Views/MainView';
import { NewFormContainerComponent } from './Views/NewFormContainerComponent';
import { ApproveFormContainerComponent } from './Views/ApproveFormContainerComponent';
import { CompletedFormContainerComponent } from './Views/CompletedFormContainerComponent';
import { DevExtremeModule } from 'devextreme-angular';
import { SampleComponent } from './Views/sample.component';
import { DrugInteractionComponent } from './Views/DrugInteractionComponent';
import { DrugOrderDetailComponent } from './Views/DrugOrderDetailComponent';
import { DrugInfoComponent } from './Views/DrugInfoComponent';
import { DashboardActionComponent } from './Views/DashboardActionComponent';
import { MaterialSelectComponent } from './Views/MaterialSelectComponent';
import { OutTransactionModalComponent } from './Views/OutTransactionModalComponent';
import { MkysLogComponent } from './Views/MkysLogComponent';
import { DrugEquivalentComponent } from './Views/DrugEquivalentComponent';
import { DrugEquivalentComponentByStockAction } from './Views/DrugEquivalentComponentByStockAction';
import { DrugTemplateSelectComponent } from './Views/DrugTemplateSelect.component';
import { AtlasReportModule } from '../Report/AtlasReportModule';
import { AtlasDynamicFormModule } from '../DynamicForm/AtlasDynamicFormModule';
import { LogisticUserMessageComponent } from './Views/LogisticUserMessageComponent';
import { MaterialExpirationDateInfoModule } from "Modules/Saglik_Lojistik/Stok_Modulleri/MaterialExpirationDateInfo/MaterialExpirationDateInfoModule";
import { MovableTransactionInputVoucherModule } from "Modules/Saglik_Lojistik/Tasinir_Islem_Fisi_Rapor_Modulleri/Giris_Rapor_Modulu/MovableTransactionInputVoucherModule";
import { MovableTransactionOutVoucherModule } from "Modules/Saglik_Lojistik/Tasinir_Islem_Fisi_Rapor_Modulleri/Cikis_Rapor_Modulu/MovableTransactionOutVoucherModule";
import { EquivalentMaterialReportForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Muadil_ILac_Raporu/EquivalentMaterialReportForm";
import { SKTGoreMalzemeRaporuModule } from "Modules/Saglik_Lojistik/Stok_Modulleri/SKT_Gore_Malzeme_Raporu/SKTGoreMalzemeRaporuModule";
import { IadeRaporlariModule } from "Modules/Saglik_Lojistik/Stok_Modulleri/Iade_Raporlari_Modulu/IadeRaporlariModule";
import { MuadilMalzemeTuketimRaporuModule } from "Modules/Saglik_Lojistik/Stok_Modulleri/Muadil_Malzeme_Tuketim_Raporu_Modulu/MuadilMalzemeTuketimRaporuModule";
import { IlacKullanimRaporlariModule } from "Modules/Saglik_Lojistik/Stok_Modulleri/Ilac_Kullanim_Raporlari_Modulu/IlacKullanimRaporlariModule";
import { DrugOrderScheduleComponent } from "./Views/DrugOrderScheduleComponent";
import { DrugOrderUpgradeComponent } from "./Views/DrugOrderUpgradeComponent";
import { DrugReturnAndDeliveryComponent } from "./Views/DrugReturnAndDeliveryComponent";
import { ITSComponent } from "./Views/ITSComponent";
import { MaterialDefinitionModule } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Malzeme_Tanimlari_Modulu/MaterialDefinitionModule';
import { DrugOrderInfoComponent } from './Views/DrugOrderInfoComponent';
import { MaterialMultiSelectModule } from 'Modules/Saglik_Lojistik/Stok_Modulleri/MaterialMultiSelect/MaterialMultiSelectModule';
import { ReturnFormModule } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Ilac_Iade_Raporu/ReturnFormModule';
import { UnusedMaterialFormModule } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Kullanilmayan_Malzeme_Raporu/UnusedMaterialFormModule';
import { CoreModule } from 'app/template/core/core.module';
import { DrugOutForRecipeTypeForm } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Recete_Turune_Gore_Ilac_Cikisi/DrugOutForRecipeTypeForm';
import { DrugPaymentFirm } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Ilac_Alinan_Firmalar_Modulu/DrugPaymentFirm';
import { SupplierAndProducerDefComponent } from './Views/SupplierAndProducerDefComponent';
import { MainViewNewComponent } from './Views/MainViewNewComponent';
import { MainViewOldComponent } from './Views/MainViewOldComponent';
import { NotSentOperationComponent } from './Views/MKYSComponents/NotSentOperationComponent';
import { CompareOperationComponent } from './Views/MKYSComponents/CompareOperationComponent';
import { IncomingDocumentComponent } from './Views/MKYSComponents/IncomingDocumentComponent';
import { EndOfYearTransferComponent } from './Views/MKYSComponents/EndOfYearTransferComponent';
import { CreateEntryTicketComponent } from './Views/GirisIslemleriComponents/CreateEntryTicketComponent';
import { EntryTicketListComponent } from './Views/GirisIslemleriComponents/EntryTicketListComponent';
import { MKYSOperationsComponent } from './Views/MKYSComponents/MKYSOperationsComponent';
import { OtherOperationsComponent } from './Views/GirisIslemleriComponents/OtherOperationsComponent';
import { MaterialSelectorComponent } from './Views/NewMaterialSelectComponent';
import { StockActionDetailOutForm } from './Views/StockActionDetailOutForm';
import { DocumentRecordLogComponent } from './Views/DocumentRecordLogComponent';
import { DrugAtlasInteractionComponent } from './Views/DrugAtlasInteractionComponent';
import { MaterialTreeDefitionComponent } from './Views/MaterialTreeDefinitionComponent';
import { DrugDefinitionModule } from 'Modules/Saglik_Lojistik/Lojistik_Tanımlar_Modulleri/Ilac_Tanimlari/DrugDefinitionModule';
import { ConsumableMaterialDefinitionModule } from 'Modules/Saglik_Lojistik/Lojistik_Tanımlar_Modulleri/Sarf_Malzeme_Tanimlari/ConsumableMaterialDefinitionModule';
import { DepletionMaterialDefinitionModule } from 'Modules/Saglik_Lojistik/Lojistik_Tanımlar_Modulleri/Tuketim_Malzeme_Tanimlari/DepletionMaterialDefinitionModule';
import { TransactionChartComponent } from './Views/TransactionChartComponent';
import { LogisticNewReportComponent } from './Views/LogisticNewReportComponent';
import { FavoriIlacRaporuModule } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Favori_Ilaclar_Raporu_Modulu/FavoriIlacRaporuModule';
import { PatientUsedMaterialComponent } from './Views/PatientUsedMaterialComponent';
import { DrugAtcReport } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Ilac_ATC_Raporu/DrugAtcReport';
import { DrugDistributionReport } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Ilac_Dagilim_Raporu/DrugDistributionReport';
import { ReceivedDrugReport } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Karsilanan_Ilaclar_Raporu/ReceivedDrugReport';
import { EczanedeBulunmayanIlaclarRaporuModule } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Eczanede_Bulunmayan_Ilaclar_Raporu_Modulu/EczanedeBulunmayanIlaclarRaporuModule';
import { LogisticDocumentUploadForm } from './Views/LogiscticDocumentComponents/LogisticDocumentUploadForm';
import { DrugGenericReport } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Ilac_Jenerik_Raporu/DrugGenericReport';
import { InOutRemainingComponent } from './Views/InOutRemainingComponent';
import { DailyConfirmDrugReport } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Gunluk_Dogrulanan_Ilaclar_Raporu/DailyConfirmDrugReport';
import { StoreInheldReport } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Depo_Mevcut_Raporu/StoreInheldReport';
import { StoreInTotalReport } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Toplam_Giris_Raporu/StoreInTotalReport';
import { StoreOutTotalReport } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Toplam_Cikis_Raporu/StoreOutTotalReport';
import { CommisionDefinitionComponent } from './Views/LogisticDefinitionComponents/CommisionDefinitionComponent';
import { CommisionSelectComponent } from './Views/CommisionSelectComponent';
import { ConsumedMaterialReport } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Tüketim_Yapilmis_Malzeme_Raporu/ConsumedMaterialReport';
import { DocumentRecordLogCheckComponent } from './Views/DocumentRecordLogCheckComponent';
import { TransferableDrugOrderComponent } from './Views/TransferableDrugOrderComponent';
import { ATCDefinitionComponent } from './Views/LogisticDefinitionComponents/ATCDefinitionComponent';
import { RouteOfAdminDefComponent } from './Views/LogisticDefinitionComponents/RouteOfAdminDefComponent';
import { HospitalTimeScheduleModule } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/HospitalTimeScheduleModule';
import { DistributionDefinitionComponent } from './Views/LogisticDefinitionComponents/DistributionDefinitionComponent';
import { OrderTemplateDefComponent } from './Views/LogisticDefinitionComponents/OrderTemplateDefComponent';
import { OrderTemplateComponent } from './Views/OrderTemplateComponent';
import { ActiveIngredientDefComponent } from './Views/LogisticDefinitionComponents/ActiveIngredientDefComponent';
import { LogisticPatientDocumentUploadForm } from './Views/LogiscticDocumentComponents/LogisticPatientDocumentUploadForm';
import { OrderTemplateAddNewComponent } from './Views/OrderTemplateAddNewComponent';
import { TreatmentMaterialTemplateAddNewComponent } from './Views/TreatmentMaterialTemplateAddNewComponent';
import { TreatmentMaterialTemplateComponent } from './Views/TreatmentMaterialTemplateComponent';
import { SubStoreDefinitionComponent } from './Views/LogisticDefinitionComponents/SubStoreDefinitionComponent';
import { MainStoreDefinitionComponent } from './Views/LogisticDefinitionComponents/MainStoreDefinitionComponent';
import { OrderRestDayDefinitionComponent } from './Views/LogisticDefinitionComponents/OrderRestDayDefinitionComponent';
import { CovidDrugReportForm } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Covid_Raporu/CovidDrugReportForm';
import { EmergencyOrderComponent } from './Views/EmergencyOrderComponent';


const routes: Routes = [
	{
		path: '',
		component: MainView,
	}
];

@NgModule({
	declarations: [EquivalentMaterialReportForm, LogisticWorkList, LogisticDashboardView, MkysIntegrationView, SupplyRequestManagerView, LogisticReportView, LogisticAddAndUpdateView, MainView,
		NewFormContainerComponent, ApproveFormContainerComponent, CompletedFormContainerComponent, SampleComponent, DrugInteractionComponent, DrugOrderDetailComponent, DrugInfoComponent,
		DashboardActionComponent, MaterialSelectComponent, OutTransactionModalComponent, DrugEquivalentComponent, DrugEquivalentComponentByStockAction, DrugOrderScheduleComponent,
		DrugTemplateSelectComponent, MkysLogComponent, LogisticUserMessageComponent, DrugOrderInfoComponent, DrugOutForRecipeTypeForm, DrugOrderUpgradeComponent, DrugReturnAndDeliveryComponent,
		MainViewNewComponent, MainViewOldComponent, NotSentOperationComponent, CompareOperationComponent, IncomingDocumentComponent, EndOfYearTransferComponent, CreateEntryTicketComponent,
		ITSComponent, EntryTicketListComponent, SupplierAndProducerDefComponent, MKYSOperationsComponent, OtherOperationsComponent, MaterialSelectorComponent, StockActionDetailOutForm, DocumentRecordLogComponent, DrugAtlasInteractionComponent,
		MaterialTreeDefitionComponent, TransactionChartComponent, LogisticNewReportComponent, DrugPaymentFirm, PatientUsedMaterialComponent, DrugAtcReport, DrugDistributionReport, ReceivedDrugReport,
		LogisticDocumentUploadForm, DrugGenericReport, InOutRemainingComponent, DailyConfirmDrugReport, StoreInheldReport, StoreInTotalReport, StoreOutTotalReport, CommisionDefinitionComponent, CommisionSelectComponent, ConsumedMaterialReport,
		DocumentRecordLogCheckComponent, TransferableDrugOrderComponent, ATCDefinitionComponent, RouteOfAdminDefComponent,DistributionDefinitionComponent,OrderTemplateDefComponent,OrderTemplateComponent,ActiveIngredientDefComponent,
		LogisticPatientDocumentUploadForm, OrderTemplateAddNewComponent, TreatmentMaterialTemplateAddNewComponent, TreatmentMaterialTemplateComponent,SubStoreDefinitionComponent,
		MainStoreDefinitionComponent,OrderRestDayDefinitionComponent, CovidDrugReportForm,EmergencyOrderComponent],

	imports: [CommonModule, CoreModule, MaterialMultiSelectModule, FormsModule, FwModule, DevExtremeModule, AtlasReportModule, DrugDefinitionModule, ConsumableMaterialDefinitionModule,
		DepletionMaterialDefinitionModule, MaterialDefinitionModule, AtlasDynamicFormModule, MaterialExpirationDateInfoModule, MovableTransactionInputVoucherModule, MovableTransactionOutVoucherModule, RouterModule.forChild(routes), SKTGoreMalzemeRaporuModule,
		IadeRaporlariModule, IlacKullanimRaporlariModule, MuadilMalzemeTuketimRaporuModule, ReturnFormModule, UnusedMaterialFormModule, FavoriIlacRaporuModule, EczanedeBulunmayanIlaclarRaporuModule, HospitalTimeScheduleModule],

	exports: [EquivalentMaterialReportForm, LogisticWorkList, LogisticDashboardView, MkysIntegrationView, SupplyRequestManagerView, LogisticReportView, LogisticAddAndUpdateView, MainView,
		NewFormContainerComponent, LogisticDocumentUploadForm, LogisticPatientDocumentUploadForm,
		ApproveFormContainerComponent, CompletedFormContainerComponent, SampleComponent, DrugInteractionComponent, DrugOrderDetailComponent, DrugInfoComponent, DashboardActionComponent,
		MaterialSelectComponent, OutTransactionModalComponent, DrugOrderInfoComponent, ReturnFormModule, UnusedMaterialFormModule, DrugOutForRecipeTypeForm, ITSComponent, DrugAtlasInteractionComponent,
		TransactionChartComponent, LogisticNewReportComponent, DrugPaymentFirm, DrugAtcReport, DrugDistributionReport, ReceivedDrugReport, DrugGenericReport, DailyConfirmDrugReport,
		StoreInheldReport, StoreInTotalReport, StoreOutTotalReport, CommisionSelectComponent, ConsumedMaterialReport, ATCDefinitionComponent, RouteOfAdminDefComponent,DistributionDefinitionComponent,
		OrderTemplateDefComponent,OrderTemplateComponent,OrderTemplateAddNewComponent, TreatmentMaterialTemplateAddNewComponent, TreatmentMaterialTemplateComponent,SubStoreDefinitionComponent,
		MainStoreDefinitionComponent,OrderRestDayDefinitionComponent,MaterialSelectorComponent, CovidDrugReportForm],

	entryComponents: [DrugInteractionComponent, DrugOrderDetailComponent, DrugInfoComponent, DashboardActionComponent, MaterialSelectComponent, OutTransactionModalComponent, DrugEquivalentComponent,
		DrugEquivalentComponentByStockAction, DrugTemplateSelectComponent, MkysLogComponent, LogisticUserMessageComponent, DrugOrderScheduleComponent, DrugOrderInfoComponent,
		DrugOrderUpgradeComponent, DrugReturnAndDeliveryComponent, StockActionDetailOutForm, DocumentRecordLogComponent, DrugAtlasInteractionComponent, TransactionChartComponent,
		PatientUsedMaterialComponent, LogisticDocumentUploadForm, LogisticPatientDocumentUploadForm, InOutRemainingComponent, CommisionSelectComponent, DocumentRecordLogCheckComponent, TransferableDrugOrderComponent,OrderTemplateComponent,ActiveIngredientDefComponent,
		OrderTemplateAddNewComponent, TreatmentMaterialTemplateAddNewComponent, TreatmentMaterialTemplateComponent, MaterialSelectorComponent,EmergencyOrderComponent]
})
export class LogisticFormsModule {
	static dynamicComponentsMap = {
		EquivalentMaterialReportForm,
		LogisticWorkList, LogisticDashboardView,
		MkysIntegrationView, SupplyRequestManagerView,
		LogisticReportView, LogisticAddAndUpdateView,
		MainView, NewFormContainerComponent,
		ApproveFormContainerComponent, CompletedFormContainerComponent,
		SampleComponent, DrugInteractionComponent,
		DrugOrderDetailComponent, DrugInfoComponent,
		DashboardActionComponent, MaterialSelectComponent,   
		OutTransactionModalComponent, DrugOrderInfoComponent,
		ReturnFormModule, UnusedMaterialFormModule,
		DrugOutForRecipeTypeForm, DrugEquivalentComponent,
		DrugEquivalentComponentByStockAction, DrugOrderScheduleComponent,
		DrugOrderUpgradeComponent, DrugReturnAndDeliveryComponent,
		LogisticUserMessageComponent, StockActionDetailOutForm,
		MkysLogComponent, DocumentRecordLogComponent,
		DrugAtlasInteractionComponent, TransactionChartComponent,
		LogisticNewReportComponent, DrugPaymentFirm,
		PatientUsedMaterialComponent, DrugAtcReport,
		DrugDistributionReport, ReceivedDrugReport,
		LogisticDocumentUploadForm,
		DrugGenericReport, InOutRemainingComponent,
		DailyConfirmDrugReport,
		StoreInheldReport, StoreInTotalReport,
		StoreOutTotalReport, CommisionDefinitionComponent,
		CommisionSelectComponent,
		ConsumedMaterialReport,
		DocumentRecordLogCheckComponent,
		TransferableDrugOrderComponent,
		ATCDefinitionComponent,
		RouteOfAdminDefComponent,
		DistributionDefinitionComponent,
		OrderTemplateDefComponent,OrderTemplateComponent,ActiveIngredientDefComponent, LogisticPatientDocumentUploadForm,
		OrderTemplateAddNewComponent, TreatmentMaterialTemplateAddNewComponent, TreatmentMaterialTemplateComponent,SubStoreDefinitionComponent,
		MainStoreDefinitionComponent,OrderRestDayDefinitionComponent,MaterialSelectorComponent, CovidDrugReportForm,EmergencyOrderComponent
	};

}
