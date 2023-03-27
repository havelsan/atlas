
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
    public partial class SmartCardLoginForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            cmdCancel.Click += new TTControlEventDelegate(cmdCancel_Click);
            cmdPinOK.Click += new TTControlEventDelegate(cmdPinOK_Click);
            SmartCardPin.TextChanged += new TTControlEventDelegate(SmartCardPin_TextChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdCancel.Click -= new TTControlEventDelegate(cmdCancel_Click);
            cmdPinOK.Click -= new TTControlEventDelegate(cmdPinOK_Click);
            SmartCardPin.TextChanged -= new TTControlEventDelegate(SmartCardPin_TextChanged);
            base.UnBindControlEvents();
        }

        private void cmdCancel_Click()
        {
#region SmartCardLoginForm_cmdCancel_Click
   this.DialogResult = DialogResult.Cancel;
            this.Close();
#endregion SmartCardLoginForm_cmdCancel_Click
        }

        private void cmdPinOK_Click()
        {
#region SmartCardLoginForm_cmdPinOK_Click
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
#endregion SmartCardLoginForm_cmdPinOK_Click
        }

        private void SmartCardPin_TextChanged()
        {
#region SmartCardLoginForm_SmartCardPin_TextChanged
   this._lastInputTime = DateTime.Now;
#endregion SmartCardLoginForm_SmartCardPin_TextChanged
        }

#region SmartCardLoginForm_Methods
        private DateTime? _lastInputTime;
        private System.Timers.Timer _pinCheckTimer;
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Her iki sn'de pin girişi sonrası bekleme kontrol edilecek
            _pinCheckTimer = new System.Timers.Timer(2000);
            _pinCheckTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnCheckPinInputTime);
            _pinCheckTimer.Enabled = true;
            
            IList<string> terminalList = TTUtils.SmartCardManagerFactory.Instance.TerminalList();
            foreach(string terminal in terminalList)
            {
                cboCardList.Items.Add(new TTComboBoxItem(terminal, terminal));
            }
            
            if ( cboCardList.Items.Count > 0 )
            {
                cboCardList.SelectedIndex = 0;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            
            if ( _pinCheckTimer != null )
            {
                _pinCheckTimer.Stop();
                _pinCheckTimer.Elapsed -= new System.Timers.ElapsedEventHandler(OnCheckPinInputTime);
                _pinCheckTimer.Enabled = false;
            }
        }
        
        private void OnCheckPinInputTime(object source, System.Timers.ElapsedEventArgs e)
        {
            if ( _lastInputTime.HasValue )
            {
                TimeSpan diff = DateTime.Now - _lastInputTime.Value;
                if ( diff.Seconds > 15 )
                {
                    if (!string.IsNullOrEmpty(SmartCardPin.Text))
                    {
                        try
                        {
                            this.Invoke((MethodInvoker)delegate {
                                            SmartCardPin.Text = string.Empty;
                                        });
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
        
#endregion SmartCardLoginForm_Methods
    }
}