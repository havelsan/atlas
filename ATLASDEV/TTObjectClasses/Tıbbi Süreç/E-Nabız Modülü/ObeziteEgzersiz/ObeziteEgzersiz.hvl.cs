
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ObeziteEgzersiz")] 

    public  partial class ObeziteEgzersiz : TTObject
    {
        public class ObeziteEgzersizList : TTObjectCollection<ObeziteEgzersiz> { }
                    
        public class ChildObeziteEgzersizCollection : TTObject.TTChildObjectCollection<ObeziteEgzersiz>
        {
            public ChildObeziteEgzersizCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildObeziteEgzersizCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ObeziteIzlemVeriSeti ObeziteIzlemVeriSeti
        {
            get { return (ObeziteIzlemVeriSeti)((ITTObject)this).GetParent("OBEZITEIZLEMVERISETI"); }
            set { this["OBEZITEIZLEMVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSEgzersiz SKRSEgzersiz
        {
            get { return (SKRSEgzersiz)((ITTObject)this).GetParent("SKRSEGZERSIZ"); }
            set { this["SKRSEGZERSIZ"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ObeziteEgzersiz(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ObeziteEgzersiz(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ObeziteEgzersiz(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ObeziteEgzersiz(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ObeziteEgzersiz(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OBEZITEEGZERSIZ", dataRow) { }
        protected ObeziteEgzersiz(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OBEZITEEGZERSIZ", dataRow, isImported) { }
        public ObeziteEgzersiz(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ObeziteEgzersiz(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ObeziteEgzersiz() : base() { }

    }
}