using AAR = Autodesk.AutoCAD.Runtime;

namespace MySweetApp.AutoCAD
{
    public class EntryPoint_Model : AAR.IExtensionApplication
    {
        public void Initialize()
        {
            try
            {
                Bootstrapper.Instance.Run();
            }
            catch { }
        }

        public void Terminate()
        {
        }
    }
}