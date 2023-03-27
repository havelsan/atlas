
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseDentalSubactionProcedureDiagnosisGrid")] 

    public  partial class BaseDentalSubactionProcedureDiagnosisGrid : DiagnosisGrid
    {
        public class BaseDentalSubactionProcedureDiagnosisGridList : TTObjectCollection<BaseDentalSubactionProcedureDiagnosisGrid> { }
                    
        public class ChildBaseDentalSubactionProcedureDiagnosisGridCollection : TTObject.TTChildObjectCollection<BaseDentalSubactionProcedureDiagnosisGrid>
        {
            public ChildBaseDentalSubactionProcedureDiagnosisGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseDentalSubactionProcedureDiagnosisGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Diş Numarası
    /// </summary>
        public ToothNumberEnum? ToothNumber
        {
            get { return (ToothNumberEnum?)(int?)this["TOOTHNUMBER"]; }
            set { this["TOOTHNUMBER"] = value; }
        }

    /// <summary>
    /// Diş Pozisyonu
    /// </summary>
        public DentalPositionEnum? DentalPosition
        {
            get { return (DentalPositionEnum?)(int?)this["DENTALPOSITION"]; }
            set { this["DENTALPOSITION"] = value; }
        }

        protected BaseDentalSubactionProcedureDiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseDentalSubactionProcedureDiagnosisGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseDentalSubactionProcedureDiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseDentalSubactionProcedureDiagnosisGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseDentalSubactionProcedureDiagnosisGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEDENTALSUBACTIONPROCEDUREDIAGNOSISGRID", dataRow) { }
        protected BaseDentalSubactionProcedureDiagnosisGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEDENTALSUBACTIONPROCEDUREDIAGNOSISGRID", dataRow, isImported) { }
        public BaseDentalSubactionProcedureDiagnosisGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseDentalSubactionProcedureDiagnosisGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseDentalSubactionProcedureDiagnosisGrid() : base() { }

    }
}