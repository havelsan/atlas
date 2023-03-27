
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCUncompletedPrevious")] 

    public  partial class HCUncompletedPrevious : TTObject
    {
        public class HCUncompletedPreviousList : TTObjectCollection<HCUncompletedPrevious> { }
                    
        public class ChildHCUncompletedPreviousCollection : TTObject.TTChildObjectCollection<HCUncompletedPrevious>
        {
            public ChildHCUncompletedPreviousCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCUncompletedPreviousCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Vakanın XXXXXX Protokol No
    /// </summary>
        public string EpisodeHospitalProtocolNo
        {
            get { return (string)this["EPISODEHOSPITALPROTOCOLNO"]; }
            set { this["EPISODEHOSPITALPROTOCOLNO"] = value; }
        }

    /// <summary>
    /// Vaka Açılış Tarihi
    /// </summary>
        public DateTime? EpisodeOpeningDate
        {
            get { return (DateTime?)this["EPISODEOPENINGDATE"]; }
            set { this["EPISODEOPENINGDATE"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu işlem numarası
    /// </summary>
        public string HCActionID
        {
            get { return (string)this["HCACTIONID"]; }
            set { this["HCACTIONID"] = value; }
        }

    /// <summary>
    /// Oluşturulma Tarihi
    /// </summary>
        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu işleminin ObjectID si
    /// </summary>
        public Guid? HCObjectID
        {
            get { return (Guid?)this["HCOBJECTID"]; }
            set { this["HCOBJECTID"] = value; }
        }

    /// <summary>
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Saha
    /// </summary>
        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCUncompletedPrevious(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCUncompletedPrevious(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCUncompletedPrevious(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCUncompletedPrevious(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCUncompletedPrevious(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCUNCOMPLETEDPREVIOUS", dataRow) { }
        protected HCUncompletedPrevious(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCUNCOMPLETEDPREVIOUS", dataRow, isImported) { }
        public HCUncompletedPrevious(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCUncompletedPrevious(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCUncompletedPrevious() : base() { }

    }
}