
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaBilgileriDVO")] 

    public  partial class HastaBilgileriDVO : BaseMedulaObject
    {
        public class HastaBilgileriDVOList : TTObjectCollection<HastaBilgileriDVO> { }
                    
        public class ChildHastaBilgileriDVOCollection : TTObject.TTChildObjectCollection<HastaBilgileriDVO>
        {
            public ChildHastaBilgileriDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaBilgileriDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHastaBilgileriByTCKimlikNoReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HASTABILGILERIDVO"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string devredilenKurum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVREDILENKURUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HASTABILGILERIDVO"].AllPropertyDefs["DEVREDILENKURUM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string sigortaliTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIGORTALITURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HASTABILGILERIDVO"].AllPropertyDefs["SIGORTALITURU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string tcKimlikNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCKIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HASTABILGILERIDVO"].AllPropertyDefs["TCKIMLIKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HASTABILGILERIDVO"].AllPropertyDefs["AD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string soyad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HASTABILGILERIDVO"].AllPropertyDefs["SOYAD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string cinsiyet
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HASTABILGILERIDVO"].AllPropertyDefs["CINSIYET"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string dogumTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HASTABILGILERIDVO"].AllPropertyDefs["DOGUMTARIHI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHastaBilgileriByTCKimlikNoReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHastaBilgileriByTCKimlikNoReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHastaBilgileriByTCKimlikNoReportQuery_Class() : base() { }
        }

        public static BindingList<HastaBilgileriDVO.GetHastaBilgileriByTCKimlikNoReportQuery_Class> GetHastaBilgileriByTCKimlikNoReportQuery(string TCKIMLIKNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTABILGILERIDVO"].QueryDefs["GetHastaBilgileriByTCKimlikNoReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TCKIMLIKNO", TCKIMLIKNO);

            return TTReportNqlObject.QueryObjects<HastaBilgileriDVO.GetHastaBilgileriByTCKimlikNoReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HastaBilgileriDVO.GetHastaBilgileriByTCKimlikNoReportQuery_Class> GetHastaBilgileriByTCKimlikNoReportQuery(TTObjectContext objectContext, string TCKIMLIKNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTABILGILERIDVO"].QueryDefs["GetHastaBilgileriByTCKimlikNoReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TCKIMLIKNO", TCKIMLIKNO);

            return TTReportNqlObject.QueryObjects<HastaBilgileriDVO.GetHastaBilgileriByTCKimlikNoReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public string devredilenKurum
        {
            get { return (string)this["DEVREDILENKURUM"]; }
            set { this["DEVREDILENKURUM"] = value; }
        }

    /// <summary>
    /// Sigortalı Türü
    /// </summary>
        public string sigortaliTuru
        {
            get { return (string)this["SIGORTALITURU"]; }
            set { this["SIGORTALITURU"] = value; }
        }

    /// <summary>
    /// Hasta TC Kimlik No
    /// </summary>
        public string tcKimlikNo
        {
            get { return (string)this["TCKIMLIKNO"]; }
            set { this["TCKIMLIKNO"] = value; }
        }

    /// <summary>
    /// Hastanın Adı
    /// </summary>
        public string ad
        {
            get { return (string)this["AD"]; }
            set { this["AD"] = value; }
        }

    /// <summary>
    /// Hastanın Soyadı
    /// </summary>
        public string soyad
        {
            get { return (string)this["SOYAD"]; }
            set { this["SOYAD"] = value; }
        }

    /// <summary>
    /// Hastanın Cinsiyeti
    /// </summary>
        public string cinsiyet
        {
            get { return (string)this["CINSIYET"]; }
            set { this["CINSIYET"] = value; }
        }

    /// <summary>
    /// Hastanın Doğum Tarihi
    /// </summary>
        public string dogumTarihi
        {
            get { return (string)this["DOGUMTARIHI"]; }
            set { this["DOGUMTARIHI"] = value; }
        }

        protected HastaBilgileriDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaBilgileriDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaBilgileriDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaBilgileriDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaBilgileriDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTABILGILERIDVO", dataRow) { }
        protected HastaBilgileriDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTABILGILERIDVO", dataRow, isImported) { }
        public HastaBilgileriDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaBilgileriDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaBilgileriDVO() : base() { }

    }
}