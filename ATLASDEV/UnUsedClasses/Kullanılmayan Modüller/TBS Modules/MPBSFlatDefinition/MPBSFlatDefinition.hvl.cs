
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSFlatDefinition")] 

    /// <summary>
    /// Daire Tanımlama
    /// </summary>
    public  partial class MPBSFlatDefinition : TTDefinitionSet
    {
        public class MPBSFlatDefinitionList : TTObjectCollection<MPBSFlatDefinition> { }
                    
        public class ChildMPBSFlatDefinitionCollection : TTObject.TTChildObjectCollection<MPBSFlatDefinition>
        {
            public ChildMPBSFlatDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSFlatDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("f8026760-aeaf-4d10-8a16-246129a22cab"); } }
            public static Guid New { get { return new Guid("e6883b9c-63a3-4552-b63f-d0fa3a8f865b"); } }
        }

    /// <summary>
    /// Daire Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Metrekare
    /// </summary>
        public int? SquareRoot
        {
            get { return (int?)this["SQUAREROOT"]; }
            set { this["SQUAREROOT"] = value; }
        }

    /// <summary>
    /// Daire No
    /// </summary>
        public int? DoorNo
        {
            get { return (int?)this["DOORNO"]; }
            set { this["DOORNO"] = value; }
        }

    /// <summary>
    /// Balkon Sayısı
    /// </summary>
        public int? NumberOfBalcony
        {
            get { return (int?)this["NUMBEROFBALCONY"]; }
            set { this["NUMBEROFBALCONY"] = value; }
        }

    /// <summary>
    /// Daire Türü
    /// </summary>
        public MPBSFlatTypeEnum? Type
        {
            get { return (MPBSFlatTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Oda Sayısı
    /// </summary>
        public int? NumberOfRooms
        {
            get { return (int?)this["NUMBEROFROOMS"]; }
            set { this["NUMBEROFROOMS"] = value; }
        }

    /// <summary>
    /// Lojman
    /// </summary>
        public MPBSApartmentDefinition Apartment
        {
            get { return (MPBSApartmentDefinition)((ITTObject)this).GetParent("APARTMENT"); }
            set { this["APARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSFlatDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSFlatDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSFlatDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSFlatDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSFlatDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSFLATDEFINITION", dataRow) { }
        protected MPBSFlatDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSFLATDEFINITION", dataRow, isImported) { }
        public MPBSFlatDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSFlatDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSFlatDefinition() : base() { }

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