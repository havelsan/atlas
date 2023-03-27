
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UTSAllMaterial")] 

    public  partial class UTSAllMaterial : TTObject
    {
        public class UTSAllMaterialList : TTObjectCollection<UTSAllMaterial> { }
                    
        public class ChildUTSAllMaterialCollection : TTObject.TTChildObjectCollection<UTSAllMaterial>
        {
            public ChildUTSAllMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUTSAllMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUTSMaterialByFilter_Class : TTReportNqlObject 
        {
            public string birincilUrunNumarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRINCILURUNNUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UTSALLMATERIAL"].AllPropertyDefs["BIRINCILURUNNUMARASI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string sinif
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SINIF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UTSALLMATERIAL"].AllPropertyDefs["SINIF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string takipDurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIPDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UTSALLMATERIAL"].AllPropertyDefs["TAKIPDURUMU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUTSMaterialByFilter_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUTSMaterialByFilter_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUTSMaterialByFilter_Class() : base() { }
        }

        public static BindingList<UTSAllMaterial.GetUTSMaterialByFilter_Class> GetUTSMaterialByFilter(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UTSALLMATERIAL"].QueryDefs["GetUTSMaterialByFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<UTSAllMaterial.GetUTSMaterialByFilter_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<UTSAllMaterial.GetUTSMaterialByFilter_Class> GetUTSMaterialByFilter(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UTSALLMATERIAL"].QueryDefs["GetUTSMaterialByFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<UTSAllMaterial.GetUTSMaterialByFilter_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string sinif
        {
            get { return (string)this["SINIF"]; }
            set { this["SINIF"] = value; }
        }

        public string takipDurumu
        {
            get { return (string)this["TAKIPDURUMU"]; }
            set { this["TAKIPDURUMU"] = value; }
        }

        public string birincilUrunNumarasi
        {
            get { return (string)this["BIRINCILURUNNUMARASI"]; }
            set { this["BIRINCILURUNNUMARASI"] = value; }
        }

        public string urunTipi
        {
            get { return (string)this["URUNTIPI"]; }
            set { this["URUNTIPI"] = value; }
        }

        public string durum
        {
            get { return (string)this["DURUM"]; }
            set { this["DURUM"] = value; }
        }

        public DateTime? durumBaslagicTarihi
        {
            get { return (DateTime?)this["DURUMBASLAGICTARIHI"]; }
            set { this["DURUMBASLAGICTARIHI"] = value; }
        }

        public string markaAdi
        {
            get { return (string)this["MARKAADI"]; }
            set { this["MARKAADI"] = value; }
        }

        public string etiketAdi
        {
            get { return (string)this["ETIKETADI"]; }
            set { this["ETIKETADI"] = value; }
        }

        public string versiyonModel
        {
            get { return (string)this["VERSIYONMODEL"]; }
            set { this["VERSIYONMODEL"] = value; }
        }

        public string katalogNo
        {
            get { return (string)this["KATALOGNO"]; }
            set { this["KATALOGNO"] = value; }
        }

        public string ithalImalBilgisi
        {
            get { return (string)this["ITHALIMALBILGISI"]; }
            set { this["ITHALIMALBILGISI"] = value; }
        }

        public DateTime? guncellenmeTarihi
        {
            get { return (DateTime?)this["GUNCELLENMETARIHI"]; }
            set { this["GUNCELLENMETARIHI"] = value; }
        }

        protected UTSAllMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UTSAllMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UTSAllMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UTSAllMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UTSAllMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UTSALLMATERIAL", dataRow) { }
        protected UTSAllMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UTSALLMATERIAL", dataRow, isImported) { }
        public UTSAllMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UTSAllMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UTSAllMaterial() : base() { }

    }
}