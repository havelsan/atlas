import { RequirementResultCode } from "Fw/Requirements/RequirementResultCode";
import { IRequirements } from "Fw/Requirements/IRequirements";
import { DrugSpecificationEnum, Episode, DrugOrderStatusEnum, HospitalTimeSchedule } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { DrugInfo } from "app/NebulaClient/Services/ObjectService/DrugOrderIntroductionService";
import { ShowBoxTypeEnum } from "app/NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { PatientDTO, ControlOfActiveIngredient_Input, ControlOfActiveIngredientMaterialModel, DrugOrderRequirement_Output, DrugOrderIntroductionGridViewModel } from "Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderGridComponentViewModel";
import { EnumItem } from "app/NebulaClient/Mscorlib/EnumItem";
import { IEnumList } from "app/NebulaClient/Mscorlib/IEnumList";
import { ClassType } from "app/NebulaClient/ClassTransformer";
import { NeHttpService } from "app/Fw/Services/NeHttpService";


export class DrugOrderAddRequirement implements IRequirements {

    public SelectedMaterials: Array<DrugInfo>;
    public DrugOrderIntroductionGridViewModelDTO: Array<DrugOrderIntroductionGridViewModel>;
    public SelectedTimeSchedule: Guid;
    public PlannedStartTime: Date;
    public DrugOrderMinDate: Date;
    public Patient: PatientDTO;
    public DoseAmount: number;
    public Day: number;
    public Episode: Episode;
    public UpdatedOnGrid: boolean;
    public DrugOrderIntroductionGridViewModel: Array<DrugOrderIntroductionGridViewModel>;
    public TimeScheduleDataSource: Array<HospitalTimeSchedule>;

