
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdditionalAdress")] 

    /// <summary>
    /// Bildirim Adres Bilgisi
    /// </summary>
    public  partial class AdditionalAdress : TTObject
    {
        public class AdditionalAdressList : TTObjectCollection<AdditionalAdress> { }
                    
        public class ChildAdditionalAdressCollection : TTObject.TTChildObjectCollection<AdditionalAdress>
        {
            public ChildAdditionalAdressCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdditionalAdressCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAdditionalAdressForEnabiz_Class : TTReportNqlObject 
        {
            public string Skrsadrestipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKRSADRESTIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESTIPI"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Bucakkodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUCAKKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSBUCAKKODLARI"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CSBMKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CSBMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALADRESS"].AllPropertyDefs["CSBMKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DisKapi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISKAPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALADRESS"].AllPropertyDefs["DISKAPI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IcKapi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ICKAPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALADRESS"].AllPropertyDefs["ICKAPI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Skrsil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKRSIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILKODLARI"].AllPropertyDefs["KODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Skrsilce
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKRSILCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILCEKODLARI"].AllPropertyDefs["KODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Skrskoy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKRSKOY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKOYKODLARI"].AllPropertyDefs["KODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Skrskmahale
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKRSKMAHALE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMAHALLEKODLARI"].AllPropertyDefs["KODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetAdditionalAdressForEnabiz_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAdditionalAdressForEnabiz_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAdditionalAdressForEnabiz_Class() : base() { }
        }

        public static BindingList<AdditionalAdress> GetAdditionalAdressByPatient(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALADRESS"].QueryDefs["GetAdditionalAdressByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<AdditionalAdress>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<AdditionalAdress.GetAdditionalAdressForEnabiz_Class> GetAdditionalAdressForEnabiz(string PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALADRESS"].QueryDefs["GetAdditionalAdressForEnabiz"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<AdditionalAdress.GetAdditionalAdressForEnabiz_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AdditionalAdress.GetAdditionalAdressForEnabiz_Class> GetAdditionalAdressForEnabiz(TTObjectContext objectContext, string PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALADRESS"].QueryDefs["GetAdditionalAdressForEnabiz"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<AdditionalAdress.GetAdditionalAdressForEnabiz_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Dış Kapı No
    /// </summary>
        public string DisKapi
        {
            get { return (string)this["DISKAPI"]; }
            set { this["DISKAPI"] = value; }
        }

    /// <summary>
    /// İç Kapı No
    /// </summary>
        public string IcKapi
        {
            get { return (string)this["ICKAPI"]; }
            set { this["ICKAPI"] = value; }
        }

    /// <summary>
    /// CSBM Kodu
    /// </summary>
        public string CSBMKodu
        {
            get { return (string)this["CSBMKODU"]; }
            set { this["CSBMKODU"] = value; }
        }

        public PatientIdentityAndAddress Patient
        {
            get { return (PatientIdentityAndAddress)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSILKodlari SKRSIl
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("SKRSIL"); }
            set { this["SKRSIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIlceKodlari SKRSIlce
        {
            get { return (SKRSIlceKodlari)((ITTObject)this).GetParent("SKRSILCE"); }
            set { this["SKRSILCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSBucakKodlari SKRSBucakKodlari
        {
            get { return (SKRSBucakKodlari)((ITTObject)this).GetParent("SKRSBUCAKKODLARI"); }
            set { this["SKRSBUCAKKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSMahalleKodlari SKRSMahalleKodlari
        {
            get { return (SKRSMahalleKodlari)((ITTObject)this).GetParent("SKRSMAHALLEKODLARI"); }
            set { this["SKRSMAHALLEKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKoyKodlari SKRSKoyKodlari
        {
            get { return (SKRSKoyKodlari)((ITTObject)this).GetParent("SKRSKOYKODLARI"); }
            set { this["SKRSKOYKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSAdresTipi SKRSAdresTipi
        {
            get { return (SKRSAdresTipi)((ITTObject)this).GetParent("SKRSADRESTIPI"); }
            set { this["SKRSADRESTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AdditionalAdress(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdditionalAdress(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdditionalAdress(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdditionalAdress(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdditionalAdress(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADDITIONALADRESS", dataRow) { }
        protected AdditionalAdress(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADDITIONALADRESS", dataRow, isImported) { }
        public AdditionalAdress(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdditionalAdress(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdditionalAdress() : base() { }

    }
}