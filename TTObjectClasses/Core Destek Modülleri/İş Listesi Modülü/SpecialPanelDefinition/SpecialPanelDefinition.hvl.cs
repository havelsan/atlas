
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SpecialPanelDefinition")] 

    /// <summary>
    /// Özel Panel Tanımı
    /// </summary>
    public  partial class SpecialPanelDefinition : TTDefinitionSet
    {
        public class SpecialPanelDefinitionList : TTObjectCollection<SpecialPanelDefinition> { }
                    
        public class ChildSpecialPanelDefinitionCollection : TTObject.TTChildObjectCollection<SpecialPanelDefinition>
        {
            public ChildSpecialPanelDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSpecialPanelDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<SpecialPanelDefinition> GetByUserAndWorkListDef(TTObjectContext objectContext, string USER, string WORKLISTDEF)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALPANELDEFINITION"].QueryDefs["GetByUserAndWorkListDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);
            paramList.Add("WORKLISTDEF", WORKLISTDEF);

            return ((ITTQuery)objectContext).QueryObjects<SpecialPanelDefinition>(queryDef, paramList);
        }

        public string Caption
        {
            get { return (string)this["CAPTION"]; }
            set { this["CAPTION"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public WorkListDefinition WorkListDefinition
        {
            get { return (WorkListDefinition)((ITTObject)this).GetParent("WORKLISTDEFINITION"); }
            set { this["WORKLISTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser User
        {
            get { return (ResUser)((ITTObject)this).GetParent("USER"); }
            set { this["USER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCriteriaValuesCollection()
        {
            _CriteriaValues = new SpecialPanelCriteriaValue.ChildSpecialPanelCriteriaValueCollection(this, new Guid("d31cc419-0c5c-4636-bba5-4ac7b6b7e143"));
            ((ITTChildObjectCollection)_CriteriaValues).GetChildren();
        }

        protected SpecialPanelCriteriaValue.ChildSpecialPanelCriteriaValueCollection _CriteriaValues = null;
        public SpecialPanelCriteriaValue.ChildSpecialPanelCriteriaValueCollection CriteriaValues
        {
            get
            {
                if (_CriteriaValues == null)
                    CreateCriteriaValuesCollection();
                return _CriteriaValues;
            }
        }

        protected SpecialPanelDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SpecialPanelDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SpecialPanelDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SpecialPanelDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SpecialPanelDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SPECIALPANELDEFINITION", dataRow) { }
        protected SpecialPanelDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SPECIALPANELDEFINITION", dataRow, isImported) { }
        public SpecialPanelDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SpecialPanelDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SpecialPanelDefinition() : base() { }

    }
}