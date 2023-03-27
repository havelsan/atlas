
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChemoRadioCureProtocolDet")] 

    /// <summary>
    /// Kemoterapi - Radyoterapi Tedavi Protokolü için kullanılan ana nesnein altındaki seans nesnesidir.
    /// </summary>
    public  partial class ChemoRadioCureProtocolDet : SubactionProcedureFlowable
    {
        public class ChemoRadioCureProtocolDetList : TTObjectCollection<ChemoRadioCureProtocolDet> { }
                    
        public class ChildChemoRadioCureProtocolDetCollection : TTObject.TTChildObjectCollection<ChemoRadioCureProtocolDet>
        {
            public ChildChemoRadioCureProtocolDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChemoRadioCureProtocolDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Cure { get { return new Guid("962ee031-f384-45ae-b743-108f02a06b84"); } }
            public static Guid Completed { get { return new Guid("5d7ecdc8-fb66-4a9c-a488-f05d76dccec8"); } }
            public static Guid Cancelled { get { return new Guid("7665fa44-3cc7-4999-b5c1-a9c36d5848e4"); } }
            public static Guid Aborted { get { return new Guid("12f5754a-350b-4f3b-93d8-3f19f875874b"); } }
        }

    /// <summary>
    /// Not
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

        public ChemoRadioCureProtocol ChemoRadioCureProtocol
        {
            get { return (ChemoRadioCureProtocol)((ITTObject)this).GetParent("CHEMORADIOCUREPROTOCOL"); }
            set { this["CHEMORADIOCUREPROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseTreatmentMaterial DrugMaterial
        {
            get { return (BaseTreatmentMaterial)((ITTObject)this).GetParent("DRUGMATERIAL"); }
            set { this["DRUGMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseTreatmentMaterial SolutionMaterial
        {
            get { return (BaseTreatmentMaterial)((ITTObject)this).GetParent("SOLUTIONMATERIAL"); }
            set { this["SOLUTIONMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ChemoRadioCureProtocolDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChemoRadioCureProtocolDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChemoRadioCureProtocolDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChemoRadioCureProtocolDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChemoRadioCureProtocolDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHEMORADIOCUREPROTOCOLDET", dataRow) { }
        protected ChemoRadioCureProtocolDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHEMORADIOCUREPROTOCOLDET", dataRow, isImported) { }
        public ChemoRadioCureProtocolDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChemoRadioCureProtocolDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChemoRadioCureProtocolDet() : base() { }

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