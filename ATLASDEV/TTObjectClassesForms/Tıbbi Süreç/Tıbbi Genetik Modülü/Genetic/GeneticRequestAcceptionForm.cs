
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
    /// Materyal Kabul
    /// </summary>
    public partial class GeneticRequestAcceptionForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            PrintBarcodeBtn.Click += new TTControlEventDelegate(PrintBarcodeBtn_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            PrintBarcodeBtn.Click -= new TTControlEventDelegate(PrintBarcodeBtn_Click);
            base.UnBindControlEvents();
        }

        private void PrintBarcodeBtn_Click()
        {
            #region GeneticRequestAcceptionForm_PrintBarcodeBtn_Click
            //const string asc01 = "\u0001";
            //         const string asc02 = "\u0002";
            //         const string crlf = "\r\n";

            //         Genetic genetic = this._Genetic;
            //         Patient p = this._Genetic.Episode.Patient;

            //         string kod = genetic.GeneticSampleNo.ToString();
            //         string isim = TTUtils.Globals.CUCase(p.FullName,false,false);
            //         string dt = (Convert.ToDateTime(p.BirthDate)).ToString("dd/MM/yyyy");
            //         string age = p.Age == null ? "" : p.Age.Value.ToString();
            //         string testLongName = genetic.GeneticTests[0].ProcedureObject.Name;
            //         //string etiket = "";

            //         StringBuilder sb = new StringBuilder();
            //         sb.AppendLine();
            //         sb.AppendLine("N");
            //         sb.AppendLine("q320");
            //         sb.AppendLine("Q223,24+00");
            //         sb.AppendLine("S3");
            //         sb.AppendLine("D8");
            //         sb.AppendLine("ZT");
            //         sb.AppendLine("TTh:m");
            //         sb.AppendLine("TDy2.mn.dd");
            //         sb.AppendLine("O");
            //         sb.AppendLine("A14,12,0,1,1,1,N," + "\"" + "Adi Soyadi :" + "\"");
            //         sb.AppendLine("A14,32,0,1,1,1,N," + "\"" + "Dogum Tarihi :" + "\"");
            //         sb.AppendLine("A152,12,0,1,1,1,N," + "\"" + isim + "\"");
            //         sb.AppendLine("A152,32,0,1,1,1,N," + "\"" + dt + "\"");
            //         sb.AppendLine("A14,51,0,1,1,1,N," + "\"" + "Yasi :" + "\"");
            //         sb.AppendLine("A152,51,0,1,1,1,N," + "\"" + age + "\"");
            //         sb.AppendLine("B81,65,0,3,2,4,65,N," + "\"" + kod + "\"");
            //         sb.AppendLine("A18,175,0,1,1,1,N," + "\"" + testLongName + "\"");
            //         sb.AppendLine("A126,138,0,4,1,1,N," + "\"" + kod + "\"");
            //         sb.AppendLine("P1");

            //         /* Eski kod
            //         etiket += asc02 + "KI70x1" + crlf;
            //         etiket += asc02 + "M3000" + crlf;
            //         etiket += asc02 + "c0000" + crlf;
            //         etiket += asc02 + "e" + crlf;
            //         etiket += asc02 + "O0215" + crlf;
            //         etiket += asc02 + "f255" + crlf;
            //         etiket += asc01 + "D";
            //         etiket += asc02 + "L" + crlf;
            //         etiket += asc02 + "L" + crlf;
            //         etiket += "D11" + crlf;
            //         etiket += "PE" + crlf;
            //         etiket += "SE" + crlf;
            //         etiket += "H10" + crlf;
            //         etiket += "1AA510300840040" + kod + crlf;
            //         etiket += "131100000420036" + isim + crlf;
            //         etiket += "131100000400259" + dt + crlf;
            //         etiket += "Q0001" + crlf;
            //         etiket += "E" + crlf;
            //          */
            //         //System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\dene.prn");
            //         //sw.Write(etiket);
            //         //sw.Close();

            //         try
            //         {
            //             System.IO.Ports.SerialPort s = new System.IO.Ports.SerialPort("COM1", 9600, System.IO.Ports.Parity.None, 8);
            //             s.Handshake = System.IO.Ports.Handshake.None;
            //             s.Open();
            //             s.WriteTimeout = 5000;
            //             s.Write(sb.ToString());
            //             s.Close();
            //         }

            //         catch(Exception ex)
            //         {
            //             string hatamesaji = "Etiket yazdırma sırasında hata oluştu\r\n" + ex.ToString();
            //         }
            var a = 1;
#endregion GeneticRequestAcceptionForm_PrintBarcodeBtn_Click
        }

        protected override void PreScript()
        {
#region GeneticRequestAcceptionForm_PreScript
    base.PreScript();
            
            if( this._Genetic.GeneticTests.Count > 0 ){
                GeneticTestDefinition genTestDef = ((GeneticTest)this._Genetic.GeneticTests[0]).ProcedureObject as GeneticTestDefinition;
                if(genTestDef != null)
                {
                    this.TestToStudyTTListBox.SelectedObject = genTestDef;
                    if( genTestDef.Equipment.Count > 0)
                    {
                        ResGeneticEqiupmentDef genEquipmentDef = genTestDef.Equipment[0].MyEquipment;
                    }               
                }
            }
#endregion GeneticRequestAcceptionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region GeneticRequestAcceptionForm_PostScript
    base.PostScript(transDef);
            if( this._Genetic.GeneticTests.Count > 0 ){
                ((GeneticTest)this._Genetic.GeneticTests[0]).ProcedureObject = (GeneticTestDefinition)this.TestToStudyTTListBox.SelectedObject;
            }
#endregion GeneticRequestAcceptionForm_PostScript

            }
                }
}