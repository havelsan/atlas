
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseHealthCommittee_ExtDoctorGrid")] 

    /// <summary>
    /// Sağlık kurulu XXXXXX dışı doktorlar
    /// </summary>
    public  partial class BaseHealthCommittee_ExtDoctorGrid : TTObject
    {
        public class BaseHealthCommittee_ExtDoctorGridList : TTObjectCollection<BaseHealthCommittee_ExtDoctorGrid> { }
                    
        public class ChildBaseHealthCommittee_ExtDoctorGridCollection : TTObject.TTChildObjectCollection<BaseHealthCommittee_ExtDoctorGrid>
        {
            public ChildBaseHealthCommittee_ExtDoctorGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseHealthCommittee_ExtDoctorGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetExternalRejectedUserByHCID_Class : TTReportNqlObject 
        {
            public string ExternalDoctorName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEHEALTHCOMMITTEE_EXTDOCTORGRID"].AllPropertyDefs["EXTERNALDOCTORNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEHEALTHCOMMITTEE_EXTDOCTORGRID"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetExternalRejectedUserByHCID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExternalRejectedUserByHCID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExternalRejectedUserByHCID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLastUpdatedHCID_Class : TTReportNqlObject 
        {
            public Guid? BaseHealthCommittee
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BASEHEALTHCOMMITTEE"]);
                }
            }

            public GetLastUpdatedHCID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLastUpdatedHCID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLastUpdatedHCID_Class() : base() { }
        }

        public static BindingList<BaseHealthCommittee_ExtDoctorGrid.GetExternalRejectedUserByHCID_Class> GetExternalRejectedUserByHCID(Guid HCID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEHEALTHCOMMITTEE_EXTDOCTORGRID"].QueryDefs["GetExternalRejectedUserByHCID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HCID", HCID);

            return TTReportNqlObject.QueryObjects<BaseHealthCommittee_ExtDoctorGrid.GetExternalRejectedUserByHCID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseHealthCommittee_ExtDoctorGrid.GetExternalRejectedUserByHCID_Class> GetExternalRejectedUserByHCID(TTObjectContext objectContext, Guid HCID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEHEALTHCOMMITTEE_EXTDOCTORGRID"].QueryDefs["GetExternalRejectedUserByHCID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HCID", HCID);

            return TTReportNqlObject.QueryObjects<BaseHealthCommittee_ExtDoctorGrid.GetExternalRejectedUserByHCID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// En son girilen doktor listesi
    /// </summary>
        public static BindingList<BaseHealthCommittee_ExtDoctorGrid> GetLastUpdatedExtDoctorList(TTObjectContext objectContext, Guid BASEHEALTHCOMMITTEE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEHEALTHCOMMITTEE_EXTDOCTORGRID"].QueryDefs["GetLastUpdatedExtDoctorList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BASEHEALTHCOMMITTEE", BASEHEALTHCOMMITTEE);

            return ((ITTQuery)objectContext).QueryObjects<BaseHealthCommittee_ExtDoctorGrid>(queryDef, paramList);
        }

        public static BindingList<BaseHealthCommittee_ExtDoctorGrid.GetLastUpdatedHCID_Class> GetLastUpdatedHCID(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEHEALTHCOMMITTEE_EXTDOCTORGRID"].QueryDefs["GetLastUpdatedHCID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseHealthCommittee_ExtDoctorGrid.GetLastUpdatedHCID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseHealthCommittee_ExtDoctorGrid.GetLastUpdatedHCID_Class> GetLastUpdatedHCID(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEHEALTHCOMMITTEE_EXTDOCTORGRID"].QueryDefs["GetLastUpdatedHCID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseHealthCommittee_ExtDoctorGrid.GetLastUpdatedHCID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Uzmanlık Tesis Numarası
    /// </summary>
        public string ExternalDoctorSpecialityRegNo
        {
            get { return (string)this["EXTERNALDOCTORSPECIALITYREGNO"]; }
            set { this["EXTERNALDOCTORSPECIALITYREGNO"] = value; }
        }

    /// <summary>
    /// XXXXXX Dışı Doktor Adı
    /// </summary>
        public string ExternalDoctorName
        {
            get { return (string)this["EXTERNALDOCTORNAME"]; }
            set { this["EXTERNALDOCTORNAME"] = value; }
        }

    /// <summary>
    /// Diploma Tesis Numarası
    /// </summary>
        public string ExternalDoctorRegNumber
        {
            get { return (string)this["EXTERNALDOCTORREGNUMBER"]; }
            set { this["EXTERNALDOCTORREGNUMBER"] = value; }
        }

    /// <summary>
    /// Onay
    /// </summary>
        public bool? Approve
        {
            get { return (bool?)this["APPROVE"]; }
            set { this["APPROVE"] = value; }
        }

    /// <summary>
    /// Red
    /// </summary>
        public bool? Reject
        {
            get { return (bool?)this["REJECT"]; }
            set { this["REJECT"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// BaseHealthCommittee_ExtDoctors
    /// </summary>
        public BaseHealthCommittee BaseHealthCommittee
        {
            get { return (BaseHealthCommittee)((ITTObject)this).GetParent("BASEHEALTHCOMMITTEE"); }
            set { this["BASEHEALTHCOMMITTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Dış XXXXXX Branşları
    /// </summary>
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseHealthCommittee_ExtDoctorGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseHealthCommittee_ExtDoctorGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseHealthCommittee_ExtDoctorGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseHealthCommittee_ExtDoctorGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseHealthCommittee_ExtDoctorGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEHEALTHCOMMITTEE_EXTDOCTORGRID", dataRow) { }
        protected BaseHealthCommittee_ExtDoctorGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEHEALTHCOMMITTEE_EXTDOCTORGRID", dataRow, isImported) { }
        public BaseHealthCommittee_ExtDoctorGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseHealthCommittee_ExtDoctorGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseHealthCommittee_ExtDoctorGrid() : base() { }

    }
}