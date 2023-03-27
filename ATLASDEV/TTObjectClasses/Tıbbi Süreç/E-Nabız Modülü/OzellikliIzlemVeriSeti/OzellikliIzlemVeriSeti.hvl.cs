
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OzellikliIzlemVeriSeti")] 

    public  partial class OzellikliIzlemVeriSeti : ENabiz
    {
        public class OzellikliIzlemVeriSetiList : TTObjectCollection<OzellikliIzlemVeriSeti> { }
                    
        public class ChildOzellikliIzlemVeriSetiCollection : TTObject.TTChildObjectCollection<OzellikliIzlemVeriSeti>
        {
            public ChildOzellikliIzlemVeriSetiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOzellikliIzlemVeriSetiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOzellikliIzlemVeriSeti_Class : TTReportNqlObject 
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

            public int? PackageID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OZELLIKLIIZLEMVERISETI"].AllPropertyDefs["PACKAGEID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string PackageName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OZELLIKLIIZLEMVERISETI"].AllPropertyDefs["PACKAGENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OZELLIKLIIZLEMVERISETI"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public int? PaoFioRatio
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAOFIORATIO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OZELLIKLIIZLEMVERISETI"].AllPropertyDefs["PAOFIORATIO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProgressDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROGRESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OZELLIKLIIZLEMVERISETI"].AllPropertyDefs["PROGRESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsProgressDeleted
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPROGRESSDELETED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OZELLIKLIIZLEMVERISETI"].AllPropertyDefs["ISPROGRESSDELETED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetOzellikliIzlemVeriSeti_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOzellikliIzlemVeriSeti_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOzellikliIzlemVeriSeti_Class() : base() { }
        }

        public static BindingList<OzellikliIzlemVeriSeti.GetOzellikliIzlemVeriSeti_Class> GetOzellikliIzlemVeriSeti(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OZELLIKLIIZLEMVERISETI"].QueryDefs["GetOzellikliIzlemVeriSeti"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OzellikliIzlemVeriSeti.GetOzellikliIzlemVeriSeti_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OzellikliIzlemVeriSeti.GetOzellikliIzlemVeriSeti_Class> GetOzellikliIzlemVeriSeti(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OZELLIKLIIZLEMVERISETI"].QueryDefs["GetOzellikliIzlemVeriSeti"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OzellikliIzlemVeriSeti.GetOzellikliIzlemVeriSeti_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// İzlem Notu
    /// </summary>
        public object Description
        {
            get { return (object)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// PAO2-FIO2 Oranı
    /// </summary>
        public int? PaoFioRatio
        {
            get { return (int?)this["PAOFIORATIO"]; }
            set { this["PAOFIORATIO"] = value; }
        }

    /// <summary>
    /// İzlem Tarihi
    /// </summary>
        public DateTime? ProgressDate
        {
            get { return (DateTime?)this["PROGRESSDATE"]; }
            set { this["PROGRESSDATE"] = value; }
        }

    /// <summary>
    /// İzlem silinirse bu veri de iptal adımına alınmalıdır
    /// </summary>
        public bool? IsProgressDeleted
        {
            get { return (bool?)this["ISPROGRESSDELETED"]; }
            set { this["ISPROGRESSDELETED"] = value; }
        }

    /// <summary>
    /// Yoğun Bakımda mı
    /// </summary>
        public SKRSDurum IsIntensiveCare
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("ISINTENSIVECARE"); }
            set { this["ISINTENSIVECARE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İzolasyon Amaçlı Yatış Mı
    /// </summary>
        public SKRSDurum IsIsolatedInpatient
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("ISISOLATEDINPATIENT"); }
            set { this["ISISOLATEDINPATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Covid Dışı Yatış Mı
    /// </summary>
        public SKRSDurum NonCovidInpatient
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("NONCOVIDINPATIENT"); }
            set { this["NONCOVIDINPATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Klinik Bulgu Var mı
    /// </summary>
        public SKRSDurum HasClinicalFinding
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("HASCLINICALFINDING"); }
            set { this["HASCLINICALFINDING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// BT Çekildi Mi
    /// </summary>
        public SKRSDurum HasCT
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("HASCT"); }
            set { this["HASCT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Pnömoni Var Mı
    /// </summary>
        public SKRSDurum HasPneumonia
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("HASPNEUMONIA"); }
            set { this["HASPNEUMONIA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Entübasyon Var mı
    /// </summary>
        public SKRSDurum HasIntubation
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("HASINTUBATION"); }
            set { this["HASINTUBATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yüksek Doz C Vitamini
    /// </summary>
        public SKRSDurum HighDoseCvitamin
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("HIGHDOSECVITAMIN"); }
            set { this["HIGHDOSECVITAMIN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hidroksiklorokin
    /// </summary>
        public SKRSDurum Hydroxychloroquine
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("HYDROXYCHLOROQUINE"); }
            set { this["HYDROXYCHLOROQUINE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kaletra
    /// </summary>
        public SKRSDurum Kaletra
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("KALETRA"); }
            set { this["KALETRA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Oseltamivir 75Gr Taniflu
    /// </summary>
        public SKRSDurum Oseltamivir
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("OSELTAMIVIR"); }
            set { this["OSELTAMIVIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Azitromisin
    /// </summary>
        public SKRSDurum Azitromisin
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("AZITROMISIN"); }
            set { this["AZITROMISIN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Favipavir Avigan
    /// </summary>
        public SKRSDurum FavipavirAvigan
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("FAVIPAVIRAVIGAN"); }
            set { this["FAVIPAVIRAVIGAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Klinik İzlem Notu
    /// </summary>
        public InPatientPhysicianProgresses InPatientPhysicianProgresses
        {
            get { return (InPatientPhysicianProgresses)((ITTObject)this).GetParent("INPATIENTPHYSICIANPROGRESSES"); }
            set { this["INPATIENTPHYSICIANPROGRESSES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İzlemi Yapan Doktor
    /// </summary>
        public ResUser ProgressUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROGRESSUSER"); }
            set { this["PROGRESSUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// BT Sonucu
    /// </summary>
        public SKRSBtCekimDurumu CTResult
        {
            get { return (SKRSBtCekimDurumu)((ITTObject)this).GetParent("CTRESULT"); }
            set { this["CTRESULT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Genel Durum
    /// </summary>
        public SKRSGenelDurum GeneralStatus
        {
            get { return (SKRSGenelDurum)((ITTObject)this).GetParent("GENERALSTATUS"); }
            set { this["GENERALSTATUS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OzellikliIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OzellikliIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OzellikliIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OzellikliIzlemVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OzellikliIzlemVeriSeti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OZELLIKLIIZLEMVERISETI", dataRow) { }
        protected OzellikliIzlemVeriSeti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OZELLIKLIIZLEMVERISETI", dataRow, isImported) { }
        public OzellikliIzlemVeriSeti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OzellikliIzlemVeriSeti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OzellikliIzlemVeriSeti() : base() { }

    }
}