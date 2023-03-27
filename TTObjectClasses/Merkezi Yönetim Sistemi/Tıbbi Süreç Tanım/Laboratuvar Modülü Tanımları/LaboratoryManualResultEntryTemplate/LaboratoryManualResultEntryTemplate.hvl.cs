
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryManualResultEntryTemplate")] 

    /// <summary>
    /// Laboratuvar Manual Sonuç Giriş Panel Tanımı
    /// </summary>
    public  partial class LaboratoryManualResultEntryTemplate : TTDefinitionSet
    {
        public class LaboratoryManualResultEntryTemplateList : TTObjectCollection<LaboratoryManualResultEntryTemplate> { }
                    
        public class ChildLaboratoryManualResultEntryTemplateCollection : TTObject.TTChildObjectCollection<LaboratoryManualResultEntryTemplate>
        {
            public ChildLaboratoryManualResultEntryTemplateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryManualResultEntryTemplateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Panel Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateLaboratoryManualResultEntryTemplateDetailsCollection()
        {
            _LaboratoryManualResultEntryTemplateDetails = new LaboratoryManualResultEntryTemplateDetail.ChildLaboratoryManualResultEntryTemplateDetailCollection(this, new Guid("0222ed8f-31f7-44a4-8b66-cdc4b1693415"));
            ((ITTChildObjectCollection)_LaboratoryManualResultEntryTemplateDetails).GetChildren();
        }

        protected LaboratoryManualResultEntryTemplateDetail.ChildLaboratoryManualResultEntryTemplateDetailCollection _LaboratoryManualResultEntryTemplateDetails = null;
        public LaboratoryManualResultEntryTemplateDetail.ChildLaboratoryManualResultEntryTemplateDetailCollection LaboratoryManualResultEntryTemplateDetails
        {
            get
            {
                if (_LaboratoryManualResultEntryTemplateDetails == null)
                    CreateLaboratoryManualResultEntryTemplateDetailsCollection();
                return _LaboratoryManualResultEntryTemplateDetails;
            }
        }

        protected LaboratoryManualResultEntryTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryManualResultEntryTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryManualResultEntryTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryManualResultEntryTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryManualResultEntryTemplate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYMANUALRESULTENTRYTEMPLATE", dataRow) { }
        protected LaboratoryManualResultEntryTemplate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYMANUALRESULTENTRYTEMPLATE", dataRow, isImported) { }
        public LaboratoryManualResultEntryTemplate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryManualResultEntryTemplate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryManualResultEntryTemplate() : base() { }

    }
}