    constructor(private http: NeHttpService, selectedMaterials: Array<DrugInfo>, drugOrderIntroductionGridViewModelDTO: Array<DrugOrderIntroductionGridViewModel>, timeScheduleDataSource: Array<HospitalTimeSchedule>, selectedTimeSchedule: Guid, plannedStartTime: Date, drugOrderMinDate: Date,
        patient: PatientDTO, doseAmount: number, day: number,
        episode: Episode, drugOrderIntroductionGridViewModel: Array<DrugOrderIntroductionGridViewModel>, updatedOnGrid: boolean) {
        //Eğere tedavi güncelleme yapılıyorsa yukarıda seçili olan malzemeleri göz ardı et.
        if (selectedMaterials != null)
            this.SelectedMaterials = selectedMaterials;
        this.DrugOrderIntroductionGridViewModelDTO = drugOrderIntroductionGridViewModelDTO;
        this.SelectedTimeSchedule = selectedTimeSchedule;
        this.TimeScheduleDataSource = timeScheduleDataSource;
        if (plannedStartTime != null)
            this.PlannedStartTime = new Date(plannedStartTime.toString());
        this.DrugOrderMinDate = drugOrderMinDate;
        this.Patient = patient;
        this.DrugOrderIntroductionGridViewModel = drugOrderIntroductionGridViewModel;
        this.DoseAmount = doseAmount;
        this.Day = day;
        this.Episode = episode;
        this.UpdatedOnGrid = updatedOnGrid;
    }
    public ExecuteRequirements(): RequirementResultCode {
        let requirementResult = new RequirementResultCode();
        //Ekle butonu ile yapılacak kontroller.
        if (this.SelectedMaterials != null) {
            if (this.PlannedStartTime < this.DrugOrderMinDate) {
                requirementResult.resultCode = <number>DrugOrderAddRequirementResultCodeEnum.CANNOT_ORDER_PAST_TIME;
                requirementResult.resultMessage = DrugOrderAddRequirementResultCodeEnum._CANNOT_ORDER_PAST_TIME.description;
                return requirementResult;
            }

            if (this.SelectedMaterials.length == 0) {
                requirementResult.resultCode = <number>DrugOrderAddRequirementResultCodeEnum.NO_MATERIAL_SELECTED;
                requirementResult.resultMessage = DrugOrderAddRequirementResultCodeEnum._NO_MATERIAL_SELECTED.description;
                return requirementResult;
            }

            let materialAlreadyAddedMessage = '';
            this.SelectedMaterials.forEach(element => {
                if (this.DrugOrderIntroductionGridViewModelDTO.find(x => x.Material.drugObjectId == element.drugObjectId) != null)
                    materialAlreadyAddedMessage += element.name + ', ';
            });

            if (!String.isNullOrEmpty(materialAlreadyAddedMessage)) {
                requirementResult.resultMessage += DrugOrderAddRequirementResultCodeEnum._MATERIAL_ALREADY_ADDED.description + ': ' + materialAlreadyAddedMessage;
                return requirementResult;
            }

            let materialContinueMessage = '';
            this.SelectedMaterials.forEach(element => {
                if (this.DrugOrderIntroductionGridViewModel.find(x => x.Material.drugObjectId === element.drugObjectId && x.Status === DrugOrderStatusEnum.Continue) != null)
                    materialContinueMessage += element.name + ', ';
            });

            if (!String.isNullOrEmpty(materialContinueMessage)) {
                requirementResult.resultMessage += DrugOrderAddRequirementResultCodeEnum._MATERIAL_CONTINUE.description + ': ' + materialContinueMessage;
                return requirementResult;
            }

            requirementResult.IsSuccess = true;
            return requirementResult;
        }
        else {
            //Tekrarla butonu ile yapılacak kontroller

            // if (this.DrugOrderIntroductionGridViewModel.filter(x => x.SelectionCheck == true &&
            //     x.Status == DrugOrderStatusEnum.Continue).length > 0) {
            //     requirementResult.resultMessage = 'Sadece Tamamlandı ve Durdurulan Direktifler tekrar edilebilir.'
            //     return requirementResult;
            // }

            if (this.DrugOrderIntroductionGridViewModel.filter(x => x.SelectionCheck == true).length == 0) {
                requirementResult.resultCode = <number>DrugOrderAddRequirementResultCodeEnum.NO_MATERIAL_SELECTED;
                requirementResult.resultMessage = DrugOrderAddRequirementResultCodeEnum._NO_MATERIAL_SELECTED.description;
                return requirementResult;
            }

            this.DrugOrderIntroductionGridViewModelDTO.forEach(dtoModel => {
                if (dtoModel.PlannedStartTime < this.DrugOrderMinDate) {
                    requirementResult.resultCode = <number>DrugOrderAddRequirementResultCodeEnum.CANNOT_ORDER_PAST_TIME;
                    requirementResult.resultMessage = DrugOrderAddRequirementResultCodeEnum._CANNOT_ORDER_PAST_TIME.description;
                    return requirementResult;
                }
            });

            // let materialAlreadyAddedMessage = '';
            // this.DrugOrderIntroductionGridViewModel.filter(x => x.SelectionCheck == true).map(x => x.Material).forEach(element => {
            //     if (this.DrugOrderIntroductionGridViewModelDTO.find(x => x.Material.drugObjectId == element.drugObjectId) != null)
            //         materialAlreadyAddedMessage += element.name + ', ';
            // });

            // if (!String.isNullOrEmpty(materialAlreadyAddedMessage)) {
            //     requirementResult.resultMessage += DrugOrderAddRequirementResultCodeEnum._MATERIAL_ALREADY_ADDED.description + ': ' + materialAlreadyAddedMessage;
            //     return requirementResult;
            // }

            requirementResult.IsSuccess = true;
            return requirementResult;
        }
    }

    public AgeWarningMessage(drugInfoList: Array<DrugInfo>): string {

        let ageMessage = '';

        drugInfoList.forEach(drug => {
            if (drug.minAge > 0 && this.Patient.Age < drug.minAge) {
                if (String.isNullOrEmpty(ageMessage))
                    ageMessage = 'Hasta ' + this.Patient.Age + ' yaşında.';
            }

            if (drug.maxAge > 0 && this.Patient.Age > drug.maxAge) {
                if (String.isNullOrEmpty(ageMessage))
                    ageMessage = 'Hasta ' + this.Patient.Age + ' yaşında.';
            }

            if (!String.isNullOrEmpty(ageMessage))
                ageMessage = ageMessage + ' </br>' + drug.name + " ilacı için tavsiye edilen yaş aralığı (" + drug.minAge + ")-(" + drug.maxAge + ")";
        });

        return ageMessage;
    }

