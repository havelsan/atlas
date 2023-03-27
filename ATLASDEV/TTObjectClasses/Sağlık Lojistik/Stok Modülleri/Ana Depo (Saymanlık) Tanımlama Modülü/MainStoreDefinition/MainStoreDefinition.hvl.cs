
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainStoreDefinition")] 

    /// <summary>
    /// Ana Depo (Saymanlık Deposu) Tanımı
    /// </summary>
    public  partial class MainStoreDefinition : Store
    {
        public class MainStoreDefinitionList : TTObjectCollection<MainStoreDefinition> { }
                    
        public class ChildMainStoreDefinitionCollection : TTObject.TTChildObjectCollection<MainStoreDefinition>
        {
            public ChildMainStoreDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainStoreDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMainStoreDefinition_Class : TTReportNqlObject 
        {
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

            public string QREF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINSTOREDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINSTOREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OpenCloseEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINSTOREDEFINITION"].AllPropertyDefs["STATUS"].DataType;
                    return (OpenCloseEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Accountancyname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANCYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINSTOREDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMainStoreDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMainStoreDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMainStoreDefinition_Class() : base() { }
        }

        public static BindingList<MainStoreDefinition.GetMainStoreDefinition_Class> GetMainStoreDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINSTOREDEFINITION"].QueryDefs["GetMainStoreDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MainStoreDefinition.GetMainStoreDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MainStoreDefinition.GetMainStoreDefinition_Class> GetMainStoreDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINSTOREDEFINITION"].QueryDefs["GetMainStoreDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MainStoreDefinition.GetMainStoreDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MainStoreDefinition> GetAllMainStores(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINSTOREDEFINITION"].QueryDefs["GetAllMainStores"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<MainStoreDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// MKYS_ButceTuru
    /// </summary>
        public MKYS_EButceTurEnum? MKYS_ButceTuru
        {
            get { return (MKYS_EButceTurEnum?)(int?)this["MKYS_BUTCETURU"]; }
            set { this["MKYS_BUTCETURU"] = value; }
        }

        public MKYS_EEntegrasyonDurumuEnum? IntegrationScope
        {
            get { return (MKYS_EEntegrasyonDurumuEnum?)(int?)this["INTEGRATIONSCOPE"]; }
            set { this["INTEGRATIONSCOPE"] = value; }
        }

        public string StoreCode
        {
            get { return (string)this["STORECODE"]; }
            set { this["STORECODE"] = value; }
        }

        public int? StoreRecordNo
        {
            get { return (int?)this["STORERECORDNO"]; }
            set { this["STORERECORDNO"] = value; }
        }

        public int? UnitRecordNo
        {
            get { return (int?)this["UNITRECORDNO"]; }
            set { this["UNITRECORDNO"] = value; }
        }

        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Mal Saymanı
    /// </summary>
        public ResUser GoodsAccountant
        {
            get { return (ResUser)((ITTObject)this).GetParent("GOODSACCOUNTANT"); }
            set { this["GOODSACCOUNTANT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Mal Sorumlusu
    /// </summary>
        public ResUser GoodsResponsible
        {
            get { return (ResUser)((ITTObject)this).GetParent("GOODSRESPONSIBLE"); }
            set { this["GOODSRESPONSIBLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hesap Sorumlusu
    /// </summary>
        public ResUser AccountManager
        {
            get { return (ResUser)((ITTObject)this).GetParent("ACCOUNTMANAGER"); }
            set { this["ACCOUNTMANAGER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MainStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainStoreDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINSTOREDEFINITION", dataRow) { }
        protected MainStoreDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINSTOREDEFINITION", dataRow, isImported) { }
        public MainStoreDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainStoreDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainStoreDefinition() : base() { }

    }
}