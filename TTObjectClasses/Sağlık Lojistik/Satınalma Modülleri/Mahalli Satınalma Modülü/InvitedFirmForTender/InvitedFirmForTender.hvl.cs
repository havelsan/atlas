
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvitedFirmForTender")] 

    /// <summary>
    /// İhaleye Davet Edilecek Firmaların Tutulduğu Sınıftır
    /// </summary>
    public  partial class InvitedFirmForTender : TTObject
    {
        public class InvitedFirmForTenderList : TTObjectCollection<InvitedFirmForTender> { }
                    
        public class ChildInvitedFirmForTenderCollection : TTObject.TTChildObjectCollection<InvitedFirmForTender>
        {
            public ChildInvitedFirmForTenderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvitedFirmForTenderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInvitedFirmsByProjectObjectID_Class : TTReportNqlObject 
        {
            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Address
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KIKTenderRegisterNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIKTENDERREGISTERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["KIKTENDERREGISTERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInvitedFirmsByProjectObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInvitedFirmsByProjectObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInvitedFirmsByProjectObjectID_Class() : base() { }
        }

        public static BindingList<InvitedFirmForTender.GetInvitedFirmsByProjectObjectID_Class> GetInvitedFirmsByProjectObjectID(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVITEDFIRMFORTENDER"].QueryDefs["GetInvitedFirmsByProjectObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<InvitedFirmForTender.GetInvitedFirmsByProjectObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvitedFirmForTender.GetInvitedFirmsByProjectObjectID_Class> GetInvitedFirmsByProjectObjectID(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVITEDFIRMFORTENDER"].QueryDefs["GetInvitedFirmsByProjectObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<InvitedFirmForTender.GetInvitedFirmsByProjectObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseProject PurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("PURCHASEPROJECT"); }
            set { this["PURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InvitedFirmForTender(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvitedFirmForTender(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvitedFirmForTender(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvitedFirmForTender(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvitedFirmForTender(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVITEDFIRMFORTENDER", dataRow) { }
        protected InvitedFirmForTender(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVITEDFIRMFORTENDER", dataRow, isImported) { }
        public InvitedFirmForTender(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvitedFirmForTender(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvitedFirmForTender() : base() { }

    }
}