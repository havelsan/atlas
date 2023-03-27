
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FTRPackageProcedure")] 

    public  partial class FTRPackageProcedure : SubActionPackageProcedure
    {
        public class FTRPackageProcedureList : TTObjectCollection<FTRPackageProcedure> { }
                    
        public class ChildFTRPackageProcedureCollection : TTObject.TTChildObjectCollection<FTRPackageProcedure>
        {
            public ChildFTRPackageProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFTRPackageProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Execution { get { return new Guid("6895bf86-efd7-4628-b9eb-00f7f9262a39"); } }
            public static Guid Completed { get { return new Guid("8485f32a-ba9b-4f08-aa10-4573aaa24aad"); } }
            public static Guid Cancelled { get { return new Guid("ea5ffcaf-05e0-4160-b840-8e935f336483"); } }
        }

        public PhysiotherapyOrderDetail PhysiotherapyOrderDetail
        {
            get { return (PhysiotherapyOrderDetail)((ITTObject)this).GetParent("PHYSIOTHERAPYORDERDETAIL"); }
            set { this["PHYSIOTHERAPYORDERDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PhysiotherapyRequest PhysiotherapyRequest
        {
            get 
            {   
                if (EpisodeAction is PhysiotherapyRequest)
                    return (PhysiotherapyRequest)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected FTRPackageProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FTRPackageProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FTRPackageProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FTRPackageProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FTRPackageProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FTRPACKAGEPROCEDURE", dataRow) { }
        protected FTRPackageProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FTRPACKAGEPROCEDURE", dataRow, isImported) { }
        public FTRPackageProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FTRPackageProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FTRPackageProcedure() : base() { }

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