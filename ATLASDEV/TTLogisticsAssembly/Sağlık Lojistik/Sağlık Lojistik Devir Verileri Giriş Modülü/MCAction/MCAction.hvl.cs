
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MCAction")] 

    /// <summary>
    /// Muvakkat Çizelgesi
    /// </summary>
    public  partial class MCAction : TTObject
    {
        public class MCActionList : TTObjectCollection<MCAction> { }
                    
        public class ChildMCActionCollection : TTObject.TTChildObjectCollection<MCAction>
        {
            public ChildMCActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMCActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class MCActionReportQuery_Class : TTReportNqlObject 
        {
            public Guid? STCAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STCACTION"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? MuvakkatenVerilen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUVAKKATENVERILEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MCACTION"].AllPropertyDefs["MUVAKKATENVERILEN"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Guid? Store
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STORE"]);
                }
            }

            public MCActionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MCActionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MCActionReportQuery_Class() : base() { }
        }

        public static BindingList<MCAction.MCActionReportQuery_Class> MCActionReportQuery(string STCOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MCACTION"].QueryDefs["MCActionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STCOBJECTID", STCOBJECTID);

            return TTReportNqlObject.QueryObjects<MCAction.MCActionReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MCAction.MCActionReportQuery_Class> MCActionReportQuery(TTObjectContext objectContext, string STCOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MCACTION"].QueryDefs["MCActionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STCOBJECTID", STCOBJECTID);

            return TTReportNqlObject.QueryObjects<MCAction.MCActionReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İlk Transfer Yapılmıştır
    /// </summary>
        public bool? IsFirstTransfer
        {
            get { return (bool?)this["ISFIRSTTRANSFER"]; }
            set { this["ISFIRSTTRANSFER"] = value; }
        }

        public double? MuvakkatenVerilen
        {
            get { return (double?)this["MUVAKKATENVERILEN"]; }
            set { this["MUVAKKATENVERILEN"] = value; }
        }

        public STCAction STCAction
        {
            get { return (STCAction)((ITTObject)this).GetParent("STCACTION"); }
            set { this["STCACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MCAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MCAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MCAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MCAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MCAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MCACTION", dataRow) { }
        protected MCAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MCACTION", dataRow, isImported) { }
        public MCAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MCAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MCAction() : base() { }

    }
}