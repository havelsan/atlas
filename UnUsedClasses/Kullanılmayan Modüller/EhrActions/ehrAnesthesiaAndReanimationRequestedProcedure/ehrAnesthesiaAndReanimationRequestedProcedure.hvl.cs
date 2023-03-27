
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrAnesthesiaAndReanimationRequestedProcedure")] 

    public  partial class ehrAnesthesiaAndReanimationRequestedProcedure : BaseEhr
    {
        public class ehrAnesthesiaAndReanimationRequestedProcedureList : TTObjectCollection<ehrAnesthesiaAndReanimationRequestedProcedure> { }
                    
        public class ChildehrAnesthesiaAndReanimationRequestedProcedureCollection : TTObject.TTChildObjectCollection<ehrAnesthesiaAndReanimationRequestedProcedure>
        {
            public ChildehrAnesthesiaAndReanimationRequestedProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrAnesthesiaAndReanimationRequestedProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
        }

    /// <summary>
    /// Anestezi Gerektiren İşlem
    /// </summary>
        public ehrAnesthesiaAndReanimation ehrAnesthesiaAndReanimation
        {
            get { return (ehrAnesthesiaAndReanimation)((ITTObject)this).GetParent("EHRANESTHESIAANDREANIMATION"); }
            set { this["EHRANESTHESIAANDREANIMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrAnesthesiaAndReanimationRequestedProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrAnesthesiaAndReanimationRequestedProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrAnesthesiaAndReanimationRequestedProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrAnesthesiaAndReanimationRequestedProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrAnesthesiaAndReanimationRequestedProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRANESTHESIAANDREANIMATIONREQUESTEDPROCEDURE", dataRow) { }
        protected ehrAnesthesiaAndReanimationRequestedProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRANESTHESIAANDREANIMATIONREQUESTEDPROCEDURE", dataRow, isImported) { }
        public ehrAnesthesiaAndReanimationRequestedProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrAnesthesiaAndReanimationRequestedProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrAnesthesiaAndReanimationRequestedProcedure() : base() { }

    }
}