    public DrugSpecWarningMessage(drugInfoList: Array<DrugInfo>): string {
        let drugSpecMessage = '';

        drugInfoList.forEach(drug => {
            //Özellikli ilaç uyarısı
            if (drug.DrugSpecifications.length > 0) {
                drug.DrugSpecifications.forEach(drugSpec => {
                    switch (drugSpec) {
                        case DrugSpecificationEnum.Psychotrophic:
                            drugSpecMessage += '<b>' + DrugSpecificationEnum._Psychotrophic.description + '</b>-';
                            break;
                        case DrugSpecificationEnum.HighRisk:
                            drugSpecMessage += '<b>' + DrugSpecificationEnum._HighRisk.description + '</b>-';
                            break;
                        case DrugSpecificationEnum.ColdChain:
                            break;
                        case DrugSpecificationEnum.Trombotic:
                            break;
                        case DrugSpecificationEnum.Vaccine:
                            break;
                        case DrugSpecificationEnum.Penicillin:
                            break;
                        case DrugSpecificationEnum.Antibiotics:
                            break;
                        case DrugSpecificationEnum.HumanAlbumin:
                            break;
                        case DrugSpecificationEnum.Epidermolysis:
                            break;
                        case DrugSpecificationEnum.AntiTrombotic:
                            break;
                        case DrugSpecificationEnum.PregnancyContraindicate:
                            if (this.Patient) {
                                if (this.Patient.Sex == "2" && this.Patient.Age >= 12 && this.Patient.Age <= 55)
                                    drugSpecMessage += '<b>' + DrugSpecificationEnum._PregnancyContraindicate.description + '</b>-';
                            }
                            break;
                        case DrugSpecificationEnum.NarrowTherapeuticInterval:
                            drugSpecMessage += '<b>' + DrugSpecificationEnum._NarrowTherapeuticInterval.description + '</b>-';
                            break;
                        case DrugSpecificationEnum.ProtectFromLight:
                            break;
                    }
                });
                if (!String.isNullOrEmpty(drugSpecMessage)) {
                    drugSpecMessage = drugSpecMessage.substr(0, drugSpecMessage.length - 1);
                    drugSpecMessage = drug.name + " ilacının özelliği/özellikleri bulunmaktadır. <b>Bilginize!</b> : </br>" + drugSpecMessage + ' </br>';
                }
            }
        });
        return drugSpecMessage;
    }

