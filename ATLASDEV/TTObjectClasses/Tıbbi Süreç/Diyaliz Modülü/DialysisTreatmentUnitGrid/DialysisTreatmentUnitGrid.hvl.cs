
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DialysisTreatmentUnitGrid")] 

    /// <summary>
    /// Diyaliz Tedavi Üniteleri
    /// </summary>
    public  partial class DialysisTreatmentUnitGrid : TTObject
    {
        public class DialysisTreatmentUnitGridList : TTObjectCollection<DialysisTreatmentUnitGrid> { }
                    
        public class ChildDialysisTreatmentUnitGridCollection : TTObject.TTChildObjectCollection<DialysisTreatmentUnitGrid>
        {
            public ChildDialysisTreatmentUnitGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDialysisTreatmentUnitGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tanı Tedavi Üniteleri
    /// </summary>
        public DialysisDefinition DefinitionAction
        {
            get { return (DialysisDefinition)((ITTObject)this).GetParent("DEFINITIONACTION"); }
            set { this["DEFINITIONACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResTreatmentDiagnosisUnit TreatmentDiagnosisUnit
        {
            get { return (ResTreatmentDiagnosisUnit)((ITTObject)this).GetParent("TREATMENTDIAGNOSISUNIT"); }
            set { this["TREATMENTDIAGNOSISUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DialysisTreatmentUnitGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DialysisTreatmentUnitGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DialysisTreatmentUnitGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DialysisTreatmentUnitGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DialysisTreatmentUnitGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIALYSISTREATMENTUNITGRID", dataRow) { }
        protected DialysisTreatmentUnitGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIALYSISTREATMENTUNITGRID", dataRow, isImported) { }
        protected DialysisTreatmentUnitGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DialysisTreatmentUnitGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DialysisTreatmentUnitGrid() : base() { }

    }
}