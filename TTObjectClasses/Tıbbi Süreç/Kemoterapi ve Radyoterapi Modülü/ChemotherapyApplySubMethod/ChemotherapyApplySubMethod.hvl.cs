
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChemotherapyApplySubMethod")] 

    /// <summary>
    /// Kemoterapi Alt Uygulama Şekilleri Tanımları
    /// </summary>
    public  partial class ChemotherapyApplySubMethod : TerminologyManagerDef
    {
        public class ChemotherapyApplySubMethodList : TTObjectCollection<ChemotherapyApplySubMethod> { }
                    
        public class ChildChemotherapyApplySubMethodCollection : TTObject.TTChildObjectCollection<ChemotherapyApplySubMethod>
        {
            public ChildChemotherapyApplySubMethodCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChemotherapyApplySubMethodCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetChemotherapyApplySubMethods_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
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

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHEMOTHERAPYAPPLYSUBMETHOD"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHEMOTHERAPYAPPLYSUBMETHOD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHEMOTHERAPYAPPLYSUBMETHOD"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetChemotherapyApplySubMethods_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetChemotherapyApplySubMethods_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetChemotherapyApplySubMethods_Class() : base() { }
        }

        public static BindingList<ChemotherapyApplySubMethod.GetChemotherapyApplySubMethods_Class> GetChemotherapyApplySubMethods(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHEMOTHERAPYAPPLYSUBMETHOD"].QueryDefs["GetChemotherapyApplySubMethods"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ChemotherapyApplySubMethod.GetChemotherapyApplySubMethods_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ChemotherapyApplySubMethod.GetChemotherapyApplySubMethods_Class> GetChemotherapyApplySubMethods(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHEMOTHERAPYAPPLYSUBMETHOD"].QueryDefs["GetChemotherapyApplySubMethods"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ChemotherapyApplySubMethod.GetChemotherapyApplySubMethods_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

        public ChemotherapyApplyMethod ChemotherapyApplyMethod
        {
            get { return (ChemotherapyApplyMethod)((ITTObject)this).GetParent("CHEMOTHERAPYAPPLYMETHOD"); }
            set { this["CHEMOTHERAPYAPPLYMETHOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ChemotherapyApplySubMethod(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChemotherapyApplySubMethod(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChemotherapyApplySubMethod(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChemotherapyApplySubMethod(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChemotherapyApplySubMethod(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHEMOTHERAPYAPPLYSUBMETHOD", dataRow) { }
        protected ChemotherapyApplySubMethod(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHEMOTHERAPYAPPLYSUBMETHOD", dataRow, isImported) { }
        public ChemotherapyApplySubMethod(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChemotherapyApplySubMethod(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChemotherapyApplySubMethod() : base() { }

    }
}