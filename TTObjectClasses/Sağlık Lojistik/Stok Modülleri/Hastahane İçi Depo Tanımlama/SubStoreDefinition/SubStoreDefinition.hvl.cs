
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubStoreDefinition")] 

    /// <summary>
    /// XXXXXX İçi Depo Tanımları
    /// </summary>
    public  partial class SubStoreDefinition : Store
    {
        public class SubStoreDefinitionList : TTObjectCollection<SubStoreDefinition> { }
                    
        public class ChildSubStoreDefinitionCollection : TTObject.TTChildObjectCollection<SubStoreDefinition>
        {
            public ChildSubStoreDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubStoreDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSubStoreDefinition_Class : TTReportNqlObject 
        {
            public string QREF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBSTOREDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBSTOREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBSTOREDEFINITION"].AllPropertyDefs["STATUS"].DataType;
                    return (OpenCloseEnum?)(int)dataType.ConvertValue(val);
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

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBSTOREDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? DependantUnitID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPENDANTUNITID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBSTOREDEFINITION"].AllPropertyDefs["DEPENDANTUNITID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string UnitCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBSTOREDEFINITION"].AllPropertyDefs["UNITCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? UnitRegistryNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITREGISTRYNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBSTOREDEFINITION"].AllPropertyDefs["UNITREGISTRYNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? SubStoreMKYS
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBSTOREMKYS"]);
                }
            }

            public MKYS_ECikisStokHareketTurEnum? MKYS_CikisHareketTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_CIKISHAREKETTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBSTOREDEFINITION"].AllPropertyDefs["MKYS_CIKISHAREKETTURU"].DataType;
                    return (MKYS_ECikisStokHareketTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Storeresponsibleid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STORERESPONSIBLEID"]);
                }
            }

            public GetSubStoreDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSubStoreDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSubStoreDefinition_Class() : base() { }
        }

        public static BindingList<SubStoreDefinition.GetSubStoreDefinition_Class> GetSubStoreDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBSTOREDEFINITION"].QueryDefs["GetSubStoreDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubStoreDefinition.GetSubStoreDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SubStoreDefinition.GetSubStoreDefinition_Class> GetSubStoreDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBSTOREDEFINITION"].QueryDefs["GetSubStoreDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SubStoreDefinition.GetSubStoreDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Bağlı Birim ID
    /// </summary>
        public int? DependantUnitID
        {
            get { return (int?)this["DEPENDANTUNITID"]; }
            set { this["DEPENDANTUNITID"] = value; }
        }

    /// <summary>
    /// Birim Kayıt No
    /// </summary>
        public int? UnitRegistryNo
        {
            get { return (int?)this["UNITREGISTRYNO"]; }
            set { this["UNITREGISTRYNO"] = value; }
        }

    /// <summary>
    /// Birim Kodu
    /// </summary>
        public string UnitCode
        {
            get { return (string)this["UNITCODE"]; }
            set { this["UNITCODE"] = value; }
        }

        public MKYS_ECikisStokHareketTurEnum? MKYS_CikisHareketTuru
        {
            get { return (MKYS_ECikisStokHareketTurEnum?)(int?)this["MKYS_CIKISHAREKETTURU"]; }
            set { this["MKYS_CIKISHAREKETTURU"] = value; }
        }

        public ResUser StoreResponsible
        {
            get { return (ResUser)((ITTObject)this).GetParent("STORERESPONSIBLE"); }
            set { this["STORERESPONSIBLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// MKYS_ServisDepo
    /// </summary>
        public MKYS_ServisDepo SubStoreMKYS
        {
            get { return (MKYS_ServisDepo)((ITTObject)this).GetParent("SUBSTOREMKYS"); }
            set { this["SUBSTOREMKYS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SubStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubStoreDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBSTOREDEFINITION", dataRow) { }
        protected SubStoreDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBSTOREDEFINITION", dataRow, isImported) { }
        public SubStoreDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubStoreDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubStoreDefinition() : base() { }

    }
}