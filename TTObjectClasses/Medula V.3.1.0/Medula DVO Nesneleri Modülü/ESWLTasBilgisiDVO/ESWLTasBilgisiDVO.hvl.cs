
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ESWLTasBilgisiDVO")] 

    public  partial class ESWLTasBilgisiDVO : BaseMedulaObject
    {
        public class ESWLTasBilgisiDVOList : TTObjectCollection<ESWLTasBilgisiDVO> { }
                    
        public class ChildESWLTasBilgisiDVOCollection : TTObject.TTChildObjectCollection<ESWLTasBilgisiDVO>
        {
            public ChildESWLTasBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildESWLTasBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? tasLokalizasyonKodu
        {
            get { return (int?)this["TASLOKALIZASYONKODU"]; }
            set { this["TASLOKALIZASYONKODU"] = value; }
        }

        public string tasBoyutu
        {
            get { return (string)this["TASBOYUTU"]; }
            set { this["TASBOYUTU"] = value; }
        }

        public ESWLRaporBilgisiDVO ESWLRaporBilgisiDVO
        {
            get { return (ESWLRaporBilgisiDVO)((ITTObject)this).GetParent("ESWLRAPORBILGISIDVO"); }
            set { this["ESWLRAPORBILGISIDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ESWLTasBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ESWLTasBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ESWLTasBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ESWLTasBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ESWLTasBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ESWLTASBILGISIDVO", dataRow) { }
        protected ESWLTasBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ESWLTASBILGISIDVO", dataRow, isImported) { }
        public ESWLTasBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ESWLTasBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ESWLTasBilgisiDVO() : base() { }

    }
}