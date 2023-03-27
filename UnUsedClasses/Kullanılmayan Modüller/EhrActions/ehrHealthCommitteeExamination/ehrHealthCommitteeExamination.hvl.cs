
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrHealthCommitteeExamination")] 

    /// <summary>
    /// Sağlık Kurulu Muayenesi
    /// </summary>
    public  partial class ehrHealthCommitteeExamination : ehrEpisodeAction
    {
        public class ehrHealthCommitteeExaminationList : TTObjectCollection<ehrHealthCommitteeExamination> { }
                    
        public class ChildehrHealthCommitteeExaminationCollection : TTObject.TTChildObjectCollection<ehrHealthCommitteeExamination>
        {
            public ChildehrHealthCommitteeExaminationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrHealthCommitteeExaminationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Kilo
    /// </summary>
        public int? Weight
        {
            get { return (int?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

    /// <summary>
    /// Boy
    /// </summary>
        public double? Height
        {
            get { return (double?)this["HEIGHT"]; }
            set { this["HEIGHT"] = value; }
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
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrHealthCommitteeExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrHealthCommitteeExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrHealthCommitteeExamination(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrHealthCommitteeExamination(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrHealthCommitteeExamination(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRHEALTHCOMMITTEEEXAMINATION", dataRow) { }
        protected ehrHealthCommitteeExamination(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRHEALTHCOMMITTEEEXAMINATION", dataRow, isImported) { }
        public ehrHealthCommitteeExamination(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrHealthCommitteeExamination(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrHealthCommitteeExamination() : base() { }

    }
}