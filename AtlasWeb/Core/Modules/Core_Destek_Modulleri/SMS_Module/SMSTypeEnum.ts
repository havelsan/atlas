import { EnumItem } from "app/NebulaClient/Mscorlib/EnumItem";
import { IEnumList } from "app/NebulaClient/Mscorlib/IEnumList";
import { ClassType } from "app/NebulaClient/ClassTransformer";


export enum SMSTypeEnum {
    AppointmentInfoSMS = 36,
    BabyObstetricInfoSMS = 29,
    BirthDaySMS = 5,
    BulkSMS = 1,
    ChemotherapyRadiotherapy = 2,
    ConsultationRequestSMS = 26,
    DiagnosisCountInfoSMS = 8,
    DiagnosisSMSForPatient = 38,
    EmergencyInterventionSMSForChief = 15,
    EmergencyInterventionSMSForDoctor = 16,
    ExamDelaySMSForChief = 9,
    ExamDelaySMSForDoctor = 10,
    ExamDelaySMSForResponsible = 19,
    FTRSessionCompleted = 3,
    GlassReportSMSForPatient = 34,
    InpatientInfoSMS = 32,
    LaboratoryTakingSampleDelaySMS = 27,
    LeaveJobPersonnelSMS = 7,
    MaterialMinimumLevelSMS = 22,
    MaterialSafetyLevelSMS = 23,
    NewPersonnelJoinSMS = 6,
    OlayAfetBilgisiSMS = 24,
    Other = 0,
    PathologyDelaySMSForResponsible = 18,
    PathologyReportDelaySMSForChief = 11,
    PathologyReportDelaySMSForForDoctor = 12,
    PathologyReportSMSForPatient = 33,
    RadAppointmentSMSForPatient = 31,
    RadiologyDelaySMS = 28,
    RadiologyReportDelaySMSForChief = 13,
    RadiologyReportDelaySMSForDoctor = 14,
    RadiologyReportDelaySMSForResponsible = 20,
    RadTestReportSMSForPatient = 30,
    SurgeryCompletedSMS = 25,
    TreatmentDischargeInfo = 4,
    UnReportedSurgerySMS = 17,
    VaccineActiveSMSForPatient = 37,
    WorkHealthSecWarnSMS = 21,
}

