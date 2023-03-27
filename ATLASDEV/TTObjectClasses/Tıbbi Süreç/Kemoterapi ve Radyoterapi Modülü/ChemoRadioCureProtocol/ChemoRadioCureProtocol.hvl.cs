
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChemoRadioCureProtocol")] 

    /// <summary>
    /// Kemoterapi - Radyoterapi Tedavi Protokolü için kullanılan ana nesnedir.
    /// </summary>
    public  partial class ChemoRadioCureProtocol : PlannedAction
    {
        public class ChemoRadioCureProtocolList : TTObjectCollection<ChemoRadioCureProtocol> { }
                    
        public class ChildChemoRadioCureProtocolCollection : TTObject.TTChildObjectCollection<ChemoRadioCureProtocol>
        {
            public ChildChemoRadioCureProtocolCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChemoRadioCureProtocolCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("5e013726-1d8c-4647-a343-b0ab6bdb0ce6"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("abed58ec-51ec-41b5-9be5-51db2c9e42af"); } }
    /// <summary>
    /// Durduruldu
    /// </summary>
            public static Guid Aborted { get { return new Guid("46584ff8-539e-4049-a98a-2eaf9ee941a0"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("55cd7181-3ec1-4a5c-9758-6abc5ecc228a"); } }
        }

    /// <summary>
    /// Kür Sayısı
    /// </summary>
        public int? CureCount
        {
            get { return (int?)this["CURECOUNT"]; }
            set { this["CURECOUNT"] = value; }
        }

    /// <summary>
    /// Tekrar Gün Sayısı
    /// </summary>
        public int? RepetitiveDayCount
        {
            get { return (int?)this["REPETITIVEDAYCOUNT"]; }
            set { this["REPETITIVEDAYCOUNT"] = value; }
        }

    /// <summary>
    /// Tedavi Öncesi Süre
    /// </summary>
        public int? PreCureMinute
        {
            get { return (int?)this["PRECUREMINUTE"]; }
            set { this["PRECUREMINUTE"] = value; }
        }

    /// <summary>
    /// Tedavi Süresi
    /// </summary>
        public int? CureTime
        {
            get { return (int?)this["CURETIME"]; }
            set { this["CURETIME"] = value; }
        }

    /// <summary>
    /// Tedavi Sonrası Süre
    /// </summary>
        public int? AfterCureTime
        {
            get { return (int?)this["AFTERCURETIME"]; }
            set { this["AFTERCURETIME"] = value; }
        }

    /// <summary>
    /// İlaç Dozu
    /// </summary>
        public int? DrugDose
        {
            get { return (int?)this["DRUGDOSE"]; }
            set { this["DRUGDOSE"] = value; }
        }

    /// <summary>
    /// Çözücü Dozu
    /// </summary>
        public int? SolventDose
        {
            get { return (int?)this["SOLVENTDOSE"]; }
            set { this["SOLVENTDOSE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public object CureDescription
        {
            get { return (object)this["CUREDESCRIPTION"]; }
            set { this["CUREDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Radyoterapi Kemoterapi ayrımı için kullanılan değişken
    /// </summary>
        public bool? IsRadiotherapyCure
        {
            get { return (bool?)this["ISRADIOTHERAPYCURE"]; }
            set { this["ISRADIOTHERAPYCURE"] = value; }
        }

        public ChemotherapyRadiotherapy ChemotherapyRadiotherapy
        {
            get { return (ChemotherapyRadiotherapy)((ITTObject)this).GetParent("CHEMOTHERAPYRADIOTHERAPY"); }
            set { this["CHEMOTHERAPYRADIOTHERAPY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EtkinMadde EtkinMadde
        {
            get { return (EtkinMadde)((ITTObject)this).GetParent("ETKINMADDE"); }
            set { this["ETKINMADDE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RadiotherapyXRayTypeDef RadiotherapyXRayTypeDef
        {
            get { return (RadiotherapyXRayTypeDef)((ITTObject)this).GetParent("RADIOTHERAPYXRAYTYPEDEF"); }
            set { this["RADIOTHERAPYXRAYTYPEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ChemotherapyApplyMethod ChemotherapyApplyMethod
        {
            get { return (ChemotherapyApplyMethod)((ITTObject)this).GetParent("CHEMOTHERAPYAPPLYMETHOD"); }
            set { this["CHEMOTHERAPYAPPLYMETHOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ChemotherapyApplySubMethod ChemotherapyApplySubMethod
        {
            get { return (ChemotherapyApplySubMethod)((ITTObject)this).GetParent("CHEMOTHERAPYAPPLYSUBMETHOD"); }
            set { this["CHEMOTHERAPYAPPLYSUBMETHOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Solvent
        {
            get { return (Material)((ITTObject)this).GetParent("SOLVENT"); }
            set { this["SOLVENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateChemoRadioCureProtocolDetCollection()
        {
            _ChemoRadioCureProtocolDet = new ChemoRadioCureProtocolDet.ChildChemoRadioCureProtocolDetCollection(this, new Guid("a9c1f961-ef85-4b26-a5e2-ddc2cf885ea7"));
            ((ITTChildObjectCollection)_ChemoRadioCureProtocolDet).GetChildren();
        }

        protected ChemoRadioCureProtocolDet.ChildChemoRadioCureProtocolDetCollection _ChemoRadioCureProtocolDet = null;
        public ChemoRadioCureProtocolDet.ChildChemoRadioCureProtocolDetCollection ChemoRadioCureProtocolDet
        {
            get
            {
                if (_ChemoRadioCureProtocolDet == null)
                    CreateChemoRadioCureProtocolDetCollection();
                return _ChemoRadioCureProtocolDet;
            }
        }

        protected ChemoRadioCureProtocol(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChemoRadioCureProtocol(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChemoRadioCureProtocol(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChemoRadioCureProtocol(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChemoRadioCureProtocol(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHEMORADIOCUREPROTOCOL", dataRow) { }
        protected ChemoRadioCureProtocol(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHEMORADIOCUREPROTOCOL", dataRow, isImported) { }
        public ChemoRadioCureProtocol(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChemoRadioCureProtocol(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChemoRadioCureProtocol() : base() { }

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