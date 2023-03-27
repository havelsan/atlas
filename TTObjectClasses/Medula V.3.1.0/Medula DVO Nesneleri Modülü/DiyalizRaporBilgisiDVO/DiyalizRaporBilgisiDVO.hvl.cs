
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiyalizRaporBilgisiDVO")] 

    public  partial class DiyalizRaporBilgisiDVO : BaseMedulaObject
    {
        public class DiyalizRaporBilgisiDVOList : TTObjectCollection<DiyalizRaporBilgisiDVO> { }
                    
        public class ChildDiyalizRaporBilgisiDVOCollection : TTObject.TTChildObjectCollection<DiyalizRaporBilgisiDVO>
        {
            public ChildDiyalizRaporBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiyalizRaporBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string refakatVarMi
        {
            get { return (string)this["REFAKATVARMI"]; }
            set { this["REFAKATVARMI"] = value; }
        }

        public int? seansGun
        {
            get { return (int?)this["SEANSGUN"]; }
            set { this["SEANSGUN"] = value; }
        }

        public int? seansSayi
        {
            get { return (int?)this["SEANSSAYI"]; }
            set { this["SEANSSAYI"] = value; }
        }

        public string butKodu
        {
            get { return (string)this["BUTKODU"]; }
            set { this["BUTKODU"] = value; }
        }

        protected DiyalizRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiyalizRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiyalizRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiyalizRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiyalizRaporBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIYALIZRAPORBILGISIDVO", dataRow) { }
        protected DiyalizRaporBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIYALIZRAPORBILGISIDVO", dataRow, isImported) { }
        public DiyalizRaporBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiyalizRaporBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiyalizRaporBilgisiDVO() : base() { }

    }
}