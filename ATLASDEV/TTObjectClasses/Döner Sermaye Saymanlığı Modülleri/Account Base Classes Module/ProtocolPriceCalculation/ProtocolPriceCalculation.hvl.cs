
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtocolPriceCalculation")] 

    public  partial class ProtocolPriceCalculation : TTObject
    {
        public class ProtocolPriceCalculationList : TTObjectCollection<ProtocolPriceCalculation> { }
                    
        public class ChildProtocolPriceCalculationCollection : TTObject.TTChildObjectCollection<ProtocolPriceCalculation>
        {
            public ChildProtocolPriceCalculationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtocolPriceCalculationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Currency? PAYERPRICE
        {
            get { return (Currency?)this["PAYERPRICE"]; }
            set { this["PAYERPRICE"] = value; }
        }

        public Currency? PATIENTPRICE
        {
            get { return (Currency?)this["PATIENTPRICE"]; }
            set { this["PATIENTPRICE"] = value; }
        }

        public Currency? PACKAGEPRICE
        {
            get { return (Currency?)this["PACKAGEPRICE"]; }
            set { this["PACKAGEPRICE"] = value; }
        }

        public bool? ISINCLUDED
        {
            get { return (bool?)this["ISINCLUDED"]; }
            set { this["ISINCLUDED"] = value; }
        }

        public PatientStatusEnum? PATIENTSTATUS
        {
            get { return (PatientStatusEnum?)(int?)this["PATIENTSTATUS"]; }
            set { this["PATIENTSTATUS"] = value; }
        }

        public ProtocolDefinition Protocol
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOL"); }
            set { this["PROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcedureDefinition Procedure
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDURE"); }
            set { this["PROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PackageDefinition PackageDefinition
        {
            get { return (PackageDefinition)((ITTObject)this).GetParent("PACKAGEDEFINITION"); }
            set { this["PACKAGEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcedureTreeDefinition ProcedureTree
        {
            get { return (ProcedureTreeDefinition)((ITTObject)this).GetParent("PROCEDURETREE"); }
            set { this["PROCEDURETREE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProtocolPriceCalculation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtocolPriceCalculation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtocolPriceCalculation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtocolPriceCalculation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtocolPriceCalculation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTOCOLPRICECALCULATION", dataRow) { }
        protected ProtocolPriceCalculation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTOCOLPRICECALCULATION", dataRow, isImported) { }
        public ProtocolPriceCalculation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtocolPriceCalculation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtocolPriceCalculation() : base() { }

    }
}