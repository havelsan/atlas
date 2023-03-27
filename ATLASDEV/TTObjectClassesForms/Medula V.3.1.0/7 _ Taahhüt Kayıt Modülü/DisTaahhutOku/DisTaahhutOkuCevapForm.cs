
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
    public partial class DisTaahhutOkuCevapForm : DisTaahhutOkuForm
    {
        override protected void BindControlEvents()
        {
            printTaahhut.Click += new TTControlEventDelegate(printTaahhut_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            printTaahhut.Click -= new TTControlEventDelegate(printTaahhut_Click);
            base.UnBindControlEvents();
        }

        private void printTaahhut_Click()
        {
            #region DisTaahhutOkuCevapForm_printTaahhut_Click
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //         saveFileDialog.DefaultExt = "pdf";
            //         saveFileDialog.Filter = "Adobe PDF Files (*.pdf)|*.pdf";
            //         saveFileDialog.FileName = TTUtils.Globals.MakeFileName(_DisTaahhutOku.taahhutOkuDVO.taahhutCevapDVO.taahhutNo.Value.ToString());
            //         DialogResult dialogResult = saveFileDialog.ShowDialog();
            //         if (dialogResult == DialogResult.OK)
            //         {
            //             try
            //             {
            //                 if (_DisTaahhutOku.taahhutOkuDVO.taahhutCevapDVO.taahhutCikti == null)
            //                     throw new TTException("Taahhüt Çıktı verisi olmadığından PDF dönüştürme işlemi gerçekleştirilemedi");

            //                 byte[] buff = (byte[])_DisTaahhutOku.taahhutOkuDVO.taahhutCevapDVO.taahhutCikti;
            //                 System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);
            //                 System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
            //                 bw.Write(buff);
            //                 bw.Close();

            //                 System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //                 proc.EnableRaisingEvents = false;
            //                 proc.StartInfo.FileName = saveFileDialog.FileName;
            //                 proc.StartInfo.WorkingDirectory = saveFileDialog.InitialDirectory;
            //                 proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            //                 proc.Start();
            //                 proc.WaitForExit();
            //             }
            //             catch (Exception ex)
            //             {
            //                 InfoBox.Show(ex);
            //             }
            //         }
            var a = 1;
            #endregion DisTaahhutOkuCevapForm_printTaahhut_Click
        }

        protected override void PreScript()
        {
#region DisTaahhutOkuCevapForm_PreScript
    if (MedulaGlobals.IsAcrobatReaderInstalled == false)
            {
                printTaahhut.Enabled = false;
                adobeStatusLabel.Text = "Bilgisayarınızda Acrobat Reader yüklü olmadığından Taahhüt Çıktısını alamazsınız.\r\n\r\nLütfen Acrobat Reader yükleyip yeniden deneyiniz.";
            }
            else
            {
                if (_DisTaahhutOku.CurrentStateDefID.Equals(DisTaahhutOku.States.CompletedSuccessfully))
                {
                    printTaahhut.Enabled = true;
                    adobeStatusLabel.Text = "Aşağıdaki düğmeye basarak Taahhüt Çıktısını alabilirsiniz.";
                }
                else
                {
                    printTaahhut.Enabled = false;
                    adobeStatusLabel.Text = "İşlem durumu \"Başarısız Tamamlandı\" olduğu için Taahhüt Çıktısı alamazsınız.";
                }
            }
#endregion DisTaahhutOkuCevapForm_PreScript

            }
                }
}