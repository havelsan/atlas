
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResWard")] 

    /// <summary>
    /// Yatan Hasta Birimi(Koğuş)
    /// </summary>
    public  partial class ResWard : ResSection
    {
        public class ResWardList : TTObjectCollection<ResWard> { }
                    
        public class ChildResWardCollection : TTObject.TTChildObjectCollection<ResWard>
        {
            public ChildResWardCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResWardCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetWardDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetWardDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWardDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWardDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_ResWard_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public OLAP_ResWard_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResWard_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResWard_Class() : base() { }
        }

        public static BindingList<ResWard.GetWardDefinition_Class> GetWardDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].QueryDefs["GetWardDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResWard.GetWardDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResWard.GetWardDefinition_Class> GetWardDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].QueryDefs["GetWardDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResWard.GetWardDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResWard.OLAP_ResWard_Class> OLAP_ResWard(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].QueryDefs["OLAP_ResWard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResWard.OLAP_ResWard_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResWard.OLAP_ResWard_Class> OLAP_ResWard(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].QueryDefs["OLAP_ResWard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResWard.OLAP_ResWard_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResWard> OLAP_ResWard_OQ(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].QueryDefs["OLAP_ResWard_OQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResWard>(queryDef, paramList);
        }

        public static BindingList<ResWard> GetResWards(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].QueryDefs["GetResWards"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResWard>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResWard> GetResWardWityEmtyBed(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].QueryDefs["GetResWardWityEmtyBed"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResWard>(queryDef, paramList);
        }

        public static BindingList<ResWard> GetByID(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].QueryDefs["GetByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<ResWard>(queryDef, paramList);
        }

    /// <summary>
    /// 112'ye Bildirilecek Boş Yatak Yüzdesi
    /// </summary>
        public int? PercentageOfEmptyBedFor112
        {
            get { return (int?)this["PERCENTAGEOFEMPTYBEDFOR112"]; }
            set { this["PERCENTAGEOFEMPTYBEDFOR112"] = value; }
        }

        public string Floor
        {
            get { return (string)this["FLOOR"]; }
            set { this["FLOOR"] = value; }
        }

    /// <summary>
    /// Yoğun Bakım
    /// </summary>
        public bool? IsIntensiveCare
        {
            get { return (bool?)this["ISINTENSIVECARE"]; }
            set { this["ISINTENSIVECARE"] = value; }
        }

    /// <summary>
    /// Servis Yatak Tipi
    /// </summary>
        public BedProcedureTypeEnum? BedProcedureType
        {
            get { return (BedProcedureTypeEnum?)(int?)this["BEDPROCEDURETYPE"]; }
            set { this["BEDPROCEDURETYPE"] = value; }
        }

    /// <summary>
    /// XXXXXX
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Res112ClinicDef Res112ClinicDef
        {
            get { return (Res112ClinicDef)((ITTObject)this).GetParent("RES112CLINICDEF"); }
            set { this["RES112CLINICDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateRoomGroupsCollection()
        {
            _RoomGroups = new ResRoomGroup.ChildResRoomGroupCollection(this, new Guid("1ca5d9b3-002f-42a5-aebe-61da7bc65b61"));
            ((ITTChildObjectCollection)_RoomGroups).GetChildren();
        }

        protected ResRoomGroup.ChildResRoomGroupCollection _RoomGroups = null;
    /// <summary>
    /// Child collection for Yatan Hasta Birimi
    /// </summary>
        public ResRoomGroup.ChildResRoomGroupCollection RoomGroups
        {
            get
            {
                if (_RoomGroups == null)
                    CreateRoomGroupsCollection();
                return _RoomGroups;
            }
        }

        protected ResWard(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResWard(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResWard(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResWard(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResWard(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESWARD", dataRow) { }
        protected ResWard(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESWARD", dataRow, isImported) { }
        public ResWard(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResWard(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResWard() : base() { }

    }
}