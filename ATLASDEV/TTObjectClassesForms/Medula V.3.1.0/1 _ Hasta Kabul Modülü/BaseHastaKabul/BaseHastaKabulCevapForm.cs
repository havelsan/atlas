
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
    /// Temel Hasta Kabul Cevap
    /// </summary>
    public partial class BaseHastaKabulCevapForm : BaseHastaKabulForm
    {
        override protected void BindControlEvents()
        {
            writeFileButton.Click += new TTControlEventDelegate(writeFileButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            writeFileButton.Click -= new TTControlEventDelegate(writeFileButton_Click);
            base.UnBindControlEvents();
        }

        private void writeFileButton_Click()
        {
#region BaseHastaKabulCevapForm_writeFileButton_Click
   //SaveFileDialog saveFileDialog = new SaveFileDialog();
   //         saveFileDialog.InitialDirectory = "c:\\";
   //         saveFileDialog.Filter = "XXXXXX Medula Dosyası (*.med)|*.med";
   //         saveFileDialog.DefaultExt = "med";
   //         saveFileDialog.RestoreDirectory = true;
   //         DialogResult dialogResult = saveFileDialog.ShowDialog(this);
   //         if (dialogResult == DialogResult.OK)
   //         {
   //             System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(saveFileDialog.FileName);
   //             streamWriter.Write(Code2D.EncodedValue);
   //             streamWriter.Close();
   //         }
#endregion BaseHastaKabulCevapForm_writeFileButton_Click
        }

        protected override void PreScript()
        {
#region BaseHastaKabulCevapForm_PreScript
    base.PreScript();


            if (string.IsNullOrEmpty(dogumTarihiCevap.Text) == false)
            {
                DateTime dateTime = Convert.ToDateTime(dogumTarihiCevap.Text);
                ((ITTDateTimePicker)dogumTarihiCevapDateTimePicker).ControlValue = dateTime;
            }

            Code2D.WriteBarcode(_BaseHastaKabul.PrepareExportXML());
#endregion BaseHastaKabulCevapForm_PreScript

            }
                }
}