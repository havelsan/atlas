
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SaglikTesisi")] 

    /// <summary>
    /// Sağlık Tesisi
    /// </summary>
    public  partial class SaglikTesisi : BaseMedulaDefinition
    {
        public class SaglikTesisiList : TTObjectCollection<SaglikTesisi> { }
                    
        public class ChildSaglikTesisiCollection : TTObject.TTChildObjectCollection<SaglikTesisi>
        {
            public ChildSaglikTesisiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSaglikTesisiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSaglikTesisiDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? tesisKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESISKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAGLIKTESISI"].AllPropertyDefs["TESISKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string tesisAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESISADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAGLIKTESISI"].AllPropertyDefs["TESISADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string tesisIl
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESISIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAGLIKTESISI"].AllPropertyDefs["TESISIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string tesisSinifKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESISSINIFKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAGLIKTESISI"].AllPropertyDefs["TESISSINIFKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string tesisTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESISTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAGLIKTESISI"].AllPropertyDefs["TESISTURU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
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

            public GetSaglikTesisiDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSaglikTesisiDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSaglikTesisiDefinitionQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class SAGLIKTESISLERIReportQuery_Class : TTReportNqlObject 
        {
            public int? tesisKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESISKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAGLIKTESISI"].AllPropertyDefs["TESISKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string tesisAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESISADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAGLIKTESISI"].AllPropertyDefs["TESISADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SAGLIKTESISLERIReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SAGLIKTESISLERIReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SAGLIKTESISLERIReportQuery_Class() : base() { }
        }

        public static BindingList<SaglikTesisi.GetSaglikTesisiDefinitionQuery_Class> GetSaglikTesisiDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SAGLIKTESISI"].QueryDefs["GetSaglikTesisiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SaglikTesisi.GetSaglikTesisiDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SaglikTesisi.GetSaglikTesisiDefinitionQuery_Class> GetSaglikTesisiDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SAGLIKTESISI"].QueryDefs["GetSaglikTesisiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SaglikTesisi.GetSaglikTesisiDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SaglikTesisi.SAGLIKTESISLERIReportQuery_Class> SAGLIKTESISLERIReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SAGLIKTESISI"].QueryDefs["SAGLIKTESISLERIReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SaglikTesisi.SAGLIKTESISLERIReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SaglikTesisi.SAGLIKTESISLERIReportQuery_Class> SAGLIKTESISLERIReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SAGLIKTESISI"].QueryDefs["SAGLIKTESISLERIReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SaglikTesisi.SAGLIKTESISLERIReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Kullanıcı Şifresi
    /// </summary>
        public string kullaniciSifresi
        {
            get { return (string)this["KULLANICISIFRESI"]; }
            set { this["KULLANICISIFRESI"] = value; }
        }

    /// <summary>
    /// Tesisin Kodu
    /// </summary>
        public int? tesisKodu
        {
            get { return (int?)this["TESISKODU"]; }
            set { this["TESISKODU"] = value; }
        }

    /// <summary>
    /// Tesisin Türü
    /// </summary>
        public string tesisTuru
        {
            get { return (string)this["TESISTURU"]; }
            set { this["TESISTURU"] = value; }
        }

    /// <summary>
    /// Tesisin İl Kodu
    /// </summary>
        public string tesisIl
        {
            get { return (string)this["TESISIL"]; }
            set { this["TESISIL"] = value; }
        }

    /// <summary>
    /// Tesis Adı
    /// </summary>
        public string tesisAdi
        {
            get { return (string)this["TESISADI"]; }
            set { this["TESISADI"] = value; }
        }

        public string tesisAdi_Shadow
        {
            get { return (string)this["TESISADI_SHADOW"]; }
        }

    /// <summary>
    /// Kullanıcı Adı Test
    /// </summary>
        public string kullaniciAdiTest
        {
            get { return (string)this["KULLANICIADITEST"]; }
            set { this["KULLANICIADITEST"] = value; }
        }

    /// <summary>
    /// Kullanıcı Şifresi Test
    /// </summary>
        public string kullaniciSifresiTest
        {
            get { return (string)this["KULLANICISIFRESITEST"]; }
            set { this["KULLANICISIFRESITEST"] = value; }
        }

        public bool? IsXXXXXXExist
        {
            get { return (bool?)this["ISXXXXXXEXIST"]; }
            set { this["ISXXXXXXEXIST"] = value; }
        }

        public long? ITSGLN
        {
            get { return (long?)this["ITSGLN"]; }
            set { this["ITSGLN"] = value; }
        }

        public string ITSPassword
        {
            get { return (string)this["ITSPASSWORD"]; }
            set { this["ITSPASSWORD"] = value; }
        }

        public string ITSUserName
        {
            get { return (string)this["ITSUSERNAME"]; }
            set { this["ITSUSERNAME"] = value; }
        }

        public long? PTSGLN
        {
            get { return (long?)this["PTSGLN"]; }
            set { this["PTSGLN"] = value; }
        }

        public string PTSPassword
        {
            get { return (string)this["PTSPASSWORD"]; }
            set { this["PTSPASSWORD"] = value; }
        }

        public string PTSUserName
        {
            get { return (string)this["PTSUSERNAME"]; }
            set { this["PTSUSERNAME"] = value; }
        }

    /// <summary>
    /// Tesis Kısa Adı
    /// </summary>
        public string tesisKisaAdi
        {
            get { return (string)this["TESISKISAADI"]; }
            set { this["TESISKISAADI"] = value; }
        }

    /// <summary>
    /// Kullanıcı Adı
    /// </summary>
        public string kullaniciAdi
        {
            get { return (string)this["KULLANICIADI"]; }
            set { this["KULLANICIADI"] = value; }
        }

    /// <summary>
    /// Tesis Sınıf Kodu
    /// </summary>
        public string tesisSinifKodu
        {
            get { return (string)this["TESISSINIFKODU"]; }
            set { this["TESISSINIFKODU"] = value; }
        }

        protected SaglikTesisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SaglikTesisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SaglikTesisi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SaglikTesisi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SaglikTesisi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SAGLIKTESISI", dataRow) { }
        protected SaglikTesisi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SAGLIKTESISI", dataRow, isImported) { }
        public SaglikTesisi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SaglikTesisi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SaglikTesisi() : base() { }

    }
}