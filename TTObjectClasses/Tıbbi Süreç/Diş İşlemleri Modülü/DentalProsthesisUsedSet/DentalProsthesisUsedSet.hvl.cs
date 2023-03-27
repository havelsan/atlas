
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalProsthesisUsedSet")] 

    /// <summary>
    /// Diş protez işlemi kullanılan takım sekmesi
    /// </summary>
    public  partial class DentalProsthesisUsedSet : TTObject
    {
        public class DentalProsthesisUsedSetList : TTObjectCollection<DentalProsthesisUsedSet> { }
                    
        public class ChildDentalProsthesisUsedSetCollection : TTObject.TTChildObjectCollection<DentalProsthesisUsedSet>
        {
            public ChildDentalProsthesisUsedSetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalProsthesisUsedSetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açıklama
    /// </summary>
        public string Definition
        {
            get { return (string)this["DEFINITION"]; }
            set { this["DEFINITION"] = value; }
        }

    /// <summary>
    /// Kullanılan Set
    /// </summary>
        public DentalSetDefinition UsedSet
        {
            get { return (DentalSetDefinition)((ITTObject)this).GetParent("USEDSET"); }
            set { this["USEDSET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// DentalProsthesis_ DentalProsthesisUsedSet
    /// </summary>
        public DentalProsthesisProcedure DentalProsthesis
        {
            get { return (DentalProsthesisProcedure)((ITTObject)this).GetParent("DENTALPROSTHESIS"); }
            set { this["DENTALPROSTHESIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DentalProsthesisUsedSet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalProsthesisUsedSet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalProsthesisUsedSet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalProsthesisUsedSet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalProsthesisUsedSet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALPROSTHESISUSEDSET", dataRow) { }
        protected DentalProsthesisUsedSet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALPROSTHESISUSEDSET", dataRow, isImported) { }
        public DentalProsthesisUsedSet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalProsthesisUsedSet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalProsthesisUsedSet() : base() { }

    }
}