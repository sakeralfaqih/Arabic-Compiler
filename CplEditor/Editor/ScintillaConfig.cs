using ScintillaNET;
using System.Drawing;
using System.Windows.Forms;

namespace CplEditor.Editor
{
    public static class ScintillaConfig
    {
        // تعريف "أرقام" لكل نمط (Style)
        // هذه الأرقام هي التي سنستخدمها لتعريف الألوان
        private const int STYLE_DEFAULT = 0;
        private const int STYLE_KEYWORD = 1;
        private const int STYLE_IDENTIFIER = 2;
        private const int STYLE_NUMBER = 3;
        private const int STYLE_STRING = 4;
        private const int STYLE_COMMENT = 5;
        private const int STYLE_OPERATOR = 6;

        // تعريف "رقم" خاص للخط الأحمر المتعرج
        private const int INDICATOR_SQUIGGLY = 8;

        public static void Configure(Scintilla editor)
        {
            // --- 1. إعدادات المحرر الأساسية (الشكل العام) ---
            editor.Dock = DockStyle.Fill;
            editor.WrapMode = WrapMode.None; // عدم التفاف الأسطر
            editor.IndentationGuides = IndentView.LookBoth; // إظهار خطوط المسافات البادئة
            // --- 2. إعدادات أرقام الأسطر (Line Numbers) ---
            editor.Margins[0].Width = 40; // عرض هامش أرقام الأسطر
            editor.Margins[0].Type = MarginType.Number;
            editor.Styles[Style.LineNumber].Font = "Consolas";
            editor.Styles[Style.LineNumber].Size = 10;
            editor.Styles[Style.LineNumber].ForeColor = Color.DarkGray;

            // --- 3. تعريف "علامة الخطأ" (الخط الأحمر المتعرج) ---
            editor.Indicators[INDICATOR_SQUIGGLY].Style = IndicatorStyle.Squiggle;
            editor.Indicators[INDICATOR_SQUIGGLY].ForeColor = Color.Red;

            // --- 4. تعريف الأنماط والألوان (Syntax Highlighting) ---

            // النمط الافتراضي (النص العادي)
            editor.Styles[STYLE_DEFAULT].Font = "Consolas";
            editor.Styles[STYLE_DEFAULT].Size = 12;
            editor.Styles[STYLE_DEFAULT].ForeColor = Color.Black;
            editor.Styles[STYLE_DEFAULT].BackColor = Color.White;
            editor.StyleClearAll(); // تطبيق النمط الافتراضي على الكل

            // الكلمات المفتاحية (مثل: برنامج, اذا, ثابت)
            editor.Styles[STYLE_KEYWORD].ForeColor = Color.Blue;
            editor.Styles[STYLE_KEYWORD].Bold = true;

            // الأسماء (Identifiers) (مثل: س, المجموع)
            editor.Styles[STYLE_IDENTIFIER].ForeColor = Color.Black;

            // الأرقام (مثل: 5, 3.14)
            editor.Styles[STYLE_NUMBER].ForeColor = Color.DarkGreen;

            // النصوص (مثل: "مرحبا")
            editor.Styles[STYLE_STRING].ForeColor = Color.Brown;

            // التعليقات (مثل: // تعليق)
            editor.Styles[STYLE_COMMENT].ForeColor = Color.Green;

            // المعاملات (مثل: +, =, >)
            editor.Styles[STYLE_OPERATOR].ForeColor = Color.DarkRed;
            editor.Styles[STYLE_OPERATOR].Bold = true;

            // --- 5. تعريف "الـ Lexer" الخاص بنا ---
            // Scintilla لا تعرف لغتك العربية، لذا سنستخدم "Lexer بسيط"
            // مبني على الكلمات المفتاحية

            // قائمة الكلمات المفتاحية (يجب أن تطابق C++)
            string keywords = "برنامج ثابت نوع متغير اجراء دالة ارجع " +
                              "قائمة سجل من اقرا اطبع اذا فان والا " +
                              "كرر الى طالما اعد حتى اضف بالقيمة بالمرجع " +
                              "صحيح حقيقي منطقي حرفي خيط_رمزي بلا صح خطأ";

            // "lexer" هو اسم النمط الذي سنستخدمه
            editor.SetKeywords(0, keywords);

            // (هذه خطوة متقدمة، سنقوم بتفعيل التلوين عند تغيير النص)
            // سنربطها في MainForm.cs
        }

        // دالة مساعدة لتطبيق التلوين
        public static void ApplyLexer(Scintilla editor)
        {
            // Scintilla تحتوي على "Lexer" بسيط جداً. سنستخدمه.
            // هذا الـ Lexer (Container) يقوم بتلوين كل شيء بناءً على
            // ما إذا كان (Default, Comment, Number, String, Keyword, Identifier)

            //editor.LexerName = "container";

            // أخبر Scintilla أن الكلمات المفتاحية (التي عرفناها أعلاه)
            // يجب أن تأخذ النمط رقم 1 (STYLE_KEYWORD)
            editor.SetProperty("lexer.cpp.keywords.index.0", "0");

            // (هذا الكود يمر على النص ويطبق الأنماط - متقدم قليلاً)
            editor.Colorize(0, -1);
        }

        // دالة مساعدة لمسح كل علامات الأخطاء
        public static void ClearAllErrorIndicators(Scintilla editor)
        {
            editor.IndicatorClearRange(0, editor.TextLength);
        }

        // دالة مساعدة لوضع "خط أحمر متعرج"
        public static void AddErrorIndicator(Scintilla editor, int line)
        {
            if (line <= 0 || line > editor.Lines.Count) return;

            var currentLine = editor.Lines[line - 1]; // (ناقص 1 لأن Scintilla تبدأ من 0)
            int startPosition = currentLine.Position;
            int length = currentLine.Length;

            // تطبيق علامة الخطأ على السطر بأكمله
            editor.IndicatorFillRange(startPosition, length);
        }
    }
}