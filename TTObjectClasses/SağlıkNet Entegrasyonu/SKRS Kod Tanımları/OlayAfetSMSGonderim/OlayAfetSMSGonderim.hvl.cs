
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OlayAfetSMSGonderim")] 

    /// <summary>
    /// Olay Afet Bildirimi güncellenirken tanımlanan ildeki afetin sms olarak gönderilmesi
    /// </summary>
    public  partial class OlayAfetSMSGonderim : TerminologyManagerDef
    {
        public class OlayAfetSMSGonderimList : TTObjectCollection<OlayAfetSMSGonderim> { }
                    
        public class ChildOlayAfetSMSGonderimCollection : TTObject.TTChildObjectCollection<OlayAfetSMSGonderim>
        {
            public ChildOlayAfetSMSGonderimCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOlayAfetSMSGonderimCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOlayAfetSMSGonderim_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Cityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILKODLARI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PhoneNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OLAYAFETSMSGONDERIM"].AllPropertyDefs["PHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOlayAfetSMSGonderim_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOlayAfetSMSGonderim_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOlayAfetSMSGonderim_Class() : base() { }
        }

        public static BindingList<OlayAfetSMSGonderim.GetOlayAfetSMSGonderim_Class> GetOlayAfetSMSGonderim(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAYAFETSMSGONDERIM"].QueryDefs["GetOlayAfetSMSGonderim"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OlayAfetSMSGonderim.GetOlayAfetSMSGonderim_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OlayAfetSMSGonderim.GetOlayAfetSMSGonderim_Class> GetOlayAfetSMSGonderim(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OLAYAFETSMSGONDERIM"].QueryDefs["GetOlayAfetSMSGonderim"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OlayAfetSMSGonderim.GetOlayAfetSMSGonderim_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Telefon Numarası
    /// </summary>
        public string PhoneNumber
        {
            get { return (string)this["PHONENUMBER"]; }
            set { this["PHONENUMBER"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSILKodlari SKRSILKodlari
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("SKRSILKODLARI"); }
            set { this["SKRSILKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OlayAfetSMSGonderim(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OlayAfetSMSGonderim(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OlayAfetSMSGonderim(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OlayAfetSMSGonderim(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OlayAfetSMSGonderim(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OLAYAFETSMSGONDERIM", dataRow) { }
        protected OlayAfetSMSGonderim(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OLAYAFETSMSGONDERIM", dataRow, isImported) { }
        public OlayAfetSMSGonderim(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OlayAfetSMSGonderim(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OlayAfetSMSGonderim() : base() { }

    }
}