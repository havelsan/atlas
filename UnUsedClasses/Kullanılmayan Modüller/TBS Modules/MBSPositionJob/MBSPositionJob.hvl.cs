
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSPositionJob")] 

    public  partial class MBSPositionJob : TTObject
    {
        public class MBSPositionJobList : TTObjectCollection<MBSPositionJob> { }
                    
        public class ChildMBSPositionJobCollection : TTObject.TTChildObjectCollection<MBSPositionJob>
        {
            public ChildMBSPositionJobCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSPositionJobCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tazminat puanı
    /// </summary>
        public double? IndemnityPoint
        {
            get { return (double?)this["INDEMNITYPOINT"]; }
            set { this["INDEMNITYPOINT"] = value; }
        }

    /// <summary>
    /// Ek gösterge
    /// </summary>
        public int? AdditionalIndicator
        {
            get { return (int?)this["ADDITIONALINDICATOR"]; }
            set { this["ADDITIONALINDICATOR"] = value; }
        }

    /// <summary>
    /// ünvan
    /// </summary>
        public string Title
        {
            get { return (string)this["TITLE"]; }
            set { this["TITLE"] = value; }
        }

        public string RankBranch
        {
            get { return (string)this["RANKBRANCH"]; }
            set { this["RANKBRANCH"] = value; }
        }

    /// <summary>
    /// Tür
    /// </summary>
        public int? Type
        {
            get { return (int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Öğrenim durumu
    /// </summary>
        public string Education
        {
            get { return (string)this["EDUCATION"]; }
            set { this["EDUCATION"] = value; }
        }

    /// <summary>
    /// Derece
    /// </summary>
        public int? Degree
        {
            get { return (int?)this["DEGREE"]; }
            set { this["DEGREE"] = value; }
        }

        public MBSPeriod Period
        {
            get { return (MBSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBSPositionJob(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSPositionJob(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSPositionJob(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSPositionJob(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSPositionJob(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSPOSITIONJOB", dataRow) { }
        protected MBSPositionJob(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSPOSITIONJOB", dataRow, isImported) { }
        public MBSPositionJob(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSPositionJob(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSPositionJob() : base() { }

    }
}