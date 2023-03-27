
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Kaynak Tipi Tanımı
    /// </summary>
    public partial class ResourceTypeTreeForm : TTForm
    {
        override protected void BindControlEvents()
        {
            ParentObjectDefName.SelectedIndexChanged += new TTControlEventDelegate(ParentObjectDefName_SelectedIndexChanged);
            RelationDefComboBox.SelectedIndexChanged += new TTControlEventDelegate(RelationDefComboBox_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ParentObjectDefName.SelectedIndexChanged -= new TTControlEventDelegate(ParentObjectDefName_SelectedIndexChanged);
            RelationDefComboBox.SelectedIndexChanged -= new TTControlEventDelegate(RelationDefComboBox_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void ParentObjectDefName_SelectedIndexChanged()
        {
#region ResourceTypeTreeForm_ParentObjectDefName_SelectedIndexChanged
   TTObjectDef objectDef = ParentObjectDefName.SelectedItem.Value as TTObjectDef;
            if(objectDef != null)
            {
                foreach(TTObjectRelationDef objectRelationDef in objectDef.ChildRelationDefs)
                {
                    RelationDefComboBox.Items.Add(new TTComboBoxItem(objectRelationDef.ToString(), objectRelationDef));
                }
            }
#endregion ResourceTypeTreeForm_ParentObjectDefName_SelectedIndexChanged
        }

        private void RelationDefComboBox_SelectedIndexChanged()
        {
#region ResourceTypeTreeForm_RelationDefComboBox_SelectedIndexChanged
   TTObjectRelationDef objectRelationDef = RelationDefComboBox.SelectedItem.Value as TTObjectRelationDef;
            if(objectRelationDef != null)
            {
                RelationDefID.Text = objectRelationDef.RelationDefID.ToString();
            }
#endregion ResourceTypeTreeForm_RelationDefComboBox_SelectedIndexChanged
        }

        protected override void PreScript()
        {
#region ResourceTypeTreeForm_PreScript
    base.PreScript();
            
            foreach(TTObjectDef objectDef in TTObjectDefManager.Instance.ObjectDefs)
            {
                ParentObjectDefName.Items.Add(new TTComboBoxItem(objectDef.Name, objectDef));
            }
#endregion ResourceTypeTreeForm_PreScript

            }
                }
}