
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
    /// Fatura Engeli Tanımlama
    /// </summary>
    public partial class InvoiceBlockingDefinitionForm : TTDefinitionForm
    {
        private Guid EpisodeActionGuid = new Guid("a9754f35-2998-48c7-80f3-5194f9e678a7");
        private Guid SubActionProcedureGuid = new Guid("3972bb0d-0388-40c6-bf41-ed9781e9e829");

        override protected void BindControlEvents()
        {
            base.BindControlEvents();
            EAComboBox.SelectedIndexChanged += new TTControlEventDelegate(EAComboBox_SelectedIndexChange);
            SPComboBox.SelectedIndexChanged += new TTControlEventDelegate(SPComboBox_SelectedIndexChange);
            StateComboBox.SelectedIndexChanged += new TTControlEventDelegate(StateComboBox_SelectedIndexChange);
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
            EAComboBox.SelectedIndexChanged -= new TTControlEventDelegate(EAComboBox_SelectedIndexChange);
            SPComboBox.SelectedIndexChanged -= new TTControlEventDelegate(SPComboBox_SelectedIndexChange);
            StateComboBox.SelectedIndexChanged -= new TTControlEventDelegate(StateComboBox_SelectedIndexChange);
        }
        protected override void PreScript()
        {
            #region InvoiceBlockingDefinitionForm_PreScript
            base.PreScript();

            // EAComboBox ve SPComboBox boş ise doldurulur
            if (EAComboBox.Items.Count == 0 || SPComboBox.Items.Count == 0)
            {
                EAComboBox.Items.Clear();
                SPComboBox.Items.Clear();

                string objectDefNames = TTObjectClasses.SystemParameter.GetParameterValue("INVOICEBLOCKINGOBJECTDEFNAMES", "");
                objectDefNames = objectDefNames.Replace("\n", String.Empty);
                objectDefNames = objectDefNames.Replace("\r", String.Empty);
                objectDefNames = objectDefNames.Replace("\t", String.Empty);
                objectDefNames = objectDefNames.Trim().ToUpperInvariant();
                List<string> objectDefNameList = objectDefNames.Split(',').ToList();
                TTObjectDefBase tempObjDef;

                //foreach (TTObjectDef objDef in TTObjectDefManager.Instance.ObjectDefs.Values.Where(x => !string.IsNullOrEmpty(x.DisplayText)).OrderBy(x => x.DisplayText)) // Tüm Objeler
                foreach (TTObjectDef objDef in TTObjectDefManager.Instance.ObjectDefs.Values.Where(x => objectDefNameList.Contains(x.Name.ToUpperInvariant())).OrderBy(x => x.DisplayText)) 
                {
                    tempObjDef = objDef;

                    while (tempObjDef.BaseObjectDef != null)
                    {
                        if (tempObjDef.BaseObjectDefID.Equals(EpisodeActionGuid) || tempObjDef.BaseObjectDefID.Equals(SubActionProcedureGuid))
                        {
                            TTComboBoxItem item = new TTComboBoxItem(objDef.DisplayText + " [" + objDef.Name + "]", objDef); 

                            if (tempObjDef.BaseObjectDefID.Equals(EpisodeActionGuid))
                                EAComboBox.Items.Add(item);
                            else
                                SPComboBox.Items.Add(item);

                            break;
                        }
                        tempObjDef = tempObjDef.BaseObjectDef;
                    }
                }
            }

            // EAComboBox, SPComboBox ve StateComboBox ta seçilen kayda göre uygun item ları seçili item yapar
            EAComboBox.SelectedItem = null;
            SPComboBox.SelectedItem = null;
            StateComboBox.SelectedItem = null;
            StateComboBox.Items.Clear();

            if (_InvoiceBlockingDefinition.StateDefId.HasValue)
            {
                TTObjectStateDef stateDef = null;
                TTObjectDefManager.Instance.AllTTObjectStateDefs.TryGetValue(_InvoiceBlockingDefinition.StateDefId.Value, out stateDef);
                if(stateDef != null)
                {
                    EAComboBox.SelectedItem = EAComboBox.Items.FirstOrDefault(x => x.Value == stateDef.ObjectDef);
                    SPComboBox.SelectedItem = SPComboBox.Items.FirstOrDefault(x => x.Value == stateDef.ObjectDef);
                    StateComboBox.SelectedItem = StateComboBox.Items.FirstOrDefault(x => x.Value == stateDef); 
                }
            }
            #endregion InvoiceBlockingDefinitionForm_PreScript
        }

        private void EAComboBox_SelectedIndexChange()
        {
            StateComboBox.Items.Clear();

            if (EAComboBox.SelectedItem != null)
            {
                SPComboBox.SelectedItem = null;
                TTObjectDef objDef = EAComboBox.SelectedItem.Value as TTObjectDef;
                foreach (TTObjectStateDef stateDef in objDef.StateDefs.Values.OrderBy(x => x.DisplayText))
                {
                    TTComboBoxItem item = new TTComboBoxItem(stateDef.DisplayText + " [" + stateDef.Name + "]", stateDef);
                    StateComboBox.Items.Add(item);
                }
            }
        }

        private void SPComboBox_SelectedIndexChange()
        {
            StateComboBox.Items.Clear();

            if (SPComboBox.SelectedItem != null)
            {
                EAComboBox.SelectedItem = null;
                TTObjectDef objDef = SPComboBox.SelectedItem.Value as TTObjectDef;
                foreach (TTObjectStateDef stateDef in objDef.StateDefs.Values.OrderBy(x => x.DisplayText))
                {
                    TTComboBoxItem item = new TTComboBoxItem(stateDef.DisplayText + " [" + stateDef.Name + "]", stateDef);
                    StateComboBox.Items.Add(item);
                }
            }
        }

        private void StateComboBox_SelectedIndexChange()
        {
            if (StateComboBox.SelectedItem != null)
            {
                TTObjectStateDef stateDef = StateComboBox.SelectedItem.Value as TTObjectStateDef;

                if (_InvoiceBlockingDefinition.StateDefId.HasValue == false ||
                   (_InvoiceBlockingDefinition.StateDefId.HasValue && _InvoiceBlockingDefinition.StateDefId.Value != stateDef.StateDefID))
                {
                    _InvoiceBlockingDefinition.StateDefId = stateDef.StateDefID;
                    _InvoiceBlockingDefinition.ObjectName = stateDef.ObjectDef.DisplayText + " [" + stateDef.ObjectDef.Name + "]";
                    _InvoiceBlockingDefinition.StateName = stateDef.DisplayText + " [" + stateDef.Name + "]";

                    TTObjectDefBase tempObjDef = stateDef.ObjectDef;

                    while (tempObjDef != null)
                    {
                        if (tempObjDef.ID.Equals(EpisodeActionGuid) || tempObjDef.ID.Equals(SubActionProcedureGuid))
                        {
                            if (tempObjDef.ID.Equals(EpisodeActionGuid))
                                _InvoiceBlockingDefinition.Type = EAorSPEnum.EpisodeAction;
                            else
                                _InvoiceBlockingDefinition.Type = EAorSPEnum.SubActionProcedure;

                            break;
                        }
                        tempObjDef = tempObjDef.BaseObjectDef;
                    }
                }
            }
        }
    }
}