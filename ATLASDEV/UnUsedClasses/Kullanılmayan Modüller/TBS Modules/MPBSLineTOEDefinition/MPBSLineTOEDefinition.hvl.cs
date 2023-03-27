
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSLineTOEDefinition")] 

    /// <summary>
    /// Satır TMK Tanımlama
    /// </summary>
    public  partial class MPBSLineTOEDefinition : TTDefinitionSet
    {
        public class MPBSLineTOEDefinitionList : TTObjectCollection<MPBSLineTOEDefinition> { }
                    
        public class ChildMPBSLineTOEDefinitionCollection : TTObject.TTChildObjectCollection<MPBSLineTOEDefinition>
        {
            public ChildMPBSLineTOEDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSLineTOEDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("60b72956-2834-43fe-becf-8f8f38cff2d5"); } }
            public static Guid New { get { return new Guid("77b27e60-e249-464c-b881-e2f31d126f4a"); } }
        }

    /// <summary>
    /// Sefer Kadro
    /// </summary>
        public int? Mobilization
        {
            get { return (int?)this["MOBILIZATION"]; }
            set { this["MOBILIZATION"] = value; }
        }

    /// <summary>
    /// Barış Kadro
    /// </summary>
        public int? Peace
        {
            get { return (int?)this["PEACE"]; }
            set { this["PEACE"] = value; }
        }

    /// <summary>
    /// Satır TMK Kodu
    /// </summary>
        public string LineTOECode
        {
            get { return (string)this["LINETOECODE"]; }
            set { this["LINETOECODE"] = value; }
        }

    /// <summary>
    /// Dönüşümlümü
    /// </summary>
        public bool? Rotative
        {
            get { return (bool?)this["ROTATIVE"]; }
            set { this["ROTATIVE"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

    /// <summary>
    /// Kurmay Kadro
    /// </summary>
        public bool? GeneralStaff
        {
            get { return (bool?)this["GENERALSTAFF"]; }
            set { this["GENERALSTAFF"] = value; }
        }

    /// <summary>
    /// Kuvvet
    /// </summary>
        public MPBSArmedForceDefinition ArmedForce
        {
            get { return (MPBSArmedForceDefinition)((ITTObject)this).GetParent("ARMEDFORCE"); }
            set { this["ARMEDFORCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public MPBSRankDefinition Rank
        {
            get { return (MPBSRankDefinition)((ITTObject)this).GetParent("RANK"); }
            set { this["RANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sınıf
    /// </summary>
        public MPBSClassDefinition Class
        {
            get { return (MPBSClassDefinition)((ITTObject)this).GetParent("CLASS"); }
            set { this["CLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paraf TMK Kodu
    /// </summary>
        public MPBSParaphTOEDefinition ParaphTOE
        {
            get { return (MPBSParaphTOEDefinition)((ITTObject)this).GetParent("PARAPHTOE"); }
            set { this["PARAPHTOE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Branş
    /// </summary>
        public MPBSBranchDefinition Branch
        {
            get { return (MPBSBranchDefinition)((ITTObject)this).GetParent("BRANCH"); }
            set { this["BRANCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kısım
    /// </summary>
        public MPBSSectionDefinition Section
        {
            get { return (MPBSSectionDefinition)((ITTObject)this).GetParent("SECTION"); }
            set { this["SECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ünvan
    /// </summary>
        public MPBSHonorificDefinition Honorific
        {
            get { return (MPBSHonorificDefinition)((ITTObject)this).GetParent("HONORIFIC"); }
            set { this["HONORIFIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Görev
    /// </summary>
        public MPBSOccupationDefinition Occupation
        {
            get { return (MPBSOccupationDefinition)((ITTObject)this).GetParent("OCCUPATION"); }
            set { this["OCCUPATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSLineTOEDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSLineTOEDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSLineTOEDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSLineTOEDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSLineTOEDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSLINETOEDEFINITION", dataRow) { }
        protected MPBSLineTOEDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSLINETOEDEFINITION", dataRow, isImported) { }
        public MPBSLineTOEDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSLineTOEDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSLineTOEDefinition() : base() { }

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