
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HemodialysisOrderDetail")] 

    /// <summary>
    /// Diyaliz Emrinin  Uygulanmasını Sağlayan Nesnedir
    /// </summary>
    public  partial class HemodialysisOrderDetail : SubactionProcedureFlowable
    {
        public class HemodialysisOrderDetailList : TTObjectCollection<HemodialysisOrderDetail> { }
                    
        public class ChildHemodialysisOrderDetailCollection : TTObject.TTChildObjectCollection<HemodialysisOrderDetail>
        {
            public ChildHemodialysisOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHemodialysisOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHemodialysisOrderDetailByRequest_Class : TTReportNqlObject 
        {
            public Guid? EpisodeAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEACTION"]);
                }
            }

            public Object Startdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STARTDATE"]);
                }
            }

            public Object Finishdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FINISHDATE"]);
                }
            }

            public GetHemodialysisOrderDetailByRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHemodialysisOrderDetailByRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHemodialysisOrderDetailByRequest_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Request { get { return new Guid("ee2557f6-5ada-4df9-a705-000dcc9c10ab"); } }
            public static Guid Cancelled { get { return new Guid("53d7b4d3-7a4c-4feb-a82f-331e67dfb92e"); } }
            public static Guid Completed { get { return new Guid("126a0e03-7df3-4c44-aae3-37e22c36eb72"); } }
            public static Guid Aborted { get { return new Guid("226ae753-1ee1-4ba1-904e-dd1950d6d6c5"); } }
        }

        public static BindingList<HemodialysisOrderDetail.GetHemodialysisOrderDetailByRequest_Class> GetHemodialysisOrderDetailByRequest(string REQUESTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDERDETAIL"].QueryDefs["GetHemodialysisOrderDetailByRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTOBJECTID", REQUESTOBJECTID);

            return TTReportNqlObject.QueryObjects<HemodialysisOrderDetail.GetHemodialysisOrderDetailByRequest_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HemodialysisOrderDetail.GetHemodialysisOrderDetailByRequest_Class> GetHemodialysisOrderDetailByRequest(TTObjectContext objectContext, string REQUESTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDERDETAIL"].QueryDefs["GetHemodialysisOrderDetailByRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTOBJECTID", REQUESTOBJECTID);

            return TTReportNqlObject.QueryObjects<HemodialysisOrderDetail.GetHemodialysisOrderDetailByRequest_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HemodialysisOrderDetail> GetPreviousOrderDetailByRequest(TTObjectContext objectContext, string REQUESTOBJECTID, DateTime SESSIONDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDERDETAIL"].QueryDefs["GetPreviousOrderDetailByRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTOBJECTID", REQUESTOBJECTID);
            paramList.Add("SESSIONDATE", SESSIONDATE);

            return ((ITTQuery)objectContext).QueryObjects<HemodialysisOrderDetail>(queryDef, paramList);
        }

    /// <summary>
    /// BUN Pre
    /// </summary>
        public int? BunPre
        {
            get { return (int?)this["BUNPRE"]; }
            set { this["BUNPRE"] = value; }
        }

    /// <summary>
    /// BUN Post
    /// </summary>
        public int? BunPost
        {
            get { return (int?)this["BUNPOST"]; }
            set { this["BUNPOST"] = value; }
        }

    /// <summary>
    /// URR
    /// </summary>
        public int? URR
        {
            get { return (int?)this["URR"]; }
            set { this["URR"] = value; }
        }

    /// <summary>
    /// Kt/V
    /// </summary>
        public int? Ktv
        {
            get { return (int?)this["KTV"]; }
            set { this["KTV"] = value; }
        }

    /// <summary>
    /// Etiyolojisi
    /// </summary>
        public string Etiology
        {
            get { return (string)this["ETIOLOGY"]; }
            set { this["ETIOLOGY"] = value; }
        }

    /// <summary>
    /// Öneriler
    /// </summary>
        public string Suggestions
        {
            get { return (string)this["SUGGESTIONS"]; }
            set { this["SUGGESTIONS"] = value; }
        }

    /// <summary>
    /// Heparinizasyon
    /// </summary>
        public string Heparinization
        {
            get { return (string)this["HEPARINIZATION"]; }
            set { this["HEPARINIZATION"] = value; }
        }

    /// <summary>
    /// Alerji
    /// </summary>
        public string Allergy
        {
            get { return (string)this["ALLERGY"]; }
            set { this["ALLERGY"] = value; }
        }

    /// <summary>
    /// Tanı Açıklama
    /// </summary>
        public string Diagnosis
        {
            get { return (string)this["DIAGNOSIS"]; }
            set { this["DIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Hepatit Açıklama
    /// </summary>
        public string Hepatitis
        {
            get { return (string)this["HEPATITIS"]; }
            set { this["HEPATITIS"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string GeneralInfo
        {
            get { return (string)this["GENERALINFO"]; }
            set { this["GENERALINFO"] = value; }
        }

    /// <summary>
    /// Diyalize BaşlamaTarihi
    /// </summary>
        public DateTime? SessionDate
        {
            get { return (DateTime?)this["SESSIONDATE"]; }
            set { this["SESSIONDATE"] = value; }
        }

    /// <summary>
    /// Seans Başlangıç Saati
    /// </summary>
        public DateTime? SessionStartTime
        {
            get { return (DateTime?)this["SESSIONSTARTTIME"]; }
            set { this["SESSIONSTARTTIME"] = value; }
        }

    /// <summary>
    /// Seans Bitiş Saati
    /// </summary>
        public DateTime? SessionFinishTime
        {
            get { return (DateTime?)this["SESSIONFINISHTIME"]; }
            set { this["SESSIONFINISHTIME"] = value; }
        }

    /// <summary>
    /// Cihaz
    /// </summary>
        public string Device
        {
            get { return (string)this["DEVICE"]; }
            set { this["DEVICE"] = value; }
        }

    /// <summary>
    /// Çekilecek Sıvı (ml)
    /// </summary>
        public int? Liquid
        {
            get { return (int?)this["LIQUID"]; }
            set { this["LIQUID"] = value; }
        }

    /// <summary>
    /// Diyalizat Aktarım Hızı
    /// </summary>
        public int? DialysateTransferSpeed
        {
            get { return (int?)this["DIALYSATETRANSFERSPEED"]; }
            set { this["DIALYSATETRANSFERSPEED"] = value; }
        }

    /// <summary>
    /// Durumu
    /// </summary>
        public HemodialysisStatusEnum? SessionStatus
        {
            get { return (HemodialysisStatusEnum?)(int?)this["SESSIONSTATUS"]; }
            set { this["SESSIONSTATUS"] = value; }
        }

    /// <summary>
    /// Diyaliz Sıvısı Na
    /// </summary>
        public int? LiquidNa
        {
            get { return (int?)this["LIQUIDNA"]; }
            set { this["LIQUIDNA"] = value; }
        }

    /// <summary>
    /// Diayliz Sıvısı K
    /// </summary>
        public int? LiquidK
        {
            get { return (int?)this["LIQUIDK"]; }
            set { this["LIQUIDK"] = value; }
        }

    /// <summary>
    /// Diyaliz Sıvısı Ca
    /// </summary>
        public int? LiquidCa
        {
            get { return (int?)this["LIQUIDCA"]; }
            set { this["LIQUIDCA"] = value; }
        }

    /// <summary>
    /// Diayliz Sıvısı Mg
    /// </summary>
        public int? LiquidMg
        {
            get { return (int?)this["LIQUIDMG"]; }
            set { this["LIQUIDMG"] = value; }
        }

    /// <summary>
    /// Diayliz Sıvısı Cl
    /// </summary>
        public int? LiquidCl
        {
            get { return (int?)this["LIQUIDCL"]; }
            set { this["LIQUIDCL"] = value; }
        }

    /// <summary>
    /// Diayliz Sıvısı CH3COO
    /// </summary>
        public int? LiquidCH3COO
        {
            get { return (int?)this["LIQUIDCH3COO"]; }
            set { this["LIQUIDCH3COO"] = value; }
        }

    /// <summary>
    /// Diayliz Sıvısı HCO3
    /// </summary>
        public int? LiquidHCO3
        {
            get { return (int?)this["LIQUIDHCO3"]; }
            set { this["LIQUIDHCO3"] = value; }
        }

    /// <summary>
    /// Seans Öncesi Ağırlık (KG)
    /// </summary>
        public int? WeightBefore
        {
            get { return (int?)this["WEIGHTBEFORE"]; }
            set { this["WEIGHTBEFORE"] = value; }
        }

    /// <summary>
    /// Seans Sonrası Ağırlık (KG)
    /// </summary>
        public int? WeightAfter
        {
            get { return (int?)this["WEIGHTAFTER"]; }
            set { this["WEIGHTAFTER"] = value; }
        }

    /// <summary>
    /// Katater Bakımı Yapıldı mı?
    /// </summary>
        public bool? CatheterCare
        {
            get { return (bool?)this["CATHETERCARE"]; }
            set { this["CATHETERCARE"] = value; }
        }

    /// <summary>
    /// AVF Bakımı Yapıldı mı?
    /// </summary>
        public bool? AVFCare
        {
            get { return (bool?)this["AVFCARE"]; }
            set { this["AVFCARE"] = value; }
        }

    /// <summary>
    /// Seans Açıklama
    /// </summary>
        public string Information
        {
            get { return (string)this["INFORMATION"]; }
            set { this["INFORMATION"] = value; }
        }

    /// <summary>
    /// Doktor
    /// </summary>
        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hemşire
    /// </summary>
        public ResUser Nurse
        {
            get { return (ResUser)((ITTObject)this).GetParent("NURSE"); }
            set { this["NURSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Destek Tedavi Hemşiresi
    /// </summary>
        public ResUser CareNurse
        {
            get { return (ResUser)((ITTObject)this).GetParent("CARENURSE"); }
            set { this["CARENURSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Damar Yolu
    /// </summary>
        public SKRSDamarErisimYolu Intravenous
        {
            get { return (SKRSDamarErisimYolu)((ITTObject)this).GetParent("INTRAVENOUS"); }
            set { this["INTRAVENOUS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Diyalizör Tipi
    /// </summary>
        public SKRSDiyalizorTipi DialyzatorType
        {
            get { return (SKRSDiyalizorTipi)((ITTObject)this).GetParent("DIALYZATORTYPE"); }
            set { this["DIALYZATORTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Diyalizör Alanı
    /// </summary>
        public SKRSDiyalizorAlani DialyzatorArea
        {
            get { return (SKRSDiyalizorAlani)((ITTObject)this).GetParent("DIALYZATORAREA"); }
            set { this["DIALYZATORAREA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Diyalize Girme Sıklığı
    /// </summary>
        public SKRSDiyalizeGirmeSikligi DialysisFrequency
        {
            get { return (SKRSDiyalizeGirmeSikligi)((ITTObject)this).GetParent("DIALYSISFREQUENCY"); }
            set { this["DIALYSISFREQUENCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fosfor Bağlayıcı Ajan
    /// </summary>
        public SKRSFosforBaglayiciAjan PhosphorusAgent
        {
            get { return (SKRSFosforBaglayiciAjan)((ITTObject)this).GetParent("PHOSPHORUSAGENT"); }
            set { this["PHOSPHORUSAGENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Önceki RRT Yöntemi
    /// </summary>
        public SKRSOncekiRRTYontemi PreviousRRT
        {
            get { return (SKRSOncekiRRTYontemi)((ITTObject)this).GetParent("PREVIOUSRRT"); }
            set { this["PREVIOUSRRT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sinekalset Kullanımı
    /// </summary>
        public SKRSSinekalset SinekalsetUsage
        {
            get { return (SKRSSinekalset)((ITTObject)this).GetParent("SINEKALSETUSAGE"); }
            set { this["SINEKALSETUSAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Peritoneal Gecirgenlik (PET)
    /// </summary>
        public SKRSPeritonealGecirgenlikPET PET
        {
            get { return (SKRSPeritonealGecirgenlikPET)((ITTObject)this).GetParent("PET"); }
            set { this["PET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Katater
    /// </summary>
        public SKRSKATATER Catheter
        {
            get { return (SKRSKATATER)((ITTObject)this).GetParent("CATHETER"); }
            set { this["CATHETER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kullanılan Diyaliz Tedavisi
    /// </summary>
        public SKRSKullanilanDiyalizTedavisi DialysisTreatment
        {
            get { return (SKRSKullanilanDiyalizTedavisi)((ITTObject)this).GetParent("DIALYSISTREATMENT"); }
            set { this["DIALYSISTREATMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Periton Diyalizi Kateter Tipi
    /// </summary>
        public SKRSPeritonDiyaliziKateterTipi CatheterType
        {
            get { return (SKRSPeritonDiyaliziKateterTipi)((ITTObject)this).GetParent("CATHETERTYPE"); }
            set { this["CATHETERTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Periton Diyaliz Kateter Yerleştirme Yöntemi
    /// </summary>
        public SKRSPeritonDiyalizKateterYerlestirmeYontemi CatheterInsertionMethod
        {
            get { return (SKRSPeritonDiyalizKateterYerlestirmeYontemi)((ITTObject)this).GetParent("CATHETERINSERTIONMETHOD"); }
            set { this["CATHETERINSERTIONMETHOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Periton Diyaliz Tünel Yönü
    /// </summary>
        public SKRSPeritonDiyalizTunelYonu PeritonealDialysisTunnel
        {
            get { return (SKRSPeritonDiyalizTunelYonu)((ITTObject)this).GetParent("PERITONEALDIALYSISTUNNEL"); }
            set { this["PERITONEALDIALYSISTUNNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Diyaliz Tedavi Yöntemi
    /// </summary>
        public SKRSDiyalizTedavisiYontemi DialysisTreatmentMethod
        {
            get { return (SKRSDiyalizTedavisiYontemi)((ITTObject)this).GetParent("DIALYSISTREATMENTMETHOD"); }
            set { this["DIALYSISTREATMENTMETHOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Anemi Tedavi Yöntemi
    /// </summary>
        public SKRSAnemiTedavisiYontemi AnemiaTreatmentMethod
        {
            get { return (SKRSAnemiTedavisiYontemi)((ITTObject)this).GetParent("ANEMIATREATMENTMETHOD"); }
            set { this["ANEMIATREATMENTMETHOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Aktif Vitamin D Kullanımı
    /// </summary>
        public SKRSAktifVitaminDKullanimi VitaminDusage
        {
            get { return (SKRSAktifVitaminDKullanimi)((ITTObject)this).GetParent("VITAMINDUSAGE"); }
            set { this["VITAMINDUSAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tedavinin Seyri
    /// </summary>
        public SKRSTedavininSeyri TreatmentCourse
        {
            get { return (SKRSTedavininSeyri)((ITTObject)this).GetParent("TREATMENTCOURSE"); }
            set { this["TREATMENTCOURSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tedavi Cihazı
    /// </summary>
        public ResEquipment TreatmentEquipment
        {
            get { return (ResEquipment)((ITTObject)this).GetParent("TREATMENTEQUIPMENT"); }
            set { this["TREATMENTEQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Periton Diyaliz Komplikasyon
    /// </summary>
        public SKRSPeritonDiyaliziKomplikasyon PeritonealComplication
        {
            get { return (SKRSPeritonDiyaliziKomplikasyon)((ITTObject)this).GetParent("PERITONEALCOMPLICATION"); }
            set { this["PERITONEALCOMPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Antihipertansif İlaç Kullanımı
    /// </summary>
        public SKRSAntihipertansifIlacKullanimDurumu Antihypertensive
        {
            get { return (SKRSAntihipertansifIlacKullanimDurumu)((ITTObject)this).GetParent("ANTIHYPERTENSIVE"); }
            set { this["ANTIHYPERTENSIVE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kan Akım Hız Aralığı (ml/dk)
    /// </summary>
        public SKRSKanAkimHizi BloodFlow
        {
            get { return (SKRSKanAkimHizi)((ITTObject)this).GetParent("BLOODFLOW"); }
            set { this["BLOODFLOW"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HemodialysisRequest HemodialysisRequest
        {
            get 
            {   
                if (EpisodeAction is HemodialysisRequest)
                    return (HemodialysisRequest)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

    /// <summary>
    /// Emir Detayları
    /// </summary>
        public HemodialysisOrder HemodialysisOrder
        {
            get 
            {   
                if (OrderObject is HemodialysisOrder)
                    return (HemodialysisOrder)OrderObject; 
                return null;
            }            
            set { OrderObject = value; }
        }

        protected HemodialysisOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HemodialysisOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HemodialysisOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HemodialysisOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HemodialysisOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEMODIALYSISORDERDETAIL", dataRow) { }
        protected HemodialysisOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEMODIALYSISORDERDETAIL", dataRow, isImported) { }
        public HemodialysisOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HemodialysisOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HemodialysisOrderDetail() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}