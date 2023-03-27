
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MLRBoard")] 

    /// <summary>
    /// MLR003_Tabela
    /// </summary>
    public  partial class MLRBoard : TTObject
    {
        public class MLRBoardList : TTObjectCollection<MLRBoard> { }
                    
        public class ChildMLRBoardCollection : TTObject.TTChildObjectCollection<MLRBoard>
        {
            public ChildMLRBoardCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMLRBoardCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Onaylandı
    /// </summary>
            public static Guid Approved { get { return new Guid("3d071024-f08b-4585-863a-c201b0a59371"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Complete { get { return new Guid("a44f9002-ef3e-4c8b-bd80-92af5a087559"); } }
    /// <summary>
    /// Yeni Tabela
    /// </summary>
            public static Guid New { get { return new Guid("a5e8c628-0a22-497e-b006-f69131460f15"); } }
        }

    /// <summary>
    /// Düzenlenme Tarihi
    /// </summary>
        public string RegulationDate
        {
            get { return (string)this["REGULATIONDATE"]; }
            set { this["REGULATIONDATE"] = value; }
        }

    /// <summary>
    /// Tabela Birimleri
    /// </summary>
        public Unit Units
        {
            get { return (Unit)((ITTObject)this).GetParent("UNITS"); }
            set { this["UNITS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tabelanın Mutfağı
    /// </summary>
        public XXXKitchen Kitchen
        {
            get { return (XXXKitchen)((ITTObject)this).GetParent("KITCHEN"); }
            set { this["KITCHEN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MLRBoard(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MLRBoard(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MLRBoard(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MLRBoard(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MLRBoard(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MLRBOARD", dataRow) { }
        protected MLRBoard(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MLRBOARD", dataRow, isImported) { }
        public MLRBoard(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MLRBoard(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MLRBoard() : base() { }

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