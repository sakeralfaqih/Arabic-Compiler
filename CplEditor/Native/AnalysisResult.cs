using System;
using System.Collections.Generic;

// (ملاحظة: سنحتاج إلى تثبيت حزمة NuGet تسمى "Newtonsoft.Json"
//  بنفس الطريقة التي ثبتنا بها ScintillaNET.
//  هذه الحزمة هي أشهر مكتبة للتعامل مع JSON في .NET)

namespace CplEditor.Native
{
    // هذا الكلاس يطابق كائن الخطأ الواحد في الـ JSON
    public class CompilationError
    {
        public int line { get; set; }
        public string message { get; set; }
    }

    // هذا الكلاس يطابق الـ JSON "الجذري" بالكامل
    public class AnalysisResult
    {
        public bool success { get; set; }
        public string message { get; set; } // رسالة النجاح
        public List<CompilationError> errors { get; set; }
    }
}