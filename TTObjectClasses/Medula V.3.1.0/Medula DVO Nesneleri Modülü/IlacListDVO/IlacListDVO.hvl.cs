
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IlacListDVO")] 

    public  partial class IlacListDVO : BaseMedulaObject
    {
        public class IlacListDVOList : TTObjectCollection<IlacListDVO> { }
                    
        public class ChildIlacListDVOCollection : TTObject.TTChildObjectCollection<IlacListDVO>
        {
            public ChildIlacListDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIlacListDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İlaç Adı
    /// </summary>
        public string ilacAdi
        {
            get { return (string)this["ILACADI"]; }
            set { this["ILACADI"] = value; }
        }

    /// <summary>
    /// İlaç Kullanım Birimi
    /// </summary>
        public double? kullanimBirimi
        {
            get { return (double?)this["KULLANIMBIRIMI"]; }
            set { this["KULLANIMBIRIMI"] = value; }
        }

    /// <summary>
    /// İlaçın Barkodu
    /// </summary>
        public string barkod
        {
            get { return (string)this["BARKOD"]; }
            set { this["BARKOD"] = value; }
        }

    /// <summary>
    /// İlaç Ara Cevap-İlaçlar
    /// </summary>
        public IlacAraCevapDVO IlacAraCevapDVO
        {
            get { return (IlacAraCevapDVO)((ITTObject)this).GetParent("ILACARACEVAPDVO"); }
            set { this["ILACARACEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateilacFiyatlariCollection()
        {
            _ilacFiyatlari = new FiyatListDVO.ChildFiyatListDVOCollection(this, new Guid("15cbd55d-7c62-4623-ba71-c50061c77c3c"));
            ((ITTChildObjectCollection)_ilacFiyatlari).GetChildren();
        }

        protected FiyatListDVO.ChildFiyatListDVOCollection _ilacFiyatlari = null;
    /// <summary>
    /// Child collection for Ilaç List-ilacFiyatlari
    /// </summary>
        public FiyatListDVO.ChildFiyatListDVOCollection ilacFiyatlari
        {
            get
            {
                if (_ilacFiyatlari == null)
                    CreateilacFiyatlariCollection();
                return _ilacFiyatlari;
            }
        }

        protected IlacListDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IlacListDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IlacListDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IlacListDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IlacListDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ILACLISTDVO", dataRow) { }
        protected IlacListDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ILACLISTDVO", dataRow, isImported) { }
        public IlacListDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IlacListDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IlacListDVO() : base() { }

    }
}