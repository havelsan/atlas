
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageExceptionProcedure")] 

    /// <summary>
    /// Paket Hizmet İstisna
    /// </summary>
    public  partial class PackageExceptionProcedure : TerminologyManagerDef
    {
        public class PackageExceptionProcedureList : TTObjectCollection<PackageExceptionProcedure> { }
                    
        public class ChildPackageExceptionProcedureCollection : TTObject.TTChildObjectCollection<PackageExceptionProcedure>
        {
            public ChildPackageExceptionProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageExceptionProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public PackageInclusiveEnum? Inclusive
        {
            get { return (PackageInclusiveEnum?)(int?)this["INCLUSIVE"]; }
            set { this["INCLUSIVE"] = value; }
        }

    /// <summary>
    /// Fiyat Listesi
    /// </summary>
        public PricingListDefinition PricingListDefinition
        {
            get { return (PricingListDefinition)((ITTObject)this).GetParent("PRICINGLISTDEFINITION"); }
            set { this["PRICINGLISTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet
    /// </summary>
        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paket Tanımlama ile ilişkisi
    /// </summary>
        public PackageDefinition PackageDefinition
        {
            get { return (PackageDefinition)((ITTObject)this).GetParent("PACKAGEDEFINITION"); }
            set { this["PACKAGEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PackageExceptionProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageExceptionProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageExceptionProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageExceptionProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageExceptionProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGEEXCEPTIONPROCEDURE", dataRow) { }
        protected PackageExceptionProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGEEXCEPTIONPROCEDURE", dataRow, isImported) { }
        public PackageExceptionProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageExceptionProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageExceptionProcedure() : base() { }

    }
}