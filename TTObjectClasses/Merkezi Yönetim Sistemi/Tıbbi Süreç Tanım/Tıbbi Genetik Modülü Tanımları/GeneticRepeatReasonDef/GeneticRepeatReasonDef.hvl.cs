
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneticRepeatReasonDef")] 

    public  partial class GeneticRepeatReasonDef : LabBaseRepeatReasonDef
    {
        public class GeneticRepeatReasonDefList : TTObjectCollection<GeneticRepeatReasonDef> { }
                    
        public class ChildGeneticRepeatReasonDefCollection : TTObject.TTChildObjectCollection<GeneticRepeatReasonDef>
        {
            public ChildGeneticRepeatReasonDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneticRepeatReasonDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GeneticRepeatReasonDefFormNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENETICREPEATREASONDEF"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENETICREPEATREASONDEF"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENETICREPEATREASONDEF"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENETICREPEATREASONDEF"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GeneticRepeatReasonDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GeneticRepeatReasonDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GeneticRepeatReasonDefFormNQL_Class() : base() { }
        }

        public static BindingList<GeneticRepeatReasonDef> GetAll(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENETICREPEATREASONDEF"].QueryDefs["GetAll"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<GeneticRepeatReasonDef>(queryDef, paramList);
        }

        public static BindingList<GeneticRepeatReasonDef.GeneticRepeatReasonDefFormNQL_Class> GeneticRepeatReasonDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENETICREPEATREASONDEF"].QueryDefs["GeneticRepeatReasonDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GeneticRepeatReasonDef.GeneticRepeatReasonDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<GeneticRepeatReasonDef.GeneticRepeatReasonDefFormNQL_Class> GeneticRepeatReasonDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENETICREPEATREASONDEF"].QueryDefs["GeneticRepeatReasonDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GeneticRepeatReasonDef.GeneticRepeatReasonDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<GeneticRepeatReasonDef> GetGeneticReptReasnDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENETICREPEATREASONDEF"].QueryDefs["GetGeneticReptReasnDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<GeneticRepeatReasonDef>(queryDef, paramList);
        }

        protected GeneticRepeatReasonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneticRepeatReasonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneticRepeatReasonDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneticRepeatReasonDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneticRepeatReasonDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENETICREPEATREASONDEF", dataRow) { }
        protected GeneticRepeatReasonDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENETICREPEATREASONDEF", dataRow, isImported) { }
        public GeneticRepeatReasonDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneticRepeatReasonDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneticRepeatReasonDef() : base() { }

    }
}