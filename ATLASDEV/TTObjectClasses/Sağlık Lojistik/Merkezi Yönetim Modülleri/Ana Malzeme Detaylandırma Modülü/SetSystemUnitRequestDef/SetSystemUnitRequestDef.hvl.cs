
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SetSystemUnitRequestDef")] 

    /// <summary>
    /// Set Sistem Ünite Tanımlama
    /// </summary>
    public  partial class SetSystemUnitRequestDef : BaseCentralAction
    {
        public class SetSystemUnitRequestDefList : TTObjectCollection<SetSystemUnitRequestDef> { }
                    
        public class ChildSetSystemUnitRequestDefCollection : TTObject.TTChildObjectCollection<SetSystemUnitRequestDef>
        {
            public ChildSetSystemUnitRequestDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSetSystemUnitRequestDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("143d41a2-e842-4064-a507-8c7e1a40e5de"); } }
    /// <summary>
    /// 1.Aşama
    /// </summary>
            public static Guid StateOne { get { return new Guid("e9ac9b73-cafc-429e-8aa2-f3e8eae9a116"); } }
    /// <summary>
    /// 2.Aşama
    /// </summary>
            public static Guid StateTwo { get { return new Guid("e536343c-a06f-496b-8831-246c009ad087"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("47b74ebe-6aef-4dec-92fd-44083e1d3406"); } }
    /// <summary>
    /// 3.Aşama
    /// </summary>
            public static Guid StateThree { get { return new Guid("b118c220-2e3e-4fc4-9537-06c4a12d7c50"); } }
        }

    /// <summary>
    ///  Set/Sistem/Ünite Tipi
    /// </summary>
        public DetailSetUnitEnum? DetailSetUnitType
        {
            get { return (DetailSetUnitEnum?)(int?)this["DETAILSETUNITTYPE"]; }
            set { this["DETAILSETUNITTYPE"] = value; }
        }

    /// <summary>
    /// Barkod Durumu
    /// </summary>
        public VarYokEnum? BarcodeStatus
        {
            get { return (VarYokEnum?)(int?)this["BARCODESTATUS"]; }
            set { this["BARCODESTATUS"] = value; }
        }

        public string Barcode
        {
            get { return (string)this["BARCODE"]; }
            set { this["BARCODE"] = value; }
        }

    /// <summary>
    /// Teklif Edilen Set/Sistem/Ünite Tanımlaması Adı
    /// </summary>
        public string Detail
        {
            get { return (string)this["DETAIL"]; }
            set { this["DETAIL"] = value; }
        }

    /// <summary>
    /// Garanti Başlama Tarihi
    /// </summary>
        public DateTime? GuarantyStartDate
        {
            get { return (DateTime?)this["GUARANTYSTARTDATE"]; }
            set { this["GUARANTYSTARTDATE"] = value; }
        }

    /// <summary>
    /// Garanti Durumu
    /// </summary>
        public VarYokGarantiEnum? GuarantyStatus
        {
            get { return (VarYokGarantiEnum?)(int?)this["GUARANTYSTATUS"]; }
            set { this["GUARANTYSTATUS"] = value; }
        }

    /// <summary>
    /// Garanti Süresi (Gün)
    /// </summary>
        public int? GuarantiePeriod
        {
            get { return (int?)this["GUARANTIEPERIOD"]; }
            set { this["GUARANTIEPERIOD"] = value; }
        }

    /// <summary>
    /// Ömür Devri (Yıl)
    /// </summary>
        public int? LifePeriod
        {
            get { return (int?)this["LIFEPERIOD"]; }
            set { this["LIFEPERIOD"] = value; }
        }

    /// <summary>
    /// İleri Teknoloji Ürünü müdür?
    /// </summary>
        public YesNoEnum? IsAdvancedTechnology
        {
            get { return (YesNoEnum?)(int?)this["ISADVANCEDTECHNOLOGY"]; }
            set { this["ISADVANCEDTECHNOLOGY"] = value; }
        }

    /// <summary>
    /// Kalibrasyon Periyodu
    /// </summary>
        public CMPeriodEnum? CalibrationPeriod
        {
            get { return (CMPeriodEnum?)(int?)this["CALIBRATIONPERIOD"]; }
            set { this["CALIBRATIONPERIOD"] = value; }
        }

    /// <summary>
    /// Kalibrasyon Gerektirir
    /// </summary>
        public bool? NeedCalibration
        {
            get { return (bool?)this["NEEDCALIBRATION"]; }
            set { this["NEEDCALIBRATION"] = value; }
        }

    /// <summary>
    /// Bakım Gerektirir
    /// </summary>
        public bool? NeedMaintenance
        {
            get { return (bool?)this["NEEDMAINTENANCE"]; }
            set { this["NEEDMAINTENANCE"] = value; }
        }

    /// <summary>
    /// Bakım Süresi
    /// </summary>
        public int? MaintenanceTime
        {
            get { return (int?)this["MAINTENANCETIME"]; }
            set { this["MAINTENANCETIME"] = value; }
        }

    /// <summary>
    /// Bakım Peryodu
    /// </summary>
        public CMPeriodEnum? MaintenancePeriod
        {
            get { return (CMPeriodEnum?)(int?)this["MAINTENANCEPERIOD"]; }
            set { this["MAINTENANCEPERIOD"] = value; }
        }

    /// <summary>
    /// Kalibrasyon Süresi
    /// </summary>
        public int? CalibrationTime
        {
            get { return (int?)this["CALIBRATIONTIME"]; }
            set { this["CALIBRATIONTIME"] = value; }
        }

    /// <summary>
    /// Marka Model Durumu
    /// </summary>
        public VarYokGarantiEnum? MarkModelStatus
        {
            get { return (VarYokGarantiEnum?)(int?)this["MARKMODELSTATUS"]; }
            set { this["MARKMODELSTATUS"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Desciption
        {
            get { return (string)this["DESCIPTION"]; }
            set { this["DESCIPTION"] = value; }
        }

    /// <summary>
    /// Kullanım Alanları
    /// </summary>
        public string UsePlaces
        {
            get { return (string)this["USEPLACES"]; }
            set { this["USEPLACES"] = value; }
        }

    /// <summary>
    /// Kullanım Amacı
    /// </summary>
        public string UseGoal
        {
            get { return (string)this["USEGOAL"]; }
            set { this["USEGOAL"] = value; }
        }

    /// <summary>
    /// Ana Malzeme Kategori Numarası
    /// </summary>
        public string MaterialCategory
        {
            get { return (string)this["MATERIALCATEGORY"]; }
            set { this["MATERIALCATEGORY"] = value; }
        }

    /// <summary>
    /// Teknik Şartname Numarası
    /// </summary>
        public string TechnicalSpecificationsNo
        {
            get { return (string)this["TECHNICALSPECIFICATIONSNO"]; }
            set { this["TECHNICALSPECIFICATIONSNO"] = value; }
        }

    /// <summary>
    /// Parça/Katalog/Referans Nu.
    /// </summary>
        public string ReferansNo
        {
            get { return (string)this["REFERANSNO"]; }
            set { this["REFERANSNO"] = value; }
        }

        public StockCard StockCard
        {
            get { return (StockCard)((ITTObject)this).GetParent("STOCKCARD"); }
            set { this["STOCKCARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailMarkDef FixedAssetDetailMarkDef
        {
            get { return (FixedAssetDetailMarkDef)((ITTObject)this).GetParent("FIXEDASSETDETAILMARKDEF"); }
            set { this["FIXEDASSETDETAILMARKDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Üretici Firma
    /// </summary>
        public Producer Producer
        {
            get { return (Producer)((ITTObject)this).GetParent("PRODUCER"); }
            set { this["PRODUCER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailModelDef FixedAssetDetailModelDef
        {
            get { return (FixedAssetDetailModelDef)((ITTObject)this).GetParent("FIXEDASSETDETAILMODELDEF"); }
            set { this["FIXEDASSETDETAILMODELDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SetSystemUnitRequestDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SetSystemUnitRequestDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SetSystemUnitRequestDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SetSystemUnitRequestDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SetSystemUnitRequestDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SETSYSTEMUNITREQUESTDEF", dataRow) { }
        protected SetSystemUnitRequestDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SETSYSTEMUNITREQUESTDEF", dataRow, isImported) { }
        public SetSystemUnitRequestDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SetSystemUnitRequestDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SetSystemUnitRequestDef() : base() { }

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