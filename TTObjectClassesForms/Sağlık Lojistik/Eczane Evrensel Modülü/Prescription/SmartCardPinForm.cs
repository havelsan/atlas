
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
    public partial class SmartCardPinForm : PrescriptionBaseForm
    {
        override protected void BindControlEvents()
        {
            cmdPinOK.Click += new TTControlEventDelegate(cmdPinOK_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdPinOK.Click -= new TTControlEventDelegate(cmdPinOK_Click);
            base.UnBindControlEvents();
        }

        private void cmdPinOK_Click()
        {
#region SmartCardPinForm_cmdPinOK_Click
   this.DialogResult = DialogResult.Cancel;
            ITTComboBoxItem selectedCard = cboCardList.SelectedItem;
            if ( selectedCard == null )
            {
                InfoBox.Show("Lütfen listeden akıllı kart seçiniz", MessageIconEnum.InformationMessage);
                return;
            }
            
            string cardPin = SmartCardPin.Text;
            if ( string.IsNullOrEmpty(cardPin) )
            {
                InfoBox.Show("Lütfen akıllı kart pini giriniz", MessageIconEnum.InformationMessage);
                return;
            }

            try
            {
                TTUtils.SmartCardManagerFactory.Instance.Login(selectedCard.Text, cardPin.Trim());
            }
            catch(Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Akıllı kart giriş işlemiz başarısız oldu");
                sb.AppendLine(ex.Message);
                InfoBox.Show(sb.ToString(), MessageIconEnum.InformationMessage);
                return;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
#endregion SmartCardPinForm_cmdPinOK_Click
        }

        protected override void PreScript()
        {
#region SmartCardPinForm_PreScript
    base.PreScript();
            
            IList<string> terminalList = TTUtils.SmartCardManagerFactory.Instance.TerminalList();
            foreach(string terminal in terminalList)
            {
                cboCardList.Items.Add(new TTComboBoxItem(terminal, terminal));
            }
#endregion SmartCardPinForm_PreScript

            }
                }
}