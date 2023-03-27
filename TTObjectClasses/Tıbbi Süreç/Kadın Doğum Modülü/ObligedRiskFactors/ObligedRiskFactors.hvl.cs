
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ObligedRiskFactors")] 

    public  partial class ObligedRiskFactors : TTObject
    {
        public class ObligedRiskFactorsList : TTObjectCollection<ObligedRiskFactors> { }
                    
        public class ChildObligedRiskFactorsCollection : TTObject.TTChildObjectCollection<ObligedRiskFactors>
        {
            public ChildObligedRiskFactorsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildObligedRiskFactorsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Zorunlu Risk Faktörü Açıklama
    /// </summary>
        public string RiskFactorDescription
        {
            get { return (string)this["RISKFACTORDESCRIPTION"]; }
            set { this["RISKFACTORDESCRIPTION"] = value; }
        }

        public SKRSGebelikBildirimiZorunluRiskFaktorleri RiskFactors
        {
            get { return (SKRSGebelikBildirimiZorunluRiskFaktorleri)((ITTObject)this).GetParent("RISKFACTORS"); }
            set { this["RISKFACTORS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PregnancyFollow PregnancyFollow
        {
            get { return (PregnancyFollow)((ITTObject)this).GetParent("PREGNANCYFOLLOW"); }
            set { this["PREGNANCYFOLLOW"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ObligedRiskFactors(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ObligedRiskFactors(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ObligedRiskFactors(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ObligedRiskFactors(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ObligedRiskFactors(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OBLIGEDRISKFACTORS", dataRow) { }
        protected ObligedRiskFactors(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OBLIGEDRISKFACTORS", dataRow, isImported) { }
        public ObligedRiskFactors(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ObligedRiskFactors(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ObligedRiskFactors() : base() { }

    }
}