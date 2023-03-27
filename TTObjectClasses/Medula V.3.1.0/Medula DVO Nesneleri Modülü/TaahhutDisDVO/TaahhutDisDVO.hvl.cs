
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TaahhutDisDVO")] 

    public  partial class TaahhutDisDVO : BaseMedulaObject
    {
        public class TaahhutDisDVOList : TTObjectCollection<TaahhutDisDVO> { }
                    
        public class ChildTaahhutDisDVOCollection : TTObject.TTChildObjectCollection<TaahhutDisDVO>
        {
            public ChildTaahhutDisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTaahhutDisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class VEM_DIS_TAAHHUT_DETAY_Class : TTReportNqlObject 
        {
            public Guid? Dis_taahhut_detay_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIS_TAAHHUT_DETAY_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Dis_taahhut_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIS_TAAHHUT_KODU"]);
                }
            }

            public int? Dis_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIS_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAAHHUTDISDVO"].AllPropertyDefs["DISNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Sut_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUT_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAAHHUTDISDVO"].AllPropertyDefs["SUTKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Cene_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CENE_KODU"]);
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_DIS_TAAHHUT_DETAY_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_DIS_TAAHHUT_DETAY_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_DIS_TAAHHUT_DETAY_Class() : base() { }
        }

        public static BindingList<TaahhutDisDVO.VEM_DIS_TAAHHUT_DETAY_Class> VEM_DIS_TAAHHUT_DETAY(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAAHHUTDISDVO"].QueryDefs["VEM_DIS_TAAHHUT_DETAY"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TaahhutDisDVO.VEM_DIS_TAAHHUT_DETAY_Class>(queryDef, paramList, pi);
        }

        public static BindingList<TaahhutDisDVO.VEM_DIS_TAAHHUT_DETAY_Class> VEM_DIS_TAAHHUT_DETAY(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAAHHUTDISDVO"].QueryDefs["VEM_DIS_TAAHHUT_DETAY"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TaahhutDisDVO.VEM_DIS_TAAHHUT_DETAY_Class>(objectContext, queryDef, paramList, pi);
        }

        public int? disNo
        {
            get { return (int?)this["DISNO"]; }
            set { this["DISNO"] = value; }
        }

        public string sutKodu
        {
            get { return (string)this["SUTKODU"]; }
            set { this["SUTKODU"] = value; }
        }

        public TaahhutKayitDVO TaahhutKayitDVO
        {
            get { return (TaahhutKayitDVO)((ITTObject)this).GetParent("TAAHHUTKAYITDVO"); }
            set { this["TAAHHUTKAYITDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TaahhutDisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TaahhutDisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TaahhutDisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TaahhutDisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TaahhutDisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAAHHUTDISDVO", dataRow) { }
        protected TaahhutDisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAAHHUTDISDVO", dataRow, isImported) { }
        public TaahhutDisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TaahhutDisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TaahhutDisDVO() : base() { }

    }
}