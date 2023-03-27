
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChemotherapyApplyMethod")] 

    /// <summary>
    /// Kemoterapi Uygulama Şekli
    /// </summary>
    public  partial class ChemotherapyApplyMethod : TerminologyManagerDef
    {
        public class ChemotherapyApplyMethodList : TTObjectCollection<ChemotherapyApplyMethod> { }
                    
        public class ChildChemotherapyApplyMethodCollection : TTObject.TTChildObjectCollection<ChemotherapyApplyMethod>
        {
            public ChildChemotherapyApplyMethodCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChemotherapyApplyMethodCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetChemotherapyApplyMethods_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHEMOTHERAPYAPPLYMETHOD"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHEMOTHERAPYAPPLYMETHOD"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHEMOTHERAPYAPPLYMETHOD"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetChemotherapyApplyMethods_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetChemotherapyApplyMethods_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetChemotherapyApplyMethods_Class() : base() { }
        }

        public static BindingList<ChemotherapyApplyMethod.GetChemotherapyApplyMethods_Class> GetChemotherapyApplyMethods(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHEMOTHERAPYAPPLYMETHOD"].QueryDefs["GetChemotherapyApplyMethods"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ChemotherapyApplyMethod.GetChemotherapyApplyMethods_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ChemotherapyApplyMethod.GetChemotherapyApplyMethods_Class> GetChemotherapyApplyMethods(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHEMOTHERAPYAPPLYMETHOD"].QueryDefs["GetChemotherapyApplyMethods"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ChemotherapyApplyMethod.GetChemotherapyApplyMethods_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

        protected ChemotherapyApplyMethod(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChemotherapyApplyMethod(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChemotherapyApplyMethod(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChemotherapyApplyMethod(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChemotherapyApplyMethod(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHEMOTHERAPYAPPLYMETHOD", dataRow) { }
        protected ChemotherapyApplyMethod(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHEMOTHERAPYAPPLYMETHOD", dataRow, isImported) { }
        public ChemotherapyApplyMethod(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChemotherapyApplyMethod(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChemotherapyApplyMethod() : base() { }

    }
}