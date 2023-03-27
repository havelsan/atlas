
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PPDAccountancyAmount")] 

    /// <summary>
    /// Mahalli Satınalmadaki Her Kalem İçin, O Kalemin Saymanlıktaki Mevcut Bilgilerini Tutan Sınıftır
    /// </summary>
    public  partial class PPDAccountancyAmount : LBAccountancyAmount
    {
        public class PPDAccountancyAmountList : TTObjectCollection<PPDAccountancyAmount> { }
                    
        public class ChildPPDAccountancyAmountCollection : TTObject.TTChildObjectCollection<PPDAccountancyAmount>
        {
            public ChildPPDAccountancyAmountCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPPDAccountancyAmountCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("d8117b22-bf1b-4263-8cfa-fc98ebaba87d"); } }
    /// <summary>
    /// Beklemede
    /// </summary>
            public static Guid Waiting { get { return new Guid("fa82cfb8-626d-40c5-b129-ea677d4a821a"); } }
    /// <summary>
    /// Cvp Döndü
    /// </summary>
            public static Guid Returned { get { return new Guid("cede3e43-e4fa-45e8-ab2b-ff9e35ce8768"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("140f02f7-5855-4e89-9963-b4c6d2cc6ec8"); } }
        }

        public PurchaseProjectDetail PurchaseProjectDetail
        {
            get { return (PurchaseProjectDetail)((ITTObject)this).GetParent("PURCHASEPROJECTDETAIL"); }
            set { this["PURCHASEPROJECTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PPDAccountancyAmount(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PPDAccountancyAmount(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PPDAccountancyAmount(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PPDAccountancyAmount(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PPDAccountancyAmount(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PPDACCOUNTANCYAMOUNT", dataRow) { }
        protected PPDAccountancyAmount(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PPDACCOUNTANCYAMOUNT", dataRow, isImported) { }
        public PPDAccountancyAmount(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PPDAccountancyAmount(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PPDAccountancyAmount() : base() { }

    }
}