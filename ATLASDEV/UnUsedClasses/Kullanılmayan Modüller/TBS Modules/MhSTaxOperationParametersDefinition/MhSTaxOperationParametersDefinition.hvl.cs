
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSTaxOperationParametersDefinition")] 

    /// <summary>
    /// Vergi İşlemleri Parametre Tanımlama
    /// </summary>
    public  partial class MhSTaxOperationParametersDefinition : TTDefinitionSet
    {
        public class MhSTaxOperationParametersDefinitionList : TTObjectCollection<MhSTaxOperationParametersDefinition> { }
                    
        public class ChildMhSTaxOperationParametersDefinitionCollection : TTObject.TTChildObjectCollection<MhSTaxOperationParametersDefinition>
        {
            public ChildMhSTaxOperationParametersDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSTaxOperationParametersDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Gelir Vergisi Hesabı
    /// </summary>
        public MhSAccount IncomeTaxAccount
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("INCOMETAXACCOUNT"); }
            set { this["INCOMETAXACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Karar Pulu İşlem Türü
    /// </summary>
        public MhSDecisionStampOperationTypeDefinition DecisionStampType
        {
            get { return (MhSDecisionStampOperationTypeDefinition)((ITTObject)this).GetParent("DECISIONSTAMPTYPE"); }
            set { this["DECISIONSTAMPTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Karar Pulu Hesabı
    /// </summary>
        public MhSAccount DecisionStampAccount
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("DECISIONSTAMPACCOUNT"); }
            set { this["DECISIONSTAMPACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ödeme Fişi Borçlu Hesap
    /// </summary>
        public MhSAccount PaymentSlipDebitAccount
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("PAYMENTSLIPDEBITACCOUNT"); }
            set { this["PAYMENTSLIPDEBITACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Damga Vergisi Hesabı
    /// </summary>
        public MhSAccount StampTaxAccount
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("STAMPTAXACCOUNT"); }
            set { this["STAMPTAXACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSTaxOperationParametersDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSTaxOperationParametersDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSTaxOperationParametersDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSTaxOperationParametersDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSTaxOperationParametersDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSTAXOPERATIONPARAMETERSDEFINITION", dataRow) { }
        protected MhSTaxOperationParametersDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSTAXOPERATIONPARAMETERSDEFINITION", dataRow, isImported) { }
        public MhSTaxOperationParametersDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSTaxOperationParametersDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSTaxOperationParametersDefinition() : base() { }

    }
}