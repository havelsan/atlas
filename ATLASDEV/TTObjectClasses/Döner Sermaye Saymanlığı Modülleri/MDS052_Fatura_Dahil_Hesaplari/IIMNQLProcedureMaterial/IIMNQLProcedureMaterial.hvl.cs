
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IIMNQLProcedureMaterial")] 

    public  partial class IIMNQLProcedureMaterial : TTObject
    {
        public class IIMNQLProcedureMaterialList : TTObjectCollection<IIMNQLProcedureMaterial> { }
                    
        public class ChildIIMNQLProcedureMaterialCollection : TTObject.TTChildObjectCollection<IIMNQLProcedureMaterial>
        {
            public ChildIIMNQLProcedureMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIIMNQLProcedureMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sonuç
    /// </summary>
        public InvoiceInclusionResultEnum? Result
        {
            get { return (InvoiceInclusionResultEnum?)(int?)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

    /// <summary>
    /// Kural Bilgisi
    /// </summary>
        public InvoiceInclusionMaster InvoiceInclusionMaster
        {
            get { return (InvoiceInclusionMaster)((ITTObject)this).GetParent("INVOICEINCLUSIONMASTER"); }
            set { this["INVOICEINCLUSIONMASTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kural Sonuç Hizmet Bilgisi
    /// </summary>
        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kural Sonuç Grup Bilgisi
    /// </summary>
        public InvoiceInclusionNQL InvoiceInclusionNQL
        {
            get { return (InvoiceInclusionNQL)((ITTObject)this).GetParent("INVOICEINCLUSIONNQL"); }
            set { this["INVOICEINCLUSIONNQL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IIMNQLProcedureMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IIMNQLProcedureMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IIMNQLProcedureMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IIMNQLProcedureMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IIMNQLProcedureMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IIMNQLPROCEDUREMATERIAL", dataRow) { }
        protected IIMNQLProcedureMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IIMNQLPROCEDUREMATERIAL", dataRow, isImported) { }
        public IIMNQLProcedureMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IIMNQLProcedureMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IIMNQLProcedureMaterial() : base() { }

    }
}