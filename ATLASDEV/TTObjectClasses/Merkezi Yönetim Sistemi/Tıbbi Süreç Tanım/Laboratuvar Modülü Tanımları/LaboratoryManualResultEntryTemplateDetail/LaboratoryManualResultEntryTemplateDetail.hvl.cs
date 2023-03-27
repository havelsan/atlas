
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryManualResultEntryTemplateDetail")] 

    /// <summary>
    /// Laboratuvar Manual Sonuç Giriş Panel Tanımı Detayları
    /// </summary>
    public  partial class LaboratoryManualResultEntryTemplateDetail : TTDefinitionSet
    {
        public class LaboratoryManualResultEntryTemplateDetailList : TTObjectCollection<LaboratoryManualResultEntryTemplateDetail> { }
                    
        public class ChildLaboratoryManualResultEntryTemplateDetailCollection : TTObject.TTChildObjectCollection<LaboratoryManualResultEntryTemplateDetail>
        {
            public ChildLaboratoryManualResultEntryTemplateDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryManualResultEntryTemplateDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public bool? SelectTest
        {
            get { return (bool?)this["SELECTTEST"]; }
            set { this["SELECTTEST"] = value; }
        }

        public LaboratoryTestDefinition LaboratoryTestDefinition
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("LABORATORYTESTDEFINITION"); }
            set { this["LABORATORYTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public LaboratoryManualResultEntryTemplate LabManualResultEntryTemplate
        {
            get { return (LaboratoryManualResultEntryTemplate)((ITTObject)this).GetParent("LABMANUALRESULTENTRYTEMPLATE"); }
            set { this["LABMANUALRESULTENTRYTEMPLATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryManualResultEntryTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryManualResultEntryTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryManualResultEntryTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryManualResultEntryTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryManualResultEntryTemplateDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYMANUALRESULTENTRYTEMPLATEDETAIL", dataRow) { }
        protected LaboratoryManualResultEntryTemplateDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYMANUALRESULTENTRYTEMPLATEDETAIL", dataRow, isImported) { }
        public LaboratoryManualResultEntryTemplateDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryManualResultEntryTemplateDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryManualResultEntryTemplateDetail() : base() { }

    }
}