
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologySpecialProcedure")] 

    public  partial class PathologySpecialProcedure : SubActionProcedure
    {
        public class PathologySpecialProcedureList : TTObjectCollection<PathologySpecialProcedure> { }
                    
        public class ChildPathologySpecialProcedureCollection : TTObject.TTChildObjectCollection<PathologySpecialProcedure>
        {
            public ChildPathologySpecialProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologySpecialProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("0606c51a-245f-43da-9323-853161cfabe5"); } }
            public static Guid Completed { get { return new Guid("cd396866-25b9-4c15-832c-a6d4a4996e48"); } }
            public static Guid New { get { return new Guid("6a1a9fa0-2e8a-43c0-87c3-fc0f7903ab82"); } }
        }

    /// <summary>
    /// Alt Malzeme Protokol Numarası Ek Numarası
    /// </summary>
        public int? SubMatPrtNoSuffixNo
        {
            get { return (int?)this["SUBMATPRTNOSUFFIXNO"]; }
            set { this["SUBMATPRTNOSUFFIXNO"] = value; }
        }

    /// <summary>
    /// Özel İşlem
    /// </summary>
        public bool? IsSpecialProcedure
        {
            get { return (bool?)this["ISSPECIALPROCEDURE"]; }
            set { this["ISSPECIALPROCEDURE"] = value; }
        }

    /// <summary>
    /// Uygulandı
    /// </summary>
        public bool? IsApplied
        {
            get { return (bool?)this["ISAPPLIED"]; }
            set { this["ISAPPLIED"] = value; }
        }

    /// <summary>
    /// Alt Malzeme Protokol Numarası
    /// </summary>
        public string SubMatPrtNoString
        {
            get { return (string)this["SUBMATPRTNOSTRING"]; }
            set { this["SUBMATPRTNOSTRING"] = value; }
        }

    /// <summary>
    /// Patoloji Özel Hizmet Tanımı İlişkisi
    /// </summary>
        public PathologySpecialProcedureDefinition SpecialProcDefinition
        {
            get { return (PathologySpecialProcedureDefinition)((ITTObject)this).GetParent("SPECIALPROCDEFINITION"); }
            set { this["SPECIALPROCDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Pathology Pathology
        {
            get 
            {   
                if (EpisodeAction is Pathology)
                    return (Pathology)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected PathologySpecialProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologySpecialProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologySpecialProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologySpecialProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologySpecialProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYSPECIALPROCEDURE", dataRow) { }
        protected PathologySpecialProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYSPECIALPROCEDURE", dataRow, isImported) { }
        public PathologySpecialProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologySpecialProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologySpecialProcedure() : base() { }

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