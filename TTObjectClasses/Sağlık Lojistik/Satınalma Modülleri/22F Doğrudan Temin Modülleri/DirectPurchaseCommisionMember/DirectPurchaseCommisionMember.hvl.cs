
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DirectPurchaseCommisionMember")] 

    public  partial class DirectPurchaseCommisionMember : CommisionMember
    {
        public class DirectPurchaseCommisionMemberList : TTObjectCollection<DirectPurchaseCommisionMember> { }
                    
        public class ChildDirectPurchaseCommisionMemberCollection : TTObject.TTChildObjectCollection<DirectPurchaseCommisionMember>
        {
            public ChildDirectPurchaseCommisionMemberCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDirectPurchaseCommisionMemberCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDPCommisionMemberByDPA_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASECOMMISIONMEMBER"].AllPropertyDefs["MEMBERDUTY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASECOMMISIONMEMBER"].AllPropertyDefs["PRIMEBACKUP"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASECOMMISIONMEMBER"].AllPropertyDefs["COMMISIONORDERNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASECOMMISIONMEMBER"].AllPropertyDefs["NAMESTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? PrintOnMatInspection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRINTONMATINSPECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASECOMMISIONMEMBER"].AllPropertyDefs["PRINTONMATINSPECTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["SHORTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sinif
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SINIF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["SHORTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDPCommisionMemberByDPA_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDPCommisionMemberByDPA_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDPCommisionMemberByDPA_Class() : base() { }
        }

        public static BindingList<DirectPurchaseCommisionMember.GetDPCommisionMemberByDPA_Class> GetDPCommisionMemberByDPA(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASECOMMISIONMEMBER"].QueryDefs["GetDPCommisionMemberByDPA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DirectPurchaseCommisionMember.GetDPCommisionMemberByDPA_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseCommisionMember.GetDPCommisionMemberByDPA_Class> GetDPCommisionMemberByDPA(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASECOMMISIONMEMBER"].QueryDefs["GetDPCommisionMemberByDPA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DirectPurchaseCommisionMember.GetDPCommisionMemberByDPA_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Muayene Raporuna Basılsın
    /// </summary>
        public bool? PrintOnMatInspection
        {
            get { return (bool?)this["PRINTONMATINSPECTION"]; }
            set { this["PRINTONMATINSPECTION"] = value; }
        }

    /// <summary>
    /// Komisyon Üyeleri
    /// </summary>
        public DirectPurchaseAction DirectPurchaseAction
        {
            get { return (DirectPurchaseAction)((ITTObject)this).GetParent("DIRECTPURCHASEACTION"); }
            set { this["DIRECTPURCHASEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DirectPurchaseCommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DirectPurchaseCommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DirectPurchaseCommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DirectPurchaseCommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DirectPurchaseCommisionMember(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIRECTPURCHASECOMMISIONMEMBER", dataRow) { }
        protected DirectPurchaseCommisionMember(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIRECTPURCHASECOMMISIONMEMBER", dataRow, isImported) { }
        public DirectPurchaseCommisionMember(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DirectPurchaseCommisionMember(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DirectPurchaseCommisionMember() : base() { }

    }
}