export namespace SMSTypeEnum {
    export const _AppointmentInfoSMS = new EnumItem(SMSTypeEnum.AppointmentInfoSMS, 'AppointmentInfoSMS', 'Randevu Bilgi Mesajı (Hasta)', 36);
    export const _BabyObstetricInfoSMS = new EnumItem(SMSTypeEnum.BabyObstetricInfoSMS, 'BabyObstetricInfoSMS', 'Bebek Doğum Mesajı (Hasta)', 29);
    export const _BirthDaySMS = new EnumItem(SMSTypeEnum.BirthDaySMS, 'BirthDaySMS', 'Doğum Günü Mesajı', 5);
    export const _BulkSMS = new EnumItem(SMSTypeEnum.BulkSMS, 'BulkSMS', 'Toplu SMS', 1);
    export const _ChemotherapyRadiotherapy = new EnumItem(SMSTypeEnum.ChemotherapyRadiotherapy, 'ChemotherapyRadiotherapy', 'Kemoterapi/Radyoterapi', 2);
    export const _ConsultationRequestSMS = new EnumItem(SMSTypeEnum.ConsultationRequestSMS, 'ConsultationRequestSMS', 'Konsültasyon İstem Mesajı', 26);
    export const _DiagnosisCountInfoSMS = new EnumItem(SMSTypeEnum.DiagnosisCountInfoSMS, 'DiagnosisCountInfoSMS', 'Tanı Sayısı Bildirim Mesajı', 8);
    export const _DiagnosisSMSForPatient = new EnumItem(SMSTypeEnum.DiagnosisSMSForPatient, 'DiagnosisSMSForPatient', 'Tanı Bilgilendirme Measjı (Hasta)', 38);
    export const _EmergencyInterventionSMSForChief = new EnumItem(SMSTypeEnum.EmergencyInterventionSMSForChief, 'EmergencyInterventionSMSForChief', 'Triaj Bilgisi  (Şef)', 15);
    export const _EmergencyInterventionSMSForDoctor = new EnumItem(SMSTypeEnum.EmergencyInterventionSMSForDoctor, 'EmergencyInterventionSMSForDoctor', 'Triaj Bilgisi (Doktor)', 16);
    export const _ExamDelaySMSForChief = new EnumItem(SMSTypeEnum.ExamDelaySMSForChief, 'ExamDelaySMSForChief', 'Poliklinik Muayene Gecikme Mesajı  (Şef)', 9);
    export const _ExamDelaySMSForDoctor = new EnumItem(SMSTypeEnum.ExamDelaySMSForDoctor, 'ExamDelaySMSForDoctor', 'Poliklinik Muayene Gecikme Mesajı (Doktor)', 10);
    export const _ExamDelaySMSForResponsible = new EnumItem(SMSTypeEnum.ExamDelaySMSForResponsible, 'ExamDelaySMSForResponsible', 'Poliklinik Muayene Gecikme Mesajı (Sorumlu)', 19);
    export const _FTRSessionCompleted = new EnumItem(SMSTypeEnum.FTRSessionCompleted, 'FTRSessionCompleted', 'FTR Seans Sonlandırma', 3);
    export const _GlassReportSMSForPatient = new EnumItem(SMSTypeEnum.GlassReportSMSForPatient, 'GlassReportSMSForPatient', 'Gözlük Reçetesi Mesajı (Hasta)', 34);
    export const _InpatientInfoSMS = new EnumItem(SMSTypeEnum.InpatientInfoSMS, 'InpatientInfoSMS', 'Yatan Hasta Mesajı (Hastaya)', 32);
    export const _LaboratoryTakingSampleDelaySMS = new EnumItem(SMSTypeEnum.LaboratoryTakingSampleDelaySMS, 'LaboratoryTakingSampleDelaySMS', 'Kan Alma Birimi Tetkik Kabul Uyarı Mesajı', 27);
    export const _LeaveJobPersonnelSMS = new EnumItem(SMSTypeEnum.LeaveJobPersonnelSMS, 'LeaveJobPersonnelSMS', 'İşten Ayrılan Personel Mesajı', 7);
    export const _MaterialMinimumLevelSMS = new EnumItem(SMSTypeEnum.MaterialMinimumLevelSMS, 'MaterialMinimumLevelSMS', 'Malzeme Minimum Seviye Mesajı', 22);
    export const _MaterialSafetyLevelSMS = new EnumItem(SMSTypeEnum.MaterialSafetyLevelSMS, 'MaterialSafetyLevelSMS', 'Malzeme Kritik Seviye Mesajı', 23);
    export const _NewPersonnelJoinSMS = new EnumItem(SMSTypeEnum.NewPersonnelJoinSMS, 'NewPersonnelJoinSMS', 'Yeni Personel Katılım Mesajı', 6);
    export const _OlayAfetBilgisiSMS = new EnumItem(SMSTypeEnum.OlayAfetBilgisiSMS, 'OlayAfetBilgisiSMS', 'Olay Afet Bilgisi Mesajı', 24);
    export const _Other = new EnumItem(SMSTypeEnum.Other, 'Other', 'Diğer', 0);
    export const _PathologyDelaySMSForResponsible = new EnumItem(SMSTypeEnum.PathologyDelaySMSForResponsible, 'PathologyDelaySMSForResponsible', 'Patoloji Rapor Süre Aşımı Mesajı (Sorumlu)', 18);
    export const _PathologyReportDelaySMSForChief = new EnumItem(SMSTypeEnum.PathologyReportDelaySMSForChief, 'PathologyReportDelaySMSForChief', 'Patoloji Rapor Süre Aşımı Mesajı (Şef)', 11);
    export const _PathologyReportDelaySMSForForDoctor = new EnumItem(SMSTypeEnum.PathologyReportDelaySMSForForDoctor, 'PathologyReportDelaySMSForForDoctor', 'Patoloji Rapor Süre Aşımı Mesajı (Doktor)', 12);
    export const _PathologyReportSMSForPatient = new EnumItem(SMSTypeEnum.PathologyReportSMSForPatient, 'PathologyReportSMSForPatient', 'Patoloji Raporu Hazır (Hasta)', 33);
    export const _RadAppointmentSMSForPatient = new EnumItem(SMSTypeEnum.RadAppointmentSMSForPatient, 'RadAppointmentSMSForPatient', 'Radyoloji Randevu Mesajı (Hasta)', 31);
    export const _RadiologyDelaySMS = new EnumItem(SMSTypeEnum.RadiologyDelaySMS, 'RadiologyDelaySMS', 'Radyoloji Birimi Tetkik Kabul Uyarı Mesajı', 28);
    export const _RadiologyReportDelaySMSForChief = new EnumItem(SMSTypeEnum.RadiologyReportDelaySMSForChief, 'RadiologyReportDelaySMSForChief', 'Radyoloji Rapor Süre Aşımı Mesajı  (Şef)', 13);
    export const _RadiologyReportDelaySMSForDoctor = new EnumItem(SMSTypeEnum.RadiologyReportDelaySMSForDoctor, 'RadiologyReportDelaySMSForDoctor', 'Radyoloji Rapor Süre Aşımı Mesajı (Doktor)', 14);
    export const _RadiologyReportDelaySMSForResponsible = new EnumItem(SMSTypeEnum.RadiologyReportDelaySMSForResponsible, 'RadiologyReportDelaySMSForResponsible', 'RadiologyReportDelaySMSForResponsible', 20);
    export const _RadTestReportSMSForPatient = new EnumItem(SMSTypeEnum.RadTestReportSMSForPatient, 'RadTestReportSMSForPatient', 'Radiyoloji Sonuç Mesajı (Hasta)', 30);
    export const _SurgeryCompletedSMS = new EnumItem(SMSTypeEnum.SurgeryCompletedSMS, 'SurgeryCompletedSMS', 'Amelita İşlemi Tamamlandı Mesajı', 25);
    export const _TreatmentDischargeInfo = new EnumItem(SMSTypeEnum.TreatmentDischargeInfo, 'TreatmentDischargeInfo', 'Ön Taburcu Bilgilendirme', 4);
    export const _UnReportedSurgerySMS = new EnumItem(SMSTypeEnum.UnReportedSurgerySMS, 'UnReportedSurgerySMS', 'Ameliyat Raporu Plan Tarihi Mesajı', 17);
    export const _VaccineActiveSMSForPatient = new EnumItem(SMSTypeEnum.VaccineActiveSMSForPatient, 'VaccineActiveSMSForPatient', 'Yenidoğan Aşı Mesajı (Hasta)', 37);
    export const _WorkHealthSecWarnSMS = new EnumItem(SMSTypeEnum.WorkHealthSecWarnSMS, 'WorkHealthSecWarnSMS', 'Sağlık Taraması Bildirim Mesajı', 21);

