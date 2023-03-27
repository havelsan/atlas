
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
    /// e-Reçete Turuncu İlaç Listesi
    /// </summary>
    public partial class OrangePrescriptionDrugListForm : ScheduledTaskBaseForm
    {
        override protected void BindControlEvents()
        {
            btnChoose.Click += new TTControlEventDelegate(btnChoose_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnChoose.Click -= new TTControlEventDelegate(btnChoose_Click);
            base.UnBindControlEvents();
        }

        private void btnChoose_Click()
        {
#region OrangePrescriptionDrugListForm_btnChoose_Click
   //FolderBrowserDialog fbd = new FolderBrowserDialog();

   //         fbd.ShowNewFolderButton = true;

   //         DialogResult result = fbd.ShowDialog();

   //         if (result == DialogResult.OK)
   //         {
   //             this.FilePath.Text = fbd.SelectedPath;
   //         }
   //         else
   //         {
   //             InfoBox.Show("İlaç Listesini Kaydetmek İstediğiniz Dosya Yolunu Seçiniz");
   //         }
            var a = 1;
            #endregion OrangePrescriptionDrugListForm_btnChoose_Click
        }
    }
}