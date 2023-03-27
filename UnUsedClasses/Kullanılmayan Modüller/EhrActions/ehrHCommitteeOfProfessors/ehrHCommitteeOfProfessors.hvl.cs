
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrHCommitteeOfProfessors")] 

    /// <summary>
    /// Profesörler Sağlık Kurulu
    /// </summary>
    public  partial class ehrHCommitteeOfProfessors : ehrEpisodeAction
    {
        public class ehrHCommitteeOfProfessorsList : TTObjectCollection<ehrHCommitteeOfProfessors> { }
                    
        public class ChildehrHCommitteeOfProfessorsCollection : TTObject.TTChildObjectCollection<ehrHCommitteeOfProfessors>
        {
            public ChildehrHCommitteeOfProfessorsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrHCommitteeOfProfessorsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Karar
    /// </summary>
        public object Decision
        {
            get { return (object)this["DECISION"]; }
            set { this["DECISION"] = value; }
        }

    /// <summary>
    /// Rapor Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// Gönderilen Onay Makamı
    /// </summary>
        public ConfirmationUnitDefinition ChairSentTo
        {
            get { return (ConfirmationUnitDefinition)((ITTObject)this).GetParent("CHAIRSENTTO"); }
            set { this["CHAIRSENTTO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrHCommitteeOfProfessors(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrHCommitteeOfProfessors(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrHCommitteeOfProfessors(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrHCommitteeOfProfessors(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrHCommitteeOfProfessors(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRHCOMMITTEEOFPROFESSORS", dataRow) { }
        protected ehrHCommitteeOfProfessors(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRHCOMMITTEEOFPROFESSORS", dataRow, isImported) { }
        public ehrHCommitteeOfProfessors(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrHCommitteeOfProfessors(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrHCommitteeOfProfessors() : base() { }

    }
}