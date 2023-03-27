//$BD17670C
import { DrugOrder, FrequencyEnum, KScheduleMaterial, DrugSpecificationEnum, DrugReportType, SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { DrugDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderIntroduction } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderIntroductionDet } from 'NebulaClient/Model/AtlasClientModel';
import { DrugUsageTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DrugShapeTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PrescriptionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { InpatientDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientPresDetail } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { OutPatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { OutPatientDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { OutpatientPresDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Type } from 'NebulaClient/ClassTransformer';
import { DrugOrderIntroductionGridViewModel, UpgradeDrugOrder_Output } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderGridComponentViewModel';
import { GetReturnableDrugOrders_Output } from './DrugReturnActionService';




export class DrugOrderIntroductionService {
    public static async AddDrugTS(DrugID: Guid, PlannedStartTime: Date): Promise<DrugOrderIntroductionDet> {
        let url: string = '/api/DrugOrderIntroductionService/AddDrugTS';
        let input = { 'DrugID': DrugID, 'PlannedStartTime': PlannedStartTime };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<DrugOrderIntroductionDet>(url, input);
        return result;
    }
    public static async CreateInpatientDrugOrderTS(drugOrder: DrugOrder, drugDescription: string): Promise<InpatientDrugOrder> {
        let url: string = '/api/DrugOrderIntroductionService/CreateInpatientDrugOrderTS';
        let input = { 'drugOrder': drugOrder, 'drugDescription': drugDescription };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<InpatientDrugOrder>(url, input);
        return result;
    }
    public static async CreateOutpatientDrugOrderTS(drugOrder: DrugOrder, drugUsageType: DrugUsageTypeEnum, drugDescription: string): Promise<OutPatientDrugOrder> {
        let url: string = '/api/DrugOrderIntroductionService/CreateOutpatientDrugOrderTS';
        let input = { 'drugOrder': drugOrder, 'drugUsageType': drugUsageType, 'drugDescription': drugDescription };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<OutPatientDrugOrder>(url, input);
        return result;
    }
    public static async AddInpatientPrescriptionTS(drugOrderIntroduction: DrugOrderIntroduction, drugOrderIntroductionDet: DrugOrderIntroductionDet,
        drugOrder: DrugOrder, inpatientPresDetails: Array<InpatientPresDetail>, inpatientPrescriptions: Array<InpatientPrescription>): Promise<AddInpatientPrescriptionTS_Output> {
        let url: string = '/api/DrugOrderIntroductionService/AddInpatientPrescriptionTS';
        let input = {
            'drugOrderIntroduction': drugOrderIntroduction, 'drugOrderIntroductionDet': drugOrderIntroductionDet,
            'drugOrder': drugOrder, 'inpatientPresDetails': inpatientPresDetails, 'inpatientPrescriptions': inpatientPrescriptions
        };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<AddInpatientPrescriptionTS_Output>(url, input);
        return result;
    }

    public static async AddInpatientPrescription(drugOrder: DrugOrder, inpatientPrescription: InpatientPrescription, drugDescription: string): Promise<AddInpatientPrescription_Output> {
        let url: string = '/api/DrugOrderIntroductionService/AddInpatientPrescription';
        let input = { 'drugOrder': drugOrder, 'inpatientPrescription': inpatientPrescription, 'drugDescription': drugDescription };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<AddInpatientPrescription_Output>(url, input);
        return result;
    }

    public static async AddOutpatientPrescription(drugOrder: DrugOrder, outpatientPrescription: OutPatientPrescription,
        drugDescription: string, drugUsageType: DrugUsageTypeEnum, drugOrderIntroductionDet: DrugOrderIntroductionDet): Promise<AddOutpatientPrescription_Output> {
        let url: string = '/api/DrugOrderIntroductionService/AddOutpatientPrescription';
        let input = {
            'drugOrder': drugOrder, 'outpatientPrescription': outpatientPrescription, 'drugDescription': drugDescription, 'drugUsageType': drugUsageType,
            'drugOrderIntroductionDet': drugOrderIntroductionDet
        };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<AddOutpatientPrescription_Output>(url, input);
        return result;
    }

    public static async AddOutpatientPrescriptionTS(drugOrderIntroduction: DrugOrderIntroduction,
        drugOrderIntroductionDet: DrugOrderIntroductionDet, drugOrder: DrugOrder): Promise<OutpatientPresDetail> {
        let url: string = '/api/DrugOrderIntroductionService/AddOutpatientPrescriptionTS';
        let input = { 'drugOrderIntroduction': drugOrderIntroduction, 'drugOrderIntroductionDet': drugOrderIntroductionDet, 'drugOrder': drugOrder };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<OutpatientPresDetail>(url, input);
        return result;
    }


    public static async GetOldDrugOrderIntroductionDets(episode: Episode): Promise<OldDrugOrderIntroductionDet> {
        let url: string = '/api/DrugOrderIntroductionService/GetOldDrugOrderIntroductionDets';
        let input = { 'episode': episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<OldDrugOrderIntroductionDet>(url, input);
        return result;
    }

    public static async GetOldDrugOrderIntroductionDetsWithDate(episode: Episode, PlannedStartDate: Date): Promise<OldDrugOrderIntroductionDet> {
        let url: string = '/api/DrugOrderIntroductionService/GetOldDrugOrderIntroductionDetsWithDate';
        let input = { 'episode': episode, 'PlannedStartDate': PlannedStartDate };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<OldDrugOrderIntroductionDet>(url, input);
        return result;
    }

    public static async GetOldDrugOrderIntroductions(episode: Episode): Promise<Array<OldDrugOrderIntroduction>> {
        let url: string = '/api/DrugOrderIntroductionService/GetOldDrugOrderIntroductions';
        let input = { 'episode': episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<OldDrugOrderIntroduction>>(url, input);
        return result;
    }

    public static GetActiveDrugOrders(episode: Episode, PlannedStartDate: Date, PlannedEndDate: Date): Promise<ActiveDrugOrders> {
        let url: string = '/api/DrugOrderIntroductionService/GetActiveDrugOrders';
        let input = { 'episode': episode, 'PlannedStartDate': PlannedStartDate, 'PlannedEndDate': PlannedEndDate };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        return new Promise<ActiveDrugOrders>((resolve, reject) => {
            httpService.post<ActiveDrugOrders>(url, input).then(r => {
                let activeDrugOrders = r as ActiveDrugOrders ;
                resolve(activeDrugOrders);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public static async SearchDrug(name: string, inheldStatus: boolean, drugIngredients: Array<DrugIngredient>): Promise<Array<DrugInfo>> {
        let url: string = '/api/DrugOrderIntroductionService/SearchDrug';
        let input = { 'name': name, 'inheldStatus': inheldStatus, 'drugIngredients': drugIngredients };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugInfo>>(url, input);
        return result;
    }

    public static async CheckERecetePasswordForCurrentUser(): Promise<boolean> {
        let url: string = '/api/DrugOrderIntroductionService/CheckERecetePasswordForCurrentUser';
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.get<boolean>(url);
        return result;
    }

    public static async UpdateOrderDetail(orderDetail: OrderDetail): Promise<UpdateOrderDetail_Output> {
        let url: string = '/api/DrugOrderIntroductionService/UpdateOrderDetail';
        let input = { 'orderDetail': orderDetail };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<UpdateOrderDetail_Output>(url, input);
        return result;
    }

    public static async GetOrderDetail(id: number): Promise<GetOrderDetail_Output> {
        let url: string = '/api/DrugOrderIntroductionService/GetOrderDetail';
        let input = { 'id': id };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<GetOrderDetail_Output>(url, input);
        return result;
    }

    public static async GetEquivalentDrug(drug: DrugDefinition, amount: number): Promise<Array<DrugInfo>> {
        let url: string = '/api/DrugOrderIntroductionService/GetEquivalentDrug';
        let input = { 'drug': drug, 'amount': amount };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugInfo>>(url, input);
        return result;
    }

    public static async StopDrugOrder(id: number): Promise<string> {
        let url: string = '/api/DrugOrderIntroductionService/StopDrugOrder';
        let input = { 'id': id };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async GetPlannedStartTime(frequency: FrequencyEnum, startDate: Date): Promise<Date> {
        let url: string = '/api/DrugOrderIntroductionService/GetPlannedStartTime';
        let input = { 'frequency': frequency, 'startDate': startDate };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Date>(url, input, Date);
        return result;
    }
    public static async GetDrugOrderQueryDayNumber(): Promise<string> {
        let url: string = '/api/DrugOrderIntroductionService/GetDrugOrderQueryDayNumber';
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.get<string>(url);
        return result;
    }

    public static async IsSGK(SubEpisodeID: Guid): Promise<boolean> {
        let url: string = '/api/DrugOrderIntroductionService/IsSGK';
        let input = { 'SubEpisodeID': SubEpisodeID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }

    public static async GetEreceteList(episode: Episode): Promise<Array<ERecete>> {
        let url: string = '/api/DrugOrderIntroductionService/GetEreceteList';
        let input = { 'episode': episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ERecete>>(url, input);
        return result;
    }

    public static async GetPresciptionByErecete(ereceteno: string, patientObjId: string): Promise<void> {
        let url: string = '/api/DrugOrderIntroductionService/GetEGetPresciptionByErecete';
        let input = { 'ereceteno': ereceteno, 'patientObjId': patientObjId };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<void>(url, input);
        return result;
    }

    public static async GetEreceteMessage(id: Guid): Promise<string> {
        let url: string = '/api/DrugOrderIntroductionService/GetEreceteMessage';
        let input = { 'id': id };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }

    public static async DiagnosisDefinition(): Promise<Array<DiagnosisDefinitionList>> {
        let url: string = '/api/DrugOrderIntroductionService/DiagnosisDefinitionTS';
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.get<Array<DiagnosisDefinitionList>>(url);
        return result;
    }

    public static async RepeatDrugOrder(inputValue: repeatDrugOrder_Input): Promise<repeatDrugOrder_Output> {
        let url: string = '/api/DrugOrderIntroductionService/RepeatDrugOrder';
        let input = { 'EReceteDetays': inputValue.EReceteDetays, 'PlannedStartDate': inputValue.PlannedStartDate };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<repeatDrugOrder_Output>(url, input);
        return result;
    }

    public static async GetPatientOwnDrug(episode: Episode): Promise<Array<DrugInfo>> {
        let url: string = '/api/DrugOrderIntroductionService/GetPatientOwnDrug';
        let input = { 'episode': episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugInfo>>(url, input);
        return result;
    }

    public static async GetPatientOwnDrugDetail(subepisode: Guid): Promise<Array<PatientOwnDrugInfo>> {
        let url: string = '/api/DrugOrderIntroductionService/GetPatientOwnDrugDetail';
        let input = { 'subepisode': subepisode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<PatientOwnDrugInfo>>(url, input);
        return result;
    }
    public static async DeletePatientOwnDrugDetail(trxobjectID: Guid): Promise<string> {
        let url: string = '/api/DrugOrderIntroductionService/DeletePatientOwnDrugDetail';
        let input = { 'trxobjectID': trxobjectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }



    public static async GetValidationPatientAgeAndMaterialAgeBand(episodeObjectID: string, materialObjectID: string): Promise<ValidationPatientAgeAndMaterialAgeBand_Output> {
        let url: string = '/api/DrugOrderIntroductionService/GetValidationPatientAgeAndMaterialAgeBand';
        let input = { 'EpisodeObjectID': episodeObjectID, 'MaterialObjectID': materialObjectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ValidationPatientAgeAndMaterialAgeBand_Output>(url, input);
        return result;
    }
    public static async MaterialDoseManagerOnPatient(episodeObjectID: string, password: string): Promise<string> {
        let url: string = '/api/DrugOrderIntroductionService/MaterialDoseManagerOnPatient';
        let input = { 'episodeObjectID': episodeObjectID, 'password': password };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async CreateDrugOrderDetails(): Promise<string> {
        let url: string = '/api/DrugOrderIntroductionService/CreateDrugOrderDetails';
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }

    public static async GetDrugOrderIntroductionDet(id: Guid): Promise<DrugOrderIntroductionDet> {
        let url: string = '/api/DrugOrderIntroductionService/GetDrugOrderIntroductionDet';
        let input = { 'id': id };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<DrugOrderIntroductionDet>(url, input);
        return result;
    }

    public static async GetPatientOwnDrugEntry(episode: Episode): Promise<Array<GetPatientOwnDrugEntry_Output>> {
        let url: string = '/api/DrugOrderIntroductionService/GetPatientOwnDrugEntry';
        let input = { 'episode': episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<GetPatientOwnDrugEntry_Output>>(url, input);
        return result;
    }
    public static async GetNewPatientOwnDrugEntry(episode: Episode): Promise<Array<GetPatientNewOwnDrugEntry_Output>> {
        let url: string = '/api/DrugOrderIntroductionService/GetPatientNewOwnDrugEntry';
        let input = { 'episode': episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<GetPatientNewOwnDrugEntry_Output>>(url, input);
        return result;
    }

    public static async CheckLabProcedure(drug: Guid, episode: Episode): Promise<Array<CheckLabProcedure_Output>> {
        let url: string = '/api/DrugOrderIntroductionService/CheckLabProcedure';
        let input = { 'drug': drug, 'episode': episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<CheckLabProcedure_Output>>(url, input);
        return result;
    }

    public static async ControlOfActiveIngredient(drug: Guid, episode: Episode, drugOrderObjectID: Guid): Promise<Array<ControlOfActiveIngredient_Output>> {
        let url: string = '/api/DrugOrderIntroductionService/ControlOfActiveIngredient';
        let input = { 'drug': drug, 'episode': episode, 'drugOrderObjectID': drugOrderObjectID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ControlOfActiveIngredient_Output>>(url, input);
        return result;
    }

    public static async ControlOfDrugSpecification(drugObjectID: Guid, formDefName: string): Promise<string> {
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let url = '/api/DrugOrderIntroductionService/ControlOfDrugSpecification?drugObjectID=' + drugObjectID + '&formDefID=' + formDefName;
        let result = await httpService.get<string>(url);
        return result;
    }

    public static async GetActiveDrugOrderDetails(drugOrderObjectID: Guid): Promise<Array<DrugOrderDetail>> {
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let url = '/api/DrugOrderIntroductionService/GetActiveDrugOrderDetails';
        let input = { 'drugOrderObjectID': drugOrderObjectID };
        let result = await httpService.post<GetActiveDrugOrderDetails_Output>(url, input);
        return result.drugOrderDetails;
    }

    public static async UpdateDrugOrderDetails(drugOrderDetails: Array<DrugOrderDetail>): Promise<boolean> {
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let url = '/api/DrugOrderIntroductionService/UpdateDrugOrderDetails';
        let input = { 'drugOrderDetails': drugOrderDetails };
        let result = await httpService.post<boolean>(url, input);
        return result;
    }

    public static async UpgradeDrugOrder(gridViewModel: DrugOrderIntroductionGridViewModel): Promise<UpgradeDrugOrder_Output> {
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let url = '/api/DrugOrderIntroductionService/UpgradeDrugOrder';
        let input = { 'gridViewModel': gridViewModel };
        let result = await httpService.post<UpgradeDrugOrder_Output>(url, input);
        return result;
    }

    public static async GetDrugOrderTimeOffset(): Promise<number> {
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let url = '/api/DrugOrderIntroductionService/GetDrugOrderTimeOffset';
        let result = await httpService.get<number>(url);
        return result;
    }

    public static async ControlOfOverDoseActiveIngredient(drug: Guid, episode: Episode, orderDose: number, orderFreq: number, newDetailList: Array<ControlOfOverDoseActiveIngredient_Details>): Promise<ControlOfOverDoseActiveIngredient_Output> {
        let url: string = '/api/DrugOrderIntroductionService/ControlOfOverDoseActiveIngredient';
        let input = { 'drug': drug, 'episode': episode, 'orderDose': orderDose, 'orderFreq': orderFreq, 'newDetailList': newDetailList };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ControlOfOverDoseActiveIngredient_Output>(url, input);
        return result;
    }

    public static async ControlRepeatDay(drug: Guid, episode: Episode, orderStartDate: Date): Promise<ControlRepeatDay_Output> {
        let url: string = '/api/DrugOrderIntroductionService/ControlRepeatDay';
        let input = { 'drug': drug, 'episode': episode, 'orderStartDate': orderStartDate };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<ControlRepeatDay_Output>(url, input);
        return result;
    }

    public static async GetPatientAllergicActiveIngredients(EpisodeID: Guid): Promise<Array<Guid>> {
        let url: string = '/api/DrugOrderIntroductionService/GetPatientAllergicActiveIngredients';
        let input = { 'EpisodeID': EpisodeID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<Guid>>(url, input);
        return result;
    }

    public static async UpdateTransferableDrugOrders(transferableDrugOrders: Array<GetReturnableDrugOrders_Output>): Promise<string> {
        let url: string = '/api/DrugOrderIntroductionService/UpdateTransferableDrugOrders';
        let input = { 'transferableDrugOrders': transferableDrugOrders };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
}
export class GetActiveDrugOrderDetails_Output {
    public drugOrderDetails: DrugOrderDetail[];
}
export class ControlOfActiveIngredient_Output {
    public drug: string;
    public activeIngredient: string;
    //Eklenecek malzemenin ObjectID'si
    public ObjectID: Guid;
}

export class ControlOfActiveIngredientForRepeat_Output {
    public ComparedDrugDef: DrugDefinition;
    public CrossedActiveIngridientDrugs: Array<ControlOfActiveIngredientForRepeat>;
    public CrossActiveIngridientNames: string;
}

export class ControlOfActiveIngredientForRepeat {
    public ActiveIngridientCrossedDrugName: string;
    public ActiveIngridientCrossedDrugObjectID: Guid;
    public CrossedMaterialName: string;
    public IsRequestedInDay: boolean;
}

export class repeatDrugOrder_Input {
    public EReceteDetays: Array<EReceteDetay>;
    public PlannedStartDate: Date;
}

export class repeatDrugOrder_Output {
    public DrugOrderIntroductionDets: Array<DrugOrderIntroductionDet>;
}
export class ValidationPatientAgeAndMaterialAgeBand_Input {
    public EpisodeObjectID: string;
    public MaterialObjectID: string;
}

export class ValidationPatientAgeAndMaterialAgeBand_Output {
    public PatientAge: Number;
    public MaterialMaxAge: Number;
    public MaterialMinAge: Number;
}

export class DiagnosisDefinitionList {
    public DiagnosisName: string;
    public DiagnosisObjID: Guid;
}

export class OldDrugOrderIntroductionDet {
    public DrugOrderIntroductionDets: Array<DrugOrderIntroductionDet>;
    public Materials: Array<Material>;
    public TempDrugOrders: Array<TempDrugOrder>;
}

export class OldDrugOrderIntroduction {
    @Type(() => Guid)
    public ObjectId: Guid;
    @Type(() => Date)
    public ActionDate: Date;
    public Description: string;
    public EReceteStatus: string;
}

export class TempDrugOrder {
    public OrderID: number;
    public DrugName: string;
    public DoseAmount: number;
    public Frequency: string;
    public Day: number;
    public OrderStatus: string;
    public OrderType: string;
    public TreatmentType: string;
    public NextDayOrder: boolean;
    public FrequencyEnumValue: FrequencyEnum;
    @Type(() => Date)
    public OrderDate: Date;
    @Type(() => Guid)
    public OrderObjectID: Guid;
    public MaterialObjectID: Guid;
    public UsageNote: string;
}
export class ActiveDrugOrders {
    @Type(() => Order)
    public Orders: Array<Order>;
    @Type(() => DrugList)
    public Drugs: Array<DrugList>;
    @Type(() => OrderDetail)
    public OrderDetails: Array<OrderDetail>;
    @Type(() => DrugList)
    public DetailDrugs: Array<DrugList>;
}

export class DrugList {
    text: string;
    id: number;
    color: string;
}

export class Order {
    id: number;
    text: string;
    ownerId: number;
    @Type(() => Date)
    startDate: Date;
    @Type(() => Date)
    endDate: Date;
    color: string;
    state: string;
    orderDetail: string;
}
export class Priority {
    text: string;
    id: number;
    color: string;
}

export class PatientOwnDrugInfo{
    objectID:string;
    name: string;
    barcode: string;
    expireDate: Date;
    @Type(() => Number)
    amount: number;
    @Type(() => Number)
    restamount: number;
}

export class DrugInfo {
    @Type(() => Number)
    minAge: number;
    @Type(() => Number)
    maxAge: number;
    drugObjectId: string;
    name: string;
    barcode: string;
    inheldStatus: string;
    drugUsageTypeEnum: DrugUsageTypeEnum;
    PatientSafetyFrom: boolean;
    prescriptionTypeEnum: PrescriptionTypeEnum;
    SgkReturnPay: string;
    drugShapeTypeEnum: DrugShapeTypeEnum;
    @Type(() => DrugIngredient)
    ActiveIngeridents: Array<DrugIngredient>;
    DrugSpecifications: Array<DrugSpecificationEnum>;
    DrugReportType: DrugReportType;
    MedulaReportNo: string;
    isPatientOwnDrug: boolean;
    drugType: boolean;
    DrugDescription: string;
    InfectionApproval: boolean;
    isDivisibleDrug: boolean;
}

export class DrugIngredient {
    @Type(() => Guid)
    Objectid: Guid;
    Name: string;
}

export class OrderDetail {
    id: number;
    text: string;
    typeId: string;
    @Type(() => Date)
    startDate: Date;
    @Type(() => Date)
    endDate: Date;
}

export class UpdateOrderDetail_Output {
    orderDetail: OrderDetail;
    detailUpdate: boolean;
    errorDescription: string;
}

export class GetOrderDetail_Output {
    orderDetail: DrugOrderDetail;
}

export class AddInpatientPrescriptionTS_Output {
    inpatientPresDetail: InpatientPresDetail;
    inpatientPrescription: InpatientPrescription;
    inpatientDrugOrders: Array<InpatientDrugOrder>;
}

export class AddInpatientPrescription_Output {
    inpatientPrescription: InpatientPrescription;
    inpatientDrugOrder: InpatientDrugOrder;
}

export class AddOutpatientPrescription_Output {
    outPatientPrescription: OutPatientPrescription;
    outPatientDrugOrder: OutPatientDrugOrder;
}

export class ERecete {
    ReceteNo: string;
    TakipNo: string;
    ReceteTarihi: string;
    ProtokolNo: string;
    Doktor: string;
    Brans: string;
    SeriNo: string;
    EReceteDetays: EReceteDetay[];
}

export class EReceteDetay {
    Barkod: string;
    Name: string;
    Frequency: string;
    DoseAmount: string;
    Day: string;
    PeryodUnit: string;
    Amount: string;
}

export class OpenColorPrescription_Input {
    @Type(() => Guid)
    SubEpisodeObjectID: Guid;
}

export class GetPatientOwnDrugEntry_Output {
    Id: number;
    @Type(() => Date)
    ActionDate: Date;
    Barcode: string;
    Name: string;
    SendAmount: number;
    Amount: number;
    DisplayText: string;
}
export class GetPatientNewOwnDrugEntry_Output {
    Id: number;
    @Type(() => Date)
    ActionDate: Date;
    Name: string;
    DisplayText: string;
}

export class CheckLabProcedure_Output {
    interactionLabProcedure: string;
    interactionMessage: string;
}

export class ControlOfOverDoseActiveIngredient_Details {
    @Type(() => Guid)
    newMaterialObjectIDList: Guid;
    totalDose: number;
}

export class ControlOfOverDoseActiveIngredient_Input {
    KScheduleMaterials: Array<KScheduleMaterial>;
    @Type(() => Guid)
    drug: Guid;
    orderDose: number;
    orderFreq: number;
    episode: Episode;
    newDetailList: Array<ControlOfOverDoseActiveIngredient_Details>;
}

export class ControlOfOverDoseActiveIngredient_Output {
    warningMessage: string;
    isWarning: boolean;
}

export class ControlRepeatDay_Output {
    warningMessage: string;
    isWarning: boolean;
}

export class GetDrugReportNo_Input {
    public EpisodeID: Guid;
    public DrugID: Guid;
}

export class GetDrugReportNo_Output {
    public result: boolean;
    public resultMessage: string;
    public reportId: string;
}