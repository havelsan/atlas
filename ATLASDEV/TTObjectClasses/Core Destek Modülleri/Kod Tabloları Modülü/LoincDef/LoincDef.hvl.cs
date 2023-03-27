
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LoincDef")] 

    /// <summary>
    /// Loinc Tanımları
    /// </summary>
    public  partial class LoincDef : TTDefinitionSet
    {
        public class LoincDefList : TTObjectCollection<LoincDef> { }
                    
        public class ChildLoincDefCollection : TTObject.TTChildObjectCollection<LoincDef>
        {
            public ChildLoincDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLoincDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Loinc_Num
    /// </summary>
        public string Loinc_Num
        {
            get { return (string)this["LOINC_NUM"]; }
            set { this["LOINC_NUM"] = value; }
        }

    /// <summary>
    /// Component
    /// </summary>
        public string Component
        {
            get { return (string)this["COMPONENT"]; }
            set { this["COMPONENT"] = value; }
        }

    /// <summary>
    /// Property
    /// </summary>
        public string Property
        {
            get { return (string)this["PROPERTY"]; }
            set { this["PROPERTY"] = value; }
        }

    /// <summary>
    /// Time_Aspct
    /// </summary>
        public string Time_Aspct
        {
            get { return (string)this["TIME_ASPCT"]; }
            set { this["TIME_ASPCT"] = value; }
        }

    /// <summary>
    /// System
    /// </summary>
        public string System
        {
            get { return (string)this["SYSTEM"]; }
            set { this["SYSTEM"] = value; }
        }

    /// <summary>
    /// Scale_Typ
    /// </summary>
        public string Scale_Typ
        {
            get { return (string)this["SCALE_TYP"]; }
            set { this["SCALE_TYP"] = value; }
        }

    /// <summary>
    /// Method_Typ
    /// </summary>
        public string Method_Typ
        {
            get { return (string)this["METHOD_TYP"]; }
            set { this["METHOD_TYP"] = value; }
        }

        protected LoincDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LoincDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LoincDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LoincDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LoincDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LOINCDEF", dataRow) { }
        protected LoincDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LOINCDEF", dataRow, isImported) { }
        public LoincDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LoincDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LoincDef() : base() { }

    }
}