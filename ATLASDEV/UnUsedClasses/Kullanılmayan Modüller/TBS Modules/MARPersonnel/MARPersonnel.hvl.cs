
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MARPersonnel")] 

    /// <summary>
    /// DE_Personel
    /// </summary>
    public  partial class MARPersonnel : MARPerson
    {
        public class MARPersonnelList : TTObjectCollection<MARPersonnel> { }
                    
        public class ChildMARPersonnelCollection : TTObject.TTChildObjectCollection<MARPersonnel>
        {
            public ChildMARPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMARPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Personel Tipi
    /// </summary>
        public PersonnelTypeEnum? Type
        {
            get { return (PersonnelTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public RankDefinitions Rank
        {
            get { return (RankDefinitions)((ITTObject)this).GetParent("RANK"); }
            set { this["RANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Görev
    /// </summary>
        public OccupationDefinition Occupation
        {
            get { return (OccupationDefinition)((ITTObject)this).GetParent("OCCUPATION"); }
            set { this["OCCUPATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MARPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MARPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MARPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MARPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MARPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MARPERSONNEL", dataRow) { }
        protected MARPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MARPERSONNEL", dataRow, isImported) { }
        public MARPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MARPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MARPersonnel() : base() { }

    }
}