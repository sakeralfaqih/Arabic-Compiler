using System.Runtime.InteropServices;
using System.Text;

namespace CplEditor.Native
{
    public static class CompilerApi
    {
        // اسم الـ DLL (يجب أن يكون في نفس مجلد ملف EXE)
        private const string DllName = "ColCompiler.dll";

        // هذا هو التعريف السحري الذي يربط C# بـ C++
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public static extern string analyze_w(string input);

        // (ملاحظة: C# ستفهم أن عليها تحرير الذاكرة
        //  التي حجزتها CoTaskMemAlloc تلقائياً بسبب [MarshalAs])
    }
}