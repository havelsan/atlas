
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrMorgue")] 

    /// <summary>
    /// Morg
    /// </summary>
    public  partial class ehrMorgue : ehrEpisodeAction
    {
        public class ehrMorgueList : TTObjectCollection<ehrMorgue> { }
                    
        public class ChildehrMorgueCollection : TTObject.TTChildObjectCollection<ehrMorgue>
        {
            public ChildehrMorgueCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrMorgueCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Ölüm Raporunun Tarihi
    /// </summary>
        public DateTime? DateOfDeathReport
        {
            get { return (DateTime?)this["DATEOFDEATHREPORT"]; }
            set { this["DATEOFDEATHREPORT"] = value; }
        }

    /// <summary>
    /// Ölüm Tarihi ve Saati
    /// </summary>
        public DateTime? DateTimeOfDeath
        {
            get { return (DateTime?)this["DATETIMEOFDEATH"]; }
            set { this["DATETIMEOFDEATH"] = value; }
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
    /// İstatistiksel Ölüm Sebebi
    /// </summary>
        public StatisticalDeathReason? StatisticalDeathReason
        {
            get { return (StatisticalDeathReason?)(int?)this["STATISTICALDEATHREASON"]; }
            set { this["STATISTICALDEATHREASON"] = value; }
        }

    /// <summary>
    /// Ölüm Yeri
    /// </summary>
        public DeathPlaceEnum? DeathPlace
        {
            get { return (DeathPlaceEnum?)(int?)this["DEATHPLACE"]; }
            set { this["DEATHPLACE"] = value; }
        }

    /// <summary>
    /// Ölüyü Teslim Alan
    /// </summary>
        public string DeathBodyAdmittedTo
        {
            get { return (string)this["DEATHBODYADMITTEDTO"]; }
            set { this["DEATHBODYADMITTEDTO"] = value; }
        }

    /// <summary>
    /// Mernis Ölüm Sebepleri
    /// </summary>
        public MernisDeathReasonDefinition MernisDeathReasons
        {
            get { return (MernisDeathReasonDefinition)((ITTObject)this).GetParent("MERNISDEATHREASONS"); }
            set { this["MERNISDEATHREASONS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ölüm Sebebi
    /// </summary>
        public ReasonForDeathDefinition ReasonForDeath
        {
            get { return (ReasonForDeathDefinition)((ITTObject)this).GetParent("REASONFORDEATH"); }
            set { this["REASONFORDEATH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrMorgue(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrMorgue(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrMorgue(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrMorgue(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrMorgue(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRMORGUE", dataRow) { }
        protected ehrMorgue(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRMORGUE", dataRow, isImported) { }
        public ehrMorgue(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrMorgue(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrMorgue() : base() { }

    }
}