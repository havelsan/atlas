
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiabetesMellitusPursuitHabit")] 

    /// <summary>
    /// Diabet Alışkanlık
    /// </summary>
    public  partial class DiabetesMellitusPursuitHabit : TTObject
    {
        public class DiabetesMellitusPursuitHabitList : TTObjectCollection<DiabetesMellitusPursuitHabit> { }
                    
        public class ChildDiabetesMellitusPursuitHabitCollection : TTObject.TTChildObjectCollection<DiabetesMellitusPursuitHabit>
        {
            public ChildDiabetesMellitusPursuitHabitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiabetesMellitusPursuitHabitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Alışkanlık
    /// </summary>
        public AliskanlikKoduEnum? aliskanlik
        {
            get { return (AliskanlikKoduEnum?)(int?)this["ALISKANLIK"]; }
            set { this["ALISKANLIK"] = value; }
        }

        public DiabetesMellitusPursuit DiabetesMellitusPursuit
        {
            get { return (DiabetesMellitusPursuit)((ITTObject)this).GetParent("DIABETESMELLITUSPURSUIT"); }
            set { this["DIABETESMELLITUSPURSUIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiabetesMellitusPursuitHabit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiabetesMellitusPursuitHabit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiabetesMellitusPursuitHabit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiabetesMellitusPursuitHabit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiabetesMellitusPursuitHabit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIABETESMELLITUSPURSUITHABIT", dataRow) { }
        protected DiabetesMellitusPursuitHabit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIABETESMELLITUSPURSUITHABIT", dataRow, isImported) { }
        public DiabetesMellitusPursuitHabit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiabetesMellitusPursuitHabit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiabetesMellitusPursuitHabit() : base() { }

    }
}