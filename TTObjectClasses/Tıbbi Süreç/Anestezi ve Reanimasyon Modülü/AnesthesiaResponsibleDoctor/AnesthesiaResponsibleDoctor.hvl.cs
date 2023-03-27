
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnesthesiaResponsibleDoctor")] 

    public  partial class AnesthesiaResponsibleDoctor : TTObject
    {
        public class AnesthesiaResponsibleDoctorList : TTObjectCollection<AnesthesiaResponsibleDoctor> { }
                    
        public class ChildAnesthesiaResponsibleDoctorCollection : TTObject.TTChildObjectCollection<AnesthesiaResponsibleDoctor>
        {
            public ChildAnesthesiaResponsibleDoctorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnesthesiaResponsibleDoctorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResUser ResponsibleDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEDOCTOR"); }
            set { this["RESPONSIBLEDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AnesthesiaAndReanimation AnesthesiaAndReanimation
        {
            get { return (AnesthesiaAndReanimation)((ITTObject)this).GetParent("ANESTHESIAANDREANIMATION"); }
            set { this["ANESTHESIAANDREANIMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AnesthesiaResponsibleDoctor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnesthesiaResponsibleDoctor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnesthesiaResponsibleDoctor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnesthesiaResponsibleDoctor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnesthesiaResponsibleDoctor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANESTHESIARESPONSIBLEDOCTOR", dataRow) { }
        protected AnesthesiaResponsibleDoctor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANESTHESIARESPONSIBLEDOCTOR", dataRow, isImported) { }
        public AnesthesiaResponsibleDoctor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnesthesiaResponsibleDoctor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnesthesiaResponsibleDoctor() : base() { }

    }
}