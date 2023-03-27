//$0F89ECD2
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NursingPainScale } from "NebulaClient/Model/AtlasClientModel";
import { PainChangingSituationDefinition } from "NebulaClient/Model/AtlasClientModel";
import { PainQualityDefinition } from "NebulaClient/Model/AtlasClientModel";
import { PainFrequencyDefiniton } from "NebulaClient/Model/AtlasClientModel";
import { PainPlaceDefition } from "NebulaClient/Model/AtlasClientModel";
import { NursingInitiativeDefinition } from "NebulaClient/Model/AtlasClientModel";

export class NursingPainScaleFormViewModel extends BaseViewModel {
    public _NursingPainScale: NursingPainScale = new NursingPainScale();
    public PainQualityDefinitions: Array<PainQualityDefinition> = new Array<PainQualityDefinition>();
    public PainFrequencyDefinitons: Array<PainFrequencyDefiniton> = new Array<PainFrequencyDefiniton>();
    public PainPlaceDefitions: Array<PainPlaceDefition> = new Array<PainPlaceDefition>();
    public PainChangingSituationDefinitions: Array<PainChangingSituationDefinition> = new Array<PainChangingSituationDefinition>();
    public SelectedChangingSituationIncreaseList: Array<PainChangingSituationDefinition> = new Array<PainChangingSituationDefinition>();
    public SelectedChangingSituationDecreaseList: Array<PainChangingSituationDefinition> = new Array<PainChangingSituationDefinition>();
    public NursingInitiativeDefinitions: Array<NursingInitiativeDefinition> = new Array<NursingInitiativeDefinition>();
    public SelectedNursingInitiatives: Array<NursingInitiativeDefinition> = new Array<NursingInitiativeDefinition>();

}
