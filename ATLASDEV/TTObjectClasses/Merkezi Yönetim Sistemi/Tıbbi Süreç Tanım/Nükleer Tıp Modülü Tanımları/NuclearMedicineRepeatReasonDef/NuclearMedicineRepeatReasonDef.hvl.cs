
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NuclearMedicineRepeatReasonDef")] 

    public  partial class NuclearMedicineRepeatReasonDef : LabBaseRepeatReasonDef
    {
        public class NuclearMedicineRepeatReasonDefList : TTObjectCollection<NuclearMedicineRepeatReasonDef> { }
                    
        public class ChildNuclearMedicineRepeatReasonDefCollection : TTObject.TTChildObjectCollection<NuclearMedicineRepeatReasonDef>
        {
            public ChildNuclearMedicineRepeatReasonDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNuclearMedicineRepeatReasonDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class NuclearMedicineRepeatReasonDefFormNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINEREPEATREASONDEF"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINEREPEATREASONDEF"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINEREPEATREASONDEF"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINEREPEATREASONDEF"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public NuclearMedicineRepeatReasonDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public NuclearMedicineRepeatReasonDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected NuclearMedicineRepeatReasonDefFormNQL_Class() : base() { }
        }

        public static BindingList<NuclearMedicineRepeatReasonDef.NuclearMedicineRepeatReasonDefFormNQL_Class> NuclearMedicineRepeatReasonDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINEREPEATREASONDEF"].QueryDefs["NuclearMedicineRepeatReasonDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NuclearMedicineRepeatReasonDef.NuclearMedicineRepeatReasonDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NuclearMedicineRepeatReasonDef.NuclearMedicineRepeatReasonDefFormNQL_Class> NuclearMedicineRepeatReasonDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINEREPEATREASONDEF"].QueryDefs["NuclearMedicineRepeatReasonDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NuclearMedicineRepeatReasonDef.NuclearMedicineRepeatReasonDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NuclearMedicineRepeatReasonDef> GetNucMedReptReasnDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINEREPEATREASONDEF"].QueryDefs["GetNucMedReptReasnDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<NuclearMedicineRepeatReasonDef>(queryDef, paramList);
        }

        protected NuclearMedicineRepeatReasonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NuclearMedicineRepeatReasonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NuclearMedicineRepeatReasonDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NuclearMedicineRepeatReasonDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NuclearMedicineRepeatReasonDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUCLEARMEDICINEREPEATREASONDEF", dataRow) { }
        protected NuclearMedicineRepeatReasonDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUCLEARMEDICINEREPEATREASONDEF", dataRow, isImported) { }
        public NuclearMedicineRepeatReasonDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NuclearMedicineRepeatReasonDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NuclearMedicineRepeatReasonDef() : base() { }

    }
}