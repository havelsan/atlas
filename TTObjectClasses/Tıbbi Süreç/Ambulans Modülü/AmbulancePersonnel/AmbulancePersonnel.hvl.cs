
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AmbulancePersonnel")] 

    /// <summary>
    /// Ambulans İşlemlerinde Ambulan Personeli Bilgilerini Taşıyan Nesne
    /// </summary>
    public  partial class AmbulancePersonnel : TTObject
    {
        public class AmbulancePersonnelList : TTObjectCollection<AmbulancePersonnel> { }
                    
        public class ChildAmbulancePersonnelCollection : TTObject.TTChildObjectCollection<AmbulancePersonnel>
        {
            public ChildAmbulancePersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAmbulancePersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAmbulancePersonnelNQL_Class : TTReportNqlObject 
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

            public string Work
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["AMBULANCEPERSONNEL"].AllPropertyDefs["WORK"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAmbulancePersonnelNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAmbulancePersonnelNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAmbulancePersonnelNQL_Class() : base() { }
        }

        public static BindingList<AmbulancePersonnel.GetAmbulancePersonnelNQL_Class> GetAmbulancePersonnelNQL(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AMBULANCEPERSONNEL"].QueryDefs["GetAmbulancePersonnelNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<AmbulancePersonnel.GetAmbulancePersonnelNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AmbulancePersonnel.GetAmbulancePersonnelNQL_Class> GetAmbulancePersonnelNQL(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["AMBULANCEPERSONNEL"].QueryDefs["GetAmbulancePersonnelNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<AmbulancePersonnel.GetAmbulancePersonnelNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Personelin Görevi
    /// </summary>
        public string Work
        {
            get { return (string)this["WORK"]; }
            set { this["WORK"] = value; }
        }

    /// <summary>
    /// Personnel
    /// </summary>
        public ResUser Personnel
        {
            get { return (ResUser)((ITTObject)this).GetParent("PERSONNEL"); }
            set { this["PERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Ambulance Ambulance
        {
            get { return (Ambulance)((ITTObject)this).GetParent("AMBULANCE"); }
            set { this["AMBULANCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AmbulancePersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AmbulancePersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AmbulancePersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AmbulancePersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AmbulancePersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AMBULANCEPERSONNEL", dataRow) { }
        protected AmbulancePersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AMBULANCEPERSONNEL", dataRow, isImported) { }
        public AmbulancePersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AmbulancePersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AmbulancePersonnel() : base() { }

    }
}