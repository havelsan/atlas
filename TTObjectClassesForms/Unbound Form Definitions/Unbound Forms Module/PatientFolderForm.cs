
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
    /// Hasta Dosyası
    /// </summary>
    public partial class PatientFolderForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            lvwEpisodes.SelectedIndexChanged += new TTControlEventDelegate(lvwEpisodes_SelectedIndexChanged);
            tlbActions.ItemClicked += new TTToolStripItemClicked(tlbActions_ItemClicked);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            lvwEpisodes.SelectedIndexChanged -= new TTControlEventDelegate(lvwEpisodes_SelectedIndexChanged);
            tlbActions.ItemClicked -= new TTToolStripItemClicked(tlbActions_ItemClicked);
            base.UnBindControlEvents();
        }

        private void lvwEpisodes_SelectedIndexChanged()
        {
#region PatientFolderForm_lvwEpisodes_SelectedIndexChanged
   RefreshActions((Guid?)null);
#endregion PatientFolderForm_lvwEpisodes_SelectedIndexChanged
        }

        private void tlbActions_ItemClicked(ITTToolStripItem item)
        {
#region PatientFolderForm_tlbActions_ItemClicked
   switch(item.Name)
            {
                case "NewActionItem":
                    tlbNewActionMenuItemClick(item);
                    break;
                case "tlbOpen":
                    ShowAction();
                    break;
                default:
                    break;                    
            }
#endregion PatientFolderForm_tlbActions_ItemClicked
        }

