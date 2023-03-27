
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResPharmacy")] 

    /// <summary>
    /// Eczane
    /// </summary>
    public  partial class ResPharmacy : ResSection
    {
        public class ResPharmacyList : TTObjectCollection<ResPharmacy> { }
                    
        public class ChildResPharmacyCollection : TTObject.TTChildObjectCollection<ResPharmacy>
        {
            public ChildResPharmacyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResPharmacyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPharmacyDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPHARMACY"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPHARMACY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPharmacyDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPharmacyDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPharmacyDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetPharmacyStoreDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPHARMACY"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPHARMACY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Guid? Hospital
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HOSPITAL"]);
                }
            }

            public OLAP_GetPharmacyStoreDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetPharmacyStoreDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetPharmacyStoreDef_Class() : base() { }
        }

        public static BindingList<ResPharmacy.GetPharmacyDefinition_Class> GetPharmacyDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPHARMACY"].QueryDefs["GetPharmacyDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPharmacy.GetPharmacyDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResPharmacy.GetPharmacyDefinition_Class> GetPharmacyDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPHARMACY"].QueryDefs["GetPharmacyDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPharmacy.GetPharmacyDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResPharmacy.OLAP_GetPharmacyStoreDef_Class> OLAP_GetPharmacyStoreDef(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPHARMACY"].QueryDefs["OLAP_GetPharmacyStoreDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPharmacy.OLAP_GetPharmacyStoreDef_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResPharmacy.OLAP_GetPharmacyStoreDef_Class> OLAP_GetPharmacyStoreDef(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPHARMACY"].QueryDefs["OLAP_GetPharmacyStoreDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPharmacy.OLAP_GetPharmacyStoreDef_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// XXXXXX
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Depo
    /// </summary>
        public PharmacyStoreDefinition PharmacyStore
        {
            get 
            {   
                if (Store is PharmacyStoreDefinition)
                    return (PharmacyStoreDefinition)Store; 
                return null;
            }            
            set { Store = value; }
        }

        protected ResPharmacy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResPharmacy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResPharmacy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResPharmacy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResPharmacy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESPHARMACY", dataRow) { }
        protected ResPharmacy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESPHARMACY", dataRow, isImported) { }
        public ResPharmacy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResPharmacy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResPharmacy() : base() { }

    }
}