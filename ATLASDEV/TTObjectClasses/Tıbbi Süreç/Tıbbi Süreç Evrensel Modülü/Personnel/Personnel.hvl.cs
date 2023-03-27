
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Personnel")] 

    /// <summary>
    /// DE_Personel
    /// </summary>
    public  partial class Personnel : Person
    {
        public class PersonnelList : TTObjectCollection<Personnel> { }
                    
        public class ChildPersonnelCollection : TTObject.TTChildObjectCollection<Personnel>
        {
            public ChildPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Rütbesi
    /// </summary>
        public string Rank
        {
            get { return (string)this["RANK"]; }
            set { this["RANK"] = value; }
        }

    /// <summary>
    /// Personel Tipi
    /// </summary>
        public int? Type
        {
            get { return (int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Görevi
    /// </summary>
        public string Occupation
        {
            get { return (string)this["OCCUPATION"]; }
            set { this["OCCUPATION"] = value; }
        }

    /// <summary>
    /// Görev Yeri
    /// </summary>
        public string OccupationalUnit
        {
            get { return (string)this["OCCUPATIONALUNIT"]; }
            set { this["OCCUPATIONALUNIT"] = value; }
        }

        protected Personnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Personnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Personnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Personnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Personnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PERSONNEL", dataRow) { }
        protected Personnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PERSONNEL", dataRow, isImported) { }
        public Personnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Personnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Personnel() : base() { }

    }
}