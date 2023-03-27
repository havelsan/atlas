
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSApartmentDefinition")] 

    /// <summary>
    /// Lojman Tanımlama
    /// </summary>
    public  partial class MPBSApartmentDefinition : TTDefinitionSet
    {
        public class MPBSApartmentDefinitionList : TTObjectCollection<MPBSApartmentDefinition> { }
                    
        public class ChildMPBSApartmentDefinitionCollection : TTObject.TTChildObjectCollection<MPBSApartmentDefinition>
        {
            public ChildMPBSApartmentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSApartmentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("329d2bb8-126b-4688-8c1d-258691274915"); } }
            public static Guid Completed { get { return new Guid("6b666c79-f7e6-48bb-85e3-d64dc18be6d7"); } }
        }

    /// <summary>
    /// Kat Sayısı
    /// </summary>
        public int? NumberOfFloor
        {
            get { return (int?)this["NUMBEROFFLOOR"]; }
            set { this["NUMBEROFFLOOR"] = value; }
        }

    /// <summary>
    /// Daire Sayısı
    /// </summary>
        public int? NumberOfFlat
        {
            get { return (int?)this["NUMBEROFFLAT"]; }
            set { this["NUMBEROFFLAT"] = value; }
        }

    /// <summary>
    /// Lojman No
    /// </summary>
        public int? No
        {
            get { return (int?)this["NO"]; }
            set { this["NO"] = value; }
        }

    /// <summary>
    /// Lojman Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Lojman Bölge
    /// </summary>
        public MPBSApartmentAreaDefinition ApartmentArea
        {
            get { return (MPBSApartmentAreaDefinition)((ITTObject)this).GetParent("APARTMENTAREA"); }
            set { this["APARTMENTAREA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSApartmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSApartmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSApartmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSApartmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSApartmentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSAPARTMENTDEFINITION", dataRow) { }
        protected MPBSApartmentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSAPARTMENTDEFINITION", dataRow, isImported) { }
        public MPBSApartmentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSApartmentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSApartmentDefinition() : base() { }

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