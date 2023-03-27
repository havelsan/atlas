
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TitleParticipationProcDef")] 

    /// <summary>
    /// Ünvan ve Özel Muayene Hizmeti Eşleştirme Tanımı
    /// </summary>
    public  partial class TitleParticipationProcDef : TTDefinitionSet
    {
        public class TitleParticipationProcDefList : TTObjectCollection<TitleParticipationProcDef> { }
                    
        public class ChildTitleParticipationProcDefCollection : TTObject.TTChildObjectCollection<TitleParticipationProcDef>
        {
            public ChildTitleParticipationProcDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTitleParticipationProcDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTitleParticipationProcDefs_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TITLEPARTICIPATIONPROCDEF"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Procedure
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PROCEDURE"]);
                }
            }

            public GetTitleParticipationProcDefs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTitleParticipationProcDefs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTitleParticipationProcDefs_Class() : base() { }
        }

        public static BindingList<TitleParticipationProcDef> GetTitleParticipationProcDefinitions(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TITLEPARTICIPATIONPROCDEF"].QueryDefs["GetTitleParticipationProcDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<TitleParticipationProcDef>(queryDef, paramList);
        }

        public static BindingList<TitleParticipationProcDef> GetByTitle(TTObjectContext objectContext, UserTitleEnum PARAMTITLE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TITLEPARTICIPATIONPROCDEF"].QueryDefs["GetByTitle"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTITLE", (int)PARAMTITLE);

            return ((ITTQuery)objectContext).QueryObjects<TitleParticipationProcDef>(queryDef, paramList);
        }

        public static BindingList<TitleParticipationProcDef.GetTitleParticipationProcDefs_Class> GetTitleParticipationProcDefs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TITLEPARTICIPATIONPROCDEF"].QueryDefs["GetTitleParticipationProcDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TitleParticipationProcDef.GetTitleParticipationProcDefs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TitleParticipationProcDef.GetTitleParticipationProcDefs_Class> GetTitleParticipationProcDefs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TITLEPARTICIPATIONPROCDEF"].QueryDefs["GetTitleParticipationProcDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TitleParticipationProcDef.GetTitleParticipationProcDefs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Ünvan
    /// </summary>
        public UserTitleEnum? Title
        {
            get { return (UserTitleEnum?)(int?)this["TITLE"]; }
            set { this["TITLE"] = value; }
        }

    /// <summary>
    /// Hizmet
    /// </summary>
        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TitleParticipationProcDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TitleParticipationProcDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TitleParticipationProcDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TitleParticipationProcDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TitleParticipationProcDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TITLEPARTICIPATIONPROCDEF", dataRow) { }
        protected TitleParticipationProcDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TITLEPARTICIPATIONPROCDEF", dataRow, isImported) { }
        protected TitleParticipationProcDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TitleParticipationProcDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TitleParticipationProcDef() : base() { }

    }
}