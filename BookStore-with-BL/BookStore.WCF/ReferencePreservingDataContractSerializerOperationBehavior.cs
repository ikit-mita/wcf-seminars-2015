using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel.Description;
using System.Xml;

namespace BookStore.WCF
{
    public class ReferencePreservingDataContractSerializerOperationBehavior : DataContractSerializerOperationBehavior
    {
        public ReferencePreservingDataContractSerializerOperationBehavior(OperationDescription operationDescription)
            : base(operationDescription)
        {
        }

        public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns, IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, knownTypes,
                0x7FFF /*maxItemsInObjectGraph*/,
                false /*ignoreExtensionDataObject*/,
                true /*preserveObjectReferences*/,
                null /*dataContractSurrogate*/);
        }

        public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, knownTypes,
                0x7FFF /*maxItemsInObjectGraph*/,
                false /*ignoreExtensionDataObject*/,
                true /*preserveObjectReferences*/,
                null /*dataContractSurrogate*/);
        }
    }
}