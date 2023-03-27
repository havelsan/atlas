
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralPreparationDefinition")] 

    /// <summary>
    /// Majistral İlaç Tanımı
    /// </summary>
    public  partial class MagistralPreparationDefinition : DrugDefinition
    {
        public class MagistralPreparationDefinitionList : TTObjectCollection<MagistralPreparationDefinition> { }
                    
        public class ChildMagistralPreparationDefinitionCollection : TTObject.TTChildObjectCollection<MagistralPreparationDefinition>
        {
            public ChildMagistralPreparationDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralPreparationDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMagistralPreparation_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALPREPARATIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALPREPARATIONDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OriginalName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORIGINALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALPREPARATIONDEFINITION"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialtreename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTREENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stockcardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALPREPARATIONDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetMagistralPreparation_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMagistralPreparation_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMagistralPreparation_Class() : base() { }
        }

        public static BindingList<MagistralPreparationDefinition.GetMagistralPreparation_Class> GetMagistralPreparation(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALPREPARATIONDEFINITION"].QueryDefs["GetMagistralPreparation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MagistralPreparationDefinition.GetMagistralPreparation_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MagistralPreparationDefinition.GetMagistralPreparation_Class> GetMagistralPreparation(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALPREPARATIONDEFINITION"].QueryDefs["GetMagistralPreparation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MagistralPreparationDefinition.GetMagistralPreparation_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Eczacılık Birimleri Tarafından Üretilir
    /// </summary>
        public bool? Pharmacology
        {
            get { return (bool?)this["PHARMACOLOGY"]; }
            set { this["PHARMACOLOGY"] = value; }
        }

        public MagistralPackagingType MagistralPackagingType
        {
            get { return (MagistralPackagingType)((ITTObject)this).GetParent("MAGISTRALPACKAGINGTYPE"); }
            set { this["MAGISTRALPACKAGINGTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MagistralPackagingSubType MagistralPackagingSubType
        {
            get { return (MagistralPackagingSubType)((ITTObject)this).GetParent("MAGISTRALPACKAGINGSUBTYPE"); }
            set { this["MAGISTRALPACKAGINGSUBTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MagistralPreparationType MagistralPreparationType
        {
            get { return (MagistralPreparationType)((ITTObject)this).GetParent("MAGISTRALPREPARATIONTYPE"); }
            set { this["MAGISTRALPREPARATIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MagistralPreparationSubType MagistralPreparationSubType
        {
            get { return (MagistralPreparationSubType)((ITTObject)this).GetParent("MAGISTRALPREPARATIONSUBTYPE"); }
            set { this["MAGISTRALPREPARATIONSUBTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMagistralDefUsedDrugsCollection()
        {
            _MagistralDefUsedDrugs = new MagistralDefUsedDrug.ChildMagistralDefUsedDrugCollection(this, new Guid("da22c60d-b8a5-44f9-8766-3ee54e4e7cf6"));
            ((ITTChildObjectCollection)_MagistralDefUsedDrugs).GetChildren();
        }

        protected MagistralDefUsedDrug.ChildMagistralDefUsedDrugCollection _MagistralDefUsedDrugs = null;
        public MagistralDefUsedDrug.ChildMagistralDefUsedDrugCollection MagistralDefUsedDrugs
        {
            get
            {
                if (_MagistralDefUsedDrugs == null)
                    CreateMagistralDefUsedDrugsCollection();
                return _MagistralDefUsedDrugs;
            }
        }

        virtual protected void CreateMagistralDefUsedChemicalsCollection()
        {
            _MagistralDefUsedChemicals = new MagistralDefUsedChemical.ChildMagistralDefUsedChemicalCollection(this, new Guid("181aca30-4139-42aa-b233-0ac3ebd397f7"));
            ((ITTChildObjectCollection)_MagistralDefUsedChemicals).GetChildren();
        }

        protected MagistralDefUsedChemical.ChildMagistralDefUsedChemicalCollection _MagistralDefUsedChemicals = null;
        public MagistralDefUsedChemical.ChildMagistralDefUsedChemicalCollection MagistralDefUsedChemicals
        {
            get
            {
                if (_MagistralDefUsedChemicals == null)
                    CreateMagistralDefUsedChemicalsCollection();
                return _MagistralDefUsedChemicals;
            }
        }

        virtual protected void CreateMagistralDefUsedConsMatsCollection()
        {
            _MagistralDefUsedConsMats = new MagistralDefUsedConsMat.ChildMagistralDefUsedConsMatCollection(this, new Guid("651da2b2-a408-4699-b145-6c4e2082302b"));
            ((ITTChildObjectCollection)_MagistralDefUsedConsMats).GetChildren();
        }

        protected MagistralDefUsedConsMat.ChildMagistralDefUsedConsMatCollection _MagistralDefUsedConsMats = null;
        public MagistralDefUsedConsMat.ChildMagistralDefUsedConsMatCollection MagistralDefUsedConsMats
        {
            get
            {
                if (_MagistralDefUsedConsMats == null)
                    CreateMagistralDefUsedConsMatsCollection();
                return _MagistralDefUsedConsMats;
            }
        }

        protected MagistralPreparationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralPreparationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralPreparationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralPreparationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralPreparationDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALPREPARATIONDEFINITION", dataRow) { }
        protected MagistralPreparationDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALPREPARATIONDEFINITION", dataRow, isImported) { }
        public MagistralPreparationDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralPreparationDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralPreparationDefinition() : base() { }

    }
}