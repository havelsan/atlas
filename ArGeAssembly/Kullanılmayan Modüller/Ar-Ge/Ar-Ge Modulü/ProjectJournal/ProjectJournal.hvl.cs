
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProjectJournal")] 

    public  partial class ProjectJournal : TTObject
    {
        public class ProjectJournalList : TTObjectCollection<ProjectJournal> { }
                    
        public class ChildProjectJournalCollection : TTObject.TTChildObjectCollection<ProjectJournal>
        {
            public ChildProjectJournalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProjectJournalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string AuthorName
        {
            get { return (string)this["AUTHORNAME"]; }
            set { this["AUTHORNAME"] = value; }
        }

        public string AuthorSurname
        {
            get { return (string)this["AUTHORSURNAME"]; }
            set { this["AUTHORSURNAME"] = value; }
        }

        public DateTime? JournalDate
        {
            get { return (DateTime?)this["JOURNALDATE"]; }
            set { this["JOURNALDATE"] = value; }
        }

        public string JournalPlace
        {
            get { return (string)this["JOURNALPLACE"]; }
            set { this["JOURNALPLACE"] = value; }
        }

        public string JournalText
        {
            get { return (string)this["JOURNALTEXT"]; }
            set { this["JOURNALTEXT"] = value; }
        }

        public string Journal
        {
            get { return (string)this["JOURNAL"]; }
            set { this["JOURNAL"] = value; }
        }

        public JournalSpeciesDef JournalType
        {
            get { return (JournalSpeciesDef)((ITTObject)this).GetParent("JOURNALTYPE"); }
            set { this["JOURNALTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ArgeProject Project
        {
            get { return (ArgeProject)((ITTObject)this).GetParent("PROJECT"); }
            set { this["PROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProjectJournal(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProjectJournal(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProjectJournal(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProjectJournal(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProjectJournal(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROJECTJOURNAL", dataRow) { }
        protected ProjectJournal(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROJECTJOURNAL", dataRow, isImported) { }
        public ProjectJournal(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProjectJournal(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProjectJournal() : base() { }

    }
}