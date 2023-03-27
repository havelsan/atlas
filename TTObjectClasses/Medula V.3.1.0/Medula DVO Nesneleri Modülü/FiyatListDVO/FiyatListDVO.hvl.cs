
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FiyatListDVO")] 

    public  partial class FiyatListDVO : BaseMedulaObject
    {
        public class FiyatListDVOList : TTObjectCollection<FiyatListDVO> { }
                    
        public class ChildFiyatListDVOCollection : TTObject.TTChildObjectCollection<FiyatListDVO>
        {
            public ChildFiyatListDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFiyatListDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İlaç Geçerlilik Tarihi
    /// </summary>
        public string gecerlilikTarihi
        {
            get { return (string)this["GECERLILIKTARIHI"]; }
            set { this["GECERLILIKTARIHI"] = value; }
        }

    /// <summary>
    /// İlaç Fiyat Bilgisi
    /// </summary>
        public double? fiyat
        {
            get { return (double?)this["FIYAT"]; }
            set { this["FIYAT"] = value; }
        }

    /// <summary>
    /// Ilaç List-ilacFiyatlari
    /// </summary>
        public IlacListDVO IlacListDVO
        {
            get { return (IlacListDVO)((ITTObject)this).GetParent("ILACLISTDVO"); }
            set { this["ILACLISTDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FiyatListDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FiyatListDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FiyatListDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FiyatListDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FiyatListDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIYATLISTDVO", dataRow) { }
        protected FiyatListDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIYATLISTDVO", dataRow, isImported) { }
        public FiyatListDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FiyatListDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FiyatListDVO() : base() { }

    }
}