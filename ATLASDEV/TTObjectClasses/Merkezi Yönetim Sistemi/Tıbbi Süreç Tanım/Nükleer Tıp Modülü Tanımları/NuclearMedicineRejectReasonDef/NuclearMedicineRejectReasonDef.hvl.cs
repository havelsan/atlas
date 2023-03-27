
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NuclearMedicineRejectReasonDef")] 

    public  partial class NuclearMedicineRejectReasonDef : LabBaseRejectReasonDef
    {
        public class NuclearMedicineRejectReasonDefList : TTObjectCollection<NuclearMedicineRejectReasonDef> { }
                    
        public class ChildNuclearMedicineRejectReasonDefCollection : TTObject.TTChildObjectCollection<NuclearMedicineRejectReasonDef>
        {
            public ChildNuclearMedicineRejectReasonDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNuclearMedicineRejectReasonDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class NuclearMedicineRejectReasonDefFormNQL_Class : TTReportNqlObject 
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

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINEREJECTREASONDEF"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINEREJECTREASONDEF"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINEREJECTREASONDEF"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINEREJECTREASONDEF"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public NuclearMedicineRejectReasonDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public NuclearMedicineRejectReasonDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected NuclearMedicineRejectReasonDefFormNQL_Class() : base() { }
        }

        public static BindingList<NuclearMedicineRejectReasonDef.NuclearMedicineRejectReasonDefFormNQL_Class> NuclearMedicineRejectReasonDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINEREJECTREASONDEF"].QueryDefs["NuclearMedicineRejectReasonDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NuclearMedicineRejectReasonDef.NuclearMedicineRejectReasonDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NuclearMedicineRejectReasonDef.NuclearMedicineRejectReasonDefFormNQL_Class> NuclearMedicineRejectReasonDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINEREJECTREASONDEF"].QueryDefs["NuclearMedicineRejectReasonDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NuclearMedicineRejectReasonDef.NuclearMedicineRejectReasonDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NuclearMedicineRejectReasonDef> GetNucMedRejctReasnDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINEREJECTREASONDEF"].QueryDefs["GetNucMedRejctReasnDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<NuclearMedicineRejectReasonDef>(queryDef, paramList);
        }

        protected NuclearMedicineRejectReasonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NuclearMedicineRejectReasonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NuclearMedicineRejectReasonDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NuclearMedicineRejectReasonDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NuclearMedicineRejectReasonDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUCLEARMEDICINEREJECTREASONDEF", dataRow) { }
        protected NuclearMedicineRejectReasonDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUCLEARMEDICINEREJECTREASONDEF", dataRow, isImported) { }
        public NuclearMedicineRejectReasonDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NuclearMedicineRejectReasonDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NuclearMedicineRejectReasonDef() : base() { }

    }
}