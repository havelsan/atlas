using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;



namespace TTObjectClasses
{
    /// <summary>
    /// İlaç Direktifi Giriş
    /// </summary>
    public partial class DrugOrderIntroduction 
    {
        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            #endregion PreInsert
        }

        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
            #region PostTransition_New2Completed
            string dailyPresDistribution = TTObjectClasses.SystemParameter.GetParameterValue("DAILYPRESDISTRIBUTION", "FALSE");
            foreach (OutpatientPresDetail outpatientPresDetail in OutpatientPresDetails)
            {
                //if (this.Episode.Patient.PatientGroup == PatientGroupEnum.PrivateNonCom)
                //    outpatientPresDetail.OutPatientPrescription.CurrentStateDefID = OutPatientPrescription.States.DrugControl;
                //else
                //{
                if (dailyPresDistribution == "FALSE")
                    outpatientPresDetail.OutPatientPrescription.CurrentStateDefID = OutPatientPrescription.States.Completed;
                else
                    outpatientPresDetail.OutPatientPrescription.CurrentStateDefID = OutPatientPrescription.States.DrugControl;
                //  }
            }
            #endregion PostTransition_New2Completed
        }

        protected void PreTransition_New2CompletedWithSign()
        {
            // From State : New   To State : CompletedWithSign
            #region PreTransition_New2CompletedWithSign
            //            string message = string.Empty;
            //            foreach (InpatientPresDetail detail in this.InpatientPresDetails)
            //            {
            //                if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.NormalPrescription)
            //                {
            //                    message = message + "Normal Reçeteye Çıkacak İlaçlar: \r\n";
            //                    foreach (InpatientDrugOrder normal in detail.InpatientPrescription.InpatientDrugOrders)
            //                        message = message + normal.Material.Name.ToString() + "\r\n";
            //                }
            //
            //                if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.GreenPrescription)
            //                {
            //                    message = message + "Yeşil Reçeteye Çıkacak İlaçlar: \r\n";
            //                    foreach (InpatientDrugOrder green in detail.InpatientPrescription.InpatientDrugOrders)
            //                        message = message + green.Material.Name.ToString() + "\r\n";
            //                }
            //
            //                if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.OrangePrescription)
            //                {
            //                    message = message + "Turuncu Reçeteye Çıkacak İlaçlar: \r\n";
            //                    foreach (InpatientDrugOrder orange in detail.InpatientPrescription.InpatientDrugOrders)
            //                        message = message + orange.Material.Name.ToString() + "\r\n";
            //                }
            //
            //                if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.RedPrescription)
            //                {
            //                    message = message + "Kırmızı Reçeteye Çıkacak İlaçlar: \r\n";
            //                    foreach (InpatientDrugOrder red in detail.InpatientPrescription.InpatientDrugOrders)
            //                        message = message + red.Material.Name.ToString() + "\r\n";
            //                }
            //
            //                if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.PurplePrescription)
            //                {
            //                    message = message + "Mor Reçeteye Çıkacak İlaçlar: \r\n";
            //                    foreach (InpatientDrugOrder purple in detail.InpatientPrescription.InpatientDrugOrders)
            //                        message = message + purple.Material.Name.ToString() + "\r\n";
            //                }
            //            }
            //
            //            foreach (OutpatientPresDetail detail in this.OutpatientPresDetails)
            //            {
            //                if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.NormalPrescription)
            //                {
            //                    message = message + "Normal Reçeteye Çıkacak İlaçlar: \r\n";
            //                    foreach (OutPatientDrugOrder normal in detail.OutPatientPrescription.OutPatientDrugOrders)
            //                        message = message + normal.Material.Name.ToString() + "\r\n";
            //                }
            //
            //                if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.GreenPrescription)
            //                {
            //                    message = message + "Yeşil Reçeteye Çıkacak İlaçlar: \r\n";
            //                    foreach (OutPatientDrugOrder green in detail.OutPatientPrescription.OutPatientDrugOrders)
            //                        message = message + green.Material.Name.ToString() + "\r\n";
            //                }
            //
            //                if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.OrangePrescription)
            //                {
            //                    message = message + "Turuncu Reçeteye Çıkacak İlaçlar: \r\n";
            //                    foreach (OutPatientDrugOrder orange in detail.OutPatientPrescription.OutPatientDrugOrders)
            //                        message = message + orange.Material.Name.ToString() + "\r\n";
            //                }
            //
            //                if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.RedPrescription)
            //                {
            //                    message = message + "Kırmızı Reçeteye Çıkacak İlaçlar: \r\n";
            //                    foreach (OutPatientDrugOrder red in detail.OutPatientPrescription.OutPatientDrugOrders)
            //                        message = message + red.Material.Name.ToString() + "\r\n";
            //                }
            //
            //                if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.PurplePrescription)
            //                {
            //                    message = message + "Mor Reçeteye Çıkacak İlaçlar: \r\n";
            //                    foreach (OutPatientDrugOrder purple in detail.OutPatientPrescription.OutPatientDrugOrders)
            //                        message = message + purple.Material.Name.ToString() + "\r\n";
            //                }
            //            }
            //
            //            if (message != string.Empty)
            //            {
            //                string result = ShowBox.Sho w(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Reçete Türü", "Yatan Hasta Reçetesine Çıkacak ilaçların Reçete Türü : \r\n" + message + "\r\n" + "Devam Etmek İstiyor Musunuz?");
            //                if (result == "V")
            //                {
            //                    throw new Exception(SystemMessage.GetMessage(719));
            //                }
            //            }
            //
            //            if (this.InpatientPresDetails.Count > 0)
            //            {
            //                ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            //                this.ERecetePassword = currentUser.ErecetePassword;
            //                SendSignedERecete();
            //                SendSignedEReceteEHUApproval();
            //            }
            //
            //            if (this.OutpatientPresDetails.Count > 0)
            //            {
            //                ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            //                this.ERecetePassword = currentUser.ErecetePassword;
            //                SendSignedDailyERecete();
            //            }
            #endregion PreTransition_New2CompletedWithSign
        }

        protected void PostTransition_New2CompletedWithSign()
        {
            // From State : New   To State : CompletedWithSign
            #region PostTransition_New2CompletedWithSign
            string dailyPresDistribution = TTObjectClasses.SystemParameter.GetParameterValue("DAILYPRESDISTRIBUTION", "FALSE");
            foreach (OutpatientPresDetail outpatientPresDetail in OutpatientPresDetails)
            {
                //if (this.Episode.Patient.PatientGroup == PatientGroupEnum.PrivateNonCom)
                //    outpatientPresDetail.OutPatientPrescription.CurrentStateDefID = OutPatientPrescription.States.DrugControl;
                //else
                //{
                if (dailyPresDistribution == "FALSE")
                    outpatientPresDetail.OutPatientPrescription.CurrentStateDefID = OutPatientPrescription.States.Completed;
                else
                    outpatientPresDetail.OutPatientPrescription.CurrentStateDefID = OutPatientPrescription.States.DrugControl;
                // }
            }
            #endregion PostTransition_New2CompletedWithSign
        }

        #region Methods
        public void AddDrug(Guid DrugID, DateTime PlannedStartTime)
        {
            DrugDefinition drug = (DrugDefinition)ObjectContext.GetObject(DrugID, typeof(DrugDefinition));
            DrugOrderIntroductionDet drugOrderIntroductionDet = new DrugOrderIntroductionDet(ObjectContext);
            drugOrderIntroductionDet.Material = drug;
            drugOrderIntroductionDet.PlannedStartTime = PlannedStartTime;
            drugOrderIntroductionDet.DrugOrderIntroduction = this;
        }

        public static DrugOrderIntroductionDet AddDrugTS(Guid DrugID, DateTime PlannedStartTime)
        {
            TTObjectContext context = new TTObjectContext(false);
            DrugDefinition drug = (DrugDefinition)context.GetObject(DrugID, typeof(DrugDefinition));
            DrugOrderIntroductionDet drugOrderIntroductionDet = new DrugOrderIntroductionDet(context);
            drugOrderIntroductionDet.Material = drug;
            drugOrderIntroductionDet.PlannedStartTime = PlannedStartTime;
            return drugOrderIntroductionDet;
        }

        public InpatientDrugOrder CreateInpatientDrugOrder(DrugOrder drugOrder, TTObjectContext context)
        {
            InpatientDrugOrder inpatientDrugOrder = new InpatientDrugOrder(context);
            inpatientDrugOrder.ActionDate = drugOrder.ActionDate;
            inpatientDrugOrder.Amount = drugOrder.Amount;
            inpatientDrugOrder.Day = drugOrder.Day;
            inpatientDrugOrder.DoseAmount = drugOrder.DoseAmount;
            inpatientDrugOrder.Frequency = drugOrder.Frequency;
            inpatientDrugOrder.FromResource = drugOrder.FromResource;
            inpatientDrugOrder.MasterResource = drugOrder.MasterResource;
            inpatientDrugOrder.Episode = drugOrder.Episode;
            inpatientDrugOrder.Material = drugOrder.Material;
            inpatientDrugOrder.UsageNote = drugOrder.UsageNote;
            inpatientDrugOrder.DrugOrderID = drugOrder.ObjectID;
            inpatientDrugOrder.PackageAmount = Math.Ceiling((double)drugOrder.Amount / (double)drugOrder.Material.PackageAmount);
            if (((DrugDefinition)drugOrder.Material).PatientSafetyFrom.HasValue && (bool)((DrugDefinition)drugOrder.Material).PatientSafetyFrom)
            {
                inpatientDrugOrder.DescriptionType = DescriptionTypeEnum.PatientSafetyAndMonitoringFormDescription;
                inpatientDrugOrder.Description = DrugDescription;
            }

            if (drugOrder.MagistralChemicalDetails.Count > 0)
            {
                foreach (MagistralChemicalDetail magistralChemicalDetail in drugOrder.MagistralChemicalDetails)
                {
                    MagistralChemicalDetail inMagistralChemicalDetail = new MagistralChemicalDetail(context);
                    inMagistralChemicalDetail.MagistralChemicalDefinition = magistralChemicalDetail.MagistralChemicalDefinition;
                    inMagistralChemicalDetail.ChemicalAmount = magistralChemicalDetail.ChemicalAmount;
                    inpatientDrugOrder.MagistralChemicalDetails.Add(inMagistralChemicalDetail);
                }
            }

            if (drugOrder.MagistralDrugDetails.Count > 0)
            {
                foreach (MagistralDrugDetail magistralDrugDetail in drugOrder.MagistralDrugDetails)
                {
                    MagistralDrugDetail inMagistralDrugDetail = new MagistralDrugDetail(context);
                    inMagistralDrugDetail.Material = magistralDrugDetail.Material;
                    inMagistralDrugDetail.PreparatAmount = magistralDrugDetail.PreparatAmount;
                    inpatientDrugOrder.MagistralDrugDetails.Add(inMagistralDrugDetail);
                }
            }


            inpatientDrugOrder.IsImmediate = drugOrder.IsImmediate;
            inpatientDrugOrder.DrugUsageType = drugOrder.DrugUsageType;
            inpatientDrugOrder.CurrentStateDefID = InpatientDrugOrder.States.New;
            inpatientDrugOrder.NursingApplication = drugOrder.NursingApplication;
            return inpatientDrugOrder;
        }

        public static InpatientDrugOrder CreateInpatientDrugOrderTS(DrugOrder drugOrder, string drugDescription, TTObjectContext context)
        {
            InpatientDrugOrder inpatientDrugOrder = new InpatientDrugOrder(context);
            inpatientDrugOrder.ActionDate = drugOrder.ActionDate;
            inpatientDrugOrder.Amount = drugOrder.Amount;
            inpatientDrugOrder.Day = drugOrder.Day;
            inpatientDrugOrder.DoseAmount = drugOrder.DoseAmount;
            inpatientDrugOrder.Frequency = drugOrder.Frequency;
            inpatientDrugOrder.FromResource = drugOrder.FromResource;
            inpatientDrugOrder.MasterResource = drugOrder.MasterResource;
            inpatientDrugOrder.Episode = drugOrder.Episode;
            inpatientDrugOrder.Material = drugOrder.Material;
            inpatientDrugOrder.UsageNote = drugOrder.UsageNote;
            inpatientDrugOrder.DrugOrderID = drugOrder.ObjectID;
            inpatientDrugOrder.PackageAmount = Math.Ceiling((double)drugOrder.Amount / (double)drugOrder.Material.PackageAmount);
            if (((DrugDefinition)drugOrder.Material).PatientSafetyFrom.HasValue && (bool)((DrugDefinition)drugOrder.Material).PatientSafetyFrom)
            {
                inpatientDrugOrder.DescriptionType = DescriptionTypeEnum.PatientSafetyAndMonitoringFormDescription;
                inpatientDrugOrder.Description = drugDescription;
            }

            if (drugOrder.MagistralChemicalDetails.Count > 0)
            {
                foreach (MagistralChemicalDetail magistralChemicalDetail in drugOrder.MagistralChemicalDetails)
                {
                    MagistralChemicalDetail inMagistralChemicalDetail = new MagistralChemicalDetail(context);
                    inMagistralChemicalDetail.MagistralChemicalDefinition = magistralChemicalDetail.MagistralChemicalDefinition;
                    inMagistralChemicalDetail.ChemicalAmount = magistralChemicalDetail.ChemicalAmount;
                    inpatientDrugOrder.MagistralChemicalDetails.Add(inMagistralChemicalDetail);
                }
            }

            if (drugOrder.MagistralDrugDetails.Count > 0)
            {
                foreach (MagistralDrugDetail magistralDrugDetail in drugOrder.MagistralDrugDetails)
                {
                    MagistralDrugDetail inMagistralDrugDetail = new MagistralDrugDetail(context);
                    inMagistralDrugDetail.Material = magistralDrugDetail.Material;
                    inMagistralDrugDetail.PreparatAmount = magistralDrugDetail.PreparatAmount;
                    inpatientDrugOrder.MagistralDrugDetails.Add(inMagistralDrugDetail);
                }
            }
            inpatientDrugOrder.IsImmediate = drugOrder.IsImmediate;
            inpatientDrugOrder.CurrentStateDefID = InpatientDrugOrder.States.New;
            inpatientDrugOrder.NursingApplication = drugOrder.NursingApplication;
            return inpatientDrugOrder;
        }

        public OutPatientDrugOrder CreateOutpatientDrugOrder(DrugOrder drugOrder, TTObjectContext context)
        {
            OutPatientDrugOrder outPatientDrugOrder = new OutPatientDrugOrder(context);
            outPatientDrugOrder.ActionDate = drugOrder.ActionDate;
            outPatientDrugOrder.Amount = drugOrder.Amount;
            outPatientDrugOrder.Day = drugOrder.Day;
            outPatientDrugOrder.DoseAmount = drugOrder.DoseAmount;
            outPatientDrugOrder.Frequency = drugOrder.Frequency;
            outPatientDrugOrder.PeriodUnitType = PeriodUnitTypeEnum.DayPeriod;
            outPatientDrugOrder.PhysicianDrug = (DrugDefinition)drugOrder.Material;
            outPatientDrugOrder.DrugUsageType = DrugUsageType;
            outPatientDrugOrder.FromResource = drugOrder.FromResource;
            outPatientDrugOrder.MasterResource = drugOrder.MasterResource;
            outPatientDrugOrder.Episode = drugOrder.Episode;
            outPatientDrugOrder.Material = drugOrder.Material;
            outPatientDrugOrder.UsageNote = drugOrder.UsageNote;
            outPatientDrugOrder.PackageAmount = Math.Ceiling((double)drugOrder.Amount / (double)drugOrder.Material.PackageAmount);
            if (((DrugDefinition)drugOrder.Material).PatientSafetyFrom.HasValue && (bool)((DrugDefinition)drugOrder.Material).PatientSafetyFrom)
            {
                outPatientDrugOrder.DescriptionType = DescriptionTypeEnum.PatientSafetyAndMonitoringFormDescription;
                outPatientDrugOrder.Description = DrugDescription;
            }

            if (drugOrder.MagistralChemicalDetails.Count > 0)
            {
                foreach (MagistralChemicalDetail magistralChemicalDetail in drugOrder.MagistralChemicalDetails)
                {
                    MagistralChemicalDetail inMagistralChemicalDetail = new MagistralChemicalDetail(context);
                    inMagistralChemicalDetail.MagistralChemicalDefinition = magistralChemicalDetail.MagistralChemicalDefinition;
                    inMagistralChemicalDetail.ChemicalAmount = magistralChemicalDetail.ChemicalAmount;
                    outPatientDrugOrder.MagistralChemicalDetails.Add(inMagistralChemicalDetail);
                }
            }

            if (drugOrder.MagistralDrugDetails.Count > 0)
            {
                foreach (MagistralDrugDetail magistralDrugDetail in drugOrder.MagistralDrugDetails)
                {
                    MagistralDrugDetail inMagistralDrugDetail = new MagistralDrugDetail(context);
                    inMagistralDrugDetail.Material = magistralDrugDetail.Material;
                    inMagistralDrugDetail.PreparatAmount = magistralDrugDetail.PreparatAmount;
                    outPatientDrugOrder.MagistralDrugDetails.Add(inMagistralDrugDetail);
                }
            }

            outPatientDrugOrder.CurrentStateDefID = OutPatientDrugOrder.States.New;
            return outPatientDrugOrder;
        }

        public static OutPatientDrugOrder CreateOutpatientDrugOrderTS(DrugOrder drugOrder, DrugUsageTypeEnum? drugUsageType, string drugDescription, PeriodUnitTypeEnum periodUnitTypeEnum, double packageAmount)
        {
            TTObjectContext context = new TTObjectContext(false);
            OutPatientDrugOrder outPatientDrugOrder = new OutPatientDrugOrder(context);
            outPatientDrugOrder.ActionDate = drugOrder.ActionDate;
            outPatientDrugOrder.Amount = drugOrder.Amount;
            outPatientDrugOrder.Day = drugOrder.Day;
            outPatientDrugOrder.DoseAmount = drugOrder.DoseAmount;
            outPatientDrugOrder.Frequency = drugOrder.Frequency;
            outPatientDrugOrder.PeriodUnitType = PeriodUnitTypeEnum.DayPeriod;
            outPatientDrugOrder.PhysicianDrug = (DrugDefinition)drugOrder.Material;
            outPatientDrugOrder.DrugUsageType = drugUsageType;
            outPatientDrugOrder.FromResource = drugOrder.FromResource;
            outPatientDrugOrder.MasterResource = drugOrder.MasterResource;
            outPatientDrugOrder.Episode = drugOrder.Episode;
            outPatientDrugOrder.Material = drugOrder.Material;
            outPatientDrugOrder.UsageNote = drugOrder.UsageNote;
            outPatientDrugOrder.PackageAmount = 1;
            if (((DrugDefinition)drugOrder.Material).PatientSafetyFrom.HasValue && (bool)((DrugDefinition)drugOrder.Material).PatientSafetyFrom)
            {
                outPatientDrugOrder.DescriptionType = DescriptionTypeEnum.PatientSafetyAndMonitoringFormDescription;
                outPatientDrugOrder.Description = drugDescription;
            }

            if (drugOrder.MagistralChemicalDetails.Count > 0)
            {
                foreach (MagistralChemicalDetail magistralChemicalDetail in drugOrder.MagistralChemicalDetails)
                {
                    MagistralChemicalDetail inMagistralChemicalDetail = new MagistralChemicalDetail(context);
                    inMagistralChemicalDetail.MagistralChemicalDefinition = magistralChemicalDetail.MagistralChemicalDefinition;
                    inMagistralChemicalDetail.ChemicalAmount = magistralChemicalDetail.ChemicalAmount;
                    outPatientDrugOrder.MagistralChemicalDetails.Add(inMagistralChemicalDetail);
                }
            }

            if (drugOrder.MagistralDrugDetails.Count > 0)
            {
                foreach (MagistralDrugDetail magistralDrugDetail in drugOrder.MagistralDrugDetails)
                {
                    MagistralDrugDetail inMagistralDrugDetail = new MagistralDrugDetail(context);
                    inMagistralDrugDetail.Material = magistralDrugDetail.Material;
                    inMagistralDrugDetail.PreparatAmount = magistralDrugDetail.PreparatAmount;
                    outPatientDrugOrder.MagistralDrugDetails.Add(inMagistralDrugDetail);
                }
            }

            outPatientDrugOrder.CurrentStateDefID = OutPatientDrugOrder.States.New;
            return outPatientDrugOrder;
        }

        public void AddInpatientPrescription(DrugOrderIntroductionDet drugOrderIntroductionDet)
        {
            if (drugOrderIntroductionDet.DrugOrder.Type == TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi"))
            {
                InpatientPrescription inpatientPrescription = null;
                foreach (InpatientPresDetail inpatientPresDetail in InpatientPresDetails)
                {
                    if (inpatientPresDetail.InpatientPrescription.PrescriptionType == ((DrugDefinition)drugOrderIntroductionDet.DrugOrder.Material).PrescriptionType)
                        inpatientPrescription = inpatientPresDetail.InpatientPrescription;
                }

                if (inpatientPrescription != null)
                {
                    DrugOrder drugOrder = drugOrderIntroductionDet.DrugOrder;
                    InpatientDrugOrder inpatientDrugOrder = CreateInpatientDrugOrder(drugOrder, ObjectContext);
                    inpatientDrugOrder.InpatientPrescription = inpatientPrescription;
                }
                else
                {
                    bool gunuBirlikHastaMi = SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily);
                    if (gunuBirlikHastaMi)
                        throw new ApplicationException(TTUtils.CultureService.GetText("M25413", "Depo mevcudu olmayan ilaçlar için lütfen ayaktan hasta reçetesi ekranını kullanınız"));
                    inpatientPrescription = new InpatientPrescription(ObjectContext);
                    inpatientPrescription.ActionDate = Common.RecTime();
                    inpatientPrescription.FillingDate = Common.RecTime();
                    inpatientPrescription.FromResource = ActiveInPatientPhysicianApp.MasterResource;
                    inpatientPrescription.MasterResource = ActiveInPatientPhysicianApp.MasterResource;
                    inpatientPrescription.MasterAction = ActiveInPatientPhysicianApp;
                    inpatientPrescription.Episode = ActiveInPatientPhysicianApp.Episode;
                    inpatientPrescription.SubEpisode = ActiveInPatientPhysicianApp.SubEpisode;
                    inpatientPrescription.PrescriptionType = ((DrugDefinition)drugOrderIntroductionDet.DrugOrder.Material).PrescriptionType;
                    IList presTypeMaterialMatch = ObjectContext.QueryObjects("PRESTYPEMATERIALMATCHDEF", "PRESCRIPTIONTYPE =" + ((int)inpatientPrescription.PrescriptionType).ToString());
                    if (presTypeMaterialMatch.Count > 0)
                        inpatientPrescription.CurrentStateDefID = InpatientPrescription.States.Request;
                    else
                        inpatientPrescription.CurrentStateDefID = InpatientPrescription.States.Request;
                    foreach (DiagnosisForPresc diagnosisPres in DiagnosisForPrescriptions)
                    {
                        DiagnosisForPresc diagnosisForPresc = (DiagnosisForPresc)diagnosisPres.Clone();
                        diagnosisForPresc.Prescription = inpatientPrescription;
                    }

                    foreach (DiagnosisForSPTS diagnosisSPTS in DiagnosisForSPTSes)
                    {
                        DiagnosisForSPTS diagnosisForSPTS = (DiagnosisForSPTS)diagnosisSPTS.Clone();
                        diagnosisForSPTS.Prescription = inpatientPrescription;
                    }

                    InpatientDrugOrder inpatientDrugOrder = CreateInpatientDrugOrder(drugOrderIntroductionDet.DrugOrder, ObjectContext);
                    inpatientDrugOrder.InpatientPrescription = inpatientPrescription;
                    InpatientPresDetail inpatientPresDetail = new InpatientPresDetail(ObjectContext);
                    inpatientPresDetail.InpatientPrescription = inpatientPrescription;
                    inpatientPresDetail.DrugOrderIntroduction = this;
                }
            }
        }

        public static InpatientPresDetail AddInpatientPrescriptionTS(DrugOrderIntroduction drugOrderIntroduction, DrugOrderIntroductionDet drugOrderIntroductionDet)
        {
            TTObjectContext context = new TTObjectContext(false);
            InpatientPresDetail newInpatientPresDetail = null;
            if (drugOrderIntroductionDet.DrugOrder.Type == TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi"))
            {
                InpatientPrescription inpatientPrescription = null;
                foreach (InpatientPresDetail inpatientPresDetail in drugOrderIntroduction.InpatientPresDetails)
                {
                    if (inpatientPresDetail.InpatientPrescription.PrescriptionType == ((DrugDefinition)drugOrderIntroductionDet.DrugOrder.Material).PrescriptionType)
                        inpatientPrescription = inpatientPresDetail.InpatientPrescription;
                }

                if (inpatientPrescription != null)
                {
                    DrugOrder drugOrder = drugOrderIntroductionDet.DrugOrder;
                    InpatientDrugOrder inpatientDrugOrder = CreateInpatientDrugOrderTS(drugOrder, drugOrderIntroduction.DrugDescription, context);
                    inpatientPrescription.InpatientDrugOrders.Add(inpatientDrugOrder);
                }
                else
                {
                    bool gunuBirlikHastaMi = drugOrderIntroduction.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily);
                    if (gunuBirlikHastaMi)
                        throw new ApplicationException(TTUtils.CultureService.GetText("M25413", "Depo mevcudu olmayan ilaçlar için lütfen ayaktan hasta reçetesi ekranını kullanınız"));
                    inpatientPrescription = new InpatientPrescription(context);
                    inpatientPrescription.ActionDate = Common.RecTime();
                    inpatientPrescription.FillingDate = Common.RecTime();
                    inpatientPrescription.FromResource = drugOrderIntroduction.ActiveInPatientPhysicianApp.MasterResource;
                    inpatientPrescription.MasterResource = drugOrderIntroduction.ActiveInPatientPhysicianApp.MasterResource;
                    inpatientPrescription.MasterAction = drugOrderIntroduction.ActiveInPatientPhysicianApp;
                    inpatientPrescription.Episode = drugOrderIntroduction.ActiveInPatientPhysicianApp.Episode;
                    inpatientPrescription.SubEpisode = drugOrderIntroduction.ActiveInPatientPhysicianApp.SubEpisode;
                    inpatientPrescription.PrescriptionType = ((DrugDefinition)drugOrderIntroductionDet.DrugOrder.Material).PrescriptionType;
                    IList presTypeMaterialMatch = context.QueryObjects("PRESTYPEMATERIALMATCHDEF", "PRESCRIPTIONTYPE =" + ((int)inpatientPrescription.PrescriptionType).ToString());
                    if (presTypeMaterialMatch.Count > 0)
                        inpatientPrescription.CurrentStateDefID = InpatientPrescription.States.Request;
                    else
                        inpatientPrescription.CurrentStateDefID = InpatientPrescription.States.Request;
                    foreach (DiagnosisForPresc diagnosisPres in drugOrderIntroduction.DiagnosisForPrescriptions)
                    {
                        DiagnosisForPresc diagnosisForPresc = (DiagnosisForPresc)diagnosisPres.Clone();
                        diagnosisForPresc.Prescription = inpatientPrescription;
                    }

                    foreach (DiagnosisForSPTS diagnosisSPTS in drugOrderIntroduction.DiagnosisForSPTSes)
                    {
                        DiagnosisForSPTS diagnosisForSPTS = (DiagnosisForSPTS)diagnosisSPTS.Clone();
                        diagnosisForSPTS.Prescription = inpatientPrescription;
                    }

                    InpatientDrugOrder inpatientDrugOrder = CreateInpatientDrugOrderTS(drugOrderIntroductionDet.DrugOrder, drugOrderIntroduction.DrugDescription, context);
                    inpatientPrescription.InpatientDrugOrders.Add(inpatientDrugOrder);
                    newInpatientPresDetail = new InpatientPresDetail(context);
                    newInpatientPresDetail.InpatientPrescription = inpatientPrescription;
                }
            }

            return newInpatientPresDetail;
        }

        public void AddOutpatientPrescription(DrugOrderIntroductionDet drugOrderIntroductionDet)
        {
            if (drugOrderIntroductionDet.DrugOrder.Type == TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi"))
            {
                OutPatientPrescription outpatientPrescription = null;
                foreach (OutpatientPresDetail outpatientPresDetail in OutpatientPresDetails)
                {
                    if (outpatientPresDetail.OutPatientPrescription.PrescriptionType == ((DrugDefinition)drugOrderIntroductionDet.DrugOrder.Material).PrescriptionType)
                        outpatientPrescription = outpatientPresDetail.OutPatientPrescription;
                }

                if (outpatientPrescription != null)
                {
                    DrugOrder drugOrder = drugOrderIntroductionDet.DrugOrder;
                    OutPatientDrugOrder outPatientDrugOrder = CreateOutpatientDrugOrder(drugOrder, ObjectContext);
                    outPatientDrugOrder.OutPatientPrescription = outpatientPrescription;
                }
                else
                {
                    outpatientPrescription = new OutPatientPrescription(ObjectContext);
                    outpatientPrescription.ActionDate = Common.RecTime();
                    outpatientPrescription.FillingDate = Common.RecTime();
                    outpatientPrescription.FromResource = MasterResource;
                    outpatientPrescription.MasterResource = MasterResource;
                    outpatientPrescription.MasterAction = this;
                    outpatientPrescription.Episode = Episode;
                    outpatientPrescription.SubEpisode = SubEpisode;
                    outpatientPrescription.PrescriptionType = ((DrugDefinition)drugOrderIntroductionDet.DrugOrder.Material).PrescriptionType;
                    outpatientPrescription.PrescriptionSubType = PrescriptionSubTypeEnum.DailyPrescriptionSubType;
                    ResUser currentUser = Common.CurrentResource;
                    if (currentUser.GetSpeciality() != null)
                        outpatientPrescription.SpecialityDefinition = currentUser.GetSpeciality();
                    else
                        throw new Exception("Uzmanlık dalınız tanımlı olmadığı için e reçete yazamazsınız.");
                    //IList presTypeMaterialMatch = this.ObjectContext.QueryObjects("PRESTYPEMATERIALMATCHDEF", "PRESCRIPTIONTYPE =" + ((int)outpatientPrescription.PrescriptionType).ToString());
                    //if (presTypeMaterialMatch.Count > 0)
                    //{
                    //    if (outpatientPrescription.MasterResource.Store == null)
                    //        throw new TTException(outpatientPrescription.MasterResource.Name + " bölümünün deposu bulunmamaktadır. Bilgi işleme haber veriniz.");
                    //    Guid materialId = ((PresTypeMaterialMatchDef)presTypeMaterialMatch[0]).Material.ObjectID;
                    //    Guid storeId = outpatientPrescription.MasterResource.Store.ObjectID;
                    //    BindingList<PrescriptionPaper.GetPrescriptionPapersDetail_Class> prescriptionPapers = PrescriptionPaper.GetPrescriptionPapersDetail(materialId, storeId, 0);
                    //    MultiSelectForm multiSelectForm = new MultiSelectForm();
                    //    foreach (PrescriptionPaper.GetPrescriptionPapersDetail_Class m in prescriptionPapers)
                    //    {
                    //        multiSelectForm.AddMSItem(m.SerialNo + "-" + m.VolumeNo, m.ObjectID.ToString(), m);
                    //    }
                    //    String mainkey = multiSelectForm.GetMSItem(null, "Reçete Seri No Seçiniz", true, true, false, false, false, false);
                    //    if (!string.IsNullOrEmpty(mainkey))
                    //    {
                    //        PrescriptionPaper.GetPrescriptionPapersDetail_Class p = (PrescriptionPaper.GetPrescriptionPapersDetail_Class)multiSelectForm.MSSelectedItemObject;
                    //        PrescriptionPaper paper = (PrescriptionPaper)this.ObjectContext.GetObject((Guid)p.ObjectID, "PRESCRIPTIONPAPER");
                    //        outpatientPrescription.PrescriptionPaper = paper;
                    //    }
                    //    else
                    //    {
                    //        throw new TTUtils.TTException("Listeden birini seçmeniz gerekmektedir.");
                    //    }
                    //}
                    outpatientPrescription.CurrentStateDefID = OutPatientPrescription.States.Request;
                    foreach (DiagnosisForPresc diagnosisPres in DiagnosisForPrescriptions)
                    {
                        DiagnosisForPresc diagnosisForPresc = (DiagnosisForPresc)diagnosisPres.Clone();
                        diagnosisForPresc.Prescription = outpatientPrescription;
                    }

                    foreach (DiagnosisForSPTS diagnosisSPTS in DiagnosisForSPTSes)
                    {
                        DiagnosisForSPTS diagnosisForSPTS = (DiagnosisForSPTS)diagnosisSPTS.Clone();
                        diagnosisForSPTS.Prescription = outpatientPrescription;
                    }

                    OutPatientDrugOrder outPatientDrugOrder = CreateOutpatientDrugOrder(drugOrderIntroductionDet.DrugOrder, ObjectContext);
                    outPatientDrugOrder.OutPatientPrescription = outpatientPrescription;
                    OutpatientPresDetail outpatientPresDetail = new OutpatientPresDetail(ObjectContext);
                    outpatientPresDetail.OutPatientPrescription = outpatientPrescription;
                    outpatientPresDetail.DrugOrderIntroduction = this;
                }
            }
        }

        public static OutpatientPresDetail AddOutpatientPrescriptionTS(DrugOrderIntroduction drugOrderIntroduction, DrugOrderIntroductionDet drugOrderIntroductionDet)
        {
            TTObjectContext context = new TTObjectContext(false);
            OutpatientPresDetail newOutpatientPresDetail = null;
            if (drugOrderIntroductionDet.DrugOrder.Type == TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi"))
            {
                OutPatientPrescription outpatientPrescription = null;
                foreach (OutpatientPresDetail outpatientPresDetail in drugOrderIntroduction.OutpatientPresDetails)
                {
                    if (outpatientPresDetail.OutPatientPrescription.PrescriptionType == ((DrugDefinition)drugOrderIntroductionDet.DrugOrder.Material).PrescriptionType)
                        outpatientPrescription = outpatientPresDetail.OutPatientPrescription;
                }

                if (outpatientPrescription != null)
                {
                    DrugOrder drugOrder = drugOrderIntroductionDet.DrugOrder;


                    OutPatientDrugOrder outPatientDrugOrder = CreateOutpatientDrugOrderTS(drugOrder, drugOrderIntroduction.DrugUsageType, drugOrderIntroduction.DrugDescription, (PeriodUnitTypeEnum)drugOrderIntroductionDet.PeriodUnitType, (double)drugOrderIntroductionDet.PackageAmount);
                    outPatientDrugOrder.OutPatientPrescription = outpatientPrescription;
                }
                else
                {
                    outpatientPrescription = new OutPatientPrescription(context);
                    outpatientPrescription.ActionDate = Common.RecTime();
                    outpatientPrescription.FillingDate = Common.RecTime();
                    outpatientPrescription.FromResource = drugOrderIntroduction.MasterResource;
                    outpatientPrescription.MasterResource = drugOrderIntroduction.MasterResource;
                    outpatientPrescription.MasterAction = drugOrderIntroduction;
                    outpatientPrescription.Episode = drugOrderIntroduction.Episode;
                    outpatientPrescription.SubEpisode = drugOrderIntroduction.SubEpisode;
                    outpatientPrescription.PrescriptionType = ((DrugDefinition)drugOrderIntroductionDet.DrugOrder.Material).PrescriptionType;
                    outpatientPrescription.PrescriptionSubType = PrescriptionSubTypeEnum.DailyPrescriptionSubType;
                    ResUser currentUser = Common.CurrentResource;
                    if (currentUser.GetSpeciality() != null)
                        outpatientPrescription.SpecialityDefinition = currentUser.GetSpeciality();
                    else
                        throw new Exception("Uzmanlık dalınız tanımlı olmadığı için e reçete yazamazsınız.");
                    outpatientPrescription.CurrentStateDefID = OutPatientPrescription.States.Request;
                    foreach (DiagnosisForPresc diagnosisPres in drugOrderIntroduction.DiagnosisForPrescriptions)
                    {
                        DiagnosisForPresc diagnosisForPresc = (DiagnosisForPresc)diagnosisPres.Clone();
                        diagnosisForPresc.Prescription = outpatientPrescription;
                    }

                    foreach (DiagnosisForSPTS diagnosisSPTS in drugOrderIntroduction.DiagnosisForSPTSes)
                    {
                        DiagnosisForSPTS diagnosisForSPTS = (DiagnosisForSPTS)diagnosisSPTS.Clone();
                        diagnosisForSPTS.Prescription = outpatientPrescription;
                    }

                    OutPatientDrugOrder outPatientDrugOrder = CreateOutpatientDrugOrderTS(drugOrderIntroductionDet.DrugOrder, drugOrderIntroduction.DrugUsageType, drugOrderIntroduction.DrugDescription, (PeriodUnitTypeEnum)drugOrderIntroductionDet.PeriodUnitType, (double)drugOrderIntroductionDet.PackageAmount);
                    outPatientDrugOrder.OutPatientPrescription = outpatientPrescription;
                    newOutpatientPresDetail = new OutpatientPresDetail(context);
                    newOutpatientPresDetail.OutPatientPrescription = outpatientPrescription;
                }
            }

            return newOutpatientPresDetail;
        }

        public void CreateDrugOrder(DrugOrderIntroductionDet drugOrderIntroductionDet)
        {
            bool gunuBirlikHastaMi = SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily);
            DrugOrder drugOrder = new DrugOrder(drugOrderIntroductionDet.ObjectContext);
            drugOrder.IsImmediate = drugOrderIntroductionDet.IsImmediate;
            drugOrder.Material = drugOrderIntroductionDet.Material;
            drugOrder.Day = drugOrderIntroductionDet.Day;
            drugOrder.DoseAmount = drugOrderIntroductionDet.DoseAmount;
            drugOrder.Frequency = drugOrderIntroductionDet.Frequency;
            drugOrder.UsageNote = drugOrderIntroductionDet.UsageNote;
            drugOrder.PlannedStartTime = drugOrderIntroductionDet.DrugOrderIntroduction.PlannedStartTime;

            if (string.IsNullOrEmpty(DrugDescription) == false)
                drugOrder.UsageNote = drugOrder.UsageNote + " " + DrugDescription;
            if (gunuBirlikHastaMi)
            {
                drugOrder.Episode = drugOrderIntroductionDet.DrugOrderIntroduction.Episode;
                drugOrder.MasterResource = drugOrderIntroductionDet.DrugOrderIntroduction.MasterResource;
                drugOrder.SecondaryMasterResource = drugOrderIntroductionDet.DrugOrderIntroduction.SecondaryMasterResource;
                EpisodeAction fea = drugOrder.SubEpisode.PatientAdmission.FiredEpisodeActions[0];
                if (fea == null)
                    throw new TTUtils.TTException("Episode başlatan işlem alınamadı");
                drugOrder.SubEpisode = fea.SubEpisode;
            }
            else
            {
                drugOrder.Episode = drugOrderIntroductionDet.DrugOrderIntroduction.ActiveInPatientPhysicianApp.Episode;
                drugOrder.MasterResource = drugOrderIntroductionDet.DrugOrderIntroduction.ActiveInPatientPhysicianApp.MasterResource;
                drugOrder.SecondaryMasterResource = drugOrderIntroductionDet.DrugOrderIntroduction.ActiveInPatientPhysicianApp.SecondaryMasterResource;
                drugOrder.InPatientPhysicianApplication = drugOrderIntroductionDet.DrugOrderIntroduction.ActiveInPatientPhysicianApp;
            }
            drugOrder.DrugUsageType = drugOrderIntroductionDet.DrugUsageType;
            drugOrder.PatientOwnDrug = drugOrderIntroductionDet.PatientOwnDrug;
            if (DrugOrder.GetContinueDrugOrder(drugOrder.Episode.ObjectID, drugOrder.Material.ObjectID, (DateTime)drugOrder.PlannedStartTime))
            {
                if (drugOrder.DoseAmount != null)
                {
                    if (DrugOrder.GetMaxDose(drugOrder))
                    {
                        int orderDay = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("ORDERPLANNIGDAYPERIOD", "1"));
                        bool returnDateControl = DrugOrderIntroduction.OrderPlanningDateControl(drugOrder);
                        if (returnDateControl)
                        {
                            if (DrugOrder.GetMaxDoseDay(drugOrder, ((double)drugOrder.Day)))
                            {
                                DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);
                                bool inheld = false;
                                double totalAmount = 0;
                                double detailCount = DrugOrder.GetDetailCount(drugOrder.Frequency);
                                double detailTimePeriod = DrugOrder.GetDetailTimePeriod(drugOrder.Frequency);
                                double unitAmount = 0;
                                detailCount = detailCount * (double)drugOrder.Day;
                                bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                                if (drugType)
                                {
                                    unitAmount = (double)drugOrder.DoseAmount;
                                    totalAmount = unitAmount * (double)detailCount;
                                }
                                else
                                {
                                    if (drugDefinition.Volume != null)
                                    {
                                        unitAmount = (double)drugOrder.DoseAmount;
                                        totalAmount = Math.Ceiling((unitAmount / (double)drugDefinition.Volume) * (double)detailCount);
                                        if (((drugDefinition.Volume) / unitAmount) > 5)
                                        {
                                            string result = "V"; // ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Uygulama Dozu Uyarısı", drugDefinition.Name + " ilacının hacmi " + drugDefinition.Volume + " " + drugDefinition.Unit.Name.ToString() + ". Doz miktarı olarak " + unitAmount.ToString() + " " + drugDefinition.Unit.Name.ToString() + " yazmak istediğinize emin misiniz?");
                                            if (result == "V")
                                            {
                                                ((ITTObject)drugOrderIntroductionDet).Delete();
                                                throw new TTException(drugDefinition.Name + " ilacını dozunu değiştirebilirsiniz.");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ((ITTObject)drugOrderIntroductionDet).Delete();
                                        throw new TTException(drugDefinition.Name + " ilacının Hacim bilgisi girilmemiştir. İlacı yazabilmeniz için hacim bilgilerinin girilmesi gerekir. Bilgi işleme haber veriniz.");
                                    }
                                }

                                drugOrder.Amount = (double)totalAmount;

                                Store pharmacyStoreClinic = Store.GetPharmacyStore(drugOrderIntroductionDet.ObjectContext);
                                drugOrder.Store = (Store)pharmacyStoreClinic;
                                if (TTObjectClasses.SystemParameter.IsWorkWithOutStock == true)
                                {
                                    if ((bool)drugDefinition.WithOutStockInheld.HasValue)
                                    {
                                        if ((bool)drugDefinition.WithOutStockInheld)
                                        {
                                            inheld = true;
                                        }
                                        else
                                        {
                                            inheld = false;
                                        }
                                    }
                                    else
                                    {
                                        inheld = false;
                                    }
                                }
                                else
                                {
                                    if (drugOrder.Material.StockInheld(pharmacyStoreClinic) >= drugOrder.Amount)
                                    {
                                        inheld = true;
                                    }
                                    else
                                    {
                                        inheld = false;
                                    }
                                }

                                if (drugOrder.Material is MagistralPreparationDefinition == false)
                                {
                                    if (drugOrder.PatientOwnDrug.HasValue == false || drugOrder.PatientOwnDrug == false)
                                    {
                                        if (inheld)
                                        {
                                            DateTime detailTime = (DateTime)drugOrder.PlannedStartTime;
                                            drugOrder.Type = TTUtils.CultureService.GetText("M26287", "K-Çizelgesi");
                                        }
                                        else
                                        {
                                            IList equivalentDrugs = drugDefinition.GetEquivalentDrugs();
                                            if (equivalentDrugs != null)
                                            {
                                                bool equInheld = false;
                                                foreach (DrugDefinition drug in equivalentDrugs)
                                                {
                                                    if (((Material)drug).ExistingInheld(((Store)pharmacyStoreClinic)))
                                                    {
                                                        equInheld = true;
                                                        break;
                                                    }
                                                }

                                                if (equInheld)
                                                {
                                                    // TODO : Eşdeğer gösterme işlemi yapılmalı SS.
                                                    //                                                    TTVisu al.TTF orm druqEquivalentForm = new TTF rmClasses.DrugEquivalentForm();
                                                    //                                                    TTForm Classes.InPatientPhysicianApplicationForm drugOrderForm = new TTFormC lasses.InPatientPhysicianApplicationForm();
                                                    //                                                    druqEquivalentForm.ShowEdit(drugOrderForm.FindForm(), drugOrder);
                                                    //                                                    if (druqEquivalentForm.DialogResult == DialogResult.OK)
                                                    //                                                    {
                                                    //                                                        drugOrderIntroductionDet.Material = drugOrder.Material;
                                                    //                                                        if (DrugOrder.GetContinueDrugOrder(drugOrder, (DateTime)drugOrder.PlannedStartTime))
                                                    //                                                        {
                                                    //                                                            drugOrder.Type = "K-Çizelgesi";
                                                    //                                                        }
                                                    //                                                        else
                                                    //                                                        {
                                                    //                                                            ((ITTObject)drugOrderIntroductionDet).Delete();
                                                    //                                                            throw new TTException(drugDefinition.Name + " ilacı daha önce order edilmiş ve hala tedavisi devam etmektedir!!!");
                                                    //                                                        }
                                                    //                                                    }
                                                    //                                                    else
                                                    //                                                    {
                                                    drugOrder.Type = TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi");
                                                    if (drugDefinition.PrescriptionType == null)
                                                    {
                                                        ((ITTObject)drugOrderIntroductionDet).Delete();
                                                        throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26056", "ilacının reçete türü  bulunmamaktadır.\r\nYatan Hasta Reçetesi oluşturma işleminde sıkıntı yaşanmaması için lütfen ilacın reçete türünü ETKM tarafından doldurtunuz."));
                                                    }

                                                    if (drugDefinition.Barcode == null || drugDefinition.Barcode == string.Empty || drugDefinition.Barcode == "0")
                                                    {
                                                        ((ITTObject)drugOrderIntroductionDet).Delete();
                                                        throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26053", "ilacının barkodu bulunmamaktadır.\r\nE-Reçeteye gönderme işleminde sıkıntı yaşanmaması için lütfen ilacın barkodlu olanının seçiniz."));
                                                    }
                                                    //}
                                                }
                                                else
                                                {
                                                    drugOrder.Type = TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi");
                                                    if (drugDefinition.PrescriptionType == null)
                                                    {
                                                        ((ITTObject)drugOrderIntroductionDet).Delete();
                                                        throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26056", "ilacının reçete türü  bulunmamaktadır.\r\nYatan Hasta Reçetesi oluşturma işleminde sıkıntı yaşanmaması için lütfen ilacın reçete türünü ETKM tarafından doldurtunuz."));
                                                    }

                                                    if (drugDefinition.Barcode == null || drugDefinition.Barcode == string.Empty || drugDefinition.Barcode == "0")
                                                    {
                                                        ((ITTObject)drugOrderIntroductionDet).Delete();
                                                        throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26053", "ilacının barkodu bulunmamaktadır.\r\nE-Reçeteye gönderme işleminde sıkıntı yaşanmaması için lütfen ilacın barkodlu olanının seçiniz."));
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                drugOrder.Type = TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi");
                                                if (drugDefinition.PrescriptionType == null)
                                                {
                                                    ((ITTObject)drugOrderIntroductionDet).Delete();
                                                    throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26056", "ilacının reçete türü  bulunmamaktadır.\r\nYatan Hasta Reçetesi oluşturma işleminde sıkıntı yaşanmaması için lütfen ilacın reçete türünü ETKM tarafından doldurtunuz."));
                                                }

                                                if (drugDefinition.Barcode == null || drugDefinition.Barcode == string.Empty || drugDefinition.Barcode == "0")
                                                {
                                                    ((ITTObject)drugOrderIntroductionDet).Delete();
                                                    throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26053", "ilacının barkodu bulunmamaktadır.\r\nE-Reçeteye gönderme işleminde sıkıntı yaşanmaması için lütfen ilacın barkodlu olanının seçiniz."));
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        drugOrder.Type = TTUtils.CultureService.GetText("M25807", "Hasta Yanında Getirdi");
                                    }
                                }
                                else
                                {
                                    Store pharmacyStoreClinics = Store.GetPharmacyStore(drugOrderIntroductionDet.ObjectContext);
                                    if (drugOrder.Material.ExistingInheld(pharmacyStoreClinics))
                                    {
                                        drugOrder.Type = TTUtils.CultureService.GetText("M26287", "K-Çizelgesi");
                                    }
                                    else
                                    {
                                        if (drugOrder.Material.ObjectID.ToString() == TTObjectClasses.SystemParameter.GetParameterValue("MAGISTRALPRE", null))
                                        {
                                            drugOrder.Type = TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi");
                                            if (drugDefinition.PrescriptionType == null)
                                            {
                                                ((ITTObject)drugOrderIntroductionDet).Delete();
                                                throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26056", "ilacının reçete türü  bulunmamaktadır.\r\nYatan Hasta Reçetesi oluşturma işleminde sıkıntı yaşanmaması için lütfen ilacın reçete türünü ETKM tarafından doldurtunuz."));
                                            }

                                            if (drugDefinition.Barcode == null || drugDefinition.Barcode == string.Empty || drugDefinition.Barcode == "0")
                                            {
                                                ((ITTObject)drugOrderIntroductionDet).Delete();
                                                throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26053", "ilacının barkodu bulunmamaktadır.\r\nE-Reçeteye gönderme işleminde sıkıntı yaşanmaması için lütfen ilacın barkodlu olanının seçiniz."));
                                            }
                                        }
                                        else
                                        {
                                            MagistralPreparationDefinition magistral = ((MagistralPreparationDefinition)drugOrder.Material);
                                            if (magistral.Pharmacology == false)
                                            {
                                                ((ITTObject)drugOrderIntroductionDet).Delete();
                                                throw new TTException(drugDefinition.Name + " majistralinin Klinik Eczanesinde mevcudu olmadığı için yazamazsınız!");
                                            }
                                            else
                                            {
                                                drugOrder.Type = TTUtils.CultureService.GetText("M25570", "Eczacılık Birimlerinden İstenecek");
                                            }
                                        }
                                    }
                                }
                            }
                            //else
                            //{
                            //    string result = Sho wBox.Sho w(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Uygulama Dozu Uyarısı", "Bu ilacı " + drugOrder.DoseAmount.ToString() + " " + drugDefinition.Unit.Name.ToString() + " yazamazsınız!\r\nBu ilacın hacmi " + drugDefinition.Volume.ToString() + " " + drugDefinition.Unit.Name.ToString() + " olarak tanımlanmıştır.\r\n" + "Devam Etmek İstiyor Musunuz?");
                            //    if (result == "V")
                            //    {
                            //        Info Box.S ow("İlaç Dozunu değiştirebilirsiniz.", MessageIconEnum.InformationMessage );
                            //        e.Cancel = true;
                            //    }
                            // }
                            else
                            {
                                ((ITTObject)drugOrderIntroductionDet).Delete();
                                throw new TTException(drugOrder.Material.Name + " ilacı " + ((DrugDefinition)drugOrder.Material).MaxDoseDay.ToString() + " günden fazla yazılamaz !");
                            }
                        }
                        else
                        {
                            if (drugOrder.Day > 1)
                            {
                                ((ITTObject)drugOrderIntroductionDet).Delete();
                                throw new TTException(drugOrder.Material.Name + " ilacı hastaya " + orderDay.ToString() + " günden fazla yazılamaz");
                            }
                            else
                            {
                                ((ITTObject)drugOrderIntroductionDet).Delete();
                                throw new TTException(drugOrder.Material.Name + " ilacı için gün alanı boş geçilemez");
                            }
                        }
                    }
                    else
                    {
                        ((ITTObject)drugOrderIntroductionDet).Delete();
                        throw new TTException(drugOrder.Material.Name + " ilacı için uygulanmak istenen doz  " + ((DrugDefinition)drugOrder.Material).MaxDose.ToString() + " 'den fazla olamaz !");
                    }
                }
            }
            else
            {
                ((ITTObject)drugOrderIntroductionDet).Delete();
                throw new TTException(drugOrder.Material.Name + " ilacı daha önce order edilmiş ve hala tedavisi devam etmektedir!!!");
            }

            drugOrderIntroductionDet.DrugOrder = drugOrder;
        }

        public class CreateDrugOrderTSViewModel
        {
            public DrugOrder DrugOrder { get; set; }
            public List<DrugOrderDetail> DrugOrderDetails = new List<DrugOrderDetail>();
        }
        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Ilac_Direktif_Giris_Yeni, TTRoleNames.Ilac_Direktif_Giris_Tamam)]
        public static CreateDrugOrderTSViewModel CreateDrugOrderTS(
                            bool? IsImmediate,
                            Guid DrugObjectID,
                            DateTime PlannedStartTime,
                            string DrugDescription,
                            Guid EpisodeObjectID,
                            Guid MasterResourceObjectID,
                            Guid SecondaryMasterResourceObjectID,
                            Guid SubEpisodeObjectID,
                            Guid ActiveInPatientPhysicianAppObjectID,
                            bool? CaseOfNeed,
                            DrugOrderIntroductionDet drugOrderIntroductionDet)
        {
            DrugOrderIntroduction.CreateDrugOrderTSViewModel createDrugOrderTSViewModel = new DrugOrderIntroduction.CreateDrugOrderTSViewModel();
            TTObjectContext context = new TTObjectContext(false);
            DrugOrder drugOrder = new DrugOrder(context);
            drugOrder.IsImmediate = IsImmediate;
            if (drugOrderIntroductionDet.Material != null)
                drugOrder.Material = drugOrderIntroductionDet.Material;
            else
                drugOrder.Material = (DrugDefinition)context.GetObject(DrugObjectID, typeof(DrugDefinition));
            drugOrder.Day = drugOrderIntroductionDet.Day;
            drugOrder.DoseAmount = drugOrderIntroductionDet.DoseAmount;
            drugOrder.Frequency = drugOrderIntroductionDet.Frequency;
            drugOrder.UsageNote = drugOrderIntroductionDet.UsageNote;
            drugOrder.PlannedStartTime = drugOrderIntroductionDet.PlannedStartTime;
            if (string.IsNullOrEmpty(DrugDescription) == false)
                drugOrder.UsageNote = drugOrder.UsageNote + " " + DrugDescription;
            drugOrder.Description = drugOrderIntroductionDet.DrugDescription;
            drugOrder.DescriptionType = drugOrderIntroductionDet.DrugDescriptionType;

            if (drugOrderIntroductionDet.DrugUsageType != null)
            {
                drugOrder.DrugUsageType = drugOrderIntroductionDet.DrugUsageType;
            }
            else
            {
                drugOrder.DrugUsageType = ((DrugDefinition)drugOrder.Material).RouteOfAdmin.DrugUsageType;
            }

            if (drugOrderIntroductionDet.DrugOrderType != null)
            {
                drugOrder.DrugOrderType = drugOrderIntroductionDet.DrugOrderType;
            }
            else
            {
                drugOrder.DrugOrderType = DrugOrderTypeEnum.Treatment;
            }

            Episode episode = (Episode)context.GetObject(EpisodeObjectID, "Episode");

            if (episode.PatientStatus == PatientStatusEnum.Outpatient || episode.PatientStatus == PatientStatusEnum.Discharge || episode.PatientStatus == PatientStatusEnum.PreDischarge)
            {
                SubEpisode subEpisode = (SubEpisode)context.GetObject(SubEpisodeObjectID, "SubEpisode");
                ResSection MasterResource = (ResSection)context.GetObject(MasterResourceObjectID, "ResSection");
                ResSection SecondaryMasterResource = null;
                if (SecondaryMasterResourceObjectID != null && SecondaryMasterResourceObjectID != Guid.Empty)
                    SecondaryMasterResource = (ResSection)context.GetObject(SecondaryMasterResourceObjectID, "ResSection");

                drugOrder.Episode = episode;
                drugOrder.MasterResource = MasterResource;
                drugOrder.SecondaryMasterResource = SecondaryMasterResource;
                drugOrder.SubEpisode = subEpisode;
            }
            else
            {
                InPatientPhysicianApplication ActiveInPatientPhysicianApp = (InPatientPhysicianApplication)context.GetObject(ActiveInPatientPhysicianAppObjectID, "InPatientPhysicianApplication");

                if (ActiveInPatientPhysicianApp == null)
                    throw new TTException(TTUtils.CultureService.GetText("M25808", "Hasta yatan durumunda olduğu için Klinik Doktor işlemlerinde ilaç yazabilirsiniz."));
                drugOrder.Episode = ActiveInPatientPhysicianApp.Episode;
                drugOrder.MasterResource = ActiveInPatientPhysicianApp.MasterResource;
                drugOrder.SecondaryMasterResource = ActiveInPatientPhysicianApp.SecondaryMasterResource;
                drugOrder.InPatientPhysicianApplication = ActiveInPatientPhysicianApp;
                drugOrder.NursingApplication = ActiveInPatientPhysicianApp.InPatientTreatmentClinicApp.NursingApplications[0];
            }
            drugOrder.CaseOfNeed = CaseOfNeed;
            drugOrder.PatientOwnDrug = drugOrderIntroductionDet.PatientOwnDrug;
            drugOrder.DrugUsageType = drugOrderIntroductionDet.DrugUsageType;
            if (DrugOrder.GetContinueDrugOrder(drugOrder.Episode.ObjectID, drugOrder.Material.ObjectID, (DateTime)drugOrder.PlannedStartTime))
            {
                if (drugOrder.DoseAmount != null)
                {
                    if (DrugOrder.GetMaxDose(drugOrder))
                    {

                        if (DrugOrder.GetMaxDoseDay(drugOrder, ((double)drugOrder.Day)))
                        {
                            DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);
                            bool inheld = false;
                            double totalAmount = 0;
                            double detailCount = DrugOrder.GetDetailCount(drugOrder.Frequency);
                            double detailTimePeriod = DrugOrder.GetDetailTimePeriod(drugOrder.Frequency);
                            double unitAmount = 0;
                            detailCount = detailCount * (double)drugOrder.Day;
                            bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                            if (drugType)
                            {
                                unitAmount = (double)drugOrder.DoseAmount;
                                totalAmount = unitAmount * (double)detailCount;
                            }
                            else
                            {
                                if (drugDefinition.Volume != null)
                                {
                                    unitAmount = (double)drugOrder.DoseAmount;
                                    totalAmount = Math.Ceiling((unitAmount / (double)drugDefinition.Volume) * (double)detailCount);
                                    if (((drugDefinition.Volume) / unitAmount) > 5)
                                    {
                                        /* string result = "V";// ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Uygulama Dozu Uyarısı", drugDefinition.Name + " ilacının hacmi " + drugDefinition.Volume + " " + drugDefinition.Unit.Name.ToString() + ". Doz miktarı olarak " + unitAmount.ToString() + " " + drugDefinition.Unit.Name.ToString() + " yazmak istediğinize emin misiniz?");
                                            if (result == "V")
                                            {
                                                throw new TTException(drugDefinition.Name + " ilacını dozunu değiştirebilirsiniz.");
                                            }*/
                                    }
                                }
                                else
                                {
                                    throw new TTException(drugDefinition.Name + " ilacının Hacim bilgisi girilmemiştir. İlacı yazabilmeniz için hacim bilgilerinin girilmesi gerekir. Bilgi işleme haber veriniz.");
                                }
                            }

                            drugOrder.Amount = (double)totalAmount;
                            Store pharmacyStoreClinic = Store.GetPharmacyStore(context);
                            drugOrder.Store = pharmacyStoreClinic;
                            if (TTObjectClasses.SystemParameter.IsWorkWithOutStock == true)
                            {
                                if ((bool)drugDefinition.WithOutStockInheld.HasValue)
                                {
                                    if ((bool)drugDefinition.WithOutStockInheld)
                                    {
                                        inheld = true;
                                    }
                                    else
                                    {
                                        inheld = false;
                                    }
                                }
                                else
                                {
                                    inheld = false;
                                }
                            }
                            else
                            {
                                if (drugOrder.Material.StockInheld(pharmacyStoreClinic) >= drugOrder.Amount)
                                {
                                    inheld = true;
                                    DrugDefinition def = (DrugDefinition)drugOrder.Material;
                                    if (def.ShowZeroOnDrugOrder != null && def.ShowZeroOnDrugOrder.Value && episode.PatientStatus == PatientStatusEnum.Inpatient)
                                        inheld = false;
                                }
                                else
                                {
                                    inheld = false;
                                }
                            }

                            if (drugOrder.Material is MagistralPreparationDefinition == false)
                            {
                                if (drugOrder.PatientOwnDrug.HasValue == false || drugOrder.PatientOwnDrug == false)
                                {
                                    if (inheld)
                                    {
                                        DateTime detailTime = (DateTime)drugOrder.PlannedStartTime;
                                        drugOrder.Type = TTUtils.CultureService.GetText("M26287", "K-Çizelgesi");
                                    }
                                    else
                                    {
                                        IList equivalentDrugs = drugDefinition.GetEquivalentDrugs();
                                        if (equivalentDrugs != null)
                                        {
                                            bool equInheld = false;
                                            foreach (DrugDefinition drug in equivalentDrugs)
                                            {
                                                if (((Material)drug).ExistingInheld(((Store)pharmacyStoreClinic)))
                                                {
                                                    equInheld = true;
                                                    break;
                                                }
                                            }

                                            if (equInheld)
                                            {
                                                // TODO : Eşdeğer gösterme işlemi yapılmalı SS.
                                                //                                                    TTVisu al.TTF orm druqEquivalentForm = new TTF rmClasses.DrugEquivalentForm();
                                                //                                                    TTForm Classes.InPatientPhysicianApplicationForm drugOrderForm = new TTFormC lasses.InPatientPhysicianApplicationForm();
                                                //                                                    druqEquivalentForm.ShowEdit(drugOrderForm.FindForm(), drugOrder);
                                                //                                                    if (druqEquivalentForm.DialogResult == DialogResult.OK)
                                                //                                                    {
                                                //                                                        drugOrderIntroductionDet.Material = drugOrder.Material;
                                                //                                                        if (DrugOrder.GetContinueDrugOrder(drugOrder, (DateTime)drugOrder.PlannedStartTime))
                                                //                                                        {
                                                //                                                            drugOrder.Type = "K-Çizelgesi";
                                                //                                                        }
                                                //                                                        else
                                                //                                                        {
                                                //                                                            ((ITTObject)drugOrderIntroductionDet).Delete();
                                                //                                                            throw new TTException(drugDefinition.Name + " ilacı daha önce order edilmiş ve hala tedavisi devam etmektedir!!!");
                                                //                                                        }
                                                //                                                    }
                                                //                                                    else
                                                //                                                    {
                                                drugOrder.Type = TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi");
                                                if (drugDefinition.PrescriptionType == null)
                                                {
                                                    throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26055", "ilacının reçete türü  bulunmamaktadır.\r\nYatan Hasta Reçetesi oluşturma işleminde sıkıntı yaşanmaması için lütfen ilacın reçete türünü doldurtunuz."));
                                                }

                                                if (drugDefinition.Barcode == null || drugDefinition.Barcode == string.Empty || drugDefinition.Barcode == "0")
                                                {
                                                    throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26053", "ilacının barkodu bulunmamaktadır.\r\nE-Reçeteye gönderme işleminde sıkıntı yaşanmaması için lütfen ilacın barkodlu olanının seçiniz."));
                                                }
                                                //}
                                            }
                                            else if(episode.PatientStatus == PatientStatusEnum.Inpatient)
                                            {
                                                drugOrder.Type = TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi");
                                                if (drugDefinition.PrescriptionType == null)
                                                {
                                                    throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26055", "ilacının reçete türü  bulunmamaktadır.\r\nYatan Hasta Reçetesi oluşturma işleminde sıkıntı yaşanmaması için lütfen ilacın reçete türünü doldurtunuz."));
                                                }

                                                if (drugDefinition.Barcode == null || drugDefinition.Barcode == string.Empty || drugDefinition.Barcode == "0")
                                                {
                                                    throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26053", "ilacının barkodu bulunmamaktadır.\r\nE-Reçeteye gönderme işleminde sıkıntı yaşanmaması için lütfen ilacın barkodlu olanının seçiniz."));
                                                }
                                                //throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M55053", " ilaç Stokta bulunmamaktadır.\r\n"));
                                            }
                                        }
                                        else
                                        {
                                            drugOrder.Type = TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi");
                                            if (drugDefinition.PrescriptionType == null)
                                            {
                                                throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26055", "ilacının reçete türü  bulunmamaktadır.\r\nYatan Hasta Reçetesi oluşturma işleminde sıkıntı yaşanmaması için lütfen ilacın reçete türünü doldurtunuz."));
                                            }

                                            if (drugDefinition.Barcode == null || drugDefinition.Barcode == string.Empty || drugDefinition.Barcode == "0")
                                            {
                                                throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26053", "ilacının barkodu bulunmamaktadır.\r\nE-Reçeteye gönderme işleminde sıkıntı yaşanmaması için lütfen ilacın barkodlu olanının seçiniz."));
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    drugOrder.Type = TTUtils.CultureService.GetText("M25807", "Hasta Yanında Getirdi");
                                }
                            }
                            else
                            {
                                Store pharmacyStoreClinics = Store.GetPharmacyStore(context);
                                if (drugOrder.Material.ExistingInheld(pharmacyStoreClinics))
                                {
                                    drugOrder.Type = TTUtils.CultureService.GetText("M26287", "K-Çizelgesi");
                                }
                                else
                                {
                                    if (drugOrder.Material.ObjectID.ToString() == TTObjectClasses.SystemParameter.GetParameterValue("MAGISTRALPRE", null))
                                    {
                                        drugOrder.Type = TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi");
                                        if (drugDefinition.PrescriptionType == null)
                                        {
                                            throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26055", "ilacının reçete türü  bulunmamaktadır.\r\nYatan Hasta Reçetesi oluşturma işleminde sıkıntı yaşanmaması için lütfen ilacın reçete türünü doldurtunuz."));
                                        }

                                        if (drugDefinition.Barcode == null || drugDefinition.Barcode == string.Empty || drugDefinition.Barcode == "0")
                                        {
                                            throw new TTException(drugDefinition.Name + TTUtils.CultureService.GetText("M26053", "ilacının barkodu bulunmamaktadır.\r\nE-Reçeteye gönderme işleminde sıkıntı yaşanmaması için lütfen ilacın barkodlu olanının seçiniz."));
                                        }
                                    }
                                    else
                                    {
                                        MagistralPreparationDefinition magistral = ((MagistralPreparationDefinition)drugOrder.Material);
                                        if (magistral.Pharmacology == false)
                                        {
                                            throw new TTException(drugDefinition.Name + " majistralinin Klinik Eczanesinde mevcudu olmadığı için yazamazsınız!");
                                        }
                                        else
                                        {
                                            drugOrder.Type = TTUtils.CultureService.GetText("M25570", "Eczacılık Birimlerinden İstenecek");
                                        }
                                    }
                                }
                            }

                            int orderDay = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("ORDERPLANNIGDAYPERIOD", "1"));
                            bool returnDateControl = DrugOrderIntroduction.OrderPlanningDateControl(drugOrder);
                            if (returnDateControl == false)
                            {
                                if (drugOrder.Type != TTUtils.CultureService.GetText("M27216", "Yatan Hasta Reçetesi"))
                                {
                                    if (drugOrder.Day > 1)
                                    {
                                        throw new TTException(drugOrder.Material.Name + " ilacı hastaya " + orderDay.ToString() + " günden fazla yazılamaz");
                                    }
                                    else
                                    {
                                        throw new TTException(drugOrder.Material.Name + " ilacı için gün alanı boş geçilemez");
                                    }
                                }
                            }
                        }
                        //else
                        //{
                        //    string result = Sho wBox.Sho w(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Uygulama Dozu Uyarısı", "Bu ilacı " + drugOrder.DoseAmount.ToString() + " " + drugDefinition.Unit.Name.ToString() + " yazamazsınız!\r\nBu ilacın hacmi " + drugDefinition.Volume.ToString() + " " + drugDefinition.Unit.Name.ToString() + " olarak tanımlanmıştır.\r\n" + "Devam Etmek İstiyor Musunuz?");
                        //    if (result == "V")
                        //    {
                        //        Info Box.S ow("İlaç Dozunu değiştirebilirsiniz.", MessageIconEnum.InformationMessage );
                        //        e.Cancel = true;
                        //    }
                        // }
                        else
                        {
                            throw new TTException(drugOrder.Material.Name + " ilacı " + ((DrugDefinition)drugOrder.Material).MaxDoseDay.ToString() + " günden fazla yazılamaz !");
                        }
                    }
                    else
                    {
                        throw new TTException(drugOrder.Material.Name + " ilacı için Maksimum Doz miktarı: " + ((DrugDefinition)drugOrder.Material).MaxDose.ToString() + " . Maksimum Doz miktarını aşan bir order veremezsiniz.");
                    }
                }
            }
            else
            {
                throw new TTException(drugOrder.Material.Name + " ilacı daha önce order edilmiş ve hala tedavisi devam etmektedir!!!");
            }
            if (drugOrder.CaseOfNeed == true)
            {
                drugOrder.Type = TTUtils.CultureService.GetText("M26386", "Lüzumu Halinde");
                drugOrder.CurrentStateDefID = DrugOrder.States.New;
            }
            if (drugOrder.Type == TTUtils.CultureService.GetText("M26287", "K-Çizelgesi"))
            {
                if (((DrugDefinition)drugOrder.Material).InfectionApproval != true)
                {
                    DateTime detailTime = (DateTime)drugOrder.PlannedStartTime;
                    double totalAmount = 0;
                    double detailCount = DrugOrder.GetDetailCount(drugOrder.Frequency);
                    double detailTimePeriod = DrugOrder.GetDetailTimePeriod(drugOrder.Frequency);
                    double unitAmount = 0;
                    double doseAmount = 0;
                    DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);
                    detailCount = detailCount * (double)drugOrder.Day;
                    bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                    if (drugType)
                    {
                        unitAmount = (double)drugOrder.DoseAmount;
                        totalAmount = unitAmount * (double)detailCount;
                        doseAmount = (double)drugOrder.DoseAmount;
                    }
                    else
                    {
                        unitAmount = (double)drugOrder.DoseAmount;
                        totalAmount = Math.Ceiling((unitAmount / (double)drugDefinition.Volume) * (double)detailCount);
                        doseAmount = (double)drugOrder.DoseAmount * (double)drugDefinition.Dose;
                    }

                    drugOrder.Amount = (double)totalAmount;
                    bool eligible = true;
                    for (int i = 0; i < detailCount; i++)
                    {
                        DrugOrderDetail drugOrderDetail = new DrugOrderDetail(drugOrder.ObjectContext);
                        drugOrderDetail.Material = (Material)drugOrder.Material;
                        drugOrderDetail.MasterResource = drugOrder.MasterResource;
                        drugOrderDetail.FromResource = drugOrder.FromResource;
                        drugOrderDetail.Episode = drugOrder.Episode;
                        drugOrderDetail.ActionDate = drugOrder.ActionDate; // Bu actionun açıldığı tarih olmalı. SS
                        drugOrderDetail.OrderPlannedDate = detailTime;
                        detailTime = detailTime.AddHours(detailTimePeriod);
                        drugOrderDetail.Amount = unitAmount;
                        drugOrderDetail.Day = drugOrder.Day;
                        drugOrderDetail.DoseAmount = doseAmount;
                        drugOrderDetail.Frequency = drugOrder.Frequency;
                        drugOrderDetail.UsageNote = drugOrder.UsageNote;
                        drugOrderDetail.DrugOrder = drugOrder;
                        drugOrderDetail.DetailNo = i + 1;
                        drugOrderDetail.SecondaryMasterResource = drugOrder.NursingApplication.SecondaryMasterResource;
                        

                        drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                        drugOrderDetail.Eligible = eligible;
                        if (drugType == false)
                        {
                            eligible = false;
                        }

                        foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                        {
                            orderDetail.NursingApplication = drugOrder.NursingApplication;
                        }
                        createDrugOrderTSViewModel.DrugOrderDetails.Add(drugOrderDetail);
                    }

                    // Burası düzeltilmesi lazım Planned State is entry yapıldı geçici olarak. SS.
                    drugOrder.CurrentStateDefID = DrugOrder.States.Planned;
                    //Şimdi verilen Order'ın Amountu rest kalan amounttan büyük ise kalan restdose'u otomatik olarak bitirme. SS.
                    /* Dictionary<object, double> restDictionary = DrugOrderTransaction.GetPatientRestDose(drugOrder.Material, drugOrder.Episode);
                        if (restDictionary.Count > 0)
                        {
                            foreach (KeyValuePair<object, double> rest in restDictionary)
                            {
                                if (rest.Value < unitAmount)
                                {
                                    DrugOrder restDrugOrder = (DrugOrder)rest.Key;
                                    DrugDoseCompletion drugDoseCompletion = new DrugDoseCompletion(drugOrder.ObjectContext);
                                    drugDoseCompletion.MasterResource = this.MasterResource;
                                    drugDoseCompletion.FromResource = this.FromResource;
                                    drugDoseCompletion.Episode = this.Episode;
                                    drugDoseCompletion.SecondaryMasterResource = this.SecondaryMasterResource;
                                    DrugDoseCompletionDetail drugDoseCompletionDetail = new DrugDoseCompletionDetail(drugOrder.ObjectContext);
                                    drugDoseCompletionDetail.ActionDate = DateTime.Today;
                                    drugDoseCompletionDetail.Amount = rest.Value;
                                    drugDoseCompletionDetail.Day = restDrugOrder.Day;
                                    drugDoseCompletionDetail.DoseAmount = rest.Value;
                                    drugDoseCompletionDetail.DrugDone = true;
                                    drugDoseCompletionDetail.DrugOrder = restDrugOrder;
                                    drugDoseCompletionDetail.Episode = restDrugOrder.Episode;
                                    drugDoseCompletionDetail.Frequency = restDrugOrder.Frequency;
                                    drugDoseCompletionDetail.FromResource = this.FromResource;
                                    drugDoseCompletionDetail.MasterResource = this.MasterResource;
                                    drugDoseCompletionDetail.Material = restDrugOrder.Material;
                                    drugDoseCompletionDetail.OrderPlannedDate = DateTime.Today;
                                    drugDoseCompletionDetail.PackageQuantity = 1;
                                    drugDoseCompletionDetail.SecondaryMasterResource = restDrugOrder.SecondaryMasterResource;
                                    drugDoseCompletionDetail.UsageNote = restDrugOrder.UsageNote;
                                    drugDoseCompletionDetail.DrugDoseCompletion = drugDoseCompletion;
                                    drugDoseCompletion.CurrentStateDefID = new Guid(DrugDoseCompletion.States.New.ToString());
                                    drugDoseCompletionDetail.CurrentStateDefID = new Guid(DrugDoseCompletionDetail.States.Planned.ToString());
                                    DrugOrderTransaction drugOrderTransaction = new DrugOrderTransaction(drugOrder.ObjectContext);
                                    drugOrderTransaction.DrugOrder = drugDoseCompletionDetail.DrugOrder;
                                    drugOrderTransaction.DrugOrderDetail = drugDoseCompletionDetail;
                                    drugOrderTransaction.Amount = 1;
                                    drugOrderTransaction.InOut = 2;
                                    drugOrderTransaction.Volume = rest.Value;

                                    //                                    ITTObject completion = (ITTObject)drugDoseCompletion;
                                    //                                    ITTObject completionDetail = (ITTObject)drugDoseCompletionDetail;
                                    //                                    completion.SetCurrentStateDef(new Guid(DrugDoseCompletion.States.Completed.ToString()));
                                    //                                    completionDetail.SetCurrentStateDef(new Guid(DrugDoseCompletionDetail.States.Apply.ToString()));

                                }
                            }
                        }*/
                }
                else
                {
                    drugOrder.CurrentStateDefID = DrugOrder.States.Approve;
                    // TO DO : Enfeksiyon Komitesi işlemi başlatılacak.
                    InfectionCommittee infectionCommittee = new InfectionCommittee(drugOrder.ObjectContext);
                    infectionCommittee.ActionDate = Common.RecTime();
                    infectionCommittee.FromResource = drugOrder.MasterResource;
                    infectionCommittee.MasterResource = drugOrder.MasterResource;
                    infectionCommittee.Episode = drugOrder.Episode;
                    infectionCommittee.SubEpisode = drugOrder.SubEpisode;
                    infectionCommittee.InPatientPhysicianApplication = drugOrder.InPatientPhysicianApplication;
                    infectionCommittee.CurrentStateDefID = InfectionCommittee.States.New;
                    InfectionCommitteeDetail infectionCommitteeDetail = new InfectionCommitteeDetail(drugOrder.ObjectContext);
                    infectionCommitteeDetail.DrugOrder = drugOrder;
                    infectionCommitteeDetail.InfectionCommittee = infectionCommittee;
                }
            }
            else if (drugOrder.Type == TTUtils.CultureService.GetText("M25807", "Hasta Yanında Getirdi"))
            {
                DateTime detailTime = (DateTime)drugOrder.PlannedStartTime;
                double totalAmount = 0;
                double detailCount = DrugOrder.GetDetailCount(drugOrder.Frequency);
                double detailTimePeriod = DrugOrder.GetDetailTimePeriod(drugOrder.Frequency);
                double unitAmount = 0;
                double doseAmount = 0;
                DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);
                detailCount = detailCount * (double)drugOrder.Day;
                bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                if (drugType)
                {
                    unitAmount = (double)drugOrder.DoseAmount;
                    totalAmount = unitAmount * (double)detailCount;
                    doseAmount = (double)drugOrder.DoseAmount;
                }
                else
                {
                    unitAmount = (double)drugOrder.DoseAmount;
                    totalAmount = Math.Ceiling((unitAmount / (double)drugDefinition.Volume) * (double)detailCount);
                    doseAmount = (double)drugOrder.DoseAmount * (double)drugDefinition.Dose;
                }

                drugOrder.Amount = (double)totalAmount;
                bool eligible = false;
                for (int i = 0; i < detailCount; i++)
                {
                    DrugOrderDetail drugOrderDetail = new DrugOrderDetail(drugOrder.ObjectContext);
                    drugOrderDetail.Material = (Material)drugOrder.Material;
                    drugOrderDetail.MasterResource = drugOrder.MasterResource;
                    drugOrderDetail.FromResource = drugOrder.FromResource;
                    drugOrderDetail.Episode = drugOrder.Episode;
                    drugOrderDetail.ActionDate = drugOrder.ActionDate; // Bu actionun açıldığı tarih olmalı. SS
                    drugOrderDetail.OrderPlannedDate = detailTime;
                    detailTime = detailTime.AddHours(detailTimePeriod);
                    drugOrderDetail.Amount = unitAmount;
                    drugOrderDetail.Day = drugOrder.Day;
                    drugOrderDetail.DoseAmount = doseAmount;
                    drugOrderDetail.Frequency = drugOrder.Frequency;
                    drugOrderDetail.UsageNote = drugOrder.UsageNote + " (Hasta ilacı yanında getirdi)";
                    drugOrderDetail.DrugOrder = drugOrder;
                    drugOrderDetail.SecondaryMasterResource = drugOrder.NursingApplication.SecondaryMasterResource;
                    drugOrderDetail.NursingApplication = drugOrder.NursingApplication;
                    drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Planned;
                    drugOrderDetail.Eligible = eligible;
                    drugOrderDetail.DetailNo = i + 1;
                    foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                    {
                        orderDetail.NursingApplication = drugOrder.NursingApplication;
                    }

                    //drugOrderDetail.Update();
                    //drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                    createDrugOrderTSViewModel.DrugOrderDetails.Add(drugOrderDetail);
                }

                // Burası düzeltilmesi lazım Planned State is entry yapıldı geçici olarak. SS.
                drugOrder.CurrentStateDefID = DrugOrder.States.Planned;
            }
            else if (drugOrder.Type == TTUtils.CultureService.GetText("M25570", "Eczacılık Birimlerinden İstenecek"))
            {
                DateTime detailTime = (DateTime)drugOrder.PlannedStartTime;
                double totalAmount = 0;
                double detailCount = DrugOrder.GetDetailCount(drugOrder.Frequency);
                double detailTimePeriod = DrugOrder.GetDetailTimePeriod(drugOrder.Frequency);
                double unitAmount = 0;
                double doseAmount = 0;
                DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);
                detailCount = detailCount * (double)drugOrder.Day;
                bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                if (drugType)
                {
                    unitAmount = (double)drugOrder.DoseAmount;
                    totalAmount = unitAmount * (double)detailCount;
                    doseAmount = (double)drugOrder.DoseAmount;
                }
                else
                {
                    unitAmount = (double)drugOrder.DoseAmount;
                    totalAmount = Math.Ceiling((unitAmount / (double)drugDefinition.Volume) * (double)detailCount);
                    doseAmount = (double)drugOrder.DoseAmount * (double)drugDefinition.Dose;
                }

                drugOrder.Amount = (double)totalAmount;
                bool eligible = false;
                for (int i = 0; i < detailCount; i++)
                {
                    DrugOrderDetail drugOrderDetail = new DrugOrderDetail(drugOrder.ObjectContext);
                    drugOrderDetail.Material = (Material)drugOrder.Material;
                    drugOrderDetail.MasterResource = drugOrder.MasterResource;
                    drugOrderDetail.FromResource = drugOrder.FromResource;
                    drugOrderDetail.Episode = drugOrder.Episode;
                    drugOrderDetail.ActionDate = drugOrder.ActionDate; // Bu actionun açıldığı tarih olmalı. SS
                    drugOrderDetail.OrderPlannedDate = detailTime;
                    detailTime = detailTime.AddHours(detailTimePeriod);
                    drugOrderDetail.Amount = unitAmount;
                    drugOrderDetail.Day = drugOrder.Day;
                    drugOrderDetail.DoseAmount = doseAmount;
                    drugOrderDetail.Frequency = drugOrder.Frequency;
                    drugOrderDetail.UsageNote = drugOrder.UsageNote + " (Hasta ilacı yanında getirdi)";
                    drugOrderDetail.DrugOrder = drugOrder;
                    drugOrderDetail.SecondaryMasterResource = drugOrder.NursingApplication.SecondaryMasterResource;
                    drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.PharmacologyRequest;
                    drugOrderDetail.Eligible = eligible;
                    drugOrderDetail.DetailNo = i + 1;
                    drugOrderDetail.NursingApplication = drugOrder.NursingApplication;

                    foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                    {
                        orderDetail.NursingApplication = drugOrder.NursingApplication;
                    }
                    createDrugOrderTSViewModel.DrugOrderDetails.Add(drugOrderDetail);
                }

                // Burası düzeltilmesi lazım Planned State is entry yapıldı geçici olarak. SS.
                drugOrder.CurrentStateDefID = DrugOrder.States.Planned;
                Guid EczBrmGuid = new Guid("21ff7408-6eef-4feb-bc6e-e8feff3fcd3d");
                IList pharmacologyResource = Resource.GetResource(drugOrder.ObjectContext, EczBrmGuid.ToString());
                MagistralPrescription magistralPrescription = new MagistralPrescription(drugOrder.ObjectContext);
                magistralPrescription.ActionDate = Common.RecTime();
                magistralPrescription.FillingDate = Common.RecTime();
                magistralPrescription.FromResource = drugOrder.MasterResource;
                magistralPrescription.MasterResource = ((ResSection)pharmacologyResource[0]);
                magistralPrescription.Episode = drugOrder.Episode;
                magistralPrescription.DrugOrder = drugOrder;
                magistralPrescription.CurrentStateDefID = MagistralPrescription.States.Record;
                BaseTreatmentMaterial materailT = new BaseTreatmentMaterial(drugOrder.ObjectContext);
                materailT.Material = drugOrder.Material;
                materailT.Amount = drugOrder.Amount;
                materailT.Eligible = true;
                materailT.Episode = drugOrder.Episode;
                materailT.Store = ((ResSection)pharmacologyResource[0]).Store;
                materailT.UseAmount = (int)drugOrder.Amount;
                materailT.CurrentStateDefID = BaseTreatmentMaterial.States.New;
                magistralPrescription.TreatmentMaterials.Add(materailT);
            }
            createDrugOrderTSViewModel.DrugOrder = drugOrder;
            return createDrugOrderTSViewModel;
        }

        public static bool OrderPlanningDateControl(DrugOrder drugOrder)
        {
            bool returValue = false;
            if (drugOrder.Day != null)
            {
                int orderDay = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("ORDERPLANNIGDAYPERIOD", "1"));
                if (orderDay == 1)
                {
                    if (((DateTime)drugOrder.PlannedStartTime).DayOfWeek == DayOfWeek.Friday || ((DateTime)drugOrder.PlannedStartTime).DayOfWeek == DayOfWeek.Saturday)
                    {
                        if (drugOrder.Day <= 3)
                        {
                            returValue = true;
                        }
                    }
                    else
                    {
                        if (drugOrder.Day <= orderDay)
                        {
                            returValue = true;
                        }
                    }
                }
                else
                {
                    if (drugOrder.Day <= orderDay)
                    {
                        returValue = true;
                    }
                }
            }
            return returValue;
        }

        public void SendERecete()
        {
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            bool error = false;
            if (SubEpisode.IsSGK)
            {
                if (string.IsNullOrEmpty(ERecetePassword))
                    throw new TTException(" E reçete şifresi girilmedi. İşlemden vazgeçildi.");
                foreach (InpatientPresDetail presDetail in InpatientPresDetails)
                {
                    EReceteIslemleri.ereceteGirisCevapDVO response = EReceteIslemleri.WebMethods.ereceteGirisSynCall(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEReceteInputRequest(presDetail.InpatientPrescription));
                    if (response != null)
                    {
                        if (response.sonucKodu.Equals("0000"))
                        {
                            presDetail.InpatientPrescription.EReceteNo = response.ereceteDVO.ereceteNo;
                            EReceteIslemleri.ereceteOnayCevapDVO resOnay = EReceteIslemleri.WebMethods.ereceteOnay(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEreceteApprovalRequest(presDetail.InpatientPrescription));
                            if (resOnay != null)
                            {
                                if (resOnay.sonucKodu.Equals("0000"))
                                {
                                    TTUtils.InfoMessageService.Instance.ShowMessage(presDetail.InpatientPrescription.EReceteNo.ToString() + " e reçete numarası ile reçete kaydedilmiştir.");
                                    presDetail.InpatientPrescription.EReceteDescription = " E Reçete başarılı bir şekilde kaydedilmiştir.";
                                    presDetail.InpatientPrescription.ERecetePassword = ERecetePassword;
                                    if (IsRepeated.HasValue && (bool)IsRepeated.Value)
                                    {
                                        TTObjectContext context = new TTObjectContext(false);
                                        ResUser updatedUser = (ResUser)context.GetObject(currentUser.ObjectID, currentUser.ObjectDef);
                                        updatedUser.ErecetePassword = ERecetePassword;
                                        context.Save();
                                        ((ITTObject)currentUser).Refresh();
                                    }
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(resOnay.uyariMesaji))
                                    {
                                        TTUtils.InfoMessageService.Instance.ShowMessage("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :") + response.uyariMesaji);
                                        error = true;
                                    }
                                    else
                                    {
                                        TTUtils.InfoMessageService.Instance.ShowMessage("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                                        error = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(response.uyariMesaji))
                            {
                                TTUtils.InfoMessageService.Instance.ShowMessage("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :") + response.uyariMesaji);
                                error = true;
                            }
                            else
                            {
                                error = true;
                                TTUtils.InfoMessageService.Instance.ShowMessage("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                            }
                        }
                    }
                }

                if (error)
                    throw new TTException("Bazı reçetelerınizde e reçeteye yollanırken hata alınmıştır. Tekrar kontrol ediniz");
            }
        }

        public void SendDailyERecete()
        {
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            bool error = false;
            if (SubEpisode.IsSGK)
            {
                if (string.IsNullOrEmpty(ERecetePassword))
                    throw new TTException(" E reçete şifresi girilmedi. İşlemden vazgeçildi.");
                foreach (OutpatientPresDetail presDetail in OutpatientPresDetails)
                {
                    EReceteIslemleri.ereceteGirisCevapDVO response = EReceteIslemleri.WebMethods.ereceteGirisSynCall(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEReceteInputRequest(presDetail.OutPatientPrescription));
                    if (response != null)
                    {
                        if (response.sonucKodu.Equals("0000"))
                        {
                            long uniqueNo = (long)Convert.ToDouble(currentUser.UniqueNo);
                            presDetail.OutPatientPrescription.EReceteNo = response.ereceteDVO.ereceteNo;
                            EReceteIslemleri.ereceteOnayCevapDVO resOnay = EReceteIslemleri.WebMethods.ereceteOnay(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEreceteDailyPresApprovalRequest(presDetail.OutPatientPrescription, uniqueNo));
                            if (resOnay != null)
                            {
                                if (resOnay.sonucKodu.Equals("0000"))
                                {
                                    TTUtils.InfoMessageService.Instance.ShowMessage(presDetail.OutPatientPrescription.EReceteNo.ToString() + " e reçete numarası ile reçete kaydedilmiştir.");
                                    presDetail.OutPatientPrescription.EReceteDescription = " E Reçete başarılı bir şekilde kaydedilmiştir.";
                                    presDetail.OutPatientPrescription.ERecetePassword = ERecetePassword;
                                    if (IsRepeated.HasValue && (bool)IsRepeated.Value)
                                    {
                                        TTObjectContext context = new TTObjectContext(false);
                                        ResUser updatedUser = (ResUser)context.GetObject(currentUser.ObjectID, currentUser.ObjectDef);
                                        updatedUser.ErecetePassword = ERecetePassword;
                                        context.Save();
                                        ((ITTObject)currentUser).Refresh();
                                    }
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(resOnay.uyariMesaji))
                                    {
                                        TTUtils.InfoMessageService.Instance.ShowMessage("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :") + response.uyariMesaji);
                                        error = true;
                                    }
                                    else
                                    {
                                        TTUtils.InfoMessageService.Instance.ShowMessage("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                                        error = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(response.uyariMesaji))
                            {
                                TTUtils.InfoMessageService.Instance.ShowMessage("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :") + response.uyariMesaji);
                                error = true;
                            }
                            else
                            {
                                error = true;
                                TTUtils.InfoMessageService.Instance.ShowMessage("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                            }
                        }
                    }
                }

                if (error)
                    throw new TTException("Bazı reçetelerınizde e reçeteye yollanırken hata alınmıştır. Tekrar kontrol ediniz");
            }
        }

        public void SendEReceteEHUApproval()
        {
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            if (SubEpisode.IsSGK)
            {
                if (string.IsNullOrEmpty(ERecetePassword))
                    throw new TTException(" E reçete şifresi girilmedi. İşlemden vazgeçildi.");
                foreach (InpatientPresDetail presDetail in InpatientPresDetails)
                {
                    if (presDetail.InpatientPrescription.IsInfectionApproval() == false && presDetail.InpatientPrescription.IsSendEreceteEHUApproval() == true)
                    {
                        long uniqueNo = (long)Convert.ToDouble(currentUser.UniqueNo);
                        EReceteIslemleri.ereceteOnayCevapDVO ehuOnay = EReceteIslemleri.WebMethods.ereceteOnay(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEreceteEHUApprovalRequest(presDetail.InpatientPrescription, uniqueNo));
                        if (ehuOnay != null)
                        {
                            if (ehuOnay.sonucKodu.Equals("0000"))
                            {
                                TTUtils.InfoMessageService.Instance.ShowMessage(presDetail.InpatientPrescription.EReceteNo.ToString() + " e reçete numarası ile reçete EHU onayı alınmıştır.");
                                presDetail.InpatientPrescription.EReceteDescription = " E Reçete başarılı bir şekilde EHU onayı almıştır.";
                                presDetail.InpatientPrescription.EHUUniqueNo = currentUser.UniqueNo.ToString();
                                if (IsRepeated.HasValue && (bool)IsRepeated.Value)
                                {
                                    TTObjectContext context = new TTObjectContext(false);
                                    ResUser updatedUser = (ResUser)context.GetObject(currentUser.ObjectID, currentUser.ObjectDef);
                                    updatedUser.ErecetePassword = presDetail.InpatientPrescription.EHURecetePassword;
                                    context.Save();
                                    ((ITTObject)currentUser).Refresh();
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(ehuOnay.uyariMesaji))
                                    throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + ehuOnay.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :") + ehuOnay.uyariMesaji);
                                else
                                    throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + ehuOnay.sonucMesaji);
                            }
                        }
                    }
                }
            }
        }

        //        public void SendSignedERecete()
        //        {
        //            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
        //            bool error = false;
        //            if (this.Episode.IsMedulaEpisode())
        //            {
        //                if (string.IsNullOrEmpty(this.ERecetePassword))
        //                    throw new TTException(" E reçete şifresi girilmedi. İşlemden vazgeçildi.");
        //
        //                foreach (InpatientPresDetail presDetail in this.InpatientPresDetails)
        //                {
        //                    EReceteIslemleri.imzaliEreceteGirisCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteGirisSync(Sites.SiteLocalHost, Common.CurrentResource.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEReceteSignedInputRequest(presDetail.InpatientPrescription));
        //                    if (response != null)
        //                    {
        //                        if (response.sonucKodu.Equals("0000"))
        //                        {
        //                            presDetail.InpatientPrescription.EReceteNo = response.ereceteDVO.ereceteNo;
        //                            EReceteIslemleri.imzaliEreceteOnayCevapDVO resOnay = EReceteIslemleri.WebMethods.imzaliEreceteOnaySync(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEreceteSignedApprovalRequest(presDetail.InpatientPrescription));
        //                            if (resOnay != null)
        //                            {
        //                                if (resOnay.sonucKodu.Equals("0000"))
        //                                {
        //                                    InfoBox.Alert(presDetail.InpatientPrescription.EReceteNo.ToString() + " e reçete numarası ile reçete kaydedilmiştir.", MessageIconEnum.InformationMessage);
        //                                    presDetail.InpatientPrescription.EReceteDescription = " E Reçete başarılı bir şekilde kaydedilmiştir.";
        //                                    presDetail.InpatientPrescription.ERecetePassword = this.ERecetePassword;
        //                                    if (this.IsRepeated.HasValue && (bool)this.IsRepeated.Value)
        //                                    {
        //                                        TTObjectContext context = new TTObjectContext(false);
        //                                        ResUser updatedUser = (ResUser)context.GetObject(currentUser.ObjectID, currentUser.ObjectDef);
        //                                        updatedUser.ErecetePassword = this.ERecetePassword;
        //                                        context.Save();
        //                                        ((ITTObject)currentUser).Refresh();
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    if (!string.IsNullOrEmpty(resOnay.uyariMesaji))
        //                                    {
        //                                        InfoBox.Alert("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
        //                                        error = true;
        //                                    }
        //                                    else
        //                                    {
        //                                        InfoBox.Alert("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji, MessageIconEnum.ErrorMessage);
        //                                        error = true;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (!string.IsNullOrEmpty(response.uyariMesaji))
        //                            {
        //                                InfoBox.Alert("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
        //                                error = true;
        //                            }
        //                            else
        //                            {
        //                                error = true;
        //                                InfoBox.Alert("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji, MessageIconEnum.ErrorMessage);
        //                            }
        //                        }
        //                    }
        //
        //                }
        //                if (error)
        //                    throw new TTException("Bazı reçetelerınizde e reçeteye yollanırken hata alınmıştır. Tekrar kontrol ediniz");
        //            }
        //        }
        //        public void SendSignedDailyERecete()
        //        {
        //            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
        //            bool error = false;
        //            if (this.Episode.IsMedulaEpisode())
        //            {
        //                if (string.IsNullOrEmpty(this.ERecetePassword))
        //                    throw new TTException(" E reçete şifresi girilmedi. İşlemden vazgeçildi.");
        //
        //                foreach (OutpatientPresDetail presDetail in this.OutpatientPresDetails)
        //                {
        //                    EReceteIslemleri.imzaliEreceteGirisCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteGirisSync(Sites.SiteLocalHost, Common.CurrentResource.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEReceteSignedInputRequest(presDetail.OutPatientPrescription));
        //                    if (response != null)
        //                    {
        //                        if (response.sonucKodu.Equals("0000"))
        //                        {
        //                            long uniqueNo = (long)Convert.ToDouble(currentUser.UniqueNo);
        //                            presDetail.OutPatientPrescription.EReceteNo = response.ereceteDVO.ereceteNo;
        //                            EReceteIslemleri.imzaliEreceteOnayCevapDVO resOnay = EReceteIslemleri.WebMethods.imzaliEreceteOnaySync(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEreceteSignedDailyPresApprovalRequest(presDetail.OutPatientPrescription, uniqueNo));
        //                            if (resOnay != null)
        //                            {
        //                                if (resOnay.sonucKodu.Equals("0000"))
        //                                {
        //                                    InfoBox.Alert(presDetail.OutPatientPrescription.EReceteNo.ToString() + " e reçete numarası ile reçete kaydedilmiştir.", MessageIconEnum.InformationMessage);
        //                                    presDetail.OutPatientPrescription.EReceteDescription = " E Reçete başarılı bir şekilde kaydedilmiştir.";
        //                                    presDetail.OutPatientPrescription.ERecetePassword = this.ERecetePassword;
        //                                    if (this.IsRepeated.HasValue && (bool)this.IsRepeated.Value)
        //                                    {
        //                                        TTObjectContext context = new TTObjectContext(false);
        //                                        ResUser updatedUser = (ResUser)context.GetObject(currentUser.ObjectID, currentUser.ObjectDef);
        //                                        updatedUser.ErecetePassword = this.ERecetePassword;
        //                                        context.Save();
        //                                        ((ITTObject)currentUser).Refresh();
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    if (!string.IsNullOrEmpty(resOnay.uyariMesaji))
        //                                    {
        //                                        InfoBox.Alert("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
        //                                        error = true;
        //                                    }
        //                                    else
        //                                    {
        //                                        InfoBox.Alert("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji, MessageIconEnum.ErrorMessage);
        //                                        error = true;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (!string.IsNullOrEmpty(response.uyariMesaji))
        //                            {
        //                                InfoBox.Alert("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
        //                                error = true;
        //                            }
        //                            else
        //                            {
        //                                error = true;
        //                                InfoBox.Alert("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji, MessageIconEnum.ErrorMessage);
        //                            }
        //                        }
        //                    }
        //
        //                }
        //                if (error)
        //                    throw new TTException("Bazı reçetelerınizde e reçeteye yollanırken hata alınmıştır. Tekrar kontrol ediniz");
        //            }
        //        }
        //        public void SendSignedEReceteEHUApproval()
        //        {
        //            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
        //            if (this.Episode.IsMedulaEpisode())
        //            {
        //                if (string.IsNullOrEmpty(this.ERecetePassword))
        //                    throw new TTException(" E reçete şifresi girilmedi. İşlemden vazgeçildi.");
        //
        //                foreach (InpatientPresDetail presDetail in this.InpatientPresDetails)
        //                {
        //                    if (presDetail.InpatientPrescription.IsInfectionApproval() == false && presDetail.InpatientPrescription.IsSendEreceteEHUApproval() == true)
        //                    {
        //                        long uniqueNo = (long)Convert.ToDouble(currentUser.UniqueNo);
        //                        EReceteIslemleri.imzaliEreceteOnayCevapDVO ehuOnay = EReceteIslemleri.WebMethods.imzaliEreceteOnaySync(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEreceteSignedEHUApprovalRequest(presDetail.InpatientPrescription, uniqueNo));
        //                        if (ehuOnay != null)
        //                        {
        //                            if (ehuOnay.sonucKodu.Equals("0000"))
        //                            {
        //                                InfoBox.Alert(presDetail.InpatientPrescription.EReceteNo.ToString() + " e reçete numarası ile reçete EHU onayı alınmıştır.", MessageIconEnum.InformationMessage);
        //                                presDetail.InpatientPrescription.EReceteDescription = " E Reçete başarılı bir şekilde EHU onayı almıştır.";
        //                                presDetail.InpatientPrescription.EHUUniqueNo = currentUser.UniqueNo.ToString();
        //
        //                                if (this.IsRepeated.HasValue && (bool)this.IsRepeated.Value)
        //                                {
        //                                    TTObjectContext context = new TTObjectContext(false);
        //                                    ResUser updatedUser = (ResUser)context.GetObject(currentUser.ObjectID, currentUser.ObjectDef);
        //                                    updatedUser.ErecetePassword = presDetail.InpatientPrescription.EHURecetePassword;
        //                                    context.Save();
        //                                    ((ITTObject)currentUser).Refresh();
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (!string.IsNullOrEmpty(ehuOnay.uyariMesaji))
        //                                    throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + ehuOnay.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + ehuOnay.uyariMesaji);
        //                                else
        //                                    throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + ehuOnay.sonucMesaji);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        #endregion Methods
        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DrugOrderIntroduction).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == DrugOrderIntroduction.States.New && toState == DrugOrderIntroduction.States.CompletedWithSign)
                PreTransition_New2CompletedWithSign();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DrugOrderIntroduction).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == DrugOrderIntroduction.States.New && toState == DrugOrderIntroduction.States.Completed)
                PostTransition_New2Completed();
            else if (fromState == DrugOrderIntroduction.States.New && toState == DrugOrderIntroduction.States.CompletedWithSign)
                PostTransition_New2CompletedWithSign();
        }
    }
}