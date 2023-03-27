
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ParticipationFreeDscGrid")] 

    public  partial class ParticipationFreeDscGrid : TTObject
    {
        public class ParticipationFreeDscGridList : TTObjectCollection<ParticipationFreeDscGrid> { }
                    
        public class ChildParticipationFreeDscGridCollection : TTObject.TTChildObjectCollection<ParticipationFreeDscGrid>
        {
            public ChildParticipationFreeDscGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildParticipationFreeDscGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Diyabet vizit tarihi
    /// </summary>
        public DateTime? VizitDate
        {
            get { return (DateTime?)this["VIZITDATE"]; }
            set { this["VIZITDATE"] = value; }
        }

    /// <summary>
    /// Diyabet takip formu 
    /// </summary>
        public string FollowFormNo
        {
            get { return (string)this["FOLLOWFORMNO"]; }
            set { this["FOLLOWFORMNO"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected ParticipationFreeDscGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ParticipationFreeDscGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ParticipationFreeDscGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ParticipationFreeDscGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ParticipationFreeDscGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PARTICIPATIONFREEDSCGRID", dataRow) { }
        protected ParticipationFreeDscGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PARTICIPATIONFREEDSCGRID", dataRow, isImported) { }
        public ParticipationFreeDscGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ParticipationFreeDscGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ParticipationFreeDscGrid() : base() { }

    }
}