    public async ExecuteRequirementsWithApproval(): Promise<RequirementResultCode> {
        let requirementResult: RequirementResultCode = new RequirementResultCode();

        let message = '';
        let ageMessage = '';
        let drugSpecMessage = '';

        //Yaş aralığı uyarısı. Ekle butonu ile oluşturulan ilaçlar için.
        if (this.SelectedMaterials != null) {
            ageMessage += this.AgeWarningMessage(this.SelectedMaterials);
            drugSpecMessage += this.DrugSpecWarningMessage(this.SelectedMaterials);
        }

        if (this.DrugOrderIntroductionGridViewModelDTO) {
            ageMessage += this.AgeWarningMessage(this.DrugOrderIntroductionGridViewModelDTO.map(x => x.Material));
            drugSpecMessage += this.DrugSpecWarningMessage(this.DrugOrderIntroductionGridViewModelDTO.map(x => x.Material));
        }
        //

        // if (!String.isNullOrEmpty(ageMessage))
        //     ageMessage = " ilaç hastanın yaş aralığı için uygun değildir. Hastanız " + ageMessage;
        //

        let input: ControlOfActiveIngredient_Input = new ControlOfActiveIngredient_Input();

        //Aynı etken maddeli ilaçlar var ise kontrol için sunucuya gönder. Yoksa gönderme

        this.DrugOrderIntroductionGridViewModelDTO.forEach(element => {
            //Çoklu ekleme için
            if (element.HospitalTimeSchedule != null && element.Day != null && element.DoseAmount != null) {
                if (this.SelectedMaterials != null && this.SelectedMaterials.length > 0) {
                    this.SelectedMaterials.map(function (params: DrugInfo) {
                        params.ActiveIngeridents.forEach(activeIng => {
                            if (element.Material.ActiveIngeridents.find(x => x.Objectid == activeIng.Objectid)) {
                                element.AddMaterialToInput = true;
                            }
                        });
                    });
                }
            }

            if ((element.AddMaterialToInput && input.materialModelList.find(x => x.ObjectID == new Guid(element.Material.drugObjectId)) == null)) {
                let materialModel: ControlOfActiveIngredientMaterialModel = new ControlOfActiveIngredientMaterialModel();
                if (element.UpdatedOnGrid) {
                    if (this.DoseAmount != null && this.Day != null && this.PlannedStartTime != null && this.SelectedTimeSchedule != null) {
                        materialModel.Amount = this.DoseAmount;
                        materialModel.Day = this.Day;
                        materialModel.ObjectID = new Guid(element.Material.drugObjectId);
                        materialModel.PlannedStartTime = new Date(this.PlannedStartTime.toString());
                        materialModel.PlannedEndTime = new Date(this.PlannedStartTime.AddDays(element.Day).toString());
                        input.materialModelList.push(materialModel);
                        element.UpdatedOnGrid = false;
                        element.AddMaterialToInput = false;
                    }
                }
                else {
                    if (element.DoseAmount != null && element.Day != null && element.DrugOrderIntroDuctionTimeSchedule != null) {
                        materialModel.Amount = element.DoseAmount;
                        materialModel.Day = element.Day;
                        materialModel.ObjectID = new Guid(element.Material.drugObjectId);
                        materialModel.PlannedStartTime = new Date(element.PlannedStartTime.toString());
                        materialModel.PlannedEndTime = new Date(element.PlannedStartTime.AddDays(element.Day).toString());
                        input.materialModelList.push(materialModel);
                        element.UpdatedOnGrid = false;
                        element.AddMaterialToInput = false;
                    }
                }
            }
        });

        if (this.SelectedMaterials != null && this.SelectedMaterials.length > 0) {
            this.SelectedMaterials.forEach(material => {
                if (input.materialModelList.find(x => x.ObjectID == new Guid(material.drugObjectId)) == null) {
                    let materialModel: ControlOfActiveIngredientMaterialModel = new ControlOfActiveIngredientMaterialModel();
                    if (this.DoseAmount != null && this.Day != null && this.PlannedStartTime != null && this.PlannedStartTime != null &&
                        this.SelectedTimeSchedule != null && this.SelectedTimeSchedule != Guid.Empty) {
                        materialModel.Amount = this.DoseAmount * <number>this.TimeScheduleDataSource.find(x => x.ObjectID == this.SelectedTimeSchedule).Frequency;
                        materialModel.Day = this.Day;
                        materialModel.PlannedStartTime = new Date(this.PlannedStartTime.toString());
                        materialModel.PlannedEndTime = new Date(this.PlannedStartTime.AddDays(this.Day).toString());
                        materialModel.ObjectID = new Guid(material.drugObjectId);
                        input.materialModelList.push(materialModel);
                    }
                }
            });
        }

        if (this.DrugOrderIntroductionGridViewModelDTO != null && this.DrugOrderIntroductionGridViewModelDTO.length > 0) {
            this.DrugOrderIntroductionGridViewModelDTO.forEach(dto => {
                if (input.materialModelList.find(x => x.ObjectID == new Guid(dto.Material.drugObjectId)) == null) {
                    let materialModel: ControlOfActiveIngredientMaterialModel = new ControlOfActiveIngredientMaterialModel();
                    if (dto.UpdatedOnGrid == true) {
                        if (this.DoseAmount != null && this.Day != null && this.PlannedStartTime != null) {
                            materialModel.Amount = this.DoseAmount;
                            materialModel.Day = this.Day;
                            materialModel.PlannedStartTime = new Date(this.PlannedStartTime.toString());
                            materialModel.PlannedEndTime = new Date(this.PlannedStartTime.AddDays(this.Day).toString());
                            materialModel.ObjectID = new Guid(dto.Material.drugObjectId);
                            input.materialModelList.push(materialModel);
                        }
                    }
                    else {
                        if (dto.DoseAmount != null && dto.Day != null && dto.PlannedStartTime != null) {
                            materialModel.Amount = dto.DrugOrderIntroDuctionTimeSchedule.map(x => x.DoseAmount).reduce((x1, x2) => x1 + x2, 0);
                            materialModel.Day = dto.Day;
                            materialModel.PlannedStartTime = new Date(dto.DrugOrderIntroDuctionTimeSchedule[0].Time.toString());
                            materialModel.PlannedEndTime = new Date(dto.DrugOrderIntroDuctionTimeSchedule[dto.DrugOrderIntroDuctionTimeSchedule.length - 1].Time.toString());
                            materialModel.ObjectID = new Guid(dto.Material.drugObjectId);
                            input.materialModelList.push(materialModel);
                        }
                    }
                    dto.UpdatedOnGrid = false;
                }
            });
        }

        input.episode = this.Episode;
        if (input.materialModelList.length > 0) {
            let result = await this.http.post<DrugOrderRequirement_Output>('api/DrugOrderRequirementService/DrugOrderRequirement', input);
            if (!String.isNullOrEmpty(result.ActiveIngredientMessage))
                message += result.ActiveIngredientMessage;
            if (!String.isNullOrEmpty(result.OverDoseMessage))
                message += result.OverDoseMessage;
        }
        
        if (!String.isNullOrEmpty(drugSpecMessage))
            message += drugSpecMessage;
        if (!String.isNullOrEmpty(ageMessage))
            message += ageMessage;
        if (!String.isNullOrEmpty(message)) {
            message += "Devam Etmek İstiyor Musunuz?";

            let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'İlaç Özellikleri',
                message);

            if (messageResult === 'V') {
                requirementResult.resultMessage = message;
                return requirementResult;
            }
        }

