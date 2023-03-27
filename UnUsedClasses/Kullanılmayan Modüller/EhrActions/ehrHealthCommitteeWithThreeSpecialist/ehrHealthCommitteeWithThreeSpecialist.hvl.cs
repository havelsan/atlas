
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrHealthCommitteeWithThreeSpecialist")] 

    /// <summary>
    /// Sağlık Kurulu Üç İmza
    /// </summary>
    public  partial class ehrHealthCommitteeWithThreeSpecialist : ehrEpisodeAction
    {
        public class ehrHealthCommitteeWithThreeSpecialistList : TTObjectCollection<ehrHealthCommitteeWithThreeSpecialist> { }
                    
        public class ChildehrHealthCommitteeWithThreeSpecialistCollection : TTObject.TTChildObjectCollection<ehrHealthCommitteeWithThreeSpecialist>
        {
            public ChildehrHealthCommitteeWithThreeSpecialistCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrHealthCommitteeWithThreeSpecialistCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Karar Teklifi
    /// </summary>
        public string OfferofDecision
        {
            get { return (string)this["OFFEROFDECISION"]; }
            set { this["OFFEROFDECISION"] = value; }
        }

    /// <summary>
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrHealthCommitteeWithThreeSpecialist(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrHealthCommitteeWithThreeSpecialist(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrHealthCommitteeWithThreeSpecialist(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrHealthCommitteeWithThreeSpecialist(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrHealthCommitteeWithThreeSpecialist(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRHEALTHCOMMITTEEWITHTHREESPECIALIST", dataRow) { }
        protected ehrHealthCommitteeWithThreeSpecialist(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRHEALTHCOMMITTEEWITHTHREESPECIALIST", dataRow, isImported) { }
        public ehrHealthCommitteeWithThreeSpecialist(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrHealthCommitteeWithThreeSpecialist(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrHealthCommitteeWithThreeSpecialist() : base() { }

    }
}