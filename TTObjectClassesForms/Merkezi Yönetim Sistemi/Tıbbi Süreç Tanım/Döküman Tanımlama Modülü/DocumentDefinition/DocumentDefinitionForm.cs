
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
    /// Döküman Tanımlama
    /// </summary>
    public partial class DocumentDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            cmdOpenButton.Click += new TTControlEventDelegate(cmdOpenButton_Click);
            cmdAddButton.Click += new TTControlEventDelegate(cmdAddButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdOpenButton.Click -= new TTControlEventDelegate(cmdOpenButton_Click);
            cmdAddButton.Click -= new TTControlEventDelegate(cmdAddButton_Click);
            base.UnBindControlEvents();
        }

        private void cmdOpenButton_Click()
        {
            #region DocumentDefinitionForm_cmdOpenButton_Click
            if (_DocumentDefinition.File != null)
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string filePath = appPath + @"\file." + _DocumentDefinition.FileExtension;
                Byte[] memoryStream = (byte[])_DocumentDefinition.File;
                const int myBufferSize = 1024;
                System.IO.Stream myInputStream = new System.IO.MemoryStream(memoryStream);
                System.IO.Stream myOutputStream = System.IO.File.OpenWrite(filePath);
                byte[] buffer = new Byte[myBufferSize];
                int numbytes;
                while ((numbytes = myInputStream.Read(buffer, 0, myBufferSize)) > 0)
                {
                    myOutputStream.Write(buffer, 0, numbytes);
                }
                myInputStream.Close();
                myOutputStream.Close();
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = filePath;
                if (_DocumentDefinition.FileExtension == "doc" || _DocumentDefinition.FileExtension == "docx")
                    proc.StartInfo.Arguments = "WINWORD.EXE";
                else if (_DocumentDefinition.FileExtension == "xls" || _DocumentDefinition.FileExtension == "xlsx")
                    proc.StartInfo.Arguments = "EXCEL.EXE";
                else
                    proc.StartInfo.Arguments = "WINWORD.EXE";
                proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
                proc.Start();
                proc.WaitForExit();
            }
            #endregion DocumentDefinitionForm_cmdOpenButton_Click
        }

        private void cmdAddButton_Click()
        {
            #region DocumentDefinitionForm_cmdAddButton_Click
            if ((bool)_DocumentDefinition.IsGroup == false)
            {
                System.Windows.Forms.OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                string fileName = @openFileDialog.FileName;
                string[] extNames = openFileDialog.SafeFileName.Split('.');
                int lastCount = extNames.Length;
                string extName = extNames[lastCount - 1];
                System.IO.FileStream fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read);
                long len;
                len = fileStream.Length;
                Byte[] fileAsByte = new Byte[len];
                fileStream.Read(fileAsByte, 0, fileAsByte.Length);
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(fileAsByte);
                _DocumentDefinition.File = memoryStream.ToArray();
                _DocumentDefinition.FileExtension = extName;
            }
            #endregion DocumentDefinitionForm_cmdAddButton_Click
        }

        protected override void PreScript()
        {
            #region CalibrationTestDefinitionForm_PreScript
            base.PreScript();
            if (_DocumentDefinition.File == null)
                this.cmdOpenButton.Enabled = false;
            else
                this.cmdOpenButton.Enabled = true;

            if (_DocumentDefinition.IsGroup.HasValue && (bool)_DocumentDefinition.IsGroup)
            {
                this.cmdOpenButton.Enabled = false;
                this.cmdAddButton.Enabled = false;
            }
            else
            {
                this.cmdOpenButton.Enabled = true;
                this.cmdAddButton.Enabled = true;
            }
            #endregion CalibrationTestDefinitionForm_PreScript

        }
    }
}