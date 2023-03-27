
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TerminologyManagerDef")] 

    public  abstract  partial class TerminologyManagerDef : TTDefinitionSet
    {
        public class TerminologyManagerDefList : TTObjectCollection<TerminologyManagerDef> { }
                    
        public class ChildTerminologyManagerDefCollection : TTObject.TTChildObjectCollection<TerminologyManagerDef>
        {
            public ChildTerminologyManagerDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTerminologyManagerDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAllDefsByLastUpdate_ReportQuery_Class : TTReportNqlObject 
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

            public GetAllDefsByLastUpdate_ReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllDefsByLastUpdate_ReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllDefsByLastUpdate_ReportQuery_Class() : base() { }
        }

        public static BindingList<TerminologyManagerDef> GetAllDefsByLastUpdate(TTObjectContext objectContext, DateTime LASTUPDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TERMINOLOGYMANAGERDEF"].QueryDefs["GetAllDefsByLastUpdate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LASTUPDATE", LASTUPDATE);

            return ((ITTQuery)objectContext).QueryObjects<TerminologyManagerDef>(queryDef, paramList);
        }

        public static BindingList<TerminologyManagerDef.GetAllDefsByLastUpdate_ReportQuery_Class> GetAllDefsByLastUpdate_ReportQuery(DateTime LASTUPDATE, Guid OBJECTDEFID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TERMINOLOGYMANAGERDEF"].QueryDefs["GetAllDefsByLastUpdate_ReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LASTUPDATE", LASTUPDATE);
            paramList.Add("OBJECTDEFID", OBJECTDEFID);

            return TTReportNqlObject.QueryObjects<TerminologyManagerDef.GetAllDefsByLastUpdate_ReportQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TerminologyManagerDef.GetAllDefsByLastUpdate_ReportQuery_Class> GetAllDefsByLastUpdate_ReportQuery(TTObjectContext objectContext, DateTime LASTUPDATE, Guid OBJECTDEFID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TERMINOLOGYMANAGERDEF"].QueryDefs["GetAllDefsByLastUpdate_ReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LASTUPDATE", LASTUPDATE);
            paramList.Add("OBJECTDEFID", OBJECTDEFID);

            return TTReportNqlObject.QueryObjects<TerminologyManagerDef.GetAllDefsByLastUpdate_ReportQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateDefinitionConceptsCollection()
        {
            _DefinitionConcepts = new DefinitionConcept.ChildDefinitionConceptCollection(this, new Guid("11b0b054-54b3-4229-ac64-235892c35385"));
            ((ITTChildObjectCollection)_DefinitionConcepts).GetChildren();
        }

        protected DefinitionConcept.ChildDefinitionConceptCollection _DefinitionConcepts = null;
    /// <summary>
    /// Child collection for Terminology Manager Definition-Tanım Kavramları
    /// </summary>
        public DefinitionConcept.ChildDefinitionConceptCollection DefinitionConcepts
        {
            get
            {
                if (_DefinitionConcepts == null)
                    CreateDefinitionConceptsCollection();
                return _DefinitionConcepts;
            }
        }

        protected TerminologyManagerDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TerminologyManagerDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TerminologyManagerDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TerminologyManagerDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TerminologyManagerDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TERMINOLOGYMANAGERDEF", dataRow) { }
        protected TerminologyManagerDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TERMINOLOGYMANAGERDEF", dataRow, isImported) { }
        public TerminologyManagerDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TerminologyManagerDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TerminologyManagerDef() : base() { }

    }
}