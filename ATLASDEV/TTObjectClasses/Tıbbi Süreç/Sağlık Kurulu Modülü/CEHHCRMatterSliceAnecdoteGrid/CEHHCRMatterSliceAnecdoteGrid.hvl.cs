
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CEHHCRMatterSliceAnecdoteGrid")] 

    public  partial class CEHHCRMatterSliceAnecdoteGrid : MatterSliceAnectodeGrid
    {
        public class CEHHCRMatterSliceAnecdoteGridList : TTObjectCollection<CEHHCRMatterSliceAnecdoteGrid> { }
                    
        public class ChildCEHHCRMatterSliceAnecdoteGridCollection : TTObject.TTChildObjectCollection<CEHHCRMatterSliceAnecdoteGrid>
        {
            public ChildCEHHCRMatterSliceAnecdoteGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCEHHCRMatterSliceAnecdoteGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Madde/Dilim/Fıkra
    /// </summary>
        public CheckingExternalHospitalHealthCommitteeReports CheckingExternalHospHCReports
        {
            get { return (CheckingExternalHospitalHealthCommitteeReports)((ITTObject)this).GetParent("CHECKINGEXTERNALHOSPHCREPORTS"); }
            set { this["CHECKINGEXTERNALHOSPHCREPORTS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CEHHCRMatterSliceAnecdoteGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CEHHCRMatterSliceAnecdoteGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CEHHCRMatterSliceAnecdoteGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CEHHCRMatterSliceAnecdoteGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CEHHCRMatterSliceAnecdoteGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CEHHCRMATTERSLICEANECDOTEGRID", dataRow) { }
        protected CEHHCRMatterSliceAnecdoteGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CEHHCRMATTERSLICEANECDOTEGRID", dataRow, isImported) { }
        public CEHHCRMatterSliceAnecdoteGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CEHHCRMatterSliceAnecdoteGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CEHHCRMatterSliceAnecdoteGrid() : base() { }

    }
}