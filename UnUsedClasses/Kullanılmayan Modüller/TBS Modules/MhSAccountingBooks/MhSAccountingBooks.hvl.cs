
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSAccountingBooks")] 

    /// <summary>
    /// Muhasebe Defterleri
    /// </summary>
    public  partial class MhSAccountingBooks : TTObject
    {
        public class MhSAccountingBooksList : TTObjectCollection<MhSAccountingBooks> { }
                    
        public class ChildMhSAccountingBooksCollection : TTObject.TTChildObjectCollection<MhSAccountingBooks>
        {
            public ChildMhSAccountingBooksCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSAccountingBooksCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sıralama
    /// </summary>
        public MhSAccountTypes? Order
        {
            get { return (MhSAccountTypes?)(int?)this["ORDER"]; }
            set { this["ORDER"] = value; }
        }

    /// <summary>
    /// Fiş No
    /// </summary>
        public int? SlipNo
        {
            get { return (int?)this["SLIPNO"]; }
            set { this["SLIPNO"] = value; }
        }

    /// <summary>
    /// Tür
    /// </summary>
        public MhSAccountTypes? Type
        {
            get { return (MhSAccountTypes?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// HesapSeviyesi
    /// </summary>
        public int? AccountDepth
        {
            get { return (int?)this["ACCOUNTDEPTH"]; }
            set { this["ACCOUNTDEPTH"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? FinishDate
        {
            get { return (DateTime?)this["FINISHDATE"]; }
            set { this["FINISHDATE"] = value; }
        }

    /// <summary>
    /// Onaylansın
    /// </summary>
        public bool? Approve
        {
            get { return (bool?)this["APPROVE"]; }
            set { this["APPROVE"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Başlangıç Hesap
    /// </summary>
        public MhSAccount StartAccount
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("STARTACCOUNT"); }
            set { this["STARTACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bitiş Hesabı
    /// </summary>
        public MhSAccount FinishAccount
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("FINISHACCOUNT"); }
            set { this["FINISHACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSAccountingBooks(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSAccountingBooks(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSAccountingBooks(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSAccountingBooks(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSAccountingBooks(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSACCOUNTINGBOOKS", dataRow) { }
        protected MhSAccountingBooks(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSACCOUNTINGBOOKS", dataRow, isImported) { }
        public MhSAccountingBooks(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSAccountingBooks(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSAccountingBooks() : base() { }

    }
}