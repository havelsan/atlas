
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BulasiciHastalikTelefon")] 

    public  partial class BulasiciHastalikTelefon : TTObject
    {
        public class BulasiciHastalikTelefonList : TTObjectCollection<BulasiciHastalikTelefon> { }
                    
        public class ChildBulasiciHastalikTelefonCollection : TTObject.TTChildObjectCollection<BulasiciHastalikTelefon>
        {
            public ChildBulasiciHastalikTelefonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBulasiciHastalikTelefonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTelNumberByEA_Class : TTReportNqlObject 
        {
            public string Telefontipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELEFONTIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTELEFONTIPI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Telno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BULASICIHASTALIKTELEFON"].AllPropertyDefs["TELEFONNUMARASI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTelNumberByEA_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTelNumberByEA_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTelNumberByEA_Class() : base() { }
        }

        public static BindingList<BulasiciHastalikTelefon.GetTelNumberByEA_Class> GetTelNumberByEA(Guid EPISODEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BULASICIHASTALIKTELEFON"].QueryDefs["GetTelNumberByEA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return TTReportNqlObject.QueryObjects<BulasiciHastalikTelefon.GetTelNumberByEA_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BulasiciHastalikTelefon.GetTelNumberByEA_Class> GetTelNumberByEA(TTObjectContext objectContext, Guid EPISODEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BULASICIHASTALIKTELEFON"].QueryDefs["GetTelNumberByEA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return TTReportNqlObject.QueryObjects<BulasiciHastalikTelefon.GetTelNumberByEA_Class>(objectContext, queryDef, paramList, pi);
        }

        public string TelefonNumarasi
        {
            get { return (string)this["TELEFONNUMARASI"]; }
            set { this["TELEFONNUMARASI"] = value; }
        }

        public SKRSTelefonTipi SKRSTelefonTipi
        {
            get { return (SKRSTelefonTipi)((ITTObject)this).GetParent("SKRSTELEFONTIPI"); }
            set { this["SKRSTELEFONTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BulasiciHastalikVeriSeti BulasiciHastalikVeriSeti
        {
            get { return (BulasiciHastalikVeriSeti)((ITTObject)this).GetParent("BULASICIHASTALIKVERISETI"); }
            set { this["BULASICIHASTALIKVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BulasiciHastalikTelefon(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BulasiciHastalikTelefon(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BulasiciHastalikTelefon(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BulasiciHastalikTelefon(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BulasiciHastalikTelefon(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BULASICIHASTALIKTELEFON", dataRow) { }
        protected BulasiciHastalikTelefon(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BULASICIHASTALIKTELEFON", dataRow, isImported) { }
        public BulasiciHastalikTelefon(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BulasiciHastalikTelefon(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BulasiciHastalikTelefon() : base() { }

    }
}