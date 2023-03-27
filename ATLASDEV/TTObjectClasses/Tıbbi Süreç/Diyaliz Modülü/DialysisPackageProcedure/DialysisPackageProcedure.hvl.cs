
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DialysisPackageProcedure")] 

    public  partial class DialysisPackageProcedure : SubActionPackageProcedure
    {
        public class DialysisPackageProcedureList : TTObjectCollection<DialysisPackageProcedure> { }
                    
        public class ChildDialysisPackageProcedureCollection : TTObject.TTChildObjectCollection<DialysisPackageProcedure>
        {
            public ChildDialysisPackageProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDialysisPackageProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public DialysisRequest DialysisRequest
        {
            get 
            {   
                if (EpisodeAction is DialysisRequest)
                    return (DialysisRequest)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected DialysisPackageProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DialysisPackageProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DialysisPackageProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DialysisPackageProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DialysisPackageProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIALYSISPACKAGEPROCEDURE", dataRow) { }
        protected DialysisPackageProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIALYSISPACKAGEPROCEDURE", dataRow, isImported) { }
        public DialysisPackageProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DialysisPackageProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DialysisPackageProcedure() : base() { }

    }
}