
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IslemSiraNoDVO")] 

    public  partial class IslemSiraNoDVO : BaseMedulaObject
    {
        public class IslemSiraNoDVOList : TTObjectCollection<IslemSiraNoDVO> { }
                    
        public class ChildIslemSiraNoDVOCollection : TTObject.TTChildObjectCollection<IslemSiraNoDVO>
        {
            public ChildIslemSiraNoDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIslemSiraNoDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Hizmet Oku Giriş-İşlem Sıra Numaraları
    /// </summary>
        public HizmetOkuGirisDVO HizmetOkuGirisDVO
        {
            get { return (HizmetOkuGirisDVO)((ITTObject)this).GetParent("HIZMETOKUGIRISDVO"); }
            set { this["HIZMETOKUGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet İptal Giriş-İşlem Sıra Numaraları
    /// </summary>
        public HizmetIptalGirisDVO HizmetIptalGirisDVO
        {
            get { return (HizmetIptalGirisDVO)((ITTObject)this).GetParent("HIZMETIPTALGIRISDVO"); }
            set { this["HIZMETIPTALGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IslemSiraNoDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IslemSiraNoDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IslemSiraNoDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IslemSiraNoDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IslemSiraNoDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ISLEMSIRANODVO", dataRow) { }
        protected IslemSiraNoDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ISLEMSIRANODVO", dataRow, isImported) { }
        public IslemSiraNoDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IslemSiraNoDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IslemSiraNoDVO() : base() { }

    }
}