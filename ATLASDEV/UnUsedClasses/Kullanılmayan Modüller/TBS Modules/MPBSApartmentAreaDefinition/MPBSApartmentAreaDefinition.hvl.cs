
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSApartmentAreaDefinition")] 

    /// <summary>
    /// Lojman Bölge Tanımlama
    /// </summary>
    public  partial class MPBSApartmentAreaDefinition : TTDefinitionSet
    {
        public class MPBSApartmentAreaDefinitionList : TTObjectCollection<MPBSApartmentAreaDefinition> { }
                    
        public class ChildMPBSApartmentAreaDefinitionCollection : TTObject.TTChildObjectCollection<MPBSApartmentAreaDefinition>
        {
            public ChildMPBSApartmentAreaDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSApartmentAreaDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("ed44a1dc-7760-43f4-87d1-15e7fdd745be"); } }
            public static Guid Completed { get { return new Guid("4cc4b9a1-275d-46bd-ab25-5bed31aa4f90"); } }
        }

    /// <summary>
    /// Bölge Adı
    /// </summary>
        public string AreaName
        {
            get { return (string)this["AREANAME"]; }
            set { this["AREANAME"] = value; }
        }

    /// <summary>
    /// Lojman Sayısı
    /// </summary>
        public int? NumberOfApartment
        {
            get { return (int?)this["NUMBEROFAPARTMENT"]; }
            set { this["NUMBEROFAPARTMENT"] = value; }
        }

        protected MPBSApartmentAreaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSApartmentAreaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSApartmentAreaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSApartmentAreaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSApartmentAreaDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSAPARTMENTAREADEFINITION", dataRow) { }
        protected MPBSApartmentAreaDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSAPARTMENTAREADEFINITION", dataRow, isImported) { }
        public MPBSApartmentAreaDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSApartmentAreaDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSApartmentAreaDefinition() : base() { }

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