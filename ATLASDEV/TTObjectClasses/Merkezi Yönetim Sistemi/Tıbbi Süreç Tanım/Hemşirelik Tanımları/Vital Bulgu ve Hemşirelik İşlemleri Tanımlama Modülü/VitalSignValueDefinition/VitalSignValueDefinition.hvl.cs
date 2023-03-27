
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VitalSignValueDefinition")] 

    /// <summary>
    /// Vital Bulgular Normal Değer Tanımları
    /// </summary>
    public  partial class VitalSignValueDefinition : TTDefinitionSet
    {
        public class VitalSignValueDefinitionList : TTObjectCollection<VitalSignValueDefinition> { }
                    
        public class ChildVitalSignValueDefinitionCollection : TTObject.TTChildObjectCollection<VitalSignValueDefinition>
        {
            public ChildVitalSignValueDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVitalSignValueDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetVitalSignValueDefinition_Class : TTReportNqlObject 
        {
            public VitalSignType? VitalSignType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VITALSIGNTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNVALUEDEFINITION"].AllPropertyDefs["VITALSIGNTYPE"].DataType;
                    return (VitalSignType?)(int)dataType.ConvertValue(val);
                }
            }

            public int? MaxAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNVALUEDEFINITION"].AllPropertyDefs["MAXAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? MinAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNVALUEDEFINITION"].AllPropertyDefs["MINAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? MaxValue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXVALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNVALUEDEFINITION"].AllPropertyDefs["MAXVALUE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? MinValue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINVALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNVALUEDEFINITION"].AllPropertyDefs["MINVALUE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string MaxValueWarning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXVALUEWARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNVALUEDEFINITION"].AllPropertyDefs["MAXVALUEWARNING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MinValueWarning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINVALUEWARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNVALUEDEFINITION"].AllPropertyDefs["MINVALUEWARNING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public GetVitalSignValueDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetVitalSignValueDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetVitalSignValueDefinition_Class() : base() { }
        }

        public static BindingList<VitalSignValueDefinition.GetVitalSignValueDefinition_Class> GetVitalSignValueDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNVALUEDEFINITION"].QueryDefs["GetVitalSignValueDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<VitalSignValueDefinition.GetVitalSignValueDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<VitalSignValueDefinition.GetVitalSignValueDefinition_Class> GetVitalSignValueDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNVALUEDEFINITION"].QueryDefs["GetVitalSignValueDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<VitalSignValueDefinition.GetVitalSignValueDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Üst Değerde Verilecek Uyarı
    /// </summary>
        public string MaxValueWarning
        {
            get { return (string)this["MAXVALUEWARNING"]; }
            set { this["MAXVALUEWARNING"] = value; }
        }

    /// <summary>
    /// Alt Değerde Verilecek Uyarı
    /// </summary>
        public string MinValueWarning
        {
            get { return (string)this["MINVALUEWARNING"]; }
            set { this["MINVALUEWARNING"] = value; }
        }

    /// <summary>
    /// Vital Bulgu Tipi
    /// </summary>
        public VitalSignType? VitalSignType
        {
            get { return (VitalSignType?)(int?)this["VITALSIGNTYPE"]; }
            set { this["VITALSIGNTYPE"] = value; }
        }

    /// <summary>
    /// Yaş Min
    /// </summary>
        public int? MinAge
        {
            get { return (int?)this["MINAGE"]; }
            set { this["MINAGE"] = value; }
        }

    /// <summary>
    /// Yaş Max
    /// </summary>
        public int? MaxAge
        {
            get { return (int?)this["MAXAGE"]; }
            set { this["MAXAGE"] = value; }
        }

    /// <summary>
    /// Min Değer
    /// </summary>
        public double? MinValue
        {
            get { return (double?)this["MINVALUE"]; }
            set { this["MINVALUE"] = value; }
        }

    /// <summary>
    /// Max Değer
    /// </summary>
        public double? MaxValue
        {
            get { return (double?)this["MAXVALUE"]; }
            set { this["MAXVALUE"] = value; }
        }

    /// <summary>
    /// Cinsiyet
    /// </summary>
        public SKRSCinsiyet Sex
        {
            get { return (SKRSCinsiyet)((ITTObject)this).GetParent("SEX"); }
            set { this["SEX"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected VitalSignValueDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VitalSignValueDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VitalSignValueDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VitalSignValueDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VitalSignValueDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VITALSIGNVALUEDEFINITION", dataRow) { }
        protected VitalSignValueDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VITALSIGNVALUEDEFINITION", dataRow, isImported) { }
        public VitalSignValueDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VitalSignValueDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VitalSignValueDefinition() : base() { }

    }
}