
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HizmetSunucuRefNoGenerator")] 

    public  partial class HizmetSunucuRefNoGenerator : TTObject
    {
        public class HizmetSunucuRefNoGeneratorList : TTObjectCollection<HizmetSunucuRefNoGenerator> { }
                    
        public class ChildHizmetSunucuRefNoGeneratorCollection : TTObject.TTChildObjectCollection<HizmetSunucuRefNoGenerator>
        {
            public ChildHizmetSunucuRefNoGeneratorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHizmetSunucuRefNoGeneratorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hizmet Sunucu Referans Numarası
    /// </summary>
        public TTSequence HizmetSunucuRefNo
        {
            get { return GetSequence("HIZMETSUNUCUREFNO"); }
        }

        protected HizmetSunucuRefNoGenerator(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HizmetSunucuRefNoGenerator(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HizmetSunucuRefNoGenerator(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HizmetSunucuRefNoGenerator(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HizmetSunucuRefNoGenerator(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HIZMETSUNUCUREFNOGENERATOR", dataRow) { }
        protected HizmetSunucuRefNoGenerator(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HIZMETSUNUCUREFNOGENERATOR", dataRow, isImported) { }
        public HizmetSunucuRefNoGenerator(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HizmetSunucuRefNoGenerator(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HizmetSunucuRefNoGenerator() : base() { }

    }
}