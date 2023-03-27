//$E19124E2
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { BloodProductPreparationForm } from './BloodProductPreparationForm';
import { BloodProductRequestForm } from './BloodProductRequestForm';

const routes: Routes = [
    {
        path: '',
        component: BloodProductRequestForm, //BloodBankExternalBloodProductRequestForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
//BloodBankExternalBloodProductRequestForm,BloodBankExternalBloodProductEntryForm,BloodGroupTestRequest,
//BloodGroupTestApprove,BloodGroupTestProcedure,BloodGroupTestCompleted,BloodBankProductInfoForm,
//BloodBankBloodProducts_CokluOzelDurumForm,BloodBankSubGroupApproveForm,BloodBankSubGroupRejectForm,
//BloodBankSubGroupCompletedForm,BloodBankSubGroupProcedureForm,BloodBankSubGroupRequestForm,
//    BloodBankSubGroupRequestOrganizeForm,
    //BloodProductDeliveryForm, BloodProductRequestInfoForm,
    //BloodProductRejectForm, CrossMatch,
    BloodProductPreparationForm,
    BloodProductRequestForm,
    //BloodProductRequestSupplyingForm, BloodProductReadyForm,
//    BloodBankDonorBloodCropTakeRegistrationForm,
//BloodBankDonorBloodCropTakeSendStockForm,BloodBankDonorBloodCropTakeCompletedForm,
//BloodBankDonorBloodCropTakeProductDegradationForm,BloodBankDonorBloodCropTakeInguiryForm,
//BloodBankCrossmatchAcceptForm,BloodBankCrossmatchCrossmatchForm,BloodBankCrossmatchCompletedForm,
//BloodBankCrossmatchRequestForm,BloodBankCoombsProcedureForm,BloodBankCoombsCompletedForm,
//BloodBankCoombsRejectForm,BloodBankCoombsRequestForm,BloodBankCoombsApproveForm,BloodBankCoombsRequestSupplyingForm,
//BloodDonationEntryForm
 ],
 exports: [
 //BloodBankExternalBloodProductRequestForm,BloodBankExternalBloodProductEntryForm,BloodGroupTestRequest,
 //BloodGroupTestApprove,BloodGroupTestProcedure,BloodGroupTestCompleted,BloodBankProductInfoForm,
 //BloodBankBloodProducts_CokluOzelDurumForm,BloodBankSubGroupApproveForm,BloodBankSubGroupRejectForm,
 //BloodBankSubGroupCompletedForm,BloodBankSubGroupProcedureForm,BloodBankSubGroupRequestForm,
 //    BloodBankSubGroupRequestOrganizeForm,
     //BloodProductDeliveryForm, BloodProductRequestInfoForm,
     //BloodProductRejectForm, CrossMatch,
     BloodProductPreparationForm,
     BloodProductRequestForm,
     //BloodProductRequestSupplyingForm, BloodProductReadyForm,
 //    BloodBankDonorBloodCropTakeRegistrationForm,
 //BloodBankDonorBloodCropTakeSendStockForm,BloodBankDonorBloodCropTakeCompletedForm,
 //BloodBankDonorBloodCropTakeProductDegradationForm,BloodBankDonorBloodCropTakeInguiryForm,
 //BloodBankCrossmatchAcceptForm,BloodBankCrossmatchCrossmatchForm,BloodBankCrossmatchCompletedForm,
 //BloodBankCrossmatchRequestForm,BloodBankCoombsProcedureForm,BloodBankCoombsCompletedForm,
 //BloodBankCoombsRejectForm,BloodBankCoombsRequestForm,BloodBankCoombsApproveForm,BloodBankCoombsRequestSupplyingForm,
 //BloodDonationEntryForm
  ],
  entryComponents: [
  //BloodBankExternalBloodProductRequestForm,BloodBankExternalBloodProductEntryForm,BloodGroupTestRequest,
  //BloodGroupTestApprove,BloodGroupTestProcedure,BloodGroupTestCompleted,BloodBankProductInfoForm,
  //BloodBankBloodProducts_CokluOzelDurumForm,BloodBankSubGroupApproveForm,BloodBankSubGroupRejectForm,
  //BloodBankSubGroupCompletedForm,BloodBankSubGroupProcedureForm,BloodBankSubGroupRequestForm,
  //    BloodBankSubGroupRequestOrganizeForm,
      //BloodProductDeliveryForm, BloodProductRequestInfoForm,
      //BloodProductRejectForm, CrossMatch,
      BloodProductPreparationForm,
      BloodProductRequestForm,
      //BloodProductRequestSupplyingForm, BloodProductReadyForm,
  //    BloodBankDonorBloodCropTakeRegistrationForm,
  //BloodBankDonorBloodCropTakeSendStockForm,BloodBankDonorBloodCropTakeCompletedForm,
  //BloodBankDonorBloodCropTakeProductDegradationForm,BloodBankDonorBloodCropTakeInguiryForm,
  //BloodBankCrossmatchAcceptForm,BloodBankCrossmatchCrossmatchForm,BloodBankCrossmatchCompletedForm,
  //BloodBankCrossmatchRequestForm,BloodBankCoombsProcedureForm,BloodBankCoombsCompletedForm,
  //BloodBankCoombsRejectForm,BloodBankCoombsRequestForm,BloodBankCoombsApproveForm,BloodBankCoombsRequestSupplyingForm,
  //BloodDonationEntryForm
   ]
})
export class KanMerkeziModule {
	static dynamicComponentsMap = {
		BloodProductPreparationForm, 
		BloodProductRequestForm, 
	};
 }

