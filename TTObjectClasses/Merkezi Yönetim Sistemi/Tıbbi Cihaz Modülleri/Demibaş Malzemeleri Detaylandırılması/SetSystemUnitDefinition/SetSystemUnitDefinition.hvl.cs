
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SetSystemUnitDefinition")] 

    public  partial class SetSystemUnitDefinition : TerminologyManagerDef
    {
        public class SetSystemUnitDefinitionList : TTObjectCollection<SetSystemUnitDefinition> { }
                    
        public class ChildSetSystemUnitDefinitionCollection : TTObject.TTChildObjectCollection<SetSystemUnitDefinition>
        {
            public ChildSetSystemUnitDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSetSystemUnitDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSetSystemUnitDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SETSYSTEMUNITDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSetSystemUnitDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSetSystemUnitDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSetSystemUnitDefinitionList_Class() : base() { }
        }

        public static BindingList<SetSystemUnitDefinition.GetSetSystemUnitDefinitionList_Class> GetSetSystemUnitDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SETSYSTEMUNITDEFINITION"].QueryDefs["GetSetSystemUnitDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SetSystemUnitDefinition.GetSetSystemUnitDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SetSystemUnitDefinition.GetSetSystemUnitDefinitionList_Class> GetSetSystemUnitDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SETSYSTEMUNITDEFINITION"].QueryDefs["GetSetSystemUnitDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SetSystemUnitDefinition.GetSetSystemUnitDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Barcode
        {
            get { return (string)this["BARCODE"]; }
            set { this["BARCODE"] = value; }
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
    /// Açıklama
    /// </summary>
        public string Desciption
        {
            get { return (string)this["DESCIPTION"]; }
            set { this["DESCIPTION"] = value; }
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
    /// Ömür Devri (Yıl)
    /// </summary>
        public int? LifePeriod
        {
            get { return (int?)this["LIFEPERIOD"]; }
            set { this["LIFEPERIOD"] = value; }
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
    /// Parça/Katalog/Referans Nu.
    /// </summary>
        public string ReferansNo
        {
            get { return (string)this["REFERANSNO"]; }
            set { this["REFERANSNO"] = value; }
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
    /// Kullanım Alanları
    /// </summary>
        public string UsePlaces
        {
            get { return (string)this["USEPLACES"]; }
            set { this["USEPLACES"] = value; }
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
    /// Bakım Peryodu
    /// </summary>
        public CMPeriodEnum? MaintenancePeriod
        {
            get { return (CMPeriodEnum?)(int?)this["MAINTENANCEPERIOD"]; }
            set { this["MAINTENANCEPERIOD"] = value; }
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

    /// <summary>
    /// Üretici Firma
    /// </summary>
        public Producer Producer
        {
            get { return (Producer)((ITTObject)this).GetParent("PRODUCER"); }
            set { this["PRODUCER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Site
    /// </summary>
        public Sites Sites
        {
            get { return (Sites)((ITTObject)this).GetParent("SITES"); }
            set { this["SITES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SetSystemUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SetSystemUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SetSystemUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SetSystemUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SetSystemUnitDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SETSYSTEMUNITDEFINITION", dataRow) { }
        protected SetSystemUnitDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SETSYSTEMUNITDEFINITION", dataRow, isImported) { }
        public SetSystemUnitDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SetSystemUnitDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SetSystemUnitDefinition() : base() { }

    }
}