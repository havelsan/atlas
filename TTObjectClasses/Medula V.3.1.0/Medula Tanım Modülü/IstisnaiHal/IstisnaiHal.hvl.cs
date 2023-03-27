
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IstisnaiHal")] 

    /// <summary>
    /// İstisnai Hal Tanımları
    /// </summary>
    public  partial class IstisnaiHal : TerminologyManagerDef
    {
        public class IstisnaiHalList : TTObjectCollection<IstisnaiHal> { }
                    
        public class ChildIstisnaiHalCollection : TTObject.TTChildObjectCollection<IstisnaiHal>
        {
            public ChildIstisnaiHalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIstisnaiHalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class IstisnaiHalDefinitionQuery_Class : TTReportNqlObject 
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

            public string Adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ISTISNAIHAL"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ISTISNAIHAL"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public IstisnaiHalDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public IstisnaiHalDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected IstisnaiHalDefinitionQuery_Class() : base() { }
        }

        public static BindingList<IstisnaiHal.IstisnaiHalDefinitionQuery_Class> IstisnaiHalDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ISTISNAIHAL"].QueryDefs["IstisnaiHalDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<IstisnaiHal.IstisnaiHalDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<IstisnaiHal.IstisnaiHalDefinitionQuery_Class> IstisnaiHalDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ISTISNAIHAL"].QueryDefs["IstisnaiHalDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<IstisnaiHal.IstisnaiHalDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Adi
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Kodu
        {
            get { return (string)this["KODU"]; }
            set { this["KODU"] = value; }
        }

        protected IstisnaiHal(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IstisnaiHal(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IstisnaiHal(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IstisnaiHal(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IstisnaiHal(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ISTISNAIHAL", dataRow) { }
        protected IstisnaiHal(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ISTISNAIHAL", dataRow, isImported) { }
        public IstisnaiHal(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IstisnaiHal(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IstisnaiHal() : base() { }

    }
}