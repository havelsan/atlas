
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="JournalSpeciesDef")] 

    public  partial class JournalSpeciesDef : BaseResDevDef
    {
        public class JournalSpeciesDefList : TTObjectCollection<JournalSpeciesDef> { }
                    
        public class ChildJournalSpeciesDefCollection : TTObject.TTChildObjectCollection<JournalSpeciesDef>
        {
            public ChildJournalSpeciesDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildJournalSpeciesDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetJournalSpeciesDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["JOURNALSPECIESDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["JOURNALSPECIESDEF"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetJournalSpeciesDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetJournalSpeciesDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetJournalSpeciesDef_Class() : base() { }
        }

        public static BindingList<JournalSpeciesDef.GetJournalSpeciesDef_Class> GetJournalSpeciesDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["JOURNALSPECIESDEF"].QueryDefs["GetJournalSpeciesDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<JournalSpeciesDef.GetJournalSpeciesDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<JournalSpeciesDef.GetJournalSpeciesDef_Class> GetJournalSpeciesDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["JOURNALSPECIESDEF"].QueryDefs["GetJournalSpeciesDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<JournalSpeciesDef.GetJournalSpeciesDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateJournalCollection()
        {
            _Journal = new ProjectJournal.ChildProjectJournalCollection(this, new Guid("9016df6e-dce2-472d-adf9-bbece3226d2f"));
            ((ITTChildObjectCollection)_Journal).GetChildren();
        }

        protected ProjectJournal.ChildProjectJournalCollection _Journal = null;
        public ProjectJournal.ChildProjectJournalCollection Journal
        {
            get
            {
                if (_Journal == null)
                    CreateJournalCollection();
                return _Journal;
            }
        }

        protected JournalSpeciesDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected JournalSpeciesDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected JournalSpeciesDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected JournalSpeciesDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected JournalSpeciesDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "JOURNALSPECIESDEF", dataRow) { }
        protected JournalSpeciesDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "JOURNALSPECIESDEF", dataRow, isImported) { }
        public JournalSpeciesDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public JournalSpeciesDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public JournalSpeciesDef() : base() { }

    }
}