#region PatientFolderForm_Methods
        private Patient _patient;

        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (_patient == null)
            {
                PatientSearchForm patientSearchForm = new PatientSearchForm();
                Patient p = (Patient)patientSearchForm.GetSelectedObject();
                if (p != null)
                    ShowPatient(p);
            }
        }

        protected override void OnInitializeControls()
        {
            base.OnInitializeControls();
            
            lvwEpisodes.Columns.Clear();
            lvwActions.Columns.Clear();

            foreach (PatientFolderDefinition pfd in PatientFolderDefinition.AllEpisodeColumns.Values)
                lvwEpisodes.Columns.Add(pfd.Caption, pfd.InitialWidth.Value);
            lvwEpisodes.Columns.Add("ToString", 250);

            foreach (PatientFolderDefinition pfd in PatientFolderDefinition.AllActionColumns.Values)
                lvwActions.Columns.Add(pfd.Caption, pfd.InitialWidth.Value);
            lvwActions.Columns.Add("ToString", 250);

            ITTToolStripDropDownButton tlbNewAction = (ITTToolStripDropDownButton)tlbActions.Items["tlbNewAction"];
            foreach (MenuDefinition md in MenuDefinition.PatientMenu.Values)
            {
                foreach (MenuDefinition mdChild in md.ChildMenus)
                {
                    ITTToolStripMenuItem item = new TTToolStripMenuItem();
                    item.Name = "NewActionItem";
                    item.Text = mdChild.Caption;
                    item.Tag = mdChild;
                    tlbNewAction.DropDownItems.Add(item);
                }
            }
        }
        
        void tlbNewActionMenuItemClick(ITTToolStripItem item)
        {
            if (item==null || ((item.Tag is MenuDefinition)==false))
                return;

            if (lvwEpisodes.SelectedItems.Count == 0)
                return;

            MenuDefinition md = (MenuDefinition)item.Tag;
            if (md.ObjectDefinitionName == null)
                return;

            string objectDefName = md.ObjectDefinitionName.ToUpperInvariant();

            if (TTObjectDefManager.Instance.ObjectDefs.ContainsKey(objectDefName) == false)
            {
                MessageBox.Show(md.ObjectDefinitionName + " isimli i?lem tanymlanmamy?.");
                return;
            }

            TTObjectDef objDef = TTObjectDefManager.Instance.ObjectDefs[objectDefName];
            if (objDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant()) == false)
            {
                MessageBox.Show(md.ObjectDefinitionName + " isimli i?lem buradan ba?latylamaz.");
                return;
            }

            Guid episodeID = (Guid)lvwEpisodes.SelectedItems[0].Tag;
            TTObjectContext objectContext = new TTObjectContext(false);
            try
            {
                Episode ep = (Episode)objectContext.GetObject(episodeID, typeof(Episode));

                EpisodeAction newAction = (EpisodeAction)objectContext.CreateObject(objectDefName);
                ep.EpisodeActions.Add(newAction);
                //TODO: set resources from user
                System.ComponentModel.BindingList<ResDepartment> resources = objectContext.QueryObjects<ResDepartment>();
                if (resources.Count == 0)
                {
                    MessageBox.Show("Hiç kaynak tanymlanmamy?.");
                    return;
                }
                newAction.FromResource = resources[0];
                if (resources.Count > 1)
                    newAction.MasterResource = resources[1];
                else
                    newAction.MasterResource = resources[0];

                System.ComponentModel.BindingList<TTObjectStateDef> states = (System.ComponentModel.BindingList<TTObjectStateDef>) ((ITTObject)newAction).GetNextStateDefs();
                if (states.Count > 0)
                    newAction.CurrentStateDef = states[0];
                TTForm frm = TTForm.GetEditForm(newAction);
                if (frm == null)
                {
                    MessageBox.Show(md.ObjectDefinitionName + " isimli i?lem için form tanymlanmamy?.");
                    return;
                }
                frm.ObjectUpdated += new ObjectUpdatedDelegate(NewAction_ObjectUpdated);
                frm.ShowEdit(this, newAction);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objectContext.Dispose();
            }
        }

        void NewAction_ObjectUpdated(TTObject ttObject, ref bool contextSaved)
        {
            ttObject.ObjectContext.Save();
            RefreshActions(ttObject.ObjectID);
        }

        public void ShowPatient(Patient patient)
        {
            _patient = patient;
            FillEpisodes();
            this.Show();
        }

        private void FillEpisodes()
        {
            lvwEpisodes.Items.Clear();
            TTObjectContext context = new TTObjectContext(true);
            Patient p = (Patient)context.GetObject(_patient.ObjectID, _patient.ObjectDef);
            foreach (Episode episode in p.Episodes)
            {
                ITTListViewItem listItem = new TTListViewItem();
                int i = 0;
                foreach (PatientFolderDefinition pfd in PatientFolderDefinition.AllEpisodeColumns.Values)
                {
                    object value = ((ITTObject)episode).GetDataMemberValue(pfd.PropertyName);
                    string text = "";
                    if (value != null)
                        text = value.ToString();

                    if (i == 0)
                        listItem.Text = text;
                    else
                        listItem.SubItems.Add(text);
                    i++;
                }
                listItem.SubItems.Add(episode.ToString());
                listItem.Tag = episode.ObjectID;
                lvwEpisodes.Items.Add(listItem);
            }

            if (lvwEpisodes.Items.Count > 0)
                lvwEpisodes.Items[0].Selected = true;

            context.Dispose();
        }

        private void FillActions(Guid episodeID, Guid? selectActionID)
        {
            TTObjectContext context = new TTObjectContext(true);
            Episode episode = (Episode)context.GetObject(episodeID, typeof(Episode));
            lvwActions.Items.Clear();
            foreach (EpisodeAction action in episode.EpisodeActions)
            {
                ITTListViewItem listItem = new TTListViewItem();
                int i = 0;
                foreach (PatientFolderDefinition pfd in PatientFolderDefinition.AllActionColumns.Values)
                {
                    object value = ((ITTObject)action).GetDataMemberValue(pfd.PropertyName);
                    string text = "";
                    if (value != null)
                        text = value.ToString();

                    if (i == 0)
                        listItem.Text = text;
                    else
                        listItem.SubItems.Add(text);
                    i++;
                }
                listItem.SubItems.Add(action.ToString());
                listItem.Tag = action.ObjectID;
                lvwActions.Items.Add(listItem);
                if (selectActionID.HasValue && selectActionID.Value==action.ObjectID)
                    listItem.Selected = true;
            }
            if (lvwActions.Items.Count>0 && lvwActions.SelectedItems.Count==0)
                lvwActions.Items[0].Selected = true;
        }

        private void RefreshActions(Guid? selectActionID)
        {
            if (lvwEpisodes.SelectedItems.Count == 0)
            {
                lvwActions.Items.Clear();
                return;
            }

            FillActions((Guid)lvwEpisodes.SelectedItems[0].Tag, selectActionID);
        }

        private void ShowAction()
        {
            if (lvwActions.SelectedItems.Count == 0)
                return;

            Guid actionID = (Guid)lvwActions.SelectedItems[0].Tag;
            TTObjectContext objectContext = new TTObjectContext(false);
            try
            {
                EpisodeAction action = (EpisodeAction)objectContext.GetObject(actionID, typeof(EpisodeAction));

                TTForm frm = TTForm.GetEditForm(action);
                if (frm == null)
                {
                    MessageBox.Show(action.ObjectDef.Name + " isimli i?lem için form tanymlanmamy?.");
                    return;
                }
                frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
                frm.ShowEdit(this, action);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                objectContext.Dispose();
            }
        }
        
        private void ShowPatientAdmission()
        {
            //TTObjectContext context = new TTObjectContext(true);
            //Guid episodeID = (Guid)lvwEpisodes.SelectedItems[0].Tag;
            //Episode episode = (Episode)context.GetObject(episodeID, typeof(Episode));
            //if (episode.LastSubEpisode.PatientAdmission!=null)
            //{
            //    try
            //    {

            //        TTForm frm = TTForm.GetEditForm(episode.LastSubEpisode.PatientAdmission);
            //        if (frm == null)
            //        {
            //            MessageBox.Show(episode.LastSubEpisode.PatientAdmission.ObjectDef.Name + " isimli işlem için form tanymlanmamy?.");
            //            return;
            //        }
            //        frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
            //        frm.ShowEdit(this, episode.LastSubEpisode.PatientAdmission);
            //    }
            //    catch (System.Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //    finally
            //    {
            //        context.Dispose();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vakaya ait Hasta Kabul'e erişilemedi ");
            //    return;
            //}
        }

        void ShowAction_ObjectUpdated(TTObject ttObject, ref bool contextSaved)
        {
            ttObject.ObjectContext.Save();
            RefreshActions(ttObject.ObjectID);
        }
        
#endregion PatientFolderForm_Methods
    }
}