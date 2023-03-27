//$3BE4DD91
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from "Fw/FwModule";
import { LaboratoryProcedureDetailForm } from "./LaboratoryProcedureDetailForm";
import { LaboratoryProcedureForm } from "./LaboratoryProcedureForm";
import { LaboratoryProcedureLongReportForm } from "./LaboratoryProcedureLongReportForm";
import { LaboratoryCokluOzelDurumForm } from "./LaboratoryCokluOzelDurumForm";
import { LaboratoryRequestRequestForm } from "./LaboratoryRequestRequestForm";
import { LaboratoryForm } from "./LaboratoryForm";
import { LaboratoryRequestInfoForm } from "./LaboratoryRequestInfoForm";
import { LaboratoryRequestProcedureForm } from "./LaboratoryRequestProcedureForm";
import { LaboratoryRequestResultForm } from "./LaboratoryRequestResultForm";
import { PanicAlertForm } from "./PanicAlertForm";

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
declarations: [ LaboratoryProcedureDetailForm, LaboratoryProcedureLongReportForm,
//LaboratoryRunMethodDefinitionForm,LaboratoryTubeDefinitonFormX,,
    LaboratoryProcedureForm, LaboratoryCokluOzelDurumForm,
    //, LaboratoryCokluOzelDurumForm,
//LaboratoryResultDetail2,LaboratorySubProcedureDetail,LaboratorySubProcedureLongReportForm,
LaboratoryRequestRequestForm, LaboratoryForm, LaboratoryRequestInfoForm, LaboratoryRequestProcedureForm,
    LaboratoryRequestResultForm, PanicAlertForm
 ],
 exports: [ LaboratoryProcedureDetailForm, LaboratoryProcedureLongReportForm,
 //LaboratoryRunMethodDefinitionForm,LaboratoryTubeDefinitonFormX,,
	 LaboratoryProcedureForm, LaboratoryCokluOzelDurumForm,
 //, LaboratoryCokluOzelDurumForm,
 //LaboratoryResultDetail2,LaboratorySubProcedureDetail,LaboratorySubProcedureLongReportForm,
 LaboratoryRequestRequestForm, LaboratoryForm, LaboratoryRequestInfoForm, LaboratoryRequestProcedureForm,
     LaboratoryRequestResultForm, PanicAlertForm
  ],
  entryComponents: [ LaboratoryProcedureDetailForm, LaboratoryProcedureLongReportForm,
  //LaboratoryRunMethodDefinitionForm,LaboratoryTubeDefinitonFormX,,
	  LaboratoryProcedureForm, LaboratoryCokluOzelDurumForm,
  //, LaboratoryCokluOzelDurumForm,
  //LaboratoryResultDetail2,LaboratorySubProcedureDetail,LaboratorySubProcedureLongReportForm,
  LaboratoryRequestRequestForm, LaboratoryForm, LaboratoryRequestInfoForm, LaboratoryRequestProcedureForm,
      LaboratoryRequestResultForm, PanicAlertForm
   ]
})
export class LaboratuarModule {
	static dynamicComponentsMap = {
		LaboratoryProcedureDetailForm, 
		LaboratoryProcedureLongReportForm, 
		LaboratoryProcedureForm, 
		LaboratoryCokluOzelDurumForm, 
		LaboratoryRequestRequestForm, 
		LaboratoryForm, 
		LaboratoryRequestInfoForm, 
		LaboratoryRequestProcedureForm, 
        LaboratoryRequestResultForm,
        PanicAlertForm
	};
 }

