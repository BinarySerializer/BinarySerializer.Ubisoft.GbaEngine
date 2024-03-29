﻿namespace BinarySerializer.Ubisoft.GbaEngine.Rayman3
{
    public class LevelInfo : BinarySerializable
    {
        public Rayman3SoundEvent StartMusicSoundEvent { get; set; }
        public Rayman3SoundEvent StopMusicSoundEvent { get; set; }

        public ushort GlobalLumsIndex { get; set; }
        public ushort GlobalCagesIndex { get; set; }

        public byte LumsCount { get; set; }
        public byte CagesCount { get; set; }

        public bool HasBlueLum { get; set; }

        public ushort ClassSize { get; set; }
        public Pointer ClassConstructorPointer { get; set; }

        public byte NextLevelId { get; set; }
        public byte LevelCurtainActorId { get; set; }
        public ushort NameTextId { get; set; }

        public Rayman3SoundEvent StartSpecialMusicSoundEvent { get; set; } // Used for enemy music and teensies in hub worlds

        public override void SerializeImpl(SerializerObject s)
        {
            StartMusicSoundEvent = s.Serialize<Rayman3SoundEvent>(StartMusicSoundEvent, name: nameof(StartMusicSoundEvent));
            StopMusicSoundEvent = s.Serialize<Rayman3SoundEvent>(StopMusicSoundEvent, name: nameof(StopMusicSoundEvent));
            
            GlobalLumsIndex = s.Serialize<ushort>(GlobalLumsIndex, name: nameof(GlobalLumsIndex));
            GlobalCagesIndex = s.Serialize<ushort>(GlobalCagesIndex, name: nameof(GlobalCagesIndex));
            
            LumsCount = s.Serialize<byte>(LumsCount, name: nameof(LumsCount));
            CagesCount = s.Serialize<byte>(CagesCount, name: nameof(CagesCount));
            
            HasBlueLum = s.Serialize<bool>(HasBlueLum, name: nameof(HasBlueLum));
            s.SerializePadding(1, logIfNotNull: true);
            
            ClassSize = s.Serialize<ushort>(ClassSize, name: nameof(ClassSize));
            s.SerializePadding(2, logIfNotNull: true);
            ClassConstructorPointer = s.SerializePointer(ClassConstructorPointer, name: nameof(ClassConstructorPointer));

            NextLevelId = s.Serialize<byte>(NextLevelId, name: nameof(NextLevelId));
            LevelCurtainActorId = s.Serialize<byte>(LevelCurtainActorId, name: nameof(LevelCurtainActorId));
            NameTextId = s.Serialize<ushort>(NameTextId, name: nameof(NameTextId));
            StartSpecialMusicSoundEvent = s.Serialize<Rayman3SoundEvent>(StartSpecialMusicSoundEvent, name: nameof(StartSpecialMusicSoundEvent));
            s.SerializePadding(2, logIfNotNull: true);
        }
    }
}
