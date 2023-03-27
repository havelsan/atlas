
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// IlacRaporu
    /// </summary>
    public partial class IlacRaporu : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public IlacRaporu MyParentReport
            {
                get { return (IlacRaporu)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField HOSPITALNAME1 { get {return Header().HOSPITALNAME1;} }
            public TTReportField REPORTHEADER1 { get {return Header().REPORTHEADER1;} }
            public TTReportField DOCTORNAME1 { get {return Footer().DOCTORNAME1;} }
            public TTReportField DOCTORNAME2 { get {return Footer().DOCTORNAME2;} }
            public TTReportField DOCTORNAME3 { get {return Footer().DOCTORNAME3;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public IlacRaporu MyParentReport
                {
                    get { return (IlacRaporu)ParentReport; }
                }
                
                public TTReportField HOSPITALNAME1;
                public TTReportField REPORTHEADER1; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 43;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HOSPITALNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 12, 178, 35, false);
                    HOSPITALNAME1.Name = "HOSPITALNAME1";
                    HOSPITALNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALNAME1.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME1.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAME1.TextFont.Size = 11;
                    HOSPITALNAME1.TextFont.Bold = true;
                    HOSPITALNAME1.TextFont.CharSet = 162;
                    HOSPITALNAME1.Value = @"XXXXXXADI";

                    REPORTHEADER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 34, 178, 41, false);
                    REPORTHEADER1.Name = "REPORTHEADER1";
                    REPORTHEADER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTHEADER1.TextFont.Size = 12;
                    REPORTHEADER1.TextFont.Bold = true;
                    REPORTHEADER1.TextFont.CharSet = 162;
                    REPORTHEADER1.Value = @"İLAÇ RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HOSPITALNAME1.CalcValue = HOSPITALNAME1.Value;
                    REPORTHEADER1.CalcValue = REPORTHEADER1.Value;
                    return new TTReportObject[] { HOSPITALNAME1,REPORTHEADER1};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public IlacRaporu MyParentReport
                {
                    get { return (IlacRaporu)ParentReport; }
                }
                
                public TTReportField DOCTORNAME1;
                public TTReportField DOCTORNAME2;
                public TTReportField DOCTORNAME3; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                    DOCTORNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 7, 62, 18, false);
                    DOCTORNAME1.Name = "DOCTORNAME1";
                    DOCTORNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORNAME1.Value = @"";

                    DOCTORNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 7, 125, 18, false);
                    DOCTORNAME2.Name = "DOCTORNAME2";
                    DOCTORNAME2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORNAME2.Value = @"";

                    DOCTORNAME3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 7, 185, 18, false);
                    DOCTORNAME3.Name = "DOCTORNAME3";
                    DOCTORNAME3.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORNAME3.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DOCTORNAME1.CalcValue = @"";
                    DOCTORNAME2.CalcValue = @"";
                    DOCTORNAME3.CalcValue = @"";
                    return new TTReportObject[] { DOCTORNAME1,DOCTORNAME2,DOCTORNAME3};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public IlacRaporu MyParentReport
            {
                get { return (IlacRaporu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NAME11 { get {return Body().NAME11;} }
            public TTReportField lblNAME11 { get {return Body().lblNAME11;} }
            public TTReportField NewField30 { get {return Body().NewField30;} }
            public TTReportField lblUNIQUEREFNO11 { get {return Body().lblUNIQUEREFNO11;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField lblBIRTHDATE { get {return Body().lblBIRTHDATE;} }
            public TTReportField lblSICILNO1 { get {return Body().lblSICILNO1;} }
            public TTReportField lblKURUM1 { get {return Body().lblKURUM1;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField dotsDYERTAR11 { get {return Body().dotsDYERTAR11;} }
            public TTReportField dotsRUTBE11 { get {return Body().dotsRUTBE11;} }
            public TTReportField dotsKABULSEBEBI11 { get {return Body().dotsKABULSEBEBI11;} }
            public TTReportField dotsDYERTAR111 { get {return Body().dotsDYERTAR111;} }
            public TTReportField dotsRUTBE111 { get {return Body().dotsRUTBE111;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField lblDATE1 { get {return Body().lblDATE1;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField lblREPDATE { get {return Body().lblREPDATE;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField NewField101 { get {return Body().NewField101;} }
            public TTReportField lblFATERNAME { get {return Body().lblFATERNAME;} }
            public TTReportField lblLNO1 { get {return Body().lblLNO1;} }
            public TTReportField lblREPORTNO1 { get {return Body().lblREPORTNO1;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField dotsDYERTAR121 { get {return Body().dotsDYERTAR121;} }
            public TTReportField dotsRUTBE121 { get {return Body().dotsRUTBE121;} }
            public TTReportField dotsKABULSEBEBI111 { get {return Body().dotsKABULSEBEBI111;} }
            public TTReportField dotsDYERTAR1111 { get {return Body().dotsDYERTAR1111;} }
            public TTReportField dotsRUTBE1111 { get {return Body().dotsRUTBE1111;} }
            public TTReportField lblADRESS { get {return Body().lblADRESS;} }
            public TTReportField dotsKABULSEBEBI112 { get {return Body().dotsKABULSEBEBI112;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField lblREASON { get {return Body().lblREASON;} }
            public TTReportField dotsKABULSEBEBI1211 { get {return Body().dotsKABULSEBEBI1211;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField lblKURUM { get {return Body().lblKURUM;} }
            public TTReportField dotsKABULSEBEBI1212 { get {return Body().dotsKABULSEBEBI1212;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public IlacRaporu MyParentReport
                {
                    get { return (IlacRaporu)ParentReport; }
                }
                
                public TTReportField NAME11;
                public TTReportField lblNAME11;
                public TTReportField NewField30;
                public TTReportField lblUNIQUEREFNO11;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField lblBIRTHDATE;
                public TTReportField lblSICILNO1;
                public TTReportField lblKURUM1;
                public TTReportField NewField16;
                public TTReportField dotsDYERTAR11;
                public TTReportField dotsRUTBE11;
                public TTReportField dotsKABULSEBEBI11;
                public TTReportField dotsDYERTAR111;
                public TTReportField dotsRUTBE111;
                public TTReportField NewField17;
                public TTReportField lblDATE1;
                public TTReportField NewField18;
                public TTReportField lblREPDATE;
                public TTReportField NewField19;
                public TTReportField NewField101;
                public TTReportField lblFATERNAME;
                public TTReportField lblLNO1;
                public TTReportField lblREPORTNO1;
                public TTReportField NewField111;
                public TTReportField dotsDYERTAR121;
                public TTReportField dotsRUTBE121;
                public TTReportField dotsKABULSEBEBI111;
                public TTReportField dotsDYERTAR1111;
                public TTReportField dotsRUTBE1111;
                public TTReportField lblADRESS;
                public TTReportField dotsKABULSEBEBI112;
                public TTReportField NewField1;
                public TTReportField lblREASON;
                public TTReportField dotsKABULSEBEBI1211;
                public TTReportField NewField11;
                public TTReportField lblKURUM;
                public TTReportField dotsKABULSEBEBI1212;
                public TTReportField NewField12;
                public TTReportShape NewLine2;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 55;
                    RepeatCount = 0;
                    
                    NAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 10, 112, 15, false);
                    NAME11.Name = "NAME11";
                    NAME11.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME11.ObjectDefName = "RadiologyTest";
                    NAME11.DataMember = "EPISODE.PATIENT.FullName";
                    NAME11.TextFont.Size = 9;
                    NAME11.TextFont.CharSet = 162;
                    NAME11.Value = @"";

                    lblNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 10, 43, 15, false);
                    lblNAME11.Name = "lblNAME11";
                    lblNAME11.TextFont.Size = 9;
                    lblNAME11.TextFont.Bold = true;
                    lblNAME11.TextFont.CharSet = 162;
                    lblNAME11.Value = @"Adı Soyadı";

                    NewField30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 4, 206, 9, false);
                    NewField30.Name = "NewField30";
                    NewField30.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField30.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField30.TextFont.Size = 9;
                    NewField30.TextFont.CharSet = 162;
                    NewField30.Value = @"";

                    lblUNIQUEREFNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 4, 151, 9, false);
                    lblUNIQUEREFNO11.Name = "lblUNIQUEREFNO11";
                    lblUNIQUEREFNO11.TextFont.Size = 9;
                    lblUNIQUEREFNO11.TextFont.Bold = true;
                    lblUNIQUEREFNO11.TextFont.CharSet = 162;
                    lblUNIQUEREFNO11.Value = @"T.C. Kimlik No";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 22, 112, 27, false);
                    NewField14.Name = "NewField14";
                    NewField14.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Size = 9;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 28, 112, 33, false);
                    NewField15.Name = "NewField15";
                    NewField15.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Size = 9;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"";

                    lblBIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 16, 43, 21, false);
                    lblBIRTHDATE.Name = "lblBIRTHDATE";
                    lblBIRTHDATE.TextFont.Size = 9;
                    lblBIRTHDATE.TextFont.Bold = true;
                    lblBIRTHDATE.TextFont.CharSet = 162;
                    lblBIRTHDATE.Value = @"Doğum Yeri / Tarihi";

                    lblSICILNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 22, 43, 27, false);
                    lblSICILNO1.Name = "lblSICILNO1";
                    lblSICILNO1.TextFont.Size = 9;
                    lblSICILNO1.TextFont.Bold = true;
                    lblSICILNO1.TextFont.CharSet = 162;
                    lblSICILNO1.Value = @"Sicil No";

                    lblKURUM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 28, 43, 33, false);
                    lblKURUM1.Name = "lblKURUM1";
                    lblKURUM1.TextFont.Size = 9;
                    lblKURUM1.TextFont.Bold = true;
                    lblKURUM1.TextFont.CharSet = 162;
                    lblKURUM1.Value = @"Görevi ve Çalıştığı Kurum";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 16, 112, 21, false);
                    NewField16.Name = "NewField16";
                    NewField16.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Size = 9;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"";

                    dotsDYERTAR11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 16, 46, 21, false);
                    dotsDYERTAR11.Name = "dotsDYERTAR11";
                    dotsDYERTAR11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsDYERTAR11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsDYERTAR11.TextFont.Size = 9;
                    dotsDYERTAR11.TextFont.Bold = true;
                    dotsDYERTAR11.TextFont.CharSet = 162;
                    dotsDYERTAR11.Value = @":";

                    dotsRUTBE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 22, 46, 27, false);
                    dotsRUTBE11.Name = "dotsRUTBE11";
                    dotsRUTBE11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsRUTBE11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsRUTBE11.TextFont.Size = 9;
                    dotsRUTBE11.TextFont.Bold = true;
                    dotsRUTBE11.TextFont.CharSet = 162;
                    dotsRUTBE11.Value = @":";

                    dotsKABULSEBEBI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 28, 46, 33, false);
                    dotsKABULSEBEBI11.Name = "dotsKABULSEBEBI11";
                    dotsKABULSEBEBI11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsKABULSEBEBI11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsKABULSEBEBI11.TextFont.Size = 9;
                    dotsKABULSEBEBI11.TextFont.Bold = true;
                    dotsKABULSEBEBI11.TextFont.CharSet = 162;
                    dotsKABULSEBEBI11.Value = @":";

                    dotsDYERTAR111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 4, 154, 9, false);
                    dotsDYERTAR111.Name = "dotsDYERTAR111";
                    dotsDYERTAR111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsDYERTAR111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsDYERTAR111.TextFont.Size = 9;
                    dotsDYERTAR111.TextFont.Bold = true;
                    dotsDYERTAR111.TextFont.CharSet = 162;
                    dotsDYERTAR111.Value = @":";

                    dotsRUTBE111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 10, 46, 15, false);
                    dotsRUTBE111.Name = "dotsRUTBE111";
                    dotsRUTBE111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsRUTBE111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsRUTBE111.TextFont.Size = 9;
                    dotsRUTBE111.TextFont.Bold = true;
                    dotsRUTBE111.TextFont.CharSet = 162;
                    dotsRUTBE111.Value = @":";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 10, 206, 15, false);
                    NewField17.Name = "NewField17";
                    NewField17.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.ObjectDefName = "RadiologyTest";
                    NewField17.DataMember = "EPISODE.PATIENT.FullName";
                    NewField17.TextFont.Size = 9;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"";

                    lblDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 10, 151, 15, false);
                    lblDATE1.Name = "lblDATE1";
                    lblDATE1.TextFont.Size = 9;
                    lblDATE1.TextFont.Bold = true;
                    lblDATE1.TextFont.CharSet = 162;
                    lblDATE1.Value = @"Müracat Tar.";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 16, 206, 21, false);
                    NewField18.Name = "NewField18";
                    NewField18.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Size = 9;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"";

                    lblREPDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 16, 151, 21, false);
                    lblREPDATE.Name = "lblREPDATE";
                    lblREPDATE.TextFont.Size = 9;
                    lblREPDATE.TextFont.Bold = true;
                    lblREPDATE.TextFont.CharSet = 162;
                    lblREPDATE.Value = @"Rapor Tarihi";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 28, 206, 33, false);
                    NewField19.Name = "NewField19";
                    NewField19.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Size = 9;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 4, 112, 9, false);
                    NewField101.Name = "NewField101";
                    NewField101.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField101.TextFont.Size = 9;
                    NewField101.TextFont.CharSet = 162;
                    NewField101.Value = @"";

                    lblFATERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 22, 151, 27, false);
                    lblFATERNAME.Name = "lblFATERNAME";
                    lblFATERNAME.TextFont.Size = 9;
                    lblFATERNAME.TextFont.Bold = true;
                    lblFATERNAME.TextFont.CharSet = 162;
                    lblFATERNAME.Value = @"Baba Adı";

                    lblLNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 28, 151, 33, false);
                    lblLNO1.Name = "lblLNO1";
                    lblLNO1.TextFont.Size = 9;
                    lblLNO1.TextFont.Bold = true;
                    lblLNO1.TextFont.CharSet = 162;
                    lblLNO1.Value = @"İşlem No";

                    lblREPORTNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 4, 43, 9, false);
                    lblREPORTNO1.Name = "lblREPORTNO1";
                    lblREPORTNO1.TextFont.Size = 9;
                    lblREPORTNO1.TextFont.Bold = true;
                    lblREPORTNO1.TextFont.CharSet = 162;
                    lblREPORTNO1.Value = @"Rapor No / Defter No";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 22, 206, 27, false);
                    NewField111.Name = "NewField111";
                    NewField111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"";

                    dotsDYERTAR121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 22, 154, 27, false);
                    dotsDYERTAR121.Name = "dotsDYERTAR121";
                    dotsDYERTAR121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsDYERTAR121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsDYERTAR121.TextFont.Size = 9;
                    dotsDYERTAR121.TextFont.Bold = true;
                    dotsDYERTAR121.TextFont.CharSet = 162;
                    dotsDYERTAR121.Value = @":";

                    dotsRUTBE121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 28, 154, 33, false);
                    dotsRUTBE121.Name = "dotsRUTBE121";
                    dotsRUTBE121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsRUTBE121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsRUTBE121.TextFont.Size = 9;
                    dotsRUTBE121.TextFont.Bold = true;
                    dotsRUTBE121.TextFont.CharSet = 162;
                    dotsRUTBE121.Value = @":";

                    dotsKABULSEBEBI111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 4, 46, 9, false);
                    dotsKABULSEBEBI111.Name = "dotsKABULSEBEBI111";
                    dotsKABULSEBEBI111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsKABULSEBEBI111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsKABULSEBEBI111.TextFont.Size = 9;
                    dotsKABULSEBEBI111.TextFont.Bold = true;
                    dotsKABULSEBEBI111.TextFont.CharSet = 162;
                    dotsKABULSEBEBI111.Value = @":";

                    dotsDYERTAR1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 10, 154, 15, false);
                    dotsDYERTAR1111.Name = "dotsDYERTAR1111";
                    dotsDYERTAR1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsDYERTAR1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsDYERTAR1111.TextFont.Size = 9;
                    dotsDYERTAR1111.TextFont.Bold = true;
                    dotsDYERTAR1111.TextFont.CharSet = 162;
                    dotsDYERTAR1111.Value = @":";

                    dotsRUTBE1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 16, 154, 21, false);
                    dotsRUTBE1111.Name = "dotsRUTBE1111";
                    dotsRUTBE1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsRUTBE1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsRUTBE1111.TextFont.Size = 9;
                    dotsRUTBE1111.TextFont.Bold = true;
                    dotsRUTBE1111.TextFont.CharSet = 162;
                    dotsRUTBE1111.Value = @":";

                    lblADRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 34, 43, 39, false);
                    lblADRESS.Name = "lblADRESS";
                    lblADRESS.TextFont.Size = 9;
                    lblADRESS.TextFont.Bold = true;
                    lblADRESS.TextFont.CharSet = 162;
                    lblADRESS.Value = @"Ev Adresi";

                    dotsKABULSEBEBI112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 34, 46, 39, false);
                    dotsKABULSEBEBI112.Name = "dotsKABULSEBEBI112";
                    dotsKABULSEBEBI112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsKABULSEBEBI112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsKABULSEBEBI112.TextFont.Size = 9;
                    dotsKABULSEBEBI112.TextFont.Bold = true;
                    dotsKABULSEBEBI112.TextFont.CharSet = 162;
                    dotsKABULSEBEBI112.Value = @":";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 34, 206, 39, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"NewField1";

                    lblREASON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 40, 43, 45, false);
                    lblREASON.Name = "lblREASON";
                    lblREASON.TextFont.Size = 9;
                    lblREASON.TextFont.Bold = true;
                    lblREASON.TextFont.CharSet = 162;
                    lblREASON.Value = @"Rapor İstek Nedeni";

                    dotsKABULSEBEBI1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 40, 46, 45, false);
                    dotsKABULSEBEBI1211.Name = "dotsKABULSEBEBI1211";
                    dotsKABULSEBEBI1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsKABULSEBEBI1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsKABULSEBEBI1211.TextFont.Size = 9;
                    dotsKABULSEBEBI1211.TextFont.Bold = true;
                    dotsKABULSEBEBI1211.TextFont.CharSet = 162;
                    dotsKABULSEBEBI1211.Value = @":";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 40, 206, 45, false);
                    NewField11.Name = "NewField11";
                    NewField11.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11.Value = @"";

                    lblKURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 46, 43, 51, false);
                    lblKURUM.Name = "lblKURUM";
                    lblKURUM.TextFont.Size = 9;
                    lblKURUM.TextFont.Bold = true;
                    lblKURUM.TextFont.CharSet = 162;
                    lblKURUM.Value = @"Sevk Eden Kurum";

                    dotsKABULSEBEBI1212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 46, 46, 51, false);
                    dotsKABULSEBEBI1212.Name = "dotsKABULSEBEBI1212";
                    dotsKABULSEBEBI1212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsKABULSEBEBI1212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsKABULSEBEBI1212.TextFont.Size = 9;
                    dotsKABULSEBEBI1212.TextFont.Bold = true;
                    dotsKABULSEBEBI1212.TextFont.CharSet = 162;
                    dotsKABULSEBEBI1212.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 46, 206, 51, false);
                    NewField12.Name = "NewField12";
                    NewField12.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField12.Value = @"";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 3, 53, 208, 53, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.DrawWidth = 2;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 3, 3, 3, 53, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 208, 3, 208, 53, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 3, 3, 208, 3, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NAME11.CalcValue = @"";
                    NAME11.PostFieldValueCalculation();
                    lblNAME11.CalcValue = lblNAME11.Value;
                    NewField30.CalcValue = @"";
                    lblUNIQUEREFNO11.CalcValue = lblUNIQUEREFNO11.Value;
                    NewField14.CalcValue = @"";
                    NewField15.CalcValue = @"";
                    lblBIRTHDATE.CalcValue = lblBIRTHDATE.Value;
                    lblSICILNO1.CalcValue = lblSICILNO1.Value;
                    lblKURUM1.CalcValue = lblKURUM1.Value;
                    NewField16.CalcValue = @"";
                    dotsDYERTAR11.CalcValue = dotsDYERTAR11.Value;
                    dotsRUTBE11.CalcValue = dotsRUTBE11.Value;
                    dotsKABULSEBEBI11.CalcValue = dotsKABULSEBEBI11.Value;
                    dotsDYERTAR111.CalcValue = dotsDYERTAR111.Value;
                    dotsRUTBE111.CalcValue = dotsRUTBE111.Value;
                    NewField17.CalcValue = @"";
                    NewField17.PostFieldValueCalculation();
                    lblDATE1.CalcValue = lblDATE1.Value;
                    NewField18.CalcValue = @"";
                    lblREPDATE.CalcValue = lblREPDATE.Value;
                    NewField19.CalcValue = @"";
                    NewField101.CalcValue = @"";
                    lblFATERNAME.CalcValue = lblFATERNAME.Value;
                    lblLNO1.CalcValue = lblLNO1.Value;
                    lblREPORTNO1.CalcValue = lblREPORTNO1.Value;
                    NewField111.CalcValue = @"";
                    dotsDYERTAR121.CalcValue = dotsDYERTAR121.Value;
                    dotsRUTBE121.CalcValue = dotsRUTBE121.Value;
                    dotsKABULSEBEBI111.CalcValue = dotsKABULSEBEBI111.Value;
                    dotsDYERTAR1111.CalcValue = dotsDYERTAR1111.Value;
                    dotsRUTBE1111.CalcValue = dotsRUTBE1111.Value;
                    lblADRESS.CalcValue = lblADRESS.Value;
                    dotsKABULSEBEBI112.CalcValue = dotsKABULSEBEBI112.Value;
                    NewField1.CalcValue = NewField1.Value;
                    lblREASON.CalcValue = lblREASON.Value;
                    dotsKABULSEBEBI1211.CalcValue = dotsKABULSEBEBI1211.Value;
                    NewField11.CalcValue = @"";
                    lblKURUM.CalcValue = lblKURUM.Value;
                    dotsKABULSEBEBI1212.CalcValue = dotsKABULSEBEBI1212.Value;
                    NewField12.CalcValue = @"";
                    return new TTReportObject[] { NAME11,lblNAME11,NewField30,lblUNIQUEREFNO11,NewField14,NewField15,lblBIRTHDATE,lblSICILNO1,lblKURUM1,NewField16,dotsDYERTAR11,dotsRUTBE11,dotsKABULSEBEBI11,dotsDYERTAR111,dotsRUTBE111,NewField17,lblDATE1,NewField18,lblREPDATE,NewField19,NewField101,lblFATERNAME,lblLNO1,lblREPORTNO1,NewField111,dotsDYERTAR121,dotsRUTBE121,dotsKABULSEBEBI111,dotsDYERTAR1111,dotsRUTBE1111,lblADRESS,dotsKABULSEBEBI112,NewField1,lblREASON,dotsKABULSEBEBI1211,NewField11,lblKURUM,dotsKABULSEBEBI1212,NewField12};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class KARARGroup : TTReportGroup
        {
            public IlacRaporu MyParentReport
            {
                get { return (IlacRaporu)ParentReport; }
            }

            new public KARARGroupBody Body()
            {
                return (KARARGroupBody)_body;
            }
            public TTReportRTF Report11 { get {return Body().Report11;} }
            public TTReportField NewField11116111 { get {return Body().NewField11116111;} }
            public TTReportField NewField1111121111 { get {return Body().NewField1111121111;} }
            public TTReportField NewField1116111 { get {return Body().NewField1116111;} }
            public TTReportField NewField111121111 { get {return Body().NewField111121111;} }
            public TTReportField ICDCode1 { get {return Body().ICDCode1;} }
            public KARARGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KARARGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new KARARGroupBody(this);
            }

            public partial class KARARGroupBody : TTReportSection
            {
                public IlacRaporu MyParentReport
                {
                    get { return (IlacRaporu)ParentReport; }
                }
                
                public TTReportRTF Report11;
                public TTReportField NewField11116111;
                public TTReportField NewField1111121111;
                public TTReportField NewField1116111;
                public TTReportField NewField111121111;
                public TTReportField ICDCode1; 
                public KARARGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 51;
                    RepeatCount = 0;
                    
                    Report11 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 5, 19, 206, 48, false);
                    Report11.Name = "Report11";
                    Report11.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                    NewField11116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 12, 21, 17, false);
                    NewField11116111.Name = "NewField11116111";
                    NewField11116111.TextFont.Size = 9;
                    NewField11116111.TextFont.Bold = true;
                    NewField11116111.TextFont.CharSet = 162;
                    NewField11116111.Value = @"KARAR                                            ";

                    NewField1111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 12, 24, 17, false);
                    NewField1111121111.Name = "NewField1111121111";
                    NewField1111121111.TextFont.Name = "Arial";
                    NewField1111121111.TextFont.Size = 9;
                    NewField1111121111.TextFont.Bold = true;
                    NewField1111121111.TextFont.CharSet = 162;
                    NewField1111121111.Value = @":";

                    NewField1116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 3, 21, 8, false);
                    NewField1116111.Name = "NewField1116111";
                    NewField1116111.TextFont.Size = 9;
                    NewField1116111.TextFont.Bold = true;
                    NewField1116111.TextFont.CharSet = 162;
                    NewField1116111.Value = @"TANI                             ";

                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 3, 24, 8, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.TextFont.Name = "Arial";
                    NewField111121111.TextFont.Size = 9;
                    NewField111121111.TextFont.Bold = true;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @":";

                    ICDCode1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 3, 206, 8, false);
                    ICDCode1.Name = "ICDCode1";
                    ICDCode1.ExpandTabs = EvetHayirEnum.ehEvet;
                    ICDCode1.TextFont.Size = 9;
                    ICDCode1.TextFont.CharSet = 162;
                    ICDCode1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Report11.CalcValue = Report11.Value;
                    NewField11116111.CalcValue = NewField11116111.Value;
                    NewField1111121111.CalcValue = NewField1111121111.Value;
                    NewField1116111.CalcValue = NewField1116111.Value;
                    NewField111121111.CalcValue = NewField111121111.Value;
                    ICDCode1.CalcValue = ICDCode1.Value;
                    return new TTReportObject[] { Report11,NewField11116111,NewField1111121111,NewField1116111,NewField111121111,ICDCode1};
                }
            }

        }

        public KARARGroup KARAR;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public IlacRaporu()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            KARAR = new KARARGroup(HEADER,"KARAR");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "ILACRAPORU";
            Caption = "IlacRaporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}