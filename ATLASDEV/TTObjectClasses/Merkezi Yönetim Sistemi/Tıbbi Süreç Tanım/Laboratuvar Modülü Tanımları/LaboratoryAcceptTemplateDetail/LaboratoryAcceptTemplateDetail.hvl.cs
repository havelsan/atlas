
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryAcceptTemplateDetail")] 

    /// <summary>
    /// Laboratuvar Kabul Panel Detayı
    /// </summary>
    public  partial class LaboratoryAcceptTemplateDetail : TTObject
    {
        public class LaboratoryAcceptTemplateDetailList : TTObjectCollection<LaboratoryAcceptTemplateDetail> { }
                    
        public class ChildLaboratoryAcceptTemplateDetailCollection : TTObject.TTChildObjectCollection<LaboratoryAcceptTemplateDetail>
        {
            public ChildLaboratoryAcceptTemplateDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryAcceptTemplateDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Çalışılacak bölüm seçimi
    /// </summary>
        public bool? SelectResource
        {
            get { return (bool?)this["SELECTRESOURCE"]; }
            set { this["SELECTRESOURCE"] = value; }
        }

    /// <summary>
    /// Laboratuvar Birimi İlişkisi
    /// </summary>
        public ResLaboratoryDepartment LaboratoryUnit
        {
            get { return (ResLaboratoryDepartment)((ITTObject)this).GetParent("LABORATORYUNIT"); }
            set { this["LABORATORYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Laboratuvar Kabul Panel Detay Tanımı İlişkisi
    /// </summary>
        public LaboratoryAcceptTemplateDefinition LaboratoryAcceptTemplateDef
        {
            get { return (LaboratoryAcceptTemplateDefinition)((ITTObject)this).GetParent("LABORATORYACCEPTTEMPLATEDEF"); }
            set { this["LABORATORYACCEPTTEMPLATEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Laboratuvar Test Tanım İlişkisi
    /// </summary>
        public LaboratoryTestDefinition LaboratoryTestDefinition
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("LABORATORYTESTDEFINITION"); }
            set { this["LABORATORYTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Laboratuvar Sekme İlişkisi
    /// </summary>
        public LaboratoryRequestFormTabDefinition LaboratoryRequestFormTab
        {
            get { return (LaboratoryRequestFormTabDefinition)((ITTObject)this).GetParent("LABORATORYREQUESTFORMTAB"); }
            set { this["LABORATORYREQUESTFORMTAB"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryAcceptTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryAcceptTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryAcceptTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryAcceptTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryAcceptTemplateDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYACCEPTTEMPLATEDETAIL", dataRow) { }
        protected LaboratoryAcceptTemplateDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYACCEPTTEMPLATEDETAIL", dataRow, isImported) { }
        public LaboratoryAcceptTemplateDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryAcceptTemplateDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryAcceptTemplateDetail() : base() { }

    }
}