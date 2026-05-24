namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class MechModel : Resource
    {
        public Q16_16[] Params { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            Params = s.SerializeIntoArray<Q16_16>(Params, Size / 4, Q16_16.SerializeInto, name: nameof(Params));

            if (Size % 4 != 0)
                s.Log("Unserialized mech params!");
        }
    }
}