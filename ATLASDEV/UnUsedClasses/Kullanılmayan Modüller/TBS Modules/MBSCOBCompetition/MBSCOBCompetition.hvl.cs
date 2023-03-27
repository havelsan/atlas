
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSCOBCompetition")] 

    public  partial class MBSCOBCompetition : MBSCOBCash
    {
        public class MBSCOBCompetitionList : TTObjectCollection<MBSCOBCompetition> { }
                    
        public class ChildMBSCOBCompetitionCollection : TTObject.TTChildObjectCollection<MBSCOBCompetition>
        {
            public ChildMBSCOBCompetitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSCOBCompetitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Yarışma adı
    /// </summary>
        public string CompetitionName
        {
            get { return (string)this["COMPETITIONNAME"]; }
            set { this["COMPETITIONNAME"] = value; }
        }

    /// <summary>
    /// Ödül Tutarı
    /// </summary>
        public double? AwardPrice
        {
            get { return (double?)this["AWARDPRICE"]; }
            set { this["AWARDPRICE"] = value; }
        }

    /// <summary>
    /// Ödül derecesi
    /// </summary>
        public string Award
        {
            get { return (string)this["AWARD"]; }
            set { this["AWARD"] = value; }
        }

        protected MBSCOBCompetition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSCOBCompetition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSCOBCompetition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSCOBCompetition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSCOBCompetition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSCOBCOMPETITION", dataRow) { }
        protected MBSCOBCompetition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSCOBCOMPETITION", dataRow, isImported) { }
        public MBSCOBCompetition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSCOBCompetition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSCOBCompetition() : base() { }

    }
}