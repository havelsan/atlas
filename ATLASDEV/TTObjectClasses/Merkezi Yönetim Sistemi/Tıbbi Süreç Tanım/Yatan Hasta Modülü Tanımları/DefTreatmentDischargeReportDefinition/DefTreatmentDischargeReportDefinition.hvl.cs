
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DefTreatmentDischargeReportDefinition")] 

    public  partial class DefTreatmentDischargeReportDefinition : TTDefinitionSet
    {
        public class DefTreatmentDischargeReportDefinitionList : TTObjectCollection<DefTreatmentDischargeReportDefinition> { }
                    
        public class ChildDefTreatmentDischargeReportDefinitionCollection : TTObject.TTChildObjectCollection<DefTreatmentDischargeReportDefinition>
        {
            public ChildDefTreatmentDischargeReportDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDefTreatmentDischargeReportDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tanım Türü
    /// </summary>
        public string Type
        {
            get { return (string)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Tanım Değeri
    /// </summary>
        public string Value
        {
            get { return (string)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected DefTreatmentDischargeReportDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DefTreatmentDischargeReportDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DefTreatmentDischargeReportDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DefTreatmentDischargeReportDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DefTreatmentDischargeReportDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEFTREATMENTDISCHARGEREPORTDEFINITION", dataRow) { }
        protected DefTreatmentDischargeReportDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEFTREATMENTDISCHARGEREPORTDEFINITION", dataRow, isImported) { }
        public DefTreatmentDischargeReportDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DefTreatmentDischargeReportDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DefTreatmentDischargeReportDefinition() : base() { }

    }
}