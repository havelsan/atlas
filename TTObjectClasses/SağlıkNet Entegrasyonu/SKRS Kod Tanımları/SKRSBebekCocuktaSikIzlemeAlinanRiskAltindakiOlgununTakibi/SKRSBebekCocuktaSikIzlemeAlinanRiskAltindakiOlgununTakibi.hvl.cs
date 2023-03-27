
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi")] 

    /// <summary>
    /// 9d81738b-2e2d-4251-b397-34dfb014dc9b
    /// </summary>
    public  partial class SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi : BaseSKRSCommonDef
    {
        public class SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibiList : TTObjectCollection<SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi> { }
                    
        public class ChildSKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibiCollection : TTObject.TTChildObjectCollection<SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi>
        {
            public ChildSKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlg_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBEBEKCOCUKTASIKIZLEMEALINANRISKALTINDAKIOLGUNUNTAKIBI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBEBEKCOCUKTASIKIZLEMEALINANRISKALTINDAKIOLGUNUNTAKIBI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBEBEKCOCUKTASIKIZLEMEALINANRISKALTINDAKIOLGUNUNTAKIBI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBEBEKCOCUKTASIKIZLEMEALINANRISKALTINDAKIOLGUNUNTAKIBI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBEBEKCOCUKTASIKIZLEMEALINANRISKALTINDAKIOLGUNUNTAKIBI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBEBEKCOCUKTASIKIZLEMEALINANRISKALTINDAKIOLGUNUNTAKIBI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBEBEKCOCUKTASIKIZLEMEALINANRISKALTINDAKIOLGUNUNTAKIBI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBEBEKCOCUKTASIKIZLEMEALINANRISKALTINDAKIOLGUNUNTAKIBI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBEBEKCOCUKTASIKIZLEMEALINANRISKALTINDAKIOLGUNUNTAKIBI"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBEBEKCOCUKTASIKIZLEMEALINANRISKALTINDAKIOLGUNUNTAKIBI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBEBEKCOCUKTASIKIZLEMEALINANRISKALTINDAKIOLGUNUNTAKIBI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlg_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlg_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlg_Class() : base() { }
        }

        public static BindingList<SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi.GetSKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlg_Class> GetSKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlg(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSBEBEKCOCUKTASIKIZLEMEALINANRISKALTINDAKIOLGUNUNTAKIBI"].QueryDefs["GetSKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlg"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi.GetSKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlg_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi.GetSKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlg_Class> GetSKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlg(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSBEBEKCOCUKTASIKIZLEMEALINANRISKALTINDAKIOLGUNUNTAKIBI"].QueryDefs["GetSKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlg"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi.GetSKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlg_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSBEBEKCOCUKTASIKIZLEMEALINANRISKALTINDAKIOLGUNUNTAKIBI", dataRow) { }
        protected SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSBEBEKCOCUKTASIKIZLEMEALINANRISKALTINDAKIOLGUNUNTAKIBI", dataRow, isImported) { }
        public SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSBebekCocuktaSikIzlemeAlinanRiskAltindakiOlgununTakibi() : base() { }

    }
}