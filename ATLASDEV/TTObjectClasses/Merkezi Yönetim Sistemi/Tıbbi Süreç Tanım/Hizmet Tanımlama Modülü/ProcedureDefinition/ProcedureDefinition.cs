
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
    /// Hizmet Tanımı
    /// </summary>
    public partial class ProcedureDefinition : TerminologyManagerDef, ISUTRulableProcedure
    {
        public partial class GetProcedureDefinitionListDefinition_Class : TTReportNqlObject
        {
        }

        public partial class GetProcedureWithNoEffectivePrice_Class : TTReportNqlObject
        {
        }

        public partial class GetProcedureWithMultiEffectivePriceByPriceList_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetProcedures_Class : TTReportNqlObject
        {
        }

        public partial class GetProcedureDefForProcedureRequest_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetProcedures_WithDate_Class : TTReportNqlObject
        {
        }

        public partial class VEM_HIZMET_Class : TTReportNqlObject
        {
        }

        public string MySUTCode
        {
            get
            {
                try
                {
                    #region SUTCode_GetScript      

                    if (!string.IsNullOrEmpty(SUTCode) && !string.IsNullOrEmpty(SUTCode.Trim()))
                        return SUTCode;

                    if (Code.Contains("."))
                        return Code.Substring(0, Code.IndexOf("."));

                    return Code;

                    #endregion SUTCode_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "SUTCode") + " : " + ex.Message, ex);
                }
            }
        }

        #region Methods
        protected override void PostInsert()
        {
            base.PostInsert();
            CreateProcedurePricesForNewProcedure();
        }

        protected override void PreInsert()
        {
            base.PreInsert();
            SetProcedureType();
            Common.SohaRuleRuleRepositoryChanged(ObjectContext, SohaRuleRepoTypeEnum.ProcedureDefRepository);
        }

        protected override void PreUpdate()
        {
            base.PreUpdate();
            if (this.HasMemberChanged("SUTCODE") || this.HasMemberChanged("NAME"))
                Common.SohaRuleRuleRepositoryChanged(ObjectContext, SohaRuleRepoTypeEnum.ProcedureDefRepository);
        }


        public void CreateProcedurePricesForNewProcedure()
        {
            if (!string.IsNullOrWhiteSpace(SUTCode))
            {
                string currentDate = Common.RecTime().ToString("yyyy-MM-dd HH:mm:ss");
                List<ProcedurePriceDefinition> procedurePriceList = ObjectContext.QueryObjects<ProcedurePriceDefinition>(" PROCEDUREOBJECT.ISACTIVE = 1 AND PROCEDUREOBJECT.SUTCODE = '" + SUTCode + "' AND PROCEDUREOBJECT.OBJECTID <> '" + ObjectID + "' AND PRICINGDETAIL.DATESTART < TODATE('" + currentDate + "') AND PRICINGDETAIL.DATEEND > TODATE('" + currentDate + "')").ToList();
                List<PricingDetailDefinition> pricingDetailDefinitionList = new List<PricingDetailDefinition>();
                foreach (ProcedurePriceDefinition item in procedurePriceList)
                {
                    if (!pricingDetailDefinitionList.Any(x => x.ObjectID == item.PricingDetail.ObjectID) && !ProcedurePrice.Any(x => x.PricingDetail.ObjectID == item.PricingDetail.ObjectID))
                        pricingDetailDefinitionList.Add(item.PricingDetail);
                }

                foreach (PricingDetailDefinition pricingDet in pricingDetailDefinitionList)
                {
                    ProcedurePriceDefinition procedurePriceDefinition = new ProcedurePriceDefinition(ObjectContext);
                    procedurePriceDefinition.ProcedureObject = this;
                    procedurePriceDefinition.PricingDetail = pricingDet;
                }
            }
        }
        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNameList = base.GetMyLocalPropertyNamesList();
            if (localPropertyNameList == null)
                localPropertyNameList = new List<string>();
            localPropertyNameList.Add("CREATEINMEDULADONTSENDSTATE");
            localPropertyNameList.Add("DOCTOR");
            return localPropertyNameList;
        }
        public ArrayList GetProcedurePricingDetail(PricingListDefinition pPricingList, DateTime? pDate)
        {
            return GetProcedurePricingDetail(this, pPricingList, pDate);
        }

        public static ArrayList GetProcedurePricingDetail(ProcedureDefinition procedureDefinition, PricingListDefinition pPricingList, DateTime? pDate)
        {
            ArrayList procPriceList = new ArrayList();
            PricingDetailDefinition firstPrice = null;
            if (pDate == null)
            {
                foreach (ProcedurePriceDefinition pp in procedureDefinition.ProcedurePrice)
                {
                    if (pp.PricingDetail.PricingList.ObjectID == pPricingList.ObjectID)
                    {
                        if (firstPrice == null)
                        {
                            procPriceList.Add(pp.PricingDetail);
                            firstPrice = pp.PricingDetail;
                        }
                        else
                        {
                            if (pp.PricingDetail.ObjectID != firstPrice.ObjectID)
                                throw new TTException(SystemMessage.GetMessageV3(557, new string[] { procedureDefinition.Code, procedureDefinition.Name }));
                        }
                    }
                }
            }
            else
            {
                foreach (ProcedurePriceDefinition pp in procedureDefinition.ProcedurePrice)
                {
                    if ((pp.PricingDetail.PricingList.ObjectID == pPricingList.ObjectID) && (pp.PricingDetail.DateStart <= pDate) && (pDate <= pp.PricingDetail.DateEnd))
                    {
                        if (firstPrice == null)
                        {
                            procPriceList.Add(pp.PricingDetail);
                            firstPrice = pp.PricingDetail;
                        }
                        else
                        {
                            if (pp.PricingDetail.ObjectID != firstPrice.ObjectID)
                                throw new TTException(SystemMessage.GetMessageV3(557, new string[] { procedureDefinition.Code, procedureDefinition.Name }));

                        }
                    }
                }
            }
            return procPriceList;
        }

        public ArrayList GetProcedurePricingDetail(PricingListDefinition pPricingList)
        {
            return GetProcedurePricingDetail(pPricingList, null);
        }

        public ArrayList GetProcedurePricingDetails(DateTime? pDate)
        {
            ArrayList procPriceList = new ArrayList();
            if (pDate == null)
            {
                foreach (ProcedurePriceDefinition pp in ProcedurePrice)
                {
                    procPriceList.Add(pp.PricingDetail);
                }
            }
            else
            {
                foreach (ProcedurePriceDefinition pp in ProcedurePrice)
                {
                    if (pp.PricingDetail.DateStart <= pDate && pDate <= pp.PricingDetail.DateEnd)
                    {
                        procPriceList.Add(pp.PricingDetail);
                    }
                }
            }
            return procPriceList;
        }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObject = this as ITTObject;
            if (theObject.IsNew)
            {
                ID.GetNextValue();
            }
        }

        public static ProcedureDefinition GetActiveByCode(TTObjectContext context, string Code)
        {
            IList procedureList = ProcedureDefinition.GetByCode(context, Code.Trim(), " AND ISACTIVE = 1");
            if (procedureList.Count == 0)
                return null;
            return (ProcedureDefinition)procedureList[0];
        }

        public double GetSUTPoint()
        {
            return ProcedureDefinition.GetSUTPoint(this);
        }



        public static double GetSUTPointByProcedureObjectId(Guid procedureObjId)
        {
            TTObjectContext readOnlyObjectContext = new TTObjectContext(true);
            ProcedureDefinition procedureDef = (ProcedureDefinition)readOnlyObjectContext.GetObject(procedureObjId, "ProcedureDefinition");
            return GetSUTPoint(procedureDef);
        }

        public static double GetSUTPoint(ProcedureDefinition procedureDef)
        {
            int priceCount = 0;
            double point = 0;
            TTObjectContext ctxRO = new TTObjectContext(true);
            ArrayList pricingDetailList = new ArrayList();

            PricingListDefinition SUTPriceList = null;
            SUTPriceList = (PricingListDefinition)PricingListDefinition.GetByObjectID(ctxRO, SystemParameter.GetParameterValue("SUTPRICELISTOBJECTID", "47466669-d190-4d13-af74-21a23d8a5ddb").ToString())[0];

            pricingDetailList = procedureDef.GetProcedurePricingDetail(SUTPriceList, DateTime.Now);

            foreach (PricingDetailDefinition pp in pricingDetailList)
            {
                if (pp.Point != null)
                    point = (double)pp.Point;

                priceCount++;
            }

            if (priceCount == 0)
                throw new TTException(SystemMessage.GetMessageV3(558, new string[] { procedureDef.Code, procedureDef.Name }));

            if (priceCount > 1)
                throw new TTException(SystemMessage.GetMessageV3(559, new string[] { procedureDef.Code, procedureDef.Name }));

            if (point == 0)
                throw new TTException(SystemMessage.GetMessageV3(560, new string[] { procedureDef.Code, procedureDef.Name }));

            return point;
        }
        public RevenueSubAccountCodeDefinition GetRevenueSubAccountCode()
        {
            if (RevenueSubAccountCode != null)
                return RevenueSubAccountCode;
            else
            {
                if (ProcedureTree != null)
                    return ProcedureTree.GetRevenueSubAccountCode();
                else
                    return null;
            }
        }

        public override string ToString()
        {
            return Code + "-" + Name ?? base.ToString();
        }

        public bool GetIsRuleExist()
        {
            if (ProcedureRuleSets.Select(string.Empty).Count > 0)
                return true;
            else
                return false;
        }

        public List<RuleBase> GetSuitableRules(DateTime actionDate, ISUTInstance currentInstance)
        {
            List<RuleBase> retValue = new List<RuleBase>();

            foreach (RuleBase rule in GetAvailableRules(actionDate))
            {
                if (rule.IsActive.HasValue && rule.IsActive.Value)
                {
                    if (rule.IsSuitable(actionDate, currentInstance))
                        retValue.Add(rule);
                }
            }
            return retValue;
        }

        public List<RuleBase> GetAvailableRules(DateTime actionDate)
        {
            List<RuleBase> retValue = new List<RuleBase>();
            TTObjectContext readOnlyObjectContext = new TTObjectContext(true);
            IList ruleObjectIDs = RuleBase.GetAvailableRules(readOnlyObjectContext, actionDate, " AND RULESETRULES.RULESET.PROCEDURERULESETS.PROCEDUREOBJECT = " + ConnectionManager.GuidToString(ObjectID));
            if (ruleObjectIDs.Count > 0)
            {
                string filterExpression = string.Empty;
                filterExpression += " WHERE OBJECTID IN(";
                int i = 1;
                foreach (RuleBase.GetAvailableRules_Class o in ruleObjectIDs)
                {
                    if (o.Ruleobjectid.HasValue)
                    {
                        filterExpression += ConnectionManager.GuidToString(o.Ruleobjectid.Value);
                        if (i < ruleObjectIDs.Count)
                            filterExpression += ",";
                    }
                    i++;
                }
                filterExpression += ")";
                retValue.AddRange(RuleBase.GetRules(readOnlyObjectContext, filterExpression));
            }
            return retValue;
        }

        public List<RuleBase.RuleResult> RunRules(DateTime actionDate, ISUTInstance currentInstance)
        {
            List<RuleBase.RuleResult> ruleResults = new List<RuleBase.RuleResult>();

            if (GetIsRuleExist())
            {
                List<RuleBase> suitableRules = GetSuitableRules(actionDate, currentInstance);
                if (suitableRules.Count > 0)
                {
                    foreach (RuleBase ruleBase in suitableRules)
                        ruleResults.AddRange(ruleBase.RunRule(actionDate, currentInstance));
                }
                else
                {
                    TTObjectContext objectContext = new TTObjectContext(false);
                    GlobalRule globalRule = new GlobalRule(objectContext);
                    globalRule.IsWarningOnly = false;
                    globalRule.Name = "HİZMET BULUNAMAYAN UYGUN KURAL";
                    globalRule.Result = TTUtils.CultureService.GetText("M25963", "Hizmete ait ödemeye uygun kural bulunamadığından işleme devam edemezsiniz.");

                    foreach (RuleBase rule in GetAvailableRules(actionDate))
                        globalRule.Result += "\r\n" + rule.Result;

                    globalRule.IsActive = true;

                    ruleResults.Add(new RuleBase.RuleResult(this, globalRule, string.Empty));
                }
            }

            return ruleResults;
        }

        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.ProcedureInfo;
        }

        public Currency? GetProcedurePrice(SubEpisodeProtocol sep, DateTime? processDate = null)
        {
            try
            {
                if (sep != null)
                {
                    DateTime? date;
                    if (processDate != null)
                        date = processDate;
                    else
                        date = Common.RecTime();

                    ArrayList col = new ArrayList();
                    col = sep.Protocol.CalculatePrice(this, sep.SubEpisode.Episode.PatientStatus, null, date, sep.SubEpisode.Episode.Patient.AgeCompleted);
                    foreach (ManipulatedPrice mpd in col)
                        return mpd.Price;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Hem Manager üstünden hem ATLAS üstünden çalışabilmesi için böyle bir kod yazılması gerekti
        /// </summary>
        public virtual void SetProcedureType()
        {
            if (ProcedureType != null && ProcedureType != ProcedureDefGroupEnum.muayeneBilgisi && ProcedureType != ProcedureDefGroupEnum.konsultasyonBilgileri && ProcedureType != ProcedureDefGroupEnum.hastaYatisBilgileri)
            {
                throw new Exception("Hizmet Türü olarak sadece \'Muayene\',\'Konsültasyon\' ve \'Hasta Yatış\' seçebilirsiniz.");
            }

        }

        /*
        public override bool GetMyChildTerminologyManagerDefs()
        {
            return false;
        }
        
        // TerminologyManagerDef te paketi hazırlayan method override edilmiştir. Kendisi ve SubProcedureDefinition olan child ları gönderiliyor.
        public override List<TTObject> GetMyDefinitionPackage()
        {
            List<TTObject> package = base.GetMyDefinitionPackage();
            
            foreach(SubProcedureDefinition sp in this.SubProcedureDefinitions)
            {
                if (!package.Contains(sp))
                    package.Add(sp);
            }
            
            return package;
        }
        */

        /// <summary>
        /// ActionTypedan Seçilen Enum değerine karşılık gelen EpisodeAction Kullandığı SubactionProcedureleri bulup Adlarını String olarak döndürür
        /// <summary>
        public static string GetProcedureDefinitionNames(ActionTypeEnum actionType)
        {
            string procedureDefNames = "";
            string objectDefName = actionType.ToString().ToUpperInvariant();
            if (actionType == ActionTypeEnum.ManipulationRequest)
                objectDefName = "MANIPULATION";
            TTObjectDef objDef = null;
            TTObjectDefManager.Instance.ObjectDefs.TryGetValue(objectDefName, out objDef);
            if (objDef != null)
            {
                if (objDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant()))
                {
                    foreach (TTObjectRelationSubtypeDef rSubType in objDef.AllChildRelationsSubtypeDefs)
                    {
                        if (rSubType.RelationDef.ParentObjectDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant()) && rSubType.RelationDef.ChildObjectDef.IsOfType(typeof(SubActionProcedure).Name.ToUpperInvariant()))
                        {
                            if (rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.Name.ToUpperInvariant() != "PROCEDUREDEFINITION")
                            {
                                if (procedureDefNames != "")
                                    procedureDefNames = procedureDefNames + ",";
                                procedureDefNames = procedureDefNames + "'" + rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.Name.ToUpperInvariant() + "'";
                            }
                            foreach (TTRelationParentRestrictions parentRestriction in rSubType.ChildObjectDef.ParentRelationRestrictions)
                            {
                                if (parentRestriction.RelationDef.ParentObjectDef.IsOfType(typeof(ProcedureDefinition).Name.ToUpperInvariant()))
                                {
                                    foreach (TTObjectDef restrictedObject in parentRestriction.RestrictedObjectDefs)
                                    {
                                        if (procedureDefNames != "")
                                            procedureDefNames = procedureDefNames + ",";
                                        procedureDefNames = procedureDefNames + "'" + restrictedObject.Name.ToUpperInvariant() + "'";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return procedureDefNames;
        }

        public PackageProcedureDefinition MyPackageProcedure()
        {
            PackageProcedureDefinition packageProcedure = PackageProcedure;

            if (packageProcedure == null)
            {
                ProcedureDefinition procedure = ProcedureDefinition.GetActiveByCode(ObjectContext, "P" + Code);
                if (procedure != null)
                {
                    packageProcedure = procedure as PackageProcedureDefinition;
                    if (packageProcedure == null)
                        throw new TTException("Paket hizmet bulunurken hata alındı. " + procedure.Code + " " + procedure.Name + " hizmeti Paket Hizmet olarak tanımlı değil.");
                }
            }

            return packageProcedure;
        }

        public string SUTPriceCode()
        {
            List<PricingDetailDefinition> priceList = new List<PricingDetailDefinition>();

            foreach (ProcedurePriceDefinition ppd in ProcedurePrice)
            {
                if (ppd.PricingDetail.PricingList.ObjectID.ToString() == SystemParameter.GetParameterValue("SUTPRICELISTOBJECTID", "47466669-d190-4d13-af74-21a23d8a5ddb"))
                    priceList.Add(ppd.PricingDetail);
            }

            if (priceList.Count > 0)
                return priceList.OrderByDescending(x => x.DateStart).Select(x => x.ExternalCode).FirstOrDefault();

            return null;
        }

        public bool IsMR
        {
            get
            {
                RadiologyTestDefinition radiologyTestDefinition = this as RadiologyTestDefinition;
                if (radiologyTestDefinition != null && radiologyTestDefinition.TestType != null) // Tetkik türü bilgisi dolu ise buradan bakılır
                {
                    if (radiologyTestDefinition.TestType.Name == "MR") // Tetkik türü MR
                        return true;
                    else
                        return false;
                }

                if (this?.ProcedureTree?.ObjectID == new Guid("6edf2225-4b77-47a2-9686-61f8c441084e")) // MR Hizmet Grubu ObjectID
                    return true;

                return false;
            }
        }

        public bool IsBT
        {
            get
            {
                RadiologyTestDefinition radiologyTestDefinition = this as RadiologyTestDefinition;
                if (radiologyTestDefinition != null && radiologyTestDefinition.TestType != null) // Tetkik türü bilgisi dolu ise buradan bakılır
                {
                    if (radiologyTestDefinition.TestType.Name == "CT") // Tetkik türü BT (Radyoloji Tetkik Tür Tanımlarındaki adı CT)
                        return true;
                    else
                        return false;
                }

                if (this?.ProcedureTree?.ObjectID == new Guid("100b4e9a-2089-4d69-a88b-370306c42d43")) // BT Hizmet Grubu ObjectID
                    return true;

                return false;
            }
        }

        public string GetName()
        {
            return Name;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }

        // Hasta Muayenesi Hizmeti ObjectId 
        public static Guid ExaminationProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("PATIENTEXAMINATIONCODE", "76de574b-3d89-455c-a71f-42e03e32a657").Trim()); }
        }

        // Acil Poliklinik Muayenesi Hizmeti ObjectId 
        public static Guid EmergencyExaminationProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("PATIENTEMERGENCYEXAMINATIONCODE", "388c4794-8abd-4823-bbce-f15a8e1b8b67").Trim()); }
        }

        // Yeşil Alan Muayenesi Hizmeti ObjectId 
        public static Guid GreenAreaExaminationProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("GREENAREAEXAMINATIONCODE", "38f84237-f1e1-4339-9eb7-dc17fbf5e9fd").Trim()); }
        }

        // Konsültasyon Hizmeti ObjectId 
        public static Guid ConsultationProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("CONSULTATIONEXAMINATIONCODE", "b7ae759e-e2a2-4a8c-93f8-3219c7446052").Trim()); }
        }

        // Yatan Konsültasyon Hizmeti ObjectId 
        public static Guid InpatientConsultationProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("INPATIENTCONSULTATIONEXAMINATIONCODE", "d9273932-77ec-4abd-b8a7-7395c0a2d523").Trim()); }
        }

        // Acil Konsültasyon Hizmeti ObjectId 
        public static Guid EmergencyConsultationProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("EMERGENCYCONSULTATIONEXAMINATIONCODE", "a52cb70c-b866-4318-9e34-0e3ee2672686").Trim()); }
        }

        // Dışarıdan Gelen Konsültasyon Hizmeti ObjectId 
        public static Guid ExternalConsultationProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("EXTERNALCONSULTATIONEXAMINATIONCODE", "0b16a29d-b6ec-46ff-ab0d-c40b01f89696").Trim()); }
        }

        // Diş Muayenesi Hizmeti ObjectId 
        public static Guid DentalExaminationProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("DENTALEXAMINATIONCODE", "68c1874d-5af8-4d02-8d8c-eb9a1d38c708").Trim()); }
        }

        // Diş Konsültasyon Hizmeti ObjectId 
        public static Guid DentalConsultationProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("DENTALCONSULTATIONCODE", "f8641184-7a6c-41b1-bc68-e339728d4dc8").Trim()); }
        }

        // Kontrol Muayenesi Hizmeti ObjectId 
        public static Guid FollowUpExaminationProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("FOLLOWUPEXAMINATIONCODE", "3697662e-85d6-4ee3-89c2-fe9c31c7878a").Trim()); }
        }

        // Sağlık Kurulu Raporu Paket Hizmeti ObjectId 
        public static Guid HCPackageProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("HCPACKAGEPROCEDURECODE", "c3edc78c-211c-46b0-a051-4ce27e67ac22").Trim()); }
        }

        // Silah Ruhsatı İçin Sağlık Kurulu Raporu Paket Hizmeti ObjectId 
        public static Guid HCGunLicensePackageProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("HCPACKAGEPROCEDURECODEGUNLICENSE", "18e1a313-7730-4814-ae4c-fd118ee34118").Trim()); }
        }

        // Tek Hekim Sağlık Raporu Paket Hizmeti ObjectId 
        public static Guid HCOneDoctorPackageProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("HCPACKAGEPROCEDURECODEONEDOCTOR", "bc286454-56b4-40e2-aa7c-fc7b0f165f53").Trim()); }
        }

        // Sağlık Kurulu Raporu Hizmeti ObjectId 
        public static Guid HCReportProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("HEALTHCOMMITTEECODE", "984a60aa-40a7-4dcb-ab71-0ab435adc4d0").Trim()); }
        }

        // Muayene Katılım Payı Hizmeti ObjectId 
        public static Guid ExaminationParticipationProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("PATIENTEXAMINATIONPARTICIPATIONCODE", "2b172bac-3bb5-4f1d-8e44-af7fe95eec3c").Trim()); }
        }

        // Gündüz Yatak Hizmeti ObjectId 
        public static Guid DailyBedProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("DAILYBEDPROCEDUREDEFINIONID", "d15c2d28-d4ed-4add-9b25-7c813049fe3b").Trim()); }
        }

        // Gündüz Yatak Hizmeti SUT Kodu 
        public static string DailyBedProcedureSUTCode
        {
            get { return SystemParameter.GetParameterValue("DAILYBEDPROCEDURESUTCODE", "510120").Trim(); }
        }

        // Refakatçi Hizmeti ObjectId 
        public static Guid CompanionProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("COMPANIONAPPLICATIONPROCEDURE", "3be83fb8-21d7-4a94-84f4-c0d1cd10ee4a").Trim()); }
        }

        // Bağış Hizmeti ObjectId
        public static Guid DonationProcedureObjectId
        {
            get { return new Guid(SystemParameter.GetParameterValue("DONATIONPROCEDUREGUID", "616c7540-ca19-4071-9baf-8930e02adc59").Trim()); }
        }

        // Sezaryen Hizmeti ObjectId
        public static Guid CesaseanProcedureObjectID
        {
            get { return new Guid(SystemParameter.GetParameterValue("CesaseanProcedureObjID", "cabf0888-af57-4cd4-b668-d261c195618a").Trim()); }
        }

        // Yoğun Bakım Hizmeti ObjectId
        public static Guid IntensiveCareProcedureObjectID
        {
            get { return new Guid(SystemParameter.GetParameterValue("IntensiveCareProcedureObjectID", "fa4778a8-fb24-4ecf-a746-a8d58a70b8fc").Trim()); }
        }

        #endregion Methods

    }
}