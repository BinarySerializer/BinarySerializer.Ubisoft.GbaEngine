namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class MechModel : Resource
    {
        public FixedPointInt32[] Params { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            Params = s.SerializeObjectArray<FixedPointInt32>(Params, Size / 4, x => x.Pre_PointPosition = 16, name: nameof(Params));

            if (Size % 4 != 0)
                s.Log($"Unserialized mech params!");
        }
    }
}