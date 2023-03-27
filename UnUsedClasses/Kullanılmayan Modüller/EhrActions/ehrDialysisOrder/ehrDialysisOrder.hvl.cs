
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrDialysisOrder")] 

    /// <summary>
    /// Diyaliz Emri
    /// </summary>
    public  partial class ehrDialysisOrder : ehrEpisodeAction
    {
        public class ehrDialysisOrderList : TTObjectCollection<ehrDialysisOrder> { }
                    
        public class ChildehrDialysisOrderCollection : TTObject.TTChildObjectCollection<ehrDialysisOrder>
        {
            public ChildehrDialysisOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrDialysisOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Doktor Diyaliz Takip Formu
    /// </summary>
        public object DoctorFollowUpForm
        {
            get { return (object)this["DOCTORFOLLOWUPFORM"]; }
            set { this["DOCTORFOLLOWUPFORM"] = value; }
        }

    /// <summary>
    /// Hemşire Diyaliz Takip Formu
    /// </summary>
        public object NurseFollowUpForm
        {
            get { return (object)this["NURSEFOLLOWUPFORM"]; }
            set { this["NURSEFOLLOWUPFORM"] = value; }
        }

    /// <summary>
    /// Sure/dk
    /// </summary>
        public long? Duration
        {
            get { return (long?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

    /// <summary>
    /// Kür
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Diyaliz İşlemi
    /// </summary>
        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrDialysisOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrDialysisOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrDialysisOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrDialysisOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrDialysisOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRDIALYSISORDER", dataRow) { }
        protected ehrDialysisOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRDIALYSISORDER", dataRow, isImported) { }
        public ehrDialysisOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrDialysisOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrDialysisOrder() : base() { }

    }
}