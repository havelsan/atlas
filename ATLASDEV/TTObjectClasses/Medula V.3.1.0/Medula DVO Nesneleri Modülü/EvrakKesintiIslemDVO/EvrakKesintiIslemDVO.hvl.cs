
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EvrakKesintiIslemDVO")] 

    public  partial class EvrakKesintiIslemDVO : BaseMedulaObject
    {
        public class EvrakKesintiIslemDVOList : TTObjectCollection<EvrakKesintiIslemDVO> { }
                    
        public class ChildEvrakKesintiIslemDVOCollection : TTObject.TTChildObjectCollection<EvrakKesintiIslemDVO>
        {
            public ChildEvrakKesintiIslemDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEvrakKesintiIslemDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string grupTuru
        {
            get { return (string)this["GRUPTURU"]; }
            set { this["GRUPTURU"] = value; }
        }

        public string grupAdi
        {
            get { return (string)this["GRUPADI"]; }
            set { this["GRUPADI"] = value; }
        }

    /// <summary>
    /// Takip Numarası
    /// </summary>
        public string takipNo
        {
            get { return (string)this["TAKIPNO"]; }
            set { this["TAKIPNO"] = value; }
        }

        public string islemSiraNo
        {
            get { return (string)this["ISLEMSIRANO"]; }
            set { this["ISLEMSIRANO"] = value; }
        }

        public DateTime? islemTarihi
        {
            get { return (DateTime?)this["ISLEMTARIHI"]; }
            set { this["ISLEMTARIHI"] = value; }
        }

        public string sutKodu
        {
            get { return (string)this["SUTKODU"]; }
            set { this["SUTKODU"] = value; }
        }

        public string islemAdi
        {
            get { return (string)this["ISLEMADI"]; }
            set { this["ISLEMADI"] = value; }
        }

        public double? tutar
        {
            get { return (double?)this["TUTAR"]; }
            set { this["TUTAR"] = value; }
        }

        public double? kesintiTutari
        {
            get { return (double?)this["KESINTITUTARI"]; }
            set { this["KESINTITUTARI"] = value; }
        }

        public string aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

        public EvrakKesintiCevapDVO EvrakKesintiCevapDVO
        {
            get { return (EvrakKesintiCevapDVO)((ITTObject)this).GetParent("EVRAKKESINTICEVAPDVO"); }
            set { this["EVRAKKESINTICEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EvrakKesintiIslemDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EvrakKesintiIslemDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EvrakKesintiIslemDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EvrakKesintiIslemDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EvrakKesintiIslemDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EVRAKKESINTIISLEMDVO", dataRow) { }
        protected EvrakKesintiIslemDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EVRAKKESINTIISLEMDVO", dataRow, isImported) { }
        public EvrakKesintiIslemDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EvrakKesintiIslemDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EvrakKesintiIslemDVO() : base() { }

    }
}