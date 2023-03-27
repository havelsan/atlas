
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UnusedReceiptNoDefinition")] 

    public  partial class UnusedReceiptNoDefinition : TTDefinitionSet
    {
        public class UnusedReceiptNoDefinitionList : TTObjectCollection<UnusedReceiptNoDefinition> { }
                    
        public class ChildUnusedReceiptNoDefinitionCollection : TTObject.TTChildObjectCollection<UnusedReceiptNoDefinition>
        {
            public ChildUnusedReceiptNoDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUnusedReceiptNoDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUnusedreceiptsNoDefinitions_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? UnusedReceiptStartNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNUSEDRECEIPTSTARTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNUSEDRECEIPTNODEFINITION"].AllPropertyDefs["UNUSEDRECEIPTSTARTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? UnusedReceiptEndNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNUSEDRECEIPTENDNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNUSEDRECEIPTNODEFINITION"].AllPropertyDefs["UNUSEDRECEIPTENDNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNUSEDRECEIPTNODEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public GetUnusedreceiptsNoDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnusedreceiptsNoDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnusedreceiptsNoDefinitions_Class() : base() { }
        }

        public static BindingList<UnusedReceiptNoDefinition.GetUnusedreceiptsNoDefinitions_Class> GetUnusedreceiptsNoDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNUSEDRECEIPTNODEFINITION"].QueryDefs["GetUnusedreceiptsNoDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UnusedReceiptNoDefinition.GetUnusedreceiptsNoDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<UnusedReceiptNoDefinition.GetUnusedreceiptsNoDefinitions_Class> GetUnusedreceiptsNoDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNUSEDRECEIPTNODEFINITION"].QueryDefs["GetUnusedreceiptsNoDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UnusedReceiptNoDefinition.GetUnusedreceiptsNoDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kullanılmayacak makbuz açıklaması
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Kullanılmayacak makbuz başlangıç sıra no
    /// </summary>
        public long? UnusedReceiptStartNo
        {
            get { return (long?)this["UNUSEDRECEIPTSTARTNO"]; }
            set { this["UNUSEDRECEIPTSTARTNO"] = value; }
        }

    /// <summary>
    /// Kullanılmayacak Makbuz Bitiş Sıra No
    /// </summary>
        public long? UnusedReceiptEndNo
        {
            get { return (long?)this["UNUSEDRECEIPTENDNO"]; }
            set { this["UNUSEDRECEIPTENDNO"] = value; }
        }

        public ReceiptCashOfficeDefinition ReceiptCashOfficeDefinition
        {
            get { return (ReceiptCashOfficeDefinition)((ITTObject)this).GetParent("RECEIPTCASHOFFICEDEFINITION"); }
            set { this["RECEIPTCASHOFFICEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UnusedReceiptNoDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UnusedReceiptNoDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UnusedReceiptNoDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UnusedReceiptNoDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UnusedReceiptNoDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UNUSEDRECEIPTNODEFINITION", dataRow) { }
        protected UnusedReceiptNoDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UNUSEDRECEIPTNODEFINITION", dataRow, isImported) { }
        public UnusedReceiptNoDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UnusedReceiptNoDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UnusedReceiptNoDefinition() : base() { }

    }
}