
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneticAcceptTemplateDetail")] 

    /// <summary>
    /// Tıbbi Genetik Paket Tanım Detayı
    /// </summary>
    public  partial class GeneticAcceptTemplateDetail : TTObject
    {
        public class GeneticAcceptTemplateDetailList : TTObjectCollection<GeneticAcceptTemplateDetail> { }
                    
        public class ChildGeneticAcceptTemplateDetailCollection : TTObject.TTChildObjectCollection<GeneticAcceptTemplateDetail>
        {
            public ChildGeneticAcceptTemplateDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneticAcceptTemplateDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adet
    /// </summary>
        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Genetik Paket Detay Tanımı İlişkisi
    /// </summary>
        public GeneticAcceptTemplateDefinition GeneticAcceptTemplateDef
        {
            get { return (GeneticAcceptTemplateDefinition)((ITTObject)this).GetParent("GENETICACCEPTTEMPLATEDEF"); }
            set { this["GENETICACCEPTTEMPLATEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tıbbi Genetik Test Tanım İlişkisi
    /// </summary>
        public GeneticTestDefinition GeneticTestDefinition
        {
            get { return (GeneticTestDefinition)((ITTObject)this).GetParent("GENETICTESTDEFINITION"); }
            set { this["GENETICTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected GeneticAcceptTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneticAcceptTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneticAcceptTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneticAcceptTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneticAcceptTemplateDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENETICACCEPTTEMPLATEDETAIL", dataRow) { }
        protected GeneticAcceptTemplateDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENETICACCEPTTEMPLATEDETAIL", dataRow, isImported) { }
        public GeneticAcceptTemplateDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneticAcceptTemplateDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneticAcceptTemplateDetail() : base() { }

    }
}