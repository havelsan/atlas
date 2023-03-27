
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseDataCorrection")] 

    public  abstract  partial class BaseDataCorrection : BaseAction
    {
        public class BaseDataCorrectionList : TTObjectCollection<BaseDataCorrection> { }
                    
        public class ChildBaseDataCorrectionCollection : TTObject.TTChildObjectCollection<BaseDataCorrection>
        {
            public ChildBaseDataCorrectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseDataCorrectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("34897a19-9fa2-4dff-a783-83131c222bbc"); } }
            public static Guid Cancelled { get { return new Guid("d9a4cfca-0c12-4913-bf60-35e811619787"); } }
            public static Guid Completed { get { return new Guid("f00f14e0-e935-4391-b052-6218ca0e612e"); } }
        }

        protected BaseDataCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseDataCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseDataCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseDataCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseDataCorrection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEDATACORRECTION", dataRow) { }
        protected BaseDataCorrection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEDATACORRECTION", dataRow, isImported) { }
        public BaseDataCorrection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseDataCorrection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseDataCorrection() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}