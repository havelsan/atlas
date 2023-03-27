
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DPA22FCodelessMaterialDef")] 

    public  partial class DPA22FCodelessMaterialDef : TerminologyManagerDef
    {
        public class DPA22FCodelessMaterialDefList : TTObjectCollection<DPA22FCodelessMaterialDef> { }
                    
        public class ChildDPA22FCodelessMaterialDefCollection : TTObject.TTChildObjectCollection<DPA22FCodelessMaterialDef>
        {
            public ChildDPA22FCodelessMaterialDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDPA22FCodelessMaterialDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class DPA22FCodelessMaterialDefNQL_Class : TTReportNqlObject 
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

            public string MaterialName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DPA22FCODELESSMATERIALDEF"].AllPropertyDefs["MATERIALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MatchedSUTCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATCHEDSUTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DPA22FCODELESSMATERIALDEF"].AllPropertyDefs["MATCHEDSUTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? MatchedSUTPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATCHEDSUTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DPA22FCODELESSMATERIALDEF"].AllPropertyDefs["MATCHEDSUTPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DPA22FCodelessMaterialDefNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DPA22FCodelessMaterialDefNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DPA22FCodelessMaterialDefNQL_Class() : base() { }
        }

        public static BindingList<DPA22FCodelessMaterialDef.DPA22FCodelessMaterialDefNQL_Class> DPA22FCodelessMaterialDefNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPA22FCODELESSMATERIALDEF"].QueryDefs["DPA22FCodelessMaterialDefNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DPA22FCodelessMaterialDef.DPA22FCodelessMaterialDefNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DPA22FCodelessMaterialDef.DPA22FCodelessMaterialDefNQL_Class> DPA22FCodelessMaterialDefNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPA22FCODELESSMATERIALDEF"].QueryDefs["DPA22FCodelessMaterialDefNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DPA22FCodelessMaterialDef.DPA22FCodelessMaterialDefNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Malzeme Adı
    /// </summary>
        public string MaterialName
        {
            get { return (string)this["MATERIALNAME"]; }
            set { this["MATERIALNAME"] = value; }
        }

    /// <summary>
    /// Eşleştiği Hizmetin SUT Kodu
    /// </summary>
        public string MatchedSUTCode
        {
            get { return (string)this["MATCHEDSUTCODE"]; }
            set { this["MATCHEDSUTCODE"] = value; }
        }

    /// <summary>
    /// Eşleştiği Hizmetin SUT Fiyatı
    /// </summary>
        public double? MatchedSUTPrice
        {
            get { return (double?)this["MATCHEDSUTPRICE"]; }
            set { this["MATCHEDSUTPRICE"] = value; }
        }

        protected DPA22FCodelessMaterialDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DPA22FCodelessMaterialDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DPA22FCodelessMaterialDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DPA22FCodelessMaterialDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DPA22FCodelessMaterialDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DPA22FCODELESSMATERIALDEF", dataRow) { }
        protected DPA22FCodelessMaterialDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DPA22FCODELESSMATERIALDEF", dataRow, isImported) { }
        public DPA22FCodelessMaterialDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DPA22FCodelessMaterialDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DPA22FCodelessMaterialDef() : base() { }

    }
}