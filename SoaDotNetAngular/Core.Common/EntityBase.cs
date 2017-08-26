using System.Runtime.Serialization;

namespace Core.Common
{
    [DataContract]
    public class EntityBase : IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
