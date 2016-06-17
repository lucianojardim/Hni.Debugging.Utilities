namespace Hni.Debugging.Data.Capture.Areas.HelpPage.ModelDescriptions
{
    public class KeyValuePairModelDescription : ModelDescription
    {
        public ModelDescription KeyModelDescription { get; set; }

        public ModelDescription ValueModelDescription { get; set; }
    }
}