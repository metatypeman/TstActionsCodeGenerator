using NLog;
using TestSandBox.Serialization;

namespace TestSandBox.SerializableObjects
{
    public class BaseSerializableObjectPo
    {

    }

    public class BaseSerializableObject: ISerializable
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        Type ISerializable.GetPlainObjectType() => GetPlainObjectType();

        protected virtual Type GetPlainObjectType() => typeof(BaseSerializableObjectPo);

        void ISerializable.OnWritePlainObject(object plainObject, ISerializer serializer)
        {
            OnWritePlainObject(plainObject, serializer);
        }

        protected virtual void OnWritePlainObject(object plainObject, ISerializer serializer)
        {
            OnWritePlainObject((BaseSerializableObjectPo)plainObject, serializer);
        }

        private void OnWritePlainObject(BaseSerializableObjectPo plainObject, ISerializer serializer)
        {
            _logger.Info("BaseSerializableObject: OnWritePlainObject");
        }

        void ISerializable.OnReadPlainObject(object plainObject, IDeserializer deserializer)
        {
            OnReadPlainObject(plainObject, deserializer);
        }

        protected virtual void OnReadPlainObject(object plainObject, IDeserializer deserializer)
        {
            OnReadPlainObject((BaseSerializableObjectPo)plainObject, deserializer);
        }

        private void OnReadPlainObject(BaseSerializableObjectPo plainObject, IDeserializer deserializer)
        {
            _logger.Info("BaseSerializableObject: OnReadPlainObject");
        }
    }
}
