
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSPsikolojikDurumDegerlendirmesi")] 

    /// <summary>
    /// 8ed2e8ce-b1fe-49f6-91ac-8f3340deac9d
    /// </summary>
    public  partial class SKRSPsikolojikDurumDegerlendirmesi : BaseSKRSCommonDef
    {
        public class SKRSPsikolojikDurumDegerlendirmesiList : TTObjectCollection<SKRSPsikolojikDurumDegerlendirmesi> { }
                    
        public class ChildSKRSPsikolojikDurumDegerlendirmesiCollection : TTObject.TTChildObjectCollection<SKRSPsikolojikDurumDegerlendirmesi>
        {
            public ChildSKRSPsikolojikDurumDegerlendirmesiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSPsikolojikDurumDegerlendirmesiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSPsikolojikDurumDegerlendirmesi_Class : TTReportNqlObject 
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

            public bool? Default
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFAULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKOLOJIKDURUMDEGERLENDIRMESI"].AllPropertyDefs["DEFAULT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string AKTIF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AKTIF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKOLOJIKDURUMDEGERLENDIRMESI"].AllPropertyDefs["AKTIF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OLUSTURULMATARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUSTURULMATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKOLOJIKDURUMDEGERLENDIRMESI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? GUNCELLENMETARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLENMETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKOLOJIKDURUMDEGERLENDIRMESI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PASIFEALINMATARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PASIFEALINMATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKOLOJIKDURUMDEGERLENDIRMESI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? GUNCELLEMETARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLEMETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKOLOJIKDURUMDEGERLENDIRMESI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKOLOJIKDURUMDEGERLENDIRMESI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KODTIPIADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODTIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKOLOJIKDURUMDEGERLENDIRMESI"].AllPropertyDefs["KODTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKOLOJIKDURUMDEGERLENDIRMESI"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OLUSTURULMATARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUSTURULMATARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKOLOJIKDURUMDEGERLENDIRMESI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? GUNCELLENMETARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLENMETARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKOLOJIKDURUMDEGERLENDIRMESI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSPsikolojikDurumDegerlendirmesi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSPsikolojikDurumDegerlendirmesi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSPsikolojikDurumDegerlendirmesi_Class() : base() { }
        }

        public static BindingList<SKRSPsikolojikDurumDegerlendirmesi.GetSKRSPsikolojikDurumDegerlendirmesi_Class> GetSKRSPsikolojikDurumDegerlendirmesi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKOLOJIKDURUMDEGERLENDIRMESI"].QueryDefs["GetSKRSPsikolojikDurumDegerlendirmesi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSPsikolojikDurumDegerlendirmesi.GetSKRSPsikolojikDurumDegerlendirmesi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSPsikolojikDurumDegerlendirmesi.GetSKRSPsikolojikDurumDegerlendirmesi_Class> GetSKRSPsikolojikDurumDegerlendirmesi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSPSIKOLOJIKDURUMDEGERLENDIRMESI"].QueryDefs["GetSKRSPsikolojikDurumDegerlendirmesi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSPsikolojikDurumDegerlendirmesi.GetSKRSPsikolojikDurumDegerlendirmesi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreatePsikolojikDurumCollection()
        {
            _PsikolojikDurum = new PsikolojikDurum.ChildPsikolojikDurumCollection(this, new Guid("0b86cce9-47ec-49eb-976c-25b982f0a254"));
            ((ITTChildObjectCollection)_PsikolojikDurum).GetChildren();
        }

        protected PsikolojikDurum.ChildPsikolojikDurumCollection _PsikolojikDurum = null;
        public PsikolojikDurum.ChildPsikolojikDurumCollection PsikolojikDurum
        {
            get
            {
                if (_PsikolojikDurum == null)
                    CreatePsikolojikDurumCollection();
                return _PsikolojikDurum;
            }
        }

        protected SKRSPsikolojikDurumDegerlendirmesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSPsikolojikDurumDegerlendirmesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSPsikolojikDurumDegerlendirmesi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSPsikolojikDurumDegerlendirmesi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSPsikolojikDurumDegerlendirmesi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSPSIKOLOJIKDURUMDEGERLENDIRMESI", dataRow) { }
        protected SKRSPsikolojikDurumDegerlendirmesi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSPSIKOLOJIKDURUMDEGERLENDIRMESI", dataRow, isImported) { }
        public SKRSPsikolojikDurumDegerlendirmesi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSPsikolojikDurumDegerlendirmesi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSPsikolojikDurumDegerlendirmesi() : base() { }

    }
}