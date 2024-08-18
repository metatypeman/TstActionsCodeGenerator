using NLog;
using TestSandBox.Serialization;

namespace TestSandBox.SerializableObjects
{
    public class SerializableObjectPo: BaseSerializableObjectPo
    {

    }

    public class SerializableObject : BaseSerializableObject, ISerializable
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        Type ISerializable.GetPlainObjectType() => GetPlainObjectType();

        protected override Type GetPlainObjectType() => typeof(SerializableObjectPo);

        void ISerializable.OnWritePlainObject(object plainObject, ISerializer serializer)
        {
            OnWritePlainObject(plainObject, serializer);
        }

        protected override void OnWritePlainObject(object plainObject, ISerializer serializer)
        {
            base.OnWritePlainObject(plainObject, serializer);

            OnWritePlainObject((SerializableObjectPo)plainObject, serializer);
        }

        private void OnWritePlainObject(SerializableObjectPo plainObject, ISerializer serializer)
        {
            _logger.Info("SerializableObject: OnWritePlainObject");
        }

        void ISerializable.OnReadPlainObject(object plainObject, IDeserializer deserializer)
        {
            OnReadPlainObject(plainObject, deserializer);
        }

        protected override void OnReadPlainObject(object plainObject, IDeserializer deserializer)
        {
            base.OnReadPlainObject(plainObject, deserializer);

            OnReadPlainObject((SerializableObjectPo)plainObject, deserializer);
        }

        private void OnReadPlainObject(SerializableObjectPo plainObject, IDeserializer deserializer)
        {
            _logger.Info("SerializableObject: OnReadPlainObject");
        }
    }
}
