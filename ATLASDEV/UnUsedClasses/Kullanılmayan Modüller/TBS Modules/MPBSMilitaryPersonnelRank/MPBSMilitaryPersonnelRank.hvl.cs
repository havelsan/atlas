
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSMilitaryPersonnelRank")] 

    /// <summary>
    /// XXXXXX Personel Rütbe
    /// </summary>
    public  partial class MPBSMilitaryPersonnelRank : TTObject
    {
        public class MPBSMilitaryPersonnelRankList : TTObjectCollection<MPBSMilitaryPersonnelRank> { }
                    
        public class ChildMPBSMilitaryPersonnelRankCollection : TTObject.TTChildObjectCollection<MPBSMilitaryPersonnelRank>
        {
            public ChildMPBSMilitaryPersonnelRankCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSMilitaryPersonnelRankCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Yeni Rütbe Nasıb Tarihi
    /// </summary>
        public DateTime? NewRankNasibDate
        {
            get { return (DateTime?)this["NEWRANKNASIBDATE"]; }
            set { this["NEWRANKNASIBDATE"] = value; }
        }

    /// <summary>
    /// Alınan Rütbeler
    /// </summary>
        public MPBSPermanentTurkishPersonnel PermanentTurkishPersonnel
        {
            get { return (MPBSPermanentTurkishPersonnel)((ITTObject)this).GetParent("PERMANENTTURKISHPERSONNEL"); }
            set { this["PERMANENTTURKISHPERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public MPBSRankDefinition RankDefinition
        {
            get { return (MPBSRankDefinition)((ITTObject)this).GetParent("RANKDEFINITION"); }
            set { this["RANKDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSMilitaryPersonnelRank(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSMilitaryPersonnelRank(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSMilitaryPersonnelRank(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSMilitaryPersonnelRank(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSMilitaryPersonnelRank(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSMILITARYPERSONNELRANK", dataRow) { }
        protected MPBSMilitaryPersonnelRank(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSMILITARYPERSONNELRANK", dataRow, isImported) { }
        public MPBSMilitaryPersonnelRank(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSMilitaryPersonnelRank(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSMilitaryPersonnelRank() : base() { }

    }
}