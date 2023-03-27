
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryTubeDefinitionX")] 

    /// <summary>
    /// Laboratuvar Tüp Tanımları
    /// </summary>
    public  partial class LaboratoryTubeDefinitionX : TTDefinitionSet
    {
        public class LaboratoryTubeDefinitionXList : TTObjectCollection<LaboratoryTubeDefinitionX> { }
                    
        public class ChildLaboratoryTubeDefinitionXCollection : TTObject.TTChildObjectCollection<LaboratoryTubeDefinitionX>
        {
            public ChildLaboratoryTubeDefinitionXCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryTubeDefinitionXCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid NewX { get { return new Guid("8d68187b-fccf-4a98-a722-36ac0c363b9b"); } }
            public static Guid CompleteX { get { return new Guid("994f2f47-402b-41e0-9de7-ec4efd92c785"); } }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string NameX
        {
            get { return (string)this["NAMEX"]; }
            set { this["NAMEX"] = value; }
        }

    /// <summary>
    /// Ayrı Barkod Üret
    /// </summary>
        public bool? IsDistinctBarcodeX
        {
            get { return (bool?)this["ISDISTINCTBARCODEX"]; }
            set { this["ISDISTINCTBARCODEX"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string DescriptionX
        {
            get { return (string)this["DESCRIPTIONX"]; }
            set { this["DESCRIPTIONX"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? ActiveX
        {
            get { return (bool?)this["ACTIVEX"]; }
            set { this["ACTIVEX"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public int? IdX
        {
            get { return (int?)this["IDX"]; }
            set { this["IDX"] = value; }
        }

    /// <summary>
    /// Barkod Açıklamasını Göster
    /// </summary>
        public bool? DisplayBarcodeDescriptionX
        {
            get { return (bool?)this["DISPLAYBARCODEDESCRIPTIONX"]; }
            set { this["DISPLAYBARCODEDESCRIPTIONX"] = value; }
        }

    /// <summary>
    /// Barkod Açıklaması
    /// </summary>
        public string BarcodeDescriptionX
        {
            get { return (string)this["BARCODEDESCRIPTIONX"]; }
            set { this["BARCODEDESCRIPTIONX"] = value; }
        }

        protected LaboratoryTubeDefinitionX(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryTubeDefinitionX(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryTubeDefinitionX(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryTubeDefinitionX(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryTubeDefinitionX(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYTUBEDEFINITIONX", dataRow) { }
        protected LaboratoryTubeDefinitionX(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYTUBEDEFINITIONX", dataRow, isImported) { }
        public LaboratoryTubeDefinitionX(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryTubeDefinitionX(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryTubeDefinitionX() : base() { }

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