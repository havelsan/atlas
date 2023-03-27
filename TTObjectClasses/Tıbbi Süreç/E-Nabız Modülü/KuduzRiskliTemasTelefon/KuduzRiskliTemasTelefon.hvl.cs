
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KuduzRiskliTemasTelefon")] 

    /// <summary>
    /// Kuduz Riskli Temas Veri Seti Telefon Bilgisi
    /// </summary>
    public  partial class KuduzRiskliTemasTelefon : TTObject
    {
        public class KuduzRiskliTemasTelefonList : TTObjectCollection<KuduzRiskliTemasTelefon> { }
                    
        public class ChildKuduzRiskliTemasTelefonCollection : TTObject.TTChildObjectCollection<KuduzRiskliTemasTelefon>
        {
            public ChildKuduzRiskliTemasTelefonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKuduzRiskliTemasTelefonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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

        public KuduzRiskliTemasVeriSeti KuduzRiskliTemasVeriSeti
        {
            get { return (KuduzRiskliTemasVeriSeti)((ITTObject)this).GetParent("KUDUZRISKLITEMASVERISETI"); }
            set { this["KUDUZRISKLITEMASVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KuduzRiskliTemasTelefon(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KuduzRiskliTemasTelefon(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KuduzRiskliTemasTelefon(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KuduzRiskliTemasTelefon(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KuduzRiskliTemasTelefon(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KUDUZRISKLITEMASTELEFON", dataRow) { }
        protected KuduzRiskliTemasTelefon(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KUDUZRISKLITEMASTELEFON", dataRow, isImported) { }
        public KuduzRiskliTemasTelefon(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KuduzRiskliTemasTelefon(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KuduzRiskliTemasTelefon() : base() { }

    }
}