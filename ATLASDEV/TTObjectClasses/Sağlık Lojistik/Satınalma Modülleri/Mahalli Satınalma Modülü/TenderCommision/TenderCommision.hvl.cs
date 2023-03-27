
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TenderCommision")] 

    /// <summary>
    /// İhale Komisyonu Üyeleri İçin Kullanılan Sınıftır. Her Komisyon Üyesi İçin Yeni Bir Instance Yaratılır
    /// </summary>
    public  partial class TenderCommision : CommisionMember
    {
        public class TenderCommisionList : TTObjectCollection<TenderCommision> { }
                    
        public class ChildTenderCommisionCollection : TTObject.TTChildObjectCollection<TenderCommision>
        {
            public ChildTenderCommisionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTenderCommisionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPrimeMembersByProjectObjectID_Class : TTReportNqlObject 
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

            public CommisionMemberDutyEnum? MemberDuty
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEMBERDUTY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TENDERCOMMISION"].AllPropertyDefs["MEMBERDUTY"].DataType;
                    return (CommisionMemberDutyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? PrimeBackup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIMEBACKUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TENDERCOMMISION"].AllPropertyDefs["PRIMEBACKUP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? CommisionOrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMMISIONORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TENDERCOMMISION"].AllPropertyDefs["COMMISIONORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string NameString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAMESTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TENDERCOMMISION"].AllPropertyDefs["NAMESTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Namesurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAMESURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Rankname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANKNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPrimeMembersByProjectObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPrimeMembersByProjectObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPrimeMembersByProjectObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMembersByProjectObjectID_Class : TTReportNqlObject 
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

            public CommisionMemberDutyEnum? MemberDuty
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEMBERDUTY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TENDERCOMMISION"].AllPropertyDefs["MEMBERDUTY"].DataType;
                    return (CommisionMemberDutyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? PrimeBackup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIMEBACKUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TENDERCOMMISION"].AllPropertyDefs["PRIMEBACKUP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? CommisionOrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMMISIONORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TENDERCOMMISION"].AllPropertyDefs["COMMISIONORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string NameString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAMESTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TENDERCOMMISION"].AllPropertyDefs["NAMESTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Namesurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAMESURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Rankname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANKNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMembersByProjectObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMembersByProjectObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMembersByProjectObjectID_Class() : base() { }
        }

        public static BindingList<TenderCommision.GetPrimeMembersByProjectObjectID_Class> GetPrimeMembersByProjectObjectID(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TENDERCOMMISION"].QueryDefs["GetPrimeMembersByProjectObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<TenderCommision.GetPrimeMembersByProjectObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<TenderCommision.GetPrimeMembersByProjectObjectID_Class> GetPrimeMembersByProjectObjectID(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TENDERCOMMISION"].QueryDefs["GetPrimeMembersByProjectObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<TenderCommision.GetPrimeMembersByProjectObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<TenderCommision.GetMembersByProjectObjectID_Class> GetMembersByProjectObjectID(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TENDERCOMMISION"].QueryDefs["GetMembersByProjectObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<TenderCommision.GetMembersByProjectObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<TenderCommision.GetMembersByProjectObjectID_Class> GetMembersByProjectObjectID(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TENDERCOMMISION"].QueryDefs["GetMembersByProjectObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<TenderCommision.GetMembersByProjectObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public PurchaseProject PurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("PURCHASEPROJECT"); }
            set { this["PURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TenderCommision(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TenderCommision(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TenderCommision(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TenderCommision(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TenderCommision(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TENDERCOMMISION", dataRow) { }
        protected TenderCommision(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TENDERCOMMISION", dataRow, isImported) { }
        public TenderCommision(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TenderCommision(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TenderCommision() : base() { }

    }
}