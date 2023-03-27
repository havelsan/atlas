
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FTRRaporBilgisiDVO")] 

    public  partial class FTRRaporBilgisiDVO : BaseMedulaObject
    {
        public class FTRRaporBilgisiDVOList : TTObjectCollection<FTRRaporBilgisiDVO> { }
                    
        public class ChildFTRRaporBilgisiDVOCollection : TTObject.TTChildObjectCollection<FTRRaporBilgisiDVO>
        {
            public ChildFTRRaporBilgisiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFTRRaporBilgisiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? ftrVucutBolgesiKodu
        {
            get { return (int?)this["FTRVUCUTBOLGESIKODU"]; }
            set { this["FTRVUCUTBOLGESIKODU"] = value; }
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

        public string tedaviTuru
        {
            get { return (string)this["TEDAVITURU"]; }
            set { this["TEDAVITURU"] = value; }
        }

        protected FTRRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FTRRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FTRRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FTRRaporBilgisiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FTRRaporBilgisiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FTRRAPORBILGISIDVO", dataRow) { }
        protected FTRRaporBilgisiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FTRRAPORBILGISIDVO", dataRow, isImported) { }
        public FTRRaporBilgisiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FTRRaporBilgisiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FTRRaporBilgisiDVO() : base() { }

    }
}