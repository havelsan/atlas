
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TransferFromPackage")] 

    /// <summary>
    /// Paket Dışına Hizmet/Malzeme Aktarma
    /// </summary>
    public  partial class TransferFromPackage : EpisodeAccountAction
    {
        public class TransferFromPackageList : TTObjectCollection<TransferFromPackage> { }
                    
        public class ChildTransferFromPackageCollection : TTObject.TTChildObjectCollection<TransferFromPackage>
        {
            public ChildTransferFromPackageCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTransferFromPackageCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("9a8afdba-4dbc-40c7-81c1-c56a15164af8"); } }
            public static Guid New { get { return new Guid("c4c58ca3-2c2e-4bb9-89c6-fbe672a0b901"); } }
        }

    /// <summary>
    /// Paket dışında bırakma nedeni
    /// </summary>
        public PackageOutReasonEnum? PackageOutReason
        {
            get { return (PackageOutReasonEnum?)(int?)this["PACKAGEOUTREASON"]; }
            set { this["PACKAGEOUTREASON"] = value; }
        }

    /// <summary>
    /// Filtreleme Tipi
    /// </summary>
        public bool? FilterType
        {
            get { return (bool?)this["FILTERTYPE"]; }
            set { this["FILTERTYPE"] = value; }
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
    /// Filtreleme Bitiş Tarihi
    /// </summary>
        public DateTime? FilterEndDate
        {
            get { return (DateTime?)this["FILTERENDDATE"]; }
            set { this["FILTERENDDATE"] = value; }
        }

    /// <summary>
    /// Anlaşma ile ilişki
    /// </summary>
        public ProtocolDefinition Protocol
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOL"); }
            set { this["PROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum ile ilişki
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
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

        virtual protected void CreateTransferFromPackSubActPacsCollection()
        {
            _TransferFromPackSubActPacs = new TransferFromPackSubActPacs.ChildTransferFromPackSubActPacsCollection(this, new Guid("3851dcc8-8d6f-42b0-a779-3bdb7f8fb0b7"));
            ((ITTChildObjectCollection)_TransferFromPackSubActPacs).GetChildren();
        }

        protected TransferFromPackSubActPacs.ChildTransferFromPackSubActPacsCollection _TransferFromPackSubActPacs = null;
    /// <summary>
    /// Child collection for Paket Dışına Hizmet/Malzeme Aktarma ile ilişki
    /// </summary>
        public TransferFromPackSubActPacs.ChildTransferFromPackSubActPacsCollection TransferFromPackSubActPacs
        {
            get
            {
                if (_TransferFromPackSubActPacs == null)
                    CreateTransferFromPackSubActPacsCollection();
                return _TransferFromPackSubActPacs;
            }
        }

        virtual protected void CreateTransferFromPackSubActMatsCollection()
        {
            _TransferFromPackSubActMats = new TransferFromPackSubActMats.ChildTransferFromPackSubActMatsCollection(this, new Guid("4b45ea87-6cd5-4499-8bfb-5d8154904ad8"));
            ((ITTChildObjectCollection)_TransferFromPackSubActMats).GetChildren();
        }

        protected TransferFromPackSubActMats.ChildTransferFromPackSubActMatsCollection _TransferFromPackSubActMats = null;
        public TransferFromPackSubActMats.ChildTransferFromPackSubActMatsCollection TransferFromPackSubActMats
        {
            get
            {
                if (_TransferFromPackSubActMats == null)
                    CreateTransferFromPackSubActMatsCollection();
                return _TransferFromPackSubActMats;
            }
        }

        virtual protected void CreateTransferFromPackSubActProcsCollection()
        {
            _TransferFromPackSubActProcs = new TransferFromPackSubActProcs.ChildTransferFromPackSubActProcsCollection(this, new Guid("b08f0719-9f49-4c00-a321-f7a6b6ae9816"));
            ((ITTChildObjectCollection)_TransferFromPackSubActProcs).GetChildren();
        }

        protected TransferFromPackSubActProcs.ChildTransferFromPackSubActProcsCollection _TransferFromPackSubActProcs = null;
    /// <summary>
    /// Child collection for Paket Dışına Hizmet/Malzeme Aktarma ile ilişki
    /// </summary>
        public TransferFromPackSubActProcs.ChildTransferFromPackSubActProcsCollection TransferFromPackSubActProcs
        {
            get
            {
                if (_TransferFromPackSubActProcs == null)
                    CreateTransferFromPackSubActProcsCollection();
                return _TransferFromPackSubActProcs;
            }
        }

        protected TransferFromPackage(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TransferFromPackage(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TransferFromPackage(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TransferFromPackage(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TransferFromPackage(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TRANSFERFROMPACKAGE", dataRow) { }
        protected TransferFromPackage(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TRANSFERFROMPACKAGE", dataRow, isImported) { }
        public TransferFromPackage(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TransferFromPackage(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TransferFromPackage() : base() { }

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