
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WebMethodCustomizationDef")] 

    public  partial class WebMethodCustomizationDef : TTDefinitionSet
    {
        public class WebMethodCustomizationDefList : TTObjectCollection<WebMethodCustomizationDef> { }
                    
        public class ChildWebMethodCustomizationDefCollection : TTObject.TTChildObjectCollection<WebMethodCustomizationDef>
        {
            public ChildWebMethodCustomizationDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWebMethodCustomizationDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Guid? webMethodDefID
        {
            get { return (Guid?)this["WEBMETHODDEFID"]; }
            set { this["WEBMETHODDEFID"] = value; }
        }

    /// <summary>
    /// Başlangıç saati
    /// </summary>
        public DateTime? StartTime
        {
            get { return (DateTime?)this["STARTTIME"]; }
            set { this["STARTTIME"] = value; }
        }

    /// <summary>
    /// Bitiş Saati
    /// </summary>
        public DateTime? EndTime
        {
            get { return (DateTime?)this["ENDTIME"]; }
            set { this["ENDTIME"] = value; }
        }

        public Guid? webServisObjectDefID
        {
            get { return (Guid?)this["WEBSERVISOBJECTDEFID"]; }
            set { this["WEBSERVISOBJECTDEFID"] = value; }
        }

        public bool? IsSync
        {
            get { return (bool?)this["ISSYNC"]; }
            set { this["ISSYNC"] = value; }
        }

        public int? Priority
        {
            get { return (int?)this["PRIORITY"]; }
            set { this["PRIORITY"] = value; }
        }

        public ResSection Resource
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcedureDefinition Procedure
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDURE"); }
            set { this["PROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected WebMethodCustomizationDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WebMethodCustomizationDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WebMethodCustomizationDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WebMethodCustomizationDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WebMethodCustomizationDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WEBMETHODCUSTOMIZATIONDEF", dataRow) { }
        protected WebMethodCustomizationDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WEBMETHODCUSTOMIZATIONDEF", dataRow, isImported) { }
        public WebMethodCustomizationDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WebMethodCustomizationDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WebMethodCustomizationDef() : base() { }

    }
}