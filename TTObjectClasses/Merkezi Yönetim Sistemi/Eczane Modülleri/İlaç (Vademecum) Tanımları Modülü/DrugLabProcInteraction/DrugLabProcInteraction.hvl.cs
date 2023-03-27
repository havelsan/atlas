
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugLabProcInteraction")] 

    public  partial class DrugLabProcInteraction : TTObject
    {
        public class DrugLabProcInteractionList : TTObjectCollection<DrugLabProcInteraction> { }
                    
        public class ChildDrugLabProcInteractionCollection : TTObject.TTChildObjectCollection<DrugLabProcInteraction>
        {
            public ChildDrugLabProcInteractionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugLabProcInteractionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Değerin Altı
    /// </summary>
        public double? MinValue
        {
            get { return (double?)this["MINVALUE"]; }
            set { this["MINVALUE"] = value; }
        }

    /// <summary>
    /// Değerin Üstü
    /// </summary>
        public double? MaxValue
        {
            get { return (double?)this["MAXVALUE"]; }
            set { this["MAXVALUE"] = value; }
        }

    /// <summary>
    /// Uyarı Mesajı
    /// </summary>
        public string Message
        {
            get { return (string)this["MESSAGE"]; }
            set { this["MESSAGE"] = value; }
        }

        public LaboratoryTestDefinition LaboratoryTestDefinition
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("LABORATORYTESTDEFINITION"); }
            set { this["LABORATORYTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugDefinition DrugDefinition
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("DRUGDEFINITION"); }
            set { this["DRUGDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugLabProcInteraction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugLabProcInteraction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugLabProcInteraction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugLabProcInteraction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugLabProcInteraction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGLABPROCINTERACTION", dataRow) { }
        protected DrugLabProcInteraction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGLABPROCINTERACTION", dataRow, isImported) { }
        public DrugLabProcInteraction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugLabProcInteraction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugLabProcInteraction() : base() { }

    }
}