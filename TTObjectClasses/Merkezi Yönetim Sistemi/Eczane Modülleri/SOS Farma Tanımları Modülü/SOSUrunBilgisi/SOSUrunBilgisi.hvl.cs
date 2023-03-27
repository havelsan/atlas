
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SOSUrunBilgisi")] 

    public  partial class SOSUrunBilgisi : TerminologyManagerDef
    {
        public class SOSUrunBilgisiList : TTObjectCollection<SOSUrunBilgisi> { }
                    
        public class ChildSOSUrunBilgisiCollection : TTObject.TTChildObjectCollection<SOSUrunBilgisi>
        {
            public ChildSOSUrunBilgisiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSOSUrunBilgisiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSOSUrunBilgisiRQ_Class : TTReportNqlObject 
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

            public long? SOSID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOSID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNBILGISI"].AllPropertyDefs["SOSID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNBILGISI"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNBILGISI"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? PackageAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNBILGISI"].AllPropertyDefs["PACKAGEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Volume
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VOLUME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNBILGISI"].AllPropertyDefs["VOLUME"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Dose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNBILGISI"].AllPropertyDefs["DOSE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string EquivalentCRC
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EQUIVALENTCRC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOSURUNBILGISI"].AllPropertyDefs["EQUIVALENTCRC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSOSUrunBilgisiRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSOSUrunBilgisiRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSOSUrunBilgisiRQ_Class() : base() { }
        }

        public static BindingList<SOSUrunBilgisi.GetSOSUrunBilgisiRQ_Class> GetSOSUrunBilgisiRQ(Guid DRUGDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SOSURUNBILGISI"].QueryDefs["GetSOSUrunBilgisiRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGDEFINITION", DRUGDEFINITION);

            return TTReportNqlObject.QueryObjects<SOSUrunBilgisi.GetSOSUrunBilgisiRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SOSUrunBilgisi.GetSOSUrunBilgisiRQ_Class> GetSOSUrunBilgisiRQ(TTObjectContext objectContext, Guid DRUGDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SOSURUNBILGISI"].QueryDefs["GetSOSUrunBilgisiRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGDEFINITION", DRUGDEFINITION);

            return TTReportNqlObject.QueryObjects<SOSUrunBilgisi.GetSOSUrunBilgisiRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public long? SOSID
        {
            get { return (long?)this["SOSID"]; }
            set { this["SOSID"] = value; }
        }

        public string Barcode
        {
            get { return (string)this["BARCODE"]; }
            set { this["BARCODE"] = value; }
        }

    /// <summary>
    /// Ürün Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public double? PackageAmount
        {
            get { return (double?)this["PACKAGEAMOUNT"]; }
            set { this["PACKAGEAMOUNT"] = value; }
        }

    /// <summary>
    /// Hacim
    /// </summary>
        public double? Volume
        {
            get { return (double?)this["VOLUME"]; }
            set { this["VOLUME"] = value; }
        }

    /// <summary>
    /// Doz
    /// </summary>
        public double? Dose
        {
            get { return (double?)this["DOSE"]; }
            set { this["DOSE"] = value; }
        }

        public string EquivalentCRC
        {
            get { return (string)this["EQUIVALENTCRC"]; }
            set { this["EQUIVALENTCRC"] = value; }
        }

        public SOSFarmasotikSekil SOSNfc
        {
            get { return (SOSFarmasotikSekil)((ITTObject)this).GetParent("SOSNFC"); }
            set { this["SOSNFC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugDefinition XXXXXXDrugDefinition
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("XXXXXXDRUGDEFINITION"); }
            set { this["XXXXXXDRUGDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SOSListeler PrescriptionType
        {
            get { return (SOSListeler)((ITTObject)this).GetParent("PRESCRIPTIONTYPE"); }
            set { this["PRESCRIPTIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SOSListeler UnitPackage
        {
            get { return (SOSListeler)((ITTObject)this).GetParent("UNITPACKAGE"); }
            set { this["UNITPACKAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SOSListeler Unit
        {
            get { return (SOSListeler)((ITTObject)this).GetParent("UNIT"); }
            set { this["UNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SOSUygulamaKodu SOSRouteOfAdmin
        {
            get { return (SOSUygulamaKodu)((ITTObject)this).GetParent("SOSROUTEOFADMIN"); }
            set { this["SOSROUTEOFADMIN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SOSListeler CalculateType
        {
            get { return (SOSListeler)((ITTObject)this).GetParent("CALCULATETYPE"); }
            set { this["CALCULATETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSOSUrunAtcsCollection()
        {
            _SOSUrunAtcs = new SOSUrunAtc.ChildSOSUrunAtcCollection(this, new Guid("95128fef-797b-43e3-b453-b708bc504226"));
            ((ITTChildObjectCollection)_SOSUrunAtcs).GetChildren();
        }

        protected SOSUrunAtc.ChildSOSUrunAtcCollection _SOSUrunAtcs = null;
        public SOSUrunAtc.ChildSOSUrunAtcCollection SOSUrunAtcs
        {
            get
            {
                if (_SOSUrunAtcs == null)
                    CreateSOSUrunAtcsCollection();
                return _SOSUrunAtcs;
            }
        }

        virtual protected void CreateSOSUrunEtkenMaddelerCollection()
        {
            _SOSUrunEtkenMaddeler = new SOSUrunEtkenMadde.ChildSOSUrunEtkenMaddeCollection(this, new Guid("6c978928-657f-4d89-b84b-c3811ba8015f"));
            ((ITTChildObjectCollection)_SOSUrunEtkenMaddeler).GetChildren();
        }

        protected SOSUrunEtkenMadde.ChildSOSUrunEtkenMaddeCollection _SOSUrunEtkenMaddeler = null;
        public SOSUrunEtkenMadde.ChildSOSUrunEtkenMaddeCollection SOSUrunEtkenMaddeler
        {
            get
            {
                if (_SOSUrunEtkenMaddeler == null)
                    CreateSOSUrunEtkenMaddelerCollection();
                return _SOSUrunEtkenMaddeler;
            }
        }

        protected SOSUrunBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SOSUrunBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SOSUrunBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SOSUrunBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SOSUrunBilgisi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOSURUNBILGISI", dataRow) { }
        protected SOSUrunBilgisi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOSURUNBILGISI", dataRow, isImported) { }
        public SOSUrunBilgisi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SOSUrunBilgisi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SOSUrunBilgisi() : base() { }

    }
}