
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IlacTeshisBilgiDVO")] 

    public  partial class IlacTeshisBilgiDVO : BaseMedulaObject
    {
        public class IlacTeshisBilgiDVOList : TTObjectCollection<IlacTeshisBilgiDVO> { }
                    
        public class ChildIlacTeshisBilgiDVOCollection : TTObject.TTChildObjectCollection<IlacTeshisBilgiDVO>
        {
            public ChildIlacTeshisBilgiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIlacTeshisBilgiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string bitisTarihi
        {
            get { return (string)this["BITISTARIHI"]; }
            set { this["BITISTARIHI"] = value; }
        }

        public string baslangicTarihi
        {
            get { return (string)this["BASLANGICTARIHI"]; }
            set { this["BASLANGICTARIHI"] = value; }
        }

        public int? teshisKodu
        {
            get { return (int?)this["TESHISKODU"]; }
            set { this["TESHISKODU"] = value; }
        }

        public string ICD10Kodu
        {
            get { return (string)this["ICD10KODU"]; }
            set { this["ICD10KODU"] = value; }
        }

        public RaporDVO RaporDVO
        {
            get { return (RaporDVO)((ITTObject)this).GetParent("RAPORDVO"); }
            set { this["RAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IlacTeshisBilgiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IlacTeshisBilgiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IlacTeshisBilgiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IlacTeshisBilgiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IlacTeshisBilgiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ILACTESHISBILGIDVO", dataRow) { }
        protected IlacTeshisBilgiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ILACTESHISBILGIDVO", dataRow, isImported) { }
        public IlacTeshisBilgiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IlacTeshisBilgiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IlacTeshisBilgiDVO() : base() { }

    }
}