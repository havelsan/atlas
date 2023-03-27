
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
    public partial class BaseExportExcelUnboundForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            selectButton.Click += new TTControlEventDelegate(selectButton_Click);
            exportButton.Click += new TTControlEventDelegate(exportButton_Click);
            openButton.Click += new TTControlEventDelegate(openButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            selectButton.Click -= new TTControlEventDelegate(selectButton_Click);
            exportButton.Click -= new TTControlEventDelegate(exportButton_Click);
            openButton.Click -= new TTControlEventDelegate(openButton_Click);
            base.UnBindControlEvents();
        }

        private void selectButton_Click()
        {
#region BaseExportExcelUnboundForm_selectButton_Click
   OnSelectFile();
#endregion BaseExportExcelUnboundForm_selectButton_Click
        }

        private void exportButton_Click()
        {
#region BaseExportExcelUnboundForm_exportButton_Click
   OnExportFile();
#endregion BaseExportExcelUnboundForm_exportButton_Click
        }

        private void openButton_Click()
        {
#region BaseExportExcelUnboundForm_openButton_Click
   OnOpenFile();
#endregion BaseExportExcelUnboundForm_openButton_Click
        }

#region BaseExportExcelUnboundForm_Methods
        protected Type _exportReportType;

        protected Dictionary<string, TTReportTool.PropertyCache<object>> _exportParameters = null;

        protected virtual void OnSelectFile()
        {
            try
            {
                //SaveFileDialog saveFileDialog = new SaveFileDialog();
                //saveFileDialog.Filter = "Excel 97-2003 Workbook (*.xls)|*.xls";
                //saveFileDialog.DefaultExt = "xls";
                //saveFileDialog.RestoreDirectory = true;
                //DialogResult dialogResult = saveFileDialog.ShowDialog(this);
                //if (dialogResult == DialogResult.OK)
                //    fileNameTextBox.Text = saveFileDialog.FileName;

                //exportButton.ReadOnly = true;
                //openButton.ReadOnly = true;
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
        }

        protected virtual void OnOpenFile()
        {
            try
            {
                if (System.IO.File.Exists(fileNameTextBox.Text) == false)
                {
                    openButton.ReadOnly = true;
                    throw new Exception("Belirtilen yolda dosya bulunamadı.\r\nDosya Yolu : " + fileNameTextBox.Text);
                }
                System.Diagnostics.Process.Start(fileNameTextBox.Text);
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
        }

        protected virtual void OnExportFile()
        {
            try
            {
                if (string.IsNullOrEmpty(fileNameTextBox.Text))
                    throw new Exception("Dosya Yolu boş olamaz.");

                TTReportTool.TTReport.ExportReport(_exportReportType, _exportParameters, fileNameTextBox.Text);
                if (System.IO.File.Exists(fileNameTextBox.Text))
                    openButton.ReadOnly = false;
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
        }
        
#endregion BaseExportExcelUnboundForm_Methods
    }
}