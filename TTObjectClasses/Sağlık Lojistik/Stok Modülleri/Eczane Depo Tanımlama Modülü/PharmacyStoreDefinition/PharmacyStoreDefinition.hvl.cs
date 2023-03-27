
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PharmacyStoreDefinition")] 

    /// <summary>
    /// Eczane Depo Tanımları
    /// </summary>
    public  partial class PharmacyStoreDefinition : MainStoreDefinition
    {
        public class PharmacyStoreDefinitionList : TTObjectCollection<PharmacyStoreDefinition> { }
                    
        public class ChildPharmacyStoreDefinitionCollection : TTObject.TTChildObjectCollection<PharmacyStoreDefinition>
        {
            public ChildPharmacyStoreDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPharmacyStoreDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPharmacyStore_Class : TTReportNqlObject 
        {
            public string QREF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSTOREDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSTOREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PharmacyTypeEnum? PharmacyType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHARMACYTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSTOREDEFINITION"].AllPropertyDefs["PHARMACYTYPE"].DataType;
                    return (PharmacyTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public OpenCloseEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSTOREDEFINITION"].AllPropertyDefs["STATUS"].DataType;
                    return (OpenCloseEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSTOREDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Storeresponsiblename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORERESPONSIBLENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPharmacyStore_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPharmacyStore_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPharmacyStore_Class() : base() { }
        }

        public static BindingList<PharmacyStoreDefinition> GetInpatientPharmacyStore(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSTOREDEFINITION"].QueryDefs["GetInpatientPharmacyStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PharmacyStoreDefinition>(queryDef, paramList);
        }

        public static BindingList<PharmacyStoreDefinition> GetPharmacyStores(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSTOREDEFINITION"].QueryDefs["GetPharmacyStores"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PharmacyStoreDefinition>(queryDef, paramList);
        }

        public static BindingList<PharmacyStoreDefinition.GetPharmacyStore_Class> GetPharmacyStore(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSTOREDEFINITION"].QueryDefs["GetPharmacyStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PharmacyStoreDefinition.GetPharmacyStore_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PharmacyStoreDefinition.GetPharmacyStore_Class> GetPharmacyStore(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSTOREDEFINITION"].QueryDefs["GetPharmacyStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PharmacyStoreDefinition.GetPharmacyStore_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PharmacyStoreDefinition> GetOutpatientPharmacyStore(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSTOREDEFINITION"].QueryDefs["GetOutpatientPharmacyStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PharmacyStoreDefinition>(queryDef, paramList);
        }

        public static BindingList<PharmacyStoreDefinition> GetPharmacyByUnitStore(TTObjectContext objectContext, Guid UNITSTORE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSTOREDEFINITION"].QueryDefs["GetPharmacyByUnitStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNITSTORE", UNITSTORE);

            return ((ITTQuery)objectContext).QueryObjects<PharmacyStoreDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Eczane Durumu
    /// </summary>
        public PharmacyTypeEnum? PharmacyType
        {
            get { return (PharmacyTypeEnum?)(int?)this["PHARMACYTYPE"]; }
            set { this["PHARMACYTYPE"] = value; }
        }

    /// <summary>
    /// Sorumlu Personel
    /// </summary>
        public ResUser StoreResponsible
        {
            get { return (ResUser)((ITTObject)this).GetParent("STORERESPONSIBLE"); }
            set { this["STORERESPONSIBLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store UnitStoreDefinition
        {
            get { return (Store)((ITTObject)this).GetParent("UNITSTOREDEFINITION"); }
            set { this["UNITSTOREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PharmacyStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PharmacyStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PharmacyStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PharmacyStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PharmacyStoreDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHARMACYSTOREDEFINITION", dataRow) { }
        protected PharmacyStoreDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHARMACYSTOREDEFINITION", dataRow, isImported) { }
        public PharmacyStoreDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PharmacyStoreDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PharmacyStoreDefinition() : base() { }

    }
}