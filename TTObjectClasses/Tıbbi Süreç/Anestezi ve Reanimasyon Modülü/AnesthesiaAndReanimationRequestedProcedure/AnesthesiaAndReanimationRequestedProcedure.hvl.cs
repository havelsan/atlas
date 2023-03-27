
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnesthesiaAndReanimationRequestedProcedure")] 

    /// <summary>
    /// Anestezi ve Reanimasyon İşlemi Yeni Süreçden İstendiğinde Anestezi Gerektiren İşlemi Taşıyan Nesne
    /// </summary>
    public  partial class AnesthesiaAndReanimationRequestedProcedure : TTObject
    {
        public class AnesthesiaAndReanimationRequestedProcedureList : TTObjectCollection<AnesthesiaAndReanimationRequestedProcedure> { }
                    
        public class ChildAnesthesiaAndReanimationRequestedProcedureCollection : TTObject.TTChildObjectCollection<AnesthesiaAndReanimationRequestedProcedure>
        {
            public ChildAnesthesiaAndReanimationRequestedProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnesthesiaAndReanimationRequestedProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Anestezi Gerektiren İşlem
    /// </summary>
        public AnesthesiaAndReanimation AnesthesiaAndReanimation
        {
            get { return (AnesthesiaAndReanimation)((ITTObject)this).GetParent("ANESTHESIAANDREANIMATION"); }
            set { this["ANESTHESIAANDREANIMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlem
    /// </summary>
        public ProcedureDefinition Procedure
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDURE"); }
            set { this["PROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AnesthesiaAndReanimationRequestedProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnesthesiaAndReanimationRequestedProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnesthesiaAndReanimationRequestedProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnesthesiaAndReanimationRequestedProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnesthesiaAndReanimationRequestedProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANESTHESIAANDREANIMATIONREQUESTEDPROCEDURE", dataRow) { }
        protected AnesthesiaAndReanimationRequestedProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANESTHESIAANDREANIMATIONREQUESTEDPROCEDURE", dataRow, isImported) { }
        public AnesthesiaAndReanimationRequestedProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnesthesiaAndReanimationRequestedProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnesthesiaAndReanimationRequestedProcedure() : base() { }

    }
}