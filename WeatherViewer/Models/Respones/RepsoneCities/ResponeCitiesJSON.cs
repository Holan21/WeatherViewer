
namespace WetherViewer.Models.Respones.RepsoneCities
{
    internal class ResponeCitiesJSON 
    {
        public bool error { get; set; } = true;
        public string msg { get; set; } = string.Empty;

        public string getMsg() { return msg; }

        public bool getError() { return error; }
        public object[] data { get; set; } = new object[0];

        public object[] getData() { return data; }
    }
}
