
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturaIptalGirisDVO")] 

    public  partial class FaturaIptalGirisDVO : BaseMedulaObject
    {
        public class FaturaIptalGirisDVOList : TTObjectCollection<FaturaIptalGirisDVO> { }
                    
        public class ChildFaturaIptalGirisDVOCollection : TTObject.TTChildObjectCollection<FaturaIptalGirisDVO>
        {
            public ChildFaturaIptalGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturaIptalGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tesis Kodu
    /// </summary>
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

    /// <summary>
    /// Fatura İptal Cevap
    /// </summary>
        public FaturaIptalCevapDVO faturaIptalCevapDVO
        {
            get { return (FaturaIptalCevapDVO)((ITTObject)this).GetParent("FATURAIPTALCEVAPDVO"); }
            set { this["FATURAIPTALCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatefaturaTeslimNoDVOsCollection()
        {
            _faturaTeslimNoDVOs = new FaturaTeslimNoDVO.ChildFaturaTeslimNoDVOCollection(this, new Guid("c253f4b3-eec2-4a64-be3f-2936fb0a38d3"));
            ((ITTChildObjectCollection)_faturaTeslimNoDVOs).GetChildren();
        }

        protected FaturaTeslimNoDVO.ChildFaturaTeslimNoDVOCollection _faturaTeslimNoDVOs = null;
    /// <summary>
    /// Child collection for Fatura İptal Giriş-Fatura Teslim Numaraları
    /// </summary>
        public FaturaTeslimNoDVO.ChildFaturaTeslimNoDVOCollection faturaTeslimNoDVOs
        {
            get
            {
                if (_faturaTeslimNoDVOs == null)
                    CreatefaturaTeslimNoDVOsCollection();
                return _faturaTeslimNoDVOs;
            }
        }

        protected FaturaIptalGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturaIptalGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturaIptalGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturaIptalGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturaIptalGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURAIPTALGIRISDVO", dataRow) { }
        protected FaturaIptalGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURAIPTALGIRISDVO", dataRow, isImported) { }
        public FaturaIptalGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturaIptalGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturaIptalGirisDVO() : base() { }

    }
}