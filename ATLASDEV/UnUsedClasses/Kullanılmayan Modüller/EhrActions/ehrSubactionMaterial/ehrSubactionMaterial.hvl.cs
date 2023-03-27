
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrSubactionMaterial")] 

    /// <summary>
    /// Sarf Malzeme
    /// </summary>
    public  partial class ehrSubactionMaterial : BaseEhr
    {
        public class ehrSubactionMaterialList : TTObjectCollection<ehrSubactionMaterial> { }
                    
        public class ChildehrSubactionMaterialCollection : TTObject.TTChildObjectCollection<ehrSubactionMaterial>
        {
            public ChildehrSubactionMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrSubactionMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Malzeme
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paket
    /// </summary>
        public PackageDefinition PackageObject
        {
            get { return (PackageDefinition)((ITTObject)this).GetParent("PACKAGEOBJECT"); }
            set { this["PACKAGEOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlem-Malzemeler
    /// </summary>
        public ehrEpisodeAction ehrEpisodeAction
        {
            get { return (ehrEpisodeAction)((ITTObject)this).GetParent("EHREPISODEACTION"); }
            set { this["EHREPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateehrAccountTransactionsCollection()
        {
            _ehrAccountTransactions = new ehrAccountTransaction.ChildehrAccountTransactionCollection(this, new Guid("7108d299-1bc9-4f0b-9d5d-6cb7269bcfe7"));
            ((ITTChildObjectCollection)_ehrAccountTransactions).GetChildren();
        }

        protected ehrAccountTransaction.ChildehrAccountTransactionCollection _ehrAccountTransactions = null;
        public ehrAccountTransaction.ChildehrAccountTransactionCollection ehrAccountTransactions
        {
            get
            {
                if (_ehrAccountTransactions == null)
                    CreateehrAccountTransactionsCollection();
                return _ehrAccountTransactions;
            }
        }

        protected ehrSubactionMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrSubactionMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrSubactionMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrSubactionMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrSubactionMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRSUBACTIONMATERIAL", dataRow) { }
        protected ehrSubactionMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRSUBACTIONMATERIAL", dataRow, isImported) { }
        public ehrSubactionMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrSubactionMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrSubactionMaterial() : base() { }

    }
}