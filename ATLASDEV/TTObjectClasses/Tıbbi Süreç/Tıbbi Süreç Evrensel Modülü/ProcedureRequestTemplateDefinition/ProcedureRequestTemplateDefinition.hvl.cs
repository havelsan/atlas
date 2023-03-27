
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureRequestTemplateDefinition")] 

    /// <summary>
    /// Procedure İstek Tanım Ekranı
    /// </summary>
    public  partial class ProcedureRequestTemplateDefinition : TTDefinitionSet
    {
        public class ProcedureRequestTemplateDefinitionList : TTObjectCollection<ProcedureRequestTemplateDefinition> { }
                    
        public class ChildProcedureRequestTemplateDefinitionCollection : TTObject.TTChildObjectCollection<ProcedureRequestTemplateDefinition>
        {
            public ChildProcedureRequestTemplateDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureRequestTemplateDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Panel Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Kullanıcı
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTemplateDetailsCollectionViews()
        {
        }

        virtual protected void CreateTemplateDetailsCollection()
        {
            _TemplateDetails = new ProcedureRequestTemplateDetail.ChildProcedureRequestTemplateDetailCollection(this, new Guid("fb5b416d-15e0-49d5-a657-f0932e191881"));
            CreateTemplateDetailsCollectionViews();
            ((ITTChildObjectCollection)_TemplateDetails).GetChildren();
        }

        protected ProcedureRequestTemplateDetail.ChildProcedureRequestTemplateDetailCollection _TemplateDetails = null;
        public ProcedureRequestTemplateDetail.ChildProcedureRequestTemplateDetailCollection TemplateDetails
        {
            get
            {
                if (_TemplateDetails == null)
                    CreateTemplateDetailsCollection();
                return _TemplateDetails;
            }
        }

        protected ProcedureRequestTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureRequestTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureRequestTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureRequestTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureRequestTemplateDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDUREREQUESTTEMPLATEDEFINITION", dataRow) { }
        protected ProcedureRequestTemplateDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDUREREQUESTTEMPLATEDEFINITION", dataRow, isImported) { }
        public ProcedureRequestTemplateDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureRequestTemplateDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureRequestTemplateDefinition() : base() { }

    }
}