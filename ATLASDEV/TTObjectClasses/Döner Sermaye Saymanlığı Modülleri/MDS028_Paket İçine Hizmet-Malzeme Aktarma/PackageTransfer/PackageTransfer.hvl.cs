
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageTransfer")] 

    /// <summary>
    /// Paket İçine Hizmet/Malzeme Aktarma
    /// </summary>
    public  partial class PackageTransfer : EpisodeAccountAction
    {
        public class PackageTransferList : TTObjectCollection<PackageTransfer> { }
                    
        public class ChildPackageTransferCollection : TTObject.TTChildObjectCollection<PackageTransfer>
        {
            public ChildPackageTransferCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageTransferCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("639c41ca-37f5-497c-8277-edebff321dbc"); } }
            public static Guid New { get { return new Guid("6bc93de6-c7d4-42ad-aadb-85aaa4e1aab5"); } }
        }

    /// <summary>
    /// Filtreleme Bitiş Tarihi
    /// </summary>
        public DateTime? FilterEndDate
        {
            get { return (DateTime?)this["FILTERENDDATE"]; }
            set { this["FILTERENDDATE"] = value; }
        }

    /// <summary>
    /// Filtreleme Başlangıç Tarihi
    /// </summary>
        public DateTime? FilterStartDate
        {
            get { return (DateTime?)this["FILTERSTARTDATE"]; }
            set { this["FILTERSTARTDATE"] = value; }
        }

    /// <summary>
    /// Hizmet hareketine ilişki
    /// </summary>
        public SubActionProcedure SubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("SUBACTIONPROCEDURE"); }
            set { this["SUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paket Tanımına ilişki
    /// </summary>
        public PackageDefinition PackageDefinition
        {
            get { return (PackageDefinition)((ITTObject)this).GetParent("PACKAGEDEFINITION"); }
            set { this["PACKAGEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet
    /// </summary>
        public ProcedureDefinition Procedure
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDURE"); }
            set { this["PROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İlaç/Malzeme
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePackageTransferProtocolDetailsCollection()
        {
            _PackageTransferProtocolDetails = new PackageTransferProtocolDetail.ChildPackageTransferProtocolDetailCollection(this, new Guid("1300754b-ab68-4cb4-9ed9-98142e77b32f"));
            ((ITTChildObjectCollection)_PackageTransferProtocolDetails).GetChildren();
        }

        protected PackageTransferProtocolDetail.ChildPackageTransferProtocolDetailCollection _PackageTransferProtocolDetails = null;
    /// <summary>
    /// Child collection for Paket İçine Hizmet/Malzeme Aktarma ile ilişki
    /// </summary>
        public PackageTransferProtocolDetail.ChildPackageTransferProtocolDetailCollection PackageTransferProtocolDetails
        {
            get
            {
                if (_PackageTransferProtocolDetails == null)
                    CreatePackageTransferProtocolDetailsCollection();
                return _PackageTransferProtocolDetails;
            }
        }

        virtual protected void CreatePackageTransferProtocolSubActionPackagesCollection()
        {
            _PackageTransferProtocolSubActionPackages = new PackageTransferProtocolSubActionPackages.ChildPackageTransferProtocolSubActionPackagesCollection(this, new Guid("fe4cdd78-abb0-4a39-a6af-dd66e62831f2"));
            ((ITTChildObjectCollection)_PackageTransferProtocolSubActionPackages).GetChildren();
        }

        protected PackageTransferProtocolSubActionPackages.ChildPackageTransferProtocolSubActionPackagesCollection _PackageTransferProtocolSubActionPackages = null;
    /// <summary>
    /// Child collection for Paket İçine Hizmet/Malzeme Aktarma ile ilişki
    /// </summary>
        public PackageTransferProtocolSubActionPackages.ChildPackageTransferProtocolSubActionPackagesCollection PackageTransferProtocolSubActionPackages
        {
            get
            {
                if (_PackageTransferProtocolSubActionPackages == null)
                    CreatePackageTransferProtocolSubActionPackagesCollection();
                return _PackageTransferProtocolSubActionPackages;
            }
        }

        virtual protected void CreatePackageTransferProtocolSubActionMaterialsCollection()
        {
            _PackageTransferProtocolSubActionMaterials = new PackageTransferProtocolSubActionMaterials.ChildPackageTransferProtocolSubActionMaterialsCollection(this, new Guid("c179362d-f507-4bd4-91b9-1f8b11e10c4d"));
            ((ITTChildObjectCollection)_PackageTransferProtocolSubActionMaterials).GetChildren();
        }

        protected PackageTransferProtocolSubActionMaterials.ChildPackageTransferProtocolSubActionMaterialsCollection _PackageTransferProtocolSubActionMaterials = null;
    /// <summary>
    /// Child collection for Paket İçine Hizmet/Malzeme Aktarma ile ilişki
    /// </summary>
        public PackageTransferProtocolSubActionMaterials.ChildPackageTransferProtocolSubActionMaterialsCollection PackageTransferProtocolSubActionMaterials
        {
            get
            {
                if (_PackageTransferProtocolSubActionMaterials == null)
                    CreatePackageTransferProtocolSubActionMaterialsCollection();
                return _PackageTransferProtocolSubActionMaterials;
            }
        }

        virtual protected void CreatePackageTransferProtocolSubActionProceduresCollection()
        {
            _PackageTransferProtocolSubActionProcedures = new PackageTransferProtocolSubActionProcedures.ChildPackageTransferProtocolSubActionProceduresCollection(this, new Guid("194c82f6-6d95-4f14-b7a8-92cc30fdc9ce"));
            ((ITTChildObjectCollection)_PackageTransferProtocolSubActionProcedures).GetChildren();
        }

        protected PackageTransferProtocolSubActionProcedures.ChildPackageTransferProtocolSubActionProceduresCollection _PackageTransferProtocolSubActionProcedures = null;
    /// <summary>
    /// Child collection for Paket İçine Hizmet/Malzeme Aktarma ile ilişki
    /// </summary>
        public PackageTransferProtocolSubActionProcedures.ChildPackageTransferProtocolSubActionProceduresCollection PackageTransferProtocolSubActionProcedures
        {
            get
            {
                if (_PackageTransferProtocolSubActionProcedures == null)
                    CreatePackageTransferProtocolSubActionProceduresCollection();
                return _PackageTransferProtocolSubActionProcedures;
            }
        }

        protected PackageTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageTransfer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGETRANSFER", dataRow) { }
        protected PackageTransfer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGETRANSFER", dataRow, isImported) { }
        public PackageTransfer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageTransfer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageTransfer() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}