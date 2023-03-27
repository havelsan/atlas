
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TutunKullanimiBagimOldUrun")] 

    public  partial class TutunKullanimiBagimOldUrun : TTObject
    {
        public class TutunKullanimiBagimOldUrunList : TTObjectCollection<TutunKullanimiBagimOldUrun> { }
                    
        public class ChildTutunKullanimiBagimOldUrunCollection : TTObject.TTChildObjectCollection<TutunKullanimiBagimOldUrun>
        {
            public ChildTutunKullanimiBagimOldUrunCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTutunKullanimiBagimOldUrunCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSBagimliOlduguUrun SKRSBagimliOlduguUrun
        {
            get { return (SKRSBagimliOlduguUrun)((ITTObject)this).GetParent("SKRSBAGIMLIOLDUGUURUN"); }
            set { this["SKRSBAGIMLIOLDUGUURUN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TutunKullanimiVeriSeti TutunKullanimiVeriSeti
        {
            get { return (TutunKullanimiVeriSeti)((ITTObject)this).GetParent("TUTUNKULLANIMIVERISETI"); }
            set { this["TUTUNKULLANIMIVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TutunKullanimiBagimOldUrun(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TutunKullanimiBagimOldUrun(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TutunKullanimiBagimOldUrun(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TutunKullanimiBagimOldUrun(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TutunKullanimiBagimOldUrun(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TUTUNKULLANIMIBAGIMOLDURUN", dataRow) { }
        protected TutunKullanimiBagimOldUrun(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TUTUNKULLANIMIBAGIMOLDURUN", dataRow, isImported) { }
        public TutunKullanimiBagimOldUrun(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TutunKullanimiBagimOldUrun(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TutunKullanimiBagimOldUrun() : base() { }

    }
}