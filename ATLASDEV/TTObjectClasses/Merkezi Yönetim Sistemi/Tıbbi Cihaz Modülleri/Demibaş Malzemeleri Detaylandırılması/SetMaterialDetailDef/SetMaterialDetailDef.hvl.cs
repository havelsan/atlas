
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SetMaterialDetailDef")] 

    public  partial class SetMaterialDetailDef : TTObject
    {
        public class SetMaterialDetailDefList : TTObjectCollection<SetMaterialDetailDef> { }
                    
        public class ChildSetMaterialDetailDefCollection : TTObject.TTChildObjectCollection<SetMaterialDetailDef>
        {
            public ChildSetMaterialDetailDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSetMaterialDetailDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Diğer Gövde Yapısı
    /// </summary>
        public bool? OtherBody
        {
            get { return (bool?)this["OTHERBODY"]; }
            set { this["OTHERBODY"] = value; }
        }

    /// <summary>
    /// Diğer Uç Yapısı
    /// </summary>
        public bool? OtherEdge
        {
            get { return (bool?)this["OTHEREDGE"]; }
            set { this["OTHEREDGE"] = value; }
        }

    /// <summary>
    /// Diğer Uzunluk
    /// </summary>
        public bool? OtherLenght
        {
            get { return (bool?)this["OTHERLENGHT"]; }
            set { this["OTHERLENGHT"] = value; }
        }

    /// <summary>
    /// Diğer Ana Malzeme Adı
    /// </summary>
        public bool? OtherMainClass
        {
            get { return (bool?)this["OTHERMAINCLASS"]; }
            set { this["OTHERMAINCLASS"] = value; }
        }

    /// <summary>
    /// Diğer Marka
    /// </summary>
        public bool? OtherMark
        {
            get { return (bool?)this["OTHERMARK"]; }
            set { this["OTHERMARK"] = value; }
        }

    /// <summary>
    /// Diğer Model
    /// </summary>
        public bool? OtherModel
        {
            get { return (bool?)this["OTHERMODEL"]; }
            set { this["OTHERMODEL"] = value; }
        }

    /// <summary>
    /// Kalibrasyon Peryodu
    /// </summary>
        public CMPeriodEnum? CalibrationPeriod
        {
            get { return (CMPeriodEnum?)(int?)this["CALIBRATIONPERIOD"]; }
            set { this["CALIBRATIONPERIOD"] = value; }
        }

    /// <summary>
    /// BMM ve TBB.TEK.KS. için Kalibrasyon Durumu
    /// </summary>
        public CMRequireEnum? CalibrationStatus
        {
            get { return (CMRequireEnum?)(int?)this["CALIBRATIONSTATUS"]; }
            set { this["CALIBRATIONSTATUS"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// El Aleti / Cihaz / Diğer Tıbbi Ana Malzemeler
    /// </summary>
        public FixedAssetDetailTypeEnum? DetailType
        {
            get { return (FixedAssetDetailTypeEnum?)(int?)this["DETAILTYPE"]; }
            set { this["DETAILTYPE"] = value; }
        }

    /// <summary>
    /// Frekans (Hz cinsinden)
    /// </summary>
        public double? Frequency
        {
            get { return (double?)this["FREQUENCY"]; }
            set { this["FREQUENCY"] = value; }
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
    /// Garanti Süresi (Gün)
    /// </summary>
        public int? GuarantiePeriod
        {
            get { return (int?)this["GUARANTIEPERIOD"]; }
            set { this["GUARANTIEPERIOD"] = value; }
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
    /// Kullanım Amacı
    /// </summary>
        public string IntendedUse
        {
            get { return (string)this["INTENDEDUSE"]; }
            set { this["INTENDEDUSE"] = value; }
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
    /// Malzeme Demode midir?
    /// </summary>
        public YesNoEnum? IsDemoded
        {
            get { return (YesNoEnum?)(int?)this["ISDEMODED"]; }
            set { this["ISDEMODED"] = value; }
        }

    /// <summary>
    /// Son Kalibrasyon Tarihi
    /// </summary>
        public DateTime? LastCalibrationDate
        {
            get { return (DateTime?)this["LASTCALIBRATIONDATE"]; }
            set { this["LASTCALIBRATIONDATE"] = value; }
        }

    /// <summary>
    /// Son Bakım Tarihi
    /// </summary>
        public DateTime? LastMaintenanceDate
        {
            get { return (DateTime?)this["LASTMAINTENANCEDATE"]; }
            set { this["LASTMAINTENANCEDATE"] = value; }
        }

    /// <summary>
    /// Uzunluğu (mm cinsinden)
    /// </summary>
        public int? Length
        {
            get { return (int?)this["LENGTH"]; }
            set { this["LENGTH"] = value; }
        }

    /// <summary>
    /// BMM ve TBB.TEK.KS. için Bakım Durumu
    /// </summary>
        public CMRequireEnum? MaintanenceStatus
        {
            get { return (CMRequireEnum?)(int?)this["MAINTANENCESTATUS"]; }
            set { this["MAINTANENCESTATUS"] = value; }
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
    /// Marka ve Model Yok ise Gerekçeli Açıklama
    /// </summary>
        public string MarkModelReason
        {
            get { return (string)this["MARKMODELREASON"]; }
            set { this["MARKMODELREASON"] = value; }
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
    /// Malzeme Faal Durumu
    /// </summary>
        public FixeAssetOperationStatusEnum? OperationStatus
        {
            get { return (FixeAssetOperationStatusEnum?)(int?)this["OPERATIONSTATUS"]; }
            set { this["OPERATIONSTATUS"] = value; }
        }

    /// <summary>
    /// Fiziki Kontroldeki Barkod Numarası
    /// </summary>
        public string PhysicalBarcode
        {
            get { return (string)this["PHYSICALBARCODE"]; }
            set { this["PHYSICALBARCODE"] = value; }
        }

    /// <summary>
    /// Malzemenin Fotografı
    /// </summary>
        public object Picture
        {
            get { return (object)this["PICTURE"]; }
            set { this["PICTURE"] = value; }
        }

    /// <summary>
    /// Güç (W cinsinden)
    /// </summary>
        public double? Power
        {
            get { return (double?)this["POWER"]; }
            set { this["POWER"] = value; }
        }

    /// <summary>
    /// Üretim Tarihi
    /// </summary>
        public DateTime? ProductionDate
        {
            get { return (DateTime?)this["PRODUCTIONDATE"]; }
            set { this["PRODUCTIONDATE"] = value; }
        }

    /// <summary>
    /// Sahanın Önerdiği Stok Numarası
    /// </summary>
        public string ProposedNATOStockNo
        {
            get { return (string)this["PROPOSEDNATOSTOCKNO"]; }
            set { this["PROPOSEDNATOSTOCKNO"] = value; }
        }

    /// <summary>
    /// Sahanın Önerdiği Stok Adı
    /// </summary>
        public string ProposedStockcardName
        {
            get { return (string)this["PROPOSEDSTOCKCARDNAME"]; }
            set { this["PROPOSEDSTOCKCARDNAME"] = value; }
        }

    /// <summary>
    /// Referans / Katalog / Parça Nu.
    /// </summary>
        public string ReferansNo
        {
            get { return (string)this["REFERANSNO"]; }
            set { this["REFERANSNO"] = value; }
        }

    /// <summary>
    /// Seri No
    /// </summary>
        public string SerialNumber
        {
            get { return (string)this["SERIALNUMBER"]; }
            set { this["SERIALNUMBER"] = value; }
        }

    /// <summary>
    /// Malzemenin Kullanıma Başlandığı Tarih
    /// </summary>
        public DateTime? UseStartDate
        {
            get { return (DateTime?)this["USESTARTDATE"]; }
            set { this["USESTARTDATE"] = value; }
        }

    /// <summary>
    /// Voltaj (V cinsinden)
    /// </summary>
        public double? Voltage
        {
            get { return (double?)this["VOLTAGE"]; }
            set { this["VOLTAGE"] = value; }
        }

        public FixedAssetDetailMainClassDefinition FixedAssetDetailMainClass
        {
            get { return (FixedAssetDetailMainClassDefinition)((ITTObject)this).GetParent("FIXEDASSETDETAILMAINCLASS"); }
            set { this["FIXEDASSETDETAILMAINCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailMarkDef FixedAssetDetailMarkDef
        {
            get { return (FixedAssetDetailMarkDef)((ITTObject)this).GetParent("FIXEDASSETDETAILMARKDEF"); }
            set { this["FIXEDASSETDETAILMARKDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailModelDef FixedAssetDetailModelDef
        {
            get { return (FixedAssetDetailModelDef)((ITTObject)this).GetParent("FIXEDASSETDETAILMODELDEF"); }
            set { this["FIXEDASSETDETAILMODELDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailBodyDef FixedAssetDetailBodyDef
        {
            get { return (FixedAssetDetailBodyDef)((ITTObject)this).GetParent("FIXEDASSETDETAILBODYDEF"); }
            set { this["FIXEDASSETDETAILBODYDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailEdgeDef FixedAssetDetailEdgeDef
        {
            get { return (FixedAssetDetailEdgeDef)((ITTObject)this).GetParent("FIXEDASSETDETAILEDGEDEF"); }
            set { this["FIXEDASSETDETAILEDGEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetMaterialDefinitionDetail FixedAssetMaterialDefDetail
        {
            get { return (FixedAssetMaterialDefinitionDetail)((ITTObject)this).GetParent("FIXEDASSETMATERIALDEFDETAIL"); }
            set { this["FIXEDASSETMATERIALDEFDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SetMaterialDetailDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SetMaterialDetailDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SetMaterialDetailDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SetMaterialDetailDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SetMaterialDetailDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SETMATERIALDETAILDEF", dataRow) { }
        protected SetMaterialDetailDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SETMATERIALDETAILDEF", dataRow, isImported) { }
        public SetMaterialDetailDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SetMaterialDetailDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SetMaterialDetailDef() : base() { }

    }
}