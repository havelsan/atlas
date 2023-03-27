
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IslemDetayDVO")] 

    public  partial class IslemDetayDVO : BaseMedulaObject
    {
        public class IslemDetayDVOList : TTObjectCollection<IslemDetayDVO> { }
                    
        public class ChildIslemDetayDVOCollection : TTObject.TTChildObjectCollection<IslemDetayDVO>
        {
            public ChildIslemDetayDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIslemDetayDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlem Tutarı
    /// </summary>
        public double? islemTutari
        {
            get { return (double?)this["ISLEMTUTARI"]; }
            set { this["ISLEMTUTARI"] = value; }
        }

    /// <summary>
    /// İşlem Sıra Numarası
    /// </summary>
        public string islemSiraNo
        {
            get { return (string)this["ISLEMSIRANO"]; }
            set { this["ISLEMSIRANO"] = value; }
        }

    /// <summary>
    /// Fatura Detay-İşlem Detayları
    /// </summary>
        public FaturaDetayDVO FaturaDetayDVO
        {
            get { return (FaturaDetayDVO)((ITTObject)this).GetParent("FATURADETAYDVO"); }
            set { this["FATURADETAYDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fatura Cevap Detay-İşlem Detayları
    /// </summary>
        public FaturaCevapDetayDVO FaturaCevapDetayDVO
        {
            get { return (FaturaCevapDetayDVO)((ITTObject)this).GetParent("FATURACEVAPDETAYDVO"); }
            set { this["FATURACEVAPDETAYDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IslemDetayDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IslemDetayDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IslemDetayDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IslemDetayDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IslemDetayDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ISLEMDETAYDVO", dataRow) { }
        protected IslemDetayDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ISLEMDETAYDVO", dataRow, isImported) { }
        public IslemDetayDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IslemDetayDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IslemDetayDVO() : base() { }

    }
}