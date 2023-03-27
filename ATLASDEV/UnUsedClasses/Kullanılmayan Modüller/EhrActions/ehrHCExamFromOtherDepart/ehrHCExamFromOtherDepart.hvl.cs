
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrHCExamFromOtherDepart")] 

    /// <summary>
    /// Diğer Birimlerden Sağlık Kurulu Muayenesi
    /// </summary>
    public  partial class ehrHCExamFromOtherDepart : ehrEpisodeAction
    {
        public class ehrHCExamFromOtherDepartList : TTObjectCollection<ehrHCExamFromOtherDepart> { }
                    
        public class ChildehrHCExamFromOtherDepartCollection : TTObject.TTChildObjectCollection<ehrHCExamFromOtherDepart>
        {
            public ChildehrHCExamFromOtherDepartCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrHCExamFromOtherDepartCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

        protected ehrHCExamFromOtherDepart(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrHCExamFromOtherDepart(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrHCExamFromOtherDepart(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrHCExamFromOtherDepart(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrHCExamFromOtherDepart(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRHCEXAMFROMOTHERDEPART", dataRow) { }
        protected ehrHCExamFromOtherDepart(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRHCEXAMFROMOTHERDEPART", dataRow, isImported) { }
        public ehrHCExamFromOtherDepart(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrHCExamFromOtherDepart(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrHCExamFromOtherDepart() : base() { }

    }
}