    export const Items: Array<EnumItem> = [_AppointmentInfoSMS, _BabyObstetricInfoSMS, _BirthDaySMS, _BulkSMS, _ChemotherapyRadiotherapy, _ConsultationRequestSMS, _DiagnosisCountInfoSMS, _DiagnosisSMSForPatient,
        _EmergencyInterventionSMSForChief, _EmergencyInterventionSMSForDoctor, _ExamDelaySMSForChief, _ExamDelaySMSForDoctor, _ExamDelaySMSForResponsible, _FTRSessionCompleted, _GlassReportSMSForPatient, _InpatientInfoSMS,
        _LaboratoryTakingSampleDelaySMS, _LeaveJobPersonnelSMS, _MaterialMinimumLevelSMS, _MaterialSafetyLevelSMS, _NewPersonnelJoinSMS, _OlayAfetBilgisiSMS, _Other, _PathologyDelaySMSForResponsible, _PathologyReportDelaySMSForChief,
        _PathologyReportDelaySMSForForDoctor, _PathologyReportSMSForPatient, _RadAppointmentSMSForPatient, _RadiologyDelaySMS, _RadiologyReportDelaySMSForChief, _RadiologyReportDelaySMSForDoctor, _RadiologyReportDelaySMSForResponsible,
        _RadTestReportSMSForPatient, _SurgeryCompletedSMS, _TreatmentDischargeInfo, _UnReportedSurgerySMS, _VaccineActiveSMSForPatient, _WorkHealthSecWarnSMS];

    @ClassType()
    export class SMSTypeEnumList implements IEnumList {
        get Items(): Array<EnumItem> {
            return SMSTypeEnum.Items;
        }
    }
}