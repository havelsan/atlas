
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSMilitaryPersonnel")] 

    /// <summary>
    /// XXXXXX Personel
    /// </summary>
    public  partial class MBSMilitaryPersonnel : MBSPersonnel
    {
        public class MBSMilitaryPersonnelList : TTObjectCollection<MBSMilitaryPersonnel> { }
                    
        public class ChildMBSMilitaryPersonnelCollection : TTObject.TTChildObjectCollection<MBSMilitaryPersonnel>
        {
            public ChildMBSMilitaryPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSMilitaryPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Rütbe
    /// </summary>
        public string Rank
        {
            get { return (string)this["RANK"]; }
            set { this["RANK"] = value; }
        }

    /// <summary>
    /// Oyak Sicil No
    /// </summary>
        public string OYAKRegistrationNo
        {
            get { return (string)this["OYAKREGISTRATIONNO"]; }
            set { this["OYAKREGISTRATIONNO"] = value; }
        }

    /// <summary>
    /// Nasıp Tarihi
    /// </summary>
        public DateTime? AdvancementDate
        {
            get { return (DateTime?)this["ADVANCEMENTDATE"]; }
            set { this["ADVANCEMENTDATE"] = value; }
        }

    /// <summary>
    /// Sınıf
    /// </summary>
        public string Class
        {
            get { return (string)this["CLASS"]; }
            set { this["CLASS"] = value; }
        }

    /// <summary>
    /// Kuvvet
    /// </summary>
        public string Vigour
        {
            get { return (string)this["VIGOUR"]; }
            set { this["VIGOUR"] = value; }
        }

    /// <summary>
    /// Yan ödeme kodu
    /// </summary>
        public string AuxiliaryPaymentCode
        {
            get { return (string)this["AUXILIARYPAYMENTCODE"]; }
            set { this["AUXILIARYPAYMENTCODE"] = value; }
        }

        protected MBSMilitaryPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSMilitaryPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSMilitaryPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSMilitaryPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSMilitaryPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSMILITARYPERSONNEL", dataRow) { }
        protected MBSMilitaryPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSMILITARYPERSONNEL", dataRow, isImported) { }
        public MBSMilitaryPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSMilitaryPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSMilitaryPersonnel() : base() { }

    }
}