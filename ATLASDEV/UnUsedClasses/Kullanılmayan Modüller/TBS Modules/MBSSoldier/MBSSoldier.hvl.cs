
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSSoldier")] 

    public  partial class MBSSoldier : MBSPerson
    {
        public class MBSSoldierList : TTObjectCollection<MBSSoldier> { }
                    
        public class ChildMBSSoldierCollection : TTObject.TTChildObjectCollection<MBSSoldier>
        {
            public ChildMBSSoldierCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSSoldierCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Künye
    /// </summary>
        public string SoldierIdentity
        {
            get { return (string)this["SOLDIERIDENTITY"]; }
            set { this["SOLDIERIDENTITY"] = value; }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public string Rank
        {
            get { return (string)this["RANK"]; }
            set { this["RANK"] = value; }
        }

    /// <summary>
    /// Baba Ad
    /// </summary>
        public string FatherName
        {
            get { return (string)this["FATHERNAME"]; }
            set { this["FATHERNAME"] = value; }
        }

    /// <summary>
    /// Doğum Yeri
    /// </summary>
        public string BirthPlace
        {
            get { return (string)this["BIRTHPLACE"]; }
            set { this["BIRTHPLACE"] = value; }
        }

        protected MBSSoldier(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSSoldier(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSSoldier(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSSoldier(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSSoldier(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSSOLDIER", dataRow) { }
        protected MBSSoldier(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSSOLDIER", dataRow, isImported) { }
        public MBSSoldier(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSSoldier(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSSoldier() : base() { }

    }
}