
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HizmetSunucuRefNoDVO")] 

    public  partial class HizmetSunucuRefNoDVO : BaseMedulaObject
    {
        public class HizmetSunucuRefNoDVOList : TTObjectCollection<HizmetSunucuRefNoDVO> { }
                    
        public class ChildHizmetSunucuRefNoDVOCollection : TTObject.TTChildObjectCollection<HizmetSunucuRefNoDVO>
        {
            public ChildHizmetSunucuRefNoDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHizmetSunucuRefNoDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hizmet Sunucu Referans Numarası
    /// </summary>
        public string hizmetSunucuRefNo
        {
            get { return (string)this["HIZMETSUNUCUREFNO"]; }
            set { this["HIZMETSUNUCUREFNO"] = value; }
        }

    /// <summary>
    /// Hizmet İptal Giriş-Hizmet Sunucu Ref Nolar
    /// </summary>
        public HizmetIptalGirisDVO HizmetIptalGirisDVO
        {
            get { return (HizmetIptalGirisDVO)((ITTObject)this).GetParent("HIZMETIPTALGIRISDVO"); }
            set { this["HIZMETIPTALGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet Oku Giriş-Hizmet Sunucu Ref Nolar
    /// </summary>
        public HizmetOkuGirisDVO HizmetOkuGirisDVO
        {
            get { return (HizmetOkuGirisDVO)((ITTObject)this).GetParent("HIZMETOKUGIRISDVO"); }
            set { this["HIZMETOKUGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HizmetSunucuRefNoDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HizmetSunucuRefNoDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HizmetSunucuRefNoDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HizmetSunucuRefNoDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HizmetSunucuRefNoDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HIZMETSUNUCUREFNODVO", dataRow) { }
        protected HizmetSunucuRefNoDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HIZMETSUNUCUREFNODVO", dataRow, isImported) { }
        public HizmetSunucuRefNoDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HizmetSunucuRefNoDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HizmetSunucuRefNoDVO() : base() { }

    }
}