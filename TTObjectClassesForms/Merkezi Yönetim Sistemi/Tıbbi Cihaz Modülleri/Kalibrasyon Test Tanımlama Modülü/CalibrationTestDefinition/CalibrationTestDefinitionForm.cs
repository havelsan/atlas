
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
    /// Kalibrasyon Prosedür Tanımlama
    /// </summary>
    public partial class CalibrationTestDefinitionForm : TTDefinitionForm
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
            #region CalibrationTestDefinitionForm_cmdOpenButton_Click
            //string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //         string filePath = appPath + @"\ProcedureMeansurmentReport.doc";
            //         Byte[] memoryStream = (byte[])_CalibrationTestDefinition.Report;
            //         const int myBufferSize = 1024;
            //         System.IO.Stream myInputStream = new System.IO.MemoryStream(memoryStream);
            //         System.IO.Stream myOutputStream = System.IO.File.OpenWrite(filePath);
            //         byte[] buffer = new Byte[myBufferSize];
            //         int numbytes;
            //         while ((numbytes = myInputStream.Read(buffer, 0, myBufferSize)) > 0)
            //         {
            //             myOutputStream.Write(buffer, 0, numbytes);
            //         }
            //         myInputStream.Close();
            //         myOutputStream.Close();
            //         System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //         proc.EnableRaisingEvents = false;
            //         proc.StartInfo.FileName = filePath ;
            //         proc.StartInfo.Arguments = "WINWORD.EXE";
            //         proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            //         proc.Start();
            //         proc.WaitForExit();
            var a = 1;
#endregion CalibrationTestDefinitionForm_cmdOpenButton_Click
        }

        private void cmdAddButton_Click()
        {
            #region CalibrationTestDefinitionForm_cmdAddButton_Click
            //System.Windows.Forms.OpenFileDialog openFileDialog = new OpenFileDialog();
            //         openFileDialog.ShowDialog();
            //         string fileName = @openFileDialog.FileName;
            //         System.IO.FileStream fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read);
            //         long len;
            //         len = fileStream.Length;
            //         Byte[] fileAsByte = new Byte[len];
            //         fileStream.Read(fileAsByte, 0, fileAsByte.Length);
            //         System.IO.MemoryStream memoryStream = new System.IO.MemoryStream (fileAsByte);
            //         _CalibrationTestDefinition.Report = memoryStream.ToArray();
            var a = 1;
            #endregion CalibrationTestDefinitionForm_cmdAddButton_Click
        }

        protected override void PreScript()
        {
#region CalibrationTestDefinitionForm_PreScript
    base.PreScript();
            if(_CalibrationTestDefinition.Report == null)
            {
                this.cmdOpenButton.Enabled = false ;
            }
#endregion CalibrationTestDefinitionForm_PreScript

            }
                }
}