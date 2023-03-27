
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingAppTemplateDet")] 

    public  partial class NursingAppTemplateDet : BaseAction
    {
        public class NursingAppTemplateDetList : TTObjectCollection<NursingAppTemplateDet> { }
                    
        public class ChildNursingAppTemplateDetCollection : TTObject.TTChildObjectCollection<NursingAppTemplateDet>
        {
            public ChildNursingAppTemplateDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingAppTemplateDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public NursingApplicationTemplate NursingAppTemp
        {
            get { return (NursingApplicationTemplate)((ITTObject)this).GetParent("NURSINGAPPTEMP"); }
            set { this["NURSINGAPPTEMP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingAppTemplateDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingAppTemplateDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingAppTemplateDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingAppTemplateDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingAppTemplateDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGAPPTEMPLATEDET", dataRow) { }
        protected NursingAppTemplateDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGAPPTEMPLATEDET", dataRow, isImported) { }
        public NursingAppTemplateDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingAppTemplateDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingAppTemplateDet() : base() { }

    }
}