
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakipFaturaDurumu")] 

    /// <summary>
    /// Takip Fatura Durumu
    /// </summary>
    public  partial class TakipFaturaDurumu : BaseMedulaDefinition
    {
        public class TakipFaturaDurumuList : TTObjectCollection<TakipFaturaDurumu> { }
                    
        public class ChildTakipFaturaDurumuCollection : TTObject.TTChildObjectCollection<TakipFaturaDurumu>
        {
            public ChildTakipFaturaDurumuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakipFaturaDurumuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTakipFaturaDurumuDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string takipFaturaDurumuKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIPFATURADURUMUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAKIPFATURADURUMU"].AllPropertyDefs["TAKIPFATURADURUMUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string takipFaturaDurumuAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIPFATURADURUMUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAKIPFATURADURUMU"].AllPropertyDefs["TAKIPFATURADURUMUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTakipFaturaDurumuDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTakipFaturaDurumuDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTakipFaturaDurumuDefinitionQuery_Class() : base() { }
        }

        public static BindingList<TakipFaturaDurumu.GetTakipFaturaDurumuDefinitionQuery_Class> GetTakipFaturaDurumuDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPFATURADURUMU"].QueryDefs["GetTakipFaturaDurumuDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TakipFaturaDurumu.GetTakipFaturaDurumuDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TakipFaturaDurumu.GetTakipFaturaDurumuDefinitionQuery_Class> GetTakipFaturaDurumuDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPFATURADURUMU"].QueryDefs["GetTakipFaturaDurumuDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TakipFaturaDurumu.GetTakipFaturaDurumuDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string takipFaturaDurumuAdi_Shado
        {
            get { return (string)this["TAKIPFATURADURUMUADI_SHADO"]; }
        }

    /// <summary>
    /// Takip Fatura Durumu Adı
    /// </summary>
        public string takipFaturaDurumuAdi
        {
            get { return (string)this["TAKIPFATURADURUMUADI"]; }
            set { this["TAKIPFATURADURUMUADI"] = value; }
        }

    /// <summary>
    /// Takip Fatura Durumu Kodu
    /// </summary>
        public string takipFaturaDurumuKodu
        {
            get { return (string)this["TAKIPFATURADURUMUKODU"]; }
            set { this["TAKIPFATURADURUMUKODU"] = value; }
        }

        protected TakipFaturaDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakipFaturaDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakipFaturaDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakipFaturaDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakipFaturaDurumu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKIPFATURADURUMU", dataRow) { }
        protected TakipFaturaDurumu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKIPFATURADURUMU", dataRow, isImported) { }
        public TakipFaturaDurumu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakipFaturaDurumu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakipFaturaDurumu() : base() { }

    }
}