
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
    /// Kan Bankası Kan Ürünü Hazırlama
    /// </summary>
    public partial class BloodProductPreparationForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            btnSend.Click += new TTControlEventDelegate(btnSend_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnSend.Click -= new TTControlEventDelegate(btnSend_Click);
            base.UnBindControlEvents();
        }

        private void btnSend_Click()
        {
#region BloodProductPreparationForm_btnSend_Click
 //  Cursor current = Cursor.Current;
            //Cursor.Current = Cursors.WaitCursor;
            try
            {
                BloodProductRequest.SendToBloodBank(this._BloodProductRequest); //Entegrasyon için.
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
             //   Cursor.Current = current;
            }
#endregion BloodProductPreparationForm_btnSend_Click
        }

        protected override void PreScript()
        {
#region BloodProductPreparationForm_PreScript
    base.PreScript();
    
    this.cmdOK.Visible = false;
    
    this.DropStateButton(BloodProductRequest.States.Completed);
    this.DropStateButton(BloodProductRequest.States.BloodProductUsage);
            this.DropStateButton(BloodProductRequest.States.BloodProductReady);
            this.DropStateButton(BloodProductRequest.States.CrossMatch);
#endregion BloodProductPreparationForm_PreScript

            }
                }
}