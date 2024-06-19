using System;

namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class SoundBank : Resource
    {
        public ushort EventsCount { get; set; }
        public ushort ResourcesCount { get; set; }
        public Pointer EventsPointer { get; set; }
        public Pointer ResourcesPointer { get; set; }
        public Pointer DataBufferPointer { get; set; }

        public Pointer<SoundEvent>[] Events { get; set; }
        public Pointer<SoundResource>[] Resources { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            EventsCount = s.Serialize<ushort>(EventsCount, name: nameof(EventsCount));
            ResourcesCount = s.Serialize<ushort>(ResourcesCount, name: nameof(ResourcesCount));
            EventsPointer = s.SerializePointer(EventsPointer, anchor: Offset, name: nameof(EventsPointer));
            ResourcesPointer = s.SerializePointer(ResourcesPointer, anchor: Offset, name: nameof(ResourcesPointer));
            DataBufferPointer = s.SerializePointer(DataBufferPointer, anchor: Offset, name: nameof(DataBufferPointer));

            s.DoAt(EventsPointer, () => Events = s.SerializePointerArray(Events, EventsCount, anchor: Offset, nullValue: UInt32.MaxValue, name: nameof(Events)));
            Events?.ResolveObject(s);

            s.DoAt(ResourcesPointer, () => Resources = s.SerializePointerArray(Resources, ResourcesCount, anchor: Offset, nullValue: UInt32.MaxValue, name: nameof(Resources)));
            Resources?.ResolveObject(s, (x, _) => x.Pre_SoundBank = this);
        }
    }
}