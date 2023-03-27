
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseHastaKabulOku")] 

    public  abstract  partial class BaseHastaKabulOku : BaseMedulaAction
    {
        public class BaseHastaKabulOkuList : TTObjectCollection<BaseHastaKabulOku> { }
                    
        public class ChildBaseHastaKabulOkuCollection : TTObject.TTChildObjectCollection<BaseHastaKabulOku>
        {
            public ChildBaseHastaKabulOkuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseHastaKabulOkuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid SentMedula { get { return new Guid("5853a5d1-eced-4a74-8612-8ef52e99f6a6"); } }
            public static Guid New { get { return new Guid("8a5d8f68-7a40-4611-9c33-3575cf4a45a4"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("bec40edb-77f6-4769-a121-f51db3bc0239"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("ca3a1a23-9ef1-4fba-b024-8e7551324059"); } }
            public static Guid Cancelled { get { return new Guid("5bde074e-fcba-4fd9-bef1-1d68f93c826e"); } }
            public static Guid SentServer { get { return new Guid("d99d3a60-06af-4331-ac30-a10c275ef8bd"); } }
        }

    /// <summary>
    /// Takip Oku Giriş
    /// </summary>
        public TakipOkuGirisDVO takipOkuGirisDVO
        {
            get { return (TakipOkuGirisDVO)((ITTObject)this).GetParent("TAKIPOKUGIRISDVO"); }
            set { this["TAKIPOKUGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseHastaKabulOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseHastaKabulOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseHastaKabulOku(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseHastaKabulOku(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseHastaKabulOku(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEHASTAKABULOKU", dataRow) { }
        protected BaseHastaKabulOku(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEHASTAKABULOKU", dataRow, isImported) { }
        public BaseHastaKabulOku(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseHastaKabulOku(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseHastaKabulOku() : base() { }

    }
}