        requirementResult.IsSuccess = true;
        return requirementResult;
    }
}


export enum DrugOrderAddRequirementResultCodeEnum {
    CANNOT_ORDER_PAST_TIME = 0,
    NO_MATERIAL_SELECTED = 1,
    NO_TIMESCHEDULE_SELECTED = 2,
    MATERIAL_ALREADY_ADDED = 3,
    MIN_MAX_AGE_CRITERIA = 4,
    MATERIAL_CONTINUE = 5,
}

export namespace DrugOrderAddRequirementResultCodeEnum {
    export const _CANNOT_ORDER_PAST_TIME = new EnumItem(DrugOrderAddRequirementResultCodeEnum.CANNOT_ORDER_PAST_TIME, 'CANNOT_ORDER_PAST_TIME', 'Geçmiş zamanlı order verilemez!', 0);
    export const _NO_MATERIAL_SELECTED = new EnumItem(DrugOrderAddRequirementResultCodeEnum.NO_MATERIAL_SELECTED, 'NO_MATERIAL_SELECTED', 'Lütfen İlaç seçiniz!', 1);
    export const _NO_TIMESCHEDULE_SELECTED = new EnumItem(DrugOrderAddRequirementResultCodeEnum.NO_TIMESCHEDULE_SELECTED, 'NO_TIMESCHEDULE_SELECTED', 'Lütfe Doz Aralığı seçiniz.', 2);
    export const _MATERIAL_ALREADY_ADDED = new EnumItem(DrugOrderAddRequirementResultCodeEnum.MATERIAL_ALREADY_ADDED, 'MATERIAL_ALREADY_ADDED', 'Bu ilaç(lar) eklenmiş!', 3);
    export const _MIN_MAX_AGE_CRITERIA = new EnumItem(DrugOrderAddRequirementResultCodeEnum.MIN_MAX_AGE_CRITERIA, 'MIN_MAX_AGE_CRITERIA', 'İlaç(lar) yaş aralığına uygun değildir!', 4);
    export const _MATERIAL_CONTINUE = new EnumItem(DrugOrderAddRequirementResultCodeEnum.MATERIAL_CONTINUE, 'MATERIAL_CONTINUE', 'Bu ilaç(lar) uygulaması devam etmektedir.', 5);
    export const Items: Array<EnumItem> = [_NO_MATERIAL_SELECTED, _NO_TIMESCHEDULE_SELECTED, _MATERIAL_ALREADY_ADDED, _CANNOT_ORDER_PAST_TIME, _MATERIAL_CONTINUE, _MIN_MAX_AGE_CRITERIA];

    @ClassType()
    export class DrugOrderAddRequirementResultCodeEnumList implements IEnumList {
        get Items(): Array<EnumItem> {
            return DrugOrderAddRequirementResultCodeEnum.Items;
        }
    }
}

