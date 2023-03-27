
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
    /// Durum Bildirir Rapor
    /// </summary>
    public partial class DurumBildirirRapor : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public DurumBildirirRapor MyParentReport
            {
                get { return (DurumBildirirRapor)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField HOSPITALNAME { get {return Header().HOSPITALNAME;} }
            public TTReportField REPORTHEADER { get {return Header().REPORTHEADER;} }
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
                public DurumBildirirRapor MyParentReport
                {
                    get { return (DurumBildirirRapor)ParentReport; }
                }
                
                public TTReportField HOSPITALNAME;
                public TTReportField REPORTHEADER; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 44;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 10, 170, 33, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.TextFont.Size = 11;
                    HOSPITALNAME.TextFont.Bold = true;
                    HOSPITALNAME.TextFont.CharSet = 162;
                    HOSPITALNAME.Value = @"XXXXXXADI";

                    REPORTHEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 32, 170, 39, false);
                    REPORTHEADER.Name = "REPORTHEADER";
                    REPORTHEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTHEADER.TextFont.Size = 12;
                    REPORTHEADER.TextFont.Bold = true;
                    REPORTHEADER.TextFont.CharSet = 162;
                    REPORTHEADER.Value = @"DURUM BİLDİRİR RAPOR";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HOSPITALNAME.CalcValue = HOSPITALNAME.Value;
                    REPORTHEADER.CalcValue = REPORTHEADER.Value;
                    return new TTReportObject[] { HOSPITALNAME,REPORTHEADER};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public DurumBildirirRapor MyParentReport
                {
                    get { return (DurumBildirirRapor)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public DurumBildirirRapor MyParentReport
            {
                get { return (DurumBildirirRapor)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportField NAME1 { get {return Body().NAME1;} }
            public TTReportField lblNAME1 { get {return Body().lblNAME1;} }
            public TTReportField UNIQUEREFNO1 { get {return Body().UNIQUEREFNO1;} }
            public TTReportField lblUNIQUEREFNO1 { get {return Body().lblUNIQUEREFNO1;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField lblSOSYALGUV { get {return Body().lblSOSYALGUV;} }
            public TTReportField lblSICILNO { get {return Body().lblSICILNO;} }
            public TTReportField lblKURUM { get {return Body().lblKURUM;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField dotsDYERTAR1 { get {return Body().dotsDYERTAR1;} }
            public TTReportField dotsRUTBE1 { get {return Body().dotsRUTBE1;} }
            public TTReportField dotsKABULSEBEBI1 { get {return Body().dotsKABULSEBEBI1;} }
            public TTReportField dotsDYERTAR11 { get {return Body().dotsDYERTAR11;} }
            public TTReportField dotsRUTBE11 { get {return Body().dotsRUTBE11;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField lblDATE { get {return Body().lblDATE;} }
            public TTReportField NewField8 { get {return Body().NewField8;} }
            public TTReportField lblID { get {return Body().lblID;} }
            public TTReportField NewField9 { get {return Body().NewField9;} }
            public TTReportField NewField10 { get {return Body().NewField10;} }
            public TTReportField lblCLINIC { get {return Body().lblCLINIC;} }
            public TTReportField lblPROTOCOLNO { get {return Body().lblPROTOCOLNO;} }
            public TTReportField lblREPORTNO { get {return Body().lblREPORTNO;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField dotsDYERTAR12 { get {return Body().dotsDYERTAR12;} }
            public TTReportField dotsRUTBE12 { get {return Body().dotsRUTBE12;} }
            public TTReportField dotsKABULSEBEBI11 { get {return Body().dotsKABULSEBEBI11;} }
            public TTReportField dotsDYERTAR111 { get {return Body().dotsDYERTAR111;} }
            public TTReportField dotsRUTBE111 { get {return Body().dotsRUTBE111;} }
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
                public DurumBildirirRapor MyParentReport
                {
                    get { return (DurumBildirirRapor)ParentReport; }
                }
                
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportField NAME1;
                public TTReportField lblNAME1;
                public TTReportField UNIQUEREFNO1;
                public TTReportField lblUNIQUEREFNO1;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField lblSOSYALGUV;
                public TTReportField lblSICILNO;
                public TTReportField lblKURUM;
                public TTReportField NewField6;
                public TTReportField dotsDYERTAR1;
                public TTReportField dotsRUTBE1;
                public TTReportField dotsKABULSEBEBI1;
                public TTReportField dotsDYERTAR11;
                public TTReportField dotsRUTBE11;
                public TTReportShape NewLine3;
                public TTReportField NewField7;
                public TTReportField lblDATE;
                public TTReportField NewField8;
                public TTReportField lblID;
                public TTReportField NewField9;
                public TTReportField NewField10;
                public TTReportField lblCLINIC;
                public TTReportField lblPROTOCOLNO;
                public TTReportField lblREPORTNO;
                public TTReportField NewField11;
                public TTReportField dotsDYERTAR12;
                public TTReportField dotsRUTBE12;
                public TTReportField dotsKABULSEBEBI11;
                public TTReportField dotsDYERTAR111;
                public TTReportField dotsRUTBE111; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 48;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 11, 204, 11, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 11, 5, 45, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 4, 155, 9, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Medula Takip No";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 4, 156, 9, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @":";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 4, 187, 9, false);
                    NewField3.Name = "NewField3";
                    NewField3.Value = @"NewField3";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 45, 204, 45, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 204, 11, 204, 46, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 14, 113, 19, false);
                    NAME1.Name = "NAME1";
                    NAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME1.ObjectDefName = "RadiologyTest";
                    NAME1.DataMember = "EPISODE.PATIENT.FullName";
                    NAME1.TextFont.Size = 9;
                    NAME1.TextFont.CharSet = 162;
                    NAME1.Value = @"";

                    lblNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 14, 45, 19, false);
                    lblNAME1.Name = "lblNAME1";
                    lblNAME1.TextFont.Size = 9;
                    lblNAME1.TextFont.Bold = true;
                    lblNAME1.TextFont.CharSet = 162;
                    lblNAME1.Value = @"Adı Soyadı";

                    UNIQUEREFNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 20, 113, 25, false);
                    UNIQUEREFNO1.Name = "UNIQUEREFNO1";
                    UNIQUEREFNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNIQUEREFNO1.TextFont.Size = 9;
                    UNIQUEREFNO1.TextFont.CharSet = 162;
                    UNIQUEREFNO1.Value = @"";

                    lblUNIQUEREFNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 20, 45, 25, false);
                    lblUNIQUEREFNO1.Name = "lblUNIQUEREFNO1";
                    lblUNIQUEREFNO1.TextFont.Size = 9;
                    lblUNIQUEREFNO1.TextFont.Bold = true;
                    lblUNIQUEREFNO1.TextFont.CharSet = 162;
                    lblUNIQUEREFNO1.Value = @"T.C. Kimlik No";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 32, 113, 37, false);
                    NewField4.Name = "NewField4";
                    NewField4.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Size = 9;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 38, 113, 43, false);
                    NewField5.Name = "NewField5";
                    NewField5.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Size = 9;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"";

                    lblSOSYALGUV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 26, 45, 31, false);
                    lblSOSYALGUV.Name = "lblSOSYALGUV";
                    lblSOSYALGUV.TextFont.Size = 9;
                    lblSOSYALGUV.TextFont.Bold = true;
                    lblSOSYALGUV.TextFont.CharSet = 162;
                    lblSOSYALGUV.Value = @"Sosyal Güv.";

                    lblSICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 32, 45, 37, false);
                    lblSICILNO.Name = "lblSICILNO";
                    lblSICILNO.TextFont.Size = 9;
                    lblSICILNO.TextFont.Bold = true;
                    lblSICILNO.TextFont.CharSet = 162;
                    lblSICILNO.Value = @"Sicil No";

                    lblKURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 38, 45, 43, false);
                    lblKURUM.Name = "lblKURUM";
                    lblKURUM.TextFont.Size = 9;
                    lblKURUM.TextFont.Bold = true;
                    lblKURUM.TextFont.CharSet = 162;
                    lblKURUM.Value = @"Çalıştığı Kurum";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 26, 113, 31, false);
                    NewField6.Name = "NewField6";
                    NewField6.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Size = 9;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"";

                    dotsDYERTAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 26, 47, 31, false);
                    dotsDYERTAR1.Name = "dotsDYERTAR1";
                    dotsDYERTAR1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsDYERTAR1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsDYERTAR1.TextFont.Size = 9;
                    dotsDYERTAR1.TextFont.Bold = true;
                    dotsDYERTAR1.TextFont.CharSet = 162;
                    dotsDYERTAR1.Value = @":";

                    dotsRUTBE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 32, 47, 37, false);
                    dotsRUTBE1.Name = "dotsRUTBE1";
                    dotsRUTBE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsRUTBE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsRUTBE1.TextFont.Size = 9;
                    dotsRUTBE1.TextFont.Bold = true;
                    dotsRUTBE1.TextFont.CharSet = 162;
                    dotsRUTBE1.Value = @":";

                    dotsKABULSEBEBI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 38, 47, 43, false);
                    dotsKABULSEBEBI1.Name = "dotsKABULSEBEBI1";
                    dotsKABULSEBEBI1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsKABULSEBEBI1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsKABULSEBEBI1.TextFont.Size = 9;
                    dotsKABULSEBEBI1.TextFont.Bold = true;
                    dotsKABULSEBEBI1.TextFont.CharSet = 162;
                    dotsKABULSEBEBI1.Value = @":";

                    dotsDYERTAR11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 14, 47, 19, false);
                    dotsDYERTAR11.Name = "dotsDYERTAR11";
                    dotsDYERTAR11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsDYERTAR11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsDYERTAR11.TextFont.Size = 9;
                    dotsDYERTAR11.TextFont.Bold = true;
                    dotsDYERTAR11.TextFont.CharSet = 162;
                    dotsDYERTAR11.Value = @":";

                    dotsRUTBE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 20, 47, 25, false);
                    dotsRUTBE11.Name = "dotsRUTBE11";
                    dotsRUTBE11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsRUTBE11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsRUTBE11.TextFont.Size = 9;
                    dotsRUTBE11.TextFont.Bold = true;
                    dotsRUTBE11.TextFont.CharSet = 162;
                    dotsRUTBE11.Value = @":";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 114, 11, 114, 45, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 14, 203, 19, false);
                    NewField7.Name = "NewField7";
                    NewField7.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.ObjectDefName = "RadiologyTest";
                    NewField7.DataMember = "EPISODE.PATIENT.FullName";
                    NewField7.TextFont.Size = 9;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"";

                    lblDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 14, 153, 19, false);
                    lblDATE.Name = "lblDATE";
                    lblDATE.TextFont.Size = 9;
                    lblDATE.TextFont.Bold = true;
                    lblDATE.TextFont.CharSet = 162;
                    lblDATE.Value = @"Muayene Tar.";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 20, 203, 25, false);
                    NewField8.Name = "NewField8";
                    NewField8.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Size = 9;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"";

                    lblID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 20, 153, 25, false);
                    lblID.Name = "lblID";
                    lblID.TextFont.Size = 9;
                    lblID.TextFont.Bold = true;
                    lblID.TextFont.CharSet = 162;
                    lblID.Value = @"Bil. İşlem No.";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 32, 203, 37, false);
                    NewField9.Name = "NewField9";
                    NewField9.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.TextFont.Size = 9;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 38, 203, 43, false);
                    NewField10.Name = "NewField10";
                    NewField10.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Size = 9;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @"";

                    lblCLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 26, 153, 31, false);
                    lblCLINIC.Name = "lblCLINIC";
                    lblCLINIC.TextFont.Size = 9;
                    lblCLINIC.TextFont.Bold = true;
                    lblCLINIC.TextFont.CharSet = 162;
                    lblCLINIC.Value = @"Pol/Klinik";

                    lblPROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 32, 153, 37, false);
                    lblPROTOCOLNO.Name = "lblPROTOCOLNO";
                    lblPROTOCOLNO.TextFont.Size = 9;
                    lblPROTOCOLNO.TextFont.Bold = true;
                    lblPROTOCOLNO.TextFont.CharSet = 162;
                    lblPROTOCOLNO.Value = @"Protokol Defter No";

                    lblREPORTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 38, 153, 43, false);
                    lblREPORTNO.Name = "lblREPORTNO";
                    lblREPORTNO.TextFont.Size = 9;
                    lblREPORTNO.TextFont.Bold = true;
                    lblREPORTNO.TextFont.CharSet = 162;
                    lblREPORTNO.Value = @"Rapor No";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 26, 203, 31, false);
                    NewField11.Name = "NewField11";
                    NewField11.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"";

                    dotsDYERTAR12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 26, 155, 31, false);
                    dotsDYERTAR12.Name = "dotsDYERTAR12";
                    dotsDYERTAR12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsDYERTAR12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsDYERTAR12.TextFont.Size = 9;
                    dotsDYERTAR12.TextFont.Bold = true;
                    dotsDYERTAR12.TextFont.CharSet = 162;
                    dotsDYERTAR12.Value = @":";

                    dotsRUTBE12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 32, 155, 37, false);
                    dotsRUTBE12.Name = "dotsRUTBE12";
                    dotsRUTBE12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsRUTBE12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsRUTBE12.TextFont.Size = 9;
                    dotsRUTBE12.TextFont.Bold = true;
                    dotsRUTBE12.TextFont.CharSet = 162;
                    dotsRUTBE12.Value = @":";

                    dotsKABULSEBEBI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 38, 155, 43, false);
                    dotsKABULSEBEBI11.Name = "dotsKABULSEBEBI11";
                    dotsKABULSEBEBI11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsKABULSEBEBI11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsKABULSEBEBI11.TextFont.Size = 9;
                    dotsKABULSEBEBI11.TextFont.Bold = true;
                    dotsKABULSEBEBI11.TextFont.CharSet = 162;
                    dotsKABULSEBEBI11.Value = @":";

                    dotsDYERTAR111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 14, 155, 19, false);
                    dotsDYERTAR111.Name = "dotsDYERTAR111";
                    dotsDYERTAR111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsDYERTAR111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsDYERTAR111.TextFont.Size = 9;
                    dotsDYERTAR111.TextFont.Bold = true;
                    dotsDYERTAR111.TextFont.CharSet = 162;
                    dotsDYERTAR111.Value = @":";

                    dotsRUTBE111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 20, 155, 25, false);
                    dotsRUTBE111.Name = "dotsRUTBE111";
                    dotsRUTBE111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsRUTBE111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsRUTBE111.TextFont.Size = 9;
                    dotsRUTBE111.TextFont.Bold = true;
                    dotsRUTBE111.TextFont.CharSet = 162;
                    dotsRUTBE111.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NAME1.CalcValue = @"";
                    NAME1.PostFieldValueCalculation();
                    lblNAME1.CalcValue = lblNAME1.Value;
                    UNIQUEREFNO1.CalcValue = @"";
                    lblUNIQUEREFNO1.CalcValue = lblUNIQUEREFNO1.Value;
                    NewField4.CalcValue = @"";
                    NewField5.CalcValue = @"";
                    lblSOSYALGUV.CalcValue = lblSOSYALGUV.Value;
                    lblSICILNO.CalcValue = lblSICILNO.Value;
                    lblKURUM.CalcValue = lblKURUM.Value;
                    NewField6.CalcValue = @"";
                    dotsDYERTAR1.CalcValue = dotsDYERTAR1.Value;
                    dotsRUTBE1.CalcValue = dotsRUTBE1.Value;
                    dotsKABULSEBEBI1.CalcValue = dotsKABULSEBEBI1.Value;
                    dotsDYERTAR11.CalcValue = dotsDYERTAR11.Value;
                    dotsRUTBE11.CalcValue = dotsRUTBE11.Value;
                    NewField7.CalcValue = @"";
                    NewField7.PostFieldValueCalculation();
                    lblDATE.CalcValue = lblDATE.Value;
                    NewField8.CalcValue = @"";
                    lblID.CalcValue = lblID.Value;
                    NewField9.CalcValue = @"";
                    NewField10.CalcValue = @"";
                    lblCLINIC.CalcValue = lblCLINIC.Value;
                    lblPROTOCOLNO.CalcValue = lblPROTOCOLNO.Value;
                    lblREPORTNO.CalcValue = lblREPORTNO.Value;
                    NewField11.CalcValue = @"";
                    dotsDYERTAR12.CalcValue = dotsDYERTAR12.Value;
                    dotsRUTBE12.CalcValue = dotsRUTBE12.Value;
                    dotsKABULSEBEBI11.CalcValue = dotsKABULSEBEBI11.Value;
                    dotsDYERTAR111.CalcValue = dotsDYERTAR111.Value;
                    dotsRUTBE111.CalcValue = dotsRUTBE111.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField3,NAME1,lblNAME1,UNIQUEREFNO1,lblUNIQUEREFNO1,NewField4,NewField5,lblSOSYALGUV,lblSICILNO,lblKURUM,NewField6,dotsDYERTAR1,dotsRUTBE1,dotsKABULSEBEBI1,dotsDYERTAR11,dotsRUTBE11,NewField7,lblDATE,NewField8,lblID,NewField9,NewField10,lblCLINIC,lblPROTOCOLNO,lblREPORTNO,NewField11,dotsDYERTAR12,dotsRUTBE12,dotsKABULSEBEBI11,dotsDYERTAR111,dotsRUTBE111};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class KARARGroup : TTReportGroup
        {
            public DurumBildirirRapor MyParentReport
            {
                get { return (DurumBildirirRapor)ParentReport; }
            }

            new public KARARGroupBody Body()
            {
                return (KARARGroupBody)_body;
            }
            public TTReportRTF Report1 { get {return Body().Report1;} }
            public TTReportField NewField1116111 { get {return Body().NewField1116111;} }
            public TTReportField NewField111121111 { get {return Body().NewField111121111;} }
            public TTReportField NewField111611 { get {return Body().NewField111611;} }
            public TTReportField NewField11112111 { get {return Body().NewField11112111;} }
            public TTReportField ICDCode { get {return Body().ICDCode;} }
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
                public DurumBildirirRapor MyParentReport
                {
                    get { return (DurumBildirirRapor)ParentReport; }
                }
                
                public TTReportRTF Report1;
                public TTReportField NewField1116111;
                public TTReportField NewField111121111;
                public TTReportField NewField111611;
                public TTReportField NewField11112111;
                public TTReportField ICDCode; 
                public KARARGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 53;
                    RepeatCount = 0;
                    
                    Report1 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 6, 21, 204, 50, false);
                    Report1.Name = "Report1";
                    Report1.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                    NewField1116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 14, 22, 19, false);
                    NewField1116111.Name = "NewField1116111";
                    NewField1116111.TextFont.Size = 9;
                    NewField1116111.TextFont.Bold = true;
                    NewField1116111.TextFont.CharSet = 162;
                    NewField1116111.Value = @"KARAR                                            ";

                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 14, 25, 19, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.TextFont.Name = "Arial";
                    NewField111121111.TextFont.Size = 9;
                    NewField111121111.TextFont.Bold = true;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @":";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 5, 22, 10, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.TextFont.Size = 9;
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"TANI                             ";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 5, 25, 10, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.TextFont.Name = "Arial";
                    NewField11112111.TextFont.Size = 9;
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @":";

                    ICDCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 5, 204, 10, false);
                    ICDCode.Name = "ICDCode";
                    ICDCode.ExpandTabs = EvetHayirEnum.ehEvet;
                    ICDCode.TextFont.Size = 9;
                    ICDCode.TextFont.CharSet = 162;
                    ICDCode.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Report1.CalcValue = Report1.Value;
                    NewField1116111.CalcValue = NewField1116111.Value;
                    NewField111121111.CalcValue = NewField111121111.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    ICDCode.CalcValue = ICDCode.Value;
                    return new TTReportObject[] { Report1,NewField1116111,NewField111121111,NewField111611,NewField11112111,ICDCode};
                }
            }

        }

        public KARARGroup KARAR;

        public partial class LetterFooterGroup : TTReportGroup
        {
            public DurumBildirirRapor MyParentReport
            {
                get { return (DurumBildirirRapor)ParentReport; }
            }

            new public LetterFooterGroupBody Body()
            {
                return (LetterFooterGroupBody)_body;
            }
            public TTReportField NewField111261111 { get {return Body().NewField111261111;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField111361111 { get {return Body().NewField111361111;} }
            public LetterFooterGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public LetterFooterGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new LetterFooterGroupBody(this);
            }

            public partial class LetterFooterGroupBody : TTReportSection
            {
                public DurumBildirirRapor MyParentReport
                {
                    get { return (DurumBildirirRapor)ParentReport; }
                }
                
                public TTReportField NewField111261111;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField111361111; 
                public LetterFooterGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 34;
                    RepeatCount = 0;
                    
                    NewField111261111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 5, 55, 10, false);
                    NewField111261111.Name = "NewField111261111";
                    NewField111261111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111261111.TextFont.Bold = true;
                    NewField111261111.TextFont.CharSet = 162;
                    NewField111261111.Value = @"Hekim - Kaşe - İmza";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 12, 91, 27, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 12, 204, 27, false);
                    NewField2.Name = "NewField2";
                    NewField2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"";

                    NewField111361111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 3, 165, 9, false);
                    NewField111361111.Name = "NewField111361111";
                    NewField111361111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111361111.TextFont.Bold = true;
                    NewField111361111.TextFont.CharSet = 162;
                    NewField111361111.Value = @"XXXXXX YÖNETİCİSİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111261111.CalcValue = NewField111261111.Value;
                    NewField1.CalcValue = @"";
                    NewField2.CalcValue = @"";
                    NewField111361111.CalcValue = NewField111361111.Value;
                    return new TTReportObject[] { NewField111261111,NewField1,NewField2,NewField111361111};
                }
            }

        }

        public LetterFooterGroup LetterFooter;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DurumBildirirRapor()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            KARAR = new KARARGroup(HEADER,"KARAR");
            LetterFooter = new LetterFooterGroup(HEADER,"LetterFooter");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "DURUMBILDIRIRRAPOR";
            Caption = "Durum Bildirir Rapor";
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