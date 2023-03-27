import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { MultiSelectComponent } from "Fw/Components/multiselect.component";
import { InfoBoxComponent } from "Fw/Components/infobox.component";
import { GetTextComponent, GetDateComponent, GetValueListComponent, GetTextComponentMultiple} from "Fw/Components/inputform.component";
import { ShowBoxComponent } from "Fw/Components/showbox.component";
import { UsernamePwdFormComponent } from "Fw/Components/UsernamePwdFormComponent";
import { TreeShowBoxComponent } from "Fw/Components/treeshowbox.component";
import { FourShowBoxComponent } from "Fw/Components/fourshowbox.component";
import { CustomShowBoxComponent } from "Fw/Components/customshowbox.component";
import { PatientAddressComponent } from "Fw/Components/patient.address";
import { DevExtremeModule } from "devextreme-angular";
import { FwModule } from "Fw/FwModule";

@NgModule({
    imports: [DevExtremeModule, FwModule, CommonModule],
    declarations: [MultiSelectComponent, InfoBoxComponent, ShowBoxComponent, GetTextComponent, GetDateComponent,
        GetValueListComponent, GetTextComponentMultiple, PatientAddressComponent, CustomShowBoxComponent,FourShowBoxComponent, TreeShowBoxComponent, UsernamePwdFormComponent],
	exports: [MultiSelectComponent, InfoBoxComponent, ShowBoxComponent, GetTextComponent, GetDateComponent, GetValueListComponent,
			GetTextComponentMultiple, PatientAddressComponent, CustomShowBoxComponent,FourShowBoxComponent, TreeShowBoxComponent, UsernamePwdFormComponent],
	entryComponents: [MultiSelectComponent, InfoBoxComponent, ShowBoxComponent, GetTextComponent, GetDateComponent, GetValueListComponent,
        GetTextComponentMultiple, PatientAddressComponent, CustomShowBoxComponent,FourShowBoxComponent, TreeShowBoxComponent, UsernamePwdFormComponent]
})
export class CoreModule {
	static dynamicComponentsMap = {
		MultiSelectComponent, 
		InfoBoxComponent, 
		ShowBoxComponent, 
		GetTextComponent, 
		GetDateComponent, 
		GetValueListComponent, 
		GetTextComponentMultiple, 
		PatientAddressComponent, 
		CustomShowBoxComponent, 
		TreeShowBoxComponent, 
		FourShowBoxComponent,
		UsernamePwdFormComponent
	};

}
