
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
    /// Kural Seti Tanımlama
    /// </summary>
    public partial class RuleSetDefinitionForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            AddRule.Click += new TTControlEventDelegate(AddRule_Click);
            RemoveRule.Click += new TTControlEventDelegate(RemoveRule_Click);
            EditRule.Click += new TTControlEventDelegate(EditRule_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            AddRule.Click -= new TTControlEventDelegate(AddRule_Click);
            RemoveRule.Click -= new TTControlEventDelegate(RemoveRule_Click);
            EditRule.Click -= new TTControlEventDelegate(EditRule_Click);
            base.UnBindControlEvents();
        }

        private void AddRule_Click()
        {
#region RuleSetDefinitionForm_AddRule_Click
   string filterExpression = string.Empty;
            if (this._RuleSet.RuleSetRules.Count > 0)
            {
                filterExpression += " WHERE OBJECTID NOT IN(";
                int i = 1;
                foreach (RuleSetRule ruleSetRule in this._RuleSet.RuleSetRules)
                {
                    filterExpression += ConnectionManager.GuidToString(ruleSetRule.Rule.ObjectID);
                    if (i < this._RuleSet.RuleSetRules.Count)
                        filterExpression += ",";
                    i++;
                }
                filterExpression += ")";
            }

            TTObjectContext objectContext = new TTObjectContext(true);
            IList rules = RuleBase.GetRules(objectContext, filterExpression);

            if (rules.Count == 0)
            {
                InfoBox.Show(this, "Eklenecek kural bulunamadı.");
                return;
            }

            MultiSelectForm multiSelectForm = new MultiSelectForm();
            foreach (RuleBase rule in rules)
                multiSelectForm.AddMSItem(rule.Name + " (" + rule.Result + ")", rule.ObjectID.ToString(), rule);

            multiSelectForm.GetMSItem(this, "Eklemek istediğiniz kuralı seçiniz.");
            if (multiSelectForm.MSSelectedItemObject != null)
            {
                RuleSetRule ruleSetRule = this._RuleSet.RuleSetRules.AddNew();
                ruleSetRule.Rule = (RuleBase)multiSelectForm.MSSelectedItemObject;
            }
#endregion RuleSetDefinitionForm_AddRule_Click
        }

        private void RemoveRule_Click()
        {
#region RuleSetDefinitionForm_RemoveRule_Click
   if (RuleSetRules.CurrentCell != null && RuleSetRules.CurrentCell.RowIndex >= 0)
            {
                ITTGridRow selectedRow = RuleSetRules.CurrentCell.OwningRow;
                if (selectedRow != null && selectedRow.TTObject != null && selectedRow.TTObject is RuleSetRule)
                {
                    RuleSetRule ruleSetRule = (RuleSetRule)selectedRow.TTObject;
                    this._RuleSet.RuleSetRules.Remove(ruleSetRule);
                    ((ITTObject)ruleSetRule).Delete();

                }
            }
#endregion RuleSetDefinitionForm_RemoveRule_Click
        }

        private void EditRule_Click()
        {
#region RuleSetDefinitionForm_EditRule_Click
   if (RuleSetRules.CurrentCell != null && RuleSetRules.CurrentCell.RowIndex >= 0)
            {
                ITTGridRow selectedRow = RuleSetRules.CurrentCell.OwningRow;
                if (selectedRow != null && selectedRow.TTObject != null && selectedRow.TTObject is RuleSetRule)
                {
                    RuleSetRule ruleSetRule = (RuleSetRule)selectedRow.TTObject;

                    TTListDef ttListDef = null;
                    foreach (TTListDef listDef in TTObjectDefManager.Instance.ListDefs)
                    {
                        if (listDef.ObjectDefID == ruleSetRule.Rule.ObjectDef.ID)
                        {
                            ttListDef = listDef;
                            break;
                        }
                    }

                    if (ttListDef != null)
                    {
                        TTDefinitionForm definitionForm = TTDefinitionForm.GetEditForm(ttListDef, "OBJECTID = " + ConnectionManager.GuidToString(ruleSetRule.Rule.ObjectID));
                        definitionForm.ShowEdit(this, ttListDef);
                    }
                }
            }
#endregion RuleSetDefinitionForm_EditRule_Click
        }
    }
}