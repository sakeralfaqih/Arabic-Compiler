using System;
using System.Drawing;
using System.Windows.Forms;
using CplEditor.Editor;       // لاستخدام ScintillaConfig
using CplEditor.Native;      // لاستخدام CompilerApi و AnalysisResult
using Newtonsoft.Json;       // لاستخدام JsonConvert
using ScintillaNET;
using System.IO; // (لأجل دوال الفتح والحفظ)

namespace CplEditor
{
    // لاحظ أن الكلاس يرث من Form واسمه Form1
    public partial class Form1 : Form
    {
        // متغير لتخزين مسار الملف المفتوح حالياً
        private string currentFilePath = null;

        public Form1()
        {
            // هذه الدالة هي التي تشغل الكود في "Form1.Designer.cs"
            // لبناء الواجهة التي صممناها بالكود
            InitializeComponent();

            // الآن بعد أن تم بناء الواجهة، نقوم بتشغيل إعداداتنا الإضافية
            InitializeEditor();
            InitializeMainMenu(); // دالة جديدة لإضافة القوائم بالكود
        }

        // --- 1. دالة الإعداد الخاصة بنا ---
        private void InitializeEditor()
        {
            // الأهم: استدعاء ملف الإعداد المذهل
            // "this.EditorControl" تم إنشاؤه في Form1.Designer.cs
            ScintillaConfig.Configure(this.EditorControl);

            // ربط "حدث" تغيير النص لتطبيق التلوين
            this.EditorControl.TextChanged += (sender, e) => {
                ScintillaConfig.ApplyLexer(this.EditorControl);
            };

            // ربط "حدث" النقر على زر التحليل
            // "this.AnalyzeButton" تم إنشاؤه في Form1.Designer.cs
            this.AnalyzeButton.Click += AnalyzeButton_Click;
        }

        // --- 2. دالة بناء القائمة العلوية (Menu) بالكود ---
        private void InitializeMainMenu()
        {
            // --- قائمة "ملف" ---
            var fileMenu = new ToolStripMenuItem("ملف");
            fileMenu.DropDownItems.Add("جديد (New)", null, (s, e) => NewFile());
            fileMenu.DropDownItems.Add("فتح (Open)", null, (s, e) => OpenFile());
            fileMenu.DropDownItems.Add("حفظ (Save)", null, (s, e) => SaveFile());
            fileMenu.DropDownItems.Add("حفظ باسم (Save As)", null, (s, e) => SaveFileAs());
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add("خروج (Exit)", null, (s, e) => Application.Exit());
            this.MainMenuStrip.Items.Add(fileMenu);

            // --- قائمة "تحرير" (يمكن إضافة المزيد) ---
            var editMenu = new ToolStripMenuItem("تحرير");
            editMenu.DropDownItems.Add("تراجع (Undo)", null, (s, e) => this.EditorControl.Undo());
            editMenu.DropDownItems.Add("إعادة (Redo)", null, (s, e) => this.EditorControl.Redo());
            editMenu.DropDownItems.Add(new ToolStripSeparator());
            editMenu.DropDownItems.Add("قص (Cut)", null, (s, e) => this.EditorControl.Cut());
            editMenu.DropDownItems.Add("نسخ (Copy)", null, (s, e) => this.EditorControl.Copy());
            editMenu.DropDownItems.Add("لصق (Paste)", null, (s, e) => this.EditorControl.Paste());
            this.MainMenuStrip.Items.Add(editMenu);
        }

        // --- 3. دالة "التحليل" (الإبداع الحقيقي) ---
        private void AnalyzeButton_Click(object sender, EventArgs e)
        {
            // 1. احصل على الكود من المحرر
            string code = EditorControl.Text;

            // 2. امسح الأخطاء القديمة (من المحرر ومن الجدول)
            ScintillaConfig.ClearAllErrorIndicators(EditorControl);
            ErrorGridView.Rows.Clear(); // "ErrorGridView" تم إنشاؤه في Designer.cs

            try
            {
                // 3. استدعاء الجسر (C++) واستقبال الـ JSON
                string jsonResult = CompilerApi.analyze_w(code);

                // 4. فك ضغط الـ JSON باستخدام Newtonsoft
                AnalysisResult result = JsonConvert.DeserializeObject<AnalysisResult>(jsonResult);
              
                // 5. تحقق من النتيجة
                if (result.success)
                {
                    
                    // نجاح!
                    // نعرض رسالة النجاح في لوحة الأخطاء بلون أخضر
                    ErrorGridView.Rows.Add(null, result.message);
                    ErrorGridView.Rows.Add(null, jsonResult);
                    ErrorGridView.Rows[0].DefaultCellStyle.ForeColor = Color.Green;
                }
                else
                {
                    // فشل! عرض الأخطاء (هذا هو الإبداع)
                    foreach (var error in result.errors)
                    {
                        // أ) أضف الخطأ إلى الجدول في الأسفل
                        ErrorGridView.Rows.Add(error.line, error.message);

                        // ب) أضف "خط أحمر متعرج" إلى المحرر
                        ScintillaConfig.AddErrorIndicator(EditorControl, error.line);
                    }
                }
            }
            catch (DllNotFoundException)
            {
                ErrorGridView.Rows.Add(0, "خطأ فادح: لم يتم العثور على ملف CplCompiler.dll");
                ScintillaConfig.AddErrorIndicator(EditorControl, 1);
            }
            catch (Exception ex)
            {
                ErrorGridView.Rows.Add(0, "خطأ غير متوقع: " + ex.Message);
                ScintillaConfig.AddErrorIndicator(EditorControl, 1);
            }
        }

        // --- 4. دوال قائمة "ملف" ---
        private void NewFile()
        {
            EditorControl.Text = string.Empty;
            currentFilePath = null;
            this.Text = "محرر CPL - ملف جديد";
        }

        private void OpenFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "ملفات CPL (*.cpl)|*.cpl|كل الملفات (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = ofd.FileName;
                    EditorControl.Text = File.ReadAllText(currentFilePath);
                    this.Text = "محرر CPL - " + Path.GetFileName(currentFilePath);
                }
            }
        }

        private void SaveFile()
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveFileAs(); // إذا كان ملفاً جديداً، اطلب "حفظ باسم"
            }
            else
            {
                File.WriteAllText(currentFilePath, EditorControl.Text);
                this.Text = "محرر CPL - " + Path.GetFileName(currentFilePath);
            }
        }

        private void SaveFileAs()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "ملفات CPL (*.cpl)|*.cpl|كل الملفات (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = sfd.FileName;
                    File.WriteAllText(currentFilePath, EditorControl.Text);
                    this.Text = "محرر CPL - " + Path.GetFileName(currentFilePath);
                }
            }
        }
    }
}