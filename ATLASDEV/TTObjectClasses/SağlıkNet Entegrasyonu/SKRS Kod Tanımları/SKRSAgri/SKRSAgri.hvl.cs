
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSAgri")] 

    /// <summary>
    /// a87d1c7a-36f1-4950-87a3-0cc1b61c1265
    /// </summary>
    public  partial class SKRSAgri : BaseSKRSCommonDef
    {
        public class SKRSAgriList : TTObjectCollection<SKRSAgri> { }
                    
        public class ChildSKRSAgriCollection : TTObject.TTChildObjectCollection<SKRSAgri>
        {
            public ChildSKRSAgriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSAgriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSAgri_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAGRI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAGRI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAGRI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAGRI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAGRI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAGRI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAGRI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAGRI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAGRI"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAGRI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAGRI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSAgri_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSAgri_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSAgri_Class() : base() { }
        }

        public static BindingList<SKRSAgri.GetSKRSAgri_Class> GetSKRSAgri(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSAGRI"].QueryDefs["GetSKRSAgri"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAgri.GetSKRSAgri_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSAgri.GetSKRSAgri_Class> GetSKRSAgri(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSAGRI"].QueryDefs["GetSKRSAgri"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAgri.GetSKRSAgri_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateEvdeSaglikIlkIzlemVeriSetiCollection()
        {
            _EvdeSaglikIlkIzlemVeriSeti = new EvdeSaglikIlkIzlemVeriSeti.ChildEvdeSaglikIlkIzlemVeriSetiCollection(this, new Guid("f1af5b8e-a04b-4027-b3eb-187f8b2d5ec2"));
            ((ITTChildObjectCollection)_EvdeSaglikIlkIzlemVeriSeti).GetChildren();
        }

        protected EvdeSaglikIlkIzlemVeriSeti.ChildEvdeSaglikIlkIzlemVeriSetiCollection _EvdeSaglikIlkIzlemVeriSeti = null;
        public EvdeSaglikIlkIzlemVeriSeti.ChildEvdeSaglikIlkIzlemVeriSetiCollection EvdeSaglikIlkIzlemVeriSeti
        {
            get
            {
                if (_EvdeSaglikIlkIzlemVeriSeti == null)
                    CreateEvdeSaglikIlkIzlemVeriSetiCollection();
                return _EvdeSaglikIlkIzlemVeriSeti;
            }
        }

        virtual protected void CreateEvdeSaglikIzlemVeriSetiCollection()
        {
            _EvdeSaglikIzlemVeriSeti = new EvdeSaglikIzlemVeriSeti.ChildEvdeSaglikIzlemVeriSetiCollection(this, new Guid("4608c38c-15b9-4f6e-b351-22bbaccd31e8"));
            ((ITTChildObjectCollection)_EvdeSaglikIzlemVeriSeti).GetChildren();
        }

        protected EvdeSaglikIzlemVeriSeti.ChildEvdeSaglikIzlemVeriSetiCollection _EvdeSaglikIzlemVeriSeti = null;
        public EvdeSaglikIzlemVeriSeti.ChildEvdeSaglikIzlemVeriSetiCollection EvdeSaglikIzlemVeriSeti
        {
            get
            {
                if (_EvdeSaglikIzlemVeriSeti == null)
                    CreateEvdeSaglikIzlemVeriSetiCollection();
                return _EvdeSaglikIzlemVeriSeti;
            }
        }

        protected SKRSAgri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSAgri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSAgri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSAgri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSAgri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSAGRI", dataRow) { }
        protected SKRSAgri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSAGRI", dataRow, isImported) { }
        public SKRSAgri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSAgri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSAgri() : base() { }

    }
}