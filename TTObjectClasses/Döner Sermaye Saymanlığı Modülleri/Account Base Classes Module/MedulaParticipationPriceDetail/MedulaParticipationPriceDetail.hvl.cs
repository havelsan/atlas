
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaParticipationPriceDetail")] 

    /// <summary>
    /// Medula Katılım Payı Ücreti Detay
    /// </summary>
    public  partial class MedulaParticipationPriceDetail : TTObject
    {
        public class MedulaParticipationPriceDetailList : TTObjectCollection<MedulaParticipationPriceDetail> { }
                    
        public class ChildMedulaParticipationPriceDetailCollection : TTObject.TTChildObjectCollection<MedulaParticipationPriceDetail>
        {
            public ChildMedulaParticipationPriceDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaParticipationPriceDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Medula Takip No
    /// </summary>
        public string ProvisionNo
        {
            get { return (string)this["PROVISIONNO"]; }
            set { this["PROVISIONNO"] = value; }
        }

    /// <summary>
    /// Muayene Katılım Payı Tutarı
    /// </summary>
        public double? ExaminationPrice
        {
            get { return (double?)this["EXAMINATIONPRICE"]; }
            set { this["EXAMINATIONPRICE"] = value; }
        }

    /// <summary>
    /// Malzeme Katılım Payı Tutarı
    /// </summary>
        public double? MaterialPrice
        {
            get { return (double?)this["MATERIALPRICE"]; }
            set { this["MATERIALPRICE"] = value; }
        }

    /// <summary>
    /// Tüp Bebek Katılım Payı Tutarı
    /// </summary>
        public double? TubeBabyPrice
        {
            get { return (double?)this["TUBEBABYPRICE"]; }
            set { this["TUBEBABYPRICE"] = value; }
        }

    /// <summary>
    /// Medula Katılım Payı Ücreti
    /// </summary>
        public MedulaParticipationPrice MedulaParticipationPrice
        {
            get { return (MedulaParticipationPrice)((ITTObject)this).GetParent("MEDULAPARTICIPATIONPRICE"); }
            set { this["MEDULAPARTICIPATIONPRICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaParticipationPriceDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaParticipationPriceDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaParticipationPriceDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaParticipationPriceDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaParticipationPriceDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAPARTICIPATIONPRICEDETAIL", dataRow) { }
        protected MedulaParticipationPriceDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAPARTICIPATIONPRICEDETAIL", dataRow, isImported) { }
        public MedulaParticipationPriceDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaParticipationPriceDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaParticipationPriceDetail() : base() { }

    }
}